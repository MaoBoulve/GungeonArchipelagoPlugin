using System.Collections.Generic;
using System.Reflection;
using Alexandria.ItemAPI;
using UnityEngine;

namespace NevernamedsItems;

internal class InfantryGrenade : SpawnObjectPlayerItem
{
	public static int InfantryGrenadeID;

	public static void Init()
	{
		//IL_0082: Unknown result type (might be due to invalid IL or missing references)
		PickupObject obj = ItemSetup.NewItem<InfantryGrenade>("Infantry Grenade", "Cheap, but Efficient", "A paltry explosive device carried by infantry soldiers from a far off land.\n\nHas a weak blast, but can be slung multiple times in quick succession.", "infantrygrenade_icon", assetbundle: true);
		SpawnObjectPlayerItem val = (SpawnObjectPlayerItem)(object)((obj is SpawnObjectPlayerItem) ? obj : null);
		ItemBuilder.SetCooldownType((PlayerItem)(object)val, (CooldownType)1, 50f);
		((PlayerItem)val).consumable = false;
		val.objectToSpawn = BuildPrefab();
		val.tossForce = 7f;
		val.canBounce = true;
		val.IsCigarettes = false;
		val.RequireEnemiesInRoom = false;
		val.SpawnRadialCopies = false;
		val.RadialCopiesToSpawn = 0;
		val.AudioEvent = "Play_OBJ_bomb_fuse_01";
		val.IsKageBunshinItem = false;
		((PickupObject)val).quality = (ItemQuality)1;
		InfantryGrenadeID = ((PickupObject)val).PickupObjectId;
	}

	public static GameObject BuildPrefab()
	{
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Expected O, but got Unknown
		//IL_01fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0200: Unknown result type (might be due to invalid IL or missing references)
		//IL_020b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0217: Expected O, but got Unknown
		//IL_021c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0221: Unknown result type (might be due to invalid IL or missing references)
		//IL_0222: Unknown result type (might be due to invalid IL or missing references)
		//IL_0227: Unknown result type (might be due to invalid IL or missing references)
		//IL_022e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0235: Unknown result type (might be due to invalid IL or missing references)
		//IL_023c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0247: Unknown result type (might be due to invalid IL or missing references)
		//IL_0252: Unknown result type (might be due to invalid IL or missing references)
		//IL_025d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0264: Unknown result type (might be due to invalid IL or missing references)
		//IL_026f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0276: Unknown result type (might be due to invalid IL or missing references)
		//IL_027d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0284: Unknown result type (might be due to invalid IL or missing references)
		//IL_028f: Unknown result type (might be due to invalid IL or missing references)
		//IL_029a: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_02be: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_02dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_02fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0309: Unknown result type (might be due to invalid IL or missing references)
		//IL_0314: Unknown result type (might be due to invalid IL or missing references)
		//IL_0319: Unknown result type (might be due to invalid IL or missing references)
		//IL_031e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0321: Unknown result type (might be due to invalid IL or missing references)
		//IL_0326: Unknown result type (might be due to invalid IL or missing references)
		//IL_0329: Unknown result type (might be due to invalid IL or missing references)
		//IL_032e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0331: Unknown result type (might be due to invalid IL or missing references)
		//IL_033b: Expected O, but got Unknown
		//IL_033b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0342: Unknown result type (might be due to invalid IL or missing references)
		//IL_0349: Unknown result type (might be due to invalid IL or missing references)
		//IL_0350: Unknown result type (might be due to invalid IL or missing references)
		//IL_035b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0362: Unknown result type (might be due to invalid IL or missing references)
		//IL_0369: Unknown result type (might be due to invalid IL or missing references)
		//IL_0374: Unknown result type (might be due to invalid IL or missing references)
		//IL_037b: Unknown result type (might be due to invalid IL or missing references)
		//IL_038b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0397: Expected O, but got Unknown
		//IL_0397: Unknown result type (might be due to invalid IL or missing references)
		//IL_0399: Unknown result type (might be due to invalid IL or missing references)
		//IL_039e: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_03bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_03dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0400: Unknown result type (might be due to invalid IL or missing references)
		//IL_040b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0418: Expected O, but got Unknown
		GameObject val = SpriteBuilder.SpriteFromResource("NevernamedsItems/Resources/ThrowableActives/infantrygrenade_throw_001.png", new GameObject("InfantryGrenade"), (Assembly)null);
		val.SetActive(false);
		FakePrefab.MarkAsFakePrefab(val);
		tk2dSpriteAnimator val2 = val.AddComponent<tk2dSpriteAnimator>();
		PickupObject byId = PickupObjectDatabase.GetById(108);
		tk2dSpriteCollectionData spriteCollection = ((SpawnObjectPlayerItem)((byId is SpawnObjectPlayerItem) ? byId : null)).objectToSpawn.GetComponent<tk2dSpriteAnimator>().Library.clips[0].frames[0].spriteCollection;
		tk2dSpriteAnimationClip val3 = SpriteBuilder.AddAnimation(val2, spriteCollection, new List<int>
		{
			SpriteBuilder.AddSpriteToCollection("NevernamedsItems/Resources/ThrowableActives/infantrygrenade_throw_001.png", spriteCollection, (Assembly)null),
			SpriteBuilder.AddSpriteToCollection("NevernamedsItems/Resources/ThrowableActives/infantrygrenade_throw_002.png", spriteCollection, (Assembly)null)
		}, "infantrygrenade_throw", (WrapMode)2, 15f);
		val3.fps = 12f;
		tk2dSpriteAnimationFrame[] frames = val3.frames;
		foreach (tk2dSpriteAnimationFrame val4 in frames)
		{
			val4.eventLerpEmissiveTime = 0.5f;
			val4.eventLerpEmissivePower = 30f;
		}
		tk2dSpriteAnimationClip val5 = SpriteBuilder.AddAnimation(val2, spriteCollection, new List<int> { SpriteBuilder.AddSpriteToCollection("NevernamedsItems/Resources/ThrowableActives/infantrygrenade_explode_001.png", spriteCollection, (Assembly)null) }, "infantrygrenade_explode", (WrapMode)2, 15f);
		val5.fps = 30f;
		tk2dSpriteAnimationFrame[] frames2 = val5.frames;
		foreach (tk2dSpriteAnimationFrame val6 in frames2)
		{
			val6.eventLerpEmissiveTime = 0.5f;
			val6.eventLerpEmissivePower = 30f;
		}
		tk2dSpriteAnimationClip val7 = SpriteBuilder.AddAnimation(val2, spriteCollection, new List<int>
		{
			SpriteBuilder.AddSpriteToCollection("NevernamedsItems/Resources/ThrowableActives/infantrygrenade_throw_001.png", spriteCollection, (Assembly)null),
			SpriteBuilder.AddSpriteToCollection("NevernamedsItems/Resources/ThrowableActives/infantrygrenade_throw_002.png", spriteCollection, (Assembly)null)
		}, "infantrygrenade_primed", (WrapMode)1, 15f);
		val7.fps = 10f;
		val7.loopStart = 0;
		tk2dSpriteAnimationFrame[] frames3 = val7.frames;
		foreach (tk2dSpriteAnimationFrame val8 in frames3)
		{
			val8.eventLerpEmissiveTime = 0.5f;
			val8.eventLerpEmissivePower = 30f;
		}
		AudioAnimatorListener val9 = val.AddComponent<AudioAnimatorListener>();
		val9.animationAudioEvents = (ActorAudioEvent[])(object)new ActorAudioEvent[1]
		{
			new ActorAudioEvent
			{
				eventName = "Play_OBJ_mine_beep_01",
				eventTag = "beep"
			}
		};
		ProximityMine val10 = new ProximityMine
		{
			explosionData = new ExplosionData
			{
				useDefaultExplosion = false,
				doDamage = true,
				forceUseThisRadius = false,
				damageRadius = 3f,
				damageToPlayer = 0f,
				damage = 30f,
				breakSecretWalls = false,
				secretWallsRadius = 3.5f,
				forcePreventSecretWallDamage = false,
				doDestroyProjectiles = true,
				doForce = true,
				pushRadius = 3f,
				force = 25f,
				debrisForce = 12.5f,
				preventPlayerForce = false,
				explosionDelay = 0.1f,
				usesComprehensiveDelay = false,
				comprehensiveDelay = 0f,
				playDefaultSFX = false,
				doScreenShake = true,
				ss = new ScreenShakeSettings
				{
					magnitude = 1f,
					speed = 6.5f,
					time = 0.22f,
					falloff = 0f,
					direction = new Vector2(0f, 0f),
					vibrationType = (VibrationType)10,
					simpleVibrationStrength = (Strength)20,
					simpleVibrationTime = (Time)20
				},
				doStickyFriction = true,
				doExplosionRing = true,
				isFreezeExplosion = false,
				freezeRadius = 5f,
				IsChandelierExplosion = false,
				rotateEffectToNormal = false,
				ignoreList = new List<SpeculativeRigidbody>(),
				overrideRangeIndicatorEffect = null,
				effect = StaticExplosionDatas.explosiveRoundsExplosion.effect,
				freezeEffect = null
			},
			explosionStyle = (ExplosiveStyle)1,
			detectRadius = 3.5f,
			explosionDelay = 1f,
			usesCustomExplosionDelay = false,
			customExplosionDelay = 0.1f,
			deployAnimName = "infantrygrenade_throw",
			explodeAnimName = "infantrygrenade_explode",
			idleAnimName = "infantrygrenade_primed",
			MovesTowardEnemies = false,
			HomingTriggeredOnSynergy = false,
			HomingDelay = 3.25f,
			HomingRadius = 10f,
			HomingSpeed = 4f
		};
		ProximityMine val11 = SpriteBuilder.AddComponent<ProximityMine>(val, val10);
		return val;
	}
}
