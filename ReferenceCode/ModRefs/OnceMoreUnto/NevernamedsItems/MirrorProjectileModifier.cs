using System;
using UnityEngine;

namespace NevernamedsItems;

public class MirrorProjectileModifier : MonoBehaviour
{
	public float MirrorRadius;

	private Projectile m_projectile;

	public MirrorProjectileModifier()
	{
		MirrorRadius = 3f;
	}

	private void Awake()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Expected O, but got Unknown
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Expected O, but got Unknown
		m_projectile = ((Component)this).GetComponent<Projectile>();
		m_projectile.AdjustPlayerProjectileTint(Color.white, 2, 0f);
		m_projectile.collidesWithProjectiles = true;
		SpeculativeRigidbody specRigidbody = ((BraveBehaviour)m_projectile).specRigidbody;
		specRigidbody.OnPreRigidbodyCollision = (OnPreRigidbodyCollisionDelegate)Delegate.Combine((Delegate)(object)specRigidbody.OnPreRigidbodyCollision, (Delegate)new OnPreRigidbodyCollisionDelegate(HandlePreCollision));
	}

	private void Update()
	{
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		Vector2 val = Vector3Extensions.XY(((BraveBehaviour)m_projectile).transform.position);
		for (int i = 0; i < StaticReferenceManager.AllProjectiles.Count; i++)
		{
			Projectile val2 = StaticReferenceManager.AllProjectiles[i];
			if (Object.op_Implicit((Object)(object)val2) && val2.Owner is AIActor)
			{
				Vector2 val3 = Vector3Extensions.XY(((BraveBehaviour)val2).transform.position) - val;
				float sqrMagnitude = ((Vector2)(ref val3)).sqrMagnitude;
				if (!(sqrMagnitude < MirrorRadius))
				{
				}
			}
		}
	}

	private void HandlePreCollision(SpeculativeRigidbody myRigidbody, PixelCollider myPixelCollider, SpeculativeRigidbody otherRigidbody, PixelCollider otherPixelCollider)
	{
		if (Object.op_Implicit((Object)(object)otherRigidbody) && Object.op_Implicit((Object)(object)((BraveBehaviour)otherRigidbody).projectile))
		{
			if (((BraveBehaviour)otherRigidbody).projectile.Owner is AIActor)
			{
				((BraveBehaviour)myRigidbody).projectile.DieInAir(false, true, true, false);
				ReflectBullet(((BraveBehaviour)otherRigidbody).projectile, retargetReflectedBullet: true, ((BraveBehaviour)myRigidbody).projectile.Owner, 10f);
			}
			PhysicsEngine.SkipCollision = true;
		}
	}

	public void ReflectBullet(Projectile p, bool retargetReflectedBullet, GameActor newOwner, float minReflectedBulletSpeed, float scaleModifier = 1f, float damageModifier = 1f, float spread = 0f)
	{
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0092: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e7: Unknown result type (might be due to invalid IL or missing references)
		p.RemoveBulletScriptControl();
		AkSoundEngine.PostEvent("Play_OBJ_metalskin_deflect_01", ((Component)GameManager.Instance).gameObject);
		if (retargetReflectedBullet && Object.op_Implicit((Object)(object)p.Owner) && Object.op_Implicit((Object)(object)((BraveBehaviour)p.Owner).specRigidbody))
		{
			Vector2 val = ((BraveBehaviour)p.Owner).specRigidbody.GetUnitCenter((ColliderType)2) - ((BraveBehaviour)p).specRigidbody.UnitCenter;
			p.Direction = ((Vector2)(ref val)).normalized;
		}
		if (spread != 0f)
		{
			p.Direction = Vector2Extensions.Rotate(p.Direction, Random.Range(0f - spread, spread));
		}
		if (Object.op_Implicit((Object)(object)p.Owner) && Object.op_Implicit((Object)(object)((BraveBehaviour)p.Owner).specRigidbody))
		{
			((BraveBehaviour)p).specRigidbody.DeregisterSpecificCollisionException(((BraveBehaviour)p.Owner).specRigidbody);
		}
		p.Owner = newOwner;
		p.SetNewShooter(((BraveBehaviour)newOwner).specRigidbody);
		p.allowSelfShooting = false;
		p.collidesWithPlayer = false;
		p.collidesWithEnemies = true;
		if (scaleModifier != 1f)
		{
			SpawnManager.PoolManager.Remove(((BraveBehaviour)p).transform);
			p.RuntimeUpdateScale(scaleModifier);
		}
		if (p.Speed < minReflectedBulletSpeed)
		{
			p.Speed = minReflectedBulletSpeed;
		}
		if (p.baseData.damage < ProjectileData.FixedFallbackDamageToEnemies)
		{
			p.baseData.damage = ProjectileData.FixedFallbackDamageToEnemies;
		}
		ProjectileData baseData = p.baseData;
		baseData.damage *= damageModifier;
		if (p.baseData.damage < 10f)
		{
			p.baseData.damage = 15f;
		}
		p.UpdateCollisionMask();
		p.Reflected();
		p.SendInDirection(p.Direction, true, true);
	}
}
