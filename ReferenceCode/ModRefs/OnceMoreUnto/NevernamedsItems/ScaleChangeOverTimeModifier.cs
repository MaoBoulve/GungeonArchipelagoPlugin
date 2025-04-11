using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Alexandria.Misc;
using UnityEngine;

namespace NevernamedsItems;

public class ScaleChangeOverTimeModifier : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CDoShrink_003Ed__2 : IEnumerator<object>, IDisposable, IEnumerator
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public ScaleChangeOverTimeModifier _003C_003E4__this;

		private float _003CrealTime_003E5__1;

		private float _003Cx_003E5__2;

		private float _003CstartDMG_003E5__3;

		private float _003Celapsed_003E5__4;

		private float _003Ct_003E5__5;

		private float _003Cscalemodifier_003E5__6;

		private float _003CpercentageScaleThisFrame_003E5__7;

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
		public _003CDoShrink_003Ed__2(int _003C_003E1__state)
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
			//IL_0045: Unknown result type (might be due to invalid IL or missing references)
			//IL_01bb: Unknown result type (might be due to invalid IL or missing references)
			switch (_003C_003E1__state)
			{
			default:
				return false;
			case 0:
				_003C_003E1__state = -1;
				_003CrealTime_003E5__1 = _003C_003E4__this.timeToChangeOver;
				_003Cx_003E5__2 = ((BraveBehaviour)_003C_003E4__this.m_projectile).sprite.scale.x;
				_003CstartDMG_003E5__3 = _003C_003E4__this.m_projectile.baseData.damage;
				if (_003C_003E4__this.timeExtendedByRangeMultiplier && Object.op_Implicit((Object)(object)ProjectileUtility.ProjectilePlayerOwner(_003C_003E4__this.m_projectile)))
				{
					_003CrealTime_003E5__1 *= ProjectileUtility.ProjectilePlayerOwner(_003C_003E4__this.m_projectile).stats.GetStatValue((StatType)26);
				}
				_003Celapsed_003E5__4 = 0f;
				break;
			case 1:
				_003C_003E1__state = -1;
				break;
			}
			if (_003Celapsed_003E5__4 < _003CrealTime_003E5__1)
			{
				_003Celapsed_003E5__4 += BraveTime.DeltaTime;
				_003Ct_003E5__5 = Mathf.Clamp01(_003Celapsed_003E5__4 / _003CrealTime_003E5__1);
				_003Cscalemodifier_003E5__6 = Mathf.Lerp(_003C_003E4__this.initialScale, _003C_003E4__this.ScaleToChangeTo, _003Ct_003E5__5);
				if (_003C_003E4__this.scaleMultAffectsDamage)
				{
					_003CpercentageScaleThisFrame_003E5__7 = _003Cscalemodifier_003E5__6 / _003C_003E4__this.initialScale;
					_003C_003E4__this.m_projectile.baseData.damage = _003CstartDMG_003E5__3 * _003CpercentageScaleThisFrame_003E5__7;
				}
				_003C_003E4__this.m_projectile.AdditionalScaleMultiplier = _003Cscalemodifier_003E5__6;
				((BraveBehaviour)_003C_003E4__this.m_projectile).sprite.scale = new Vector3(_003Cx_003E5__2 * _003Cscalemodifier_003E5__6, _003Cx_003E5__2 * _003Cscalemodifier_003E5__6, _003Cx_003E5__2 * _003Cscalemodifier_003E5__6);
				if ((Object)(object)((BraveBehaviour)_003C_003E4__this.m_projectile).specRigidbody != (Object)null)
				{
					((BraveBehaviour)_003C_003E4__this.m_projectile).specRigidbody.UpdateCollidersOnScale = true;
				}
				_003C_003E2__current = null;
				_003C_003E1__state = 1;
				return true;
			}
			if (_003C_003E4__this.destroyAfterChange)
			{
				_003C_003E4__this.m_projectile.DieInAir(_003C_003E4__this.suppressDeathFXIfdestroyed, true, true, false);
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

	private float initialScale;

	public float timeToChangeOver;

	public float ScaleToChangeTo;

	public bool destroyAfterChange;

	public bool timeExtendedByRangeMultiplier;

	public bool suppressDeathFXIfdestroyed;

	public bool scaleMultAffectsDamage;

	public ScaleChangeOverTimeModifier()
	{
		timeToChangeOver = 1f;
		ScaleToChangeTo = 0.1f;
		destroyAfterChange = false;
		timeExtendedByRangeMultiplier = true;
		suppressDeathFXIfdestroyed = true;
		scaleMultAffectsDamage = false;
	}

	private void Start()
	{
		m_projectile = ((Component)this).GetComponent<Projectile>();
		initialScale = m_projectile.AdditionalScaleMultiplier;
		((MonoBehaviour)this).StartCoroutine(DoShrink());
	}

	private IEnumerator DoShrink()
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CDoShrink_003Ed__2(0)
		{
			_003C_003E4__this = this
		};
	}
}
