using System;
using System.Collections.Generic;
using Alexandria.ItemAPI;
using UnityEngine;

namespace NevernamedsItems;

public class Kevin : PassiveItem
{
	public static int KevinID;

	public GameActorCharmEffect charmEffect;

	public static void Init()
	{
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		PickupObject obj = ItemSetup.NewItem<Kevin>("Kevin", "Long Live the Keving", "What may appear at first to be the skinned face of a Bullet Kin is in fact the flag of the Sovereign Nation of Kevin.\n\nIn your time of need, the Sovereign Nation of Kevin's sole resident (Kevin) will join you in battle. No matter how many times he gets knocked down, he'll just keep getting back up.", "kevin_icon", assetbundle: true);
		PassiveItem val = (PassiveItem)(object)((obj is PassiveItem) ? obj : null);
		((PickupObject)val).quality = (ItemQuality)1;
		ItemBuilder.AddToSubShop((PickupObject)(object)val, (ShopType)2, 1f);
		List<string> list = new List<string> { "nn:kevin", "eyepatch" };
		CustomSynergies.Add("High Lord Kevin", list, (List<string>)null, true);
		AlexandriaTags.SetTag((PickupObject)(object)val, "non_companion_living_item");
		KevinID = ((PickupObject)val).PickupObjectId;
	}

	private void SpawnKevin()
	{
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		string text = ((!((PassiveItem)this).Owner.HasPickupID(118)) ? "01972dee89fc4404a5c408d50007dad5" : "70216cae6c1346309d86d4a0b4603045");
		PlayerController owner = ((PassiveItem)this).Owner;
		AIActor orLoadByGuid = EnemyDatabase.GetOrLoadByGuid(text);
		IntVector2? val = ((PassiveItem)this).Owner.CurrentRoom.GetRandomVisibleClearSpot(2, 2);
		AIActor val2 = AIActor.Spawn(((BraveBehaviour)orLoadByGuid).aiActor, val.Value, GameManager.Instance.Dungeon.data.GetAbsoluteRoomFromPosition(val.Value), true, (AwakenAnimationType)0, true);
		val2.CanTargetEnemies = true;
		val2.CanTargetPlayers = false;
		PhysicsEngine.Instance.RegisterOverlappingGhostCollisionExceptions(((BraveBehaviour)val2).specRigidbody, (int?)null, false);
		((Component)val2).gameObject.AddComponent<KillOnRoomClear>();
		val2.IsHarmlessEnemy = true;
		val2.IgnoreForRoomClear = true;
		val2.HandleReinforcementFallIntoRoom(0f);
		((Component)val2).gameObject.AddComponent<AIActorIsKevin>();
	}

	public override void Pickup(PlayerController player)
	{
		((PassiveItem)this).Pickup(player);
		player.OnEnteredCombat = (Action)Delegate.Combine(player.OnEnteredCombat, new Action(SpawnKevin));
	}

	public override DebrisObject Drop(PlayerController player)
	{
		DebrisObject result = ((PassiveItem)this).Drop(player);
		player.OnEnteredCombat = (Action)Delegate.Remove(player.OnEnteredCombat, new Action(SpawnKevin));
		return result;
	}

	public override void OnDestroy()
	{
		if (Object.op_Implicit((Object)(object)((PassiveItem)this).Owner))
		{
			PlayerController owner = ((PassiveItem)this).Owner;
			owner.OnEnteredCombat = (Action)Delegate.Remove(owner.OnEnteredCombat, new Action(SpawnKevin));
		}
		((PassiveItem)this).OnDestroy();
	}
}
