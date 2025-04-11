using System.Collections.Generic;
using UnityEngine;

namespace NevernamedsItems;

internal class EasyGoopDefinitions
{
	public static GoopDefinition FireDef;

	public static GoopDefinition OilDef;

	public static GoopDefinition PoisonDef;

	public static GoopDefinition BlobulonGoopDef;

	public static GoopDefinition WebGoop;

	public static GoopDefinition WaterGoop;

	public static GoopDefinition NapalmGoop;

	public static GoopDefinition NapalmGoopQuickIgnite;

	public static GoopDefinition CharmGoopDef;

	public static GoopDefinition GreenFireDef;

	public static GoopDefinition CheeseDef;

	public static GoopDefinition noteblood;

	public static GoopDefinition MimicSpit;

	public static GoopDefinition BulletKingWine;

	public static GoopDefinition PropulsionGoop;

	public static GoopDefinition PlayerFriendlyWebGoop;

	public static GoopDefinition PlagueGoop;

	public static GoopDefinition HoneyGoop;

	public static GoopDefinition PitGoop;

	public static GoopDefinition JarateGoop;

	public static GoopDefinition EnemyFriendlyPoisonGoop;

	public static GoopDefinition EnemyFriendlyFireGoop;

	public static GoopDefinition PlayerFriendlyPoisonGoop;

	public static GoopDefinition PlayerFriendlyFireGoop;

	public static GoopDefinition PlayerFriendlyHoneyGoop;

	private static string[] goops;

	private static List<GoopDefinition> goopDefs;

	public static void DefineDefaultGoops()
	{
		//IL_0155: Unknown result type (might be due to invalid IL or missing references)
		//IL_015a: Unknown result type (might be due to invalid IL or missing references)
		//IL_015f: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01de: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f8: Expected O, but got Unknown
		//IL_0227: Unknown result type (might be due to invalid IL or missing references)
		//IL_0231: Expected O, but got Unknown
		//IL_0257: Unknown result type (might be due to invalid IL or missing references)
		//IL_025c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0261: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_02de: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ea: Expected O, but got Unknown
		//IL_0343: Unknown result type (might be due to invalid IL or missing references)
		//IL_0348: Unknown result type (might be due to invalid IL or missing references)
		//IL_034d: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_03aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_03bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_03cb: Expected O, but got Unknown
		AssetBundle val = ResourceManager.LoadAssetBundle("shared_auto_001");
		goopDefs = new List<GoopDefinition>();
		string[] array = goops;
		foreach (string text in array)
		{
			GoopDefinition val3;
			try
			{
				Object obj = val.LoadAsset(text);
				GameObject val2 = (GameObject)(object)((obj is GameObject) ? obj : null);
				val3 = val2.GetComponent<GoopDefinition>();
			}
			catch
			{
				Object obj2 = val.LoadAsset(text);
				val3 = (GoopDefinition)(object)((obj2 is GoopDefinition) ? obj2 : null);
			}
			((Object)val3).name = text.Replace("assets/data/goops/", "").Replace(".asset", "");
			goopDefs.Add(val3);
		}
		List<GoopDefinition> list = goopDefs;
		FireDef = goopDefs[0];
		OilDef = goopDefs[1];
		PoisonDef = goopDefs[2];
		BlobulonGoopDef = goopDefs[3];
		WebGoop = goopDefs[4];
		WaterGoop = goopDefs[5];
		NapalmGoop = goopDefs[6];
		NapalmGoopQuickIgnite = goopDefs[7];
		HoneyGoop = ScriptableObject.CreateInstance<GoopDefinition>();
		HoneyGoop.CanBeIgnited = false;
		HoneyGoop.damagesEnemies = false;
		HoneyGoop.damagesPlayers = false;
		HoneyGoop.baseColor32 = Color32.op_Implicit(ExtendedColours.honeyYellow);
		HoneyGoop.goopTexture = Initialisation.assetBundle.LoadAsset<Texture2D>("honey_standard_base_001");
		HoneyGoop.usesLifespan = false;
		HoneyGoop.playerStepsChangeLifetime = true;
		HoneyGoop.playerStepsLifetime = 2.5f;
		HoneyGoop.AppliesSpeedModifier = true;
		HoneyGoop.AppliesSpeedModifierContinuously = true;
		HoneyGoop.SpeedModifierEffect = StaticStatusEffects.HoneySpeedMod;
		HoneyGoop.goopDamageTypeInteractions = new List<GoopDamageTypeInteraction>
		{
			new GoopDamageTypeInteraction
			{
				freezesGoop = false,
				electrifiesGoop = false,
				ignitionMode = (GoopIgnitionMode)0,
				damageType = (CoreDamageTypes)0
			}
		};
		PlayerFriendlyHoneyGoop = Object.Instantiate<GoopDefinition>(HoneyGoop);
		PlayerFriendlyHoneyGoop.SpeedModifierEffect = StaticStatusEffects.FriendlyHoneySpeedMod;
		PlayerFriendlyHoneyGoop.playerStepsChangeLifetime = false;
		PropulsionGoop = new GoopDefinition();
		PropulsionGoop.CanBeIgnited = false;
		PropulsionGoop.damagesEnemies = false;
		PropulsionGoop.damagesPlayers = false;
		PropulsionGoop.baseColor32 = Color32.op_Implicit(ExtendedColours.vibrantOrange);
		PropulsionGoop.goopTexture = PoisonDef.goopTexture;
		PropulsionGoop.lifespan = 30f;
		PropulsionGoop.usesLifespan = true;
		PropulsionGoop.AppliesSpeedModifier = true;
		PropulsionGoop.AppliesSpeedModifierContinuously = true;
		PropulsionGoop.SpeedModifierEffect = StaticStatusEffects.PropulsionGoopSpeedMod;
		PropulsionGoop.goopDamageTypeInteractions = new List<GoopDamageTypeInteraction>
		{
			new GoopDamageTypeInteraction
			{
				freezesGoop = false,
				electrifiesGoop = false,
				ignitionMode = (GoopIgnitionMode)0,
				damageType = (CoreDamageTypes)0
			}
		};
		GoopDefinition val4 = Object.Instantiate<GoopDefinition>(WebGoop);
		val4.playerStepsChangeLifetime = false;
		val4.SpeedModifierEffect = StaticStatusEffects.FriendlyWebGoopSpeedMod;
		PlayerFriendlyWebGoop = val4;
		PlagueGoop = ScriptableObject.CreateInstance<GoopDefinition>();
		PlagueGoop.CanBeIgnited = false;
		PlagueGoop.damagesEnemies = false;
		PlagueGoop.damagesPlayers = false;
		PlagueGoop.baseColor32 = Color32.op_Implicit(ExtendedColours.plaguePurple);
		PlagueGoop.goopTexture = PoisonDef.goopTexture;
		PlagueGoop.lifespan = 10f;
		PlagueGoop.usesLifespan = true;
		PlagueGoop.HealthModifierEffect = (GameActorHealthEffect)(object)StaticStatusEffects.StandardPlagueEffect;
		PlagueGoop.AppliesDamageOverTime = true;
		PlagueGoop.goopDamageTypeInteractions = new List<GoopDamageTypeInteraction>
		{
			new GoopDamageTypeInteraction
			{
				freezesGoop = false,
				electrifiesGoop = false,
				ignitionMode = (GoopIgnitionMode)0,
				damageType = (CoreDamageTypes)0
			}
		};
		GoopDefinition val5 = Object.Instantiate<GoopDefinition>(PoisonDef);
		val5.damagesEnemies = false;
		val5.HealthModifierEffect = StatusEffectHelper.GeneratePoison(3f, damagesEnemies: false);
		EnemyFriendlyPoisonGoop = val5;
		GoopDefinition val6 = Object.Instantiate<GoopDefinition>(FireDef);
		val6.damagesEnemies = false;
		val6.damagePerSecondtoEnemies = 0f;
		val6.fireBurnsEnemies = false;
		val6.AppliesDamageOverTime = false;
		val6.fireDamagePerSecondToEnemies = 0f;
		EnemyFriendlyFireGoop = val6;
		GoopDefinition val7 = Object.Instantiate<GoopDefinition>(PoisonDef);
		val7.damagesEnemies = true;
		val7.damagesPlayers = false;
		val7.HealthModifierEffect = StatusEffectHelper.GeneratePoison(3f, damagesEnemies: true, 4f, affectsPlayers: false);
		PlayerFriendlyPoisonGoop = val7;
		GoopDefinition val8 = Object.Instantiate<GoopDefinition>(FireDef);
		val8.damagesPlayers = false;
		val8.fireDamageToPlayer = 0f;
		PlayerFriendlyFireGoop = val8;
	}

	public static GoopDefinition GenerateBloodGoop(float dps, Color Color, float lifeSpan = 20f)
	{
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Unknown result type (might be due to invalid IL or missing references)
		//IL_0089: Unknown result type (might be due to invalid IL or missing references)
		//IL_0095: Expected O, but got Unknown
		GoopDefinition val = ScriptableObject.CreateInstance<GoopDefinition>();
		val.CanBeIgnited = false;
		val.damagesEnemies = true;
		val.damagesPlayers = false;
		val.baseColor32 = Color32.op_Implicit(Color);
		val.goopTexture = PoisonDef.goopTexture;
		val.lifespan = lifeSpan;
		val.usesLifespan = true;
		val.damagePerSecondtoEnemies = dps;
		val.CanBeElectrified = true;
		val.electrifiedTime = 1f;
		val.electrifiedDamagePerSecondToEnemies = 20f;
		val.electrifiedDamageToPlayer = 0.5f;
		val.goopDamageTypeInteractions = new List<GoopDamageTypeInteraction>
		{
			new GoopDamageTypeInteraction
			{
				damageType = (CoreDamageTypes)64,
				electrifiesGoop = true
			}
		};
		return val;
	}

	static EasyGoopDefinitions()
	{
		PickupObject byId = PickupObjectDatabase.GetById(310);
		CharmGoopDef = ((byId == null) ? null : ((Component)byId).GetComponent<WingsItem>()?.RollGoop);
		PickupObject byId2 = PickupObjectDatabase.GetById(698);
		GreenFireDef = ((Component)((Gun)((byId2 is Gun) ? byId2 : null)).DefaultModule.projectiles[0]).GetComponent<GoopModifier>().goopDefinition;
		PickupObject byId3 = PickupObjectDatabase.GetById(808);
		CheeseDef = ((Component)((Gun)((byId3 is Gun) ? byId3 : null)).DefaultModule.projectiles[0]).GetComponent<GoopModifier>().goopDefinition;
		PickupObject byId4 = PickupObjectDatabase.GetById(272);
		noteblood = ((byId4 == null) ? null : ((Component)byId4).GetComponent<IronCoinItem>()?.BloodDefinition);
		MimicSpit = ((Component)EnemyDatabase.GetOrLoadByGuid("479556d05c7c44f3b6abb3b2067fc778")).GetComponent<GoopDoer>().goopDefinition;
		BulletKingWine = ((BraveBehaviour)EnemyDatabase.GetOrLoadByGuid("ffca09398635467da3b1f4a54bcfda80")).bulletBank.GetBullet("goblet").BulletObject.GetComponent<GoopDoer>().goopDefinition;
		goops = new string[8] { "assets/data/goops/napalmgoopthatworks.asset", "assets/data/goops/oil goop.asset", "assets/data/goops/poison goop.asset", "assets/data/goops/blobulongoop.asset", "assets/data/goops/phasewebgoop.asset", "assets/data/goops/water goop.asset", "assets/data/goops/napalm goop.asset", "assets/data/goops/napalmgoopquickignite.asset" };
	}
}
