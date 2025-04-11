using System.Collections.Generic;
using Alexandria.ItemAPI;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class LaserWelder : GunBehaviour
{
	public static ExplosionData LaserWelderExplosion;

	public static int ID;

	public static void Add()
	{
		//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0118: Unknown result type (might be due to invalid IL or missing references)
		//IL_0132: Unknown result type (might be due to invalid IL or missing references)
		//IL_013e: Unknown result type (might be due to invalid IL or missing references)
		//IL_02cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_02dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0300: Unknown result type (might be due to invalid IL or missing references)
		//IL_0322: Unknown result type (might be due to invalid IL or missing references)
		//IL_0327: Unknown result type (might be due to invalid IL or missing references)
		//IL_032e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0339: Unknown result type (might be due to invalid IL or missing references)
		//IL_0340: Unknown result type (might be due to invalid IL or missing references)
		//IL_034b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0356: Unknown result type (might be due to invalid IL or missing references)
		//IL_0361: Unknown result type (might be due to invalid IL or missing references)
		//IL_036c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0373: Unknown result type (might be due to invalid IL or missing references)
		//IL_037a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0381: Unknown result type (might be due to invalid IL or missing references)
		//IL_0388: Unknown result type (might be due to invalid IL or missing references)
		//IL_038f: Unknown result type (might be due to invalid IL or missing references)
		//IL_039a: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d4: Expected O, but got Unknown
		Gun val = Databases.Items.NewGun("Laser Welder", "laserwelder");
		Game.Items.Rename("outdated_gun_mods:laser_welder", "nn:laser_welder");
		((Component)val).gameObject.AddComponent<LaserWelder>();
		GunExt.SetShortDescription((PickupObject)(object)val, "Cleanup in Detail");
		GunExt.SetLongDescription((PickupObject)(object)val, "Blasts enemies apart in a burst of gruesome viscera... someone's gonna have to clean up that mess...\n\nAllows for the repair of objects.");
		val.SetGunSprites("laserwelder");
		GunExt.SetAnimationFPS(val, val.shootAnimation, 15);
		PickupObject byId = PickupObjectDatabase.GetById(86);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId is Gun) ? byId : null), true, false);
		ref string gunSwitchGroup = ref val.gunSwitchGroup;
		PickupObject byId2 = PickupObjectDatabase.GetById(153);
		gunSwitchGroup = ((Gun)((byId2 is Gun) ? byId2 : null)).gunSwitchGroup;
		ref VFXPool muzzleFlashEffects = ref val.muzzleFlashEffects;
		PickupObject byId3 = PickupObjectDatabase.GetById(58);
		muzzleFlashEffects = ((Gun)((byId3 is Gun) ? byId3 : null)).muzzleFlashEffects;
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.shootStyle = (ShootStyle)1;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 0.4f;
		val.DefaultModule.cooldownTime = 0.11f;
		val.DefaultModule.numberOfShotsInClip = 5;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(3.3125f, 0.6875f, 0f);
		val.SetBaseMaxAmmo(230);
		val.gunClass = (GunClass)45;
		val.DefaultModule.ammoType = (AmmoType)6;
		Projectile val2 = Object.Instantiate<Projectile>(val.DefaultModule.projectiles[0]);
		((Component)val2).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val2).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val2);
		val.DefaultModule.projectiles[0] = val2;
		val2.baseData.damage = 5f;
		val2.baseData.force = 4f;
		val2.baseData.speed = 600f;
		val2.AppliesFire = false;
		((Component)val2).gameObject.AddComponent<LaserWelderComp>();
		ref ProjectileImpactVFXPool hitEffects = ref val2.hitEffects;
		PickupObject byId4 = PickupObjectDatabase.GetById(32);
		hitEffects = ((Gun)((byId4 is Gun) ? byId4 : null)).DefaultModule.projectiles[0].hitEffects;
		val2.SetProjectileSprite("laserwelder_proj", 10, 3, lightened: true, (Anchor)4, 10, 3, anchorChangesCollider: true, fixesScale: false, null, null);
		val2.hitEffects.CenterDeathVFXOnProjectile = true;
		List<string> list = new List<string> { "NevernamedsItems/Resources/TrailSprites/laserwelder_trail_001", "NevernamedsItems/Resources/TrailSprites/laserwelder_trail_002", "NevernamedsItems/Resources/TrailSprites/laserwelder_trail_003", "NevernamedsItems/Resources/TrailSprites/laserwelder_trail_004", "NevernamedsItems/Resources/TrailSprites/laserwelder_trail_005" };
		List<string> list2 = new List<string> { "NevernamedsItems/Resources/TrailSprites/laserwelder_trailstart_001", "NevernamedsItems/Resources/TrailSprites/laserwelder_trailstart_002", "NevernamedsItems/Resources/TrailSprites/laserwelder_trailstart_003", "NevernamedsItems/Resources/TrailSprites/laserwelder_trailstart_004", "NevernamedsItems/Resources/TrailSprites/laserwelder_trailstart_005" };
		TrailAPI.AddTrailToProjectile(val2, "NevernamedsItems/Resources/TrailSprites/laserwelder_trail_001", new Vector2(17f, 5f), new Vector2(0f, 6f), list, 20, list2, 20, 0.1f, -1f, -1f, true, true);
		((PickupObject)val).quality = (ItemQuality)3;
		Databases.Items.Add((PickupObject)(object)val, false, "ANY");
		ID = ((PickupObject)val).PickupObjectId;
		LaserWelderExplosion = new ExplosionData
		{
			breakSecretWalls = false,
			effect = SharedVFX.BloodExplosion,
			doDamage = true,
			damageRadius = 2.5f,
			damageToPlayer = 0f,
			damage = 30f,
			debrisForce = 20f,
			doExplosionRing = true,
			doDestroyProjectiles = true,
			doForce = true,
			doScreenShake = true,
			playDefaultSFX = true,
			ignoreList = new List<SpeculativeRigidbody>(),
			pushRadius = 4f,
			ss = GameManager.Instance.Dungeon.sharedSettingsPrefab.DefaultSmallExplosionData.ss,
			force = 20f
		};
	}
}
