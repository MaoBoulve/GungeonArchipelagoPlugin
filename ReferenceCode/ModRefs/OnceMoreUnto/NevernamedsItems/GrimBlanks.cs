using Alexandria.EnemyAPI;
using UnityEngine;

namespace NevernamedsItems;

public class GrimBlanks : PassiveItem
{
	public static void Init()
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		PickupObject val = ItemSetup.NewItem<GrimBlanks>("Grim Blanks", "Bullets Die With You", "Killing an enemy erases all of their bullets.\n\nThese special blanks are subtle, quiet, and highly targeted.", "grimblanks_icon", assetbundle: true);
		val.quality = (ItemQuality)1;
	}

	private void OnEnemyKilled(PlayerController player, HealthHaver enemy)
	{
		if (Object.op_Implicit((Object)(object)enemy) && Object.op_Implicit((Object)(object)((BraveBehaviour)enemy).aiActor))
		{
			AIActorUtility.DeleteOwnedBullets((GameActor)(object)((BraveBehaviour)enemy).aiActor, 1f, true);
		}
	}

	public override DebrisObject Drop(PlayerController player)
	{
		DebrisObject result = ((PassiveItem)this).Drop(player);
		player.OnKilledEnemyContext -= OnEnemyKilled;
		return result;
	}

	public override void Pickup(PlayerController player)
	{
		((PassiveItem)this).Pickup(player);
		player.OnKilledEnemyContext += OnEnemyKilled;
	}

	public override void OnDestroy()
	{
		if (Object.op_Implicit((Object)(object)((PassiveItem)this).Owner))
		{
			((PassiveItem)this).Owner.OnKilledEnemyContext -= OnEnemyKilled;
		}
		((PassiveItem)this).OnDestroy();
	}
}
