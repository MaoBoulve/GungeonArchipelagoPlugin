using Alexandria.ItemAPI;
using Alexandria.Misc;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class ServiceWeaponSpin : AdvancedGunBehavior
{
	public static int ID;

	public static void Add()
	{
		//IL_00d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0102: Unknown result type (might be due to invalid IL or missing references)
		//IL_0121: Unknown result type (might be due to invalid IL or missing references)
		//IL_012d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0173: Unknown result type (might be due to invalid IL or missing references)
		//IL_018a: Unknown result type (might be due to invalid IL or missing references)
		//IL_020f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0227: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Spin", "serviceweaponspin");
		Game.Items.Rename("outdated_gun_mods:spin", "nn:service_weapon+spin");
		((Component)val).gameObject.AddComponent<ServiceWeapon>();
		GunExt.SetShortDescription((PickupObject)(object)val, "");
		GunExt.SetLongDescription((PickupObject)(object)val, "");
		val.SetGunSprites("serviceweaponspin", 8, noAmmonomicon: true);
		GunExt.SetAnimationFPS(val, val.shootAnimation, 12);
		GunExt.SetAnimationFPS(val, val.reloadAnimation, 12);
		ref string gunSwitchGroup = ref val.gunSwitchGroup;
		PickupObject byId = PickupObjectDatabase.GetById(124);
		gunSwitchGroup = ((Gun)((byId is Gun) ? byId : null)).gunSwitchGroup;
		ref VFXPool muzzleFlashEffects = ref val.muzzleFlashEffects;
		PickupObject byId2 = PickupObjectDatabase.GetById(ServiceWeapon.ID);
		muzzleFlashEffects = ((Gun)((byId2 is Gun) ? byId2 : null)).muzzleFlashEffects;
		PickupObject byId3 = PickupObjectDatabase.GetById(124);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId3 is Gun) ? byId3 : null), true, false);
		((Component)val).GetComponent<tk2dSpriteAnimator>().GetClipByName(val.reloadAnimation).wrapMode = (WrapMode)1;
		((Component)val).GetComponent<tk2dSpriteAnimator>().GetClipByName(val.reloadAnimation).loopStart = 2;
		((Component)val).GetComponent<tk2dSpriteAnimator>().GetClipByName(val.shootAnimation).wrapMode = (WrapMode)0;
		val.usesContinuousFireAnimation = true;
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.shootStyle = (ShootStyle)1;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 1f;
		val.DefaultModule.cooldownTime = 0.05f;
		val.DefaultModule.numberOfShotsInClip = -1;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(2.0625f, 1f, 0f);
		val.SetBaseMaxAmmo(29);
		val.gunClass = (GunClass)10;
		Projectile val2 = ProjectileUtility.InstantiateAndFakeprefab(val.DefaultModule.projectiles[0]);
		val.DefaultModule.projectiles[0] = val2;
		val2.baseData.damage = 10f;
		ProjectileData baseData = val2.baseData;
		baseData.speed *= 2f;
		ref ProjectileImpactVFXPool hitEffects = ref val2.hitEffects;
		PickupObject byId4 = PickupObjectDatabase.GetById(15);
		hitEffects = ((Gun)((byId4 is Gun) ? byId4 : null)).DefaultModule.projectiles[0].hitEffects;
		val.DefaultModule.ammoType = (AmmoType)14;
		val.DefaultModule.customAmmoType = "Service Weapon Bullets";
		((PickupObject)val).quality = (ItemQuality)(-100);
		Databases.Items.Add(val, (tk2dSpriteCollectionData)null, "ANY");
		ID = ((PickupObject)val).PickupObjectId;
	}
}
