using System.Collections.Generic;
using System.Linq;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

internal class GlassChamber : PassiveItem
{
	public static int GlassChamberID;

	private int currentItems;

	private int lastItems;

	public static void Init()
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		PickupObject val = ItemSetup.NewItem<GlassChamber>("Glass Chamber", "Seeload", "Reloading is 10% faster for every Glass Guon Stone the bearer has.\n\nA symbol of the tentative peace between the fragile Lady of Pane, and the mighty king-god Relodin.", "glasschamber_icon", assetbundle: true);
		val.quality = (ItemQuality)2;
		GlassChamberID = val.PickupObjectId;
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
		RemoveStat((StatType)10);
		foreach (PassiveItem passiveItem in player.passiveItems)
		{
			if (((PickupObject)passiveItem).PickupObjectId == 565)
			{
				if (((PassiveItem)this).Owner.HasPickupID(Game.Items["nn:glass_rounds"].PickupObjectId))
				{
					AddStat((StatType)10, 0.85f, (ModifyMethod)1);
				}
				else
				{
					AddStat((StatType)10, 0.9f, (ModifyMethod)1);
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
		if (!base.m_pickedUpThisRun)
		{
			PickupObject byId = PickupObjectDatabase.GetById(565);
			player.AcquirePassiveItemPrefabDirectly((PassiveItem)(object)((byId is PassiveItem) ? byId : null));
		}
		GameManager.Instance.OnNewLevelFullyLoaded += OnNewFloor;
		((PassiveItem)this).Pickup(player);
	}

	public override DebrisObject Drop(PlayerController player)
	{
		GameManager.Instance.OnNewLevelFullyLoaded -= OnNewFloor;
		return ((PassiveItem)this).Drop(player);
	}

	public override void OnDestroy()
	{
		GameManager.Instance.OnNewLevelFullyLoaded -= OnNewFloor;
		((PassiveItem)this).OnDestroy();
	}

	private void OnNewFloor()
	{
		if (Object.op_Implicit((Object)(object)((PassiveItem)this).Owner))
		{
			_003F val = ((PassiveItem)this).Owner;
			PickupObject byId = PickupObjectDatabase.GetById(565);
			((PlayerController)val).AcquirePassiveItemPrefabDirectly((PassiveItem)(object)((byId is PassiveItem) ? byId : null));
		}
	}
}
