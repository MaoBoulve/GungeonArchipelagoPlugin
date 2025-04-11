using System;
using Alexandria.ItemAPI;
using Alexandria.Misc;
using SaveAPI;
using UnityEngine;

namespace NevernamedsItems;

public class RustyCasing : PassiveItem
{
	public static int RustyCasingID;

	public static void Init()
	{
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		PickupObject obj = ItemSetup.NewItem<RustyCasing>("Rusty Casing", "Heheheheheheh", "Yesyesyoulikestufffyouneeedmoney.\nThisgiveyoumoneyyesyesyes.\n\nHeheheheheheh", "rustycasing_icon", assetbundle: true);
		PassiveItem val = (PassiveItem)(object)((obj is PassiveItem) ? obj : null);
		((PickupObject)val).quality = (ItemQuality)1;
		RustyCasingID = ((PickupObject)val).PickupObjectId;
		((PickupObject)(object)val).SetupUnlockOnCustomStat(CustomTrackedStats.RUSTY_ITEMS_PURCHASED, 2f, (PrerequisiteOperation)2);
	}

	public override void Pickup(PlayerController player)
	{
		ExtendedPlayerComponent extComp = PlayerUtility.GetExtComp(player);
		extComp.OnPickedUpAmmo = (Action<PlayerController, AmmoPickup>)Delegate.Combine(extComp.OnPickedUpAmmo, new Action<PlayerController, AmmoPickup>(OnAmmo));
		ExtendedPlayerComponent extComp2 = PlayerUtility.GetExtComp(player);
		extComp2.OnPickedUpBlank = (Action<SilencerItem, PlayerController>)Delegate.Combine(extComp2.OnPickedUpBlank, new Action<SilencerItem, PlayerController>(OnBlank));
		ExtendedPlayerComponent extComp3 = PlayerUtility.GetExtComp(player);
		extComp3.OnPickedUpKey = (Action<PlayerController, KeyBulletPickup>)Delegate.Combine(extComp3.OnPickedUpKey, new Action<PlayerController, KeyBulletPickup>(OnKey));
		ExtendedPlayerComponent extComp4 = PlayerUtility.GetExtComp(player);
		extComp4.OnPickedUpHP = (Action<PlayerController, HealthPickup>)Delegate.Combine(extComp4.OnPickedUpHP, new Action<PlayerController, HealthPickup>(OnHealth));
		((PassiveItem)this).Pickup(player);
	}

	public override void DisableEffect(PlayerController player)
	{
		ExtendedPlayerComponent extComp = PlayerUtility.GetExtComp(player);
		extComp.OnPickedUpAmmo = (Action<PlayerController, AmmoPickup>)Delegate.Remove(extComp.OnPickedUpAmmo, new Action<PlayerController, AmmoPickup>(OnAmmo));
		ExtendedPlayerComponent extComp2 = PlayerUtility.GetExtComp(player);
		extComp2.OnPickedUpBlank = (Action<SilencerItem, PlayerController>)Delegate.Remove(extComp2.OnPickedUpBlank, new Action<SilencerItem, PlayerController>(OnBlank));
		ExtendedPlayerComponent extComp3 = PlayerUtility.GetExtComp(player);
		extComp3.OnPickedUpKey = (Action<PlayerController, KeyBulletPickup>)Delegate.Remove(extComp3.OnPickedUpKey, new Action<PlayerController, KeyBulletPickup>(OnKey));
		ExtendedPlayerComponent extComp4 = PlayerUtility.GetExtComp(player);
		extComp4.OnPickedUpHP = (Action<PlayerController, HealthPickup>)Delegate.Remove(extComp4.OnPickedUpHP, new Action<PlayerController, HealthPickup>(OnHealth));
		((PassiveItem)this).DisableEffect(player);
	}

	public void OnAmmo(PlayerController player, AmmoPickup ammo)
	{
		GiveCash(player, 6);
	}

	public void OnBlank(SilencerItem blank, PlayerController player)
	{
		GiveCash(player, 4);
	}

	public void OnKey(PlayerController player, KeyBulletPickup key)
	{
		if (key.IsRatKey)
		{
			GiveCash(player, 10);
		}
		else
		{
			GiveCash(player, 6);
		}
	}

	public void OnHealth(PlayerController player, HealthPickup hp)
	{
		if (hp.armorAmount > 0)
		{
			GiveCash(player, 8);
		}
		else
		{
			GiveCash(player, Mathf.CeilToInt(hp.healAmount * 8f));
		}
	}

	public static void GiveCash(PlayerController player, int cashAmount)
	{
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		if (CustomSynergies.PlayerHasActiveSynergy(player, "Lost, Never Found"))
		{
			cashAmount += 5;
		}
		if (cashAmount > 0)
		{
			LootEngine.SpawnCurrency(((BraveBehaviour)player).sprite.WorldCenter, cashAmount, false);
		}
	}
}
