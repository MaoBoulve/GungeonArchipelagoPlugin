using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Alexandria.ItemAPI;
using SaveAPI;
using UnityEngine;

namespace NevernamedsItems;

public class CloakOfDarkness : PassiveItem
{
	[CompilerGenerated]
	private sealed class _003CUnstealthy_003Ed__6 : IEnumerator<object>, IDisposable, IEnumerator
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public CloakOfDarkness _003C_003E4__this;

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
		public _003CUnstealthy_003Ed__6(int _003C_003E1__state)
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
				((PassiveItem)_003C_003E4__this).Owner.OnDidUnstealthyAction += _003C_003E4__this.BreakStealth;
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

	private float particleCounter;

	public static void Init()
	{
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		PickupObject obj = ItemSetup.NewItem<CloakOfDarkness>("Cloak of Darkness", "Shrouded in Mystery", "Temporarily fools the Jammed by robing you in the shadows typical of their lord.\nAlso occasionally allows one to themselves become a shadow.", "cloakofdarkness_icon", assetbundle: true);
		PassiveItem val = (PassiveItem)(object)((obj is PassiveItem) ? obj : null);
		((PickupObject)val).quality = (ItemQuality)5;
		ItemBuilder.AddPassiveStatModifier((PickupObject)(object)val, (StatType)14, 2f, (ModifyMethod)0);
		((PickupObject)(object)val).SetupUnlockOnCustomFlag(CustomDungeonFlags.ALLJAMMED_BEATEN_FORGE, requiredFlagValue: true);
	}

	public void AIActorMods(AIActor target)
	{
		if (!Object.op_Implicit((Object)(object)target) || !target.IsBlackPhantom || !Object.op_Implicit((Object)(object)((BraveBehaviour)target).healthHaver) || ((BraveBehaviour)target).healthHaver.IsBoss)
		{
			return;
		}
		float num = 1f;
		if (AllJammedState.AllJammedActive)
		{
			num = 0.5f;
		}
		if (Random.value <= num)
		{
			GameActorCharmEffect val = StatusEffectHelper.GenerateCharmEffect(13f);
			((GameActor)target).ApplyEffect((GameActorEffect)(object)val, 1f, (Projectile)null);
			if (Random.value <= 0.5f)
			{
				AdvancedKillOnRoomClear advancedKillOnRoomClear = ((Component)target).gameObject.AddComponent<AdvancedKillOnRoomClear>();
				advancedKillOnRoomClear.triggersOnRoomUnseal = true;
			}
		}
	}

	public override void Update()
	{
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		if (Object.op_Implicit((Object)(object)((PassiveItem)this).Owner))
		{
			particleCounter += BraveTime.DeltaTime * 40f;
			if (particleCounter > 1f)
			{
				int num = Mathf.FloorToInt(particleCounter);
				particleCounter %= 1f;
				GlobalSparksDoer.DoRandomParticleBurst(num, Vector2Extensions.ToVector3ZisY(((BraveBehaviour)((PassiveItem)this).Owner).sprite.WorldBottomLeft, 0f), Vector2Extensions.ToVector3ZisY(((BraveBehaviour)((PassiveItem)this).Owner).sprite.WorldTopRight, 0f), Vector3.up, 90f, 0.5f, (float?)null, (float?)null, (Color?)null, (SparksType)1);
			}
		}
		((PassiveItem)this).Update();
	}

	private void EnteredCombat()
	{
		if (Random.value <= 0.5f || CustomSynergies.PlayerHasActiveSynergy(((PassiveItem)this).Owner, "Cloak and Mirrors"))
		{
			StealthEffect();
		}
	}

	private void StealthEffect()
	{
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Expected O, but got Unknown
		PlayerController owner = ((PassiveItem)this).Owner;
		BreakStealth(owner);
		owner.OnItemStolen += BreakStealthOnSteal;
		owner.ChangeSpecialShaderFlag(1, 1f);
		((BraveBehaviour)owner).healthHaver.OnDamaged += new OnDamagedEvent(OnDamaged);
		((GameActor)owner).SetIsStealthed(true, "cloak of darkness");
		owner.SetCapableOfStealing(true, "cloak of darkness", (float?)null);
		((MonoBehaviour)GameManager.Instance).StartCoroutine(Unstealthy());
	}

	private IEnumerator Unstealthy()
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CUnstealthy_003Ed__6(0)
		{
			_003C_003E4__this = this
		};
	}

	private void OnDamaged(float resultValue, float maxValue, CoreDamageTypes damageTypes, DamageCategory damageCategory, Vector2 damageDirection)
	{
		BreakStealth(((PassiveItem)this).Owner);
	}

	private void BreakStealth(PlayerController player)
	{
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Expected O, but got Unknown
		player.ChangeSpecialShaderFlag(1, 0f);
		player.OnItemStolen -= BreakStealthOnSteal;
		((GameActor)player).SetIsStealthed(false, "cloak of darkness");
		((BraveBehaviour)player).healthHaver.OnDamaged -= new OnDamagedEvent(OnDamaged);
		player.SetCapableOfStealing(false, "cloak of darkness", (float?)null);
		player.OnDidUnstealthyAction -= BreakStealth;
		AkSoundEngine.PostEvent("Play_ENM_wizardred_appear_01", ((Component)this).gameObject);
	}

	private void BreakStealthOnSteal(PlayerController arg1, ShopItemController arg2)
	{
		BreakStealth(arg1);
	}

	public override void Pickup(PlayerController player)
	{
		player.OnEnteredCombat = (Action)Delegate.Combine(player.OnEnteredCombat, new Action(EnteredCombat));
		((PassiveItem)this).Pickup(player);
		AIActor.OnPostStart = (Action<AIActor>)Delegate.Combine(AIActor.OnPostStart, new Action<AIActor>(AIActorMods));
	}

	public override DebrisObject Drop(PlayerController player)
	{
		player.OnEnteredCombat = (Action)Delegate.Remove(player.OnEnteredCombat, new Action(EnteredCombat));
		DebrisObject result = ((PassiveItem)this).Drop(player);
		AIActor.OnPostStart = (Action<AIActor>)Delegate.Remove(AIActor.OnPostStart, new Action<AIActor>(AIActorMods));
		return result;
	}

	public override void OnDestroy()
	{
		if (Object.op_Implicit((Object)(object)((PassiveItem)this).Owner))
		{
			PlayerController owner = ((PassiveItem)this).Owner;
			owner.OnEnteredCombat = (Action)Delegate.Remove(owner.OnEnteredCombat, new Action(EnteredCombat));
		}
		AIActor.OnPostStart = (Action<AIActor>)Delegate.Remove(AIActor.OnPostStart, new Action<AIActor>(AIActorMods));
		((PassiveItem)this).OnDestroy();
	}
}
