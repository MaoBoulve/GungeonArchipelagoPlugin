using System;
using System.Collections.Generic;
using Alexandria.Assetbundle;
using Alexandria.ItemAPI;
using Alexandria.Misc;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class HookGun : GunBehaviour
{
	public class FakeBoomerangController : BraveBehaviour
	{
		private float cachedSpeed = 0f;

		private void Start()
		{
			cachedSpeed = ((BraveBehaviour)this).projectile.baseData.speed;
			((BraveBehaviour)this).projectile.baseData.range = 100f;
			SlowDownOverTimeModifier component = ((Component)((BraveBehaviour)this).projectile).GetComponent<SlowDownOverTimeModifier>();
			component.OnCompleteStop = (Action<Projectile>)Delegate.Combine(component.OnCompleteStop, new Action<Projectile>(OnStop));
		}

		private void OnStop(Projectile self)
		{
			//IL_004a: Unknown result type (might be due to invalid IL or missing references)
			//IL_005a: Unknown result type (might be due to invalid IL or missing references)
			SlowDownOverTimeModifier component = ((Component)((BraveBehaviour)this).projectile).GetComponent<SlowDownOverTimeModifier>();
			component.OnCompleteStop = (Action<Projectile>)Delegate.Remove(component.OnCompleteStop, new Action<Projectile>(OnStop));
			Object.Destroy((Object)(object)((Component)((BraveBehaviour)this).projectile).GetComponent<SlowDownOverTimeModifier>());
			((BraveBehaviour)this).projectile.SendInDirection(MathsAndLogicHelper.DegreeToVector2(Vector2Extensions.ToAngle(((BraveBehaviour)this).projectile.Direction) + 180f), true, true);
			SlowDownOverTimeModifier slowDownOverTimeModifier = ((Component)((BraveBehaviour)this).projectile).gameObject.AddComponent<SlowDownOverTimeModifier>();
			slowDownOverTimeModifier.doRandomTimeMultiplier = false;
			slowDownOverTimeModifier.extendTimeByRangeStat = false;
			slowDownOverTimeModifier.killAfterCompleteStop = false;
			slowDownOverTimeModifier.targetSpeed = cachedSpeed;
			slowDownOverTimeModifier.timeToSlowOver = 1f;
		}
	}

	public static int ID;

	public static void Add()
	{
		//IL_008e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0102: Unknown result type (might be due to invalid IL or missing references)
		//IL_0121: Unknown result type (might be due to invalid IL or missing references)
		//IL_014b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0153: Unknown result type (might be due to invalid IL or missing references)
		//IL_036a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0255: Unknown result type (might be due to invalid IL or missing references)
		//IL_0290: Unknown result type (might be due to invalid IL or missing references)
		//IL_0507: Unknown result type (might be due to invalid IL or missing references)
		//IL_0542: Unknown result type (might be due to invalid IL or missing references)
		//IL_0621: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Hook Gun", "hookgun");
		Game.Items.Rename("outdated_gun_mods:hook_gun", "nn:hook_gun");
		((Component)val).gameObject.AddComponent<HookGun>();
		GunExt.SetShortDescription((PickupObject)(object)val, "Gadzooks");
		GunExt.SetLongDescription((PickupObject)(object)val, "An old device, though immaculately maintained.\n\nThe Executioners of the Gungeon Proper know its true purpose.");
		val.SetGunSprites("hookgun", 8, noAmmonomicon: false, 2);
		GunExt.SetAnimationFPS(val, val.shootAnimation, 10);
		GunExt.SetAnimationFPS(val, val.reloadAnimation, 10);
		((Component)val).GetComponent<tk2dSpriteAnimator>().GetClipByName(val.reloadAnimation).wrapMode = (WrapMode)0;
		ItemBuilder.AddPassiveStatModifier((PickupObject)(object)val, (StatType)14, 1f, (ModifyMethod)0);
		ref string gunSwitchGroup = ref val.gunSwitchGroup;
		PickupObject byId = PickupObjectDatabase.GetById(124);
		gunSwitchGroup = ((Gun)((byId is Gun) ? byId : null)).gunSwitchGroup;
		for (int i = 0; i < 2; i++)
		{
			PickupObject byId2 = PickupObjectDatabase.GetById(86);
			GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId2 is Gun) ? byId2 : null), true, false);
		}
		val.reloadTime = 1f;
		val.SetBarrel(32, 8);
		val.muzzleFlashEffects.type = (VFXPoolType)0;
		val.SetBaseMaxAmmo(400);
		val.ammo = 400;
		val.gunClass = (GunClass)50;
		foreach (ProjectileModule projectile in val.Volley.projectiles)
		{
			projectile.shootStyle = (ShootStyle)0;
			projectile.sequenceStyle = (ProjectileSequenceStyle)0;
			projectile.cooldownTime = 0.25f;
			projectile.numberOfShotsInClip = 10;
			projectile.angleVariance = 0f;
			if (projectile != val.DefaultModule)
			{
				Projectile val2 = (Projectile)(object)DataCloners.CopyFields<TachyonProjectile>(Object.Instantiate<Projectile>(projectile.projectiles[0]));
				FakePrefabExtensions.MakeFakePrefab(((Component)val2).gameObject);
				val2.baseData.damage = 10f;
				((BraveBehaviour)val2).specRigidbody.CollideWithTileMap = false;
				val2.m_ignoreTileCollisionsTimer = 1f;
				val2.pierceMinorBreakables = true;
				SlowDownOverTimeModifier slowDownOverTimeModifier = ((Component)val2).gameObject.AddComponent<SlowDownOverTimeModifier>();
				slowDownOverTimeModifier.doRandomTimeMultiplier = true;
				slowDownOverTimeModifier.extendTimeByRangeStat = false;
				slowDownOverTimeModifier.killAfterCompleteStop = false;
				slowDownOverTimeModifier.targetSpeed = 0f;
				slowDownOverTimeModifier.timeToSlowOver = 1f;
				((Component)val2).gameObject.AddComponent<FakeBoomerangController>();
				projectile.ammoCost = 0;
				ProjectileBuilders.AnimateProjectileBundle(val2, "HookGunProj", Initialisation.ProjectileCollection, Initialisation.projectileAnimationCollection, "HookGunProj", MiscTools.DupeList<IntVector2>(new IntVector2(15, 15), 4), MiscTools.DupeList(value: true, 4), MiscTools.DupeList<Anchor>((Anchor)4, 4), MiscTools.DupeList(value: true, 4), MiscTools.DupeList(value: false, 4), MiscTools.DupeList<Vector3?>(null, 4), MiscTools.DupeList((IntVector2?)new IntVector2(13, 13), 4), MiscTools.DupeList<IntVector2?>(null, 4), MiscTools.DupeList<Projectile>(null, 4));
				ref GameObject overrideMidairDeathVFX = ref val2.hitEffects.overrideMidairDeathVFX;
				PickupObject byId3 = PickupObjectDatabase.GetById(417);
				overrideMidairDeathVFX = ((Gun)((byId3 is Gun) ? byId3 : null)).DefaultModule.projectiles[0].hitEffects.overrideMidairDeathVFX;
				val2.hitEffects.alwaysUseMidair = true;
				projectile.projectiles[0] = val2;
			}
			else
			{
				Projectile val3 = ProjectileSetupUtility.MakeProjectile(86, 20f);
				ModdedStatusEffectSlashBehaviour moddedStatusEffectSlashBehaviour = ((Component)val3).gameObject.AddComponent<ModdedStatusEffectSlashBehaviour>();
				((ProjectileSlashingBehaviour)moddedStatusEffectSlashBehaviour).DestroyBaseAfterFirstSlash = true;
				((ProjectileSlashingBehaviour)moddedStatusEffectSlashBehaviour).slashParameters = ScriptableObject.CreateInstance<SlashData>();
				((ProjectileSlashingBehaviour)moddedStatusEffectSlashBehaviour).slashParameters.soundEvent = null;
				((ProjectileSlashingBehaviour)moddedStatusEffectSlashBehaviour).slashParameters.projInteractMode = (ProjInteractMode)0;
				((ProjectileSlashingBehaviour)moddedStatusEffectSlashBehaviour).SlashDamageUsesBaseProjectileDamage = true;
				((ProjectileSlashingBehaviour)moddedStatusEffectSlashBehaviour).slashParameters.doVFX = false;
				((ProjectileSlashingBehaviour)moddedStatusEffectSlashBehaviour).slashParameters.doHitVFX = true;
				((ProjectileSlashingBehaviour)moddedStatusEffectSlashBehaviour).slashParameters.slashRange = 1.8125f;
				((ProjectileSlashingBehaviour)moddedStatusEffectSlashBehaviour).slashParameters.slashDegrees = 10f;
				((ProjectileSlashingBehaviour)moddedStatusEffectSlashBehaviour).slashParameters.playerKnockbackForce = 0f;
				moddedStatusEffectSlashBehaviour.appliesExsanguination = true;
				val3.baseData.damage = 7f;
				projectile.ammoCost = 1;
				projectile.projectiles[0] = val3;
			}
		}
		AdvancedVolleyModificationSynergyProcessor advancedVolleyModificationSynergyProcessor = ((Component)val).gameObject.AddComponent<AdvancedVolleyModificationSynergyProcessor>();
		AdvancedVolleyModificationSynergyData advancedVolleyModificationSynergyData = ScriptableObject.CreateInstance<AdvancedVolleyModificationSynergyData>();
		ProjectileModule val4 = ProjectileModule.CreateClone(val.DefaultModule, false, -1);
		val4.projectiles[0] = ProjectileSetupUtility.MakeProjectile(86, 10f);
		val4.projectiles[0].m_ignoreTileCollisionsTimer = 1f;
		val4.projectiles[0].pierceMinorBreakables = true;
		SlowDownOverTimeModifier slowDownOverTimeModifier2 = ((Component)val4.projectiles[0]).gameObject.AddComponent<SlowDownOverTimeModifier>();
		slowDownOverTimeModifier2.doRandomTimeMultiplier = true;
		slowDownOverTimeModifier2.extendTimeByRangeStat = false;
		slowDownOverTimeModifier2.killAfterCompleteStop = false;
		slowDownOverTimeModifier2.targetSpeed = 0f;
		slowDownOverTimeModifier2.timeToSlowOver = 1f;
		((Component)val4.projectiles[0]).gameObject.AddComponent<FakeBoomerangController>();
		ProjectileBuilders.AnimateProjectileBundle(val4.projectiles[0], "HookGunProj", Initialisation.ProjectileCollection, Initialisation.projectileAnimationCollection, "HookGunProj", MiscTools.DupeList<IntVector2>(new IntVector2(15, 15), 4), MiscTools.DupeList(value: true, 4), MiscTools.DupeList<Anchor>((Anchor)4, 4), MiscTools.DupeList(value: true, 4), MiscTools.DupeList(value: false, 4), MiscTools.DupeList<Vector3?>(null, 4), MiscTools.DupeList((IntVector2?)new IntVector2(13, 13), 4), MiscTools.DupeList<IntVector2?>(null, 4), MiscTools.DupeList<Projectile>(null, 4));
		ref GameObject overrideMidairDeathVFX2 = ref val4.projectiles[0].hitEffects.overrideMidairDeathVFX;
		PickupObject byId4 = PickupObjectDatabase.GetById(417);
		overrideMidairDeathVFX2 = ((Gun)((byId4 is Gun) ? byId4 : null)).DefaultModule.projectiles[0].hitEffects.overrideMidairDeathVFX;
		val4.projectiles[0].hitEffects.alwaysUseMidair = true;
		val4.ammoCost = 0;
		advancedVolleyModificationSynergyData.AddsModules = true;
		advancedVolleyModificationSynergyData.ModulesToAdd = new List<ProjectileModule> { val4 }.ToArray();
		advancedVolleyModificationSynergyData.RequiredSynergy = "Kalibers Hooks";
		advancedVolleyModificationSynergyProcessor.synergies.Add(advancedVolleyModificationSynergyData);
		val.AddClipDebris(0, 1, "clipdebris_hookgun");
		val.AddClipSprites("hookgun");
		((PickupObject)val).quality = (ItemQuality)2;
		Databases.Items.Add(val, (tk2dSpriteCollectionData)null, "ANY");
		ItemBuilder.AddToSubShop((PickupObject)(object)val, (ShopType)2, 1f);
		ID = ((PickupObject)val).PickupObjectId;
	}
}
