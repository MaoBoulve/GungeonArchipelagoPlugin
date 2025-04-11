using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class Gunion : GunBehaviour
{
	public static int ID;

	public static void Add()
	{
		//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00de: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_011c: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e7: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Gunion", "gunion");
		Game.Items.Rename("outdated_gun_mods:gunion", "nn:gunion");
		((Component)val).gameObject.AddComponent<Gunion>();
		GunExt.SetShortDescription((PickupObject)(object)val, "Allium Cepa");
		GunExt.SetLongDescription((PickupObject)(object)val, "A gunion (Allium cepa L., from Latin cepa meaning \"gunion\"), also known as the bulb gunion or common gunion, is a vegetable that is the most widely cultivated species of the genus Allium.");
		val.SetGunSprites("gunion", 8, noAmmonomicon: false, 2);
		GunExt.SetAnimationFPS(val, val.shootAnimation, 12);
		GunExt.SetAnimationFPS(val, val.reloadAnimation, 12);
		ref VFXPool muzzleFlashEffects = ref val.muzzleFlashEffects;
		PickupObject byId = PickupObjectDatabase.GetById(33);
		muzzleFlashEffects = ((Gun)((byId is Gun) ? byId : null)).muzzleFlashEffects;
		ref string gunSwitchGroup = ref val.gunSwitchGroup;
		PickupObject byId2 = PickupObjectDatabase.GetById(124);
		gunSwitchGroup = ((Gun)((byId2 is Gun) ? byId2 : null)).gunSwitchGroup;
		PickupObject byId3 = PickupObjectDatabase.GetById(56);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId3 is Gun) ? byId3 : null), true, false);
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.shootStyle = (ShootStyle)0;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 0.4f;
		val.gunClass = (GunClass)1;
		val.DefaultModule.cooldownTime = 0.4f;
		val.DefaultModule.numberOfShotsInClip = 3;
		val.SetBaseMaxAmmo(100);
		((PickupObject)val).quality = (ItemQuality)2;
		Databases.Items.Add(val, (tk2dSpriteCollectionData)null, "ANY");
		val.SetBarrel(18, 12);
		Projectile val2 = ProjectileSetupUtility.MakeProjectile(56, 7.8f);
		val2.SetProjectileSprite("gunion_proj", 7, 4, lightened: false, (Anchor)0, null, null, anchorChangesCollider: true, fixesScale: false, null, null);
		ref ProjectileImpactVFXPool hitEffects = ref val2.hitEffects;
		PickupObject byId4 = PickupObjectDatabase.GetById(33);
		hitEffects = ((Gun)((byId4 is Gun) ? byId4 : null)).DefaultModule.projectiles[0].hitEffects;
		ModdedStatusEffectApplier moddedStatusEffectApplier = ((Component)val2).gameObject.AddComponent<ModdedStatusEffectApplier>();
		moddedStatusEffectApplier.appliesCrying = true;
		val.DefaultModule.projectiles[0] = val2;
		val.DefaultModule.ammoType = (AmmoType)14;
		val.DefaultModule.customAmmoType = "poison_blob";
		val.AddClipDebris(3, 1, "clipdebris_gunion");
		ID = ((PickupObject)val).PickupObjectId;
	}
}
