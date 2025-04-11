using System.Collections.Generic;
using Alexandria.ItemAPI;
using UnityEngine;

namespace NevernamedsItems;

public class SharedVFX
{
	public static GameObject WeakenedStatusEffectOverheadVFX;

	public static GameObject SpiratTeleportVFX;

	public static GameObject LaserSight;

	public static GameObject TeleporterPrototypeTelefragVFX;

	public static GameObject BloodiedScarfPoofVFX;

	public static GameObject ChestTeleporterTimeWarp;

	public static GameObject MachoBraceDustUpVFX;

	public static GameObject MachoBraceBurstVFX;

	public static GameObject MachoBraceOverheadVFX;

	public static GameObject LastBulletStandingX;

	public static GameObject HealingSparkles;

	public static GameObject GreenLaserCircleVFX;

	public static GameObject YellowLaserCircleVFX;

	public static GameObject RedLaserCircleVFX;

	public static GameObject BlueLaserCircleVFX;

	public static GameObject SmoothLightBlueLaserCircleVFX;

	public static GameObject SmoothLightGreenLaserCircleVFX;

	public static GameObject WhiteCircleVFX;

	public static GameObject BlueFrostBlastVFX;

	public static GameObject RedFireBlastVFX;

	public static GameObject SmallMagicPuffVFX;

	public static GameObject BigDustCloud;

	public static GameObject BloodImpactVFX;

	public static VFXPool SpiratTeleportVFXPool;

	public static GameObject HighPriestImplosionRing;

	public static GameObject ERRORShellsOverhead;

	public static GameObject PlagueOverhead;

	public static GameObject FriendlyOverhead;

	public static GameObject LockdownOverhead;

	public static GameObject JarateDrip;

	public static GameObject CryingOverhead;

	public static GameObject GildedOverhead;

	public static VFXPool DoomBoomMuzzle;

	public static GameObject PurpleLaserCircleVFX;

	public static GameObject BigWhitePoofVFX;

	public static GameObject SmallHeartImpact;

	public static GameObject W3irdstarImpact;

	public static GameObject SquarePegImpact;

	public static GameObject ArcImpact;

	public static GameObject ArcImpactRed;

	public static GameObject PaleRedImpact;

	public static GameObject BlueExplosionShard;

	public static GameObject ArcExplosion;

	public static GameObject ArcExplosionRed;

	public static GameObject JarateExplosion;

	public static GameObject BloodExplosion;

	public static GameObject KillDevilExplosion;

	public static GameObject ColouredPoofRed;

	public static GameObject ColouredPoofOrange;

	public static GameObject ColouredPoofYellow;

	public static GameObject ColouredPoofGreen;

	public static GameObject ColouredPoofBlue;

	public static GameObject ColouredPoofIndigo;

	public static GameObject ColouredPoofBrown;

	public static GameObject ColouredPoofWhite;

	public static GameObject ColouredPoofCyan;

	public static GameObject ColouredPoofGrey;

	public static GameObject ColouredPoofGold;

	public static GameObject ColouredPoofPink;

	public static GameObject DamageUpVFX;

	public static GameObject ShotSpeedUpVFX;

	public static GameObject SpeedUpVFX;

	public static GameObject FirerateUpVFX;

	public static GameObject AccuracyUpVFX;

	public static GameObject KnockbackUpVFX;

	public static GameObject ReloadSpeedUpVFX;

	public static GameObject GundetaleSpareVFX;

	public static GameObject LoveBurstAOE;

	public static GameObject LaserSlash;

	public static GameObject LaserSlashUndertale;

	public static GameObject TenPointsPopup;

	public static GameObject GoldenSparkle;

	public static GameObject BulletSmokeTrail;

	public static GameObject BulletSparkTrail;

	public static GameObject BloodCandleVFX;

	public static GameObject TinyBluePoofVFX;

	public static GameObject BlueSparkle;

	public static void Init()
	{
		//IL_0228: Unknown result type (might be due to invalid IL or missing references)
		//IL_022d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0266: Unknown result type (might be due to invalid IL or missing references)
		//IL_026b: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_038f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0394: Unknown result type (might be due to invalid IL or missing references)
		//IL_03cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0465: Unknown result type (might be due to invalid IL or missing references)
		//IL_046a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0485: Unknown result type (might be due to invalid IL or missing references)
		//IL_048b: Expected O, but got Unknown
		//IL_0735: Unknown result type (might be due to invalid IL or missing references)
		//IL_073a: Unknown result type (might be due to invalid IL or missing references)
		//IL_07a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_07a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_07e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_07e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_08a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_08a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_08dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_08e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0920: Unknown result type (might be due to invalid IL or missing references)
		//IL_0925: Unknown result type (might be due to invalid IL or missing references)
		//IL_0942: Unknown result type (might be due to invalid IL or missing references)
		GatherVanillaEffects();
		ERRORShellsOverhead = VFXToolbox.CreateVFXBundle("ErrorShellsOverhead", usesZHeight: false, 0f, -1f, -1f, null);
		PlagueOverhead = VFXToolbox.CreateVFXBundle("PlagueOverhead", usesZHeight: false, 0f, -1f, -1f, null);
		FriendlyOverhead = VFXToolbox.CreateVFXBundle("FriendlyOverhead", usesZHeight: false, 0f, -1f, -1f, null);
		LockdownOverhead = VFXToolbox.CreateVFXBundle("LockdownOverhead", usesZHeight: false, 0f, -1f, -1f, null);
		JarateDrip = VFXToolbox.CreateVFXBundle("JarateDrip", usesZHeight: false, 0f, -1f, -1f, null);
		CryingOverhead = VFXToolbox.CreateVFXBundle("CryingOverhead", usesZHeight: false, 0f, -1f, -1f, null);
		GildedOverhead = VFXToolbox.CreateVFXBundle("GildedOverhead", usesZHeight: false, 0f, -1f, -1f, null);
		PurpleLaserCircleVFX = VFXToolbox.CreateVFXBundle("PurpleLaserImpact", usesZHeight: false, 0f, -1f, -1f, null);
		BigWhitePoofVFX = VFXToolbox.CreateVFXBundle("BigWhitePoof", usesZHeight: false, 0f, -1f, -1f, null);
		SmallHeartImpact = VFXToolbox.CreateVFXBundle("LovePistolImpact", usesZHeight: true, 5f, -1f, -1f, null);
		W3irdstarImpact = VFXToolbox.CreateVFXBundle("W3irdstarImpact", usesZHeight: false, 0f, -1f, -1f, null);
		SquarePegImpact = VFXToolbox.CreateVFXBundle("SquarePegImpact", usesZHeight: false, 0f, -1f, -1f, null);
		ArcImpact = VFXToolbox.CreateVFXBundle("ArcImpact", usesZHeight: true, 0.18f, 20f, 5f, Color32.op_Implicit(new Color32((byte)145, (byte)223, byte.MaxValue, byte.MaxValue)));
		ArcImpactRed = VFXToolbox.CreateVFXBundle("ArcImpactRed", usesZHeight: true, 0.18f, 20f, 5f, Color32.op_Implicit(new Color32(byte.MaxValue, (byte)90, (byte)90, byte.MaxValue)));
		PaleRedImpact = VFXToolbox.CreateVFXBundle("PaleRedImpact", usesZHeight: true, 1f, 7f, 7f, Color32.op_Implicit(new Color32(byte.MaxValue, (byte)117, (byte)117, byte.MaxValue)));
		BlueExplosionShard = ((Component)Breakables.GenerateDebrisObject(Initialisation.VFXCollection, "blueexplosiondebris", debrisObjectsCanRotate: true, 1f, 1f, 360f)).gameObject;
		PickupObject byId = PickupObjectDatabase.GetById(304);
		GameObject val = FakePrefabExtensions.InstantiateAndFakeprefab(((Component)((BraveBehaviour)((Component)((ComplexProjectileModifier)((byId is ComplexProjectileModifier) ? byId : null)).ExplosionData.effect.transform.Find("vfx_explosion_debris_001")).gameObject.GetComponent<ExplosionDebrisLauncher>().debrisSources[0]).transform.Find("vfx_explosion_subsidiary_001")).gameObject);
		val.transform.SetParent(BlueExplosionShard.transform);
		ArcExplosion = VFXToolbox.CreateVFXBundle("ArcExplosion", usesZHeight: true, 0.18f, 20f, 5f, Color32.op_Implicit(new Color32((byte)145, (byte)223, byte.MaxValue, byte.MaxValue)));
		ArcExplosionRed = VFXToolbox.CreateVFXBundle("ArcExplosionRed", usesZHeight: true, 0.18f, 20f, 5f, Color32.op_Implicit(new Color32(byte.MaxValue, (byte)90, (byte)90, byte.MaxValue)));
		JarateExplosion = VFXToolbox.CreateVFXBundle("JarateExplosion", usesZHeight: false, 0f, -1f, -1f, null);
		BloodExplosion = VFXToolbox.CreateVFXBundle("BloodExplosion", usesZHeight: false, 0f, -1f, -1f, null);
		KillDevilExplosion = VFXToolbox.CreateVFXBundle("KillDevilExplosion", usesZHeight: true, 0.18f, 5f, 10f, Color32.op_Implicit(new Color32((byte)149, (byte)197, (byte)246, byte.MaxValue)));
		GameObject val2 = new GameObject("Debris Launcher");
		val2.transform.SetParent(KillDevilExplosion.transform);
		ExplosionDebrisLauncher val3 = val2.AddComponent<ExplosionDebrisLauncher>();
		val3.minExpulsionForce = 3f;
		val3.maxExpulsionForce = 7f;
		val3.maxShards = 2;
		val3.minShards = 1;
		val3.debrisSources = new List<DebrisObject> { BlueExplosionShard.GetComponent<DebrisObject>() }.ToArray();
		ColouredPoofRed = VFXToolbox.CreateVFXBundle("ColourPoofRed", usesZHeight: false, 0f, -1f, -1f, null);
		ColouredPoofOrange = VFXToolbox.CreateVFXBundle("ColourPoofOrange", usesZHeight: false, 0f, -1f, -1f, null);
		ColouredPoofYellow = VFXToolbox.CreateVFXBundle("ColourPoofYellow", usesZHeight: false, 0f, -1f, -1f, null);
		ColouredPoofGreen = VFXToolbox.CreateVFXBundle("ColourPoofGreen", usesZHeight: false, 0f, -1f, -1f, null);
		ColouredPoofBlue = VFXToolbox.CreateVFXBundle("ColourPoofBlue", usesZHeight: false, 0f, -1f, -1f, null);
		ColouredPoofIndigo = VFXToolbox.CreateVFXBundle("ColourPoofIndigo", usesZHeight: false, 0f, -1f, -1f, null);
		ColouredPoofBrown = VFXToolbox.CreateVFXBundle("ColourPoofBrown", usesZHeight: false, 0f, -1f, -1f, null);
		ColouredPoofWhite = VFXToolbox.CreateVFXBundle("ColourPoofWhite", usesZHeight: false, 0f, -1f, -1f, null);
		ColouredPoofCyan = VFXToolbox.CreateVFXBundle("ColourPoofCyan", usesZHeight: false, 0f, -1f, -1f, null);
		ColouredPoofGrey = VFXToolbox.CreateVFXBundle("ColourPoofGrey", usesZHeight: false, 0f, -1f, -1f, null);
		ColouredPoofGold = VFXToolbox.CreateVFXBundle("ColourPoofGold", usesZHeight: false, 0f, -1f, -1f, null);
		ColouredPoofPink = VFXToolbox.CreateVFXBundle("ColourPoofPink", usesZHeight: false, 0f, -1f, -1f, null);
		SpeedUpVFX = VFXToolbox.CreateVFXBundle("SpeedUpVFX", usesZHeight: true, 0.18f, -1f, -1f, null);
		GundetaleSpareVFX = VFXToolbox.CreateVFXBundle("GundertaleSpare", usesZHeight: true, 0.18f, 5f, 5f, Color32.op_Implicit(new Color32(byte.MaxValue, (byte)229, (byte)87, byte.MaxValue)));
		LoveBurstAOE = VFXToolbox.CreateVFXBundle("LoveBurstAOE", usesZHeight: true, 0.18f, -1f, -1f, null);
		LaserSlash = VFXToolbox.CreateVFXBundle("LaserSlash", usesZHeight: true, 0.18f, 10f, 10f, Color32.op_Implicit(new Color32(byte.MaxValue, (byte)116, byte.MaxValue, byte.MaxValue)));
		LaserSlashUndertale = VFXToolbox.CreateVFXBundle("LaserSlashUndertale", usesZHeight: true, 0.18f, 10f, 10f, Color32.op_Implicit(new Color32(byte.MaxValue, (byte)116, byte.MaxValue, byte.MaxValue)));
		TenPointsPopup = VFXToolbox.CreateVFXBundle("TenPointsPopup", usesZHeight: true, 0.18f, -1f, -1f, null);
		GoldenSparkle = VFXToolbox.CreateVFXBundle("GoldenSparkle", usesZHeight: false, 0f, -1f, -1f, null);
		BulletSmokeTrail = VFXToolbox.CreateVFXBundle("BulletSmokeTrail", usesZHeight: false, 0f, -1f, -1f, null);
		BulletSparkTrail = VFXToolbox.CreateVFXBundle("BulletSparkTrail", usesZHeight: false, 0f, 10f, 10f, Color32.op_Implicit(new Color32((byte)246, (byte)217, (byte)101, byte.MaxValue)));
		BloodCandleVFX = VFXToolbox.CreateVFXBundle("BloodCandleVFX", usesZHeight: false, 0f, 10f, 20f, Color32.op_Implicit(new Color32(byte.MaxValue, (byte)0, (byte)0, byte.MaxValue)));
		TinyBluePoofVFX = VFXToolbox.CreateVFXBundle("TinyBluePoof", usesZHeight: false, 0f, 3f, 5f, Color32.op_Implicit(new Color32((byte)149, (byte)197, (byte)246, byte.MaxValue)));
		BlueSparkle = VFXToolbox.CreateVFXBundle("DiamondSparkle", new IntVector2(7, 7), (Anchor)4, usesZHeight: true, 0.4f, -1f, null);
	}

	public static void GatherVanillaEffects()
	{
		GameObject val = LoadHelper.LoadAssetFromAnywhere<GameObject>("_ChallengeManager");
		ChallengeModifier challenge = val.GetComponent<ChallengeManager>().PossibleChallenges[0].challenge;
		LastBulletStandingX = ((BestForLastChallengeModifier)((challenge is BestForLastChallengeModifier) ? challenge : null)).KingVFX;
		GameObject bulletObject = ((BraveBehaviour)EnemyDatabase.GetOrLoadByGuid("7ec3e8146f634c559a7d58b19191cd43")).bulletBank.GetBullet("self").BulletObject;
		Projectile component = bulletObject.GetComponent<Projectile>();
		if ((Object)(object)component != (Object)null)
		{
			TeleportProjModifier component2 = ((Component)component).GetComponent<TeleportProjModifier>();
			if ((Object)(object)component2 != (Object)null)
			{
				SpiratTeleportVFXPool = component2.teleportVfx;
				SpiratTeleportVFX = component2.teleportVfx.effects[0].effects[0].effect;
			}
		}
		AIAnimator aiAnimator = ((BraveBehaviour)EnemyDatabase.GetOrLoadByGuid("6c43fddfd401456c916089fdd1c99b1c")).aiAnimator;
		List<NamedVFXPool> otherVFX = aiAnimator.OtherVFX;
		foreach (NamedVFXPool item in otherVFX)
		{
			if (!(item.name == "mergo"))
			{
				continue;
			}
			VFXComplex[] effects = item.vfxPool.effects;
			foreach (VFXComplex val2 in effects)
			{
				VFXObject[] effects2 = val2.effects;
				foreach (VFXObject val3 in effects2)
				{
					HighPriestImplosionRing = val3.effect;
				}
			}
		}
	}

	static SharedVFX()
	{
		Object obj = ResourceCache.Acquire("Global VFX/VFX_Debuff_Status");
		WeakenedStatusEffectOverheadVFX = (GameObject)(object)((obj is GameObject) ? obj : null);
		Object obj2 = LoadHelper.LoadAssetFromAnywhere("assets/resourcesbundle/global vfx/vfx_lasersight.prefab");
		LaserSight = (GameObject)(object)((obj2 is GameObject) ? obj2 : null);
		TeleporterPrototypeTelefragVFX = ((Component)PickupObjectDatabase.GetById(449)).GetComponent<TeleporterPrototypeItem>().TelefragVFXPrefab.gameObject;
		BloodiedScarfPoofVFX = ((Component)PickupObjectDatabase.GetById(436)).GetComponent<BlinkPassiveItem>().BlinkpoofVfx.gameObject;
		PickupObject byId = PickupObjectDatabase.GetById(573);
		ChestTeleporterTimeWarp = ((ChestTeleporterItem)((byId is ChestTeleporterItem) ? byId : null)).TeleportVFX;
		MachoBraceDustUpVFX = ((Component)PickupObjectDatabase.GetById(665)).GetComponent<MachoBraceItem>().DustUpVFX;
		MachoBraceBurstVFX = ((Component)PickupObjectDatabase.GetById(665)).GetComponent<MachoBraceItem>().BurstVFX;
		MachoBraceOverheadVFX = ((Component)PickupObjectDatabase.GetById(665)).GetComponent<MachoBraceItem>().OverheadVFX;
		HealingSparkles = BraveResources.Load<GameObject>("Global VFX/VFX_Healing_Sparkles_001", ".prefab");
		PickupObject byId2 = PickupObjectDatabase.GetById(89);
		GreenLaserCircleVFX = ((Gun)((byId2 is Gun) ? byId2 : null)).DefaultModule.projectiles[0].hitEffects.overrideMidairDeathVFX;
		PickupObject byId3 = PickupObjectDatabase.GetById(651);
		YellowLaserCircleVFX = ((Gun)((byId3 is Gun) ? byId3 : null)).DefaultModule.projectiles[0].hitEffects.overrideMidairDeathVFX;
		PickupObject byId4 = PickupObjectDatabase.GetById(32);
		RedLaserCircleVFX = ((Gun)((byId4 is Gun) ? byId4 : null)).DefaultModule.projectiles[0].hitEffects.overrideMidairDeathVFX;
		PickupObject byId5 = PickupObjectDatabase.GetById(59);
		BlueLaserCircleVFX = ((Gun)((byId5 is Gun) ? byId5 : null)).DefaultModule.projectiles[0].hitEffects.enemy.effects[0].effects[0].effect;
		PickupObject byId6 = PickupObjectDatabase.GetById(576);
		SmoothLightBlueLaserCircleVFX = ((Gun)((byId6 is Gun) ? byId6 : null)).DefaultModule.projectiles[0].hitEffects.overrideMidairDeathVFX;
		PickupObject byId7 = PickupObjectDatabase.GetById(360);
		SmoothLightGreenLaserCircleVFX = ((Gun)((byId7 is Gun) ? byId7 : null)).DefaultModule.projectiles[0].hitEffects.overrideMidairDeathVFX;
		PickupObject byId8 = PickupObjectDatabase.GetById(330);
		WhiteCircleVFX = ((Gun)((byId8 is Gun) ? byId8 : null)).DefaultModule.projectiles[0].hitEffects.overrideMidairDeathVFX;
		PickupObject byId9 = PickupObjectDatabase.GetById(225);
		BlueFrostBlastVFX = ((Gun)((byId9 is Gun) ? byId9 : null)).DefaultModule.projectiles[0].hitEffects.overrideMidairDeathVFX;
		PickupObject byId10 = PickupObjectDatabase.GetById(125);
		RedFireBlastVFX = ((Gun)((byId10 is Gun) ? byId10 : null)).DefaultModule.projectiles[0].hitEffects.overrideMidairDeathVFX;
		PickupObject byId11 = PickupObjectDatabase.GetById(338);
		SmallMagicPuffVFX = ((Gun)((byId11 is Gun) ? byId11 : null)).DefaultModule.projectiles[0].hitEffects.overrideMidairDeathVFX;
		PickupObject byId12 = PickupObjectDatabase.GetById(37);
		BigDustCloud = ((Gun)((byId12 is Gun) ? byId12 : null)).DefaultModule.chargeProjectiles[0].Projectile.hitEffects.overrideMidairDeathVFX;
		PickupObject byId13 = PickupObjectDatabase.GetById(369);
		BloodImpactVFX = ((Gun)((byId13 is Gun) ? byId13 : null)).DefaultModule.chargeProjectiles[0].Projectile.hitEffects.tileMapVertical.effects[0].effects[0].effect;
		DoomBoomMuzzle = VFXToolbox.CreateVFXPoolBundle("DoomBoomMuzzle", usesZHeight: false, 0f, (VFXAlignment)0, -1f, null);
	}
}
