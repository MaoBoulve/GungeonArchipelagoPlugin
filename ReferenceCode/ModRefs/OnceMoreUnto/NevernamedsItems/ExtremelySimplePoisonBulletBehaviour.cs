using System;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class ExtremelySimplePoisonBulletBehaviour : MonoBehaviour
{
	private Projectile m_projectile;

	public Color tintColour;

	public bool useSpecialTint;

	public int procChance;

	public int duration;

	public ExtremelySimplePoisonBulletBehaviour()
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		tintColour = Color.green;
		useSpecialTint = true;
		procChance = 1;
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
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Unknown result type (might be due to invalid IL or missing references)
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00df: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Expected O, but got Unknown
		if (Object.op_Implicit((Object)(object)enemy) && Object.op_Implicit((Object)(object)((BraveBehaviour)enemy).gameActor) && Object.op_Implicit((Object)(object)((BraveBehaviour)enemy).healthHaver))
		{
			if (Random.value <= (float)procChance)
			{
				GameActorHealthEffect healthModifierEffect = ((Component)Game.Items["irradiated_lead"]).GetComponent<BulletStatusEffectItem>().HealthModifierEffect;
				GameActorHealthEffect val = new GameActorHealthEffect
				{
					duration = ((GameActorEffect)healthModifierEffect).duration,
					DamagePerSecondToEnemies = healthModifierEffect.DamagePerSecondToEnemies,
					TintColor = tintColour,
					DeathTintColor = tintColour,
					effectIdentifier = ((GameActorEffect)healthModifierEffect).effectIdentifier,
					AppliesTint = true,
					AppliesDeathTint = true,
					resistanceType = (EffectResistanceType)2,
					OverheadVFX = ((GameActorEffect)healthModifierEffect).OverheadVFX,
					AffectsEnemies = true,
					AffectsPlayers = false,
					AppliesOutlineTint = false,
					ignitesGoops = false,
					OutlineTintColor = tintColour,
					PlaysVFXOnActor = false
				};
				if (duration > 0)
				{
					((GameActorEffect)val).duration = duration;
				}
				((BraveBehaviour)enemy).gameActor.ApplyEffect((GameActorEffect)(object)val, 1f, (Projectile)null);
			}
		}
		else
		{
			ETGModConsole.Log((object)"Target could not be poisoned", false);
		}
	}
}
