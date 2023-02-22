using HarmonyLib;
using System.Reflection;
using System.Security.Cryptography;

namespace DotNetMonitor.Patches
{
    [HarmonyPatch(typeof(AsymmetricAlgorithm))]
    class AsymmetricAlgorithmPatch
    {
        [HarmonyPrefix]
        [HarmonyPatch("KeySize", MethodType.Setter)]
        static void PrefixKeySize(AsymmetricAlgorithm __instance, int value)
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

        [HarmonyPostfix]
        [HarmonyPatch("Create", new[] { typeof(string) })]
        static void PostfixCreate(AsymmetricAlgorithm __instance, string algName, AsymmetricAlgorithm __result)
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
        [HarmonyPatch("FromXmlString", new[] { typeof(string) })]
        static void PostfixFromXmlString(AsymmetricAlgorithm __instance, ref string xmlString)
        {
            Console.WriteLine(__instance.GetType().Name + ".FromXmlString(xmlString: " + xmlString + ")");
        }
        
        [HarmonyPostfix]
        [HarmonyPatch("ToXmlString", new[] { typeof(bool) })]
        static void PostfixToXmlString(AsymmetricAlgorithm __instance, ref bool includePrivateParameters, ref string __result)
        {
            Console.WriteLine(__instance.GetType().Name + ".ToXmlString(includePrivateParameters: " + includePrivateParameters.ToString() + ") = " + __result);
        }
        */
    }
}
