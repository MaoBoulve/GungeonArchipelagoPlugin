using Dungeonator;
using UnityEngine;

namespace NevernamedsItems;

public class CartographersEye : PassiveItem
{
	public static int CartographersEyeID;

	public static void Init()
	{
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		PickupObject obj = ItemSetup.NewItem<CartographersEye>("Cartographers Eye", "Shows the Way", "Grants vision of important rooms.\nGrants access to a randomly selected special room.\n\nCreated by legendary cartographer Woban to guide him in his old age as his vision failed.", "cartographerseye_icon", assetbundle: true);
		PassiveItem val = (PassiveItem)(object)((obj is PassiveItem) ? obj : null);
		((PickupObject)val).CanBeDropped = true;
		((PickupObject)val).quality = (ItemQuality)3;
		CartographersEyeID = ((PickupObject)val).PickupObjectId;
	}

	private void OnFloorLoaded()
	{
		//IL_008b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0091: Invalid comparison between Unknown and I4
		//IL_013c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0146: Invalid comparison between Unknown and I4
		int num = Random.Range(1, 4);
		for (int i = 0; i < GameManager.Instance.Dungeon.data.rooms.Count; i++)
		{
			RoomHandler val = GameManager.Instance.Dungeon.data.rooms[i];
			if (val == null)
			{
				continue;
			}
			if (val.IsShop)
			{
				val.RevealedOnMap = true;
				Minimap.Instance.RevealMinimapRoom(val, true, false, val == GameManager.Instance.PrimaryPlayer.CurrentRoom);
				if (num == 1)
				{
					val.visibility = (VisibilityStatus)1;
				}
			}
			else if ((int)val.area.PrototypeRoomCategory == 4)
			{
				val.RevealedOnMap = true;
				Minimap.Instance.RevealMinimapRoom(val, true, false, val == GameManager.Instance.PrimaryPlayer.CurrentRoom);
				if (num == 2)
				{
					val.visibility = (VisibilityStatus)1;
				}
			}
			else if (!string.IsNullOrEmpty(val.GetRoomName()) && val.GetRoomName().Contains("Boss Foyer"))
			{
				val.RevealedOnMap = true;
				Minimap.Instance.RevealMinimapRoom(val, true, false, val == GameManager.Instance.PrimaryPlayer.CurrentRoom);
				if (num == 3 && (int)GameManager.Instance.Dungeon.tileIndices.tilesetId != 128)
				{
					val.visibility = (VisibilityStatus)1;
				}
			}
		}
		Minimap.Instance.m_shouldBuildTilemap = true;
	}

	public override void Pickup(PlayerController player)
	{
		if (!base.m_pickedUpThisRun)
		{
			OnFloorLoaded();
		}
		GameManager.Instance.OnNewLevelFullyLoaded += OnFloorLoaded;
		((PassiveItem)this).Pickup(player);
	}

	public override DebrisObject Drop(PlayerController player)
	{
		GameManager.Instance.OnNewLevelFullyLoaded -= OnFloorLoaded;
		return ((PassiveItem)this).Drop(player);
	}

	public override void OnDestroy()
	{
		GameManager.Instance.OnNewLevelFullyLoaded -= OnFloorLoaded;
		((PassiveItem)this).OnDestroy();
	}
}
