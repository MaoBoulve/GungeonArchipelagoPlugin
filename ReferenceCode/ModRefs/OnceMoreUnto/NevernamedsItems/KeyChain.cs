using System;
using System.Reflection;
using Alexandria.ItemAPI;
using Gungeon;
using MonoMod.RuntimeDetour;
using UnityEngine;

namespace NevernamedsItems;

public class KeyChain : PassiveItem
{
	private Hook keyPickupHook = new Hook((MethodBase)typeof(KeyBulletPickup).GetMethod("Pickup", BindingFlags.Instance | BindingFlags.Public), typeof(KeyChain).GetMethod("keyPickupHookMethod"));

	public static void Init()
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		PickupObject val = ItemSetup.NewItem<KeyChain>("Keychain", "Chain Reaction", "25% chance to double any keys picked up.\n\nNobody quite understands how keys work in the Gungeon, but this thing apparently gives you more of them so who cares.", "keychain_icon", assetbundle: true);
		val.quality = (ItemQuality)3;
		ItemBuilder.AddToSubShop(val, (ShopType)1, 1f);
	}

	public static void keyPickupHookMethod(Action<KeyBulletPickup, PlayerController> orig, KeyBulletPickup self, PlayerController player)
	{
		orig(self, player);
		if (player.HasPickupID(Game.Items["nn:keychain"].PickupObjectId))
		{
			if (!self.IsRatKey && Random.value < 0.25f)
			{
				PlayerConsumables carriedConsumables = player.carriedConsumables;
				carriedConsumables.KeyBullets += 1;
			}
			else if (self.IsRatKey && Random.value < 0.1f)
			{
				PlayerConsumables carriedConsumables2 = player.carriedConsumables;
				carriedConsumables2.ResourcefulRatKeys += 1;
			}
		}
	}
}
