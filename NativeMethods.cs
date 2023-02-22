using System;
using System.Runtime.InteropServices;

namespace DotNetMonitor
{
    class NativeMethods
    {
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static public extern bool EnableWindow(IntPtr hWnd, bool bEnable);
    }
}
