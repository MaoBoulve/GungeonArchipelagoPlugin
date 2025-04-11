using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Alexandria.Misc;
using Dungeonator;
using UnityEngine;

namespace NevernamedsItems;

public class FungoRandomBullets : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CFloatHandler_003Ed__8 : IEnumerator<object>, IDisposable, IEnumerator
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public FungoRandomBullets _003C_003E4__this;

		private float _003CHunterChance_003E5__1;

		private int _003CtimesToFloat_003E5__2;

		private int _003Ci_003E5__3;

		private float _003CHunterSpeed_003E5__4;

		private Vector2 _003CdirVec_003E5__5;

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
		public _003CFloatHandler_003Ed__8(int _003C_003E1__state)
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
			//IL_0109: Unknown result type (might be due to invalid IL or missing references)
			//IL_0113: Expected O, but got Unknown
			//IL_01df: Unknown result type (might be due to invalid IL or missing references)
			//IL_01e4: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ea: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ef: Unknown result type (might be due to invalid IL or missing references)
			//IL_020b: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			if (num != 0)
			{
				if (num != 1)
				{
					return false;
				}
				_003C_003E1__state = -1;
				_003Ci_003E5__3++;
				goto IL_0136;
			}
			_003C_003E1__state = -1;
			_003CHunterChance_003E5__1 = _003C_003E4__this.HunterSporeChance;
			if (_003C_003E4__this.HasSynergyHunterSpores)
			{
				_003CHunterChance_003E5__1 = 0.5f;
			}
			if (Object.op_Implicit((Object)(object)_003C_003E4__this.m_projectile) && Object.op_Implicit((Object)(object)ProjectileUtility.ProjectilePlayerOwner(_003C_003E4__this.m_projectile)))
			{
				if (Random.value > _003CHunterChance_003E5__1 || !ProjectileUtility.ProjectilePlayerOwner(_003C_003E4__this.m_projectile).IsInCombat)
				{
					_003C_003E4__this.m_projectile.baseData.speed = 0.1f;
					_003C_003E4__this.m_projectile.UpdateSpeed();
					_003CtimesToFloat_003E5__2 = Random.Range(3, 6);
					_003Ci_003E5__3 = 0;
					goto IL_0136;
				}
				_003CHunterSpeed_003E5__4 = 5f;
				if (_003C_003E4__this.HasSynergyHunterSpores)
				{
					_003CHunterSpeed_003E5__4 = 10f;
				}
				_003C_003E4__this.m_projectile.baseData.speed = _003CHunterSpeed_003E5__4;
				_003C_003E4__this.m_projectile.UpdateSpeed();
				_003CdirVec_003E5__5 = ProjectileUtility.GetVectorToNearestEnemy(_003C_003E4__this.m_projectile, true, (ActiveEnemyType)1, (List<AIActor>)null, (Func<AIActor, bool>)null);
				if (_003CdirVec_003E5__5 != Vector2.zero)
				{
					_003C_003E4__this.m_projectile.SendInDirection(_003CdirVec_003E5__5, false, true);
				}
			}
			goto IL_021a;
			IL_0136:
			if (_003Ci_003E5__3 < _003CtimesToFloat_003E5__2)
			{
				ProjectileUtility.SendInRandomDirection(_003C_003E4__this.m_projectile);
				_003C_003E2__current = (object)new WaitForSeconds(1f);
				_003C_003E1__state = 1;
				return true;
			}
			if (Object.op_Implicit((Object)(object)_003C_003E4__this.m_projectile))
			{
				_003C_003E4__this.m_projectile.DieInAir(false, true, true, false);
			}
			goto IL_021a;
			IL_021a:
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

	private float speedMultiplierPerFrame;

	private bool shouldSpeedModify;

	public bool HasSynergyHunterSpores;

	public float HunterSporeChance = 0.1f;

	public FungoRandomBullets()
	{
		HasSynergyHunterSpores = false;
	}

	private void Start()
	{
		try
		{
			m_projectile = ((Component)this).GetComponent<Projectile>();
			float num = Random.Range(10f, 101f) / 100f;
			ProjectileData baseData = m_projectile.baseData;
			baseData.damage *= num;
			m_projectile.RuntimeUpdateScale(num);
			ProjectileData baseData2 = m_projectile.baseData;
			baseData2.speed /= num;
			m_projectile.UpdateSpeed();
			speedMultiplierPerFrame = Random.Range(86f, 98f) / 100f;
			shouldSpeedModify = true;
		}
		catch (Exception ex)
		{
			ETGModConsole.Log((object)ex.Message, false);
			ETGModConsole.Log((object)ex.StackTrace, false);
		}
	}

	private void FixedUpdate()
	{
		if (shouldSpeedModify)
		{
			if (m_projectile.baseData.speed > 0.01f)
			{
				ProjectileData baseData = m_projectile.baseData;
				baseData.speed *= speedMultiplierPerFrame;
				m_projectile.UpdateSpeed();
			}
			else
			{
				((MonoBehaviour)GameManager.Instance).StartCoroutine(FloatHandler());
				shouldSpeedModify = false;
			}
		}
	}

	private IEnumerator FloatHandler()
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CFloatHandler_003Ed__8(0)
		{
			_003C_003E4__this = this
		};
	}
}
