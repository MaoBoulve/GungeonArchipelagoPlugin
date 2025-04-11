using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class DiscGunSuperDiscForme : GunBehaviour
{
	public static int DiscGunSuperDiscSynergyFormeID;

	public static void Add()
	{
		//IL_008e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0122: Unknown result type (might be due to invalid IL or missing references)
		//IL_012a: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e3: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Super Disc Gun", "discgunsuper");
		Game.Items.Rename("outdated_gun_mods:super_disc_gun", "nn:disc_gun+super_disc");
		((Component)val).gameObject.AddComponent<DiscGunSuperDiscForme>();
		GunExt.SetShortDescription((PickupObject)(object)val, "Badder Choices");
		GunExt.SetLongDescription((PickupObject)(object)val, "Fires a shit-ton of discs. If you're reading this, you're a hacker.");
		val.SetGunSprites("discgunsuper", 8, noAmmonomicon: true);
		GunExt.SetAnimationFPS(val, val.shootAnimation, 14);
		GunExt.SetAnimationFPS(val, val.reloadAnimation, 14);
		((Component)val).GetComponent<tk2dSpriteAnimator>().GetClipByName(val.reloadAnimation).wrapMode = (WrapMode)0;
		ref VFXPool muzzleFlashEffects = ref val.muzzleFlashEffects;
		PickupObject byId = PickupObjectDatabase.GetById(393);
		muzzleFlashEffects = ((Gun)((byId is Gun) ? byId : null)).muzzleFlashEffects;
		ref string gunSwitchGroup = ref val.gunSwitchGroup;
		PickupObject byId2 = PickupObjectDatabase.GetById(12);
		gunSwitchGroup = ((Gun)((byId2 is Gun) ? byId2 : null)).gunSwitchGroup;
		val.SetBarrel(30, 17);
		for (int i = 0; i < 5; i++)
		{
			PickupObject byId3 = PickupObjectDatabase.GetById(86);
			GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId3 is Gun) ? byId3 : null), true, false);
		}
		foreach (ProjectileModule projectile in val.Volley.projectiles)
		{
			projectile.ammoCost = 1;
			projectile.shootStyle = (ShootStyle)0;
			projectile.sequenceStyle = (ProjectileSequenceStyle)0;
			projectile.cooldownTime = 0.25f;
			projectile.numberOfShotsInClip = 10;
			projectile.angleVariance = 20f;
			Projectile value = ProjectileSetupUtility.MakeProjectile(DiscGun.DiscGunID, 20f);
			projectile.projectiles[0] = value;
			if (projectile != val.DefaultModule)
			{
				projectile.ammoCost = 0;
			}
		}
		val.reloadTime = 1f;
		val.SetBaseMaxAmmo(300);
		val.AddClipSprites("discgun");
		((PickupObject)val).quality = (ItemQuality)(-100);
		Databases.Items.Add(val, (tk2dSpriteCollectionData)null, "ANY");
		GunExt.SetName((PickupObject)(object)val, "Disc Gun");
		DiscGunSuperDiscSynergyFormeID = ((PickupObject)val).PickupObjectId;
	}
}
