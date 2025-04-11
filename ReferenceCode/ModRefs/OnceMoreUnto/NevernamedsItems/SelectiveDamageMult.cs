using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace NevernamedsItems;

public class SelectiveDamageMult : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CChangeProjectileDamage_003Ed__7 : IEnumerator<object>, IDisposable, IEnumerator
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Projectile bullet;

		public SelectiveDamageMult _003C_003E4__this;

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
		public _003CChangeProjectileDamage_003Ed__7(int _003C_003E1__state)
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
			//IL_0026: Unknown result type (might be due to invalid IL or missing references)
			//IL_0030: Expected O, but got Unknown
			switch (_003C_003E1__state)
			{
			default:
				return false;
			case 0:
				_003C_003E1__state = -1;
				_003C_003E2__current = (object)new WaitForSeconds(0.1f);
				_003C_003E1__state = 1;
				return true;
			case 1:
				_003C_003E1__state = -1;
				if ((Object)(object)bullet != (Object)null)
				{
					ProjectileData baseData = bullet.baseData;
					baseData.damage /= _003C_003E4__this.multiplier;
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

	public float multiplier;

	public bool multOnFlyingEnemies;

	public bool multOnStunnedEnemies;

	private Projectile m_projectile;

	public SelectiveDamageMult()
	{
		multiplier = 1f;
		multOnFlyingEnemies = false;
		multOnStunnedEnemies = false;
	}

	private void Start()
	{
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Expected O, but got Unknown
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Expected O, but got Unknown
		m_projectile = ((Component)this).GetComponent<Projectile>();
		SpeculativeRigidbody specRigidbody = ((BraveBehaviour)m_projectile).specRigidbody;
		specRigidbody.OnPreRigidbodyCollision = (OnPreRigidbodyCollisionDelegate)Delegate.Combine((Delegate)(object)specRigidbody.OnPreRigidbodyCollision, (Delegate)new OnPreRigidbodyCollisionDelegate(HandlePreCollision));
	}

	private void HandlePreCollision(SpeculativeRigidbody myRigidbody, PixelCollider myPixelCollider, SpeculativeRigidbody otherRigidbody, PixelCollider otherPixelCollider)
	{
		if (Object.op_Implicit((Object)(object)otherRigidbody) && Object.op_Implicit((Object)(object)((BraveBehaviour)otherRigidbody).healthHaver) && Object.op_Implicit((Object)(object)((BraveBehaviour)((BraveBehaviour)otherRigidbody).healthHaver).aiActor) && Object.op_Implicit((Object)(object)((BraveBehaviour)myRigidbody).projectile))
		{
			Projectile projectile = ((BraveBehaviour)myRigidbody).projectile;
			if (multOnFlyingEnemies && ((GameActor)((BraveBehaviour)otherRigidbody).aiActor).IsFlying)
			{
				DoMult(projectile);
			}
			if (multOnStunnedEnemies && (Object)(object)((BraveBehaviour)otherRigidbody).behaviorSpeculator != (Object)null && ((BraveBehaviour)otherRigidbody).behaviorSpeculator.IsStunned)
			{
				DoMult(projectile);
			}
		}
	}

	private void DoMult(Projectile self)
	{
		ProjectileData baseData = self.baseData;
		baseData.damage *= multiplier;
		((MonoBehaviour)GameManager.Instance).StartCoroutine(ChangeProjectileDamage(((BraveBehaviour)self).projectile));
	}

	private IEnumerator ChangeProjectileDamage(Projectile bullet)
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CChangeProjectileDamage_003Ed__7(0)
		{
			_003C_003E4__this = this,
			bullet = bullet
		};
	}
}
