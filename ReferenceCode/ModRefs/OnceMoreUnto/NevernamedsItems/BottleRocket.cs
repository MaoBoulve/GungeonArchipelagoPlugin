using System.Collections.Generic;
using Alexandria.Assetbundle;
using Alexandria.ItemAPI;
using Alexandria.Misc;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class BottleRocket : AdvancedGunBehavior
{
	public static int ID;

	public static Projectile highPressureBeam;

	public static Projectile highPressurePoison;

	public static ExplosionData bottleRocketBoom;

	public static void Add()
	{
		//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_012a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0149: Unknown result type (might be due to invalid IL or missing references)
		//IL_016e: Unknown result type (might be due to invalid IL or missing references)
		//IL_020a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0211: Expected O, but got Unknown
		//IL_03d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_040b: Unknown result type (might be due to invalid IL or missing references)
		//IL_055e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0563: Unknown result type (might be due to invalid IL or missing references)
		//IL_056a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0577: Expected O, but got Unknown
		//IL_0598: Unknown result type (might be due to invalid IL or missing references)
		//IL_05be: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Bottle Rocket", "bottlerocket");
		Game.Items.Rename("outdated_gun_mods:bottle_rocket", "nn:bottle_rocket");
		BottleRocket bottleRocket = ((Component)val).gameObject.AddComponent<BottleRocket>();
		((AdvancedGunBehavior)bottleRocket).preventNormalFireAudio = true;
		GunExt.SetShortDescription((PickupObject)(object)val, "Waterarms Afficionado");
		GunExt.SetLongDescription((PickupObject)(object)val, "A pressurised bottle of fluid. Pumping it any fuller will send it flying off in erratic directions.\n\nProne to exploding.");
		val.SetGunSprites("bottlerocket");
		PickupObject byId = PickupObjectDatabase.GetById(56);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId is Gun) ? byId : null), true, false);
		ref string gunSwitchGroup = ref val.gunSwitchGroup;
		PickupObject byId2 = PickupObjectDatabase.GetById(150);
		gunSwitchGroup = ((Gun)((byId2 is Gun) ? byId2 : null)).gunSwitchGroup;
		val.DefaultModule.ammoCost = 1;
		val.doesScreenShake = true;
		val.DefaultModule.shootStyle = (ShootStyle)3;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 0.5f;
		val.DefaultModule.cooldownTime = 1f;
		val.DefaultModule.angleVariance = 5f;
		ref VFXPool muzzleFlashEffects = ref val.muzzleFlashEffects;
		PickupObject byId3 = PickupObjectDatabase.GetById(359);
		muzzleFlashEffects = ((Gun)((byId3 is Gun) ? byId3 : null)).muzzleFlashEffects;
		val.DefaultModule.numberOfShotsInClip = 1;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(1.43f, 0.62f, 0f);
		val.SetBaseMaxAmmo(100);
		val.ammo = 100;
		val.gunClass = (GunClass)60;
		GunExt.SetAnimationFPS(val, val.chargeAnimation, 8);
		((Component)val).GetComponent<tk2dSpriteAnimator>().GetClipByName(val.chargeAnimation).wrapMode = (WrapMode)1;
		((Component)val).GetComponent<tk2dSpriteAnimator>().GetClipByName(val.chargeAnimation).loopStart = 0;
		((Component)val).GetComponent<tk2dSpriteAnimator>().GetClipByName(val.chargeAnimation).frames[3].eventAudio = "Play_WPN_trashgun_impact_01";
		((Component)val).GetComponent<tk2dSpriteAnimator>().GetClipByName(val.chargeAnimation).frames[3].triggerEvent = true;
		((Component)val).GetComponent<tk2dSpriteAnimator>().GetClipByName(val.shootAnimation).frames[0].eventAudio = "Play_ENV_water_splash_01";
		((Component)val).GetComponent<tk2dSpriteAnimator>().GetClipByName(val.shootAnimation).frames[0].triggerEvent = true;
		ExplosionData val2 = new ExplosionData();
		ref GameObject effect = ref val2.effect;
		PickupObject byId4 = PickupObjectDatabase.GetById(36);
		effect = ((Gun)((byId4 is Gun) ? byId4 : null)).DefaultModule.chargeProjectiles[1].Projectile.hitEffects.overrideMidairDeathVFX;
		val2.ignoreList = new List<SpeculativeRigidbody>();
		val2.ss = StaticExplosionDatas.tetrisBlockExplosion.ss;
		val2.damageRadius = 3.5f;
		val2.damageToPlayer = 0f;
		val2.doDamage = true;
		val2.damage = 19f;
		val2.doDestroyProjectiles = false;
		val2.doForce = true;
		val2.debrisForce = 20f;
		val2.preventPlayerForce = true;
		val2.explosionDelay = 0.1f;
		val2.usesComprehensiveDelay = false;
		val2.doScreenShake = true;
		val2.playDefaultSFX = false;
		val2.force = 20f;
		val2.breakSecretWalls = false;
		bottleRocketBoom = val2;
		Projectile val3 = Object.Instantiate<Projectile>(val.DefaultModule.projectiles[0]);
		((Component)val3).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val3).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val3);
		val3.baseData.damage = 19f;
		ProjectileData baseData = val3.baseData;
		baseData.force *= 2f;
		ProjectileData baseData2 = val3.baseData;
		baseData2.speed *= 1.4f;
		ProjectileData baseData3 = val3.baseData;
		baseData3.range *= 2f;
		ref GameObject overrideMidairDeathVFX = ref val3.hitEffects.overrideMidairDeathVFX;
		PickupObject byId5 = PickupObjectDatabase.GetById(33);
		overrideMidairDeathVFX = ((Gun)((byId5 is Gun) ? byId5 : null)).DefaultModule.projectiles[0].hitEffects.overrideMidairDeathVFX;
		val3.hitEffects.alwaysUseMidair = true;
		ProjectileBuilders.AnimateProjectileBundle(val3, "BottleRocketProjectile", Initialisation.ProjectileCollection, Initialisation.projectileAnimationCollection, "BottleRocketProjectile", MiscTools.DupeList<IntVector2>(new IntVector2(24, 16), 2), MiscTools.DupeList(value: false, 2), MiscTools.DupeList<Anchor>((Anchor)4, 2), MiscTools.DupeList(value: true, 2), MiscTools.DupeList(value: false, 2), MiscTools.DupeList<Vector3?>(null, 2), MiscTools.DupeList((IntVector2?)new IntVector2(15, 8), 2), MiscTools.DupeList<IntVector2?>(null, 2), MiscTools.DupeList<Projectile>(null, 2));
		((Component)val3).gameObject.AddComponent<ProjectileMotionDrift>();
		((Component)val3).gameObject.AddComponent<BounceProjModifier>();
		GoopModifier val4 = ((Component)val3).gameObject.AddComponent<GoopModifier>();
		val4.SpawnGoopInFlight = true;
		val4.SpawnGoopOnCollision = true;
		val4.CollisionSpawnRadius = 5f;
		val4.InFlightSpawnRadius = 1f;
		val4.InFlightSpawnFrequency = 0.05f;
		val4.goopDefinition = EasyGoopDefinitions.WaterGoop;
		CustomImpactSoundBehav customImpactSoundBehav = ((Component)val3).gameObject.AddComponent<CustomImpactSoundBehav>();
		customImpactSoundBehav.ImpactSFX = "Play_ENM_blobulord_splash_01";
		ExplosiveModifier orAddComponent = GameObjectExtensions.GetOrAddComponent<ExplosiveModifier>(((Component)val3).gameObject);
		orAddComponent.explosionData = bottleRocketBoom;
		orAddComponent.doExplosion = true;
		BeamBulletsBehaviour beamBulletsBehaviour = ((Component)val3).gameObject.AddComponent<BeamBulletsBehaviour>();
		beamBulletsBehaviour.firetype = BeamBulletsBehaviour.FireType.BACKWARDS;
		PickupObject byId6 = PickupObjectDatabase.GetById(10);
		highPressureBeam = Object.Instantiate<Projectile>(((Gun)((byId6 is Gun) ? byId6 : null)).DefaultModule.projectiles[0]);
		ProjectileData baseData4 = highPressureBeam.baseData;
		baseData4.speed *= 2f;
		((Component)highPressureBeam).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)highPressureBeam).gameObject);
		Object.DontDestroyOnLoad((Object)(object)highPressureBeam);
		beamBulletsBehaviour.beamToFire = highPressureBeam;
		ChargeProjectile item = new ChargeProjectile
		{
			Projectile = val3,
			ChargeTime = 0.5f
		};
		val.DefaultModule.chargeProjectiles = new List<ChargeProjectile> { item };
		val.DefaultModule.ammoType = (AmmoType)14;
		val.DefaultModule.customAmmoType = CustomClipAmmoTypeToolbox.AddCustomAmmoType("Bottle Rocket Bullets", "NevernamedsItems/Resources/CustomGunAmmoTypes/bottlerocket_clipfull", "NevernamedsItems/Resources/CustomGunAmmoTypes/bottlerocket_clipempty");
		((PickupObject)val).quality = (ItemQuality)2;
		Databases.Items.Add(val, (tk2dSpriteCollectionData)null, "ANY");
		PickupObject byId7 = PickupObjectDatabase.GetById(208);
		highPressurePoison = Object.Instantiate<Projectile>(((Gun)((byId7 is Gun) ? byId7 : null)).DefaultModule.projectiles[0]);
		ProjectileData baseData5 = highPressurePoison.baseData;
		baseData5.speed *= 2f;
		((Component)highPressurePoison).GetComponent<GoopModifier>().goopDefinition = EasyGoopDefinitions.PlayerFriendlyPoisonGoop;
		((Component)highPressurePoison).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)highPressurePoison).gameObject);
		Object.DontDestroyOnLoad((Object)(object)highPressurePoison);
		ID = ((PickupObject)val).PickupObjectId;
	}

	public override void PostProcessProjectile(Projectile projectile)
	{
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		if (Object.op_Implicit((Object)(object)projectile) && Object.op_Implicit((Object)(object)ProjectileUtility.ProjectilePlayerOwner(projectile)) && CustomSynergies.PlayerHasActiveSynergy(ProjectileUtility.ProjectilePlayerOwner(projectile), "Toxic Solutions"))
		{
			((Component)projectile).GetComponent<GoopModifier>().goopDefinition = EasyGoopDefinitions.PlayerFriendlyPoisonGoop;
			((Component)projectile).GetComponent<BeamBulletsBehaviour>().beamToFire = highPressurePoison;
			projectile.AdjustPlayerProjectileTint(ExtendedColours.poisonGreen, 1, 0f);
		}
		((AdvancedGunBehavior)this).PostProcessProjectile(projectile);
	}
}
