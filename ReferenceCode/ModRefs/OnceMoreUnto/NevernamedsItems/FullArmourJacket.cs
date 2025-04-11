using System.Collections.Generic;
using System.Linq;
using Alexandria.ItemAPI;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

internal class FullArmourJacket : PassiveItem
{
	public static int FullArmourJacketID;

	private float currentArmour;

	private float lastArmour;

	public static void Init()
	{
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		PickupObject obj = ItemSetup.NewItem<FullArmourJacket>("Full Armour Jacket", "Live n' Lerm", "Every piece of Armour increases damage by 6%.\n\nThe best defence is a good offence.", "fullarmourjacket_icon", assetbundle: true);
		PassiveItem val = (PassiveItem)(object)((obj is PassiveItem) ? obj : null);
		((PickupObject)val).quality = (ItemQuality)3;
		AlexandriaTags.SetTag((PickupObject)(object)val, "bullet_modifier");
		val.ArmorToGainOnInitialPickup = 1;
		FullArmourJacketID = ((PickupObject)val).PickupObjectId;
		Doug.AddToLootPool(((PickupObject)val).PickupObjectId);
	}

	public override void Update()
	{
		if (Object.op_Implicit((Object)(object)((PassiveItem)this).Owner))
		{
			CalculateHealth(((PassiveItem)this).Owner);
		}
	}

	private void CalculateHealth(PlayerController player)
	{
		currentArmour = ((BraveBehaviour)player).healthHaver.Armor;
		if (currentArmour != lastArmour)
		{
			RemoveStat((StatType)5);
			float num;
			if (player.HasPickupID(Game.Items["nn:junkllets"].PickupObjectId))
			{
				num = currentArmour * 0.07f;
				num += 1f;
			}
			else
			{
				num = currentArmour * 0.06f;
				num += 1f;
			}
			AddStat((StatType)5, num, (ModifyMethod)1);
			lastArmour = currentArmour;
			player.stats.RecalculateStats(player, true, false);
		}
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
