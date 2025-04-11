using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace NevernamedsItems;

public class KnifeReturnEffect : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CHandleKnifeSlowdownAndReturn_003Ed__1 : IEnumerator<object>, IDisposable, IEnumerator
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public KnifeReturnEffect _003C_003E4__this;

		private float _003CstarterSpeed_003E5__1;

		private float _003CprogressiveMultiplier1_003E5__2;

		private HomeInOnPlayerModifyer _003CorAddComponent_003E5__3;

		private CollideWithPlayerBehaviour _003Ckillknife_003E5__4;

		private float _003CprogressiveMultiplier2_003E5__5;

		private int _003Ci_003E5__6;

		private int _003Ci_003E5__7;

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
		public _003CHandleKnifeSlowdownAndReturn_003Ed__1(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			_003CorAddComponent_003E5__3 = null;
			_003Ckillknife_003E5__4 = null;
			_003C_003E1__state = -2;
		}

		private bool MoveNext()
		{
			//IL_0092: Unknown result type (might be due to invalid IL or missing references)
			//IL_009c: Expected O, but got Unknown
			//IL_016b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0175: Expected O, but got Unknown
			switch (_003C_003E1__state)
			{
			default:
				return false;
			case 0:
				_003C_003E1__state = -1;
				_003CstarterSpeed_003E5__1 = _003C_003E4__this.m_projectile.Speed;
				_003CprogressiveMultiplier1_003E5__2 = 0.9f;
				_003Ci_003E5__6 = 0;
				goto IL_00bd;
			case 1:
				_003C_003E1__state = -1;
				_003Ci_003E5__6++;
				goto IL_00bd;
			case 2:
				{
					_003C_003E1__state = -1;
					_003Ci_003E5__7++;
					break;
				}
				IL_00bd:
				if (_003Ci_003E5__6 < 7)
				{
					_003C_003E4__this.m_projectile.Speed = _003CstarterSpeed_003E5__1 * _003CprogressiveMultiplier1_003E5__2;
					_003CprogressiveMultiplier1_003E5__2 -= 0.1f;
					_003C_003E2__current = (object)new WaitForSeconds(0.1f);
					_003C_003E1__state = 1;
					return true;
				}
				_003CorAddComponent_003E5__3 = GameObjectExtensions.GetOrAddComponent<HomeInOnPlayerModifyer>(((Component)_003C_003E4__this.m_projectile).gameObject);
				_003CorAddComponent_003E5__3.HomingRadius = 1000f;
				_003CorAddComponent_003E5__3.AngularVelocity = 4000f;
				_003Ckillknife_003E5__4 = GameObjectExtensions.GetOrAddComponent<CollideWithPlayerBehaviour>(((Component)_003C_003E4__this.m_projectile).gameObject);
				_003CprogressiveMultiplier2_003E5__5 = 0.3f;
				_003Ci_003E5__7 = 0;
				break;
			}
			if (_003Ci_003E5__7 < 8)
			{
				_003C_003E4__this.m_projectile.Speed = _003CstarterSpeed_003E5__1 * _003CprogressiveMultiplier2_003E5__5;
				_003CprogressiveMultiplier2_003E5__5 += 0.1f;
				_003C_003E2__current = (object)new WaitForSeconds(0.1f);
				_003C_003E1__state = 2;
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

	private float m_lastElapsedDistance = 0f;

	private bool hasAddedHoming = false;

	public float range;

	public KnifeReturnEffect()
	{
		range = 0.1f;
	}

	private IEnumerator HandleKnifeSlowdownAndReturn()
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CHandleKnifeSlowdownAndReturn_003Ed__1(0)
		{
			_003C_003E4__this = this
		};
	}

	public void Start()
	{
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Expected O, but got Unknown
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Expected O, but got Unknown
		try
		{
			m_projectile = ((Component)this).GetComponent<Projectile>();
			((BraveBehaviour)m_projectile).specRigidbody.UpdateCollidersOnScale = true;
			m_projectile.OnPostUpdate += HandlePostUpdate;
			SpeculativeRigidbody specRigidbody = ((BraveBehaviour)m_projectile).specRigidbody;
			specRigidbody.OnPreRigidbodyCollision = (OnPreRigidbodyCollisionDelegate)Delegate.Combine((Delegate)(object)specRigidbody.OnPreRigidbodyCollision, (Delegate)new OnPreRigidbodyCollisionDelegate(HandlePreCollision));
			hasAddedHoming = false;
		}
		catch (Exception ex)
		{
			ETGModConsole.Log((object)ex.Message, false);
			ETGModConsole.Log((object)ex.StackTrace, false);
		}
	}

	private void HandlePreCollision(SpeculativeRigidbody myRigidbody, PixelCollider myPixelCollider, SpeculativeRigidbody otherRigidbody, PixelCollider otherPixelCollider)
	{
		if (!Object.op_Implicit((Object)(object)otherRigidbody) || !Object.op_Implicit((Object)(object)((Component)otherRigidbody).gameObject))
		{
			return;
		}
		PlayerController component = ((Component)otherRigidbody).gameObject.GetComponent<PlayerController>();
		if (!((Object)(object)component != (Object)null))
		{
			return;
		}
		foreach (Gun allGun in component.inventory.AllGuns)
		{
			if (((PickupObject)allGun).PickupObjectId == ButchersKnife.ButchersKnifeID)
			{
				ButchersKnife component2 = ((Component)allGun).GetComponent<ButchersKnife>();
				if ((Object)(object)component2 != (Object)null)
				{
					component2.OnProjectileReturn();
				}
			}
		}
		m_projectile.DieInAir(false, true, true, false);
	}

	private void HandlePostUpdate(Projectile proj)
	{
		try
		{
			if (Object.op_Implicit((Object)(object)proj))
			{
				float elapsedDistance = proj.GetElapsedDistance();
				if (elapsedDistance - m_lastElapsedDistance > range && !hasAddedHoming)
				{
					((MonoBehaviour)GameManager.Instance).StartCoroutine(HandleKnifeSlowdownAndReturn());
					hasAddedHoming = true;
				}
			}
		}
		catch (Exception ex)
		{
			ETGModConsole.Log((object)ex.Message, false);
			ETGModConsole.Log((object)ex.StackTrace, false);
		}
	}
}
