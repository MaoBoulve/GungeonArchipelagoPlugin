using Alexandria.ItemAPI;
using Alexandria.Misc;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class BouncerRPG : AdvancedGunBehavior
{
	public static int ID;

	public static void Add()
	{
		//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_011c: Unknown result type (might be due to invalid IL or missing references)
		//IL_013b: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c9: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Bouncer RPG", "bouncerrpg");
		Game.Items.Rename("outdated_gun_mods:bouncer_rpg", "nn:bouncer_rpg");
		((Component)val).gameObject.AddComponent<BouncerRPG>();
		GunExt.SetShortDescription((PickupObject)(object)val, "Kaboing");
		GunExt.SetLongDescription((PickupObject)(object)val, "The payload of this standard rocket propelled grenade has been coated in rubber, allowing it to ricochet once before detonating.");
		val.SetGunSprites("bouncerrpg");
		GunExt.SetAnimationFPS(val, val.shootAnimation, 12);
		PickupObject byId = PickupObjectDatabase.GetById(56);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId is Gun) ? byId : null), true, false);
		ref string gunSwitchGroup = ref val.gunSwitchGroup;
		PickupObject byId2 = PickupObjectDatabase.GetById(39);
		gunSwitchGroup = ((Gun)((byId2 is Gun) ? byId2 : null)).gunSwitchGroup;
		ref VFXPool muzzleFlashEffects = ref val.muzzleFlashEffects;
		PickupObject byId3 = PickupObjectDatabase.GetById(39);
		muzzleFlashEffects = ((Gun)((byId3 is Gun) ? byId3 : null)).muzzleFlashEffects;
		val.doesScreenShake = false;
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.shootStyle = (ShootStyle)0;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 2.5f;
		val.DefaultModule.cooldownTime = 1f;
		val.DefaultModule.numberOfShotsInClip = 2;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(1.625f, 0.75f, 0f);
		val.SetBaseMaxAmmo(35);
		val.ammo = 35;
		val.gunClass = (GunClass)45;
		Projectile val2 = ProjectileUtility.InstantiateAndFakeprefab(val.DefaultModule.projectiles[0]);
		SimpleProjectileTrail simpleProjectileTrail = ((Component)val2).gameObject.AddComponent<SimpleProjectileTrail>();
		simpleProjectileTrail.addSmoke = true;
		val2.baseData.UsesCustomAccelerationCurve = true;
		ref AnimationCurve accelerationCurve = ref val2.baseData.AccelerationCurve;
		PickupObject byId4 = PickupObjectDatabase.GetById(39);
		accelerationCurve = ((Gun)((byId4 is Gun) ? byId4 : null)).DefaultModule.projectiles[0].baseData.AccelerationCurve;
		BounceProjModifier val3 = ((Component)val2).gameObject.AddComponent<BounceProjModifier>();
		val3.numberOfBounces = 1;
		StatModifyOnBounce statModifyOnBounce = ((Component)val2).gameObject.AddComponent<StatModifyOnBounce>();
		statModifyOnBounce.mods.Add(new StatModifyOnBounce.Modifiers
		{
			stattype = StatModifyOnBounce.ProjectileStatType.SPEED,
			amount = 2f
		});
		statModifyOnBounce.mods.Add(new StatModifyOnBounce.Modifiers
		{
			stattype = StatModifyOnBounce.ProjectileStatType.DAMAGE,
			amount = 2f
		});
		ExplosiveModifier val4 = ((Component)val2).gameObject.AddComponent<ExplosiveModifier>();
		val4.doExplosion = true;
		ref ExplosionData explosionData = ref val4.explosionData;
		PickupObject byId5 = PickupObjectDatabase.GetById(39);
		explosionData = ((Component)((Gun)((byId5 is Gun) ? byId5 : null)).DefaultModule.projectiles[0]).GetComponent<ExplosiveModifier>().explosionData;
		val2.SetProjectileSprite("bouncerrpg_proj", 10, 9, lightened: false, (Anchor)4, 9, 8, anchorChangesCollider: true, fixesScale: false, null, null);
		val.DefaultModule.projectiles[0] = val2;
		val.DefaultModule.ammoType = (AmmoType)14;
		val.DefaultModule.customAmmoType = CustomClipAmmoTypeToolbox.AddCustomAmmoType("BouncerRPG Ammo", "NevernamedsItems/Resources/CustomGunAmmoTypes/bouncerrpg_clipfull", "NevernamedsItems/Resources/CustomGunAmmoTypes/bouncerrpg_clipempty");
		((PickupObject)val).quality = (ItemQuality)3;
		Databases.Items.Add(val, (tk2dSpriteCollectionData)null, "ANY");
		ID = ((PickupObject)val).PickupObjectId;
	}
}
