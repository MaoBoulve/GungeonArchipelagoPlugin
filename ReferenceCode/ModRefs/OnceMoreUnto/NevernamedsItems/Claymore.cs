using Alexandria.ItemAPI;
using Alexandria.Misc;
using Gungeon;
using SaveAPI;
using UnityEngine;

namespace NevernamedsItems;

public class Claymore : AdvancedGunBehavior
{
	public static int ID;

	public static void Add()
	{
		//IL_00e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0119: Unknown result type (might be due to invalid IL or missing references)
		//IL_0144: Unknown result type (might be due to invalid IL or missing references)
		//IL_015a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0162: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_022c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0254: Unknown result type (might be due to invalid IL or missing references)
		//IL_0259: Unknown result type (might be due to invalid IL or missing references)
		//IL_0263: Unknown result type (might be due to invalid IL or missing references)
		//IL_0268: Unknown result type (might be due to invalid IL or missing references)
		//IL_0272: Unknown result type (might be due to invalid IL or missing references)
		//IL_0277: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Claymore", "claymore");
		Game.Items.Rename("outdated_gun_mods:claymore", "nn:claymore");
		Claymore claymore = ((Component)val).gameObject.AddComponent<Claymore>();
		ref string gunSwitchGroup = ref val.gunSwitchGroup;
		PickupObject byId = PickupObjectDatabase.GetById(417);
		gunSwitchGroup = ((Gun)((byId is Gun) ? byId : null)).gunSwitchGroup;
		GunExt.SetShortDescription((PickupObject)(object)val, "Bladeborn");
		GunExt.SetLongDescription((PickupObject)(object)val, "Slices and detonates foes\n\nFrom the extensive and ostentatious sword collection of King Charthur of the knights of the octagonal table.");
		val.SetGunSprites("claymore");
		GunExt.SetAnimationFPS(val, val.shootAnimation, 13);
		GunExt.SetAnimationFPS(val, val.reloadAnimation, 0);
		ItemBuilder.AddPassiveStatModifier((PickupObject)(object)val, (StatType)14, 1f, (ModifyMethod)0);
		ref ScreenShakeSettings gunScreenShake = ref val.gunScreenShake;
		PickupObject byId2 = PickupObjectDatabase.GetById(417);
		gunScreenShake = ((Gun)((byId2 is Gun) ? byId2 : null)).gunScreenShake;
		PickupObject byId3 = PickupObjectDatabase.GetById(86);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId3 is Gun) ? byId3 : null), true, false);
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.shootStyle = (ShootStyle)0;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 1.1f;
		val.DefaultModule.cooldownTime = 0.6f;
		val.muzzleFlashEffects.type = (VFXPoolType)0;
		val.DefaultModule.numberOfShotsInClip = 5;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(2.9375f, 3f, 0f);
		val.SetBaseMaxAmmo(80);
		((PickupObject)val).quality = (ItemQuality)3;
		val.gunClass = (GunClass)50;
		Projectile val2 = ProjectileUtility.SetupProjectile(86);
		val.DefaultModule.projectiles[0] = val2;
		val2.baseData.damage = 5f;
		((BraveBehaviour)((BraveBehaviour)val2).sprite).renderer.enabled = false;
		ExplosiveSlashModifier explosiveSlashModifier = ((Component)val2).gameObject.AddComponent<ExplosiveSlashModifier>();
		((ProjectileSlashingBehaviour)explosiveSlashModifier).DestroyBaseAfterFirstSlash = true;
		((ProjectileSlashingBehaviour)explosiveSlashModifier).slashParameters = ScriptableObject.CreateInstance<SlashData>();
		((ProjectileSlashingBehaviour)explosiveSlashModifier).slashParameters.soundEvent = null;
		((ProjectileSlashingBehaviour)explosiveSlashModifier).slashParameters.projInteractMode = (ProjInteractMode)1;
		((ProjectileSlashingBehaviour)explosiveSlashModifier).SlashDamageUsesBaseProjectileDamage = true;
		((ProjectileSlashingBehaviour)explosiveSlashModifier).slashParameters.doVFX = false;
		((ProjectileSlashingBehaviour)explosiveSlashModifier).slashParameters.doHitVFX = true;
		((ProjectileSlashingBehaviour)explosiveSlashModifier).slashParameters.slashRange = 3.5f;
		((ProjectileSlashingBehaviour)explosiveSlashModifier).slashParameters.playerKnockbackForce = 40f;
		explosiveSlashModifier.explosionData = StaticExplosionDatas.explosiveRoundsExplosion;
		val.DefaultModule.ammoType = (AmmoType)14;
		val.DefaultModule.customAmmoType = CustomClipAmmoTypeToolbox.AddCustomAmmoType("Claymore Bullets", "NevernamedsItems/Resources/CustomGunAmmoTypes/claymore_clipfull", "NevernamedsItems/Resources/CustomGunAmmoTypes/claymore_clipempty");
		val.carryPixelOffset = new IntVector2(15, 0);
		val.carryPixelUpOffset = new IntVector2(-15, 10);
		val.carryPixelDownOffset = new IntVector2(-15, -10);
		Databases.Items.Add((PickupObject)(object)val, false, "ANY");
		ID = ((PickupObject)val).PickupObjectId;
		((PickupObject)(object)val).SetupUnlockOnCustomFlag(CustomDungeonFlags.ADVDRAGUN_KILLED_BULLET, requiredFlagValue: true);
	}
}
