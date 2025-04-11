using System.Collections.Generic;
using Alexandria.ItemAPI;
using Alexandria.Misc;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class SquareBracket : GunBehaviour
{
	public static int ID;

	public static void Add()
	{
		//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_0115: Unknown result type (might be due to invalid IL or missing references)
		//IL_012e: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0207: Unknown result type (might be due to invalid IL or missing references)
		//IL_0231: Unknown result type (might be due to invalid IL or missing references)
		//IL_0248: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Square Bracket", "squarebracket");
		Game.Items.Rename("outdated_gun_mods:square_bracket", "nn:square_bracket");
		((Component)val).gameObject.AddComponent<SquareBracket>();
		GunExt.SetShortDescription((PickupObject)(object)val, "Brace For Impact");
		GunExt.SetLongDescription((PickupObject)(object)val, "Fires square wave energy beams.\n\nA remnant of an ancient cult of technomages, versed in the dark arts of vector rotation.");
		val.SetGunSprites("squarebracket");
		GunExt.SetAnimationFPS(val, val.shootAnimation, 15);
		PickupObject byId = PickupObjectDatabase.GetById(56);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId is Gun) ? byId : null), true, false);
		ref string gunSwitchGroup = ref val.gunSwitchGroup;
		PickupObject byId2 = PickupObjectDatabase.GetById(89);
		gunSwitchGroup = ((Gun)((byId2 is Gun) ? byId2 : null)).gunSwitchGroup;
		ref VFXPool muzzleFlashEffects = ref val.muzzleFlashEffects;
		PickupObject byId3 = PickupObjectDatabase.GetById(89);
		muzzleFlashEffects = ((Gun)((byId3 is Gun) ? byId3 : null)).muzzleFlashEffects;
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.shootStyle = (ShootStyle)1;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 0.8f;
		val.DefaultModule.cooldownTime = 0.1f;
		val.DefaultModule.numberOfShotsInClip = 5;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(1.4375f, 0.6875f, 0f);
		val.SetBaseMaxAmmo(400);
		val.gunClass = (GunClass)1;
		Projectile val2 = ProjectileUtility.InstantiateAndFakeprefab(val.DefaultModule.projectiles[0]);
		val.DefaultModule.projectiles[0] = val2;
		ProjectileData baseData = val2.baseData;
		baseData.speed *= 2f;
		val2.baseData.damage = 7f;
		((BraveBehaviour)((BraveBehaviour)val2).sprite).renderer.enabled = false;
		((Component)val2).gameObject.AddComponent<SquareMotionHandler>();
		val2.hitEffects.overrideMidairDeathVFX = SharedVFX.GreenLaserCircleVFX;
		val2.hitEffects.alwaysUseMidair = true;
		List<string> list = new List<string> { "NevernamedsItems/Resources/TrailSprites/smallgreentrail_001", "NevernamedsItems/Resources/TrailSprites/smallgreentrail_002", "NevernamedsItems/Resources/TrailSprites/smallgreentrail_003" };
		TrailAPI.AddTrailToProjectile(val2, "NevernamedsItems/Resources/TrailSprites/smallgreentrail_001", new Vector2(3f, 2f), new Vector2(1f, 1f), list, 20, list, 20, -1f, 0.0001f, -1f, true, true);
		val.DefaultModule.ammoType = (AmmoType)14;
		val.DefaultModule.customAmmoType = "green blaster";
		((PickupObject)val).quality = (ItemQuality)2;
		Databases.Items.Add((PickupObject)(object)val, false, "ANY");
		ID = ((PickupObject)val).PickupObjectId;
	}
}
