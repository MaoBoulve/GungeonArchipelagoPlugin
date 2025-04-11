using System.Collections.Generic;
using Alexandria.Assetbundle;
using Alexandria.ItemAPI;
using Gungeon;
using SaveAPI;
using UnityEngine;

namespace NevernamedsItems;

public class Redhawk : GunBehaviour
{
	public static int ID;

	public static void Add()
	{
		//IL_00dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_012e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0147: Unknown result type (might be due to invalid IL or missing references)
		//IL_0153: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_031b: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Redhawk", "redhawk");
		Game.Items.Rename("outdated_gun_mods:redhawk", "nn:redhawk");
		((Component)val).gameObject.AddComponent<Redhawk>();
		GunExt.SetShortDescription((PickupObject)(object)val, "Rugged");
		GunExt.SetLongDescription((PickupObject)(object)val, "An ancient masterwork, rumoured to be an unreleased Edwin classical original.\n\nThe Redhawk's bullets seem to rip and rend the exact right strands of sinew and muscle to cripple any foe.");
		GunInt.SetupSprite(val, Initialisation.gunCollection, "redhawk_idle_001", 8, "redhawk_ammonomicon_001");
		GunExt.SetAnimationFPS(val, val.shootAnimation, 15);
		GunExt.SetAnimationFPS(val, val.reloadAnimation, 0);
		PickupObject byId = PickupObjectDatabase.GetById(56);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId is Gun) ? byId : null), true, false);
		ref string gunSwitchGroup = ref val.gunSwitchGroup;
		PickupObject byId2 = PickupObjectDatabase.GetById(198);
		gunSwitchGroup = ((Gun)((byId2 is Gun) ? byId2 : null)).gunSwitchGroup;
		ref VFXPool muzzleFlashEffects = ref val.muzzleFlashEffects;
		PickupObject byId3 = PickupObjectDatabase.GetById(58);
		muzzleFlashEffects = ((Gun)((byId3 is Gun) ? byId3 : null)).muzzleFlashEffects;
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.shootStyle = (ShootStyle)0;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 1f;
		val.DefaultModule.cooldownTime = 0.2f;
		val.DefaultModule.numberOfShotsInClip = 6;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(1.625f, 0.6875f, 0f);
		val.SetBaseMaxAmmo(200);
		val.gunClass = (GunClass)1;
		val.DefaultModule.ammoType = (AmmoType)6;
		Projectile val2 = Object.Instantiate<Projectile>(val.DefaultModule.projectiles[0]);
		((Component)val2).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val2).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val2);
		val.DefaultModule.projectiles[0] = val2;
		val2.baseData.damage = 8f;
		val2.baseData.force = 4f;
		val2.baseData.speed = 45f;
		ref ProjectileImpactVFXPool hitEffects = ref val2.hitEffects;
		PickupObject byId4 = PickupObjectDatabase.GetById(32);
		hitEffects = ((Gun)((byId4 is Gun) ? byId4 : null)).DefaultModule.projectiles[0].hitEffects;
		val2.SetProjectileSprite("laserwelder_proj", 10, 3, lightened: true, (Anchor)4, 10, 3, anchorChangesCollider: true, fixesScale: false, null, null);
		val2.hitEffects.CenterDeathVFXOnProjectile = true;
		ProjWeaknessModifier projWeaknessModifier = ((Component)val2).gameObject.AddComponent<ProjWeaknessModifier>();
		projWeaknessModifier.chanceToApply = 0.33f;
		List<string> list = new List<string> { "NevernamedsItems/Resources/TrailSprites/laserwelder_trail_001", "NevernamedsItems/Resources/TrailSprites/laserwelder_trail_002", "NevernamedsItems/Resources/TrailSprites/laserwelder_trail_003", "NevernamedsItems/Resources/TrailSprites/laserwelder_trail_004", "NevernamedsItems/Resources/TrailSprites/laserwelder_trail_005" };
		List<string> list2 = new List<string> { "NevernamedsItems/Resources/TrailSprites/laserwelder_trailstart_001", "NevernamedsItems/Resources/TrailSprites/laserwelder_trailstart_002", "NevernamedsItems/Resources/TrailSprites/laserwelder_trailstart_003", "NevernamedsItems/Resources/TrailSprites/laserwelder_trailstart_004", "NevernamedsItems/Resources/TrailSprites/laserwelder_trailstart_005" };
		TrailAPI.AddTrailToProjectile(val2, "NevernamedsItems/Resources/TrailSprites/laserwelder_trail_001", new Vector2(17f, 5f), new Vector2(0f, 6f), list, 20, list2, 20, 0.1f, -1f, -1f, true, true);
		((PickupObject)val).quality = (ItemQuality)4;
		Databases.Items.Add((PickupObject)(object)val, false, "ANY");
		ID = ((PickupObject)val).PickupObjectId;
		((PickupObject)(object)val).SetupUnlockOnCustomFlag(CustomDungeonFlags.ADVDRAGUN_KILLED_SHADE, requiredFlagValue: true);
	}
}
