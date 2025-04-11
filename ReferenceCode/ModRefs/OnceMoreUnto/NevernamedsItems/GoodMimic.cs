using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Alexandria.ItemAPI;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

internal class GoodMimic : AdvancedGunBehavior
{
	private bool canChangeToBossWeapon = true;

	private static FieldInfo m_currentlyPlayingChargeVFX_info = typeof(Gun).GetField("m_currentlyPlayingChargeVFX", BindingFlags.Instance | BindingFlags.NonPublic);

	private static FieldInfo m_defaultLocalPosition_info = typeof(Gun).GetField("m_defaultLocalPosition", BindingFlags.Instance | BindingFlags.NonPublic);

	private static FieldInfo m_originalBarrelOffsetPosition_info = typeof(Gun).GetField("m_originalBarrelOffsetPosition", BindingFlags.Instance | BindingFlags.NonPublic);

	private static FieldInfo m_originalMuzzleOffsetPosition_info = typeof(Gun).GetField("m_originalMuzzleOffsetPosition", BindingFlags.Instance | BindingFlags.NonPublic);

	private static FieldInfo m_originalChargeOffsetPosition_info = typeof(Gun).GetField("m_originalChargeOffsetPosition", BindingFlags.Instance | BindingFlags.NonPublic);

	private static FieldInfo m_cachedGunHandedness_info = typeof(Gun).GetField("m_cachedGunHandedness", BindingFlags.Instance | BindingFlags.NonPublic);

	private static MethodInfo HandleFrameDelayedTransformation_info = typeof(Gun).GetMethod("HandleFrameDelayedTransformation", BindingFlags.Instance | BindingFlags.NonPublic);

	public static int GoodMimicID;

	public static Dictionary<string, int> Entries { get; set; } = new Dictionary<string, int>
	{
		{
			EnemyGuidDatabase.Entries["shelleton"],
			464
		},
		{
			EnemyGuidDatabase.Entries["gunzookie"],
			599
		},
		{
			EnemyGuidDatabase.Entries["gunzockie"],
			599
		},
		{
			EnemyGuidDatabase.Entries["gigi"],
			445
		},
		{
			EnemyGuidDatabase.Entries["bird_parrot"],
			445
		},
		{
			EnemyGuidDatabase.Entries["skusket"],
			45
		},
		{
			EnemyGuidDatabase.Entries["black_skusket"],
			45
		},
		{
			EnemyGuidDatabase.Entries["skusket_head"],
			45
		},
		{
			EnemyGuidDatabase.Entries["muzzle_wisp"],
			125
		},
		{
			EnemyGuidDatabase.Entries["muzzle_flare"],
			698
		},
		{
			EnemyGuidDatabase.Entries["grenade_kin"],
			19
		},
		{
			EnemyGuidDatabase.Entries["mountain_cube"],
			130
		},
		{
			EnemyGuidDatabase.Entries["shambling_round"],
			23
		},
		{
			EnemyGuidDatabase.Entries["fuselier"],
			332
		},
		{
			EnemyGuidDatabase.Entries["bullet_shark"],
			Gunshark.GunsharkID
		},
		{
			EnemyGuidDatabase.Entries["bookllet"],
			Bookllet.BooklletID
		},
		{
			EnemyGuidDatabase.Entries["blue_bookllet"],
			Bookllet.BooklletID
		},
		{
			EnemyGuidDatabase.Entries["green_bookllet"],
			Bookllet.BooklletID
		},
		{
			EnemyGuidDatabase.Entries["necronomicon"],
			Bookllet.BooklletID
		},
		{
			EnemyGuidDatabase.Entries["bombshee"],
			3
		},
		{
			EnemyGuidDatabase.Entries["bullet_king"],
			551
		},
		{
			EnemyGuidDatabase.Entries["gatling_gull"],
			84
		},
		{
			EnemyGuidDatabase.Entries["treadnaught"],
			486
		},
		{
			EnemyGuidDatabase.Entries["cannonbalrog"],
			37
		},
		{
			EnemyGuidDatabase.Entries["dragun"],
			146
		},
		{
			EnemyGuidDatabase.Entries["dragun_advanced"],
			670
		},
		{
			EnemyGuidDatabase.Entries["helicopter_agunim"],
			707
		},
		{
			EnemyGuidDatabase.Entries["tazie"],
			StunGun.StunGunID
		},
		{
			EnemyGuidDatabase.Entries["gun_nut"],
			BulletBlade.BulletBladeID
		},
		{
			EnemyGuidDatabase.Entries["spectral_gun_nut"],
			BulletBladeGhostForme.GhostBladeID
		},
		{
			EnemyGuidDatabase.Entries["hooded_bullet"],
			761
		},
		{
			EnemyGuidDatabase.Entries["fungun"],
			FungoCannon.FungoCannonID
		},
		{
			EnemyGuidDatabase.Entries["spogre"],
			FungoCannon.FungoCannonID
		},
		{
			EnemyGuidDatabase.Entries["key_bullet_kin"],
			Rekeyter.RekeyterID
		},
		{
			EnemyGuidDatabase.Entries["lore_gunjurer"],
			Lorebook.LorebookID
		},
		{
			EnemyGuidDatabase.Entries["blizzbulon"],
			Icicle.IcicleID
		},
		{
			EnemyGuidDatabase.Entries["phaser_spider"],
			PhaserSpiderling.PhaserSpiderlingID
		},
		{
			EnemyGuidDatabase.Entries["lead_maiden"],
			MaidenRifle.MaidenRifleID
		},
		{
			EnemyGuidDatabase.Entries["bullat"],
			Bullatterer.BullattererID
		},
		{
			EnemyGuidDatabase.Entries["spirat"],
			Bullatterer.BullattererID
		},
		{
			EnemyGuidDatabase.Entries["grenat"],
			Bullatterer.BullattererID
		},
		{
			EnemyGuidDatabase.Entries["shotgat"],
			Bullatterer.BullattererID
		},
		{
			EnemyGuidDatabase.Entries["king_bullat"],
			KingBullatterer.KingBullattererID
		},
		{
			EnemyGuidDatabase.Entries["gargoyle"],
			KingBullatterer.KingBullattererID
		},
		{
			EnemyGuidDatabase.Entries["dynamite_kin"],
			DynamiteLauncher.DynamiteLauncherID
		},
		{
			EnemyGuidDatabase.Entries["misfire_beast"],
			Beastclaw.BeastclawID
		},
		{
			ModdedGUIDDatabase.ExpandTheGungeonGUIDs["com4nd0_boss"],
			HeavyAssaultRifle.HeavyAssaultRifleID
		},
		{
			ModdedGUIDDatabase.ExpandTheGungeonGUIDs["parasitic_abomination"],
			333
		},
		{
			ModdedGUIDDatabase.ExpandTheGungeonGUIDs["cronenberg"],
			333
		},
		{
			ModdedGUIDDatabase.ExpandTheGungeonGUIDs["agressive_cronenberg"],
			333
		},
		{
			EnemyGuidDatabase.Entries["great_bullet_shark"],
			GunsharkMegasharkSynergyForme.GunsharkMegasharkSynergyFormeID
		}
	};

	public static Dictionary<string, int> SpecialOverrideGuns { get; set; } = new Dictionary<string, int> { 
	{
		EnemyGuidDatabase.Entries["shroomer"],
		ShroomedGun.ShroomedGunID
	} };

	public static void Add()
	{
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0190: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Good Mimic", "goodmimic");
		Game.Items.Rename("outdated_gun_mods:good_mimic", "nn:good_mimic");
		((Component)val).gameObject.AddComponent<GoodMimic>();
		GunExt.SetShortDescription((PickupObject)(object)val, "All Grown Up");
		GunExt.SetLongDescription((PickupObject)(object)val, "Unlike most, this mimic thirsts for adventure rather than blood.\n\nBest to be polite though, just in case.");
		GunExt.SetupSprite(val, (tk2dSpriteCollectionData)null, "goodmimic_idle_001", 8);
		GunExt.SetAnimationFPS(val, val.shootAnimation, 10);
		PickupObject byId = PickupObjectDatabase.GetById(86);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId is Gun) ? byId : null), true, false);
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.shootStyle = (ShootStyle)0;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 1.1f;
		val.gunHandedness = (GunHandedness)0;
		val.DefaultModule.cooldownTime = 0.1f;
		val.DefaultModule.numberOfShotsInClip = 6;
		val.SetBaseMaxAmmo(300);
		((PickupObject)val).quality = (ItemQuality)(-100);
		Projectile val2 = Object.Instantiate<Projectile>(val.DefaultModule.projectiles[0]);
		((Component)val2).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val2).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val2);
		val.DefaultModule.projectiles[0] = val2;
		ProjectileData baseData = val2.baseData;
		baseData.damage *= 1f;
		ProjectileData baseData2 = val2.baseData;
		baseData2.speed *= 1f;
		ProjectileData baseData3 = val2.baseData;
		baseData3.range *= 2f;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(1f, 0.37f, 0f);
		Databases.Items.Add(val, (tk2dSpriteCollectionData)null, "ANY");
		GoodMimicID = ((PickupObject)val).PickupObjectId;
	}

	protected override void Update()
	{
		((AdvancedGunBehavior)this).Update();
		if ((Object)(object)base.gun.CurrentOwner == (Object)null)
		{
			PickupObject byId = PickupObjectDatabase.GetById(GoodMimicID);
			TransformToTargetGunSpecial((Gun)(object)((byId is Gun) ? byId : null));
		}
	}

	protected override void OnPickedUpByPlayer(PlayerController player)
	{
		player.OnAnyEnemyReceivedDamage = (Action<float, bool, HealthHaver>)Delegate.Combine(player.OnAnyEnemyReceivedDamage, new Action<float, bool, HealthHaver>(ProjectileHitEnemy));
		((AdvancedGunBehavior)this).OnPickedUpByPlayer(player);
	}

	protected override void OnPostDroppedByPlayer(PlayerController player)
	{
		player.OnAnyEnemyReceivedDamage = (Action<float, bool, HealthHaver>)Delegate.Remove(player.OnAnyEnemyReceivedDamage, new Action<float, bool, HealthHaver>(ProjectileHitEnemy));
		((AdvancedGunBehavior)this).OnPostDroppedByPlayer(player);
	}

	public void ProjectileHitEnemy(float damage, bool fatal, HealthHaver enemy)
	{
		CustomEnemyTagsSystem component = ((Component)enemy).gameObject.GetComponent<CustomEnemyTagsSystem>();
		if (((Object)(object)component != (Object)null && component.ignoreForGoodMimic) || !((Object)(object)enemy != (Object)null) || !((Object)(object)((BraveBehaviour)enemy).aiActor != (Object)null) || ((!fatal || enemy.IsBoss) && (!enemy.IsBoss || !canChangeToBossWeapon)))
		{
			return;
		}
		int num = -1;
		if ((Object)(object)((BraveBehaviour)((BraveBehaviour)enemy).aiActor).aiShooter != (Object)null && (Object)(object)((BraveBehaviour)((BraveBehaviour)enemy).aiActor).aiShooter.CurrentGun != (Object)null)
		{
			num = ((!SpecialOverrideGuns.ContainsKey(((BraveBehaviour)enemy).aiActor.EnemyGuid)) ? ((PickupObject)((BraveBehaviour)((BraveBehaviour)enemy).aiActor).aiShooter.CurrentGun).PickupObjectId : SpecialOverrideGuns[((BraveBehaviour)enemy).aiActor.EnemyGuid]);
		}
		else if (Entries.ContainsKey(((BraveBehaviour)enemy).aiActor.EnemyGuid))
		{
			num = Entries[((BraveBehaviour)enemy).aiActor.EnemyGuid];
		}
		if (num > 0)
		{
			if (enemy.IsBoss)
			{
				canChangeToBossWeapon = false;
				((MonoBehaviour)this).Invoke("ResetBossWeaponCooldown", 2.5f);
			}
			PickupObject byId = PickupObjectDatabase.GetById(num);
			TransformToTargetGunSpecial((Gun)(object)((byId is Gun) ? byId : null));
		}
	}

	private void ResetBossWeaponCooldown()
	{
		canChangeToBossWeapon = true;
	}

	public void TransformToTargetGunSpecial(Gun targetGun)
	{
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Invalid comparison between Unknown and O
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_02fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0350: Unknown result type (might be due to invalid IL or missing references)
		//IL_0355: Unknown result type (might be due to invalid IL or missing references)
		//IL_0361: Unknown result type (might be due to invalid IL or missing references)
		//IL_0366: Unknown result type (might be due to invalid IL or missing references)
		//IL_0372: Unknown result type (might be due to invalid IL or missing references)
		//IL_0377: Unknown result type (might be due to invalid IL or missing references)
		//IL_0383: Unknown result type (might be due to invalid IL or missing references)
		//IL_0388: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_03bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0331: Unknown result type (might be due to invalid IL or missing references)
		//IL_019d: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0449: Unknown result type (might be due to invalid IL or missing references)
		//IL_0465: Unknown result type (might be due to invalid IL or missing references)
		//IL_04ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_04ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_0635: Unknown result type (might be due to invalid IL or missing references)
		//IL_063a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0513: Unknown result type (might be due to invalid IL or missing references)
		//IL_052f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a00: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a05: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a38: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a3d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b65: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b6a: Unknown result type (might be due to invalid IL or missing references)
		int clipShotsRemaining = base.gun.ClipShotsRemaining;
		if ((object)(VFXPool)m_currentlyPlayingChargeVFX_info.GetValue(base.gun) != null)
		{
			((VFXPool)m_currentlyPlayingChargeVFX_info.GetValue(base.gun)).DestroyAll();
			m_currentlyPlayingChargeVFX_info.SetValue(base.gun, null);
		}
		ProjectileVolleyData volley = base.gun.Volley;
		base.gun.RawSourceVolley = targetGun.RawSourceVolley;
		base.gun.singleModule = targetGun.singleModule;
		base.gun.modifiedVolley = null;
		if (Object.op_Implicit((Object)(object)((BraveBehaviour)targetGun).sprite))
		{
			base.gun.DefaultSpriteID = ((BraveBehaviour)targetGun).sprite.spriteId;
			base.gun.GetSprite().SetSprite(((BraveBehaviour)targetGun).sprite.Collection, base.gun.DefaultSpriteID);
			if (Object.op_Implicit((Object)(object)((BraveBehaviour)this).spriteAnimator) && Object.op_Implicit((Object)(object)((BraveBehaviour)targetGun).spriteAnimator))
			{
				((BraveBehaviour)this).spriteAnimator.Library = ((BraveBehaviour)targetGun).spriteAnimator.Library;
			}
			AttachPoint[] attachPoints = base.gun.GetSprite().Collection.GetAttachPoints(base.gun.DefaultSpriteID);
			AttachPoint val = ((attachPoints == null) ? null : Array.Find(attachPoints, (AttachPoint a) => a.name == "PrimaryHand"));
			AttachPoint val2 = val;
			if (val2 != null)
			{
				m_defaultLocalPosition_info.SetValue(base.gun, -val2.position);
			}
		}
		if (targetGun.GetBaseMaxAmmo() != base.gun.GetBaseMaxAmmo() && targetGun.GetBaseMaxAmmo() > 0)
		{
			int num = ((!base.gun.InfiniteAmmo) ? base.gun.AdjustedMaxAmmo : base.gun.GetBaseMaxAmmo());
			base.gun.SetBaseMaxAmmo(targetGun.GetBaseMaxAmmo());
			if (base.gun.AdjustedMaxAmmo > 0 && num > 0 && base.gun.ammo > 0 && !base.gun.InfiniteAmmo)
			{
				base.gun.ammo = Mathf.FloorToInt((float)base.gun.ammo / (float)num * (float)base.gun.AdjustedMaxAmmo);
				base.gun.ammo = Mathf.Min(base.gun.ammo, base.gun.AdjustedMaxAmmo);
			}
			else
			{
				base.gun.ammo = Mathf.Min(base.gun.ammo, base.gun.GetBaseMaxAmmo());
			}
		}
		base.gun.gunSwitchGroup = targetGun.gunSwitchGroup;
		base.gun.isAudioLoop = targetGun.isAudioLoop;
		base.gun.gunClass = targetGun.gunClass;
		if (!string.IsNullOrEmpty(base.gun.gunSwitchGroup))
		{
			AkSoundEngine.SetSwitch("WPN_Guns", base.gun.gunSwitchGroup, ((Component)this).gameObject);
		}
		base.gun.currentGunDamageTypeModifiers = targetGun.currentGunDamageTypeModifiers;
		base.gun.carryPixelOffset = targetGun.carryPixelOffset;
		base.gun.carryPixelUpOffset = targetGun.carryPixelUpOffset;
		base.gun.carryPixelDownOffset = targetGun.carryPixelDownOffset;
		base.gun.leftFacingPixelOffset = targetGun.leftFacingPixelOffset;
		base.gun.UsesPerCharacterCarryPixelOffsets = targetGun.UsesPerCharacterCarryPixelOffsets;
		base.gun.PerCharacterPixelOffsets = targetGun.PerCharacterPixelOffsets;
		base.gun.gunPosition = targetGun.gunPosition;
		base.gun.forceFlat = targetGun.forceFlat;
		if (targetGun.GainsRateOfFireAsContinueAttack != base.gun.GainsRateOfFireAsContinueAttack)
		{
			base.gun.GainsRateOfFireAsContinueAttack = targetGun.GainsRateOfFireAsContinueAttack;
			base.gun.RateOfFireMultiplierAdditionPerSecond = targetGun.RateOfFireMultiplierAdditionPerSecond;
		}
		if (Object.op_Implicit((Object)(object)base.gun.barrelOffset) && Object.op_Implicit((Object)(object)targetGun.barrelOffset))
		{
			base.gun.barrelOffset.localPosition = targetGun.barrelOffset.localPosition;
			m_originalBarrelOffsetPosition_info.SetValue(base.gun, targetGun.barrelOffset.localPosition);
		}
		if (Object.op_Implicit((Object)(object)base.gun.muzzleOffset) && Object.op_Implicit((Object)(object)targetGun.muzzleOffset))
		{
			base.gun.muzzleOffset.localPosition = targetGun.muzzleOffset.localPosition;
			m_originalMuzzleOffsetPosition_info.SetValue(base.gun, targetGun.muzzleOffset.localPosition);
		}
		if (Object.op_Implicit((Object)(object)base.gun.chargeOffset) && Object.op_Implicit((Object)(object)targetGun.chargeOffset))
		{
			base.gun.chargeOffset.localPosition = targetGun.chargeOffset.localPosition;
			m_originalChargeOffsetPosition_info.SetValue(base.gun, targetGun.chargeOffset.localPosition);
		}
		base.gun.reloadTime = targetGun.reloadTime;
		base.gun.blankDuringReload = targetGun.blankDuringReload;
		base.gun.blankReloadRadius = targetGun.blankReloadRadius;
		base.gun.reflectDuringReload = targetGun.reflectDuringReload;
		base.gun.blankKnockbackPower = targetGun.blankKnockbackPower;
		base.gun.blankDamageToEnemies = targetGun.blankDamageToEnemies;
		base.gun.blankDamageScalingOnEmptyClip = targetGun.blankDamageScalingOnEmptyClip;
		base.gun.doesScreenShake = targetGun.doesScreenShake;
		base.gun.gunScreenShake = targetGun.gunScreenShake;
		base.gun.directionlessScreenShake = targetGun.directionlessScreenShake;
		base.gun.AppliesHoming = targetGun.AppliesHoming;
		base.gun.AppliedHomingAngularVelocity = targetGun.AppliedHomingAngularVelocity;
		base.gun.AppliedHomingDetectRadius = targetGun.AppliedHomingDetectRadius;
		base.gun.GoopReloadsFree = targetGun.GoopReloadsFree;
		base.gun.gunHandedness = targetGun.gunHandedness;
		m_cachedGunHandedness_info.SetValue(base.gun, null);
		base.gun.shootAnimation = targetGun.shootAnimation;
		base.gun.usesContinuousFireAnimation = targetGun.usesContinuousFireAnimation;
		base.gun.reloadAnimation = targetGun.reloadAnimation;
		base.gun.emptyReloadAnimation = targetGun.emptyReloadAnimation;
		base.gun.idleAnimation = targetGun.idleAnimation;
		base.gun.chargeAnimation = targetGun.chargeAnimation;
		base.gun.dischargeAnimation = targetGun.dischargeAnimation;
		base.gun.emptyAnimation = targetGun.emptyAnimation;
		base.gun.introAnimation = targetGun.introAnimation;
		base.gun.finalShootAnimation = targetGun.finalShootAnimation;
		base.gun.enemyPreFireAnimation = targetGun.enemyPreFireAnimation;
		base.gun.dodgeAnimation = targetGun.dodgeAnimation;
		base.gun.muzzleFlashEffects = targetGun.muzzleFlashEffects;
		base.gun.usesContinuousMuzzleFlash = targetGun.usesContinuousMuzzleFlash;
		base.gun.finalMuzzleFlashEffects = targetGun.finalMuzzleFlashEffects;
		base.gun.reloadEffects = targetGun.reloadEffects;
		base.gun.emptyReloadEffects = targetGun.emptyReloadEffects;
		base.gun.activeReloadSuccessEffects = targetGun.activeReloadSuccessEffects;
		base.gun.activeReloadFailedEffects = targetGun.activeReloadFailedEffects;
		base.gun.shellCasing = targetGun.shellCasing;
		base.gun.shellsToLaunchOnFire = targetGun.shellsToLaunchOnFire;
		base.gun.shellCasingOnFireFrameDelay = targetGun.shellCasingOnFireFrameDelay;
		base.gun.shellsToLaunchOnReload = targetGun.shellsToLaunchOnReload;
		base.gun.reloadShellLaunchFrame = targetGun.reloadShellLaunchFrame;
		base.gun.clipObject = targetGun.clipObject;
		base.gun.clipsToLaunchOnReload = targetGun.clipsToLaunchOnReload;
		base.gun.reloadClipLaunchFrame = targetGun.reloadClipLaunchFrame;
		base.gun.IsTrickGun = targetGun.IsTrickGun;
		base.gun.TrickGunAlternatesHandedness = targetGun.TrickGunAlternatesHandedness;
		base.gun.alternateVolley = targetGun.alternateVolley;
		base.gun.alternateShootAnimation = targetGun.alternateShootAnimation;
		base.gun.alternateReloadAnimation = targetGun.alternateReloadAnimation;
		base.gun.alternateIdleAnimation = targetGun.alternateIdleAnimation;
		base.gun.alternateSwitchGroup = targetGun.alternateSwitchGroup;
		base.gun.rampBullets = targetGun.rampBullets;
		base.gun.rampStartHeight = targetGun.rampStartHeight;
		base.gun.rampTime = targetGun.rampTime;
		base.gun.usesDirectionalAnimator = targetGun.usesDirectionalAnimator;
		base.gun.usesDirectionalIdleAnimations = targetGun.usesDirectionalIdleAnimations;
		Component[] components = ((Component)targetGun).GetComponents<Component>();
		Component[] components2 = ((Component)this).GetComponents<Component>();
		Component[] array = components;
		foreach (Component val3 in array)
		{
			if ((Object)(object)((Component)base.gun).GetComponent(((object)val3).GetType()) == (Object)null)
			{
				Component val4 = ((Component)base.gun).gameObject.AddComponent(((object)val3).GetType());
				GunTools.SetFields(val4, val3, true, true);
			}
		}
		Component[] array2 = components2;
		foreach (Component val5 in array2)
		{
			if ((Object)(object)val5 != (Object)(object)this && (Object)(object)((Component)targetGun).GetComponent(((object)val5).GetType()) == (Object)null)
			{
				Object.Destroy((Object)(object)val5);
			}
		}
		if (Object.op_Implicit((Object)(object)((BraveBehaviour)this).aiAnimator))
		{
			Object.Destroy((Object)(object)((BraveBehaviour)this).aiAnimator);
			((BraveBehaviour)this).aiAnimator = null;
		}
		if (Object.op_Implicit((Object)(object)((BraveBehaviour)targetGun).aiAnimator))
		{
			AIAnimator val6 = ((Component)this).gameObject.AddComponent<AIAnimator>();
			AIAnimator aiAnimator = ((BraveBehaviour)targetGun).aiAnimator;
			val6.facingType = aiAnimator.facingType;
			val6.DirectionParent = aiAnimator.DirectionParent;
			val6.faceSouthWhenStopped = aiAnimator.faceSouthWhenStopped;
			val6.faceTargetWhenStopped = aiAnimator.faceTargetWhenStopped;
			val6.directionalType = aiAnimator.directionalType;
			val6.RotationQuantizeTo = aiAnimator.RotationQuantizeTo;
			val6.RotationOffset = aiAnimator.RotationOffset;
			val6.ForceKillVfxOnPreDeath = aiAnimator.ForceKillVfxOnPreDeath;
			val6.SuppressAnimatorFallback = aiAnimator.SuppressAnimatorFallback;
			val6.IsBodySprite = aiAnimator.IsBodySprite;
			val6.IdleAnimation = aiAnimator.IdleAnimation;
			val6.MoveAnimation = aiAnimator.MoveAnimation;
			val6.FlightAnimation = aiAnimator.FlightAnimation;
			val6.HitAnimation = aiAnimator.HitAnimation;
			val6.OtherAnimations = aiAnimator.OtherAnimations;
			val6.OtherVFX = aiAnimator.OtherVFX;
			val6.OtherScreenShake = aiAnimator.OtherScreenShake;
			val6.IdleFidgetAnimations = aiAnimator.IdleFidgetAnimations;
			((BraveBehaviour)this).aiAnimator = val6;
		}
		MultiTemporaryOrbitalSynergyProcessor component = ((Component)targetGun).GetComponent<MultiTemporaryOrbitalSynergyProcessor>();
		MultiTemporaryOrbitalSynergyProcessor component2 = ((Component)this).GetComponent<MultiTemporaryOrbitalSynergyProcessor>();
		if (!Object.op_Implicit((Object)(object)component) && Object.op_Implicit((Object)(object)component2))
		{
			Object.Destroy((Object)(object)component2);
		}
		else if (Object.op_Implicit((Object)(object)component) && !Object.op_Implicit((Object)(object)component2))
		{
			MultiTemporaryOrbitalSynergyProcessor val7 = ((Component)this).gameObject.AddComponent<MultiTemporaryOrbitalSynergyProcessor>();
			val7.RequiredSynergy = component.RequiredSynergy;
			val7.OrbitalPrefab = component.OrbitalPrefab;
		}
		if ((Object)(object)base.gun.RawSourceVolley != (Object)null)
		{
			for (int k = 0; k < base.gun.RawSourceVolley.projectiles.Count; k++)
			{
				base.gun.RawSourceVolley.projectiles[k].ResetRuntimeData();
			}
		}
		else
		{
			base.gun.singleModule.ResetRuntimeData();
		}
		if ((Object)(object)volley != (Object)null)
		{
			base.gun.RawSourceVolley = DuctTapeItem.TransferDuctTapeModules(volley, base.gun.RawSourceVolley, base.gun);
		}
		if (base.gun.CurrentOwner is PlayerController)
		{
			GameActor currentOwner = base.gun.CurrentOwner;
			PlayerController val8 = (PlayerController)(object)((currentOwner is PlayerController) ? currentOwner : null);
			if ((Object)(object)val8.stats != (Object)null)
			{
				val8.stats.RecalculateStats(val8, false, false);
			}
		}
		if (((Component)this).gameObject.activeSelf)
		{
			((MonoBehaviour)this).StartCoroutine((IEnumerator)HandleFrameDelayedTransformation_info.Invoke(base.gun, new object[0]));
		}
		base.gun.DidTransformGunThisFrame = true;
	}
}
