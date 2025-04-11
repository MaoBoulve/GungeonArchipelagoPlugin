using Alexandria.Assetbundle;
using Alexandria.ItemAPI;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class Jackhammer : AdvancedGunBehavior
{
	public static int ID;

	public static void Add()
	{
		//IL_0104: Unknown result type (might be due to invalid IL or missing references)
		//IL_010c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0202: Unknown result type (might be due to invalid IL or missing references)
		//IL_022c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0245: Unknown result type (might be due to invalid IL or missing references)
		//IL_024c: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Jackhammer", "jackhammer");
		Game.Items.Rename("outdated_gun_mods:jackhammer", "nn:jackhammer");
		((Component)val).gameObject.AddComponent<Jackhammer>();
		GunExt.SetShortDescription((PickupObject)(object)val, "A Better Way");
		GunExt.SetLongDescription((PickupObject)(object)val, "A fully automatic shotgun designed by a dissilusioned Gungeoneer.\n\nPump action is soooo last decade.");
		GunInt.SetupSprite(val, Initialisation.gunCollection, "jackhammer_idle_001", 8, "jackhammer_ammonomicon_001");
		ref string gunSwitchGroup = ref val.gunSwitchGroup;
		PickupObject byId = PickupObjectDatabase.GetById(98);
		gunSwitchGroup = ((Gun)((byId is Gun) ? byId : null)).gunSwitchGroup;
		GunExt.SetAnimationFPS(val, val.shootAnimation, 13);
		GunExt.SetAnimationFPS(val, val.idleAnimation, 5);
		ref VFXPool muzzleFlashEffects = ref val.muzzleFlashEffects;
		PickupObject byId2 = PickupObjectDatabase.GetById(23);
		muzzleFlashEffects = ((Gun)((byId2 is Gun) ? byId2 : null)).muzzleFlashEffects;
		for (int i = 0; i < 4; i++)
		{
			PickupObject byId3 = PickupObjectDatabase.GetById(86);
			GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId3 is Gun) ? byId3 : null), true, false);
		}
		foreach (ProjectileModule projectile in val.Volley.projectiles)
		{
			projectile.ammoCost = 1;
			projectile.shootStyle = (ShootStyle)1;
			projectile.sequenceStyle = (ProjectileSequenceStyle)0;
			projectile.cooldownTime = 0.15f;
			projectile.angleVariance = 10f;
			projectile.numberOfShotsInClip = 20;
			Projectile val2 = Object.Instantiate<Projectile>(projectile.projectiles[0]);
			projectile.projectiles[0] = val2;
			((Component)val2).gameObject.SetActive(false);
			FakePrefab.MarkAsFakePrefab(((Component)val2).gameObject);
			Object.DontDestroyOnLoad((Object)(object)val2);
			val2.AdditionalScaleMultiplier = 0.8f;
			val2.baseData.range = 15f;
			val2.baseData.damage = 4f;
			ProjectileData baseData = val2.baseData;
			baseData.force *= 0.5f;
			if (projectile != val.DefaultModule)
			{
				projectile.ammoCost = 0;
			}
		}
		val.DefaultModule.ammoType = (AmmoType)11;
		val.reloadTime = 1f;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(1.5625f, 0.375f, 0f);
		val.SetBaseMaxAmmo(350);
		val.gunClass = (GunClass)5;
		((PickupObject)val).quality = (ItemQuality)4;
		Databases.Items.Add(val, (tk2dSpriteCollectionData)null, "ANY");
		val.Volley.UsesShotgunStyleVelocityRandomizer = true;
		ID = ((PickupObject)val).PickupObjectId;
	}
}
