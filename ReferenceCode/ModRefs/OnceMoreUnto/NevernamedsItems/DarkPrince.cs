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

public class DarkPrince : PassiveItem
{
	public class DebuffedByDarkPrince : MonoBehaviour
	{
	}

	public class DarkPrinceController : CompanionController
	{
		[CompilerGenerated]
		private sealed class _003CAttack_003Ed__2 : IEnumerator<object>, IDisposable, IEnumerator
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public Vector2 pointOnTarget;

			public DarkPrinceController _003C_003E4__this;

			private GameObject _003Cprojobj_003E5__1;

			private Projectile _003Cproj_003E5__2;

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
				_003Cprojobj_003E5__1 = null;
				_003Cproj_003E5__2 = null;
				_003C_003E1__state = -2;
			}

			private bool MoveNext()
			{
				//IL_0073: Unknown result type (might be due to invalid IL or missing references)
				//IL_007d: Expected O, but got Unknown
				//IL_00b4: Unknown result type (might be due to invalid IL or missing references)
				//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
				//IL_0246: Unknown result type (might be due to invalid IL or missing references)
				//IL_0250: Expected O, but got Unknown
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
					AkSoundEngine.PostEvent("Play_ENM_wizardred_shoot_01", ((Component)_003C_003E4__this).gameObject);
					_003Cprojobj_003E5__1 = ProjSpawnHelper.SpawnProjectileTowardsPoint(DarkPrinceProjectile, ((BraveBehaviour)_003C_003E4__this).sprite.WorldCenter, pointOnTarget);
					_003Cproj_003E5__2 = _003Cprojobj_003E5__1.GetComponent<Projectile>();
					if (Object.op_Implicit((Object)(object)_003Cproj_003E5__2))
					{
						_003Cproj_003E5__2.Owner = (GameActor)(object)_003C_003E4__this.Owner;
						_003Cproj_003E5__2.Shooter = ((BraveBehaviour)_003C_003E4__this).specRigidbody;
						ProjectileData baseData = _003Cproj_003E5__2.baseData;
						baseData.damage *= _003C_003E4__this.Owner.stats.GetStatValue((StatType)5);
						ProjectileData baseData2 = _003Cproj_003E5__2.baseData;
						baseData2.speed *= _003C_003E4__this.Owner.stats.GetStatValue((StatType)6);
						ProjectileData baseData3 = _003Cproj_003E5__2.baseData;
						baseData3.range *= _003C_003E4__this.Owner.stats.GetStatValue((StatType)26);
						ProjectileData baseData4 = _003Cproj_003E5__2.baseData;
						baseData4.force *= _003C_003E4__this.Owner.stats.GetStatValue((StatType)12);
						Projectile obj = _003Cproj_003E5__2;
						obj.BossDamageMultiplier *= _003C_003E4__this.Owner.stats.GetStatValue((StatType)22);
						_003Cproj_003E5__2.UpdateSpeed();
						ProjectileUtility.ApplyCompanionModifierToBullet(_003Cproj_003E5__2, _003C_003E4__this.Owner);
						_003C_003E4__this.Owner.DoPostProcessProjectile(_003Cproj_003E5__2);
					}
					_003C_003E2__current = (object)new WaitForSeconds(0.1f);
					_003C_003E1__state = 2;
					return true;
				case 2:
					_003C_003E1__state = -1;
					((BraveBehaviour)_003C_003E4__this).aiActor.MovementSpeed = ((BraveBehaviour)_003C_003E4__this).aiActor.BaseMovementSpeed;
					_003C_003E4__this.isAttacking = false;
					_003C_003E4__this.attackTimer = 2f;
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
			//IL_0065: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00dc: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e5: Unknown result type (might be due to invalid IL or missing references)
			//IL_0108: Unknown result type (might be due to invalid IL or missing references)
			if (Object.op_Implicit((Object)(object)((BraveBehaviour)this).aiActor.OverrideTarget) && (Object)(object)((Component)((BraveBehaviour)this).aiActor.OverrideTarget).GetComponent<DebuffedByDarkPrince>() != (Object)null)
			{
				((BraveBehaviour)this).aiActor.OverrideTarget = null;
			}
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
	}

	public static GameObject DarkPrinceProjectile;

	public static GameObject prefab;

	private static readonly string guid = "darkprincei98qy7wiyf4ugwu6sudtsfu6sdf";

	public static void Init()
	{
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_0161: Unknown result type (might be due to invalid IL or missing references)
		//IL_0170: Unknown result type (might be due to invalid IL or missing references)
		PickupObject obj = ItemSetup.NewItem<CompanionItem>("Dark Prince", "Wicked Heir", "This young Gunjurer is the unlikely heir to a vast magical empire, operating from beyond the curtain... he is also very impressionable, with his dark magics able to be put to fantastic use.", "darkprince_icon", assetbundle: true);
		CompanionItem val = (CompanionItem)(object)((obj is CompanionItem) ? obj : null);
		((PickupObject)val).quality = (ItemQuality)5;
		val.CompanionGuid = guid;
		BuildPrefab();
		ItemBuilder.AddToSubShop((PickupObject)(object)val, (ShopType)2, 1f);
		PickupObject byId = PickupObjectDatabase.GetById(56);
		DarkPrinceProjectile = FakePrefabExtensions.InstantiateAndFakeprefab(((Component)((Gun)((byId is Gun) ? byId : null)).DefaultModule.projectiles[0]).gameObject);
		Projectile component = DarkPrinceProjectile.GetComponent<Projectile>();
		component.baseData.damage = 1f;
		component.baseData.speed = 100f;
		component.SetProjectileSprite("laserwelder_proj", 10, 3, lightened: true, (Anchor)4, 10, 3, anchorChangesCollider: true, fixesScale: false, null, null);
		ProjWeaknessModifier projWeaknessModifier = ((Component)component).gameObject.AddComponent<ProjWeaknessModifier>();
		projWeaknessModifier.UsesSeparateStatsForBosses = true;
		projWeaknessModifier.isDarkPrince = true;
		HomingModifier val2 = ((Component)component).gameObject.AddComponent<HomingModifier>();
		val2.AngularVelocity = 400f;
		val2.HomingRadius = 200f;
		List<string> list = new List<string> { "NevernamedsItems/Resources/TrailSprites/darkprince_trail_001", "NevernamedsItems/Resources/TrailSprites/darkprince_trail_002", "NevernamedsItems/Resources/TrailSprites/darkprince_trail_003", "NevernamedsItems/Resources/TrailSprites/darkprince_trail_004", "NevernamedsItems/Resources/TrailSprites/darkprince_trail_005" };
		TrailAPI.AddTrailToProjectile(component, "NevernamedsItems/Resources/TrailSprites/darkprince_trail_001", new Vector2(21f, 1f), new Vector2(0f, 10f), list, 10, (List<string>)null, 20, 0.1f, 0.1f, -1f, true, true);
	}

	public static void BuildPrefab()
	{
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_0098: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_012b: Unknown result type (might be due to invalid IL or missing references)
		//IL_016f: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0202: Unknown result type (might be due to invalid IL or missing references)
		//IL_0246: Unknown result type (might be due to invalid IL or missing references)
		//IL_0277: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_032f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0336: Expected O, but got Unknown
		if (!((Object)(object)prefab != (Object)null) && !CompanionBuilder.companionDictionary.ContainsKey(guid))
		{
			prefab = CompanionBuilder.BuildPrefab("Dark Prince", guid, "NevernamedsItems/Resources/Companions/DarkPrince/darkprince_idlefrontright_001", new IntVector2(6, 1), new IntVector2(5, 5));
			DarkPrinceController darkPrinceController = prefab.AddComponent<DarkPrinceController>();
			((BraveBehaviour)darkPrinceController).aiActor.MovementSpeed = 4f;
			AIAnimator orAddComponent = GameObjectExtensions.GetOrAddComponent<AIAnimator>(prefab);
			orAddComponent.AdvAddAnimation("idle", (DirectionType)4, (AnimationType)1, new List<AnimationUtilityExtensions.DirectionalAnimationData>
			{
				new AnimationUtilityExtensions.DirectionalAnimationData
				{
					subAnimationName = "idle_back_right",
					wrapMode = (WrapMode)0,
					fps = 9,
					pathDirectory = "NevernamedsItems/Resources/Companions/DarkPrince/darkprince_idlebackright"
				},
				new AnimationUtilityExtensions.DirectionalAnimationData
				{
					subAnimationName = "idle_front_right",
					wrapMode = (WrapMode)0,
					fps = 9,
					pathDirectory = "NevernamedsItems/Resources/Companions/DarkPrince/darkprince_idlefrontright"
				},
				new AnimationUtilityExtensions.DirectionalAnimationData
				{
					subAnimationName = "idle_front_left",
					wrapMode = (WrapMode)0,
					fps = 9,
					pathDirectory = "NevernamedsItems/Resources/Companions/DarkPrince/darkprince_idlefrontleft"
				},
				new AnimationUtilityExtensions.DirectionalAnimationData
				{
					subAnimationName = "idle_back_left",
					wrapMode = (WrapMode)0,
					fps = 9,
					pathDirectory = "NevernamedsItems/Resources/Companions/DarkPrince/darkprince_idlebackleft"
				}
			});
			orAddComponent.AdvAddAnimation("move", (DirectionType)4, (AnimationType)0, new List<AnimationUtilityExtensions.DirectionalAnimationData>
			{
				new AnimationUtilityExtensions.DirectionalAnimationData
				{
					subAnimationName = "move_back_right",
					wrapMode = (WrapMode)0,
					fps = 9,
					pathDirectory = "NevernamedsItems/Resources/Companions/DarkPrince/darkprince_walkbackright"
				},
				new AnimationUtilityExtensions.DirectionalAnimationData
				{
					subAnimationName = "move_front_right",
					wrapMode = (WrapMode)0,
					fps = 9,
					pathDirectory = "NevernamedsItems/Resources/Companions/DarkPrince/darkprince_walkfrontright"
				},
				new AnimationUtilityExtensions.DirectionalAnimationData
				{
					subAnimationName = "move_front_left",
					wrapMode = (WrapMode)0,
					fps = 9,
					pathDirectory = "NevernamedsItems/Resources/Companions/DarkPrince/darkprince_walkfrontleft"
				},
				new AnimationUtilityExtensions.DirectionalAnimationData
				{
					subAnimationName = "move_back_left",
					wrapMode = (WrapMode)0,
					fps = 9,
					pathDirectory = "NevernamedsItems/Resources/Companions/DarkPrince/darkprince_walkbackleft"
				}
			});
			orAddComponent.AdvAddAnimation("attack", (DirectionType)4, (AnimationType)6, new List<AnimationUtilityExtensions.DirectionalAnimationData>
			{
				new AnimationUtilityExtensions.DirectionalAnimationData
				{
					subAnimationName = "attack_back_right",
					wrapMode = (WrapMode)2,
					fps = 9,
					pathDirectory = "NevernamedsItems/Resources/Companions/DarkPrince/darkprince_attackbackright"
				},
				new AnimationUtilityExtensions.DirectionalAnimationData
				{
					subAnimationName = "attack_front_right",
					wrapMode = (WrapMode)2,
					fps = 9,
					pathDirectory = "NevernamedsItems/Resources/Companions/DarkPrince/darkprince_attackfrontright"
				},
				new AnimationUtilityExtensions.DirectionalAnimationData
				{
					subAnimationName = "attack_front_left",
					wrapMode = (WrapMode)2,
					fps = 9,
					pathDirectory = "NevernamedsItems/Resources/Companions/DarkPrince/darkprince_attackfrontleft"
				},
				new AnimationUtilityExtensions.DirectionalAnimationData
				{
					subAnimationName = "attack_back_left",
					wrapMode = (WrapMode)2,
					fps = 9,
					pathDirectory = "NevernamedsItems/Resources/Companions/DarkPrince/darkprince_attackbackleft"
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
