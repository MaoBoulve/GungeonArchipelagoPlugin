using System.Collections.Generic;
using System.Linq;
using Alexandria.ItemAPI;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

internal class CrowdedClip : PassiveItem
{
	private int currentItems;

	private int lastItems;

	private int currentGuns;

	private int lastGuns;

	public static void Init()
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		PickupObject val = ItemSetup.NewItem<CrowdedClip>("Crowded Clips", "More the Merrier", "+1% Damage and Firerate but -1% accuracy for every item or gun held.\n\nThis extroverted artefact enjoys the company of other items, and rewards their presence.", "crowdedclips_icon", assetbundle: true);
		val.quality = (ItemQuality)4;
		AlexandriaTags.SetTag(val, "bullet_modifier");
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
		currentGuns = player.inventory.AllGuns.Count;
		bool flag = currentItems != lastItems;
		bool flag2 = currentGuns != lastGuns;
		if (!(flag || flag2))
		{
			return;
		}
		RemoveStat((StatType)5);
		RemoveStat((StatType)1);
		RemoveStat((StatType)2);
		if (!((PassiveItem)this).Owner.HasPickupID(Game.Items["nn:bashful_shot"].PickupObjectId))
		{
			foreach (PassiveItem passiveItem in player.passiveItems)
			{
				AddStat((StatType)5, 1.01f, (ModifyMethod)1);
				AddStat((StatType)1, 1.01f, (ModifyMethod)1);
				AddStat((StatType)2, 1.01f, (ModifyMethod)1);
			}
			foreach (Gun allGun in player.inventory.AllGuns)
			{
				AddStat((StatType)5, 1.01f, (ModifyMethod)1);
				AddStat((StatType)1, 1.01f, (ModifyMethod)1);
				AddStat((StatType)2, 1.01f, (ModifyMethod)1);
			}
		}
		else if (((PassiveItem)this).Owner.HasPickupID(Game.Items["nn:bashful_shot"].PickupObjectId))
		{
			AddStat((StatType)5, 1f, (ModifyMethod)0);
			AddStat((StatType)1, 1f, (ModifyMethod)0);
			AddStat((StatType)2, 1f, (ModifyMethod)1);
		}
		lastItems = currentItems;
		lastGuns = currentGuns;
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
