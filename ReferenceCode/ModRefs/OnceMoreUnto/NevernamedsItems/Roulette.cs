using System;
using System.Collections.Generic;
using Alexandria.ItemAPI;
using UnityEngine;

namespace NevernamedsItems;

internal class Roulette : PlayerItem
{
	public static int RouletteID;

	public static List<PlayerItem> cachedActiveItemsToKillDrop = new List<PlayerItem>();

	public static List<PassiveItem> cachedPassiveItemsToKillDrop = new List<PassiveItem>();

	public static List<Gun> cachedGunsToDestroy = new List<Gun>();

	public static List<int> passiveItemsToIgnore = new List<int> { 467, 468, 469, 470, 471, 127, 565, 316, RouletteID };

	public static void Init()
	{
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		PickupObject obj = ItemSetup.NewItem<Roulette>("Roulette", "Spin To Win", "", "workinprogress_icon", assetbundle: true);
		PlayerItem val = (PlayerItem)(object)((obj is PlayerItem) ? obj : null);
		ItemBuilder.SetCooldownType(val, (CooldownType)3, 0f);
		val.consumable = false;
		((PickupObject)val).quality = (ItemQuality)(-100);
		RouletteID = ((PickupObject)val).PickupObjectId;
	}

	public override bool CanBeUsed(PlayerController user)
	{
		return true;
	}

	public override void DoEffect(PlayerController user)
	{
		try
		{
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			cachedPassiveItemsToKillDrop.Clear();
			cachedGunsToDestroy.Clear();
			cachedActiveItemsToKillDrop.Clear();
			if (user.passiveItems.Count > 0)
			{
				foreach (PassiveItem passiveItem in user.passiveItems)
				{
					bool flag = passiveItemsToIgnore.Contains(((PickupObject)passiveItem).PickupObjectId);
					if (((PickupObject)passiveItem).CanActuallyBeDropped(user) && !flag)
					{
						num2++;
						cachedPassiveItemsToKillDrop.Add(passiveItem);
					}
				}
			}
			if (user.inventory.AllGuns.Count > 0)
			{
				foreach (Gun allGun in user.inventory.AllGuns)
				{
					if (((PickupObject)allGun).CanActuallyBeDropped(user))
					{
						num++;
						cachedGunsToDestroy.Add(allGun);
					}
				}
			}
			if (user.activeItems.Count > 0)
			{
				foreach (PlayerItem activeItem in user.activeItems)
				{
					bool flag2 = passiveItemsToIgnore.Contains(((PickupObject)activeItem).PickupObjectId);
					if (((PickupObject)activeItem).CanActuallyBeDropped(user) && !flag2)
					{
						num3++;
						cachedActiveItemsToKillDrop.Add(activeItem);
					}
				}
			}
			if (cachedActiveItemsToKillDrop.Count > 0)
			{
				for (int num4 = cachedActiveItemsToKillDrop.Count - 1; num4 >= 0; num4--)
				{
					if (((PickupObject)cachedActiveItemsToKillDrop[num4]).PickupObjectId != RouletteID)
					{
						KillDropWeirdActive(cachedActiveItemsToKillDrop[num4]);
					}
				}
			}
			if (cachedPassiveItemsToKillDrop.Count > 0)
			{
				for (int num5 = cachedPassiveItemsToKillDrop.Count - 1; num5 >= 0; num5--)
				{
					KillDropWeirdItem(cachedPassiveItemsToKillDrop[num5]);
				}
			}
			if (cachedGunsToDestroy.Count > 0)
			{
				for (int num6 = cachedGunsToDestroy.Count - 1; num6 >= 0; num6--)
				{
					user.inventory.RemoveGunFromInventory(cachedGunsToDestroy[num6]);
				}
			}
			user.stats.RecalculateStats(user, false, false);
			if (num2 > 0)
			{
				for (int i = 0; i < num2; i++)
				{
					PickupObject itemOfTypeAndQuality = (PickupObject)(object)LootEngine.GetItemOfTypeAndQuality<PassiveItem>((ItemQuality)4, GameManager.Instance.RewardManager.ItemsLootTable, true);
					LootEngine.GivePrefabToPlayer(((Component)itemOfTypeAndQuality).gameObject, user);
				}
			}
			user.stats.RecalculateStats(user, false, false);
			if (num3 > 0)
			{
				int num7 = (int)user.stats.GetStatValue((StatType)8);
				if (num7 > 0)
				{
					for (int j = 0; j < num7; j++)
					{
						PickupObject itemOfTypeAndQuality2 = (PickupObject)(object)LootEngine.GetItemOfTypeAndQuality<PlayerItem>((ItemQuality)4, GameManager.Instance.RewardManager.ItemsLootTable, true);
						LootEngine.GivePrefabToPlayer(((Component)itemOfTypeAndQuality2).gameObject, user);
					}
				}
				for (int k = 0; k < num3 - num7; k++)
				{
					PickupObject itemOfTypeAndQuality3 = (PickupObject)(object)LootEngine.GetItemOfTypeAndQuality<PassiveItem>((ItemQuality)4, GameManager.Instance.RewardManager.ItemsLootTable, true);
					LootEngine.GivePrefabToPlayer(((Component)itemOfTypeAndQuality3).gameObject, user);
				}
			}
			user.stats.RecalculateStats(user, false, false);
			for (int l = 0; l < num; l++)
			{
				PickupObject itemOfTypeAndQuality4 = (PickupObject)(object)LootEngine.GetItemOfTypeAndQuality<Gun>((ItemQuality)4, GameManager.Instance.RewardManager.GunsLootTable, true);
				LootEngine.GivePrefabToPlayer(((Component)itemOfTypeAndQuality4).gameObject, user);
			}
		}
		catch (Exception ex)
		{
			ETGModConsole.Log((object)ex.Message, false);
			ETGModConsole.Log((object)ex.StackTrace, false);
		}
	}

	public void KillDropWeirdItem(PassiveItem item)
	{
		DebrisObject val = base.LastOwner.DropPassiveItem(item);
		Object.Destroy((Object)(object)((Component)val).gameObject, 0.01f);
	}

	public void KillDropWeirdActive(PlayerItem item)
	{
		DebrisObject val = base.LastOwner.DropActiveItem(item, 4f, false);
		Object.Destroy((Object)(object)((Component)val).gameObject, 0.01f);
	}

	public override void Pickup(PlayerController player)
	{
		((PlayerItem)this).Pickup(player);
	}
}
