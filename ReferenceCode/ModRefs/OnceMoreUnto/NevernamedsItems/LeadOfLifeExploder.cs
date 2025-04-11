using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Dungeonator;
using UnityEngine;

namespace NevernamedsItems;

internal class LeadOfLifeExploder : LeadOfLifeCompanion
{
	[CompilerGenerated]
	private sealed class _003CDoKatanaBulletsChain_003Ed__3 : IEnumerator<object>, IDisposable, IEnumerator
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Vector2 startPosition;

		public Vector2 direction;

		public LeadOfLifeExploder _003C_003E4__this;

		private float _003CperExplosionTime_003E5__1;

		private float[] _003CexplosionTimes_003E5__2;

		private Vector2 _003ClastValidPosition_003E5__3;

		private bool _003ChitWall_003E5__4;

		private int _003Cindex_003E5__5;

		private float _003Celapsed_003E5__6;

		private Vector2 _003CcurrentDirection_003E5__7;

		private RoomHandler _003CcurrentRoom_003E5__8;

		private int _003Ci_003E5__9;

		private Vector2 _003Cvector_003E5__10;

		private Vector2 _003Cvector2_003E5__11;

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
		public _003CDoKatanaBulletsChain_003Ed__3(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			_003CexplosionTimes_003E5__2 = null;
			_003CcurrentRoom_003E5__8 = null;
			_003C_003E1__state = -2;
		}

		private bool MoveNext()
		{
			//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
			//IL_0127: Unknown result type (might be due to invalid IL or missing references)
			//IL_0132: Unknown result type (might be due to invalid IL or missing references)
			//IL_0142: Unknown result type (might be due to invalid IL or missing references)
			//IL_0147: Unknown result type (might be due to invalid IL or missing references)
			//IL_014c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0153: Unknown result type (might be due to invalid IL or missing references)
			//IL_0159: Unknown result type (might be due to invalid IL or missing references)
			//IL_0178: Unknown result type (might be due to invalid IL or missing references)
			//IL_017d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0189: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c1: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c6: Unknown result type (might be due to invalid IL or missing references)
			//IL_01d7: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b5: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ba: Unknown result type (might be due to invalid IL or missing references)
			switch (_003C_003E1__state)
			{
			default:
				return false;
			case 0:
				_003C_003E1__state = -1;
				_003CperExplosionTime_003E5__1 = _003C_003E4__this.chainExplosionDuration / (float)_003C_003E4__this.chainExplosionAmount;
				_003CexplosionTimes_003E5__2 = new float[_003C_003E4__this.chainExplosionAmount];
				_003CexplosionTimes_003E5__2[0] = 0f;
				_003CexplosionTimes_003E5__2[1] = _003CperExplosionTime_003E5__1;
				_003Ci_003E5__9 = 2;
				while (_003Ci_003E5__9 < _003C_003E4__this.chainExplosionAmount)
				{
					_003CexplosionTimes_003E5__2[_003Ci_003E5__9] = _003CexplosionTimes_003E5__2[_003Ci_003E5__9 - 1] + _003CperExplosionTime_003E5__1;
					_003Ci_003E5__9++;
				}
				_003ClastValidPosition_003E5__3 = startPosition;
				_003ChitWall_003E5__4 = false;
				_003Cindex_003E5__5 = 0;
				_003Celapsed_003E5__6 = 0f;
				_003CcurrentDirection_003E5__7 = direction;
				_003CcurrentRoom_003E5__8 = Vector3Extensions.GetAbsoluteRoom(startPosition);
				break;
			case 1:
				_003C_003E1__state = -1;
				break;
			}
			if (_003Celapsed_003E5__6 < _003C_003E4__this.chainExplosionDuration)
			{
				_003Celapsed_003E5__6 += BraveTime.DeltaTime;
				while (_003Cindex_003E5__5 < _003C_003E4__this.chainExplosionAmount && _003Celapsed_003E5__6 >= _003CexplosionTimes_003E5__2[_003Cindex_003E5__5])
				{
					_003Cvector_003E5__10 = startPosition + ((Vector2)(ref _003CcurrentDirection_003E5__7)).normalized * _003C_003E4__this.chainExplosionDistance;
					_003Cvector2_003E5__11 = Vector2.Lerp(startPosition, _003Cvector_003E5__10, ((float)_003Cindex_003E5__5 + 1f) / (float)_003C_003E4__this.chainExplosionAmount);
					if (!_003C_003E4__this.ValidPositionForKatanaSlash(_003Cvector2_003E5__11))
					{
						_003ChitWall_003E5__4 = true;
					}
					if (!_003ChitWall_003E5__4)
					{
						_003ClastValidPosition_003E5__3 = _003Cvector2_003E5__11;
					}
					Exploder.Explode(Vector2.op_Implicit(_003ClastValidPosition_003E5__3), _003C_003E4__this.explosion, _003CcurrentDirection_003E5__7, (Action)null, false, (CoreDamageTypes)0, false);
					_003Cindex_003E5__5++;
				}
				_003C_003E2__current = null;
				_003C_003E1__state = 1;
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

	public ExplosionData explosion;

	public bool doChainExplosion;

	public float chainExplosionDistance;

	public float chainExplosionDuration;

	public int chainExplosionAmount;

	public new static LeadOfLifeExploder AddToPrefab(GameObject prefab, int itemID, float moveSpeed = 5f, List<MovementBehaviorBase> movementBehaviors = null)
	{
		//IL_0091: Unknown result type (might be due to invalid IL or missing references)
		//IL_0098: Expected O, but got Unknown
		LeadOfLifeExploder leadOfLifeExploder = prefab.AddComponent<LeadOfLifeExploder>();
		((BraveBehaviour)leadOfLifeExploder).aiActor.MovementSpeed = moveSpeed;
		leadOfLifeExploder.tiedItemID = itemID;
		((BraveBehaviour)leadOfLifeExploder).aiAnimator.GetDirectionalAnimation("idle").Prefix = "idle";
		if (((BraveBehaviour)leadOfLifeExploder).aiAnimator.GetDirectionalAnimation("move") != null)
		{
			((BraveBehaviour)leadOfLifeExploder).aiAnimator.GetDirectionalAnimation("move").Prefix = "run";
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
		return leadOfLifeExploder;
	}

	public override void Attack()
	{
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		if (doChainExplosion)
		{
			((MonoBehaviour)GameManager.Instance.Dungeon).StartCoroutine(DoKatanaBulletsChain(((BraveBehaviour)this).specRigidbody.UnitCenter, GetAngleToTarget()));
		}
		else
		{
			Exploder.Explode(Vector2.op_Implicit(((BraveBehaviour)this).specRigidbody.UnitCenter), explosion, Vector2.zero, (Action)null, false, (CoreDamageTypes)0, false);
		}
		timesAttacked++;
		base.Attack();
	}

	private IEnumerator DoKatanaBulletsChain(Vector2 startPosition, Vector2 direction)
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CDoKatanaBulletsChain_003Ed__3(0)
		{
			_003C_003E4__this = this,
			startPosition = startPosition,
			direction = direction
		};
	}

	private bool ValidPositionForKatanaSlash(Vector2 pos)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Invalid comparison between Unknown and I4
		IntVector2 val = Vector2Extensions.ToIntVector2(pos, (VectorConversions)0);
		return GameManager.Instance.Dungeon.data.CheckInBoundsAndValid(val) && (int)GameManager.Instance.Dungeon.data[val].type != 1;
	}
}
