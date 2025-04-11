using Dungeonator;
using UnityEngine;

namespace NevernamedsItems;

public class TatteredMap : PassiveItem
{
	public static int TatteredMapID;

	public static void Init()
	{
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		PickupObject obj = ItemSetup.NewItem<TatteredMap>("Tattered Map", "Reveals Some Rooms", "Partially reveals the floor.\n\nThis moth-eaten parchment has seen better days.", "tatteredmap_icon", assetbundle: true);
		PassiveItem val = (PassiveItem)(object)((obj is PassiveItem) ? obj : null);
		((PickupObject)val).CanBeDropped = true;
		((PickupObject)val).quality = (ItemQuality)1;
		TatteredMapID = ((PickupObject)val).PickupObjectId;
	}

	private void OnFloorLoaded()
	{
		for (int i = 0; i < GameManager.Instance.Dungeon.data.rooms.Count; i++)
		{
			if (Random.value <= 0.25f)
			{
				RoomHandler val = GameManager.Instance.Dungeon.data.rooms[i];
				Minimap.Instance.RevealMinimapRoom(val, true, false, val == GameManager.Instance.PrimaryPlayer.CurrentRoom);
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
