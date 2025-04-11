using System;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class ApplyDirectStatusEffects
{
	public static void ApplyDirectFreeze(GameActor target, float duration, float freezeAmount, float damageToDealOnUnfreeze, Color tintColour, Color deathTintColour, EffectResistanceType resistanceType, string identifier, bool tintsEnemy, bool tintsCorpse)
	{
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		//IL_0091: Unknown result type (might be due to invalid IL or missing references)
		//IL_009d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0102: Unknown result type (might be due to invalid IL or missing references)
		//IL_010a: Expected O, but got Unknown
		try
		{
			GameActorFreezeEffect freezeModifierEffect = ((Component)PickupObjectDatabase.GetById(278)).GetComponent<BulletStatusEffectItem>().FreezeModifierEffect;
			GameActorFreezeEffect val = new GameActorFreezeEffect
			{
				duration = duration,
				TintColor = tintColour,
				DeathTintColor = deathTintColour,
				effectIdentifier = identifier,
				AppliesTint = tintsEnemy,
				AppliesDeathTint = tintsCorpse,
				resistanceType = resistanceType,
				FreezeAmount = freezeAmount,
				UnfreezeDamagePercent = damageToDealOnUnfreeze,
				crystalNum = freezeModifierEffect.crystalNum,
				crystalRot = freezeModifierEffect.crystalRot,
				crystalVariation = freezeModifierEffect.crystalVariation,
				FreezeCrystals = freezeModifierEffect.FreezeCrystals,
				debrisAngleVariance = freezeModifierEffect.debrisAngleVariance,
				debrisMaxForce = freezeModifierEffect.debrisMaxForce,
				debrisMinForce = freezeModifierEffect.debrisMinForce,
				OverheadVFX = ((GameActorEffect)freezeModifierEffect).OverheadVFX,
				vfxExplosion = freezeModifierEffect.vfxExplosion,
				stackMode = ((GameActorEffect)freezeModifierEffect).stackMode,
				maxStackedDuration = ((GameActorEffect)freezeModifierEffect).maxStackedDuration,
				AffectsEnemies = true,
				AffectsPlayers = false,
				AppliesOutlineTint = false,
				OutlineTintColor = tintColour,
				PlaysVFXOnActor = true
			};
			target.ApplyEffect((GameActorEffect)(object)val, 1f, (Projectile)null);
		}
		catch (Exception ex)
		{
			ETGModConsole.Log((object)ex.Message, false);
			ETGModConsole.Log((object)ex.StackTrace, false);
		}
	}

	public static void ApplyDirectPoison(GameActor target, float duration, float dps, Color tintColour, Color deathTintColour, EffectResistanceType resistanceType, string identifier, bool tintsEnemy, bool tintsCorpse)
	{
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		//IL_0086: Unknown result type (might be due to invalid IL or missing references)
		//IL_0087: Unknown result type (might be due to invalid IL or missing references)
		//IL_008c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Expected O, but got Unknown
		GameActorHealthEffect healthModifierEffect = ((Component)Game.Items["irradiated_lead"]).GetComponent<BulletStatusEffectItem>().HealthModifierEffect;
		GameActorHealthEffect val = new GameActorHealthEffect
		{
			duration = duration,
			DamagePerSecondToEnemies = dps,
			TintColor = tintColour,
			DeathTintColor = deathTintColour,
			effectIdentifier = identifier,
			AppliesTint = tintsEnemy,
			AppliesDeathTint = tintsCorpse,
			resistanceType = resistanceType,
			OverheadVFX = ((GameActorEffect)healthModifierEffect).OverheadVFX,
			AffectsEnemies = true,
			AffectsPlayers = false,
			AppliesOutlineTint = false,
			ignitesGoops = false,
			OutlineTintColor = tintColour,
			PlaysVFXOnActor = false
		};
		if (Object.op_Implicit((Object)(object)target) && Object.op_Implicit((Object)(object)((BraveBehaviour)target).aiActor) && Object.op_Implicit((Object)(object)((BraveBehaviour)target).healthHaver) && ((BraveBehaviour)target).healthHaver.IsAlive)
		{
			target.ApplyEffect((GameActorEffect)(object)val, 1f, (Projectile)null);
		}
	}

	public static void ApplyDirectSlow(GameActor target, float duration, float speedMultiplier, Color tintColour, Color deathTintColour, EffectResistanceType resistanceType, string identifier, bool tintsEnemy, bool tintsCorpse)
	{
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0082: Unknown result type (might be due to invalid IL or missing references)
		//IL_0089: Unknown result type (might be due to invalid IL or missing references)
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		//IL_0091: Unknown result type (might be due to invalid IL or missing references)
		//IL_0092: Unknown result type (might be due to invalid IL or missing references)
		//IL_0097: Unknown result type (might be due to invalid IL or missing references)
		//IL_009f: Expected O, but got Unknown
		PickupObject obj = Databases.Items["triple_crossbow"];
		Gun val = (Gun)(object)((obj is Gun) ? obj : null);
		GameActorSpeedEffect speedEffect = val.DefaultModule.projectiles[0].speedEffect;
		GameActorSpeedEffect val2 = new GameActorSpeedEffect
		{
			duration = duration,
			TintColor = tintColour,
			DeathTintColor = deathTintColour,
			effectIdentifier = identifier,
			AppliesTint = tintsEnemy,
			AppliesDeathTint = tintsCorpse,
			resistanceType = resistanceType,
			SpeedMultiplier = speedMultiplier,
			OverheadVFX = ((GameActorEffect)speedEffect).OverheadVFX,
			AffectsEnemies = true,
			AffectsPlayers = false,
			AppliesOutlineTint = false,
			OutlineTintColor = tintColour,
			PlaysVFXOnActor = false
		};
		if (Object.op_Implicit((Object)(object)target) && Object.op_Implicit((Object)(object)((BraveBehaviour)target).aiActor) && Object.op_Implicit((Object)(object)((BraveBehaviour)target).healthHaver) && ((BraveBehaviour)target).healthHaver.IsAlive)
		{
			target.ApplyEffect((GameActorEffect)(object)val2, 1f, (Projectile)null);
		}
	}

	public static void ApplyDirectFire(GameActor target, float duration, float dps, Color tintColour, Color deathTintColour, EffectResistanceType resistanceType, string identifier, bool tintsEnemy, bool tintsCorpse)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_007f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0090: Expected O, but got Unknown
		GameActorFireEffect val = new GameActorFireEffect
		{
			duration = duration,
			DamagePerSecondToEnemies = dps,
			TintColor = tintColour,
			DeathTintColor = deathTintColour,
			effectIdentifier = identifier,
			AppliesTint = tintsEnemy,
			AppliesDeathTint = tintsCorpse,
			resistanceType = resistanceType,
			OverheadVFX = ((GameActorEffect)StaticStatusEffects.hotLeadEffect).OverheadVFX,
			AffectsEnemies = true,
			AffectsPlayers = false,
			AppliesOutlineTint = false,
			ignitesGoops = ((GameActorHealthEffect)StaticStatusEffects.hotLeadEffect).ignitesGoops,
			OutlineTintColor = tintColour,
			PlaysVFXOnActor = ((GameActorEffect)StaticStatusEffects.hotLeadEffect).PlaysVFXOnActor
		};
		if (Object.op_Implicit((Object)(object)target) && Object.op_Implicit((Object)(object)((BraveBehaviour)target).aiActor) && Object.op_Implicit((Object)(object)((BraveBehaviour)target).healthHaver) && ((BraveBehaviour)target).healthHaver.IsAlive)
		{
			target.ApplyEffect((GameActorEffect)(object)val, 1f, (Projectile)null);
		}
	}
}
