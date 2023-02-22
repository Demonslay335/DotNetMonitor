using HarmonyLib;
using System;
using System.Reflection;

namespace DotNetMonitor.Patches
{
    [HarmonyPatch(typeof(Environment))]
    class EnvironmentPatch
    {
        [HarmonyPrefix]
        [HarmonyPatch("Exit", new[] { typeof(int) })]
        static bool PrefixExit(int exitCode)
        {
            MainForm.DispatchApiCall(new CallStruct
            {
                Instance = "Environment",
                MethodName = "Exit",
                Parameters = MethodBase.GetCurrentMethod().GetParameters().WithValues(new CallLookup
                {
                    [nameof(exitCode)] = exitCode
                })
            });

            // Exiting the environment this way kills our entire process
            return false;
        }
    }
}
