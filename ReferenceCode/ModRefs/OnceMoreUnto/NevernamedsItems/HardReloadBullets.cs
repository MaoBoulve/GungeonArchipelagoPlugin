using Alexandria.ItemAPI;

namespace NevernamedsItems;

public class HardReloadBullets : PassiveItem
{
	public static void Init()
	{
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		PickupObject val = ItemSetup.NewItem<HardReloadBullets>("Hard Reload Bullets", "Slippery Buggers", "These bullets were made by a narcissistic gunslinger purely to flex his highly trained fine motor skills on others.", "hardreloadbullets_icon", assetbundle: true);
		ItemBuilder.AddPassiveStatModifier(val, (StatType)10, 1.5f, (ModifyMethod)1);
		ItemBuilder.AddPassiveStatModifier(val, (StatType)5, 1.3f, (ModifyMethod)1);
		val.quality = (ItemQuality)2;
		AlexandriaTags.SetTag(val, "bullet_modifier");
		ItemBuilder.AddToSubShop(val, (ShopType)3, 1f);
		Doug.AddToLootPool(val.PickupObjectId);
	}
}
