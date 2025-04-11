using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Alexandria.ItemAPI;
using UnityEngine;

namespace NevernamedsItems;

internal class VenusianBars : PlayerItem
{
	[CompilerGenerated]
	private sealed class _003CHandleTimedStatModifier_003Ed__2 : IEnumerator<object>, IDisposable, IEnumerator
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public PlayerController player;

		public VenusianBars _003C_003E4__this;

		private StatModifier _003CfirerateMod_003E5__1;

		private StatModifier _003CchargeMod_003E5__2;

		private StatModifier _003CreloadMod_003E5__3;

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
		public _003CHandleTimedStatModifier_003Ed__2(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			_003CfirerateMod_003E5__1 = null;
			_003CchargeMod_003E5__2 = null;
			_003CreloadMod_003E5__3 = null;
			_003C_003E1__state = -2;
		}

		private bool MoveNext()
		{
			//IL_0024: Unknown result type (might be due to invalid IL or missing references)
			//IL_0029: Unknown result type (might be due to invalid IL or missing references)
			//IL_0034: Unknown result type (might be due to invalid IL or missing references)
			//IL_0036: Unknown result type (might be due to invalid IL or missing references)
			//IL_003b: Unknown result type (might be due to invalid IL or missing references)
			//IL_003d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0047: Expected O, but got Unknown
			//IL_0048: Unknown result type (might be due to invalid IL or missing references)
			//IL_004d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0058: Unknown result type (might be due to invalid IL or missing references)
			//IL_005b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0060: Unknown result type (might be due to invalid IL or missing references)
			//IL_0062: Unknown result type (might be due to invalid IL or missing references)
			//IL_006c: Expected O, but got Unknown
			//IL_006d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0072: Unknown result type (might be due to invalid IL or missing references)
			//IL_007d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0080: Unknown result type (might be due to invalid IL or missing references)
			//IL_0085: Unknown result type (might be due to invalid IL or missing references)
			//IL_0087: Unknown result type (might be due to invalid IL or missing references)
			//IL_0091: Expected O, but got Unknown
			//IL_00f5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ff: Expected O, but got Unknown
			switch (_003C_003E1__state)
			{
			default:
				return false;
			case 0:
				_003C_003E1__state = -1;
				_003CfirerateMod_003E5__1 = new StatModifier
				{
					amount = 100f,
					statToBoost = (StatType)1,
					modifyType = (ModifyMethod)1
				};
				_003CchargeMod_003E5__2 = new StatModifier
				{
					amount = 100f,
					statToBoost = (StatType)25,
					modifyType = (ModifyMethod)1
				};
				_003CreloadMod_003E5__3 = new StatModifier
				{
					amount = 0.01f,
					statToBoost = (StatType)10,
					modifyType = (ModifyMethod)1
				};
				player.ownerlessStatModifiers.Add(_003CfirerateMod_003E5__1);
				player.ownerlessStatModifiers.Add(_003CchargeMod_003E5__2);
				player.ownerlessStatModifiers.Add(_003CreloadMod_003E5__3);
				player.stats.RecalculateStats(player, false, false);
				_003C_003E2__current = (object)new WaitForSeconds(10f);
				_003C_003E1__state = 1;
				return true;
			case 1:
				_003C_003E1__state = -1;
				player.ownerlessStatModifiers.Remove(_003CfirerateMod_003E5__1);
				player.ownerlessStatModifiers.Remove(_003CchargeMod_003E5__2);
				player.ownerlessStatModifiers.Remove(_003CreloadMod_003E5__3);
				player.stats.RecalculateStats(player, false, false);
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
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		PickupObject obj = ItemSetup.NewItem<VenusianBars>("Venusian Bars", "Verified", "A charm forged out of pure, condensed talent by the one and only Gun God. While it doesn't allow the bearer to come even close to matching his skillz, they can still spit some mad bars and bullets.\nWorks best on Automatic weapons.\n\n\n\nPop Pop.", "venusianbars_icon", assetbundle: true);
		PlayerItem val = (PlayerItem)(object)((obj is PlayerItem) ? obj : null);
		ItemBuilder.SetCooldownType(val, (CooldownType)1, 1000f);
		ItemBuilder.AddPassiveStatModifier((PickupObject)(object)val, (StatType)14, 1f, (ModifyMethod)0);
		ItemBuilder.AddPassiveStatModifier((PickupObject)(object)val, (StatType)4, 1f, (ModifyMethod)0);
		val.consumable = false;
		((PickupObject)val).quality = (ItemQuality)5;
	}

	public override void DoEffect(PlayerController user)
	{
		AkSoundEngine.PostEvent("Play_WPN_LowerCaseR_Bye_GameOver_01", ((Component)this).gameObject);
		((MonoBehaviour)user).StartCoroutine(HandleTimedStatModifier(user));
	}

	private IEnumerator HandleTimedStatModifier(PlayerController player)
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CHandleTimedStatModifier_003Ed__2(0)
		{
			_003C_003E4__this = this,
			player = player
		};
	}
}
