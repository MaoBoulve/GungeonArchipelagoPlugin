using Alexandria.Assetbundle;
using Alexandria.ItemAPI;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class DiamondCutter : AdvancedGunBehavior
{
	public static int ID;

	public static void Add()
	{
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_011e: Unknown result type (might be due to invalid IL or missing references)
		//IL_013d: Unknown result type (might be due to invalid IL or missing references)
		//IL_027d: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a3: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Diamond Cutter", "diamondcutter");
		Game.Items.Rename("outdated_gun_mods:diamond_cutter", "nn:diamond_cutter");
		DiamondCutter diamondCutter = ((Component)val).gameObject.AddComponent<DiamondCutter>();
		((AdvancedGunBehavior)diamondCutter).preventNormalReloadAudio = true;
		((AdvancedGunBehavior)diamondCutter).preventNormalFireAudio = true;
		((AdvancedGunBehavior)diamondCutter).overrideNormalFireAudio = "Play_WPN_blasphemy_shot_01";
		GunExt.SetShortDescription((PickupObject)(object)val, "Face It!");
		GunExt.SetLongDescription((PickupObject)(object)val, "Fires piercing gemstones.\n\nLeft in a chest by a powerful warrior of shimmering crystal... who didn't show up to work today.");
		GunInt.SetupSprite(val, Initialisation.gunCollection, "diamondcutter_idle_001", 8, "diamondcutter_ammonomicon_001");
		GunExt.SetAnimationFPS(val, val.reloadAnimation, 1);
		ref VFXPool muzzleFlashEffects = ref val.muzzleFlashEffects;
		PickupObject byId = PickupObjectDatabase.GetById(97);
		muzzleFlashEffects = ((Gun)((byId is Gun) ? byId : null)).muzzleFlashEffects;
		PickupObject byId2 = PickupObjectDatabase.GetById(56);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId2 is Gun) ? byId2 : null), true, false);
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.shootStyle = (ShootStyle)0;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 0.8f;
		val.DefaultModule.cooldownTime = 0.2f;
		val.DefaultModule.numberOfShotsInClip = 3;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(1.81f, 1.43f, 0f);
		val.SetBaseMaxAmmo(100);
		val.ammo = 100;
		val.gunClass = (GunClass)50;
		ItemBuilder.AddPassiveStatModifier((PickupObject)(object)val, (StatType)14, 1f, (ModifyMethod)0);
		Projectile val2 = Object.Instantiate<Projectile>(val.DefaultModule.projectiles[0]);
		((Component)val2).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val2).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val2);
		val2.baseData.damage = 10f;
		ProjectileData baseData = val2.baseData;
		baseData.speed *= 1.5f;
		val2.hitEffects.alwaysUseMidair = true;
		ref GameObject overrideMidairDeathVFX = ref val2.hitEffects.overrideMidairDeathVFX;
		PickupObject byId3 = PickupObjectDatabase.GetById(506);
		overrideMidairDeathVFX = ((Gun)((byId3 is Gun) ? byId3 : null)).DefaultModule.projectiles[0].hitEffects.overrideMidairDeathVFX;
		PierceProjModifier val3 = ((Component)val2).gameObject.AddComponent<PierceProjModifier>();
		val3.penetration = 10;
		MaintainDamageOnPierce maintainDamageOnPierce = ((Component)val2).gameObject.AddComponent<MaintainDamageOnPierce>();
		maintainDamageOnPierce.damageMultOnPierce = 2f;
		val2.pierceMinorBreakables = true;
		val2.SetProjectileSprite("diamondcutter_proj", 23, 13, lightened: false, (Anchor)4, 17, 5, anchorChangesCollider: true, fixesScale: false, null, null);
		val2.DestroyMode = (ProjectileDestroyMode)2;
		val.DefaultModule.projectiles[0] = val2;
		val.DefaultModule.ammoType = (AmmoType)14;
		val.DefaultModule.customAmmoType = CustomClipAmmoTypeToolbox.AddCustomAmmoType("DiamondCutter Bullets", "NevernamedsItems/Resources/CustomGunAmmoTypes/diamondcutter_clipfull", "NevernamedsItems/Resources/CustomGunAmmoTypes/diamondcutter_clipempty");
		((PickupObject)val).quality = (ItemQuality)3;
		Databases.Items.Add((PickupObject)(object)val, false, "ANY");
		ID = ((PickupObject)val).PickupObjectId;
	}
}
