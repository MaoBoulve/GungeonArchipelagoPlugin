using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Dungeonator;
using UnityEngine;

namespace NevernamedsItems;

public class GenericShrine : BraveBehaviour, IPlayerInteractable
{
	[CompilerGenerated]
	private sealed class _003CSequence_003Ed__16 : IEnumerator<object>, IDisposable, IEnumerator
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public PlayerController interactor;

		public GenericShrine _003C_003E4__this;

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
		public _003CSequence_003Ed__16(int _003C_003E1__state)
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
			//IL_0039: Unknown result type (might be due to invalid IL or missing references)
			switch (_003C_003E1__state)
			{
			default:
				return false;
			case 0:
				_003C_003E1__state = -1;
				TextBoxManager.ShowStoneTablet(_003C_003E4__this.talkpoint.position, _003C_003E4__this.talkpoint, -1f, _003C_003E4__this.PanelText(interactor), true, false);
				_003CselectedResponse_003E5__1 = -1;
				interactor.SetInputOverride("shrineConversation");
				_003C_003E2__current = null;
				_003C_003E1__state = 1;
				return true;
			case 1:
				_003C_003E1__state = -1;
				if (_003C_003E4__this.CanAccept(interactor))
				{
					GameUIRoot.Instance.DisplayPlayerConversationOptions(interactor, (TalkModule)null, _003C_003E4__this.AcceptText(interactor), _003C_003E4__this.DeclineText(interactor));
				}
				else
				{
					GameUIRoot.Instance.DisplayPlayerConversationOptions(interactor, (TalkModule)null, _003C_003E4__this.DeclineText(interactor), string.Empty);
				}
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
			interactor.ClearInputOverride("shrineConversation");
			TextBoxManager.ClearTextBox(_003C_003E4__this.talkpoint);
			if (!_003C_003E4__this.CanAccept(interactor))
			{
				_003C_003E4__this.OnDecline(interactor);
			}
			else if (_003CselectedResponse_003E5__1 == 0)
			{
				_003C_003E4__this.OnAccept(interactor);
				_003C_003E4__this.timesAccepted++;
			}
			else
			{
				_003C_003E4__this.OnDecline(interactor);
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

	private Transform talkpoint;

	private GameObject m_instanceMinimapIcon;

	public int timesAccepted = 0;

	private void Start()
	{
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Expected O, but got Unknown
		talkpoint = ((BraveBehaviour)this).transform.Find("talkpoint");
		m_room = GameManager.Instance.Dungeon.data.GetAbsoluteRoomFromPosition(Vector3Extensions.IntXY(((BraveBehaviour)this).transform.position, (VectorConversions)2));
		m_room.RegisterInteractable((IPlayerInteractable)(object)this);
		m_instanceMinimapIcon = Minimap.Instance.RegisterRoomIcon(m_room, (GameObject)BraveResources.Load("Global Prefabs/Minimap_Shrine_Icon", ".prefab"), false);
		OnPlacement();
	}

	public virtual void OnPlacement()
	{
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
		if (!TextBoxManager.HasTextBox(talkpoint))
		{
			((MonoBehaviour)this).StartCoroutine(Sequence(interactor));
		}
	}

	public virtual bool CanAccept(PlayerController Interactor)
	{
		return true;
	}

	public virtual void OnAccept(PlayerController Interactor)
	{
	}

	public virtual void OnDecline(PlayerController Interactor)
	{
	}

	public virtual string AcceptText(PlayerController Interactor)
	{
		return "Accept";
	}

	public virtual string DeclineText(PlayerController Interactor)
	{
		return "Decline";
	}

	public virtual string PanelText(PlayerController Interactor)
	{
		return "This is a shine. Dear God.";
	}

	public IEnumerator Sequence(PlayerController interactor)
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CSequence_003Ed__16(0)
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

	public void DeregisterMapIcon()
	{
		if (Object.op_Implicit((Object)(object)m_instanceMinimapIcon))
		{
			Minimap.Instance.DeregisterRoomIcon(m_room, m_instanceMinimapIcon);
			m_instanceMinimapIcon = null;
		}
	}
}
