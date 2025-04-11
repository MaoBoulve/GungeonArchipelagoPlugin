using Alexandria.ItemAPI;

namespace NevernamedsItems;

public class LooseChange : PassiveItem
{
	private int floorsVisited;

	public static void Init()
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		PickupObject val = ItemSetup.NewItem<LooseChange>("Loose Change", "Cash Money", "Gives some money every floor. Amount increases for every floor you've been to previously.\n\nGo and buy yourself something nice.", "loosechange_icon", assetbundle: true);
		val.quality = (ItemQuality)1;
	}

	private void OnNewFloor()
	{
		PlayerController owner = ((PassiveItem)this).Owner;
		int num = floorsVisited * 10;
		if (CustomSynergies.PlayerHasActiveSynergy(((PassiveItem)this).Owner, "Lost, Never Found"))
		{
			num += 5;
		}
		PlayerConsumables carriedConsumables = owner.carriedConsumables;
		carriedConsumables.Currency += num;
		floorsVisited++;
	}

	public override void Pickup(PlayerController player)
	{
		if (!base.m_pickedUpThisRun)
		{
			PlayerConsumables carriedConsumables = player.carriedConsumables;
			carriedConsumables.Currency += 10;
			floorsVisited = 2;
		}
		GameManager.Instance.OnNewLevelFullyLoaded += OnNewFloor;
		((PassiveItem)this).Pickup(player);
	}

	public override DebrisObject Drop(PlayerController player)
	{
		DebrisObject result = ((PassiveItem)this).Drop(player);
		GameManager.Instance.OnNewLevelFullyLoaded -= OnNewFloor;
		return result;
	}

	public override void OnDestroy()
	{
		GameManager.Instance.OnNewLevelFullyLoaded -= OnNewFloor;
		((PassiveItem)this).OnDestroy();
	}
}
