using Alexandria.ItemAPI;

namespace NevernamedsItems;

public class HeavyChamber : PassiveItem
{
	public static int HeavyChamberID;

	public static void Init()
	{
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		PickupObject val = ItemSetup.NewItem<HeavyChamber>("Heavy Chamber", "Trade-off", "Doubles clip size, but also doubles the time it takes to reload.\n\nThis chamber is sturdy enough to carry many more bullets, but reloading it is a pain.", "heavychamber_icon", assetbundle: true);
		ItemBuilder.AddPassiveStatModifier(val, (StatType)10, 2f, (ModifyMethod)1);
		ItemBuilder.AddPassiveStatModifier(val, (StatType)16, 2f, (ModifyMethod)1);
		val.CanBeDropped = true;
		val.quality = (ItemQuality)3;
		HeavyChamberID = val.PickupObjectId;
	}
}
