using Alexandria.ItemAPI;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class OBrienFist : AdvancedGunBehavior
{
	public static int ID;

	public static void Add()
	{
		//IL_009b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_012d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0152: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b8: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("O'Brien Fist", "obrienfist");
		Game.Items.Rename("outdated_gun_mods:o'brien_fist", "nn:obrien_fist");
		((Component)val).gameObject.AddComponent<OBrienFist>();
		GunExt.SetShortDescription((PickupObject)(object)val, "Bathe In the Fire");
		GunExt.SetLongDescription((PickupObject)(object)val, "The limb of a lumbering tortured golem who sought the Gungeon to sate his bloodlust.\n\nYour enemies will run, or face your rage.");
		val.SetGunSprites("obrienfist");
		GunExt.SetAnimationFPS(val, val.shootAnimation, 16);
		PickupObject byId = PickupObjectDatabase.GetById(86);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId is Gun) ? byId : null), true, false);
		ref string gunSwitchGroup = ref val.gunSwitchGroup;
		PickupObject byId2 = PickupObjectDatabase.GetById(23);
		gunSwitchGroup = ((Gun)((byId2 is Gun) ? byId2 : null)).gunSwitchGroup;
		val.gunHandedness = (GunHandedness)3;
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.shootStyle = (ShootStyle)1;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 1f;
		val.DefaultModule.cooldownTime = 0.08f;
		val.DefaultModule.angleVariance = 7f;
		ref VFXPool muzzleFlashEffects = ref val.muzzleFlashEffects;
		PickupObject byId3 = PickupObjectDatabase.GetById(23);
		muzzleFlashEffects = ((Gun)((byId3 is Gun) ? byId3 : null)).muzzleFlashEffects;
		val.DefaultModule.numberOfShotsInClip = 30;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(1.0625f, 0.125f, 0f);
		val.SetBaseMaxAmmo(500);
		val.ammo = 500;
		val.gunClass = (GunClass)10;
		PickupObject byId4 = PickupObjectDatabase.GetById(336);
		Projectile val2 = Object.Instantiate<Projectile>(((Gun)((byId4 is Gun) ? byId4 : null)).DefaultModule.projectiles[0]);
		((Component)val2).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val2).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val2);
		PickupObject byId5 = PickupObjectDatabase.GetById(722);
		Projectile val3 = Object.Instantiate<Projectile>(((Gun)((byId5 is Gun) ? byId5 : null)).DefaultModule.projectiles[0]);
		((Component)val3).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val3).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val3);
		PickupObject byId6 = PickupObjectDatabase.GetById(86);
		Projectile val4 = Object.Instantiate<Projectile>(((Gun)((byId6 is Gun) ? byId6 : null)).DefaultModule.projectiles[0]);
		((Component)val4).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val4).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val4);
		((BraveBehaviour)((BraveBehaviour)val4).sprite).renderer.enabled = false;
		SneakyShotgunComponent orAddComponent = GameObjectExtensions.GetOrAddComponent<SneakyShotgunComponent>(((Component)val4).gameObject);
		orAddComponent.eraseSource = true;
		orAddComponent.doVelocityRandomiser = true;
		orAddComponent.postProcess = true;
		orAddComponent.projPrefabToFire = val2;
		orAddComponent.scaleOffOwnerAccuracy = true;
		orAddComponent.numToFire = 6;
		orAddComponent.angleVariance = 45f;
		orAddComponent.overrideProjectileSynergy = "The Green Room Pale";
		orAddComponent.synergyProjectilePrefab = val3;
		val.DefaultModule.finalProjectile = val4;
		val.DefaultModule.usesOptionalFinalProjectile = true;
		val.DefaultModule.numberOfFinalProjectiles = 1;
		((PickupObject)val).quality = (ItemQuality)4;
		Databases.Items.Add(val, (tk2dSpriteCollectionData)null, "ANY");
		ID = ((PickupObject)val).PickupObjectId;
	}
}
