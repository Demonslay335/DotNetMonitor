using HarmonyLib;
using System;
using System.Reflection;
using System.Security.Cryptography;

namespace DotNetMonitor.Patches
{
    [HarmonyPatch(typeof(RNGCryptoServiceProvider))]
    class RNGCryptoServiceProviderPatch
    {
        [HarmonyPrefix]
        [HarmonyPatch(MethodType.Constructor, new Type[] { })]
        static void PrefixConstructor(RNGCryptoServiceProvider __instance)
        {
            MainForm.DispatchApiCall(new CallStruct
            {
                Instance = __instance,
                MethodName = "ctor",
                Parameters = MethodBase.GetCurrentMethod().GetParameters().WithValues(),
            });
        }

        [HarmonyPrefix]
        [HarmonyPatch(MethodType.Constructor, new[] { typeof(string) })]
        static void PrefixConstructor(RNGCryptoServiceProvider __instance, string str)
        {
            MainForm.DispatchApiCall(new CallStruct
            {
                Instance = __instance,
                MethodName = "ctor",
                Parameters = MethodBase.GetCurrentMethod().GetParameters().WithValues(new CallLookup
                {
                    [nameof(str)] = str
                }),
            });
        }

        [HarmonyPrefix]
        [HarmonyPatch(MethodType.Constructor, new[] { typeof(byte[]) })]
        static void PrefixConstructor(RNGCryptoServiceProvider __instance, byte[] rgb)
        {
            MainForm.DispatchApiCall(new CallStruct
            {
                Instance = __instance,
                MethodName = "ctor",
                Parameters = MethodBase.GetCurrentMethod().GetParameters().WithValues(new CallLookup
                {
                    [nameof(rgb)] = rgb
                }),
            });
        }

        [HarmonyPrefix]
        [HarmonyPatch(MethodType.Constructor, new[] { typeof(CspParameters) })]
        static void PrefixConstructor(RNGCryptoServiceProvider __instance, CspParameters cspParams)
        {
            MainForm.DispatchApiCall(new CallStruct
            {
                Instance = __instance,
                MethodName = "ctor",
                Parameters = MethodBase.GetCurrentMethod().GetParameters().WithValues(new CallLookup
                {
                    [nameof(cspParams)] = cspParams
                }),
            });
        }

        [HarmonyPostfix]
        [HarmonyPatch("GetBytes", new[] { typeof(byte[]) })]
        static void PostfixGetBytes(RNGCryptoServiceProvider __instance, byte[] data)
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

        [HarmonyPostfix]
        [HarmonyPatch("GetNonZeroBytes", new[] { typeof(byte[]) })]
        static void PostfixGetBytes(RandomNumberGenerator __instance, byte[] data)
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
    }
}
