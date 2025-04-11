using Alexandria.Misc;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class SnakeMinigun : GunBehaviour
{
	public static int ID;

	public static void Add()
	{
		//IL_008e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00de: Unknown result type (might be due to invalid IL or missing references)
		//IL_0124: Unknown result type (might be due to invalid IL or missing references)
		//IL_017e: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Snake Minigun", "snakeminigun");
		Game.Items.Rename("outdated_gun_mods:snake_minigun", "nn:snake_minigun");
		((Component)val).gameObject.AddComponent<SnakeMinigun>();
		GunExt.SetShortDescription((PickupObject)(object)val, "SSSSSSSSSSSSSSSSSS");
		GunExt.SetLongDescription((PickupObject)(object)val, "Among the finest examples of the respected, albeit niche, tradition of snakesmithing.\n\nContains more snakes by volume than any other device of its kind.");
		val.SetGunSprites("snakeminigun", 8, noAmmonomicon: false, 2);
		GunExt.SetAnimationFPS(val, val.shootAnimation, 15);
		GunExt.SetAnimationFPS(val, val.reloadAnimation, 15);
		((Component)val).GetComponent<tk2dSpriteAnimator>().GetClipByName(val.reloadAnimation).wrapMode = (WrapMode)0;
		PickupObject byId = PickupObjectDatabase.GetById(84);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId is Gun) ? byId : null), true, false);
		ref string gunSwitchGroup = ref val.gunSwitchGroup;
		PickupObject byId2 = PickupObjectDatabase.GetById(84);
		gunSwitchGroup = ((Gun)((byId2 is Gun) ? byId2 : null)).gunSwitchGroup;
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.shootStyle = (ShootStyle)1;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 1f;
		val.DefaultModule.cooldownTime = 0.06f;
		val.DefaultModule.numberOfShotsInClip = 15;
		val.SetBarrel(43, 8);
		val.SetBaseMaxAmmo(800);
		val.gunClass = (GunClass)25;
		ref VFXPool muzzleFlashEffects = ref val.muzzleFlashEffects;
		PickupObject byId3 = PickupObjectDatabase.GetById(89);
		muzzleFlashEffects = ((Gun)((byId3 is Gun) ? byId3 : null)).muzzleFlashEffects;
		Projectile val2 = ProjectileUtility.InstantiateAndFakeprefab(StandardisedProjectiles.snake);
		val2.baseData.damage = 4f;
		val.DefaultModule.projectiles[0] = val2;
		val.AddClipSprites("snakeclip");
		((PickupObject)val).quality = (ItemQuality)5;
		Databases.Items.Add(val, (tk2dSpriteCollectionData)null, "ANY");
		ID = ((PickupObject)val).PickupObjectId;
	}
}
