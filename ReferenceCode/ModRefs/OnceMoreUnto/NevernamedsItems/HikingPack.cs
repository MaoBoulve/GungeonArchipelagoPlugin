using Alexandria.ItemAPI;

namespace NevernamedsItems;

public class HikingPack : PassiveItem
{
	public static void Init()
	{
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		PickupObject obj = ItemSetup.NewItem<HikingPack>("Hiking Pack", "Go Take A Hike", "A large pack intended for use in hiking.\n\nHas plenty of pockets to hide all your spice in.", "hikingpack_icon", assetbundle: true);
		PassiveItem val = (PassiveItem)(object)((obj is PassiveItem) ? obj : null);
		ItemBuilder.AddPassiveStatModifier((PickupObject)(object)val, (StatType)8, 2f, (ModifyMethod)0);
		((PickupObject)val).quality = (ItemQuality)2;
		ItemBuilder.AddToSubShop((PickupObject)(object)val, (ShopType)3, 1f);
	}
}
