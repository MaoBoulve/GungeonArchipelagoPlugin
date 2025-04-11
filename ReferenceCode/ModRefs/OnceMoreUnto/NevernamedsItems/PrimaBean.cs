using Alexandria.ItemAPI;

namespace NevernamedsItems;

public class PrimaBean : PassiveItem
{
	public static void Init()
	{
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		PickupObject val = ItemSetup.NewItem<PrimaBean>("Prima Bean", "Magic?", "There are strange magics coursing through this bean, like fiber! It’s good for your body damnit!", "primabean_improved", assetbundle: true);
		ItemBuilder.AddPassiveStatModifier(val, (StatType)3, 3f, (ModifyMethod)0);
		val.quality = (ItemQuality)5;
		ItemBuilder.AddToSubShop(val, (ShopType)2, 1f);
	}

	public override void Pickup(PlayerController player)
	{
		if (player.ForceZeroHealthState && !base.m_pickedUpThisRun)
		{
			HealthHaver healthHaver = ((BraveBehaviour)player).healthHaver;
			healthHaver.Armor += 3f;
		}
		((PassiveItem)this).Pickup(player);
	}
}
