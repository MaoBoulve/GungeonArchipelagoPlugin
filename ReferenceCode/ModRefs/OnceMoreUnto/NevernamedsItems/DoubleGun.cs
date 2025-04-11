using Alexandria.Assetbundle;
using Alexandria.ItemAPI;
using Alexandria.Misc;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class DoubleGun : AdvancedGunBehavior
{
	public static int DoubleGunID;

	public static void Add()
	{
		//IL_0116: Unknown result type (might be due to invalid IL or missing references)
		//IL_011e: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_022c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0275: Unknown result type (might be due to invalid IL or missing references)
		//IL_028e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0295: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Double Gun", "doublegun");
		Game.Items.Rename("outdated_gun_mods:double_gun", "nn:double_gun");
		((Component)val).gameObject.AddComponent<DoubleGun>();
		GunExt.SetShortDescription((PickupObject)(object)val, "Better Than One");
		GunExt.SetLongDescription((PickupObject)(object)val, "The result of a one night stand between a shotgun and a revolver. Fires two shots at once.");
		GunInt.SetupSprite(val, Initialisation.gunCollection, "doublegun_idle_001", 8, "doublegun_ammonomicon_001");
		ref string gunSwitchGroup = ref val.gunSwitchGroup;
		PickupObject byId = PickupObjectDatabase.GetById(51);
		gunSwitchGroup = ((Gun)((byId is Gun) ? byId : null)).gunSwitchGroup;
		GunExt.SetAnimationFPS(val, val.shootAnimation, 15);
		GunExt.SetAnimationFPS(val, val.reloadAnimation, 13);
		GunExt.SetAnimationFPS(val, val.idleAnimation, 5);
		for (int i = 0; i < 2; i++)
		{
			PickupObject byId2 = PickupObjectDatabase.GetById(181);
			GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId2 is Gun) ? byId2 : null), true, false);
		}
		ref VFXPool muzzleFlashEffects = ref val.muzzleFlashEffects;
		PickupObject byId3 = PickupObjectDatabase.GetById(23);
		muzzleFlashEffects = ((Gun)((byId3 is Gun) ? byId3 : null)).muzzleFlashEffects;
		foreach (ProjectileModule projectile in val.Volley.projectiles)
		{
			projectile.ammoCost = 1;
			projectile.shootStyle = (ShootStyle)0;
			projectile.sequenceStyle = (ProjectileSequenceStyle)0;
			projectile.cooldownTime = 0.25f;
			projectile.angleVariance = 1f;
			projectile.numberOfShotsInClip = 3;
			Projectile val2 = Object.Instantiate<Projectile>(projectile.projectiles[0]);
			projectile.projectiles[0] = val2;
			((Component)val2).gameObject.SetActive(false);
			FakePrefab.MarkAsFakePrefab(((Component)val2).gameObject);
			Object.DontDestroyOnLoad((Object)(object)val2);
			val2.baseData.damage = 7.5f;
			ProjectileData baseData = val2.baseData;
			baseData.speed *= 0.7f;
			projectile.positionOffset = Vector2.op_Implicit(new Vector2(0f, -0.3f));
			if (projectile != val.DefaultModule)
			{
				projectile.positionOffset = Vector2.op_Implicit(new Vector2(0f, 0.3f));
				projectile.ammoCost = 0;
			}
		}
		val.DefaultModule.ammoType = (AmmoType)14;
		val.DefaultModule.customAmmoType = CustomClipAmmoTypeToolbox.AddCustomAmmoType("DoubleGun Ammo", "NevernamedsItems/Resources/CustomGunAmmoTypes/doublegun_clipfull", "NevernamedsItems/Resources/CustomGunAmmoTypes/doublegun_clipempty");
		val.reloadTime = 1f;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(1.43f, 0.87f, 0f);
		val.SetBaseMaxAmmo(200);
		val.gunClass = (GunClass)1;
		((PickupObject)val).quality = (ItemQuality)1;
		Databases.Items.Add(val, (tk2dSpriteCollectionData)null, "ANY");
		DoubleGunID = ((PickupObject)val).PickupObjectId;
	}

	public override void PostProcessProjectile(Projectile projectile)
	{
		if (Object.op_Implicit((Object)(object)projectile) && Object.op_Implicit((Object)(object)ProjectileUtility.ProjectilePlayerOwner(projectile)) && CustomSynergies.PlayerHasActiveSynergy(ProjectileUtility.ProjectilePlayerOwner(projectile), "Double Or Nothing") && ProjectileUtility.ProjectilePlayerOwner(projectile).HasPickupID(168))
		{
			bool flag = true;
			foreach (PlayerItem activeItem in ProjectileUtility.ProjectilePlayerOwner(projectile).activeItems)
			{
				if (((PickupObject)activeItem).PickupObjectId == 168 && activeItem.IsCurrentlyActive)
				{
					flag = false;
				}
			}
			if (flag)
			{
				ProjectileData baseData = projectile.baseData;
				baseData.damage *= 0f;
				projectile.AdditionalScaleMultiplier *= 0.1f;
			}
			else
			{
				projectile.AdditionalScaleMultiplier *= 1.2f;
				ProjectileData baseData2 = projectile.baseData;
				baseData2.damage *= 2f;
			}
		}
		((AdvancedGunBehavior)this).PostProcessProjectile(projectile);
	}
}
