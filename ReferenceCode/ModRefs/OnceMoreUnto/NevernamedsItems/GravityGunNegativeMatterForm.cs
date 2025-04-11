using Alexandria.ItemAPI;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class GravityGunNegativeMatterForm : AdvancedGunBehavior
{
	public static int GravityGunNegativeMatterID;

	public static void Add()
	{
		//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_011b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0127: Unknown result type (might be due to invalid IL or missing references)
		//IL_016b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0182: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a9: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Dark Matter Grav Gun", "gravitygunnegativematter");
		Game.Items.Rename("outdated_gun_mods:dark_matter_grav_gun", "nn:gravity_gun+negative_matter");
		((Component)val).gameObject.AddComponent<GravityGunNegativeMatterForm>();
		GunExt.SetShortDescription((PickupObject)(object)val, "ding ding");
		GunExt.SetLongDescription((PickupObject)(object)val, "");
		val.SetGunSprites("gravitygunnegativematter", 8, noAmmonomicon: true);
		GunExt.SetAnimationFPS(val, val.shootAnimation, 25);
		ref string gunSwitchGroup = ref val.gunSwitchGroup;
		PickupObject byId = PickupObjectDatabase.GetById(562);
		gunSwitchGroup = ((Gun)((byId is Gun) ? byId : null)).gunSwitchGroup;
		PickupObject byId2 = PickupObjectDatabase.GetById(86);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId2 is Gun) ? byId2 : null), true, false);
		val.usesContinuousFireAnimation = true;
		((Component)val).GetComponent<tk2dSpriteAnimator>().GetClipByName(val.shootAnimation).wrapMode = (WrapMode)1;
		((Component)val).GetComponent<tk2dSpriteAnimator>().GetClipByName(val.shootAnimation).loopStart = 1;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(1.31f, 0.5f, 0f);
		val.SetBaseMaxAmmo(10000);
		val.ammo = 10000;
		val.doesScreenShake = false;
		val.DefaultModule.shootStyle = (ShootStyle)1;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.DefaultModule.cooldownTime = 0.1f;
		val.DefaultModule.numberOfShotsInClip = 10000;
		val.DefaultModule.angleVariance = 0f;
		val.InfiniteAmmo = true;
		val.DefaultModule.ammoType = (AmmoType)2;
		val.reloadTime = 0f;
		val.muzzleFlashEffects.type = (VFXPoolType)0;
		val.DefaultModule.ammoCost = 0;
		val.DefaultModule.projectiles[0] = null;
		((PickupObject)val).quality = (ItemQuality)(-100);
		Databases.Items.Add(val, (tk2dSpriteCollectionData)null, "ANY");
		GravityGunNegativeMatterID = ((PickupObject)val).PickupObjectId;
		GunExt.SetName((PickupObject)(object)val, "Gravity Gun");
	}
}
