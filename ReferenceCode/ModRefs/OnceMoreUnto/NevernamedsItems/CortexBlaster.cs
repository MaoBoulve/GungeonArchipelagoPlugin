using System;
using System.Collections.Generic;
using Alexandria.Assetbundle;
using Alexandria.ItemAPI;
using Alexandria.Misc;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class CortexBlaster : AdvancedGunBehavior
{
	public static int ID;

	public static void Add()
	{
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0145: Unknown result type (might be due to invalid IL or missing references)
		//IL_0151: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0404: Unknown result type (might be due to invalid IL or missing references)
		//IL_0409: Unknown result type (might be due to invalid IL or missing references)
		//IL_0539: Unknown result type (might be due to invalid IL or missing references)
		//IL_0548: Unknown result type (might be due to invalid IL or missing references)
		//IL_0587: Unknown result type (might be due to invalid IL or missing references)
		//IL_058c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0701: Unknown result type (might be due to invalid IL or missing references)
		//IL_0710: Unknown result type (might be due to invalid IL or missing references)
		//IL_073f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0744: Unknown result type (might be due to invalid IL or missing references)
		//IL_074b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0756: Unknown result type (might be due to invalid IL or missing references)
		//IL_075f: Expected O, but got Unknown
		//IL_075f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0764: Unknown result type (might be due to invalid IL or missing references)
		//IL_076c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0779: Expected O, but got Unknown
		//IL_079d: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Cortex Blaster", "cortexblaster");
		Game.Items.Rename("outdated_gun_mods:cortex_blaster", "nn:cortex_blaster");
		CortexBlaster cortexBlaster = ((Component)val).gameObject.AddComponent<CortexBlaster>();
		GunExt.SetShortDescription((PickupObject)(object)val, "Crash Bang-De-Shoot");
		GunExt.SetLongDescription((PickupObject)(object)val, "The signature weapon of a mad, sad scientist. It's inner workings are complete nonsense to everyone save it's creator.\n\nCharges up to fire swirling charges of plasma.");
		GunInt.SetupSprite(val, Initialisation.gunCollection, "cortexblaster_idle_001", 8, "cortexblaster_ammonomicon_001");
		GunExt.SetAnimationFPS(val, val.shootAnimation, 15);
		GunExt.SetAnimationFPS(val, val.chargeAnimation, 10);
		GunExt.SetAnimationFPS(val, val.reloadAnimation, 15);
		ref string gunSwitchGroup = ref val.gunSwitchGroup;
		PickupObject byId = PickupObjectDatabase.GetById(13);
		gunSwitchGroup = ((Gun)((byId is Gun) ? byId : null)).gunSwitchGroup;
		PickupObject byId2 = PickupObjectDatabase.GetById(56);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId2 is Gun) ? byId2 : null), true, false);
		((Component)val).GetComponent<tk2dSpriteAnimator>().GetClipByName(val.chargeAnimation).wrapMode = (WrapMode)1;
		((Component)val).GetComponent<tk2dSpriteAnimator>().GetClipByName(val.chargeAnimation).loopStart = 3;
		((Component)val).GetComponent<tk2dSpriteAnimator>().GetClipByName(val.reloadAnimation).wrapMode = (WrapMode)1;
		((Component)val).GetComponent<tk2dSpriteAnimator>().GetClipByName(val.reloadAnimation).loopStart = 2;
		ref ScreenShakeSettings gunScreenShake = ref val.gunScreenShake;
		PickupObject byId3 = PickupObjectDatabase.GetById(23);
		gunScreenShake = ((Gun)((byId3 is Gun) ? byId3 : null)).gunScreenShake;
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.shootStyle = (ShootStyle)3;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.DefaultModule.cooldownTime = 0.2f;
		val.DefaultModule.numberOfShotsInClip = 10;
		val.DefaultModule.angleVariance = 0f;
		val.reloadTime = 1f;
		ref VFXPool muzzleFlashEffects = ref val.muzzleFlashEffects;
		PickupObject byId4 = PickupObjectDatabase.GetById(334);
		muzzleFlashEffects = ((Gun)((byId4 is Gun) ? byId4 : null)).muzzleFlashEffects;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(1.9375f, 0.8125f, 0f);
		val.gunClass = (GunClass)60;
		val.SetBaseMaxAmmo(220);
		val.ammo = 220;
		Projectile val2 = ProjectileUtility.InstantiateAndFakeprefab(val.DefaultModule.projectiles[0]);
		val2.SetProjectileSprite("cortexblaster_proj", 17, 7, lightened: false, (Anchor)4, 11, 3, anchorChangesCollider: true, fixesScale: false, null, null);
		val2.hitEffects.alwaysUseMidair = true;
		val2.baseData.damage = 10f;
		ProjectileData baseData = val2.baseData;
		baseData.force *= 1.2f;
		ProjectileData baseData2 = val2.baseData;
		baseData2.speed *= 0.9f;
		val2.hitEffects.overrideMidairDeathVFX = SharedVFX.PurpleLaserCircleVFX;
		List<string> list = new List<string> { "NevernamedsItems/Resources/TrailSprites/cortexblaster_trail_001", "NevernamedsItems/Resources/TrailSprites/cortexblaster_trail_002", "NevernamedsItems/Resources/TrailSprites/cortexblaster_trail_003" };
		PickupObject byId5 = PickupObjectDatabase.GetById(56);
		ImprovedHelixProjectile val3 = DataCloners.CopyFields<ImprovedHelixProjectile>(Object.Instantiate<Projectile>(((Gun)((byId5 is Gun) ? byId5 : null)).DefaultModule.projectiles[0]));
		val3.SpawnShadowBulletsOnSpawn = false;
		FakePrefabExtensions.MakeFakePrefab(((Component)val3).gameObject);
		((Projectile)(object)val3).SetProjectileSprite("cortexblaster_proj", 17, 7, lightened: false, (Anchor)4, 11, 3, anchorChangesCollider: true, fixesScale: false, null, null);
		((Projectile)val3).hitEffects.alwaysUseMidair = true;
		((Projectile)val3).hitEffects.overrideMidairDeathVFX = SharedVFX.PurpleLaserCircleVFX;
		((Projectile)val3).baseData.damage = 11f;
		ProjectileData baseData3 = ((Projectile)val3).baseData;
		baseData3.force *= 1.2f;
		((Projectile)val3).pierceMinorBreakables = true;
		ProjectileData baseData4 = ((Projectile)val3).baseData;
		baseData4.speed *= 0.9f;
		((Component)val3).gameObject.AddComponent<PierceProjModifier>();
		TrailAPI.AddTrailToProjectile((Projectile)(object)val3, "NevernamedsItems/Resources/TrailSprites/cortexblaster_trail_001", new Vector2(6f, 4f), new Vector2(0f, 1f), list, 20, list, 20, -1f, 0.0001f, -1f, true, true);
		GameObjectExtensions.GetOrAddComponent<EmmisiveTrail>(((Component)val3).gameObject);
		StatusEffectBulletSynergy orAddComponent = GameObjectExtensions.GetOrAddComponent<StatusEffectBulletSynergy>(((Component)val3).gameObject);
		orAddComponent.tint = ExtendedColours.freezeBlue;
		orAddComponent.StatusEffects.AddRange(new List<GameActorEffect> { (GameActorEffect)(object)StaticStatusEffects.frostBulletsEffect });
		orAddComponent.synergyToCheckFor = "It's About Rime";
		PickupObject byId6 = PickupObjectDatabase.GetById(56);
		ImprovedHelixProjectile val4 = DataCloners.CopyFields<ImprovedHelixProjectile>(Object.Instantiate<Projectile>(((Gun)((byId6 is Gun) ? byId6 : null)).DefaultModule.projectiles[0]));
		val4.SpawnShadowBulletsOnSpawn = false;
		FakePrefabExtensions.MakeFakePrefab(((Component)val4).gameObject);
		((Projectile)(object)val4).SetProjectileSprite("cortexblaster_proj", 17, 7, lightened: false, (Anchor)4, 11, 3, anchorChangesCollider: true, fixesScale: false, null, null);
		((Projectile)val4).hitEffects.alwaysUseMidair = true;
		((Projectile)val4).hitEffects.overrideMidairDeathVFX = SharedVFX.PurpleLaserCircleVFX;
		val4.startInverted = true;
		((Projectile)val4).baseData.damage = 11f;
		ProjectileData baseData5 = ((Projectile)val4).baseData;
		baseData5.force *= 1.2f;
		ProjectileData baseData6 = ((Projectile)val4).baseData;
		baseData6.speed *= 0.9f;
		((Projectile)val4).pierceMinorBreakables = true;
		((Component)val4).gameObject.AddComponent<PierceProjModifier>();
		TrailAPI.AddTrailToProjectile((Projectile)(object)val4, "NevernamedsItems/Resources/TrailSprites/cortexblaster_trail_001", new Vector2(6f, 4f), new Vector2(0f, 1f), list, 20, list, 20, -1f, 0.0001f, -1f, true, true);
		GameObjectExtensions.GetOrAddComponent<EmmisiveTrail>(((Component)val4).gameObject);
		StatusEffectBulletSynergy orAddComponent2 = GameObjectExtensions.GetOrAddComponent<StatusEffectBulletSynergy>(((Component)val4).gameObject);
		orAddComponent2.tint = ExtendedColours.freezeBlue;
		orAddComponent2.StatusEffects.AddRange(new List<GameActorEffect> { (GameActorEffect)(object)StaticStatusEffects.frostBulletsEffect });
		orAddComponent2.synergyToCheckFor = "It's About Rime";
		PickupObject byId7 = PickupObjectDatabase.GetById(56);
		Projectile val5 = ProjectileUtility.InstantiateAndFakeprefab(((Gun)((byId7 is Gun) ? byId7 : null)).DefaultModule.projectiles[0]);
		val5.SetProjectileSprite("cortexblaster_proj", 17, 7, lightened: false, (Anchor)4, 11, 3, anchorChangesCollider: true, fixesScale: false, null, null);
		val5.hitEffects.alwaysUseMidair = true;
		val5.hitEffects.overrideMidairDeathVFX = SharedVFX.PurpleLaserCircleVFX;
		val5.baseData.damage = 11f;
		ProjectileData baseData7 = val5.baseData;
		baseData7.force *= 1.2f;
		ProjectileData baseData8 = val5.baseData;
		baseData8.speed *= 0.9f;
		((Component)val5).gameObject.AddComponent<PierceProjModifier>();
		((Component)val5).gameObject.AddComponent<BounceProjModifier>();
		((Object)((Component)val5).gameObject).name = "CortexBlaster_Main_ChargeProj";
		SneakyShotgunComponent sneakyShotgunComponent = ((Component)val5).gameObject.AddComponent<SneakyShotgunComponent>();
		sneakyShotgunComponent.eraseSource = false;
		sneakyShotgunComponent.angleVariance = 0f;
		sneakyShotgunComponent.doVelocityRandomiser = false;
		sneakyShotgunComponent.useComplexPrefabs = true;
		sneakyShotgunComponent.complexPrefabs.Add((Projectile)(object)val3);
		sneakyShotgunComponent.complexPrefabs.Add((Projectile)(object)val4);
		TrailAPI.AddTrailToProjectile(val5, "NevernamedsItems/Resources/TrailSprites/cortexblaster_trail_001", new Vector2(6f, 4f), new Vector2(0f, 1f), list, 20, list, 20, -1f, 0.0001f, -1f, true, true);
		GameObjectExtensions.GetOrAddComponent<EmmisiveTrail>(((Component)val5).gameObject);
		ChargeProjectile item = new ChargeProjectile
		{
			Projectile = val2,
			ChargeTime = 0f,
			VfxPool = null
		};
		ChargeProjectile item2 = new ChargeProjectile
		{
			Projectile = val5,
			ChargeTime = 0.5f
		};
		val.DefaultModule.chargeProjectiles = new List<ChargeProjectile> { item, item2 };
		((PickupObject)val).quality = (ItemQuality)3;
		Databases.Items.Add(val, (tk2dSpriteCollectionData)null, "ANY");
		ID = ((PickupObject)val).PickupObjectId;
	}

	public override void PostProcessProjectile(Projectile projectile)
	{
		if (Object.op_Implicit((Object)(object)base.gun) && Object.op_Implicit((Object)(object)GunTools.GunPlayerOwner(base.gun)) && CustomSynergies.PlayerHasActiveSynergy(GunTools.GunPlayerOwner(base.gun), "Hidden Gem") && ((Object)((Component)projectile).gameObject).name.Contains("CortexBlaster_Main_ChargeProj"))
		{
			BounceProjModifier component = ((Component)projectile).gameObject.GetComponent<BounceProjModifier>();
			if (Object.op_Implicit((Object)(object)component))
			{
				component.OnBounceContext = (Action<BounceProjModifier, SpeculativeRigidbody>)Delegate.Combine(component.OnBounceContext, new Action<BounceProjModifier, SpeculativeRigidbody>(BounceProjContext));
			}
		}
		((AdvancedGunBehavior)this).PostProcessProjectile(projectile);
	}

	public void BounceProjContext(BounceProjModifier mod, SpeculativeRigidbody spec)
	{
		if (Object.op_Implicit((Object)(object)mod) && Object.op_Implicit((Object)(object)((BraveBehaviour)mod).projectile))
		{
			ProjectileData baseData = ((BraveBehaviour)mod).projectile.baseData;
			baseData.damage *= 1.4f;
			HomingModifier orAddComponent = GameObjectExtensions.GetOrAddComponent<HomingModifier>(((Component)((BraveBehaviour)mod).projectile).gameObject);
			orAddComponent.AngularVelocity = 360f;
			orAddComponent.HomingRadius = 5f;
		}
	}
}
