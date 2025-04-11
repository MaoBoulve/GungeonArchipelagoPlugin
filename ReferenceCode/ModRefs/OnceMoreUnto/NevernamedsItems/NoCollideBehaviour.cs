using System;
using UnityEngine;

namespace NevernamedsItems;

public class NoCollideBehaviour : MonoBehaviour
{
	private Projectile m_projectile;

	public bool worksOnEnemies = false;

	public bool worksOnProjectiles = false;

	public bool minorBreakablesOnly = false;

	public NoCollideBehaviour()
	{
		worksOnProjectiles = false;
		worksOnEnemies = true;
	}

	public void Start()
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Expected O, but got Unknown
		try
		{
			m_projectile = ((Component)this).GetComponent<Projectile>();
			SpeculativeRigidbody specRigidbody = ((BraveBehaviour)m_projectile).specRigidbody;
			specRigidbody.OnPreRigidbodyCollision = (OnPreRigidbodyCollisionDelegate)Delegate.Combine((Delegate)(object)specRigidbody.OnPreRigidbodyCollision, (Delegate)new OnPreRigidbodyCollisionDelegate(HandlePreCollision));
		}
		catch (Exception ex)
		{
			ETGModConsole.Log((object)ex.Message, false);
			ETGModConsole.Log((object)ex.StackTrace, false);
		}
	}

	private void HandlePreCollision(SpeculativeRigidbody myRigidbody, PixelCollider myPixelCollider, SpeculativeRigidbody otherRigidbody, PixelCollider otherPixelCollider)
	{
		try
		{
			if (!Object.op_Implicit((Object)(object)otherRigidbody))
			{
				return;
			}
			if (minorBreakablesOnly)
			{
				if (Object.op_Implicit((Object)(object)((BraveBehaviour)otherRigidbody).minorBreakable))
				{
					PhysicsEngine.SkipCollision = true;
				}
			}
			else if ((Object)(object)((BraveBehaviour)otherRigidbody).aiActor != (Object)null && (Object)(object)((BraveBehaviour)otherRigidbody).healthHaver != (Object)null)
			{
				if (worksOnEnemies)
				{
					PhysicsEngine.SkipCollision = true;
				}
			}
			else if ((Object)(object)((BraveBehaviour)otherRigidbody).projectile != (Object)null && ((BraveBehaviour)otherRigidbody).projectile.collidesWithProjectiles)
			{
				if (worksOnProjectiles)
				{
					PhysicsEngine.SkipCollision = true;
				}
			}
			else
			{
				PhysicsEngine.SkipCollision = true;
			}
		}
		catch (Exception ex)
		{
			ETGModConsole.Log((object)ex.Message, false);
			ETGModConsole.Log((object)ex.StackTrace, false);
		}
	}
}
