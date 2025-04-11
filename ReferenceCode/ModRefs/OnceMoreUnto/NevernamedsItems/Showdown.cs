using System;
using System.Collections.Generic;
using Alexandria.ItemAPI;
using Dungeonator;
using UnityEngine;

namespace NevernamedsItems;

public class Showdown : PassiveItem
{
	public static void Init()
	{
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		PickupObject obj = ItemSetup.NewItem<Showdown>("Showdown", "Now it's just you and me...", "Prevents bosses from being able to spawn additional backup.\n\nAn icon of the one-on-one gunfights of days gone by.", "showdown_improved", assetbundle: true);
		PassiveItem val = (PassiveItem)(object)((obj is PassiveItem) ? obj : null);
		((PickupObject)val).quality = (ItemQuality)1;
	}

	public void AIActorMods(AIActor target)
	{
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Invalid comparison between Unknown and I4
		//IL_010d: Unknown result type (might be due to invalid IL or missing references)
		if (((BraveBehaviour)target).healthHaver.IsBoss || (int)((DungeonPlaceableBehaviour)target).GetAbsoluteParentRoom().area.PrototypeRoomCategory != 3 || (target.IsHarmlessEnemy && !(target.EnemyGuid == EnemyGuidDatabase.Entries["mine_flayers_claymore"])) || !((DungeonPlaceableBehaviour)target).GetAbsoluteParentRoom().IsSealed)
		{
			return;
		}
		if (CustomSynergies.PlayerHasActiveSynergy(((PassiveItem)this).Owner, "Frenemies"))
		{
			((GameActor)target).ApplyEffect((GameActorEffect)(object)GameManager.Instance.Dungeon.sharedSettingsPrefab.DefaultPermanentCharmEffect, 1f, (Projectile)null);
			target.IsHarmlessEnemy = true;
		}
		else
		{
			target.EraseFromExistenceWithRewards(true);
		}
		if (!CustomSynergies.PlayerHasActiveSynergy(((PassiveItem)this).Owner, "Dirty Tricks"))
		{
			return;
		}
		List<AIActor> activeEnemies = ((DungeonPlaceableBehaviour)target).GetAbsoluteParentRoom().GetActiveEnemies((ActiveEnemyType)0);
		if (activeEnemies == null)
		{
			return;
		}
		for (int i = 0; i < activeEnemies.Count; i++)
		{
			AIActor val = activeEnemies[i];
			if (((BraveBehaviour)val).healthHaver.IsBoss)
			{
				((BraveBehaviour)val).healthHaver.ApplyDamage(50f, Vector2.zero, "Dirty Tricks", (CoreDamageTypes)0, (DamageCategory)5, true, (PixelCollider)null, true);
			}
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
