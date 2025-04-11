using Alexandria.Assetbundle;
using Alexandria.ItemAPI;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class Ulfberht : AdvancedGunBehavior
{
	public static int ID;

	public static void Add()
	{
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0107: Unknown result type (might be due to invalid IL or missing references)
		//IL_012b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0272: Unknown result type (might be due to invalid IL or missing references)
		//IL_02de: Unknown result type (might be due to invalid IL or missing references)
		//IL_0304: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Ulfberht", "ulfbehrt");
		Game.Items.Rename("outdated_gun_mods:ulfberht", "nn:ulfberht");
		Ulfberht ulfberht = ((Component)val).gameObject.AddComponent<Ulfberht>();
		GunExt.SetShortDescription((PickupObject)(object)val, "+VLFBEHT+");
		GunExt.SetLongDescription((PickupObject)(object)val, "Part of an ancient series of guns from a widespread and respected family of Gunsmiths, now lost to time.\n\nCrusty, rusty firearms such as this one are the only evidence of their existence...");
		GunInt.SetupSprite(val, Initialisation.gunCollection, "ulfbehrt_idle_001", 8, "ulfbehrt_ammonomicon_001");
		ref VFXPool muzzleFlashEffects = ref val.muzzleFlashEffects;
		PickupObject byId = PickupObjectDatabase.GetById(38);
		muzzleFlashEffects = ((Gun)((byId is Gun) ? byId : null)).muzzleFlashEffects;
		PickupObject byId2 = PickupObjectDatabase.GetById(56);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId2 is Gun) ? byId2 : null), true, false);
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.shootStyle = (ShootStyle)0;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 0.8f;
		val.DefaultModule.cooldownTime = 0.25f;
		val.DefaultModule.numberOfShotsInClip = 7;
		val.DefaultModule.angleVariance = 10f;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(1.5f, 0.8125f, 0f);
		val.SetBaseMaxAmmo(150);
		val.ammo = 150;
		val.gunClass = (GunClass)1;
		Projectile val2 = Object.Instantiate<Projectile>(val.DefaultModule.projectiles[0]);
		((Component)val2).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val2).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val2);
		val2.baseData.damage = 7f;
		val2.baseData.range = 5f;
		ProjectileData baseData = val2.baseData;
		baseData.speed *= 0.9f;
		val2.hitEffects.alwaysUseMidair = true;
		ref GameObject overrideMidairDeathVFX = ref val2.hitEffects.overrideMidairDeathVFX;
		PickupObject byId3 = PickupObjectDatabase.GetById(761);
		overrideMidairDeathVFX = ((Gun)((byId3 is Gun) ? byId3 : null)).DefaultModule.projectiles[0].hitEffects.overrideMidairDeathVFX;
		SpawnProjModifier val3 = ((Component)val2).gameObject.AddComponent<SpawnProjModifier>();
		val3.spawnProjecitlesOnDieInAir = true;
		val3.spawnProjectilesInFlight = false;
		val3.spawnProjectilesOnCollision = true;
		val3.spawnOnObjectCollisions = true;
		val3.spawnCollisionProjectilesOnBounce = true;
		val3.randomRadialStartAngle = true;
		PickupObject byId4 = PickupObjectDatabase.GetById(86);
		GameObject val4 = FakePrefabExtensions.InstantiateAndFakeprefab(((Component)((Gun)((byId4 is Gun) ? byId4 : null)).DefaultModule.projectiles[0]).gameObject);
		val4.GetComponent<Projectile>().AdditionalScaleMultiplier = 0.8f;
		val4.GetComponent<Projectile>().baseData.damage = 3f;
		val3.projectileToSpawnOnCollision = val4.GetComponent<Projectile>();
		val3.collisionSpawnStyle = (CollisionSpawnStyle)0;
		val3.fireRandomlyInAngle = true;
		val3.PostprocessSpawnedProjectiles = true;
		val3.numberToSpawnOnCollison = 5;
		val2.SetProjectileSprite("ulfbehrt_proj", 11, 9, lightened: true, (Anchor)4, 9, 7, anchorChangesCollider: true, fixesScale: false, null, null);
		val.DefaultModule.projectiles[0] = val2;
		val.DefaultModule.ammoType = (AmmoType)14;
		val.DefaultModule.customAmmoType = CustomClipAmmoTypeToolbox.AddCustomAmmoType("Ulfbehrt Bullets", "NevernamedsItems/Resources/CustomGunAmmoTypes/ulfbehrt_clipfull", "NevernamedsItems/Resources/CustomGunAmmoTypes/ulfbehrt_clipempty");
		((PickupObject)val).quality = (ItemQuality)1;
		Databases.Items.Add((PickupObject)(object)val, false, "ANY");
		ID = ((PickupObject)val).PickupObjectId;
	}
}
