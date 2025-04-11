using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using Alexandria.ItemAPI;
using SaveAPI;
using UnityEngine;

namespace NevernamedsItems;

internal class Lvl2Molotov : SpawnObjectPlayerItem
{
	public class LvL2MolotovEffect : CustomThrowableEffectDoer
	{
		[CompilerGenerated]
		private sealed class _003CKill_003Ed__1 : IEnumerator<object>, IDisposable, IEnumerator
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public GameObject obj;

			public LvL2MolotovEffect _003C_003E4__this;

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
					_003C_003E2__current = (object)new WaitForSeconds(0.25f);
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
			//IL_0013: Unknown result type (might be due to invalid IL or missing references)
			//IL_0018: Unknown result type (might be due to invalid IL or missing references)
			DeadlyDeadlyGoopManager goopManagerForGoopType = DeadlyDeadlyGoopManager.GetGoopManagerForGoopType(EasyGoopDefinitions.GreenFireDef);
			goopManagerForGoopType.TimedAddGoopCircle(Vector2.op_Implicit(obj.transform.position), 4f, 0.75f, true);
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
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		PickupObject obj = ItemSetup.NewItem<Lvl2Molotov>("Lvl. 2 Molotov", "BURN IT DOWN", "A souped up molotov, mixed together using organic, non-gmo, locally grown magical chemicals.", "lvl2molotov_icon", assetbundle: true);
		SpawnObjectPlayerItem val = (SpawnObjectPlayerItem)(object)((obj is SpawnObjectPlayerItem) ? obj : null);
		ItemBuilder.SetCooldownType((PlayerItem)(object)val, (CooldownType)1, 800f);
		((PlayerItem)val).consumable = false;
		val.objectToSpawn = BuildPrefab();
		val.tossForce = 12f;
		val.canBounce = false;
		val.IsCigarettes = false;
		val.RequireEnemiesInRoom = false;
		val.SpawnRadialCopies = false;
		val.RadialCopiesToSpawn = 0;
		val.AudioEvent = null;
		val.IsKageBunshinItem = false;
		((PickupObject)val).quality = (ItemQuality)1;
		((PickupObject)(object)val).SetupUnlockOnCustomFlag(CustomDungeonFlags.BOSSRUSH_CONVICT, requiredFlagValue: true);
	}

	public static GameObject BuildPrefab()
	{
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Expected O, but got Unknown
		//IL_0235: Unknown result type (might be due to invalid IL or missing references)
		//IL_023a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0241: Unknown result type (might be due to invalid IL or missing references)
		//IL_024c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0257: Unknown result type (might be due to invalid IL or missing references)
		//IL_0262: Unknown result type (might be due to invalid IL or missing references)
		//IL_0269: Unknown result type (might be due to invalid IL or missing references)
		//IL_0274: Unknown result type (might be due to invalid IL or missing references)
		//IL_0281: Expected O, but got Unknown
		GameObject val = SpriteBuilder.SpriteFromResource("NevernamedsItems/Resources/ThrowableActives/lvl2molotov_spin_001.png", new GameObject("Lvl2Molotov"), (Assembly)null);
		val.SetActive(false);
		FakePrefab.MarkAsFakePrefab(val);
		tk2dSpriteAnimator val2 = val.AddComponent<tk2dSpriteAnimator>();
		PickupObject byId = PickupObjectDatabase.GetById(108);
		tk2dSpriteCollectionData spriteCollection = ((SpawnObjectPlayerItem)((byId is SpawnObjectPlayerItem) ? byId : null)).objectToSpawn.GetComponent<tk2dSpriteAnimator>().Library.clips[0].frames[0].spriteCollection;
		tk2dSpriteAnimationClip val3 = SpriteBuilder.AddAnimation(val2, spriteCollection, new List<int> { SpriteBuilder.AddSpriteToCollection("NevernamedsItems/Resources/ThrowableActives/lvl2molotov_spin_004.png", spriteCollection, (Assembly)null) }, "lvl2mol_throw", (WrapMode)2, 15f);
		val3.fps = 12f;
		tk2dSpriteAnimationFrame[] frames = val3.frames;
		foreach (tk2dSpriteAnimationFrame val4 in frames)
		{
			val4.eventLerpEmissiveTime = 0.5f;
			val4.eventLerpEmissivePower = 30f;
		}
		tk2dSpriteAnimationClip val5 = SpriteBuilder.AddAnimation(val2, spriteCollection, new List<int>
		{
			SpriteBuilder.AddSpriteToCollection("NevernamedsItems/Resources/ThrowableActives/lvl2molotov_burst_001.png", spriteCollection, (Assembly)null),
			SpriteBuilder.AddSpriteToCollection("NevernamedsItems/Resources/ThrowableActives/lvl2molotov_burst_002.png", spriteCollection, (Assembly)null),
			SpriteBuilder.AddSpriteToCollection("NevernamedsItems/Resources/ThrowableActives/lvl2molotov_burst_003.png", spriteCollection, (Assembly)null),
			SpriteBuilder.AddSpriteToCollection("NevernamedsItems/Resources/ThrowableActives/lvl2molotov_burst_004.png", spriteCollection, (Assembly)null)
		}, "lvl2mol_burst", (WrapMode)2, 15f);
		val5.fps = 16f;
		tk2dSpriteAnimationFrame[] frames2 = val5.frames;
		foreach (tk2dSpriteAnimationFrame val6 in frames2)
		{
			val6.eventLerpEmissiveTime = 0.5f;
			val6.eventLerpEmissivePower = 30f;
		}
		tk2dSpriteAnimationClip val7 = SpriteBuilder.AddAnimation(val2, spriteCollection, new List<int>
		{
			SpriteBuilder.AddSpriteToCollection("NevernamedsItems/Resources/ThrowableActives/lvl2molotov_spin_001.png", spriteCollection, (Assembly)null),
			SpriteBuilder.AddSpriteToCollection("NevernamedsItems/Resources/ThrowableActives/lvl2molotov_spin_002.png", spriteCollection, (Assembly)null),
			SpriteBuilder.AddSpriteToCollection("NevernamedsItems/Resources/ThrowableActives/lvl2molotov_spin_003.png", spriteCollection, (Assembly)null),
			SpriteBuilder.AddSpriteToCollection("NevernamedsItems/Resources/ThrowableActives/lvl2molotov_spin_004.png", spriteCollection, (Assembly)null)
		}, "lvl2mol_default", (WrapMode)1, 15f);
		val7.fps = 10f;
		val7.loopStart = 0;
		tk2dSpriteAnimationFrame[] frames3 = val7.frames;
		foreach (tk2dSpriteAnimationFrame val8 in frames3)
		{
			val8.eventLerpEmissiveTime = 0.5f;
			val8.eventLerpEmissivePower = 30f;
		}
		CustomThrowableObject val9 = new CustomThrowableObject
		{
			doEffectOnHitGround = true,
			OnThrownAnimation = "lvl2mol_throw",
			OnHitGroundAnimation = "lvl2mol_burst",
			DefaultAnim = "lvl2mol_default",
			destroyOnHitGround = false,
			thrownSoundEffect = "Play_OBJ_item_throw_01",
			effectSoundEffect = "Play_OBJ_glassbottle_shatter_01"
		};
		SpriteBuilder.AddComponent<CustomThrowableObject>(val, val9);
		val.AddComponent<LvL2MolotovEffect>();
		return val;
	}
}
