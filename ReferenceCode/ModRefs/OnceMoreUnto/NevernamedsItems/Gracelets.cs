using Alexandria.ItemAPI;
using SaveAPI;

namespace NevernamedsItems;

public class Gracelets : PassiveItem
{
	public static int ID;

	public static void Init()
	{
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		PickupObject val = ItemSetup.NewItem<Gracelets>("Gracelets", "Make a Match", "Powerful enchanted bracelets, they resonate with harmonising power- bending fate to encourage even greater levels of synergy.\n\nCreated by a powerful sorceress from the moon Sniperion.", "gracelets_icon", assetbundle: true);
		ItemBuilder.AddPassiveStatModifier(val, (StatType)4, 1f, (ModifyMethod)0);
		val.quality = (ItemQuality)3;
		ID = val.PickupObjectId;
		val.SetupUnlockOnFlag((GungeonFlags)58001, requiredFlagValue: true);
	}
}
