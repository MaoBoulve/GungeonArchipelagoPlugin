using System;
using UnityEngine;

namespace NevernamedsItems;

public class ProjWeaknessModifier : MonoBehaviour
{
	public float chanceToApply;

	public float EnemyHealthModifier;

	public float EnemyCooldownModifier;

	public float EnemySpeedMultiplier;

	public bool EnemyKeepHealthPercentage;

	public float EnemyDuration;

	public bool UsesSeparateStatsForBosses;

	public float BossHealthModifier;

	public float BossCooldownModifier;

	public float BossSpeedMultiplier;

	public bool BossKeepHealthPercentage;

	public float BossDuration;

	public bool isDarkPrince;

	public static AIActorDebuffEffect WeakenedDebuff;

	public static AIActorDebuffEffect BossWeakenedDebuff;

	public ProjWeaknessModifier()
	{
		chanceToApply = 1f;
		EnemyHealthModifier = 0.65f;
		EnemyCooldownModifier = 1.2f;
		EnemySpeedMultiplier = 0.8f;
		EnemyKeepHealthPercentage = true;
		EnemyDuration = 100000f;
		BossHealthModifier = 0.75f;
		BossCooldownModifier = 1.2f;
		BossSpeedMultiplier = 0.8f;
		BossKeepHealthPercentage = true;
		BossDuration = 100000f;
		UsesSeparateStatsForBosses = true;
		isDarkPrince = false;
	}

	private void Start()
	{
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Expected O, but got Unknown
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0087: Unknown result type (might be due to invalid IL or missing references)
		//IL_0093: Unknown result type (might be due to invalid IL or missing references)
		//IL_009f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bb: Expected O, but got Unknown
		if (chanceToApply >= Random.value)
		{
			WeakenedDebuff = new AIActorDebuffEffect
			{
				HealthMultiplier = EnemyHealthModifier,
				CooldownMultiplier = EnemyCooldownModifier,
				SpeedMultiplier = EnemySpeedMultiplier,
				KeepHealthPercentage = EnemyKeepHealthPercentage,
				OverheadVFX = MagickeCauldron.overheadder,
				duration = EnemyDuration
			};
			BossWeakenedDebuff = new AIActorDebuffEffect
			{
				HealthMultiplier = BossHealthModifier,
				CooldownMultiplier = BossCooldownModifier,
				SpeedMultiplier = BossSpeedMultiplier,
				KeepHealthPercentage = BossKeepHealthPercentage,
				OverheadVFX = MagickeCauldron.overheadder,
				duration = BossDuration
			};
			Projectile component = ((Component)this).GetComponent<Projectile>();
			component.OnHitEnemy = (Action<Projectile, SpeculativeRigidbody, bool>)Delegate.Combine(component.OnHitEnemy, new Action<Projectile, SpeculativeRigidbody, bool>(OnHitenemy));
		}
	}

	private void OnHitenemy(Projectile self, SpeculativeRigidbody enemy, bool fatal)
	{
		if (Object.op_Implicit((Object)(object)enemy) && Object.op_Implicit((Object)(object)((BraveBehaviour)enemy).aiActor) && !fatal)
		{
			if (Object.op_Implicit((Object)(object)((BraveBehaviour)enemy).healthHaver) && ((BraveBehaviour)enemy).healthHaver.IsBoss && UsesSeparateStatsForBosses)
			{
				((GameActor)((BraveBehaviour)enemy).aiActor).ApplyEffect((GameActorEffect)(object)BossWeakenedDebuff, 1f, (Projectile)null);
			}
			else
			{
				((GameActor)((BraveBehaviour)enemy).aiActor).ApplyEffect((GameActorEffect)(object)WeakenedDebuff, 1f, (Projectile)null);
			}
			if (isDarkPrince)
			{
				((Component)enemy).gameObject.AddComponent<DarkPrince.DebuffedByDarkPrince>();
			}
		}
	}
}
