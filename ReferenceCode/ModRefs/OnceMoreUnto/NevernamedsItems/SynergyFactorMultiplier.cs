using Alexandria.Misc;
using HarmonyLib;
using UnityEngine;

namespace NevernamedsItems;

[HarmonyPatch(typeof(SynergyFactorConstants), "GetSynergyFactor")]
public static class SynergyFactorMultiplier
{
	public static void Postfix(ref float __result)
	{
		float num = 0f;
		if ((Object)(object)GameManager.Instance.PrimaryPlayer != (Object)null)
		{
			num += (float)PlayerUtility.GetNumberOfItemInInventory(GameManager.Instance.PrimaryPlayer, Gracelets.ID);
		}
		if ((Object)(object)GameManager.Instance.SecondaryPlayer != (Object)null)
		{
			num += (float)PlayerUtility.GetNumberOfItemInInventory(GameManager.Instance.SecondaryPlayer, Gracelets.ID);
		}
		__result *= num * 10f;
	}
}
