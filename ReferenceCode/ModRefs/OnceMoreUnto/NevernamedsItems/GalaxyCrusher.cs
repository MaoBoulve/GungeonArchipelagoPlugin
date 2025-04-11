using System.Collections.Generic;
using Alexandria.ItemAPI;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class GalaxyCrusher : AdvancedGunBehavior
{
	public static int ID;

	public static void Add()
	{
		//IL_01e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_0235: Unknown result type (might be due to invalid IL or missing references)
		//IL_024c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0263: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_03bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_03fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0432: Unknown result type (might be due to invalid IL or missing references)
		//IL_0458: Unknown result type (might be due to invalid IL or missing references)
		//IL_045d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0464: Unknown result type (might be due to invalid IL or missing references)
		//IL_0471: Expected O, but got Unknown
		//IL_0492: Unknown result type (might be due to invalid IL or missing references)
		//IL_04a9: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Galaxy Crusher", "galaxycrusher");
		Game.Items.Rename("outdated_gun_mods:galaxy_crusher", "nn:galaxy_crusher");
		GalaxyCrusher galaxyCrusher = ((Component)val).gameObject.AddComponent<GalaxyCrusher>();
		((AdvancedGunBehavior)galaxyCrusher).preventNormalReloadAudio = true;
		((AdvancedGunBehavior)galaxyCrusher).overrideNormalReloadAudio = "Play_ENV_water_splash_01";
		GunExt.SetShortDescription((PickupObject)(object)val, "Cosmic Crunch");
		GunExt.SetLongDescription((PickupObject)(object)val, "Tears apart the fabric of space time and good game design, allowing for ridiculous gun effects and fourth wall breaking Ammonomicon descriptions.");
		val.SetGunSprites("galaxycrusher");
		GunExt.SetAnimationFPS(val, val.chargeAnimation, 13);
		GunExt.SetAnimationFPS(val, val.shootAnimation, 12);
		GunExt.SetAnimationFPS(val, val.reloadAnimation, 9);
		PickupObject byId = PickupObjectDatabase.GetById(86);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId is Gun) ? byId : null), true, false);
		((Component)val).GetComponent<tk2dSpriteAnimator>().GetClipByName(val.shootAnimation).frames[0].eventAudio = "Play_WPN_blackhole_shot_01";
		((Component)val).GetComponent<tk2dSpriteAnimator>().GetClipByName(val.shootAnimation).frames[0].triggerEvent = true;
		((Component)val).GetComponent<tk2dSpriteAnimator>().GetClipByName(val.chargeAnimation).frames[0].eventAudio = "Play_WPN_blackhole_charge_01";
		((Component)val).GetComponent<tk2dSpriteAnimator>().GetClipByName(val.chargeAnimation).frames[0].triggerEvent = true;
		((Component)val).GetComponent<tk2dSpriteAnimator>().GetClipByName(val.chargeAnimation).frames[22].eventAudio = "Play_WPN_stdissuelaser_shot_01";
		((Component)val).GetComponent<tk2dSpriteAnimator>().GetClipByName(val.chargeAnimation).frames[22].triggerEvent = true;
		((Component)val).GetComponent<tk2dSpriteAnimator>().GetClipByName(val.chargeAnimation).frames[24].eventAudio = "Play_WPN_stdissuelaser_shot_01";
		((Component)val).GetComponent<tk2dSpriteAnimator>().GetClipByName(val.chargeAnimation).frames[24].triggerEvent = true;
		ref VFXPool muzzleFlashEffects = ref val.muzzleFlashEffects;
		PickupObject byId2 = PickupObjectDatabase.GetById(228);
		muzzleFlashEffects = ((Gun)((byId2 is Gun) ? byId2 : null)).muzzleFlashEffects;
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.shootStyle = (ShootStyle)3;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 2f;
		val.DefaultModule.cooldownTime = 0.5f;
		val.DefaultModule.numberOfShotsInClip = 1;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(4.18f, 1.56f, 0f);
		val.SetBaseMaxAmmo(10);
		val.gunClass = (GunClass)60;
		((Component)val).GetComponent<tk2dSpriteAnimator>().GetClipByName(val.chargeAnimation).wrapMode = (WrapMode)1;
		((Component)val).GetComponent<tk2dSpriteAnimator>().GetClipByName(val.chargeAnimation).loopStart = 21;
		PickupObject byId3 = PickupObjectDatabase.GetById(169);
		Projectile val2 = Object.Instantiate<Projectile>(((Gun)((byId3 is Gun) ? byId3 : null)).DefaultModule.projectiles[0]);
		((Component)val2).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val2).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val2);
		val.DefaultModule.projectiles[0] = val2;
		val2.baseData.damage = 20f;
		ProjectileData baseData = val2.baseData;
		baseData.speed *= 10f;
		val2.AdditionalScaleMultiplier = 2f;
		PickupObject byId4 = PickupObjectDatabase.GetById(169);
		Projectile val3 = Object.Instantiate<Projectile>(((Gun)((byId4 is Gun) ? byId4 : null)).DefaultModule.projectiles[0]);
		((Component)val3).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val3).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val3);
		val.DefaultModule.projectiles[0] = val3;
		val3.baseData.damage = 5f;
		val3.baseData.speed = 5f;
		val3.AdditionalScaleMultiplier = 0.9f;
		BounceProjModifier val4 = ((Component)val3).gameObject.AddComponent<BounceProjModifier>();
		val4.numberOfBounces = 1;
		EasyTrailBullet easyTrailBullet = ((Component)val3).gameObject.AddComponent<EasyTrailBullet>();
		easyTrailBullet.TrailPos = Vector2.op_Implicit(((BraveBehaviour)val3).transform.position);
		easyTrailBullet.StartWidth = 1.56f;
		easyTrailBullet.EndWidth = 0f;
		easyTrailBullet.LifeTime = 1.5f;
		easyTrailBullet.BaseColor = Color.black;
		easyTrailBullet.EndColor = Color.black;
		SpawnProjModifier val5 = ((Component)val2).gameObject.AddComponent<SpawnProjModifier>();
		val5.spawnProjecitlesOnDieInAir = true;
		val5.spawnProjectilesOnCollision = true;
		val5.spawnProjectilesInFlight = false;
		val5.spawnOnObjectCollisions = true;
		val5.collisionSpawnStyle = (CollisionSpawnStyle)0;
		val5.numberToSpawnOnCollison = 30;
		val5.PostprocessSpawnedProjectiles = true;
		val5.projectileToSpawnOnCollision = val3;
		val5.spawnCollisionProjectilesOnBounce = false;
		ChargeProjectile item = new ChargeProjectile
		{
			Projectile = val2,
			ChargeTime = 2f
		};
		val.DefaultModule.chargeProjectiles = new List<ChargeProjectile> { item };
		val.DefaultModule.ammoType = (AmmoType)14;
		val.DefaultModule.customAmmoType = "black_hole";
		((PickupObject)val).quality = (ItemQuality)5;
		Databases.Items.Add((PickupObject)(object)val, false, "ANY");
		ID = ((PickupObject)val).PickupObjectId;
	}
}
