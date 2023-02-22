using HarmonyLib;
using System.Reflection;
using System.Security.Cryptography;

namespace DotNetMonitor.Patches
{
    [HarmonyPatch(typeof(Rfc2898DeriveBytes))]
    class Rfc2898DeriveBytesPatch
    {
        [HarmonyPrefix]
        [HarmonyPatch(MethodType.Constructor, new[] { typeof(string), typeof(int) })]
        static void PrefixConstructor(Rfc2898DeriveBytes __instance, string password, int saltSize)
        {

            MainForm.DispatchApiCall(new CallStruct
            {
                Instance = __instance,
                MethodName = "ctor",
                Parameters = MethodBase.GetCurrentMethod().GetParameters().WithValues(new CallLookup
                {
                    [nameof(password)] = password,
                    [nameof(saltSize)] = saltSize
                }),
            });
        }

        [HarmonyPrefix]
        [HarmonyPatch(MethodType.Constructor, new[] { typeof(string), typeof(byte[]) })]
        static void PrefixConstructor(Rfc2898DeriveBytes __instance, string password, byte[] salt)
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
        [HarmonyPatch(MethodType.Constructor, new[] { typeof(string), typeof(int), typeof(int) })]
        static void PrefixConstructor(Rfc2898DeriveBytes __instance, string password, int saltSize, int iterations)
        {
            MainForm.DispatchApiCall(new CallStruct
            {
                Instance = __instance,
                MethodName = "ctor",
                Parameters = MethodBase.GetCurrentMethod().GetParameters().WithValues(new CallLookup
                {
                    [nameof(password)] = password,
                    [nameof(saltSize)] = saltSize,
                    [nameof(iterations)] = iterations
                }),
            });
        }

        [HarmonyPrefix]
        [HarmonyPatch(MethodType.Constructor, new[] { typeof(string), typeof(byte[]), typeof(int) })]
        static void PrefixConstructor(Rfc2898DeriveBytes __instance, string password, byte[] salt, int iterations)
        {
            MainForm.DispatchApiCall(new CallStruct
            {
                Instance = __instance,
                MethodName = "ctor",
                Parameters = MethodBase.GetCurrentMethod().GetParameters().WithValues(new CallLookup
                {
                    [nameof(password)] = password,
                    [nameof(salt)] = salt,
                    [nameof(iterations)] = iterations
                }),
            });
        }

        [HarmonyPrefix]
        [HarmonyPatch(MethodType.Constructor, new[] { typeof(byte[]), typeof(byte[]), typeof(int) })]
        static void PrefixConstructor(Rfc2898DeriveBytes __instance, byte[] password, byte[] salt, int iterations)
        {
            MainForm.DispatchApiCall(new CallStruct
            {
                Instance = __instance,
                MethodName = "ctor",
                Parameters = MethodBase.GetCurrentMethod().GetParameters().WithValues(new CallLookup
                {
                    [nameof(password)] = password,
                    [nameof(salt)] = salt,
                    [nameof(iterations)] = iterations
                }),
            });
        }

        [HarmonyPrefix]
        [HarmonyPatch(MethodType.Constructor, new[] { typeof(string), typeof(int), typeof(int), typeof(HashAlgorithmName) })]
        static void PrefixConstructor(Rfc2898DeriveBytes __instance, string password, int saltSize, int iterations, HashAlgorithmName hashAlgorithm)
        {
            MainForm.DispatchApiCall(new CallStruct
            {
                Instance = __instance,
                MethodName = "ctor",
                Parameters = MethodBase.GetCurrentMethod().GetParameters().WithValues(new CallLookup
                {
                    [nameof(password)] = password,
                    [nameof(saltSize)] = saltSize,
                    [nameof(iterations)] = iterations,
                    [nameof(hashAlgorithm)] = hashAlgorithm
                }),
            });
        }

        [HarmonyPrefix]
        [HarmonyPatch(MethodType.Constructor, new[] { typeof(string), typeof(byte[]), typeof(int), typeof(HashAlgorithmName) })]
        static void PrefixConstructor(Rfc2898DeriveBytes __instance, string password, byte[] salt, int iterations, HashAlgorithmName hashAlgorithm)
        {
            MainForm.DispatchApiCall(new CallStruct
            {
                Instance = __instance,
                MethodName = "ctor",
                Parameters = MethodBase.GetCurrentMethod().GetParameters().WithValues(new CallLookup
                {
                    [nameof(password)] = password,
                    [nameof(salt)] = salt,
                    [nameof(iterations)] = iterations,
                    [nameof(hashAlgorithm)] = hashAlgorithm
                }),
            });
        }

        [HarmonyPrefix]
        [HarmonyPatch(MethodType.Constructor, new[] { typeof(byte[]), typeof(byte[]), typeof(int), typeof(HashAlgorithmName) })]
        static void PrefixConstructor(Rfc2898DeriveBytes __instance, byte[] password, byte[] salt, int iterations, HashAlgorithmName hashAlgorithm)
        {
            MainForm.DispatchApiCall(new CallStruct
            {
                Instance = __instance,
                MethodName = "ctor",
                Parameters = MethodBase.GetCurrentMethod().GetParameters().WithValues(new CallLookup
                {
                    [nameof(password)] = password,
                    [nameof(salt)] = salt,
                    [nameof(iterations)] = iterations,
                    [nameof(hashAlgorithm)] = hashAlgorithm
                }),
            });
        }

        [HarmonyPrefix]
        [HarmonyPatch("IterationCount", MethodType.Setter)]
        static void PrefixIterationCount(Rfc2898DeriveBytes __instance, int value)
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
        static void PrefixSalt(Rfc2898DeriveBytes __instance, byte[] value)
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
