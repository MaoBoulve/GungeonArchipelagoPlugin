using System;
using Alexandria.ItemAPI;
using SaveAPI;
using UnityEngine;

namespace NevernamedsItems;

public class ElectricCylinder : PassiveItem
{
	public static int ID;

	public static void Init()
	{
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		PickupObject val = ItemSetup.NewItem<ElectricCylinder>("Electric Cylinder", "Vrrrt", "On the rare occasion that Tailor the Tinker has taken up arms, he always found the rotational velocity of gun cylinders unsatisfactory.\n\nAn electric motor fixes this.", "electriccylinder_icon", assetbundle: true);
		ItemBuilder.AddPassiveStatModifier(val, (StatType)1, 2f, (ModifyMethod)1);
		ItemBuilder.AddPassiveStatModifier(val, (StatType)10, 0.5f, (ModifyMethod)1);
		val.quality = (ItemQuality)5;
		val.SetupUnlockOnCustomFlag(CustomDungeonFlags.RAT_KILLED_ROBOT, requiredFlagValue: true);
		ID = val.PickupObjectId;
	}

	public override void Pickup(PlayerController player)
	{
		player.OnReloadedGun = (Action<PlayerController, Gun>)Delegate.Combine(player.OnReloadedGun, new Action<PlayerController, Gun>(OnReload));
		((PassiveItem)this).Pickup(player);
	}

	public override void DisableEffect(PlayerController player)
	{
		if (Object.op_Implicit((Object)(object)player))
		{
			player.OnReloadedGun = (Action<PlayerController, Gun>)Delegate.Remove(player.OnReloadedGun, new Action<PlayerController, Gun>(OnReload));
		}
		((PassiveItem)this).DisableEffect(player);
	}

	private void OnReload(PlayerController player, Gun gun)
	{
		AkSoundEngine.PostEvent("electricdrillbuzz", ((Component)this).gameObject);
	}
}
