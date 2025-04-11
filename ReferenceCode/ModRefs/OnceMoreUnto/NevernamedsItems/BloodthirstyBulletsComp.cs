using System;
using Alexandria.Misc;
using UnityEngine;

namespace NevernamedsItems;

public class BloodthirstyBulletsComp : MonoBehaviour
{
	private Projectile m_projectile;

	public float jamChance;

	public float nonJamDamageMult;

	public BloodthirstyBulletsComp()
	{
		jamChance = 0.4f;
		nonJamDamageMult = 15f;
	}

	public void Start()
	{
		m_projectile = ((Component)this).GetComponent<Projectile>();
		Projectile projectile = m_projectile;
		projectile.OnHitEnemy = (Action<Projectile, SpeculativeRigidbody, bool>)Delegate.Combine(projectile.OnHitEnemy, new Action<Projectile, SpeculativeRigidbody, bool>(OnHitEnemy));
	}

	private void OnHitEnemy(Projectile arg1, SpeculativeRigidbody arg2, bool arg3)
	{
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0106: Unknown result type (might be due to invalid IL or missing references)
		if (!((Object)(object)arg2 != (Object)null) || !Object.op_Implicit((Object)(object)ProjectileUtility.ProjectilePlayerOwner(arg1)) || !((Object)(object)((BraveBehaviour)arg2).aiActor != (Object)null) || AllJammedState.AllJammedActive || ((BraveBehaviour)arg2).aiActor.IsBlackPhantom)
		{
			return;
		}
		if (((PickupObject)((GameActor)ProjectileUtility.ProjectilePlayerOwner(arg1)).CurrentGun).PickupObjectId == 17)
		{
			((BraveBehaviour)((BraveBehaviour)arg2).aiActor).healthHaver.ApplyDamage(2.2f, Vector2.zero, "BonusDamage", (CoreDamageTypes)0, (DamageCategory)0, true, (PixelCollider)null, false);
		}
		else if (!((BraveBehaviour)arg2).healthHaver.IsDead && !((BraveBehaviour)arg2).healthHaver.IsBoss)
		{
			float value = Random.value;
			if (Random.value <= jamChance)
			{
				((BraveBehaviour)arg2).aiActor.BecomeBlackPhantom();
			}
			else
			{
				((BraveBehaviour)((BraveBehaviour)arg2).aiActor).healthHaver.ApplyDamage(arg1.baseData.damage * nonJamDamageMult, Vector2.zero, "BonusDamage", (CoreDamageTypes)0, (DamageCategory)0, true, (PixelCollider)null, false);
			}
		}
	}
}
