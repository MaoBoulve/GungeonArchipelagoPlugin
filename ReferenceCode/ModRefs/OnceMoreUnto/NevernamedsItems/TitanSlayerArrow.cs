using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Alexandria.Misc;
using UnityEngine;

namespace NevernamedsItems;

public class TitanSlayerArrow : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CRestoreSpeed_003Ed__7 : IEnumerator<object>, IDisposable, IEnumerator
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public TitanSlayerArrow _003C_003E4__this;

		private float _003Cdur_003E5__1;

		private float _003Cel_003E5__2;

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
		public _003CRestoreSpeed_003Ed__7(int _003C_003E1__state)
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
			int num = _003C_003E1__state;
			if (num != 0)
			{
				if (num != 1)
				{
					return false;
				}
				_003C_003E1__state = -1;
			}
			else
			{
				_003C_003E1__state = -1;
				if (!Object.op_Implicit((Object)(object)_003C_003E4__this.self))
				{
					goto IL_00fe;
				}
				_003Cdur_003E5__1 = 0.2f;
				_003Cel_003E5__2 = 0f;
			}
			if (_003Cel_003E5__2 <= _003Cdur_003E5__1)
			{
				if (Object.op_Implicit((Object)(object)_003C_003E4__this.self))
				{
					_003C_003E4__this.self.baseData.speed = Mathf.Lerp(0f, _003C_003E4__this.speedToRestoreTo * 0.7f, _003Cel_003E5__2 / _003Cdur_003E5__1);
					_003C_003E4__this.self.UpdateSpeed();
				}
				_003Cel_003E5__2 += BraveTime.DeltaTime;
				_003C_003E2__current = null;
				_003C_003E1__state = 1;
				return true;
			}
			goto IL_00fe;
			IL_00fe:
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

	public Projectile self;

	public BounceProjModifier bounce;

	public SlowDownOverTimeModifier slow;

	private float speedToRestoreTo;

	public int phase = 1;

	public float timeinPhase2 = 0f;

	private bool isDestroying = false;

	public void Start()
	{
		self = ((Component)this).GetComponent<Projectile>();
		bounce = ((Component)this).GetComponent<BounceProjModifier>();
		bounce.OnBounce += OnBounce;
	}

	public void OnBounce()
	{
		if (phase == 1)
		{
			speedToRestoreTo = self.baseData.speed;
			slow = ((Component)self).gameObject.AddComponent<SlowDownOverTimeModifier>();
			slow.timeToSlowOver = 0.2f;
			slow.extendTimeByRangeStat = false;
			phase++;
		}
	}

	public IEnumerator RestoreSpeed()
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CRestoreSpeed_003Ed__7(0)
		{
			_003C_003E4__this = this
		};
	}

	public void Update()
	{
		//IL_0143: Unknown result type (might be due to invalid IL or missing references)
		//IL_0148: Unknown result type (might be due to invalid IL or missing references)
		//IL_015d: Unknown result type (might be due to invalid IL or missing references)
		//IL_018a: Unknown result type (might be due to invalid IL or missing references)
		//IL_018f: Unknown result type (might be due to invalid IL or missing references)
		if (Object.op_Implicit((Object)(object)self) && Object.op_Implicit((Object)(object)ProjectileUtility.ProjectilePlayerOwner(self)) && Object.op_Implicit((Object)(object)((GameActor)ProjectileUtility.ProjectilePlayerOwner(self)).CurrentGun) && ((GameActor)ProjectileUtility.ProjectilePlayerOwner(self)).CurrentGun.IsReloading && phase == 2)
		{
			timeinPhase2 += BraveTime.DeltaTime;
			if (timeinPhase2 > 0.2f)
			{
				Object.Destroy((Object)(object)slow);
				phase++;
				HomeInOnPlayerModifyer orAddComponent = GameObjectExtensions.GetOrAddComponent<HomeInOnPlayerModifyer>(((Component)self).gameObject);
				orAddComponent.HomingRadius = 1000f;
				orAddComponent.AngularVelocity = 4000f;
				((MonoBehaviour)this).StartCoroutine(RestoreSpeed());
				((BraveBehaviour)self).specRigidbody.CollideWithTileMap = false;
				((BraveBehaviour)self).specRigidbody.Reinitialize();
			}
		}
		if (phase == 3 && Object.op_Implicit((Object)(object)self) && Object.op_Implicit((Object)(object)ProjectileUtility.ProjectilePlayerOwner(self)) && !isDestroying && Vector2.Distance(Vector2.op_Implicit(self.LastPosition), ((BraveBehaviour)ProjectileUtility.ProjectilePlayerOwner(self)).specRigidbody.UnitCenter) < 2f)
		{
			isDestroying = true;
			SpawnManager.SpawnVFX(SharedVFX.WhiteCircleVFX, self.LastPosition, Quaternion.identity);
			if (Object.op_Implicit((Object)(object)((GameActor)ProjectileUtility.ProjectilePlayerOwner(self)).CurrentGun) && Object.op_Implicit((Object)(object)((Component)((GameActor)ProjectileUtility.ProjectilePlayerOwner(self)).CurrentGun).GetComponent<TitanSlayer>()) && ((GameActor)ProjectileUtility.ProjectilePlayerOwner(self)).CurrentGun.IsReloading)
			{
				Gun currentGun = ((GameActor)ProjectileUtility.ProjectilePlayerOwner(self)).CurrentGun;
				currentGun.ForceImmediateReload(false);
				GameUIRoot.Instance.ForceClearReload(ProjectileUtility.ProjectilePlayerOwner(self).PlayerIDX);
			}
			Object.Destroy((Object)(object)((Component)self).gameObject);
		}
	}
}
