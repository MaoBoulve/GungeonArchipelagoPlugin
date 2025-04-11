using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Alexandria.ItemAPI;
using UnityEngine;

namespace NevernamedsItems;

public class GunknightAmulet : PassiveItem
{
	[CompilerGenerated]
	private sealed class _003CHandleEffects_003Ed__2 : IEnumerator<object>, IDisposable, IEnumerator
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public PlayerController player;

		public Gun gun;

		public GunknightAmulet _003C_003E4__this;

		private int _003Ci_003E5__1;

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
		public _003CHandleEffects_003Ed__2(int _003C_003E1__state)
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
				_003C_003E2__current = null;
				_003C_003E1__state = 1;
				return true;
			case 1:
				_003C_003E1__state = -1;
				if (gun.CurrentOwner is PlayerController)
				{
					ref int reference = ref _003Ci_003E5__1;
					GameActor currentOwner = gun.CurrentOwner;
					reference = ((PlayerController)((currentOwner is PlayerController) ? currentOwner : null)).PlayerIDX;
					GameUIRoot.Instance.ForceClearReload(_003Ci_003E5__1);
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

	public static void Init()
	{
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		PickupObject val = ItemSetup.NewItem<GunknightAmulet>("Gunknight Amulet", "Banished Reload", "Chance to skip reload.\n\nThe lost amulet of Cormorant, the Aimless Gunknight. It was given to him by his father, who obtained it from his father before him, and his father before him, and his father before him...", "gunknightamulet_icon", assetbundle: true);
		val.CanBeDropped = true;
		val.quality = (ItemQuality)1;
	}

	private void OnReload(PlayerController player, Gun gun)
	{
		float num = 0.25f;
		if (CustomSynergies.PlayerHasActiveSynergy(player, "Reuknighted"))
		{
			num = 0.5f;
		}
		if (Random.value <= num)
		{
			gun.ForceImmediateReload(false);
			((MonoBehaviour)player).StartCoroutine(HandleEffects(player, gun));
		}
	}

	private IEnumerator HandleEffects(PlayerController player, Gun gun)
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CHandleEffects_003Ed__2(0)
		{
			_003C_003E4__this = this,
			player = player,
			gun = gun
		};
	}

	public override void Pickup(PlayerController player)
	{
		player.OnReloadedGun = (Action<PlayerController, Gun>)Delegate.Combine(player.OnReloadedGun, new Action<PlayerController, Gun>(OnReload));
		((PassiveItem)this).Pickup(player);
	}

	public override DebrisObject Drop(PlayerController player)
	{
		player.OnReloadedGun = (Action<PlayerController, Gun>)Delegate.Remove(player.OnReloadedGun, new Action<PlayerController, Gun>(OnReload));
		return ((PassiveItem)this).Drop(player);
	}
}
