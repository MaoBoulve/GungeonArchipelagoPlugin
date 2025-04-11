using Alexandria.ItemAPI;
using Alexandria.Misc;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class Arquebus : AdvancedGunBehavior
{
	public static int ID;

	public static void Add()
	{
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0123: Unknown result type (might be due to invalid IL or missing references)
		//IL_013a: Unknown result type (might be due to invalid IL or missing references)
		//IL_024b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0265: Unknown result type (might be due to invalid IL or missing references)
		//IL_026c: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Arquebus", "arquebus");
		Game.Items.Rename("outdated_gun_mods:arquebus", "nn:arquebus");
		((Component)val).gameObject.AddComponent<Arquebus>();
		GunExt.SetShortDescription((PickupObject)(object)val, "Line and Sinker");
		GunExt.SetLongDescription((PickupObject)(object)val, "A classic muzzleloader, overstuffed with black powder from the depths of the Gungeon's labyrinthine mines.\n\nKicks up plenty of shrapnel on impact.");
		val.SetGunSprites("arquebus");
		GunExt.SetAnimationFPS(val, val.shootAnimation, 15);
		GunExt.SetAnimationFPS(val, val.reloadAnimation, 6);
		ref string gunSwitchGroup = ref val.gunSwitchGroup;
		PickupObject byId = PickupObjectDatabase.GetById(9);
		gunSwitchGroup = ((Gun)((byId is Gun) ? byId : null)).gunSwitchGroup;
		ref VFXPool muzzleFlashEffects = ref val.muzzleFlashEffects;
		PickupObject byId2 = PickupObjectDatabase.GetById(9);
		muzzleFlashEffects = ((Gun)((byId2 is Gun) ? byId2 : null)).muzzleFlashEffects;
		PickupObject byId3 = PickupObjectDatabase.GetById(9);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId3 is Gun) ? byId3 : null), true, false);
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.shootStyle = (ShootStyle)0;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 1.32f;
		val.DefaultModule.cooldownTime = 1f;
		val.DefaultModule.numberOfShotsInClip = 1;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(4.0625f, 1.9375f, 0f);
		val.SetBaseMaxAmmo(90);
		val.gunClass = (GunClass)15;
		Projectile val2 = ProjectileUtility.InstantiateAndFakeprefab(val.DefaultModule.projectiles[0]);
		val.DefaultModule.projectiles[0] = val2;
		val2.baseData.damage = 40f;
		BounceProjModifier component = ((Component)val2).GetComponent<BounceProjModifier>();
		component.numberOfBounces = 2;
		SpawnProjModifier val3 = ((Component)val2).gameObject.AddComponent<SpawnProjModifier>();
		val3.SpawnedProjectilesInheritAppearance = false;
		val3.SpawnedProjectileScaleModifier = 0.5f;
		val3.SpawnedProjectilesInheritData = true;
		val3.spawnProjectilesOnCollision = true;
		val3.spawnProjecitlesOnDieInAir = false;
		val3.doOverrideObjectCollisionSpawnStyle = true;
		val3.randomRadialStartAngle = true;
		val3.startAngle = Random.Range(0, 180);
		val3.numberToSpawnOnCollison = 5;
		PickupObject byId4 = PickupObjectDatabase.GetById(531);
		Projectile val4 = ProjectileUtility.InstantiateAndFakeprefab(((ComplexProjectileModifier)((byId4 is ComplexProjectileModifier) ? byId4 : null)).CollisionSpawnProjectile);
		val4.baseData.damage = 10f;
		val4.SetProjectileSprite("arquebusflak", 4, 4, lightened: false, (Anchor)4, 4, 4, anchorChangesCollider: true, fixesScale: false, null, null);
		val3.projectileToSpawnOnCollision = val4;
		val3.collisionSpawnStyle = (CollisionSpawnStyle)1;
		val3.spawnCollisionProjectilesOnBounce = true;
		val2.pierceMinorBreakables = true;
		val.DefaultModule.ammoType = (AmmoType)8;
		((PickupObject)val).quality = (ItemQuality)3;
		Databases.Items.Add(val, (tk2dSpriteCollectionData)null, "ANY");
		ID = ((PickupObject)val).PickupObjectId;
	}
}
