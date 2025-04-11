using System.Collections.Generic;
using Alexandria.ItemAPI;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class StasisRifle : AdvancedGunBehavior
{
	public static void Add()
	{
		//IL_008d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		//IL_0109: Unknown result type (might be due to invalid IL or missing references)
		//IL_0128: Unknown result type (might be due to invalid IL or missing references)
		//IL_014d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0293: Unknown result type (might be due to invalid IL or missing references)
		//IL_0298: Unknown result type (might be due to invalid IL or missing references)
		//IL_029f: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ac: Expected O, but got Unknown
		//IL_02cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e4: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Stasis Rifle", "stasisrifle");
		Game.Items.Rename("outdated_gun_mods:stasis_rifle", "nn:stasis_rifle");
		StasisRifle stasisRifle = ((Component)val).gameObject.AddComponent<StasisRifle>();
		GunExt.SetShortDescription((PickupObject)(object)val, "Hold Position");
		GunExt.SetLongDescription((PickupObject)(object)val, "Fires dangerous particle bolts that freeze time in a small radius around the impact site.\n\nWorks underwater.");
		val.SetGunSprites("stasisrifle");
		PickupObject byId = PickupObjectDatabase.GetById(56);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId is Gun) ? byId : null), true, false);
		val.DefaultModule.ammoCost = 1;
		val.doesScreenShake = true;
		val.DefaultModule.shootStyle = (ShootStyle)3;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 1f;
		val.DefaultModule.cooldownTime = 2f;
		val.DefaultModule.angleVariance = 0f;
		ref VFXPool muzzleFlashEffects = ref val.muzzleFlashEffects;
		PickupObject byId2 = PickupObjectDatabase.GetById(153);
		muzzleFlashEffects = ((Gun)((byId2 is Gun) ? byId2 : null)).muzzleFlashEffects;
		val.DefaultModule.numberOfShotsInClip = 1;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(2.68f, 0.56f, 0f);
		val.SetBaseMaxAmmo(35);
		val.ammo = 35;
		val.gunClass = (GunClass)60;
		GunExt.SetAnimationFPS(val, val.chargeAnimation, 8);
		((Component)val).GetComponent<tk2dSpriteAnimator>().GetClipByName(val.chargeAnimation).wrapMode = (WrapMode)1;
		((Component)val).GetComponent<tk2dSpriteAnimator>().GetClipByName(val.chargeAnimation).loopStart = 22;
		((Component)val).GetComponent<tk2dSpriteAnimator>().GetClipByName(val.shootAnimation).frames[0].eventAudio = "Play_WPN_energycannon_shot";
		((Component)val).GetComponent<tk2dSpriteAnimator>().GetClipByName(val.shootAnimation).frames[0].triggerEvent = true;
		Projectile val2 = Object.Instantiate<Projectile>(val.DefaultModule.projectiles[0]);
		((Component)val2).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val2).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val2);
		val2.baseData.damage = 17f;
		ProjectileData baseData = val2.baseData;
		baseData.force *= 0.5f;
		ProjectileData baseData2 = val2.baseData;
		baseData2.speed *= 2f;
		ProjectileData baseData3 = val2.baseData;
		baseData3.range *= 2f;
		val2.hitEffects.overrideMidairDeathVFX = SharedVFX.SmoothLightBlueLaserCircleVFX;
		val2.hitEffects.alwaysUseMidair = true;
		GunTools.SetProjectileSpriteRight(val2, "highvelocityrifle_projectile", 13, 5, true, (Anchor)4, (int?)11, (int?)4, true, false, (int?)null, (int?)null, (Projectile)null);
		FreezeTimeOnHitModifier orAddComponent = GameObjectExtensions.GetOrAddComponent<FreezeTimeOnHitModifier>(((Component)val2).gameObject);
		ChargeProjectile item = new ChargeProjectile
		{
			Projectile = val2,
			ChargeTime = 3f
		};
		val.DefaultModule.chargeProjectiles = new List<ChargeProjectile> { item };
		val.DefaultModule.ammoType = (AmmoType)14;
		val.DefaultModule.customAmmoType = "Toolgun Bullets";
		((PickupObject)val).quality = (ItemQuality)4;
		Databases.Items.Add(val, (tk2dSpriteCollectionData)null, "ANY");
	}
}
