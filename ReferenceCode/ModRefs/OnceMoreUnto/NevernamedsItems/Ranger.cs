using Alexandria.Assetbundle;
using Alexandria.ItemAPI;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class Ranger : AdvancedGunBehavior
{
	public static int RangerID;

	public static void Add()
	{
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0515: Unknown result type (might be due to invalid IL or missing references)
		//IL_051d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0750: Unknown result type (might be due to invalid IL or missing references)
		//IL_077b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0782: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Ranger", "ranger");
		Game.Items.Rename("outdated_gun_mods:ranger", "nn:ranger");
		Ranger ranger = ((Component)val).gameObject.AddComponent<Ranger>();
		GunExt.SetShortDescription((PickupObject)(object)val, "Shooting Range");
		GunExt.SetLongDescription((PickupObject)(object)val, "Fires an even range of bullets, starting high in damage at one end of the spread and incrementally decreasing towards the other.");
		GunInt.SetupSprite(val, Initialisation.gunCollection, "ranger_idle_001", 8, "ranger_ammonomicon_001");
		GunExt.SetAnimationFPS(val, val.shootAnimation, 15);
		((Component)val.barrelOffset).transform.localPosition = new Vector3(1.93f, 0.81f, 0f);
		for (int i = 0; i < 6; i++)
		{
			PickupObject byId = PickupObjectDatabase.GetById(86);
			GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId is Gun) ? byId : null), true, false);
		}
		float cooldownTime = 0.6f;
		int numberOfShotsInClip = 8;
		PickupObject byId2 = PickupObjectDatabase.GetById(86);
		Projectile val2 = Object.Instantiate<Projectile>(((Gun)((byId2 is Gun) ? byId2 : null)).DefaultModule.projectiles[0]);
		((Component)val2).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val2).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val2);
		ProjectileData baseData = val2.baseData;
		baseData.damage *= 4f;
		ProjectileData baseData2 = val2.baseData;
		baseData2.speed *= 0.65f;
		PickupObject byId3 = PickupObjectDatabase.GetById(86);
		Projectile val3 = Object.Instantiate<Projectile>(((Gun)((byId3 is Gun) ? byId3 : null)).DefaultModule.projectiles[0]);
		((Component)val3).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val3).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val3);
		ProjectileData baseData3 = val3.baseData;
		baseData3.damage *= 3.4f;
		ProjectileData baseData4 = val3.baseData;
		baseData4.speed *= 0.65f;
		PickupObject byId4 = PickupObjectDatabase.GetById(86);
		Projectile val4 = Object.Instantiate<Projectile>(((Gun)((byId4 is Gun) ? byId4 : null)).DefaultModule.projectiles[0]);
		((Component)val4).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val4).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val4);
		ProjectileData baseData5 = val4.baseData;
		baseData5.damage *= 2.8f;
		ProjectileData baseData6 = val4.baseData;
		baseData6.speed *= 0.65f;
		PickupObject byId5 = PickupObjectDatabase.GetById(86);
		Projectile val5 = Object.Instantiate<Projectile>(((Gun)((byId5 is Gun) ? byId5 : null)).DefaultModule.projectiles[0]);
		((Component)val5).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val5).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val5);
		ProjectileData baseData7 = val5.baseData;
		baseData7.damage *= 2.2f;
		ProjectileData baseData8 = val5.baseData;
		baseData8.speed *= 0.65f;
		PickupObject byId6 = PickupObjectDatabase.GetById(86);
		Projectile val6 = Object.Instantiate<Projectile>(((Gun)((byId6 is Gun) ? byId6 : null)).DefaultModule.projectiles[0]);
		((Component)val6).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val6).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val6);
		ProjectileData baseData9 = val6.baseData;
		baseData9.damage *= 1.6f;
		ProjectileData baseData10 = val6.baseData;
		baseData10.speed *= 0.65f;
		PickupObject byId7 = PickupObjectDatabase.GetById(86);
		Projectile val7 = Object.Instantiate<Projectile>(((Gun)((byId7 is Gun) ? byId7 : null)).DefaultModule.projectiles[0]);
		((Component)val7).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val7).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val7);
		ProjectileData baseData11 = val7.baseData;
		baseData11.damage *= 1f;
		ProjectileData baseData12 = val7.baseData;
		baseData12.speed *= 0.65f;
		GunTools.SetProjectileSpriteRight(val2, "rangerproj_1", 23, 23, true, (Anchor)4, (int?)20, (int?)20, true, false, (int?)null, (int?)null, (Projectile)null);
		GunTools.SetProjectileSpriteRight(val3, "rangerproj_2", 20, 20, true, (Anchor)4, (int?)17, (int?)17, true, false, (int?)null, (int?)null, (Projectile)null);
		GunTools.SetProjectileSpriteRight(val4, "rangerproj_3", 16, 16, true, (Anchor)4, (int?)13, (int?)13, true, false, (int?)null, (int?)null, (Projectile)null);
		GunTools.SetProjectileSpriteRight(val5, "rangerproj_4", 12, 12, true, (Anchor)4, (int?)11, (int?)11, true, false, (int?)null, (int?)null, (Projectile)null);
		GunTools.SetProjectileSpriteRight(val6, "rangerproj_5", 9, 9, true, (Anchor)4, (int?)8, (int?)8, true, false, (int?)null, (int?)null, (Projectile)null);
		GunTools.SetProjectileSpriteRight(val7, "rangerproj_6", 6, 6, true, (Anchor)4, (int?)6, (int?)6, true, false, (int?)null, (int?)null, (Projectile)null);
		int num = 0;
		foreach (ProjectileModule projectile in val.Volley.projectiles)
		{
			projectile.numberOfShotsInClip = numberOfShotsInClip;
			projectile.cooldownTime = cooldownTime;
			projectile.sequenceStyle = (ProjectileSequenceStyle)1;
			projectile.shootStyle = (ShootStyle)0;
			if (num <= 0)
			{
				projectile.ammoCost = 0;
				projectile.angleVariance = 0.01f;
				projectile.angleFromAim = 40f;
				projectile.projectiles[0] = val2;
				projectile.projectiles.Add(val7);
				num++;
			}
			else if (num == 1)
			{
				projectile.ammoCost = 1;
				projectile.angleVariance = 0.01f;
				projectile.angleFromAim = 24f;
				projectile.projectiles[0] = val3;
				projectile.projectiles.Add(val6);
				num++;
			}
			else if (num == 2)
			{
				projectile.ammoCost = 0;
				projectile.angleFromAim = 8f;
				projectile.angleVariance = 0.1f;
				projectile.projectiles[0] = val4;
				projectile.projectiles.Add(val5);
				num++;
			}
			else if (num == 3)
			{
				projectile.ammoCost = 0;
				projectile.angleFromAim = -8f;
				projectile.angleVariance = 0.1f;
				projectile.projectiles[0] = val5;
				projectile.projectiles.Add(val4);
				num++;
			}
			else if (num == 4)
			{
				projectile.ammoCost = 0;
				projectile.angleFromAim = -24f;
				projectile.angleVariance = 0.1f;
				projectile.projectiles[0] = val6;
				projectile.projectiles.Add(val3);
				num++;
			}
			else if (num >= 5)
			{
				projectile.ammoCost = 0;
				projectile.angleFromAim = -40f;
				projectile.angleVariance = 0.1f;
				projectile.projectiles[0] = val7;
				projectile.projectiles.Add(val2);
				num++;
			}
		}
		val.DefaultModule.ammoType = (AmmoType)14;
		val.DefaultModule.customAmmoType = "Justice Bullets";
		val.reloadTime = 1.4f;
		val.SetBaseMaxAmmo(100);
		val.gunClass = (GunClass)5;
		((PickupObject)val).quality = (ItemQuality)4;
		Databases.Items.Add(val, (tk2dSpriteCollectionData)null, "ANY");
		RangerID = ((PickupObject)val).PickupObjectId;
	}
}
