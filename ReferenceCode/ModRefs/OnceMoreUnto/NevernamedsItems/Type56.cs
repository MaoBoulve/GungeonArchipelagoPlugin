using Alexandria.ItemAPI;
using Alexandria.Misc;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class Type56 : AdvancedGunBehavior
{
	public static int ID;

	public static void Add()
	{
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0124: Unknown result type (might be due to invalid IL or missing references)
		//IL_0149: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0204: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Type 56", "type56");
		Game.Items.Rename("outdated_gun_mods:type_56", "nn:type_56");
		((Component)val).gameObject.AddComponent<Type56>();
		GunExt.SetShortDescription((PickupObject)(object)val, "State Standard");
		GunExt.SetLongDescription((PickupObject)(object)val, "Cheap imperial hardware from the fringes of Hegemony space. Its brittle ammunition is prone to fragmentation.");
		val.SetGunSprites("type56");
		GunExt.SetAnimationFPS(val, val.shootAnimation, 12);
		GunExt.SetAnimationFPS(val, val.reloadAnimation, 0);
		PickupObject byId = PickupObjectDatabase.GetById(15);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId is Gun) ? byId : null), true, false);
		ref string gunSwitchGroup = ref val.gunSwitchGroup;
		PickupObject byId2 = PickupObjectDatabase.GetById(15);
		gunSwitchGroup = ((Gun)((byId2 is Gun) ? byId2 : null)).gunSwitchGroup;
		ref VFXPool muzzleFlashEffects = ref val.muzzleFlashEffects;
		PickupObject byId3 = PickupObjectDatabase.GetById(15);
		muzzleFlashEffects = ((Gun)((byId3 is Gun) ? byId3 : null)).muzzleFlashEffects;
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.shootStyle = (ShootStyle)1;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 0.7f;
		val.DefaultModule.cooldownTime = 0.1f;
		val.DefaultModule.numberOfShotsInClip = 20;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(1.75f, 0.3125f, 0f);
		val.SetBaseMaxAmmo(400);
		val.ammo = 400;
		val.gunClass = (GunClass)10;
		Projectile val2 = ProjectileUtility.InstantiateAndFakeprefab(val.DefaultModule.projectiles[0]);
		val2.baseData.damage = 5f;
		val.DefaultModule.projectiles[0] = val2;
		SpawnProjModifier val3 = ((Component)val2).gameObject.AddComponent<SpawnProjModifier>();
		val3.SpawnedProjectilesInheritAppearance = true;
		val3.SpawnedProjectileScaleModifier = 0.5f;
		val3.SpawnedProjectilesInheritData = true;
		val3.spawnProjectilesOnCollision = true;
		val3.spawnProjecitlesOnDieInAir = true;
		val3.doOverrideObjectCollisionSpawnStyle = true;
		val3.randomRadialStartAngle = true;
		val3.startAngle = Random.Range(0, 180);
		val3.numberToSpawnOnCollison = 4;
		ref Projectile projectileToSpawnOnCollision = ref val3.projectileToSpawnOnCollision;
		PickupObject byId4 = PickupObjectDatabase.GetById(531);
		projectileToSpawnOnCollision = ((ComplexProjectileModifier)((byId4 is ComplexProjectileModifier) ? byId4 : null)).CollisionSpawnProjectile;
		val3.collisionSpawnStyle = (CollisionSpawnStyle)1;
		((PickupObject)val).quality = (ItemQuality)3;
		Databases.Items.Add(val, (tk2dSpriteCollectionData)null, "ANY");
		ID = ((PickupObject)val).PickupObjectId;
		AlexandriaTags.SetTag((PickupObject)(object)val, "kalashnikov");
	}
}
