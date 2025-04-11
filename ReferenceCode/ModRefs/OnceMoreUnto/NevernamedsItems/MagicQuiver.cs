using System.Collections.Generic;
using System.Linq;
using Alexandria.ItemAPI;
using UnityEngine;

namespace NevernamedsItems;

public class MagicQuiver : PassiveItem
{
	private Gun currentHeldGun;

	private Gun lastHeldGun;

	public static void Init()
	{
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		PickupObject obj = ItemSetup.NewItem<MagicQuiver>("Magic Quiver", "Stranger Ranger", "Increases the damage of arrow-based weapons.\n\nAlben Smallbore was commissioned to create this artefact by a disappointed Bowman, disatisfied with the Gungeon's nigh dismissal of his craft.", "magicquiver_icon", assetbundle: true);
		PassiveItem val = (PassiveItem)(object)((obj is PassiveItem) ? obj : null);
		((PickupObject)val).quality = (ItemQuality)2;
	}

	public override void Update()
	{
		if (Object.op_Implicit((Object)(object)((PassiveItem)this).Owner) && Object.op_Implicit((Object)(object)((GameActor)((PassiveItem)this).Owner).CurrentGun))
		{
			currentHeldGun = ((GameActor)((PassiveItem)this).Owner).CurrentGun;
			if ((Object)(object)currentHeldGun != (Object)(object)lastHeldGun)
			{
				RemoveStat((StatType)5);
				if (AlexandriaTags.HasTag((PickupObject)(object)((GameActor)((PassiveItem)this).Owner).CurrentGun, "arrow_bolt_weapon"))
				{
					AddStat((StatType)5, 1.5f, (ModifyMethod)1);
				}
				((PassiveItem)this).Owner.stats.RecalculateStats(((PassiveItem)this).Owner, true, false);
				lastHeldGun = currentHeldGun;
			}
		}
		((PassiveItem)this).Update();
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
