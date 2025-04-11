using System;
using UnityEngine;

namespace NevernamedsItems;

public class GainAmmoOnHitEnemyModifier : MonoBehaviour
{
	public bool requireKill = false;

	public int ammoToGain = 1;

	private Projectile m_projectile;

	private void Awake()
	{
		m_projectile = ((Component)this).GetComponent<Projectile>();
		Projectile projectile = m_projectile;
		projectile.OnHitEnemy = (Action<Projectile, SpeculativeRigidbody, bool>)Delegate.Combine(projectile.OnHitEnemy, new Action<Projectile, SpeculativeRigidbody, bool>(OnHit));
	}

	private void OnHit(Projectile obj, SpeculativeRigidbody enemy, bool fatal)
	{
		if ((fatal || !requireKill) && (Object)(object)obj.PossibleSourceGun != (Object)null && obj.PossibleSourceGun.CanGainAmmo)
		{
			obj.PossibleSourceGun.GainAmmo(ammoToGain);
		}
	}
}
