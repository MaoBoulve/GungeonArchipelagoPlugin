using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Alexandria.ItemAPI;
using Alexandria.Misc;
using Dungeonator;
using UnityEngine;

namespace NevernamedsItems;

internal class OrganDonorCard : PlayerItem
{
	public class OrganDonorCardCompanionController : CompanionController
	{
		[CompilerGenerated]
		private sealed class _003CForceAttack_003Ed__1 : IEnumerator<object>, IDisposable, IEnumerator
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public OrganDonorCardCompanionController _003C_003E4__this;

			private GameObject _003Cobj_003E5__1;

			private Projectile _003Cself_003E5__2;

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
			public _003CForceAttack_003Ed__1(int _003C_003E1__state)
			{
				this._003C_003E1__state = _003C_003E1__state;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				_003Cobj_003E5__1 = null;
				_003Cself_003E5__2 = null;
				_003C_003E1__state = -2;
			}

			private bool MoveNext()
			{
				//IL_0044: Unknown result type (might be due to invalid IL or missing references)
				//IL_004e: Expected O, but got Unknown
				//IL_0088: Unknown result type (might be due to invalid IL or missing references)
				//IL_0098: Unknown result type (might be due to invalid IL or missing references)
				//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
				switch (_003C_003E1__state)
				{
				default:
					return false;
				case 0:
					_003C_003E1__state = -1;
					((BraveBehaviour)_003C_003E4__this).aiAnimator.PlayUntilFinished("attack", false, (string)null, -1f, false);
					_003C_003E2__current = (object)new WaitForSeconds(0.22f);
					_003C_003E1__state = 1;
					return true;
				case 1:
					_003C_003E1__state = -1;
					if ((Object)(object)((Component)_003C_003E4__this).gameObject != (Object)null)
					{
						_003Cobj_003E5__1 = ProjectileUtility.InstantiateAndFireTowardsPosition(heartCompanionBullet, ((BraveBehaviour)_003C_003E4__this).specRigidbody.UnitCenter, ((BraveBehaviour)MathsAndLogicHelper.GetNearestEnemyToPosition(((BraveBehaviour)_003C_003E4__this).specRigidbody.UnitCenter, true, (ActiveEnemyType)1, (List<AIActor>)null, (Func<AIActor, bool>)null)).sprite.WorldCenter, 0f, 10f, _003C_003E4__this.Owner);
						_003Cself_003E5__2 = _003Cobj_003E5__1.GetComponent<Projectile>();
						_003Cself_003E5__2.Owner = (GameActor)(object)_003C_003E4__this.Owner;
						_003Cself_003E5__2.Shooter = ((BraveBehaviour)_003C_003E4__this).specRigidbody;
						ProjectileData baseData = _003Cself_003E5__2.baseData;
						baseData.damage *= _003C_003E4__this.Owner.stats.GetStatValue((StatType)5);
						ProjectileData baseData2 = _003Cself_003E5__2.baseData;
						baseData2.speed *= _003C_003E4__this.Owner.stats.GetStatValue((StatType)6);
						ProjectileUtility.ApplyCompanionModifierToBullet(_003Cself_003E5__2, _003C_003E4__this.Owner);
						_003Cobj_003E5__1 = null;
						_003Cself_003E5__2 = null;
					}
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

		private float timer;

		public PlayerController Owner;

		private void Start()
		{
			Owner = base.m_owner;
			timer = 3f;
		}

		public IEnumerator ForceAttack()
		{
			//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
			return new _003CForceAttack_003Ed__1(0)
			{
				_003C_003E4__this = this
			};
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
				if (timer <= 0f)
				{
					((MonoBehaviour)this).StartCoroutine(ForceAttack());
					timer = 3f;
				}
			}
		}
	}

	[CompilerGenerated]
	private sealed class _003CRecalculateCompanions_003Ed__12 : IEnumerator<object>, IDisposable, IEnumerator
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public PlayerController player;

		public OrganDonorCard _003C_003E4__this;

		private int _003Ci_003E5__1;

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
		public _003CRecalculateCompanions_003Ed__12(int _003C_003E1__state)
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
			//IL_006f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0079: Expected O, but got Unknown
			switch (_003C_003E1__state)
			{
			default:
				return false;
			case 0:
				_003C_003E1__state = -1;
				_003C_003E2__current = null;
				_003C_003E1__state = 1;
				return true;
			case 1:
				_003C_003E1__state = -1;
				_003Ci_003E5__1 = 0;
				break;
			case 2:
				_003C_003E1__state = -1;
				_003Ci_003E5__1++;
				break;
			}
			if (_003Ci_003E5__1 < _003C_003E4__this.numberOfHeartBuddies)
			{
				((MonoBehaviour)_003C_003E4__this).StartCoroutine(_003C_003E4__this.SpawnNewCompanion(player));
				_003C_003E2__current = (object)new WaitForSeconds(0.1f);
				_003C_003E1__state = 2;
				return true;
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

	[CompilerGenerated]
	private sealed class _003CSpawnNewCompanion_003Ed__10 : IEnumerator<object>, IDisposable, IEnumerator
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public PlayerController user;

		public OrganDonorCard _003C_003E4__this;

		private GameObject _003CspawnedCompanion_003E5__1;

		private OrganDonorCardCompanionController _003CcompController_003E5__2;

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
		public _003CSpawnNewCompanion_003Ed__10(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			_003CspawnedCompanion_003E5__1 = null;
			_003CcompController_003E5__2 = null;
			_003C_003E1__state = -2;
		}

		private bool MoveNext()
		{
			//IL_003e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0043: Unknown result type (might be due to invalid IL or missing references)
			//IL_0048: Unknown result type (might be due to invalid IL or missing references)
			//IL_00fb: Unknown result type (might be due to invalid IL or missing references)
			switch (_003C_003E1__state)
			{
			default:
				return false;
			case 0:
				_003C_003E1__state = -1;
				_003CspawnedCompanion_003E5__1 = Object.Instantiate<GameObject>(((Component)EnemyDatabase.GetOrLoadByGuid(heartCompanionGUID)).gameObject, Vector2.op_Implicit(((BraveBehaviour)user).specRigidbody.UnitCenter), Quaternion.identity);
				_003CcompController_003E5__2 = GameObjectExtensions.GetOrAddComponent<OrganDonorCardCompanionController>(_003CspawnedCompanion_003E5__1);
				_003C_003E4__this.ExtantCompanions.Add(_003CspawnedCompanion_003E5__1);
				((CompanionController)_003CcompController_003E5__2).Initialize(user);
				if (Object.op_Implicit((Object)(object)((BraveBehaviour)_003CcompController_003E5__2).specRigidbody))
				{
					PhysicsEngine.Instance.RegisterOverlappingGhostCollisionExceptions(((BraveBehaviour)_003CcompController_003E5__2).specRigidbody, (int?)null, false);
				}
				_003C_003E2__current = null;
				_003C_003E1__state = 1;
				return true;
			case 1:
				_003C_003E1__state = -1;
				if (Object.op_Implicit((Object)(object)((BraveBehaviour)_003CcompController_003E5__2).knockbackDoer))
				{
					((BraveBehaviour)_003CcompController_003E5__2).knockbackDoer.ApplyKnockback(Random.insideUnitCircle, 50f, false);
				}
				if (Object.op_Implicit((Object)(object)((BraveBehaviour)_003CcompController_003E5__2).aiAnimator))
				{
					((BraveBehaviour)_003CcompController_003E5__2).aiAnimator.PlayUntilFinished("spawn", false, (string)null, -1f, false);
				}
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

	public static GameObject heartCompanionPrefab;

	public static Projectile heartCompanionBullet;

	public static string heartCompanionGUID = "omitb_organdonorcard_heartcompanion";

	public int numberOfHeartBuddies;

	private List<GameObject> ExtantCompanions;

	public static void Init()
	{
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		PickupObject obj = ItemSetup.NewItem<OrganDonorCard>("Organ Donor Card", "Gift of Life", "Donate your hearts to someone who needs them.\n\nCompensates you handsomely- You might even make a new friend! (The hole left in your  body is also a nifty place to store active items)\n\nNot reccomended for use by perverted Turtles.", "organdonorcard_icon", assetbundle: true);
		PlayerItem val = (PlayerItem)(object)((obj is PlayerItem) ? obj : null);
		ItemBuilder.SetCooldownType(val, (CooldownType)0, 5f);
		ItemBuilder.AddPassiveStatModifier((PickupObject)(object)val, (StatType)8, 1f, (ModifyMethod)0);
		val.consumable = false;
		((PickupObject)val).quality = (ItemQuality)1;
		heartCompanionBullet = ProjectileUtility.SetupProjectile(56);
		heartCompanionBullet.baseData.damage = 20f;
		heartCompanionBullet.pierceMinorBreakables = true;
		ProjectileData baseData = heartCompanionBullet.baseData;
		baseData.range *= 10f;
		heartCompanionBullet.SetProjectileSprite("viscerifle_heart_projectile", 16, 7, lightened: false, (Anchor)4, 16, 7, anchorChangesCollider: true, fixesScale: false, null, null);
		GoopModifier val2 = ((Component)heartCompanionBullet).gameObject.AddComponent<GoopModifier>();
		val2.goopDefinition = EasyGoopDefinitions.BlobulonGoopDef;
		val2.SpawnGoopInFlight = true;
		val2.InFlightSpawnFrequency = 0.05f;
		val2.InFlightSpawnRadius = 1f;
		val2.SpawnGoopOnCollision = true;
		val2.CollisionSpawnRadius = 2f;
		BuildPrefab();
	}

	public override void Pickup(PlayerController player)
	{
		if (ExtantCompanions == null)
		{
			ExtantCompanions = new List<GameObject>();
		}
		if (!base.m_pickedUpThisRun)
		{
			numberOfHeartBuddies = 0;
		}
		((MonoBehaviour)this).StartCoroutine(RecalculateCompanions(player));
		GameManager.Instance.OnNewLevelFullyLoaded += OnNewFloor;
		((PlayerItem)this).Pickup(player);
	}

	public override void OnPreDrop(PlayerController user)
	{
		DestroyAllCompanions();
		GameManager.Instance.OnNewLevelFullyLoaded -= OnNewFloor;
		((PlayerItem)this).OnPreDrop(user);
	}

	public override void OnDestroy()
	{
		DestroyAllCompanions();
		GameManager.Instance.OnNewLevelFullyLoaded -= OnNewFloor;
		((PlayerItem)this).OnDestroy();
	}

	private void OnNewFloor()
	{
		if (Object.op_Implicit((Object)(object)base.LastOwner))
		{
			((MonoBehaviour)this).StartCoroutine(RecalculateCompanions(base.LastOwner));
		}
	}

	public IEnumerator SpawnNewCompanion(PlayerController user)
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CSpawnNewCompanion_003Ed__10(0)
		{
			_003C_003E4__this = this,
			user = user
		};
	}

	public void DestroyAllCompanions()
	{
		if (ExtantCompanions.Count <= 0)
		{
			return;
		}
		for (int num = ExtantCompanions.Count - 1; num >= 0; num--)
		{
			if (Object.op_Implicit((Object)(object)ExtantCompanions[num]) && Object.op_Implicit((Object)(object)ExtantCompanions[num].gameObject))
			{
				Object.Destroy((Object)(object)ExtantCompanions[num].gameObject);
			}
		}
		ExtantCompanions.Clear();
	}

	public IEnumerator RecalculateCompanions(PlayerController player)
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CRecalculateCompanions_003Ed__12(0)
		{
			_003C_003E4__this = this,
			player = player
		};
	}

	public override void DoEffect(PlayerController user)
	{
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00be: Expected O, but got Unknown
		//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00df: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Expected O, but got Unknown
		int num = 20;
		if (CustomSynergies.PlayerHasActiveSynergy(base.LastOwner, "Heart so wet and cold..."))
		{
			num *= 2;
		}
		if (CustomSynergies.PlayerHasActiveSynergy(base.LastOwner, "Do-Gooder"))
		{
			num *= 2;
		}
		LootEngine.SpawnCurrency(((BraveBehaviour)user).specRigidbody.UnitCenter, num, false);
		SpawnManager.SpawnVFX(SharedVFX.BloodExplosion, Vector2.op_Implicit(((BraveBehaviour)user).specRigidbody.UnitCenter), Quaternion.identity);
		PlayableCharacters characterIdentity = user.characterIdentity;
		if (user.ForceZeroHealthState)
		{
			((BraveBehaviour)user).healthHaver.Armor = ((BraveBehaviour)user).healthHaver.Armor - 2f;
		}
		else
		{
			StatModifier item = new StatModifier
			{
				amount = -1f,
				statToBoost = (StatType)3,
				modifyType = (ModifyMethod)0
			};
			user.ownerlessStatModifiers.Add(item);
		}
		StatModifier item2 = new StatModifier
		{
			amount = 1f,
			statToBoost = (StatType)8,
			modifyType = (ModifyMethod)0
		};
		user.ownerlessStatModifiers.Add(item2);
		user.stats.RecalculateStats(user, false, false);
		((MonoBehaviour)this).StartCoroutine(SpawnNewCompanion(user));
		numberOfHeartBuddies++;
	}

	public override bool CanBeUsed(PlayerController user)
	{
		if (user.ForceZeroHealthState)
		{
			return ((BraveBehaviour)user).healthHaver.Armor > 2f;
		}
		return ((BraveBehaviour)user).healthHaver.GetMaxHealth() > 1f;
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
		//IL_02e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e9: Expected O, but got Unknown
		if (!((Object)(object)heartCompanionPrefab != (Object)null) && !CompanionBuilder.companionDictionary.ContainsKey(heartCompanionGUID))
		{
			heartCompanionPrefab = CompanionBuilder.BuildPrefab("OrganDonor HeartBud", heartCompanionGUID, "NevernamedsItems/Resources/Companions/OrganDonorCompanions/organdonorcompanion_idlesouth_001", new IntVector2(8, 2), new IntVector2(5, 5));
			OrganDonorCardCompanionController organDonorCardCompanionController = heartCompanionPrefab.AddComponent<OrganDonorCardCompanionController>();
			((BraveBehaviour)organDonorCardCompanionController).aiActor.MovementSpeed = 6f;
			AIAnimator orAddComponent = GameObjectExtensions.GetOrAddComponent<AIAnimator>(heartCompanionPrefab);
			orAddComponent.AdvAddAnimation("idle", (DirectionType)9, (AnimationType)1, new List<AnimationUtilityExtensions.DirectionalAnimationData>
			{
				new AnimationUtilityExtensions.DirectionalAnimationData
				{
					subAnimationName = "idle_north",
					wrapMode = (WrapMode)0,
					fps = 9,
					pathDirectory = "NevernamedsItems/Resources/Companions/OrganDonorCompanions/organdonorcompanion_idlenorth"
				},
				new AnimationUtilityExtensions.DirectionalAnimationData
				{
					subAnimationName = "idle_east",
					wrapMode = (WrapMode)0,
					fps = 9,
					pathDirectory = "NevernamedsItems/Resources/Companions/OrganDonorCompanions/organdonorcompanion_idleeast"
				},
				new AnimationUtilityExtensions.DirectionalAnimationData
				{
					subAnimationName = "idle_south",
					wrapMode = (WrapMode)0,
					fps = 9,
					pathDirectory = "NevernamedsItems/Resources/Companions/OrganDonorCompanions/organdonorcompanion_idlesouth"
				},
				new AnimationUtilityExtensions.DirectionalAnimationData
				{
					subAnimationName = "idle_west",
					wrapMode = (WrapMode)0,
					fps = 9,
					pathDirectory = "NevernamedsItems/Resources/Companions/OrganDonorCompanions/organdonorcompanion_idlewest"
				}
			});
			orAddComponent.AdvAddAnimation("move", (DirectionType)9, (AnimationType)0, new List<AnimationUtilityExtensions.DirectionalAnimationData>
			{
				new AnimationUtilityExtensions.DirectionalAnimationData
				{
					subAnimationName = "move_north",
					wrapMode = (WrapMode)0,
					fps = 9,
					pathDirectory = "NevernamedsItems/Resources/Companions/OrganDonorCompanions/organdonorcompanion_movenorth"
				},
				new AnimationUtilityExtensions.DirectionalAnimationData
				{
					subAnimationName = "move_east",
					wrapMode = (WrapMode)0,
					fps = 9,
					pathDirectory = "NevernamedsItems/Resources/Companions/OrganDonorCompanions/organdonorcompanion_moveeast"
				},
				new AnimationUtilityExtensions.DirectionalAnimationData
				{
					subAnimationName = "move_south",
					wrapMode = (WrapMode)0,
					fps = 9,
					pathDirectory = "NevernamedsItems/Resources/Companions/OrganDonorCompanions/organdonorcompanion_movesouth"
				},
				new AnimationUtilityExtensions.DirectionalAnimationData
				{
					subAnimationName = "move_west",
					wrapMode = (WrapMode)0,
					fps = 9,
					pathDirectory = "NevernamedsItems/Resources/Companions/OrganDonorCompanions/organdonorcompanion_movewest"
				}
			});
			orAddComponent.AdvAddAnimation("spawn", (DirectionType)1, (AnimationType)6, new List<AnimationUtilityExtensions.DirectionalAnimationData>
			{
				new AnimationUtilityExtensions.DirectionalAnimationData
				{
					subAnimationName = "spawn",
					wrapMode = (WrapMode)2,
					fps = 9,
					pathDirectory = "NevernamedsItems/Resources/Companions/OrganDonorCompanions/organdonorcompanion_spawn"
				}
			});
			orAddComponent.AdvAddAnimation("attack", (DirectionType)1, (AnimationType)6, new List<AnimationUtilityExtensions.DirectionalAnimationData>
			{
				new AnimationUtilityExtensions.DirectionalAnimationData
				{
					subAnimationName = "attack",
					wrapMode = (WrapMode)2,
					fps = 9,
					pathDirectory = "NevernamedsItems/Resources/Companions/OrganDonorCompanions/organdonorcompanion_attack"
				}
			});
			BehaviorSpeculator component = heartCompanionPrefab.GetComponent<BehaviorSpeculator>();
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
			val.PathInterval = 0.1f;
			movementBehaviors.Add((MovementBehaviorBase)(object)val);
		}
	}
}
