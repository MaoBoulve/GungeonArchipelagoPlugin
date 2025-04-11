using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Alexandria.Misc;
using UnityEngine;

namespace NevernamedsItems;

public class FerroboltOrbController : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CCheckNshit_003Ed__3 : IEnumerator<object>, IDisposable, IEnumerator
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public FerroboltOrbController _003C_003E4__this;

		private GameObject _003CgameObject_003E5__1;

		private Projectile _003Ccomponent_003E5__2;

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
		public _003CCheckNshit_003Ed__3(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			_003CgameObject_003E5__1 = null;
			_003Ccomponent_003E5__2 = null;
			_003C_003E1__state = -2;
		}

		private bool MoveNext()
		{
			//IL_0065: Unknown result type (might be due to invalid IL or missing references)
			//IL_006a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0084: Unknown result type (might be due to invalid IL or missing references)
			//IL_008e: Unknown result type (might be due to invalid IL or missing references)
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
				if (Ferrobolt.shouldLaunchBolt)
				{
					Ferrobolt.shouldLaunchBolt = false;
					_003CgameObject_003E5__1 = SpawnManager.SpawnProjectile(((Component)Ferrobolt.launchProj).gameObject, Vector2.op_Implicit(((BraveBehaviour)_003C_003E4__this.self).sprite.WorldCenter), Quaternion.Euler(0f, 0f, Vector2Extensions.ToAngle(_003C_003E4__this.self.Direction)), true);
					_003Ccomponent_003E5__2 = _003CgameObject_003E5__1.GetComponent<Projectile>();
					if ((Object)(object)_003Ccomponent_003E5__2 != (Object)null)
					{
						_003Ccomponent_003E5__2.Owner = (GameActor)(object)_003C_003E4__this.owner;
						_003Ccomponent_003E5__2.Shooter = ((BraveBehaviour)_003C_003E4__this.owner).specRigidbody;
						ProjectileData baseData = _003Ccomponent_003E5__2.baseData;
						baseData.damage *= _003C_003E4__this.owner.stats.GetStatValue((StatType)5);
						ProjectileData baseData2 = _003Ccomponent_003E5__2.baseData;
						baseData2.force *= _003C_003E4__this.owner.stats.GetStatValue((StatType)12);
						ProjectileData baseData3 = _003Ccomponent_003E5__2.baseData;
						baseData3.range *= _003C_003E4__this.owner.stats.GetStatValue((StatType)26);
						ProjectileData baseData4 = _003Ccomponent_003E5__2.baseData;
						baseData4.speed *= _003C_003E4__this.owner.stats.GetStatValue((StatType)6);
						Projectile obj = _003Ccomponent_003E5__2;
						obj.BossDamageMultiplier *= _003C_003E4__this.owner.stats.GetStatValue((StatType)22);
						_003C_003E4__this.owner.DoPostProcessProjectile(_003Ccomponent_003E5__2);
					}
					Object.Destroy((Object)(object)((Component)_003C_003E4__this).gameObject);
					_003CgameObject_003E5__1 = null;
					_003Ccomponent_003E5__2 = null;
				}
				else
				{
					Ferrobolt.shouldLaunchBolt = true;
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
		owner = ProjectileUtility.ProjectilePlayerOwner(self);
		((MonoBehaviour)this).StartCoroutine(CheckNshit());
	}

	private IEnumerator CheckNshit()
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CCheckNshit_003Ed__3(0)
		{
			_003C_003E4__this = this
		};
	}
}
