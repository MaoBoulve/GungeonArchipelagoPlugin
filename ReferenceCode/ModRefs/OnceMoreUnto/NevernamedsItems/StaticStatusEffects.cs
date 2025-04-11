using UnityEngine;

namespace NevernamedsItems;

public class StaticStatusEffects
{
	public static GameActorFireEffect hotLeadEffect = ((Component)PickupObjectDatabase.GetById(295)).GetComponent<BulletStatusEffectItem>().FireModifierEffect;

	public static GameActorFireEffect greenFireEffect = ((Component)PickupObjectDatabase.GetById(706)).GetComponent<Gun>().DefaultModule.projectiles[0].fireEffect;

	public static GameActorFireEffect SunlightBurn = ((Component)PickupObjectDatabase.GetById(748)).GetComponent<Gun>().DefaultModule.chargeProjectiles[0].Projectile.fireEffect;

	public static GameActorFreezeEffect frostBulletsEffect = ((Component)PickupObjectDatabase.GetById(278)).GetComponent<BulletStatusEffectItem>().FreezeModifierEffect;

	public static GameActorFreezeEffect chaosBulletsFreeze = ((Component)PickupObjectDatabase.GetById(569)).GetComponent<ChaosBulletsItem>().FreezeModifierEffect;

	public static GameActorHealthEffect irradiatedLeadEffect = ((Component)PickupObjectDatabase.GetById(204)).GetComponent<BulletStatusEffectItem>().HealthModifierEffect;

	public static GameActorCharmEffect charmingRoundsEffect = ((Component)PickupObjectDatabase.GetById(527)).GetComponent<BulletStatusEffectItem>().CharmModifierEffect;

	public static GameActorCheeseEffect elimentalerCheeseEffect;

	public static GameActorCheeseEffect instantCheese;

	public static GameActorSpeedEffect tripleCrossbowSlowEffect;

	public static AIActorDebuffEffect wolfDebuff;

	public static GameActorSpeedEffect FriendlyWebGoopSpeedMod;

	public static GameActorSpeedEffect HoneySpeedMod;

	public static GameActorSpeedEffect FriendlyHoneySpeedMod;

	public static GameActorSpeedEffect PropulsionGoopSpeedMod;

	public static GameActorConfusionEffect ConfusionEffect;

	public static GameActorPlagueEffect StandardPlagueEffect;

	public static void InitCustomEffects()
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0071: Unknown result type (might be due to invalid IL or missing references)
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Expected O, but got Unknown
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00df: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0106: Unknown result type (might be due to invalid IL or missing references)
		//IL_010d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0114: Unknown result type (might be due to invalid IL or missing references)
		//IL_011a: Unknown result type (might be due to invalid IL or missing references)
		//IL_011f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0124: Unknown result type (might be due to invalid IL or missing references)
		//IL_0130: Expected O, but got Unknown
		//IL_0130: Unknown result type (might be due to invalid IL or missing references)
		//IL_0135: Unknown result type (might be due to invalid IL or missing references)
		//IL_0140: Unknown result type (might be due to invalid IL or missing references)
		//IL_0146: Unknown result type (might be due to invalid IL or missing references)
		//IL_014b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0150: Unknown result type (might be due to invalid IL or missing references)
		//IL_0156: Unknown result type (might be due to invalid IL or missing references)
		//IL_015b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0160: Unknown result type (might be due to invalid IL or missing references)
		//IL_016b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0172: Unknown result type (might be due to invalid IL or missing references)
		//IL_0179: Unknown result type (might be due to invalid IL or missing references)
		//IL_017b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0180: Unknown result type (might be due to invalid IL or missing references)
		//IL_018b: Unknown result type (might be due to invalid IL or missing references)
		//IL_019b: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cc: Expected O, but got Unknown
		//IL_01cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0207: Unknown result type (might be due to invalid IL or missing references)
		//IL_020e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0215: Unknown result type (might be due to invalid IL or missing references)
		//IL_0217: Unknown result type (might be due to invalid IL or missing references)
		//IL_021c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0227: Unknown result type (might be due to invalid IL or missing references)
		//IL_022e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0235: Unknown result type (might be due to invalid IL or missing references)
		//IL_023c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0243: Unknown result type (might be due to invalid IL or missing references)
		//IL_0249: Unknown result type (might be due to invalid IL or missing references)
		//IL_024e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0253: Unknown result type (might be due to invalid IL or missing references)
		//IL_025f: Expected O, but got Unknown
		FriendlyWebGoopSpeedMod = new GameActorSpeedEffect
		{
			duration = 1f,
			TintColor = ((GameActorEffect)tripleCrossbowSlowEffect).TintColor,
			DeathTintColor = ((GameActorEffect)tripleCrossbowSlowEffect).DeathTintColor,
			effectIdentifier = "FriendlyWebSlow",
			AppliesTint = false,
			AppliesDeathTint = false,
			resistanceType = (EffectResistanceType)0,
			SpeedMultiplier = 0.4f,
			OverheadVFX = null,
			AffectsEnemies = true,
			AffectsPlayers = false,
			AppliesOutlineTint = false,
			OutlineTintColor = ((GameActorEffect)tripleCrossbowSlowEffect).OutlineTintColor,
			PlaysVFXOnActor = false
		};
		HoneySpeedMod = new GameActorSpeedEffect
		{
			duration = 1f,
			TintColor = ((GameActorEffect)tripleCrossbowSlowEffect).TintColor,
			DeathTintColor = ((GameActorEffect)tripleCrossbowSlowEffect).DeathTintColor,
			effectIdentifier = "HoneySlow",
			AppliesTint = false,
			AppliesDeathTint = false,
			resistanceType = (EffectResistanceType)0,
			SpeedMultiplier = 0.6f,
			OverheadVFX = ((GameActorEffect)tripleCrossbowSlowEffect).OverheadVFX,
			AffectsEnemies = true,
			AffectsPlayers = true,
			AppliesOutlineTint = false,
			OutlineTintColor = ((GameActorEffect)tripleCrossbowSlowEffect).OutlineTintColor,
			PlaysVFXOnActor = false
		};
		FriendlyHoneySpeedMod = new GameActorSpeedEffect
		{
			duration = 1f,
			TintColor = ((GameActorEffect)tripleCrossbowSlowEffect).TintColor,
			DeathTintColor = ((GameActorEffect)tripleCrossbowSlowEffect).DeathTintColor,
			effectIdentifier = "HoneySlow",
			AppliesTint = false,
			AppliesDeathTint = false,
			resistanceType = (EffectResistanceType)0,
			SpeedMultiplier = 0.6f,
			OverheadVFX = ((GameActorEffect)tripleCrossbowSlowEffect).OverheadVFX,
			AffectsEnemies = true,
			AffectsPlayers = false,
			AppliesOutlineTint = false,
			OutlineTintColor = ((GameActorEffect)tripleCrossbowSlowEffect).OutlineTintColor,
			PlaysVFXOnActor = false
		};
		PropulsionGoopSpeedMod = new GameActorSpeedEffect
		{
			duration = 1f,
			TintColor = ((GameActorEffect)tripleCrossbowSlowEffect).TintColor,
			DeathTintColor = ((GameActorEffect)tripleCrossbowSlowEffect).DeathTintColor,
			effectIdentifier = "PropulsionGoopSpeed",
			AppliesTint = false,
			AppliesDeathTint = false,
			resistanceType = (EffectResistanceType)0,
			SpeedMultiplier = 1.4f,
			OverheadVFX = null,
			AffectsEnemies = true,
			AffectsPlayers = true,
			AppliesOutlineTint = false,
			OutlineTintColor = ((GameActorEffect)tripleCrossbowSlowEffect).OutlineTintColor,
			PlaysVFXOnActor = false
		};
	}

	static StaticStatusEffects()
	{
		PickupObject byId = PickupObjectDatabase.GetById(626);
		elimentalerCheeseEffect = ((Gun)((byId is Gun) ? byId : null)).DefaultModule.projectiles[0].cheeseEffect;
		instantCheese = StatusEffectHelper.GenerateCheese(10f, 150f);
		PickupObject byId2 = PickupObjectDatabase.GetById(381);
		tripleCrossbowSlowEffect = ((Gun)((byId2 is Gun) ? byId2 : null)).DefaultModule.projectiles[0].speedEffect;
		AttackBehaviorBase obj = ((BraveBehaviour)EnemyDatabase.GetOrLoadByGuid("ededff1deaf3430eaf8321d0c6b2bd80")).behaviorSpeculator.AttackBehaviors.Find((AttackBehaviorBase x) => x is WolfCompanionAttackBehavior);
		wolfDebuff = ((WolfCompanionAttackBehavior)((obj is WolfCompanionAttackBehavior) ? obj : null)).EnemyDebuff;
	}
}
