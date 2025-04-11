using System;
using Alexandria.ItemAPI;
using SaveAPI;
using UnityEngine;

namespace NevernamedsItems;

public class TitanBullets : PassiveItem
{
	public static int ID;

	public static void Init()
	{
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		PickupObject val = ItemSetup.NewItem<TitanBullets>("Titan Bullets", "Absolute Unit", "Bullets increase massively in size, and slightly in damage.\n\nThese bullets are so big that enemies are left in shock and awe.", "titanbullets_icon", assetbundle: true);
		ItemBuilder.AddPassiveStatModifier(val, (StatType)15, 10f, (ModifyMethod)1);
		ItemBuilder.AddPassiveStatModifier(val, (StatType)5, 1.05f, (ModifyMethod)1);
		val.quality = (ItemQuality)1;
		AlexandriaTags.SetTag(val, "bullet_modifier");
		val.SetupUnlockOnCustomStat(CustomTrackedStats.TITAN_KIN_KILLED, 4f, (PrerequisiteOperation)2);
		ID = val.PickupObjectId;
		Doug.AddToLootPool(val.PickupObjectId);
	}

	public override void Pickup(PlayerController player)
	{
		player.PostProcessProjectile += PostProcessProjectile;
		((PassiveItem)this).Pickup(player);
	}

	private void PostProcessProjectile(Projectile sourceProjectile, float effectChanceScalar)
	{
		if (Random.value < 0.3f * effectChanceScalar)
		{
			sourceProjectile.OnHitEnemy = (Action<Projectile, SpeculativeRigidbody, bool>)Delegate.Combine(sourceProjectile.OnHitEnemy, new Action<Projectile, SpeculativeRigidbody, bool>(AddStunEffect));
		}
	}

	private void AddStunEffect(Projectile arg1, SpeculativeRigidbody arg2, bool arg3)
	{
		if ((Object)(object)arg2 != (Object)null && ((BraveBehaviour)arg2).healthHaver.IsAlive && !((BraveBehaviour)arg2).healthHaver.IsBoss)
		{
			((BraveBehaviour)arg2).behaviorSpeculator.Stun(1f, true);
		}
	}

	public override void DisableEffect(PlayerController player)
	{
		if (Object.op_Implicit((Object)(object)((PassiveItem)this).Owner))
		{
			player.PostProcessProjectile -= PostProcessProjectile;
		}
		((PassiveItem)this).DisableEffect(player);
	}
}
