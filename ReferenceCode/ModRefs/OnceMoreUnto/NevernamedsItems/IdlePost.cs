using HarmonyLib;
using UnityEngine;

namespace NevernamedsItems;

[HarmonyPatch(typeof(Gun))]
[HarmonyPatch(/*Could not decode attribute arguments.*/)]
public class IdlePost
{
	[HarmonyPostfix]
	public static void HarmonyPostfix(Gun __instance)
	{
		if (__instance.usesContinuousFireAnimation && __instance.usesDirectionalAnimator)
		{
			AIAnimator aiAnimator = ((BraveBehaviour)__instance).aiAnimator;
			if ((Object)(object)aiAnimator != (Object)null && aiAnimator.m_currentActionState != null)
			{
				aiAnimator.EndAnimation();
			}
		}
	}
}
