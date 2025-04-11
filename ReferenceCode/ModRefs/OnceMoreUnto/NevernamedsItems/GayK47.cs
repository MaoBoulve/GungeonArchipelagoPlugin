using Alexandria.ItemAPI;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class GayK47 : AdvancedGunBehavior
{
	public static int GayK47ID;

	public static void Add()
	{
		//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_013b: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0219: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("GayK-47", "gayk47");
		Game.Items.Rename("outdated_gun_mods:gayk47", "nn:gayk47");
		((Component)val).gameObject.AddComponent<GayK47>();
		GunExt.SetShortDescription((PickupObject)(object)val, "Somewhere");
		GunExt.SetLongDescription((PickupObject)(object)val, "This shiny AK comes in all types of colours.\n\nThinks that the Machine Pistol is cute, but is too embarrassed to say anything.");
		val.SetGunSprites("gayk47");
		GunExt.SetAnimationFPS(val, val.shootAnimation, 12);
		ref string gunSwitchGroup = ref val.gunSwitchGroup;
		PickupObject byId = PickupObjectDatabase.GetById(15);
		gunSwitchGroup = ((Gun)((byId is Gun) ? byId : null)).gunSwitchGroup;
		PickupObject byId2 = PickupObjectDatabase.GetById(86);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId2 is Gun) ? byId2 : null), true, false);
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.shootStyle = (ShootStyle)1;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 1f;
		val.DefaultModule.cooldownTime = 0.15f;
		val.DefaultModule.numberOfShotsInClip = 20;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(2.25f, 0.5f, 0f);
		ref VFXPool muzzleFlashEffects = ref val.muzzleFlashEffects;
		PickupObject byId3 = PickupObjectDatabase.GetById(15);
		muzzleFlashEffects = ((Gun)((byId3 is Gun) ? byId3 : null)).muzzleFlashEffects;
		val.SetBaseMaxAmmo(400);
		val.ammo = 400;
		val.gunClass = (GunClass)50;
		ref ScreenShakeSettings gunScreenShake = ref val.gunScreenShake;
		PickupObject byId4 = PickupObjectDatabase.GetById(15);
		gunScreenShake = ((Gun)((byId4 is Gun) ? byId4 : null)).gunScreenShake;
		Projectile val2 = Object.Instantiate<Projectile>(val.DefaultModule.projectiles[0]);
		((Component)val2).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val2).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val2);
		val.DefaultModule.projectiles[0] = val2;
		val2.baseData.damage = 6f;
		ProjectileData baseData = val2.baseData;
		baseData.speed *= 1f;
		ProjectileData baseData2 = val2.baseData;
		baseData2.range *= 2f;
		((Component)val2).gameObject.AddComponent<GayK47Mod>();
		val.DefaultModule.ammoType = (AmmoType)14;
		val.DefaultModule.customAmmoType = CustomClipAmmoTypeToolbox.AddCustomAmmoType("Gayk47 Bullets", "NevernamedsItems/Resources/CustomGunAmmoTypes/gayk47_clipfull", "NevernamedsItems/Resources/CustomGunAmmoTypes/gayk47_clipempty");
		((PickupObject)val).quality = (ItemQuality)4;
		Databases.Items.Add((PickupObject)(object)val, false, "ANY");
		AlexandriaTags.SetTag((PickupObject)(object)val, "kalashnikov");
		GayK47ID = ((PickupObject)val).PickupObjectId;
	}

	public override void PostProcessProjectile(Projectile projectile)
	{
		((AdvancedGunBehavior)this).PostProcessProjectile(projectile);
	}
}
