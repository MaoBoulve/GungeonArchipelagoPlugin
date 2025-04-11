using System;
using Alexandria.ItemAPI;
using Alexandria.Misc;
using UnityEngine;

namespace NevernamedsItems;

public class Blanket : BlankModificationItem
{
	private static int ID;

	public static void Init()
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		PickupObject val = ItemSetup.NewItem<Blanket>("Blanket", "Security", "Chance to refund used blanks.\n\nWrapping yourself in this child's blanket makes you feel safe, calm, and itchy.", "blanket_icon", assetbundle: true);
		val.quality = (ItemQuality)3;
		ItemBuilder.AddToSubShop(val, (ShopType)4, 1f);
		ID = val.PickupObjectId;
		AlexandriaTags.SetTag(val, "ammolet");
	}

	public override void Pickup(PlayerController player)
	{
		player.OnUsedBlank += BlankSpent;
		ExtendedPlayerComponent extComp = PlayerUtility.GetExtComp(player);
		extComp.OnBlankModificationItemProcessed = (Action<PlayerController, SilencerInstance, Vector2, BlankModificationItem>)Delegate.Combine(extComp.OnBlankModificationItemProcessed, new Action<PlayerController, SilencerInstance, Vector2, BlankModificationItem>(OnBlankModTriggered));
		((BlankModificationItem)this).Pickup(player);
	}

	public override void DisableEffect(PlayerController player)
	{
		player.OnUsedBlank -= BlankSpent;
		ExtendedPlayerComponent extComp = PlayerUtility.GetExtComp(player);
		extComp.OnBlankModificationItemProcessed = (Action<PlayerController, SilencerInstance, Vector2, BlankModificationItem>)Delegate.Remove(extComp.OnBlankModificationItemProcessed, new Action<PlayerController, SilencerInstance, Vector2, BlankModificationItem>(OnBlankModTriggered));
		((PassiveItem)this).DisableEffect(player);
	}

	private void BlankSpent(PlayerController player, int what)
	{
		if (Random.value <= 0.5f)
		{
			player.BloopItemAboveHead(((BraveBehaviour)PickupObjectDatabase.GetById(224)).sprite, "");
			LootEngine.GivePrefabToPlayer(((Component)PickupObjectDatabase.GetById(224)).gameObject, player);
		}
	}

	private void OnBlankModTriggered(PlayerController user, SilencerInstance blank, Vector2 pos, BlankModificationItem item)
	{
		if ((Object)(object)item == (Object)(object)this && (Object)(object)user != (Object)null && CustomSynergies.PlayerHasActiveSynergy(user, "My Favourite Blankie") && Random.value <= 0.1f && user.IsInCombat)
		{
			user.BloopItemAboveHead(((BraveBehaviour)PickupObjectDatabase.GetById(224)).sprite, "");
			LootEngine.GivePrefabToPlayer(((Component)PickupObjectDatabase.GetById(224)).gameObject, user);
		}
	}
}
