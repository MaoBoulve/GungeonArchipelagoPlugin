using UnityEngine;

namespace NevernamedsItems;

public static class SpecialDrop
{
	public static DebrisObject DropItem(PlayerController player, PickupObject thingum, bool deregisterGuns)
	{
		//IL_0145: Unknown result type (might be due to invalid IL or missing references)
		//IL_014b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0151: Unknown result type (might be due to invalid IL or missing references)
		//IL_0156: Unknown result type (might be due to invalid IL or missing references)
		//IL_015b: Unknown result type (might be due to invalid IL or missing references)
		PassiveItem component = ((Component)thingum).GetComponent<PassiveItem>();
		PlayerItem component2 = ((Component)thingum).GetComponent<PlayerItem>();
		Gun component3 = ((Component)thingum).GetComponent<Gun>();
		if ((Object)(object)component != (Object)null)
		{
			if (player.passiveItems.Contains(component))
			{
				player.passiveItems.Remove(component);
				GameUIRoot.Instance.RemovePassiveItemFromDock(component);
				DebrisObject val = component.Drop(player);
				player.stats.RecalculateStats(player, false, false);
				DontDontDestroyOnLoad(((Component)val).gameObject);
				return val;
			}
			ETGModConsole.Log((object)"Failed to drop item because the player doesn't have it?", false);
			return null;
		}
		if ((Object)(object)component2 != (Object)null)
		{
			if (player.activeItems.Contains(component2))
			{
				player.activeItems.Remove(component2);
				DebrisObject val2 = component2.Drop(player, 4f);
				player.stats.RecalculateStats(player, false, false);
				DontDontDestroyOnLoad(((Component)val2).gameObject);
				return val2;
			}
			ETGModConsole.Log((object)"Failed to drop item because the player doesn't have it?", false);
			return null;
		}
		if ((Object)(object)component3 != (Object)null)
		{
			if (player.inventory.AllGuns.Contains(component3))
			{
				player.inventory.RemoveGunFromInventory(component3);
				DebrisObject val3 = LootEngine.DropItemWithoutInstantiating(((Component)component3).gameObject, player.LockedApproximateSpriteCenter, Vector2.op_Implicit(player.unadjustedAimPoint - player.LockedApproximateSpriteCenter), 4f, true, false, false, false);
				if (deregisterGuns)
				{
					Component val4 = null;
					Component[] componentsInChildren = ((Component)val3).GetComponentsInChildren<Component>();
					foreach (Component val5 in componentsInChildren)
					{
						if (val5 is Gun)
						{
							val4 = val5;
						}
					}
					if ((Object)(object)val4 != (Object)null)
					{
						Object.Destroy((Object)(object)val4);
					}
				}
				player.stats.RecalculateStats(player, false, false);
				DontDontDestroyOnLoad(((Component)val3).gameObject);
				return val3;
			}
			ETGModConsole.Log((object)"Failed to drop item because the player doesn't have it?", false);
			return null;
		}
		return null;
	}

	private static void DontDontDestroyOnLoad(GameObject target)
	{
		if (Object.op_Implicit((Object)(object)target) && Object.op_Implicit((Object)(object)GameManager.Instance.Dungeon) && (Object)(object)target.transform.parent == (Object)null)
		{
			target.transform.parent = ((Component)GameManager.Instance.Dungeon).transform;
			target.transform.parent = null;
		}
	}
}
