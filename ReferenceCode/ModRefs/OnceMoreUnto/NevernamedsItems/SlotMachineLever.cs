using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Dungeonator;
using UnityEngine;

namespace NevernamedsItems;

public class SlotMachineLever : BraveBehaviour, IPlayerInteractable
{
	[CompilerGenerated]
	private sealed class _003CSequence_003Ed__7 : IEnumerator<object>, IDisposable, IEnumerator
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public PlayerController interactor;

		public SlotMachineLever _003C_003E4__this;

		private int _003CselectedResponse_003E5__1;

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
		public _003CSequence_003Ed__7(int _003C_003E1__state)
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
			switch (_003C_003E1__state)
			{
			default:
				return false;
			case 0:
				_003C_003E1__state = -1;
				_003CselectedResponse_003E5__1 = -1;
				interactor.SetInputOverride("slotMachine");
				_003C_003E2__current = null;
				_003C_003E1__state = 1;
				return true;
			case 1:
				_003C_003E1__state = -1;
				GameUIRoot.Instance.DisplayPlayerConversationOptions(interactor, (TalkModule)null, $"Roll the Bones <Current Bet: {_003C_003E4__this.master.currentBet}[sprite \"ui_coin\"]>", "Resist the temptation");
				break;
			case 2:
				_003C_003E1__state = -1;
				break;
			}
			if (!GameUIRoot.Instance.GetPlayerConversationResponse(ref _003CselectedResponse_003E5__1))
			{
				_003C_003E2__current = null;
				_003C_003E1__state = 2;
				return true;
			}
			interactor.ClearInputOverride("slotMachine");
			if (_003CselectedResponse_003E5__1 == 0)
			{
				AkSoundEngine.PostEvent("Play_OBJ_daggershield_shot_01", ((Component)_003C_003E4__this).gameObject);
				_003C_003E4__this.master.DoodadTriggered(0, lever: true, interactor);
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

	public SlotMachine master;

	public RoomHandler m_room;

	private void Start()
	{
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		m_room = GameManager.Instance.Dungeon.data.GetAbsoluteRoomFromPosition(Vector3Extensions.IntXY(((BraveBehaviour)this).transform.position, (VectorConversions)2));
		m_room.RegisterInteractable((IPlayerInteractable)(object)this);
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
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		SpriteOutlineManager.AddOutlineToSprite(((BraveBehaviour)this).sprite, Color.white);
		((BraveBehaviour)this).sprite.UpdateZDepth();
	}

	public void OnExitRange(PlayerController interactor)
	{
		SpriteOutlineManager.RemoveOutlineFromSprite(((BraveBehaviour)this).sprite, true);
		((BraveBehaviour)this).sprite.UpdateZDepth();
	}

	public void Interact(PlayerController interactor)
	{
		if (Object.op_Implicit((Object)(object)master) && !master.busy)
		{
			((MonoBehaviour)this).StartCoroutine(Sequence(interactor));
		}
	}

	public IEnumerator Sequence(PlayerController interactor)
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CSequence_003Ed__7(0)
		{
			_003C_003E4__this = this,
			interactor = interactor
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

	public override void OnDestroy()
	{
		((BraveBehaviour)this).OnDestroy();
	}
}
