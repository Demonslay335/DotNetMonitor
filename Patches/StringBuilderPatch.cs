using HarmonyLib;
using System.Reflection;
using System.Text;

namespace DotNetMonitor.Patches
{
    [HarmonyPatch(typeof(StringBuilder))]
    class StringBuilderPatch
    {
        [HarmonyPostfix]
        [HarmonyPatch("ToString", new[] { typeof(int), typeof(int) })]
        static void PostfixToString(StringBuilder __instance, int startIndex, int length, string __result)
        {
            MainForm.DispatchApiCall(new CallStruct
            {
                Instance = __instance,
                MethodName = "ToString",
                Parameters = MethodBase.GetCurrentMethod().GetParameters().WithValues(new CallLookup
                {
                    [nameof(startIndex)] = startIndex,
                    [nameof(length)] = length,
                    [nameof(__result)] = __result
                }),
            });
        }

        /* Causes StackOverflowException
        [HarmonyPostfix]
        [HarmonyPatch("ToString", new Type[] { })]
        static void PostfixToString(ref string __result)
        {
            Console.WriteLine("StringBuilder.ToString() = " + __result);
        }
        */
    }
}
