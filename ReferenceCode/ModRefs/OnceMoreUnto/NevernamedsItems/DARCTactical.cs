using Alexandria.ItemAPI;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class DARCTactical : GunBehaviour
{
	public static int ID;

	public static void Add()
	{
		//IL_00d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_012a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0144: Unknown result type (might be due to invalid IL or missing references)
		//IL_0151: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d3: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("DARC Tactical", "darctactical");
		Game.Items.Rename("outdated_gun_mods:darc_tactical", "nn:arc_tactical+darc_tactical");
		((Component)val).gameObject.AddComponent<DARCTactical>();
		GunExt.SetShortDescription((PickupObject)(object)val, "Stormed Troopers");
		GunExt.SetLongDescription((PickupObject)(object)val, "This rapid firing weapon was designed by the ARC Private Security Company for dangerous field combat situations.\n\nIt has since become popular in completely different environments, namely the collections of tough guys who like having bigger guns than they need.");
		val.SetGunSprites("darctactical", 8, noAmmonomicon: true);
		GunExt.SetAnimationFPS(val, val.shootAnimation, 30);
		GunExt.SetAnimationFPS(val, val.reloadAnimation, 0);
		PickupObject byId = PickupObjectDatabase.GetById(DARCPistol.ID);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId is Gun) ? byId : null), true, false);
		ref string gunSwitchGroup = ref val.gunSwitchGroup;
		PickupObject byId2 = PickupObjectDatabase.GetById(153);
		gunSwitchGroup = ((Gun)((byId2 is Gun) ? byId2 : null)).gunSwitchGroup;
		ref VFXPool muzzleFlashEffects = ref val.muzzleFlashEffects;
		PickupObject byId3 = PickupObjectDatabase.GetById(41);
		muzzleFlashEffects = ((Gun)((byId3 is Gun) ? byId3 : null)).muzzleFlashEffects;
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.shootStyle = (ShootStyle)1;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 0.5f;
		val.DefaultModule.cooldownTime = 0.099f;
		val.DefaultModule.numberOfShotsInClip = 32;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(2.625f, 0.5f, 0f);
		val.SetBaseMaxAmmo(500);
		val.gunClass = (GunClass)10;
		val.DefaultModule.ammoType = (AmmoType)14;
		val.DefaultModule.customAmmoType = "DARC Bullets";
		Projectile val2 = Object.Instantiate<Projectile>(val.DefaultModule.projectiles[0]);
		((Component)val2).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val2).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val2);
		val.DefaultModule.projectiles[0] = val2;
		val2.baseData.damage = 4.8f;
		val2.baseData.force = 4f;
		((PickupObject)val).quality = (ItemQuality)(-100);
		Databases.Items.Add((PickupObject)(object)val, false, "ANY");
		ID = ((PickupObject)val).PickupObjectId;
	}
}
