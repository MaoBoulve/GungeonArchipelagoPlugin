using Alexandria.ItemAPI;
using Alexandria.Misc;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class Spitfire : AdvancedGunBehavior
{
	public static int ID;

	public static void Add()
	{
		//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_013f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0164: Unknown result type (might be due to invalid IL or missing references)
		//IL_023d: Unknown result type (might be due to invalid IL or missing references)
		//IL_02df: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f7: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Spitballer", "spitfire");
		Game.Items.Rename("outdated_gun_mods:spitballer", "nn:spitballer+spitfire");
		((Component)val).gameObject.AddComponent<Spitfire>();
		GunExt.SetShortDescription((PickupObject)(object)val, "");
		GunExt.SetLongDescription((PickupObject)(object)val, "");
		val.SetGunSprites("spitfire", 8, noAmmonomicon: true);
		GunExt.SetAnimationFPS(val, val.shootAnimation, 12);
		((Component)val).GetComponent<tk2dSpriteAnimator>().GetClipByName(val.shootAnimation).frames[0].eventAudio = "spit_fire";
		((Component)val).GetComponent<tk2dSpriteAnimator>().GetClipByName(val.shootAnimation).frames[0].triggerEvent = true;
		PickupObject byId = PickupObjectDatabase.GetById(56);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId is Gun) ? byId : null), true, false);
		ref VFXPool muzzleFlashEffects = ref val.muzzleFlashEffects;
		PickupObject byId2 = PickupObjectDatabase.GetById(33);
		muzzleFlashEffects = ((Gun)((byId2 is Gun) ? byId2 : null)).muzzleFlashEffects;
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.shootStyle = (ShootStyle)1;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 1f;
		val.DefaultModule.cooldownTime = 0.21f;
		val.DefaultModule.numberOfShotsInClip = 10;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(1.75f, 0.875f, 0f);
		val.SetBaseMaxAmmo(2000);
		val.ammo = 2000;
		val.gunClass = (GunClass)10;
		Projectile component = FakePrefabExtensions.InstantiateAndFakeprefab(((Component)val.DefaultModule.projectiles[0]).gameObject).GetComponent<Projectile>();
		val.DefaultModule.projectiles[0] = component;
		((Object)((Component)component).gameObject).name = "spitfire_proj";
		component.baseData.damage = 8f;
		component.SetProjectileSprite("spitfire_proj", 10, 2, lightened: false, (Anchor)4, 10, 2, anchorChangesCollider: true, fixesScale: false, null, null);
		BulletSharkProjectileDoer bulletSharkProjectileDoer = ((Component)component).gameObject.AddComponent<BulletSharkProjectileDoer>();
		Projectile val2 = ProjectileUtility.SetupProjectile(86);
		val2.baseData.damage = 5.1f;
		ProjectileData baseData = val2.baseData;
		baseData.speed *= 0.8f;
		val2.hitEffects.overrideMidairDeathVFX = VFXToolbox.CreateVFXBundle("SpitballerImpact", new IntVector2(10, 8), (Anchor)4, usesZHeight: true, 0.2f, -1f, null);
		val2.hitEffects.alwaysUseMidair = true;
		val2.SetProjectileSprite("spitballer_proj", 4, 4, lightened: false, (Anchor)4, 4, 4, anchorChangesCollider: true, fixesScale: false, null, null);
		GoopModifier val3 = ((Component)val2).gameObject.AddComponent<GoopModifier>();
		val3.SpawnGoopOnCollision = true;
		val3.CollisionSpawnRadius = 0.5f;
		val3.goopDefinition = EasyGoopDefinitions.WaterGoop;
		bulletSharkProjectileDoer.toSpawn = val2;
		val.DefaultModule.ammoType = (AmmoType)14;
		val.DefaultModule.customAmmoType = "white";
		((PickupObject)val).quality = (ItemQuality)(-100);
		Databases.Items.Add((PickupObject)(object)val, false, "ANY");
		GunExt.SetName((PickupObject)(object)val, "Spitballer");
		ID = ((PickupObject)val).PickupObjectId;
	}
}
