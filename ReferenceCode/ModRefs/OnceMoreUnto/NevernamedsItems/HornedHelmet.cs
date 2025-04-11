using System;
using Alexandria.ItemAPI;
using Alexandria.Misc;
using UnityEngine;

namespace NevernamedsItems;

internal class HornedHelmet : PassiveItem
{
	public static int HornedHelmetID;

	public static void Init()
	{
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		PickupObject obj = ItemSetup.NewItem<HornedHelmet>("Horned Helmet", "19 STR 7 INT", "You burst into a berserker rage upon the mere sight of fresh prey. What a monster!", "hornedhelmet_icon", assetbundle: true);
		PassiveItem val = (PassiveItem)(object)((obj is PassiveItem) ? obj : null);
		((PickupObject)val).quality = (ItemQuality)3;
		ItemBuilder.AddToSubShop((PickupObject)(object)val, (ShopType)3, 1f);
		HornedHelmetID = ((PickupObject)val).PickupObjectId;
	}

	public override void Pickup(PlayerController player)
	{
		player.OnEnteredCombat = (Action)Delegate.Combine(player.OnEnteredCombat, new Action(OnEnteredCombat));
		((PassiveItem)this).Pickup(player);
	}

	public override void DisableEffect(PlayerController player)
	{
		player.OnEnteredCombat = (Action)Delegate.Remove(player.OnEnteredCombat, new Action(OnEnteredCombat));
		((PassiveItem)this).DisableEffect(player);
	}

	private void OnEnteredCombat()
	{
		if (Object.op_Implicit((Object)(object)((PassiveItem)this).Owner) && Object.op_Implicit((Object)(object)PlayerUtility.GetExtComp(((PassiveItem)this).Owner)))
		{
			PlayerUtility.GetExtComp(((PassiveItem)this).Owner).Enrage(3f, true);
		}
	}
}
