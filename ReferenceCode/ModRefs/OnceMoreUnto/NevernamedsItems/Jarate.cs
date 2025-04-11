using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using Alexandria.ItemAPI;
using Dungeonator;
using UnityEngine;

namespace NevernamedsItems;

internal class Jarate : SpawnObjectPlayerItem
{
	public class JarateSmashEffect : CustomThrowableEffectDoer
	{
		[CompilerGenerated]
		private sealed class _003CKill_003Ed__1 : IEnumerator<object>, IDisposable, IEnumerator
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public GameObject obj;

			public JarateSmashEffect _003C_003E4__this;

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
			//IL_000e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0013: Unknown result type (might be due to invalid IL or missing references)
			//IL_0018: Unknown result type (might be due to invalid IL or missing references)
			//IL_003e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0044: Unknown result type (might be due to invalid IL or missing references)
			//IL_009e: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f2: Unknown result type (might be due to invalid IL or missing references)
			//IL_0109: Unknown result type (might be due to invalid IL or missing references)
			//IL_0121: Unknown result type (might be due to invalid IL or missing references)
			//IL_0158: Unknown result type (might be due to invalid IL or missing references)
			//IL_015d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0163: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a2: Unknown result type (might be due to invalid IL or missing references)
			tk2dBaseSprite component = obj.GetComponent<tk2dBaseSprite>();
			GameObject val = SpawnManager.SpawnVFX(SharedVFX.JarateExplosion, Vector2.op_Implicit(component.WorldCenter), Quaternion.identity);
			if (Object.op_Implicit((Object)(object)GameManager.Instance.PrimaryPlayer) && Vector2.Distance(((GameActor)GameManager.Instance.PrimaryPlayer).CenterPosition, component.WorldCenter) < 4f)
			{
				GameManager.Instance.PrimaryPlayer.CurrentFireMeterValue = 0f;
				GameManager.Instance.PrimaryPlayer.IsOnFire = false;
			}
			if (Object.op_Implicit((Object)(object)GameManager.Instance.SecondaryPlayer) && Vector2.Distance(((GameActor)GameManager.Instance.SecondaryPlayer).CenterPosition, component.WorldCenter) < 4f)
			{
				GameManager.Instance.SecondaryPlayer.CurrentFireMeterValue = 0f;
				GameManager.Instance.SecondaryPlayer.IsOnFire = false;
			}
			DeadlyDeadlyGoopManager goopManagerForGoopType = DeadlyDeadlyGoopManager.GetGoopManagerForGoopType(EasyGoopDefinitions.JarateGoop);
			goopManagerForGoopType.TimedAddGoopCircle(component.WorldCenter, 6f, 0.75f, true);
			if (Vector3Extensions.GetAbsoluteRoom(component.WorldCenter) != null)
			{
				List<AIActor> activeEnemies = Vector3Extensions.GetAbsoluteRoom(component.WorldCenter).GetActiveEnemies((ActiveEnemyType)0);
				if (activeEnemies != null)
				{
					for (int i = 0; i < activeEnemies.Count; i++)
					{
						AIActor val2 = activeEnemies[i];
						if (Vector2.Distance(Vector2.op_Implicit(val2.Position), component.WorldCenter) < 5f && Object.op_Implicit((Object)(object)((BraveBehaviour)val2).healthHaver))
						{
							((GameActor)val2).ApplyEffect((GameActorEffect)(object)new GameActorJarateEffect
							{
								duration = 10f,
								stackMode = (EffectStackingMode)0,
								HealthMultiplier = (((BraveBehaviour)val2).healthHaver.IsBoss ? 0.75f : 0.66f),
								SpeedMultiplier = 0.9f
							}, 1f, (Projectile)null);
						}
					}
				}
			}
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
		Jarate jarate = ItemSetup.NewItem<Jarate>("Jarate", "Good Job", "Throws a jar of miracle fluids which weakens the Gundead. \n\nGungeoneering can be a long and tedious process. The ancient art of Jarate was derived as an ingenious solution to both combat and excrement reprocessing.", "jarate_icon", assetbundle: true) as Jarate;
		ItemBuilder.SetCooldownType((PlayerItem)(object)jarate, (CooldownType)1, 800f);
		((PlayerItem)jarate).consumable = false;
		((SpawnObjectPlayerItem)jarate).objectToSpawn = BuildPrefab();
		((SpawnObjectPlayerItem)jarate).tossForce = 12f;
		((SpawnObjectPlayerItem)jarate).canBounce = false;
		((SpawnObjectPlayerItem)jarate).IsCigarettes = false;
		((SpawnObjectPlayerItem)jarate).RequireEnemiesInRoom = false;
		((SpawnObjectPlayerItem)jarate).SpawnRadialCopies = false;
		((SpawnObjectPlayerItem)jarate).RadialCopiesToSpawn = 0;
		((SpawnObjectPlayerItem)jarate).AudioEvent = null;
		((SpawnObjectPlayerItem)jarate).IsKageBunshinItem = false;
		((PickupObject)jarate).quality = (ItemQuality)2;
	}

	public static GameObject BuildPrefab()
	{
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Expected O, but got Unknown
		//IL_0161: Unknown result type (might be due to invalid IL or missing references)
		//IL_0166: Unknown result type (might be due to invalid IL or missing references)
		//IL_016d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0178: Unknown result type (might be due to invalid IL or missing references)
		//IL_0183: Unknown result type (might be due to invalid IL or missing references)
		//IL_018e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0195: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ad: Expected O, but got Unknown
		GameObject val = SpriteBuilder.SpriteFromResource("NevernamedsItems/Resources/ThrowableActives/Jarate/jarate_toss_001.png", new GameObject("JarateToss"), (Assembly)null);
		FakePrefabExtensions.MakeFakePrefab(val);
		tk2dSpriteAnimator val2 = val.AddComponent<tk2dSpriteAnimator>();
		PickupObject byId = PickupObjectDatabase.GetById(108);
		tk2dSpriteCollectionData spriteCollection = ((SpawnObjectPlayerItem)((byId is SpawnObjectPlayerItem) ? byId : null)).objectToSpawn.GetComponent<tk2dSpriteAnimator>().Library.clips[0].frames[0].spriteCollection;
		tk2dSpriteAnimationClip val3 = SpriteBuilder.AddAnimation(val2, spriteCollection, new List<int> { SpriteBuilder.AddSpriteToCollection("NevernamedsItems/Resources/ThrowableActives/Jarate/jarate_toss_004.png", spriteCollection, (Assembly)null) }, "deploy", (WrapMode)2, 15f);
		val3.fps = 12f;
		tk2dSpriteAnimationClip val4 = SpriteBuilder.AddAnimation(val2, spriteCollection, new List<int>
		{
			SpriteBuilder.AddSpriteToCollection("NevernamedsItems/Resources/ThrowableActives/Jarate/jarate_break_001.png", spriteCollection, (Assembly)null),
			SpriteBuilder.AddSpriteToCollection("NevernamedsItems/Resources/ThrowableActives/Jarate/jarate_break_002.png", spriteCollection, (Assembly)null),
			SpriteBuilder.AddSpriteToCollection("NevernamedsItems/Resources/ThrowableActives/Jarate/jarate_break_003.png", spriteCollection, (Assembly)null)
		}, "break", (WrapMode)2, 15f);
		val4.fps = 16f;
		tk2dSpriteAnimationClip val5 = SpriteBuilder.AddAnimation(val2, spriteCollection, new List<int>
		{
			SpriteBuilder.AddSpriteToCollection("NevernamedsItems/Resources/ThrowableActives/Jarate/jarate_toss_001.png", spriteCollection, (Assembly)null),
			SpriteBuilder.AddSpriteToCollection("NevernamedsItems/Resources/ThrowableActives/Jarate/jarate_toss_002.png", spriteCollection, (Assembly)null),
			SpriteBuilder.AddSpriteToCollection("NevernamedsItems/Resources/ThrowableActives/Jarate/jarate_toss_003.png", spriteCollection, (Assembly)null),
			SpriteBuilder.AddSpriteToCollection("NevernamedsItems/Resources/ThrowableActives/Jarate/jarate_toss_004.png", spriteCollection, (Assembly)null)
		}, "toss", (WrapMode)1, 15f);
		val5.fps = 12f;
		val5.loopStart = 0;
		CustomThrowableObject val6 = new CustomThrowableObject
		{
			doEffectOnHitGround = true,
			OnThrownAnimation = "deploy",
			OnHitGroundAnimation = "break",
			DefaultAnim = "toss",
			destroyOnHitGround = false,
			thrownSoundEffect = "Play_OBJ_item_throw_01",
			effectSoundEffect = "Play_OBJ_glassbottle_shatter_01"
		};
		SpriteBuilder.AddComponent<CustomThrowableObject>(val, val6);
		val.AddComponent<JarateSmashEffect>();
		return val;
	}
}
