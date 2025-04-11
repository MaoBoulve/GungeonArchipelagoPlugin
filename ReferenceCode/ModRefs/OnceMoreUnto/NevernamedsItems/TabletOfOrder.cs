using System;
using Dungeonator;
using SaveAPI;
using UnityEngine;

namespace NevernamedsItems;

public class TabletOfOrder : PassiveItem
{
	private RoomHandler lastCheckedRoom;

	public static void Init()
	{
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		PickupObject obj = ItemSetup.NewItem<TabletOfOrder>("Tablet Of Order", "Everything In It's Place", "Buffs enemies, but removes their ability to call in reinforcements.\n\nAn ancient magical artefact once used by the Order of the True Gun to quell dissent in their ranks.", "tabletoforder_improved", assetbundle: true);
		PassiveItem val = (PassiveItem)(object)((obj is PassiveItem) ? obj : null);
		((PickupObject)val).quality = (ItemQuality)3;
		((PickupObject)(object)val).SetupUnlockOnCustomFlag(CustomDungeonFlags.CHALLENGE_WHATARMY_BEATEN, requiredFlagValue: true);
	}

	public override void Update()
	{
		if (Object.op_Implicit((Object)(object)((PassiveItem)this).Owner) && ((PassiveItem)this).Owner.CurrentRoom != null && ((PassiveItem)this).Owner.CurrentRoom != lastCheckedRoom)
		{
			((PassiveItem)this).Owner.CurrentRoom.ClearReinforcementLayers();
			lastCheckedRoom = ((PassiveItem)this).Owner.CurrentRoom;
		}
		((PassiveItem)this).Update();
	}

	public void AIActorMods(AIActor target)
	{
		if (Object.op_Implicit((Object)(object)target) && Object.op_Implicit((Object)(object)((BraveBehaviour)target).healthHaver) && !((BraveBehaviour)target).healthHaver.IsBoss)
		{
			float maxHealth = ((BraveBehaviour)target).healthHaver.GetMaxHealth();
			((BraveBehaviour)target).healthHaver.SetHealthMaximum(maxHealth * 1.5f, (float?)null, false);
			((BraveBehaviour)target).healthHaver.ForceSetCurrentHealth(maxHealth * 1.5f);
		}
	}

	public override void Pickup(PlayerController player)
	{
		((PassiveItem)this).Pickup(player);
		AIActor.OnPreStart = (Action<AIActor>)Delegate.Combine(AIActor.OnPreStart, new Action<AIActor>(AIActorMods));
	}

	public override DebrisObject Drop(PlayerController player)
	{
		DebrisObject result = ((PassiveItem)this).Drop(player);
		AIActor.OnPreStart = (Action<AIActor>)Delegate.Remove(AIActor.OnPreStart, new Action<AIActor>(AIActorMods));
		return result;
	}

	public override void OnDestroy()
	{
		AIActor.OnPreStart = (Action<AIActor>)Delegate.Remove(AIActor.OnPreStart, new Action<AIActor>(AIActorMods));
		((PassiveItem)this).OnDestroy();
	}
}
