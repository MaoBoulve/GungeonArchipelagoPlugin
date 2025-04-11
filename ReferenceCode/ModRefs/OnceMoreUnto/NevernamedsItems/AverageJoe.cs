using Alexandria.ItemAPI;
using Alexandria.Misc;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class AverageJoe : AdvancedGunBehavior
{
	public static int ID;

	public static void Add()
	{
		//IL_00d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0127: Unknown result type (might be due to invalid IL or missing references)
		//IL_014c: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01da: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Average Joe", "averagejoe");
		Game.Items.Rename("outdated_gun_mods:average_joe", "nn:average_joe");
		((Component)val).gameObject.AddComponent<AverageJoe>();
		GunExt.SetShortDescription((PickupObject)(object)val, "Everyman");
		GunExt.SetLongDescription((PickupObject)(object)val, "Shots from this gun deal damage equal to the average damage per bullet of each gun in the owner's arsenal.\n\nA boring gun for the boring everyman- flagrantly and irresponsibly having been aesthetically modified with a red sash.");
		val.SetGunSprites("averagejoe");
		GunExt.SetAnimationFPS(val, val.shootAnimation, 17);
		GunExt.SetAnimationFPS(val, val.reloadAnimation, 0);
		PickupObject byId = PickupObjectDatabase.GetById(56);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId is Gun) ? byId : null), true, false);
		ref string gunSwitchGroup = ref val.gunSwitchGroup;
		PickupObject byId2 = PickupObjectDatabase.GetById(54);
		gunSwitchGroup = ((Gun)((byId2 is Gun) ? byId2 : null)).gunSwitchGroup;
		ref VFXPool muzzleFlashEffects = ref val.muzzleFlashEffects;
		PickupObject byId3 = PickupObjectDatabase.GetById(184);
		muzzleFlashEffects = ((Gun)((byId3 is Gun) ? byId3 : null)).muzzleFlashEffects;
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.shootStyle = (ShootStyle)1;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 0.7f;
		val.DefaultModule.cooldownTime = 0.4f;
		val.DefaultModule.numberOfShotsInClip = 10;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(2.0625f, 1f, 0f);
		val.SetBaseMaxAmmo(300);
		val.ammo = 300;
		val.gunClass = (GunClass)10;
		Projectile val2 = ProjectileUtility.InstantiateAndFakeprefab(val.DefaultModule.projectiles[0]);
		val.DefaultModule.projectiles[0] = val2;
		val2.SetProjectileSprite("boltcaster_proj", 23, 3, lightened: true, (Anchor)4, 13, 3, anchorChangesCollider: true, fixesScale: false, null, null);
		((Component)val2).gameObject.AddComponent<DamageAverageBehaviour>();
		val.DefaultModule.ammoType = (AmmoType)14;
		val.DefaultModule.customAmmoType = "Risk Rifle Bullets";
		((PickupObject)val).quality = (ItemQuality)2;
		Databases.Items.Add(val, (tk2dSpriteCollectionData)null, "ANY");
		ID = ((PickupObject)val).PickupObjectId;
	}
}
