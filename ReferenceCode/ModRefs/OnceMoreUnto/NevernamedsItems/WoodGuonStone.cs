using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Alexandria.ItemAPI;
using Alexandria.Misc;
using Dungeonator;
using UnityEngine;

namespace NevernamedsItems;

internal class WoodGuonStone : AdvancedPlayerOrbitalItem
{
	[CompilerGenerated]
	private sealed class _003CHandleDeathTimer_003Ed__5 : IEnumerator<object>, IDisposable, IEnumerator
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public WoodGuonStone _003C_003E4__this;

		private float _003Cseconds_003E5__1;

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
		public _003CHandleDeathTimer_003Ed__5(int _003C_003E1__state)
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
			//IL_005d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0067: Expected O, but got Unknown
			switch (_003C_003E1__state)
			{
			default:
				return false;
			case 0:
				_003C_003E1__state = -1;
				_003Cseconds_003E5__1 = 20f;
				if (CustomSynergies.PlayerHasActiveSynergy(((PassiveItem)_003C_003E4__this).Owner, "Mahoguny Guon Stones"))
				{
					_003Cseconds_003E5__1 *= 2f;
				}
				_003C_003E2__current = (object)new WaitForSeconds(_003Cseconds_003E5__1);
				_003C_003E1__state = 1;
				return true;
			case 1:
				_003C_003E1__state = -1;
				_003C_003E4__this.shouldBeKilledNextOpportunity = true;
				_003C_003E4__this.InstaKillGuon();
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

	public static PlayerOrbital orbitalPrefab;

	public bool shouldBeKilledNextOpportunity;

	public static void Init()
	{
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		PickupObject obj = ItemSetup.NewItem<WoodGuonStone>("Wood Guon Stone", "Fleeting Protection", "Provides brief protection, but destroys itself after a short time.", "woodguon_icon", assetbundle: true);
		AdvancedPlayerOrbitalItem val = (AdvancedPlayerOrbitalItem)(object)((obj is AdvancedPlayerOrbitalItem) ? obj : null);
		((PickupObject)val).quality = (ItemQuality)(-100);
		AlexandriaTags.SetTag((PickupObject)(object)val, "guon_stone");
		val.OrbitalPrefab = ItemSetup.CreateOrbitalObject("Wood Guon Stone", "woodguon_ingame", new IntVector2(9, 9), new IntVector2(-4, -5), null, 2.5f, 120f, 0, (OrbitalMotionStyle)0).GetComponent<PlayerOrbital>();
		((PickupObject)val).CanBeDropped = false;
	}

	public override void Pickup(PlayerController player)
	{
		((AdvancedPlayerOrbitalItem)this).Pickup(player);
		((MonoBehaviour)this).StartCoroutine(HandleDeathTimer());
	}

	public override void Update()
	{
		if (!Dungeon.IsGenerating && Object.op_Implicit((Object)(object)((PassiveItem)this).Owner) && shouldBeKilledNextOpportunity)
		{
			InstaKillGuon();
		}
		((AdvancedPlayerOrbitalItem)this).Update();
	}

	private IEnumerator HandleDeathTimer()
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CHandleDeathTimer_003Ed__5(0)
		{
			_003C_003E4__this = this
		};
	}

	public void InstaKillGuon()
	{
		Object.Destroy((Object)(object)base.m_extantOrbital);
		PlayerUtility.RemoveItemFromInventory(((PassiveItem)this).Owner, (PickupObject)(object)this);
	}
}
