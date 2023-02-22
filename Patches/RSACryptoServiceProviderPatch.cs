using HarmonyLib;
using System;
using System.Reflection;
using System.Security.Cryptography;

namespace DotNetMonitor.Patches
{
    [HarmonyPatch(typeof(RSACryptoServiceProvider))]
    class RSACryptoServiceProviderPatch
    {
        [HarmonyPrefix]
        [HarmonyPatch(MethodType.Constructor, new Type[] { })]
        static void PrefixConstructor(RSACryptoServiceProvider __instance)
        {
            MainForm.DispatchApiCall(new CallStruct
            {
                Instance = __instance,
                MethodName = "ctor",
                Parameters = MethodBase.GetCurrentMethod().GetParameters().WithValues(),
            });
        }

        [HarmonyPrefix]
        [HarmonyPatch(MethodType.Constructor, new[] { typeof(int) })]
        static void PrefixConstructor(RSACryptoServiceProvider __instance, int dwKeySize)
        {
            MainForm.DispatchApiCall(new CallStruct
            {
                Instance = __instance,
                MethodName = "ctor",
                Parameters = MethodBase.GetCurrentMethod().GetParameters().WithValues(new CallLookup
                {
                    [nameof(dwKeySize)] = dwKeySize
                }),
            });
        }

        [HarmonyPrefix]
        [HarmonyPatch(MethodType.Constructor, new[] { typeof(CspParameters) })]
        static void PrefixConstructor(RSACryptoServiceProvider __instance, CspParameters parameters)
        {
            MainForm.DispatchApiCall(new CallStruct
            {
                Instance = __instance,
                MethodName = "ctor",
                Parameters = MethodBase.GetCurrentMethod().GetParameters().WithValues(new CallLookup
                {
                    [nameof(parameters)] = parameters
                }),
            });
        }

        [HarmonyPrefix]
        [HarmonyPatch(MethodType.Constructor, new[] { typeof(int), typeof(CspParameters) })]
        static void PrefixConstructor(RSACryptoServiceProvider __instance, int dwKeySize, CspParameters parameters)
        {
            MainForm.DispatchApiCall(new CallStruct
            {
                Instance = __instance,
                MethodName = "ctor",
                Parameters = MethodBase.GetCurrentMethod().GetParameters().WithValues(new CallLookup
                {
                    [nameof(parameters)] = parameters,
                    [nameof(dwKeySize)] = dwKeySize
                }),
            });
        }

        [HarmonyPrefix]
        [HarmonyPatch("PersistKeyInCsp", MethodType.Setter)]
        static void PrefixPersistKeyInCsp(RSACryptoServiceProvider __instance, int value)
        {
            MainForm.DispatchApiCall(new CallStruct
            {
                Instance = __instance,
                MethodName = "PersistKeyInCsp",
                Parameters = MethodBase.GetCurrentMethod().GetParameters().WithValues(new CallLookup
                {
                    [nameof(value)] = value
                }),
            });
        }

        [HarmonyPostfix]
        [HarmonyPatch("Decrypt", new[] { typeof(byte[]), typeof(RSAEncryptionPadding) })]
        static void PostfixDecrypt(RSACryptoServiceProvider __instance, byte[] data, RSAEncryptionPadding padding, byte[] __result)
        {
            MainForm.DispatchApiCall(new CallStruct
            {
                Instance = __instance,
                MethodName = "Decrypt",
                Parameters = MethodBase.GetCurrentMethod().GetParameters().WithValues(new CallLookup
                {
                    [nameof(data)] = data,
                    [nameof(padding)] = padding,
                    [nameof(__result)] = __result
                }),
            });
        }

        [HarmonyPostfix]
        [HarmonyPatch("Decrypt", new[] { typeof(byte[]), typeof(bool) })]
        static void PostfixDecrypt(RSACryptoServiceProvider __instance, byte[] rgb, bool fOAEP, byte[] __result)
        {
            MainForm.DispatchApiCall(new CallStruct
            {
                Instance = __instance,
                MethodName = "Decrypt",
                Parameters = MethodBase.GetCurrentMethod().GetParameters().WithValues(new CallLookup
                {
                    [nameof(rgb)] = rgb,
                    [nameof(fOAEP)] = fOAEP,
                    [nameof(__result)] = __result
                }),
            });
        }

        [HarmonyPostfix]
        [HarmonyPatch("Encrypt", new[] { typeof(byte[]), typeof(RSAEncryptionPadding) })]
        static void PostfixEncrypt(RSACryptoServiceProvider __instance, byte[] data, RSAEncryptionPadding padding, byte[] __result)
        {
            MainForm.DispatchApiCall(new CallStruct
            {
                Instance = __instance,
                MethodName = "Encrypt",
                Parameters = MethodBase.GetCurrentMethod().GetParameters().WithValues(new CallLookup
                {
                    [nameof(data)] = data,
                    [nameof(padding)] = padding,
                    [nameof(__result)] = __result
                }),
            });
        }

        [HarmonyPostfix]
        [HarmonyPatch("Encrypt", new[] { typeof(byte[]), typeof(bool) })]
        static void PostfixEncrypt(RSACryptoServiceProvider __instance, byte[] rgb, bool fOAEP, byte[] __result)
        {
            MainForm.DispatchApiCall(new CallStruct
            {
                Instance = __instance,
                MethodName = "Encrypt",
                Parameters = MethodBase.GetCurrentMethod().GetParameters().WithValues(new CallLookup
                {
                    [nameof(rgb)] = rgb,
                    [nameof(fOAEP)] = fOAEP,
                    [nameof(__result)] = __result
                }),
            });
        }

        [HarmonyPostfix]
        [HarmonyPatch("ExportCspBlob", new[] { typeof(bool) })]
        static void PostfixExportCspBlob(RSACryptoServiceProvider __instance, bool includePrivateParameters, byte[] __result)
        {
            MainForm.DispatchApiCall(new CallStruct
            {
                Instance = __instance,
                MethodName = "ExportCspBlob",
                Parameters = MethodBase.GetCurrentMethod().GetParameters().WithValues(new CallLookup
                {
                    [nameof(includePrivateParameters)] = includePrivateParameters,
                    [nameof(__result)] = __result
                }),
            });
        }

        [HarmonyPostfix]
        [HarmonyPatch("ExportParameters", new[] { typeof(bool) })]
        static void PostfixExportParameters(RSACryptoServiceProvider __instance, bool includePrivateParameters, RSAParameters __result)
        {
            MainForm.DispatchApiCall(new CallStruct
            {
                Instance = __instance,
                MethodName = "ExportParameters",
                Parameters = MethodBase.GetCurrentMethod().GetParameters().WithValues(new CallLookup
                {
                    [nameof(includePrivateParameters)] = includePrivateParameters,
                    [nameof(__result)] = __result
                }),
            });
        }

        [HarmonyPostfix]
        [HarmonyPatch("ImportCspBlob", new[] { typeof(byte[]) })]
        static void PostfixImportCspBlob(RSACryptoServiceProvider __instance, byte[] keyBlob)
        {
            MainForm.DispatchApiCall(new CallStruct
            {
                Instance = __instance,
                MethodName = "ExportCspBlob",
                Parameters = MethodBase.GetCurrentMethod().GetParameters().WithValues(new CallLookup
                {
                    [nameof(keyBlob)] = keyBlob
                }),
            });
        }

        [HarmonyPostfix]
        [HarmonyPatch("ImportParameters", new[] { typeof(RSAParameters) })]
        static void PostfixExportCspBlob(RSACryptoServiceProvider __instance, RSAParameters parameters)
        {
            MainForm.DispatchApiCall(new CallStruct
            {
                Instance = __instance,
                MethodName = "ImportParameters",
                Parameters = MethodBase.GetCurrentMethod().GetParameters().WithValues(new CallLookup
                {
                    [nameof(parameters)] = parameters
                }),
            });
        }
    }
}
