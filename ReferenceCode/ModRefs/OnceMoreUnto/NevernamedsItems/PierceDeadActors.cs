using System;
using UnityEngine;

namespace NevernamedsItems;

public class PierceDeadActors : MonoBehaviour
{
	private Projectile m_projectile;

	private void Start()
	{
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Expected O, but got Unknown
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Expected O, but got Unknown
		m_projectile = ((Component)this).GetComponent<Projectile>();
		SpeculativeRigidbody specRigidbody = ((BraveBehaviour)m_projectile).specRigidbody;
		specRigidbody.OnPreRigidbodyCollision = (OnPreRigidbodyCollisionDelegate)Delegate.Combine((Delegate)(object)specRigidbody.OnPreRigidbodyCollision, (Delegate)new OnPreRigidbodyCollisionDelegate(PreCollision));
	}

	private void PreCollision(SpeculativeRigidbody myRigidbody, PixelCollider myPixelCollider, SpeculativeRigidbody otherRigidbody, PixelCollider otherPixelCollider)
	{
		if ((Object)(object)myRigidbody != (Object)null && (Object)(object)otherRigidbody != (Object)null && (Object)(object)((BraveBehaviour)otherRigidbody).healthHaver != (Object)null && ((BraveBehaviour)otherRigidbody).healthHaver.IsDead)
		{
			PhysicsEngine.SkipCollision = true;
		}
	}
}
