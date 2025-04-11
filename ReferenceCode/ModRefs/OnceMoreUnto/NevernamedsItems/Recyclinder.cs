using Alexandria.ItemAPI;
using SaveAPI;
using UnityEngine;

namespace NevernamedsItems;

internal class Recyclinder : PlayerItem
{
	public static int RecyclinderID;

	private ItemQuality itemToGiveQuality = (ItemQuality)1;

	public static void Init()
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		PickupObject obj = ItemSetup.NewItem<Recyclinder>("Recyclinder", "Lean Green Machine", "An environmentally friendly alternative to the methane-belching Gun Munchers, the Recyclinder uses proprietary technology to convert guns into items of equal quality. Waste not, want not.\n\nIt's probably nanites. It's ALWAYS nanites with these things, right? I'm not just going cazy?", "recyclinder_icon", assetbundle: true);
		PlayerItem val = (PlayerItem)(object)((obj is PlayerItem) ? obj : null);
		ItemBuilder.SetCooldownType(val, (CooldownType)1, 200f);
		val.consumable = false;
		((PickupObject)val).quality = (ItemQuality)4;
		ItemBuilder.AddToSubShop((PickupObject)(object)val, (ShopType)3, 1f);
		((PickupObject)(object)val).SetupUnlockOnCustomFlag(CustomDungeonFlags.PURCHASED_RECYCLINDER, requiredFlagValue: true);
		RecyclinderID = ((PickupObject)val).PickupObjectId;
	}

	public override void DoEffect(PlayerController user)
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_0082: Unknown result type (might be due to invalid IL or missing references)
		//IL_0087: Unknown result type (might be due to invalid IL or missing references)
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		//IL_009b: Invalid comparison between Unknown and I4
		//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bf: Invalid comparison between Unknown and I4
		//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e3: Invalid comparison between Unknown and I4
		//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0104: Invalid comparison between Unknown and I4
		//IL_00ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_011f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0125: Invalid comparison between Unknown and I4
		//IL_010f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0157: Unknown result type (might be due to invalid IL or missing references)
		//IL_015c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0161: Unknown result type (might be due to invalid IL or missing references)
		//IL_0130: Unknown result type (might be due to invalid IL or missing references)
		if (user.CharacterUsesRandomGuns)
		{
			itemToGiveQuality = (ItemQuality)1;
			spawnRecycledItem();
			itemToGiveQuality = (ItemQuality)2;
			spawnRecycledItem();
			itemToGiveQuality = (ItemQuality)3;
			spawnRecycledItem();
			itemToGiveQuality = (ItemQuality)4;
			spawnRecycledItem();
			itemToGiveQuality = (ItemQuality)5;
			spawnRecycledItem();
			user.RemoveActiveItem(((PickupObject)this).PickupObjectId);
		}
		else if (((PickupObject)((GameActor)user).CurrentGun).CanActuallyBeDropped(user))
		{
			Gun currentGun = ((GameActor)user).CurrentGun;
			ItemQuality quality = ((PickupObject)currentGun).quality;
			user.inventory.DestroyCurrentGun();
			if ((int)((PickupObject)currentGun).quality == 1)
			{
				itemToGiveQuality = (ItemQuality)1;
				spawnRecycledItem();
			}
			else if ((int)((PickupObject)currentGun).quality == 2)
			{
				itemToGiveQuality = (ItemQuality)2;
				spawnRecycledItem();
			}
			else if ((int)((PickupObject)currentGun).quality == 3)
			{
				itemToGiveQuality = (ItemQuality)3;
				spawnRecycledItem();
			}
			else if ((int)((PickupObject)currentGun).quality == 4)
			{
				itemToGiveQuality = (ItemQuality)4;
				spawnRecycledItem();
			}
			else if ((int)((PickupObject)currentGun).quality == 5)
			{
				itemToGiveQuality = (ItemQuality)5;
				spawnRecycledItem();
			}
			else
			{
				LootEngine.SpawnItem(((Component)PickupObjectDatabase.GetById(127)).gameObject, Vector2.op_Implicit(((BraveBehaviour)base.LastOwner).specRigidbody.UnitCenter), Vector2.zero, 1f, false, true, false);
			}
		}
	}

	private void spawnRecycledItem()
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		PickupObject itemOfTypeAndQuality = LootEngine.GetItemOfTypeAndQuality<PickupObject>(itemToGiveQuality, GameManager.Instance.RewardManager.ItemsLootTable, false);
		LootEngine.SpawnItem(((Component)itemOfTypeAndQuality).gameObject, Vector2.op_Implicit(((BraveBehaviour)base.LastOwner).specRigidbody.UnitCenter), Vector2.left, 1f, false, true, false);
	}

	public override bool CanBeUsed(PlayerController user)
	{
		if (((PickupObject)((GameActor)user).CurrentGun).CanActuallyBeDropped(user))
		{
			return true;
		}
		return false;
	}
}
