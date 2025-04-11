using Alexandria.ItemAPI;

namespace NevernamedsItems;

public class NumberOneBossMug : PassiveItem
{
	public static void Init()
	{
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		PickupObject val = ItemSetup.NewItem<NumberOneBossMug>("#1 Boss Mug", "You're the boss now", "Slightly increased damage against bosses.\n\nThe inscription on this eldritch relic gives you all the confidence you need to boss around the boss.", "numberonebossmug_improved", assetbundle: true);
		ItemBuilder.AddPassiveStatModifier(val, (StatType)22, 1.25f, (ModifyMethod)1);
		val.quality = (ItemQuality)2;
	}
}
