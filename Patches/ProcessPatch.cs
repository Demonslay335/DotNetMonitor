using HarmonyLib;
using System;
using System.Diagnostics;
using System.Reflection;
using System.Security;

namespace DotNetMonitor.Patches
{
    [HarmonyPatch(typeof(Process))]
    class ProcessPatch
    {
        [HarmonyPrefix]
        [HarmonyPatch("Start", new[] { typeof(string), typeof(string) })]
        static public void PrefixStart(Process __instance, string fileName, string arguments, Process __result)
        {
            MainForm.DispatchApiCall(new CallStruct
            {
                Instance = __instance,
                MethodName = "Start",
                Parameters = MethodBase.GetCurrentMethod().GetParameters().WithValues(new CallLookup
                {
                    [nameof(fileName)] = fileName,
                    [nameof(arguments)] = arguments,
                    [nameof(__result)] = __result
                }),
            });
        }

        [HarmonyPrefix]
        [HarmonyPatch("Start", new[] { typeof(ProcessStartInfo) })]
        static public void PrefixStart(Process __instance, ProcessStartInfo startInfo, Process __result)
        {
            MainForm.DispatchApiCall(new CallStruct
            {
                Instance = __instance,
                MethodName = "Start",
                Parameters = MethodBase.GetCurrentMethod().GetParameters().WithValues(new CallLookup
                {
                    [nameof(startInfo)] = startInfo,
                    [nameof(__result)] = __result
                }),
            });
        }

        [HarmonyPrefix]
        [HarmonyPatch("Start", new[] { typeof(string)})]
        static public void PrefixStart(Process __instance, string fileName, Process __result)
        {
            MainForm.DispatchApiCall(new CallStruct
            {
                Instance = __instance,
                MethodName = "Start",
                Parameters = MethodBase.GetCurrentMethod().GetParameters().WithValues(new CallLookup
                {
                    [nameof(fileName)] = fileName,
                    [nameof(__result)] = __result
                }),
            });
        }

        [HarmonyPrefix]
        [HarmonyPatch("Start", new[] { typeof(string), typeof(string), typeof(string), typeof(SecureString), typeof(string) })]
        static public void PrefixStart(Process __instance, string fileName, string arguments, string userName, SecureString password, string domain, Process __result)
        {
            MainForm.DispatchApiCall(new CallStruct
            {
                Instance = __instance,
                MethodName = "Start",
                Parameters = MethodBase.GetCurrentMethod().GetParameters().WithValues(new CallLookup
                {
                    [nameof(fileName)] = fileName,
                    [nameof(arguments)] = arguments,
                    [nameof(userName)] = userName,
                    [nameof(password)] = password,
                    [nameof(domain)] = domain,
                    [nameof(__result)] = __result
                }),
            });
        }

        [HarmonyPrefix]
        [HarmonyPatch("Start", new[] { typeof(string), typeof(string), typeof(SecureString), typeof(string) })]
        static public void PrefixStart(Process __instance, string fileName, string userName, SecureString password, string domain, Process __result)
        {
            MainForm.DispatchApiCall(new CallStruct
            {
                Instance = __instance,
                MethodName = "Start",
                Parameters = MethodBase.GetCurrentMethod().GetParameters().WithValues(new CallLookup
                {
                    [nameof(fileName)] = fileName,
                    [nameof(userName)] = userName,
                    [nameof(password)] = password,
                    [nameof(domain)] = domain,
                    [nameof(__result)] = __result
                }),
            });
        }

        [HarmonyPrefix]
        [HarmonyPatch("Start", new Type[] { })]
        static public void PrefixStart(Process __instance, bool __result)
        {
            MainForm.DispatchApiCall(new CallStruct
            {
                Instance = __instance,
                MethodName = "Start",
                Parameters = MethodBase.GetCurrentMethod().GetParameters().WithValues(new CallLookup
                {
                    [nameof(__result)] = __result
                }),
            });
        }

        [HarmonyPrefix]
        [HarmonyPatch("Kill", new Type[] { })]
        static public bool PrefixKill(Process __instance)
        {
            MainForm.DispatchApiCall(new CallStruct
            {
                Instance = __instance,
                MethodName = "Kill",
                Parameters = MethodBase.GetCurrentMethod().GetParameters().WithValues(),
            });

            // Intercept attempts to kill our process
            return __instance.Id != Process.GetCurrentProcess().Id;
        }

        [HarmonyPrefix]
        [HarmonyPatch("WaitForExit", new[] { typeof(int) })]
        static public void PrefixWaitForExit(Process __instance, int milliseconds, bool __result)
        {
            MainForm.DispatchApiCall(new CallStruct
            {
                Instance = __instance,
                MethodName = "WaitForExit",
                Parameters = MethodBase.GetCurrentMethod().GetParameters().WithValues(new CallLookup
                {
                    [nameof(milliseconds)] = milliseconds,
                    [nameof(__result)] = __result
                }),
            });
        }

        [HarmonyPrefix]
        [HarmonyPatch("WaitForExit", new Type[] { })]
        static public void PrefixWaitForExit(Process __instance)
        {
            MainForm.DispatchApiCall(new CallStruct
            {
                Instance = __instance,
                MethodName = "WaitForExit",
                Parameters = MethodBase.GetCurrentMethod().GetParameters().WithValues(),
            });
        }
    }
}
