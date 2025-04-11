using Alexandria.ItemAPI;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class Glazerbeam : AdvancedGunBehavior
{
	public static int GlazerbeamID;

	public static void Add()
	{
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0122: Unknown result type (might be due to invalid IL or missing references)
		//IL_0147: Unknown result type (might be due to invalid IL or missing references)
		//IL_026a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0281: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Glazerbeam", "glazerbeam");
		Game.Items.Rename("outdated_gun_mods:glazerbeam", "nn:glazerbeam");
		((Component)val).gameObject.AddComponent<Glazerbeam>();
		GunExt.SetShortDescription((PickupObject)(object)val, "Static Lasers");
		GunExt.SetLongDescription((PickupObject)(object)val, "Fires lasers that hang in the air. Repurposed from arbitrarily menacing 'laser walls' salvaged from an abandoned supervillain hideout.");
		val.SetGunSprites("glazerbeam");
		GunExt.SetAnimationFPS(val, val.shootAnimation, 14);
		ref string gunSwitchGroup = ref val.gunSwitchGroup;
		PickupObject byId = PickupObjectDatabase.GetById(153);
		gunSwitchGroup = ((Gun)((byId is Gun) ? byId : null)).gunSwitchGroup;
		PickupObject byId2 = PickupObjectDatabase.GetById(38);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId2 is Gun) ? byId2 : null), true, false);
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.shootStyle = (ShootStyle)1;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 1f;
		val.DefaultModule.cooldownTime = 0.25f;
		val.DefaultModule.angleFromAim = 0f;
		val.DefaultModule.angleVariance = 10f;
		val.DefaultModule.numberOfShotsInClip = 10;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(2f, 0.56f, 0f);
		val.SetBaseMaxAmmo(300);
		val.ammo = 300;
		val.gunClass = (GunClass)20;
		Projectile val2 = Object.Instantiate<Projectile>(LaserBullets.SimpleRedBeam);
		((Component)val2).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val2).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val2);
		val2.baseData.damage = 10f;
		Projectile val3 = Object.Instantiate<Projectile>(val.DefaultModule.projectiles[0]);
		((Component)val3).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val3).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val3);
		val.DefaultModule.projectiles[0] = val3;
		val3.baseData.damage = 20f;
		val3.baseData.speed = 1.7f;
		val3.baseData.range = 3f;
		GunTools.SetProjectileSpriteRight(val3, "enemystyle_projectile", 10, 10, true, (Anchor)4, (int?)8, (int?)8, true, false, (int?)null, (int?)null, (Projectile)null);
		((BraveBehaviour)val3).transform.parent = val.barrelOffset;
		BeamBulletsBehaviour beamBulletsBehaviour = ((Component)val3).gameObject.AddComponent<BeamBulletsBehaviour>();
		beamBulletsBehaviour.firetype = BeamBulletsBehaviour.FireType.FORWARDS;
		beamBulletsBehaviour.beamToFire = val2;
		val.DefaultModule.ammoType = (AmmoType)14;
		val.DefaultModule.customAmmoType = "Punishment Ray Lasers";
		((PickupObject)val).quality = (ItemQuality)3;
		Databases.Items.Add(val, (tk2dSpriteCollectionData)null, "ANY");
		GlazerbeamID = ((PickupObject)val).PickupObjectId;
	}
}
