using System;
using UnityEngine;

namespace NevernamedsItems;

internal class ColdOne : PassiveItem
{
	public static void Init()
	{
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		PickupObject obj = ItemSetup.NewItem<ColdOne>("Cold One", "Brewsky", "Cools off active items when taking damage.\n\nLizard blue flavour.", "coldone_icon", assetbundle: true);
		PassiveItem val = (PassiveItem)(object)((obj is PassiveItem) ? obj : null);
		((PickupObject)val).quality = (ItemQuality)1;
	}

	private void Cooloff(PlayerController user)
	{
		if ((Object)(object)user.CurrentItem != (Object)null)
		{
			user.CurrentItem.remainingRoomCooldown = Math.Max(0, user.CurrentItem.remainingRoomCooldown - 1);
			user.CurrentItem.remainingTimeCooldown = Mathf.Max(0f, user.CurrentItem.remainingTimeCooldown - 5f);
			user.CurrentItem.remainingDamageCooldown = Mathf.Max(0f, user.CurrentItem.remainingDamageCooldown - 500f);
		}
	}

	public override void Pickup(PlayerController player)
	{
		((PassiveItem)this).Pickup(player);
		player.OnReceivedDamage += Cooloff;
	}

	public override void DisableEffect(PlayerController player)
	{
		if (Object.op_Implicit((Object)(object)player))
		{
			player.OnReceivedDamage -= Cooloff;
		}
		((PassiveItem)this).DisableEffect(player);
	}
}
