using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class Clamshell : GunBehaviour
{
	public static int ID;

	public static void Add()
	{
		//IL_00d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_011b: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f9: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Clamshell", "clamshell");
		Game.Items.Rename("outdated_gun_mods:clamshell", "nn:clamshell");
		((Component)val).gameObject.AddComponent<Clamshell>();
		GunExt.SetShortDescription((PickupObject)(object)val, "Greefer");
		GunExt.SetLongDescription((PickupObject)(object)val, "Fires highly volatile shells.While it may initially appear to be one large gun, this weapon is in fact a colony of many small guns working together.");
		val.SetGunSprites("clamshell", 8, noAmmonomicon: false, 2);
		GunExt.SetAnimationFPS(val, val.shootAnimation, 8);
		GunExt.SetAnimationFPS(val, val.reloadAnimation, 8);
		ref VFXPool muzzleFlashEffects = ref val.muzzleFlashEffects;
		PickupObject byId = PickupObjectDatabase.GetById(39);
		muzzleFlashEffects = ((Gun)((byId is Gun) ? byId : null)).muzzleFlashEffects;
		ref string gunSwitchGroup = ref val.gunSwitchGroup;
		PickupObject byId2 = PickupObjectDatabase.GetById(39);
		gunSwitchGroup = ((Gun)((byId2 is Gun) ? byId2 : null)).gunSwitchGroup;
		PickupObject byId3 = PickupObjectDatabase.GetById(86);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId3 is Gun) ? byId3 : null), true, false);
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.shootStyle = (ShootStyle)0;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 1.1f;
		val.gunClass = (GunClass)45;
		val.DefaultModule.cooldownTime = 1f;
		val.DefaultModule.numberOfShotsInClip = 2;
		val.SetBaseMaxAmmo(50);
		((PickupObject)val).quality = (ItemQuality)2;
		Databases.Items.Add(val, (tk2dSpriteCollectionData)null, "ANY");
		val.SetBarrel(27, 12);
		Projectile val2 = ProjectileSetupUtility.MakeProjectile(56, 10f);
		val2.baseData.UsesCustomAccelerationCurve = true;
		ref AnimationCurve accelerationCurve = ref val2.baseData.AccelerationCurve;
		PickupObject byId4 = PickupObjectDatabase.GetById(39);
		accelerationCurve = ((Gun)((byId4 is Gun) ? byId4 : null)).DefaultModule.projectiles[0].baseData.AccelerationCurve;
		val2.SetProjectileSprite("clamshell_proj", 8, 8, lightened: false, (Anchor)4, 6, 6, anchorChangesCollider: true, fixesScale: false, null, null);
		ExplosiveModifier orAddComponent = GameObjectExtensions.GetOrAddComponent<ExplosiveModifier>(((Component)val2).gameObject);
		orAddComponent.doExplosion = true;
		orAddComponent.explosionData = StaticExplosionDatas.explosiveRoundsExplosion.CopyExplosionData();
		orAddComponent.explosionData.damage = 20f;
		Projectile val3 = ProjectileSetupUtility.MakeProjectile(599, 7f);
		RandomProjectileStatsComponent randomProjectileStatsComponent = ((Component)val3).gameObject.AddComponent<RandomProjectileStatsComponent>();
		randomProjectileStatsComponent.randomScale = true;
		randomProjectileStatsComponent.highScalePercent = 100;
		randomProjectileStatsComponent.lowScalePercent = 40;
		SpawnProjModifier orAddComponent2 = GameObjectExtensions.GetOrAddComponent<SpawnProjModifier>(((Component)val2).gameObject);
		orAddComponent2.spawnProjectilesInFlight = true;
		orAddComponent2.numToSpawnInFlight = 1;
		orAddComponent2.fireRandomlyInAngle = true;
		orAddComponent2.inFlightSpawnAngle = 360f;
		orAddComponent2.inFlightSpawnCooldown = 0.1f;
		orAddComponent2.projectileToSpawnInFlight = val3;
		orAddComponent2.usesComplexSpawnInFlight = true;
		orAddComponent2.spawnProjectilesOnCollision = true;
		orAddComponent2.projectileToSpawnOnCollision = val3;
		orAddComponent2.numberToSpawnOnCollison = 8;
		orAddComponent2.spawnOnObjectCollisions = true;
		orAddComponent2.spawnCollisionProjectilesOnBounce = true;
		orAddComponent2.spawnProjecitlesOnDieInAir = true;
		orAddComponent2.collisionSpawnStyle = (CollisionSpawnStyle)0;
		orAddComponent2.randomRadialStartAngle = true;
		val.DefaultModule.projectiles[0] = val2;
		val.AddClipSprites("minigun");
		val.carryPixelOffset = new IntVector2(2, 3);
		ID = ((PickupObject)val).PickupObjectId;
	}
}
