using Alexandria.Assetbundle;
using Alexandria.ItemAPI;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class Dimensionaliser : AdvancedGunBehavior
{
	public static int DimensionaliserID;

	public static void Add()
	{
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_010e: Unknown result type (might be due to invalid IL or missing references)
		//IL_012d: Unknown result type (might be due to invalid IL or missing references)
		//IL_02bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_02fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_041d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0443: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Dimensionaliser", "dimensionaliser");
		Game.Items.Rename("outdated_gun_mods:dimensionaliser", "nn:dimensionaliser");
		((Component)val).gameObject.AddComponent<Dimensionaliser>();
		GunExt.SetShortDescription((PickupObject)(object)val, "The Multiverse!");
		GunExt.SetLongDescription((PickupObject)(object)val, "Opens portals to random segments of the multiverse, letting kaliber-knows-what through.\n\n");
		val.SetGunSprites("dimensionaliser");
		GunExt.SetAnimationFPS(val, val.shootAnimation, 14);
		PickupObject byId = PickupObjectDatabase.GetById(56);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId is Gun) ? byId : null), true, false);
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.shootStyle = (ShootStyle)0;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 1f;
		val.DefaultModule.cooldownTime = 2f;
		val.DefaultModule.angleVariance = 7f;
		ref VFXPool muzzleFlashEffects = ref val.muzzleFlashEffects;
		PickupObject byId2 = PickupObjectDatabase.GetById(89);
		muzzleFlashEffects = ((Gun)((byId2 is Gun) ? byId2 : null)).muzzleFlashEffects;
		val.DefaultModule.numberOfShotsInClip = 2;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(0.81f, 0.43f, 0f);
		val.SetBaseMaxAmmo(100);
		val.ammo = 100;
		val.gunClass = (GunClass)50;
		Projectile val2 = Object.Instantiate<Projectile>(val.DefaultModule.projectiles[0]);
		((Component)val2).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val2).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val2);
		val2.baseData.damage = 5f;
		ProjectileData baseData = val2.baseData;
		baseData.speed *= 1f;
		val2.hitEffects.overrideMidairDeathVFX = SharedVFX.GreenLaserCircleVFX;
		val2.hitEffects.alwaysUseMidair = true;
		val2.SetProjectileSprite("dimensionaliser_projectile", 12, 7, lightened: true, (Anchor)4, 10, 5, anchorChangesCollider: true, fixesScale: false, null, null);
		PickupObject byId3 = PickupObjectDatabase.GetById(86);
		Projectile val3 = Object.Instantiate<Projectile>(((Gun)((byId3 is Gun) ? byId3 : null)).DefaultModule.projectiles[0]);
		((Component)val3).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val3).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val3);
		val3.baseData.damage = 0f;
		val3.baseData.speed = 0f;
		((BraveBehaviour)val3).specRigidbody.CollideWithTileMap = false;
		val3.pierceMinorBreakables = true;
		DimensionaliserPortal orAddComponent = GameObjectExtensions.GetOrAddComponent<DimensionaliserPortal>(((Component)val3).gameObject);
		orAddComponent.subProj = val2;
		NoCollideBehaviour orAddComponent2 = GameObjectExtensions.GetOrAddComponent<NoCollideBehaviour>(((Component)val3).gameObject);
		orAddComponent2.worksOnEnemies = true;
		orAddComponent2.worksOnProjectiles = true;
		val3.hitEffects.overrideMidairDeathVFX = SharedVFX.GreenLaserCircleVFX;
		val3.hitEffects.alwaysUseMidair = true;
		ProjectileBuilders.AnimateProjectileBundle(val3, "DimensionaliserPortalIdle", Initialisation.ProjectileCollection, Initialisation.projectileAnimationCollection, "DimensionaliserPortalIdle", MiscTools.DupeList<IntVector2>(new IntVector2(55, 55), 90), MiscTools.DupeList(value: true, 90), MiscTools.DupeList<Anchor>((Anchor)4, 90), MiscTools.DupeList(value: true, 90), MiscTools.DupeList(value: false, 90), MiscTools.DupeList<Vector3?>(null, 90), MiscTools.DupeList((IntVector2?)new IntVector2(30, 30), 90), MiscTools.DupeList<IntVector2?>(null, 90), MiscTools.DupeList<Projectile>(null, 90));
		Projectile val4 = Object.Instantiate<Projectile>(val.DefaultModule.projectiles[0]);
		((Component)val4).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val4).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val4);
		val4.baseData.damage = 1f;
		ProjectileData baseData2 = val4.baseData;
		baseData2.speed *= 3f;
		val4.hitEffects.overrideMidairDeathVFX = SharedVFX.GreenLaserCircleVFX;
		val4.hitEffects.alwaysUseMidair = true;
		DimensionaliserProjectile orAddComponent3 = GameObjectExtensions.GetOrAddComponent<DimensionaliserProjectile>(((Component)val4).gameObject);
		orAddComponent3.portalPrefab = ((Component)val3).gameObject;
		val4.SetProjectileSprite("dimensionaliser_projectile", 12, 7, lightened: true, (Anchor)4, 10, 5, anchorChangesCollider: true, fixesScale: false, null, null);
		val.DefaultModule.projectiles[0] = val4;
		val.DefaultModule.ammoType = (AmmoType)14;
		val.DefaultModule.customAmmoType = CustomClipAmmoTypeToolbox.AddCustomAmmoType("Dimensionaliser Bullets", "NevernamedsItems/Resources/CustomGunAmmoTypes/dimensionaliser_clipfull", "NevernamedsItems/Resources/CustomGunAmmoTypes/dimensionaliser_clipempty");
		((PickupObject)val).quality = (ItemQuality)5;
		Databases.Items.Add(val, (tk2dSpriteCollectionData)null, "ANY");
		DimensionaliserID = ((PickupObject)val).PickupObjectId;
	}
}
