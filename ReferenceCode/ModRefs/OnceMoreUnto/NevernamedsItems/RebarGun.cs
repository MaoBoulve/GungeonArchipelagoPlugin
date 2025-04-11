using System.Collections.Generic;
using Alexandria.Assetbundle;
using Alexandria.ItemAPI;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class RebarGun : AdvancedGunBehavior
{
	public static int RebarGunID;

	public static void Add()
	{
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_014c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0158: Unknown result type (might be due to invalid IL or missing references)
		//IL_019e: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_02aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d0: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Rebar Gun", "rebargun");
		Game.Items.Rename("outdated_gun_mods:rebar_gun", "nn:rebar_gun");
		((Component)val).gameObject.AddComponent<RebarGun>();
		GunExt.SetShortDescription((PickupObject)(object)val, "Raising the Bar");
		GunExt.SetLongDescription((PickupObject)(object)val, "An incredibly satisfying piece of industrial machinery, designed specifically for killing adorable wildlife.");
		GunInt.SetupSprite(val, Initialisation.gunCollection, "rebargun_idle_001", 8, "rebargun_ammonomicon_001");
		ref string gunSwitchGroup = ref val.gunSwitchGroup;
		PickupObject byId = PickupObjectDatabase.GetById(806);
		gunSwitchGroup = ((Gun)((byId is Gun) ? byId : null)).gunSwitchGroup;
		GunExt.SetAnimationFPS(val, val.shootAnimation, 16);
		PickupObject byId2 = PickupObjectDatabase.GetById(56);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId2 is Gun) ? byId2 : null), true, false);
		List<string> spritePaths = new List<string> { "NevernamedsItems/Resources/MiscVFX/GunVFX/RebarGunImpactVFX2_001", "NevernamedsItems/Resources/MiscVFX/GunVFX/RebarGunImpactVFX2_002", "NevernamedsItems/Resources/MiscVFX/GunVFX/RebarGunImpactVFX2_003", "NevernamedsItems/Resources/MiscVFX/GunVFX/RebarGunImpactVFX2_004", "NevernamedsItems/Resources/MiscVFX/GunVFX/RebarGunImpactVFX2_005", "NevernamedsItems/Resources/MiscVFX/GunVFX/RebarGunImpactVFX2_006" };
		VFXPool val2 = VFXToolbox.CreateVFXPool("Rebar Gun Impact VFX", spritePaths, 16, new IntVector2(11, 8), (Anchor)3, usesZHeight: false, 0f, persist: true, (VFXAlignment)1, -1f, null, (WrapMode)2);
		ref VFXPool muzzleFlashEffects = ref val.muzzleFlashEffects;
		PickupObject byId3 = PickupObjectDatabase.GetById(12);
		muzzleFlashEffects = ((Gun)((byId3 is Gun) ? byId3 : null)).muzzleFlashEffects;
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.shootStyle = (ShootStyle)0;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 1.21f;
		val.DefaultModule.cooldownTime = 0.3f;
		val.DefaultModule.numberOfShotsInClip = 3;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(1.5f, 0.87f, 0f);
		val.SetBaseMaxAmmo(170);
		val.gunClass = (GunClass)1;
		Projectile val3 = Object.Instantiate<Projectile>(val.DefaultModule.projectiles[0]);
		((Component)val3).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val3).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val3);
		val.DefaultModule.projectiles[0] = val3;
		((BraveBehaviour)val3).transform.parent = val.barrelOffset;
		GunTools.SetProjectileSpriteRight(val3, "rebargun_proj", 20, 2, false, (Anchor)4, (int?)6, (int?)2, true, false, (int?)null, (int?)null, (Projectile)null);
		ProjectileData baseData = val3.baseData;
		baseData.speed *= 4f;
		val3.baseData.damage = 20f;
		ProjectileData baseData2 = val3.baseData;
		baseData2.force *= 5f;
		val3.hitEffects.deathTileMapHorizontal = val2;
		val3.hitEffects.tileMapHorizontal = val2;
		val.DefaultModule.ammoType = (AmmoType)14;
		val.DefaultModule.customAmmoType = CustomClipAmmoTypeToolbox.AddCustomAmmoType("Rebar Shells", "NevernamedsItems/Resources/CustomGunAmmoTypes/rebargun_clipfull", "NevernamedsItems/Resources/CustomGunAmmoTypes/rebargun_clipempty");
		((PickupObject)val).quality = (ItemQuality)3;
		Databases.Items.Add(val, (tk2dSpriteCollectionData)null, "ANY");
		RebarGunID = ((PickupObject)val).PickupObjectId;
	}
}
