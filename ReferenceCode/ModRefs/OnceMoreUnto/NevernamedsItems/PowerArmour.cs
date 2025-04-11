using Alexandria.ItemAPI;
using SaveAPI;

namespace NevernamedsItems;

public class PowerArmour : PassiveItem
{
	public static int PowerArmourID;

	public static void Init()
	{
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		PickupObject val = ItemSetup.NewItem<PowerArmour>("Power Armour", "Power Fantasy", "A high tech suit of armour from a small planet on the rim of explored space. It's layered plasteel composition makes it incredibly tough.", "powerarmour_improved", assetbundle: true);
		val.CanBeDropped = false;
		val.quality = (ItemQuality)4;
		ItemBuilder.AddToSubShop(val, (ShopType)3, 1f);
		val.SetupUnlockOnCustomFlag(CustomDungeonFlags.PURCHASED_POWERARMOUR, requiredFlagValue: true);
		PowerArmourID = val.PickupObjectId;
	}

	public override void Pickup(PlayerController player)
	{
		if (!base.m_pickedUpThisRun)
		{
			HealthHaver healthHaver = ((BraveBehaviour)player).healthHaver;
			healthHaver.Armor += 8f;
		}
		((PassiveItem)this).Pickup(player);
	}
}
