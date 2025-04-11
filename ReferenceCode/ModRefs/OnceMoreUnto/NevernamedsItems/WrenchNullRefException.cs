using Alexandria.ItemAPI;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class WrenchNullRefException : AdvancedGunBehavior
{
	public static int NullWrenchID;

	public static void Add()
	{
		//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		//IL_0128: Unknown result type (might be due to invalid IL or missing references)
		//IL_0154: Unknown result type (might be due to invalid IL or missing references)
		//IL_03cf: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Null Reference Exwrenchion", "wrenchnull");
		Game.Items.Rename("outdated_gun_mods:null_reference_exwrenchion", "nn:wrench+null_reference_exception");
		((Component)val).gameObject.AddComponent<WrenchNullRefException>();
		GunExt.SetShortDescription((PickupObject)(object)val, "Mod The Gun");
		GunExt.SetLongDescription((PickupObject)(object)val, "i am so tired while coding this.                            revisiting this some years later, I am still tired.");
		val.SetGunSprites("wrenchnull", 8, noAmmonomicon: true);
		GunExt.SetAnimationFPS(val, val.shootAnimation, 12);
		GunExt.SetAnimationFPS(val, val.reloadAnimation, 1);
		PickupObject byId = PickupObjectDatabase.GetById(56);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId is Gun) ? byId : null), true, false);
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.shootStyle = (ShootStyle)4;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)2;
		val.DefaultModule.orderedGroupCounts.Add(1);
		val.DefaultModule.orderedGroupCounts.Add(1);
		val.DefaultModule.orderedGroupCounts.Add(1);
		val.DefaultModule.burstShotCount = 3;
		val.DefaultModule.burstCooldownTime = 0.1f;
		val.reloadTime = 1f;
		val.DefaultModule.cooldownTime = 0.5f;
		val.muzzleFlashEffects.type = (VFXPoolType)0;
		val.DefaultModule.numberOfShotsInClip = 12;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(1.43f, 0.31f, 0f);
		val.SetBaseMaxAmmo(400);
		Projectile val2 = Object.Instantiate<Projectile>(val.DefaultModule.projectiles[0]);
		((Component)val2).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val2).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val2);
		ProjectileData baseData = val2.baseData;
		baseData.damage *= 1.8f;
		ProjectileData baseData2 = val2.baseData;
		baseData2.speed *= 1f;
		ProjectileData baseData3 = val2.baseData;
		baseData3.range *= 10f;
		GunTools.SetProjectileSpriteRight(val2, "wrench_null_projectile", 13, 7, false, (Anchor)4, (int?)12, (int?)7, true, false, (int?)null, (int?)null, (Projectile)null);
		PickupObject byId2 = PickupObjectDatabase.GetById(56);
		Projectile val3 = Object.Instantiate<Projectile>(((Gun)((byId2 is Gun) ? byId2 : null)).DefaultModule.projectiles[0]);
		((Component)val3).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val3).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val3);
		ProjectileData baseData4 = val3.baseData;
		baseData4.damage *= 1.8f;
		ProjectileData baseData5 = val3.baseData;
		baseData5.speed *= 1f;
		ProjectileData baseData6 = val3.baseData;
		baseData6.range *= 10f;
		GunTools.SetProjectileSpriteRight(val3, "wrench_reference_projectile", 36, 7, false, (Anchor)4, (int?)30, (int?)7, true, false, (int?)null, (int?)null, (Projectile)null);
		PickupObject byId3 = PickupObjectDatabase.GetById(56);
		Projectile val4 = Object.Instantiate<Projectile>(((Gun)((byId3 is Gun) ? byId3 : null)).DefaultModule.projectiles[0]);
		((Component)val4).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val4).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val4);
		ProjectileData baseData7 = val4.baseData;
		baseData7.damage *= 1.8f;
		ProjectileData baseData8 = val4.baseData;
		baseData8.speed *= 1f;
		ProjectileData baseData9 = val4.baseData;
		baseData9.range *= 10f;
		GunTools.SetProjectileSpriteRight(val4, "wrench_exception_projectile", 35, 9, false, (Anchor)4, (int?)30, (int?)7, true, false, (int?)null, (int?)null, (Projectile)null);
		val.DefaultModule.projectiles[0] = val2;
		val.DefaultModule.projectiles.Add(val3);
		val.DefaultModule.projectiles.Add(val4);
		((PickupObject)val).quality = (ItemQuality)(-100);
		Databases.Items.Add(val, (tk2dSpriteCollectionData)null, "ANY");
		NullWrenchID = ((PickupObject)val).PickupObjectId;
	}
}
