using HarmonyLib;
using System;
using System.Reflection;
using System.Threading;

namespace DotNetMonitor.Patches
{
    [HarmonyPatch(typeof(Thread))]
    class ThreadPatch
    {
        [HarmonyPrefix]
        [HarmonyPatch(MethodType.Constructor, new[] { typeof(ThreadStart) })]
        static void PrefixConstructor(Thread __instance, ThreadStart start)
        {
            MainForm.DispatchApiCall(new CallStruct
            {
                Instance = __instance,
                MethodName = "ctor",
                Parameters = MethodBase.GetCurrentMethod().GetParameters().WithValues(new CallLookup
                {
                    [nameof(start)] = start
                }),
            });
        }

        [HarmonyPrefix]
        [HarmonyPatch(MethodType.Constructor, new[] { typeof(ParameterizedThreadStart) })]
        static void PrefixConstructor(Thread __instance, ParameterizedThreadStart start)
        {
            MainForm.DispatchApiCall(new CallStruct
            {
                Instance = __instance,
                MethodName = "ctor",
                Parameters = MethodBase.GetCurrentMethod().GetParameters().WithValues(new CallLookup
                {
                    [nameof(start)] = start
                }),
            });
        }

        [HarmonyPrefix]
        [HarmonyPatch(MethodType.Constructor, new[] { typeof(ThreadStart), typeof(int) })]
        static void PrefixConstructor(Thread __instance, ThreadStart start, int maxStackSize)
        {
            MainForm.DispatchApiCall(new CallStruct
            {
                Instance = __instance,
                MethodName = "ctor",
                Parameters = MethodBase.GetCurrentMethod().GetParameters().WithValues(new CallLookup
                {
                    [nameof(start)] = start,
                    [nameof(maxStackSize)] = maxStackSize
                }),
            });
        }

        [HarmonyPrefix]
        [HarmonyPatch(MethodType.Constructor, new[] { typeof(ParameterizedThreadStart), typeof(int) })]
        static void PrefixConstructor(Thread __instance, ParameterizedThreadStart start, int maxStackSize)
        {
            MainForm.DispatchApiCall(new CallStruct
            {
                Instance = __instance,
                MethodName = "ctor",
                Parameters = MethodBase.GetCurrentMethod().GetParameters().WithValues(new CallLookup
                {
                    [nameof(start)] = start,
                    [nameof(maxStackSize)] = maxStackSize
                }),
            });
        }

        [HarmonyPrefix]
        [HarmonyPatch("IsBackground", MethodType.Setter)]
        static void PrefixIsBackground(Thread __instance, bool value)
        {
            MainForm.DispatchApiCall(new CallStruct
            {
                Instance = __instance,
                MethodName = "IsBackground",
                Parameters = MethodBase.GetCurrentMethod().GetParameters().WithValues(new CallLookup
                {
                    [nameof(value)] = value
                }),
            });
        }

        [HarmonyPrefix]
        [HarmonyPatch("Name", MethodType.Setter)]
        static void PrefixName(Thread __instance, string value)
        {
            MainForm.DispatchApiCall(new CallStruct
            {
                Instance = __instance,
                MethodName = "Name",
                Parameters = MethodBase.GetCurrentMethod().GetParameters().WithValues(new CallLookup
                {
                    [nameof(value)] = value
                }),
            });
        }

        [HarmonyPrefix]
        [HarmonyPatch("Sleep", new[] { typeof(TimeSpan) })]
        static bool PrefixSleep(Thread __instance, TimeSpan timeout)
        {
            MainForm.DispatchApiCall(new CallStruct
            {
                Instance = __instance,
                MethodName = "Next",
                Parameters = MethodBase.GetCurrentMethod().GetParameters().WithValues(new CallLookup
                {
                    [nameof(timeout)] = timeout
                })
            });

            // Absorb
            return false;
        }

        [HarmonyPrefix]
        [HarmonyPatch("Sleep", new [] { typeof(int) })]
        static bool PrefixSleep(Thread __instance, int millisecondsTimeout)
        {
            MainForm.DispatchApiCall(new CallStruct
            {
                Instance = __instance,
                MethodName = "Sleep",
                Parameters = MethodBase.GetCurrentMethod().GetParameters().WithValues(new CallLookup
                {
                    [nameof(millisecondsTimeout)] = millisecondsTimeout
                })
            });

            // Aborb
            return false;
        }

        [HarmonyPrefix]
        [HarmonyPatch("Start", new [] { typeof(object) })]
        static void PrefixStart(Thread __instance, object parameter)
        {
            MainForm.DispatchApiCall(new CallStruct
            {
                Instance = __instance,
                MethodName = "Start",
                Parameters = MethodBase.GetCurrentMethod().GetParameters().WithValues(new CallLookup
                {
                    [nameof(parameter)] = parameter
                })
            });
        }

        [HarmonyPrefix]
        [HarmonyPatch("Start", new Type[] { })]
        static void PrefixStart(Thread __instance)
        {
            MainForm.DispatchApiCall(new CallStruct
            {
                Instance = __instance,
                MethodName = "Start",
                Parameters = MethodBase.GetCurrentMethod().GetParameters().WithValues()
            });
        }

        [HarmonyPrefix]
        [HarmonyPatch("Suspend", new Type[] { })]
        static void PrefixSuspend(Thread __instance)
        {
            MainForm.DispatchApiCall(new CallStruct
            {
                Instance = __instance,
                MethodName = "Suspend",
                Parameters = MethodBase.GetCurrentMethod().GetParameters().WithValues()
            });
        }

        [HarmonyPrefix]
        [HarmonyPatch("Resume", new Type[] { })]
        static void PrefixResume(Thread __instance)
        {
            MainForm.DispatchApiCall(new CallStruct
            {
                Instance = __instance,
                MethodName = "Resume",
                Parameters = MethodBase.GetCurrentMethod().GetParameters().WithValues()
            });
        }

        [HarmonyPrefix]
        [HarmonyPatch("Join", new [] { typeof(int) })]
        static void PrefixJoin(Thread __instance, int millisecondsTimeout)
        {
            MainForm.DispatchApiCall(new CallStruct
            {
                Instance = __instance,
                MethodName = "Join",
                Parameters = MethodBase.GetCurrentMethod().GetParameters().WithValues(new CallLookup
                {
                    [nameof(millisecondsTimeout)] = millisecondsTimeout
                })
            });
        }

        [HarmonyPrefix]
        [HarmonyPatch("Join", new Type[] { })]
        static void PrefixJoin(Thread __instance)
        {
            MainForm.DispatchApiCall(new CallStruct
            {
                Instance = __instance,
                MethodName = "Join",
                Parameters = MethodBase.GetCurrentMethod().GetParameters().WithValues()
            });
        }

        [HarmonyPrefix]
        [HarmonyPatch("Join", new[] { typeof(TimeSpan) })]
        static void PrefixJoin(Thread __instance, TimeSpan timeout)
        {
            MainForm.DispatchApiCall(new CallStruct
            {
                Instance = __instance,
                MethodName = "Join",
                Parameters = MethodBase.GetCurrentMethod().GetParameters().WithValues(new CallLookup
                {
                    [nameof(timeout)] = timeout
                })
            });
        }

        [HarmonyPrefix]
        [HarmonyPatch("Abort", new[] { typeof(object) })]
        static void PrefixAbort(Thread __instance, object stateInfo)
        {
            MainForm.DispatchApiCall(new CallStruct
            {
                Instance = __instance,
                MethodName = "Abort",
                Parameters = MethodBase.GetCurrentMethod().GetParameters().WithValues(new CallLookup
                {
                    [nameof(stateInfo)] = stateInfo
                })
            });
        }

        [HarmonyPrefix]
        [HarmonyPatch("Abort", new Type[] { })]
        static void PrefixAbort(Thread __instance)
        {
            MainForm.DispatchApiCall(new CallStruct
            {
                Instance = __instance,
                MethodName = "Abort",
                Parameters = MethodBase.GetCurrentMethod().GetParameters().WithValues()
            });
        }
    }
}
