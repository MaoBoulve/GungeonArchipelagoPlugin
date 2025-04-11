using SaveAPI;

namespace NevernamedsItems;

public class HoleyWater : PassiveItem
{
	public static int HoleyWaterID;

	public static void Init()
	{
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		PickupObject obj = ItemSetup.NewItem<HoleyWater>("Holey Water", "Pure", "Prevents the more esoteric effects of curse.\n\nDistilled with water taken from the elusive Shrine of Cleansing.", "holeywater_icon", assetbundle: true);
		PassiveItem val = (PassiveItem)(object)((obj is PassiveItem) ? obj : null);
		((PickupObject)val).quality = (ItemQuality)1;
		HoleyWaterID = ((PickupObject)val).PickupObjectId;
		((PickupObject)(object)val).SetupUnlockOnCustomFlag(CustomDungeonFlags.FLOOR_CLEARED_WITH_CURSE, requiredFlagValue: true);
	}

	public override void Pickup(PlayerController player)
	{
		((PassiveItem)this).Pickup(player);
	}

	public override DebrisObject Drop(PlayerController player)
	{
		return ((PassiveItem)this).Drop(player);
	}

	public override void OnDestroy()
	{
		((PassiveItem)this).OnDestroy();
	}
}
