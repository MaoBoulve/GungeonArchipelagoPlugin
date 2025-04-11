using System;
using UnityEngine;

namespace NevernamedsItems;

internal class ThousandSinsProjectileModifier : MonoBehaviour
{
	private Projectile self;

	public void Start()
	{
		self = ((Component)this).GetComponent<Projectile>();
		if (Object.op_Implicit((Object)(object)self))
		{
			Projectile obj = self;
			obj.OnHitEnemy = (Action<Projectile, SpeculativeRigidbody, bool>)Delegate.Combine(obj.OnHitEnemy, new Action<Projectile, SpeculativeRigidbody, bool>(OnHitEnemy));
		}
	}

	private void OnHitEnemy(Projectile me, SpeculativeRigidbody enemy, bool fatal)
	{
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		if (Object.op_Implicit((Object)(object)enemy) && fatal && Object.op_Implicit((Object)(object)((BraveBehaviour)enemy).healthHaver))
		{
			float maxHealth = ((BraveBehaviour)enemy).healthHaver.GetMaxHealth();
			maxHealth *= 0.5f;
			GoopDefinition val = EasyGoopDefinitions.GenerateBloodGoop(maxHealth, Color.red, 10f);
			DeadlyDeadlyGoopManager goopManagerForGoopType = DeadlyDeadlyGoopManager.GetGoopManagerForGoopType(val);
			goopManagerForGoopType.TimedAddGoopCircle(enemy.UnitCenter, 3f, 0.5f, false);
		}
	}
}
