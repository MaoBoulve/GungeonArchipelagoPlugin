using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace NevernamedsItems;

public class ContinualKillOnRoomClear : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CSuicide_003Ed__3 : IEnumerator<object>, IDisposable, IEnumerator
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public ContinualKillOnRoomClear _003C_003E4__this;

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
		public _003CSuicide_003Ed__3(int _003C_003E1__state)
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
			//IL_002c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0036: Expected O, but got Unknown
			//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
			//IL_0143: Unknown result type (might be due to invalid IL or missing references)
			switch (_003C_003E1__state)
			{
			default:
				return false;
			case 0:
				_003C_003E1__state = -1;
				_003C_003E2__current = (object)new WaitForSeconds(_003C_003E4__this.lengthOfNonCombatSurvival);
				_003C_003E1__state = 1;
				return true;
			case 1:
				_003C_003E1__state = -1;
				if ((Object.op_Implicit((Object)(object)_003C_003E4__this.self) & Object.op_Implicit((Object)(object)((BraveBehaviour)_003C_003E4__this.self).healthHaver)) && ((BraveBehaviour)_003C_003E4__this.self).healthHaver.IsAlive)
				{
					_003C_003E4__this.ithasBegun = true;
					if (_003C_003E4__this.forceExplode && Object.op_Implicit((Object)(object)((BraveBehaviour)_003C_003E4__this.self).specRigidbody))
					{
						Exploder.DoDefaultExplosion(Vector2.op_Implicit(((BraveBehaviour)_003C_003E4__this.self).specRigidbody.UnitCenter), Vector2.zero, (Action)null, false, (CoreDamageTypes)0, false);
					}
					if (_003C_003E4__this.eraseInsteadOfKill)
					{
						_003C_003E4__this.self.EraseFromExistenceWithRewards(false);
					}
					else if (Object.op_Implicit((Object)(object)((BraveBehaviour)_003C_003E4__this.self).healthHaver))
					{
						((BraveBehaviour)_003C_003E4__this.self).healthHaver.ApplyDamage(float.MaxValue, Vector2.zero, "Erasure", (CoreDamageTypes)0, (DamageCategory)0, false, (PixelCollider)null, false);
					}
				}
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

	private bool ithasBegun = false;

	private AIActor self;

	public float lengthOfNonCombatSurvival;

	public bool eraseInsteadOfKill;

	public bool forceExplode;

	public ContinualKillOnRoomClear()
	{
		lengthOfNonCombatSurvival = 1f;
	}

	private void Start()
	{
		if (Object.op_Implicit((Object)(object)((Component)this).GetComponent<AIActor>()))
		{
			self = ((Component)this).GetComponent<AIActor>();
		}
	}

	private void Update()
	{
		if (!GameManager.Instance.PrimaryPlayer.IsInCombat && !ithasBegun)
		{
			ithasBegun = true;
			((MonoBehaviour)GameManager.Instance).StartCoroutine(Suicide());
		}
	}

	private IEnumerator Suicide()
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CSuicide_003Ed__3(0)
		{
			_003C_003E4__this = this
		};
	}
}
