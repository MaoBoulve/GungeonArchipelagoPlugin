using System.Collections.Generic;
using Alexandria.Assetbundle;
using Alexandria.ItemAPI;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class EmberCannon : AdvancedGunBehavior
{
	public static int EmberCannonID;

	public static void Add()
	{
		//IL_00f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_011b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0175: Unknown result type (might be due to invalid IL or missing references)
		//IL_017d: Unknown result type (might be due to invalid IL or missing references)
		//IL_023c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0241: Unknown result type (might be due to invalid IL or missing references)
		//IL_0249: Unknown result type (might be due to invalid IL or missing references)
		//IL_0256: Expected O, but got Unknown
		//IL_02af: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f9: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Ember Cannon", "embercannon");
		Game.Items.Rename("outdated_gun_mods:ember_cannon", "nn:ember_cannon");
		EmberCannon emberCannon = ((Component)val).gameObject.AddComponent<EmberCannon>();
		((AdvancedGunBehavior)emberCannon).preventNormalFireAudio = true;
		((AdvancedGunBehavior)emberCannon).preventNormalReloadAudio = true;
		((AdvancedGunBehavior)emberCannon).overrideNormalReloadAudio = "Play_ENM_flame_veil_01";
		GunExt.SetShortDescription((PickupObject)(object)val, "Burns Eternal");
		GunExt.SetLongDescription((PickupObject)(object)val, "This mighty furnace was created to warm a group of hopeless souls trapped in the freezing hollow.\n\nThough it no longer burns with it's ancient ferocity, it has not yet run cold in a thousand years.");
		GunInt.SetupSprite(val, Initialisation.gunCollection, "embercannon_idle_001", 8, "embercannon_ammonomicon_001");
		((Component)val).GetComponent<tk2dSpriteAnimator>().GetClipByName(val.shootAnimation).frames[0].eventAudio = "Play_WPN_seriouscannon_shot_01";
		((Component)val).GetComponent<tk2dSpriteAnimator>().GetClipByName(val.shootAnimation).frames[0].triggerEvent = true;
		ref VFXPool muzzleFlashEffects = ref val.muzzleFlashEffects;
		PickupObject byId = PickupObjectDatabase.GetById(37);
		muzzleFlashEffects = ((Gun)((byId is Gun) ? byId : null)).muzzleFlashEffects;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(1.93f, 0.87f, 0f);
		GunExt.SetAnimationFPS(val, val.shootAnimation, 10);
		GunExt.SetAnimationFPS(val, val.chargeAnimation, 8);
		val.gunClass = (GunClass)60;
		for (int i = 0; i < 10; i++)
		{
			PickupObject byId2 = PickupObjectDatabase.GetById(83);
			GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId2 is Gun) ? byId2 : null), true, false);
		}
		foreach (ProjectileModule projectile in val.Volley.projectiles)
		{
			projectile.ammoCost = 1;
			projectile.shootStyle = (ShootStyle)3;
			projectile.sequenceStyle = (ProjectileSequenceStyle)0;
			projectile.cooldownTime = 0.7f;
			projectile.angleVariance = 20f;
			projectile.numberOfShotsInClip = 3;
			Projectile val2 = Object.Instantiate<Projectile>(projectile.projectiles[0]);
			projectile.projectiles[0] = val2;
			((Component)val2).gameObject.SetActive(false);
			FakePrefab.MarkAsFakePrefab(((Component)val2).gameObject);
			Object.DontDestroyOnLoad((Object)(object)val2);
			RandomProjectileStatsComponent randomProjectileStatsComponent = ((Component)val2).gameObject.AddComponent<RandomProjectileStatsComponent>();
			randomProjectileStatsComponent.randomDamage = true;
			randomProjectileStatsComponent.randomSpeed = true;
			randomProjectileStatsComponent.randomRange = true;
			randomProjectileStatsComponent.randomKnockback = true;
			randomProjectileStatsComponent.scaleBasedOnDamage = true;
			if (projectile != val.DefaultModule)
			{
				projectile.ammoCost = 0;
			}
			ChargeProjectile item = new ChargeProjectile
			{
				Projectile = val2,
				ChargeTime = 0.5f
			};
			projectile.chargeProjectiles = new List<ChargeProjectile> { item };
		}
		val.reloadTime = 1f;
		val.SetBaseMaxAmmo(100);
		((Component)val).GetComponent<tk2dSpriteAnimator>().GetClipByName(val.chargeAnimation).wrapMode = (WrapMode)1;
		((Component)val).GetComponent<tk2dSpriteAnimator>().GetClipByName(val.chargeAnimation).loopStart = 2;
		val.DefaultModule.ammoType = (AmmoType)14;
		val.DefaultModule.customAmmoType = CustomClipAmmoTypeToolbox.AddCustomAmmoType("Ember Cannon Ammo", "NevernamedsItems/Resources/CustomGunAmmoTypes/embercannon_clipfull", "NevernamedsItems/Resources/CustomGunAmmoTypes/embercannon_clipempty");
		((PickupObject)val).quality = (ItemQuality)3;
		Databases.Items.Add(val, (tk2dSpriteCollectionData)null, "ANY");
		EmberCannonID = ((PickupObject)val).PickupObjectId;
	}

	protected override void Update()
	{
		((AdvancedGunBehavior)this).Update();
	}
}
