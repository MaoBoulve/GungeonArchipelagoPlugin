using Alexandria.ItemAPI;
using Dungeonator;
using UnityEngine;

namespace NevernamedsItems;

internal class GSwitch : PlayerItem
{
	public static int GSwitchID;

	public static void Init()
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		PickupObject obj = ItemSetup.NewItem<GSwitch>("G-Switch", "Wahoo!", "Turns cash into a protective barrier.\n\nThis particular G-Switch once ruled a part of the Keep as a usurper, before eventually being dethroned from within it's G-Switch Palace.", "gswitch_icon", assetbundle: true);
		PlayerItem val = (PlayerItem)(object)((obj is PlayerItem) ? obj : null);
		ItemBuilder.SetCooldownType(val, (CooldownType)0, 1f);
		val.consumable = false;
		((PickupObject)val).quality = (ItemQuality)1;
		GSwitchID = ((PickupObject)val).PickupObjectId;
	}

	public override void DoEffect(PlayerController user)
	{
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		if (CustomSynergies.PlayerHasActiveSynergy(user, "G is for Gain"))
		{
			PlayerConsumables carriedConsumables = user.carriedConsumables;
			carriedConsumables.Currency -= 1;
		}
		else
		{
			PlayerConsumables carriedConsumables2 = user.carriedConsumables;
			carriedConsumables2.Currency -= 3;
		}
		MiscToolbox.SpawnShield(user, Vector2.op_Implicit(((BraveBehaviour)user).sprite.WorldCenter));
		if (CustomSynergies.PlayerHasActiveSynergy(user, "Prototype Form"))
		{
			DoSynergyShields(user.CurrentRoom, user);
		}
	}

	private void DoSynergyShields(RoomHandler room, PlayerController user)
	{
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		CurrencyPickup[] array = Object.FindObjectsOfType<CurrencyPickup>();
		CurrencyPickup[] array2 = array;
		foreach (CurrencyPickup val in array2)
		{
			if (Vector3Extensions.GetAbsoluteRoom(((BraveBehaviour)val).transform.position) == room)
			{
				MiscToolbox.SpawnShield(user, Vector2.op_Implicit(((BraveBehaviour)val).sprite.WorldCenter));
			}
		}
	}

	public override bool CanBeUsed(PlayerController user)
	{
		if (user.HasPickupID(376))
		{
			if (user.carriedConsumables.Currency >= 1)
			{
				return true;
			}
			return false;
		}
		if (user.carriedConsumables.Currency >= 3)
		{
			return true;
		}
		return false;
	}

	public override void Pickup(PlayerController player)
	{
		((PlayerItem)this).Pickup(player);
	}
}
