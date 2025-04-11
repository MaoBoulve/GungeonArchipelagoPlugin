using Alexandria.ItemAPI;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class HornetsNest : GunBehaviour
{
	public static int ID;

	public static void Add()
	{
		//IL_009b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0126: Unknown result type (might be due to invalid IL or missing references)
		//IL_017a: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Hornets Nest", "hornetsnest");
		Game.Items.Rename("outdated_gun_mods:hornets_nest", "nn:hornets_nest");
		((Component)val).gameObject.AddComponent<HornetsNest>();
		GunExt.SetShortDescription((PickupObject)(object)val, "Kicked into Action");
		GunExt.SetLongDescription((PickupObject)(object)val, "Years of gunsmiths attempting to upgrade the humble Bee Hive have finally been proven futile with the discovery of the once-mythical Hornet.");
		val.SetGunSprites("hornetsnest", 8, noAmmonomicon: false, 2);
		GunExt.SetAnimationFPS(val, val.shootAnimation, 12);
		ref string gunSwitchGroup = ref val.gunSwitchGroup;
		PickupObject byId = PickupObjectDatabase.GetById(14);
		gunSwitchGroup = ((Gun)((byId is Gun) ? byId : null)).gunSwitchGroup;
		PickupObject byId2 = PickupObjectDatabase.GetById(14);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId2 is Gun) ? byId2 : null), true, false);
		val.gunHandedness = (GunHandedness)1;
		ref VFXPool muzzleFlashEffects = ref val.muzzleFlashEffects;
		PickupObject byId3 = PickupObjectDatabase.GetById(14);
		muzzleFlashEffects = ((Gun)((byId3 is Gun) ? byId3 : null)).muzzleFlashEffects;
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.shootStyle = (ShootStyle)1;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 1f;
		val.DefaultModule.cooldownTime = 0.11f;
		val.DefaultModule.numberOfShotsInClip = -1;
		val.SetBarrel(18, 7);
		val.SetBaseMaxAmmo(300);
		val.ammo = 300;
		val.gunClass = (GunClass)50;
		PickupObject byId4 = PickupObjectDatabase.GetById(138);
		Projectile val2 = Object.Instantiate<Projectile>(((SpawnProjectileOnDamagedItem)((byId4 is SpawnProjectileOnDamagedItem) ? byId4 : null)).synergyProjectile);
		((Component)val2).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val2).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val2);
		val.DefaultModule.projectiles[0] = val2;
		((PickupObject)val).quality = (ItemQuality)4;
		Databases.Items.Add((PickupObject)(object)val, false, "ANY");
		ID = ((PickupObject)val).PickupObjectId;
	}
}
