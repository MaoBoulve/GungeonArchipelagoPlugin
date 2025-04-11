using System.Collections.Generic;
using System.Linq;
using Alexandria.ItemAPI;
using Gungeon;
using SaveAPI;
using UnityEngine;

namespace NevernamedsItems;

internal class Junkllets : PassiveItem
{
	private int currentItems;

	private int lastItems;

	public static void Init()
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		PickupObject val = ItemSetup.NewItem<Junkllets>("Junkllets", "Hunky Junk", "+5% damage for every piece of Junk the bearer posesses.\n\nTechnology such as this already comes pre-installed on most Hegemony Issue machine intelligences... for some reason.", "junkllets_icon", assetbundle: true);
		val.quality = (ItemQuality)2;
		AlexandriaTags.SetTag(val, "bullet_modifier");
		val.SetupUnlockOnCustomFlag(CustomDungeonFlags.ROBOT_HELD_FIVE_JUNK, requiredFlagValue: true);
		Doug.AddToLootPool(val.PickupObjectId);
	}

	public override void Update()
	{
		if (Object.op_Implicit((Object)(object)((PassiveItem)this).Owner))
		{
			CalculateStats(((PassiveItem)this).Owner);
		}
	}

	private void CalculateStats(PlayerController player)
	{
		currentItems = player.passiveItems.Count;
		if (currentItems == lastItems)
		{
			return;
		}
		RemoveStat((StatType)5);
		foreach (PassiveItem passiveItem in player.passiveItems)
		{
			if (((PickupObject)passiveItem).PickupObjectId == 127 || ((PickupObject)passiveItem).PickupObjectId == 580 || ((PickupObject)passiveItem).PickupObjectId == 641 || ((PickupObject)passiveItem).PickupObjectId == 148)
			{
				if (player.HasPickupID(Game.Items["nn:full_armour_jacket"].PickupObjectId))
				{
					AddStat((StatType)5, 1.07f, (ModifyMethod)1);
				}
				else
				{
					AddStat((StatType)5, 1.05f, (ModifyMethod)1);
				}
			}
		}
		lastItems = currentItems;
		player.stats.RecalculateStats(player, true, false);
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
}
