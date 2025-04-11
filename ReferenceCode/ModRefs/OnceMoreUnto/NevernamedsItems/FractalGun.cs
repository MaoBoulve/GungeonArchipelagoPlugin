using Alexandria.Assetbundle;
using Alexandria.ItemAPI;
using Alexandria.Misc;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class FractalGun : AdvancedGunBehavior
{
	public static int ID;

	public static void Add()
	{
		//IL_016f: Unknown result type (might be due to invalid IL or missing references)
		//IL_017b: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0201: Unknown result type (might be due to invalid IL or missing references)
		//IL_029c: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Fractal Gun", "fractalgun");
		Game.Items.Rename("outdated_gun_mods:fractal_gun", "nn:fractal_gun");
		FractalGun fractalGun = ((Component)val).gameObject.AddComponent<FractalGun>();
		((AdvancedGunBehavior)fractalGun).preventNormalFireAudio = true;
		((AdvancedGunBehavior)fractalGun).overrideNormalFireAudio = "Play_WPN_beretta_shot_01";
		GunExt.SetShortDescription((PickupObject)(object)val, "Spray and Spray");
		GunExt.SetLongDescription((PickupObject)(object)val, "This gun repeats infinitely along the Nth dimension.\n\nThis gun repeats infinitely along the Nth dimension.\n\nThis gun repeats infinitely along the Nth dimension.");
		((Component)val).GetComponent<tk2dSpriteAnimator>().GetClipByName(val.shootAnimation).frames[2].eventAudio = "Play_WPN_beretta_shot_01";
		((Component)val).GetComponent<tk2dSpriteAnimator>().GetClipByName(val.shootAnimation).frames[2].triggerEvent = true;
		((Component)val).GetComponent<tk2dSpriteAnimator>().GetClipByName(val.shootAnimation).frames[3].eventAudio = "Play_WPN_minigun_shot_01";
		((Component)val).GetComponent<tk2dSpriteAnimator>().GetClipByName(val.shootAnimation).frames[3].triggerEvent = true;
		((Component)val).GetComponent<tk2dSpriteAnimator>().GetClipByName(val.shootAnimation).frames[3].eventAudio = "Play_WPN_minigun_shot_01";
		((Component)val).GetComponent<tk2dSpriteAnimator>().GetClipByName(val.shootAnimation).frames[3].triggerEvent = true;
		GunInt.SetupSprite(val, Initialisation.gunCollection, "fractalgun_idle_001", 8, "fractalgun_ammonomicon_001");
		GunExt.SetAnimationFPS(val, val.shootAnimation, 12);
		PickupObject byId = PickupObjectDatabase.GetById(86);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId is Gun) ? byId : null), true, false);
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.shootStyle = (ShootStyle)0;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 0.76f;
		val.DefaultModule.cooldownTime = 0.3f;
		ref VFXPool muzzleFlashEffects = ref val.muzzleFlashEffects;
		PickupObject byId2 = PickupObjectDatabase.GetById(124);
		muzzleFlashEffects = ((Gun)((byId2 is Gun) ? byId2 : null)).muzzleFlashEffects;
		val.DefaultModule.numberOfShotsInClip = 3;
		val.DefaultModule.angleVariance = 12f;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(1.3125f, 0.8125f, 0f);
		val.SetBaseMaxAmmo(170);
		val.gunClass = (GunClass)1;
		Projectile val2 = ProjectileUtility.InstantiateAndFakeprefab(val.DefaultModule.projectiles[0]);
		val2.baseData.damage = 7.5f;
		ProjectileData baseData = val2.baseData;
		baseData.speed *= 0.7f;
		ProjectileData baseData2 = val2.baseData;
		baseData2.range *= 10f;
		ProjectileSplitController projectileSplitController = ((Component)val2).gameObject.AddComponent<ProjectileSplitController>();
		projectileSplitController.distanceTillSplit = 4f;
		projectileSplitController.amtToSplitTo = 3;
		projectileSplitController.maxRecursionAmount = 3;
		projectileSplitController.distanceBasedSplit = true;
		val.DefaultModule.projectiles[0] = val2;
		((PickupObject)val).quality = (ItemQuality)3;
		Databases.Items.Add(val, (tk2dSpriteCollectionData)null, "ANY");
		ID = ((PickupObject)val).PickupObjectId;
	}
}
