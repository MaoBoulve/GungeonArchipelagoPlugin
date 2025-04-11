using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Alexandria.Assetbundle;
using Alexandria.ItemAPI;
using Alexandria.Misc;
using Dungeonator;
using UnityEngine;

namespace NevernamedsItems;

public class FunGuy : CompanionItem
{
	public class FunGuyController : CompanionController
	{
		[CompilerGenerated]
		private sealed class _003CAttack_003Ed__2 : IEnumerator<object>, IDisposable, IEnumerator
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public FunGuyController _003C_003E4__this;

			private int _003Ci_003E5__1;

			private GameObject _003CtoFire_003E5__2;

			private GameObject _003Cobj_003E5__3;

			private Projectile _003Cproj_003E5__4;

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
				_003CtoFire_003E5__2 = null;
				_003Cobj_003E5__3 = null;
				_003Cproj_003E5__4 = null;
				_003C_003E1__state = -2;
			}

			private bool MoveNext()
			{
				//IL_007b: Unknown result type (might be due to invalid IL or missing references)
				//IL_0085: Expected O, but got Unknown
				//IL_010c: Unknown result type (might be due to invalid IL or missing references)
				//IL_0111: Unknown result type (might be due to invalid IL or missing references)
				//IL_012c: Unknown result type (might be due to invalid IL or missing references)
				//IL_0131: Unknown result type (might be due to invalid IL or missing references)
				//IL_031b: Unknown result type (might be due to invalid IL or missing references)
				switch (_003C_003E1__state)
				{
				default:
					return false;
				case 0:
					_003C_003E1__state = -1;
					_003C_003E4__this.isAttacking = true;
					((BraveBehaviour)_003C_003E4__this).aiActor.MovementSpeed = 0f;
					AkSoundEngine.PostEvent("Play_ENM_mushroom_cloud_01", ((Component)_003C_003E4__this).gameObject);
					((BraveBehaviour)_003C_003E4__this).aiAnimator.PlayUntilFinished("attack", false, (string)null, -1f, false);
					_003C_003E2__current = (object)new WaitForSeconds(0.25f);
					_003C_003E1__state = 1;
					return true;
				case 1:
					_003C_003E1__state = -1;
					_003Ci_003E5__1 = 0;
					while (_003Ci_003E5__1 < 15)
					{
						ref GameObject reference = ref _003CtoFire_003E5__2;
						PickupObject byId = PickupObjectDatabase.GetById(FungoCannon.FungoCannonID);
						reference = ((Component)((Gun)((byId is Gun) ? byId : null)).DefaultModule.chargeProjectiles[0].Projectile).gameObject;
						if (CustomSynergies.PlayerHasActiveSynergy(_003C_003E4__this.Owner, "Pointiest One"))
						{
							_003CtoFire_003E5__2 = ((Component)synergyFungusProj).gameObject;
						}
						_003Cobj_003E5__3 = Object.Instantiate<GameObject>(_003CtoFire_003E5__2, Vector2.op_Implicit(((BraveBehaviour)_003C_003E4__this).sprite.WorldCenter), Quaternion.Euler(new Vector3(0f, 0f, (float)Random.Range(0, 360))));
						_003Cproj_003E5__4 = _003Cobj_003E5__3.GetComponent<Projectile>();
						if (Object.op_Implicit((Object)(object)_003Cproj_003E5__4))
						{
							_003Cproj_003E5__4.Owner = (GameActor)(object)_003C_003E4__this.Owner;
							_003Cproj_003E5__4.Shooter = ((BraveBehaviour)_003C_003E4__this.Owner).specRigidbody;
							ProjectileData baseData = _003Cproj_003E5__4.baseData;
							baseData.damage *= _003C_003E4__this.Owner.stats.GetStatValue((StatType)5);
							ProjectileData baseData2 = _003Cproj_003E5__4.baseData;
							baseData2.speed *= _003C_003E4__this.Owner.stats.GetStatValue((StatType)6);
							ProjectileData baseData3 = _003Cproj_003E5__4.baseData;
							baseData3.range *= _003C_003E4__this.Owner.stats.GetStatValue((StatType)26);
							ProjectileData baseData4 = _003Cproj_003E5__4.baseData;
							baseData4.force *= _003C_003E4__this.Owner.stats.GetStatValue((StatType)12);
							Projectile obj = _003Cproj_003E5__4;
							obj.BossDamageMultiplier *= _003C_003E4__this.Owner.stats.GetStatValue((StatType)22);
							_003Cproj_003E5__4.UpdateSpeed();
							ProjectileUtility.ApplyCompanionModifierToBullet(_003Cproj_003E5__4, _003C_003E4__this.Owner);
							_003C_003E4__this.Owner.DoPostProcessProjectile(_003Cproj_003E5__4);
						}
						_003CtoFire_003E5__2 = null;
						_003Cobj_003E5__3 = null;
						_003Cproj_003E5__4 = null;
						_003Ci_003E5__1++;
					}
					if (CustomSynergies.PlayerHasActiveSynergy(_003C_003E4__this.Owner, "Mush Ado About Nothing"))
					{
						PlayerUtility.DoEasyBlank(_003C_003E4__this.Owner, ((BraveBehaviour)_003C_003E4__this).sprite.WorldCenter, (EasyBlankType)1);
					}
					((BraveBehaviour)_003C_003E4__this).aiActor.MovementSpeed = ((BraveBehaviour)_003C_003E4__this).aiActor.BaseMovementSpeed;
					_003C_003E4__this.attackTimer = 4f;
					_003C_003E4__this.isAttacking = false;
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

		private float attackTimer;

		private bool isAttacking;

		public PlayerController Owner;

		private void Start()
		{
			Owner = base.m_owner;
			attackTimer = 4f;
			isAttacking = false;
		}

		public override void Update()
		{
			//IL_0028: Unknown result type (might be due to invalid IL or missing references)
			//IL_009f: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b4: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00da: Unknown result type (might be due to invalid IL or missing references)
			//IL_00df: Unknown result type (might be due to invalid IL or missing references)
			if (!Object.op_Implicit((Object)(object)Owner) || Dungeon.IsGenerating || !Owner.IsInCombat || Vector3Extensions.GetAbsoluteRoom(((BraveBehaviour)this).transform.position) != Owner.CurrentRoom)
			{
				return;
			}
			if (attackTimer > 0f)
			{
				attackTimer -= BraveTime.DeltaTime;
			}
			else if ((Object)(object)((BraveBehaviour)this).aiActor.OverrideTarget != (Object)null && !isAttacking)
			{
				Vector2 val = BraveMathCollege.ClosestPointOnRectangle(((BraveBehaviour)this).sprite.WorldCenter, ((BraveBehaviour)this).aiActor.OverrideTarget.HitboxPixelCollider.UnitBottomLeft, ((BraveBehaviour)this).aiActor.OverrideTarget.HitboxPixelCollider.UnitDimensions);
				if (Vector2.Distance(((BraveBehaviour)this).sprite.WorldCenter, val) < 5f)
				{
					((MonoBehaviour)this).StartCoroutine(Attack());
				}
			}
		}

		private IEnumerator Attack()
		{
			//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
			return new _003CAttack_003Ed__2(0)
			{
				_003C_003E4__this = this
			};
		}
	}

	public static Projectile synergyFungusProj;

	public static GameObject prefab;

	public static GameObject synergyPrefab;

	private static readonly string guid = "funguy32o6697439ysa7if7d6syf6e6thasiuft64";

	private static readonly string synergyguid = "funguysynergy327498ryye78ighidsgdstdistkd7t";

	public static void Init()
	{
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_013e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0179: Unknown result type (might be due to invalid IL or missing references)
		//IL_018b: Unknown result type (might be due to invalid IL or missing references)
		PickupObject obj = ItemSetup.NewItem<FunGuy>("Fun Guy", "Myc-inda Fella", "This young fungun has become dissilusioned with the ways of the Gungeon. Or at least, it seems that way. It's unclear if it really knows what's going on.", "funguy_icon", assetbundle: true);
		CompanionItem val = (CompanionItem)(object)((obj is CompanionItem) ? obj : null);
		((PickupObject)val).quality = (ItemQuality)2;
		val.CompanionGuid = guid;
		BuildPrefab();
		PickupObject byId = PickupObjectDatabase.GetById(86);
		synergyFungusProj = Object.Instantiate<Projectile>(((Gun)((byId is Gun) ? byId : null)).DefaultModule.projectiles[0]);
		FakePrefabExtensions.MakeFakePrefab(((Component)synergyFungusProj).gameObject);
		synergyFungusProj.SetProjectileSprite("yellowtriangleproj_001", 19, 17, lightened: true, (Anchor)4, 9, 9, anchorChangesCollider: true, fixesScale: false, null, null);
		FungoRandomBullets orAddComponent = GameObjectExtensions.GetOrAddComponent<FungoRandomBullets>(((Component)synergyFungusProj).gameObject);
		ProjectileData baseData = synergyFungusProj.baseData;
		baseData.speed *= 0.2f;
		synergyFungusProj.baseData.damage = 12.5f;
		PierceProjModifier val2 = ((Component)synergyFungusProj).gameObject.AddComponent<PierceProjModifier>();
		val2.penetration = 1;
		val2.penetratesBreakables = true;
		((Component)synergyFungusProj).gameObject.AddComponent<PierceDeadActors>();
		synergyFungusProj.pierceMinorBreakables = true;
		ProjectileBuilders.AnimateProjectileBundle(synergyFungusProj, "YellowTriangleProjectile", Initialisation.ProjectileCollection, Initialisation.projectileAnimationCollection, "YellowTriangleProjectile", MiscTools.DupeList<IntVector2>(new IntVector2(19, 17), 4), MiscTools.DupeList(value: true, 4), MiscTools.DupeList<Anchor>((Anchor)4, 4), MiscTools.DupeList(value: true, 4), MiscTools.DupeList(value: false, 4), MiscTools.DupeList<Vector3?>(null, 4), MiscTools.DupeList((IntVector2?)new IntVector2(9, 9), 4), MiscTools.DupeList((IntVector2?)new IntVector2(5, 3), 4), MiscTools.DupeList<Projectile>(null, 4));
	}

	public override void Update()
	{
		if (Object.op_Implicit((Object)(object)((CompanionItem)this).ExtantCompanion) && Object.op_Implicit((Object)(object)((PassiveItem)this).Owner))
		{
			if (((CompanionItem)this).ExtantCompanion.GetComponent<AIActor>().EnemyGuid == synergyguid && !CustomSynergies.PlayerHasActiveSynergy(((PassiveItem)this).Owner, "Pointiest One"))
			{
				base.CompanionGuid = guid;
				((CompanionItem)this).ForceCompanionRegeneration(((PassiveItem)this).Owner, (Vector2?)null);
			}
			else if (((CompanionItem)this).ExtantCompanion.GetComponent<AIActor>().EnemyGuid != synergyguid && CustomSynergies.PlayerHasActiveSynergy(((PassiveItem)this).Owner, "Pointiest One"))
			{
				base.CompanionGuid = synergyguid;
				((CompanionItem)this).ForceCompanionRegeneration(((PassiveItem)this).Owner, (Vector2?)null);
			}
		}
		((CompanionItem)this).Update();
	}

	public static void BuildPrefab()
	{
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_011b: Unknown result type (might be due to invalid IL or missing references)
		//IL_014c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0190: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0217: Unknown result type (might be due to invalid IL or missing references)
		//IL_021e: Expected O, but got Unknown
		//IL_02a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0318: Unknown result type (might be due to invalid IL or missing references)
		//IL_0349: Unknown result type (might be due to invalid IL or missing references)
		//IL_038e: Unknown result type (might be due to invalid IL or missing references)
		//IL_03bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_0404: Unknown result type (might be due to invalid IL or missing references)
		//IL_0435: Unknown result type (might be due to invalid IL or missing references)
		//IL_048e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0495: Expected O, but got Unknown
		if (!((Object)(object)prefab != (Object)null) && !CompanionBuilder.companionDictionary.ContainsKey(guid))
		{
			prefab = CompanionBuilder.BuildPrefab("Fun Guy", guid, "NevernamedsItems/Resources/Companions/FunGuy/funguy_idleright_001", new IntVector2(8, 2), new IntVector2(9, 11));
			FunGuyController funGuyController = prefab.AddComponent<FunGuyController>();
			((BraveBehaviour)funGuyController).aiActor.MovementSpeed = 5f;
			((BraveBehaviour)funGuyController).specRigidbody.CollideWithTileMap = false;
			AIAnimator orAddComponent = GameObjectExtensions.GetOrAddComponent<AIAnimator>(prefab);
			orAddComponent.AdvAddAnimation("idle", (DirectionType)2, (AnimationType)1, new List<AnimationUtilityExtensions.DirectionalAnimationData>
			{
				new AnimationUtilityExtensions.DirectionalAnimationData
				{
					subAnimationName = "idle_right",
					wrapMode = (WrapMode)0,
					fps = 9,
					pathDirectory = "NevernamedsItems/Resources/Companions/FunGuy/funguy_idleright"
				},
				new AnimationUtilityExtensions.DirectionalAnimationData
				{
					subAnimationName = "idle_left",
					wrapMode = (WrapMode)0,
					fps = 9,
					pathDirectory = "NevernamedsItems/Resources/Companions/FunGuy/funguy_idleleft"
				}
			});
			orAddComponent.AdvAddAnimation("move", (DirectionType)2, (AnimationType)0, new List<AnimationUtilityExtensions.DirectionalAnimationData>
			{
				new AnimationUtilityExtensions.DirectionalAnimationData
				{
					subAnimationName = "move_right",
					wrapMode = (WrapMode)0,
					fps = 9,
					pathDirectory = "NevernamedsItems/Resources/Companions/FunGuy/funguy_walkright"
				},
				new AnimationUtilityExtensions.DirectionalAnimationData
				{
					subAnimationName = "move_left",
					wrapMode = (WrapMode)0,
					fps = 9,
					pathDirectory = "NevernamedsItems/Resources/Companions/FunGuy/funguy_moveleft"
				}
			});
			orAddComponent.AdvAddAnimation("attack", (DirectionType)2, (AnimationType)6, new List<AnimationUtilityExtensions.DirectionalAnimationData>
			{
				new AnimationUtilityExtensions.DirectionalAnimationData
				{
					subAnimationName = "attack_right",
					wrapMode = (WrapMode)2,
					fps = 12,
					pathDirectory = "NevernamedsItems/Resources/Companions/FunGuy/funguy_attackright"
				},
				new AnimationUtilityExtensions.DirectionalAnimationData
				{
					subAnimationName = "attack_left",
					wrapMode = (WrapMode)2,
					fps = 12,
					pathDirectory = "NevernamedsItems/Resources/Companions/FunGuy/funguy_attackleft"
				}
			});
			BehaviorSpeculator component = prefab.GetComponent<BehaviorSpeculator>();
			CustomCompanionBehaviours.SimpleCompanionApproach simpleCompanionApproach = new CustomCompanionBehaviours.SimpleCompanionApproach();
			simpleCompanionApproach.DesiredDistance = 4f;
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
		if (!((Object)(object)synergyPrefab != (Object)null) && !CompanionBuilder.companionDictionary.ContainsKey(synergyguid))
		{
			synergyPrefab = CompanionBuilder.BuildPrefab("Fun Guy Synergy", synergyguid, "NevernamedsItems/Resources/Companions/FunGuy/funguysyn_idleright_001", new IntVector2(8, 2), new IntVector2(9, 11));
			FunGuyController funGuyController2 = synergyPrefab.AddComponent<FunGuyController>();
			((BraveBehaviour)funGuyController2).aiActor.MovementSpeed = 5f;
			((BraveBehaviour)funGuyController2).specRigidbody.CollideWithTileMap = false;
			AIAnimator orAddComponent2 = GameObjectExtensions.GetOrAddComponent<AIAnimator>(synergyPrefab);
			orAddComponent2.AdvAddAnimation("idle", (DirectionType)2, (AnimationType)1, new List<AnimationUtilityExtensions.DirectionalAnimationData>
			{
				new AnimationUtilityExtensions.DirectionalAnimationData
				{
					subAnimationName = "idle_right",
					wrapMode = (WrapMode)0,
					fps = 9,
					pathDirectory = "NevernamedsItems/Resources/Companions/FunGuy/funguysyn_idleright"
				},
				new AnimationUtilityExtensions.DirectionalAnimationData
				{
					subAnimationName = "idle_left",
					wrapMode = (WrapMode)0,
					fps = 9,
					pathDirectory = "NevernamedsItems/Resources/Companions/FunGuy/funguysyn_idleleft"
				}
			});
			orAddComponent2.AdvAddAnimation("move", (DirectionType)2, (AnimationType)0, new List<AnimationUtilityExtensions.DirectionalAnimationData>
			{
				new AnimationUtilityExtensions.DirectionalAnimationData
				{
					subAnimationName = "move_right",
					wrapMode = (WrapMode)0,
					fps = 9,
					pathDirectory = "NevernamedsItems/Resources/Companions/FunGuy/funguysyn_moveright"
				},
				new AnimationUtilityExtensions.DirectionalAnimationData
				{
					subAnimationName = "move_left",
					wrapMode = (WrapMode)0,
					fps = 9,
					pathDirectory = "NevernamedsItems/Resources/Companions/FunGuy/funguysyn_moveleft"
				}
			});
			orAddComponent2.AdvAddAnimation("attack", (DirectionType)2, (AnimationType)6, new List<AnimationUtilityExtensions.DirectionalAnimationData>
			{
				new AnimationUtilityExtensions.DirectionalAnimationData
				{
					subAnimationName = "attack_right",
					wrapMode = (WrapMode)2,
					fps = 12,
					pathDirectory = "NevernamedsItems/Resources/Companions/FunGuy/funguysyn_attackright"
				},
				new AnimationUtilityExtensions.DirectionalAnimationData
				{
					subAnimationName = "attack_left",
					wrapMode = (WrapMode)2,
					fps = 12,
					pathDirectory = "NevernamedsItems/Resources/Companions/FunGuy/funguysyn_attackleft"
				}
			});
			BehaviorSpeculator component2 = synergyPrefab.GetComponent<BehaviorSpeculator>();
			CustomCompanionBehaviours.SimpleCompanionApproach simpleCompanionApproach2 = new CustomCompanionBehaviours.SimpleCompanionApproach();
			simpleCompanionApproach2.DesiredDistance = 4f;
			component2.MovementBehaviors.Add((MovementBehaviorBase)(object)simpleCompanionApproach2);
			List<MovementBehaviorBase> movementBehaviors2 = component2.MovementBehaviors;
			CompanionFollowPlayerBehavior val = new CompanionFollowPlayerBehavior();
			val.IdleAnimations = new string[1] { "idle" };
			val.CatchUpRadius = 6f;
			val.CatchUpMaxSpeed = 10f;
			val.CatchUpAccelTime = 1f;
			val.CatchUpSpeed = 7f;
			movementBehaviors2.Add((MovementBehaviorBase)(object)val);
		}
	}
}
