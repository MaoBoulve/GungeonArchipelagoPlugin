using System;
using UnityEngine;

namespace NevernamedsItems;

public class PermaCharmBulletBehaviour : MonoBehaviour
{
	private Projectile m_projectile;

	public Color tintColour;

	public bool useSpecialTint;

	public float procChance;

	public PermaCharmBulletBehaviour()
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		tintColour = ExtendedColours.pink;
		useSpecialTint = true;
		procChance = 1f;
	}

	private void Start()
	{
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		m_projectile = ((Component)this).GetComponent<Projectile>();
		if (useSpecialTint)
		{
			m_projectile.AdjustPlayerProjectileTint(tintColour, 2, 0f);
		}
		Projectile projectile = m_projectile;
		projectile.OnHitEnemy = (Action<Projectile, SpeculativeRigidbody, bool>)Delegate.Combine(projectile.OnHitEnemy, new Action<Projectile, SpeculativeRigidbody, bool>(OnHitEnemy));
	}

	private void OnHitEnemy(Projectile bullet, SpeculativeRigidbody enemy, bool fatal)
	{
		if (Random.value <= procChance && Object.op_Implicit((Object)(object)enemy) && Object.op_Implicit((Object)(object)((BraveBehaviour)enemy).aiActor))
		{
			((GameActor)((BraveBehaviour)enemy).aiActor).ApplyEffect((GameActorEffect)(object)GameManager.Instance.Dungeon.sharedSettingsPrefab.DefaultPermanentCharmEffect, 1f, (Projectile)null);
		}
	}
}
