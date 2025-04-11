using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Alexandria.ItemAPI;
using UnityEngine;

namespace NevernamedsItems;

internal class CombatKnife : PlayerItem
{
	[CompilerGenerated]
	private sealed class _003CDoSlash_003Ed__2 : IEnumerator<object>, IDisposable, IEnumerator
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public PlayerController user;

		public float angle;

		public float delay;

		public SlashData slashParameters;

		public CombatKnife _003C_003E4__this;

		private Vector2 _003Cvector_003E5__1;

		private Vector2 _003Cnormalized_003E5__2;

		private Vector2 _003Cdir_003E5__3;

		private float _003CangleToUse_003E5__4;

		private Vector2 _003Cnormalized2_003E5__5;

		private Vector2 _003Cdir2_003E5__6;

		private Vector2 _003Cnormalized3_003E5__7;

		private Vector2 _003Cdir3_003E5__8;

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
		public _003CDoSlash_003Ed__2(int _003C_003E1__state)
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
			//IL_0027: Unknown result type (might be due to invalid IL or missing references)
			//IL_0031: Expected O, but got Unknown
			//IL_005e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0063: Unknown result type (might be due to invalid IL or missing references)
			//IL_006f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0074: Unknown result type (might be due to invalid IL or missing references)
			//IL_007a: Unknown result type (might be due to invalid IL or missing references)
			//IL_007f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0084: Unknown result type (might be due to invalid IL or missing references)
			//IL_0087: Unknown result type (might be due to invalid IL or missing references)
			//IL_008c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0093: Unknown result type (might be due to invalid IL or missing references)
			//IL_009e: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00af: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
			//IL_012e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0138: Unknown result type (might be due to invalid IL or missing references)
			//IL_013d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0149: Unknown result type (might be due to invalid IL or missing references)
			//IL_014f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0159: Unknown result type (might be due to invalid IL or missing references)
			//IL_015e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0163: Unknown result type (might be due to invalid IL or missing references)
			//IL_0169: Unknown result type (might be due to invalid IL or missing references)
			//IL_0199: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a3: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a8: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b4: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ba: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c4: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c9: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ce: Unknown result type (might be due to invalid IL or missing references)
			//IL_01d4: Unknown result type (might be due to invalid IL or missing references)
			switch (_003C_003E1__state)
			{
			default:
				return false;
			case 0:
				_003C_003E1__state = -1;
				_003C_003E2__current = (object)new WaitForSeconds(delay);
				_003C_003E1__state = 1;
				return true;
			case 1:
			{
				_003C_003E1__state = -1;
				AkSoundEngine.PostEvent("Play_WPN_blasphemy_shot_01", ((Component)user).gameObject);
				_003Cvector_003E5__1 = ((GameActor)user).CenterPosition;
				Vector2 val = Vector3Extensions.XY(user.unadjustedAimPoint) - _003Cvector_003E5__1;
				_003Cnormalized_003E5__2 = ((Vector2)(ref val)).normalized;
				_003Cnormalized_003E5__2 = Vector2Extensions.Rotate(_003Cnormalized_003E5__2, angle);
				_003Cdir_003E5__3 = ((GameActor)user).CenterPosition + _003Cnormalized_003E5__2 * 0.75f;
				_003CangleToUse_003E5__4 = ((GameActor)user).CurrentGun.CurrentAngle + angle;
				SlashDoer.DoSwordSlash(_003Cdir_003E5__3, _003CangleToUse_003E5__4, (GameActor)(object)user, slashParameters, ((BraveBehaviour)user).transform);
				if (CustomSynergies.PlayerHasActiveSynergy(user, "Tri-Tip Dagger"))
				{
					_003Cnormalized2_003E5__5 = Vector2Extensions.Rotate(_003Cnormalized_003E5__2, 45f);
					_003Cdir2_003E5__6 = ((GameActor)user).CenterPosition + _003Cnormalized2_003E5__5 * 0.75f;
					SlashDoer.DoSwordSlash(_003Cdir2_003E5__6, _003CangleToUse_003E5__4 + 45f, (GameActor)(object)user, slashParameters, ((BraveBehaviour)user).transform);
					_003Cnormalized3_003E5__7 = Vector2Extensions.Rotate(_003Cnormalized_003E5__2, -45f);
					_003Cdir3_003E5__8 = ((GameActor)user).CenterPosition + _003Cnormalized3_003E5__7 * 0.75f;
					SlashDoer.DoSwordSlash(_003Cdir3_003E5__8, _003CangleToUse_003E5__4 + -45f, (GameActor)(object)user, slashParameters, ((BraveBehaviour)user).transform);
				}
				return false;
			}
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
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		PickupObject obj = ItemSetup.NewItem<CombatKnife>("Combat Knife", "Quiet and Always Available", "In the galaxy at large, knife kills are considered demonstrations of extreme skill, and many bounty hunters, soldiers, and general vagabonds often forego more effective weaponry in hopes of gaining that prestige.", "combatknife_icon", assetbundle: true);
		PlayerItem val = (PlayerItem)(object)((obj is PlayerItem) ? obj : null);
		ItemBuilder.SetCooldownType(val, (CooldownType)0, 3f);
		ItemBuilder.AddPassiveStatModifier((PickupObject)(object)val, (StatType)14, 1f, (ModifyMethod)0);
		val.consumable = false;
		((PickupObject)val).quality = (ItemQuality)1;
	}

	public override void DoEffect(PlayerController user)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Expected O, but got Unknown
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		SlashData val = new SlashData();
		val.damage = 30f * user.stats.GetStatValue((StatType)5);
		val.enemyKnockbackForce = 10f * user.stats.GetStatValue((StatType)12);
		val.projInteractMode = (ProjInteractMode)0;
		List<GameActorEffect> list = null;
		if (CustomSynergies.PlayerHasActiveSynergy(user, "1000 Degree Knife"))
		{
			list = new List<GameActorEffect>();
			list.Add((GameActorEffect)(object)StaticStatusEffects.hotLeadEffect);
		}
		val.statusEffects = list;
		if (CustomSynergies.PlayerHasActiveSynergy(user, "Mirror Blade"))
		{
			val.projInteractMode = (ProjInteractMode)2;
		}
		if (CustomSynergies.PlayerHasActiveSynergy(user, "Tri-Tip Dagger"))
		{
			val.enemyKnockbackForce /= 3f;
		}
		if (CustomSynergies.PlayerHasActiveSynergy(user, "Whirling Blade"))
		{
			val.enemyKnockbackForce = 0f;
		}
		((MonoBehaviour)user).StartCoroutine(DoSlash(user, 0f, 0f, val));
		if (CustomSynergies.PlayerHasActiveSynergy(user, "Whirling Blade"))
		{
			((MonoBehaviour)user).StartCoroutine(DoSlash(user, 90f, 0.25f, val));
			((MonoBehaviour)user).StartCoroutine(DoSlash(user, 180f, 0.5f, val));
			((MonoBehaviour)user).StartCoroutine(DoSlash(user, 270f, 0.75f, val));
		}
	}

	private IEnumerator DoSlash(PlayerController user, float angle, float delay, SlashData slashParameters)
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CDoSlash_003Ed__2(0)
		{
			_003C_003E4__this = this,
			user = user,
			angle = angle,
			delay = delay,
			slashParameters = slashParameters
		};
	}
}
