using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Alexandria.EnemyAPI;
using Alexandria.ItemAPI;
using Alexandria.Misc;
using Dungeonator;
using UnityEngine;

namespace NevernamedsItems;

public class Cubud : PassiveItem
{
	public class CubudController : CompanionController
	{
		[CompilerGenerated]
		private sealed class _003CAttack_003Ed__2 : IEnumerator<object>, IDisposable, IEnumerator
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public Vector2 pointOnTarget;

			public CubudController _003C_003E4__this;

			private int _003Ci_003E5__1;

			private float _003CstartAngle_003E5__2;

			private float _003CendAngle_003E5__3;

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
			public _003CAttack_003Ed__2(int _003C_003E1__state)
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
				//IL_0073: Unknown result type (might be due to invalid IL or missing references)
				//IL_007d: Expected O, but got Unknown
				//IL_0126: Unknown result type (might be due to invalid IL or missing references)
				//IL_0130: Expected O, but got Unknown
				switch (_003C_003E1__state)
				{
				default:
					return false;
				case 0:
					_003C_003E1__state = -1;
					((BraveBehaviour)_003C_003E4__this).aiActor.MovementSpeed = 0f;
					_003C_003E4__this.isAttacking = true;
					((BraveBehaviour)_003C_003E4__this).aiAnimator.PlayUntilFinished("attack", false, (string)null, -1f, false);
					_003C_003E2__current = (object)new WaitForSeconds(0.33f);
					_003C_003E1__state = 1;
					return true;
				case 1:
					_003C_003E1__state = -1;
					AkSoundEngine.PostEvent("Play_OBJ_cauldron_splash_01", ((Component)_003C_003E4__this).gameObject);
					_003Ci_003E5__1 = 0;
					while (_003Ci_003E5__1 < 4)
					{
						_003CstartAngle_003E5__2 = 45f + 90f * (float)_003Ci_003E5__1;
						_003CendAngle_003E5__3 = -45f + 90f * (float)_003Ci_003E5__1;
						((MonoBehaviour)_003C_003E4__this).StartCoroutine(_003C_003E4__this.DoPoisonStream(_003CstartAngle_003E5__2, _003CendAngle_003E5__3));
						_003Ci_003E5__1++;
					}
					_003C_003E2__current = (object)new WaitForSeconds(0.1f);
					_003C_003E1__state = 2;
					return true;
				case 2:
					_003C_003E1__state = -1;
					((BraveBehaviour)_003C_003E4__this).aiActor.MovementSpeed = ((BraveBehaviour)_003C_003E4__this).aiActor.BaseMovementSpeed;
					_003C_003E4__this.isAttacking = false;
					_003C_003E4__this.attackTimer = 4f;
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

		[CompilerGenerated]
		private sealed class _003CDoPoisonStream_003Ed__3 : IEnumerator<object>, IDisposable, IEnumerator
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public float startAngle;

			public float endAngle;

			public CubudController _003C_003E4__this;

			private float _003Celapsed_003E5__1;

			private BeamController _003Cbeam_003E5__2;

			private Projectile _003Cbeamprojcomponent_003E5__3;

			private float _003CfinalAngle_003E5__4;

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
			public _003CDoPoisonStream_003Ed__3(int _003C_003E1__state)
			{
				this._003C_003E1__state = _003C_003E1__state;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				_003Cbeam_003E5__2 = null;
				_003Cbeamprojcomponent_003E5__3 = null;
				_003C_003E1__state = -2;
			}

			private bool MoveNext()
			{
				//IL_0064: Unknown result type (might be due to invalid IL or missing references)
				//IL_0212: Unknown result type (might be due to invalid IL or missing references)
				switch (_003C_003E1__state)
				{
				default:
					return false;
				case 0:
				{
					_003C_003E1__state = -1;
					_003Celapsed_003E5__1 = 0f;
					ref BeamController reference = ref _003Cbeam_003E5__2;
					PickupObject byId = PickupObjectDatabase.GetById(208);
					reference = BeamAPI.FreeFireBeamFromAnywhere(((Gun)((byId is Gun) ? byId : null)).DefaultModule.projectiles[0], _003C_003E4__this.Owner, ((Component)_003C_003E4__this).gameObject, Vector2.zero, startAngle, 0.1f, true, false, 0f);
					_003Cbeamprojcomponent_003E5__3 = ((Component)_003Cbeam_003E5__2).GetComponent<Projectile>();
					if (PassiveItem.IsFlagSetForCharacter(_003C_003E4__this.Owner, typeof(BattleStandardItem)))
					{
						ProjectileData baseData = _003Cbeamprojcomponent_003E5__3.baseData;
						baseData.damage *= BattleStandardItem.BattleStandardCompanionDamageMultiplier;
					}
					if (Object.op_Implicit((Object)(object)((GameActor)_003C_003E4__this.Owner).CurrentGun) && ((GameActor)_003C_003E4__this.Owner).CurrentGun.LuteCompanionBuffActive)
					{
						ProjectileData baseData2 = _003Cbeamprojcomponent_003E5__3.baseData;
						baseData2.damage *= 2f;
					}
					ProjectileData baseData3 = _003Cbeamprojcomponent_003E5__3.baseData;
					baseData3.damage *= _003C_003E4__this.Owner.stats.GetStatValue((StatType)5);
					ProjectileData baseData4 = _003Cbeamprojcomponent_003E5__3.baseData;
					baseData4.speed *= _003C_003E4__this.Owner.stats.GetStatValue((StatType)6);
					ProjectileData baseData5 = _003Cbeamprojcomponent_003E5__3.baseData;
					baseData5.force *= _003C_003E4__this.Owner.stats.GetStatValue((StatType)12);
					Projectile obj = _003Cbeamprojcomponent_003E5__3;
					obj.BossDamageMultiplier *= _003C_003E4__this.Owner.stats.GetStatValue((StatType)22);
					break;
				}
				case 1:
					_003C_003E1__state = -1;
					break;
				}
				while (_003Celapsed_003E5__1 <= 0.1f)
				{
					if (Object.op_Implicit((Object)(object)_003Cbeam_003E5__2))
					{
						_003CfinalAngle_003E5__4 = Mathf.Lerp(startAngle, endAngle, _003Celapsed_003E5__1 / 0.1f);
						_003Cbeam_003E5__2.Direction = MathsAndLogicHelper.DegreeToVector2(_003CfinalAngle_003E5__4);
						_003Celapsed_003E5__1 += BraveTime.DeltaTime;
						_003C_003E2__current = null;
						_003C_003E1__state = 1;
						return true;
					}
				}
				return false;
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

		public PlayerController Owner;

		private float attackTimer;

		private bool isAttacking;

		private void Start()
		{
			Owner = base.m_owner;
			attackTimer = 2f;
		}

		public override void Update()
		{
			//IL_0028: Unknown result type (might be due to invalid IL or missing references)
			//IL_0098: Unknown result type (might be due to invalid IL or missing references)
			//IL_009d: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
			if (!Object.op_Implicit((Object)(object)Owner) || Dungeon.IsGenerating || !Owner.IsInCombat || Vector3Extensions.GetAbsoluteRoom(((BraveBehaviour)this).transform.position) != Owner.CurrentRoom)
			{
				return;
			}
			if (attackTimer > 0f)
			{
				attackTimer -= BraveTime.DeltaTime;
			}
			else if (Object.op_Implicit((Object)(object)((BraveBehaviour)this).aiActor.OverrideTarget))
			{
				Vector2 val = AIActorUtility.ClosestPointOnRigidBody(((BraveBehaviour)this).aiActor.OverrideTarget, ((BraveBehaviour)this).sprite.WorldCenter);
				if (val != Vector2.zero && !isAttacking)
				{
					((MonoBehaviour)this).StartCoroutine(Attack(val));
				}
			}
		}

		private IEnumerator Attack(Vector2 pointOnTarget)
		{
			//IL_000e: Unknown result type (might be due to invalid IL or missing references)
			//IL_000f: Unknown result type (might be due to invalid IL or missing references)
			//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
			return new _003CAttack_003Ed__2(0)
			{
				_003C_003E4__this = this,
				pointOnTarget = pointOnTarget
			};
		}

		private IEnumerator DoPoisonStream(float startAngle, float endAngle)
		{
			//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
			return new _003CDoPoisonStream_003Ed__3(0)
			{
				_003C_003E4__this = this,
				startAngle = startAngle,
				endAngle = endAngle
			};
		}
	}

	public static GameObject prefab;

	private static readonly string guid = "nn:cubud";

	public static void Init()
	{
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		PickupObject obj = ItemSetup.NewItem<CompanionItem>("Cubud", "Stanking Officer", "An up and coming officer in the Blobulonian army before it's fall- they were one of the few members of the aerial corps to volunteer for the genetic modification program.", "cubud_icon", assetbundle: true);
		CompanionItem val = (CompanionItem)(object)((obj is CompanionItem) ? obj : null);
		((PickupObject)val).quality = (ItemQuality)2;
		val.CompanionGuid = guid;
		BuildPrefab();
		ItemBuilder.AddToSubShop((PickupObject)(object)val, (ShopType)0, 1f);
	}

	public static void BuildPrefab()
	{
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_0100: Unknown result type (might be due to invalid IL or missing references)
		//IL_0131: Unknown result type (might be due to invalid IL or missing references)
		//IL_0162: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0208: Unknown result type (might be due to invalid IL or missing references)
		//IL_0239: Unknown result type (might be due to invalid IL or missing references)
		//IL_028f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0296: Expected O, but got Unknown
		if (!((Object)(object)prefab != (Object)null) && !CompanionBuilder.companionDictionary.ContainsKey(guid))
		{
			prefab = CompanionBuilder.BuildPrefab("Cubud", guid, "NevernamedsItems/Resources/Companions/Cubud/cubud_idleright_001", new IntVector2(12, 1), new IntVector2(7, 9));
			CubudController cubudController = prefab.AddComponent<CubudController>();
			((BraveBehaviour)cubudController).aiActor.MovementSpeed = 4f;
			AIAnimator orAddComponent = GameObjectExtensions.GetOrAddComponent<AIAnimator>(prefab);
			((CompanionController)cubudController).CanCrossPits = true;
			((GameActor)((BraveBehaviour)cubudController).aiActor).SetIsFlying(true, "Flying Entity", false, true);
			((GameActor)((BraveBehaviour)cubudController).aiActor).ActorShadowOffset = new Vector3(0f, -0.2f);
			orAddComponent.AdvAddAnimation("idle", (DirectionType)4, (AnimationType)1, new List<AnimationUtilityExtensions.DirectionalAnimationData>
			{
				new AnimationUtilityExtensions.DirectionalAnimationData
				{
					subAnimationName = "idle_back_right",
					wrapMode = (WrapMode)0,
					fps = 9,
					pathDirectory = "NevernamedsItems/Resources/Companions/Cubud/cubud_idleback"
				},
				new AnimationUtilityExtensions.DirectionalAnimationData
				{
					subAnimationName = "idle_front_right",
					wrapMode = (WrapMode)0,
					fps = 9,
					pathDirectory = "NevernamedsItems/Resources/Companions/Cubud/cubud_idleright"
				},
				new AnimationUtilityExtensions.DirectionalAnimationData
				{
					subAnimationName = "idle_front_left",
					wrapMode = (WrapMode)0,
					fps = 9,
					pathDirectory = "NevernamedsItems/Resources/Companions/Cubud/cubud_idleleft"
				},
				new AnimationUtilityExtensions.DirectionalAnimationData
				{
					subAnimationName = "idle_back_left",
					wrapMode = (WrapMode)0,
					fps = 9,
					pathDirectory = "NevernamedsItems/Resources/Companions/Cubud/cubud_idleback"
				}
			});
			orAddComponent.AdvAddAnimation("attack", (DirectionType)4, (AnimationType)6, new List<AnimationUtilityExtensions.DirectionalAnimationData>
			{
				new AnimationUtilityExtensions.DirectionalAnimationData
				{
					subAnimationName = "attack_back_right",
					wrapMode = (WrapMode)2,
					fps = 9,
					pathDirectory = "NevernamedsItems/Resources/Companions/Cubud/cubud_attackback"
				},
				new AnimationUtilityExtensions.DirectionalAnimationData
				{
					subAnimationName = "attack_front_right",
					wrapMode = (WrapMode)2,
					fps = 9,
					pathDirectory = "NevernamedsItems/Resources/Companions/Cubud/cubud_attackright"
				},
				new AnimationUtilityExtensions.DirectionalAnimationData
				{
					subAnimationName = "attack_front_left",
					wrapMode = (WrapMode)2,
					fps = 9,
					pathDirectory = "NevernamedsItems/Resources/Companions/Cubud/cubud_attackleft"
				},
				new AnimationUtilityExtensions.DirectionalAnimationData
				{
					subAnimationName = "attack_back_left",
					wrapMode = (WrapMode)2,
					fps = 9,
					pathDirectory = "NevernamedsItems/Resources/Companions/Cubud/cubud_attackback"
				}
			});
			BehaviorSpeculator component = prefab.GetComponent<BehaviorSpeculator>();
			CustomCompanionBehaviours.SimpleCompanionApproach simpleCompanionApproach = new CustomCompanionBehaviours.SimpleCompanionApproach();
			simpleCompanionApproach.DesiredDistance = 7f;
			component.MovementBehaviors.Add((MovementBehaviorBase)(object)simpleCompanionApproach);
			List<MovementBehaviorBase> movementBehaviors = component.MovementBehaviors;
			CompanionFollowPlayerBehavior val = new CompanionFollowPlayerBehavior();
			val.IdleAnimations = new string[1] { "idle" };
			val.CatchUpRadius = 6f;
			val.CatchUpMaxSpeed = 10f;
			val.CatchUpAccelTime = 1f;
			val.CatchUpSpeed = 7f;
			movementBehaviors.Add((MovementBehaviorBase)(object)val);
		}
	}
}
