using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Alexandria.ItemAPI;
using UnityEngine;

namespace NevernamedsItems;

public class SunlightJavelinModifiers : GunBehaviour
{
	[CompilerGenerated]
	private sealed class _003CHandleFear_003Ed__3 : IEnumerator<object>, IDisposable, IEnumerator
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public PlayerController user;

		public SpeculativeRigidbody enemy;

		public SunlightJavelinModifiers _003C_003E4__this;

		private FleePlayerData _003CfleePlayerData_003E5__1;

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
		public _003CHandleFear_003Ed__3(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			_003CfleePlayerData_003E5__1 = null;
			_003C_003E1__state = -2;
		}

		private bool MoveNext()
		{
			//IL_0059: Unknown result type (might be due to invalid IL or missing references)
			//IL_0063: Expected O, but got Unknown
			//IL_00d4: Unknown result type (might be due to invalid IL or missing references)
			//IL_00de: Expected O, but got Unknown
			//IL_00e4: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ee: Expected O, but got Unknown
			switch (_003C_003E1__state)
			{
			default:
				return false;
			case 0:
				_003C_003E1__state = -1;
				if (_003C_003E4__this.fleeData == null || (Object)(object)_003C_003E4__this.fleeData.Player != (Object)(object)user)
				{
					_003C_003E4__this.fleeData = new FleePlayerData();
					_003C_003E4__this.fleeData.Player = user;
					FleePlayerData fleeData = _003C_003E4__this.fleeData;
					fleeData.StartDistance *= 2f;
				}
				if ((Object)(object)((BraveBehaviour)((BraveBehaviour)enemy).aiActor).behaviorSpeculator != (Object)null)
				{
					((BraveBehaviour)((BraveBehaviour)enemy).aiActor).behaviorSpeculator.FleePlayerData = _003C_003E4__this.fleeData;
					_003CfleePlayerData_003E5__1 = new FleePlayerData();
					_003C_003E2__current = (object)new WaitForSeconds(10f);
					_003C_003E1__state = 1;
					return true;
				}
				break;
			case 1:
				_003C_003E1__state = -1;
				((BraveBehaviour)((BraveBehaviour)enemy).aiActor).behaviorSpeculator.FleePlayerData.Player = null;
				_003CfleePlayerData_003E5__1 = null;
				break;
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

	private FleePlayerData fleeData;

	public override void PostProcessProjectile(Projectile projectile)
	{
		GameActor currentOwner = base.gun.CurrentOwner;
		PlayerController val = (PlayerController)(object)((currentOwner is PlayerController) ? currentOwner : null);
		if (CustomSynergies.PlayerHasActiveSynergy(val, "Grease Lightning"))
		{
			ProjectileData baseData = projectile.baseData;
			baseData.damage *= 2f;
		}
		if (CustomSynergies.PlayerHasActiveSynergy(val, "Gunderbolts and Lightning"))
		{
			projectile.OnHitEnemy = (Action<Projectile, SpeculativeRigidbody, bool>)Delegate.Combine(projectile.OnHitEnemy, new Action<Projectile, SpeculativeRigidbody, bool>(AddFearEffect));
		}
		((GunBehaviour)this).PostProcessProjectile(projectile);
	}

	private void AddFearEffect(Projectile arg1, SpeculativeRigidbody arg2, bool arg3)
	{
		GameActor owner = arg1.Owner;
		PlayerController val = (PlayerController)(object)((owner is PlayerController) ? owner : null);
		if ((Object)(object)arg2 != (Object)null && (Object)(object)((BraveBehaviour)arg2).aiActor != (Object)null && (Object)(object)val != (Object)null && (Object)(object)arg2 != (Object)null && ((BraveBehaviour)arg2).healthHaver.IsAlive && ((BraveBehaviour)arg2).aiActor.EnemyGuid != "465da2bb086a4a88a803f79fe3a27677" && ((BraveBehaviour)arg2).aiActor.EnemyGuid != "05b8afe0b6cc4fffa9dc6036fa24c8ec")
		{
			((MonoBehaviour)this).StartCoroutine(HandleFear(val, arg2));
		}
	}

	private IEnumerator HandleFear(PlayerController user, SpeculativeRigidbody enemy)
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CHandleFear_003Ed__3(0)
		{
			_003C_003E4__this = this,
			user = user,
			enemy = enemy
		};
	}
}
