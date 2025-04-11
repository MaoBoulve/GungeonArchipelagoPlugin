using System;
using System.Collections.Generic;
using Alexandria.ItemAPI;
using SaveAPI;
using UnityEngine;

namespace NevernamedsItems;

internal class ChanceKinEffigy : PassiveItem
{
	public static int ChanceEffigyID;

	public static List<int> lootIDlist = new List<int> { 78, 600, 565, 73, 85, 120 };

	public static void Init()
	{
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		PickupObject obj = ItemSetup.NewItem<ChanceKinEffigy>("Chance Effigy", "Guns Upon A Time", "Chance Kin drop bonus supplies.\n\nHailing from the same ludicrous sect who forged the Keybullet Effigy. Their religious rites, while inclusive of Chance Kin, rarely focus on them as they are perceived as lesser spirits.", "chanceeffigy_icon", assetbundle: true);
		PassiveItem val = (PassiveItem)(object)((obj is PassiveItem) ? obj : null);
		((PickupObject)val).quality = (ItemQuality)1;
		ChanceEffigyID = ((PickupObject)val).PickupObjectId;
		((PickupObject)(object)val).SetupUnlockOnCustomFlag(CustomDungeonFlags.KILLEDJAMMEDCHANCEKIN, requiredFlagValue: true);
	}

	private void OnKilledEnemy(PlayerController player, HealthHaver enemy)
	{
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_0086: Expected O, but got Unknown
		if (Object.op_Implicit((Object)(object)((PassiveItem)this).Owner) && Object.op_Implicit((Object)(object)((BraveBehaviour)enemy).aiActor) && (((BraveBehaviour)enemy).aiActor.EnemyGuid == "699cd24270af4cd183d671090d8323a1" || ((BraveBehaviour)enemy).aiActor.EnemyGuid == "a446c626b56d4166915a4e29869737fd") && CustomSynergies.PlayerHasActiveSynergy(((PassiveItem)this).Owner, "Luck of the Quickdraw"))
		{
			StatModifier item = new StatModifier
			{
				amount = 1.1f,
				statToBoost = (StatType)5,
				modifyType = (ModifyMethod)1
			};
			((PassiveItem)this).Owner.ownerlessStatModifiers.Add(item);
			((PassiveItem)this).Owner.stats.RecalculateStats(((PassiveItem)this).Owner, false, false);
		}
	}

	private void OnPreSpawn(AIActor actor)
	{
		if (Object.op_Implicit((Object)(object)((PassiveItem)this).Owner) && Object.op_Implicit((Object)(object)actor) && (actor.EnemyGuid == "699cd24270af4cd183d671090d8323a1" || actor.EnemyGuid == "a446c626b56d4166915a4e29869737fd"))
		{
			actor.AdditionalSafeItemDrops.Add(PickupObjectDatabase.GetById(BraveUtility.RandomElement<int>(lootIDlist)));
		}
	}

	private void OnEnteredCombat()
	{
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		if (Object.op_Implicit((Object)(object)((PassiveItem)this).Owner) && Random.value <= 0.015f)
		{
			AIActor orLoadByGuid = EnemyDatabase.GetOrLoadByGuid("a446c626b56d4166915a4e29869737fd");
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
		player.OnKilledEnemyContext += OnKilledEnemy;
		player.OnEnteredCombat = (Action)Delegate.Combine(player.OnEnteredCombat, new Action(OnEnteredCombat));
	}

	public override DebrisObject Drop(PlayerController player)
	{
		DebrisObject result = ((PassiveItem)this).Drop(player);
		player.OnKilledEnemyContext -= OnKilledEnemy;
		player.OnEnteredCombat = (Action)Delegate.Remove(player.OnEnteredCombat, new Action(OnEnteredCombat));
		AIActor.OnPreStart = (Action<AIActor>)Delegate.Remove(AIActor.OnPreStart, new Action<AIActor>(OnPreSpawn));
		return result;
	}

	public override void OnDestroy()
	{
		if (Object.op_Implicit((Object)(object)((PassiveItem)this).Owner))
		{
			((PassiveItem)this).Owner.OnKilledEnemyContext -= OnKilledEnemy;
			PlayerController owner = ((PassiveItem)this).Owner;
			owner.OnEnteredCombat = (Action)Delegate.Remove(owner.OnEnteredCombat, new Action(OnEnteredCombat));
		}
		AIActor.OnPreStart = (Action<AIActor>)Delegate.Remove(AIActor.OnPreStart, new Action<AIActor>(OnPreSpawn));
		((PassiveItem)this).OnDestroy();
	}
}
