using System.Collections.Generic;
using Alexandria.ItemAPI;
using Dungeonator;
using UnityEngine;

namespace NevernamedsItems;

public class Autollet : PassiveItem
{
	public static int AutolletID;

	public List<RoomHandler> roomsVisitedThisFloor = new List<RoomHandler>();

	public RoomHandler lastRoom;

	public RoomHandler currentRoom;

	public static void Init()
	{
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		PickupObject val = ItemSetup.NewItem<Autollet>("Autollet", "Automatic and Effective", "Automatically triggers a free blank upon entering an unvisited room with enemies.\n\nThe end product of using science to reverse engineer the strange and esoteric Elder Blank.", "autollet_icon", assetbundle: true);
		val.CanBeDropped = true;
		val.quality = (ItemQuality)2;
		ItemBuilder.AddToSubShop(val, (ShopType)4, 1f);
		AutolletID = val.PickupObjectId;
		AlexandriaTags.SetTag(val, "ammolet");
	}

	private void TriggerBlankIfAppropriate()
	{
		if (((PassiveItem)this).Owner.CurrentRoom.GetActiveEnemiesCount((ActiveEnemyType)0) > 0 || CustomSynergies.PlayerHasActiveSynergy(((PassiveItem)this).Owner, "Code Blanks"))
		{
			((PassiveItem)this).Owner.ForceBlank(45f, 0.5f, false, true, (Vector2?)null, true, -1f);
		}
	}

	public override void Update()
	{
		if (Object.op_Implicit((Object)(object)((PassiveItem)this).Owner) && ((PassiveItem)this).Owner.CurrentRoom != null)
		{
			currentRoom = ((PassiveItem)this).Owner.CurrentRoom;
			if (currentRoom != lastRoom)
			{
				if (!roomsVisitedThisFloor.Contains(currentRoom))
				{
					TriggerBlankIfAppropriate();
					roomsVisitedThisFloor.Add(currentRoom);
				}
				lastRoom = currentRoom;
			}
		}
		((PassiveItem)this).Update();
	}

	private void NewFloor()
	{
		roomsVisitedThisFloor.Clear();
	}

	public override void Pickup(PlayerController player)
	{
		GameManager.Instance.OnNewLevelFullyLoaded += NewFloor;
		((PassiveItem)this).Pickup(player);
	}

	public override void DisableEffect(PlayerController player)
	{
		GameManager.Instance.OnNewLevelFullyLoaded -= NewFloor;
		((PassiveItem)this).DisableEffect(player);
	}
}
