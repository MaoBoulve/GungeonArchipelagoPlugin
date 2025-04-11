using System.Collections.Generic;
using System.Linq;
using Alexandria.ItemAPI;
using SaveAPI;
using UnityEngine;

namespace NevernamedsItems;

public class SpringloadedChamber : PassiveItem
{
	private int currentClip;

	private int lastClip;

	private Gun currentGun;

	private Gun lastGun;

	public static int ID;

	private bool DamageIsUP;

	public static void Init()
	{
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		PickupObject val = ItemSetup.NewItem<SpringloadedChamber>("Springloaded Chamber", "Marvellous Mechanism", "Increases damage by 30% for the first half of the clip, but decreases it by 20% for the second.\n\nA miraculous clockwork doodad cannibalised from the Wind Up Gun. Proof that springs are, and will always be, the best form of potential energy.", "springloadedchamber_icon", assetbundle: true);
		ItemBuilder.AddPassiveStatModifier(val, (StatType)10, 0.8f, (ModifyMethod)1);
		val.quality = (ItemQuality)3;
		val.SetupUnlockOnCustomFlag(CustomDungeonFlags.PURCHASED_SPRINGLOADEDCHAMBER, requiredFlagValue: true);
		val.AddItemToTrorcMetaShop(19, null);
		ID = val.PickupObjectId;
	}

	public override void Update()
	{
		if (!Object.op_Implicit((Object)(object)((PassiveItem)this).Owner))
		{
			return;
		}
		currentClip = ((GameActor)((PassiveItem)this).Owner).CurrentGun.ClipShotsRemaining;
		currentGun = ((GameActor)((PassiveItem)this).Owner).CurrentGun;
		if (currentClip != lastClip || (Object)(object)currentGun != (Object)(object)lastGun)
		{
			int num = 2;
			if (((PassiveItem)this).Owner.HasPickupID(334))
			{
				num = 4;
			}
			if (((GameActor)((PassiveItem)this).Owner).CurrentGun.ClipShotsRemaining > ((GameActor)((PassiveItem)this).Owner).CurrentGun.ClipCapacity / num)
			{
				DamageBonusState();
			}
			else
			{
				DamageDownState();
			}
			lastClip = currentClip;
			lastGun = currentGun;
		}
	}

	private void DamageBonusState()
	{
		if (!DamageIsUP)
		{
			RemoveStat((StatType)5);
			RemoveStat((StatType)15);
			AddStat((StatType)5, 1.3f, (ModifyMethod)1);
			AddStat((StatType)15, 1.2f, (ModifyMethod)1);
			DamageIsUP = true;
			((PassiveItem)this).Owner.stats.RecalculateStats(((PassiveItem)this).Owner, true, false);
		}
	}

	private void DamageDownState()
	{
		if (DamageIsUP)
		{
			RemoveStat((StatType)5);
			RemoveStat((StatType)15);
			float amount = 0.8f;
			float amount2 = 0.8f;
			if (((PassiveItem)this).Owner.HasPickupID(69))
			{
				amount = 1f;
				amount2 = 1f;
			}
			AddStat((StatType)15, amount2, (ModifyMethod)1);
			AddStat((StatType)5, amount, (ModifyMethod)1);
			((PassiveItem)this).Owner.stats.RecalculateStats(((PassiveItem)this).Owner, true, false);
			DamageIsUP = false;
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
}
