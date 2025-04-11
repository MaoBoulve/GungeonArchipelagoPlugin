using System;
using System.Collections.Generic;
using Alexandria.ItemAPI;
using Alexandria.Misc;
using Dungeonator;
using UnityEngine;

namespace NevernamedsItems;

internal class LeadOfLifeRandomShooter : LeadOfLifeCompanion
{
	public List<Projectile> bulletsToFire;

	public float angleVariance;

	public new static LeadOfLifeRandomShooter AddToPrefab(GameObject prefab, int itemID, float moveSpeed = 5f, List<MovementBehaviorBase> movementBehaviors = null)
	{
		//IL_0091: Unknown result type (might be due to invalid IL or missing references)
		//IL_0098: Expected O, but got Unknown
		LeadOfLifeRandomShooter leadOfLifeRandomShooter = prefab.AddComponent<LeadOfLifeRandomShooter>();
		((BraveBehaviour)leadOfLifeRandomShooter).aiActor.MovementSpeed = moveSpeed;
		leadOfLifeRandomShooter.tiedItemID = itemID;
		((BraveBehaviour)leadOfLifeRandomShooter).aiAnimator.GetDirectionalAnimation("idle").Prefix = "idle";
		if (((BraveBehaviour)leadOfLifeRandomShooter).aiAnimator.GetDirectionalAnimation("move") != null)
		{
			((BraveBehaviour)leadOfLifeRandomShooter).aiAnimator.GetDirectionalAnimation("move").Prefix = "run";
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
		return leadOfLifeRandomShooter;
	}

	public LeadOfLifeRandomShooter()
	{
		angleVariance = 15f;
	}

	public override void Attack()
	{
		DoChanceBulletsSpawn();
		timesAttacked++;
		base.Attack();
	}

	private void DoChanceBulletsSpawn()
	{
		//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ac: Invalid comparison between Unknown and I4
		//IL_00cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d1: Invalid comparison between Unknown and I4
		List<Projectile> list = new List<Projectile>();
		List<Projectile> list2 = new List<Projectile>();
		if (!Object.op_Implicit((Object)(object)Owner) || Owner.inventory == null)
		{
			return;
		}
		for (int i = 0; i < Owner.inventory.AllGuns.Count; i++)
		{
			if (!Object.op_Implicit((Object)(object)Owner.inventory.AllGuns[i]) || Owner.inventory.AllGuns[i].InfiniteAmmo)
			{
				continue;
			}
			ProjectileModule defaultModule = Owner.inventory.AllGuns[i].DefaultModule;
			if ((int)defaultModule.shootStyle == 2)
			{
				list2.Add(defaultModule.GetCurrentProjectile());
			}
			else if ((int)defaultModule.shootStyle == 3)
			{
				Projectile val = null;
				for (int j = 0; j < 15; j++)
				{
					ChargeProjectile val2 = defaultModule.chargeProjectiles[Random.Range(0, defaultModule.chargeProjectiles.Count)];
					if (val2 != null)
					{
						val = val2.Projectile;
					}
					if (Object.op_Implicit((Object)(object)val))
					{
						break;
					}
				}
				list.Add(val);
			}
			else
			{
				list.Add(defaultModule.GetCurrentProjectile());
			}
		}
		int num = list.Count + list2.Count;
		if (num > 0)
		{
			int num2 = Random.Range(0, num);
			if (num2 > list.Count)
			{
				FireBeams(BraveUtility.RandomElement<Projectile>(list2));
			}
			else
			{
				FireBullets(BraveUtility.RandomElement<Projectile>(list));
			}
		}
		else
		{
			PickupObject byId = PickupObjectDatabase.GetById(56);
			FireBullets(((Gun)((byId is Gun) ? byId : null)).DefaultModule.projectiles[0]);
		}
	}

	private void FireBullets(Projectile projectileToFire)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		AIActor nearestEnemyToPosition = MathsAndLogicHelper.GetNearestEnemyToPosition(((BraveBehaviour)this).sprite.WorldCenter, true, (ActiveEnemyType)1, (List<AIActor>)null, (Func<AIActor, bool>)null);
		if (Object.op_Implicit((Object)(object)nearestEnemyToPosition))
		{
			GameObject val = ProjSpawnHelper.SpawnProjectileTowardsPoint(((Component)projectileToFire).gameObject, ((BraveBehaviour)this).sprite.WorldCenter, Vector2.op_Implicit(nearestEnemyToPosition.Position), 0f, angleVariance);
			Projectile component = val.GetComponent<Projectile>();
			if ((Object)(object)component != (Object)null)
			{
				component.Owner = (GameActor)(object)Owner;
				component.TreatedAsNonProjectileForChallenge = true;
				component.Shooter = ((BraveBehaviour)this).specRigidbody;
				component.collidesWithPlayer = false;
				PostProcessProjectile(component);
			}
		}
	}

	private void FireBeams(Projectile beam)
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		BeamController beam2 = BeamAPI.FreeFireBeamFromAnywhere(beam, Owner, ((Component)this).gameObject, Vector2.zero, Vector2Extensions.ToAngle(GetAngleToFire()), 1f, true, false, 0f);
		PostProcessBeam(beam2);
	}

	public Vector2 GetAngleToFire()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		Vector2 val = MathsAndLogicHelper.GetPositionOfNearestEnemy(((BraveBehaviour)this).specRigidbody.UnitCenter, (ActorCenter)2, true, (ActiveEnemyType)1, (List<AIActor>)null, (Func<AIActor, bool>)null) - ((BraveBehaviour)this).specRigidbody.UnitCenter;
		return ((Vector2)(ref val)).normalized;
	}

	public virtual void PostProcessProjectile(Projectile projectile)
	{
	}

	public virtual void PostProcessBeam(BeamController beam)
	{
	}
}
