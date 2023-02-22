using HarmonyLib;
using System.Reflection;
using System.Security.Cryptography;

namespace DotNetMonitor.Patches
{
    [HarmonyPatch(typeof(PasswordDeriveBytes))]
    class PasswordDeriveBytesPatch
    {
        [HarmonyPrefix]
        [HarmonyPatch(MethodType.Constructor, new[] { typeof(string), typeof(byte[]) })]
        static void PrefixConstructor(PasswordDeriveBytes __instance, string strPassword, byte[] rgbSalt)
        {
            MainForm.DispatchApiCall(new CallStruct
            {
                Instance = __instance,
                MethodName = "ctor",
                Parameters = MethodBase.GetCurrentMethod().GetParameters().WithValues(new CallLookup
                {
                    [nameof(strPassword)] = strPassword,
                    [nameof(rgbSalt)] = rgbSalt
                }),
            });
        }

        [HarmonyPrefix]
        [HarmonyPatch(MethodType.Constructor, new[] { typeof(byte[]), typeof(byte[]) })]
        static void PrefixConstructor(PasswordDeriveBytes __instance, byte[] password, byte[] salt)
        {
            MainForm.DispatchApiCall(new CallStruct
            {
                Instance = __instance,
                MethodName = "ctor",
                Parameters = MethodBase.GetCurrentMethod().GetParameters().WithValues(new CallLookup
                {
                    [nameof(password)] = password,
                    [nameof(salt)] = salt
                }),
            });
        }

        [HarmonyPrefix]
        [HarmonyPatch(MethodType.Constructor, new[] { typeof(string), typeof(byte[]), typeof(CspParameters) })]
        static void PrefixConstructor(PasswordDeriveBytes __instance, string strPassword, byte[] rgbSalt, CspParameters cspParams)
        {
            MainForm.DispatchApiCall(new CallStruct
            {
                Instance = __instance,
                MethodName = "ctor",
                Parameters = MethodBase.GetCurrentMethod().GetParameters().WithValues(new CallLookup
                {
                    [nameof(strPassword)] = strPassword,
                    [nameof(rgbSalt)] = rgbSalt,
                    [nameof(cspParams)] = cspParams
                }),
            });
        }

        [HarmonyPrefix]
        [HarmonyPatch(MethodType.Constructor, new[] { typeof(byte[]), typeof(byte[]), typeof(CspParameters) })]
        static void PrefixConstructor(PasswordDeriveBytes __instance, byte[] password, byte[] salt, CspParameters cspParams)
        {
            MainForm.DispatchApiCall(new CallStruct
            {
                Instance = __instance,
                MethodName = "ctor",
                Parameters = MethodBase.GetCurrentMethod().GetParameters().WithValues(new CallLookup
                {
                    [nameof(password)] = password,
                    [nameof(salt)] = salt,
                    [nameof(cspParams)] = cspParams
                }),
            });
        }

        [HarmonyPrefix]
        [HarmonyPatch(MethodType.Constructor, new[] { typeof(byte[]), typeof(byte[]), typeof(string), typeof(int) })]
        static void PrefixConstructor(PasswordDeriveBytes __instance, byte[] password, byte[] salt, string hashName, int iterations)
        {
            MainForm.DispatchApiCall(new CallStruct
            {
                Instance = __instance,
                MethodName = "ctor",
                Parameters = MethodBase.GetCurrentMethod().GetParameters().WithValues(new CallLookup
                {
                    [nameof(password)] = password,
                    [nameof(salt)] = salt,
                    [nameof(hashName)] = hashName,
                    [nameof(iterations)] = iterations
                }),
            });
        }

        [HarmonyPrefix]
        [HarmonyPatch(MethodType.Constructor, new[] { typeof(string), typeof(byte[]), typeof(string), typeof(int), typeof(CspParameters) })]
        static void PrefixConstructor(PasswordDeriveBytes __instance, string strPassword, byte[] rgbSalt, string strHashName, int iterations, CspParameters cspParams)
        {
            MainForm.DispatchApiCall(new CallStruct
            {
                Instance = __instance,
                MethodName = "ctor",
                Parameters = MethodBase.GetCurrentMethod().GetParameters().WithValues(new CallLookup
                {
                    [nameof(strPassword)] = strPassword,
                    [nameof(rgbSalt)] = rgbSalt,
                    [nameof(strHashName)] = strHashName,
                    [nameof(iterations)] = iterations,
                    [nameof(cspParams)] = cspParams
                }),
            });
        }

        [HarmonyPrefix]
        [HarmonyPatch(MethodType.Constructor, new[] { typeof(byte[]), typeof(byte[]), typeof(string), typeof(int), typeof(CspParameters) })]
        static void PrefixConstructor(PasswordDeriveBytes __instance, byte[] password, byte[] salt, string hashName, int iterations, CspParameters cspParams)
        {
            MainForm.DispatchApiCall(new CallStruct
            {
                Instance = __instance,
                MethodName = "ctor",
                Parameters = MethodBase.GetCurrentMethod().GetParameters().WithValues(new CallLookup
                {
                    [nameof(password)] = password,
                    [nameof(salt)] = salt,
                    [nameof(hashName)] = hashName,
                    [nameof(iterations)] = iterations,
                    [nameof(cspParams)] = cspParams
                }),
            });
        }

        [HarmonyPrefix]
        [HarmonyPatch("HashName", MethodType.Setter)]
        static void PrefixHashName(PasswordDeriveBytes __instance, string value)
        {
            MainForm.DispatchApiCall(new CallStruct
            {
                Instance = __instance,
                MethodName = "HashName",
                Parameters = MethodBase.GetCurrentMethod().GetParameters().WithValues(new CallLookup
                {
                    [nameof(value)] = value
                }),
            });
        }

        [HarmonyPrefix]
        [HarmonyPatch("IterationCount", MethodType.Setter)]
        static void PrefixIterationCount(PasswordDeriveBytes __instance, int value)
        {
            MainForm.DispatchApiCall(new CallStruct
            {
                Instance = __instance,
                MethodName = "IterationCount",
                Parameters = MethodBase.GetCurrentMethod().GetParameters().WithValues(new CallLookup
                {
                    [nameof(value)] = value
                }),
            });
        }

        [HarmonyPrefix]
        [HarmonyPatch("Salt", MethodType.Setter)]
        static void PrefixSalt(PasswordDeriveBytes __instance, byte[] value)
        {
            MainForm.DispatchApiCall(new CallStruct
            {
                Instance = __instance,
                MethodName = "Salt",
                Parameters = MethodBase.GetCurrentMethod().GetParameters().WithValues(new CallLookup
                {
                    [nameof(value)] = value
                }),
            });
        }

        [HarmonyPostfix]
        [HarmonyPatch("CryptDeriveKey", new[] { typeof(string), typeof(string), typeof(int), typeof(byte[]) })]
        static void PostfixCryptDeriveKey(PasswordDeriveBytes __instance, string algname, string alghashname, int keySize, byte[] rgbIV, byte[] __result)
        {
            MainForm.DispatchApiCall(new CallStruct
            {
                Instance = __instance,
                MethodName = "CryptDeriveKey",
                Parameters = MethodBase.GetCurrentMethod().GetParameters().WithValues(new CallLookup
                {
                    [nameof(algname)] = algname,
                    [nameof(alghashname)] = alghashname,
                    [nameof(keySize)] = keySize,
                    [nameof(rgbIV)] = rgbIV,
                    [nameof(__result)] = __result
                }),
            });
        }

        [HarmonyPostfix]
        [HarmonyPatch("GetBytes", new[] { typeof(int) })]
        static void PostfixGetBytes(DeriveBytes __instance, int cb, byte[] __result)
        {
            MainForm.DispatchApiCall(new CallStruct
            {
                Instance = __instance,
                MethodName = "GetBytes",
                Parameters = MethodBase.GetCurrentMethod().GetParameters().WithValues(new CallLookup
                {
                    [nameof(cb)] = cb,
                    [nameof(__result)] = __result
                }),
            });
        }
    }
}
