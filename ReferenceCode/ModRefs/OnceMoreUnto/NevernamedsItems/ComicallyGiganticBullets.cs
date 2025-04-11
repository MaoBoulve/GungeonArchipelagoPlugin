using Alexandria.ItemAPI;

namespace NevernamedsItems;

internal class ComicallyGiganticBullets : PassiveItem
{
	public static void Init()
	{
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		PickupObject val = ItemSetup.NewItem<ComicallyGiganticBullets>("Comically Gigantic Bullets", "What is this?", "These were a very bad idea.'This item cannot appear in normal play, but I left it in the mod for people to give themselves because I'm a maniac.' - NN", "comicallygiganticbullets_icon", assetbundle: true);
		ItemBuilder.AddPassiveStatModifier(val, (StatType)5, 100f, (ModifyMethod)1);
		val.quality = (ItemQuality)(-100);
	}
}
