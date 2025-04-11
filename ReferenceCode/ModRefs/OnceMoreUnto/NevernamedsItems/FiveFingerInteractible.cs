using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Dungeonator;
using UnityEngine;

namespace NevernamedsItems;

public class FiveFingerInteractible : BraveBehaviour, IPlayerInteractable
{
	[CompilerGenerated]
	private sealed class _003CHandleStealth_003Ed__6 : IEnumerator<object>, IDisposable, IEnumerator
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public PlayerController user;

		public FiveFingerInteractible _003C_003E4__this;

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
		public _003CHandleStealth_003Ed__6(int _003C_003E1__state)
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
			//IL_0080: Unknown result type (might be due to invalid IL or missing references)
			switch (_003C_003E1__state)
			{
			default:
				return false;
			case 0:
				_003C_003E1__state = -1;
				user.ChangeSpecialShaderFlag(1, 1f);
				((GameActor)user).SetIsStealthed(true, "fivefingerdiscount");
				user.SetCapableOfStealing(true, "FiveFingerDiscount", (float?)null);
				((BraveBehaviour)user).specRigidbody.AddCollisionLayerIgnoreOverride(CollisionMask.LayerToMask((CollisionLayer)2, (CollisionLayer)3));
				LootEngine.DoDefaultPurplePoof(((GameActor)user).CenterPosition, false);
				_003C_003E2__current = null;
				_003C_003E1__state = 1;
				return true;
			case 1:
				_003C_003E1__state = -1;
				user.OnDidUnstealthyAction += _003C_003E4__this.BreakStealth;
				user.OnItemStolen += _003C_003E4__this.BreakStealthOnSteal;
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

	public RoomHandler m_room;

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
		if (!((GameActor)interactor).IsStealthed)
		{
			AkSoundEngine.PostEvent("Play_ENM_wizardred_appear_01", ((Component)this).gameObject);
			((MonoBehaviour)interactor).StartCoroutine(HandleStealth(interactor));
		}
	}

	private IEnumerator HandleStealth(PlayerController user)
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CHandleStealth_003Ed__6(0)
		{
			_003C_003E4__this = this,
			user = user
		};
	}

	private void BreakStealthOnSteal(PlayerController arg1, ShopItemController arg2)
	{
		BreakStealth(arg1);
	}

	private void BreakStealth(PlayerController obj)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		LootEngine.DoDefaultPurplePoof(((GameActor)obj).CenterPosition, false);
		obj.OnDidUnstealthyAction -= BreakStealth;
		obj.OnItemStolen -= BreakStealthOnSteal;
		((BraveBehaviour)obj).specRigidbody.RemoveCollisionLayerIgnoreOverride(CollisionMask.LayerToMask((CollisionLayer)2, (CollisionLayer)3));
		obj.ChangeSpecialShaderFlag(1, 0f);
		((GameActor)obj).SetIsStealthed(false, "fivefingerdiscount");
		obj.SetCapableOfStealing(false, "FiveFingerDiscount", (float?)null);
		AkSoundEngine.PostEvent("Play_ENM_wizardred_appear_01", ((Component)this).gameObject);
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
}
