using System;
using Alexandria.EnemyAPI;
using UnityEngine;

namespace NevernamedsItems;

public class Eraser : PassiveItem
{
	public static void Init()
	{
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		PickupObject obj = ItemSetup.NewItem<Eraser>("Eraser", "Now I Only Want You Gone", "Chance to erase enemy bullets.\n\nDesigned to remove mistakes, including that mistake of walking into that bullet that you were just about to make!", "eraser_icon", assetbundle: true);
		PassiveItem val = (PassiveItem)(object)((obj is PassiveItem) ? obj : null);
		((PickupObject)val).quality = (ItemQuality)3;
	}

	private void PostProcessProjectile(Projectile sourceProjectile, float effectChanceScalar)
	{
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		float num = 0.25f * effectChanceScalar;
		if (Random.value <= num)
		{
			sourceProjectile.AdjustPlayerProjectileTint(ExtendedColours.pink, 2, 0f);
			sourceProjectile.OnHitEnemy = (Action<Projectile, SpeculativeRigidbody, bool>)Delegate.Combine(sourceProjectile.OnHitEnemy, new Action<Projectile, SpeculativeRigidbody, bool>(OnHit));
		}
	}

	private void OnHit(Projectile proj, SpeculativeRigidbody enemy, bool fatal)
	{
		if (Object.op_Implicit((Object)(object)enemy) && Object.op_Implicit((Object)(object)((BraveBehaviour)enemy).gameActor) && Object.op_Implicit((Object)(object)((BraveBehaviour)enemy).healthHaver))
		{
			float num = 1f;
			if (((BraveBehaviour)enemy).healthHaver.IsBoss)
			{
				num = 0.33f;
			}
			AIActorUtility.DeleteOwnedBullets(((BraveBehaviour)enemy).gameActor, num, false);
		}
	}

	private void PostProcessBeam(BeamController beam, SpeculativeRigidbody enemy, float tickrate)
	{
		float num = 0.25f;
		GameActor gameActor = ((BraveBehaviour)enemy).gameActor;
		if (Object.op_Implicit((Object)(object)gameActor) && Random.value < BraveMathCollege.SliceProbability(num, tickrate) && Object.op_Implicit((Object)(object)enemy) && Object.op_Implicit((Object)(object)((BraveBehaviour)enemy).gameActor) && Object.op_Implicit((Object)(object)((BraveBehaviour)enemy).healthHaver))
		{
			float num2 = 1f;
			if (((BraveBehaviour)enemy).healthHaver.IsBoss)
			{
				num2 = 0.33f;
			}
			AIActorUtility.DeleteOwnedBullets(((BraveBehaviour)enemy).gameActor, num2, false);
		}
	}

	public override DebrisObject Drop(PlayerController player)
	{
		DebrisObject result = ((PassiveItem)this).Drop(player);
		player.PostProcessProjectile -= PostProcessProjectile;
		player.PostProcessBeamTick -= PostProcessBeam;
		return result;
	}

	public override void Pickup(PlayerController player)
	{
		((PassiveItem)this).Pickup(player);
		player.PostProcessProjectile += PostProcessProjectile;
		player.PostProcessBeamTick += PostProcessBeam;
	}

	public override void OnDestroy()
	{
		if (Object.op_Implicit((Object)(object)((PassiveItem)this).Owner))
		{
			((PassiveItem)this).Owner.PostProcessBeamTick -= PostProcessBeam;
			((PassiveItem)this).Owner.PostProcessProjectile -= PostProcessProjectile;
		}
		((PassiveItem)this).OnDestroy();
	}
}
