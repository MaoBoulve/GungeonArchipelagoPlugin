using System;
using UnityEngine;

namespace NevernamedsItems;

public class InherentExsanguinationEffect : MonoBehaviour
{
	private Projectile m_projectile;

	public float duration;

	private void Start()
	{
		m_projectile = ((Component)this).GetComponent<Projectile>();
		Projectile projectile = m_projectile;
		projectile.OnHitEnemy = (Action<Projectile, SpeculativeRigidbody, bool>)Delegate.Combine(projectile.OnHitEnemy, new Action<Projectile, SpeculativeRigidbody, bool>(HitEnemy));
	}

	private void HitEnemy(Projectile self, SpeculativeRigidbody enemy, bool fatal)
	{
		if (!fatal && Object.op_Implicit((Object)(object)enemy) && Object.op_Implicit((Object)(object)((BraveBehaviour)enemy).gameActor))
		{
			((BraveBehaviour)enemy).gameActor.ApplyEffect((GameActorEffect)(object)new GameActorExsanguinationEffect
			{
				duration = duration
			}, 1f, (Projectile)null);
		}
	}
}
