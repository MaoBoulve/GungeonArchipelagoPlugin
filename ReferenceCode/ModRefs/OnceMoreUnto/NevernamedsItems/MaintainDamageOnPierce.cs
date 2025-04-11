using System;
using System.Reflection;
using UnityEngine;

namespace NevernamedsItems;

public class MaintainDamageOnPierce : MonoBehaviour
{
	public float damageMultOnPierce;

	private Projectile m_projectile;

	public MaintainDamageOnPierce()
	{
		damageMultOnPierce = 1f;
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
		FieldInfo field = typeof(Projectile).GetField("m_hasPierced", BindingFlags.Instance | BindingFlags.NonPublic);
		field.SetValue(((BraveBehaviour)myRigidbody).projectile, false);
		ProjectileData baseData = m_projectile.baseData;
		baseData.damage *= damageMultOnPierce;
	}
}
