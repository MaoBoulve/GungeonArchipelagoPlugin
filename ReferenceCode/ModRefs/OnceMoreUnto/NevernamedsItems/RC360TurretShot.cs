using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Alexandria.ItemAPI;
using Alexandria.Misc;
using Dungeonator;
using UnityEngine;

namespace NevernamedsItems;

public class RC360TurretShot : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CDelayedPostProcess_003Ed__4 : IEnumerator<object>, IDisposable, IEnumerator
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Projectile bulletToClone;

		public RC360TurretShot _003C_003E4__this;

		private float _003Cangle_003E5__1;

		private GameObject _003CnewBulletOBJ_003E5__2;

		private GameObject _003CspawnedBulletOBJ_003E5__3;

		private Projectile _003Ccomponent_003E5__4;

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
		public _003CDelayedPostProcess_003Ed__4(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			_003CnewBulletOBJ_003E5__2 = null;
			_003CspawnedBulletOBJ_003E5__3 = null;
			_003Ccomponent_003E5__4 = null;
			_003C_003E1__state = -2;
		}

		private bool MoveNext()
		{
			//IL_00af: Unknown result type (might be due to invalid IL or missing references)
			//IL_012f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0134: Unknown result type (might be due to invalid IL or missing references)
			//IL_0149: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ea: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f3: Unknown result type (might be due to invalid IL or missing references)
			switch (_003C_003E1__state)
			{
			default:
				return false;
			case 0:
				_003C_003E1__state = -1;
				_003C_003E2__current = null;
				_003C_003E1__state = 1;
				return true;
			case 1:
				_003C_003E1__state = -1;
				if ((Object)(object)((Component)bulletToClone).GetComponent<RC360TurretShot>() != (Object)null)
				{
					return false;
				}
				if ((Object)(object)_003C_003E4__this.self.PossibleSourceGun == (Object)null || (Object)(object)bulletToClone.PossibleSourceGun == (Object)null)
				{
					return false;
				}
				if ((Object)(object)bulletToClone.PossibleSourceGun == (Object)(object)_003C_003E4__this.self.PossibleSourceGun)
				{
					_003Cangle_003E5__1 = Vector2Extensions.ToAngle(bulletToClone.Direction);
					if (CustomSynergies.PlayerHasActiveSynergy(_003C_003E4__this.owner, "I Call Hacks"))
					{
						_003Cangle_003E5__1 = Vector2Extensions.ToAngle(MathsAndLogicHelper.GetVectorToNearestEnemy(((BraveBehaviour)_003C_003E4__this.self).specRigidbody.UnitCenter, true, (ActiveEnemyType)1, (List<AIActor>)null, (Func<AIActor, bool>)null));
					}
					_003CnewBulletOBJ_003E5__2 = FakePrefab.Clone(((Component)bulletToClone).gameObject);
					_003CspawnedBulletOBJ_003E5__3 = SpawnManager.SpawnProjectile(_003CnewBulletOBJ_003E5__2, Vector2.op_Implicit(((BraveBehaviour)_003C_003E4__this.self).sprite.WorldCenter), Quaternion.Euler(0f, 0f, _003Cangle_003E5__1), true);
					_003Ccomponent_003E5__4 = _003CspawnedBulletOBJ_003E5__3.GetComponent<Projectile>();
					if ((Object)(object)_003Ccomponent_003E5__4 != (Object)null)
					{
						_003Ccomponent_003E5__4.Owner = (GameActor)(object)_003C_003E4__this.owner;
						_003Ccomponent_003E5__4.Shooter = ((BraveBehaviour)_003C_003E4__this.owner).specRigidbody;
					}
					_003CnewBulletOBJ_003E5__2 = null;
					_003CspawnedBulletOBJ_003E5__3 = null;
					_003Ccomponent_003E5__4 = null;
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

	private Projectile self;

	private PlayerController owner;

	private void Start()
	{
		self = ((Component)this).GetComponent<Projectile>();
		if (Object.op_Implicit((Object)(object)ProjectileUtility.ProjectilePlayerOwner(self)))
		{
			owner = ProjectileUtility.ProjectilePlayerOwner(self);
		}
		if (Object.op_Implicit((Object)(object)owner))
		{
			owner.PostProcessProjectile += PostProcess;
		}
	}

	private void OnDestroy()
	{
		if (Object.op_Implicit((Object)(object)owner))
		{
			owner.PostProcessProjectile -= PostProcess;
		}
	}

	private void PostProcess(Projectile bulletToClone, float t)
	{
		((MonoBehaviour)self).StartCoroutine(DelayedPostProcess(bulletToClone));
	}

	private IEnumerator DelayedPostProcess(Projectile bulletToClone)
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CDelayedPostProcess_003Ed__4(0)
		{
			_003C_003E4__this = this,
			bulletToClone = bulletToClone
		};
	}
}
