using System;
using System.Collections.Generic;
using Alexandria.DungeonAPI;
using Alexandria.ItemAPI;
using UnityEngine;

namespace NevernamedsItems;

internal class Pestilence : PassiveItem
{
	public static void Init()
	{
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		PickupObject obj = ItemSetup.NewItem<Pestilence>("Pestilence", "Yersinia Bestis", "Afflicts one enemy per room with a deadly plague.\n\nA tiny bundle of DNA molecules that directly attacks the shells that make up Gundead bodies.", "pestilence_icon", assetbundle: true);
		PassiveItem val = (PassiveItem)(object)((obj is PassiveItem) ? obj : null);
		((PickupObject)val).quality = (ItemQuality)2;
		ItemBuilder.AddToSubShop((PickupObject)(object)val, (ShopType)0, 1f);
	}

	public override void Pickup(PlayerController player)
	{
		player.OnEnteredCombat = (Action)Delegate.Combine(player.OnEnteredCombat, new Action(OnEnteredCombat));
		((PassiveItem)this).Pickup(player);
	}

	public override DebrisObject Drop(PlayerController player)
	{
		player.OnEnteredCombat = (Action)Delegate.Remove(player.OnEnteredCombat, new Action(OnEnteredCombat));
		return ((PassiveItem)this).Drop(player);
	}

	public override void OnDestroy()
	{
		if (Object.op_Implicit((Object)(object)((PassiveItem)this).Owner))
		{
			PlayerController owner = ((PassiveItem)this).Owner;
			owner.OnEnteredCombat = (Action)Delegate.Remove(owner.OnEnteredCombat, new Action(OnEnteredCombat));
		}
		((PassiveItem)this).OnDestroy();
	}

	private void OnEnteredCombat()
	{
		if (!Object.op_Implicit((Object)(object)((PassiveItem)this).Owner))
		{
			return;
		}
		if (CustomSynergies.PlayerHasActiveSynergy(((PassiveItem)this).Owner, "Multimorbidities"))
		{
			List<AIActor> xEnemiesInRoom = RoomUtility.GetXEnemiesInRoom(((PassiveItem)this).Owner.CurrentRoom, 2, true, true);
			{
				foreach (AIActor item in xEnemiesInRoom)
				{
					((GameActor)item).ApplyEffect((GameActorEffect)(object)StaticStatusEffects.StandardPlagueEffect, 1f, (Projectile)null);
				}
				return;
			}
		}
		AIActor randomActiveEnemy = ((PassiveItem)this).Owner.CurrentRoom.GetRandomActiveEnemy(false);
		if (Object.op_Implicit((Object)(object)randomActiveEnemy) && Object.op_Implicit((Object)(object)((BraveBehaviour)randomActiveEnemy).healthHaver))
		{
			((GameActor)randomActiveEnemy).ApplyEffect((GameActorEffect)(object)StaticStatusEffects.StandardPlagueEffect, 1f, (Projectile)null);
		}
	}
}
