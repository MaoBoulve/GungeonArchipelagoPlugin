using System.Collections.Generic;
using Alexandria.Misc;
using Dungeonator;
using UnityEngine;

namespace NevernamedsItems;

public class TryKillAllProjectile : Projectile
{
	public override void Move()
	{
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0181: Unknown result type (might be due to invalid IL or missing references)
		//IL_0186: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0118: Unknown result type (might be due to invalid IL or missing references)
		//IL_011f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0124: Unknown result type (might be due to invalid IL or missing references)
		//IL_0129: Unknown result type (might be due to invalid IL or missing references)
		//IL_0132: Unknown result type (might be due to invalid IL or missing references)
		//IL_0139: Unknown result type (might be due to invalid IL or missing references)
		//IL_014a: Unknown result type (might be due to invalid IL or missing references)
		//IL_014f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0154: Unknown result type (might be due to invalid IL or missing references)
		base.m_timeElapsed += ((Projectile)this).LocalDeltaTime;
		if (base.angularVelocity != 0f)
		{
			base.m_transform.RotateAround(Vector2.op_Implicit(Vector3Extensions.XY(base.m_transform.position)), Vector3.forward, base.angularVelocity * ((Projectile)this).LocalDeltaTime);
		}
		if (base.baseData.UsesCustomAccelerationCurve)
		{
			float num = Mathf.Clamp01((base.m_timeElapsed - base.baseData.IgnoreAccelCurveTime) / base.baseData.CustomAccelerationCurveDuration);
			base.m_currentSpeed = base.baseData.AccelerationCurve.Evaluate(num) * base.baseData.speed;
		}
		((BraveBehaviour)this).specRigidbody.Velocity = base.m_currentDirection * base.m_currentSpeed;
		if (ProjectileUtility.GetAbsoluteRoom((Projectile)(object)this) != null && ProjectileUtility.GetAbsoluteRoom((Projectile)(object)this).GetActiveEnemiesCount((ActiveEnemyType)0) > 0)
		{
			List<AIActor> activeEnemies = ProjectileUtility.GetAbsoluteRoom((Projectile)(object)this).GetActiveEnemies((ActiveEnemyType)0);
			foreach (AIActor item in activeEnemies)
			{
				Vector2 val = MathsAndLogicHelper.CalculateVectorBetween(((Projectile)this).SafeCenter, ((GameActor)item).CenterPosition);
				SpeculativeRigidbody specRigidbody = ((BraveBehaviour)this).specRigidbody;
				specRigidbody.Velocity += ((Vector2)(ref val)).normalized * (base.m_currentSpeed * 0.25f);
			}
		}
		base.m_currentDirection = ((Vector2)(ref ((BraveBehaviour)this).specRigidbody.Velocity)).normalized;
		base.m_currentSpeed *= 1f - base.baseData.damping * ((Projectile)this).LocalDeltaTime;
		((Projectile)this).LastVelocity = ((BraveBehaviour)this).specRigidbody.Velocity;
	}
}
