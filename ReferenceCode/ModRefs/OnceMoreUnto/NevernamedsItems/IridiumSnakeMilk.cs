using Alexandria.ItemAPI;

namespace NevernamedsItems;

public class IridiumSnakeMilk : PassiveItem
{
	public static void Init()
	{
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		PickupObject val = ItemSetup.NewItem<IridiumSnakeMilk>("Iridium Snake Milk", "All Speed Up", "The imbibing of this vile tasting milk increases the speed of everything one does.\n\nOriginally given as a reward to those who reached the deepest depths of the Black Powder Mine.", "iridiumsnakemilk_icon", assetbundle: true);
		ItemBuilder.AddPassiveStatModifier(val, (StatType)6, 1.25f, (ModifyMethod)1);
		ItemBuilder.AddPassiveStatModifier(val, (StatType)10, 0.75f, (ModifyMethod)1);
		ItemBuilder.AddPassiveStatModifier(val, (StatType)1, 1.25f, (ModifyMethod)1);
		ItemBuilder.AddPassiveStatModifier(val, (StatType)25, 1.25f, (ModifyMethod)1);
		ItemBuilder.AddPassiveStatModifier(val, (StatType)0, 2f, (ModifyMethod)0);
		val.quality = (ItemQuality)4;
	}
}
