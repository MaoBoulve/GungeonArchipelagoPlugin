using System;
using Dungeonator;
using UnityEngine;

namespace NevernamedsItems;

internal class FowlRing : PassiveItem
{
	public static int FowlRingID;

	public static void Init()
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		PickupObject val = ItemSetup.NewItem<FowlRing>("Fowl Ring", "Cluck Up", "One enemy per room becomes a chicken.\n\nA symbol of poultry affinity, manifesting one's most fowl desires.", "fowlring_icon", assetbundle: true);
		val.quality = (ItemQuality)1;
		FowlRingID = val.PickupObjectId;
	}

	private void EnteredCombat()
	{
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_0070: Expected O, but got Unknown
		if ((Object)(object)((PassiveItem)this).Owner != (Object)null && ((PassiveItem)this).Owner.CurrentRoom != null && ((PassiveItem)this).Owner.CurrentRoom.HasActiveEnemies((ActiveEnemyType)1))
		{
			AIActor randomActiveEnemy = ((PassiveItem)this).Owner.CurrentRoom.GetRandomActiveEnemy(false);
			randomActiveEnemy.Transmogrify(EnemyDatabase.GetOrLoadByGuid(EnemyGuidDatabase.Entries["chicken"]), (GameObject)ResourceCache.Acquire("Global VFX/VFX_Item_Spawn_Poof"));
		}
	}

	public override void Pickup(PlayerController player)
	{
		((PassiveItem)this).Pickup(player);
		player.OnEnteredCombat = (Action)Delegate.Combine(player.OnEnteredCombat, new Action(EnteredCombat));
	}

	public override DebrisObject Drop(PlayerController player)
	{
		DebrisObject result = ((PassiveItem)this).Drop(player);
		player.OnEnteredCombat = (Action)Delegate.Remove(player.OnEnteredCombat, new Action(EnteredCombat));
		return result;
	}

	public override void OnDestroy()
	{
		if (Object.op_Implicit((Object)(object)((PassiveItem)this).Owner))
		{
			PlayerController owner = ((PassiveItem)this).Owner;
			owner.OnEnteredCombat = (Action)Delegate.Remove(owner.OnEnteredCombat, new Action(EnteredCombat));
		}
		((PassiveItem)this).OnDestroy();
	}
}
