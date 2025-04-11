using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace NevernamedsItems;

public class MobiusClip : PassiveItem
{
	private Gun currentHeldGun;

	private Gun lastHeldGun;

	public static void Init()
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		PickupObject val = ItemSetup.NewItem<MobiusClip>("Mobius Clip", "The Power of Infinity", "Triples the damage of all infinite ammo guns. Does not work on guns that are A tier or above.\n\nA peculiar mathematical concept repurposed to store powerful ammunition.", "mobiusclip_icon", assetbundle: true);
		val.quality = (ItemQuality)2;
	}

	public override void Update()
	{
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Invalid comparison between Unknown and I4
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0071: Invalid comparison between Unknown and I4
		if (Object.op_Implicit((Object)(object)((PassiveItem)this).Owner))
		{
			currentHeldGun = ((GameActor)((PassiveItem)this).Owner).CurrentGun;
			if ((Object)(object)currentHeldGun != (Object)(object)lastHeldGun)
			{
				if (((GameActor)((PassiveItem)this).Owner).CurrentGun.InfiniteAmmo && (int)((PickupObject)((GameActor)((PassiveItem)this).Owner).CurrentGun).quality != 4 && (int)((PickupObject)((GameActor)((PassiveItem)this).Owner).CurrentGun).quality != 5)
				{
					GiveSynergyBoost();
				}
				else
				{
					RemoveSynergyBoost();
				}
				lastHeldGun = currentHeldGun;
			}
		}
		((PassiveItem)this).Update();
	}

	private void GiveSynergyBoost()
	{
		RemoveStat((StatType)5);
		AddStat((StatType)5, 3f, (ModifyMethod)1);
		((PassiveItem)this).Owner.stats.RecalculateStats(((PassiveItem)this).Owner, true, false);
	}

	private void RemoveSynergyBoost()
	{
		RemoveStat((StatType)5);
		((PassiveItem)this).Owner.stats.RecalculateStats(((PassiveItem)this).Owner, true, false);
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
