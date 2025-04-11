using Alexandria.ItemAPI;
using UnityEngine;

namespace NevernamedsItems;

internal class HeartOfGold : PassiveItem
{
	public static int HeartOfGoldID;

	public static void Init()
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		PickupObject val = ItemSetup.NewItem<HeartOfGold>("Heart of Gold", "Red Gold", "Squirts out some cash upon it's bearer taking damage.\n\nA small statue of a much larger and far more hostile golden heart discovered deep underground...", "heartofgold_icon", assetbundle: true);
		val.quality = (ItemQuality)2;
		HeartOfGoldID = val.PickupObjectId;
	}

	private void giveCash(PlayerController user)
	{
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		int num = 10;
		if (CustomSynergies.PlayerHasActiveSynergy(((PassiveItem)this).Owner, "Do-Gooder"))
		{
			num *= 2;
		}
		LootEngine.SpawnCurrency(((BraveBehaviour)user).sprite.WorldCenter, num, false);
	}

	public override void Pickup(PlayerController player)
	{
		((PassiveItem)this).Pickup(player);
		player.OnReceivedDamage += giveCash;
	}

	public override DebrisObject Drop(PlayerController player)
	{
		DebrisObject result = ((PassiveItem)this).Drop(player);
		player.OnReceivedDamage -= giveCash;
		return result;
	}

	public override void OnDestroy()
	{
		if (Object.op_Implicit((Object)(object)((PassiveItem)this).Owner))
		{
			((PassiveItem)this).Owner.OnReceivedDamage -= giveCash;
		}
		((PassiveItem)this).OnDestroy();
	}
}
