using UnityEngine;

namespace NevernamedsItems;

public class FaultyHoverboots : PassiveItem
{
	public bool isFlying = false;

	public static void Init()
	{
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		PickupObject obj = ItemSetup.NewItem<FaultyHoverboots>("Faulty Hoverboots", "Come Fly With Me", "Grants flight, but ceases to function upon dodge rolling. Resets every floor.\n\nConceptualised by a Turtle, and created by a lunatic with nothing better to do.", "workinprogress_icon", assetbundle: true);
		PassiveItem val = (PassiveItem)(object)((obj is PassiveItem) ? obj : null);
		((PickupObject)val).quality = (ItemQuality)(-100);
	}

	private void onDodgeRoll(PlayerController player, Vector2 dirVec)
	{
		ETGModConsole.Log((object)"You dodge rolled.", false);
		((GameActor)((PassiveItem)this).Owner).SetIsFlying(false, "faultyhoverboots", true, false);
		ETGModConsole.Log((object)"Flight was removed.", false);
	}

	private void OnNewFloor()
	{
		ETGModConsole.Log((object)"A new floor was loaded", false);
		((GameActor)((PassiveItem)this).Owner).SetIsFlying(true, "faultyhoverboots", true, false);
		ETGModConsole.Log((object)"Flight was given.", false);
	}

	public override DebrisObject Drop(PlayerController player)
	{
		DebrisObject result = ((PassiveItem)this).Drop(player);
		player.OnRollStarted -= onDodgeRoll;
		GameManager.Instance.OnNewLevelFullyLoaded -= OnNewFloor;
		ETGModConsole.Log((object)"The item was dropped.", false);
		((GameActor)((PassiveItem)this).Owner).SetIsFlying(false, "faultyhoverboots", true, false);
		ETGModConsole.Log((object)"Flight was removed", false);
		return result;
	}

	public override void Pickup(PlayerController player)
	{
		((PassiveItem)this).Pickup(player);
		player.OnRollStarted += onDodgeRoll;
		GameManager.Instance.OnNewLevelFullyLoaded += OnNewFloor;
		ETGModConsole.Log((object)"The item was picked up.", false);
		if (!base.m_pickedUpThisRun)
		{
			ETGModConsole.Log((object)"We passed the pickup check", false);
			((GameActor)player).SetIsFlying(true, "faultyhoverboots", true, false);
			ETGModConsole.Log((object)"Flight was given.", false);
		}
	}

	public override void OnDestroy()
	{
		GameManager.Instance.OnNewLevelFullyLoaded -= OnNewFloor;
		((PassiveItem)this).Owner.OnRollStarted -= onDodgeRoll;
		ETGModConsole.Log((object)"The item was destroyed.", false);
		((GameActor)((PassiveItem)this).Owner).SetIsFlying(false, "faultyhoverboots", true, false);
		ETGModConsole.Log((object)"Flight was removed", false);
		((PassiveItem)this).OnDestroy();
	}
}
