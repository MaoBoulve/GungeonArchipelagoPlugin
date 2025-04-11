using System;
using Alexandria.ItemAPI;
using SaveAPI;
using UnityEngine;

namespace NevernamedsItems;

internal class KeyBulletEffigy : PassiveItem
{
	public static int KeybulletEffigyID;

	public static void Init()
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		PickupObject val = ItemSetup.NewItem<KeyBulletEffigy>("Keybullet Effigy", "Aimgels on High", "Keybullet Kin drop bonus keys.\n\nA holy item from a historical sect of Gun Cultists that worshipped Keybullet Kin as Aimgels of Kaliber, sent down from Bullet Heaven to deliver holy gifts.", "keybulleteffigy_icon", assetbundle: true);
		val.quality = (ItemQuality)1;
		ItemBuilder.AddToSubShop(val, (ShopType)2, 1f);
		ItemBuilder.AddToSubShop(val, (ShopType)1, 1f);
		KeybulletEffigyID = val.PickupObjectId;
		val.SetupUnlockOnCustomFlag(CustomDungeonFlags.KILLEDJAMMEDKEYBULLETKIN, requiredFlagValue: true);
	}

	private void OnPreSpawn(AIActor actor)
	{
		if (Object.op_Implicit((Object)(object)((PassiveItem)this).Owner) && Object.op_Implicit((Object)(object)actor) && (actor.EnemyGuid == "699cd24270af4cd183d671090d8323a1" || actor.EnemyGuid == "a446c626b56d4166915a4e29869737fd"))
		{
			actor.AdditionalSafeItemDrops.Add(PickupObjectDatabase.GetById(67));
			if (CustomSynergies.PlayerHasActiveSynergy(((PassiveItem)this).Owner, "Spare Kin"))
			{
				actor.AdditionalSafeItemDrops.Add(PickupObjectDatabase.GetById(67));
			}
		}
	}

	private void OnEnteredCombat()
	{
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		if (Object.op_Implicit((Object)(object)((PassiveItem)this).Owner) && Random.value <= 0.015f)
		{
			AIActor orLoadByGuid = EnemyDatabase.GetOrLoadByGuid("699cd24270af4cd183d671090d8323a1");
			IntVector2? val = ((PassiveItem)this).Owner.CurrentRoom.GetRandomVisibleClearSpot(1, 1);
			if (val.HasValue)
			{
				AIActor val2 = AIActor.Spawn(((BraveBehaviour)orLoadByGuid).aiActor, val.Value, GameManager.Instance.Dungeon.data.GetAbsoluteRoomFromPosition(val.Value), true, (AwakenAnimationType)0, true);
				PhysicsEngine.Instance.RegisterOverlappingGhostCollisionExceptions(((BraveBehaviour)val2).specRigidbody, (int?)null, false);
				val2.HandleReinforcementFallIntoRoom(0f);
			}
		}
	}

	public override void Pickup(PlayerController player)
	{
		((PassiveItem)this).Pickup(player);
		AIActor.OnPreStart = (Action<AIActor>)Delegate.Combine(AIActor.OnPreStart, new Action<AIActor>(OnPreSpawn));
		player.OnEnteredCombat = (Action)Delegate.Combine(player.OnEnteredCombat, new Action(OnEnteredCombat));
	}

	public override DebrisObject Drop(PlayerController player)
	{
		DebrisObject result = ((PassiveItem)this).Drop(player);
		player.OnEnteredCombat = (Action)Delegate.Remove(player.OnEnteredCombat, new Action(OnEnteredCombat));
		AIActor.OnPreStart = (Action<AIActor>)Delegate.Remove(AIActor.OnPreStart, new Action<AIActor>(OnPreSpawn));
		return result;
	}

	public override void OnDestroy()
	{
		if (Object.op_Implicit((Object)(object)((PassiveItem)this).Owner))
		{
			PlayerController owner = ((PassiveItem)this).Owner;
			owner.OnEnteredCombat = (Action)Delegate.Remove(owner.OnEnteredCombat, new Action(OnEnteredCombat));
		}
		AIActor.OnPreStart = (Action<AIActor>)Delegate.Remove(AIActor.OnPreStart, new Action<AIActor>(OnPreSpawn));
		((PassiveItem)this).OnDestroy();
	}
}
