using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Alexandria.ItemAPI;
using UnityEngine;

namespace NevernamedsItems;

public class SpectreBullets : PassiveItem
{
	[CompilerGenerated]
	private sealed class _003CHandleFear_003Ed__4 : IEnumerator<object>, IDisposable, IEnumerator
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public PlayerController user;

		public SpeculativeRigidbody enemy;

		public SpectreBullets _003C_003E4__this;

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
		public _003CHandleFear_003Ed__4(int _003C_003E1__state)
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
			//IL_005e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0068: Expected O, but got Unknown
			//IL_00de: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e8: Expected O, but got Unknown
			//IL_00ee: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f8: Expected O, but got Unknown
			switch (_003C_003E1__state)
			{
			default:
				return false;
			case 0:
				_003C_003E1__state = -1;
				if (_003C_003E4__this.fleeData == null || (Object)(object)_003C_003E4__this.fleeData.Player != (Object)(object)((PassiveItem)_003C_003E4__this).Owner)
				{
					_003C_003E4__this.fleeData = new FleePlayerData();
					_003C_003E4__this.fleeData.Player = ((PassiveItem)_003C_003E4__this).Owner;
					FleePlayerData fleeData = _003C_003E4__this.fleeData;
					fleeData.StartDistance *= 2f;
				}
				if ((Object)(object)((BraveBehaviour)((BraveBehaviour)enemy).aiActor).behaviorSpeculator != (Object)null)
				{
					((BraveBehaviour)((BraveBehaviour)enemy).aiActor).behaviorSpeculator.FleePlayerData = _003C_003E4__this.fleeData;
					_003CfleePlayerData_003E5__1 = new FleePlayerData();
					_003C_003E2__current = (object)new WaitForSeconds(7f);
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

	public static void Init()
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		PickupObject val = ItemSetup.NewItem<SpectreBullets>("Spectre Bullets", "SpoOOOooOOoky!", "These terrifying rounds are modelled after a spirit that shouldn’t even exist.", "spectrebullets_icon", assetbundle: true);
		val.quality = (ItemQuality)3;
		AlexandriaTags.SetTag(val, "bullet_modifier");
		Doug.AddToLootPool(val.PickupObjectId);
	}

	public override void Pickup(PlayerController player)
	{
		((PassiveItem)this).Pickup(player);
		player.PostProcessProjectile += PostProcessProjectile;
	}

	private void PostProcessProjectile(Projectile sourceProjectile, float effectChanceScalar)
	{
		float num = 0.4f;
		float num2 = num * effectChanceScalar;
		if (Random.value < num2)
		{
			sourceProjectile.OnHitEnemy = (Action<Projectile, SpeculativeRigidbody, bool>)Delegate.Combine(sourceProjectile.OnHitEnemy, new Action<Projectile, SpeculativeRigidbody, bool>(AddFearEffect));
		}
	}

	private void AddFearEffect(Projectile arg1, SpeculativeRigidbody arg2, bool arg3)
	{
		if ((Object)(object)arg2 != (Object)null && (Object)(object)((BraveBehaviour)arg2).aiActor != (Object)null && (Object)(object)((PassiveItem)this).Owner != (Object)null && (Object)(object)arg2 != (Object)null && ((BraveBehaviour)arg2).healthHaver.IsAlive && ((BraveBehaviour)arg2).aiActor.EnemyGuid != "465da2bb086a4a88a803f79fe3a27677" && ((BraveBehaviour)arg2).aiActor.EnemyGuid != "05b8afe0b6cc4fffa9dc6036fa24c8ec")
		{
			((MonoBehaviour)this).StartCoroutine(HandleFear(((PassiveItem)this).Owner, arg2));
		}
	}

	private IEnumerator HandleFear(PlayerController user, SpeculativeRigidbody enemy)
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CHandleFear_003Ed__4(0)
		{
			_003C_003E4__this = this,
			user = user,
			enemy = enemy
		};
	}

	public override DebrisObject Drop(PlayerController player)
	{
		DebrisObject result = ((PassiveItem)this).Drop(player);
		player.PostProcessProjectile -= PostProcessProjectile;
		return result;
	}

	public override void OnDestroy()
	{
		if (Object.op_Implicit((Object)(object)((PassiveItem)this).Owner))
		{
			((PassiveItem)this).Owner.PostProcessProjectile -= PostProcessProjectile;
		}
		((PassiveItem)this).OnDestroy();
	}
}
