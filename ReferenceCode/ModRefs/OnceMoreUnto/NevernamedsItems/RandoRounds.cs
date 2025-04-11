using System;
using System.Collections.Generic;
using System.Linq;
using Alexandria.ItemAPI;
using SaveAPI;

namespace NevernamedsItems;

public class RandoRounds : PassiveItem
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
		PickupObject val = ItemSetup.NewItem<RandoRounds>("Rando Rounds", "Something Up", "Increases two random bullet related stats by 15%.\n\nThese shells were hand-crafted by Chancelot, the disgraced Ex-Knight of the Octagonal Table.\n\nOne of the order's most popular members, he was cast out after being caught in Princess Gunivere's chambers.", "rando6_icon", assetbundle: true);
		val.quality = (ItemQuality)2;
		AlexandriaTags.SetTag(val, "bullet_modifier");
		val.SetupUnlockOnCustomFlag(CustomDungeonFlags.PURCHASED_RANDOROUNDS, requiredFlagValue: true);
		val.AddItemToDougMetaShop(19, null);
		Doug.AddToLootPool(val.PickupObjectId);
	}

	private void PickStats()
	{
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Invalid comparison between Unknown and I4
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		if (hasPicked)
		{
			return;
		}
		for (int i = 0; i < 2; i++)
		{
			Effect item = BraveUtility.RandomElement<Effect>(statEffects);
			statEffects.Remove(item);
			if ((int)item.modifyMethod == 1)
			{
				AddStat(item.statToEffect, item.amount, (ModifyMethod)1);
			}
			else
			{
				AddStat(item.statToEffect, item.amount, (ModifyMethod)0);
			}
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
		statEffects.Add(new Effect
		{
			statToEffect = (StatType)2,
			modifyMethod = (ModifyMethod)1,
			amount = 0.85f
		});
		statEffects.Add(new Effect
		{
			statToEffect = (StatType)10,
			modifyMethod = (ModifyMethod)1,
			amount = 0.85f
		});
		statEffects.Add(new Effect
		{
			statToEffect = (StatType)5,
			modifyMethod = (ModifyMethod)1,
			amount = 1.15f
		});
		statEffects.Add(new Effect
		{
			statToEffect = (StatType)15,
			modifyMethod = (ModifyMethod)1,
			amount = 1.15f
		});
		statEffects.Add(new Effect
		{
			statToEffect = (StatType)6,
			modifyMethod = (ModifyMethod)1,
			amount = 1.15f
		});
		statEffects.Add(new Effect
		{
			statToEffect = (StatType)1,
			modifyMethod = (ModifyMethod)1,
			amount = 1.15f
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
