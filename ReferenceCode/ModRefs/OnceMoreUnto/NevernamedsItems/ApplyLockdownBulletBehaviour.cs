using System;
using UnityEngine;

namespace NevernamedsItems;

public class ApplyLockdownBulletBehaviour : MonoBehaviour
{
	private Projectile m_projectile;

	public Color bulletTintColour;

	public Color enemyTintColour;

	public Color corpseTintColour;

	public float duration;

	public bool useSpecialBulletTint;

	public bool TintEnemy;

	public bool TintCorpse;

	public int procChance;

	public ApplyLockdownBulletBehaviour()
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		bulletTintColour = Color.grey;
		useSpecialBulletTint = false;
		TintEnemy = true;
		TintCorpse = false;
		enemyTintColour = Color.grey;
		duration = 1f;
		procChance = 1;
	}

	private void Start()
	{
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		m_projectile = ((Component)this).GetComponent<Projectile>();
		if (useSpecialBulletTint)
		{
			m_projectile.AdjustPlayerProjectileTint(bulletTintColour, 2, 0f);
		}
		Projectile projectile = m_projectile;
		projectile.OnHitEnemy = (Action<Projectile, SpeculativeRigidbody, bool>)Delegate.Combine(projectile.OnHitEnemy, new Action<Projectile, SpeculativeRigidbody, bool>(OnHitEnemy));
	}

	private void OnHitEnemy(Projectile bullet, SpeculativeRigidbody enemy, bool fatal)
	{
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		if (Random.value <= (float)procChance)
		{
			ApplyLockdown.ApplyDirectLockdown(((BraveBehaviour)enemy).gameActor, duration, enemyTintColour, corpseTintColour, (EffectResistanceType)0, "Lockdown", TintEnemy, TintCorpse);
		}
	}
}
