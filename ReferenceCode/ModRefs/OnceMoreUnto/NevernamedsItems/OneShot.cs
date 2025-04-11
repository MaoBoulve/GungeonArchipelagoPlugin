using Alexandria.ItemAPI;

namespace NevernamedsItems;

public class OneShot : PassiveItem
{
	public static int OneShotID;

	public static void Init()
	{
		//IL_0170: Unknown result type (might be due to invalid IL or missing references)
		PickupObject val = ItemSetup.NewItem<OneShot>("1 Shot", "+1 to Everything", "Increases almost every single stat by exactly 1.\n\nHow good or bad that is really depends on the stat.", "1shot_icon", assetbundle: true);
		ItemBuilder.AddPassiveStatModifier(val, (StatType)5, 1f, (ModifyMethod)0);
		ItemBuilder.AddPassiveStatModifier(val, (StatType)2, 1f, (ModifyMethod)0);
		ItemBuilder.AddPassiveStatModifier(val, (StatType)18, 1f, (ModifyMethod)0);
		ItemBuilder.AddPassiveStatModifier(val, (StatType)16, 1f, (ModifyMethod)0);
		ItemBuilder.AddPassiveStatModifier(val, (StatType)9, 1f, (ModifyMethod)0);
		ItemBuilder.AddPassiveStatModifier(val, (StatType)25, 1f, (ModifyMethod)0);
		ItemBuilder.AddPassiveStatModifier(val, (StatType)4, 1f, (ModifyMethod)0);
		ItemBuilder.AddPassiveStatModifier(val, (StatType)14, 1f, (ModifyMethod)0);
		ItemBuilder.AddPassiveStatModifier(val, (StatType)22, 1f, (ModifyMethod)0);
		ItemBuilder.AddPassiveStatModifier(val, (StatType)21, 1f, (ModifyMethod)0);
		ItemBuilder.AddPassiveStatModifier(val, (StatType)27, 1f, (ModifyMethod)0);
		ItemBuilder.AddPassiveStatModifier(val, (StatType)28, 1f, (ModifyMethod)0);
		ItemBuilder.AddPassiveStatModifier(val, (StatType)23, 1f, (ModifyMethod)0);
		ItemBuilder.AddPassiveStatModifier(val, (StatType)13, 0.1f, (ModifyMethod)0);
		ItemBuilder.AddPassiveStatModifier(val, (StatType)3, 1f, (ModifyMethod)0);
		ItemBuilder.AddPassiveStatModifier(val, (StatType)12, 0.1f, (ModifyMethod)0);
		ItemBuilder.AddPassiveStatModifier(val, (StatType)0, 1f, (ModifyMethod)0);
		ItemBuilder.AddPassiveStatModifier(val, (StatType)15, 1f, (ModifyMethod)0);
		ItemBuilder.AddPassiveStatModifier(val, (StatType)6, 1f, (ModifyMethod)0);
		ItemBuilder.AddPassiveStatModifier(val, (StatType)26, 1f, (ModifyMethod)0);
		ItemBuilder.AddPassiveStatModifier(val, (StatType)1, 1f, (ModifyMethod)0);
		ItemBuilder.AddPassiveStatModifier(val, (StatType)10, 1f, (ModifyMethod)0);
		ItemBuilder.AddPassiveStatModifier(val, (StatType)20, 1f, (ModifyMethod)0);
		val.quality = (ItemQuality)5;
		AlexandriaTags.SetTag(val, "bullet_modifier");
		OneShotID = val.PickupObjectId;
		Doug.AddToLootPool(val.PickupObjectId, 0.1f);
	}
}
