using Alexandria.ItemAPI;
using UnityEngine;

namespace NevernamedsItems;

public class SpareBlank : PassiveItem
{
	public static void Init()
	{
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		PickupObject val = ItemSetup.NewItem<SpareBlank>("Spare Blank", "+1 to Blank", "Never hurts to have a spare.", "spareblank_new", assetbundle: true);
		ItemBuilder.AddPassiveStatModifier(val, (StatType)18, 1f, (ModifyMethod)0);
		val.quality = (ItemQuality)1;
		ItemBuilder.AddToSubShop(val, (ShopType)4, 1f);
	}

	public override void Pickup(PlayerController player)
	{
		if (!base.m_pickedUpThisRun)
		{
			LootEngine.GivePrefabToPlayer(((Component)PickupObjectDatabase.GetById(224)).gameObject, player);
		}
		((PassiveItem)this).Pickup(player);
	}
}
