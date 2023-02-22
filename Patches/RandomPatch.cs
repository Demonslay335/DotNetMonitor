using System;
using System.Reflection;
using HarmonyLib;

namespace DotNetMonitor.Patches
{
    [HarmonyPatch(typeof(Random))]
    class RandomPatch
    {
        [HarmonyPrefix]
        [HarmonyPatch(MethodType.Constructor, new[] { typeof(int) })]
        static void PrefixConstructor(Random __instance, int Seed)
        {
            MainForm.DispatchApiCall(new CallStruct
            {
                Instance = __instance,
                MethodName = "ctor",
                Parameters = MethodBase.GetCurrentMethod().GetParameters().WithValues(new CallLookup
                {
                    [nameof(Seed)] = Seed
                }),
            });
        }

        [HarmonyPostfix]
        [HarmonyPatch("Next", new Type[] { })]
        static void PostfixNext(Random __instance, int __result)
        {
            MainForm.DispatchApiCall(new CallStruct
            {
                Instance = __instance,
                MethodName = "Next",
                Parameters = MethodBase.GetCurrentMethod().GetParameters().WithValues(new CallLookup
                {
                    [nameof(__result)] = __result
                })
            });
        }

        [HarmonyPostfix]
        [HarmonyPatch("Next", new[] { typeof(int), typeof(int) })]
        static void PostfixNext(Random __instance, int minValue, int maxValue, int __result)
        {
            MainForm.DispatchApiCall(new CallStruct
            {
                Instance = __instance,
                MethodName = "Next",
                Parameters = MethodBase.GetCurrentMethod().GetParameters().WithValues(new CallLookup
                {
                    [nameof(minValue)] = minValue,
                    [nameof(maxValue)] = maxValue,
                    [nameof(__result)] = __result
                }),
            });
        }

        [HarmonyPostfix]
        [HarmonyPatch("Next", new[] { typeof(int) })]
        static void PostfixNext(Random __instance, int maxValue, int __result)
        {
            MainForm.DispatchApiCall(new CallStruct
            {
                Instance = __instance,
                MethodName = "Next",
                Parameters = MethodBase.GetCurrentMethod().GetParameters().WithValues(new CallLookup
                {
                    [nameof(maxValue)] = maxValue,
                    [nameof(__result)] = __result
                }),
            });
        }

        [HarmonyPostfix]
        [HarmonyPatch("NextBytes", new[] { typeof(byte[]) })]
        static void PostfixNextBytes(Random __instance, ref byte[] buffer)
        {
            MainForm.DispatchApiCall(new CallStruct
            {
                Instance = __instance,
                MethodName = "NextBytes",
                Parameters = MethodBase.GetCurrentMethod().GetParameters().WithValues(new CallLookup
                {
                    [nameof(buffer)] = buffer
                }),
            });
        }

        [HarmonyPostfix]
        [HarmonyPatch("NextDouble", new Type[] { })]
        static void PostfixNextDouble(Random __instance, double __result)
        {
            MainForm.DispatchApiCall(new CallStruct
            {
                Instance = __instance,
                MethodName = "NextDouble",
                Parameters = MethodBase.GetCurrentMethod().GetParameters().WithValues(new CallLookup
                {
                    [nameof(__result)] = __result
                }),
            });
        }
    }
}
