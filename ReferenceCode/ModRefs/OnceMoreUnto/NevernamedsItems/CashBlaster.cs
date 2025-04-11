using System.Collections.Generic;
using Alexandria.BreakableAPI;
using Alexandria.ItemAPI;
using Alexandria.Misc;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class CashBlaster : AdvancedGunBehavior
{
	public static int ID;

	public static void Add()
	{
		//IL_010f: Unknown result type (might be due to invalid IL or missing references)
		//IL_011b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0172: Unknown result type (might be due to invalid IL or missing references)
		//IL_018c: Unknown result type (might be due to invalid IL or missing references)
		//IL_024e: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_02fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0301: Unknown result type (might be due to invalid IL or missing references)
		//IL_0308: Unknown result type (might be due to invalid IL or missing references)
		//IL_030f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0316: Unknown result type (might be due to invalid IL or missing references)
		//IL_031e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0325: Unknown result type (might be due to invalid IL or missing references)
		//IL_032c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0333: Unknown result type (might be due to invalid IL or missing references)
		//IL_033a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0341: Unknown result type (might be due to invalid IL or missing references)
		//IL_034d: Expected O, but got Unknown
		//IL_0355: Unknown result type (might be due to invalid IL or missing references)
		//IL_037b: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Cash Blaster", "cashblaster");
		Game.Items.Rename("outdated_gun_mods:cash_blaster", "nn:cash_blaster");
		CashBlaster cashBlaster = ((Component)val).gameObject.AddComponent<CashBlaster>();
		((AdvancedGunBehavior)cashBlaster).preventNormalFireAudio = true;
		((AdvancedGunBehavior)cashBlaster).preventNormalReloadAudio = true;
		GunExt.SetShortDescription((PickupObject)(object)val, "Money Guney");
		GunExt.SetLongDescription((PickupObject)(object)val, "A tacky device designed to fire paper currency.\n\nUnfortunately, paper currency is not legal tender in the Gungeon.");
		val.SetGunSprites("cashblaster");
		GunExt.SetAnimationFPS(val, val.shootAnimation, 12);
		GunExt.SetAnimationFPS(val, val.reloadAnimation, 0);
		PickupObject byId = PickupObjectDatabase.GetById(86);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId is Gun) ? byId : null), true, false);
		val.doesScreenShake = false;
		ref VFXPool muzzleFlashEffects = ref val.muzzleFlashEffects;
		PickupObject byId2 = PickupObjectDatabase.GetById(12);
		muzzleFlashEffects = ((Gun)((byId2 is Gun) ? byId2 : null)).muzzleFlashEffects;
		((Component)val).GetComponent<tk2dSpriteAnimator>().GetClipByName(val.shootAnimation).frames[0].eventAudio = "Play_OBJ_book_drop_01";
		((Component)val).GetComponent<tk2dSpriteAnimator>().GetClipByName(val.shootAnimation).frames[0].triggerEvent = true;
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.shootStyle = (ShootStyle)1;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 0.9f;
		val.DefaultModule.angleVariance = 12f;
		val.DefaultModule.cooldownTime = 0.1f;
		val.DefaultModule.numberOfShotsInClip = 20;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(0.875f, 0.5625f, 0f);
		val.SetBaseMaxAmmo(300);
		val.gunClass = (GunClass)10;
		Projectile val2 = ProjectileUtility.InstantiateAndFakeprefab(val.DefaultModule.projectiles[0]);
		val.DefaultModule.projectiles[0] = val2;
		val2.baseData.damage = 4f;
		val2.EasyAnimate(new List<string> { "cashproj_001", "cashproj_002", "cashproj_003", "cashproj_004", "cashproj_005", "cashproj_006", "cashproj_007", "cashproj_008", "cashproj_009", "cashproj_010" }, 10, new IntVector2(12, 8), 7, light: false, (WrapMode)0);
		SlowDownOverTimeModifier slowDownOverTimeModifier = ((Component)val2).gameObject.AddComponent<SlowDownOverTimeModifier>();
		slowDownOverTimeModifier.extendTimeByRangeStat = true;
		slowDownOverTimeModifier.activateDriftAfterstop = true;
		slowDownOverTimeModifier.doRandomTimeMultiplier = true;
		slowDownOverTimeModifier.killAfterCompleteStop = true;
		slowDownOverTimeModifier.timeTillKillAfterCompleteStop = 1f;
		slowDownOverTimeModifier.timeToSlowOver = 0.5f;
		slowDownOverTimeModifier.targetSpeed = val2.baseData.speed * 0.1f;
		DriftModifier driftModifier = ((Component)val2).gameObject.AddComponent<DriftModifier>();
		GameObject gameObject = ((Component)BreakableAPIToolbox.GenerateDebrisObject("NevernamedsItems/Resources/Debris/cashdebris.png", true, 1f, 1f, 0f, 0f, (tk2dSprite)null, 1f, (string)null, (GameObject)null, 0, false, (GoopDefinition)null, 1f)).gameObject;
		val2.hitEffects = new ProjectileImpactVFXPool
		{
			suppressHitEffectsIfOffscreen = false,
			suppressMidairDeathVfx = false,
			overrideMidairZHeight = -1,
			overrideEarlyDeathVfx = null,
			overrideMidairDeathVFX = gameObject,
			midairInheritsVelocity = true,
			midairInheritsFlip = true,
			midairInheritsRotation = true,
			alwaysUseMidair = true,
			CenterDeathVFXOnProjectile = false,
			HasProjectileDeathVFX = false
		};
		val.DefaultModule.ammoType = (AmmoType)14;
		val.DefaultModule.customAmmoType = CustomClipAmmoTypeToolbox.AddCustomAmmoType("Cashblaster Bullets", "NevernamedsItems/Resources/CustomGunAmmoTypes/cashblaster_clipfull", "NevernamedsItems/Resources/CustomGunAmmoTypes/cashblaster_clipempty");
		((PickupObject)val).quality = (ItemQuality)2;
		Databases.Items.Add((PickupObject)(object)val, false, "ANY");
		ID = ((PickupObject)val).PickupObjectId;
	}
}
