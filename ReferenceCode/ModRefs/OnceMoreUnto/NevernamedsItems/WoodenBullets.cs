using Alexandria.ItemAPI;

namespace NevernamedsItems;

public class WoodenBullets : PassiveItem
{
	public static void Init()
	{
		//IL_0092: Unknown result type (might be due to invalid IL or missing references)
		PickupObject val = ItemSetup.NewItem<WoodenBullets>("Wooden Bullets", "Staple Material", "Gives a very minor increase to all bullet related stats.\n\nMade of rich mahoguny.", "woodenbullets_improved", assetbundle: true);
		ItemBuilder.AddPassiveStatModifier(val, (StatType)12, 1.05f, (ModifyMethod)1);
		ItemBuilder.AddPassiveStatModifier(val, (StatType)1, 1.05f, (ModifyMethod)1);
		ItemBuilder.AddPassiveStatModifier(val, (StatType)10, 0.95f, (ModifyMethod)1);
		ItemBuilder.AddPassiveStatModifier(val, (StatType)5, 1.05f, (ModifyMethod)1);
		ItemBuilder.AddPassiveStatModifier(val, (StatType)15, 1.05f, (ModifyMethod)1);
		ItemBuilder.AddPassiveStatModifier(val, (StatType)6, 1.05f, (ModifyMethod)1);
		ItemBuilder.AddPassiveStatModifier(val, (StatType)26, 1.05f, (ModifyMethod)1);
		ItemBuilder.AddPassiveStatModifier(val, (StatType)2, 0.95f, (ModifyMethod)1);
		val.quality = (ItemQuality)1;
		AlexandriaTags.SetTag(val, "bullet_modifier");
		Doug.AddToLootPool(val.PickupObjectId);
	}
}
