using Alexandria.ItemAPI;
using Alexandria.Misc;

namespace NevernamedsItems;

public class ExaltedHeart : PassiveItem
{
	public static int ExaltedHeartID;

	public static void Init()
	{
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		PickupObject val = ItemSetup.NewItem<ExaltedHeart>("Exalted Heart", "Praise Be Kaliber", "This ornate heart throbs with the power of Kaliber.", "exaltedheart_icon", assetbundle: true);
		ItemBuilder.AddPassiveStatModifier(val, (StatType)3, 1f, (ModifyMethod)0);
		val.quality = (ItemQuality)2;
		ExaltedHeartID = val.PickupObjectId;
		LootUtility.RemovePickupFromLootTables(val);
	}
}
