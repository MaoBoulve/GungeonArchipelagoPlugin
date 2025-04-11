using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Alexandria.ItemAPI;
using SaveAPI;
using UnityEngine;

namespace NevernamedsItems;

internal class ShellNecklace : ActiveGunVolleyModificationItem
{
	[CompilerGenerated]
	private sealed class _003CHandleTimedStatModifier_003Ed__8 : IEnumerator<object>, IDisposable, IEnumerator
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public PlayerController player;

		public ShellNecklace necklace;

		private StatModifier _003CaccuracyMod_003E5__1;

		private StatModifier _003CdamageMod_003E5__2;

		private StatModifier _003CfirerateMod_003E5__3;

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
		public _003CHandleTimedStatModifier_003Ed__8(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			_003CaccuracyMod_003E5__1 = null;
			_003CdamageMod_003E5__2 = null;
			_003CfirerateMod_003E5__3 = null;
			_003C_003E1__state = -2;
		}

		private bool MoveNext()
		{
			//IL_0030: Unknown result type (might be due to invalid IL or missing references)
			//IL_0035: Unknown result type (might be due to invalid IL or missing references)
			//IL_0040: Unknown result type (might be due to invalid IL or missing references)
			//IL_0042: Unknown result type (might be due to invalid IL or missing references)
			//IL_0047: Unknown result type (might be due to invalid IL or missing references)
			//IL_0049: Unknown result type (might be due to invalid IL or missing references)
			//IL_0053: Expected O, but got Unknown
			//IL_0054: Unknown result type (might be due to invalid IL or missing references)
			//IL_0059: Unknown result type (might be due to invalid IL or missing references)
			//IL_0064: Unknown result type (might be due to invalid IL or missing references)
			//IL_0066: Unknown result type (might be due to invalid IL or missing references)
			//IL_006b: Unknown result type (might be due to invalid IL or missing references)
			//IL_006d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0077: Expected O, but got Unknown
			//IL_0078: Unknown result type (might be due to invalid IL or missing references)
			//IL_007d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0088: Unknown result type (might be due to invalid IL or missing references)
			//IL_008a: Unknown result type (might be due to invalid IL or missing references)
			//IL_008f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0091: Unknown result type (might be due to invalid IL or missing references)
			//IL_009b: Expected O, but got Unknown
			//IL_00ff: Unknown result type (might be due to invalid IL or missing references)
			//IL_0109: Expected O, but got Unknown
			switch (_003C_003E1__state)
			{
			default:
				return false;
			case 0:
				_003C_003E1__state = -1;
				necklace.isActive = true;
				_003CaccuracyMod_003E5__1 = new StatModifier
				{
					amount = 2f,
					statToBoost = (StatType)2,
					modifyType = (ModifyMethod)1
				};
				_003CdamageMod_003E5__2 = new StatModifier
				{
					amount = 0.33f,
					statToBoost = (StatType)5,
					modifyType = (ModifyMethod)1
				};
				_003CfirerateMod_003E5__3 = new StatModifier
				{
					amount = 0.5f,
					statToBoost = (StatType)1,
					modifyType = (ModifyMethod)1
				};
				player.ownerlessStatModifiers.Add(_003CaccuracyMod_003E5__1);
				player.ownerlessStatModifiers.Add(_003CdamageMod_003E5__2);
				player.ownerlessStatModifiers.Add(_003CfirerateMod_003E5__3);
				player.stats.RecalculateStats(player, false, false);
				_003C_003E2__current = (object)new WaitForSeconds(15f);
				_003C_003E1__state = 1;
				return true;
			case 1:
				_003C_003E1__state = -1;
				player.ownerlessStatModifiers.Remove(_003CaccuracyMod_003E5__1);
				player.ownerlessStatModifiers.Remove(_003CdamageMod_003E5__2);
				player.ownerlessStatModifiers.Remove(_003CfirerateMod_003E5__3);
				player.stats.RecalculateStats(player, false, false);
				if ((Object)(object)necklace != (Object)null)
				{
					necklace.isActive = false;
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

	public static int ID;

	public bool isActive;

	public static void Init()
	{
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		PickupObject obj = ItemSetup.NewItem<ShellNecklace>("Shell Necklace", "One For All", "Makes any gun into a shotgun!\n\nA series of brightly coloured shotgun shells on a string. Upon coming to the Gungeon, less scrupulous travellers were alarmed to learn that the Gundead did not possess ears with which to make a normal necklace- so they made do.", "shellnecklace_icon", assetbundle: true);
		ActiveGunVolleyModificationItem val = (ActiveGunVolleyModificationItem)(object)((obj is ActiveGunVolleyModificationItem) ? obj : null);
		ItemBuilder.SetCooldownType((PlayerItem)(object)val, (CooldownType)1, 600f);
		val.duration = 15f;
		val.DuplicatesOfBaseModule = 5;
		val.DuplicateAngleOffset = 0f;
		((PickupObject)val).quality = (ItemQuality)2;
		ID = ((PickupObject)val).PickupObjectId;
		((PickupObject)(object)val).SetupUnlockOnCustomStat(CustomTrackedStats.BEGGAR_TOTAL_DONATIONS, 74f, (PrerequisiteOperation)2);
	}

	public override void Pickup(PlayerController player)
	{
		player.PostProcessProjectile += PostProcessProj;
		((PlayerItem)this).Pickup(player);
	}

	public override void OnPreDrop(PlayerController user)
	{
		user.PostProcessProjectile -= PostProcessProj;
		((PlayerItem)this).OnPreDrop(user);
	}

	public override void OnDestroy()
	{
		if (Object.op_Implicit((Object)(object)((PlayerItem)this).LastOwner))
		{
			((PlayerItem)this).LastOwner.PostProcessProjectile -= PostProcessProj;
		}
		((ActiveGunVolleyModificationItem)this).OnDestroy();
	}

	private void PostProcessProj(Projectile proj, float f)
	{
		if (((PlayerItem)this).IsActive)
		{
			ProjectileData baseData = proj.baseData;
			baseData.speed *= Random.Range(0.9f, 1.1f);
			proj.UpdateSpeed();
		}
	}

	public override void DoEffect(PlayerController user)
	{
		((MonoBehaviour)user).StartCoroutine(HandleTimedStatModifier(user, this));
		((ActiveGunVolleyModificationItem)this).DoEffect(user);
	}

	private static IEnumerator HandleTimedStatModifier(PlayerController player, ShellNecklace necklace)
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CHandleTimedStatModifier_003Ed__8(0)
		{
			player = player,
			necklace = necklace
		};
	}
}
