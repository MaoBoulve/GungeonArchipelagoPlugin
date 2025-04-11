using Alexandria.ItemAPI;
using Alexandria.Misc;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class ServiceWeaponShatter : AdvancedGunBehavior
{
	public static int ID;

	public static void Add()
	{
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_013e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0153: Unknown result type (might be due to invalid IL or missing references)
		//IL_0184: Unknown result type (might be due to invalid IL or missing references)
		//IL_018c: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_02eb: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Shatter", "serviceweaponshatter");
		Game.Items.Rename("outdated_gun_mods:shatter", "nn:service_weapon+shatter");
		((Component)val).gameObject.AddComponent<ServiceWeaponShatter>();
		GunExt.SetShortDescription((PickupObject)(object)val, "");
		GunExt.SetLongDescription((PickupObject)(object)val, "");
		val.SetGunSprites("serviceweaponshatter", 8, noAmmonomicon: true);
		GunExt.SetAnimationFPS(val, val.shootAnimation, 12);
		GunExt.SetAnimationFPS(val, val.reloadAnimation, 12);
		ref string gunSwitchGroup = ref val.gunSwitchGroup;
		PickupObject byId = PickupObjectDatabase.GetById(47);
		gunSwitchGroup = ((Gun)((byId is Gun) ? byId : null)).gunSwitchGroup;
		ref VFXPool muzzleFlashEffects = ref val.muzzleFlashEffects;
		PickupObject byId2 = PickupObjectDatabase.GetById(ServiceWeapon.ID);
		muzzleFlashEffects = ((Gun)((byId2 is Gun) ? byId2 : null)).muzzleFlashEffects;
		ref ScreenShakeSettings gunScreenShake = ref val.gunScreenShake;
		PickupObject byId3 = PickupObjectDatabase.GetById(51);
		gunScreenShake = ((Gun)((byId3 is Gun) ? byId3 : null)).gunScreenShake;
		for (int i = 0; i < 5; i++)
		{
			PickupObject byId4 = PickupObjectDatabase.GetById(56);
			GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId4 is Gun) ? byId4 : null), true, false);
		}
		((Component)val).GetComponent<tk2dSpriteAnimator>().GetClipByName(val.reloadAnimation).wrapMode = (WrapMode)1;
		((Component)val).GetComponent<tk2dSpriteAnimator>().GetClipByName(val.reloadAnimation).loopStart = 3;
		val.reloadTime = 1.8f;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(1.625f, 1f, 0f);
		val.SetBaseMaxAmmo(6);
		val.gunClass = (GunClass)5;
		foreach (ProjectileModule projectile in val.Volley.projectiles)
		{
			projectile.ammoCost = 0;
			projectile.shootStyle = (ShootStyle)0;
			projectile.sequenceStyle = (ProjectileSequenceStyle)0;
			projectile.cooldownTime = 0.7f;
			projectile.angleVariance = 19f;
			projectile.numberOfShotsInClip = -1;
			Projectile val2 = ProjectileUtility.InstantiateAndFakeprefab(projectile.projectiles[0]);
			projectile.projectiles[0] = val2;
			val2.baseData.damage = 20f;
			ProjectileData baseData = val2.baseData;
			baseData.speed *= 2f;
			ProjectileData baseData2 = val2.baseData;
			baseData2.force *= 2f;
			val2.baseData.range = 8f;
			val2.SetProjectileSprite("serviceweapon_proj", 11, 6, lightened: true, (Anchor)4, 10, 5, anchorChangesCollider: true, fixesScale: false, null, null);
			ref GameObject overrideMidairDeathVFX = ref val2.hitEffects.overrideMidairDeathVFX;
			PickupObject byId5 = PickupObjectDatabase.GetById(98);
			overrideMidairDeathVFX = ((Gun)((byId5 is Gun) ? byId5 : null)).DefaultModule.projectiles[0].hitEffects.overrideMidairDeathVFX;
			val2.hitEffects.alwaysUseMidair = true;
			projectile.ammoType = (AmmoType)14;
			projectile.customAmmoType = "Service Weapon Bullets";
		}
		val.Volley.UsesShotgunStyleVelocityRandomizer = true;
		val.DefaultModule.ammoCost = 1;
		((PickupObject)val).quality = (ItemQuality)(-100);
		Databases.Items.Add(val, (tk2dSpriteCollectionData)null, "ANY");
		ID = ((PickupObject)val).PickupObjectId;
	}
}
