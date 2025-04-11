using SaveAPI;
using UnityEngine;

namespace NevernamedsItems;

internal class ExoskeletalArmour : PassiveItem
{
	public static int MeatShieldID;

	public static void Init()
	{
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		PickupObject obj = ItemSetup.NewItem<ExoskeletalArmour>("Meat Shield", "Self Sacrifice", "Causes health to take damage before armour, and gives a little of both.", "meatshield_improved", assetbundle: true);
		PassiveItem val = (PassiveItem)(object)((obj is PassiveItem) ? obj : null);
		((PickupObject)val).quality = (ItemQuality)1;
		((PickupObject)(object)val).SetupUnlockOnCustomFlag(CustomDungeonFlags.PURCHASED_MEATSHIELD, requiredFlagValue: true);
		((PickupObject)(object)val).AddItemToDougMetaShop(15, null);
		val.ArmorToGainOnInitialPickup = 2;
		MeatShieldID = ((PickupObject)val).PickupObjectId;
	}

	public override void Update()
	{
		if (Object.op_Implicit((Object)(object)((PassiveItem)this).Owner) && !((PassiveItem)this).Owner.ForceZeroHealthState && !((BraveBehaviour)((PassiveItem)this).Owner).healthHaver.NextDamageIgnoresArmor && ((BraveBehaviour)((PassiveItem)this).Owner).healthHaver.GetCurrentHealth() >= 0.5f)
		{
			((BraveBehaviour)((PassiveItem)this).Owner).healthHaver.NextDamageIgnoresArmor = true;
		}
	}

	public override void Pickup(PlayerController player)
	{
		if (!base.m_pickedUpThisRun)
		{
			((BraveBehaviour)player).healthHaver.ApplyHealing(1f);
		}
		((PassiveItem)this).Pickup(player);
	}
}
