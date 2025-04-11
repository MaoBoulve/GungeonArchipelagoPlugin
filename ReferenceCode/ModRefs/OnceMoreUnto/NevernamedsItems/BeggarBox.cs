using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Dungeonator;
using SaveAPI;
using UnityEngine;

namespace NevernamedsItems;

public class BeggarBox : BraveBehaviour, IPlayerInteractable
{
	[CompilerGenerated]
	private sealed class _003CHandleInteract_003Ed__7 : IEnumerator<object>, IDisposable, IEnumerator
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public PlayerController interactor;

		public BeggarBox _003C_003E4__this;

		private int _003Camt_003E5__1;

		private int _003CselectedResponse_003E5__2;

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
		public _003CHandleInteract_003Ed__7(int _003C_003E1__state)
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
			//IL_0135: Unknown result type (might be due to invalid IL or missing references)
			//IL_0144: Unknown result type (might be due to invalid IL or missing references)
			//IL_0149: Unknown result type (might be due to invalid IL or missing references)
			switch (_003C_003E1__state)
			{
			default:
				return false;
			case 0:
				_003C_003E1__state = -1;
				_003Camt_003E5__1 = 10;
				if (SaveAPIManager.GetFlag(CustomDungeonFlags.GIVEN_BEGGARSBELIEF))
				{
					_003Camt_003E5__1 = 50;
					_003Camt_003E5__1 = Math.Min(_003Camt_003E5__1, _003C_003E4__this.master.AmountToNextReward);
				}
				else if (_003C_003E4__this.master.NextReward != null)
				{
					if (_003C_003E4__this.master.NextReward.req >= 100)
					{
						_003Camt_003E5__1 = 50;
					}
					if (_003C_003E4__this.master.NextReward.req >= 1000)
					{
						_003Camt_003E5__1 = 100;
					}
					_003Camt_003E5__1 = Math.Min(_003Camt_003E5__1, _003C_003E4__this.master.AmountToNextReward);
				}
				_003Camt_003E5__1 = Math.Min(_003Camt_003E5__1, interactor.carriedConsumables.Currency);
				TextBoxManager.ShowNote(((BraveBehaviour)_003C_003E4__this).transform.position + new Vector3(0f, 1f), ((BraveBehaviour)_003C_003E4__this).transform, -1f, "Too old fer gunnin. Donations welcome.\n" + _003C_003E4__this.master.NextRewardString + "\n" + _003C_003E4__this.master.TotalString, true, false);
				_003CselectedResponse_003E5__2 = -1;
				interactor.SetInputOverride("shrineConversation");
				_003C_003E2__current = null;
				_003C_003E1__state = 1;
				return true;
			case 1:
				_003C_003E1__state = -1;
				if (interactor.carriedConsumables.Currency > 0)
				{
					GameUIRoot.Instance.DisplayPlayerConversationOptions(interactor, (TalkModule)null, $"Donate <{_003Camt_003E5__1}[sprite \"ui_coin\"]>", "Turn Away");
				}
				else
				{
					GameUIRoot.Instance.DisplayPlayerConversationOptions(interactor, (TalkModule)null, "Turn Away", string.Empty);
				}
				break;
			case 2:
				_003C_003E1__state = -1;
				break;
			}
			if (!GameUIRoot.Instance.GetPlayerConversationResponse(ref _003CselectedResponse_003E5__2))
			{
				_003C_003E2__current = null;
				_003C_003E1__state = 2;
				return true;
			}
			interactor.ClearInputOverride("shrineConversation");
			TextBoxManager.ClearTextBox(((BraveBehaviour)_003C_003E4__this).transform);
			if (_003CselectedResponse_003E5__2 == 0 && interactor.carriedConsumables.Currency > 0)
			{
				PlayerConsumables carriedConsumables = interactor.carriedConsumables;
				carriedConsumables.Currency -= _003Camt_003E5__1;
				_003C_003E4__this.master.OnDonationMade(_003Camt_003E5__1, interactor);
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

	public RoomHandler m_room;

	public Beggar master;

	private void Start()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		SpriteOutlineManager.AddOutlineToSprite(((BraveBehaviour)this).sprite, Color.black);
		m_room = GameManager.Instance.Dungeon.data.GetAbsoluteRoomFromPosition(Vector3Extensions.IntXY(((BraveBehaviour)this).transform.position, (VectorConversions)2));
		m_room.RegisterInteractable((IPlayerInteractable)(object)this);
	}

	public float GetDistanceToPoint(Vector2 point)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		return Vector2.Distance(point, Vector2.op_Implicit(((BraveBehaviour)this).transform.position)) / 1.5f;
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
		if (!master.busy)
		{
			((MonoBehaviour)this).StartCoroutine(HandleInteract(interactor));
		}
	}

	public IEnumerator HandleInteract(PlayerController interactor)
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CHandleInteract_003Ed__7(0)
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
