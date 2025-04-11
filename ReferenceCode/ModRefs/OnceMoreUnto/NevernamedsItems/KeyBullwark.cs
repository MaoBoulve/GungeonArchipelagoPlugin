using Alexandria.ItemAPI;
using UnityEngine;

namespace NevernamedsItems;

public class KeyBullwark : PassiveItem
{
	public static int KeyBulwarkID;

	public static void Init()
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		PickupObject val = ItemSetup.NewItem<KeyBullwark>("Key Bulwark", "Keyfensive Maneuver", "Converts all your keys into armour upon entering a new floor. Every key converted gives a small, permanent damage upgrade.", "keybulwark_icon", assetbundle: true);
		val.quality = (ItemQuality)3;
		ItemBuilder.AddToSubShop(val, (ShopType)1, 1f);
		KeyBulwarkID = val.PickupObjectId;
	}

	private void OnNewFloor()
	{
		PlayerController owner = ((PassiveItem)this).Owner;
		int keyBullets = owner.carriedConsumables.KeyBullets;
		HealthHaver healthHaver = ((BraveBehaviour)owner).healthHaver;
		healthHaver.Armor += (float)keyBullets;
		float num = (float)keyBullets * 0.05f;
		float baseStatValue = owner.stats.GetBaseStatValue((StatType)5);
		float num2 = baseStatValue + num;
		owner.stats.SetBaseStatValue((StatType)5, num2, owner);
		PlayerConsumables carriedConsumables = owner.carriedConsumables;
		carriedConsumables.KeyBullets -= keyBullets;
	}

	public override void Pickup(PlayerController player)
	{
		if (!base.m_pickedUpThisRun)
		{
			LootEngine.GivePrefabToPlayer(((Component)PickupObjectDatabase.GetById(67)).gameObject, player);
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
