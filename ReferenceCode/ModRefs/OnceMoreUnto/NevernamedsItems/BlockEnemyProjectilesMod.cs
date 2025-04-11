using System;
using UnityEngine;

namespace NevernamedsItems;

public class BlockEnemyProjectilesMod : MonoBehaviour
{
	public bool projectileSurvives;

	private Projectile m_projectile;

	public BlockEnemyProjectilesMod()
	{
		projectileSurvives = false;
	}

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
		if (Object.op_Implicit((Object)(object)otherRigidbody) && Object.op_Implicit((Object)(object)((BraveBehaviour)otherRigidbody).projectile))
		{
			if (((BraveBehaviour)otherRigidbody).projectile.Owner is AIActor)
			{
				((BraveBehaviour)otherRigidbody).projectile.DieInAir(false, true, true, false);
			}
			if (!projectileSurvives)
			{
				((BraveBehaviour)myRigidbody).projectile.DieInAir(false, true, true, false);
			}
			PhysicsEngine.SkipCollision = true;
		}
	}
}
