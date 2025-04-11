using Alexandria.ItemAPI;
using UnityEngine;

namespace NevernamedsItems;

public class IronSights : PassiveItem
{
	public static int IronSightsID;

	public static void Init()
	{
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		PickupObject val = ItemSetup.NewItem<IronSights>("Iron Sights", "Sturdy and Standard", "This convenient little knick-knack clips on to your gun, making it much easier to aim.\n\nThe previous owner seems to have clipped it onto a key... perhaps they were having trouble getting it in the lock?", "ironsights_improved", assetbundle: true);
		ItemBuilder.AddPassiveStatModifier(val, (StatType)2, 0.6f, (ModifyMethod)1);
		val.quality = (ItemQuality)1;
		ItemBuilder.AddToSubShop(val, (ShopType)3, 1f);
		IronSightsID = val.PickupObjectId;
	}

	public override void Pickup(PlayerController player)
	{
		if (!base.m_pickedUpThisRun)
		{
			LootEngine.GivePrefabToPlayer(((Component)PickupObjectDatabase.GetById(67)).gameObject, player);
		}
		((PassiveItem)this).Pickup(player);
	}
}
