using HarmonyLib;
using System;
using System.Reflection;
using System.Security.Cryptography;

namespace DotNetMonitor.Patches
{
    [HarmonyPatch(typeof(RandomNumberGenerator))]
    class RandomNumberGeneratorPatch
    {
        [HarmonyPostfix]
        [HarmonyPatch("Create", new Type[] { })]
        static void PostfixCreate(RandomNumberGenerator __instance, RandomNumberGenerator __result)
        {
            MainForm.DispatchApiCall(new CallStruct
            {
                Instance = __instance,
                MethodName = "Create",
                Parameters = MethodBase.GetCurrentMethod().GetParameters().WithValues(new CallLookup
                {
                    [nameof(__result)] = __result
                }),
            });
        }

        [HarmonyPostfix]
        [HarmonyPatch("Create", new[] { typeof(string) })]
        static void PostfixCreate(RandomNumberGenerator __instance, string rngName, RandomNumberGenerator __result)
        {
            MainForm.DispatchApiCall(new CallStruct
            {
                Instance = __instance,
                MethodName = "Create",
                Parameters = MethodBase.GetCurrentMethod().GetParameters().WithValues(new CallLookup
                {
                    [nameof(rngName)] = rngName,
                    [nameof(__result)] = __result
                }),
            });
        }
        /* Abstract method
        [HarmonyPostfix]
        [HarmonyPatch("GetBytes", new[] { typeof(byte[]) })]
        static void PostfixGetBytes(RandomNumberGenerator __instance, byte[] data)
        {
            MainForm.DispatchApiCall(new CallStruct
            {
                Instance = __instance,
                MethodName = "GetBytes",
                Parameters = MethodBase.GetCurrentMethod().GetParameters().WithValues(new CallLookup
                {
                    [nameof(data)] = data
                }),
            });
        }
        */
        [HarmonyPostfix]
        [HarmonyPatch("GetBytes", new[] { typeof(byte[]), typeof(int), typeof(int) })]
        static void PostfixGetBytes(RandomNumberGenerator __instance, byte[] data, int offset, int count)
        {
            MainForm.DispatchApiCall(new CallStruct
            {
                Instance = __instance,
                MethodName = "GetBytes",
                Parameters = MethodBase.GetCurrentMethod().GetParameters().WithValues(new CallLookup
                {
                    [nameof(data)] = data,
                    [nameof(offset)] = offset,
                    [nameof(count)] = count
                }),
            });
        }
        /* Throws InvalidProgramException
        [HarmonyPostfix]
        [HarmonyPatch("GetNonZeroBytes", new[] { typeof(byte[]) })]
        static void PostfixGetNonZeroBytes(RandomNumberGenerator __instance, byte[] data)
        {
            MainForm.DispatchApiCall(new CallStruct
            {
                Instance = __instance,
                MethodName = "GetNonZeroBytes",
                Parameters = MethodBase.GetCurrentMethod().GetParameters().WithValues(new CallLookup
                {
                    [nameof(data)] = data
                }),
            });
        }
        */
    }
}
