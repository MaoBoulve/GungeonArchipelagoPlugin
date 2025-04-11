using Alexandria.ItemAPI;

namespace NevernamedsItems;

public class HeartContainer : PassiveItem
{
	public static int ID;

	public static void Init()
	{
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		PickupObject val = ItemSetup.NewItem<HeartContainer>("Heart Container", "Back to Basics", "A high quality health storage device.\n\nDungeon divers have used devices like these for decades to avoid an untimely death.", "heartcontainer_icon", assetbundle: true);
		ItemBuilder.AddPassiveStatModifier(val, (StatType)3, 1f, (ModifyMethod)0);
		val.quality = (ItemQuality)3;
		val.ItemSpansBaseQualityTiers = true;
		val.ItemRespectsHeartMagnificence = true;
		ID = val.PickupObjectId;
	}

	public override void Pickup(PlayerController player)
	{
		if (!base.m_pickedUpThisRun)
		{
			((BraveBehaviour)player).healthHaver.ApplyHealing(100f);
		}
		((PassiveItem)this).Pickup(player);
	}
}
