using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Alexandria.Misc;
using UnityEngine;

namespace NevernamedsItems;

public class SlowDownOverTimeModifier : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CDoSpeedChange_003Ed__13 : IEnumerator<object>, IDisposable, IEnumerator
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public SlowDownOverTimeModifier _003C_003E4__this;

		private float _003CrealTime_003E5__1;

		private float _003Celapsed_003E5__2;

		private float _003Ct_003E5__3;

		private float _003CspeedMod_003E5__4;

		private BulletLifeTimer _003Ctimer_003E5__5;

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
		public _003CDoSpeedChange_003Ed__13(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			_003Ctimer_003E5__5 = null;
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
				_003CrealTime_003E5__1 = _003C_003E4__this.timeToSlowOver;
				if (_003C_003E4__this.doRandomTimeMultiplier)
				{
					_003CrealTime_003E5__1 *= Random.Range(0.5f, 1f);
				}
				if (_003C_003E4__this.extendTimeByRangeStat && Object.op_Implicit((Object)(object)ProjectileUtility.ProjectilePlayerOwner(_003C_003E4__this.self)))
				{
					_003CrealTime_003E5__1 *= ProjectileUtility.ProjectilePlayerOwner(_003C_003E4__this.self).stats.GetStatValue((StatType)26);
				}
				_003Celapsed_003E5__2 = 0f;
				break;
			case 1:
				_003C_003E1__state = -1;
				break;
			}
			if (_003Celapsed_003E5__2 < _003CrealTime_003E5__1)
			{
				_003Celapsed_003E5__2 += BraveTime.DeltaTime;
				_003Ct_003E5__3 = Mathf.Clamp01(_003Celapsed_003E5__2 / _003CrealTime_003E5__1);
				_003CspeedMod_003E5__4 = Mathf.Lerp(_003C_003E4__this.initialSpeed, _003C_003E4__this.targetSpeed, _003Ct_003E5__3);
				_003C_003E4__this.self.baseData.speed = _003CspeedMod_003E5__4;
				_003C_003E4__this.self.UpdateSpeed();
				if (Object.op_Implicit((Object)(object)_003C_003E4__this.self))
				{
					_003C_003E2__current = null;
					_003C_003E1__state = 1;
					return true;
				}
			}
			if (_003C_003E4__this.OnCompleteStop != null)
			{
				_003C_003E4__this.OnCompleteStop(_003C_003E4__this.self);
			}
			if (_003C_003E4__this.activateDriftAfterstop && Object.op_Implicit((Object)(object)((Component)_003C_003E4__this.self).GetComponent<DriftModifier>()))
			{
				((Component)_003C_003E4__this.self).GetComponent<DriftModifier>().Activate();
			}
			if (_003C_003E4__this.killAfterCompleteStop)
			{
				_003Ctimer_003E5__5 = ((Component)_003C_003E4__this.self).gameObject.AddComponent<BulletLifeTimer>();
				_003Ctimer_003E5__5.secondsTillDeath = _003C_003E4__this.timeTillKillAfterCompleteStop;
				_003Ctimer_003E5__5 = null;
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

	private Projectile self;

	private PlayerController owner;

	private float initialSpeed;

	public bool killAfterCompleteStop;

	public float timeToSlowOver;

	public bool extendTimeByRangeStat;

	public bool doRandomTimeMultiplier;

	public float timeTillKillAfterCompleteStop;

	public bool activateDriftAfterstop;

	public float targetSpeed;

	public Action<Projectile> OnCompleteStop;

	public SlowDownOverTimeModifier()
	{
		timeTillKillAfterCompleteStop = 7f;
		killAfterCompleteStop = false;
		timeToSlowOver = 1f;
		doRandomTimeMultiplier = false;
		extendTimeByRangeStat = true;
		activateDriftAfterstop = false;
		targetSpeed = 0f;
	}

	private void Start()
	{
		self = ((Component)this).GetComponent<Projectile>();
		owner = ProjectileUtility.ProjectilePlayerOwner(self);
		initialSpeed = self.baseData.speed;
		((MonoBehaviour)this).StartCoroutine(DoSpeedChange());
	}

	private IEnumerator DoSpeedChange()
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CDoSpeedChange_003Ed__13(0)
		{
			_003C_003E4__this = this
		};
	}
}
