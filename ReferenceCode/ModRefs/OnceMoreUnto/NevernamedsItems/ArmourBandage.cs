using System;
using UnityEngine;

namespace NevernamedsItems;

public class ArmourBandage : PassiveItem
{
	public static int ArmourBandageID;

	public static void Init()
	{
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		PickupObject obj = ItemSetup.NewItem<ArmourBandage>("Armour Bandage", "Hurtful Heals", "Taking damage to armour heals half a heart.\n\nA simple recipe for recycling broken armour into medical supplies.", "armourbandage_icon", assetbundle: true);
		PassiveItem val = (PassiveItem)(object)((obj is PassiveItem) ? obj : null);
		((PickupObject)val).quality = (ItemQuality)1;
		ArmourBandageID = ((PickupObject)val).PickupObjectId;
		val.ArmorToGainOnInitialPickup = 1;
	}

	public override void Pickup(PlayerController player)
	{
		player.LostArmor = (Action)Delegate.Combine(player.LostArmor, new Action(OnLostArmor));
		((PassiveItem)this).Pickup(player);
	}

	public override DebrisObject Drop(PlayerController player)
	{
		player.LostArmor = (Action)Delegate.Remove(player.LostArmor, new Action(OnLostArmor));
		return ((PassiveItem)this).Drop(player);
	}

	public override void OnDestroy()
	{
		if (Object.op_Implicit((Object)(object)((PassiveItem)this).Owner))
		{
			((PassiveItem)this).Owner.LostArmor = (Action)Delegate.Remove(((PassiveItem)this).Owner.LostArmor, new Action(OnLostArmor));
		}
		((PassiveItem)this).OnDestroy();
	}

	private void OnLostArmor()
	{
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		if (Object.op_Implicit((Object)(object)((PassiveItem)this).Owner))
		{
			((BraveBehaviour)((PassiveItem)this).Owner).healthHaver.ApplyHealing(0.5f);
			AkSoundEngine.PostEvent("Play_OBJ_heart_heal_01", ((Component)((PassiveItem)this).Owner).gameObject);
			((GameActor)((PassiveItem)this).Owner).PlayEffectOnActor(((Component)PickupObjectDatabase.GetById(73)).GetComponent<HealthPickup>().healVFX, Vector3.zero, true, false, false);
		}
	}
}
