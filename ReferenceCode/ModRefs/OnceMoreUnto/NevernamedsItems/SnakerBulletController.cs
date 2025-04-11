using System;
using UnityEngine;

namespace NevernamedsItems;

public class SnakerBulletController : MonoBehaviour
{
	private bool hasEatenApple;

	public Snaker sourceGun;

	private Projectile m_projectile;

	public SnakerBulletController()
	{
		hasEatenApple = false;
	}

	private void Start()
	{
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Expected O, but got Unknown
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Expected O, but got Unknown
		m_projectile = ((Component)this).GetComponent<Projectile>();
		m_projectile.collidesWithProjectiles = true;
		m_projectile.collidesOnlyWithPlayerProjectiles = true;
		m_projectile.UpdateCollisionMask();
		SpeculativeRigidbody specRigidbody = ((BraveBehaviour)m_projectile).specRigidbody;
		specRigidbody.OnPreRigidbodyCollision = (OnPreRigidbodyCollisionDelegate)Delegate.Combine((Delegate)(object)specRigidbody.OnPreRigidbodyCollision, (Delegate)new OnPreRigidbodyCollisionDelegate(PreCollision));
	}

	private void PreCollision(SpeculativeRigidbody myRigidbody, PixelCollider myPixelCollider, SpeculativeRigidbody otherRigidbody, PixelCollider otherPixelCollider)
	{
		if (!((Object)(object)myRigidbody != (Object)null) || !((Object)(object)otherRigidbody != (Object)null) || !Object.op_Implicit((Object)(object)((BraveBehaviour)otherRigidbody).projectile) || !(((BraveBehaviour)otherRigidbody).projectile.Owner is PlayerController))
		{
			return;
		}
		if (Object.op_Implicit((Object)(object)((Component)otherRigidbody).gameObject.GetComponent<SnakerAppleController>()))
		{
			ProjectileData baseData = m_projectile.baseData;
			baseData.damage *= 3f;
			m_projectile.RuntimeUpdateScale(1.5f);
			GameObjectExtensions.GetOrAddComponent<HomingModifier>(((Component)m_projectile).gameObject);
			BounceProjModifier orAddComponent = GameObjectExtensions.GetOrAddComponent<BounceProjModifier>(((Component)m_projectile).gameObject);
			orAddComponent.numberOfBounces++;
			((BraveBehaviour)otherRigidbody).projectile.DieInAir(true, false, false, false);
			if ((Object)(object)sourceGun != (Object)null && !hasEatenApple)
			{
				sourceGun.ApplesEatenThisRoom++;
			}
			hasEatenApple = true;
		}
		PhysicsEngine.SkipCollision = true;
	}
}
