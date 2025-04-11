using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Alexandria.ItemAPI;
using SaveAPI;
using UnityEngine;

namespace NevernamedsItems;

internal class SpeedPotion : PlayerItem
{
	[CompilerGenerated]
	private sealed class _003CGainOutline_003Ed__11 : IEnumerator<object>, IDisposable, IEnumerator
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public SpeedPotion _003C_003E4__this;

		private PlayerController _003Cuser_003E5__1;

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
		public _003CGainOutline_003Ed__11(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			_003Cuser_003E5__1 = null;
			_003C_003E1__state = -2;
		}

		private bool MoveNext()
		{
			//IL_0037: Unknown result type (might be due to invalid IL or missing references)
			//IL_0041: Expected O, but got Unknown
			switch (_003C_003E1__state)
			{
			default:
				return false;
			case 0:
				_003C_003E1__state = -1;
				_003Cuser_003E5__1 = ((PlayerItem)_003C_003E4__this).LastOwner;
				_003C_003E2__current = (object)new WaitForSeconds(0.05f);
				_003C_003E1__state = 1;
				return true;
			case 1:
				_003C_003E1__state = -1;
				_003C_003E4__this.EnableVFX(_003Cuser_003E5__1);
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

	[CompilerGenerated]
	private sealed class _003CLoseOutline_003Ed__12 : IEnumerator<object>, IDisposable, IEnumerator
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public SpeedPotion _003C_003E4__this;

		private PlayerController _003Cuser_003E5__1;

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
		public _003CLoseOutline_003Ed__12(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			_003Cuser_003E5__1 = null;
			_003C_003E1__state = -2;
		}

		private bool MoveNext()
		{
			//IL_0037: Unknown result type (might be due to invalid IL or missing references)
			//IL_0041: Expected O, but got Unknown
			switch (_003C_003E1__state)
			{
			default:
				return false;
			case 0:
				_003C_003E1__state = -1;
				_003Cuser_003E5__1 = ((PlayerItem)_003C_003E4__this).LastOwner;
				_003C_003E2__current = (object)new WaitForSeconds(0.05f);
				_003C_003E1__state = 1;
				return true;
			case 1:
				_003C_003E1__state = -1;
				_003C_003E4__this.DisableVFX(_003Cuser_003E5__1);
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

	public static int SpeedPotionID;

	private float movementBuff = -1f;

	private float duration = 15f;

	private bool activeOutline = false;

	public static void Init()
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		PickupObject obj = ItemSetup.NewItem<SpeedPotion>("Speed Potion", "Gotta Go Fast", "This is either made of pure magic, or pure back-alleyway-snowflakes if ya know what I mean.", "speedpotion2_icon", assetbundle: true);
		PlayerItem val = (PlayerItem)(object)((obj is PlayerItem) ? obj : null);
		ItemBuilder.SetCooldownType(val, (CooldownType)1, 500f);
		val.consumable = false;
		((PickupObject)val).quality = (ItemQuality)2;
		ItemBuilder.AddToSubShop((PickupObject)(object)val, (ShopType)0, 1f);
		((PickupObject)(object)val).SetupUnlockOnCustomFlag(CustomDungeonFlags.PURCHASED_SPEEDPOTION, requiredFlagValue: true);
		((PickupObject)(object)val).AddItemToGooptonMetaShop(12, null);
		SpeedPotionID = ((PickupObject)val).PickupObjectId;
	}

	public override void DoEffect(PlayerController user)
	{
		AkSoundEngine.PostEvent("Play_OBJ_power_up_01", ((Component)this).gameObject);
		StartEffect(user);
		((MonoBehaviour)this).StartCoroutine(ItemBuilder.HandleDuration((PlayerItem)(object)this, duration, user, (Action<PlayerController>)EndEffect));
	}

	private void EnableVFX(PlayerController user)
	{
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		Material outlineMaterial = SpriteOutlineManager.GetOutlineMaterial(((BraveBehaviour)user).sprite);
		outlineMaterial.SetColor("_OverrideColor", new Color(70f, 1f, 90f));
	}

	private void DisableVFX(PlayerController user)
	{
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		Material outlineMaterial = SpriteOutlineManager.GetOutlineMaterial(((BraveBehaviour)user).sprite);
		outlineMaterial.SetColor("_OverrideColor", new Color(0f, 0f, 0f));
	}

	private void StartEffect(PlayerController user)
	{
		float baseStatValue = user.stats.GetBaseStatValue((StatType)0);
		float num = baseStatValue * 2f;
		user.stats.SetBaseStatValue((StatType)0, num, user);
		movementBuff = num - baseStatValue;
		EnableVFX(user);
		activeOutline = true;
	}

	private void EndEffect(PlayerController user)
	{
		if (!(movementBuff <= 0f))
		{
			float baseStatValue = user.stats.GetBaseStatValue((StatType)0);
			float num = baseStatValue - movementBuff;
			user.stats.SetBaseStatValue((StatType)0, num, user);
			movementBuff = -1f;
			DisableVFX(user);
			activeOutline = false;
		}
	}

	private void PlayerTookDamage(float resultValue, float maxValue, CoreDamageTypes damageTypes, DamageCategory damageCategory, Vector2 damageDirection)
	{
		if (activeOutline)
		{
			((MonoBehaviour)GameManager.Instance).StartCoroutine(GainOutline());
		}
		else if (!activeOutline)
		{
			((MonoBehaviour)GameManager.Instance).StartCoroutine(LoseOutline());
		}
	}

	private IEnumerator GainOutline()
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CGainOutline_003Ed__11(0)
		{
			_003C_003E4__this = this
		};
	}

	private IEnumerator LoseOutline()
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CLoseOutline_003Ed__12(0)
		{
			_003C_003E4__this = this
		};
	}

	public override void Pickup(PlayerController player)
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Expected O, but got Unknown
		((BraveBehaviour)player).healthHaver.OnDamaged += new OnDamagedEvent(PlayerTookDamage);
		((PlayerItem)this).Pickup(player);
		((PickupObject)this).CanBeDropped = true;
	}

	public override void OnPreDrop(PlayerController user)
	{
		if (((PlayerItem)this).IsCurrentlyActive)
		{
			((PlayerItem)this).IsCurrentlyActive = false;
			EndEffect(user);
		}
	}

	public DebrisObject Drop(PlayerController player)
	{
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Expected O, but got Unknown
		DebrisObject result = ((PlayerItem)this).Drop(player, 4f);
		((BraveBehaviour)player).healthHaver.OnDamaged -= new OnDamagedEvent(PlayerTookDamage);
		((PlayerItem)this).IsCurrentlyActive = false;
		EndEffect(player);
		return result;
	}

	public override void OnDestroy()
	{
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Expected O, but got Unknown
		if (Object.op_Implicit((Object)(object)base.LastOwner))
		{
			((BraveBehaviour)base.LastOwner).healthHaver.OnDamaged -= new OnDamagedEvent(PlayerTookDamage);
			((PlayerItem)this).IsCurrentlyActive = false;
			EndEffect(base.LastOwner);
		}
		((PlayerItem)this).OnDestroy();
	}

	public override bool CanBeUsed(PlayerController user)
	{
		return ((PlayerItem)this).CanBeUsed(user);
	}
}
