using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Alexandria.ItemAPI;
using UnityEngine;

namespace NevernamedsItems;

public class HeartBox : PassiveItem
{
	[CompilerGenerated]
	private sealed class _003CUnstealthy_003Ed__7 : IEnumerator<object>, IDisposable, IEnumerator
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public PlayerController player;

		public HeartBox _003C_003E4__this;

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
		public _003CUnstealthy_003Ed__7(int _003C_003E1__state)
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
				_003C_003E2__current = (object)new WaitForSeconds(0.15f);
				_003C_003E1__state = 1;
				return true;
			case 1:
				_003C_003E1__state = -1;
				player.OnDidUnstealthyAction += _003C_003E4__this.BreakStealth;
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

	public static int ID;

	public static void Init()
	{
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		PickupObject val = ItemSetup.NewItem<HeartBox>("Heart Box", "High Capacity", "Left over from a bulk shipment of heart pickups ordered by the Gungeon Acquisitions Department. \n\nCan store all sorts of things!", "heartbox_icon", assetbundle: true);
		ItemBuilder.AddPassiveStatModifier(val, (StatType)3, 1f, (ModifyMethod)0);
		ItemBuilder.AddPassiveStatModifier(val, (StatType)8, 1f, (ModifyMethod)0);
		ItemBuilder.AddPassiveStatModifier(val, (StatType)9, 1.25f, (ModifyMethod)1);
		val.quality = (ItemQuality)3;
		val.ItemSpansBaseQualityTiers = true;
		val.ItemRespectsHeartMagnificence = true;
		ID = val.PickupObjectId;
	}

	public override void Pickup(PlayerController player)
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Expected O, but got Unknown
		((BraveBehaviour)player).healthHaver.OnDamaged += new OnDamagedEvent(OnDamaged);
		((PassiveItem)this).Pickup(player);
	}

	public override void DisableEffect(PlayerController player)
	{
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Expected O, but got Unknown
		if (Object.op_Implicit((Object)(object)player))
		{
			if (((GameActor)player).IsStealthed)
			{
				BreakStealth(player);
			}
			((BraveBehaviour)player).healthHaver.OnDamaged -= new OnDamagedEvent(OnDamaged);
		}
		((PassiveItem)this).DisableEffect(player);
	}

	private void OnDamaged(float resultValue, float maxValue, CoreDamageTypes damageTypes, DamageCategory damageCategory, Vector2 damageDirection)
	{
		if (Object.op_Implicit((Object)(object)((PassiveItem)this).Owner) && CustomSynergies.PlayerHasActiveSynergy(((PassiveItem)this).Owner, "Sleepin In a Cardboard Box"))
		{
			StealthEffect(((PassiveItem)this).Owner);
		}
	}

	private void StealthEffect(PlayerController player)
	{
		BreakStealth(player);
		player.OnItemStolen += BreakStealthOnSteal;
		player.ChangeSpecialShaderFlag(1, 1f);
		((GameActor)player).SetIsStealthed(true, "heartbox");
		player.SetCapableOfStealing(true, "heartbox", (float?)null);
		((MonoBehaviour)GameManager.Instance).StartCoroutine(Unstealthy(player));
	}

	private void BreakStealth(PlayerController player)
	{
		player.ChangeSpecialShaderFlag(1, 0f);
		player.OnItemStolen -= BreakStealthOnSteal;
		((GameActor)player).SetIsStealthed(false, "heartbox");
		player.SetCapableOfStealing(false, "heartbox", (float?)null);
		player.OnDidUnstealthyAction -= BreakStealth;
		AkSoundEngine.PostEvent("Play_ENM_wizardred_appear_01", ((Component)this).gameObject);
	}

	private IEnumerator Unstealthy(PlayerController player)
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CUnstealthy_003Ed__7(0)
		{
			_003C_003E4__this = this,
			player = player
		};
	}

	private void BreakStealthOnSteal(PlayerController arg1, ShopItemController arg2)
	{
		BreakStealth(arg1);
	}
}
