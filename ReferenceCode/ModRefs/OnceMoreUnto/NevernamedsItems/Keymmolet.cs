using System;
using Alexandria.ItemAPI;
using Alexandria.Misc;
using Dungeonator;
using UnityEngine;

namespace NevernamedsItems;

public class Keymmolet : BlankModificationItem
{
	private static int ID;

	public static void Init()
	{
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		PickupObject obj = ItemSetup.NewItem<Keymmolet>("Keymmolet", "Blanks are Key", "Using a blank unlocks all chests in the room!\n\nA brilliant evolution in ammolet technology, combining the radial power of a blank with the opening power of a key.", "keymmolet_icon", assetbundle: true);
		BlankModificationItem val = (BlankModificationItem)(object)((obj is BlankModificationItem) ? obj : null);
		((PickupObject)val).quality = (ItemQuality)4;
		ItemBuilder.AddToSubShop((PickupObject)(object)val, (ShopType)4, 1f);
		ID = ((PickupObject)val).PickupObjectId;
		AlexandriaTags.SetTag((PickupObject)(object)val, "ammolet");
	}

	public override void Pickup(PlayerController player)
	{
		ExtendedPlayerComponent extComp = PlayerUtility.GetExtComp(player);
		extComp.OnBlankModificationItemProcessed = (Action<PlayerController, SilencerInstance, Vector2, BlankModificationItem>)Delegate.Combine(extComp.OnBlankModificationItemProcessed, new Action<PlayerController, SilencerInstance, Vector2, BlankModificationItem>(OnBlankModTriggered));
		((BlankModificationItem)this).Pickup(player);
	}

	public override void DisableEffect(PlayerController player)
	{
		ExtendedPlayerComponent extComp = PlayerUtility.GetExtComp(player);
		extComp.OnBlankModificationItemProcessed = (Action<PlayerController, SilencerInstance, Vector2, BlankModificationItem>)Delegate.Remove(extComp.OnBlankModificationItemProcessed, new Action<PlayerController, SilencerInstance, Vector2, BlankModificationItem>(OnBlankModTriggered));
		((PassiveItem)this).DisableEffect(player);
	}

	private void OnBlankModTriggered(PlayerController user, SilencerInstance blank, Vector2 pos, BlankModificationItem item)
	{
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Invalid comparison between Unknown and I4
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		if (!(item is Keymmolet))
		{
			return;
		}
		RoomHandler currentRoom = user.CurrentRoom;
		Chest[] array = Object.FindObjectsOfType<Chest>();
		Chest[] array2 = array;
		foreach (Chest val in array2)
		{
			if (Vector3Extensions.GetAbsoluteRoom(((BraveBehaviour)val).transform.position) == currentRoom)
			{
				if ((int)val.ChestIdentifier == 1 && val.IsLocked)
				{
					TextBubble.DoAmbientTalk(((BraveBehaviour)val).transform, new Vector3(1f, 2f, 0f), "Nice try", 4f);
				}
				else
				{
					val.ForceUnlock();
				}
			}
		}
	}
}
