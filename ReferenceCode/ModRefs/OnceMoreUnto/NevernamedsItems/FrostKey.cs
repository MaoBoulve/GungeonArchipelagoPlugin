using System.Collections.Generic;
using System.Linq;
using Alexandria.ItemAPI;
using UnityEngine;

namespace NevernamedsItems;

internal class FrostKey : PassiveItem
{
	private float currentKeys;

	private float lastKeys;

	private float currentItems;

	private float lastItems;

	public static List<int> frostAndGunfireSynergyItems = new List<int> { 146, 191, 395, 670 };

	public static void Init()
	{
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		PickupObject val = ItemSetup.NewItem<FrostKey>("Frost Key", "Cold Open", "Keys increase coolness.\n\nDespite his age, Flynt remains stubbornly convinced that he is, and always will be, a 'cool dude' (as the kids say).", "frostkey_icon", assetbundle: true);
		ItemBuilder.AddToSubShop(val, (ShopType)1, 1f);
		val.quality = (ItemQuality)3;
	}

	public override void Update()
	{
		if (!Object.op_Implicit((Object)(object)((PassiveItem)this).Owner))
		{
			return;
		}
		currentKeys = ((PassiveItem)this).Owner.carriedConsumables.KeyBullets;
		currentItems = ((PassiveItem)this).Owner.passiveItems.Count;
		if (currentKeys == lastKeys && currentItems == lastItems)
		{
			return;
		}
		int keyBullets = ((PassiveItem)this).Owner.carriedConsumables.KeyBullets;
		int num = 0;
		RemoveStat((StatType)4);
		foreach (PassiveItem passiveItem in ((PassiveItem)this).Owner.passiveItems)
		{
			if (frostAndGunfireSynergyItems.Contains(((PickupObject)passiveItem).PickupObjectId))
			{
				num += 2;
			}
		}
		AddStat((StatType)4, keyBullets + num, (ModifyMethod)0);
		((PassiveItem)this).Owner.stats.RecalculateStats(((PassiveItem)this).Owner, true, false);
		lastKeys = currentKeys;
		lastItems = currentItems;
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
