using System.Collections.Generic;
using System.Linq;
using SaveAPI;
using UnityEngine;

namespace NevernamedsItems;

internal class OverpricedHeadband : PassiveItem
{
	public static int OverpricedHeadbandID;

	private float currentCash;

	private float lastCash;

	public static void Init()
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		PickupObject val = ItemSetup.NewItem<OverpricedHeadband>("Overpriced Headband", "Ultimate", "Apparently being rich = being cool these days.\n\nMaybe you should write a song about how rich you are.", "overpricedheadband_improved", assetbundle: true);
		val.quality = (ItemQuality)2;
		val.SetupUnlockOnCustomFlag(CustomDungeonFlags.PURCHASED_OVERPRICEDHEADBAND, requiredFlagValue: true);
		OverpricedHeadbandID = val.PickupObjectId;
	}

	public override void Update()
	{
		if (!Object.op_Implicit((Object)(object)((PassiveItem)this).Owner))
		{
			return;
		}
		currentCash = ((PassiveItem)this).Owner.carriedConsumables.Currency;
		if (currentCash == lastCash)
		{
			return;
		}
		RemoveStat((StatType)4);
		float num = currentCash / 25f;
		double num2 = Mathf.FloorToInt(num);
		if (num2 > 0.0)
		{
			for (int i = 0; (double)i < num2; i++)
			{
				AddStat((StatType)4, 1f, (ModifyMethod)0);
			}
		}
		((PassiveItem)this).Owner.stats.RecalculateStats(((PassiveItem)this).Owner, false, false);
		lastCash = currentCash;
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

	public override void Pickup(PlayerController player)
	{
		((PassiveItem)this).Pickup(player);
	}

	public override DebrisObject Drop(PlayerController player)
	{
		return ((PassiveItem)this).Drop(player);
	}

	public override void OnDestroy()
	{
		((PassiveItem)this).OnDestroy();
	}
}
