using System.Collections.Generic;
using Alexandria.ItemAPI;
using Dungeonator;
using UnityEngine;

namespace NevernamedsItems;

public class Citrinitas : PassiveItem
{
	private RoomHandler lastRoom;

	private List<RoomHandler> previouslyEnteredRooms = new List<RoomHandler>();

	public static void Init()
	{
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		PickupObject obj = ItemSetup.NewItem<Citrinitas>("Citrinitas", "Wisdom", "Entering secret rooms grants fortune, and permanent upgrades.\n\nThe third phase of the Philosopher's Stone formation process, in which Solar Wisdom drives away the Lunar Energy of the Albedo.", "citrinitas_icon", assetbundle: true);
		PassiveItem val = (PassiveItem)(object)((obj is PassiveItem) ? obj : null);
		((PickupObject)val).quality = (ItemQuality)2;
		ItemBuilder.AddToSubShop((PickupObject)(object)val, (ShopType)0, 1f);
	}

	private void GiveRandomPermanentStatBuff()
	{
		//IL_000a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Expected O, but got Unknown
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		//IL_008e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_0101: Unknown result type (might be due to invalid IL or missing references)
		//IL_0109: Unknown result type (might be due to invalid IL or missing references)
		//IL_011d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0125: Unknown result type (might be due to invalid IL or missing references)
		//IL_0139: Unknown result type (might be due to invalid IL or missing references)
		//IL_0140: Unknown result type (might be due to invalid IL or missing references)
		int num = Random.Range(1, 10);
		StatModifier val = new StatModifier();
		switch (num)
		{
		case 1:
			val.amount = 1.1f;
			val.modifyType = (ModifyMethod)1;
			val.statToBoost = (StatType)5;
			break;
		case 2:
			val.amount = 1.1f;
			val.modifyType = (ModifyMethod)1;
			val.statToBoost = (StatType)1;
			break;
		case 3:
			val.amount = 1.1f;
			val.modifyType = (ModifyMethod)1;
			val.statToBoost = (StatType)0;
			break;
		case 4:
			val.amount = 1.1f;
			val.modifyType = (ModifyMethod)1;
			val.statToBoost = (StatType)6;
			break;
		case 5:
			val.amount = 0.9f;
			val.modifyType = (ModifyMethod)1;
			val.statToBoost = (StatType)10;
			break;
		case 6:
			val.amount = 0.9f;
			val.modifyType = (ModifyMethod)1;
			val.statToBoost = (StatType)2;
			break;
		case 7:
			val.amount = 1.1f;
			val.modifyType = (ModifyMethod)1;
			val.statToBoost = (StatType)16;
			break;
		case 8:
			val.amount = 1.1f;
			val.modifyType = (ModifyMethod)1;
			val.statToBoost = (StatType)9;
			break;
		case 9:
			val.amount = 1f;
			val.modifyType = (ModifyMethod)0;
			val.statToBoost = (StatType)4;
			break;
		}
		((PassiveItem)this).Owner.ownerlessStatModifiers.Add(val);
		((PassiveItem)this).Owner.stats.RecalculateStats(((PassiveItem)this).Owner, false, false);
	}

	public override void Update()
	{
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		//IL_0078: Invalid comparison between Unknown and I4
		//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
		if (Object.op_Implicit((Object)(object)((PassiveItem)this).Owner) && ((PassiveItem)this).Owner.CurrentRoom != null && !string.IsNullOrEmpty(((PassiveItem)this).Owner.CurrentRoom.GetRoomName()) && ((PassiveItem)this).Owner.CurrentRoom != lastRoom)
		{
			if ((int)((PassiveItem)this).Owner.CurrentRoom.area.PrototypeRoomCategory == 6 && !previouslyEnteredRooms.Contains(((PassiveItem)this).Owner.CurrentRoom))
			{
				IntVector2 centeredVisibleClearSpot = ((PassiveItem)this).Owner.CurrentRoom.GetCenteredVisibleClearSpot(2, 2);
				LootEngine.SpawnCurrency(((IntVector2)(ref centeredVisibleClearSpot)).ToVector2(), Random.Range(20, 51), false);
				GiveRandomPermanentStatBuff();
				previouslyEnteredRooms.Add(((PassiveItem)this).Owner.CurrentRoom);
			}
			lastRoom = ((PassiveItem)this).Owner.CurrentRoom;
		}
	}
}
