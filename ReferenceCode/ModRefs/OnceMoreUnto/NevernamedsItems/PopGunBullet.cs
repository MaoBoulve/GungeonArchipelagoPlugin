using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Alexandria.Misc;
using UnityEngine;

namespace NevernamedsItems;

public class PopGunBullet : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CDoSpeedChange_003Ed__11 : IEnumerator<object>, IDisposable, IEnumerator
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public PopGunBullet _003C_003E4__this;

		private float _003CrealTime_003E5__1;

		private float _003Celapsed_003E5__2;

		private float _003Ct_003E5__3;

		private float _003CspeedMod_003E5__4;

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
		public _003CDoSpeedChange_003Ed__11(int _003C_003E1__state)
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
			switch (_003C_003E1__state)
			{
			default:
				return false;
			case 0:
				_003C_003E1__state = -1;
				_003CrealTime_003E5__1 = 1f;
				_003CrealTime_003E5__1 *= ProjectileUtility.ProjectilePlayerOwner(_003C_003E4__this.m_projectile).stats.GetStatValue((StatType)26);
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
				_003CspeedMod_003E5__4 = Mathf.Lerp(_003C_003E4__this.initialSpeed, 0f, _003Ct_003E5__3);
				_003C_003E4__this.m_projectile.baseData.speed = _003CspeedMod_003E5__4;
				_003C_003E4__this.m_projectile.UpdateSpeed();
				if (!_003C_003E4__this.isReturning)
				{
					_003C_003E2__current = null;
					_003C_003E1__state = 1;
					return true;
				}
			}
			_003C_003E4__this.hasStopped = true;
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

	private PlayerController owner;

	private float initialSpeed;

	private bool isReturning;

	private bool hasStopped;

	private ArbitraryCableDrawer m_cable;

	private int connectedGunID;

	private void Start()
	{
		m_projectile = ((Component)this).GetComponent<Projectile>();
		owner = ProjectileUtility.ProjectilePlayerOwner(m_projectile);
		initialSpeed = m_projectile.baseData.speed;
		((MonoBehaviour)this).StartCoroutine(DoSpeedChange());
	}

	private void Update()
	{
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_009a: Unknown result type (might be due to invalid IL or missing references)
		if (Object.op_Implicit((Object)(object)owner) && Object.op_Implicit((Object)(object)m_projectile) && Object.op_Implicit((Object)(object)((GameActor)owner).CurrentGun))
		{
			if (((GameActor)owner).CurrentGun.IsReloading && !isReturning && hasStopped)
			{
				DoReturn();
			}
			if (isReturning && Vector2.Distance(Vector2.op_Implicit(((GameActor)owner).CurrentGun.barrelOffset.position), ((BraveBehaviour)m_projectile).sprite.WorldCenter) < 1f)
			{
				m_projectile.DieInAir(false, true, true, false);
			}
			if (connectedGunID != ((PickupObject)((GameActor)owner).CurrentGun).PickupObjectId)
			{
				RecalcCable();
				connectedGunID = ((PickupObject)((GameActor)owner).CurrentGun).PickupObjectId;
			}
		}
	}

	private void RecalcCable()
	{
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		if (Object.op_Implicit((Object)(object)m_cable))
		{
			Object.Destroy((Object)(object)m_cable);
			m_cable = null;
		}
		m_cable = ((Component)m_projectile).gameObject.AddComponent<ArbitraryCableDrawer>();
		m_cable.Attach2Offset = ((BraveBehaviour)m_projectile).specRigidbody.UnitCenter - Vector3Extensions.XY(((BraveBehaviour)m_projectile).transform.position);
		m_cable.Initialize(((GameActor)owner).CurrentGun.barrelOffset, ((BraveBehaviour)m_projectile).transform);
	}

	private IEnumerator DoSpeedChange()
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CDoSpeedChange_003Ed__11(0)
		{
			_003C_003E4__this = this
		};
	}

	private void OnDestroy()
	{
		if (isReturning)
		{
			Projectile projectile = m_projectile;
			projectile.ModifyVelocity = (Func<Vector2, Vector2>)Delegate.Remove(projectile.ModifyVelocity, new Func<Vector2, Vector2>(ModifyVelocity));
		}
		if (Object.op_Implicit((Object)(object)m_cable))
		{
			Object.Destroy((Object)(object)m_cable);
		}
	}

	private void DoReturn()
	{
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		isReturning = true;
		if (Object.op_Implicit((Object)(object)owner) && Object.op_Implicit((Object)(object)((GameActor)owner).CurrentGun))
		{
			Vector2 val = MathsAndLogicHelper.CalculateVectorBetween(((BraveBehaviour)m_projectile).sprite.WorldCenter, Vector2.op_Implicit(((GameActor)owner).CurrentGun.barrelOffset.position));
			m_projectile.SendInDirection(val, true, true);
			m_projectile.baseData.speed = initialSpeed;
			ProjectileData baseData = m_projectile.baseData;
			baseData.damage *= 2f;
			m_projectile.UpdateSpeed();
			Projectile projectile = m_projectile;
			projectile.ModifyVelocity = (Func<Vector2, Vector2>)Delegate.Combine(projectile.ModifyVelocity, new Func<Vector2, Vector2>(ModifyVelocity));
		}
	}

	private Vector2 ModifyVelocity(Vector2 inVel)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_015c: Unknown result type (might be due to invalid IL or missing references)
		//IL_015d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0071: Unknown result type (might be due to invalid IL or missing references)
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_0086: Unknown result type (might be due to invalid IL or missing references)
		//IL_008b: Unknown result type (might be due to invalid IL or missing references)
		//IL_008c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_0169: Unknown result type (might be due to invalid IL or missing references)
		//IL_0176: Unknown result type (might be due to invalid IL or missing references)
		//IL_0128: Unknown result type (might be due to invalid IL or missing references)
		//IL_012d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0113: Unknown result type (might be due to invalid IL or missing references)
		//IL_0190: Unknown result type (might be due to invalid IL or missing references)
		//IL_0191: Unknown result type (might be due to invalid IL or missing references)
		//IL_018b: Unknown result type (might be due to invalid IL or missing references)
		//IL_018c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0195: Unknown result type (might be due to invalid IL or missing references)
		Vector2 val = inVel;
		Vector2 val2 = ((!Object.op_Implicit((Object)(object)((BraveBehaviour)m_projectile).sprite)) ? Vector3Extensions.XY(((Component)this).transform.position) : ((BraveBehaviour)m_projectile).sprite.WorldCenter);
		if (Object.op_Implicit((Object)(object)owner) && (Object)(object)((GameActor)owner).CurrentGun != (Object)null)
		{
			Vector2 val3 = Vector2.op_Implicit(((GameActor)owner).CurrentGun.barrelOffset.position - Vector2Extensions.ToVector3ZUp(val2, 0f));
			float num = Vector2Extensions.ToAngle(val3);
			float num2 = Vector2Extensions.ToAngle(inVel);
			float num3 = 300f * m_projectile.LocalDeltaTime;
			float num4 = Mathf.MoveTowardsAngle(num2, num, num3);
			if (m_projectile is HelixProjectile)
			{
				float num5 = num4 - num2;
				Projectile projectile = m_projectile;
				((HelixProjectile)((projectile is HelixProjectile) ? projectile : null)).AdjustRightVector(num5);
			}
			else
			{
				if (m_projectile.shouldRotate)
				{
					((Component)this).transform.rotation = Quaternion.Euler(0f, 0f, num4);
				}
				val = BraveMathCollege.DegreesToVector(num4, ((Vector2)(ref inVel)).magnitude);
			}
			if (m_projectile.OverrideMotionModule != null)
			{
				m_projectile.OverrideMotionModule.AdjustRightVector(num4 - num2);
			}
		}
		if (val == Vector2.zero || float.IsNaN(val.x) || float.IsNaN(val.y))
		{
			return inVel;
		}
		return val;
	}
}
