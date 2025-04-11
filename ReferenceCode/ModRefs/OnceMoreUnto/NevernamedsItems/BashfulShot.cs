using System.Collections.Generic;
using System.Linq;
using Alexandria.ItemAPI;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

internal class BashfulShot : PassiveItem
{
	public static int BashfulShotID;

	private int currentItems;

	private int lastItems;

	private int currentGuns;

	private int lastGuns;

	public static void Init()
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		PickupObject val = ItemSetup.NewItem<BashfulShot>("Bashful Shot", "Travel Light", "Grants a large damage and firerate boost which decreases with each item and gun held.\n\nThese remarkably compatible musket balls prefer to keep to themselves, and don’t like other items getting in the way.\n\nMaybe don’t pick up that Junk.", "bashfulshot_improved", assetbundle: true);
		val.quality = (ItemQuality)5;
		AlexandriaTags.SetTag(val, "bullet_modifier");
		BashfulShotID = val.PickupObjectId;
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
		int num = 0;
		foreach (PassiveItem passiveItem in player.passiveItems)
		{
			num++;
		}
		foreach (Gun allGun in player.inventory.AllGuns)
		{
			num++;
		}
		if (num <= 30 && !((PassiveItem)this).Owner.HasPickupID(Game.Items["nn:crowded_clips"].PickupObjectId))
		{
			float num2 = 1f;
			float num3 = 1f;
			for (int i = 0; i < num; i++)
			{
				num2 -= 0.03f;
				num3 -= 0.03f;
			}
			num2 = Mathf.Max(0f, num2);
			num3 = Mathf.Max(0f, num3);
			AddStat((StatType)5, num3, (ModifyMethod)0);
			AddStat((StatType)1, num2, (ModifyMethod)0);
		}
		else if (((PassiveItem)this).Owner.HasPickupID(Game.Items["nn:crowded_clips"].PickupObjectId))
		{
			AddStat((StatType)5, 1f, (ModifyMethod)0);
			AddStat((StatType)1, 1f, (ModifyMethod)0);
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
