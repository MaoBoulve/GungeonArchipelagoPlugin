using Alexandria.ItemAPI;
using Alexandria.Misc;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class BigBorz : AdvancedGunBehavior
{
	public static int ID;

	public static void Add()
	{
		//IL_00cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Unknown result type (might be due to invalid IL or missing references)
		//IL_0132: Unknown result type (might be due to invalid IL or missing references)
		//IL_014c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0202: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Big Borz", "bigborz");
		Game.Items.Rename("outdated_gun_mods:big_borz", "nn:borz+big_borz");
		BigBorz bigBorz = ((Component)val).gameObject.AddComponent<BigBorz>();
		GunExt.SetShortDescription((PickupObject)(object)val, "");
		GunExt.SetLongDescription((PickupObject)(object)val, "");
		val.SetGunSprites("bigborz", 8, noAmmonomicon: true);
		GunExt.SetAnimationFPS(val, val.shootAnimation, 10);
		GunExt.SetAnimationFPS(val, val.reloadAnimation, 0);
		PickupObject byId = PickupObjectDatabase.GetById(86);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId is Gun) ? byId : null), true, false);
		ref VFXPool muzzleFlashEffects = ref val.muzzleFlashEffects;
		PickupObject byId2 = PickupObjectDatabase.GetById(2);
		muzzleFlashEffects = ((Gun)((byId2 is Gun) ? byId2 : null)).muzzleFlashEffects;
		ref string gunSwitchGroup = ref val.gunSwitchGroup;
		PickupObject byId3 = PickupObjectDatabase.GetById(2);
		gunSwitchGroup = ((Gun)((byId3 is Gun) ? byId3 : null)).gunSwitchGroup;
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.shootStyle = (ShootStyle)1;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 1f;
		val.DefaultModule.cooldownTime = 0.2f;
		val.DefaultModule.angleVariance = 5f;
		val.DefaultModule.numberOfShotsInClip = 70;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(1.625f, 0.9375f, 0f);
		val.SetBaseMaxAmmo(700);
		val.gunClass = (GunClass)10;
		Projectile val2 = ProjectileUtility.InstantiateAndFakeprefab(val.DefaultModule.projectiles[0]);
		ProjectileData baseData = val2.baseData;
		baseData.speed *= 1.5f;
		val2.baseData.damage = 6f;
		val2.SetProjectileSprite("12x12_yellowenemy_projectile", 12, 12, lightened: true, (Anchor)4, 11, 11, anchorChangesCollider: true, fixesScale: false, null, null);
		ref ProjectileImpactVFXPool hitEffects = ref val2.hitEffects;
		PickupObject byId4 = PickupObjectDatabase.GetById(15);
		hitEffects = ((Gun)((byId4 is Gun) ? byId4 : null)).DefaultModule.projectiles[0].hitEffects;
		val.DefaultModule.projectiles[0] = val2;
		((PickupObject)val).quality = (ItemQuality)(-100);
		Databases.Items.Add(val, (tk2dSpriteCollectionData)null, "ANY");
		ID = ((PickupObject)val).PickupObjectId;
		GunExt.SetName((PickupObject)(object)val, "Borz");
	}
}
