using HarmonyLib;
using System;
using System.Reflection;
using System.Security.Cryptography;

namespace DotNetMonitor.Patches
{
    [HarmonyPatch(typeof(SymmetricAlgorithm))]
    class SymmetricAlgorithmPatch
    {
        [HarmonyPrefix]
        [HarmonyPatch("FeedbackSize", MethodType.Setter)]
        static void PrefixFeedbackSize(SymmetricAlgorithm __instance, int value)
        {
            MainForm.DispatchApiCall(new CallStruct
            {
                Instance = __instance,
                MethodName = "FeedbackSize",
                Parameters = MethodBase.GetCurrentMethod().GetParameters().WithValues(new CallLookup
                {
                    [nameof(value)] = value
                }),
            });
        }
        
        [HarmonyPrefix]
        [HarmonyPatch("KeySize", MethodType.Setter)]
        static void PrefixKeySize(SymmetricAlgorithm __instance, int value)
        {
            MainForm.DispatchApiCall(new CallStruct
            {
                Instance = __instance,
                MethodName = "KeySize",
                Parameters = MethodBase.GetCurrentMethod().GetParameters().WithValues(new CallLookup
                {
                    [nameof(value)] = value
                }),
            });
        }
        
        [HarmonyPrefix]
        [HarmonyPatch("Key", MethodType.Setter)]
        static void PrefixKey(SymmetricAlgorithm __instance, byte[] value)
        {
            MainForm.DispatchApiCall(new CallStruct
            {
                Instance = __instance,
                MethodName = "Key",
                Parameters = MethodBase.GetCurrentMethod().GetParameters().WithValues(new CallLookup
                {
                    [nameof(value)] = value
                }),
            });
        }
        
        [HarmonyPrefix]
        [HarmonyPatch("IV", MethodType.Setter)]
        static void PrefixIV(SymmetricAlgorithm __instance, byte[] value)
        {
            MainForm.DispatchApiCall(new CallStruct
            {
                Instance = __instance,
                MethodName = "IV",
                Parameters = MethodBase.GetCurrentMethod().GetParameters().WithValues(new CallLookup
                {
                    [nameof(value)] = value
                }),
            });
        }
        
        [HarmonyPrefix]
        [HarmonyPatch("BlockSize", MethodType.Setter)]
        static void PrefixBlockSize(SymmetricAlgorithm __instance, int value)
        {
            MainForm.DispatchApiCall(new CallStruct
            {
                Instance = __instance,
                MethodName = "BlockSize",
                Parameters = MethodBase.GetCurrentMethod().GetParameters().WithValues(new CallLookup
                {
                    [nameof(value)] = value
                }),
            });
        }
        
        [HarmonyPrefix]
        [HarmonyPatch("Padding", MethodType.Setter)]
        static void PrefixPaddingMode(SymmetricAlgorithm __instance, PaddingMode value)
        {
            MainForm.DispatchApiCall(new CallStruct
            {
                Instance = __instance,
                MethodName = "Padding",
                Parameters = MethodBase.GetCurrentMethod().GetParameters().WithValues(new CallLookup
                {
                    [nameof(value)] = value
                }),
            });
        }
        
        [HarmonyPrefix]
        [HarmonyPatch("Mode", MethodType.Setter)]
        static void PrefixCipherMode(SymmetricAlgorithm __instance, CipherMode value)
        {
            MainForm.DispatchApiCall(new CallStruct
            {
                Instance = __instance,
                MethodName = "Mode",
                Parameters = MethodBase.GetCurrentMethod().GetParameters().WithValues(new CallLookup
                {
                    [nameof(value)] = value
                }),
            });
        }

        [HarmonyPostfix]
        [HarmonyPatch("Create", new Type[] { })]
        static void PostfixCreate(SymmetricAlgorithm __instance, SymmetricAlgorithm __result)
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
        static void PostfixCreate(SymmetricAlgorithm __instance, string algName, SymmetricAlgorithm __result)
        {
            MainForm.DispatchApiCall(new CallStruct
            {
                Instance = __instance,
                MethodName = "Create",
                Parameters = MethodBase.GetCurrentMethod().GetParameters().WithValues(new CallLookup
                {
                    [nameof(algName)] = algName,
                    [nameof(__result)] = __result
                }),
            });
        }
        
        [HarmonyPostfix]
        [HarmonyPatch("CreateDecryptor", new Type[] {})]
        static void PostfixCreateDecryptor(SymmetricAlgorithm __instance, ICryptoTransform __result)
        {
            MainForm.DispatchApiCall(new CallStruct
            {
                Instance = __instance,
                MethodName = "CreateDecryptor",
                Parameters = MethodBase.GetCurrentMethod().GetParameters().WithValues(new CallLookup
                {
                    [nameof(__result)] = __result
                }),
            });
        }

        [HarmonyPostfix]
        [HarmonyPatch("CreateEncryptor", new Type[] {})]
        static void PostfixCreateEncryptor(SymmetricAlgorithm __instance, ICryptoTransform __result)
        {
            MainForm.DispatchApiCall(new CallStruct
            {
                Instance = __instance,
                MethodName = "CreateEncryptor",
                Parameters = MethodBase.GetCurrentMethod().GetParameters().WithValues(new CallLookup
                {
                    [nameof(__result)] = __result
                }),
            });
        }
        
    }
}
