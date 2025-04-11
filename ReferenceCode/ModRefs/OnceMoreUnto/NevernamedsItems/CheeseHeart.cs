using SaveAPI;
using UnityEngine;

namespace NevernamedsItems;

internal class CheeseHeart : PassiveItem
{
	public static int CheeseHeartID;

	public static void Init()
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		PickupObject val = ItemSetup.NewItem<CheeseHeart>("Cheese Heart", "Eat Your Heart Out", "Sprays cheese everywhere on hit.\n\nCarefully sculpted, and completely anatomically correct!", "cheeseheart_icon", assetbundle: true);
		val.quality = (ItemQuality)2;
		val.SetupUnlockOnCustomFlag(CustomDungeonFlags.FAILEDRATMAZE, requiredFlagValue: true);
		CheeseHeartID = val.PickupObjectId;
	}

	public override void Pickup(PlayerController player)
	{
		player.OnReceivedDamage += OnHitEffect;
		((PassiveItem)this).Pickup(player);
	}

	public override void DisableEffect(PlayerController player)
	{
		if (Object.op_Implicit((Object)(object)player))
		{
			player.OnReceivedDamage -= OnHitEffect;
		}
		((PassiveItem)this).DisableEffect(player);
	}

	private void OnHitEffect(PlayerController user)
	{
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		DeadlyDeadlyGoopManager.GetGoopManagerForGoopType(EasyGoopDefinitions.CheeseDef).TimedAddGoopCircle(((BraveBehaviour)((PassiveItem)this).Owner).sprite.WorldCenter, 10f, 1f, false);
	}
}
