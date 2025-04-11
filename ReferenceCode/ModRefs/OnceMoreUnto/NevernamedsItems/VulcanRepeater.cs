using Alexandria.ItemAPI;
using Alexandria.Misc;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class VulcanRepeater : AdvancedGunBehavior
{
	public static int ID;

	public static void Add()
	{
		//IL_00d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_011a: Unknown result type (might be due to invalid IL or missing references)
		//IL_014b: Unknown result type (might be due to invalid IL or missing references)
		//IL_015e: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Vulcan Repeater", "vulcanrepeater");
		Game.Items.Rename("outdated_gun_mods:vulcan_repeater", "nn:vulcan_repeater");
		((Component)val).gameObject.AddComponent<VulcanRepeater>();
		GunExt.SetShortDescription((PickupObject)(object)val, "Glocram Rises");
		GunExt.SetLongDescription((PickupObject)(object)val, "Fires powerful explosive bolts which have a chance to split in two for double the power.\n\nForged with the soul of an impossible beast, by warriors of a forgotten age.");
		val.SetGunSprites("vulcanrepeater");
		GunExt.SetAnimationFPS(val, val.shootAnimation, 8);
		GunExt.SetAnimationFPS(val, val.reloadAnimation, 0);
		ref string gunSwitchGroup = ref val.gunSwitchGroup;
		PickupObject byId = PickupObjectDatabase.GetById(12);
		gunSwitchGroup = ((Gun)((byId is Gun) ? byId : null)).gunSwitchGroup;
		ref VFXPool muzzleFlashEffects = ref val.muzzleFlashEffects;
		PickupObject byId2 = PickupObjectDatabase.GetById(12);
		muzzleFlashEffects = ((Gun)((byId2 is Gun) ? byId2 : null)).muzzleFlashEffects;
		PickupObject byId3 = PickupObjectDatabase.GetById(56);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId3 is Gun) ? byId3 : null), true, false);
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.shootStyle = (ShootStyle)0;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 0.8f;
		val.gunClass = (GunClass)1;
		val.DefaultModule.cooldownTime = 0.5f;
		val.DefaultModule.numberOfShotsInClip = 1;
		val.SetBaseMaxAmmo(50);
		((PickupObject)val).quality = (ItemQuality)4;
		Databases.Items.Add((PickupObject)(object)val, false, "ANY");
		((Component)val.barrelOffset).transform.localPosition = new Vector3(2.5f, 0.875f, 0f);
		val.DefaultModule.ammoType = (AmmoType)14;
		val.DefaultModule.customAmmoType = CustomClipAmmoTypeToolbox.AddCustomAmmoType("Vulcan Repeater Bolts", "NevernamedsItems/Resources/CustomGunAmmoTypes/vulcanrepeater_clipfull", "NevernamedsItems/Resources/CustomGunAmmoTypes/vulcanrepeater_clipempty");
		Projectile val2 = ProjectileUtility.InstantiateAndFakeprefab(val.DefaultModule.projectiles[0]);
		val.DefaultModule.projectiles[0] = val2;
		val2.baseData.damage = 22f;
		ProjectileData baseData = val2.baseData;
		baseData.speed *= 1.2f;
		ExplosiveModifier val3 = ((Component)val2).gameObject.AddComponent<ExplosiveModifier>();
		val3.doExplosion = true;
		val3.explosionData = StaticExplosionDatas.explosiveRoundsExplosion;
		ProjectileSplitController projectileSplitController = ((Component)val2).gameObject.AddComponent<ProjectileSplitController>();
		projectileSplitController.amtToSplitTo = 2;
		projectileSplitController.chanceToSplit = 0.45f;
		projectileSplitController.distanceBasedSplit = true;
		projectileSplitController.distanceTillSplit = 5f;
		projectileSplitController.dmgMultAfterSplit = 0.5f;
		val2.SetProjectileSprite("vulcanrepeater_proj", 16, 5, lightened: false, (Anchor)4, 14, 3, anchorChangesCollider: true, fixesScale: false, null, null);
		ID = ((PickupObject)val).PickupObjectId;
		AlexandriaTags.SetTag((PickupObject)(object)val, "arrow_bolt_weapon");
	}
}
