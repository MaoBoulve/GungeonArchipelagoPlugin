using System;
using UnityEngine;

namespace NevernamedsItems;

public class ExtremelySimpleStatusEffectBulletBehaviour : MonoBehaviour
{
	public GameActorFireEffect fireEffect;

	public bool usesFireEffect;

	public bool usesCharmEffect;

	public GameActorCharmEffect charmEffect;

	public GameActorHealthEffect poisonEffect;

	public bool usesPoisonEffect;

	public bool usesSpeedEffect;

	public GameActorSpeedEffect speedEffect;

	private Projectile m_projectile;

	public Color tintColour;

	public bool useSpecialTint;

	public float onFiredProcChance;

	public float onHitProcChance;

	public ExtremelySimpleStatusEffectBulletBehaviour()
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		tintColour = Color.red;
		useSpecialTint = false;
		onFiredProcChance = 1f;
		onHitProcChance = 1f;
		fireEffect = StaticStatusEffects.hotLeadEffect;
		usesFireEffect = false;
		usesCharmEffect = false;
		usesPoisonEffect = false;
		usesSpeedEffect = false;
		speedEffect = StaticStatusEffects.tripleCrossbowSlowEffect;
		poisonEffect = StaticStatusEffects.irradiatedLeadEffect;
		charmEffect = StaticStatusEffects.charmingRoundsEffect;
	}

	private void Start()
	{
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		m_projectile = ((Component)this).GetComponent<Projectile>();
		if (Random.value <= onFiredProcChance)
		{
			if (useSpecialTint)
			{
				m_projectile.AdjustPlayerProjectileTint(tintColour, 2, 0f);
			}
			Projectile projectile = m_projectile;
			projectile.OnHitEnemy = (Action<Projectile, SpeculativeRigidbody, bool>)Delegate.Combine(projectile.OnHitEnemy, new Action<Projectile, SpeculativeRigidbody, bool>(OnHitEnemy));
		}
	}

	private void OnHitEnemy(Projectile bullet, SpeculativeRigidbody enemy, bool fatal)
	{
		if ((Object)(object)enemy != (Object)null && (Object)(object)((BraveBehaviour)enemy).gameActor != (Object)null && (Object)(object)((BraveBehaviour)enemy).healthHaver != (Object)null && ((BraveBehaviour)enemy).healthHaver.IsAlive && Random.value <= onHitProcChance)
		{
			if (usesFireEffect)
			{
				((BraveBehaviour)enemy).gameActor.ApplyEffect((GameActorEffect)(object)fireEffect, 1f, (Projectile)null);
			}
			if (usesPoisonEffect)
			{
				((BraveBehaviour)enemy).gameActor.ApplyEffect((GameActorEffect)(object)poisonEffect, 1f, (Projectile)null);
			}
			if (usesCharmEffect)
			{
				((BraveBehaviour)enemy).gameActor.ApplyEffect((GameActorEffect)(object)charmEffect, 1f, (Projectile)null);
			}
			if (usesSpeedEffect)
			{
				((BraveBehaviour)enemy).gameActor.ApplyEffect((GameActorEffect)(object)speedEffect, 1f, (Projectile)null);
			}
		}
	}
}
