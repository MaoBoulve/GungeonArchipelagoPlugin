using Alexandria.Assetbundle;
using Alexandria.ItemAPI;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class IrregularShotgun : GunBehaviour
{
	public static int ID;

	public static void Add()
	{
		//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_0114: Unknown result type (might be due to invalid IL or missing references)
		//IL_012a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0270: Unknown result type (might be due to invalid IL or missing references)
		//IL_0296: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Irregular Shotgun", "irregularshotgun");
		Game.Items.Rename("outdated_gun_mods:irregular_shotgun", "nn:irregular_shotgun");
		((Component)val).gameObject.AddComponent<IrregularShotgun>();
		GunExt.SetShortDescription((PickupObject)(object)val, "weo8onerco;ma8437465");
		GunExt.SetLongDescription((PickupObject)(object)val, "This shotgun has seen the void, andddddddddddddddddddddfdfd 9d8dy73287675246c53xydf56ui87no8mp9,ufdauhjkds8888888888888");
		GunInt.SetupSprite(val, Initialisation.gunCollection, "irregularshotgun_idle_001", 8, "irregularshotgun_ammonomicon_001");
		GunExt.SetAnimationFPS(val, val.shootAnimation, 13);
		GunExt.SetAnimationFPS(val, val.reloadAnimation, 7);
		PickupObject byId = PickupObjectDatabase.GetById(35);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId is Gun) ? byId : null), true, false);
		ref string gunSwitchGroup = ref val.gunSwitchGroup;
		PickupObject byId2 = PickupObjectDatabase.GetById(93);
		gunSwitchGroup = ((Gun)((byId2 is Gun) ? byId2 : null)).gunSwitchGroup;
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.shootStyle = (ShootStyle)0;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 1.1837736f;
		val.DefaultModule.cooldownTime = 0.55224645f;
		val.DefaultModule.numberOfShotsInClip = 7;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(2.625f, 0.75f, 0f);
		val.SetBaseMaxAmmo(127);
		val.gunClass = (GunClass)5;
		Projectile val2 = Object.Instantiate<Projectile>(val.DefaultModule.projectiles[0]);
		((Component)val2).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val2).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val2);
		val2.baseData.damage = 40f;
		val2.AdditionalScaleMultiplier = 1.2f;
		Projectile val3 = Object.Instantiate<Projectile>(val2);
		((Component)val3).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val3).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val3);
		val.DefaultModule.projectiles[0] = val3;
		AddProj(2, val, val2, 0.5f, 0.95f);
		AddProj(3, val, val2, 0.33f, 0.9f);
		AddProj(4, val, val2, 0.25f, 0.85f);
		AddProj(5, val, val2, 0.2f, 0.8f);
		AddProj(6, val, val2, 0.166f, 0.75f);
		AddProj(7, val, val2, 0.1428f, 0.7f);
		AddProj(8, val, val2, 0.125f, 0.65f);
		AddProj(9, val, val2, 0.1111f, 0.6f);
		AddProj(10, val, val2, 0.1f, 0.55f);
		val.DefaultModule.ammoType = (AmmoType)14;
		val.DefaultModule.customAmmoType = CustomClipAmmoTypeToolbox.AddCustomAmmoType("Irregular Shotgun Slugs", "NevernamedsItems/Resources/CustomGunAmmoTypes/irregularshotgun_clipfull", "NevernamedsItems/Resources/CustomGunAmmoTypes/irregularshotgun_clipempty");
		((PickupObject)val).quality = (ItemQuality)3;
		Databases.Items.Add(val, (tk2dSpriteCollectionData)null, "ANY");
		ID = ((PickupObject)val).PickupObjectId;
	}

	public static void AddProj(int amt, Gun gun, Projectile genericProj, float dmgMult, float scaleMult)
	{
		Projectile val = Object.Instantiate<Projectile>(genericProj);
		((Component)val).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val);
		gun.DefaultModule.projectiles.Add(val);
		SneakyShotgunComponent sneakyShotgunComponent = ((Component)val).gameObject.AddComponent<SneakyShotgunComponent>();
		sneakyShotgunComponent.numToFire = amt;
		sneakyShotgunComponent.projPrefabToFire = genericProj;
		sneakyShotgunComponent.damageMult = dmgMult;
		sneakyShotgunComponent.scaleMult = scaleMult;
	}
}
