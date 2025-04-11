using Alexandria.ItemAPI;
using Alexandria.Misc;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class Monsoon : GunBehaviour
{
	public static int ID;

	public static void Add()
	{
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_012d: Unknown result type (might be due to invalid IL or missing references)
		//IL_01da: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_0348: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Monsoon", "monsoon");
		Game.Items.Rename("outdated_gun_mods:monsoon", "nn:monsoon");
		((Component)val).gameObject.AddComponent<Monsoon>();
		GunExt.SetShortDescription((PickupObject)(object)val, "Bless The Rains");
		GunExt.SetLongDescription((PickupObject)(object)val, "Lobs concentrated rainfall.\n\nAs the Gungeon is far from watertight, rainwater that falls upon the keep tends to pool in the Chambers below.");
		val.SetGunSprites("monsoon", 8, noAmmonomicon: false, 2);
		PickupObject byId = PickupObjectDatabase.GetById(86);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId is Gun) ? byId : null), true, false);
		ref string gunSwitchGroup = ref val.gunSwitchGroup;
		PickupObject byId2 = PickupObjectDatabase.GetById(33);
		gunSwitchGroup = ((Gun)((byId2 is Gun) ? byId2 : null)).gunSwitchGroup;
		val.muzzleFlashEffects = VFXToolbox.CreateVFXPoolBundle("MonsoonMuzzle", usesZHeight: false, 0f, (VFXAlignment)0, 5f, Color32.op_Implicit(new Color32(byte.MaxValue, (byte)117, (byte)117, byte.MaxValue)));
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.shootStyle = (ShootStyle)0;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 1.23f;
		val.DefaultModule.cooldownTime = 0.85f;
		val.DefaultModule.numberOfShotsInClip = 5;
		val.SetBarrel(21, 11);
		val.SetBaseMaxAmmo(100);
		val.ammo = 100;
		val.gunClass = (GunClass)1;
		ref ScreenShakeSettings gunScreenShake = ref val.gunScreenShake;
		PickupObject byId3 = PickupObjectDatabase.GetById(202);
		gunScreenShake = ((Gun)((byId3 is Gun) ? byId3 : null)).gunScreenShake;
		PickupObject byId4 = PickupObjectDatabase.GetById(33);
		LobbedProjectile lobbedProjectile = DataCloners.CopyFields<LobbedProjectile>(Object.Instantiate<Projectile>(((Gun)((byId4 is Gun) ? byId4 : null)).DefaultModule.projectiles[0]));
		FakePrefabExtensions.MakeFakePrefab(((Component)lobbedProjectile).gameObject);
		((Component)lobbedProjectile).gameObject.AddComponent<BounceProjModifier>().numberOfBounces = 5;
		lobbedProjectile.visualHeight = 2f;
		lobbedProjectile.spawnCollisionProjectilesOnFloorBounce = true;
		lobbedProjectile.spawnCollisionGoopOnFloorBounce = true;
		lobbedProjectile.canHitAnythingEvenWhenNotGrounded = true;
		SpawnProjModifier val2 = ((Component)lobbedProjectile).gameObject.AddComponent<SpawnProjModifier>();
		val2.spawnProjectilesOnCollision = true;
		val2.spawnCollisionProjectilesOnBounce = true;
		val2.randomRadialStartAngle = true;
		val2.numberToSpawnOnCollison = 5;
		val2.collisionSpawnStyle = (CollisionSpawnStyle)0;
		PickupObject byId5 = PickupObjectDatabase.GetById(33);
		LobbedProjectile lobbedProjectile2 = DataCloners.CopyFields<LobbedProjectile>(Object.Instantiate<Projectile>(((Gun)((byId5 is Gun) ? byId5 : null)).DefaultModule.projectiles[0]));
		FakePrefabExtensions.MakeFakePrefab(((Component)lobbedProjectile2).gameObject);
		((Component)lobbedProjectile2).gameObject.AddComponent<BounceProjModifier>().numberOfBounces = 1;
		((Projectile)lobbedProjectile2).AdditionalScaleMultiplier = 0.5f;
		lobbedProjectile2.visualHeight = 1f;
		lobbedProjectile2.forcedDistance = 2f;
		lobbedProjectile2.spawnCollisionGoopOnFloorBounce = true;
		lobbedProjectile2.canHitAnythingEvenWhenNotGrounded = true;
		GoopModifier val3 = ((Component)lobbedProjectile2).gameObject.AddComponent<GoopModifier>();
		val3.SpawnGoopOnCollision = true;
		val3.CollisionSpawnRadius = 0.5f;
		val3.goopDefinition = GoopUtility.WaterDef;
		val2.projectileToSpawnOnCollision = (Projectile)(object)lobbedProjectile2;
		GoopModifier val4 = ((Component)lobbedProjectile).gameObject.AddComponent<GoopModifier>();
		val4.SpawnGoopOnCollision = true;
		val4.CollisionSpawnRadius = 2f;
		val4.goopDefinition = GoopUtility.WaterDef;
		val.muzzleFlashEffects.effects[0].effects[0].attached = false;
		val.DefaultModule.projectiles[0] = (Projectile)(object)lobbedProjectile;
		val.gunHandedness = (GunHandedness)2;
		val.DefaultModule.ammoType = (AmmoType)14;
		val.DefaultModule.customAmmoType = "Tear";
		val.AddShellCasing(1, 1, 0, 0, "shell_diamond");
		DebrisObject component = val.shellCasing.GetComponent<DebrisObject>();
		component.DoesGoopOnRest = true;
		component.GoopRadius = 0.3f;
		component.AssignedGoop = GoopUtility.WaterDef;
		((PickupObject)val).quality = (ItemQuality)3;
		Databases.Items.Add(val, (tk2dSpriteCollectionData)null, "ANY");
		ID = ((PickupObject)val).PickupObjectId;
	}
}
