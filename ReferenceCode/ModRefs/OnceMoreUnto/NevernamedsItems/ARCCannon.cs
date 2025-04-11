using System.Collections.Generic;
using Alexandria.ItemAPI;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class ARCCannon : GunBehaviour
{
	public static int ID;

	public static void Add()
	{
		//IL_00da: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_012c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0143: Unknown result type (might be due to invalid IL or missing references)
		//IL_0150: Unknown result type (might be due to invalid IL or missing references)
		//IL_0211: Unknown result type (might be due to invalid IL or missing references)
		//IL_0220: Unknown result type (might be due to invalid IL or missing references)
		//IL_0251: Unknown result type (might be due to invalid IL or missing references)
		//IL_0256: Unknown result type (might be due to invalid IL or missing references)
		//IL_025d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0268: Unknown result type (might be due to invalid IL or missing references)
		//IL_026f: Unknown result type (might be due to invalid IL or missing references)
		//IL_027a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0285: Unknown result type (might be due to invalid IL or missing references)
		//IL_0290: Unknown result type (might be due to invalid IL or missing references)
		//IL_029b: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_02be: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ce: Expected O, but got Unknown
		//IL_03b8: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("ARC Cannon", "arccannon");
		Game.Items.Rename("outdated_gun_mods:arc_cannon", "nn:arc_cannon");
		((Component)val).gameObject.AddComponent<ARCCannon>();
		GunExt.SetShortDescription((PickupObject)(object)val, "All Lightning");
		GunExt.SetLongDescription((PickupObject)(object)val, "The ARC Cannon was commissioned from the ARC Private Security Company by the Sultan of a distant planet, who now spends his free time striking ships from the sky and declaring himself a god.");
		val.SetGunSprites("arccannon");
		GunExt.SetAnimationFPS(val, val.shootAnimation, 15);
		GunExt.SetAnimationFPS(val, val.reloadAnimation, 0);
		PickupObject byId = PickupObjectDatabase.GetById(ARCPistol.ID);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId is Gun) ? byId : null), true, false);
		ref string gunSwitchGroup = ref val.gunSwitchGroup;
		PickupObject byId2 = PickupObjectDatabase.GetById(153);
		gunSwitchGroup = ((Gun)((byId2 is Gun) ? byId2 : null)).gunSwitchGroup;
		ref VFXPool muzzleFlashEffects = ref val.muzzleFlashEffects;
		PickupObject byId3 = PickupObjectDatabase.GetById(228);
		muzzleFlashEffects = ((Gun)((byId3 is Gun) ? byId3 : null)).muzzleFlashEffects;
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.shootStyle = (ShootStyle)0;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 3f;
		val.DefaultModule.cooldownTime = 1f;
		val.DefaultModule.numberOfShotsInClip = 1;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(2.8125f, 1f, 0f);
		val.SetBaseMaxAmmo(40);
		val.gunClass = (GunClass)15;
		val.DefaultModule.ammoType = (AmmoType)14;
		val.DefaultModule.customAmmoType = "ARC Bullets";
		Projectile val2 = Object.Instantiate<Projectile>(val.DefaultModule.projectiles[0]);
		((Component)val2).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val2).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val2);
		val.DefaultModule.projectiles[0] = val2;
		val2.baseData.damage = 20f;
		LightningProjectileComp component = ((Component)val2).gameObject.GetComponent<LightningProjectileComp>();
		Object.Destroy((Object)(object)((Component)val2).GetComponent<TrailController>());
		List<string> list = new List<string> { "NevernamedsItems/Resources/TrailSprites/bigarctrail_mid_001", "NevernamedsItems/Resources/TrailSprites/bigarctrail_mid_002", "NevernamedsItems/Resources/TrailSprites/bigarctrail_mid_003" };
		TrailAPI.AddTrailToProjectile(val2, "NevernamedsItems/Resources/TrailSprites/bigarctrail_mid_001", new Vector2(8f, 7f), new Vector2(1f, 1f), list, 20, list, 20, -1f, 0.0001f, -1f, true, true);
		ExplosiveModifier val3 = ((Component)val2).gameObject.AddComponent<ExplosiveModifier>();
		val3.explosionData = new ExplosionData
		{
			breakSecretWalls = false,
			effect = SharedVFX.ArcExplosion,
			doDamage = true,
			damageRadius = 3f,
			damageToPlayer = 0f,
			damage = 40f,
			debrisForce = 20f,
			doExplosionRing = true,
			doDestroyProjectiles = true,
			doForce = true,
			doScreenShake = true,
			playDefaultSFX = true,
			force = 20f
		};
		PickupObject byId4 = PickupObjectDatabase.GetById(ARCPistol.ID);
		Projectile val4 = Object.Instantiate<Projectile>(((Gun)((byId4 is Gun) ? byId4 : null)).DefaultModule.projectiles[0]);
		((Component)val4).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val4).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val4);
		val4.baseData.damage = 5f;
		LightningProjectileComp component2 = ((Component)val4).gameObject.GetComponent<LightningProjectileComp>();
		((Component)((BraveBehaviour)val4).projectile).gameObject.AddComponent<PierceProjModifier>();
		component2.targetEnemies = false;
		SpawnProjModifier val5 = ((Component)val2).gameObject.AddComponent<SpawnProjModifier>();
		val5.numberToSpawnOnCollison = 5;
		val5.numToSpawnInFlight = 0;
		val5.PostprocessSpawnedProjectiles = true;
		val5.projectileToSpawnOnCollision = val4;
		val5.randomRadialStartAngle = true;
		val5.spawnCollisionProjectilesOnBounce = true;
		val5.spawnOnObjectCollisions = true;
		val5.spawnProjecitlesOnDieInAir = true;
		val5.spawnProjectilesOnCollision = true;
		val5.spawnProjectilesInFlight = false;
		val5.alignToSurfaceNormal = true;
		((PickupObject)val).quality = (ItemQuality)4;
		Databases.Items.Add((PickupObject)(object)val, false, "ANY");
		ID = ((PickupObject)val).PickupObjectId;
	}
}
