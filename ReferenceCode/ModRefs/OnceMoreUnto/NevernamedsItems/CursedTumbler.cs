using Alexandria.ItemAPI;
using SaveAPI;

namespace NevernamedsItems;

public class CursedTumbler : PassiveItem
{
	public static int CursedTumblerID;

	public static void Init()
	{
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		PickupObject val = ItemSetup.NewItem<CursedTumbler>("Cursed Tumbler", "What's In The Box?", "Gives chests a chance to be Jammed.\n\nAn 4th dimensional set of mechanisms designed to lock away all evil in this world.", "cursedtumbler_improved", assetbundle: true);
		ItemBuilder.AddPassiveStatModifier(val, (StatType)14, 1f, (ModifyMethod)0);
		val.CanBeDropped = true;
		val.quality = (ItemQuality)3;
		CursedTumblerID = val.PickupObjectId;
		val.SetupUnlockOnCustomStat(CustomTrackedStats.JAMMED_CHESTS_OPENED, 0f, (PrerequisiteOperation)2);
	}
}
