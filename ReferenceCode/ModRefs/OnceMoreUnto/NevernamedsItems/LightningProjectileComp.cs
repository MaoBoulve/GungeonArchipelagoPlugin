using System;
using System.Collections.Generic;
using Alexandria.Misc;
using Dungeonator;
using UnityEngine;

namespace NevernamedsItems;

public class LightningProjectileComp : MonoBehaviour
{
	public bool targetEnemies;

	public float wiggleCooldown;

	public float arcToEnemyRange;

	public float arcBetweenEnemiesRange;

	private float initialAngle;

	private float curTimer;

	private Projectile self;

	private PlayerController owner;

	private AIActor lastHitEnemy;

	private AIActor secondToLastHitEnemy;

	public LightningProjectileComp()
	{
		initialAngle = float.NegativeInfinity;
		targetEnemies = true;
		wiggleCooldown = 0.005f;
		arcToEnemyRange = 4f;
		arcBetweenEnemiesRange = 4f;
	}

	private void Start()
	{
		curTimer = wiggleCooldown;
		self = ((Component)this).GetComponent<Projectile>();
		Projectile obj = self;
		obj.OnHitEnemy = (Action<Projectile, SpeculativeRigidbody, bool>)Delegate.Combine(obj.OnHitEnemy, new Action<Projectile, SpeculativeRigidbody, bool>(OnHitEnemy));
		owner = ProjectileUtility.ProjectilePlayerOwner(self);
		if (Object.op_Implicit((Object)(object)((Component)self).GetComponent<BounceProjModifier>()))
		{
			BounceProjModifier component = ((Component)self).GetComponent<BounceProjModifier>();
			component.OnBounceContext = (Action<BounceProjModifier, SpeculativeRigidbody>)Delegate.Combine(component.OnBounceContext, new Action<BounceProjModifier, SpeculativeRigidbody>(OnBounce));
		}
	}

	private void OnBounce(BounceProjModifier mod, SpeculativeRigidbody collider)
	{
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		initialAngle = Vector2Extensions.ToAngle(self.Direction);
	}

	private void Update()
	{
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_012b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0098: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_010a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0112: Unknown result type (might be due to invalid IL or missing references)
		//IL_0117: Unknown result type (might be due to invalid IL or missing references)
		if (!Object.op_Implicit((Object)(object)self))
		{
			return;
		}
		if (curTimer > 0f)
		{
			curTimer -= BraveTime.DeltaTime;
			return;
		}
		if (initialAngle == float.NegativeInfinity)
		{
			initialAngle = Vector2Extensions.ToAngle(self.Direction);
		}
		float num = ProjSpawnHelper.GetAccuracyAngled(initialAngle, 80f, owner);
		if (targetEnemies)
		{
			AIActor nearestEnemyToPosition = MathsAndLogicHelper.GetNearestEnemyToPosition(((BraveBehaviour)self).specRigidbody.UnitCenter, true, (ActiveEnemyType)0, new List<AIActor> { lastHitEnemy, secondToLastHitEnemy }, (Func<AIActor, bool>)null);
			if ((Object)(object)nearestEnemyToPosition != (Object)null && Vector2.Distance(((BraveBehaviour)self).specRigidbody.UnitCenter, GivenActorPos(nearestEnemyToPosition)) < arcToEnemyRange)
			{
				num = Vector2Extensions.ToAngle(MathsAndLogicHelper.CalculateVectorBetween(((BraveBehaviour)self).specRigidbody.UnitCenter, GivenActorPos(nearestEnemyToPosition)));
			}
		}
		self.SendInDirection(MathsAndLogicHelper.DegreeToVector2(num), false, true);
		curTimer = wiggleCooldown;
	}

	private void OnHitEnemy(Projectile self, SpeculativeRigidbody enemy, bool fatal)
	{
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_0108: Unknown result type (might be due to invalid IL or missing references)
		//IL_0110: Unknown result type (might be due to invalid IL or missing references)
		//IL_0115: Unknown result type (might be due to invalid IL or missing references)
		//IL_0124: Unknown result type (might be due to invalid IL or missing references)
		if (!Object.op_Implicit((Object)(object)enemy) || !Object.op_Implicit((Object)(object)((BraveBehaviour)enemy).aiActor))
		{
			return;
		}
		if ((Object)(object)((BraveBehaviour)enemy).aiActor != (Object)(object)lastHitEnemy)
		{
			if ((Object)(object)lastHitEnemy != (Object)null)
			{
				secondToLastHitEnemy = lastHitEnemy;
			}
			lastHitEnemy = ((BraveBehaviour)enemy).aiActor;
		}
		if (!targetEnemies)
		{
			return;
		}
		AIActor nearestEnemyToPosition = MathsAndLogicHelper.GetNearestEnemyToPosition(enemy.UnitCenter, true, (ActiveEnemyType)0, new List<AIActor> { lastHitEnemy, secondToLastHitEnemy }, (Func<AIActor, bool>)null);
		if ((Object)(object)nearestEnemyToPosition != (Object)null && Vector2.Distance(enemy.UnitCenter, GivenActorPos(nearestEnemyToPosition)) < arcBetweenEnemiesRange)
		{
			PierceProjModifier component = ((Component)self).gameObject.GetComponent<PierceProjModifier>();
			if ((Object)(object)component != (Object)null)
			{
				component.penetration++;
			}
			else
			{
				((Component)self).gameObject.AddComponent<PierceProjModifier>();
			}
			float num = Vector2Extensions.ToAngle(MathsAndLogicHelper.CalculateVectorBetween(((BraveBehaviour)self).specRigidbody.UnitCenter, GivenActorPos(nearestEnemyToPosition)));
			self.SendInDirection(MathsAndLogicHelper.DegreeToVector2(num), true, true);
			curTimer = wiggleCooldown;
		}
	}

	private Vector2 GivenActorPos(AIActor actor)
	{
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		if ((Object)(object)((BraveBehaviour)actor).sprite != (Object)null)
		{
			return ((BraveBehaviour)actor).sprite.WorldCenter;
		}
		if ((Object)(object)((BraveBehaviour)actor).specRigidbody != (Object)null)
		{
			return ((BraveBehaviour)actor).specRigidbody.UnitCenter;
		}
		return Vector2.op_Implicit(((BraveBehaviour)actor).transform.position);
	}
}
