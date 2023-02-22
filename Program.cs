using System;
using System.Windows.Forms;

namespace DotNetMonitor
{
    class Program
    {
        static public MainForm MainFormInstance;

        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            MainFormInstance = new MainForm();
            Application.Run(MainFormInstance);
        }
    }
}
