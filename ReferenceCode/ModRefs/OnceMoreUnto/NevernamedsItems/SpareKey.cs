using Alexandria.ItemAPI;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class SpareKey : PassiveItem
{
	public static void Init()
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		PickupObject val = ItemSetup.NewItem<SpareKey>("Spare Key", "Important to Have", "Grants an extra key every floor.\nHaving a spare key is important, what if you lose the one you have?", "sparekey_new", assetbundle: true);
		val.quality = (ItemQuality)3;
		ItemBuilder.AddToSubShop(val, (ShopType)1, 1f);
	}

	private void OnNewFloor()
	{
		PlayerController owner = ((PassiveItem)this).Owner;
		LootEngine.GivePrefabToPlayer(((Component)PickupObjectDatabase.GetById(67)).gameObject, owner);
		if (((PassiveItem)this).Owner.HasPickupID(Game.Items["nn:spare_blank"].PickupObjectId))
		{
			LootEngine.GivePrefabToPlayer(((Component)PickupObjectDatabase.GetById(120)).gameObject, owner);
		}
	}

	public override void Pickup(PlayerController player)
	{
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
