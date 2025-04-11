using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace NevernamedsItems;

public class LeadOfLifeCompanion : CompanionController
{
	[CompilerGenerated]
	private sealed class _003CHandleAttackCoroutine_003Ed__5 : IEnumerator<object>, IDisposable, IEnumerator
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public LeadOfLifeCompanion _003C_003E4__this;

		private int _003Ci_003E5__1;

		private float _003CburstCooldown_003E5__2;

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
		public _003CHandleAttackCoroutine_003Ed__5(int _003C_003E1__state)
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
			//IL_00f2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00fc: Expected O, but got Unknown
			int num = _003C_003E1__state;
			if (num != 0)
			{
				if (num != 1)
				{
					return false;
				}
				_003C_003E1__state = -1;
				goto IL_010d;
			}
			_003C_003E1__state = -1;
			_003C_003E4__this.isAttacking = true;
			_003Ci_003E5__1 = 0;
			goto IL_0120;
			IL_010d:
			_003Ci_003E5__1++;
			goto IL_0120;
			IL_0120:
			if (_003Ci_003E5__1 < _003C_003E4__this.numberOfBurstAttacks)
			{
				_003C_003E4__this.Attack();
				if (_003C_003E4__this.burstFireCooldown > 0f)
				{
					_003CburstCooldown_003E5__2 = _003C_003E4__this.burstFireCooldown;
					if (_003C_003E4__this.burstAttackBenefitsFromFirerate)
					{
						if (Object.op_Implicit((Object)(object)_003C_003E4__this.baseLeadOfLife) && _003C_003E4__this.baseLeadOfLife.globalCompanionFirerateMultiplier != 1f)
						{
							_003CburstCooldown_003E5__2 /= _003C_003E4__this.baseLeadOfLife.globalCompanionFirerateMultiplier;
						}
						_003CburstCooldown_003E5__2 = _003C_003E4__this.ModifyCooldown(_003CburstCooldown_003E5__2);
					}
					_003C_003E2__current = (object)new WaitForSeconds(_003CburstCooldown_003E5__2);
					_003C_003E1__state = 1;
					return true;
				}
				goto IL_010d;
			}
			_003C_003E4__this.isAttacking = false;
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

	public float timer;

	public PlayerController Owner;

	public int tiedItemID;

	public LeadOfLife baseLeadOfLife;

	public PickupObject alternativeSpawner;

	public PickupObject correspondingItem;

	public string overrideShader;

	public bool attackOnTimer;

	public bool requiresTargetToAttack;

	public bool attacksOnActiveUse;

	public int activeItemIDToAttackOn;

	public float fireCooldown;

	public int numberOfBurstAttacks;

	public float burstFireCooldown;

	public bool burstAttackBenefitsFromFirerate;

	public int timesAttacked;

	public bool isAttacking;

	public bool ignitesGoop;

	public float globalCompanionFirerateMultiplier;

	public bool spawnsCurrencyOnRoomClear;

	public float objectSpawnChance;

	public float objectTossForce;

	public GameObject objectToToss;

	public bool tossedObjectBounces;

	public LeadOfLifeCompanion()
	{
		overrideShader = null;
		attackOnTimer = true;
		fireCooldown = 1.3f;
		requiresTargetToAttack = true;
		numberOfBurstAttacks = 1;
		burstFireCooldown = 0f;
		burstAttackBenefitsFromFirerate = true;
		globalCompanionFirerateMultiplier = 1f;
		objectToToss = null;
		objectSpawnChance = 0f;
		objectTossForce = 0f;
		tossedObjectBounces = false;
		attacksOnActiveUse = false;
		activeItemIDToAttackOn = -1;
		timesAttacked = 0;
		isAttacking = false;
	}

	public static LeadOfLifeCompanion AddToPrefab(GameObject prefab, int itemID, float moveSpeed = 5f, List<MovementBehaviorBase> movementBehaviors = null)
	{
		//IL_0091: Unknown result type (might be due to invalid IL or missing references)
		//IL_0098: Expected O, but got Unknown
		LeadOfLifeCompanion leadOfLifeCompanion = prefab.AddComponent<LeadOfLifeCompanion>();
		((BraveBehaviour)leadOfLifeCompanion).aiActor.MovementSpeed = moveSpeed;
		leadOfLifeCompanion.tiedItemID = itemID;
		((BraveBehaviour)leadOfLifeCompanion).aiAnimator.GetDirectionalAnimation("idle").Prefix = "idle";
		if (((BraveBehaviour)leadOfLifeCompanion).aiAnimator.GetDirectionalAnimation("move") != null)
		{
			((BraveBehaviour)leadOfLifeCompanion).aiAnimator.GetDirectionalAnimation("move").Prefix = "run";
		}
		BehaviorSpeculator component = prefab.GetComponent<BehaviorSpeculator>();
		if (movementBehaviors == null)
		{
			List<MovementBehaviorBase> movementBehaviors2 = component.MovementBehaviors;
			List<MovementBehaviorBase> list = new List<MovementBehaviorBase> { (MovementBehaviorBase)(object)new CustomCompanionBehaviours.LeadOfLifeCompanionApproach() };
			CompanionFollowPlayerBehavior val = new CompanionFollowPlayerBehavior();
			val.IdleAnimations = new string[1] { "idle" };
			list.Add((MovementBehaviorBase)(object)val);
			movementBehaviors2.AddRange(list);
		}
		else
		{
			component.MovementBehaviors.AddRange(movementBehaviors);
		}
		return leadOfLifeCompanion;
	}

	public override void Update()
	{
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0071: Unknown result type (might be due to invalid IL or missing references)
		if (Object.op_Implicit((Object)(object)((BraveBehaviour)this).specRigidbody) && Object.op_Implicit((Object)(object)((BraveBehaviour)this).aiActor) && Object.op_Implicit((Object)(object)Owner) && Object.op_Implicit((Object)(object)((BraveBehaviour)this).transform))
		{
			if (ignitesGoop)
			{
				DeadlyDeadlyGoopManager.IgniteGoopsCircle(((BraveBehaviour)this).specRigidbody.UnitBottomCenter, 1f);
			}
			if (Owner.IsInCombat && Vector3Extensions.GetAbsoluteRoom(((BraveBehaviour)this).transform.position) == Owner.CurrentRoom && ((Object)(object)((BraveBehaviour)this).aiActor.OverrideTarget != (Object)null || !requiresTargetToAttack))
			{
				if (timer > 0f && !isAttacking)
				{
					timer -= BraveTime.DeltaTime;
				}
				if (timer <= 0f)
				{
					if (attackOnTimer)
					{
						((MonoBehaviour)this).StartCoroutine(HandleAttackCoroutine());
					}
					float num = fireCooldown;
					if (Object.op_Implicit((Object)(object)baseLeadOfLife) && baseLeadOfLife.globalCompanionFirerateMultiplier != 1f)
					{
						num /= baseLeadOfLife.globalCompanionFirerateMultiplier;
					}
					num = ModifyCooldown(num);
					timer = num;
				}
			}
		}
		((CompanionController)this).Update();
	}

	private void OnOwnerUsedActiveItem(PlayerController player, PlayerItem item)
	{
		OwnerUsedActiveItem(item);
		if (attacksOnActiveUse && (((PickupObject)item).PickupObjectId == activeItemIDToAttackOn || activeItemIDToAttackOn == -1))
		{
			((MonoBehaviour)this).StartCoroutine(HandleAttackCoroutine());
		}
	}

	private IEnumerator HandleAttackCoroutine()
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CHandleAttackCoroutine_003Ed__5(0)
		{
			_003C_003E4__this = this
		};
	}

	public virtual void Attack()
	{
		if (objectSpawnChance > 0f)
		{
			SpawnObject();
		}
	}

	private void SpawnObject()
	{
		//IL_0117: Unknown result type (might be due to invalid IL or missing references)
		//IL_011c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0121: Unknown result type (might be due to invalid IL or missing references)
		//IL_0129: Unknown result type (might be due to invalid IL or missing references)
		//IL_012e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0133: Unknown result type (might be due to invalid IL or missing references)
		//IL_0135: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0169: Unknown result type (might be due to invalid IL or missing references)
		//IL_016b: Unknown result type (might be due to invalid IL or missing references)
		//IL_014a: Unknown result type (might be due to invalid IL or missing references)
		//IL_014c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0156: Unknown result type (might be due to invalid IL or missing references)
		//IL_015b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0160: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0104: Unknown result type (might be due to invalid IL or missing references)
		//IL_008b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0097: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0190: Unknown result type (might be due to invalid IL or missing references)
		//IL_021a: Unknown result type (might be due to invalid IL or missing references)
		if (!(Random.value <= objectSpawnChance) || !Object.op_Implicit((Object)(object)((BraveBehaviour)this).sprite) || !((Object)(object)objectToToss != (Object)null))
		{
			return;
		}
		GameObject val = null;
		if (objectTossForce == 0f)
		{
			GameObject val2 = Object.Instantiate<GameObject>(objectToToss, Vector2.op_Implicit(((BraveBehaviour)this).sprite.WorldCenter), Quaternion.identity);
			val = val2;
			tk2dBaseSprite component = val2.GetComponent<tk2dBaseSprite>();
			if ((Object)(object)component != (Object)null)
			{
				component.PlaceAtPositionByAnchor(Vector2Extensions.ToVector3ZUp(((BraveBehaviour)this).sprite.WorldCenter, ((BraveBehaviour)component).transform.position.z), (Anchor)4);
				if ((Object)(object)((BraveBehaviour)component).specRigidbody != (Object)null)
				{
					((BraveBehaviour)component).specRigidbody.RegisterGhostCollisionException(((BraveBehaviour)Owner).specRigidbody);
					((BraveBehaviour)component).specRigidbody.RegisterGhostCollisionException(((BraveBehaviour)this).specRigidbody);
				}
			}
			val2.transform.position = dfVectorExtensions.Quantize(val2.transform.position, 0.0625f);
		}
		else
		{
			Vector3 val3 = Vector2.op_Implicit(GetAngleToTarget());
			Vector3 val4 = Vector2.op_Implicit(((BraveBehaviour)this).sprite.WorldCenter);
			if (val3.y > 0f)
			{
				val4 += Vector3.up * 0.25f;
			}
			GameObject val5 = Object.Instantiate<GameObject>(objectToToss, val4, Quaternion.identity);
			tk2dBaseSprite component2 = val5.GetComponent<tk2dBaseSprite>();
			if (Object.op_Implicit((Object)(object)component2))
			{
				component2.PlaceAtPositionByAnchor(val4, (Anchor)4);
			}
			val = val5;
			DebrisObject val6 = LootEngine.DropItemWithoutInstantiating(val5, val5.transform.position, Vector2.op_Implicit(val3), objectTossForce, false, false, true, false);
			if (val3.y > 0f && Object.op_Implicit((Object)(object)val6))
			{
				val6.additionalHeightBoost = -1f;
				if (Object.op_Implicit((Object)(object)((BraveBehaviour)val6).sprite))
				{
					((BraveBehaviour)val6).sprite.UpdateZDepth();
				}
			}
			val6.IsAccurateDebris = true;
			((EphemeralObject)val6).Priority = (EphemeralPriority)0;
			val6.bounceCount = (tossedObjectBounces ? 1 : 0);
		}
		if ((Object)(object)val != (Object)null)
		{
			SpawnObjectItem componentInChildren = val.GetComponentInChildren<SpawnObjectItem>();
			if (Object.op_Implicit((Object)(object)componentInChildren))
			{
				componentInChildren.SpawningPlayer = Owner;
			}
			PostSpawnObject(val);
		}
	}

	private void OnRoomClearEffects(PlayerController guy)
	{
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		if (Object.op_Implicit((Object)(object)((BraveBehaviour)this).specRigidbody))
		{
			timer = 1f;
			OnRoomClear();
			if (spawnsCurrencyOnRoomClear)
			{
				LootEngine.SpawnCurrency(((BraveBehaviour)this).specRigidbody.UnitCenter, Random.Range(0, 4), false);
			}
		}
	}

	public Vector2 GetAngleToTarget()
	{
		//IL_008d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0092: Unknown result type (might be due to invalid IL or missing references)
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0082: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		if ((Object)(object)((BraveBehaviour)this).aiActor.OverrideTarget != (Object)null)
		{
			Vector2 val;
			if ((Object)(object)((BraveBehaviour)((BraveBehaviour)this).aiActor.OverrideTarget).sprite != (Object)null)
			{
				val = ((BraveBehaviour)((BraveBehaviour)this).aiActor.OverrideTarget).sprite.WorldCenter - ((BraveBehaviour)this).specRigidbody.UnitCenter;
				return ((Vector2)(ref val)).normalized;
			}
			val = ((BraveBehaviour)this).aiActor.OverrideTarget.UnitCenter - ((BraveBehaviour)this).specRigidbody.UnitCenter;
			return ((Vector2)(ref val)).normalized;
		}
		return Vector2.zero;
	}

	private void Start()
	{
		Owner = base.m_owner;
		timer = 1f;
		if (!Object.op_Implicit((Object)(object)Owner))
		{
			return;
		}
		foreach (PassiveItem passiveItem in Owner.passiveItems)
		{
			if (Object.op_Implicit((Object)(object)passiveItem) && Object.op_Implicit((Object)(object)((Component)passiveItem).GetComponent<LeadOfLife>()) && ((Component)passiveItem).GetComponent<LeadOfLife>().extantCompanions.Count > 0 && ((Component)passiveItem).GetComponent<LeadOfLife>().extantCompanions.Contains(this))
			{
				baseLeadOfLife = ((Component)passiveItem).GetComponent<LeadOfLife>();
			}
		}
		Owner.OnRoomClearEvent += OnRoomClearEffects;
		Owner.OnUsedPlayerItem += OnOwnerUsedActiveItem;
		if (!string.IsNullOrEmpty(overrideShader))
		{
			((BraveBehaviour)((BraveBehaviour)this).sprite).renderer.material.shader = ShaderCache.Acquire(overrideShader);
		}
	}

	public override void OnDestroy()
	{
		if (Object.op_Implicit((Object)(object)Owner))
		{
			Owner.OnRoomClearEvent -= OnRoomClearEffects;
			Owner.OnUsedPlayerItem -= OnOwnerUsedActiveItem;
		}
		((CompanionController)this).OnDestroy();
	}

	public virtual float ModifyCooldown(float originalCooldown)
	{
		return originalCooldown;
	}

	public virtual void PostSpawnObject(GameObject prop)
	{
	}

	public virtual void OwnerUsedActiveItem(PlayerItem active)
	{
	}

	public virtual void OnRoomClear()
	{
	}
}
