using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Alexandria.ItemAPI;
using SaveAPI;
using UnityEngine;

namespace NevernamedsItems;

internal class ShotInTheArm : PlayerItem
{
	[CompilerGenerated]
	private sealed class _003CHandleDamageDrainCoroutine_003Ed__2 : IEnumerator<object>, IDisposable, IEnumerator
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public PlayerController coroutineTarget;

		public ShotInTheArm _003C_003E4__this;

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
		public _003CHandleDamageDrainCoroutine_003Ed__2(int _003C_003E1__state)
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
				_003CrealTime_003E5__3 = 3f;
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
				coroutineTarget.stats.RecalculateStats(coroutineTarget, false, false);
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

	public static void Init()
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		PickupObject obj = ItemSetup.NewItem<ShotInTheArm>("Shot In The Arm", "The Jab", "A vial full of volatile stimulant. Briefly buffs offensive power. \n\nUsed by Primerdyne Marines to steady their trigger fingers in active combat.", "shotinthearm_icon", assetbundle: true);
		PlayerItem val = (PlayerItem)(object)((obj is PlayerItem) ? obj : null);
		ItemBuilder.SetCooldownType(val, (CooldownType)0, 7f);
		val.consumable = false;
		((PickupObject)val).quality = (ItemQuality)1;
		ItemBuilder.AddToSubShop((PickupObject)(object)val, (ShopType)3, 1f);
		((PickupObject)(object)val).SetupUnlockOnCustomFlag(CustomDungeonFlags.BOSSRUSH_MARINE, requiredFlagValue: true);
	}

	public override void DoEffect(PlayerController user)
	{
		if (Object.op_Implicit((Object)(object)user))
		{
			((MonoBehaviour)user).StartCoroutine(HandleDamageDrainCoroutine(user));
		}
	}

	private IEnumerator HandleDamageDrainCoroutine(PlayerController coroutineTarget)
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CHandleDamageDrainCoroutine_003Ed__2(0)
		{
			_003C_003E4__this = this,
			coroutineTarget = coroutineTarget
		};
	}
}
