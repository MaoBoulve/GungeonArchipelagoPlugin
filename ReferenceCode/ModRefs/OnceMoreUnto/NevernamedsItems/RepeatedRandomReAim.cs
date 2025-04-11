using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Alexandria.Misc;
using UnityEngine;

namespace NevernamedsItems;

public class RepeatedRandomReAim : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CDoReAim_003Ed__2 : IEnumerator<object>, IDisposable, IEnumerator
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public RepeatedRandomReAim _003C_003E4__this;

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
		public _003CDoReAim_003Ed__2(int _003C_003E1__state)
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
			//IL_0029: Unknown result type (might be due to invalid IL or missing references)
			//IL_0033: Expected O, but got Unknown
			switch (_003C_003E1__state)
			{
			default:
				return false;
			case 0:
				_003C_003E1__state = -1;
				break;
			case 1:
				_003C_003E1__state = -1;
				ProjectileUtility.SendInRandomDirection(_003C_003E4__this.m_projectile);
				break;
			}
			if ((Object)(object)_003C_003E4__this.m_projectile != (Object)null)
			{
				_003C_003E2__current = (object)new WaitForSeconds(0.2f);
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

	private Projectile m_projectile;

	private void Start()
	{
		m_projectile = ((Component)this).GetComponent<Projectile>();
		((MonoBehaviour)this).StartCoroutine(DoReAim());
	}

	private IEnumerator DoReAim()
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CDoReAim_003Ed__2(0)
		{
			_003C_003E4__this = this
		};
	}
}
