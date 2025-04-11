using Alexandria.Assetbundle;
using Alexandria.ItemAPI;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class Nocturne : AdvancedGunBehavior
{
	public static void Add()
	{
		//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0123: Unknown result type (might be due to invalid IL or missing references)
		//IL_0147: Unknown result type (might be due to invalid IL or missing references)
		//IL_02de: Unknown result type (might be due to invalid IL or missing references)
		//IL_0304: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Nocturne", "nocturne");
		Game.Items.Rename("outdated_gun_mods:nocturne", "nn:nocturne");
		((Component)val).gameObject.AddComponent<Nocturne>();
		GunExt.SetShortDescription((PickupObject)(object)val, "Welcome Back");
		GunExt.SetLongDescription((PickupObject)(object)val, "Alternates between faster purple blasts, and more damaging green blasts.\n\nThis gun was left in the Gungeon as one part of a great puzzle.\nUnfortunately, the seekers seem to have given up.");
		GunInt.SetupSprite(val, Initialisation.gunCollection, "nocturne_idle_001", 8, "nocturne_ammonomicon_001");
		GunExt.SetAnimationFPS(val, val.shootAnimation, 10);
		ref string gunSwitchGroup = ref val.gunSwitchGroup;
		PickupObject byId = PickupObjectDatabase.GetById(357);
		gunSwitchGroup = ((Gun)((byId is Gun) ? byId : null)).gunSwitchGroup;
		PickupObject byId2 = PickupObjectDatabase.GetById(86);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId2 is Gun) ? byId2 : null), true, false);
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.shootStyle = (ShootStyle)0;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)1;
		ref VFXPool muzzleFlashEffects = ref val.muzzleFlashEffects;
		PickupObject byId3 = PickupObjectDatabase.GetById(334);
		muzzleFlashEffects = ((Gun)((byId3 is Gun) ? byId3 : null)).muzzleFlashEffects;
		val.reloadTime = 1f;
		val.DefaultModule.cooldownTime = 0.1f;
		val.DefaultModule.numberOfShotsInClip = 6;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(1.75f, 0.87f, 0f);
		val.SetBaseMaxAmmo(200);
		val.ammo = 200;
		val.gunClass = (GunClass)1;
		Projectile val2 = Object.Instantiate<Projectile>(val.DefaultModule.projectiles[0]);
		((Component)val2).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val2).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val2);
		val2.baseData.damage = 9f;
		ProjectileData baseData = val2.baseData;
		baseData.speed *= 1.5f;
		val2.hitEffects.overrideMidairDeathVFX = SharedVFX.RedLaserCircleVFX;
		val2.hitEffects.alwaysUseMidair = true;
		GunTools.SetProjectileSpriteRight(val2, "nocturnepurple_projectile", 10, 10, true, (Anchor)4, (int?)8, (int?)8, true, false, (int?)null, (int?)null, (Projectile)null);
		PickupObject byId4 = PickupObjectDatabase.GetById(86);
		Projectile val3 = Object.Instantiate<Projectile>(((Gun)((byId4 is Gun) ? byId4 : null)).DefaultModule.projectiles[0]);
		((Component)val3).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val3).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val3);
		val3.baseData.damage = 15f;
		ProjectileData baseData2 = val3.baseData;
		baseData2.speed *= 0.5f;
		val3.hitEffects.overrideMidairDeathVFX = SharedVFX.GreenLaserCircleVFX;
		val3.hitEffects.alwaysUseMidair = true;
		GunTools.SetProjectileSpriteRight(val3, "nocturnegreen_projectile", 10, 10, true, (Anchor)4, (int?)8, (int?)8, true, false, (int?)null, (int?)null, (Projectile)null);
		val.DefaultModule.projectiles[0] = val2;
		val.DefaultModule.projectiles.Add(val3);
		val.DefaultModule.ammoType = (AmmoType)14;
		val.DefaultModule.customAmmoType = CustomClipAmmoTypeToolbox.AddCustomAmmoType("Nocturne Bullets", "NevernamedsItems/Resources/CustomGunAmmoTypes/nocturne_clipfull", "NevernamedsItems/Resources/CustomGunAmmoTypes/nocturne_clipempty");
		((PickupObject)val).quality = (ItemQuality)3;
		Databases.Items.Add(val, (tk2dSpriteCollectionData)null, "ANY");
	}
}
