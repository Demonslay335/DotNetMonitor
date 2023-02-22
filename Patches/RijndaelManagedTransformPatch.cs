using HarmonyLib;
using System.Reflection;
using System.Security.Cryptography;

namespace DotNetMonitor.Patches
{

    [HarmonyPatch(typeof(RijndaelManagedTransform))]
    class RijndaelManagedTransformPatch
    {
        [HarmonyPostfix]
        [HarmonyPatch("TransformBlock", new[] { typeof(byte[]), typeof(int), typeof(int), typeof(byte[]), typeof(int) })]
        static void PostfixTransformBlock(RijndaelManagedTransform __instance, byte[] inputBuffer, int inputOffset, int inputCount, byte[] outputBuffer, int outputOffset, int __result)
        {
            MainForm.DispatchApiCall(new CallStruct
            {
                Instance = __instance,
                MethodName = "TransformBlock",
                Parameters = MethodBase.GetCurrentMethod().GetParameters().WithValues(new CallLookup
                {
                    [nameof(inputBuffer)] = inputBuffer,
                    [nameof(inputOffset)] = inputOffset,
                    [nameof(inputCount)] = inputCount,
                    [nameof(outputBuffer)] = outputBuffer,
                    [nameof(outputOffset)] = outputOffset,
                    [nameof(__result)] = __result
                }),
            });
        }

        [HarmonyPostfix]
        [HarmonyPatch("TransformFinalBlock", new[] { typeof(byte[]), typeof(int), typeof(int) })]
        static void PostfixTransformFinalBlock(RijndaelManagedTransform __instance, byte[] inputBuffer, int inputOffset, int inputCount, byte[] __result)
        {
            MainForm.DispatchApiCall(new CallStruct
            {
                Instance = __instance,
                MethodName = "TransformFinalBlock",
                Parameters = MethodBase.GetCurrentMethod().GetParameters().WithValues(new CallLookup
                {
                    [nameof(inputBuffer)] = inputBuffer,
                    [nameof(inputOffset)] = inputOffset,
                    [nameof(inputCount)] = inputCount,
                    [nameof(__result)] = __result
                }),
            });
        }
    }
}
