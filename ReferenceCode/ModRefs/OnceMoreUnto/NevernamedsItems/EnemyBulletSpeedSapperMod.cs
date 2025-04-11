using System;
using Alexandria.ItemAPI;
using Alexandria.Misc;
using UnityEngine;

namespace NevernamedsItems;

public class EnemyBulletSpeedSapperMod : MonoBehaviour
{
	private Projectile m_projectile;

	private Projectile lastCollidedProjectile;

	private void Start()
	{
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Expected O, but got Unknown
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Expected O, but got Unknown
		m_projectile = ((Component)this).GetComponent<Projectile>();
		m_projectile.collidesWithProjectiles = true;
		m_projectile.UpdateCollisionMask();
		SpeculativeRigidbody specRigidbody = ((BraveBehaviour)m_projectile).specRigidbody;
		specRigidbody.OnPreRigidbodyCollision = (OnPreRigidbodyCollisionDelegate)Delegate.Combine((Delegate)(object)specRigidbody.OnPreRigidbodyCollision, (Delegate)new OnPreRigidbodyCollisionDelegate(HandlePreCollision));
	}

	private void HandlePreCollision(SpeculativeRigidbody myRigidbody, PixelCollider myPixelCollider, SpeculativeRigidbody otherRigidbody, PixelCollider otherPixelCollider)
	{
		//IL_00f7: Unknown result type (might be due to invalid IL or missing references)
		if (!Object.op_Implicit((Object)(object)otherRigidbody) || !Object.op_Implicit((Object)(object)((BraveBehaviour)otherRigidbody).projectile))
		{
			return;
		}
		if (((BraveBehaviour)otherRigidbody).projectile.Owner is AIActor && (Object)(object)((BraveBehaviour)otherRigidbody).projectile != (Object)(object)lastCollidedProjectile)
		{
			((BraveBehaviour)otherRigidbody).projectile.RemoveBulletScriptControl();
			ProjectileData baseData = ((BraveBehaviour)otherRigidbody).projectile.baseData;
			baseData.speed *= 0.5f;
			((BraveBehaviour)otherRigidbody).projectile.UpdateSpeed();
			ProjectileData baseData2 = m_projectile.baseData;
			baseData2.speed *= 1.2f;
			m_projectile.UpdateSpeed();
			if (Object.op_Implicit((Object)(object)ProjectileUtility.ProjectilePlayerOwner(m_projectile)) && CustomSynergies.PlayerHasActiveSynergy(ProjectileUtility.ProjectilePlayerOwner(m_projectile), "Accelent"))
			{
				DeadlyDeadlyGoopManager goopManagerForGoopType = DeadlyDeadlyGoopManager.GetGoopManagerForGoopType(EasyGoopDefinitions.FireDef);
				goopManagerForGoopType.AddGoopCircle(((BraveBehaviour)m_projectile).sprite.WorldCenter, 0.5f, -1, false, -1);
			}
			lastCollidedProjectile = ((BraveBehaviour)otherRigidbody).projectile;
		}
		PhysicsEngine.SkipCollision = true;
	}
}
