using Alexandria.ItemAPI;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class MinigunMiniShotgunSynergyForme : GunBehaviour
{
	public static int MiniShotgunID;

	public static void Add()
	{
		//IL_008e: Unknown result type (might be due to invalid IL or missing references)
		//IL_011e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0126: Unknown result type (might be due to invalid IL or missing references)
		//IL_020b: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Mini Shotgun", "minishotgun2");
		Game.Items.Rename("outdated_gun_mods:mini_shotgun", "nn:mini_gun+mini_shotgun");
		((Component)val).gameObject.AddComponent<MinigunMiniShotgunSynergyForme>();
		GunExt.SetShortDescription((PickupObject)(object)val, "Tiny Toys");
		GunExt.SetLongDescription((PickupObject)(object)val, "This shotgun is the size of my self confidence.");
		val.SetGunSprites("minishotgun2", 8, noAmmonomicon: true, 2);
		GunExt.SetAnimationFPS(val, val.shootAnimation, 16);
		GunExt.SetAnimationFPS(val, val.reloadAnimation, 16);
		((Component)val).GetComponent<tk2dSpriteAnimator>().GetClipByName(val.reloadAnimation).wrapMode = (WrapMode)0;
		ref string gunSwitchGroup = ref val.gunSwitchGroup;
		PickupObject byId = PickupObjectDatabase.GetById(43);
		gunSwitchGroup = ((Gun)((byId is Gun) ? byId : null)).gunSwitchGroup;
		for (int i = 0; i < 3; i++)
		{
			PickupObject byId2 = PickupObjectDatabase.GetById(86);
			GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId2 is Gun) ? byId2 : null), true, false);
		}
		ref VFXPool muzzleFlashEffects = ref val.muzzleFlashEffects;
		PickupObject byId3 = PickupObjectDatabase.GetById(79);
		muzzleFlashEffects = ((Gun)((byId3 is Gun) ? byId3 : null)).muzzleFlashEffects;
		val.SetBarrel(13, 6);
		foreach (ProjectileModule projectile in val.Volley.projectiles)
		{
			projectile.ammoCost = 1;
			projectile.shootStyle = (ShootStyle)0;
			projectile.sequenceStyle = (ProjectileSequenceStyle)0;
			projectile.cooldownTime = 0.4f;
			projectile.angleVariance = 10f;
			projectile.numberOfShotsInClip = 4;
			Projectile val2 = Object.Instantiate<Projectile>(projectile.projectiles[0]);
			projectile.projectiles[0] = val2;
			((Component)val2).gameObject.SetActive(false);
			FakePrefab.MarkAsFakePrefab(((Component)val2).gameObject);
			Object.DontDestroyOnLoad((Object)(object)val2);
			val2.baseData.damage = 7f;
			val2.AdditionalScaleMultiplier *= 0.5f;
			if (projectile != val.DefaultModule)
			{
				projectile.ammoCost = 0;
			}
		}
		val.reloadTime = 1.1f;
		val.SetBaseMaxAmmo(200);
		((PickupObject)val).quality = (ItemQuality)(-100);
		Databases.Items.Add(val, (tk2dSpriteCollectionData)null, "ANY");
		GunExt.SetName((PickupObject)(object)val, "Mini Gun");
		val.AddShellCasing(1, 6, 0, 0, "shell_tiny");
		val.AddClipSprites("minishotgun");
		MiniShotgunID = ((PickupObject)val).PickupObjectId;
	}
}
