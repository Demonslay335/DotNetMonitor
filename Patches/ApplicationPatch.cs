using HarmonyLib;
using System;
using System.Windows.Forms;

namespace DotNetMonitor.Patches
{
    [HarmonyPatch(typeof(Application))]
    class ApplicationPatch
    {
        [HarmonyFinalizer]
        [HarmonyPatch("SetCompatibleTextRenderingDefault", new[] { typeof(bool) })]
        static Exception FinalizerSetCompatibleTextRenderingDefault()
        {
            // Absorb exceptions caused by us launching a GUI app - we already initialized things as a GUI
            return null;
        }

        [HarmonyFinalizer]
        [HarmonyPatch("Run", new[] { typeof(Form) })]
        static Exception FinalizerRun(Form mainForm, Exception __exception)
        {
            // Application.Run can't be run more than once in a GUI thread, and Show() returns immediately
            // We want ShowDialog() so we still pump the UI, but without disabling our main window
            // Cannot use Show(), because it causes the main form to be on a different thread than anything it spawns
            mainForm.Load += (s, e) =>
            {
                Program.MainFormInstance.Enabled = true;
                NativeMethods.EnableWindow(Program.MainFormInstance.Handle, true);
            };
            mainForm.ShowDialog();
            return null;
        }
    }
}
