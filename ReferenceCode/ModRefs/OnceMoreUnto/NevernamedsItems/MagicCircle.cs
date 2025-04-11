using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace NevernamedsItems;

internal class MagicCircle : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CDisableManager_003Ed__5 : IEnumerator<object>, IDisposable, IEnumerator
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public float time;

		public MagicCircle _003C_003E4__this;

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
		public _003CDisableManager_003Ed__5(int _003C_003E1__state)
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
			//IL_0027: Unknown result type (might be due to invalid IL or missing references)
			//IL_0031: Expected O, but got Unknown
			switch (_003C_003E1__state)
			{
			default:
				return false;
			case 0:
				_003C_003E1__state = -1;
				_003C_003E2__current = (object)new WaitForSeconds(time);
				_003C_003E1__state = 1;
				return true;
			case 1:
				_003C_003E1__state = -1;
				_003C_003E4__this.Disable();
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

	public static List<MagicCircle> AllMagicCircles = new List<MagicCircle>();

	public float radius;

	public bool preventMagicIndicator;

	public Color colour;

	public bool destroyOnDisable;

	public bool emitsParticles;

	public bool autoEnableOnStart;

	public float autoEnableAutoDisableTimer;

	private bool circleEnabled;

	private List<AIActor> actorsInCircle = new List<AIActor>();

	private HeatIndicatorController m_radialIndicator;

	public MagicCircle()
	{
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		((Behaviour)this).enabled = false;
		emitsParticles = false;
		colour = Color.white;
		radius = 3f;
		destroyOnDisable = true;
		autoEnableOnStart = true;
		autoEnableAutoDisableTimer = -1f;
		preventMagicIndicator = false;
	}

	private void Start()
	{
		AllMagicCircles.Add(this);
		if (autoEnableOnStart)
		{
			Enable(autoEnableAutoDisableTimer);
		}
	}

	private void OnDestroy()
	{
		AllMagicCircles.Remove(this);
	}

	public void Enable(float disableAfterSeconds = -1f)
	{
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		if (!((Behaviour)this).enabled)
		{
			if (!preventMagicIndicator)
			{
				if ((Object)(object)m_radialIndicator != (Object)null)
				{
					m_radialIndicator.EndEffect();
				}
				m_radialIndicator = ((GameObject)Object.Instantiate(ResourceCache.Acquire("Global VFX/HeatIndicator"), ((Component)this).gameObject.transform.position, Quaternion.identity)).GetComponent<HeatIndicatorController>();
				m_radialIndicator.CurrentColor = colour;
				m_radialIndicator.IsFire = emitsParticles;
				m_radialIndicator.CurrentRadius = radius;
				((Component)m_radialIndicator).transform.parent = ((Component)this).transform;
			}
			OnEnabled();
			((Behaviour)this).enabled = true;
			if (disableAfterSeconds > 0f)
			{
				((MonoBehaviour)this).StartCoroutine(DisableManager(disableAfterSeconds));
			}
		}
		else
		{
			Debug.LogWarning((object)"Alexandria (MagicCircleDoer): Cannot enable a magic circle which is already enabled.");
		}
	}

	private IEnumerator DisableManager(float time)
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CDisableManager_003Ed__5(0)
		{
			_003C_003E4__this = this,
			time = time
		};
	}

	public void Disable()
	{
		if ((Object)(object)m_radialIndicator != (Object)null)
		{
			m_radialIndicator.EndEffect();
			m_radialIndicator = null;
		}
		for (int num = actorsInCircle.Count - 1; num >= 0; num--)
		{
			if ((Object)(object)actorsInCircle[num] != (Object)null)
			{
				EnemyLeftCircle(actorsInCircle[num]);
			}
		}
		actorsInCircle.Clear();
		OnDisabled();
		((Behaviour)this).enabled = false;
		if (destroyOnDisable)
		{
			Object.Destroy((Object)(object)((Component)this).gameObject);
		}
	}

	public void UpdateRadius(float newRadius)
	{
		radius = newRadius;
		if (Object.op_Implicit((Object)(object)m_radialIndicator))
		{
			m_radialIndicator.CurrentRadius = radius;
			m_radialIndicator.m_materialInst.SetFloat(m_radialIndicator.m_radiusID, radius);
		}
		OnRadiusUpdated();
	}

	public virtual void OnEnabled()
	{
	}

	public virtual void OnDisabled()
	{
	}

	public virtual void OnRadiusUpdated()
	{
	}

	public virtual void TickOnEnemy(AIActor enemy)
	{
	}

	public virtual void EnemyEnteredCircle(AIActor enemy)
	{
	}

	public virtual void EnemyLeftCircle(AIActor enemy)
	{
	}

	private void Update()
	{
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		if (!circleEnabled || GameManager.Instance.IsLoadingLevel || !((Object)(object)GameManager.Instance.Dungeon != (Object)null))
		{
			return;
		}
		for (int num = StaticReferenceManager.AllEnemies.Count - 1; num >= 0; num--)
		{
			if ((Object)(object)StaticReferenceManager.AllEnemies[num] != (Object)null)
			{
				if (Vector2.Distance(Vector2.op_Implicit(StaticReferenceManager.AllEnemies[num].Position), Vector2.op_Implicit(((Component)this).gameObject.transform.position)) <= radius)
				{
					if (!actorsInCircle.Contains(StaticReferenceManager.AllEnemies[num]))
					{
						EnemyEnteredCircle(StaticReferenceManager.AllEnemies[num]);
						actorsInCircle.Add(StaticReferenceManager.AllEnemies[num]);
					}
					TickOnEnemy(StaticReferenceManager.AllEnemies[num]);
				}
				else if (actorsInCircle.Contains(StaticReferenceManager.AllEnemies[num]))
				{
					EnemyLeftCircle(StaticReferenceManager.AllEnemies[num]);
					actorsInCircle.Remove(StaticReferenceManager.AllEnemies[num]);
				}
			}
		}
		for (int num2 = actorsInCircle.Count - 1; num2 >= 0; num2--)
		{
			if ((Object)(object)actorsInCircle[num2] == (Object)null)
			{
				actorsInCircle.RemoveAt(num2);
			}
		}
	}
}
