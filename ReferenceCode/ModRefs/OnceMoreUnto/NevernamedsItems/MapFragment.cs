using Alexandria.ItemAPI;
using Dungeonator;
using UnityEngine;

namespace NevernamedsItems;

public class MapFragment : PassiveItem
{
	public static int MapFragmentID;

	public RoomHandler lastRoom;

	public static void Init()
	{
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		PickupObject obj = ItemSetup.NewItem<MapFragment>("Map Fragment", "Selective Information", "Reveals nearby rooms.\n\nSeemingly torn from a larger map.", "mapfragment_icon", assetbundle: true);
		PassiveItem val = (PassiveItem)(object)((obj is PassiveItem) ? obj : null);
		((PickupObject)val).CanBeDropped = true;
		((PickupObject)val).CustomCost = 20;
		((PickupObject)val).UsesCustomCost = true;
		((PickupObject)val).quality = (ItemQuality)1;
		MapFragmentID = ((PickupObject)val).PickupObjectId;
	}

	public override void Update()
	{
		if (!Object.op_Implicit((Object)(object)((PassiveItem)this).Owner) || ((PassiveItem)this).Owner.CurrentRoom == null)
		{
			return;
		}
		if (((PassiveItem)this).Owner.CurrentRoom != lastRoom)
		{
			foreach (RoomHandler connectedRoom in ((PassiveItem)this).Owner.CurrentRoom.connectedRooms)
			{
				if (!connectedRoom.IsSecretRoom || CustomSynergies.PlayerHasActiveSynergy(((PassiveItem)this).Owner, "Trust In The All-Seeing"))
				{
					Minimap.Instance.RevealMinimapRoom(connectedRoom, true, true, false);
					if (CustomSynergies.PlayerHasActiveSynergy(((PassiveItem)this).Owner, "Restoration"))
					{
						foreach (RoomHandler connectedRoom2 in connectedRoom.connectedRooms)
						{
							if (!connectedRoom.IsSecretRoom || CustomSynergies.PlayerHasActiveSynergy(((PassiveItem)this).Owner, "Trust In The All-Seeing"))
							{
								Minimap.Instance.RevealMinimapRoom(connectedRoom2, true, true, false);
							}
						}
					}
				}
				lastRoom = ((PassiveItem)this).Owner.CurrentRoom;
			}
		}
		((PassiveItem)this).Update();
	}
}
