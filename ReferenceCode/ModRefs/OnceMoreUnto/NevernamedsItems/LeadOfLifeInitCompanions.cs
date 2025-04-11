using System;
using System.Collections.Generic;
using Alexandria.ItemAPI;
using Alexandria.Misc;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public static class LeadOfLifeInitCompanions
{
	public static GameObject BuildIndividualPrefab(LeadOfLifeCompanionStats companionStats, string filePath, int spawningItemID, int fps, IntVector2 hitboxSize, IntVector2 hitboxOffset, bool nowalk = false, bool twoway = false, bool moddedFolder = false)
	{
		//IL_0097: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		if ((Object)(object)companionStats.prefab == (Object)null || !CompanionBuilder.companionDictionary.ContainsKey(companionStats.guid))
		{
			string text = (moddedFolder ? "LeadOfLifeModded" : "LeadOfLife");
			string text2 = (twoway ? "idleright" : "idle");
			GameObject val = CompanionBuilder.BuildPrefab("LeadOfLife " + filePath, companionStats.guid, "NevernamedsItems/Resources/Companions/" + text + "/" + filePath + "_" + text2 + "_001", hitboxOffset, hitboxSize);
			if (!twoway)
			{
				CompanionBuilder.AddAnimation(val, "idle", "NevernamedsItems/Resources/Companions/" + text + "/" + filePath + "_idle", fps, (AnimationType)1, (DirectionType)1, (FlipType)0);
				if (!nowalk)
				{
					CompanionBuilder.AddAnimation(val, "run", "NevernamedsItems/Resources/Companions/" + text + "/" + filePath + "_run", fps, (AnimationType)0, (DirectionType)1, (FlipType)0);
				}
			}
			else
			{
				CompanionBuilder.AddAnimation(val, "idle_right", "NevernamedsItems/Resources/Companions/" + text + "/" + filePath + "_idleright", fps, (AnimationType)1, (DirectionType)2, (FlipType)0);
				CompanionBuilder.AddAnimation(val, "idle_left", "NevernamedsItems/Resources/Companions/" + text + "/" + filePath + "_idleleft", fps, (AnimationType)1, (DirectionType)2, (FlipType)0);
				if (!nowalk)
				{
					CompanionBuilder.AddAnimation(val, "move_right", "NevernamedsItems/Resources/Companions/" + text + "/" + filePath + "_moveright", fps, (AnimationType)0, (DirectionType)2, (FlipType)0);
				}
				if (!nowalk)
				{
					CompanionBuilder.AddAnimation(val, "move_left", "NevernamedsItems/Resources/Companions/" + text + "/" + filePath + "_moveleft", fps, (AnimationType)0, (DirectionType)2, (FlipType)0);
				}
			}
			if (LeadOfLife.CompanionItemDictionary.ContainsKey(spawningItemID))
			{
				LeadOfLife.CompanionItemDictionary[spawningItemID].Add(companionStats.guid);
			}
			else
			{
				LeadOfLife.CompanionItemDictionary.Add(spawningItemID, new List<string> { companionStats.guid });
			}
			return val;
		}
		return companionStats.prefab;
	}

	public static Projectile GetProjectileForID(int id)
	{
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Invalid comparison between Unknown and I4
		PickupObject byId = PickupObjectDatabase.GetById(id);
		Projectile val = (((int)((Gun)((byId is Gun) ? byId : null)).DefaultModule.shootStyle != 3) ? ((Gun)/*isinst with value type is only supported in some contexts*/).DefaultModule.projectiles[0] : ((Gun)/*isinst with value type is only supported in some contexts*/).DefaultModule.chargeProjectiles[0].Projectile);
		GameObject val2 = FakePrefabExtensions.InstantiateAndFakeprefab(((Component)val).gameObject);
		return val2.GetComponent<Projectile>();
	}

	public static void BuildPrefabs()
	{
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_009f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0134: Unknown result type (might be due to invalid IL or missing references)
		//IL_013b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0175: Unknown result type (might be due to invalid IL or missing references)
		//IL_017c: Unknown result type (might be due to invalid IL or missing references)
		//IL_017d: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_023c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0243: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_0317: Unknown result type (might be due to invalid IL or missing references)
		//IL_031e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0363: Unknown result type (might be due to invalid IL or missing references)
		//IL_036a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0399: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a0: Expected O, but got Unknown
		//IL_03e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_046b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0470: Unknown result type (might be due to invalid IL or missing references)
		//IL_048c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0493: Unknown result type (might be due to invalid IL or missing references)
		//IL_0549: Unknown result type (might be due to invalid IL or missing references)
		//IL_0577: Unknown result type (might be due to invalid IL or missing references)
		//IL_057e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0632: Unknown result type (might be due to invalid IL or missing references)
		//IL_0639: Unknown result type (might be due to invalid IL or missing references)
		//IL_06c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_06c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_07a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_07a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0818: Unknown result type (might be due to invalid IL or missing references)
		//IL_081f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0858: Unknown result type (might be due to invalid IL or missing references)
		//IL_08bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_08c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_090c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0913: Expected O, but got Unknown
		//IL_095a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0961: Unknown result type (might be due to invalid IL or missing references)
		//IL_09d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_09e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a3f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a47: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a98: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a9f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ad8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b35: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b3c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bae: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bb6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c19: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c5e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c65: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d2a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d31: Unknown result type (might be due to invalid IL or missing references)
		//IL_0dae: Unknown result type (might be due to invalid IL or missing references)
		//IL_0db5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e2d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e34: Unknown result type (might be due to invalid IL or missing references)
		//IL_0eb6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ebb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ee3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0eea: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f83: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f8a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fc3: Unknown result type (might be due to invalid IL or missing references)
		//IL_1022: Unknown result type (might be due to invalid IL or missing references)
		//IL_1029: Unknown result type (might be due to invalid IL or missing references)
		//IL_10a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_10ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_1122: Unknown result type (might be due to invalid IL or missing references)
		//IL_1129: Unknown result type (might be due to invalid IL or missing references)
		//IL_11a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_11a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_1227: Unknown result type (might be due to invalid IL or missing references)
		//IL_122c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1248: Unknown result type (might be due to invalid IL or missing references)
		//IL_124f: Unknown result type (might be due to invalid IL or missing references)
		//IL_12f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_12fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_13a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_13ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_13e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_1441: Unknown result type (might be due to invalid IL or missing references)
		//IL_1449: Unknown result type (might be due to invalid IL or missing references)
		//IL_14a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_1508: Unknown result type (might be due to invalid IL or missing references)
		//IL_150f: Unknown result type (might be due to invalid IL or missing references)
		//IL_158c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1591: Unknown result type (might be due to invalid IL or missing references)
		//IL_15cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_15d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_169d: Unknown result type (might be due to invalid IL or missing references)
		//IL_16a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_1770: Unknown result type (might be due to invalid IL or missing references)
		//IL_1777: Unknown result type (might be due to invalid IL or missing references)
		//IL_17fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_1804: Unknown result type (might be due to invalid IL or missing references)
		//IL_187c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1883: Unknown result type (might be due to invalid IL or missing references)
		//IL_18e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_18ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_196e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1975: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a4f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a56: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b21: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b28: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b76: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b7d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1bf8: Unknown result type (might be due to invalid IL or missing references)
		//IL_1bff: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c6e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c75: Unknown result type (might be due to invalid IL or missing references)
		//IL_1cc2: Unknown result type (might be due to invalid IL or missing references)
		//IL_1cf6: Unknown result type (might be due to invalid IL or missing references)
		//IL_1cfd: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d4a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d75: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d7c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ddd: Unknown result type (might be due to invalid IL or missing references)
		//IL_1df9: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e00: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e6e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e75: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f05: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f0c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f7a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f81: Unknown result type (might be due to invalid IL or missing references)
		//IL_1fb0: Unknown result type (might be due to invalid IL or missing references)
		//IL_1fb7: Expected O, but got Unknown
		//IL_2047: Unknown result type (might be due to invalid IL or missing references)
		//IL_204c: Unknown result type (might be due to invalid IL or missing references)
		//IL_204e: Unknown result type (might be due to invalid IL or missing references)
		//IL_2053: Unknown result type (might be due to invalid IL or missing references)
		//IL_2055: Unknown result type (might be due to invalid IL or missing references)
		//IL_205a: Unknown result type (might be due to invalid IL or missing references)
		//IL_2061: Unknown result type (might be due to invalid IL or missing references)
		//IL_2068: Unknown result type (might be due to invalid IL or missing references)
		//IL_2073: Unknown result type (might be due to invalid IL or missing references)
		//IL_207a: Unknown result type (might be due to invalid IL or missing references)
		//IL_2081: Unknown result type (might be due to invalid IL or missing references)
		//IL_2088: Unknown result type (might be due to invalid IL or missing references)
		//IL_208f: Unknown result type (might be due to invalid IL or missing references)
		//IL_2097: Unknown result type (might be due to invalid IL or missing references)
		//IL_209e: Unknown result type (might be due to invalid IL or missing references)
		//IL_20a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_20ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_20b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_20bf: Expected O, but got Unknown
		//IL_20d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_20d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_20d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_20dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_20df: Unknown result type (might be due to invalid IL or missing references)
		//IL_20e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_20eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_20f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_20fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_2104: Unknown result type (might be due to invalid IL or missing references)
		//IL_210b: Unknown result type (might be due to invalid IL or missing references)
		//IL_2112: Unknown result type (might be due to invalid IL or missing references)
		//IL_2119: Unknown result type (might be due to invalid IL or missing references)
		//IL_2120: Unknown result type (might be due to invalid IL or missing references)
		//IL_2127: Unknown result type (might be due to invalid IL or missing references)
		//IL_212e: Unknown result type (might be due to invalid IL or missing references)
		//IL_2135: Unknown result type (might be due to invalid IL or missing references)
		//IL_213c: Unknown result type (might be due to invalid IL or missing references)
		//IL_2148: Expected O, but got Unknown
		//IL_2168: Unknown result type (might be due to invalid IL or missing references)
		//IL_2170: Unknown result type (might be due to invalid IL or missing references)
		//IL_2278: Unknown result type (might be due to invalid IL or missing references)
		//IL_227f: Unknown result type (might be due to invalid IL or missing references)
		//IL_22f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_22fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_23a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_23ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_23e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_24a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_24ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_2528: Unknown result type (might be due to invalid IL or missing references)
		//IL_252f: Unknown result type (might be due to invalid IL or missing references)
		//IL_25b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_25b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_266f: Unknown result type (might be due to invalid IL or missing references)
		//IL_2677: Unknown result type (might be due to invalid IL or missing references)
		//IL_26fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_2703: Unknown result type (might be due to invalid IL or missing references)
		//IL_2760: Unknown result type (might be due to invalid IL or missing references)
		//IL_2767: Unknown result type (might be due to invalid IL or missing references)
		//IL_27d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_27da: Unknown result type (might be due to invalid IL or missing references)
		//IL_284c: Unknown result type (might be due to invalid IL or missing references)
		//IL_2854: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			LeadOfLife.HotLeadCompanion.prefab = BuildIndividualPrefab(LeadOfLife.HotLeadCompanion, "hotleadcompanion", 295, 7, new IntVector2(7, 7), new IntVector2(6, 1));
			LeadOfLifeBasicShooter leadOfLifeBasicShooter = LeadOfLifeBasicShooter.AddToPrefab(LeadOfLife.HotLeadCompanion.prefab, 295);
			Projectile projectileForID = GetProjectileForID(336);
			projectileForID.AdditionalScaleMultiplier = 0.5f;
			leadOfLifeBasicShooter.bulletsToFire = new List<Projectile> { projectileForID };
			leadOfLifeBasicShooter.fireCooldown = 2.5f;
			leadOfLifeBasicShooter.ignitesGoop = true;
			LeadOfLife.IrradiatedLeadCompanion.prefab = BuildIndividualPrefab(LeadOfLife.IrradiatedLeadCompanion, "irradiatedleadcompanion", 204, 7, new IntVector2(7, 7), new IntVector2(6, 1));
			LeadOfLifeBasicShooter leadOfLifeBasicShooter2 = LeadOfLifeBasicShooter.AddToPrefab(LeadOfLife.IrradiatedLeadCompanion.prefab, 204);
			Projectile projectileForID2 = GetProjectileForID(86);
			projectileForID2.AdjustPlayerProjectileTint(ExtendedColours.poisonGreen, 1, 0f);
			projectileForID2.AppliesPoison = true;
			projectileForID2.PoisonApplyChance = 1f;
			projectileForID2.healthEffect = StaticStatusEffects.irradiatedLeadEffect;
			leadOfLifeBasicShooter2.bulletsToFire = new List<Projectile> { projectileForID2 };
			LeadOfLife.BatteryBulletsCompanion.prefab = BuildIndividualPrefab(LeadOfLife.BatteryBulletsCompanion, "batterybulletscompanion", 410, 7, new IntVector2(7, 7), new IntVector2(6, 1));
			LeadOfLifeBasicShooter leadOfLifeBasicShooter3 = LeadOfLifeBasicShooter.AddToPrefab(LeadOfLife.BatteryBulletsCompanion.prefab, 410);
			Projectile projectileForID3 = GetProjectileForID(86);
			projectileForID3.damageTypes = (CoreDamageTypes)(projectileForID3.damageTypes | 0x40);
			leadOfLifeBasicShooter3.bulletsToFire = new List<Projectile> { projectileForID3 };
			leadOfLifeBasicShooter3.angleVariance = 2f;
			LeadOfLife.PlusOneBulletsCompanion.prefab = BuildIndividualPrefab(LeadOfLife.PlusOneBulletsCompanion, "plusonebulletscompanion", 286, 7, new IntVector2(7, 7), new IntVector2(7, 1));
			LeadOfLifeBasicShooter leadOfLifeBasicShooter4 = LeadOfLifeBasicShooter.AddToPrefab(LeadOfLife.PlusOneBulletsCompanion.prefab, 286);
			Projectile projectileForID4 = GetProjectileForID(86);
			ProjectileData baseData = projectileForID4.baseData;
			baseData.damage *= 1.25f;
			leadOfLifeBasicShooter4.bulletsToFire = new List<Projectile> { projectileForID4 };
			LeadOfLife.AngryBulletsCompanion.prefab = BuildIndividualPrefab(LeadOfLife.AngryBulletsCompanion, "angrybulletscompanion", 323, 7, new IntVector2(7, 7), new IntVector2(6, 1));
			LeadOfLifeBasicShooter leadOfLifeBasicShooter5 = LeadOfLifeBasicShooter.AddToPrefab(LeadOfLife.AngryBulletsCompanion.prefab, 323);
			Projectile projectileForID5 = GetProjectileForID(86);
			((Component)projectileForID5).gameObject.AddComponent<AngryBulletsProjectileBehaviour>();
			leadOfLifeBasicShooter5.bulletsToFire = new List<Projectile> { projectileForID5 };
			LeadOfLife.CursedBulletsCompanion.prefab = BuildIndividualPrefab(LeadOfLife.CursedBulletsCompanion, "cursedbulletscompanion", 571, 7, new IntVector2(7, 7), new IntVector2(6, 1));
			LeadOfLifeBasicShooter leadOfLifeBasicShooter6 = LeadOfLifeBasicShooter.AddToPrefab(LeadOfLife.CursedBulletsCompanion.prefab, 571);
			Projectile projectileForID6 = GetProjectileForID(86);
			ScaleProjectileStatOffPlayerStat scaleProjectileStatOffPlayerStat = ((Component)projectileForID6).gameObject.AddComponent<ScaleProjectileStatOffPlayerStat>();
			scaleProjectileStatOffPlayerStat.multiplierPerLevelOfStat = 0.15f;
			scaleProjectileStatOffPlayerStat.projstat = ScaleProjectileStatOffPlayerStat.ProjectileStatType.DAMAGE;
			scaleProjectileStatOffPlayerStat.playerstat = (StatType)14;
			projectileForID6.AdjustPlayerProjectileTint(ExtendedColours.cursedBulletsPurple, 1, 0f);
			projectileForID6.CurseSparks = true;
			leadOfLifeBasicShooter6.bulletsToFire = new List<Projectile> { projectileForID6 };
			LeadOfLife.EasyReloadBulletsCompanion.prefab = BuildIndividualPrefab(LeadOfLife.EasyReloadBulletsCompanion, "easyreloadbulletscompanion", 375, 7, new IntVector2(7, 7), new IntVector2(8, 1));
			GameObject prefab = LeadOfLife.EasyReloadBulletsCompanion.prefab;
			List<MovementBehaviorBase> list = new List<MovementBehaviorBase>();
			List<MovementBehaviorBase> list2 = list;
			CompanionFollowPlayerBehavior val = new CompanionFollowPlayerBehavior();
			val.IdleAnimations = new string[1] { "idle" };
			list2.Add((MovementBehaviorBase)(object)val);
			LeadOfLifeCompanion leadOfLifeCompanion = LeadOfLifeCompanion.AddToPrefab(prefab, 375, 5f, list);
			leadOfLifeCompanion.globalCompanionFirerateMultiplier = 1.25f;
			LeadOfLife.GhostBulletsCompanion.prefab = BuildIndividualPrefab(LeadOfLife.GhostBulletsCompanion, "ghostbulletscompanion", 172, 7, new IntVector2(7, 7), new IntVector2(1, 3), nowalk: true);
			LeadOfLifeBasicShooter leadOfLifeBasicShooter7 = LeadOfLifeBasicShooter.AddToPrefab(LeadOfLife.GhostBulletsCompanion.prefab, 172);
			Projectile projectileForID7 = GetProjectileForID(86);
			PierceProjModifier val2 = ((Component)projectileForID7).gameObject.AddComponent<PierceProjModifier>();
			val2.penetration = 1;
			leadOfLifeBasicShooter7.bulletsToFire = new List<Projectile> { projectileForID7 };
			((CompanionController)leadOfLifeBasicShooter7).CanCrossPits = true;
			((GameActor)((BraveBehaviour)leadOfLifeBasicShooter7).aiActor).ActorShadowOffset = new Vector3(0f, -0.5f);
			LeadOfLife.FlakBulletsCompanion.prefab = BuildIndividualPrefab(LeadOfLife.FlakBulletsCompanion, "flakbulletscompanion", 531, 7, new IntVector2(7, 7), new IntVector2(8, 1));
			LeadOfLifeBasicShooter leadOfLifeBasicShooter8 = LeadOfLifeBasicShooter.AddToPrefab(LeadOfLife.FlakBulletsCompanion.prefab, 531);
			Projectile projectileForID8 = GetProjectileForID(56);
			SpawnProjModifier val3 = ((Component)projectileForID8).gameObject.AddComponent<SpawnProjModifier>();
			val3.SpawnedProjectilesInheritAppearance = true;
			val3.SpawnedProjectileScaleModifier = 0.5f;
			val3.SpawnedProjectilesInheritData = true;
			val3.spawnProjectilesOnCollision = true;
			val3.spawnProjecitlesOnDieInAir = true;
			val3.doOverrideObjectCollisionSpawnStyle = true;
			val3.startAngle = Random.Range(0, 180);
			val3.numberToSpawnOnCollison = 3;
			val3.projectileToSpawnOnCollision = ((Component)Game.Items["flak_bullets"]).GetComponent<ComplexProjectileModifier>().CollisionSpawnProjectile;
			val3.collisionSpawnStyle = (CollisionSpawnStyle)1;
			leadOfLifeBasicShooter8.bulletsToFire = new List<Projectile> { projectileForID8 };
			LeadOfLife.HeavyBulletsCompanion.prefab = BuildIndividualPrefab(LeadOfLife.HeavyBulletsCompanion, "heavybulletscompanion", 111, 5, new IntVector2(7, 7), new IntVector2(4, 1));
			LeadOfLifeBasicShooter leadOfLifeBasicShooter9 = LeadOfLifeBasicShooter.AddToPrefab(LeadOfLife.HeavyBulletsCompanion.prefab, 111, 3.5f);
			Projectile projectileForID9 = GetProjectileForID(86);
			ProjectileData baseData2 = projectileForID9.baseData;
			baseData2.damage *= 1.25f;
			ProjectileData baseData3 = projectileForID9.baseData;
			baseData3.speed *= 0.5f;
			ProjectileData baseData4 = projectileForID9.baseData;
			baseData4.force *= 2f;
			projectileForID9.AdditionalScaleMultiplier = 1.25f;
			leadOfLifeBasicShooter9.bulletsToFire = new List<Projectile> { projectileForID9 };
			LeadOfLife.RemoteBulletsCompanion.prefab = BuildIndividualPrefab(LeadOfLife.RemoteBulletsCompanion, "remotebulletscompanion", 530, 7, new IntVector2(7, 7), new IntVector2(7, 1));
			LeadOfLifeBasicShooter leadOfLifeBasicShooter10 = LeadOfLifeBasicShooter.AddToPrefab(LeadOfLife.RemoteBulletsCompanion.prefab, 530);
			Projectile projectileForID10 = GetProjectileForID(86);
			ProjectileData baseData5 = projectileForID10.baseData;
			baseData5.damage *= 1.1f;
			((Component)projectileForID10).gameObject.AddComponent<RemoteBulletsProjectileBehaviour>();
			leadOfLifeBasicShooter10.bulletsToFire = new List<Projectile> { projectileForID10 };
			LeadOfLife.KatanaBulletsCompanion.prefab = BuildIndividualPrefab(LeadOfLife.KatanaBulletsCompanion, "katanabulletscompanion", 822, 7, new IntVector2(7, 7), new IntVector2(8, 1));
			LeadOfLifeExploder leadOfLifeExploder = LeadOfLifeExploder.AddToPrefab(LeadOfLife.KatanaBulletsCompanion.prefab, 822);
			leadOfLifeExploder.doChainExplosion = true;
			leadOfLifeExploder.chainExplosionDuration = ((Component)Game.Items["katana_bullets"]).GetComponent<ComplexProjectileModifier>().LCEChainDuration;
			leadOfLifeExploder.chainExplosionDistance = ((Component)Game.Items["katana_bullets"]).GetComponent<ComplexProjectileModifier>().LCEChainDistance;
			leadOfLifeExploder.chainExplosionAmount = ((Component)Game.Items["katana_bullets"]).GetComponent<ComplexProjectileModifier>().LCEChainNumExplosions;
			leadOfLifeExploder.explosion = ((Component)Game.Items["katana_bullets"]).GetComponent<ComplexProjectileModifier>().LinearChainExplosionData;
			leadOfLifeExploder.fireCooldown = 5f;
			LeadOfLife.BouncyBulletsCompanion.prefab = BuildIndividualPrefab(LeadOfLife.BouncyBulletsCompanion, "bouncybulletscompanion", 288, 7, new IntVector2(7, 7), new IntVector2(6, 1));
			LeadOfLifeBasicShooter leadOfLifeBasicShooter11 = LeadOfLifeBasicShooter.AddToPrefab(LeadOfLife.BouncyBulletsCompanion.prefab, 288);
			Projectile projectileForID11 = GetProjectileForID(86);
			((Component)projectileForID11).gameObject.AddComponent<BounceProjModifier>();
			leadOfLifeBasicShooter11.bulletsToFire = new List<Projectile> { projectileForID11 };
			LeadOfLife.SilverBulletsCompanion.prefab = BuildIndividualPrefab(LeadOfLife.SilverBulletsCompanion, "silverbulletscompanion", 538, 7, new IntVector2(7, 7), new IntVector2(7, 1));
			LeadOfLifeBasicShooter leadOfLifeBasicShooter12 = LeadOfLifeBasicShooter.AddToPrefab(LeadOfLife.SilverBulletsCompanion.prefab, 538);
			Projectile projectileForID12 = GetProjectileForID(56);
			projectileForID12.AdjustPlayerProjectileTint(ExtendedColours.silvedBulletsSilver, 1, 0f);
			projectileForID12.BlackPhantomDamageMultiplier *= 3.25f;
			projectileForID12.BossDamageMultiplier *= 1.25f;
			leadOfLifeBasicShooter12.bulletsToFire = new List<Projectile> { projectileForID12 };
			LeadOfLife.ZombieBulletsCompanion.prefab = BuildIndividualPrefab(LeadOfLife.ZombieBulletsCompanion, "zombiebulletscompanion", 528, 7, new IntVector2(7, 7), new IntVector2(6, 1));
			CustomCompanionBehaviours.LeadOfLifeCompanionApproach leadOfLifeCompanionApproach = new CustomCompanionBehaviours.LeadOfLifeCompanionApproach();
			leadOfLifeCompanionApproach.DesiredDistance = 1.2f;
			leadOfLifeCompanionApproach.isZombieBullets = true;
			GameObject prefab2 = LeadOfLife.ZombieBulletsCompanion.prefab;
			list = new List<MovementBehaviorBase>();
			List<MovementBehaviorBase> list3 = list;
			val = new CompanionFollowPlayerBehavior();
			val.IdleAnimations = new string[1] { "idle" };
			list3.Add((MovementBehaviorBase)(object)val);
			list.Add((MovementBehaviorBase)(object)leadOfLifeCompanionApproach);
			LeadOfLifeCompanion leadOfLifeCompanion2 = LeadOfLifeCompanion.AddToPrefab(prefab2, 528, 5f, list);
			LeadOfLife.Bloody9mmCompanion.prefab = BuildIndividualPrefab(LeadOfLife.Bloody9mmCompanion, "bloody9mmcompanion", 524, 7, new IntVector2(7, 7), new IntVector2(8, 3));
			LeadOfLifeBasicShooter leadOfLifeBasicShooter13 = LeadOfLifeBasicShooter.AddToPrefab(LeadOfLife.Bloody9mmCompanion.prefab, 524);
			leadOfLifeBasicShooter13.bulletsToFire = new List<Projectile> { ((Component)PickupObjectDatabase.GetById(524)).GetComponent<RandomProjectileReplacementItem>().ReplacementProjectile };
			leadOfLifeBasicShooter13.fireCooldown = 5f;
			LeadOfLife.BumbulletsCompanion.prefab = BuildIndividualPrefab(LeadOfLife.BumbulletsCompanion, "bumbulletscompanion", 630, 7, new IntVector2(7, 7), new IntVector2(8, 1));
			LeadOfLifeBasicShooter leadOfLifeBasicShooter14 = LeadOfLifeBasicShooter.AddToPrefab(LeadOfLife.BumbulletsCompanion.prefab, 630);
			leadOfLifeBasicShooter14.bulletsToFire = new List<Projectile> { GetProjectileForID(14) };
			LeadOfLife.ChanceBulletsCompanion.prefab = BuildIndividualPrefab(LeadOfLife.ChanceBulletsCompanion, "chancebulletscompanion", 521, 7, new IntVector2(7, 7), new IntVector2(10, 1));
			LeadOfLifeRandomShooter leadOfLifeRandomShooter = LeadOfLifeRandomShooter.AddToPrefab(LeadOfLife.ChanceBulletsCompanion.prefab, 521);
			leadOfLifeRandomShooter.fireCooldown = 1.5f;
			LeadOfLife.CharmingRoundsCompanion.prefab = BuildIndividualPrefab(LeadOfLife.CharmingRoundsCompanion, "charmingroundscompanion", 527, 7, new IntVector2(7, 7), new IntVector2(6, 1));
			LeadOfLifeBasicShooter leadOfLifeBasicShooter15 = LeadOfLifeBasicShooter.AddToPrefab(LeadOfLife.CharmingRoundsCompanion.prefab, 527);
			Projectile projectileForID13 = GetProjectileForID(86);
			projectileForID13.AdjustPlayerProjectileTint(ExtendedColours.charmPink, 1, 0f);
			projectileForID13.AppliesCharm = true;
			projectileForID13.CharmApplyChance = 1f;
			projectileForID13.charmEffect = StaticStatusEffects.charmingRoundsEffect;
			leadOfLifeBasicShooter15.bulletsToFire = new List<Projectile> { projectileForID13 };
			LeadOfLife.DevolverRoundsCompanion.prefab = BuildIndividualPrefab(LeadOfLife.DevolverRoundsCompanion, "devolverroundscompanion", 638, 7, new IntVector2(7, 7), new IntVector2(7, 1));
			LeadOfLifeBasicShooter leadOfLifeBasicShooter16 = LeadOfLifeBasicShooter.AddToPrefab(LeadOfLife.DevolverRoundsCompanion.prefab, 638);
			Projectile projectileForID14 = GetProjectileForID(484);
			projectileForID14.ChanceToTransmogrify = 0.1f;
			leadOfLifeBasicShooter16.bulletsToFire = new List<Projectile> { projectileForID14 };
			LeadOfLife.GildedBulletsCompanion.prefab = BuildIndividualPrefab(LeadOfLife.GildedBulletsCompanion, "gildedbulletscompanion", 532, 7, new IntVector2(7, 7), new IntVector2(10, 0));
			LeadOfLifeBasicShooter leadOfLifeBasicShooter17 = LeadOfLifeBasicShooter.AddToPrefab(LeadOfLife.GildedBulletsCompanion.prefab, 532);
			Projectile projectileForID15 = GetProjectileForID(86);
			ScaleProjectileStatOffConsumableCount scaleProjectileStatOffConsumableCount = ((Component)projectileForID15).gameObject.AddComponent<ScaleProjectileStatOffConsumableCount>();
			scaleProjectileStatOffConsumableCount.multiplierPerLevelOfStat = 0.0038f;
			scaleProjectileStatOffConsumableCount.projstat = ScaleProjectileStatOffConsumableCount.ProjectileStatType.DAMAGE;
			scaleProjectileStatOffConsumableCount.consumableType = ScaleProjectileStatOffConsumableCount.ConsumableType.MONEY;
			projectileForID15.AdjustPlayerProjectileTint(ExtendedColours.gildedBulletsGold, 1, 0f);
			leadOfLifeBasicShooter17.bulletsToFire = new List<Projectile> { projectileForID15 };
			leadOfLifeBasicShooter17.spawnsCurrencyOnRoomClear = true;
			LeadOfLife.HelixBulletsCompanion.prefab = BuildIndividualPrefab(LeadOfLife.HelixBulletsCompanion, "helixbulletscompanion", 568, 7, new IntVector2(7, 7), new IntVector2(7, 1));
			LeadOfLifeBasicShooter leadOfLifeBasicShooter18 = LeadOfLifeBasicShooter.AddToPrefab(LeadOfLife.HelixBulletsCompanion.prefab, 568);
			leadOfLifeBasicShooter18.bulletsToFire = new List<Projectile>
			{
				((Gun)/*isinst with value type is only supported in some contexts*/).RawSourceVolley.projectiles[0].projectiles[0],
				((Gun)/*isinst with value type is only supported in some contexts*/).RawSourceVolley.projectiles[1].projectiles[0]
			};
			leadOfLifeBasicShooter18.fireCooldown = 1.6f;
			LeadOfLife.HomingBulletsCompanion.prefab = BuildIndividualPrefab(LeadOfLife.HomingBulletsCompanion, "homingbulletscompanion", 284, 7, new IntVector2(7, 7), new IntVector2(5, 0));
			LeadOfLifeBasicShooter leadOfLifeBasicShooter19 = LeadOfLifeBasicShooter.AddToPrefab(LeadOfLife.HomingBulletsCompanion.prefab, 284);
			Projectile projectileForID16 = GetProjectileForID(86);
			HomingModifier val4 = ((Component)projectileForID16).gameObject.AddComponent<HomingModifier>();
			val4.HomingRadius = 100f;
			leadOfLifeBasicShooter19.bulletsToFire = new List<Projectile> { projectileForID16 };
			LeadOfLife.MagicBulletsCompanion.prefab = BuildIndividualPrefab(LeadOfLife.MagicBulletsCompanion, "magicbulletscompanion", 533, 7, new IntVector2(7, 7), new IntVector2(6, 0));
			LeadOfLifeBasicShooter leadOfLifeBasicShooter20 = LeadOfLifeBasicShooter.AddToPrefab(LeadOfLife.MagicBulletsCompanion.prefab, 533);
			Projectile projectileForID17 = GetProjectileForID(61);
			projectileForID17.ChanceToTransmogrify = 1f;
			leadOfLifeBasicShooter20.bulletsToFire = new List<Projectile> { projectileForID17 };
			leadOfLifeBasicShooter20.fireCooldown = 7.5f;
			LeadOfLife.RocketPoweredBulletsCompanion.prefab = BuildIndividualPrefab(LeadOfLife.RocketPoweredBulletsCompanion, "rocketpoweredbulletscompanion", 113, 7, new IntVector2(7, 7), new IntVector2(2, 0), nowalk: true);
			LeadOfLifeBasicShooter leadOfLifeBasicShooter21 = LeadOfLifeBasicShooter.AddToPrefab(LeadOfLife.RocketPoweredBulletsCompanion.prefab, 113, 8f);
			Projectile projectileForID18 = GetProjectileForID(16);
			ProjectileData baseData6 = projectileForID18.baseData;
			baseData6.speed *= 1.5f;
			leadOfLifeBasicShooter21.bulletsToFire = new List<Projectile> { projectileForID18 };
			((CompanionController)leadOfLifeBasicShooter21).CanCrossPits = true;
			leadOfLifeBasicShooter21.ignitesGoop = true;
			((GameActor)((BraveBehaviour)leadOfLifeBasicShooter21).aiActor).ActorShadowOffset = new Vector3(0f, -0.5f);
			leadOfLifeBasicShooter21.fireCooldown = 1f;
			LeadOfLife.ScattershotCompanion.prefab = BuildIndividualPrefab(LeadOfLife.ScattershotCompanion, "scattershotcompanion", 241, 7, new IntVector2(7, 7), new IntVector2(6, 0));
			LeadOfLifeBasicShooter leadOfLifeBasicShooter22 = LeadOfLifeBasicShooter.AddToPrefab(LeadOfLife.ScattershotCompanion.prefab, 241);
			Projectile projectileForID19 = GetProjectileForID(56);
			ProjectileData baseData7 = projectileForID19.baseData;
			baseData7.damage *= 0.6f;
			leadOfLifeBasicShooter22.bulletsToFire = new List<Projectile> { projectileForID19, projectileForID19, projectileForID19 };
			leadOfLifeBasicShooter22.angleVariance = 35f;
			LeadOfLife.ShadowBulletsCompanion.prefab = BuildIndividualPrefab(LeadOfLife.ShadowBulletsCompanion, "shadowbulletscompanion", 352, 7, new IntVector2(7, 7), new IntVector2(6, 0));
			LeadOfLifeBasicShooter leadOfLifeBasicShooter23 = LeadOfLifeBasicShooter.AddToPrefab(LeadOfLife.ShadowBulletsCompanion.prefab, 352);
			Projectile projectileForID20 = GetProjectileForID(86);
			projectileForID20.AdjustPlayerProjectileTint(ExtendedColours.shadowBulletsBlue, 1, 0f);
			AutoDoShadowChainOnSpawn orAddComponent = GameObjectExtensions.GetOrAddComponent<AutoDoShadowChainOnSpawn>(((Component)projectileForID20).gameObject);
			orAddComponent.NumberInChain = 1;
			orAddComponent.pauseLength = 0.1f;
			leadOfLifeBasicShooter23.bulletsToFire = new List<Projectile> { projectileForID20 };
			LeadOfLife.StoutBulletsCompanion.prefab = BuildIndividualPrefab(LeadOfLife.StoutBulletsCompanion, "stoutbulletscompanion", 523, 5, new IntVector2(6, 7), new IntVector2(6, 0));
			LeadOfLifeProximityShooter leadOfLifeProximityShooter = LeadOfLifeProximityShooter.AddToPrefab(LeadOfLife.StoutBulletsCompanion.prefab, 523, 3.5f);
			Projectile projectileForID21 = GetProjectileForID(35);
			projectileForID21.baseData.damage = 15f;
			leadOfLifeProximityShooter.bulletsToFire = new List<Projectile> { projectileForID21 };
			leadOfLifeProximityShooter.scaleProxClose = true;
			LeadOfLife.AlphaBulletsCompanion.prefab = BuildIndividualPrefab(LeadOfLife.AlphaBulletsCompanion, "alphabulletscompanion", 373, 7, new IntVector2(7, 7), new IntVector2(5, 0));
			LeadOfLifeClipBasedShooter leadOfLifeClipBasedShooter = LeadOfLifeClipBasedShooter.AddToPrefab(LeadOfLife.AlphaBulletsCompanion.prefab, 373);
			leadOfLifeClipBasedShooter.bulletsToFire = new List<Projectile> { GetProjectileForID(519) };
			leadOfLifeClipBasedShooter.fireCooldown = 1.1f;
			leadOfLifeClipBasedShooter.isAlpha = true;
			LeadOfLife.OmegaBulletsCompanion.prefab = BuildIndividualPrefab(LeadOfLife.OmegaBulletsCompanion, "omegabulletscompanion", 374, 7, new IntVector2(7, 7), new IntVector2(5, 0));
			LeadOfLifeClipBasedShooter leadOfLifeClipBasedShooter2 = LeadOfLifeClipBasedShooter.AddToPrefab(LeadOfLife.OmegaBulletsCompanion.prefab, 374);
			leadOfLifeClipBasedShooter2.bulletsToFire = new List<Projectile> { GetProjectileForID(519) };
			leadOfLifeClipBasedShooter2.fireCooldown = 1.1f;
			leadOfLifeClipBasedShooter2.isOmega = true;
			LeadOfLife.ChaosBulletsCompanion.prefab = BuildIndividualPrefab(LeadOfLife.ChaosBulletsCompanion, "chaosbulletscompanion", 569, 9, new IntVector2(5, 5), new IntVector2(9, 0), nowalk: true);
			LeadOfLifeBasicShooter leadOfLifeBasicShooter24 = LeadOfLifeBasicShooter.AddToPrefab(LeadOfLife.ChaosBulletsCompanion.prefab, 569, 7f);
			Projectile projectileForID22 = GetProjectileForID(86);
			ChaosBulletsModifierComp chaosBulletsModifierComp = ((Component)projectileForID22).gameObject.AddComponent<ChaosBulletsModifierComp>();
			chaosBulletsModifierComp.chanceOfActivatingStatusEffect = 0.5f;
			leadOfLifeBasicShooter24.bulletsToFire = new List<Projectile> { projectileForID22 };
			((CompanionController)leadOfLifeBasicShooter24).CanCrossPits = true;
			((GameActor)((BraveBehaviour)leadOfLifeBasicShooter24).aiActor).ActorShadowOffset = new Vector3(0f, -0.5f);
			LeadOfLife.ExplosiveRoundsCompanion.prefab = BuildIndividualPrefab(LeadOfLife.ExplosiveRoundsCompanion, "explosiveroundscompanion", 304, 7, new IntVector2(7, 7), new IntVector2(4, 0));
			LeadOfLifeBasicShooter leadOfLifeBasicShooter25 = LeadOfLifeBasicShooter.AddToPrefab(LeadOfLife.ExplosiveRoundsCompanion.prefab, 304);
			leadOfLifeBasicShooter25.bulletsToFire = new List<Projectile> { GetProjectileForID(19) };
			leadOfLifeBasicShooter25.fireCooldown = 5f;
			leadOfLifeBasicShooter25.objectSpawnChance = 0.1f;
			leadOfLifeBasicShooter25.objectToToss = ((Component)PickupObjectDatabase.GetById(108)).GetComponent<SpawnObjectPlayerItem>().objectToSpawn.gameObject;
			leadOfLifeBasicShooter25.tossedObjectBounces = true;
			leadOfLifeBasicShooter25.objectTossForce = 6f;
			LeadOfLife.FatBulletsCompanion.prefab = BuildIndividualPrefab(LeadOfLife.FatBulletsCompanion, "fatbulletscompanion", 277, 5, new IntVector2(7, 7), new IntVector2(5, 0));
			LeadOfLifeBasicShooter leadOfLifeBasicShooter26 = LeadOfLifeBasicShooter.AddToPrefab(LeadOfLife.FatBulletsCompanion.prefab, 277, 3.5f);
			Projectile projectileForID23 = GetProjectileForID(86);
			ProjectileData baseData8 = projectileForID23.baseData;
			baseData8.damage *= 1.45f;
			ProjectileData baseData9 = projectileForID23.baseData;
			baseData9.force *= 2f;
			projectileForID23.AdditionalScaleMultiplier *= 2f;
			leadOfLifeBasicShooter26.bulletsToFire = new List<Projectile> { projectileForID23 };
			LeadOfLife.FrostBulletsCompanion.prefab = BuildIndividualPrefab(LeadOfLife.FrostBulletsCompanion, "frostbulletscompanion", 278, 7, new IntVector2(7, 7), new IntVector2(5, 0));
			LeadOfLifeBasicShooter leadOfLifeBasicShooter27 = LeadOfLifeBasicShooter.AddToPrefab(LeadOfLife.FrostBulletsCompanion.prefab, 278);
			Projectile projectileForID24 = GetProjectileForID(86);
			projectileForID24.AdjustPlayerProjectileTint(ExtendedColours.freezeBlue, 1, 0f);
			projectileForID24.AppliesFreeze = true;
			projectileForID24.FreezeApplyChance = 1f;
			projectileForID24.freezeEffect = StaticStatusEffects.frostBulletsEffect;
			leadOfLifeBasicShooter27.bulletsToFire = new List<Projectile> { projectileForID24 };
			LeadOfLife.HungryBulletsCompanion.prefab = BuildIndividualPrefab(LeadOfLife.HungryBulletsCompanion, "hungrybulletscompanion", 655, 7, new IntVector2(7, 7), new IntVector2(9, 0), nowalk: false, twoway: true);
			LeadOfLifeBasicShooter leadOfLifeBasicShooter28 = LeadOfLifeBasicShooter.AddToPrefab(LeadOfLife.HungryBulletsCompanion.prefab, 655);
			Projectile projectileForID25 = GetProjectileForID(736);
			if (Object.op_Implicit((Object)(object)((Component)projectileForID25).GetComponent<EnemyBulletsBecomeJammedModifier>()))
			{
				Object.Destroy((Object)(object)((Component)projectileForID25).GetComponent<EnemyBulletsBecomeJammedModifier>());
			}
			projectileForID25.AdjustPlayerProjectileTint(ExtendedColours.purple, 1, 0f);
			HungryProjectileModifier val5 = ((Component)projectileForID25).gameObject.AddComponent<HungryProjectileModifier>();
			val5.HungryRadius = 1.5f;
			leadOfLifeBasicShooter28.bulletsToFire = new List<Projectile> { projectileForID25 };
			leadOfLifeBasicShooter28.fireCooldown = 2.5f;
			LeadOfLife.OrbitalBulletsCompanion.prefab = BuildIndividualPrefab(LeadOfLife.OrbitalBulletsCompanion, "orbitalbulletscompanion", 661, 9, new IntVector2(6, 6), new IntVector2(6, 0), nowalk: true);
			LeadOfLifeComplexShooter leadOfLifeComplexShooter = LeadOfLifeComplexShooter.AddToPrefab(LeadOfLife.OrbitalBulletsCompanion.prefab, 661);
			Projectile projectileForID26 = GetProjectileForID(86);
			ProjectileData baseData10 = projectileForID26.baseData;
			baseData10.damage *= 0.6f;
			leadOfLifeComplexShooter.bulletsToFire = new List<Projectile> { projectileForID26 };
			((CompanionController)leadOfLifeComplexShooter).CanCrossPits = true;
			((GameActor)((BraveBehaviour)leadOfLifeComplexShooter).aiActor).ActorShadowOffset = new Vector3(0f, -0.5f);
			leadOfLifeComplexShooter.angleVariance = 45f;
			leadOfLifeComplexShooter.fireCooldown = 0.5f;
			leadOfLifeComplexShooter.orbital = true;
			LeadOfLife.ShockRoundsCompanion.prefab = BuildIndividualPrefab(LeadOfLife.ShockRoundsCompanion, "shockroundscompanion", 298, 7, new IntVector2(7, 7), new IntVector2(6, 0));
			LeadOfLifeBasicShooter leadOfLifeBasicShooter29 = LeadOfLifeBasicShooter.AddToPrefab(LeadOfLife.ShockRoundsCompanion.prefab, 298);
			Projectile projectileForID27 = GetProjectileForID(86);
			ProjectileData baseData11 = projectileForID27.baseData;
			baseData11.damage *= 0.2f;
			ProjectileData baseData12 = projectileForID27.baseData;
			baseData12.speed *= 0.25f;
			((BraveBehaviour)((BraveBehaviour)projectileForID27).sprite).renderer.enabled = false;
			NoCollideBehaviour orAddComponent2 = GameObjectExtensions.GetOrAddComponent<NoCollideBehaviour>(((Component)projectileForID27).gameObject);
			orAddComponent2.worksOnProjectiles = true;
			orAddComponent2.worksOnEnemies = true;
			PickupObject byId = PickupObjectDatabase.GetById(298);
			ComplexProjectileModifier val6 = (ComplexProjectileModifier)(object)((byId is ComplexProjectileModifier) ? byId : null);
			ChainLightningModifier orAddComponent3 = GameObjectExtensions.GetOrAddComponent<ChainLightningModifier>(((Component)projectileForID27).gameObject);
			orAddComponent3.LinkVFXPrefab = val6.ChainLightningVFX;
			orAddComponent3.damageTypes = val6.ChainLightningDamageTypes;
			orAddComponent3.maximumLinkDistance = 20f;
			orAddComponent3.damagePerHit = 5f;
			orAddComponent3.damageCooldown = val6.ChainLightningDamageCooldown;
			if ((Object)(object)val6.ChainLightningDispersalParticles != (Object)null)
			{
				orAddComponent3.UsesDispersalParticles = true;
				orAddComponent3.DispersalParticleSystemPrefab = val6.ChainLightningDispersalParticles;
				orAddComponent3.DispersalDensity = val6.ChainLightningDispersalDensity;
				orAddComponent3.DispersalMinCoherency = val6.ChainLightningDispersalMinCoherence;
				orAddComponent3.DispersalMaxCoherency = val6.ChainLightningDispersalMaxCoherence;
			}
			else
			{
				orAddComponent3.UsesDispersalParticles = false;
			}
			leadOfLifeBasicShooter29.bulletsToFire = new List<Projectile> { projectileForID27 };
			leadOfLifeBasicShooter29.fireCooldown = 0.25f;
			leadOfLifeBasicShooter29.angleVariance = 60f;
			LeadOfLife.SnowballetsCompanion.prefab = BuildIndividualPrefab(LeadOfLife.SnowballetsCompanion, "snowballetscompanion", 636, 7, new IntVector2(7, 7), new IntVector2(7, 0));
			LeadOfLifeProximityShooter leadOfLifeProximityShooter2 = LeadOfLifeProximityShooter.AddToPrefab(LeadOfLife.SnowballetsCompanion.prefab, 636);
			Projectile projectileForID28 = GetProjectileForID(402);
			ProjectileData baseData13 = projectileForID28.baseData;
			baseData13.damage *= 1.4284f;
			leadOfLifeProximityShooter2.bulletsToFire = new List<Projectile> { projectileForID28 };
			leadOfLifeProximityShooter2.scaleProxDistant = true;
			LeadOfLife.VorpalBulletsCompanion.prefab = BuildIndividualPrefab(LeadOfLife.VorpalBulletsCompanion, "vorpalbulletscompanion", 640, 7, new IntVector2(7, 7), new IntVector2(8, 0));
			LeadOfLifeBasicShooter leadOfLifeBasicShooter30 = LeadOfLifeBasicShooter.AddToPrefab(LeadOfLife.VorpalBulletsCompanion.prefab, 640);
			leadOfLifeBasicShooter30.bulletsToFire = new List<Projectile> { ((Component)PickupObjectDatabase.GetById(640)).GetComponent<ComplexProjectileModifier>().CriticalProjectile };
			leadOfLifeBasicShooter30.fireCooldown = 7f;
			LeadOfLife.BlankBulletsCompanion.prefab = BuildIndividualPrefab(LeadOfLife.BlankBulletsCompanion, "blankbulletscompanion", 579, 7, new IntVector2(7, 7), new IntVector2(5, 0));
			LeadOfLifeMassRoomDamager leadOfLifeMassRoomDamager = LeadOfLifeMassRoomDamager.AddToPrefab(LeadOfLife.BlankBulletsCompanion.prefab, 579);
			leadOfLifeMassRoomDamager.fireCooldown = 5f;
			leadOfLifeMassRoomDamager.doesBlank = true;
			leadOfLifeMassRoomDamager.roomDamageAmount = 0f;
			LeadOfLife.PlatinumBulletsCompanion.prefab = BuildIndividualPrefab(LeadOfLife.PlatinumBulletsCompanion, "platinumbulletscompanion", 627, 7, new IntVector2(7, 7), new IntVector2(6, 0));
			LeadOfLifeComplexShooter leadOfLifeComplexShooter2 = LeadOfLifeComplexShooter.AddToPrefab(LeadOfLife.PlatinumBulletsCompanion.prefab, 627);
			Projectile projectileForID29 = GetProjectileForID(545);
			projectileForID29.baseData.damage = 7f;
			leadOfLifeComplexShooter2.bulletsToFire = new List<Projectile> { projectileForID29 };
			leadOfLifeComplexShooter2.platinum = true;
			LeadOfLife.LichsEyeBulletsCompanionA.prefab = BuildIndividualPrefab(LeadOfLife.LichsEyeBulletsCompanionA, "lichseyebulletscompaniona", 815, 7, new IntVector2(6, 6), new IntVector2(6, 2));
			LeadOfLifeBasicShooter leadOfLifeBasicShooter31 = LeadOfLifeBasicShooter.AddToPrefab(LeadOfLife.LichsEyeBulletsCompanionA.prefab, 815);
			Projectile projectileForID30 = GetProjectileForID(604);
			leadOfLifeBasicShooter31.bulletsToFire = new List<Projectile>
			{
				projectileForID30,
				projectileForID30,
				projectileForID30,
				projectileForID30,
				projectileForID30,
				projectileForID30,
				projectileForID30,
				((Component)/*isinst with value type is only supported in some contexts*/).GetComponent<FireOnReloadSynergyProcessor>().DirectedBurstSettings.ProjectileInterface.SpecifiedProjectile
			};
			leadOfLifeBasicShooter31.multiShotsSequential = true;
			LeadOfLife.LichsEyeBulletsCompanionB.prefab = BuildIndividualPrefab(LeadOfLife.LichsEyeBulletsCompanionB, "lichseyebulletscompanionb", 815, 7, new IntVector2(6, 6), new IntVector2(6, 2));
			LeadOfLifeBasicShooter leadOfLifeBasicShooter32 = LeadOfLifeBasicShooter.AddToPrefab(LeadOfLife.LichsEyeBulletsCompanionB.prefab, 815);
			leadOfLifeBasicShooter32.bulletsToFire = new List<Projectile>
			{
				projectileForID30,
				projectileForID30,
				projectileForID30,
				projectileForID30,
				projectileForID30,
				projectileForID30,
				projectileForID30,
				((Component)/*isinst with value type is only supported in some contexts*/).GetComponent<FireOnReloadSynergyProcessor>().DirectedBurstSettings.ProjectileInterface.SpecifiedProjectile
			};
			leadOfLifeBasicShooter32.multiShotsSequential = true;
			LeadOfLife.BulletTimeCompanion.prefab = BuildIndividualPrefab(LeadOfLife.BulletTimeCompanion, "bullettimecompanion", 69, 7, new IntVector2(7, 7), new IntVector2(6, 2));
			LeadOfLifeTimeSlower leadOfLifeTimeSlower = LeadOfLifeTimeSlower.AddToPrefab(LeadOfLife.BulletTimeCompanion.prefab, 69, 7f);
			leadOfLifeTimeSlower.fireCooldown = 25f;
			LeadOfLife.DarumaCompanion.prefab = BuildIndividualPrefab(LeadOfLife.DarumaCompanion, "darumacompanion", 643, 7, new IntVector2(7, 7), new IntVector2(6, 2));
			LeadOfLifeBasicShooter leadOfLifeBasicShooter33 = LeadOfLifeBasicShooter.AddToPrefab(LeadOfLife.DarumaCompanion.prefab, 643);
			leadOfLifeBasicShooter33.bulletsToFire = new List<Projectile> { GetProjectileForID(53) };
			leadOfLifeBasicShooter33.attackOnTimer = false;
			leadOfLifeBasicShooter33.attacksOnActiveUse = true;
			leadOfLifeBasicShooter33.activeItemIDToAttackOn = 643;
			LeadOfLife.RiddleOfLeadCompanion.prefab = BuildIndividualPrefab(LeadOfLife.RiddleOfLeadCompanion, "riddleofleadcompanion", 271, 7, new IntVector2(8, 7), new IntVector2(6, 2));
			LeadOfLifeBasicShooter leadOfLifeBasicShooter34 = LeadOfLifeBasicShooter.AddToPrefab(LeadOfLife.RiddleOfLeadCompanion.prefab, 271, 3.5f);
			leadOfLifeBasicShooter34.bulletsToFire = new List<Projectile> { GetProjectileForID(GunOfAThousandSins.GunOfAThousandSinsID) };
			leadOfLifeBasicShooter34.fireCooldown = 5f;
			LeadOfLife.ShotgunCoffeeCompanion.prefab = BuildIndividualPrefab(LeadOfLife.ShotgunCoffeeCompanion, "shotguncoffeecompanion", 427, 11, new IntVector2(7, 7), new IntVector2(6, 2));
			LeadOfLifeGooper leadOfLifeGooper = LeadOfLifeGooper.AddToPrefab(LeadOfLife.ShotgunCoffeeCompanion.prefab, 427, 10f);
			leadOfLifeGooper.fireCooldown = 4.5f;
			leadOfLifeGooper.goopRadiusOrWidth = 3f;
			leadOfLifeGooper.goopDefToSpawn = EasyGoopDefinitions.GenerateBloodGoop(5f, ExtendedColours.brown, 10f);
			leadOfLifeGooper.doGoopCircle = true;
			LeadOfLife.ShotgaColaCompanion.prefab = BuildIndividualPrefab(LeadOfLife.ShotgaColaCompanion, "shotgacolacompanion", 426, 11, new IntVector2(7, 7), new IntVector2(5, 2));
			LeadOfLifeGooper leadOfLifeGooper2 = LeadOfLifeGooper.AddToPrefab(LeadOfLife.ShotgaColaCompanion.prefab, 426, 10f);
			leadOfLifeGooper2.fireCooldown = 2f;
			leadOfLifeGooper2.goopRadiusOrWidth = 1.5f;
			leadOfLifeGooper2.goopDefToSpawn = EasyGoopDefinitions.GenerateBloodGoop(5f, ExtendedColours.brown, 10f);
			LeadOfLife.ElderBlankCompanion.prefab = BuildIndividualPrefab(LeadOfLife.ElderBlankCompanion, "elderblankcompanion", 499, 7, new IntVector2(7, 7), new IntVector2(5, 2));
			LeadOfLifeMassRoomDamager leadOfLifeMassRoomDamager2 = LeadOfLifeMassRoomDamager.AddToPrefab(LeadOfLife.ElderBlankCompanion.prefab, 499);
			leadOfLifeMassRoomDamager2.attackOnTimer = false;
			leadOfLifeMassRoomDamager2.attacksOnActiveUse = true;
			leadOfLifeMassRoomDamager2.activeItemIDToAttackOn = 499;
			leadOfLifeMassRoomDamager2.doesBlank = true;
			leadOfLifeMassRoomDamager2.roomDamageAmount = 20f;
			leadOfLifeMassRoomDamager2.blankType = (EasyBlankType)0;
			LeadOfLife.BulletGunCompanion.prefab = BuildIndividualPrefab(LeadOfLife.BulletGunCompanion, "bulletguncompanion", 503, 7, new IntVector2(5, 5), new IntVector2(4, 1));
			LeadOfLifeBasicShooter leadOfLifeBasicShooter35 = LeadOfLifeBasicShooter.AddToPrefab(LeadOfLife.BulletGunCompanion.prefab, 503);
			leadOfLifeBasicShooter35.bulletsToFire = new List<Projectile> { GetProjectileForID(503) };
			leadOfLifeBasicShooter35.fireCooldown = 1.6f;
			LeadOfLife.ShellGunCompanion.prefab = BuildIndividualPrefab(LeadOfLife.ShellGunCompanion, "shellguncompanion", 512, 7, new IntVector2(7, 7), new IntVector2(7, 2));
			LeadOfLifeBasicShooter leadOfLifeBasicShooter36 = LeadOfLifeBasicShooter.AddToPrefab(LeadOfLife.ShellGunCompanion.prefab, 512);
			Projectile projectileForID31 = GetProjectileForID(512);
			leadOfLifeBasicShooter36.bulletsToFire = new List<Projectile> { projectileForID31, projectileForID31, projectileForID31 };
			leadOfLifeBasicShooter36.fireCooldown = 2f;
			leadOfLifeBasicShooter36.angleVariance = 16f;
			LeadOfLife.CaseyCompanion.prefab = BuildIndividualPrefab(LeadOfLife.CaseyCompanion, "caseycompanion", 541, 7, new IntVector2(4, 4), new IntVector2(8, 2));
			LeadOfLifeBasicShooter leadOfLifeBasicShooter37 = LeadOfLifeBasicShooter.AddToPrefab(LeadOfLife.CaseyCompanion.prefab, 541);
			leadOfLifeBasicShooter37.bulletsToFire = new List<Projectile> { GetProjectileForID(541) };
			leadOfLifeBasicShooter37.fireCooldown = 3.5f;
			LeadOfLife.BTCKTPCompanion.prefab = BuildIndividualPrefab(LeadOfLife.BTCKTPCompanion, "BTCKTPcompanion", 303, 7, new IntVector2(8, 8), new IntVector2(6, 2));
			GameObject prefab3 = LeadOfLife.BTCKTPCompanion.prefab;
			list = new List<MovementBehaviorBase>();
			List<MovementBehaviorBase> list4 = list;
			val = new CompanionFollowPlayerBehavior();
			val.IdleAnimations = new string[1] { "idle" };
			list4.Add((MovementBehaviorBase)(object)val);
			LeadOfLifeCompanion leadOfLifeCompanion3 = LeadOfLifeCompanion.AddToPrefab(prefab3, 303, 7f, list);
			((BraveBehaviour)leadOfLifeCompanion3).aiActor.CollisionDamage = 0f;
			((BraveBehaviour)((BraveBehaviour)leadOfLifeCompanion3).aiActor).specRigidbody.CollideWithOthers = true;
			((BraveBehaviour)((BraveBehaviour)leadOfLifeCompanion3).aiActor).specRigidbody.CollideWithTileMap = false;
			((BraveBehaviour)leadOfLifeCompanion3).healthHaver.PreventAllDamage = true;
			((BraveBehaviour)((BraveBehaviour)leadOfLifeCompanion3).aiActor).specRigidbody.PixelColliders.Clear();
			((BraveBehaviour)((BraveBehaviour)leadOfLifeCompanion3).aiActor).specRigidbody.PixelColliders.Add(new PixelCollider
			{
				ColliderGenerationMode = (PixelColliderGeneration)0,
				CollisionLayer = (CollisionLayer)3,
				IsTrigger = false,
				BagleUseFirstFrameOnly = false,
				SpecifyBagelFrame = string.Empty,
				BagelColliderNumber = 0,
				ManualOffsetX = 6,
				ManualOffsetY = 2,
				ManualWidth = 8,
				ManualHeight = 17,
				ManualDiameter = 0,
				ManualLeftX = 0,
				ManualLeftY = 0,
				ManualRightX = 0,
				ManualRightY = 0
			});
			((BraveBehaviour)((BraveBehaviour)leadOfLifeCompanion3).aiAnimator).specRigidbody.PixelColliders.Add(new PixelCollider
			{
				ColliderGenerationMode = (PixelColliderGeneration)0,
				CollisionLayer = (CollisionLayer)0,
				IsTrigger = false,
				BagleUseFirstFrameOnly = false,
				SpecifyBagelFrame = string.Empty,
				BagelColliderNumber = 0,
				ManualOffsetX = 6,
				ManualOffsetY = 2,
				ManualWidth = 8,
				ManualHeight = 8,
				ManualDiameter = 0,
				ManualLeftX = 0,
				ManualLeftY = 0,
				ManualRightX = 0,
				ManualRightY = 0
			});
			((CompanionController)leadOfLifeCompanion3).CanInterceptBullets = true;
			LeadOfLife.OneShotCompanion.prefab = BuildIndividualPrefab(LeadOfLife.OneShotCompanion, "oneshotcompanion", OneShot.OneShotID, 7, new IntVector2(7, 7), new IntVector2(10, 1), nowalk: false, twoway: false, moddedFolder: true);
			LeadOfLifeBasicShooter leadOfLifeBasicShooter38 = LeadOfLifeBasicShooter.AddToPrefab(LeadOfLife.OneShotCompanion.prefab, OneShot.OneShotID, 8f);
			Projectile projectileForID32 = GetProjectileForID(86);
			ProjectileData baseData14 = projectileForID32.baseData;
			baseData14.damage *= 2f;
			ProjectileData baseData15 = projectileForID32.baseData;
			baseData15.speed *= 2f;
			ProjectileData baseData16 = projectileForID32.baseData;
			baseData16.range *= 2f;
			ProjectileData baseData17 = projectileForID32.baseData;
			baseData17.force *= 2f;
			projectileForID32.BossDamageMultiplier *= 2f;
			projectileForID32.BlackPhantomDamageMultiplier *= 2f;
			projectileForID32.AdditionalScaleMultiplier *= 2f;
			leadOfLifeBasicShooter38.bulletsToFire = new List<Projectile> { projectileForID32 };
			leadOfLifeBasicShooter38.fireCooldown = 0.65f;
			LeadOfLife.FiftyCalRoundsCompanion.prefab = BuildIndividualPrefab(LeadOfLife.FiftyCalRoundsCompanion, "fiftycalroundscompanion", FiftyCalRounds.FiftyCalRoundsID, 7, new IntVector2(6, 6), new IntVector2(6, 1), nowalk: false, twoway: false, moddedFolder: true);
			LeadOfLifeBasicShooter leadOfLifeBasicShooter39 = LeadOfLifeBasicShooter.AddToPrefab(LeadOfLife.FiftyCalRoundsCompanion.prefab, FiftyCalRounds.FiftyCalRoundsID);
			Projectile projectileForID33 = GetProjectileForID(49);
			projectileForID33.baseData.damage = 8f;
			leadOfLifeBasicShooter39.bulletsToFire = new List<Projectile> { projectileForID33 };
			LeadOfLife.AlkaliBulletsCompanion.prefab = BuildIndividualPrefab(LeadOfLife.AlkaliBulletsCompanion, "alkalibulletscompanion", AlkaliBullets.AlkaliBulletsID, 7, new IntVector2(7, 7), new IntVector2(6, 1), nowalk: false, twoway: false, moddedFolder: true);
			LeadOfLifeBasicShooter leadOfLifeBasicShooter40 = LeadOfLifeBasicShooter.AddToPrefab(LeadOfLife.AlkaliBulletsCompanion.prefab, AlkaliBullets.AlkaliBulletsID);
			Projectile projectileForID34 = GetProjectileForID(VacuumGun.ID);
			ProjectileInstakillBehaviour orAddComponent4 = GameObjectExtensions.GetOrAddComponent<ProjectileInstakillBehaviour>(((Component)projectileForID34).gameObject);
			orAddComponent4.tagsToKill.Add("blobulon");
			orAddComponent4.protectBosses = false;
			orAddComponent4.enemyGUIDSToEraseFromExistence.Add(EnemyGuidDatabase.Entries["bloodbulon"]);
			leadOfLifeBasicShooter40.bulletsToFire = new List<Projectile> { projectileForID34 };
			LeadOfLife.AntimagicRoundsCompanion.prefab = BuildIndividualPrefab(LeadOfLife.AntimagicRoundsCompanion, "antimagicroundscompanion", AntimagicRounds.AntimagicRoundsID, 7, new IntVector2(7, 7), new IntVector2(9, 1), nowalk: false, twoway: false, moddedFolder: true);
			LeadOfLifeBasicShooter leadOfLifeBasicShooter41 = LeadOfLifeBasicShooter.AddToPrefab(LeadOfLife.AntimagicRoundsCompanion.prefab, AntimagicRounds.AntimagicRoundsID);
			Projectile projectileForID35 = GetProjectileForID(56);
			projectileForID35.AdjustPlayerProjectileTint(ExtendedColours.purple, 1, 0f);
			ProjectileInstakillBehaviour orAddComponent5 = GameObjectExtensions.GetOrAddComponent<ProjectileInstakillBehaviour>(((Component)projectileForID35).gameObject);
			orAddComponent5.tagsToKill.AddRange(new List<string> { "gunjurer", "gunsinger", "bookllet" });
			orAddComponent5.enemyGUIDsToKill.AddRange(new List<string>
			{
				EnemyGuidDatabase.Entries["wizbang"],
				EnemyGuidDatabase.Entries["pot_fairy"]
			});
			leadOfLifeBasicShooter41.bulletsToFire = new List<Projectile> { projectileForID35 };
			LeadOfLife.AntimatterBulletsCompanion.prefab = BuildIndividualPrefab(LeadOfLife.AntimatterBulletsCompanion, "antimatterbulletscompanion", AntimatterBullets.AntimatterBulletsID, 7, new IntVector2(7, 7), new IntVector2(6, 1), nowalk: false, twoway: false, moddedFolder: true);
			LeadOfLifeBasicShooter leadOfLifeBasicShooter42 = LeadOfLifeBasicShooter.AddToPrefab(LeadOfLife.AntimatterBulletsCompanion.prefab, AntimatterBullets.AntimatterBulletsID);
			Projectile projectileForID36 = GetProjectileForID(86);
			ExplodeOnBulletIntersection orAddComponent6 = GameObjectExtensions.GetOrAddComponent<ExplodeOnBulletIntersection>(((Component)projectileForID36).gameObject);
			orAddComponent6.explosionData = AntimatterBullets.smallPlayerSafeExplosion;
			leadOfLifeBasicShooter42.bulletsToFire = new List<Projectile> { projectileForID36 };
			LeadOfLife.BashfulShotCompanion.prefab = BuildIndividualPrefab(LeadOfLife.BashfulShotCompanion, "bashfulshotcompanion", BashfulShot.BashfulShotID, 7, new IntVector2(8, 8), new IntVector2(5, 1), nowalk: false, twoway: false, moddedFolder: true);
			LeadOfLifeCompanionCountReactiveShooter leadOfLifeCompanionCountReactiveShooter = LeadOfLifeCompanionCountReactiveShooter.AddToPrefab(LeadOfLife.BashfulShotCompanion.prefab, BashfulShot.BashfulShotID);
			Projectile projectileForID37 = GetProjectileForID(9);
			ProjectileData baseData18 = projectileForID37.baseData;
			baseData18.damage *= 0.5f;
			leadOfLifeCompanionCountReactiveShooter.bulletsToFire = new List<Projectile> { projectileForID37 };
			leadOfLifeCompanionCountReactiveShooter.bashfulShot = true;
			LeadOfLife.BashingBulletsCompanion.prefab = BuildIndividualPrefab(LeadOfLife.BashingBulletsCompanion, "bashingbulletscompanion", BashingBullets.BashingBulletsID, 7, new IntVector2(7, 7), new IntVector2(8, 1), nowalk: false, twoway: false, moddedFolder: true);
			LeadOfLifeBasicShooter leadOfLifeBasicShooter43 = LeadOfLifeBasicShooter.AddToPrefab(LeadOfLife.BashingBulletsCompanion.prefab, BashingBullets.BashingBulletsID);
			Projectile projectileForID38 = GetProjectileForID(541);
			ProjectileData baseData19 = projectileForID38.baseData;
			baseData19.damage *= 0.125f;
			ProjectileData baseData20 = projectileForID38.baseData;
			baseData20.range *= 0.5f;
			projectileForID38.AppliesStun = true;
			projectileForID38.StunApplyChance = 0.5f;
			projectileForID38.AppliedStunDuration = 1f;
			leadOfLifeBasicShooter43.bulletsToFire = new List<Projectile> { projectileForID38 };
			LeadOfLife.BirdshotCompanion.prefab = BuildIndividualPrefab(LeadOfLife.BirdshotCompanion, "birdshotcompanion", Birdshot.BirdshotID, 7, new IntVector2(7, 7), new IntVector2(14, 1), nowalk: false, twoway: false, moddedFolder: true);
			LeadOfLifeBasicShooter leadOfLifeBasicShooter44 = LeadOfLifeBasicShooter.AddToPrefab(LeadOfLife.BirdshotCompanion.prefab, Birdshot.BirdshotID);
			Projectile projectileForID39 = GetProjectileForID(86);
			SelectiveDamageMult orAddComponent7 = GameObjectExtensions.GetOrAddComponent<SelectiveDamageMult>(((Component)projectileForID39).gameObject);
			orAddComponent7.multOnFlyingEnemies = true;
			orAddComponent7.multiplier = 1.4f;
			leadOfLifeBasicShooter44.bulletsToFire = new List<Projectile> { projectileForID39 };
			LeadOfLife.BlightShellCompanion.prefab = BuildIndividualPrefab(LeadOfLife.BlightShellCompanion, "blightshellcompanion", BlightShell.BlightShellID, 7, new IntVector2(7, 7), new IntVector2(8, 1), nowalk: false, twoway: false, moddedFolder: true);
			LeadOfLifeBasicShooter leadOfLifeBasicShooter45 = LeadOfLifeBasicShooter.AddToPrefab(LeadOfLife.BlightShellCompanion.prefab, BlightShell.BlightShellID);
			Projectile projectileForID40 = GetProjectileForID(86);
			ScaleProjectileStatOffPlayerStat scaleProjectileStatOffPlayerStat2 = ((Component)projectileForID40).gameObject.AddComponent<ScaleProjectileStatOffPlayerStat>();
			scaleProjectileStatOffPlayerStat2.multiplierPerLevelOfStat = 0.15f;
			scaleProjectileStatOffPlayerStat2.projstat = ScaleProjectileStatOffPlayerStat.ProjectileStatType.DAMAGE;
			scaleProjectileStatOffPlayerStat2.playerstat = (StatType)14;
			projectileForID40.AdjustPlayerProjectileTint(ExtendedColours.cursedBulletsPurple, 1, 0f);
			projectileForID40.CurseSparks = true;
			leadOfLifeBasicShooter45.bulletsToFire = new List<Projectile> { projectileForID40, projectileForID40, projectileForID40, projectileForID40 };
			leadOfLifeBasicShooter45.fireCooldown = 3.5f;
			LeadOfLife.BloodthirstyBulletsCompanion.prefab = BuildIndividualPrefab(LeadOfLife.BloodthirstyBulletsCompanion, "bloodthirstybulletscompanion", BloodthirstyBullets.BloodthirstyBulletsID, 7, new IntVector2(7, 7), new IntVector2(5, 1), nowalk: false, twoway: false, moddedFolder: true);
			LeadOfLifeBasicShooter leadOfLifeBasicShooter46 = LeadOfLifeBasicShooter.AddToPrefab(LeadOfLife.BloodthirstyBulletsCompanion.prefab, BloodthirstyBullets.BloodthirstyBulletsID);
			Projectile projectileForID41 = GetProjectileForID(86);
			GameObjectExtensions.GetOrAddComponent<BloodthirstyBulletsComp>(((Component)projectileForID41).gameObject);
			leadOfLifeBasicShooter46.bulletsToFire = new List<Projectile> { projectileForID41 };
			LeadOfLife.TitanBulletsCompanion.prefab = BuildIndividualPrefab(LeadOfLife.TitanBulletsCompanion, "titanbulletscompanion", TitanBullets.ID, 5, new IntVector2(9, 9), new IntVector2(11, 2), nowalk: false, twoway: false, moddedFolder: true);
			LeadOfLifeBasicShooter leadOfLifeBasicShooter47 = LeadOfLifeBasicShooter.AddToPrefab(LeadOfLife.TitanBulletsCompanion.prefab, TitanBullets.ID, 3f);
			Projectile projectileForID42 = GetProjectileForID(86);
			projectileForID42.AdditionalScaleMultiplier = 10000f;
			ProjectileData baseData21 = projectileForID42.baseData;
			baseData21.damage *= 1.05f;
			projectileForID42.AppliesStun = true;
			projectileForID42.StunApplyChance = 0.7f;
			projectileForID42.AppliedStunDuration = 2f;
			leadOfLifeBasicShooter47.bulletsToFire = new List<Projectile> { projectileForID42 };
		}
		catch (Exception ex)
		{
			ETGModConsole.Log((object)ex.Message, false);
			ETGModConsole.Log((object)ex.StackTrace, false);
		}
	}
}
