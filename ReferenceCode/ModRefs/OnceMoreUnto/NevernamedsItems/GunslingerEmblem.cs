using Alexandria.ItemAPI;

namespace NevernamedsItems;

public class GunslingerEmblem : PassiveItem
{
	public static void Init()
	{
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		PickupObject val = ItemSetup.NewItem<GunslingerEmblem>("Gunslinger Emblem", "Class Divide", "Serves as a helpful buff for Gunslinger Class warriors. Fortunately, that's pretty much everyone here.", "gunslingeremblem_improved", assetbundle: true);
		ItemBuilder.AddPassiveStatModifier(val, (StatType)26, 1.1f, (ModifyMethod)1);
		ItemBuilder.AddPassiveStatModifier(val, (StatType)10, 0.9f, (ModifyMethod)1);
		ItemBuilder.AddPassiveStatModifier(val, (StatType)1, 1.1f, (ModifyMethod)1);
		ItemBuilder.AddPassiveStatModifier(val, (StatType)5, 1.1f, (ModifyMethod)1);
		val.quality = (ItemQuality)3;
	}
}
