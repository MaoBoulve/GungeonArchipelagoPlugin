using System.Collections.Generic;
using System.Linq;
using Alexandria.ItemAPI;
using UnityEngine;

namespace NevernamedsItems;

internal class Lewis : PlayerItem
{
	public static int LewisID;

	private bool hasSynergy;

	private bool needRestat;

	public static void Init()
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		PickupObject obj = ItemSetup.NewItem<Lewis>("Lewis", "With Friends Like These...", "This absolute freeloader just sits in your active item storage doing nothing.\n\nAt least he kinda pays rent through providing you some stats", "lewis_icon", assetbundle: true);
		PlayerItem val = (PlayerItem)(object)((obj is PlayerItem) ? obj : null);
		ItemBuilder.SetCooldownType(val, (CooldownType)1, 1000f);
		val.consumable = false;
		((PickupObject)val).quality = (ItemQuality)3;
		AlexandriaTags.SetTag((PickupObject)(object)val, "non_companion_living_item");
		LewisID = ((PickupObject)val).PickupObjectId;
	}

	public override void DoEffect(PlayerController user)
	{
		AkSoundEngine.PostEvent("Play_ENM_blobulord_reform_01", ((Component)this).gameObject);
	}

	public override void Pickup(PlayerController player)
	{
		((PlayerItem)this).Pickup(player);
		needRestat = true;
		player.stats.RecalculateStats(player, true, false);
	}

	public DebrisObject Drop(PlayerController player)
	{
		DebrisObject result = ((PlayerItem)this).Drop(player, 4f);
		hasSynergy = false;
		needRestat = false;
		player.stats.RecalculateStats(player, true, false);
		return result;
	}

	public override void OnDestroy()
	{
		if ((Object)(object)base.LastOwner != (Object)null)
		{
			hasSynergy = false;
			needRestat = false;
			base.LastOwner.stats.RecalculateStats(base.LastOwner, true, false);
		}
		((PlayerItem)this).OnDestroy();
	}

	private void AddStat(StatType statType, float amount, ModifyMethod method = 0)
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Expected O, but got Unknown
		StatModifier[] passiveStatModifiers = base.passiveStatModifiers;
		foreach (StatModifier val in passiveStatModifiers)
		{
			if (val.statToBoost == statType)
			{
				return;
			}
		}
		StatModifier val2 = new StatModifier
		{
			amount = amount,
			statToBoost = statType,
			modifyType = method
		};
		if (base.passiveStatModifiers == null)
		{
			base.passiveStatModifiers = (StatModifier[])(object)new StatModifier[1] { val2 };
		}
		else
		{
			base.passiveStatModifiers = base.passiveStatModifiers.Concat((IEnumerable<StatModifier>)(object)new StatModifier[1] { val2 }).ToArray();
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

	public override void Update()
	{
		PlayerController lastOwner = base.LastOwner;
		if (Object.op_Implicit((Object)(object)lastOwner) && lastOwner.HasActiveItem(((PickupObject)this).PickupObjectId))
		{
			if (CustomSynergies.PlayerHasActiveSynergy(lastOwner, "Rally The Slacker") && !hasSynergy)
			{
				hasSynergy = true;
				needRestat = true;
				RemoveStat((StatType)5);
				RemoveStat((StatType)1);
				RemoveStat((StatType)10);
				RemoveStat((StatType)0);
				RemoveStat((StatType)3);
				AddStat((StatType)5, 1.5f, (ModifyMethod)1);
				AddStat((StatType)1, 1.5f, (ModifyMethod)1);
				AddStat((StatType)10, 0.5f, (ModifyMethod)1);
				AddStat((StatType)0, 1.5f, (ModifyMethod)1);
				AddStat((StatType)3, 2f, (ModifyMethod)0);
				lastOwner.stats.RecalculateStats(lastOwner, true, false);
			}
			else if (!CustomSynergies.PlayerHasActiveSynergy(lastOwner, "Rally The Slacker") && needRestat)
			{
				needRestat = false;
				hasSynergy = false;
				RemoveStat((StatType)5);
				RemoveStat((StatType)1);
				RemoveStat((StatType)10);
				RemoveStat((StatType)0);
				RemoveStat((StatType)3);
				AddStat((StatType)5, 1.2f, (ModifyMethod)1);
				AddStat((StatType)1, 1.2f, (ModifyMethod)1);
				AddStat((StatType)10, 0.8f, (ModifyMethod)1);
				AddStat((StatType)0, 1.2f, (ModifyMethod)1);
				AddStat((StatType)3, 1f, (ModifyMethod)0);
				lastOwner.stats.RecalculateStats(lastOwner, true, false);
			}
		}
	}
}
