using HarmonyLib;
using System.Net;
using System.Reflection;

namespace DotNetMonitor.Patches
{
    [HarmonyPatch(typeof(Dns))]
    class DnsPatch
    {
        [HarmonyPostfix]
        [HarmonyPatch("Resolve", new[] { typeof(string) })]
        static void PostfixResolve(string hostName, IPHostEntry __result)
        {
            MainForm.DispatchApiCall(new CallStruct
            {
                Instance = null,
                MethodName = "Resolve",
                Parameters = MethodBase.GetCurrentMethod().GetParameters().WithValues(new CallLookup
                {
                    [nameof(hostName)] = hostName,
                    [nameof(__result)] = __result
                }),
            });
        }
    }
}
