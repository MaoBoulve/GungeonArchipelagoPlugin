using System;
using UnityEngine;

namespace NevernamedsItems;

internal class BarcodeScannerProjectile : MonoBehaviour
{
	private Projectile m_projectile;

	private void Start()
	{
		m_projectile = ((Component)this).GetComponent<Projectile>();
		if (Object.op_Implicit((Object)(object)m_projectile))
		{
			Projectile projectile = m_projectile;
			projectile.OnHitEnemy = (Action<Projectile, SpeculativeRigidbody, bool>)Delegate.Combine(projectile.OnHitEnemy, new Action<Projectile, SpeculativeRigidbody, bool>(OnHitEnemy));
		}
	}

	private void OnHitEnemy(Projectile proj, SpeculativeRigidbody enemy, bool fatal)
	{
		if (fatal && Object.op_Implicit((Object)(object)enemy) && Object.op_Implicit((Object)(object)((BraveBehaviour)enemy).aiActor))
		{
			AIActor aiActor = ((BraveBehaviour)enemy).aiActor;
			aiActor.AssignedCurrencyToDrop += Random.Range(1, 4);
		}
	}
}
