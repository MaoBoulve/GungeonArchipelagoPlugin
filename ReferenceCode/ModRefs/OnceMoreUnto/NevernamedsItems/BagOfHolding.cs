using Alexandria.ItemAPI;
using UnityEngine;

namespace NevernamedsItems;

public class BagOfHolding : PassiveItem
{
	public static void Init()
	{
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		PickupObject obj = ItemSetup.NewItem<BagOfHolding>("Bag of Holding", "Space Gallore", "Drastically increases active item storage.\n\nThe mad wizard Alben Smallbore theorised that bags such as these could be turned into violent explosive devices if they were ever punctured. Sadly, his research was never realised.", "bagofholding_icon", assetbundle: true);
		PassiveItem val = (PassiveItem)(object)((obj is PassiveItem) ? obj : null);
		ItemBuilder.AddPassiveStatModifier((PickupObject)(object)val, (StatType)8, 10f, (ModifyMethod)0);
		((PickupObject)val).quality = (ItemQuality)4;
		ItemBuilder.AddToSubShop((PickupObject)(object)val, (ShopType)2, 1f);
	}

	public override void Pickup(PlayerController player)
	{
		bool pickedUpThisRun = base.m_pickedUpThisRun;
		((PassiveItem)this).Pickup(player);
		if (!pickedUpThisRun)
		{
			PlayerItem itemOfTypeAndQuality = LootEngine.GetItemOfTypeAndQuality<PlayerItem>((ItemQuality)4, GameManager.Instance.RewardManager.ItemsLootTable, true);
			LootEngine.TryGivePrefabToPlayer(((Component)itemOfTypeAndQuality).gameObject, ((PassiveItem)this).Owner, false);
		}
	}
}
