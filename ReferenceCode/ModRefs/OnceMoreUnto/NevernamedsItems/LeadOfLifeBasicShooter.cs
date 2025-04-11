using System;
using System.Collections.Generic;
using System.Linq;
using Alexandria.Misc;
using UnityEngine;

namespace NevernamedsItems;

internal class LeadOfLifeBasicShooter : LeadOfLifeCompanion
{
	public List<Projectile> bulletsToFire;

	public float angleVariance;

	public bool multiShotsSequential;

	private int lastFiredSequential;

	public new static LeadOfLifeBasicShooter AddToPrefab(GameObject prefab, int itemID, float moveSpeed = 5f, List<MovementBehaviorBase> movementBehaviors = null)
	{
		//IL_0091: Unknown result type (might be due to invalid IL or missing references)
		//IL_0098: Expected O, but got Unknown
		LeadOfLifeBasicShooter leadOfLifeBasicShooter = prefab.AddComponent<LeadOfLifeBasicShooter>();
		((BraveBehaviour)leadOfLifeBasicShooter).aiActor.MovementSpeed = moveSpeed;
		leadOfLifeBasicShooter.tiedItemID = itemID;
		((BraveBehaviour)leadOfLifeBasicShooter).aiAnimator.GetDirectionalAnimation("idle").Prefix = "idle";
		if (((BraveBehaviour)leadOfLifeBasicShooter).aiAnimator.GetDirectionalAnimation("move") != null)
		{
			((BraveBehaviour)leadOfLifeBasicShooter).aiAnimator.GetDirectionalAnimation("move").Prefix = "run";
		}
		BehaviorSpeculator component = prefab.GetComponent<BehaviorSpeculator>();
		if (movementBehaviors == null)
		{
			List<MovementBehaviorBase> movementBehaviors2 = component.MovementBehaviors;
			List<MovementBehaviorBase> list = new List<MovementBehaviorBase> { (MovementBehaviorBase)(object)new CustomCompanionBehaviours.LeadOfLifeCompanionApproach() };
			CompanionFollowPlayerBehavior val = new CompanionFollowPlayerBehavior();
			val.IdleAnimations = new string[1] { "idle" };
			list.Add((MovementBehaviorBase)(object)val);
			movementBehaviors2.AddRange(list);
		}
		else
		{
			component.MovementBehaviors.AddRange(movementBehaviors);
		}
		return leadOfLifeBasicShooter;
	}

	public LeadOfLifeBasicShooter()
	{
		bulletsToFire = new List<Projectile>();
		angleVariance = 15f;
		multiShotsSequential = false;
		lastFiredSequential = 0;
	}

	public override void Attack()
	{
		if (multiShotsSequential)
		{
			FireBullets(bulletsToFire[lastFiredSequential]);
			lastFiredSequential++;
			if (lastFiredSequential > bulletsToFire.Count() - 1)
			{
				lastFiredSequential = 0;
			}
		}
		else
		{
			foreach (Projectile item in bulletsToFire)
			{
				FireBullets(item);
			}
		}
		timesAttacked++;
		base.Attack();
	}

	private void FireBullets(Projectile projectileToFire)
	{
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		if ((Object)(object)((BraveBehaviour)this).aiActor.OverrideTarget != (Object)null)
		{
			Vector2 targetPosition = (((Object)(object)((BraveBehaviour)((BraveBehaviour)this).aiActor.OverrideTarget).sprite != (Object)null) ? ((BraveBehaviour)((BraveBehaviour)this).aiActor.OverrideTarget).sprite.WorldCenter : ((BraveBehaviour)this).aiActor.OverrideTarget.UnitCenter);
			GameObject val = ProjSpawnHelper.SpawnProjectileTowardsPoint(((Component)projectileToFire).gameObject, ((BraveBehaviour)this).sprite.WorldCenter, targetPosition, 0f, angleVariance);
			Projectile component = val.GetComponent<Projectile>();
			if ((Object)(object)component != (Object)null)
			{
				component.Owner = (GameActor)(object)Owner;
				component.TreatedAsNonProjectileForChallenge = true;
				component.Shooter = ((BraveBehaviour)this).specRigidbody;
				component.collidesWithPlayer = false;
				component.OnHitEnemy = (Action<Projectile, SpeculativeRigidbody, bool>)Delegate.Combine(component.OnHitEnemy, new Action<Projectile, SpeculativeRigidbody, bool>(OnHitEnemy));
				ProjectileUtility.ApplyCompanionModifierToBullet(component, Owner);
				PostProcessProjectile(component);
			}
		}
	}

	private void OnHitEnemy(Projectile bullet, SpeculativeRigidbody enemy, bool fatal)
	{
		LandedShotOnEnemy(enemy, bullet, fatal);
	}

	public virtual void PostProcessProjectile(Projectile projectile)
	{
	}

	public virtual void LandedShotOnEnemy(SpeculativeRigidbody enemy, Projectile projectile, bool fatal)
	{
	}
}
