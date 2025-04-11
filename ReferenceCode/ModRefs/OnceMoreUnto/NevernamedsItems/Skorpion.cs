using Alexandria.ItemAPI;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class Skorpion : AdvancedGunBehavior
{
	public static int ID;

	public static void Add()
	{
		//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_010f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0134: Unknown result type (might be due to invalid IL or missing references)
		//IL_019a: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a1: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Skorpion", "skorpion");
		Game.Items.Rename("outdated_gun_mods:skorpion", "nn:skorpion");
		((Component)val).gameObject.AddComponent<Skorpion>();
		GunExt.SetShortDescription((PickupObject)(object)val, "Model 59");
		GunExt.SetLongDescription((PickupObject)(object)val, "A military sidearm most notable for not actually incorporating scorpions at any stage during construction.");
		val.SetGunSprites("skorpion");
		GunExt.SetAnimationFPS(val, val.shootAnimation, 12);
		PickupObject byId = PickupObjectDatabase.GetById(86);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId is Gun) ? byId : null), true, false);
		ref VFXPool muzzleFlashEffects = ref val.muzzleFlashEffects;
		PickupObject byId2 = PickupObjectDatabase.GetById(23);
		muzzleFlashEffects = ((Gun)((byId2 is Gun) ? byId2 : null)).muzzleFlashEffects;
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.shootStyle = (ShootStyle)1;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 1.4f;
		val.DefaultModule.cooldownTime = 0.06f;
		val.DefaultModule.numberOfShotsInClip = 45;
		val.DefaultModule.angleVariance = 10f;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(2.625f, 0.8125f, 0f);
		val.SetBaseMaxAmmo(660);
		val.ammo = 660;
		val.gunClass = (GunClass)10;
		Projectile val2 = Object.Instantiate<Projectile>(val.DefaultModule.projectiles[0]);
		((Component)val2).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val2).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val2);
		val.DefaultModule.projectiles[0] = val2;
		val2.baseData.damage = 4f;
		val.DefaultModule.ammoType = (AmmoType)0;
		((PickupObject)val).quality = (ItemQuality)2;
		Databases.Items.Add((PickupObject)(object)val, false, "ANY");
		AdvancedFireOnReloadSynergyProcessor val3 = ((Component)val).gameObject.AddComponent<AdvancedFireOnReloadSynergyProcessor>();
		val3.synergyToCheck = "Skorpion Sting";
		val3.angleVariance = 5f;
		val3.numToFire = 1;
		ref Projectile projToFire = ref val3.projToFire;
		PickupObject byId3 = PickupObjectDatabase.GetById(406);
		projToFire = ((Gun)((byId3 is Gun) ? byId3 : null)).Volley.projectiles[1].projectiles[0];
		ItemBuilder.AddToSubShop((PickupObject)(object)val, (ShopType)3, 1f);
		ID = ((PickupObject)val).PickupObjectId;
	}
}
