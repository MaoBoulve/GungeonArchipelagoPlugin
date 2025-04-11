using HarmonyLib;
using UnityEngine;

namespace NevernamedsItems;

[HarmonyPatch(typeof(CompanionItem))]
[HarmonyPatch(/*Could not decode attribute arguments.*/)]
public class CreatePost
{
	[HarmonyPostfix]
	public static void HarmonyPostfix(CompanionItem __instance, PlayerController owner)
	{
		if (Object.op_Implicit((Object)(object)__instance) && __instance is ExtendedCompanionItem)
		{
			(__instance as ExtendedCompanionItem).OnCompanionCreation(owner);
		}
	}
}
