using Microsoft.Win32.SafeHandles;
using System;
using System.IO;
using System.Runtime.InteropServices;

namespace DotNetMonitor
{
    // https://developercommunity.visualstudio.com/comments/22335/view.html
    // https://stackoverflow.com/questions/49145316/why-no-text-colors-after-using-createfileconout-to-redirect-the-console/49145317#49145317
    public class ConsoleHelper
    {
        // defines for commandline output
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool AttachConsole(int dwProcessId);

        public const int ATTACH_PARENT_PROCESS = -1;

        [DllImport("kernel32.dll", EntryPoint = "AllocConsole", SetLastError = true, CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        private static extern int AllocConsole();

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern int FreeConsole();

        [DllImport("kernel32.dll", CharSet = CharSet.Auto)] //, EntryPoint = "CreateFileW", SetLastError = true, CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall
        private static extern IntPtr CreateFileW(
            string lpFileName,
            UInt32 dwDesiredAccess,
            UInt32 dwShareMode,
            IntPtr lpSecurityAttributes,
            UInt32 dwCreationDisposition,
            UInt32 dwFlagsAndAttributes,
            IntPtr hTemplateFile
        );

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool CloseHandle(IntPtr hObject);

        [DllImport("kernel32.dll")]
        static extern bool SetStdHandle(int nStdHandle, IntPtr hHandle);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool GetConsoleMode(IntPtr hConsoleHandle, out uint lpMode);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool SetConsoleMode(IntPtr hConsoleHandle, uint dwMode);

        [DllImport("user32.dll", SetLastError = true)]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll", EntryPoint = "GetSystemMenu")]
        extern static IntPtr GetSystemMenu(IntPtr hWnd, IntPtr bRevert);
        [DllImport("user32.dll", EntryPoint = "RemoveMenu")]
        extern static int RemoveMenu(IntPtr hMenu, int nPos, int flags);

        [DllImport("kernel32")]
        static public extern bool SetConsoleCtrlHandler(HandlerRoutine HandlerRoutine, bool Add);

        public delegate bool HandlerRoutine(CtrlTypes CtrlType);

        public enum CtrlTypes
        {
            CTRL_C_EVENT = 0,
            CTRL_BREAK_EVENT,
            CTRL_CLOSE_EVENT,
            CTRL_LOGOFF_EVENT = 5,
            CTRL_SHUTDOWN_EVENT
        }

        private const int MY_CODE_PAGE = 437;
        private const uint GENERIC_READ = 0x80000000;
        private const uint GENERIC_WRITE = 0x40000000;
        private const uint FILE_SHARE_WRITE = 0x2;
        private const uint OPEN_EXISTING = 0x3;

        const int STD_INPUT_HANDLE = -10;
        const int STD_OUTPUT_HANDLE = -11;
        const int STD_ERROR_HANDLE = -12;

        const int ENABLE_VIRTUAL_TERMINAL_INPUT = 0x200;

        const int SW_HIDE = 0x00;
        const int SW_SHOW = 0x05;

        static private SafeFileHandle OutSafeHandle;
        static private SafeFileHandle InSafeHandle;

        static public bool IsSetup = false;

        static public void SetupConsole(string title)
        {
            if (!IsSetup)
            {
                // Create console
                AllocConsole();

                // Disable the console close button           
                IntPtr CLOSE_MENU = GetSystemMenu(GetConsoleWindow(), IntPtr.Zero);
                int SC_CLOSE = 0xF060;
                RemoveMenu(CLOSE_MENU, SC_CLOSE, 0x0);

                // Disable Ctrl+C
                SetConsoleCtrlHandler(null, true);

                try
                {
                    var outFile = CreateFileW("CONOUT$", GENERIC_WRITE | GENERIC_READ, FILE_SHARE_WRITE, IntPtr.Zero, OPEN_EXISTING, /*FILE_ATTRIBUTE_NORMAL*/0, IntPtr.Zero);
                    var inFile = CreateFileW("CONIN$", GENERIC_WRITE | GENERIC_READ, FILE_SHARE_WRITE, IntPtr.Zero, OPEN_EXISTING, /*FILE_ATTRIBUTE_NORMAL*/0, IntPtr.Zero);

                    OutSafeHandle = new SafeFileHandle(outFile, true);
                    InSafeHandle = new SafeFileHandle(inFile, true);

                    SetStdHandle(STD_OUTPUT_HANDLE, outFile);
                    SetStdHandle(STD_INPUT_HANDLE, inFile);

                    var outFs = new FileStream(OutSafeHandle, FileAccess.Write);
                    var inFs = new FileStream(InSafeHandle, FileAccess.Read);

                    var writer = new StreamWriter(outFs) { AutoFlush = true };
                    var reader = new StreamReader(inFs);

                    Console.SetOut(writer);
                    Console.SetIn(reader);
                    Console.SetError(writer);

                    if (GetConsoleMode(outFile, out var cMode))
                    {
                        SetConsoleMode(outFile, cMode | ENABLE_VIRTUAL_TERMINAL_INPUT);
                    }

                    if (GetConsoleMode(inFile, out cMode))
                    {
                        SetConsoleMode(inFile, cMode | ENABLE_VIRTUAL_TERMINAL_INPUT);
                    }

                    Console.Title = title;
                }
                catch (Exception)
                {
                    // Ignore
                }

                IsSetup = true;
            }
            else
            {
                // Clear buffers and reuse
                Console.Clear();
                while (Console.KeyAvailable)
                {
                    Console.ReadKey(false);
                }
                ShowWindow(GetConsoleWindow(), SW_SHOW);
            }
        }

        static public void CloseConsole(bool destroy)
        {
            if (destroy)
            {
                // Detach console
                OutSafeHandle.Dispose();
                InSafeHandle.Dispose();
                FreeConsole();
                IsSetup = false;
            }
            else
            {
                ShowWindow(GetConsoleWindow(), SW_HIDE);
            }
        }
    }
}
