using HarmonyLib;
using Bark.Modules.Movement;
using Bark.Modules;
using Bark.Tools;
using System;
using AA;
using GorillaLocomotion;
using UnityEngine;

namespace Bark.Patches
{
    [HarmonyPatch(typeof(GorillaNetworkPublicTestsJoin))]
    [HarmonyPatch("LocalPlayerSpeed", MethodType.Normal)]
    internal class TagSpeedPatch
    {
        private static bool Prefix()
        {
            return false;
        }
    }

    [HarmonyPatch(typeof(GorillaNetworkPublicTestJoin2))]
    [HarmonyPatch("GracePeriod", MethodType.Normal)]
    public class GenericSpeedPatch
    {
        private static bool Prefix()
        {
            return false;
        }
    }

    [HarmonyPatch(typeof(Player))]
    [HarmonyPatch("GetSwimmingVelocityForHand", MethodType.Normal)]
    internal class SwimmingVelocityPatch
    {
        private static void Postfix(ref Vector3 swimmingVelocityChange)
        {
            try
            {
                if (!SpeedBoost.active) return;
                swimmingVelocityChange *= SpeedBoost.scale;
            }
            catch (Exception e) { Logging.Exception(e); }
        }
    }
}
