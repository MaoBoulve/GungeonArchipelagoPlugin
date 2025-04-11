using System.Collections.Generic;
using Alexandria.BreakableAPI;
using Alexandria.ItemAPI;
using Alexandria.Misc;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class ConfettiCannon : AdvancedGunBehavior
{
	public static int ID;

	public static Projectile redConfetti;

	public static Projectile orangeConfetti;

	public static Projectile yellowConfetti;

	public static Projectile greenConfetti;

	public static Projectile blueConfetti;

	public static Projectile purpleConfetti;

	public static Projectile pinkConfetti;

	public static void Add()
	{
		//IL_00e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01db: Unknown result type (might be due to invalid IL or missing references)
		//IL_0151: Unknown result type (might be due to invalid IL or missing references)
		//IL_0159: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Confetti Cannon", "confetticannon");
		Game.Items.Rename("outdated_gun_mods:confetti_cannon", "nn:confetti_cannon");
		ConfettiCannon confettiCannon = ((Component)val).gameObject.AddComponent<ConfettiCannon>();
		((AdvancedGunBehavior)confettiCannon).preventNormalFireAudio = true;
		((AdvancedGunBehavior)confettiCannon).preventNormalReloadAudio = true;
		((AdvancedGunBehavior)confettiCannon).overrideNormalFireAudio = "Play_OBJ_chest_surprise_01";
		GunExt.SetShortDescription((PickupObject)(object)val, "Congratulations!");
		GunExt.SetLongDescription((PickupObject)(object)val, "A tube containing a small gunpowder charge and a collection of paper confetti.\n\nOften used to celebrate gundead birthdays, and by nature of the weapon, gundead funerals.");
		val.SetGunSprites("confetticannon");
		GunExt.SetAnimationFPS(val, val.shootAnimation, 12);
		GunExt.SetAnimationFPS(val, val.reloadAnimation, 0);
		for (int i = 0; i < 12; i++)
		{
			PickupObject byId = PickupObjectDatabase.GetById(86);
			GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId is Gun) ? byId : null), true, false);
		}
		val.doesScreenShake = false;
		val.reloadTime = 0.8f;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(1.5625f, 0.625f, 0f);
		val.SetBaseMaxAmmo(100);
		val.gunClass = (GunClass)5;
		ref VFXPool muzzleFlashEffects = ref val.muzzleFlashEffects;
		PickupObject byId2 = PickupObjectDatabase.GetById(12);
		muzzleFlashEffects = ((Gun)((byId2 is Gun) ? byId2 : null)).muzzleFlashEffects;
		foreach (ProjectileModule projectile in val.Volley.projectiles)
		{
			projectile.ammoCost = ((projectile == val.DefaultModule) ? 1 : 0);
			projectile.shootStyle = (ShootStyle)1;
			projectile.sequenceStyle = (ProjectileSequenceStyle)0;
			projectile.angleVariance = 12f;
			projectile.cooldownTime = 0.1f;
			projectile.numberOfShotsInClip = 1;
			SetUpModuleProjectiles(projectile);
		}
		val.Volley.UsesShotgunStyleVelocityRandomizer = true;
		val.DefaultModule.ammoType = (AmmoType)14;
		val.DefaultModule.customAmmoType = CustomClipAmmoTypeToolbox.AddCustomAmmoType("ConfettiCannon Ammo", "NevernamedsItems/Resources/CustomGunAmmoTypes/confetticannon_clipfull", "NevernamedsItems/Resources/CustomGunAmmoTypes/confetticannon_clipempty");
		((PickupObject)val).quality = (ItemQuality)1;
		Databases.Items.Add((PickupObject)(object)val, false, "ANY");
		ID = ((PickupObject)val).PickupObjectId;
	}

	private static void SetUpModuleProjectiles(ProjectileModule module)
	{
		if ((Object)(object)redConfetti == (Object)null)
		{
			redConfetti = madeindivproj("red");
			orangeConfetti = madeindivproj("orange");
			yellowConfetti = madeindivproj("yellow");
			greenConfetti = madeindivproj("green");
			blueConfetti = madeindivproj("blue");
			purpleConfetti = madeindivproj("purple");
			pinkConfetti = madeindivproj("pink");
		}
		module.projectiles[0] = redConfetti;
		module.projectiles.Add(orangeConfetti);
		module.projectiles.Add(yellowConfetti);
		module.projectiles.Add(greenConfetti);
		module.projectiles.Add(blueConfetti);
		module.projectiles.Add(purpleConfetti);
		module.projectiles.Add(pinkConfetti);
	}

	private static Projectile madeindivproj(string colour)
	{
		//IL_013b: Unknown result type (might be due to invalid IL or missing references)
		//IL_01eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0205: Unknown result type (might be due to invalid IL or missing references)
		//IL_020c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0213: Unknown result type (might be due to invalid IL or missing references)
		//IL_021a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0221: Unknown result type (might be due to invalid IL or missing references)
		//IL_0228: Unknown result type (might be due to invalid IL or missing references)
		//IL_022f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0236: Unknown result type (might be due to invalid IL or missing references)
		//IL_0242: Expected O, but got Unknown
		PickupObject byId = PickupObjectDatabase.GetById(86);
		Projectile val = ProjectileUtility.InstantiateAndFakeprefab(((Gun)((byId is Gun) ? byId : null)).DefaultModule.projectiles[0]);
		val.baseData.damage = 3.5f;
		ProjectileData baseData = val.baseData;
		baseData.force *= 0.1f;
		val.EasyAnimate(new List<string>
		{
			"confetti_" + colour + "_001",
			"confetti_" + colour + "_002",
			"confetti_" + colour + "_003",
			"confetti_" + colour + "_004",
			"confetti_" + colour + "_005",
			"confetti_" + colour + "_006",
			"confetti_" + colour + "_007",
			"confetti_" + colour + "_008",
			"confetti_" + colour + "_009",
			"confetti_" + colour + "_010"
		}, 10, new IntVector2(12, 8), 7, light: false, (WrapMode)0);
		SlowDownOverTimeModifier slowDownOverTimeModifier = ((Component)val).gameObject.AddComponent<SlowDownOverTimeModifier>();
		slowDownOverTimeModifier.extendTimeByRangeStat = true;
		slowDownOverTimeModifier.activateDriftAfterstop = true;
		slowDownOverTimeModifier.doRandomTimeMultiplier = true;
		slowDownOverTimeModifier.killAfterCompleteStop = true;
		slowDownOverTimeModifier.timeTillKillAfterCompleteStop = 1f;
		slowDownOverTimeModifier.timeToSlowOver = 0.5f;
		slowDownOverTimeModifier.targetSpeed = val.baseData.speed * 0.1f;
		DriftModifier driftModifier = ((Component)val).gameObject.AddComponent<DriftModifier>();
		GameObject gameObject = ((Component)BreakableAPIToolbox.GenerateDebrisObject("NevernamedsItems/Resources/Debris/confetti_debris_" + colour + ".png", true, 1f, 1f, 0f, 0f, (tk2dSprite)null, 1f, (string)null, (GameObject)null, 0, false, (GoopDefinition)null, 1f)).gameObject;
		val.hitEffects = new ProjectileImpactVFXPool
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
		return val;
	}
}
