using Alexandria.ItemAPI;
using UnityEngine;

namespace NevernamedsItems;

internal class SharpKey : PlayerItem
{
	public static void Init()
	{
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		PickupObject obj = ItemSetup.NewItem<SharpKey>("Sharp Key", "SaKeyfice", "This key is hungry for sustenance so that it may lay its eggs, and spawn the next generation of keys.", "sharpkey_improved", assetbundle: true);
		PlayerItem val = (PlayerItem)(object)((obj is PlayerItem) ? obj : null);
		ItemBuilder.SetCooldownType(val, (CooldownType)0, 5f);
		ItemBuilder.AddPassiveStatModifier((PickupObject)(object)val, (StatType)14, 1f, (ModifyMethod)0);
		val.consumable = false;
		((PickupObject)val).quality = (ItemQuality)3;
		ItemBuilder.AddToSubShop((PickupObject)(object)val, (ShopType)1, 1f);
	}

	public override void DoEffect(PlayerController user)
	{
		AkSoundEngine.PostEvent("Play_OBJ_goldkey_pickup_01", ((Component)this).gameObject);
		LootEngine.GivePrefabToPlayer(((Component)PickupObjectDatabase.GetById(67)).gameObject, user);
		if (user.ForceZeroHealthState)
		{
			HealthHaver healthHaver = ((BraveBehaviour)user).healthHaver;
			healthHaver.Armor -= 2f;
		}
		else
		{
			((BraveBehaviour)user).healthHaver.ApplyHealing(-1.5f);
		}
	}

	public override bool CanBeUsed(PlayerController user)
	{
		if (user.ForceZeroHealthState)
		{
			return ((BraveBehaviour)user).healthHaver.Armor > 2f;
		}
		return ((BraveBehaviour)user).healthHaver.GetCurrentHealth() > 1.5f;
	}
}
