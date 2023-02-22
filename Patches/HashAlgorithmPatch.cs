using HarmonyLib;
using System;
using System.IO;
using System.Reflection;
using System.Security.Cryptography;

namespace DotNetMonitor.Patches
{
    [HarmonyPatch(typeof(HashAlgorithm))]
    class HashAlgorithmPatch
    {
        [HarmonyPostfix]
        [HarmonyPatch("Create", new[] { typeof(string) })]
        static void PostfixCreate(HashAlgorithm __instance, string hashName, HashAlgorithm __result)
        {
            MainForm.DispatchApiCall(new CallStruct
            {
                Instance = __instance,
                MethodName = "Create",
                Parameters = MethodBase.GetCurrentMethod().GetParameters().WithValues(new CallLookup
                {
                    [nameof(hashName)] = hashName,
                    [nameof(__result)] = __result
                })
            });
        }

        [HarmonyPostfix]
        [HarmonyPatch("Create", new Type[] { })]
        static void PostfixCreate(HashAlgorithm __instance, HashAlgorithm __result)
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
        [HarmonyPatch("ComputeHash", new[] { typeof(byte[]), typeof(int), typeof(int) })]
        static void PostfixComputeHash(HashAlgorithm __instance, byte[] buffer, int offset, int count, byte[] __result)
        {
            MainForm.DispatchApiCall(new CallStruct
            {
                Instance = __instance,
                MethodName = "ComputeHash",
                Parameters = MethodBase.GetCurrentMethod().GetParameters().WithValues(new CallLookup
                {
                    [nameof(buffer)] = buffer,
                    [nameof(offset)] = offset,
                    [nameof(count)] = count,
                    [nameof(__result)] = __result
                }),
            });
        }

        [HarmonyPostfix]
        [HarmonyPatch("ComputeHash", new[] { typeof(byte[]) })]
        static void PostfixComputeHash(HashAlgorithm __instance, byte[] buffer, byte[] __result)
        {
            MainForm.DispatchApiCall(new CallStruct
            {
                Instance = __instance,
                MethodName = "ComputeHash",
                Parameters = MethodBase.GetCurrentMethod().GetParameters().WithValues(new CallLookup
                {
                    [nameof(buffer)] = buffer,
                    [nameof(__result)] = __result
                }),
            });
        }

        [HarmonyPostfix]
        [HarmonyPatch("ComputeHash", new[] { typeof(Stream) })]
        static void PostfixComputeHash(HashAlgorithm __instance, Stream inputStream, byte[] __result)
        {
            MainForm.DispatchApiCall(new CallStruct
            {
                Instance = __instance,
                MethodName = "ComputeHash",
                Parameters = MethodBase.GetCurrentMethod().GetParameters().WithValues(new CallLookup
                {
                    [nameof(inputStream)] = inputStream,
                    [nameof(__result)] = __result
                }),
            });
        }
    }
}
