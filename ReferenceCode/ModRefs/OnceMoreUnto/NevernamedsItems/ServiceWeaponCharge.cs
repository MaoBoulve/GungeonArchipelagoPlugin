using System.Collections.Generic;
using Alexandria.ItemAPI;
using Alexandria.Misc;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class ServiceWeaponCharge : AdvancedGunBehavior
{
	public static int ID;

	public static void Add()
	{
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0110: Unknown result type (might be due to invalid IL or missing references)
		//IL_0180: Unknown result type (might be due to invalid IL or missing references)
		//IL_018c: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0305: Unknown result type (might be due to invalid IL or missing references)
		//IL_030a: Unknown result type (might be due to invalid IL or missing references)
		//IL_031a: Unknown result type (might be due to invalid IL or missing references)
		//IL_032a: Unknown result type (might be due to invalid IL or missing references)
		//IL_033a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0345: Unknown result type (might be due to invalid IL or missing references)
		//IL_0350: Unknown result type (might be due to invalid IL or missing references)
		//IL_0357: Unknown result type (might be due to invalid IL or missing references)
		//IL_0362: Unknown result type (might be due to invalid IL or missing references)
		//IL_0369: Unknown result type (might be due to invalid IL or missing references)
		//IL_0370: Unknown result type (might be due to invalid IL or missing references)
		//IL_037b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0382: Unknown result type (might be due to invalid IL or missing references)
		//IL_038d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0394: Unknown result type (might be due to invalid IL or missing references)
		//IL_039b: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a7: Expected O, but got Unknown
		//IL_04bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_04c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_04d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_04e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_04f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_04fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0507: Unknown result type (might be due to invalid IL or missing references)
		//IL_050e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0519: Unknown result type (might be due to invalid IL or missing references)
		//IL_0520: Unknown result type (might be due to invalid IL or missing references)
		//IL_0527: Unknown result type (might be due to invalid IL or missing references)
		//IL_0532: Unknown result type (might be due to invalid IL or missing references)
		//IL_0539: Unknown result type (might be due to invalid IL or missing references)
		//IL_0544: Unknown result type (might be due to invalid IL or missing references)
		//IL_054b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0552: Unknown result type (might be due to invalid IL or missing references)
		//IL_055e: Expected O, but got Unknown
		//IL_0688: Unknown result type (might be due to invalid IL or missing references)
		//IL_068d: Unknown result type (might be due to invalid IL or missing references)
		//IL_069d: Unknown result type (might be due to invalid IL or missing references)
		//IL_06ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_06bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_06c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_06d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_06da: Unknown result type (might be due to invalid IL or missing references)
		//IL_06e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_06ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_06f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_06fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0705: Unknown result type (might be due to invalid IL or missing references)
		//IL_0710: Unknown result type (might be due to invalid IL or missing references)
		//IL_0717: Unknown result type (might be due to invalid IL or missing references)
		//IL_071e: Unknown result type (might be due to invalid IL or missing references)
		//IL_072a: Expected O, but got Unknown
		//IL_072a: Unknown result type (might be due to invalid IL or missing references)
		//IL_072f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0736: Unknown result type (might be due to invalid IL or missing references)
		//IL_0743: Expected O, but got Unknown
		//IL_0743: Unknown result type (might be due to invalid IL or missing references)
		//IL_0748: Unknown result type (might be due to invalid IL or missing references)
		//IL_074f: Unknown result type (might be due to invalid IL or missing references)
		//IL_075c: Expected O, but got Unknown
		//IL_075c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0761: Unknown result type (might be due to invalid IL or missing references)
		//IL_0769: Unknown result type (might be due to invalid IL or missing references)
		//IL_0776: Expected O, but got Unknown
		//IL_07a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_07c1: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Charge", "serviceweaponcharge");
		Game.Items.Rename("outdated_gun_mods:charge", "nn:service_weapon+charge");
		((Component)val).gameObject.AddComponent<ServiceWeaponCharge>();
		GunExt.SetShortDescription((PickupObject)(object)val, "");
		GunExt.SetLongDescription((PickupObject)(object)val, "");
		val.SetGunSprites("serviceweaponcharge", 8, noAmmonomicon: true);
		GunExt.SetAnimationFPS(val, val.shootAnimation, 12);
		GunExt.SetAnimationFPS(val, val.reloadAnimation, 12);
		GunExt.SetAnimationFPS(val, val.chargeAnimation, 4);
		ref string gunSwitchGroup = ref val.gunSwitchGroup;
		PickupObject byId = PickupObjectDatabase.GetById(124);
		gunSwitchGroup = ((Gun)((byId is Gun) ? byId : null)).gunSwitchGroup;
		ref VFXPool muzzleFlashEffects = ref val.muzzleFlashEffects;
		PickupObject byId2 = PickupObjectDatabase.GetById(362);
		muzzleFlashEffects = ((Gun)((byId2 is Gun) ? byId2 : null)).muzzleFlashEffects;
		PickupObject byId3 = PickupObjectDatabase.GetById(56);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId3 is Gun) ? byId3 : null), true, false);
		((Component)val).GetComponent<tk2dSpriteAnimator>().GetClipByName(val.reloadAnimation).wrapMode = (WrapMode)1;
		((Component)val).GetComponent<tk2dSpriteAnimator>().GetClipByName(val.reloadAnimation).loopStart = 2;
		((Component)val).GetComponent<tk2dSpriteAnimator>().GetClipByName(val.chargeAnimation).wrapMode = (WrapMode)1;
		((Component)val).GetComponent<tk2dSpriteAnimator>().GetClipByName(val.chargeAnimation).loopStart = 10;
		((Component)val).GetComponent<tk2dSpriteAnimator>().GetClipByName(val.shootAnimation).frames[0].eventAudio = "Play_wpn_chargelaser_shot_01";
		((Component)val).GetComponent<tk2dSpriteAnimator>().GetClipByName(val.shootAnimation).frames[0].triggerEvent = true;
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.shootStyle = (ShootStyle)3;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 1f;
		val.DefaultModule.cooldownTime = 0.1f;
		val.DefaultModule.numberOfShotsInClip = -1;
		val.DefaultModule.angleVariance = 0f;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(2.0625f, 1f, 0f);
		val.SetBaseMaxAmmo(3);
		val.gunClass = (GunClass)60;
		PickupObject byId4 = PickupObjectDatabase.GetById(56);
		Projectile val2 = ProjectileUtility.InstantiateAndFakeprefab(((Gun)((byId4 is Gun) ? byId4 : null)).DefaultModule.projectiles[0]);
		val.DefaultModule.projectiles[0] = val2;
		val2.baseData.damage = 10f;
		ProjectileData baseData = val2.baseData;
		baseData.speed *= 1.2f;
		val2.SetProjectileSprite("serviceweapon_proj", 11, 6, lightened: true, (Anchor)4, 10, 5, anchorChangesCollider: true, fixesScale: false, null, null);
		ref GameObject overrideMidairDeathVFX = ref val2.hitEffects.overrideMidairDeathVFX;
		PickupObject byId5 = PickupObjectDatabase.GetById(178);
		overrideMidairDeathVFX = ((Component)((byId5 is Gun) ? byId5 : null)).GetComponent<FireOnReloadSynergyProcessor>().DirectedBurstSettings.ProjectileInterface.SpecifiedProjectile.hitEffects.tileMapHorizontal.effects[0].effects[0].effect;
		val2.hitEffects.alwaysUseMidair = true;
		ImplosionBehaviour implosionBehaviour = ((Component)val2).gameObject.AddComponent<ImplosionBehaviour>();
		implosionBehaviour.waitTime = 0.2f;
		implosionBehaviour.Suck = true;
		implosionBehaviour.explosionData = new ExplosionData
		{
			effect = StaticExplosionDatas.explosiveRoundsExplosion.effect,
			ignoreList = StaticExplosionDatas.explosiveRoundsExplosion.ignoreList,
			ss = StaticExplosionDatas.explosiveRoundsExplosion.ss,
			damageRadius = 5f,
			damageToPlayer = 0f,
			doDamage = true,
			damage = 45f,
			doDestroyProjectiles = false,
			doForce = true,
			debrisForce = 30f,
			preventPlayerForce = true,
			explosionDelay = 0.1f,
			usesComprehensiveDelay = false,
			doScreenShake = true,
			playDefaultSFX = true
		};
		PickupObject byId6 = PickupObjectDatabase.GetById(56);
		Projectile val3 = ProjectileUtility.InstantiateAndFakeprefab(((Gun)((byId6 is Gun) ? byId6 : null)).DefaultModule.projectiles[0]);
		val3.baseData.damage = 10f;
		ProjectileData baseData2 = val3.baseData;
		baseData2.speed *= 1.4f;
		val3.SetProjectileSprite("serviceweapon_proj", 11, 6, lightened: true, (Anchor)4, 10, 5, anchorChangesCollider: true, fixesScale: false, null, null);
		val3.AdditionalScaleMultiplier = 1.1f;
		ref GameObject overrideMidairDeathVFX2 = ref val3.hitEffects.overrideMidairDeathVFX;
		PickupObject byId7 = PickupObjectDatabase.GetById(178);
		overrideMidairDeathVFX2 = ((Component)((byId7 is Gun) ? byId7 : null)).GetComponent<FireOnReloadSynergyProcessor>().DirectedBurstSettings.ProjectileInterface.SpecifiedProjectile.hitEffects.tileMapHorizontal.effects[0].effects[0].effect;
		val3.hitEffects.alwaysUseMidair = true;
		((Component)val3).gameObject.AddComponent<DrainClipBehav>().shotsToDrain = 1;
		ImplosionBehaviour implosionBehaviour2 = ((Component)val3).gameObject.AddComponent<ImplosionBehaviour>();
		implosionBehaviour2.waitTime = 0.6f;
		implosionBehaviour2.Suck = true;
		implosionBehaviour2.explosionData = new ExplosionData
		{
			effect = StaticExplosionDatas.genericLargeExplosion.effect,
			ignoreList = StaticExplosionDatas.genericLargeExplosion.ignoreList,
			ss = StaticExplosionDatas.genericLargeExplosion.ss,
			damageRadius = 5f,
			damageToPlayer = 0f,
			doDamage = true,
			damage = 90f,
			doDestroyProjectiles = false,
			doForce = true,
			debrisForce = 30f,
			preventPlayerForce = true,
			explosionDelay = 0.1f,
			usesComprehensiveDelay = false,
			doScreenShake = true,
			playDefaultSFX = true
		};
		PickupObject byId8 = PickupObjectDatabase.GetById(56);
		Projectile val4 = ProjectileUtility.InstantiateAndFakeprefab(((Gun)((byId8 is Gun) ? byId8 : null)).DefaultModule.projectiles[0]);
		val4.baseData.damage = 10f;
		ProjectileData baseData3 = val4.baseData;
		baseData3.speed *= 1.6f;
		val4.SetProjectileSprite("serviceweapon_proj", 11, 6, lightened: true, (Anchor)4, 10, 5, anchorChangesCollider: true, fixesScale: false, null, null);
		val4.AdditionalScaleMultiplier = 1.2f;
		ref GameObject overrideMidairDeathVFX3 = ref val4.hitEffects.overrideMidairDeathVFX;
		PickupObject byId9 = PickupObjectDatabase.GetById(178);
		overrideMidairDeathVFX3 = ((Component)((byId9 is Gun) ? byId9 : null)).GetComponent<FireOnReloadSynergyProcessor>().DirectedBurstSettings.ProjectileInterface.SpecifiedProjectile.hitEffects.tileMapHorizontal.effects[0].effects[0].effect;
		val4.hitEffects.alwaysUseMidair = true;
		((Component)val4).gameObject.AddComponent<DrainClipBehav>().shotsToDrain = 2;
		ImplosionBehaviour implosionBehaviour3 = ((Component)val4).gameObject.AddComponent<ImplosionBehaviour>();
		implosionBehaviour3.waitTime = 1f;
		implosionBehaviour3.Suck = true;
		implosionBehaviour3.vfx = SharedVFX.HighPriestImplosionRing;
		implosionBehaviour3.explosionData = new ExplosionData
		{
			effect = StaticExplosionDatas.genericLargeExplosion.effect,
			ignoreList = StaticExplosionDatas.genericLargeExplosion.ignoreList,
			ss = StaticExplosionDatas.genericLargeExplosion.ss,
			damageRadius = 5f,
			damageToPlayer = 0f,
			doDamage = true,
			damage = 135f,
			doDestroyProjectiles = true,
			doForce = true,
			debrisForce = 30f,
			preventPlayerForce = true,
			explosionDelay = 0.1f,
			usesComprehensiveDelay = false,
			doScreenShake = true,
			playDefaultSFX = true
		};
		ChargeProjectile item = new ChargeProjectile
		{
			Projectile = val2,
			ChargeTime = 0.8f
		};
		ChargeProjectile item2 = new ChargeProjectile
		{
			Projectile = val3,
			ChargeTime = 1.6f
		};
		ChargeProjectile item3 = new ChargeProjectile
		{
			Projectile = val4,
			ChargeTime = 2.4f
		};
		val.DefaultModule.chargeProjectiles = new List<ChargeProjectile> { item, item2, item3 };
		val.DefaultModule.ammoType = (AmmoType)14;
		val.DefaultModule.customAmmoType = "Service Weapon Bullets";
		((PickupObject)val).quality = (ItemQuality)(-100);
		Databases.Items.Add(val, (tk2dSpriteCollectionData)null, "ANY");
		ID = ((PickupObject)val).PickupObjectId;
	}
}
