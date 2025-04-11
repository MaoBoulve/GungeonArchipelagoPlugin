using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Alexandria.ItemAPI;
using Dungeonator;
using UnityEngine;

namespace NevernamedsItems;

public class LilMunchy : PassiveItem
{
	public class LilMunchyController : CompanionController, IPlayerInteractable
	{
		[CompilerGenerated]
		private sealed class _003CDoDisgust_003Ed__11 : IEnumerator<object>, IDisposable, IEnumerator
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public LilMunchyController _003C_003E4__this;

			private Vector2 _003Cvector_003E5__1;

			private GameObject _003CcrossX_003E5__2;

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
			public _003CDoDisgust_003Ed__11(int _003C_003E1__state)
			{
				this._003C_003E1__state = _003C_003E1__state;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				_003CcrossX_003E5__2 = null;
				_003C_003E1__state = -2;
			}

			private bool MoveNext()
			{
				//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
				//IL_007a: Unknown result type (might be due to invalid IL or missing references)
				//IL_008f: Unknown result type (might be due to invalid IL or missing references)
				//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
				//IL_00b4: Unknown result type (might be due to invalid IL or missing references)
				//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
				//IL_00d7: Unknown result type (might be due to invalid IL or missing references)
				//IL_00dc: Unknown result type (might be due to invalid IL or missing references)
				//IL_00f4: Unknown result type (might be due to invalid IL or missing references)
				//IL_00fe: Expected O, but got Unknown
				switch (_003C_003E1__state)
				{
				default:
					return false;
				case 0:
					_003C_003E1__state = -1;
					_003C_003E4__this.isDoingSomething = true;
					((BraveBehaviour)_003C_003E4__this).aiAnimator.PlayUntilFinished("disgust", false, (string)null, -1f, false);
					((BraveBehaviour)_003C_003E4__this).aiActor.MovementSpeed = 0f;
					_003Cvector_003E5__1 = ((!Object.op_Implicit((Object)(object)((BraveBehaviour)((BraveBehaviour)_003C_003E4__this).aiActor).sprite)) ? Vector2.up : (Vector2.up * (((BraveBehaviour)((BraveBehaviour)_003C_003E4__this).aiActor).sprite.WorldTopCenter.y - ((BraveBehaviour)((BraveBehaviour)_003C_003E4__this).aiActor).sprite.WorldBottomCenter.y)));
					_003CcrossX_003E5__2 = ((GameActor)((BraveBehaviour)_003C_003E4__this).aiActor).PlayEffectOnActor(SharedVFX.LastBulletStandingX, Vector2.op_Implicit(_003Cvector_003E5__1), true, false, false);
					_003C_003E2__current = (object)new WaitForSeconds(0.5556f);
					_003C_003E1__state = 1;
					return true;
				case 1:
					_003C_003E1__state = -1;
					AkSoundEngine.PostEvent("Play_ENM_lizard_bubble_01", ((Component)_003C_003E4__this).gameObject);
					((BraveBehaviour)_003C_003E4__this).aiActor.MovementSpeed = ((BraveBehaviour)_003C_003E4__this).aiActor.BaseMovementSpeed;
					Object.Destroy((Object)(object)_003CcrossX_003E5__2);
					_003C_003E4__this.isDoingSomething = false;
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
		private sealed class _003CEatGun_003Ed__8 : IEnumerator<object>, IDisposable, IEnumerator
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public PlayerController interactor;

			public LilMunchyController _003C_003E4__this;

			private ItemQuality _003CcachedQual_003E5__1;

			private Vector2 _003Cvector_003E5__2;

			private GameObject _003Cheart_003E5__3;

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
			public _003CEatGun_003Ed__8(int _003C_003E1__state)
			{
				this._003C_003E1__state = _003C_003E1__state;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				_003Cheart_003E5__3 = null;
				_003C_003E1__state = -2;
			}

			private bool MoveNext()
			{
				//IL_007c: Unknown result type (might be due to invalid IL or missing references)
				//IL_0081: Unknown result type (might be due to invalid IL or missing references)
				//IL_01cc: Unknown result type (might be due to invalid IL or missing references)
				//IL_00fb: Unknown result type (might be due to invalid IL or missing references)
				//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
				//IL_00cf: Unknown result type (might be due to invalid IL or missing references)
				//IL_00e9: Unknown result type (might be due to invalid IL or missing references)
				//IL_00f4: Unknown result type (might be due to invalid IL or missing references)
				//IL_0174: Unknown result type (might be due to invalid IL or missing references)
				//IL_017a: Invalid comparison between Unknown and I4
				//IL_0100: Unknown result type (might be due to invalid IL or missing references)
				//IL_011c: Unknown result type (might be due to invalid IL or missing references)
				//IL_0121: Unknown result type (might be due to invalid IL or missing references)
				//IL_0139: Unknown result type (might be due to invalid IL or missing references)
				//IL_0143: Expected O, but got Unknown
				//IL_01e2: Unknown result type (might be due to invalid IL or missing references)
				//IL_01e7: Unknown result type (might be due to invalid IL or missing references)
				//IL_01a5: Unknown result type (might be due to invalid IL or missing references)
				//IL_01af: Expected O, but got Unknown
				switch (_003C_003E1__state)
				{
				default:
					return false;
				case 0:
					_003C_003E1__state = -1;
					_003C_003E4__this.isDoingSomething = true;
					((BraveBehaviour)_003C_003E4__this).aiActor.MovementSpeed = 0f;
					((BraveBehaviour)_003C_003E4__this).aiAnimator.PlayUntilFinished("eat", false, (string)null, -1f, false);
					_003CcachedQual_003E5__1 = ((PickupObject)((GameActor)interactor).CurrentGun).quality;
					interactor.inventory.RemoveGunFromInventory(((GameActor)interactor).CurrentGun);
					_003Cvector_003E5__2 = ((!Object.op_Implicit((Object)(object)((BraveBehaviour)((BraveBehaviour)_003C_003E4__this).aiActor).sprite)) ? Vector2.up : (Vector2.up * (((BraveBehaviour)((BraveBehaviour)_003C_003E4__this).aiActor).sprite.WorldTopCenter.y - ((BraveBehaviour)((BraveBehaviour)_003C_003E4__this).aiActor).sprite.WorldBottomCenter.y)));
					_003Cheart_003E5__3 = ((GameActor)((BraveBehaviour)_003C_003E4__this).aiActor).PlayEffectOnActor(((GameActorEffect)StaticStatusEffects.charmingRoundsEffect).OverheadVFX, Vector2.op_Implicit(_003Cvector_003E5__2), true, false, false);
					_003C_003E2__current = (object)new WaitForSeconds(0.5f);
					_003C_003E1__state = 1;
					return true;
				case 1:
					_003C_003E1__state = -1;
					if (Object.op_Implicit((Object)(object)_003Cheart_003E5__3))
					{
						Object.Destroy((Object)(object)_003Cheart_003E5__3);
					}
					if ((int)_003C_003E4__this.lastEatenGunQuality > 0)
					{
						((BraveBehaviour)_003C_003E4__this).aiAnimator.PlayUntilFinished("puke", false, (string)null, -1f, false);
						_003C_003E2__current = (object)new WaitForSeconds(1.22f);
						_003C_003E1__state = 2;
						return true;
					}
					_003C_003E4__this.lastEatenGunQuality = _003CcachedQual_003E5__1;
					((BraveBehaviour)_003C_003E4__this).aiActor.MovementSpeed = ((BraveBehaviour)_003C_003E4__this).aiActor.BaseMovementSpeed;
					_003C_003E4__this.isDoingSomething = false;
					break;
				case 2:
					_003C_003E1__state = -1;
					_003C_003E4__this.DetermineAndSpawnMunchedGun(interactor, _003CcachedQual_003E5__1);
					break;
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

		private RoomHandler curRoom;

		private ItemQuality lastEatenGunQuality = (ItemQuality)0;

		private bool isDoingSomething = false;

		public PlayerController Owner;

		private void Start()
		{
			//IL_0023: Unknown result type (might be due to invalid IL or missing references)
			//IL_0029: Unknown result type (might be due to invalid IL or missing references)
			Owner = base.m_owner;
			curRoom = GameManager.Instance.Dungeon.data.GetAbsoluteRoomFromPosition(Vector3Extensions.IntXY(((BraveBehaviour)this).transform.position, (VectorConversions)2));
			curRoom.RegisterInteractable((IPlayerInteractable)(object)this);
		}

		public override void Update()
		{
			if (Object.op_Implicit((Object)(object)((BraveBehaviour)this).aiActor) && Object.op_Implicit((Object)(object)((BraveBehaviour)this).aiActor.CompanionOwner) && curRoom != ((BraveBehaviour)this).aiActor.CompanionOwner.CurrentRoom)
			{
				if (curRoom != null)
				{
					ReAssign(curRoom, ((BraveBehaviour)this).aiActor.CompanionOwner.CurrentRoom);
				}
				else
				{
					((BraveBehaviour)this).aiActor.CompanionOwner.CurrentRoom.RegisterInteractable((IPlayerInteractable)(object)this);
				}
				curRoom = ((BraveBehaviour)this).aiActor.CompanionOwner.CurrentRoom;
			}
		}

		private void ReAssign(RoomHandler oldRoom, RoomHandler newRoom)
		{
			oldRoom.DeregisterInteractable((IPlayerInteractable)(object)this);
			newRoom.RegisterInteractable((IPlayerInteractable)(object)this);
		}

		public float GetDistanceToPoint(Vector2 point)
		{
			//IL_0025: Unknown result type (might be due to invalid IL or missing references)
			//IL_002a: Unknown result type (might be due to invalid IL or missing references)
			//IL_002f: Unknown result type (might be due to invalid IL or missing references)
			//IL_003a: Unknown result type (might be due to invalid IL or missing references)
			//IL_003f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0046: Unknown result type (might be due to invalid IL or missing references)
			//IL_0051: Unknown result type (might be due to invalid IL or missing references)
			//IL_0056: Unknown result type (might be due to invalid IL or missing references)
			//IL_0061: Unknown result type (might be due to invalid IL or missing references)
			//IL_0069: Unknown result type (might be due to invalid IL or missing references)
			//IL_007a: Unknown result type (might be due to invalid IL or missing references)
			//IL_008a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0092: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
			if (!Object.op_Implicit((Object)(object)((BraveBehaviour)this).sprite))
			{
				return float.MaxValue;
			}
			Bounds bounds = ((BraveBehaviour)this).sprite.GetBounds();
			((Bounds)(ref bounds)).SetMinMax(((Bounds)(ref bounds)).min + ((BraveBehaviour)this).transform.position, ((Bounds)(ref bounds)).max + ((BraveBehaviour)this).transform.position);
			float num = Mathf.Max(Mathf.Min(point.x, ((Bounds)(ref bounds)).max.x), ((Bounds)(ref bounds)).min.x);
			float num2 = Mathf.Max(Mathf.Min(point.y, ((Bounds)(ref bounds)).max.y), ((Bounds)(ref bounds)).min.y);
			return Mathf.Sqrt((point.x - num) * (point.x - num) + (point.y - num2) * (point.y - num2));
		}

		public void OnEnteredRange(PlayerController interactor)
		{
			//IL_0014: Unknown result type (might be due to invalid IL or missing references)
			SpriteOutlineManager.RemoveOutlineFromSprite(((BraveBehaviour)this).sprite, true);
			SpriteOutlineManager.AddOutlineToSprite(((BraveBehaviour)this).sprite, Color.white);
		}

		public void OnExitRange(PlayerController interactor)
		{
			//IL_0014: Unknown result type (might be due to invalid IL or missing references)
			SpriteOutlineManager.RemoveOutlineFromSprite(((BraveBehaviour)this).sprite, true);
			SpriteOutlineManager.AddOutlineToSprite(((BraveBehaviour)this).sprite, Color.black);
		}

		public void Interact(PlayerController interactor)
		{
			if (isDoingSomething || interactor.IsInCombat)
			{
				return;
			}
			if ((Object)(object)((GameActor)interactor).CurrentGun != (Object)null)
			{
				if (((PickupObject)((GameActor)interactor).CurrentGun).CanBeDropped && !((GameActor)interactor).CurrentGun.InfiniteAmmo)
				{
					((MonoBehaviour)this).StartCoroutine(EatGun(interactor));
				}
				else
				{
					((MonoBehaviour)this).StartCoroutine(DoDisgust());
				}
			}
			else
			{
				((MonoBehaviour)this).StartCoroutine(DoDisgust());
			}
		}

		private IEnumerator EatGun(PlayerController interactor)
		{
			//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
			return new _003CEatGun_003Ed__8(0)
			{
				_003C_003E4__this = this,
				interactor = interactor
			};
		}

		private void DetermineAndSpawnMunchedGun(PlayerController player, ItemQuality recentQuality)
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			//IL_0003: Unknown result type (might be due to invalid IL or missing references)
			//IL_0009: Unknown result type (might be due to invalid IL or missing references)
			//IL_000f: Expected I4, but got Unknown
			//IL_000f: Expected I4, but got Unknown
			//IL_003f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0044: Unknown result type (might be due to invalid IL or missing references)
			//IL_0049: Unknown result type (might be due to invalid IL or missing references)
			//IL_005e: Unknown result type (might be due to invalid IL or missing references)
			int num = Random.Range((int)recentQuality, lastEatenGunQuality + 1);
			GameObject itemForPlayer = GameManager.Instance.RewardManager.GetItemForPlayer(player, GameManager.Instance.RewardManager.GunsLootTable, (ItemQuality)num, (List<GameObject>)null, false, (Random)null, false, (List<GameObject>)null, false, (RewardSource)0);
			LootEngine.SpawnItem(itemForPlayer, Vector2.op_Implicit(((BraveBehaviour)this).sprite.WorldCenter), Vector2.zero, 0f, true, false, false);
			lastEatenGunQuality = (ItemQuality)0;
			((BraveBehaviour)this).aiActor.MovementSpeed = ((BraveBehaviour)this).aiActor.BaseMovementSpeed;
			isDoingSomething = false;
		}

		private IEnumerator DoDisgust()
		{
			//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
			return new _003CDoDisgust_003Ed__11(0)
			{
				_003C_003E4__this = this
			};
		}

		public string GetAnimationState(PlayerController interactor, out bool shouldBeFlipped)
		{
			shouldBeFlipped = false;
			return string.Empty;
		}

		public float GetOverrideMaxDistance()
		{
			return 1.5f;
		}
	}

	public static GameObject prefab;

	private static readonly string guid = "lilmunchy83y8ye7w86655746847635";

	public static void Init()
	{
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		PickupObject obj = ItemSetup.NewItem<CompanionItem>("Lil Munchy", "Hungry Hungry", "A juvenile muncher that hasn't yet found a suitable generic dungeon room in which to take root.\n\nHe has an endless appetite!", "lilmunchy_icon", assetbundle: true);
		CompanionItem val = (CompanionItem)(object)((obj is CompanionItem) ? obj : null);
		((PickupObject)val).quality = (ItemQuality)2;
		val.CompanionGuid = guid;
		BuildPrefab();
	}

	public static void BuildPrefab()
	{
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_012c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0171: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0204: Unknown result type (might be due to invalid IL or missing references)
		//IL_0248: Unknown result type (might be due to invalid IL or missing references)
		//IL_028c: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0305: Unknown result type (might be due to invalid IL or missing references)
		//IL_030c: Expected O, but got Unknown
		if (!((Object)(object)prefab != (Object)null) && !CompanionBuilder.companionDictionary.ContainsKey(guid))
		{
			prefab = CompanionBuilder.BuildPrefab("Lil Munchy", guid, "NevernamedsItems/Resources/Companions/LilMunchy/munchy_idle_front_001", new IntVector2(7, 2), new IntVector2(6, 6));
			LilMunchyController lilMunchyController = prefab.AddComponent<LilMunchyController>();
			((BraveBehaviour)lilMunchyController).aiActor.MovementSpeed = 4f;
			AIAnimator orAddComponent = GameObjectExtensions.GetOrAddComponent<AIAnimator>(prefab);
			orAddComponent.AdvAddAnimation("idle", (DirectionType)9, (AnimationType)1, new List<AnimationUtilityExtensions.DirectionalAnimationData>
			{
				new AnimationUtilityExtensions.DirectionalAnimationData
				{
					subAnimationName = "idle_north",
					wrapMode = (WrapMode)0,
					fps = 9,
					pathDirectory = "NevernamedsItems/Resources/Companions/LilMunchy/munchy_idle_back"
				},
				new AnimationUtilityExtensions.DirectionalAnimationData
				{
					subAnimationName = "idle_east",
					wrapMode = (WrapMode)0,
					fps = 9,
					pathDirectory = "NevernamedsItems/Resources/Companions/LilMunchy/munchy_idle_right"
				},
				new AnimationUtilityExtensions.DirectionalAnimationData
				{
					subAnimationName = "idle_south",
					wrapMode = (WrapMode)0,
					fps = 9,
					pathDirectory = "NevernamedsItems/Resources/Companions/LilMunchy/munchy_idle_front"
				},
				new AnimationUtilityExtensions.DirectionalAnimationData
				{
					subAnimationName = "idle_west",
					wrapMode = (WrapMode)0,
					fps = 9,
					pathDirectory = "NevernamedsItems/Resources/Companions/LilMunchy/munchy_idle_left"
				}
			});
			orAddComponent.AdvAddAnimation("move", (DirectionType)9, (AnimationType)0, new List<AnimationUtilityExtensions.DirectionalAnimationData>
			{
				new AnimationUtilityExtensions.DirectionalAnimationData
				{
					subAnimationName = "move_north",
					wrapMode = (WrapMode)0,
					fps = 9,
					pathDirectory = "NevernamedsItems/Resources/Companions/LilMunchy/munchy_move_back"
				},
				new AnimationUtilityExtensions.DirectionalAnimationData
				{
					subAnimationName = "move_east",
					wrapMode = (WrapMode)0,
					fps = 9,
					pathDirectory = "NevernamedsItems/Resources/Companions/LilMunchy/munchy_move_right"
				},
				new AnimationUtilityExtensions.DirectionalAnimationData
				{
					subAnimationName = "move_south",
					wrapMode = (WrapMode)0,
					fps = 9,
					pathDirectory = "NevernamedsItems/Resources/Companions/LilMunchy/munchy_move_front"
				},
				new AnimationUtilityExtensions.DirectionalAnimationData
				{
					subAnimationName = "move_west",
					wrapMode = (WrapMode)0,
					fps = 9,
					pathDirectory = "NevernamedsItems/Resources/Companions/LilMunchy/munchy_move_left"
				}
			});
			orAddComponent.AdvAddAnimation("eat", (DirectionType)1, (AnimationType)6, new List<AnimationUtilityExtensions.DirectionalAnimationData>
			{
				new AnimationUtilityExtensions.DirectionalAnimationData
				{
					subAnimationName = "eat",
					wrapMode = (WrapMode)2,
					fps = 9,
					pathDirectory = "NevernamedsItems/Resources/Companions/LilMunchy/munchy_eat"
				}
			});
			orAddComponent.AdvAddAnimation("puke", (DirectionType)1, (AnimationType)6, new List<AnimationUtilityExtensions.DirectionalAnimationData>
			{
				new AnimationUtilityExtensions.DirectionalAnimationData
				{
					subAnimationName = "puke",
					wrapMode = (WrapMode)2,
					fps = 9,
					pathDirectory = "NevernamedsItems/Resources/Companions/LilMunchy/munchy_puke"
				}
			});
			orAddComponent.AdvAddAnimation("disgust", (DirectionType)1, (AnimationType)6, new List<AnimationUtilityExtensions.DirectionalAnimationData>
			{
				new AnimationUtilityExtensions.DirectionalAnimationData
				{
					subAnimationName = "disgust",
					wrapMode = (WrapMode)2,
					fps = 9,
					pathDirectory = "NevernamedsItems/Resources/Companions/LilMunchy/munchy_disgust"
				}
			});
			BehaviorSpeculator component = prefab.GetComponent<BehaviorSpeculator>();
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
