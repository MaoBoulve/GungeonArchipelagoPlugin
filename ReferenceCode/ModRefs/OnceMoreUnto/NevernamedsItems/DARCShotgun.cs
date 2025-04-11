using Alexandria.ItemAPI;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class DARCShotgun : AdvancedGunBehavior
{
	public static int ID;

	public static void Add()
	{
		//IL_0103: Unknown result type (might be due to invalid IL or missing references)
		//IL_010b: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0202: Unknown result type (might be due to invalid IL or missing references)
		//IL_020a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0229: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("DARC Shotgun", "darcshotgun");
		Game.Items.Rename("outdated_gun_mods:darc_shotgun", "nn:arc_shotgun+darc_shotgun");
		DARCShotgun dARCShotgun = ((Component)val).gameObject.AddComponent<DARCShotgun>();
		GunExt.SetShortDescription((PickupObject)(object)val, "Crack The Heavens");
		GunExt.SetLongDescription((PickupObject)(object)val, "Part of a short-lived campaign from the ARC Private Security Company to advertise their weaponry to the public as valuable home defence tools.\n\nAfter the fourth lawsuit from a disgruntled customer blasting their own legs off, ARC pulled the campaign.");
		val.SetGunSprites("darcshotgun", 8, noAmmonomicon: true);
		GunExt.SetAnimationFPS(val, val.shootAnimation, 13);
		GunExt.SetAnimationFPS(val, val.idleAnimation, 5);
		ref string gunSwitchGroup = ref val.gunSwitchGroup;
		PickupObject byId = PickupObjectDatabase.GetById(153);
		gunSwitchGroup = ((Gun)((byId is Gun) ? byId : null)).gunSwitchGroup;
		ref VFXPool muzzleFlashEffects = ref val.muzzleFlashEffects;
		PickupObject byId2 = PickupObjectDatabase.GetById(41);
		muzzleFlashEffects = ((Gun)((byId2 is Gun) ? byId2 : null)).muzzleFlashEffects;
		for (int i = 0; i < 6; i++)
		{
			PickupObject byId3 = PickupObjectDatabase.GetById(DARCPistol.ID);
			GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId3 is Gun) ? byId3 : null), true, false);
		}
		foreach (ProjectileModule projectile in val.Volley.projectiles)
		{
			projectile.ammoCost = 1;
			projectile.shootStyle = (ShootStyle)0;
			projectile.sequenceStyle = (ProjectileSequenceStyle)0;
			projectile.cooldownTime = 0.54f;
			projectile.angleVariance = 15f;
			projectile.numberOfShotsInClip = 10;
			Projectile val2 = Object.Instantiate<Projectile>(projectile.projectiles[0]);
			projectile.projectiles[0] = val2;
			((Component)val2).gameObject.SetActive(false);
			FakePrefab.MarkAsFakePrefab(((Component)val2).gameObject);
			Object.DontDestroyOnLoad((Object)(object)val2);
			val2.baseData.damage = 6f;
			if (projectile != val.DefaultModule)
			{
				projectile.ammoCost = 0;
			}
		}
		val.reloadTime = 1.8f;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(2.5f, 0.625f, 0f);
		val.SetBaseMaxAmmo(150);
		val.gunClass = (GunClass)5;
		((PickupObject)val).quality = (ItemQuality)(-100);
		Databases.Items.Add((PickupObject)(object)val, false, "ANY");
		val.DefaultModule.ammoType = (AmmoType)14;
		val.DefaultModule.customAmmoType = "DARC Bullets";
		val.Volley.UsesShotgunStyleVelocityRandomizer = true;
		ID = ((PickupObject)val).PickupObjectId;
	}
}
