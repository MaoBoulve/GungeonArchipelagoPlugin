using System;
using System.Collections.Generic;
using System.Reflection;
using Alexandria.Misc;
using MonoMod.RuntimeDetour;
using SaveAPI;
using UnityEngine;

namespace NevernamedsItems;

public class AmmoTrap : PassiveItem
{
	public static List<int> bannedIDs = new List<int> { 78, 600, 565, 120, 224, 67 };

	private float lastCheckedRatItemStoleded;

	public static Hook ammoSpawnHook;

	public static int AmmoTrapID;

	public static void Init()
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Expected O, but got Unknown
		PickupObject val = ItemSetup.NewItem<AmmoTrap>("Ammo Trap", "Clickity Clack", "Prevents ammo from being stolen by the dastardly Rat, and even causes him to drop some of his own upon going in for the grabby.\n\nWhy didn't we think of this sooner.", "ammotrap_icon", assetbundle: true);
		val.quality = (ItemQuality)3;
		val.SetupUnlockOnCustomFlag(CustomDungeonFlags.ALLJAMMED_BEATEN_RAT, requiredFlagValue: true);
		AmmoTrapID = val.PickupObjectId;
		ammoSpawnHook = new Hook((MethodBase)typeof(LootEngine).GetMethod("PostprocessItemSpawn", BindingFlags.Static | BindingFlags.NonPublic), typeof(AmmoTrap).GetMethod("doEffect", BindingFlags.Static | BindingFlags.Public));
	}

	public static void doEffect(Action<DebrisObject> orig, DebrisObject spawnedItem)
	{
		try
		{
			orig(spawnedItem);
			if (GameManagerUtility.AnyPlayerHasPickupID(GameManager.Instance, AmmoTrapID))
			{
				AmmoPickup component = ((Component)spawnedItem).gameObject.GetComponent<AmmoPickup>();
				if ((Object)(object)component != (Object)null)
				{
					((PickupObject)component).IgnoredByRat = true;
				}
			}
		}
		catch (Exception ex)
		{
			ETGModConsole.Log((object)ex.Message, false);
			ETGModConsole.Log((object)ex.StackTrace, false);
		}
	}

	public override void Update()
	{
		if (GameStatsManager.Instance.GetPlayerStatValue((TrackedStats)83) != lastCheckedRatItemStoleded)
		{
			lastCheckedRatItemStoleded = GameStatsManager.Instance.GetPlayerStatValue((TrackedStats)83);
			DoAmmoSpawn();
		}
		((PassiveItem)this).Update();
	}

	private void DoAmmoSpawn()
	{
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		TalkDoerLite[] array = Object.FindObjectsOfType<TalkDoerLite>();
		TalkDoerLite[] array2 = array;
		foreach (TalkDoerLite val in array2)
		{
			if (((Object)val).name.Contains("ResourcefulRat_Thief"))
			{
				LootEngine.SpawnItem(((Component)PickupObjectDatabase.GetById(78)).gameObject, ((BraveBehaviour)val).transform.position, Vector2.zero, 0f, true, false, false);
			}
		}
	}

	public override void Pickup(PlayerController player)
	{
		lastCheckedRatItemStoleded = GameStatsManager.Instance.GetPlayerStatValue((TrackedStats)83);
		((PassiveItem)this).Pickup(player);
		if (base.m_pickedUpThisRun)
		{
			return;
		}
		foreach (Gun allGun in player.inventory.AllGuns)
		{
			if (allGun.CanGainAmmo)
			{
				allGun.GainAmmo(allGun.AdjustedMaxAmmo);
			}
		}
	}
}
