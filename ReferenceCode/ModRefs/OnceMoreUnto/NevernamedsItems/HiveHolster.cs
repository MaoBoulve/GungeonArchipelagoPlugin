using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace NevernamedsItems;

public class HiveHolster : PassiveItem
{
	[CompilerGenerated]
	private sealed class _003CHandleBees_003Ed__3 : IEnumerator<object>, IDisposable, IEnumerator
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public PlayerController player;

		public HiveHolster _003C_003E4__this;

		private int _003CbeesToSpawn_003E5__1;

		private int _003Ci_003E5__2;

		private Projectile _003Cprojectile_003E5__3;

		private GameObject _003CgameObject_003E5__4;

		private Projectile _003Ccomponent_003E5__5;

		private Projectile _003Cprojectile_003E5__6;

		private GameObject _003CgameObject_003E5__7;

		private Projectile _003Ccomponent_003E5__8;

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
		public _003CHandleBees_003Ed__3(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			_003Cprojectile_003E5__3 = null;
			_003CgameObject_003E5__4 = null;
			_003Ccomponent_003E5__5 = null;
			_003Cprojectile_003E5__6 = null;
			_003CgameObject_003E5__7 = null;
			_003Ccomponent_003E5__8 = null;
			_003C_003E1__state = -2;
		}

		private bool MoveNext()
		{
			//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ed: Unknown result type (might be due to invalid IL or missing references)
			//IL_0130: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c4: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ce: Expected O, but got Unknown
			//IL_0262: Unknown result type (might be due to invalid IL or missing references)
			//IL_0298: Unknown result type (might be due to invalid IL or missing references)
			//IL_029d: Unknown result type (might be due to invalid IL or missing references)
			//IL_02e0: Unknown result type (might be due to invalid IL or missing references)
			switch (_003C_003E1__state)
			{
			default:
				return false;
			case 0:
				_003C_003E1__state = -1;
				_003CbeesToSpawn_003E5__1 = 5;
				if (((PassiveItem)_003C_003E4__this).Owner.HasPickupID(14) || ((PassiveItem)_003C_003E4__this).Owner.HasPickupID(432) || ((PassiveItem)_003C_003E4__this).Owner.HasPickupID(138) || ((PassiveItem)_003C_003E4__this).Owner.HasPickupID(630))
				{
					_003CbeesToSpawn_003E5__1 += 2;
				}
				_003Ci_003E5__2 = 0;
				break;
			case 1:
				_003C_003E1__state = -1;
				_003Cprojectile_003E5__3 = null;
				_003CgameObject_003E5__4 = null;
				_003Ccomponent_003E5__5 = null;
				_003Ci_003E5__2++;
				break;
			}
			if (_003Ci_003E5__2 < _003CbeesToSpawn_003E5__1)
			{
				_003Cprojectile_003E5__3 = ((Gun)Databases.Items[14]).DefaultModule.projectiles[0];
				_003CgameObject_003E5__4 = SpawnManager.SpawnProjectile(((Component)_003Cprojectile_003E5__3).gameObject, Vector2.op_Implicit(((BraveBehaviour)((PassiveItem)_003C_003E4__this).Owner).sprite.WorldCenter), Quaternion.Euler(0f, 0f, ((Object)(object)((GameActor)((PassiveItem)_003C_003E4__this).Owner).CurrentGun == (Object)null) ? 0f : ((GameActor)((PassiveItem)_003C_003E4__this).Owner).CurrentGun.CurrentAngle), true);
				_003Ccomponent_003E5__5 = _003CgameObject_003E5__4.GetComponent<Projectile>();
				if ((Object)(object)_003Ccomponent_003E5__5 != (Object)null)
				{
					_003Ccomponent_003E5__5.Owner = (GameActor)(object)((PassiveItem)_003C_003E4__this).Owner;
					_003Ccomponent_003E5__5.Shooter = ((BraveBehaviour)((PassiveItem)_003C_003E4__this).Owner).specRigidbody;
					_003Ccomponent_003E5__5.baseData.damage = 3f * player.stats.GetStatValue((StatType)5);
				}
				_003C_003E2__current = (object)new WaitForSeconds(0.1f);
				_003C_003E1__state = 1;
				return true;
			}
			if (((PassiveItem)_003C_003E4__this).Owner.HasPickupID(92) && ((PickupObject)((GameActor)((PassiveItem)_003C_003E4__this).Owner).CurrentGun).PickupObjectId == 92)
			{
				_003Cprojectile_003E5__6 = ((Gun)Databases.Items[92]).DefaultModule.projectiles[0];
				_003CgameObject_003E5__7 = SpawnManager.SpawnProjectile(((Component)_003Cprojectile_003E5__6).gameObject, Vector2.op_Implicit(((BraveBehaviour)((PassiveItem)_003C_003E4__this).Owner).sprite.WorldCenter), Quaternion.Euler(0f, 0f, ((Object)(object)((GameActor)((PassiveItem)_003C_003E4__this).Owner).CurrentGun == (Object)null) ? 0f : ((GameActor)((PassiveItem)_003C_003E4__this).Owner).CurrentGun.CurrentAngle), true);
				_003Ccomponent_003E5__8 = _003CgameObject_003E5__7.GetComponent<Projectile>();
				if ((Object)(object)_003Ccomponent_003E5__8 != (Object)null)
				{
					_003Ccomponent_003E5__8.Owner = (GameActor)(object)((PassiveItem)_003C_003E4__this).Owner;
					_003Ccomponent_003E5__8.Shooter = ((BraveBehaviour)((PassiveItem)_003C_003E4__this).Owner).specRigidbody;
					ProjectileData baseData = _003Ccomponent_003E5__8.baseData;
					baseData.speed *= 2f;
					_003Ccomponent_003E5__8.baseData.damage = 10f * player.stats.GetStatValue((StatType)5);
				}
				_003Cprojectile_003E5__6 = null;
				_003CgameObject_003E5__7 = null;
				_003Ccomponent_003E5__8 = null;
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

	public bool canActivate = true;

	public static void Init()
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		PickupObject val = ItemSetup.NewItem<HiveHolster>("Hive Holster", "Beeload", "A small hive of bees seems to have taken up residence in this old holster.\n\nBears striking resemblance to THE Hive Holster, that sits on the hip of the legendary Gunstinger. But it couldn't be THAT one... right?", "hiveholster_icon", assetbundle: true);
		val.quality = (ItemQuality)3;
	}

	private void HandleGunReloaded(PlayerController player, Gun playerGun)
	{
		if (playerGun.ClipShotsRemaining == 0 && canActivate)
		{
			((MonoBehaviour)this).StartCoroutine(HandleBees(player));
			canActivate = false;
			((MonoBehaviour)this).Invoke("Reset", 2f);
		}
	}

	private IEnumerator HandleBees(PlayerController player)
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CHandleBees_003Ed__3(0)
		{
			_003C_003E4__this = this,
			player = player
		};
	}

	private void Reset()
	{
		canActivate = true;
	}

	public override void Pickup(PlayerController player)
	{
		((PassiveItem)this).Pickup(player);
		player.OnReloadedGun = (Action<PlayerController, Gun>)Delegate.Combine(player.OnReloadedGun, new Action<PlayerController, Gun>(HandleGunReloaded));
	}

	public override DebrisObject Drop(PlayerController player)
	{
		DebrisObject result = ((PassiveItem)this).Drop(player);
		player.OnReloadedGun = (Action<PlayerController, Gun>)Delegate.Remove(player.OnReloadedGun, new Action<PlayerController, Gun>(HandleGunReloaded));
		return result;
	}

	public override void OnDestroy()
	{
		if (Object.op_Implicit((Object)(object)((PassiveItem)this).Owner))
		{
			PlayerController owner = ((PassiveItem)this).Owner;
			owner.OnReloadedGun = (Action<PlayerController, Gun>)Delegate.Remove(owner.OnReloadedGun, new Action<PlayerController, Gun>(HandleGunReloaded));
		}
		((PassiveItem)this).OnDestroy();
	}
}
