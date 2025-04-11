using HarmonyLib;
using UnityEngine;

namespace NevernamedsItems;

[HarmonyPatch(typeof(MinorBreakable))]
[HarmonyPatch(/*Could not decode attribute arguments.*/)]
public static class MinorBreakableStuff
{
	[HarmonyPrefix]
	public static void BreakPref(MinorBreakable __instance, Vector2 vec)
	{
		if (Object.op_Implicit((Object)(object)__instance) && ((Behaviour)__instance).enabled && OMITBActions.MinorBreakableBroken != null)
		{
			OMITBActions.MinorBreakableBroken(__instance);
		}
	}
}
