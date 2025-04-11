using Alexandria.ItemAPI;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class GatlingGunGatterUp : AdvancedGunBehavior
{
	public static int GatGunID;

	public static void Add()
	{
		//IL_0096: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_012a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0132: Unknown result type (might be due to invalid IL or missing references)
		//IL_0211: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Gat Gun", "gatgun");
		Game.Items.Rename("outdated_gun_mods:gat_gun", "nn:gatling_gun+gatter_up");
		((Component)val).gameObject.AddComponent<GatlingGunGatterUp>();
		GunExt.SetShortDescription((PickupObject)(object)val, "oh dear");
		GunExt.SetLongDescription((PickupObject)(object)val, "a literal fucking gat");
		val.SetGunSprites("gatgun", 8, noAmmonomicon: true);
		GunExt.SetAnimationFPS(val, val.shootAnimation, 16);
		ref string gunSwitchGroup = ref val.gunSwitchGroup;
		PickupObject byId = PickupObjectDatabase.GetById(84);
		gunSwitchGroup = ((Gun)((byId is Gun) ? byId : null)).gunSwitchGroup;
		val.reloadTime = 1.5f;
		val.muzzleFlashEffects.type = (VFXPoolType)0;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(0.87f, 0.43f, 0f);
		val.SetBaseMaxAmmo(240);
		val.ammo = 240;
		for (int i = 0; i < 3; i++)
		{
			PickupObject byId2 = PickupObjectDatabase.GetById(84);
			GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId2 is Gun) ? byId2 : null), true, false);
		}
		foreach (ProjectileModule projectile in val.Volley.projectiles)
		{
			projectile.ammoCost = 1;
			projectile.shootStyle = (ShootStyle)1;
			projectile.sequenceStyle = (ProjectileSequenceStyle)0;
			projectile.cooldownTime = 0.25f;
			projectile.angleVariance = 5f;
			if (projectile != val.DefaultModule)
			{
				projectile.angleVariance = 25f;
			}
			projectile.numberOfShotsInClip = 16;
			Projectile val2 = Object.Instantiate<Projectile>(projectile.projectiles[0]);
			projectile.projectiles[0] = val2;
			((Component)val2).gameObject.SetActive(false);
			FakePrefab.MarkAsFakePrefab(((Component)val2).gameObject);
			Object.DontDestroyOnLoad((Object)(object)val2);
			if (projectile != val.DefaultModule)
			{
				projectile.ammoCost = 0;
			}
			((BraveBehaviour)val2).transform.parent = val.barrelOffset;
		}
		((PickupObject)val).quality = (ItemQuality)(-100);
		Databases.Items.Add(val, (tk2dSpriteCollectionData)null, "ANY");
		GunExt.SetName((PickupObject)(object)val, "Gatling Gun");
		GatGunID = ((PickupObject)val).PickupObjectId;
	}
}
