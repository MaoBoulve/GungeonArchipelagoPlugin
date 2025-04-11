using Alexandria.ItemAPI;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class TestGun : AdvancedGunBehavior
{
	public static void Add()
	{
		//IL_009b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_015f: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ed: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Testinator", "testinator");
		Game.Items.Rename("outdated_gun_mods:testinator", "nn:testinator");
		TestGun testGun = ((Component)val).gameObject.AddComponent<TestGun>();
		((AdvancedGunBehavior)testGun).preventNormalFireAudio = true;
		((AdvancedGunBehavior)testGun).overrideNormalFireAudio = "Play_GoldenEye_BulletFire";
		GunExt.SetLongDescription((PickupObject)(object)val, "Made for fun. Probably broken.");
		val.SetGunSprites("wailingmagnum");
		GunExt.SetAnimationFPS(val, val.shootAnimation, 10);
		PickupObject byId = PickupObjectDatabase.GetById(86);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId is Gun) ? byId : null), true, false);
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.shootStyle = (ShootStyle)1;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)1;
		val.reloadTime = 1.1f;
		val.DefaultModule.cooldownTime = 0.1f;
		val.DefaultModule.numberOfShotsInClip = 7;
		val.SetBaseMaxAmmo(700);
		PickupObject byId2 = PickupObjectDatabase.GetById(56);
		LobbedProjectile lobbedProjectile = DataCloners.CopyFields<LobbedProjectile>(Object.Instantiate<Projectile>(((Gun)((byId2 is Gun) ? byId2 : null)).DefaultModule.projectiles[0]));
		FakePrefabExtensions.MakeFakePrefab(((Component)lobbedProjectile).gameObject);
		((Component)lobbedProjectile).gameObject.AddComponent<BounceProjModifier>().numberOfBounces = 5;
		lobbedProjectile.visualHeight = 2f;
		lobbedProjectile.spawnCollisionProjectilesOnFloorBounce = true;
		SpawnProjModifier val2 = ((Component)lobbedProjectile).gameObject.AddComponent<SpawnProjModifier>();
		val2.spawnProjectilesOnCollision = true;
		val2.spawnCollisionProjectilesOnBounce = true;
		val2.randomRadialStartAngle = true;
		val2.numberToSpawnOnCollison = 5;
		val2.collisionSpawnStyle = (CollisionSpawnStyle)0;
		PickupObject byId3 = PickupObjectDatabase.GetById(56);
		LobbedProjectile lobbedProjectile2 = DataCloners.CopyFields<LobbedProjectile>(Object.Instantiate<Projectile>(((Gun)((byId3 is Gun) ? byId3 : null)).DefaultModule.projectiles[0]));
		FakePrefabExtensions.MakeFakePrefab(((Component)lobbedProjectile2).gameObject);
		((Component)lobbedProjectile2).gameObject.AddComponent<BounceProjModifier>().numberOfBounces = 1;
		((Projectile)lobbedProjectile2).AdditionalScaleMultiplier = 0.5f;
		lobbedProjectile2.visualHeight = 1f;
		lobbedProjectile2.forcedDistance = 2f;
		val2.projectileToSpawnOnCollision = (Projectile)(object)lobbedProjectile2;
		val.DefaultModule.projectiles[0] = (Projectile)(object)lobbedProjectile;
		((PickupObject)val).quality = (ItemQuality)(-100);
		Databases.Items.Add(val, (tk2dSpriteCollectionData)null, "ANY");
	}

	public override void PostProcessProjectile(Projectile projectile)
	{
		((AdvancedGunBehavior)this).PostProcessProjectile(projectile);
	}
}
