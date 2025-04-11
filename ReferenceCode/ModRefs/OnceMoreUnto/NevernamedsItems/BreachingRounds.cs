using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Alexandria.ItemAPI;
using UnityEngine;

namespace NevernamedsItems;

public class BreachingRounds : PassiveItem
{
	[CompilerGenerated]
	private sealed class _003CHandleDamageDrainCoroutine_003Ed__4 : IEnumerator<object>, IDisposable, IEnumerator
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public PlayerController coroutineTarget;

		public BreachingRounds _003C_003E4__this;

		private float _003Cmultiplier_003E5__1;

		private float _003CscaleMult_003E5__2;

		private float _003CrealTime_003E5__3;

		private float _003Celapsed_003E5__4;

		private float _003Ct_003E5__5;

		private float _003Cdamagemodifier_003E5__6;

		private float _003CscaleMod_003E5__7;

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
		public _003CHandleDamageDrainCoroutine_003Ed__4(int _003C_003E1__state)
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
				_003Cmultiplier_003E5__1 = 3.5f;
				_003CscaleMult_003E5__2 = 2f;
				_003CrealTime_003E5__3 = 7.5f;
				_003Celapsed_003E5__4 = 0f;
				break;
			case 1:
				_003C_003E1__state = -1;
				break;
			}
			if (_003Celapsed_003E5__4 < _003CrealTime_003E5__3)
			{
				_003Celapsed_003E5__4 += BraveTime.DeltaTime;
				_003Ct_003E5__5 = Mathf.Clamp01(_003Celapsed_003E5__4 / _003CrealTime_003E5__3);
				_003Cdamagemodifier_003E5__6 = Mathf.Lerp(_003Cmultiplier_003E5__1, 1f, _003Ct_003E5__5);
				_003CscaleMod_003E5__7 = Mathf.Lerp(_003CscaleMult_003E5__2, 1f, _003Ct_003E5__5);
				ItemBuilder.RemovePassiveStatModifier((PickupObject)(object)_003C_003E4__this, (StatType)5);
				ItemBuilder.RemovePassiveStatModifier((PickupObject)(object)_003C_003E4__this, (StatType)15);
				ItemBuilder.AddPassiveStatModifier((PickupObject)(object)_003C_003E4__this, (StatType)5, _003Cdamagemodifier_003E5__6, (ModifyMethod)1);
				ItemBuilder.AddPassiveStatModifier((PickupObject)(object)_003C_003E4__this, (StatType)15, _003CscaleMod_003E5__7, (ModifyMethod)1);
				if (Object.op_Implicit((Object)(object)((PassiveItem)_003C_003E4__this).Owner))
				{
					((PassiveItem)_003C_003E4__this).Owner.stats.RecalculateStats(((PassiveItem)_003C_003E4__this).Owner, false, false);
				}
				_003C_003E2__current = null;
				_003C_003E1__state = 1;
				return true;
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

	public static int ID;

	public static void Init()
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		PickupObject val = ItemSetup.NewItem<BreachingRounds>("Breaching Rounds", "Breach and Clear", "Gives a damage boost upon entering combat, which quickly deteriorates over time. Speed is key.\n\nUsed by ancient dungeon crawlers to blast open locks and hidden walls, though the Gungeon's secret rooms are a little too tough for that.", "breachrounds_icon", assetbundle: true);
		val.quality = (ItemQuality)2;
		AlexandriaTags.SetTag(val, "bullet_modifier");
		ItemBuilder.AddToSubShop(val, (ShopType)3, 1f);
		ID = val.PickupObjectId;
		Doug.AddToLootPool(val.PickupObjectId);
	}

	public override void Pickup(PlayerController player)
	{
		((PassiveItem)this).Pickup(player);
		player.OnEnteredCombat = (Action)Delegate.Combine(player.OnEnteredCombat, new Action(EnteredCombat));
	}

	private void EnteredCombat()
	{
		if (Object.op_Implicit((Object)(object)((PassiveItem)this).Owner))
		{
			((MonoBehaviour)((PassiveItem)this).Owner).StopCoroutine(HandleDamageDrainCoroutine(((PassiveItem)this).Owner));
			ItemBuilder.RemovePassiveStatModifier((PickupObject)(object)this, (StatType)5);
			ItemBuilder.RemovePassiveStatModifier((PickupObject)(object)this, (StatType)15);
			((MonoBehaviour)((PassiveItem)this).Owner).StartCoroutine(HandleDamageDrainCoroutine(((PassiveItem)this).Owner));
		}
	}

	private IEnumerator HandleDamageDrainCoroutine(PlayerController coroutineTarget)
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CHandleDamageDrainCoroutine_003Ed__4(0)
		{
			_003C_003E4__this = this,
			coroutineTarget = coroutineTarget
		};
	}

	public override DebrisObject Drop(PlayerController player)
	{
		DebrisObject result = ((PassiveItem)this).Drop(player);
		player.OnEnteredCombat = (Action)Delegate.Remove(player.OnEnteredCombat, new Action(EnteredCombat));
		return result;
	}

	public override void OnDestroy()
	{
		if (Object.op_Implicit((Object)(object)((PassiveItem)this).Owner))
		{
			PlayerController owner = ((PassiveItem)this).Owner;
			owner.OnEnteredCombat = (Action)Delegate.Remove(owner.OnEnteredCombat, new Action(EnteredCombat));
		}
		((PassiveItem)this).OnDestroy();
	}
}
