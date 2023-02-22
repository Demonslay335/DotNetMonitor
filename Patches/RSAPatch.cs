using HarmonyLib;
using System;
using System.Reflection;
using System.Security.Cryptography;

namespace DotNetMonitor.Patches
{
    [HarmonyPatch(typeof(RSA))]
    class RSAPatch
    {
        [HarmonyPostfix]
        [HarmonyPatch("Create", new[] { typeof(int) })]
        static void PostfixCreate(RSA __instance, int keySizeInBits, RSA __result)
        {
            MainForm.DispatchApiCall(new CallStruct
            {
                Instance = __instance,
                MethodName = "Create",
                Parameters = MethodBase.GetCurrentMethod().GetParameters().WithValues(new CallLookup
                {
                    [nameof(keySizeInBits)] = keySizeInBits,
                    [nameof(__result)] = __result
                }),
            });
        }

        [HarmonyPostfix]
        [HarmonyPatch("Create", new[] { typeof(RSAParameters) })]
        static void PostfixCreate(RSA __instance, RSAParameters parameters, RSA __result)
        {
            MainForm.DispatchApiCall(new CallStruct
            {
                Instance = __instance,
                MethodName = "Create",
                Parameters = MethodBase.GetCurrentMethod().GetParameters().WithValues(new CallLookup
                {
                    [nameof(parameters)] = parameters,
                    [nameof(__result)] = __result
                }),
            });
        }

        [HarmonyPostfix]
        [HarmonyPatch("Create", new Type[] { })]
        static void PostfixCreate(RSA __instance, RSA __result)
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
        static void PostfixCreate(RSA __instance, string algName, RSA __result)
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
        /* These throw InvalidProgramException...
        [HarmonyPostfix]
        [HarmonyPatch("Decrypt", new[] { typeof(byte[]), typeof(RSAEncryptionPadding) })]
        static void PostfixDecrypt(RSA __instance, ref byte[] data, ref RSAEncryptionPadding padding)
        {
            Console.WriteLine(__instance.GetType().Name + ".Decrypt(data: " + data.Take(0x10) + "..., padding: " + padding.ToString() + ")");
        }

        [HarmonyPostfix]
        [HarmonyPatch("Encrypt", new[] { typeof(byte[]), typeof(RSAEncryptionPadding) })]
        static void PostfixEncrypt(RSA __instance, ref byte[] data, ref RSAEncryptionPadding padding)
        {
            Console.WriteLine(__instance.GetType().Name + ".Encrypt(data: " + data.Take(0x10) + "..., padding: " + padding.ToString() + ")");
        }
        
        [HarmonyPostfix]
        [HarmonyPatch("ExportParameters", new[] { typeof(bool) })]
        static void PostfixExportParameters(RSA __instance, ref bool includePrivateParameters, ref RSAParameters __result)
        {
            Console.WriteLine(__instance.GetType().Name + ".ExportParameters(includePrivateParameters: " + includePrivateParameters.ToString() + ") = " + __result.ToString());
        }
        */
        [HarmonyPostfix]
        [HarmonyPatch("ToXmlString", new[] { typeof(bool) })]
        static void PostfixToXmlString(RSA __instance, bool includePrivateParameters, string __result)
        {
            MainForm.DispatchApiCall(new CallStruct
            {
                Instance = __instance,
                MethodName = "ToXmlString",
                Parameters = MethodBase.GetCurrentMethod().GetParameters().WithValues(new CallLookup
                {
                    [nameof(includePrivateParameters)] = includePrivateParameters,
                    [nameof(__result)] = __result
                }),
            });
        }
    }
}
