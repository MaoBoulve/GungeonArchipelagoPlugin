using Alexandria.ItemAPI;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class NNBlankPersonality : PassiveItem
{
	public static void Init()
	{
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		PickupObject val = ItemSetup.NewItem<NNBlankPersonality>("Blank Stare", "Unreadable", "Mysterious, boring, and a bit creepy, your newfound personality will sometimes make shopkeepers give you blanks just to make you go away and stop staring.", "blankpersonality_icon", assetbundle: true);
		ItemBuilder.AddPassiveStatModifier(val, (StatType)4, 1f, (ModifyMethod)0);
		val.quality = (ItemQuality)2;
		ItemBuilder.AddToSubShop(val, (ShopType)4, 1f);
	}

	private void OnItemPurchased(PlayerController player, ShopItemController obj)
	{
		if (((PassiveItem)this).Owner.HasPickupID(Game.Items["nn:spare_blank"].PickupObjectId))
		{
			LootEngine.GivePrefabToPlayer(((Component)PickupObjectDatabase.GetById(224)).gameObject, player);
		}
		else if (Random.value < 0.5f)
		{
			LootEngine.GivePrefabToPlayer(((Component)PickupObjectDatabase.GetById(224)).gameObject, player);
		}
		if (((PassiveItem)this).Owner.HasPickupID(Game.Items["nn:spare_key"].PickupObjectId) && Random.value <= 0.1f)
		{
			LootEngine.GivePrefabToPlayer(((Component)PickupObjectDatabase.GetById(67)).gameObject, player);
		}
	}

	public override void Pickup(PlayerController player)
	{
		((PassiveItem)this).Pickup(player);
		player.OnItemPurchased += OnItemPurchased;
	}

	public override DebrisObject Drop(PlayerController player)
	{
		DebrisObject result = ((PassiveItem)this).Drop(player);
		player.OnItemPurchased -= OnItemPurchased;
		return result;
	}

	public override void OnDestroy()
	{
		if (Object.op_Implicit((Object)(object)((PassiveItem)this).Owner))
		{
			((PassiveItem)this).Owner.OnItemPurchased -= OnItemPurchased;
		}
		((PassiveItem)this).OnDestroy();
	}
}
