using System.Collections.Generic;
using System.Linq;
using Alexandria.ItemAPI;
using SaveAPI;
using UnityEngine;

namespace NevernamedsItems;

public class BeltFeeder : PassiveItem
{
	public static int ID;

	public float timeShooting;

	private float amt;

	public StatModifier cur;

	public static void Init()
	{
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		PickupObject val = ItemSetup.NewItem<BeltFeeder>("Belt Feeder", "More Lead", "Feeds fresh ammo into your guns at a much higher rate.\n\nUtterly mundane, but nonetheless effective.", "beltfeeder_icon", assetbundle: true);
		ItemBuilder.AddPassiveStatModifier(val, (StatType)6, 1.1f, (ModifyMethod)1);
		ItemBuilder.AddPassiveStatModifier(val, (StatType)12, 1.1f, (ModifyMethod)1);
		ItemBuilder.AddPassiveStatModifier(val, (StatType)1, 1.3f, (ModifyMethod)1);
		val.quality = (ItemQuality)2;
		ItemBuilder.AddToSubShop(val, (ShopType)3, 1f);
		ID = val.PickupObjectId;
		val.SetupUnlockOnCustomStat(CustomTrackedStats.DOUG_ITEMS_PURCHASED, 2f, (PrerequisiteOperation)2);
	}

	public override void Update()
	{
		//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e1: Expected O, but got Unknown
		if (Object.op_Implicit((Object)(object)((PassiveItem)this).Owner))
		{
			BraveInput instanceForPlayer = BraveInput.GetInstanceForPlayer(((PassiveItem)this).Owner.PlayerIDX);
			if (CustomSynergies.PlayerHasActiveSynergy(((PassiveItem)this).Owner, "Belting Out") && instanceForPlayer.GetButton((GungeonActionType)8) && Object.op_Implicit((Object)(object)((GameActor)((PassiveItem)this).Owner).CurrentGun) && !((GameActor)((PassiveItem)this).Owner).CurrentGun.IsReloading)
			{
				timeShooting += BraveTime.DeltaTime;
				amt = Mathf.Lerp(1f, 4f, timeShooting / 10f);
				List<StatModifier> list = base.passiveStatModifiers.ToList();
				list.Remove(cur);
				cur = new StatModifier
				{
					amount = amt,
					modifyType = (ModifyMethod)1,
					statToBoost = (StatType)1
				};
				list.Add(cur);
				base.passiveStatModifiers = list.ToArray();
				((PassiveItem)this).Owner.stats.RecalculateStats(((PassiveItem)this).Owner, false, false);
			}
			else if (amt > 1f)
			{
				List<StatModifier> list2 = base.passiveStatModifiers.ToList();
				list2.Remove(cur);
				base.passiveStatModifiers = list2.ToArray();
				ItemBuilder.RemovePassiveStatModifier((PickupObject)(object)this, (StatType)15);
				((PassiveItem)this).Owner.stats.RecalculateStats(((PassiveItem)this).Owner, false, false);
				timeShooting = 0f;
			}
		}
		((PassiveItem)this).Update();
	}

	public override void DisableEffect(PlayerController player)
	{
		if (Object.op_Implicit((Object)(object)player) && player.ownerlessStatModifiers.Contains(cur))
		{
			player.ownerlessStatModifiers.Remove(cur);
			player.stats.RecalculateStats(player, false, false);
		}
		((PassiveItem)this).DisableEffect(player);
	}
}
