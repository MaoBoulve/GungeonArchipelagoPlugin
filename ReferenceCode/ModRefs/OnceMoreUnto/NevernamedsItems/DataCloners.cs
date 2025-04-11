using UnityEngine;

namespace NevernamedsItems;

internal static class DataCloners
{
	public static ExplosionData CopyExplosionData(this ExplosionData other)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0096: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00de: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_010d: Unknown result type (might be due to invalid IL or missing references)
		//IL_011e: Unknown result type (might be due to invalid IL or missing references)
		//IL_012f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0140: Unknown result type (might be due to invalid IL or missing references)
		//IL_0143: Unknown result type (might be due to invalid IL or missing references)
		//IL_0177: Unknown result type (might be due to invalid IL or missing references)
		//IL_0178: Unknown result type (might be due to invalid IL or missing references)
		//IL_017d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0184: Unknown result type (might be due to invalid IL or missing references)
		//IL_0189: Unknown result type (might be due to invalid IL or missing references)
		//IL_018e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0195: Unknown result type (might be due to invalid IL or missing references)
		//IL_019a: Unknown result type (might be due to invalid IL or missing references)
		//IL_019f: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b5: Expected O, but got Unknown
		//IL_01b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0209: Unknown result type (might be due to invalid IL or missing references)
		//IL_0215: Unknown result type (might be due to invalid IL or missing references)
		//IL_0221: Unknown result type (might be due to invalid IL or missing references)
		//IL_022e: Expected O, but got Unknown
		return new ExplosionData
		{
			useDefaultExplosion = other.useDefaultExplosion,
			doDamage = other.doDamage,
			forceUseThisRadius = other.forceUseThisRadius,
			damageRadius = other.damageRadius,
			damageToPlayer = other.damageToPlayer,
			damage = other.damage,
			breakSecretWalls = other.breakSecretWalls,
			secretWallsRadius = other.secretWallsRadius,
			forcePreventSecretWallDamage = other.forcePreventSecretWallDamage,
			doDestroyProjectiles = other.doDestroyProjectiles,
			doForce = other.doForce,
			pushRadius = other.pushRadius,
			force = other.force,
			debrisForce = other.debrisForce,
			preventPlayerForce = other.preventPlayerForce,
			explosionDelay = other.explosionDelay,
			usesComprehensiveDelay = other.usesComprehensiveDelay,
			comprehensiveDelay = other.comprehensiveDelay,
			effect = other.effect,
			doScreenShake = other.doScreenShake,
			ss = new ScreenShakeSettings
			{
				magnitude = other.ss.magnitude,
				speed = other.ss.speed,
				time = other.ss.time,
				falloff = other.ss.falloff,
				direction = new Vector2
				{
					x = other.ss.direction.x,
					y = other.ss.direction.y
				},
				vibrationType = other.ss.vibrationType,
				simpleVibrationTime = other.ss.simpleVibrationTime,
				simpleVibrationStrength = other.ss.simpleVibrationStrength
			},
			doStickyFriction = other.doStickyFriction,
			doExplosionRing = other.doExplosionRing,
			isFreezeExplosion = other.isFreezeExplosion,
			freezeRadius = other.freezeRadius,
			freezeEffect = other.freezeEffect,
			playDefaultSFX = other.playDefaultSFX,
			IsChandelierExplosion = other.IsChandelierExplosion,
			rotateEffectToNormal = other.rotateEffectToNormal,
			ignoreList = other.ignoreList,
			overrideRangeIndicatorEffect = other.overrideRangeIndicatorEffect
		};
	}

	public static AIBulletBank CopyAIBulletBank(AIBulletBank bank)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Expected O, but got Unknown
		//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
		GameObject val = new GameObject();
		AIBulletBank orAddComponent = GameObjectExtensions.GetOrAddComponent<AIBulletBank>(val);
		orAddComponent.Bullets = bank.Bullets;
		orAddComponent.FixedPlayerPosition = bank.FixedPlayerPosition;
		orAddComponent.OnProjectileCreated = bank.OnProjectileCreated;
		orAddComponent.OverrideGun = bank.OverrideGun;
		orAddComponent.rampTime = bank.rampTime;
		orAddComponent.OnProjectileCreatedWithSource = bank.OnProjectileCreatedWithSource;
		orAddComponent.rampBullets = bank.rampBullets;
		orAddComponent.transforms = bank.transforms;
		orAddComponent.useDefaultBulletIfMissing = bank.useDefaultBulletIfMissing;
		orAddComponent.rampStartHeight = bank.rampStartHeight;
		orAddComponent.SpecificRigidbodyException = bank.SpecificRigidbodyException;
		orAddComponent.PlayShells = bank.PlayShells;
		orAddComponent.PlayAudio = bank.PlayAudio;
		orAddComponent.PlayVfx = bank.PlayVfx;
		orAddComponent.CollidesWithEnemies = bank.CollidesWithEnemies;
		orAddComponent.FixedPlayerRigidbodyLastPosition = bank.FixedPlayerRigidbodyLastPosition;
		orAddComponent.ActorName = bank.ActorName;
		orAddComponent.TimeScale = bank.TimeScale;
		orAddComponent.SuppressPlayerVelocityAveraging = bank.SuppressPlayerVelocityAveraging;
		orAddComponent.FixedPlayerRigidbody = bank.FixedPlayerRigidbody;
		return orAddComponent;
	}

	public static T CopyFields<T>(Projectile sample2) where T : Projectile
	{
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0476: Unknown result type (might be due to invalid IL or missing references)
		//IL_047b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0611: Unknown result type (might be due to invalid IL or missing references)
		//IL_0623: Unknown result type (might be due to invalid IL or missing references)
		//IL_0647: Unknown result type (might be due to invalid IL or missing references)
		T val = ((Component)sample2).gameObject.AddComponent<T>();
		((Projectile)val).PossibleSourceGun = sample2.PossibleSourceGun;
		((Projectile)val).SpawnedFromOtherPlayerProjectile = sample2.SpawnedFromOtherPlayerProjectile;
		((Projectile)val).PlayerProjectileSourceGameTimeslice = sample2.PlayerProjectileSourceGameTimeslice;
		((Projectile)val).BulletScriptSettings = sample2.BulletScriptSettings;
		((Projectile)val).damageTypes = sample2.damageTypes;
		((Projectile)val).allowSelfShooting = sample2.allowSelfShooting;
		((Projectile)val).collidesWithPlayer = sample2.collidesWithPlayer;
		((Projectile)val).collidesWithProjectiles = sample2.collidesWithProjectiles;
		((Projectile)val).collidesOnlyWithPlayerProjectiles = sample2.collidesOnlyWithPlayerProjectiles;
		((Projectile)val).projectileHitHealth = sample2.projectileHitHealth;
		((Projectile)val).collidesWithEnemies = sample2.collidesWithEnemies;
		((Projectile)val).shouldRotate = sample2.shouldRotate;
		((Projectile)val).shouldFlipVertically = sample2.shouldFlipVertically;
		((Projectile)val).shouldFlipHorizontally = sample2.shouldFlipHorizontally;
		((Projectile)val).ignoreDamageCaps = sample2.ignoreDamageCaps;
		((Projectile)val).baseData = sample2.baseData;
		((Projectile)val).AppliesPoison = sample2.AppliesPoison;
		((Projectile)val).PoisonApplyChance = sample2.PoisonApplyChance;
		((Projectile)val).healthEffect = sample2.healthEffect;
		((Projectile)val).AppliesSpeedModifier = sample2.AppliesSpeedModifier;
		((Projectile)val).SpeedApplyChance = sample2.SpeedApplyChance;
		((Projectile)val).speedEffect = sample2.speedEffect;
		((Projectile)val).AppliesCharm = sample2.AppliesCharm;
		((Projectile)val).CharmApplyChance = sample2.CharmApplyChance;
		((Projectile)val).charmEffect = sample2.charmEffect;
		((Projectile)val).AppliesFreeze = sample2.AppliesFreeze;
		((Projectile)val).FreezeApplyChance = sample2.FreezeApplyChance;
		((Projectile)val).freezeEffect = sample2.freezeEffect;
		((Projectile)val).AppliesFire = sample2.AppliesFire;
		((Projectile)val).FireApplyChance = sample2.FireApplyChance;
		((Projectile)val).fireEffect = sample2.fireEffect;
		((Projectile)val).AppliesStun = sample2.AppliesStun;
		((Projectile)val).StunApplyChance = sample2.StunApplyChance;
		((Projectile)val).AppliedStunDuration = sample2.AppliedStunDuration;
		((Projectile)val).AppliesBleed = sample2.AppliesBleed;
		((Projectile)val).bleedEffect = sample2.bleedEffect;
		((Projectile)val).AppliesCheese = sample2.AppliesCheese;
		((Projectile)val).CheeseApplyChance = sample2.CheeseApplyChance;
		((Projectile)val).cheeseEffect = sample2.cheeseEffect;
		((Projectile)val).BleedApplyChance = sample2.BleedApplyChance;
		((Projectile)val).CanTransmogrify = sample2.CanTransmogrify;
		((Projectile)val).ChanceToTransmogrify = sample2.ChanceToTransmogrify;
		((Projectile)val).TransmogrifyTargetGuids = sample2.TransmogrifyTargetGuids;
		((Projectile)val).BossDamageMultiplier = sample2.BossDamageMultiplier;
		((Projectile)val).SpawnedFromNonChallengeItem = sample2.SpawnedFromNonChallengeItem;
		((Projectile)val).TreatedAsNonProjectileForChallenge = sample2.TreatedAsNonProjectileForChallenge;
		((Projectile)val).hitEffects = sample2.hitEffects;
		((Projectile)val).CenterTilemapHitEffectsByProjectileVelocity = sample2.CenterTilemapHitEffectsByProjectileVelocity;
		((Projectile)val).wallDecals = sample2.wallDecals;
		((Projectile)val).persistTime = sample2.persistTime;
		((Projectile)val).angularVelocity = sample2.angularVelocity;
		((Projectile)val).angularVelocityVariance = sample2.angularVelocityVariance;
		((Projectile)val).spawnEnemyGuidOnDeath = sample2.spawnEnemyGuidOnDeath;
		((Projectile)val).HasFixedKnockbackDirection = sample2.HasFixedKnockbackDirection;
		((Projectile)val).FixedKnockbackDirection = sample2.FixedKnockbackDirection;
		((Projectile)val).pierceMinorBreakables = sample2.pierceMinorBreakables;
		((Projectile)val).objectImpactEventName = sample2.objectImpactEventName;
		((Projectile)val).enemyImpactEventName = sample2.enemyImpactEventName;
		((Projectile)val).onDestroyEventName = sample2.onDestroyEventName;
		((Projectile)val).additionalStartEventName = sample2.additionalStartEventName;
		((Projectile)val).IsRadialBurstLimited = sample2.IsRadialBurstLimited;
		((Projectile)val).MaxRadialBurstLimit = sample2.MaxRadialBurstLimit;
		((Projectile)val).AdditionalBurstLimits = sample2.AdditionalBurstLimits;
		((Projectile)val).AppliesKnockbackToPlayer = sample2.AppliesKnockbackToPlayer;
		((Projectile)val).PlayerKnockbackForce = sample2.PlayerKnockbackForce;
		((Projectile)val).HasDefaultTint = sample2.HasDefaultTint;
		((Projectile)val).DefaultTintColor = sample2.DefaultTintColor;
		((Projectile)val).IsCritical = sample2.IsCritical;
		((Projectile)val).BlackPhantomDamageMultiplier = sample2.BlackPhantomDamageMultiplier;
		((Projectile)val).PenetratesInternalWalls = sample2.PenetratesInternalWalls;
		((Projectile)val).neverMaskThis = sample2.neverMaskThis;
		((Projectile)val).isFakeBullet = sample2.isFakeBullet;
		((Projectile)val).CanBecomeBlackBullet = sample2.CanBecomeBlackBullet;
		((Projectile)val).TrailRenderer = sample2.TrailRenderer;
		((Projectile)val).CustomTrailRenderer = sample2.CustomTrailRenderer;
		((Projectile)val).DelayedDamageToExploders = sample2.DelayedDamageToExploders;
		((Projectile)val).OnHitEnemy = sample2.OnHitEnemy;
		((Projectile)val).OnWillKillEnemy = sample2.OnWillKillEnemy;
		((Projectile)val).OnBecameDebris = sample2.OnBecameDebris;
		((Projectile)val).OnBecameDebrisGrounded = sample2.OnBecameDebrisGrounded;
		((Projectile)val).IsBlackBullet = sample2.IsBlackBullet;
		((Projectile)val).statusEffectsToApply = sample2.statusEffectsToApply;
		((Projectile)val).AdditionalScaleMultiplier = sample2.AdditionalScaleMultiplier;
		((Projectile)val).ModifyVelocity = sample2.ModifyVelocity;
		((Projectile)val).CurseSparks = sample2.CurseSparks;
		((Projectile)val).PreMoveModifiers = sample2.PreMoveModifiers;
		((Projectile)val).OverrideMotionModule = sample2.OverrideMotionModule;
		((Projectile)val).Shooter = sample2.Shooter;
		((Projectile)val).Owner = sample2.Owner;
		((Projectile)val).Speed = sample2.Speed;
		((Projectile)val).Direction = sample2.Direction;
		((Projectile)val).DestroyMode = sample2.DestroyMode;
		((Projectile)val).Inverted = sample2.Inverted;
		((Projectile)val).LastVelocity = sample2.LastVelocity;
		((Projectile)val).ManualControl = sample2.ManualControl;
		((Projectile)val).ForceBlackBullet = sample2.ForceBlackBullet;
		((Projectile)val).IsBulletScript = sample2.IsBulletScript;
		((Projectile)val).OverrideTrailPoint = sample2.OverrideTrailPoint;
		((Projectile)val).SkipDistanceElapsedCheck = sample2.SkipDistanceElapsedCheck;
		((Projectile)val).ImmuneToBlanks = sample2.ImmuneToBlanks;
		((Projectile)val).ImmuneToSustainedBlanks = sample2.ImmuneToSustainedBlanks;
		((Projectile)val).ForcePlayerBlankable = sample2.ForcePlayerBlankable;
		((Projectile)val).IsReflectedBySword = sample2.IsReflectedBySword;
		((Projectile)val).LastReflectedSlashId = sample2.LastReflectedSlashId;
		((Projectile)val).TrailRendererController = sample2.TrailRendererController;
		((Projectile)val).braveBulletScript = sample2.braveBulletScript;
		((Projectile)val).TrapOwner = sample2.TrapOwner;
		((Projectile)val).SuppressHitEffects = sample2.SuppressHitEffects;
		Object.Destroy((Object)(object)sample2);
		return val;
	}
}
