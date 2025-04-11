using Alexandria.ItemAPI;

namespace NevernamedsItems;

public class EndlessBullets : PassiveItem
{
	public static void Init()
	{
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		PickupObject val = ItemSetup.NewItem<EndlessBullets>("Endless Bullets", "And They Don't Stop Comin'", "Grants nigh infinite range on all weapons.\n\nIn the Gungeon, range is your ultimate advantage. Keep your distance from the enemy.", "endlessbullets_icon", assetbundle: true);
		ItemBuilder.AddPassiveStatModifier(val, (StatType)26, 100f, (ModifyMethod)1);
		val.quality = (ItemQuality)2;
		AlexandriaTags.SetTag(val, "bullet_modifier");
		Doug.AddToLootPool(val.PickupObjectId);
	}
}
