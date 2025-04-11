using System.Collections.Generic;
using System.Linq;
using Alexandria.ItemAPI;
using UnityEngine;

namespace NevernamedsItems;

internal class ForsakenHeart : PassiveItem
{
	public static int ForsakenHeartID;

	private float lastCurse = -1f;

	public static void Init()
	{
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		PickupObject val = ItemSetup.NewItem<ForsakenHeart>("Forsaken Heart", "And lo, it shall embroil within", "A cursed heart embiggens the smallest of wretches.", "forsakenheart_icon", assetbundle: true);
		ItemBuilder.AddPassiveStatModifier(val, (StatType)14, 1f, (ModifyMethod)0);
		val.quality = (ItemQuality)3;
		ItemBuilder.AddToSubShop(val, (ShopType)2, 1f);
		ForsakenHeartID = val.PickupObjectId;
	}

	public override void Update()
	{
		if ((Object)(object)((PassiveItem)this).Owner != (Object)null)
		{
			float statValue = ((PassiveItem)this).Owner.stats.GetStatValue((StatType)14);
			if (statValue != lastCurse)
			{
				RemoveStat((StatType)3);
				if (statValue > 0f)
				{
					AddStat((StatType)3, Mathf.FloorToInt(statValue / 2.5f), (ModifyMethod)0);
					((PassiveItem)this).Owner.stats.RecalculateStats(((PassiveItem)this).Owner, true, false);
					lastCurse = statValue;
				}
			}
		}
		((PassiveItem)this).Update();
	}

	private void AddStat(StatType statType, float amount, ModifyMethod method = 0)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Expected O, but got Unknown
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		StatModifier val = new StatModifier();
		val.amount = amount;
		val.statToBoost = statType;
		val.modifyType = method;
		StatModifier[] passiveStatModifiers = base.passiveStatModifiers;
		foreach (StatModifier val2 in passiveStatModifiers)
		{
			if (val2.statToBoost == statType)
			{
				return;
			}
		}
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
