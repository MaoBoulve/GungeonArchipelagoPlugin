using Alexandria.ItemAPI;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class Gravitron : AdvancedGunBehavior
{
	public static int GravitronID;

	public static void Add()
	{
		//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0119: Unknown result type (might be due to invalid IL or missing references)
		//IL_013e: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_0225: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Gravitron", "gravitron");
		Game.Items.Rename("outdated_gun_mods:gravitron", "nn:gravitron");
		((Component)val).gameObject.AddComponent<Gravitron>();
		GunExt.SetShortDescription((PickupObject)(object)val, "Outstanding In It's Field");
		GunExt.SetLongDescription((PickupObject)(object)val, "Bullets orbit enemies.\n\nMilitary adaptation of orbtial projectile technology, these bullets are clever enough to latch onto the target instead of their owner.");
		val.SetGunSprites("gravitron");
		GunExt.SetAnimationFPS(val, val.shootAnimation, 10);
		ref string gunSwitchGroup = ref val.gunSwitchGroup;
		PickupObject byId = PickupObjectDatabase.GetById(13);
		gunSwitchGroup = ((Gun)((byId is Gun) ? byId : null)).gunSwitchGroup;
		PickupObject byId2 = PickupObjectDatabase.GetById(86);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId2 is Gun) ? byId2 : null), true, false);
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.shootStyle = (ShootStyle)1;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 1.1f;
		ref VFXPool muzzleFlashEffects = ref val.muzzleFlashEffects;
		PickupObject byId3 = PickupObjectDatabase.GetById(334);
		muzzleFlashEffects = ((Gun)((byId3 is Gun) ? byId3 : null)).muzzleFlashEffects;
		val.DefaultModule.cooldownTime = 0.2f;
		val.DefaultModule.numberOfShotsInClip = 25;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(2.12f, 0.56f, 0f);
		val.SetBaseMaxAmmo(360);
		val.ammo = 360;
		val.gunClass = (GunClass)10;
		Projectile val2 = Object.Instantiate<Projectile>(val.DefaultModule.projectiles[0]);
		((Component)val2).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val2).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val2);
		ProjectileData baseData = val2.baseData;
		baseData.range *= 2f;
		GravitronBulletsBehaviour orAddComponent = GameObjectExtensions.GetOrAddComponent<GravitronBulletsBehaviour>(((Component)val2).gameObject);
		orAddComponent.maxOrbitalRadius = 6f;
		orAddComponent.minOrbitalRadius = 3.5f;
		GunTools.SetProjectileSpriteRight(val2, "gravitron_projectile", 7, 7, true, (Anchor)4, (int?)6, (int?)6, true, false, (int?)null, (int?)null, (Projectile)null);
		val.DefaultModule.ammoType = (AmmoType)14;
		val.DefaultModule.customAmmoType = CustomClipAmmoTypeToolbox.AddCustomAmmoType("Gravitron Bullets", "NevernamedsItems/Resources/CustomGunAmmoTypes/gravitron_clipfull", "NevernamedsItems/Resources/CustomGunAmmoTypes/gravitron_clipempty");
		val.DefaultModule.projectiles[0] = val2;
		((PickupObject)val).quality = (ItemQuality)3;
		Databases.Items.Add(val, (tk2dSpriteCollectionData)null, "ANY");
		GravitronID = ((PickupObject)val).PickupObjectId;
	}
}
