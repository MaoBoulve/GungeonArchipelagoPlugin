using UnityEngine;

namespace NevernamedsItems;

internal class StatusEffectHelper
{
	public static GameActorCheeseEffect GenerateCheese(float length = 10f, float intensity = 50f)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Unknown result type (might be due to invalid IL or missing references)
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0104: Unknown result type (might be due to invalid IL or missing references)
		//IL_0114: Unknown result type (might be due to invalid IL or missing references)
		//IL_0124: Unknown result type (might be due to invalid IL or missing references)
		//IL_0134: Unknown result type (might be due to invalid IL or missing references)
		//IL_013a: Unknown result type (might be due to invalid IL or missing references)
		//IL_013f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0144: Unknown result type (might be due to invalid IL or missing references)
		//IL_0154: Unknown result type (might be due to invalid IL or missing references)
		//IL_015a: Unknown result type (might be due to invalid IL or missing references)
		//IL_015f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0164: Unknown result type (might be due to invalid IL or missing references)
		//IL_0175: Expected O, but got Unknown
		return new GameActorCheeseEffect
		{
			duration = length,
			TintColor = ((GameActorEffect)StaticStatusEffects.elimentalerCheeseEffect).TintColor,
			DeathTintColor = ((GameActorEffect)StaticStatusEffects.elimentalerCheeseEffect).DeathTintColor,
			effectIdentifier = "Cheese",
			AppliesTint = true,
			AppliesDeathTint = true,
			resistanceType = (EffectResistanceType)0,
			CheeseAmount = intensity,
			OverheadVFX = ((GameActorEffect)StaticStatusEffects.elimentalerCheeseEffect).OverheadVFX,
			AffectsPlayers = ((GameActorEffect)StaticStatusEffects.elimentalerCheeseEffect).AffectsPlayers,
			AppliesOutlineTint = ((GameActorEffect)StaticStatusEffects.elimentalerCheeseEffect).AppliesOutlineTint,
			OutlineTintColor = ((GameActorEffect)StaticStatusEffects.elimentalerCheeseEffect).OutlineTintColor,
			PlaysVFXOnActor = ((GameActorEffect)StaticStatusEffects.elimentalerCheeseEffect).PlaysVFXOnActor,
			AffectsEnemies = ((GameActorEffect)StaticStatusEffects.elimentalerCheeseEffect).AffectsEnemies,
			debrisAngleVariance = StaticStatusEffects.elimentalerCheeseEffect.debrisAngleVariance,
			debrisMaxForce = StaticStatusEffects.elimentalerCheeseEffect.debrisMaxForce,
			debrisMinForce = StaticStatusEffects.elimentalerCheeseEffect.debrisMinForce,
			CheeseCrystals = StaticStatusEffects.elimentalerCheeseEffect.CheeseCrystals,
			CheeseGoop = StaticStatusEffects.elimentalerCheeseEffect.CheeseGoop,
			CheeseGoopRadius = StaticStatusEffects.elimentalerCheeseEffect.CheeseGoopRadius,
			crystalNum = StaticStatusEffects.elimentalerCheeseEffect.crystalNum,
			crystalRot = StaticStatusEffects.elimentalerCheeseEffect.crystalRot,
			crystalVariation = StaticStatusEffects.elimentalerCheeseEffect.crystalVariation,
			maxStackedDuration = ((GameActorEffect)StaticStatusEffects.elimentalerCheeseEffect).maxStackedDuration,
			stackMode = ((GameActorEffect)StaticStatusEffects.elimentalerCheeseEffect).stackMode,
			vfxExplosion = StaticStatusEffects.elimentalerCheeseEffect.vfxExplosion
		};
	}

	public static GameActorHealthEffect GeneratePoison(float dps = 3f, bool damagesEnemies = true, float duration = 4f, bool affectsPlayers = true)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		//IL_0082: Unknown result type (might be due to invalid IL or missing references)
		//IL_0092: Unknown result type (might be due to invalid IL or missing references)
		//IL_0098: Unknown result type (might be due to invalid IL or missing references)
		//IL_009d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b3: Expected O, but got Unknown
		return new GameActorHealthEffect
		{
			duration = duration,
			TintColor = ((GameActorEffect)StaticStatusEffects.irradiatedLeadEffect).TintColor,
			DeathTintColor = ((GameActorEffect)StaticStatusEffects.irradiatedLeadEffect).DeathTintColor,
			effectIdentifier = "Poison",
			AppliesTint = true,
			AppliesDeathTint = true,
			resistanceType = (EffectResistanceType)2,
			DamagePerSecondToEnemies = dps,
			ignitesGoops = false,
			OverheadVFX = ((GameActorEffect)StaticStatusEffects.irradiatedLeadEffect).OverheadVFX,
			AffectsEnemies = damagesEnemies,
			AffectsPlayers = ((GameActorEffect)StaticStatusEffects.irradiatedLeadEffect).AffectsPlayers,
			AppliesOutlineTint = ((GameActorEffect)StaticStatusEffects.irradiatedLeadEffect).AppliesOutlineTint,
			OutlineTintColor = ((GameActorEffect)StaticStatusEffects.irradiatedLeadEffect).OutlineTintColor,
			PlaysVFXOnActor = ((GameActorEffect)StaticStatusEffects.irradiatedLeadEffect).PlaysVFXOnActor
		};
	}

	public static GameActorFireEffect GenerateFireEffect(float dps = 3f, bool damagesEnemies = true, float duration = 4f)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		//IL_0087: Unknown result type (might be due to invalid IL or missing references)
		//IL_0097: Unknown result type (might be due to invalid IL or missing references)
		//IL_009d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0107: Unknown result type (might be due to invalid IL or missing references)
		//IL_0117: Unknown result type (might be due to invalid IL or missing references)
		//IL_011d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0122: Unknown result type (might be due to invalid IL or missing references)
		//IL_0127: Unknown result type (might be due to invalid IL or missing references)
		//IL_0138: Expected O, but got Unknown
		return new GameActorFireEffect
		{
			duration = duration,
			TintColor = ((GameActorEffect)StaticStatusEffects.hotLeadEffect).TintColor,
			DeathTintColor = ((GameActorEffect)StaticStatusEffects.hotLeadEffect).DeathTintColor,
			effectIdentifier = ((GameActorEffect)StaticStatusEffects.hotLeadEffect).effectIdentifier,
			AppliesTint = true,
			AppliesDeathTint = true,
			resistanceType = (EffectResistanceType)1,
			DamagePerSecondToEnemies = dps,
			ignitesGoops = true,
			OverheadVFX = ((GameActorEffect)StaticStatusEffects.hotLeadEffect).OverheadVFX,
			AffectsEnemies = damagesEnemies,
			AffectsPlayers = ((GameActorEffect)StaticStatusEffects.hotLeadEffect).AffectsPlayers,
			AppliesOutlineTint = ((GameActorEffect)StaticStatusEffects.hotLeadEffect).AppliesOutlineTint,
			OutlineTintColor = ((GameActorEffect)StaticStatusEffects.hotLeadEffect).OutlineTintColor,
			PlaysVFXOnActor = ((GameActorEffect)StaticStatusEffects.hotLeadEffect).PlaysVFXOnActor,
			FlameVfx = StaticStatusEffects.hotLeadEffect.FlameVfx,
			flameBuffer = StaticStatusEffects.hotLeadEffect.flameBuffer,
			flameFpsVariation = StaticStatusEffects.hotLeadEffect.flameFpsVariation,
			flameMoveChance = StaticStatusEffects.hotLeadEffect.flameMoveChance,
			flameNumPerSquareUnit = StaticStatusEffects.hotLeadEffect.flameNumPerSquareUnit,
			maxStackedDuration = ((GameActorEffect)StaticStatusEffects.hotLeadEffect).maxStackedDuration,
			stackMode = ((GameActorEffect)StaticStatusEffects.hotLeadEffect).stackMode,
			IsGreenFire = StaticStatusEffects.hotLeadEffect.IsGreenFire
		};
	}

	public static GameActorSpeedEffect GenerateLockdown(float duration = 4f)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0081: Expected O, but got Unknown
		return new GameActorSpeedEffect
		{
			duration = duration,
			TintColor = Color.grey,
			DeathTintColor = Color.grey,
			effectIdentifier = "lockdown",
			AppliesTint = true,
			AppliesDeathTint = true,
			resistanceType = (EffectResistanceType)0,
			SpeedMultiplier = 0f,
			OverheadVFX = SharedVFX.LockdownOverhead,
			AffectsEnemies = true,
			AffectsPlayers = false,
			AppliesOutlineTint = false,
			OutlineTintColor = Color.grey,
			PlaysVFXOnActor = false
		};
	}

	public static GameActorCharmEffect GenerateCharmEffect(float duration)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Unknown result type (might be due to invalid IL or missing references)
		//IL_009d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ee: Expected O, but got Unknown
		return new GameActorCharmEffect
		{
			duration = duration,
			TintColor = ((GameActorEffect)StaticStatusEffects.charmingRoundsEffect).TintColor,
			AppliesDeathTint = ((GameActorEffect)StaticStatusEffects.charmingRoundsEffect).AppliesDeathTint,
			AppliesTint = ((GameActorEffect)StaticStatusEffects.charmingRoundsEffect).AppliesTint,
			effectIdentifier = ((GameActorEffect)StaticStatusEffects.charmingRoundsEffect).effectIdentifier,
			DeathTintColor = ((GameActorEffect)StaticStatusEffects.charmingRoundsEffect).DeathTintColor,
			OverheadVFX = ((GameActorEffect)StaticStatusEffects.charmingRoundsEffect).OverheadVFX,
			AffectsEnemies = ((GameActorEffect)StaticStatusEffects.charmingRoundsEffect).AffectsEnemies,
			AppliesOutlineTint = ((GameActorEffect)StaticStatusEffects.charmingRoundsEffect).AppliesOutlineTint,
			AffectsPlayers = ((GameActorEffect)StaticStatusEffects.charmingRoundsEffect).AffectsPlayers,
			maxStackedDuration = ((GameActorEffect)StaticStatusEffects.charmingRoundsEffect).maxStackedDuration,
			OutlineTintColor = ((GameActorEffect)StaticStatusEffects.charmingRoundsEffect).OutlineTintColor,
			PlaysVFXOnActor = ((GameActorEffect)StaticStatusEffects.charmingRoundsEffect).PlaysVFXOnActor,
			resistanceType = ((GameActorEffect)StaticStatusEffects.charmingRoundsEffect).resistanceType,
			stackMode = ((GameActorEffect)StaticStatusEffects.charmingRoundsEffect).stackMode
		};
	}

	public static GameActorPlagueEffect GeneratePlagueEffect(float duration, float dps, bool tintEnemy, Color bodyTint, bool tintCorpse, Color corpseTint)
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0073: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		return new GameActorPlagueEffect
		{
			duration = 10f,
			effectIdentifier = "plague",
			resistanceType = (EffectResistanceType)0,
			DamagePerSecondToEnemies = 2f,
			ignitesGoops = false,
			OverheadVFX = SharedVFX.PlagueOverhead,
			AffectsEnemies = true,
			AffectsPlayers = false,
			AppliesOutlineTint = false,
			PlaysVFXOnActor = false,
			AppliesTint = tintEnemy,
			AppliesDeathTint = tintCorpse,
			TintColor = bodyTint,
			DeathTintColor = corpseTint
		};
	}

	public static GameActorConfusionEffect GenerateConfusionEfffect(float duration)
	{
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		return new GameActorConfusionEffect
		{
			duration = duration,
			effectIdentifier = "confusion",
			resistanceType = (EffectResistanceType)0,
			OverheadVFX = null,
			AffectsEnemies = true,
			AffectsPlayers = false,
			AppliesOutlineTint = false,
			PlaysVFXOnActor = false
		};
	}

	public static GameActorCryingEffect GenerateCryingEfffect(float duration)
	{
		return new GameActorCryingEffect
		{
			duration = duration
		};
	}

	public static GameActorSizeEffect GenerateSizeEffect(float duration, Vector2 targetScale)
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		return new GameActorSizeEffect
		{
			duration = duration,
			newScaleMultiplier = targetScale,
			effectIdentifier = "shrink",
			resistanceType = (EffectResistanceType)0,
			OverheadVFX = null,
			AffectsEnemies = true,
			AffectsPlayers = false,
			AppliesOutlineTint = false,
			PlaysVFXOnActor = false,
			AppliesTint = false,
			AppliesDeathTint = false,
			TintColor = Color.red,
			DeathTintColor = Color.red
		};
	}
}
