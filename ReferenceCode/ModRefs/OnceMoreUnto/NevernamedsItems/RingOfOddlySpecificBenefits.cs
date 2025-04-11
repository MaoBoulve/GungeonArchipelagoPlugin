using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace NevernamedsItems;

internal class RingOfOddlySpecificBenefits : PassiveItem
{
	[CompilerGenerated]
	private sealed class _003CGainOutline_003Ed__22 : IEnumerator<object>, IDisposable, IEnumerator
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public RingOfOddlySpecificBenefits _003C_003E4__this;

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
		public _003CGainOutline_003Ed__22(int _003C_003E1__state)
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
				_003Cuser_003E5__1 = ((PassiveItem)_003C_003E4__this).Owner;
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
	private sealed class _003CLoseOutline_003Ed__23 : IEnumerator<object>, IDisposable, IEnumerator
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public RingOfOddlySpecificBenefits _003C_003E4__this;

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
		public _003CLoseOutline_003Ed__23(int _003C_003E1__state)
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
				_003Cuser_003E5__1 = ((PassiveItem)_003C_003E4__this).Owner;
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

	private float currentArmour;

	private float lastArmour;

	private float currentCash;

	private float lastCash;

	private float currentGunAmmo;

	private float lastGunAmmo;

	private float currentCurse;

	private float lastCurse;

	private float currentCoolness;

	private float lastCoolness;

	private bool hasRightArmour;

	private bool hasRightCash;

	private bool hasRightGunAmmo;

	private bool curseAndCoolnessMatch;

	private bool activeOutline = false;

	public static void Init()
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		PickupObject val = ItemSetup.NewItem<RingOfOddlySpecificBenefits>("Ring of Oddly Specific Benefits", "Picky Picky", "Gives certain boons in... oddly specific situations.\n\nThis ring was created by the mad wizard Alben Smallbore, though even he has no clue what it actually does.", "ringofoddlyspecificbenefits_icon", assetbundle: true);
		val.quality = (ItemQuality)1;
	}

	public override void Update()
	{
		if (!Object.op_Implicit((Object)(object)((PassiveItem)this).Owner))
		{
			return;
		}
		currentArmour = ((BraveBehaviour)((PassiveItem)this).Owner).healthHaver.Armor;
		currentCash = ((PassiveItem)this).Owner.carriedConsumables.Currency;
		currentGunAmmo = ((GameActor)((PassiveItem)this).Owner).CurrentGun.ammo;
		currentCurse = ((PassiveItem)this).Owner.stats.GetStatValue((StatType)14);
		currentCoolness = ((PassiveItem)this).Owner.stats.GetStatValue((StatType)4);
		if (currentArmour != lastArmour)
		{
			if (currentArmour == 4f)
			{
				hasRightArmour = true;
			}
			else
			{
				hasRightArmour = false;
			}
		}
		if (currentCash != lastCash)
		{
			float num = currentCash % 10f;
			if (num == 4f || num == 8f)
			{
				hasRightCash = true;
			}
			else
			{
				hasRightCash = false;
			}
		}
		if (currentGunAmmo != lastGunAmmo)
		{
			int num2 = (int)((double)currentGunAmmo / Math.Pow(10.0, (int)Math.Floor(Math.Log10(currentGunAmmo))));
			if (num2 == 5)
			{
				hasRightGunAmmo = true;
			}
			else
			{
				hasRightGunAmmo = false;
			}
		}
		if (currentCurse != lastCurse || currentCoolness != lastCoolness)
		{
			if (currentCurse == 0f && currentCoolness == 0f)
			{
				curseAndCoolnessMatch = false;
				return;
			}
			if (currentCurse == currentCoolness)
			{
				curseAndCoolnessMatch = true;
			}
			else
			{
				curseAndCoolnessMatch = false;
			}
		}
		RemoveStat((StatType)5);
		RemoveStat((StatType)0);
		RemoveStat((StatType)6);
		RemoveStat((StatType)10);
		DisableVFX(((PassiveItem)this).Owner);
		activeOutline = false;
		if (hasRightCash || hasRightArmour || hasRightGunAmmo || curseAndCoolnessMatch)
		{
			GiveBoon(((PassiveItem)this).Owner);
			EnableVFX(((PassiveItem)this).Owner);
			activeOutline = true;
		}
		((PassiveItem)this).Owner.stats.RecalculateStats(((PassiveItem)this).Owner, true, false);
		lastArmour = currentArmour;
		lastCash = currentCash;
		lastGunAmmo = currentGunAmmo;
		lastCurse = currentCurse;
		lastCoolness = currentCoolness;
	}

	private void GiveBoon(PlayerController player)
	{
		AddStat((StatType)5, 1.163f, (ModifyMethod)1);
		AddStat((StatType)0, 1.163f, (ModifyMethod)1);
		AddStat((StatType)6, 1.163f, (ModifyMethod)1);
		AddStat((StatType)10, 0.837f, (ModifyMethod)1);
	}

	private void AddStat(StatType statType, float amount, ModifyMethod method = 0)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Expected O, but got Unknown
		StatModifier val = new StatModifier
		{
			amount = amount,
			statToBoost = statType,
			modifyType = method
		};
		if (base.passiveStatModifiers == null)
		{
			base.passiveStatModifiers = (StatModifier[])(object)new StatModifier[1] { val };
		}
		else
		{
			base.passiveStatModifiers = base.passiveStatModifiers.Concat((IEnumerable<StatModifier>)(object)new StatModifier[1] { val }).ToArray();
		}
	}

	private void RemoveStat(StatType statType)
	{
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		List<StatModifier> list = new List<StatModifier>();
		for (int i = 0; i < base.passiveStatModifiers.Length; i++)
		{
			if (base.passiveStatModifiers[i].statToBoost != statType)
			{
				list.Add(base.passiveStatModifiers[i]);
			}
		}
		base.passiveStatModifiers = list.ToArray();
	}

	private void EnableVFX(PlayerController user)
	{
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		if (Object.op_Implicit((Object)(object)user) && Object.op_Implicit((Object)(object)((BraveBehaviour)user).sprite))
		{
			Material outlineMaterial = SpriteOutlineManager.GetOutlineMaterial(((BraveBehaviour)user).sprite);
			if ((Object)(object)outlineMaterial != (Object)null)
			{
				outlineMaterial.SetColor("_OverrideColor", new Color(1f, 69f / 85f, 0.050980393f));
			}
		}
	}

	private void DisableVFX(PlayerController user)
	{
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		if (Object.op_Implicit((Object)(object)user) && Object.op_Implicit((Object)(object)((BraveBehaviour)user).sprite))
		{
			Material outlineMaterial = SpriteOutlineManager.GetOutlineMaterial(((BraveBehaviour)user).sprite);
			if ((Object)(object)outlineMaterial != (Object)null)
			{
				outlineMaterial.SetColor("_OverrideColor", new Color(0f, 0f, 0f));
			}
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
		return new _003CGainOutline_003Ed__22(0)
		{
			_003C_003E4__this = this
		};
	}

	private IEnumerator LoseOutline()
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CLoseOutline_003Ed__23(0)
		{
			_003C_003E4__this = this
		};
	}

	public override void Pickup(PlayerController player)
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Expected O, but got Unknown
		((BraveBehaviour)player).healthHaver.OnDamaged += new OnDamagedEvent(PlayerTookDamage);
		((PassiveItem)this).Pickup(player);
	}

	public override DebrisObject Drop(PlayerController player)
	{
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Expected O, but got Unknown
		DisableVFX(((PassiveItem)this).Owner);
		activeOutline = false;
		((BraveBehaviour)player).healthHaver.OnDamaged -= new OnDamagedEvent(PlayerTookDamage);
		return ((PassiveItem)this).Drop(player);
	}

	public override void OnDestroy()
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		if (Object.op_Implicit((Object)(object)((PassiveItem)this).Owner))
		{
			DisableVFX(((PassiveItem)this).Owner);
			activeOutline = false;
			((BraveBehaviour)((PassiveItem)this).Owner).healthHaver.OnDamaged -= new OnDamagedEvent(PlayerTookDamage);
		}
		((PassiveItem)this).OnDestroy();
	}
}
