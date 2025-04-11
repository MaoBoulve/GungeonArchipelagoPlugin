using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Alexandria.Misc;
using Dungeonator;
using UnityEngine;

namespace NevernamedsItems;

public class SelfReAimBehaviour : MonoBehaviour
{
	public enum ReAimTrigger
	{
		TIMER,
		RELOAD,
		IMMEDIATE
	}

	[CompilerGenerated]
	private sealed class _003CDoReAim_003Ed__4 : IEnumerator<object>, IDisposable, IEnumerator
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public bool instant;

		public SelfReAimBehaviour _003C_003E4__this;

		private int _003Ci_003E5__1;

		private Vector2 _003CdirVec_003E5__2;

		private List<string>.Enumerator _003C_003Es__3;

		private string _003Cson_003E5__4;

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
		public _003CDoReAim_003Ed__4(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			_003C_003Es__3 = default(List<string>.Enumerator);
			_003Cson_003E5__4 = null;
			_003C_003E1__state = -2;
		}

		private bool MoveNext()
		{
			//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cf: Unknown result type (might be due to invalid IL or missing references)
			//IL_007d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0087: Expected O, but got Unknown
			//IL_01db: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b9: Unknown result type (might be due to invalid IL or missing references)
			//IL_01be: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c3: Unknown result type (might be due to invalid IL or missing references)
			switch (_003C_003E1__state)
			{
			default:
				return false;
			case 0:
				_003C_003E1__state = -1;
				_003Ci_003E5__1 = 0;
				goto IL_022f;
			case 1:
				_003C_003E1__state = -1;
				goto IL_0097;
			case 2:
				{
					_003C_003E1__state = -1;
					goto IL_0097;
				}
				IL_022f:
				if ((float)_003Ci_003E5__1 < _003C_003E4__this.reAimAmount)
				{
					if (instant)
					{
						_003C_003E2__current = null;
						_003C_003E1__state = 1;
						return true;
					}
					if (_003C_003E4__this.reAimDelay > 0f)
					{
						_003C_003E2__current = (object)new WaitForSeconds(_003C_003E4__this.reAimDelay);
						_003C_003E1__state = 2;
						return true;
					}
					goto IL_0097;
				}
				return false;
				IL_0097:
				if (Object.op_Implicit((Object)(object)_003C_003E4__this.m_projectile))
				{
					_003CdirVec_003E5__2 = ProjectileUtility.GetVectorToNearestEnemy(_003C_003E4__this.m_projectile, true, (ActiveEnemyType)1, (List<AIActor>)null, (Func<AIActor, bool>)null);
					if (_003CdirVec_003E5__2 != Vector2.zero)
					{
						if (_003C_003E4__this.sounds != null && _003C_003E4__this.sounds.Count > 0)
						{
							_003C_003Es__3 = _003C_003E4__this.sounds.GetEnumerator();
							try
							{
								while (_003C_003Es__3.MoveNext())
								{
									_003Cson_003E5__4 = _003C_003Es__3.Current;
									AkSoundEngine.PostEvent(_003Cson_003E5__4, ((Component)_003C_003E4__this).gameObject);
									_003Cson_003E5__4 = null;
								}
							}
							finally
							{
								((IDisposable)_003C_003Es__3/*cast due to .constrained prefix*/).Dispose();
							}
							_003C_003Es__3 = default(List<string>.Enumerator);
						}
						if ((Object)(object)_003C_003E4__this.VFX != (Object)null)
						{
							SpawnManager.SpawnVFX(_003C_003E4__this.VFX, Vector2.op_Implicit(((BraveBehaviour)_003C_003E4__this.m_projectile).specRigidbody.UnitCenter), Quaternion.identity);
						}
						_003C_003E4__this.m_projectile.SendInDirection(_003CdirVec_003E5__2, false, true);
						if (_003C_003E4__this.OnReAim != null)
						{
							_003C_003E4__this.OnReAim(_003C_003E4__this.m_projectile);
						}
					}
				}
				_003Ci_003E5__1++;
				goto IL_022f;
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

	public ReAimTrigger trigger;

	public float reAimDelay;

	public float reAimAmount;

	public float maxReloadReAims;

	public GameObject VFX;

	public List<string> sounds = null;

	public Action<Projectile> OnReAim;

	private float storedReloadReaims;

	private Projectile m_projectile;

	private PlayerController owner;

	public SelfReAimBehaviour()
	{
		trigger = ReAimTrigger.IMMEDIATE;
		reAimAmount = 1f;
		reAimDelay = 0f;
		maxReloadReAims = 1f;
	}

	public void Start()
	{
		m_projectile = ((Component)this).GetComponent<Projectile>();
		owner = ProjectileUtility.ProjectilePlayerOwner(m_projectile);
		if (trigger == ReAimTrigger.IMMEDIATE)
		{
			((MonoBehaviour)this).StartCoroutine(DoReAim(instant: true));
		}
		else if (trigger == ReAimTrigger.TIMER)
		{
			((MonoBehaviour)this).StartCoroutine(DoReAim(instant: false));
		}
		else if (trigger == ReAimTrigger.RELOAD && (Object)(object)owner != (Object)null)
		{
			PlayerController obj = owner;
			obj.OnReloadedGun = (Action<PlayerController, Gun>)Delegate.Combine(obj.OnReloadedGun, new Action<PlayerController, Gun>(OnReload));
		}
	}

	private void OnDestroy()
	{
		if (trigger == ReAimTrigger.RELOAD)
		{
			PlayerController obj = owner;
			obj.OnReloadedGun = (Action<PlayerController, Gun>)Delegate.Remove(obj.OnReloadedGun, new Action<PlayerController, Gun>(OnReload));
		}
	}

	private void OnReload(PlayerController reloader, Gun gun)
	{
		if (storedReloadReaims < maxReloadReAims)
		{
			((MonoBehaviour)this).StartCoroutine(DoReAim(instant: false));
			storedReloadReaims += 1f;
		}
	}

	public IEnumerator DoReAim(bool instant)
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CDoReAim_003Ed__4(0)
		{
			_003C_003E4__this = this,
			instant = instant
		};
	}
}
