using Alexandria.ItemAPI;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class RepeatovolverInfinite : AdvancedGunBehavior
{
	public static int ID;

	public static void Add()
	{
		//IL_0086: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0105: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c0: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Repeatovolver Infinite", "repeatovolverinf");
		Game.Items.Rename("outdated_gun_mods:repeatovolver_infinite", "nn:repeatovolver+ad_infinitum");
		((Component)val).gameObject.AddComponent<DiamondGaxe>();
		GunExt.SetShortDescription((PickupObject)(object)val, "");
		GunExt.SetLongDescription((PickupObject)(object)val, "");
		val.SetGunSprites("repeatovolverinf", 8, noAmmonomicon: true, 2);
		PickupObject byId = PickupObjectDatabase.GetById(56);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId is Gun) ? byId : null), true, false);
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.shootStyle = (ShootStyle)4;
		val.DefaultModule.burstShotCount = 15;
		val.DefaultModule.burstCooldownTime = 0.04f;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 1f;
		val.DefaultModule.cooldownTime = 1f;
		val.DefaultModule.numberOfShotsInClip = 15;
		val.SetBarrel(20, 9);
		val.SetBaseMaxAmmo(1000);
		val.InfiniteAmmo = true;
		val.gunClass = (GunClass)10;
		val.gunHandedness = (GunHandedness)2;
		Projectile val2 = ProjectileSetupUtility.MakeProjectile(56, 3f);
		val.DefaultModule.projectiles[0] = val2;
		ref VFXPool muzzleFlashEffects = ref val.muzzleFlashEffects;
		PickupObject byId2 = PickupObjectDatabase.GetById(62);
		muzzleFlashEffects = ((Gun)((byId2 is Gun) ? byId2 : null)).muzzleFlashEffects;
		ProjectileData baseData = val2.baseData;
		baseData.range *= 2f;
		((BraveBehaviour)val2).transform.parent = val.barrelOffset;
		GunTools.SetProjectileSpriteRight(val2, "repeating_projectile", 9, 6, false, (Anchor)4, (int?)9, (int?)6, true, false, (int?)null, (int?)null, (Projectile)null);
		val.AddShellCasing();
		((PickupObject)val).quality = (ItemQuality)(-100);
		Databases.Items.Add(val, (tk2dSpriteCollectionData)null, "ANY");
		GunExt.SetName((PickupObject)(object)val, "Repeatovolver");
		ID = ((PickupObject)val).PickupObjectId;
	}
}
