using System;
using UnityEngine;

namespace NevernamedsItems;

public class OMITBPortalController : MonoBehaviour
{
	private bool isOrangePortal;

	private bool isActive;

	private Projectile m_projectile;

	public OMITBPortalController linkedOther;

	private SpeculativeRigidbody m_rigidBoy;

	private void Start()
	{
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Expected O, but got Unknown
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Expected O, but got Unknown
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		//IL_0087: Unknown result type (might be due to invalid IL or missing references)
		m_projectile = ((Component)this).GetComponent<Projectile>();
		m_rigidBoy = ((Component)this).GetComponent<SpeculativeRigidbody>();
		SpeculativeRigidbody specRigidbody = ((BraveBehaviour)m_rigidBoy).specRigidbody;
		specRigidbody.OnPreRigidbodyCollision = (OnPreRigidbodyCollisionDelegate)Delegate.Combine((Delegate)(object)specRigidbody.OnPreRigidbodyCollision, (Delegate)new OnPreRigidbodyCollisionDelegate(Collision));
		foreach (OMITBPortalController allPortal in PortalGun.allPortals)
		{
			if (Object.op_Implicit((Object)(object)allPortal) && Vector3Extensions.GetAbsoluteRoom(((BraveBehaviour)allPortal.m_projectile).transform.position) == Vector3Extensions.GetAbsoluteRoom(((BraveBehaviour)m_projectile).transform.position) && (Object)(object)allPortal.linkedOther == (Object)null)
			{
				if (allPortal.isOrangePortal && !isOrangePortal)
				{
					linkedOther = allPortal;
					allPortal.linkedOther = this;
					allPortal.ActivatePortal();
					ActivatePortal();
				}
				else if (!allPortal.isOrangePortal && isOrangePortal)
				{
					linkedOther = allPortal;
					allPortal.linkedOther = this;
					allPortal.ActivatePortal();
					ActivatePortal();
				}
			}
		}
	}

	public void ActivatePortal()
	{
		isActive = true;
	}

	private void Collision(SpeculativeRigidbody myRigidbody, PixelCollider myPixelCollider, SpeculativeRigidbody otherRigidbody, PixelCollider otherPixelCollider)
	{
	}
}
