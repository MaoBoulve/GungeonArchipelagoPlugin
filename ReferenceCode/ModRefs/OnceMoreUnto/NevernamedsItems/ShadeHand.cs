using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Alexandria.ItemAPI;
using Alexandria.TranslationAPI;
using UnityEngine;

namespace NevernamedsItems;

internal class ShadeHand : PlayerItem
{
	[CompilerGenerated]
	private sealed class _003CUnstealthy_003Ed__3 : IEnumerator<object>, IDisposable, IEnumerator
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public ShadeHand _003C_003E4__this;

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
		public _003CUnstealthy_003Ed__3(int _003C_003E1__state)
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
				((PlayerItem)_003C_003E4__this).LastOwner.OnDidUnstealthyAction += _003C_003E4__this.BreakStealth;
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

	private float duration = 10f;

	public static void Init()
	{
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Expected O, but got Unknown
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		string text = "Hand of Night";
		GameObject val = new GameObject(text);
		ShadeHand shadeHand = val.AddComponent<ShadeHand>();
		ItemBuilder.AddSpriteToObjectAssetbundle(text, Initialisation.itemCollection.GetSpriteIdByName("shadehand_icon"), Initialisation.itemCollection, val);
		string text2 = "Giveth and Taketh Away";
		string text3 = "The cold and clammy hands of a long-dead, particularly wrathful shade.";
		ItemBuilder.SetupItem((PickupObject)(object)shadeHand, text2, text3, "nn");
		ItemBuilder.SetCooldownType((PlayerItem)(object)shadeHand, (CooldownType)1, 800f);
		((PlayerItem)shadeHand).consumable = false;
		((PickupObject)shadeHand).quality = (ItemQuality)(-100);
		((PickupObject)shadeHand).CanBeDropped = false;
		TranslationManager.TranslateItemName((PickupObject)(object)shadeHand, (GungeonSupportedLanguages)9, "Рука Ночи");
		TranslationManager.TranslateItemShortDescription((PickupObject)(object)shadeHand, (GungeonSupportedLanguages)9, "Даёт и Забирает");
		TranslationManager.TranslateItemLongDescription((PickupObject)(object)shadeHand, (GungeonSupportedLanguages)9, "Холодные и липкие руки давно сгинувшей и особенно яростной тени.");
	}

	public override void DoEffect(PlayerController user)
	{
		StealthEffect();
		((MonoBehaviour)this).StartCoroutine(ItemBuilder.HandleDuration((PlayerItem)(object)this, duration, user, (Action<PlayerController>)BreakStealth));
	}

	private void StealthEffect()
	{
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Expected O, but got Unknown
		PlayerController lastOwner = base.LastOwner;
		BreakStealth(lastOwner);
		lastOwner.OnItemStolen += BreakStealthOnSteal;
		lastOwner.ChangeSpecialShaderFlag(1, 1f);
		((BraveBehaviour)lastOwner).healthHaver.OnDamaged += new OnDamagedEvent(OnDamaged);
		((GameActor)lastOwner).SetIsStealthed(true, "shade");
		lastOwner.SetCapableOfStealing(true, "shade", (float?)null);
		((MonoBehaviour)GameManager.Instance).StartCoroutine(Unstealthy());
	}

	private IEnumerator Unstealthy()
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CUnstealthy_003Ed__3(0)
		{
			_003C_003E4__this = this
		};
	}

	private void OnDamaged(float resultValue, float maxValue, CoreDamageTypes damageTypes, DamageCategory damageCategory, Vector2 damageDirection)
	{
		BreakStealth(base.LastOwner);
	}

	private void BreakStealthOnSteal(PlayerController arg1, ShopItemController arg2)
	{
		BreakStealth(arg1);
	}

	private void BreakStealth(PlayerController player)
	{
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Expected O, but got Unknown
		player.ChangeSpecialShaderFlag(1, 0f);
		player.OnItemStolen -= BreakStealthOnSteal;
		((GameActor)player).SetIsStealthed(false, "shade");
		((BraveBehaviour)player).healthHaver.OnDamaged -= new OnDamagedEvent(OnDamaged);
		player.SetCapableOfStealing(false, "shade", (float?)null);
		player.OnDidUnstealthyAction -= BreakStealth;
		AkSoundEngine.PostEvent("Play_ENM_wizardred_appear_01", ((Component)this).gameObject);
	}
}
