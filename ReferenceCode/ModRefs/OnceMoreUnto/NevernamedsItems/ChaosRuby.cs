using System;
using System.Collections.Generic;
using System.Linq;
using SaveAPI;
using UnityEngine;

namespace NevernamedsItems;

public class ChaosRuby : PassiveItem
{
	public struct Effect
	{
		public StatType statToEffect;

		public float amount;

		public ModifyMethod modifyMethod;

		public Action<Effect, PlayerController> action;
	}

	private bool hasPicked = false;

	public int randomNumber;

	public string randomNumberToString;

	public List<Effect> statEffects = new List<Effect>();

	public static void Init()
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		PickupObject val = ItemSetup.NewItem<ChaosRuby>("Chaos Ruby", "(Un)Control", "Increases one random stat by 20%, at least in most cases.\n\nRumour has it that these gemstones are what drew Tonic the Sledge Dog to The Gungeon in the first place.", "chaosruby_improved", assetbundle: true);
		val.quality = (ItemQuality)1;
		val.SetupUnlockOnCustomFlag(CustomDungeonFlags.BEATEN_KEEP_TURBO_MODE, requiredFlagValue: true);
	}

	private void PickStats()
	{
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Invalid comparison between Unknown and I4
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Invalid comparison between Unknown and I4
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		if (hasPicked)
		{
			return;
		}
		PlayableCharacters characterIdentity = ((PassiveItem)this).Owner.characterIdentity;
		Effect item = BraveUtility.RandomElement<Effect>(statEffects);
		statEffects.Remove(item);
		if ((int)item.modifyMethod == 1)
		{
			AddStat(item.statToEffect, item.amount, (ModifyMethod)1);
		}
		else
		{
			if ((int)item.statToEffect == 3 && ((PassiveItem)this).Owner.ForceZeroHealthState)
			{
				LootEngine.GivePrefabToPlayer(((Component)PickupObjectDatabase.GetById(120)).gameObject, ((PassiveItem)this).Owner);
			}
			AddStat(item.statToEffect, item.amount, (ModifyMethod)0);
		}
		((PassiveItem)this).Owner.stats.RecalculateStats(((PassiveItem)this).Owner, true, false);
		hasPicked = true;
	}

	public void DefineEffects()
	{
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0109: Unknown result type (might be due to invalid IL or missing references)
		//IL_0111: Unknown result type (might be due to invalid IL or missing references)
		//IL_013b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0143: Unknown result type (might be due to invalid IL or missing references)
		//IL_016d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0175: Unknown result type (might be due to invalid IL or missing references)
		//IL_019f: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0203: Unknown result type (might be due to invalid IL or missing references)
		//IL_020b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0235: Unknown result type (might be due to invalid IL or missing references)
		//IL_023d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0267: Unknown result type (might be due to invalid IL or missing references)
		//IL_026f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0299: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0303: Unknown result type (might be due to invalid IL or missing references)
		//IL_032c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0334: Unknown result type (might be due to invalid IL or missing references)
		statEffects.Add(new Effect
		{
			statToEffect = (StatType)2,
			modifyMethod = (ModifyMethod)1,
			amount = 0.8f
		});
		statEffects.Add(new Effect
		{
			statToEffect = (StatType)10,
			modifyMethod = (ModifyMethod)1,
			amount = 0.8f
		});
		statEffects.Add(new Effect
		{
			statToEffect = (StatType)5,
			modifyMethod = (ModifyMethod)1,
			amount = 1.2f
		});
		statEffects.Add(new Effect
		{
			statToEffect = (StatType)15,
			modifyMethod = (ModifyMethod)1,
			amount = 1.2f
		});
		statEffects.Add(new Effect
		{
			statToEffect = (StatType)6,
			modifyMethod = (ModifyMethod)1,
			amount = 1.2f
		});
		statEffects.Add(new Effect
		{
			statToEffect = (StatType)1,
			modifyMethod = (ModifyMethod)1,
			amount = 1.2f
		});
		statEffects.Add(new Effect
		{
			statToEffect = (StatType)22,
			modifyMethod = (ModifyMethod)1,
			amount = 1.2f
		});
		statEffects.Add(new Effect
		{
			statToEffect = (StatType)21,
			modifyMethod = (ModifyMethod)1,
			amount = 1.2f
		});
		statEffects.Add(new Effect
		{
			statToEffect = (StatType)27,
			modifyMethod = (ModifyMethod)1,
			amount = 1.2f
		});
		statEffects.Add(new Effect
		{
			statToEffect = (StatType)28,
			modifyMethod = (ModifyMethod)1,
			amount = 1.2f
		});
		statEffects.Add(new Effect
		{
			statToEffect = (StatType)13,
			modifyMethod = (ModifyMethod)1,
			amount = 0.8f
		});
		statEffects.Add(new Effect
		{
			statToEffect = (StatType)12,
			modifyMethod = (ModifyMethod)1,
			amount = 1.2f
		});
		statEffects.Add(new Effect
		{
			statToEffect = (StatType)30,
			modifyMethod = (ModifyMethod)1,
			amount = 1.2f
		});
		statEffects.Add(new Effect
		{
			statToEffect = (StatType)20,
			modifyMethod = (ModifyMethod)1,
			amount = 1.2f
		});
		statEffects.Add(new Effect
		{
			statToEffect = (StatType)0,
			modifyMethod = (ModifyMethod)1,
			amount = 1.2f
		});
		statEffects.Add(new Effect
		{
			statToEffect = (StatType)3,
			modifyMethod = (ModifyMethod)0,
			amount = 1f
		});
		statEffects.Add(new Effect
		{
			statToEffect = (StatType)4,
			modifyMethod = (ModifyMethod)0,
			amount = 1f
		});
	}

	public override void Pickup(PlayerController player)
	{
		((PassiveItem)this).Pickup(player);
		DefineEffects();
		PickStats();
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
}
