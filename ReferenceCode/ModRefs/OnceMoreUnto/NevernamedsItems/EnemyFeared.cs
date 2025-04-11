using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace NevernamedsItems;

public class EnemyFeared : BraveBehaviour
{
	[CompilerGenerated]
	private sealed class _003CHandleFear_003Ed__1 : IEnumerator<object>, IDisposable, IEnumerator
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public EnemyFeared _003C_003E4__this;

		private FleePlayerData _003Cfleedata_003E5__1;

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
		public _003CHandleFear_003Ed__1(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			_003Cfleedata_003E5__1 = null;
			_003C_003E1__state = -2;
		}

		private bool MoveNext()
		{
			//IL_0042: Unknown result type (might be due to invalid IL or missing references)
			//IL_0047: Unknown result type (might be due to invalid IL or missing references)
			//IL_0058: Unknown result type (might be due to invalid IL or missing references)
			//IL_0069: Unknown result type (might be due to invalid IL or missing references)
			//IL_0080: Expected O, but got Unknown
			//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b2: Expected O, but got Unknown
			switch (_003C_003E1__state)
			{
			default:
				return false;
			case 0:
				_003C_003E1__state = -1;
				if ((Object)(object)((BraveBehaviour)_003C_003E4__this.enemy).behaviorSpeculator != (Object)null)
				{
					_003Cfleedata_003E5__1 = new FleePlayerData
					{
						StartDistance = _003C_003E4__this.fearStartDistance,
						StopDistance = _003C_003E4__this.fearStopDistance,
						Player = _003C_003E4__this.player
					};
					((BraveBehaviour)_003C_003E4__this.enemy).behaviorSpeculator.FleePlayerData = _003Cfleedata_003E5__1;
					_003C_003E2__current = (object)new WaitForSeconds(_003C_003E4__this.fearLength);
					_003C_003E1__state = 1;
					return true;
				}
				break;
			case 1:
				_003C_003E1__state = -1;
				((BraveBehaviour)_003C_003E4__this.enemy).behaviorSpeculator.FleePlayerData = null;
				_003Cfleedata_003E5__1 = null;
				break;
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

	public PlayerController player;

	private AIActor enemy;

	public float fearLength;

	public float fearStartDistance;

	public float fearStopDistance;

	private void Start()
	{
		enemy = ((BraveBehaviour)this).aiActor;
		if ((Object)(object)player != (Object)null && (Object)(object)enemy != (Object)null)
		{
			((MonoBehaviour)this).StartCoroutine("HandleFear");
		}
	}

	private IEnumerator HandleFear()
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CHandleFear_003Ed__1(0)
		{
			_003C_003E4__this = this
		};
	}
}
