using System;
using UnityEngine;

namespace NevernamedsItems;

public class ExplodeOnBulletIntersection : MonoBehaviour
{
	public ExplosionData explosionData;

	private int timesExploded = 0;

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
		//IL_0073: Unknown result type (might be due to invalid IL or missing references)
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		if (!((Object)(object)otherRigidbody != (Object)null) || !((Object)(object)((BraveBehaviour)otherRigidbody).projectile != (Object)null) || timesExploded >= 3)
		{
			return;
		}
		if (((BraveBehaviour)otherRigidbody).projectile.Owner is AIActor && (Object)(object)((BraveBehaviour)otherRigidbody).projectile != (Object)(object)lastCollidedProjectile)
		{
			if (explosionData != null)
			{
				Exploder.Explode(Vector2.op_Implicit(((BraveBehaviour)m_projectile).specRigidbody.UnitCenter), explosionData, Vector2.zero, (Action)null, true, (CoreDamageTypes)0, false);
			}
			lastCollidedProjectile = ((BraveBehaviour)otherRigidbody).projectile;
			timesExploded++;
		}
		PhysicsEngine.SkipCollision = true;
	}
}
