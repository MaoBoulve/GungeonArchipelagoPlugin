using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Alexandria.ItemAPI;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class Diode : PassiveItem
{
	public class DiodeCompanionBehaviour : CompanionController
	{
		[CompilerGenerated]
		private sealed class _003CHandleDamageCooldown_003Ed__7 : IEnumerator<object>, IDisposable, IEnumerator
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public AIActor damagedTarget;

			public DiodeCompanionBehaviour _003C_003E4__this;

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
			public _003CHandleDamageCooldown_003Ed__7(int _003C_003E1__state)
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
				//IL_003d: Unknown result type (might be due to invalid IL or missing references)
				//IL_0047: Expected O, but got Unknown
				switch (_003C_003E1__state)
				{
				default:
					return false;
				case 0:
					_003C_003E1__state = -1;
					_003C_003E4__this.m_damagedEnemies.Add(damagedTarget);
					_003C_003E2__current = (object)new WaitForSeconds(0.25f);
					_003C_003E1__state = 1;
					return true;
				case 1:
					_003C_003E1__state = -1;
					_003C_003E4__this.m_damagedEnemies.Remove(damagedTarget);
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

		public float DamagePerHit;

		private tk2dTiledSprite extantLink;

		private GameObject LinkVFXPrefab;

		private PlayerController Owner;

		private HashSet<AIActor> m_damagedEnemies = new HashSet<AIActor>();

		public DiodeCompanionBehaviour()
		{
			DamagePerHit = 3.5f;
		}

		public override void OnDestroy()
		{
			if ((Object)(object)extantLink != (Object)null)
			{
				SpawnManager.Despawn(((Component)extantLink).gameObject);
				extantLink = null;
			}
			((CompanionController)this).OnDestroy();
		}

		private void Start()
		{
			Owner = base.m_owner;
			LinkVFXPrefab = FakePrefab.Clone(((Component)Game.Items["shock_rounds"]).GetComponent<ComplexProjectileModifier>().ChainLightningVFX);
		}

		private void FixedUpdate()
		{
		}

		public override void Update()
		{
			if ((Object)(object)LinkVFXPrefab == (Object)null)
			{
				LinkVFXPrefab = FakePrefab.Clone(((Component)Game.Items["shock_rounds"]).GetComponent<ComplexProjectileModifier>().ChainLightningVFX);
			}
			if (Object.op_Implicit((Object)(object)Owner) && Owner.IsInCombat && (Object)(object)extantLink == (Object)null)
			{
				tk2dTiledSprite component = SpawnManager.SpawnVFX(LinkVFXPrefab, false).GetComponent<tk2dTiledSprite>();
				extantLink = component;
			}
			else if (Object.op_Implicit((Object)(object)Owner) && Owner.IsInCombat && (Object)(object)extantLink != (Object)null)
			{
				UpdateLink(Owner, extantLink);
			}
			else if ((Object)(object)extantLink != (Object)null)
			{
				SpawnManager.Despawn(((Component)extantLink).gameObject);
				extantLink = null;
			}
			((CompanionController)this).Update();
		}

		private void UpdateLink(PlayerController target, tk2dTiledSprite m_extantLink)
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0018: Unknown result type (might be due to invalid IL or missing references)
			//IL_001d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0024: Unknown result type (might be due to invalid IL or missing references)
			//IL_0025: Unknown result type (might be due to invalid IL or missing references)
			//IL_0030: Unknown result type (might be due to invalid IL or missing references)
			//IL_0031: Unknown result type (might be due to invalid IL or missing references)
			//IL_0032: Unknown result type (might be due to invalid IL or missing references)
			//IL_0037: Unknown result type (might be due to invalid IL or missing references)
			//IL_003a: Unknown result type (might be due to invalid IL or missing references)
			//IL_005e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0068: Unknown result type (might be due to invalid IL or missing references)
			//IL_0084: Unknown result type (might be due to invalid IL or missing references)
			//IL_0097: Unknown result type (might be due to invalid IL or missing references)
			//IL_0098: Unknown result type (might be due to invalid IL or missing references)
			Vector2 unitCenter = ((BraveBehaviour)this).specRigidbody.UnitCenter;
			Vector2 unitCenter2 = ((BraveBehaviour)target).specRigidbody.HitboxPixelCollider.UnitCenter;
			((BraveBehaviour)m_extantLink).transform.position = Vector2.op_Implicit(unitCenter);
			Vector2 val = unitCenter2 - unitCenter;
			float num = BraveMathCollege.Atan2Degrees(((Vector2)(ref val)).normalized);
			int num2 = Mathf.RoundToInt(((Vector2)(ref val)).magnitude / 0.0625f);
			m_extantLink.dimensions = new Vector2((float)num2, m_extantLink.dimensions.y);
			((BraveBehaviour)m_extantLink).transform.rotation = Quaternion.Euler(0f, 0f, num);
			((tk2dBaseSprite)m_extantLink).UpdateZDepth();
			ApplyLinearDamage(unitCenter, unitCenter2);
		}

		private void ApplyLinearDamage(Vector2 p1, Vector2 p2)
		{
			//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
			//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cf: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00fb: Unknown result type (might be due to invalid IL or missing references)
			float num = DamagePerHit;
			if (PassiveItem.IsFlagSetForCharacter(Owner, typeof(BattleStandardItem)))
			{
				num *= BattleStandardItem.BattleStandardCompanionDamageMultiplier;
			}
			if (Object.op_Implicit((Object)(object)((GameActor)Owner).CurrentGun) && ((GameActor)Owner).CurrentGun.LuteCompanionBuffActive)
			{
				num *= 2f;
			}
			for (int i = 0; i < StaticReferenceManager.AllEnemies.Count; i++)
			{
				AIActor val = StaticReferenceManager.AllEnemies[i];
				if (!m_damagedEnemies.Contains(val) && Object.op_Implicit((Object)(object)val) && val.HasBeenEngaged && val.IsNormalEnemy && Object.op_Implicit((Object)(object)((BraveBehaviour)val).specRigidbody))
				{
					Vector2 zero = Vector2.zero;
					if (BraveUtility.LineIntersectsAABB(p1, p2, ((BraveBehaviour)val).specRigidbody.HitboxPixelCollider.UnitBottomLeft, ((BraveBehaviour)val).specRigidbody.HitboxPixelCollider.UnitDimensions, ref zero))
					{
						((BraveBehaviour)val).healthHaver.ApplyDamage(num, Vector2.zero, "Chain Lightning", (CoreDamageTypes)64, (DamageCategory)0, false, (PixelCollider)null, false);
						((MonoBehaviour)GameManager.Instance).StartCoroutine(HandleDamageCooldown(val));
					}
				}
			}
		}

		private IEnumerator HandleDamageCooldown(AIActor damagedTarget)
		{
			//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
			return new _003CHandleDamageCooldown_003Ed__7(0)
			{
				_003C_003E4__this = this,
				damagedTarget = damagedTarget
			};
		}
	}

	public static GameObject prefab;

	private static readonly string guid = "diode_3032943893489384394893";

	public static void Init()
	{
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		PickupObject obj = ItemSetup.NewItem<CompanionItem>("Diode", "Electric Buddy", "This little guy connects to you via an electric arc.\n\nOne of the first creations of a young tinker, it wandered out of her workshop in search of adventure, and somehow wound up down here.", "diode_icon", assetbundle: true);
		CompanionItem val = (CompanionItem)(object)((obj is CompanionItem) ? obj : null);
		((PickupObject)val).quality = (ItemQuality)2;
		val.CompanionGuid = guid;
		BuildPrefab();
	}

	public static void BuildPrefab()
	{
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_012e: Unknown result type (might be due to invalid IL or missing references)
		//IL_015b: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ef: Expected O, but got Unknown
		if (!((Object)(object)prefab != (Object)null) && !CompanionBuilder.companionDictionary.ContainsKey(guid))
		{
			prefab = CompanionBuilder.BuildPrefab("Diode Companion", guid, "NevernamedsItems/Resources/Companions/Diode/diode_idle_001", new IntVector2(4, 0), new IntVector2(8, 8));
			DiodeCompanionBehaviour diodeCompanionBehaviour = prefab.AddComponent<DiodeCompanionBehaviour>();
			AIAnimator orAddComponent = GameObjectExtensions.GetOrAddComponent<AIAnimator>(prefab);
			orAddComponent.AdvAddAnimation("idle", (DirectionType)2, (AnimationType)1, new List<AnimationUtilityExtensions.DirectionalAnimationData>
			{
				new AnimationUtilityExtensions.DirectionalAnimationData
				{
					subAnimationName = "idle_right",
					wrapMode = (WrapMode)0,
					fps = 7,
					pathDirectory = "NevernamedsItems/Resources/Companions/Diode/diode_idle"
				},
				new AnimationUtilityExtensions.DirectionalAnimationData
				{
					subAnimationName = "idle_left",
					wrapMode = (WrapMode)0,
					fps = 7,
					pathDirectory = "NevernamedsItems/Resources/Companions/Diode/diode_idle"
				}
			});
			orAddComponent.AdvAddAnimation("move", (DirectionType)2, (AnimationType)0, new List<AnimationUtilityExtensions.DirectionalAnimationData>
			{
				new AnimationUtilityExtensions.DirectionalAnimationData
				{
					subAnimationName = "move_right",
					wrapMode = (WrapMode)0,
					fps = 12,
					pathDirectory = "NevernamedsItems/Resources/Companions/Diode/diode_moveright"
				},
				new AnimationUtilityExtensions.DirectionalAnimationData
				{
					subAnimationName = "move_left",
					wrapMode = (WrapMode)0,
					fps = 12,
					pathDirectory = "NevernamedsItems/Resources/Companions/Diode/diode_moveleft"
				}
			});
			((CompanionController)diodeCompanionBehaviour).CanInterceptBullets = false;
			((CompanionController)diodeCompanionBehaviour).companionID = (CompanionIdentifier)0;
			((BraveBehaviour)diodeCompanionBehaviour).aiActor.MovementSpeed = 7f;
			((BraveBehaviour)((BraveBehaviour)diodeCompanionBehaviour).aiActor).healthHaver.PreventAllDamage = true;
			((BraveBehaviour)diodeCompanionBehaviour).aiActor.CollisionDamage = 0f;
			((BraveBehaviour)((BraveBehaviour)diodeCompanionBehaviour).aiActor).specRigidbody.CollideWithOthers = false;
			((BraveBehaviour)((BraveBehaviour)diodeCompanionBehaviour).aiActor).specRigidbody.CollideWithTileMap = false;
			BehaviorSpeculator component = prefab.GetComponent<BehaviorSpeculator>();
			CustomCompanionBehaviours.SimpleCompanionApproach simpleCompanionApproach = new CustomCompanionBehaviours.SimpleCompanionApproach();
			simpleCompanionApproach.DesiredDistance = 2f;
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
