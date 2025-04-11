using System.Collections.Generic;
using Alexandria.ItemAPI;
using Alexandria.Misc;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class WaveformLens : GunBehaviour
{
	public static int ID;

	public static void Add()
	{
		//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_013b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0153: Unknown result type (might be due to invalid IL or missing references)
		//IL_015f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0204: Unknown result type (might be due to invalid IL or missing references)
		//IL_0220: Unknown result type (might be due to invalid IL or missing references)
		//IL_0233: Unknown result type (might be due to invalid IL or missing references)
		//IL_0238: Unknown result type (might be due to invalid IL or missing references)
		//IL_024b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0252: Unknown result type (might be due to invalid IL or missing references)
		//IL_0259: Unknown result type (might be due to invalid IL or missing references)
		//IL_0264: Unknown result type (might be due to invalid IL or missing references)
		//IL_026f: Unknown result type (might be due to invalid IL or missing references)
		//IL_027a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0286: Expected O, but got Unknown
		//IL_0298: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_044d: Unknown result type (might be due to invalid IL or missing references)
		//IL_045c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0482: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Waveform Lens", "waveformlens");
		Game.Items.Rename("outdated_gun_mods:waveform_lens", "nn:waveform_lens");
		((Component)val).gameObject.AddComponent<WaveformLens>();
		GunExt.SetShortDescription((PickupObject)(object)val, "No Man's Gun");
		GunExt.SetLongDescription((PickupObject)(object)val, "A scientific waveform multitool designed for deep space exploration.\n\nInitial releases of the technology were highly flawed, but years of R&D have managed to develop the device into something resembling a useful tool.");
		val.SetGunSprites("waveformlens");
		GunExt.SetAnimationFPS(val, val.shootAnimation, 15);
		GunExt.SetAnimationFPS(val, val.alternateShootAnimation, 15);
		GunExt.SetAnimationFPS(val, val.reloadAnimation, 5);
		GunExt.SetAnimationFPS(val, val.alternateReloadAnimation, 5);
		PickupObject byId = PickupObjectDatabase.GetById(86);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId is Gun) ? byId : null), true, false);
		ref string gunSwitchGroup = ref val.gunSwitchGroup;
		PickupObject byId2 = PickupObjectDatabase.GetById(32);
		gunSwitchGroup = ((Gun)((byId2 is Gun) ? byId2 : null)).gunSwitchGroup;
		ref string alternateSwitchGroup = ref val.alternateSwitchGroup;
		PickupObject byId3 = PickupObjectDatabase.GetById(383);
		alternateSwitchGroup = ((Gun)((byId3 is Gun) ? byId3 : null)).gunSwitchGroup;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(1f, 0.75f, 0f);
		ref VFXPool muzzleFlashEffects = ref val.muzzleFlashEffects;
		PickupObject byId4 = PickupObjectDatabase.GetById(59);
		muzzleFlashEffects = ((Gun)((byId4 is Gun) ? byId4 : null)).muzzleFlashEffects;
		val.IsTrickGun = true;
		val.reloadTime = 1f;
		val.SetBaseMaxAmmo(300);
		val.gunClass = (GunClass)10;
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.shootStyle = (ShootStyle)1;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.DefaultModule.cooldownTime = 0.1f;
		val.DefaultModule.numberOfShotsInClip = 10;
		Projectile val2 = ProjectileUtility.SetupProjectile(86);
		val.DefaultModule.projectiles[0] = val2;
		val2.baseData.damage = 5f;
		val2.SetProjectileSprite("waveformlens_proj", 5, 5, lightened: false, (Anchor)4, 4, 4, anchorChangesCollider: true, fixesScale: false, null, null);
		val2.hitEffects.overrideMidairDeathVFX = SharedVFX.SmoothLightBlueLaserCircleVFX;
		val2.hitEffects.alwaysUseMidair = true;
		val.DefaultModule.ammoType = (AmmoType)14;
		val.DefaultModule.customAmmoType = "evo3";
		ProjectileModule val3 = ProjectileModule.CreateClone(((Gun)PickupObjectDatabase.GetById(56)).DefaultModule, false, -1);
		val.alternateVolley = new ProjectileVolleyData
		{
			projectiles = new List<ProjectileModule> { val3 },
			UsesShotgunStyleVelocityRandomizer = false,
			ModulesAreTiers = false,
			BeamRotationDegreesPerSecond = 30f,
			DecreaseFinalSpeedPercentMin = -5f,
			IncreaseFinalSpeedPercentMax = 5f,
			UsesBeamRotationLimiter = false
		};
		val.alternateVolley.projectiles[0].ammoType = (AmmoType)6;
		val.alternateVolley.projectiles[0].ammoCost = 1;
		val.alternateVolley.projectiles[0].shootStyle = (ShootStyle)0;
		val.alternateVolley.projectiles[0].cooldownTime = 0.5f;
		val.alternateVolley.projectiles[0].numberOfShotsInClip = 5;
		val.alternateVolley.projectiles[0].angleVariance = 0f;
		Projectile val4 = ProjectileUtility.SetupProjectile(56);
		val3.projectiles[0] = val4;
		ref ProjectileImpactVFXPool hitEffects = ref val4.hitEffects;
		PickupObject byId5 = PickupObjectDatabase.GetById(32);
		hitEffects = ((Gun)((byId5 is Gun) ? byId5 : null)).DefaultModule.projectiles[0].hitEffects;
		val4.baseData.damage = 10f;
		val4.baseData.speed = 600f;
		val4.SetProjectileSprite("laserwelder_proj", 10, 3, lightened: true, (Anchor)4, 10, 3, anchorChangesCollider: true, fixesScale: false, null, null);
		val4.hitEffects.CenterDeathVFXOnProjectile = true;
		List<string> list = new List<string> { "NevernamedsItems/Resources/TrailSprites/laserwelder_trail_001", "NevernamedsItems/Resources/TrailSprites/laserwelder_trail_002", "NevernamedsItems/Resources/TrailSprites/laserwelder_trail_003", "NevernamedsItems/Resources/TrailSprites/laserwelder_trail_004", "NevernamedsItems/Resources/TrailSprites/laserwelder_trail_005" };
		List<string> list2 = new List<string> { "NevernamedsItems/Resources/TrailSprites/laserwelder_trailstart_001", "NevernamedsItems/Resources/TrailSprites/laserwelder_trailstart_002", "NevernamedsItems/Resources/TrailSprites/laserwelder_trailstart_003", "NevernamedsItems/Resources/TrailSprites/laserwelder_trailstart_004", "NevernamedsItems/Resources/TrailSprites/laserwelder_trailstart_005" };
		TrailAPI.AddTrailToProjectile(val4, "NevernamedsItems/Resources/TrailSprites/laserwelder_trail_001", new Vector2(17f, 5f), new Vector2(0f, 6f), list, 20, list2, 20, 0.1f, -1f, -1f, true, true);
		((PickupObject)val).quality = (ItemQuality)2;
		Databases.Items.Add((PickupObject)(object)val, false, "ANY");
		ID = ((PickupObject)val).PickupObjectId;
	}
}
