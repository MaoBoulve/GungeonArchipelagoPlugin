using System;
using System.Collections.Generic;
using Alexandria.ItemAPI;
using Dungeonator;
using SaveAPI;
using UnityEngine;

namespace NevernamedsItems;

public class GoomperorsCrown : PassiveItem
{
	public bool ShouldSlowThisRoom;

	public static void Init()
	{
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		PickupObject obj = ItemSetup.NewItem<GoomperorsCrown>("Goomperors Crown", "The Slime Must Flow", "The crown of the ancient Blobulonian emperor Gool Atinous.\n\nChance to slow down entire rooms!", "goomperorscrown_icon", assetbundle: true);
		PassiveItem val = (PassiveItem)(object)((obj is PassiveItem) ? obj : null);
		((PickupObject)val).quality = (ItemQuality)5;
		ItemBuilder.AddToSubShop((PickupObject)(object)val, (ShopType)0, 1f);
		((PickupObject)(object)val).SetupUnlockOnCustomFlag(CustomDungeonFlags.PURCHASED_GOOMPERORSCROWN, requiredFlagValue: true);
		((PickupObject)(object)val).AddItemToGooptonMetaShop(30, null);
	}

	public void AIActorMods(AIActor target)
	{
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		if (ShouldSlowThisRoom && Object.op_Implicit((Object)(object)target) && Object.op_Implicit((Object)(object)((BraveBehaviour)target).aiActor) && ((BraveBehaviour)target).aiActor.EnemyGuid != null)
		{
			ApplyDirectStatusEffects.ApplyDirectSlow((GameActor)(object)target, 1E+10f, 0.75f, Color.white, Color.white, (EffectResistanceType)0, "Goomperors Crown", tintsEnemy: false, tintsCorpse: false);
		}
	}

	public void onEnteredCombat()
	{
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		if (Random.value < 0.25f)
		{
			ShouldSlowThisRoom = true;
		}
		else
		{
			ShouldSlowThisRoom = false;
		}
		if (!ShouldSlowThisRoom)
		{
			return;
		}
		List<AIActor> activeEnemies = ((PassiveItem)this).Owner.CurrentRoom.GetActiveEnemies((ActiveEnemyType)0);
		if (activeEnemies == null)
		{
			return;
		}
		for (int i = 0; i < activeEnemies.Count; i++)
		{
			AIActor val = activeEnemies[i];
			if (val.IsNormalEnemy)
			{
				ApplyDirectStatusEffects.ApplyDirectSlow(((BraveBehaviour)val).gameActor, 1E+10f, 0.75f, Color.white, Color.white, (EffectResistanceType)0, "Goomperors Crown", tintsEnemy: false, tintsCorpse: false);
			}
		}
	}

	private void onRoomCleared(PlayerController player)
	{
		ShouldSlowThisRoom = false;
	}

	public override void Pickup(PlayerController player)
	{
		((PassiveItem)this).Pickup(player);
		AIActor.OnPreStart = (Action<AIActor>)Delegate.Combine(AIActor.OnPreStart, new Action<AIActor>(AIActorMods));
		player.OnEnteredCombat = (Action)Delegate.Combine(player.OnEnteredCombat, new Action(onEnteredCombat));
		player.OnRoomClearEvent += onRoomCleared;
	}

	public override DebrisObject Drop(PlayerController player)
	{
		DebrisObject result = ((PassiveItem)this).Drop(player);
		AIActor.OnPreStart = (Action<AIActor>)Delegate.Remove(AIActor.OnPreStart, new Action<AIActor>(AIActorMods));
		player.OnEnteredCombat = (Action)Delegate.Remove(player.OnEnteredCombat, new Action(onEnteredCombat));
		player.OnRoomClearEvent -= onRoomCleared;
		return result;
	}

	public override void OnDestroy()
	{
		AIActor.OnPreStart = (Action<AIActor>)Delegate.Remove(AIActor.OnPreStart, new Action<AIActor>(AIActorMods));
		((PassiveItem)this).OnDestroy();
	}
}
