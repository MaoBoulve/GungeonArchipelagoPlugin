using System;
using Alexandria.ItemAPI;
using Alexandria.Misc;
using UnityEngine;

namespace NevernamedsItems;

public class SonicCylinder : PassiveItem
{
	public static int ID;

	public static void Init()
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		PickupObject val = ItemSetup.NewItem<SonicCylinder>("Sonic Cylinder", "Blue Hole", "Legends tell of a gun that created a powerful bullet banishing sonic wave with every function of its double action trigger. \n\nThis is one of the few remaining parts of that powerful pre-gungeon artefact.", "soniccylinder_icon", assetbundle: true);
		val.quality = (ItemQuality)4;
		ItemBuilder.AddToSubShop(val, (ShopType)2, 1f);
		ItemBuilder.AddToSubShop(val, (ShopType)4, 1f);
		ItemBuilder.AddPassiveStatModifier(val, (StatType)14, 2f, (ModifyMethod)0);
		ID = val.PickupObjectId;
	}

	private void HandleGunReloaded(PlayerController player, Gun playerGun)
	{
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		if (playerGun.ClipShotsRemaining == 0 && Object.op_Implicit((Object)(object)player) && Random.value <= (float)playerGun.ClipCapacity / 50f)
		{
			PlayerUtility.DoEasyBlank(player, Vector2.op_Implicit(playerGun.barrelOffset.position), (EasyBlankType)1);
		}
	}

	public override void Pickup(PlayerController player)
	{
		player.OnReloadedGun = (Action<PlayerController, Gun>)Delegate.Combine(player.OnReloadedGun, new Action<PlayerController, Gun>(HandleGunReloaded));
		((PassiveItem)this).Pickup(player);
	}

	public override void DisableEffect(PlayerController player)
	{
		if (Object.op_Implicit((Object)(object)player))
		{
			player.OnReloadedGun = (Action<PlayerController, Gun>)Delegate.Remove(player.OnReloadedGun, new Action<PlayerController, Gun>(HandleGunReloaded));
		}
		((PassiveItem)this).DisableEffect(player);
	}
}
