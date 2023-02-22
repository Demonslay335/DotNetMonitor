using HarmonyLib;
using System;
using System.Reflection;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel.Design;
using System.Collections.Generic;
using System.Windows.Threading;
using System.Text;
using System.Linq;
using System.IO;
using System.ComponentModel;
using System.Runtime.InteropServices;
using DotNetMonitor.Controls.HexBox;

namespace DotNetMonitor
{
    public partial class MainForm : Form
    {
        static string HarmonyId = "com.dotnetmonitor";
        Harmony Harmony = new Harmony(HarmonyId);

        static int InstanceId = 0;
        static long CallId = 0;

        static bool ConsoleWasSetup = false;

        static List<CallStruct> ApiCalls = new List<CallStruct>();
        static BindingSource CallBindingSource;

        static List<OverridableApi> Apis = new List<OverridableApi>();
        static BindingSource ApiBindingSource;

        static BackgroundWorker AssemblyWorker = new BackgroundWorker();

        static protected Dispatcher _UiDispatcher;

        private HexBox HexBufferBox;

        public struct AssemblyArgs
        {
            public string AssemblyName;
            public MethodInfo Method;
            public object[] Parameters;
        }

        public static class Types
        {
            public static Type UInt16 = typeof(UInt16);
            public static Type UInt16Ref = typeof(UInt16).MakeByRefType();

            public static Type Int16 = typeof(Int16);
            public static Type Int16Ref = typeof(Int16).MakeByRefType();

            public static Type Int32 = typeof(Int32);
            public static Type Int32Ref = typeof(Int32).MakeByRefType();

            public static Type UInt32 = typeof(UInt32);
            public static Type UInt32Ref = typeof(UInt32).MakeByRefType();

            public static Type Int64 = typeof(Int64);
            public static Type Int64Ref = typeof(Int64).MakeByRefType();

            public static Type UInt64 = typeof(UInt64);
            public static Type UInt64Ref = typeof(UInt64).MakeByRefType();

            public static Type Byte = typeof(byte);
            public static Type ByteRef = typeof(byte).MakeByRefType();

            public static Type ByteArray = typeof(byte[]);
            public static Type ByteArrayRef = typeof(byte[]).MakeByRefType();

            public static Type String = typeof(string);
            public static Type StringRef = typeof(string).MakeByRefType();

            public static Type StringArray = typeof(string[]);
            public static Type StringArrayRef = typeof(string[]).MakeByRefType();
        }

        public MainForm()
        {
            InitializeComponent();

            // Designer blows up when adding from there everytime...
            HexBufferBox = new HexBox()
            {
                ColumnInfoVisible = true,
                Dock = DockStyle.Fill,
                Font = new System.Drawing.Font("Courier New", 9F, FontStyle.Regular),
                LineInfoVisible =  true,
                Name = "HexBufferBox",
                VScrollBarVisible = true
            };
            HexBufferBox.ByteProvider = new DynamicByteProvider(new byte[] { });
            HexGroupBox.Controls.Add(HexBufferBox);
            
            // Save a reference to the UI dispatcher
            _UiDispatcher = Dispatcher.CurrentDispatcher;

            ApiBindingSource = new BindingSource() { DataSource = Apis };
            ApiDataViewGrid.AutoGenerateColumns = false;
            ApiDataViewGrid.DataSource = ApiBindingSource;

            CallBindingSource = new BindingSource() { DataSource = ApiCalls };
            CallsDataGridView.AutoGenerateColumns = false;
            CallsDataGridView.DataSource = CallBindingSource;

            ParametersDataGridView.AutoGenerateColumns = false;

            AssemblyWorker.DoWork += ApiWorker_DoWork;
            AssemblyWorker.RunWorkerCompleted += ApiWorker_RunWorkerCompleted;
        }

        #region API Worker (for console assemblies)

        private void ApiWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            AssemblyArgs args = (AssemblyArgs)e.Argument;

            // Attach a console in case the assembly tries to use it
            ConsoleHelper.SetupConsole(args.AssemblyName);
            Console.WriteLine(
                "----- Console spawned by DotNetMonitor -----" + Environment.NewLine +
                "[!] Warning: closing this console by any means before assembly has exited will close DotNetMonitor!" + Environment.NewLine +
                Environment.NewLine
            );
            ConsoleWasSetup = true;            

            args.Method.Invoke(null, args.Parameters);

            if (ConsoleHelper.IsSetup)
            {
                Console.WriteLine(Environment.NewLine + "[+] Assembly exited, press any key to safely close this console.");
                while (!Console.KeyAvailable)
                {
                }
                Console.WriteLine("Exiting...");
                ConsoleHelper.CloseConsole(false);
            }
        }

        private void ApiWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                StatusLabel.Text = "Error with execution of console assembly, see log file";
                FileLog.Log(e.Error.ToString());
            }

            ProcessFinished(e.Error == null);
        }

        #endregion

        public static void DispatchApiCall(CallStruct call)
        {
            call.ID = CallId++;
            call.Time = DateTime.Now;
            call.Ticks = Environment.TickCount;

            FileLog.Log(call.ToCsv());
            
            _UiDispatcher.BeginInvoke(new Action(() => CallBindingSource.Add(call)));
        }

        public void ProcessFinished(bool success)
        {
            if (success)
            {
                StatusLabel.Text = "Assembly exited.";
            }
            Harmony.UnpatchAll();
        }

        #region Events

        private void MainForm_Load(object sender, EventArgs e)
        {
            MonitoredTreeView.ImageList = new ImageList();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Cleanup patches
            Harmony.UnpatchAll(HarmonyId);

            // Close any straggling consoles
            if (ConsoleWasSetup)
            {
                ConsoleHelper.CloseConsole(true);
            }
        }

        private void LoadFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (OpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                string file = OpenFileDialog.FileName;
                try
                {
                    Harmony.PatchAll();

                    // Hide the Application patches, they are just necessary for getting things to run in our context
                    ApiDataViewGrid.DataSource = Harmony.GetPatchedMethods().Where(m => m.DeclaringType.FullName != "System.Windows.Forms.Application").ToApiList();

                    StatusLabel.Text = string.Format("Executing assembly {0}...", file);
                    Assembly assembly = Assembly.LoadFrom(file);

                    Icon appIcon = Icon.ExtractAssociatedIcon(assembly.Location);
                    
                    if (!MonitoredTreeView.ImageList.Images.ContainsKey(assembly.FullName))
                    {
                        Bitmap bitmap = appIcon.ToBitmap();
                        bitmap.MakeTransparent();
                        MonitoredTreeView.ImageList.Images.Add(assembly.FullName, bitmap);
                    }

                    TreeNode node = new TreeNode(assembly.FullName)
                    {
                        ImageKey = assembly.FullName,
                        Tag = InstanceId++
                    };
                    MonitoredTreeView.Nodes.Add(node);

                    // Determine which signature Main is using
                    ParameterInfo[] p = assembly.EntryPoint.GetParameters();
                    object[] parameters = new object[] { };
                    if (p.Length == 1 && p[0].ParameterType == Types.StringArray)
                    {
                       parameters = new object[] { new string[] { Path.GetFileName(file) } };
                    }
                    
                    // Determine console app vs GUI
                    if (Utility.GetFileType(file) == System.Reflection.Emit.PEFileKinds.WindowApplication)
                    {
                        // Run on our own thread
                        assembly.EntryPoint.Invoke(null, parameters);

                        ProcessFinished(true);
                    }
                    else
                    {
                        // We have to run on another thread to keep the UI responsive - not collecting calls :\
                        AssemblyWorker.RunWorkerAsync(new AssemblyArgs
                        {
                            AssemblyName = assembly.FullName,
                            Method = assembly.EntryPoint,
                            Parameters = parameters
                        });
                    }
                }
                catch(HarmonyException ex)
                {
                    StatusLabel.Text = "Harmony error, see log file";
                    FileLog.Log(ex.ToString());
                }
                catch(BadImageFormatException ex)
                {
                    StatusLabel.Text = "File is either not .NET, wrong architecture, or there's a .NET version issue";
                    FileLog.Log(ex.ToString());
                }
                catch (TargetParameterCountException ex)
                {
                    StatusLabel.Text = "Unable to determine correct entrypoint parameters";
                    FileLog.Log(ex.ToString());
                }
                catch (Exception ex)
                {
                    StatusLabel.Text = "General error, see log file";
                    FileLog.Log(ex.ToString());
                }
            }
        }

        private void MonitoredTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            
        }

        private void ApiDataViewGrid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (ApiDataViewGrid.Rows[e.RowIndex].DataBoundItem != null && ApiDataViewGrid.Columns[e.ColumnIndex].DataPropertyName.Contains("."))
            {
                e.Value = Utility.BindProperty(ApiDataViewGrid.Rows[e.RowIndex].DataBoundItem, ApiDataViewGrid.Columns[e.ColumnIndex].DataPropertyName);
            }

            var cell = ApiDataViewGrid.Rows[e.RowIndex].Cells[e.ColumnIndex];

            if (e.ColumnIndex == ApiDataViewGrid.Columns["ApiName"].Index)
            {
                cell.ToolTipText = ApiDataViewGrid.Rows[e.RowIndex].Cells["ApiFullName"].Value.ToString();
            }

            cell.ReadOnly = !(bool)ApiDataViewGrid.Rows[e.RowIndex].Cells["ApiOverridable"].Value;
        }

        private void CallsDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            CallStruct thisCall = (CallStruct)CallsDataGridView.SelectedRows[0].DataBoundItem;

            // Let's highlight any other calls for this same instance
            foreach (DataGridViewRow row in CallsDataGridView.Rows)
            {
                row.DefaultCellStyle.BackColor = (((CallStruct)row.DataBoundItem).Instance == thisCall.Instance) ? Color.Yellow : SystemColors.Window;
            }

            // Display details
            ParametersDataGridView.DataSource = thisCall.Parameters;
        }

        private void CallsDataGridView_CellContextMenuStripNeeded(object sender, DataGridViewCellContextMenuStripNeededEventArgs e)
        {
            DataGridView grid = (DataGridView)sender;

            if(e.RowIndex == -1 || e.ColumnIndex == -1)
            {
                return;
            }

            CallStruct thisCall = (CallStruct)grid.SelectedRows[0].DataBoundItem;

            if (thisCall.Instance.GetType() == typeof(Random))
            {
                e.ContextMenuStrip = RandomContextMenuStrip;
            }
        }

        private void ParametersDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            // Load the raw byte value into the dump view
            if (ParametersDataGridView.SelectedRows.Count > 0)
            {
                ParameterInfoWithValue param = (ParameterInfoWithValue)ParametersDataGridView.SelectedRows[0].DataBoundItem;

                if (param.Value != null)
                {
                    if (param.ParameterType == Types.Byte || param.ParameterType == Types.ByteRef)
                    {
                        HexBufferBox.DisplayBytes(new byte[] { (byte)param.Value });
                    }
                    else if (param.ParameterType == Types.ByteArray || param.ParameterType == Types.ByteArrayRef)
                    {
                        HexBufferBox.DisplayBytes((byte[])param.Value);
                    }
                    else if (param.ParameterType == Types.Int16 || param.ParameterType == Types.Int16Ref)
                    {
                        HexBufferBox.DisplayBytes(BitConverter.GetBytes((Int16)param.Value));
                    }
                    else if (param.ParameterType == Types.UInt16 || param.ParameterType == Types.UInt16Ref)
                    {
                        HexBufferBox.DisplayBytes(BitConverter.GetBytes((UInt16)param.Value));
                    }
                    else if (param.ParameterType == Types.Int32 || param.ParameterType == Types.Int32Ref)
                    {
                        HexBufferBox.DisplayBytes(BitConverter.GetBytes((Int32)param.Value));
                    }
                    else if (param.ParameterType == Types.UInt32 || param.ParameterType == Types.UInt32Ref)
                    {
                        HexBufferBox.DisplayBytes(BitConverter.GetBytes((UInt32)param.Value));
                    }
                    else if (param.ParameterType == Types.Int64 || param.ParameterType == Types.Int64Ref)
                    {
                        HexBufferBox.DisplayBytes(BitConverter.GetBytes((Int64)param.Value));
                    }
                    else if (param.ParameterType == Types.UInt64 || param.ParameterType == Types.UInt64Ref)
                    {
                        HexBufferBox.DisplayBytes(BitConverter.GetBytes((UInt64)param.Value));
                    }
                    else if (param.ParameterType == Types.String || param.ParameterType == Types.StringRef)
                    {
                        HexBufferBox.DisplayBytes(Encoding.UTF8.GetBytes((string)param.Value));
                    }
                }
            }
        }

        #endregion

        private void ReconstructRandomSequenceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CallsDataGridView.SelectedRows.Count == 0)
            {
                return;
            }

            CallStruct thisCall = (CallStruct)CallsDataGridView.SelectedRows[0].DataBoundItem;

            int seed = 0;

            // Gather a list of all the calls from this instance
            List<CallStruct> calls = new List<CallStruct>();
            CallStruct currentCall;
            foreach(DataGridViewRow row in CallsDataGridView.Rows)
            {
                currentCall = (CallStruct)row.DataBoundItem;

                if (currentCall.Instance == thisCall.Instance)
                {
                    // Harvest the seed from the constructor call
                    ParameterInfoWithValue seedParam = currentCall.Parameters.FirstOrDefault(p => p.Name == "Seed");
                    if (seedParam != default(ParameterInfoWithValue))
                    {
                        seed = (int)seedParam.Value;
                    }
                    else if(currentCall.MethodName == "Next" || currentCall.MethodName == "NextDouble")
                    {
                        calls.Add(currentCall);
                    }
                }                
            }

            // Sort by execution time
            calls.Sort((a, b) => a.Time.CompareTo(b.Time));

            string sequence = "Random(" + seed + ") = [" + string.Join(", ", calls.Select(c => c.ReturnValue)) + "]";

            StatusLabel.Text = sequence;

            Clipboard.SetText(sequence);
        }
    }
}
