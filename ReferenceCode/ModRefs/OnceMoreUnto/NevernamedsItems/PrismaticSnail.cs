using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Alexandria.ItemAPI;
using Alexandria.Misc;
using UnityEngine;

namespace NevernamedsItems;

public class PrismaticSnail
{
	public class PrismaticSnailController : CompanionController
	{
		[CompilerGenerated]
		private sealed class _003CAttack_003Ed__3 : IEnumerator<object>, IDisposable, IEnumerator
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public PrismaticSnailController _003C_003E4__this;

			private float _003Camt_003E5__1;

			private int _003Ci_003E5__2;

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
			public _003CAttack_003Ed__3(int _003C_003E1__state)
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
				//IL_00f0: Unknown result type (might be due to invalid IL or missing references)
				//IL_00fa: Expected O, but got Unknown
				switch (_003C_003E1__state)
				{
				default:
					return false;
				case 0:
					_003C_003E1__state = -1;
					_003C_003E4__this.attacking = true;
					((BraveBehaviour)_003C_003E4__this).aiActor.MovementSpeed = 0f;
					_003Camt_003E5__1 = 360f;
					if (Random.value <= 0.5f)
					{
						_003Camt_003E5__1 = -360f;
					}
					_003Ci_003E5__2 = 0;
					while (_003Ci_003E5__2 < 8)
					{
						((MonoBehaviour)_003C_003E4__this).StartCoroutine(_003C_003E4__this.BeamLerp(_003Ci_003E5__2 * 45, (float)(_003Ci_003E5__2 * 45) + _003Camt_003E5__1));
						_003Ci_003E5__2++;
					}
					((BraveBehaviour)_003C_003E4__this).aiAnimator.PlayForDuration("attack", 5f, false, (string)null, -1f, false);
					_003C_003E2__current = (object)new WaitForSeconds(5f);
					_003C_003E1__state = 1;
					return true;
				case 1:
					_003C_003E1__state = -1;
					((BraveBehaviour)_003C_003E4__this).aiActor.MovementSpeed = 4f;
					_003C_003E4__this.timerRemaining = 7f;
					_003C_003E4__this.attacking = false;
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
		private sealed class _003CBeamLerp_003Ed__4 : IEnumerator<object>, IDisposable, IEnumerator
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public float startAngle;

			public float endAngle;

			public PrismaticSnailController _003C_003E4__this;

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
			public _003CBeamLerp_003Ed__4(int _003C_003E1__state)
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
				//IL_004f: Unknown result type (might be due to invalid IL or missing references)
				//IL_01fd: Unknown result type (might be due to invalid IL or missing references)
				switch (_003C_003E1__state)
				{
				default:
					return false;
				case 0:
				{
					_003C_003E1__state = -1;
					_003Celapsed_003E5__1 = 0f;
					_003Cbeam_003E5__2 = BeamAPI.FreeFireBeamFromAnywhere(prismBeam.GetComponent<Projectile>(), ((CompanionController)_003C_003E4__this).m_owner, ((Component)_003C_003E4__this).gameObject, Vector2.zero, startAngle, 5f, true, false, 0f);
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
				while (_003Celapsed_003E5__1 <= 5f)
				{
					if (Object.op_Implicit((Object)(object)_003Cbeam_003E5__2))
					{
						_003CfinalAngle_003E5__4 = Mathf.Lerp(startAngle, endAngle, _003Celapsed_003E5__1 / 5f);
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

		private bool attacking;

		private float timerRemaining;

		private PlayerController Owner;

		private void Start()
		{
			Owner = base.m_owner;
			timerRemaining = 7f;
			attacking = false;
		}

		public override void Update()
		{
			//IL_0021: Unknown result type (might be due to invalid IL or missing references)
			//IL_0040: Unknown result type (might be due to invalid IL or missing references)
			if (Object.op_Implicit((Object)(object)Owner) && Owner.IsInCombat && Vector3Extensions.GetAbsoluteRoom(((BraveBehaviour)this).aiActor.Position) != null && Owner.CurrentRoom != null && Vector3Extensions.GetAbsoluteRoom(((BraveBehaviour)this).aiActor.Position) == Owner.CurrentRoom)
			{
				if (timerRemaining > 0f)
				{
					timerRemaining -= BraveTime.DeltaTime;
				}
				else if (!attacking)
				{
					((MonoBehaviour)this).StartCoroutine(Attack());
				}
			}
			((CompanionController)this).Update();
		}

		private IEnumerator Attack()
		{
			//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
			return new _003CAttack_003Ed__3(0)
			{
				_003C_003E4__this = this
			};
		}

		private IEnumerator BeamLerp(float startAngle, float endAngle)
		{
			//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
			return new _003CBeamLerp_003Ed__4(0)
			{
				_003C_003E4__this = this,
				startAngle = startAngle,
				endAngle = endAngle
			};
		}
	}

	public static GameObject prismBeam;

	public static GameObject prefab;

	private static readonly string guid = "omitb_prismaticsnail_companion";

	public static void Init()
	{
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0157: Unknown result type (might be due to invalid IL or missing references)
		//IL_016b: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ed: Unknown result type (might be due to invalid IL or missing references)
		PickupObject obj = ItemSetup.NewItem<CompanionItem>("Prismatic Snail", "27616", "A curious mollusc in a crystal shell. When you put your ear to the opening, you can hear it frantically reciting the same string of numbers over and over again...", "prismaticsnail_icon", assetbundle: true);
		CompanionItem val = (CompanionItem)(object)((obj is CompanionItem) ? obj : null);
		((PickupObject)val).quality = (ItemQuality)3;
		val.CompanionGuid = guid;
		BuildPrefab();
		PickupObject byId = PickupObjectDatabase.GetById(86);
		Projectile val2 = ProjectileUtility.InstantiateAndFakeprefab(((Gun)((byId is Gun) ? byId : null)).DefaultModule.projectiles[0]);
		BasicBeamController val3 = BeamAPI.GenerateBeamPrefab(val2, "NevernamedsItems/Resources/BeamSprites/pocolocobeam_mid_001", new Vector2(4f, 4f), new Vector2(0f, 0f), new List<string>
		{
			"NevernamedsItems/Resources/BeamSprites/pocolocobeam_mid_001", "NevernamedsItems/Resources/BeamSprites/pocolocobeam_mid_002", "NevernamedsItems/Resources/BeamSprites/pocolocobeam_mid_003", "NevernamedsItems/Resources/BeamSprites/pocolocobeam_mid_004", "NevernamedsItems/Resources/BeamSprites/pocolocobeam_mid_005", "NevernamedsItems/Resources/BeamSprites/pocolocobeam_mid_006", "NevernamedsItems/Resources/BeamSprites/pocolocobeam_mid_007", "NevernamedsItems/Resources/BeamSprites/pocolocobeam_mid_008", "NevernamedsItems/Resources/BeamSprites/pocolocobeam_mid_009", "NevernamedsItems/Resources/BeamSprites/pocolocobeam_mid_010",
			"NevernamedsItems/Resources/BeamSprites/pocolocobeam_mid_011", "NevernamedsItems/Resources/BeamSprites/pocolocobeam_mid_012"
		}, 13, new List<string> { "NevernamedsItems/Resources/BeamSprites/yellowbeam_impact_001", "NevernamedsItems/Resources/BeamSprites/yellowbeam_impact_002", "NevernamedsItems/Resources/BeamSprites/yellowbeam_impact_003", "NevernamedsItems/Resources/BeamSprites/yellowbeam_impact_004" }, 13, (Vector2?)new Vector2(4f, 4f), (Vector2?)new Vector2(7f, 7f), (List<string>)null, -1, (Vector2?)null, (Vector2?)null, (List<string>)null, -1, (Vector2?)null, (Vector2?)null, 10f, 0f);
		val2.baseData.damage = 5f;
		ProjectileData baseData = val2.baseData;
		baseData.force *= 1f;
		ProjectileData baseData2 = val2.baseData;
		baseData2.range *= 200f;
		val3.boneType = (BeamBoneType)0;
		val3.startAudioEvent = "Play_WPN_radiationlaser_shot_01";
		val3.endAudioEvent = "Stop_WPN_All";
		prismBeam = ((Component)val2).gameObject;
	}

	public static void BuildPrefab()
	{
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_010e: Unknown result type (might be due to invalid IL or missing references)
		//IL_013f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0183: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0208: Unknown result type (might be due to invalid IL or missing references)
		//IL_020f: Expected O, but got Unknown
		if (!((Object)(object)prefab != (Object)null) && !CompanionBuilder.companionDictionary.ContainsKey(guid))
		{
			prefab = CompanionBuilder.BuildPrefab("PrismaticSnail", guid, "NevernamedsItems/Resources/Companions/PrismaticSnail/prismatismsnail_idleleft_001", new IntVector2(7, 1), new IntVector2(11, 8));
			PrismaticSnailController prismaticSnailController = prefab.AddComponent<PrismaticSnailController>();
			((BraveBehaviour)prismaticSnailController).aiActor.MovementSpeed = 4f;
			AIAnimator orAddComponent = GameObjectExtensions.GetOrAddComponent<AIAnimator>(prefab);
			orAddComponent.AdvAddAnimation("idle", (DirectionType)2, (AnimationType)1, new List<AnimationUtilityExtensions.DirectionalAnimationData>
			{
				new AnimationUtilityExtensions.DirectionalAnimationData
				{
					subAnimationName = "idle_right",
					wrapMode = (WrapMode)0,
					fps = 9,
					pathDirectory = "NevernamedsItems/Resources/Companions/PrismaticSnail/prismatismsnail_idleright"
				},
				new AnimationUtilityExtensions.DirectionalAnimationData
				{
					subAnimationName = "idle_left",
					wrapMode = (WrapMode)0,
					fps = 9,
					pathDirectory = "NevernamedsItems/Resources/Companions/PrismaticSnail/prismatismsnail_idleleft"
				}
			});
			orAddComponent.AdvAddAnimation("move", (DirectionType)2, (AnimationType)0, new List<AnimationUtilityExtensions.DirectionalAnimationData>
			{
				new AnimationUtilityExtensions.DirectionalAnimationData
				{
					subAnimationName = "move_right",
					wrapMode = (WrapMode)0,
					fps = 9,
					pathDirectory = "NevernamedsItems/Resources/Companions/PrismaticSnail/prismatismsnail_moveright"
				},
				new AnimationUtilityExtensions.DirectionalAnimationData
				{
					subAnimationName = "move_left",
					wrapMode = (WrapMode)0,
					fps = 9,
					pathDirectory = "NevernamedsItems/Resources/Companions/PrismaticSnail/prismatismsnail_moveleft"
				}
			});
			orAddComponent.AdvAddAnimation("attack", (DirectionType)2, (AnimationType)6, new List<AnimationUtilityExtensions.DirectionalAnimationData>
			{
				new AnimationUtilityExtensions.DirectionalAnimationData
				{
					subAnimationName = "attack_right",
					wrapMode = (WrapMode)0,
					fps = 1,
					pathDirectory = "NevernamedsItems/Resources/Companions/PrismaticSnail/prismatismsnail_attackright"
				},
				new AnimationUtilityExtensions.DirectionalAnimationData
				{
					subAnimationName = "attack_left",
					wrapMode = (WrapMode)0,
					fps = 1,
					pathDirectory = "NevernamedsItems/Resources/Companions/PrismaticSnail/prismatismsnail_attackleft"
				}
			});
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
