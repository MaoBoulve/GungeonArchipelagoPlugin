using System.Collections.Generic;
using Alexandria.ItemAPI;
using Alexandria.Misc;
using Alexandria.VisualAPI;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class ServiceWeaponPierce : AdvancedGunBehavior
{
	public static int ID;

	public static void Add()
	{
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0110: Unknown result type (might be due to invalid IL or missing references)
		//IL_0186: Unknown result type (might be due to invalid IL or missing references)
		//IL_0192: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0303: Unknown result type (might be due to invalid IL or missing references)
		//IL_0308: Unknown result type (might be due to invalid IL or missing references)
		//IL_0333: Unknown result type (might be due to invalid IL or missing references)
		//IL_0338: Unknown result type (might be due to invalid IL or missing references)
		//IL_033f: Unknown result type (might be due to invalid IL or missing references)
		//IL_034c: Expected O, but got Unknown
		//IL_036d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0385: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Pierce", "serviceweaponpierce");
		Game.Items.Rename("outdated_gun_mods:pierce", "nn:service_weapon+pierce");
		((Component)val).gameObject.AddComponent<ServiceWeaponPierce>();
		GunExt.SetShortDescription((PickupObject)(object)val, "");
		GunExt.SetLongDescription((PickupObject)(object)val, "");
		val.SetGunSprites("serviceweaponpierce", 8, noAmmonomicon: true);
		GunExt.SetAnimationFPS(val, val.shootAnimation, 12);
		GunExt.SetAnimationFPS(val, val.reloadAnimation, 12);
		GunExt.SetAnimationFPS(val, val.chargeAnimation, 7);
		ref string gunSwitchGroup = ref val.gunSwitchGroup;
		PickupObject byId = PickupObjectDatabase.GetById(124);
		gunSwitchGroup = ((Gun)((byId is Gun) ? byId : null)).gunSwitchGroup;
		ref VFXPool muzzleFlashEffects = ref val.muzzleFlashEffects;
		PickupObject byId2 = PickupObjectDatabase.GetById(362);
		muzzleFlashEffects = ((Gun)((byId2 is Gun) ? byId2 : null)).muzzleFlashEffects;
		PickupObject byId3 = PickupObjectDatabase.GetById(56);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId3 is Gun) ? byId3 : null), true, false);
		((Component)val).GetComponent<tk2dSpriteAnimator>().GetClipByName(val.reloadAnimation).wrapMode = (WrapMode)1;
		((Component)val).GetComponent<tk2dSpriteAnimator>().GetClipByName(val.reloadAnimation).loopStart = 3;
		((Component)val).GetComponent<tk2dSpriteAnimator>().GetClipByName(val.chargeAnimation).wrapMode = (WrapMode)1;
		((Component)val).GetComponent<tk2dSpriteAnimator>().GetClipByName(val.chargeAnimation).loopStart = 7;
		((Component)val).GetComponent<tk2dSpriteAnimator>().GetClipByName(val.shootAnimation).frames[0].eventAudio = "Play_wpn_chargelaser_shot_01";
		((Component)val).GetComponent<tk2dSpriteAnimator>().GetClipByName(val.shootAnimation).frames[0].triggerEvent = true;
		val.usesContinuousFireAnimation = true;
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.shootStyle = (ShootStyle)3;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 1f;
		val.DefaultModule.cooldownTime = 0.1f;
		val.DefaultModule.numberOfShotsInClip = -1;
		val.DefaultModule.angleVariance = 0f;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(2.0625f, 1f, 0f);
		val.SetBaseMaxAmmo(2);
		val.gunClass = (GunClass)60;
		Projectile val2 = ProjectileUtility.InstantiateAndFakeprefab(val.DefaultModule.projectiles[0]);
		val.DefaultModule.projectiles[0] = val2;
		val2.baseData.damage = 70f;
		ProjectileData baseData = val2.baseData;
		baseData.speed *= 4f;
		val2.SetProjectileSprite("serviceweaponpierce_proj", 24, 13, lightened: true, (Anchor)4, 20, 10, anchorChangesCollider: true, fixesScale: false, null, null);
		ref ProjectileImpactVFXPool hitEffects = ref val2.hitEffects;
		PickupObject byId4 = PickupObjectDatabase.GetById(328);
		hitEffects = ((Gun)((byId4 is Gun) ? byId4 : null)).DefaultModule.chargeProjectiles[0].Projectile.hitEffects;
		ImprovedAfterImage val3 = ((Component)val2).gameObject.AddComponent<ImprovedAfterImage>();
		val3.spawnShadows = true;
		val3.shadowLifetime = Random.Range(0.1f, 0.2f);
		val3.shadowTimeDelay = 0.001f;
		val3.dashColor = new Color(1f, 0.8f, 0.55f, 0.3f);
		((Object)val3).name = "Gun Trail";
		PierceProjModifier val4 = ((Component)val2).gameObject.AddComponent<PierceProjModifier>();
		val4.penetration = 1;
		val2.PenetratesInternalWalls = true;
		ChargeProjectile item = new ChargeProjectile
		{
			Projectile = val2,
			ChargeTime = 1f
		};
		val.DefaultModule.chargeProjectiles = new List<ChargeProjectile> { item };
		val.DefaultModule.ammoType = (AmmoType)14;
		val.DefaultModule.customAmmoType = "Service Weapon Bullets";
		((PickupObject)val).quality = (ItemQuality)(-100);
		Databases.Items.Add(val, (tk2dSpriteCollectionData)null, "ANY");
		ID = ((PickupObject)val).PickupObjectId;
	}
}
