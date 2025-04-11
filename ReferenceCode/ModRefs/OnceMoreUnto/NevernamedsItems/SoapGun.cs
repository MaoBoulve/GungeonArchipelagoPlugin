using System.Linq;
using Alexandria.Assetbundle;
using Alexandria.ItemAPI;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class SoapGun : AdvancedGunBehavior
{
	public static int ID;

	public static void Add()
	{
		//IL_011c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0124: Unknown result type (might be due to invalid IL or missing references)
		//IL_0232: Unknown result type (might be due to invalid IL or missing references)
		//IL_0248: Unknown result type (might be due to invalid IL or missing references)
		//IL_024f: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Soap Gun", "soapgun");
		Game.Items.Rename("outdated_gun_mods:soap_gun", "nn:soap_gun");
		((Component)val).gameObject.AddComponent<SoapGun>();
		GunExt.SetShortDescription((PickupObject)(object)val, "Rub a dub dub");
		GunExt.SetLongDescription((PickupObject)(object)val, "Launches a spray of light, airy, and delicate soap bubbles.\n\nUsed for class five cleaning emergencies, when approach is not an option.");
		GunInt.SetupSprite(val, Initialisation.gunCollection, "soapgun_idle_001", 8, "soapgun_ammonomicon_001");
		ref string gunSwitchGroup = ref val.gunSwitchGroup;
		PickupObject byId = PickupObjectDatabase.GetById(404);
		gunSwitchGroup = ((Gun)((byId is Gun) ? byId : null)).gunSwitchGroup;
		GunExt.SetAnimationFPS(val, val.shootAnimation, 15);
		GunExt.SetAnimationFPS(val, val.reloadAnimation, 13);
		GunExt.SetAnimationFPS(val, val.idleAnimation, 5);
		for (int i = 0; i < 4; i++)
		{
			PickupObject byId2 = PickupObjectDatabase.GetById(599);
			GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId2 is Gun) ? byId2 : null), true, false);
		}
		ref VFXPool muzzleFlashEffects = ref val.muzzleFlashEffects;
		PickupObject byId3 = PickupObjectDatabase.GetById(404);
		muzzleFlashEffects = ((Gun)((byId3 is Gun) ? byId3 : null)).muzzleFlashEffects;
		foreach (ProjectileModule projectile in val.Volley.projectiles)
		{
			projectile.ammoCost = 1;
			projectile.shootStyle = (ShootStyle)0;
			projectile.sequenceStyle = (ProjectileSequenceStyle)0;
			projectile.cooldownTime = 0.4f;
			projectile.angleVariance = 30f;
			projectile.numberOfShotsInClip = 3;
			for (int j = 0; j < projectile.projectiles.Count(); j++)
			{
				Projectile val2 = Object.Instantiate<Projectile>(projectile.projectiles[j]);
				projectile.projectiles[j] = val2;
				FakePrefabExtensions.MakeFakePrefab(((Component)val2).gameObject);
				ProjectileData baseData = val2.baseData;
				baseData.speed *= 3f;
				ProjectileData baseData2 = val2.baseData;
				baseData2.range *= 2f;
			}
			if (projectile != val.DefaultModule)
			{
				projectile.ammoCost = 0;
			}
		}
		val.reloadTime = 0.9f;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(1.4375f, 0.3125f, 0f);
		val.SetBaseMaxAmmo(100);
		val.gunClass = (GunClass)5;
		((PickupObject)val).quality = (ItemQuality)2;
		Databases.Items.Add(val, (tk2dSpriteCollectionData)null, "ANY");
		val.AddClipSprites("bubblefist");
		val.Volley.UsesShotgunStyleVelocityRandomizer = true;
		ID = ((PickupObject)val).PickupObjectId;
	}
}
