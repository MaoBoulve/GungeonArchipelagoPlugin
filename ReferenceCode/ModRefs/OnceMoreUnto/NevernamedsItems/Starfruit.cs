using Alexandria.ItemAPI;

namespace NevernamedsItems;

public class Starfruit : PassiveItem
{
	public static void Init()
	{
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		PickupObject val = ItemSetup.NewItem<Starfruit>("Starfruit", "Like a Dream", "Increases most stats.\n\nThis mysterious fruit tastes different to all who eat it.", "starfruit_icon", assetbundle: true);
		ItemBuilder.AddPassiveStatModifier(val, (StatType)6, 1.15f, (ModifyMethod)1);
		ItemBuilder.AddPassiveStatModifier(val, (StatType)26, 1.15f, (ModifyMethod)1);
		ItemBuilder.AddPassiveStatModifier(val, (StatType)10, 0.85f, (ModifyMethod)1);
		ItemBuilder.AddPassiveStatModifier(val, (StatType)1, 1.15f, (ModifyMethod)1);
		ItemBuilder.AddPassiveStatModifier(val, (StatType)9, 1.15f, (ModifyMethod)1);
		ItemBuilder.AddPassiveStatModifier(val, (StatType)5, 1.15f, (ModifyMethod)1);
		ItemBuilder.AddPassiveStatModifier(val, (StatType)2, 0.85f, (ModifyMethod)1);
		val.quality = (ItemQuality)5;
	}
}
