using System.Collections.Generic;
using Alexandria.ItemAPI;
using Alexandria.Misc;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class LtBluesPhaser : GunBehaviour
{
	public static int ID;

	public static void Add()
	{
		//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0141: Unknown result type (might be due to invalid IL or missing references)
		//IL_015b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0243: Unknown result type (might be due to invalid IL or missing references)
		//IL_0252: Unknown result type (might be due to invalid IL or missing references)
		//IL_027c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0293: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Lt. Blues Phaser", "ltbluesphaser");
		Game.Items.Rename("outdated_gun_mods:lt_blues_phaser", "nn:lt_blues_phaser");
		((Component)val).gameObject.AddComponent<LtBluesPhaser>();
		GunExt.SetShortDescription((PickupObject)(object)val, "<><>");
		GunExt.SetLongDescription((PickupObject)(object)val, "The plasma blaster of a Colorscant lieutenant whose platoon was stranded within the Gungeon in a bygone age.");
		val.SetGunSprites("ltbluesphaser");
		GunExt.SetAnimationFPS(val, val.shootAnimation, 15);
		PickupObject byId = PickupObjectDatabase.GetById(56);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId is Gun) ? byId : null), true, false);
		ref string gunSwitchGroup = ref val.gunSwitchGroup;
		PickupObject byId2 = PickupObjectDatabase.GetById(59);
		gunSwitchGroup = ((Gun)((byId2 is Gun) ? byId2 : null)).gunSwitchGroup;
		ref VFXPool muzzleFlashEffects = ref val.muzzleFlashEffects;
		PickupObject byId3 = PickupObjectDatabase.GetById(59);
		muzzleFlashEffects = ((Gun)((byId3 is Gun) ? byId3 : null)).muzzleFlashEffects;
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.shootStyle = (ShootStyle)4;
		val.DefaultModule.burstCooldownTime = 0.1f;
		val.DefaultModule.burstShotCount = 4;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 1f;
		val.DefaultModule.cooldownTime = 0.25f;
		val.DefaultModule.numberOfShotsInClip = 8;
		val.DefaultModule.angleVariance = 10f;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(1.4375f, 0.375f, 0f);
		val.SetBaseMaxAmmo(400);
		val.gunClass = (GunClass)10;
		Projectile val2 = ProjectileUtility.InstantiateAndFakeprefab(val.DefaultModule.projectiles[0]);
		val.DefaultModule.projectiles[0] = val2;
		ProjectileData baseData = val2.baseData;
		baseData.speed *= 0.5f;
		val2.baseData.damage = 6.5f;
		((BraveBehaviour)((BraveBehaviour)val2).sprite).renderer.enabled = false;
		SquareMotionHandler squareMotionHandler = ((Component)val2).gameObject.AddComponent<SquareMotionHandler>();
		squareMotionHandler.angleChange = 45f;
		squareMotionHandler.randomiseStart = true;
		((Component)val2).gameObject.AddComponent<PierceProjModifier>();
		val2.hitEffects.overrideMidairDeathVFX = SharedVFX.BlueLaserCircleVFX;
		val2.hitEffects.alwaysUseMidair = true;
		List<string> list = new List<string> { "NevernamedsItems/Resources/TrailSprites/smallbluetrail_001", "NevernamedsItems/Resources/TrailSprites/smallbluetrail_002", "NevernamedsItems/Resources/TrailSprites/smallbluetrail_003" };
		TrailAPI.AddTrailToProjectile(val2, "NevernamedsItems/Resources/TrailSprites/smallbluetrail_001", new Vector2(3f, 2f), new Vector2(1f, 1f), list, 20, list, 20, -1f, 0.0001f, -1f, true, true);
		val.DefaultModule.ammoType = (AmmoType)14;
		val.DefaultModule.customAmmoType = "pulse blue";
		((PickupObject)val).quality = (ItemQuality)2;
		Databases.Items.Add((PickupObject)(object)val, false, "ANY");
		ID = ((PickupObject)val).PickupObjectId;
	}
}
