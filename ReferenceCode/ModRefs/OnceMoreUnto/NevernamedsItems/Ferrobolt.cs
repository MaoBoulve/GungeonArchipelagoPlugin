using System.Collections.Generic;
using Alexandria.Assetbundle;
using Alexandria.ItemAPI;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class Ferrobolt : AdvancedGunBehavior
{
	public static int ID;

	public static Projectile launchProj;

	public static bool shouldLaunchBolt;

	public static void Add()
	{
		//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_0127: Unknown result type (might be due to invalid IL or missing references)
		//IL_0146: Unknown result type (might be due to invalid IL or missing references)
		//IL_017a: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0310: Unknown result type (might be due to invalid IL or missing references)
		//IL_033d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0342: Unknown result type (might be due to invalid IL or missing references)
		//IL_0349: Unknown result type (might be due to invalid IL or missing references)
		//IL_0356: Expected O, but got Unknown
		//IL_0377: Unknown result type (might be due to invalid IL or missing references)
		//IL_039d: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Ferrobolt", "ferrobolt");
		Game.Items.Rename("outdated_gun_mods:ferrobolt", "nn:ferrobolt");
		Ferrobolt ferrobolt = ((Component)val).gameObject.AddComponent<Ferrobolt>();
		((AdvancedGunBehavior)ferrobolt).preventNormalFireAudio = true;
		GunExt.SetShortDescription((PickupObject)(object)val, "Law of Attraction");
		GunExt.SetLongDescription((PickupObject)(object)val, "Fires alternating monopolar electromagnetic blasts.\n\nUpon the discovery of the first monopole, the tech was immediately weaponised.");
		val.SetGunSprites("ferrobolt");
		PickupObject byId = PickupObjectDatabase.GetById(86);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId is Gun) ? byId : null), true, false);
		ref string gunSwitchGroup = ref val.gunSwitchGroup;
		PickupObject byId2 = PickupObjectDatabase.GetById(150);
		gunSwitchGroup = ((Gun)((byId2 is Gun) ? byId2 : null)).gunSwitchGroup;
		val.DefaultModule.ammoCost = 1;
		val.doesScreenShake = true;
		val.DefaultModule.shootStyle = (ShootStyle)3;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)1;
		val.reloadTime = 0.5f;
		val.DefaultModule.cooldownTime = 0.2f;
		val.DefaultModule.angleVariance = 0f;
		ref VFXPool muzzleFlashEffects = ref val.muzzleFlashEffects;
		PickupObject byId3 = PickupObjectDatabase.GetById(23);
		muzzleFlashEffects = ((Gun)((byId3 is Gun) ? byId3 : null)).muzzleFlashEffects;
		val.DefaultModule.numberOfShotsInClip = 8;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(2.1875f, 0.4375f, 0f);
		val.SetBaseMaxAmmo(100);
		val.ammo = 100;
		val.gunClass = (GunClass)60;
		GunExt.SetAnimationFPS(val, val.chargeAnimation, 8);
		GunExt.SetAnimationFPS(val, val.reloadAnimation, 10);
		((Component)val).GetComponent<tk2dSpriteAnimator>().GetClipByName(val.chargeAnimation).wrapMode = (WrapMode)1;
		((Component)val).GetComponent<tk2dSpriteAnimator>().GetClipByName(val.chargeAnimation).loopStart = 2;
		((Component)val).GetComponent<tk2dSpriteAnimator>().GetClipByName(val.shootAnimation).frames[0].eventAudio = "Play_wpn_chargelaser_shot_01";
		((Component)val).GetComponent<tk2dSpriteAnimator>().GetClipByName(val.shootAnimation).frames[0].triggerEvent = true;
		Projectile component = FakePrefabExtensions.InstantiateAndFakeprefab(((Component)val.DefaultModule.projectiles[0]).gameObject).GetComponent<Projectile>();
		component.baseData.damage = 0f;
		component.baseData.force = 0f;
		NoCollideBehaviour noCollideBehaviour = ((Component)component).gameObject.AddComponent<NoCollideBehaviour>();
		noCollideBehaviour.worksOnEnemies = true;
		noCollideBehaviour.worksOnProjectiles = true;
		BounceProjModifier val2 = ((Component)component).gameObject.AddComponent<BounceProjModifier>();
		val2.numberOfBounces = 100;
		FerroboltOrbController ferroboltOrbController = ((Component)component).gameObject.AddComponent<FerroboltOrbController>();
		SlowDownOverTimeModifier slowDownOverTimeModifier = ((Component)component).gameObject.AddComponent<SlowDownOverTimeModifier>();
		slowDownOverTimeModifier.timeToSlowOver = 0.5f;
		slowDownOverTimeModifier.killAfterCompleteStop = true;
		slowDownOverTimeModifier.timeTillKillAfterCompleteStop = 12f;
		ref GameObject overrideMidairDeathVFX = ref component.hitEffects.overrideMidairDeathVFX;
		PickupObject byId4 = PickupObjectDatabase.GetById(57);
		overrideMidairDeathVFX = ((Gun)((byId4 is Gun) ? byId4 : null)).DefaultModule.projectiles[0].hitEffects.overrideMidairDeathVFX;
		component.hitEffects.alwaysUseMidair = true;
		ProjectileBuilders.AnimateProjectileBundle(component, "FerroboltOrbProjectile", Initialisation.ProjectileCollection, Initialisation.projectileAnimationCollection, "FerroboltOrbProjectile", MiscTools.DupeList<IntVector2>(new IntVector2(14, 14), 4), MiscTools.DupeList(value: true, 4), MiscTools.DupeList<Anchor>((Anchor)4, 4), MiscTools.DupeList(value: true, 4), MiscTools.DupeList(value: false, 4), MiscTools.DupeList<Vector3?>(null, 4), MiscTools.DupeList((IntVector2?)new IntVector2(8, 8), 4), MiscTools.DupeList<IntVector2?>(null, 4), MiscTools.DupeList<Projectile>(null, 4));
		ChargeProjectile item = new ChargeProjectile
		{
			Projectile = component,
			ChargeTime = 0.5f
		};
		val.DefaultModule.chargeProjectiles = new List<ChargeProjectile> { item };
		val.DefaultModule.ammoType = (AmmoType)14;
		val.DefaultModule.customAmmoType = CustomClipAmmoTypeToolbox.AddCustomAmmoType("Ferrobolt Bullets", "NevernamedsItems/Resources/CustomGunAmmoTypes/ferrobolt_clipfull", "NevernamedsItems/Resources/CustomGunAmmoTypes/ferrobolt_clipempty");
		((PickupObject)val).quality = (ItemQuality)2;
		Databases.Items.Add((PickupObject)(object)val, false, "ANY");
		ID = ((PickupObject)val).PickupObjectId;
		PickupObject byId5 = PickupObjectDatabase.GetById(56);
		Projectile component2 = FakePrefabExtensions.InstantiateAndFakeprefab(((Component)((Gun)((byId5 is Gun) ? byId5 : null)).DefaultModule.projectiles[0]).gameObject).GetComponent<Projectile>();
		component2.baseData.damage = 30f;
		ProjectileData baseData = component2.baseData;
		baseData.speed *= 2f;
		ProjectileData baseData2 = component2.baseData;
		baseData2.force *= 2f;
		PierceProjModifier val3 = ((Component)component2).gameObject.AddComponent<PierceProjModifier>();
		val3.penetration = 100;
		component2.pierceMinorBreakables = true;
		component2.SetProjectileSprite("ferrobolt_bolt_001", 19, 8, lightened: true, (Anchor)4, 16, 6, anchorChangesCollider: true, fixesScale: false, null, null);
		ref GameObject overrideMidairDeathVFX2 = ref component2.hitEffects.overrideMidairDeathVFX;
		PickupObject byId6 = PickupObjectDatabase.GetById(57);
		overrideMidairDeathVFX2 = ((Gun)((byId6 is Gun) ? byId6 : null)).DefaultModule.chargeProjectiles[0].Projectile.hitEffects.overrideMidairDeathVFX;
		component2.hitEffects.alwaysUseMidair = true;
		((Component)component2).gameObject.AddComponent<FerroboltBoltController>();
		launchProj = component2;
	}
}
