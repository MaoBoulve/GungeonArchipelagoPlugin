using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Alexandria.ItemAPI;
using Dungeonator;
using SaveAPI;
using UnityEngine;

namespace NevernamedsItems;

public class BabyGoodDet : PassiveItem
{
	public class BabyDetBehav : CompanionController
	{
		[CompilerGenerated]
		private sealed class _003CDoLaserAttack_003Ed__3 : IEnumerator<object>, IDisposable, IEnumerator
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public BabyDetBehav _003C_003E4__this;

			private Projectile _003CbeamToFire_003E5__1;

			private int _003Cangle_003E5__2;

			private int _003Ci_003E5__3;

			private BeamController _003Cbeam_003E5__4;

			private Projectile _003Cbeamprojcomponent_003E5__5;

			private int _003Cangle_003E5__6;

			private int _003Ci_003E5__7;

			private BeamController _003Cbeam_003E5__8;

			private Projectile _003Cbeamprojcomponent_003E5__9;

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
			public _003CDoLaserAttack_003Ed__3(int _003C_003E1__state)
			{
				this._003C_003E1__state = _003C_003E1__state;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				_003CbeamToFire_003E5__1 = null;
				_003Cbeam_003E5__4 = null;
				_003Cbeamprojcomponent_003E5__5 = null;
				_003Cbeam_003E5__8 = null;
				_003Cbeamprojcomponent_003E5__9 = null;
				_003C_003E1__state = -2;
			}

			private bool MoveNext()
			{
				//IL_005e: Unknown result type (might be due to invalid IL or missing references)
				//IL_0068: Expected O, but got Unknown
				//IL_0269: Unknown result type (might be due to invalid IL or missing references)
				//IL_0113: Unknown result type (might be due to invalid IL or missing references)
				//IL_038e: Unknown result type (might be due to invalid IL or missing references)
				//IL_0398: Expected O, but got Unknown
				switch (_003C_003E1__state)
				{
				default:
					return false;
				case 0:
					_003C_003E1__state = -1;
					_003C_003E4__this.isAttacking = true;
					((BraveBehaviour)_003C_003E4__this).aiAnimator.PlayUntilFinished("attack", false, (string)null, -1f, false);
					_003C_003E2__current = (object)new WaitForSeconds(0.5f);
					_003C_003E1__state = 1;
					return true;
				case 1:
				{
					_003C_003E1__state = -1;
					AIActor aiActor2 = ((BraveBehaviour)_003C_003E4__this).aiActor;
					aiActor2.MovementSpeed *= 0.0001f;
					((BraveBehaviour)_003C_003E4__this).aiAnimator.PlayForDuration("contattack", 1f, false, (string)null, -1f, false);
					_003CbeamToFire_003E5__1 = ((BraveBehaviour)LaserBullets.SimpleRedBeam).projectile;
					if (Random.value <= 0.5f)
					{
						_003Cangle_003E5__2 = 135;
						_003Ci_003E5__3 = 0;
						while (_003Ci_003E5__3 < 4)
						{
							_003Cbeam_003E5__4 = BeamAPI.FreeFireBeamFromAnywhere(_003CbeamToFire_003E5__1, ((CompanionController)_003C_003E4__this).m_owner, ((Component)_003C_003E4__this).gameObject, Vector2.zero, (float)_003Cangle_003E5__2, 1f, true, false, 0f);
							_003Cbeamprojcomponent_003E5__5 = ((Component)_003Cbeam_003E5__4).GetComponent<Projectile>();
							ProjectileData baseData = _003Cbeamprojcomponent_003E5__5.baseData;
							baseData.damage *= 3f;
							if (PassiveItem.IsFlagSetForCharacter(_003C_003E4__this.Owner, typeof(BattleStandardItem)))
							{
								ProjectileData baseData2 = _003Cbeamprojcomponent_003E5__5.baseData;
								baseData2.damage *= BattleStandardItem.BattleStandardCompanionDamageMultiplier;
							}
							if (Object.op_Implicit((Object)(object)((GameActor)_003C_003E4__this.Owner).CurrentGun) && ((GameActor)_003C_003E4__this.Owner).CurrentGun.LuteCompanionBuffActive)
							{
								ProjectileData baseData3 = _003Cbeamprojcomponent_003E5__5.baseData;
								baseData3.damage *= 2f;
							}
							_003Cangle_003E5__2 -= 90;
							_003Cbeam_003E5__4 = null;
							_003Cbeamprojcomponent_003E5__5 = null;
							_003Ci_003E5__3++;
						}
					}
					else
					{
						_003Cangle_003E5__6 = 180;
						_003Ci_003E5__7 = 0;
						while (_003Ci_003E5__7 < 4)
						{
							_003Cbeam_003E5__8 = BeamAPI.FreeFireBeamFromAnywhere(_003CbeamToFire_003E5__1, ((CompanionController)_003C_003E4__this).m_owner, ((Component)_003C_003E4__this).gameObject, Vector2.zero, (float)_003Cangle_003E5__6, 1f, true, false, 0f);
							_003Cbeamprojcomponent_003E5__9 = ((Component)_003Cbeam_003E5__8).GetComponent<Projectile>();
							ProjectileData baseData4 = _003Cbeamprojcomponent_003E5__9.baseData;
							baseData4.damage *= 3f;
							if (PassiveItem.IsFlagSetForCharacter(_003C_003E4__this.Owner, typeof(BattleStandardItem)))
							{
								ProjectileData baseData5 = _003Cbeamprojcomponent_003E5__9.baseData;
								baseData5.damage *= BattleStandardItem.BattleStandardCompanionDamageMultiplier;
							}
							if (Object.op_Implicit((Object)(object)((GameActor)_003C_003E4__this.Owner).CurrentGun) && ((GameActor)_003C_003E4__this.Owner).CurrentGun.LuteCompanionBuffActive)
							{
								ProjectileData baseData6 = _003Cbeamprojcomponent_003E5__9.baseData;
								baseData6.damage *= 2f;
							}
							_003Cangle_003E5__6 -= 90;
							_003Cbeam_003E5__8 = null;
							_003Cbeamprojcomponent_003E5__9 = null;
							_003Ci_003E5__7++;
						}
					}
					_003C_003E2__current = (object)new WaitForSeconds(1f);
					_003C_003E1__state = 2;
					return true;
				}
				case 2:
				{
					_003C_003E1__state = -1;
					_003C_003E4__this.isAttacking = false;
					_003C_003E4__this.timer = 1.5f;
					AIActor aiActor = ((BraveBehaviour)_003C_003E4__this).aiActor;
					aiActor.MovementSpeed /= 0.0001f;
					return false;
				}
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

		private bool isAttacking = false;

		private float timer;

		public PlayerController Owner;

		private void Start()
		{
			Owner = base.m_owner;
			timer = 1.5f;
		}

		public override void Update()
		{
			//IL_0028: Unknown result type (might be due to invalid IL or missing references)
			if (Object.op_Implicit((Object)(object)Owner) && !Dungeon.IsGenerating && Owner.IsInCombat && Vector3Extensions.GetAbsoluteRoom(((BraveBehaviour)this).transform.position) == Owner.CurrentRoom)
			{
				if (timer > 0f)
				{
					timer -= BraveTime.DeltaTime;
				}
				if (timer <= 0f && !isAttacking)
				{
					((MonoBehaviour)this).StartCoroutine(DoLaserAttack());
				}
			}
		}

		private IEnumerator DoLaserAttack()
		{
			//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
			return new _003CDoLaserAttack_003Ed__3(0)
			{
				_003C_003E4__this = this
			};
		}
	}

	public static GameObject prefab;

	private static readonly string guid = "babygooddet849495496394626832697243782667wei";

	public static void Init()
	{
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		PickupObject obj = ItemSetup.NewItem<CompanionItem>("Baby Good Det", "Laserbrained", "A scale model Det, constructed as part of some asinine Gundead school project.\n\nFires powerful lasers, but can have a hard time hitting her target.", "babygooddet_icon", assetbundle: true);
		CompanionItem val = (CompanionItem)(object)((obj is CompanionItem) ? obj : null);
		((PickupObject)val).quality = (ItemQuality)2;
		val.CompanionGuid = guid;
		BuildPrefab();
		((PickupObject)(object)val).SetupUnlockOnCustomFlag(CustomDungeonFlags.PURCHASED_BABYGOODDET, requiredFlagValue: true);
		((PickupObject)(object)val).AddItemToDougMetaShop(50, null);
	}

	public static void BuildPrefab()
	{
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_009b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0138: Unknown result type (might be due to invalid IL or missing references)
		//IL_0152: Unknown result type (might be due to invalid IL or missing references)
		//IL_0189: Unknown result type (might be due to invalid IL or missing references)
		//IL_0190: Expected O, but got Unknown
		if (!((Object)(object)prefab != (Object)null) && !CompanionBuilder.companionDictionary.ContainsKey(guid))
		{
			prefab = CompanionBuilder.BuildPrefab("Baby Good Det", guid, "NevernamedsItems/Resources/Companions/BabyGoodDet/babygooddet_idle_001", new IntVector2(5, 3), new IntVector2(9, 8));
			BabyDetBehav babyDetBehav = prefab.AddComponent<BabyDetBehav>();
			((BraveBehaviour)babyDetBehav).aiActor.MovementSpeed = 5f;
			((CompanionController)babyDetBehav).CanCrossPits = true;
			((GameActor)((BraveBehaviour)babyDetBehav).aiActor).SetIsFlying(true, "Flying Entity", false, true);
			((GameActor)((BraveBehaviour)babyDetBehav).aiActor).ActorShadowOffset = new Vector3(0f, -0.5f);
			CompanionBuilder.AddAnimation(prefab, "flight", "NevernamedsItems/Resources/Companions/BabyGoodDet/babygooddet_idle", 7, (AnimationType)1, (DirectionType)1, (FlipType)0);
			CompanionBuilder.AddAnimation(prefab, "idle", "NevernamedsItems/Resources/Companions/BabyGoodDet/babygooddet_idle", 7, (AnimationType)3, (DirectionType)1, (FlipType)0);
			CompanionBuilder.AddAnimation(prefab, "attack", "NevernamedsItems/Resources/Companions/BabyGoodDet/babygooddet_attack", 6, (AnimationType)1, (DirectionType)1, (FlipType)0);
			CompanionBuilder.AddAnimation(prefab, "contattack", "NevernamedsItems/Resources/Companions/BabyGoodDet/babygooddet_contattack", 6, (AnimationType)1, (DirectionType)1, (FlipType)0);
			((BraveBehaviour)babyDetBehav).aiAnimator.GetDirectionalAnimation("idle").Prefix = "idle";
			prefab.GetComponent<tk2dSpriteAnimator>().GetClipByName("attack").wrapMode = (WrapMode)2;
			prefab.GetComponent<tk2dSpriteAnimator>().GetClipByName("contattack").wrapMode = (WrapMode)0;
			BehaviorSpeculator component = prefab.GetComponent<BehaviorSpeculator>();
			CustomCompanionBehaviours.SimpleCompanionApproach simpleCompanionApproach = new CustomCompanionBehaviours.SimpleCompanionApproach();
			simpleCompanionApproach.DesiredDistance = 5f;
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
