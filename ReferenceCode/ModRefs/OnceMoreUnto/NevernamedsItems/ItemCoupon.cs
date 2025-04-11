using System;
using System.Collections.Generic;
using Alexandria.ItemAPI;
using UnityEngine;

namespace NevernamedsItems;

public class ItemCoupon : PlayerItem
{
	private float duration = 5f;

	private bool playerHasMiserlyRing = false;

	private bool couponActive = false;

	private float priceChange = -1f;

	public static void Init()
	{
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		PickupObject obj = ItemSetup.NewItem<ItemCoupon>("Coupon", "100th Lucky Gungeoneer", "Entitles you to one free item at most Gungeon based merchanteering establishments. Simply use the coupon, and select your item in the alloted time.", "coupon_improved", assetbundle: true);
		PlayerItem val = (PlayerItem)(object)((obj is PlayerItem) ? obj : null);
		ItemBuilder.SetCooldownType(val, (CooldownType)3, 500f);
		((PickupObject)val).quality = (ItemQuality)3;
		List<string> list = new List<string> { "nn:coupon", "ring_of_miserly_protection" };
		CustomSynergies.Add("Livin' Off Discounts", list, (List<string>)null, true);
	}

	public override void DoEffect(PlayerController user)
	{
		if (user.HasPickupID(132))
		{
			playerHasMiserlyRing = true;
		}
		StartEffect(user);
		((MonoBehaviour)this).StartCoroutine(ItemBuilder.HandleDuration((PlayerItem)(object)this, duration, user, (Action<PlayerController>)EndEffect));
	}

	private void StartEffect(PlayerController user)
	{
		couponActive = true;
		float baseStatValue = user.stats.GetBaseStatValue((StatType)13);
		float num = baseStatValue * 0.001f;
		user.stats.SetBaseStatValue((StatType)13, num, user);
		float baseStatValue2 = user.stats.GetBaseStatValue((StatType)8);
		baseStatValue2 += 1f;
		user.stats.SetBaseStatValue((StatType)8, baseStatValue2, user);
		priceChange = baseStatValue - num;
	}

	private void EndEffect(PlayerController user)
	{
		if (!(priceChange <= 0f))
		{
			float baseStatValue = user.stats.GetBaseStatValue((StatType)13);
			float num = baseStatValue + priceChange;
			user.stats.SetBaseStatValue((StatType)13, num, user);
			float baseStatValue2 = user.stats.GetBaseStatValue((StatType)8);
			baseStatValue2 -= 1f;
			user.stats.SetBaseStatValue((StatType)8, baseStatValue2, user);
			priceChange = -1f;
			couponActive = false;
			playerHasMiserlyRing = false;
		}
	}

	private void OnItemPurchased(PlayerController player, ShopItemController obj)
	{
		if (!couponActive || priceChange <= 0f)
		{
			return;
		}
		float baseStatValue = player.stats.GetBaseStatValue((StatType)13);
		float num = baseStatValue + priceChange;
		player.stats.SetBaseStatValue((StatType)13, num, player);
		if (playerHasMiserlyRing && !player.HasPickupID(451))
		{
			PickupObject byId = PickupObjectDatabase.GetById(132);
			player.AcquirePassiveItemPrefabDirectly((PassiveItem)(object)((byId is PassiveItem) ? byId : null));
			if (player.ForceZeroHealthState)
			{
				LootEngine.GivePrefabToPlayer(((Component)PickupObjectDatabase.GetById(120)).gameObject, base.LastOwner);
				LootEngine.GivePrefabToPlayer(((Component)PickupObjectDatabase.GetById(120)).gameObject, base.LastOwner);
			}
		}
		else if (playerHasMiserlyRing && player.HasPickupID(451))
		{
			applyWeirdHealing();
		}
		float baseStatValue2 = player.stats.GetBaseStatValue((StatType)8);
		baseStatValue2 -= 1f;
		player.stats.SetBaseStatValue((StatType)8, baseStatValue2, player);
		priceChange = -1f;
		player.RemoveActiveItem(((PickupObject)this).PickupObjectId);
	}

	private void applyWeirdHealing()
	{
		((BraveBehaviour)base.LastOwner).healthHaver.ApplyHealing(2f);
		if (base.LastOwner.ForceZeroHealthState)
		{
			LootEngine.GivePrefabToPlayer(((Component)PickupObjectDatabase.GetById(120)).gameObject, base.LastOwner);
			LootEngine.GivePrefabToPlayer(((Component)PickupObjectDatabase.GetById(120)).gameObject, base.LastOwner);
		}
	}

	public override void OnPreDrop(PlayerController user)
	{
		if (((PlayerItem)this).IsCurrentlyActive)
		{
			((PlayerItem)this).IsCurrentlyActive = false;
			EndEffect(user);
		}
	}

	public override void Pickup(PlayerController player)
	{
		player.OnItemPurchased += OnItemPurchased;
		((PlayerItem)this).Pickup(player);
		((PickupObject)this).CanBeDropped = true;
	}

	public void Break()
	{
		base.m_pickedUp = true;
		Object.Destroy((Object)(object)((Component)this).gameObject, 1f);
	}

	public DebrisObject Drop(PlayerController player)
	{
		DebrisObject val = ((PlayerItem)this).Drop(player, 4f);
		player.OnItemPurchased -= OnItemPurchased;
		((PlayerItem)this).IsCurrentlyActive = false;
		EndEffect(player);
		ItemCoupon component = ((Component)val).GetComponent<ItemCoupon>();
		component.Break();
		return val;
	}
}
