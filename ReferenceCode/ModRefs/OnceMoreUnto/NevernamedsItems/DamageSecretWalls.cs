using System;
using UnityEngine;

namespace NevernamedsItems;

public class DamageSecretWalls : MonoBehaviour
{
	public float damageToDeal;

	private Projectile m_projectile;

	public DamageSecretWalls()
	{
		damageToDeal = 1E+10f;
	}

	public void Start()
	{
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected O, but got Unknown
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Expected O, but got Unknown
		m_projectile = ((Component)this).GetComponent<Projectile>();
		if (Object.op_Implicit((Object)(object)m_projectile))
		{
			SpeculativeRigidbody specRigidbody = ((BraveBehaviour)m_projectile).specRigidbody;
			specRigidbody.OnPreRigidbodyCollision = (OnPreRigidbodyCollisionDelegate)Delegate.Combine((Delegate)(object)specRigidbody.OnPreRigidbodyCollision, (Delegate)new OnPreRigidbodyCollisionDelegate(HandlePierce));
		}
	}

	private void HandlePierce(SpeculativeRigidbody myRigidbody, PixelCollider myPixelCollider, SpeculativeRigidbody otherRigidbody, PixelCollider otherPixelCollider)
	{
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		if ((Object)(object)((Component)otherRigidbody).GetComponent<MajorBreakable>() != (Object)null && ((Component)otherRigidbody).GetComponent<MajorBreakable>().IsSecretDoor)
		{
			((Component)otherRigidbody).GetComponent<MajorBreakable>().ApplyDamage(damageToDeal, Vector2.zero, false, false, true);
		}
	}
}
