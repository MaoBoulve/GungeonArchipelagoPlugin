using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using Alexandria.ItemAPI;
using UnityEngine;

namespace NevernamedsItems;

internal class DiceGrenade : SpawnObjectPlayerItem
{
	public class DiceGrenadeEffect : CustomThrowableEffectDoer
	{
		[CompilerGenerated]
		private sealed class _003CKill_003Ed__1 : IEnumerator<object>, IDisposable, IEnumerator
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public GameObject obj;

			public DiceGrenadeEffect _003C_003E4__this;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return _003C_003E2__current;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return _003C_003E2__current;
				}
			}

			[DebuggerHidden]
			public _003CKill_003Ed__1(int _003C_003E1__state)
			{
				this._003C_003E1__state = _003C_003E1__state;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				_003C_003E1__state = -2;
			}

			private bool MoveNext()
			{
				//IL_0026: Unknown result type (might be due to invalid IL or missing references)
				//IL_0030: Expected O, but got Unknown
				switch (_003C_003E1__state)
				{
				default:
					return false;
				case 0:
					_003C_003E1__state = -1;
					_003C_003E2__current = (object)new WaitForSeconds(0.1f);
					_003C_003E1__state = 1;
					return true;
				case 1:
					_003C_003E1__state = -1;
					Object.Destroy((Object)(object)obj);
					return false;
				}
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
				throw new NotSupportedException();
			}
		}

		public override void OnEffect(GameObject obj)
		{
			//IL_0021: Unknown result type (might be due to invalid IL or missing references)
			//IL_0026: Unknown result type (might be due to invalid IL or missing references)
			//IL_002d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0034: Unknown result type (might be due to invalid IL or missing references)
			//IL_003b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0042: Unknown result type (might be due to invalid IL or missing references)
			//IL_004d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0062: Unknown result type (might be due to invalid IL or missing references)
			//IL_0077: Unknown result type (might be due to invalid IL or missing references)
			//IL_007e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0085: Unknown result type (might be due to invalid IL or missing references)
			//IL_008c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0093: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00af: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cf: Unknown result type (might be due to invalid IL or missing references)
			//IL_00da: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e9: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ee: Unknown result type (might be due to invalid IL or missing references)
			//IL_0103: Unknown result type (might be due to invalid IL or missing references)
			//IL_010e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0119: Unknown result type (might be due to invalid IL or missing references)
			//IL_0124: Unknown result type (might be due to invalid IL or missing references)
			//IL_012f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0134: Unknown result type (might be due to invalid IL or missing references)
			//IL_0139: Unknown result type (might be due to invalid IL or missing references)
			//IL_013c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0141: Unknown result type (might be due to invalid IL or missing references)
			//IL_0144: Unknown result type (might be due to invalid IL or missing references)
			//IL_0149: Unknown result type (might be due to invalid IL or missing references)
			//IL_014c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0156: Expected O, but got Unknown
			//IL_0156: Unknown result type (might be due to invalid IL or missing references)
			//IL_015d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0164: Unknown result type (might be due to invalid IL or missing references)
			//IL_016b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0176: Unknown result type (might be due to invalid IL or missing references)
			//IL_017d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0184: Unknown result type (might be due to invalid IL or missing references)
			//IL_018f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0196: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ba: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c2: Expected O, but got Unknown
			//IL_029e: Unknown result type (might be due to invalid IL or missing references)
			//IL_02a3: Unknown result type (might be due to invalid IL or missing references)
			//IL_02a9: Unknown result type (might be due to invalid IL or missing references)
			//IL_027c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0281: Unknown result type (might be due to invalid IL or missing references)
			float num = Random.Range(2f, 5f);
			float num2 = Random.Range(25f, 50f);
			ExplosionData val = new ExplosionData
			{
				useDefaultExplosion = false,
				doDamage = true,
				forceUseThisRadius = false,
				damageRadius = num,
				damageToPlayer = 0f,
				damage = Random.Range(10f, 50f),
				breakSecretWalls = (Random.value <= 0.5f),
				secretWallsRadius = num,
				forcePreventSecretWallDamage = false,
				doDestroyProjectiles = true,
				doForce = true,
				pushRadius = Random.Range(3f, 10f),
				force = num2,
				debrisForce = num2,
				preventPlayerForce = false,
				explosionDelay = 0f,
				usesComprehensiveDelay = false,
				comprehensiveDelay = 0f,
				playDefaultSFX = false,
				doScreenShake = true,
				ss = new ScreenShakeSettings
				{
					magnitude = Random.Range(1f, 3f),
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
				effect = ((num > 3.5f) ? StaticExplosionDatas.genericLargeExplosion.effect : StaticExplosionDatas.explosiveRoundsExplosion.effect),
				freezeEffect = null
			};
			if (CustomSynergies.PlayerHasActiveSynergy(((SpawnObjectItem)obj.GetComponent<CustomThrowableObject>()).SpawningPlayer, "Roll With Advantage"))
			{
				DeadlyDeadlyGoopManager goopManagerForGoopType = DeadlyDeadlyGoopManager.GetGoopManagerForGoopType(BraveUtility.RandomElement<GoopDefinition>(new List<GoopDefinition>
				{
					EasyGoopDefinitions.BlobulonGoopDef,
					EasyGoopDefinitions.CharmGoopDef,
					EasyGoopDefinitions.CheeseDef,
					EasyGoopDefinitions.FireDef,
					EasyGoopDefinitions.GreenFireDef,
					EasyGoopDefinitions.HoneyGoop,
					EasyGoopDefinitions.OilDef,
					EasyGoopDefinitions.PitGoop,
					EasyGoopDefinitions.PlagueGoop,
					EasyGoopDefinitions.PlayerFriendlyWebGoop,
					EasyGoopDefinitions.WaterGoop
				}));
				goopManagerForGoopType.TimedAddGoopCircle(Vector2.op_Implicit(obj.transform.position), 4f, 0.75f, true);
			}
			Exploder.Explode(Vector2.op_Implicit(((tk2dBaseSprite)obj.GetComponent<tk2dSprite>()).WorldCenter), val, Vector2.zero, (Action)null, false, (CoreDamageTypes)0, false);
			((MonoBehaviour)this).StartCoroutine(Kill(obj));
		}

		private IEnumerator Kill(GameObject obj)
		{
			//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
			return new _003CKill_003Ed__1(0)
			{
				_003C_003E4__this = this,
				obj = obj
			};
		}
	}

	public static void Init()
	{
		//IL_0082: Unknown result type (might be due to invalid IL or missing references)
		PickupObject obj = ItemSetup.NewItem<DiceGrenade>("Dice Grenade", "Die, Fool!", "A rare collectors item, two explosions are never quite the same.\n\nDesigned for the assassination of tabletop roleplayers, this one was put up for resale online after a series of continually poor rolls.", "dicegrenade_icon", assetbundle: true);
		SpawnObjectPlayerItem val = (SpawnObjectPlayerItem)(object)((obj is SpawnObjectPlayerItem) ? obj : null);
		ItemBuilder.SetCooldownType((PlayerItem)(object)val, (CooldownType)1, 190f);
		((PlayerItem)val).consumable = false;
		val.objectToSpawn = BuildPrefab();
		val.tossForce = 5f;
		val.canBounce = true;
		val.IsCigarettes = false;
		val.RequireEnemiesInRoom = false;
		val.SpawnRadialCopies = false;
		val.RadialCopiesToSpawn = 0;
		val.AudioEvent = "Play_OBJ_bomb_fuse_01";
		val.IsKageBunshinItem = false;
		((PickupObject)val).quality = (ItemQuality)1;
	}

	public static GameObject BuildPrefab()
	{
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Expected O, but got Unknown
		//IL_02cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_02fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0305: Unknown result type (might be due to invalid IL or missing references)
		//IL_030c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0313: Unknown result type (might be due to invalid IL or missing references)
		//IL_0320: Expected O, but got Unknown
		GameObject val = SpriteBuilder.SpriteFromResource("NevernamedsItems/Resources/ThrowableActives/dicegrenade_primed_001.png", new GameObject("DiceBomb"), (Assembly)null);
		val.SetActive(false);
		FakePrefab.MarkAsFakePrefab(val);
		tk2dSpriteAnimator val2 = val.AddComponent<tk2dSpriteAnimator>();
		PickupObject byId = PickupObjectDatabase.GetById(108);
		tk2dSpriteCollectionData spriteCollection = ((SpawnObjectPlayerItem)((byId is SpawnObjectPlayerItem) ? byId : null)).objectToSpawn.GetComponent<tk2dSpriteAnimator>().Library.clips[0].frames[0].spriteCollection;
		tk2dSpriteAnimationClip val3 = SpriteBuilder.AddAnimation(val2, spriteCollection, new List<int>
		{
			SpriteBuilder.AddSpriteToCollection("NevernamedsItems/Resources/ThrowableActives/dicegrenade_throw_001.png", spriteCollection, (Assembly)null),
			SpriteBuilder.AddSpriteToCollection("NevernamedsItems/Resources/ThrowableActives/dicegrenade_throw_002.png", spriteCollection, (Assembly)null),
			SpriteBuilder.AddSpriteToCollection("NevernamedsItems/Resources/ThrowableActives/dicegrenade_throw_003.png", spriteCollection, (Assembly)null),
			SpriteBuilder.AddSpriteToCollection("NevernamedsItems/Resources/ThrowableActives/dicegrenade_throw_004.png", spriteCollection, (Assembly)null),
			SpriteBuilder.AddSpriteToCollection("NevernamedsItems/Resources/ThrowableActives/dicegrenade_throw_005.png", spriteCollection, (Assembly)null),
			SpriteBuilder.AddSpriteToCollection("NevernamedsItems/Resources/ThrowableActives/dicegrenade_throw_006.png", spriteCollection, (Assembly)null),
			SpriteBuilder.AddSpriteToCollection("NevernamedsItems/Resources/ThrowableActives/dicegrenade_throw_007.png", spriteCollection, (Assembly)null),
			SpriteBuilder.AddSpriteToCollection("NevernamedsItems/Resources/ThrowableActives/dicegrenade_throw_008.png", spriteCollection, (Assembly)null),
			SpriteBuilder.AddSpriteToCollection("NevernamedsItems/Resources/ThrowableActives/dicegrenade_throw_009.png", spriteCollection, (Assembly)null),
			SpriteBuilder.AddSpriteToCollection("NevernamedsItems/Resources/ThrowableActives/dicegrenade_throw_010.png", spriteCollection, (Assembly)null)
		}, "dicebomb_thrown", (WrapMode)2, 15f);
		val3.fps = 20f;
		tk2dSpriteAnimationFrame[] frames = val3.frames;
		foreach (tk2dSpriteAnimationFrame val4 in frames)
		{
			val4.eventLerpEmissiveTime = 0.5f;
			val4.eventLerpEmissivePower = 30f;
		}
		tk2dSpriteAnimationClip val5 = SpriteBuilder.AddAnimation(val2, spriteCollection, new List<int> { SpriteBuilder.AddSpriteToCollection("NevernamedsItems/Resources/ThrowableActives/dicegrenade_explode_001.png", spriteCollection, (Assembly)null) }, "dicebomb_explode", (WrapMode)2, 15f);
		val5.fps = 16f;
		tk2dSpriteAnimationFrame[] frames2 = val5.frames;
		foreach (tk2dSpriteAnimationFrame val6 in frames2)
		{
			val6.eventLerpEmissiveTime = 0.5f;
			val6.eventLerpEmissivePower = 30f;
		}
		tk2dSpriteAnimationClip val7 = SpriteBuilder.AddAnimation(val2, spriteCollection, new List<int>
		{
			SpriteBuilder.AddSpriteToCollection("NevernamedsItems/Resources/ThrowableActives/dicegrenade_primed_001.png", spriteCollection, (Assembly)null),
			SpriteBuilder.AddSpriteToCollection("NevernamedsItems/Resources/ThrowableActives/dicegrenade_primed_002.png", spriteCollection, (Assembly)null),
			SpriteBuilder.AddSpriteToCollection("NevernamedsItems/Resources/ThrowableActives/dicegrenade_primed_003.png", spriteCollection, (Assembly)null),
			SpriteBuilder.AddSpriteToCollection("NevernamedsItems/Resources/ThrowableActives/dicegrenade_primed_004.png", spriteCollection, (Assembly)null),
			SpriteBuilder.AddSpriteToCollection("NevernamedsItems/Resources/ThrowableActives/dicegrenade_primed_005.png", spriteCollection, (Assembly)null),
			SpriteBuilder.AddSpriteToCollection("NevernamedsItems/Resources/ThrowableActives/dicegrenade_primed_006.png", spriteCollection, (Assembly)null)
		}, "dicebomb_primed", (WrapMode)1, 15f);
		val7.fps = 12f;
		val7.loopStart = 4;
		tk2dSpriteAnimationFrame[] frames3 = val7.frames;
		foreach (tk2dSpriteAnimationFrame val8 in frames3)
		{
			val8.eventLerpEmissiveTime = 0.5f;
			val8.eventLerpEmissivePower = 30f;
		}
		CustomThrowableObject val9 = new CustomThrowableObject
		{
			OnThrownAnimation = "dicebomb_thrown",
			DefaultAnim = "dicebomb_primed",
			OnEffectAnim = "dicebomb_explode",
			thrownSoundEffect = "Play_OBJ_item_throw_01",
			destroyOnHitGround = false,
			doEffectOnHitGround = false,
			doEffectAfterTime = true,
			timeTillEffect = 1f
		};
		SpriteBuilder.AddComponent<CustomThrowableObject>(val, val9);
		val.AddComponent<DiceGrenadeEffect>();
		return val;
	}
}
