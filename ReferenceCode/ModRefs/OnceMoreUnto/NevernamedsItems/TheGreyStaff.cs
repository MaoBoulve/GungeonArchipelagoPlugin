using Alexandria.ItemAPI;
using Alexandria.Misc;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class TheGreyStaff : AdvancedGunBehavior
{
	public static int ID;

	public static void Add()
	{
		//IL_00be: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_0138: Unknown result type (might be due to invalid IL or missing references)
		//IL_015d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0223: Unknown result type (might be due to invalid IL or missing references)
		//IL_023a: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("The Grey Staff", "thegreystaff");
		Game.Items.Rename("outdated_gun_mods:the_grey_staff", "nn:the_grey_staff");
		((Component)val).gameObject.AddComponent<TheGreyStaff>();
		GunExt.SetShortDescription((PickupObject)(object)val, "You Shall Not Pass");
		GunExt.SetLongDescription((PickupObject)(object)val, "An ancient and powerful gun barrel from an age before the Gungeon.\n\nThough studied by Alben Smallbore, it is not of his craft.");
		val.SetGunSprites("thegreystaff");
		GunExt.SetAnimationFPS(val, val.shootAnimation, 12);
		GunExt.SetAnimationFPS(val, val.reloadAnimation, 12);
		ref string gunSwitchGroup = ref val.gunSwitchGroup;
		PickupObject byId = PickupObjectDatabase.GetById(145);
		gunSwitchGroup = ((Gun)((byId is Gun) ? byId : null)).gunSwitchGroup;
		PickupObject byId2 = PickupObjectDatabase.GetById(56);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId2 is Gun) ? byId2 : null), true, false);
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.shootStyle = (ShootStyle)1;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 1.3f;
		val.DefaultModule.cooldownTime = 0.1f;
		val.DefaultModule.angleVariance = 20f;
		val.DefaultModule.numberOfShotsInClip = 30;
		ref VFXPool muzzleFlashEffects = ref val.muzzleFlashEffects;
		PickupObject byId3 = PickupObjectDatabase.GetById(97);
		muzzleFlashEffects = ((Gun)((byId3 is Gun) ? byId3 : null)).muzzleFlashEffects;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(2.5f, 0.625f, 0f);
		val.SetBaseMaxAmmo(777);
		val.ammo = 777;
		val.gunClass = (GunClass)10;
		Projectile val2 = ProjectileUtility.InstantiateAndFakeprefab(val.DefaultModule.projectiles[0]);
		val2.baseData.damage = 5.5f;
		val2.baseData.speed = 11f;
		val2.SetProjectileSprite("16x16_white_circle", 6, 6, lightened: true, (Anchor)4, 6, 6, anchorChangesCollider: true, fixesScale: false, null, null);
		val2.hitEffects.overrideMidairDeathVFX = SharedVFX.WhiteCircleVFX;
		val2.hitEffects.alwaysUseMidair = true;
		BounceProjModifier val3 = ((Component)val2).gameObject.AddComponent<BounceProjModifier>();
		val3.numberOfBounces = 2;
		RemoteBulletsProjectileBehaviour remoteBulletsProjectileBehaviour = ((Component)val2).gameObject.AddComponent<RemoteBulletsProjectileBehaviour>();
		val.DefaultModule.projectiles[0] = val2;
		val.DefaultModule.ammoType = (AmmoType)14;
		val.DefaultModule.customAmmoType = "white";
		((PickupObject)val).quality = (ItemQuality)4;
		Databases.Items.Add((PickupObject)(object)val, false, "ANY");
		ID = ((PickupObject)val).PickupObjectId;
	}
}
