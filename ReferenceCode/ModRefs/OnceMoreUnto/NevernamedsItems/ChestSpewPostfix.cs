using System;
using System.Collections.Generic;
using HarmonyLib;
using UnityEngine;

namespace NevernamedsItems;

[HarmonyPatch(typeof(Chest))]
[HarmonyPatch(/*Could not decode attribute arguments.*/)]
public class ChestSpewPostfix
{
	[HarmonyPrefix]
	public static bool HarmonyPrefix(Chest __instance, List<Transform> spawnTransforms)
	{
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		BowlerShopChest component = ((Component)__instance).GetComponent<BowlerShopChest>();
		if ((Object)(object)component != (Object)null)
		{
			List<DebrisObject> list = new List<DebrisObject>();
			for (int i = 0; i < __instance.contents.Count; i++)
			{
				List<DebrisObject> list2 = LootEngine.SpewLoot(new List<GameObject> { ((Component)__instance.contents[i]).gameObject }, spawnTransforms[i].position);
				list.AddRange(list2);
				for (int j = 0; j < list2.Count; j++)
				{
					if (Object.op_Implicit((Object)(object)list2[j]))
					{
						list2[j].PreventFallingInPits = true;
					}
					if (!((Object)(object)((Component)list2[j]).GetComponent<Gun>() != (Object)null) && !((Object)(object)((Component)list2[j]).GetComponent<CurrencyPickup>() != (Object)null) && (Object)(object)((BraveBehaviour)list2[j]).specRigidbody != (Object)null)
					{
						((BraveBehaviour)list2[j]).specRigidbody.CollideWithOthers = false;
						DebrisObject val = list2[j];
						val.OnTouchedGround = (Action<DebrisObject>)Delegate.Combine(val.OnTouchedGround, new Action<DebrisObject>(__instance.BecomeViableItem));
					}
				}
			}
			component.interactible.OnOpenedChest();
			((MonoBehaviour)GameManager.Instance.Dungeon).StartCoroutine(__instance.HandleRainbowRunLootProcessing(list));
			return false;
		}
		return true;
	}
}
