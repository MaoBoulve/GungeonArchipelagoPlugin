using System;
using UnityEngine;

namespace NevernamedsItems;

public class CollideWithPlayerBehaviour : MonoBehaviour
{
	private Projectile m_projectile;

	public void Start()
	{
		try
		{
			m_projectile = ((Component)this).GetComponent<Projectile>();
			m_projectile.allowSelfShooting = true;
			m_projectile.collidesWithEnemies = true;
			m_projectile.collidesWithPlayer = true;
			m_projectile.SetNewShooter(m_projectile.Shooter);
			m_projectile.UpdateCollisionMask();
		}
		catch (Exception ex)
		{
			ETGModConsole.Log((object)ex.Message, false);
			ETGModConsole.Log((object)ex.StackTrace, false);
		}
	}
}
