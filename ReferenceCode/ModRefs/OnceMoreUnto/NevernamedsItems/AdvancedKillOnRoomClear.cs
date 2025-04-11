using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Dungeonator;
using UnityEngine;

namespace NevernamedsItems;

internal class AdvancedKillOnRoomClear : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CDoDeath_003Ed__5 : IEnumerator<object>, IDisposable, IEnumerator
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public AdvancedKillOnRoomClear _003C_003E4__this;

		private bool _003Cflag_003E5__1;

		private int _003Ci_003E5__2;

		private NamedDirectionalAnimation _003CnamedDirectionalAnimation_003E5__3;

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
		public _003CDoDeath_003Ed__5(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			_003CnamedDirectionalAnimation_003E5__3 = null;
			_003C_003E1__state = -2;
		}

		private bool MoveNext()
		{
			//IL_0267: Unknown result type (might be due to invalid IL or missing references)
			//IL_0282: Unknown result type (might be due to invalid IL or missing references)
			//IL_028c: Expected O, but got Unknown
			//IL_00cf: Unknown result type (might be due to invalid IL or missing references)
			//IL_0161: Unknown result type (might be due to invalid IL or missing references)
			//IL_016b: Expected O, but got Unknown
			//IL_0181: Unknown result type (might be due to invalid IL or missing references)
			//IL_018b: Expected O, but got Unknown
			//IL_0197: Unknown result type (might be due to invalid IL or missing references)
			switch (_003C_003E1__state)
			{
			default:
				return false;
			case 0:
				_003C_003E1__state = -1;
				_003C_003E4__this.deathHasBegun = true;
				if (!string.IsNullOrEmpty(_003C_003E4__this.overrideDeathAnim) && Object.op_Implicit((Object)(object)((BraveBehaviour)_003C_003E4__this.self).aiAnimator))
				{
					_003Cflag_003E5__1 = false;
					_003Ci_003E5__2 = 0;
					while (_003Ci_003E5__2 < ((BraveBehaviour)_003C_003E4__this.self).aiAnimator.OtherAnimations.Count)
					{
						if (((BraveBehaviour)_003C_003E4__this.self).aiAnimator.OtherAnimations[_003Ci_003E5__2].name == "death")
						{
							((BraveBehaviour)_003C_003E4__this.self).aiAnimator.OtherAnimations[_003Ci_003E5__2].anim.Type = (DirectionType)1;
							((BraveBehaviour)_003C_003E4__this.self).aiAnimator.OtherAnimations[_003Ci_003E5__2].anim.Prefix = _003C_003E4__this.overrideDeathAnim;
							_003Cflag_003E5__1 = true;
						}
						_003Ci_003E5__2++;
					}
					if (!_003Cflag_003E5__1)
					{
						_003CnamedDirectionalAnimation_003E5__3 = new NamedDirectionalAnimation();
						_003CnamedDirectionalAnimation_003E5__3.name = "death";
						_003CnamedDirectionalAnimation_003E5__3.anim = new DirectionalAnimation();
						_003CnamedDirectionalAnimation_003E5__3.anim.Type = (DirectionType)1;
						_003CnamedDirectionalAnimation_003E5__3.anim.Prefix = _003C_003E4__this.overrideDeathAnim;
						_003CnamedDirectionalAnimation_003E5__3.anim.Flipped = (FlipType[])(object)new FlipType[1];
						((BraveBehaviour)_003C_003E4__this.self).aiAnimator.OtherAnimations.Add(_003CnamedDirectionalAnimation_003E5__3);
						_003CnamedDirectionalAnimation_003E5__3 = null;
					}
				}
				if (_003C_003E4__this.preventExplodeOnDeath && Object.op_Implicit((Object)(object)((Component)_003C_003E4__this.self).GetComponent<ExplodeOnDeath>()))
				{
					((Behaviour)((Component)_003C_003E4__this.self).GetComponent<ExplodeOnDeath>()).enabled = false;
				}
				((BraveBehaviour)_003C_003E4__this.self).healthHaver.PreventAllDamage = false;
				((BraveBehaviour)_003C_003E4__this.self).healthHaver.ApplyDamage(100000f, Vector2.zero, "Death on Room Clear", (CoreDamageTypes)0, (DamageCategory)5, true, (PixelCollider)null, false);
				_003C_003E2__current = (object)new WaitForSeconds(1f);
				_003C_003E1__state = 1;
				return true;
			case 1:
				_003C_003E1__state = -1;
				if (Object.op_Implicit((Object)(object)_003C_003E4__this.self) && Object.op_Implicit((Object)(object)((BraveBehaviour)_003C_003E4__this.self).healthHaver) && ((BraveBehaviour)_003C_003E4__this.self).healthHaver.IsAlive)
				{
					_003C_003E4__this.self.EraseFromExistenceWithRewards(false);
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

	private AIActor self;

	private RoomHandler parentRoom;

	public string overrideDeathAnim;

	public bool preventExplodeOnDeath;

	public bool triggersOnRoomClear;

	public bool triggersOnRoomUnseal;

	private bool deathHasBegun;

	public AdvancedKillOnRoomClear()
	{
		triggersOnRoomClear = true;
		triggersOnRoomUnseal = false;
		deathHasBegun = false;
	}

	public void Start()
	{
		self = ((Component)this).GetComponent<AIActor>();
		if (Object.op_Implicit((Object)(object)self) && ((BraveBehaviour)self).aiActor.ParentRoom != null)
		{
			parentRoom = ((BraveBehaviour)self).aiActor.ParentRoom;
			if (triggersOnRoomClear)
			{
				RoomHandler obj = parentRoom;
				obj.OnEnemiesCleared = (Action)Delegate.Combine(obj.OnEnemiesCleared, new Action(RoomCleared));
			}
		}
	}

	private void OnDestroy()
	{
		if (Object.op_Implicit((Object)(object)self) && parentRoom != null)
		{
			RoomHandler obj = parentRoom;
			obj.OnEnemiesCleared = (Action)Delegate.Remove(obj.OnEnemiesCleared, new Action(RoomCleared));
		}
	}

	private void Update()
	{
		if (((Behaviour)self).enabled && Object.op_Implicit((Object)(object)((BraveBehaviour)self).behaviorSpeculator) && ((Behaviour)((BraveBehaviour)self).behaviorSpeculator).enabled && (parentRoom == null || !parentRoom.IsSealed) && !deathHasBegun && !((BraveBehaviour)self).aiAnimator.IsPlaying("spawn") && !((BraveBehaviour)self).aiAnimator.IsPlaying("awaken"))
		{
			((Behaviour)self).enabled = false;
			ETGMod.StartGlobalCoroutine(DoDeath());
		}
	}

	private void RoomCleared()
	{
		if (deathHasBegun)
		{
			ETGMod.StartGlobalCoroutine(DoDeath());
		}
	}

	public IEnumerator DoDeath()
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CDoDeath_003Ed__5(0)
		{
			_003C_003E4__this = this
		};
	}
}
