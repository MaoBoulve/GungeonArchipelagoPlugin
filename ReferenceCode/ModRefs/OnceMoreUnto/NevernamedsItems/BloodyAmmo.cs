using System;
using Alexandria.Misc;
using UnityEngine;

namespace NevernamedsItems;

public class BloodyAmmo : PassiveItem
{
	public static int BloodyAmmoID;

	public static void Init()
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		PickupObject val = ItemSetup.NewItem<BloodyAmmo>("Bloody Ammo", "Lead Vessel", "Heals the owner upon picking up ammo.\n\nAn ammo box with it's skin removed.", "bloodyammo_icon", assetbundle: true);
		val.quality = (ItemQuality)3;
		BloodyAmmoID = val.PickupObjectId;
	}

	public void OnAmmoCollected(PlayerController player, AmmoPickup self)
	{
		((BraveBehaviour)player).healthHaver.ApplyHealing(0.5f);
		if (player.ForceZeroHealthState)
		{
			LootEngine.GivePrefabToPlayer(((Component)PickupObjectDatabase.GetById(120)).gameObject, player);
		}
	}

	public override void Pickup(PlayerController player)
	{
		if (Object.op_Implicit((Object)(object)PlayerUtility.GetExtComp(player)))
		{
			ExtendedPlayerComponent extComp = PlayerUtility.GetExtComp(player);
			extComp.OnPickedUpAmmo = (Action<PlayerController, AmmoPickup>)Delegate.Combine(extComp.OnPickedUpAmmo, new Action<PlayerController, AmmoPickup>(OnAmmoCollected));
		}
		((PassiveItem)this).Pickup(player);
	}

	public override void DisableEffect(PlayerController player)
	{
		if ((Object)(object)player != (Object)null && Object.op_Implicit((Object)(object)PlayerUtility.GetExtComp(player)))
		{
			ExtendedPlayerComponent extComp = PlayerUtility.GetExtComp(player);
			extComp.OnPickedUpAmmo = (Action<PlayerController, AmmoPickup>)Delegate.Remove(extComp.OnPickedUpAmmo, new Action<PlayerController, AmmoPickup>(OnAmmoCollected));
		}
		((PassiveItem)this).DisableEffect(player);
	}
}
