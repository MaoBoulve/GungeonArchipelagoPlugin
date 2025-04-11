using System;
using System.Collections.Generic;
using Dungeonator;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

internal class DragunsScale : PassiveItem
{
	private GameActorFireEffect fireEffect = ((Component)Game.Items["hot_lead"]).GetComponent<BulletStatusEffectItem>().FireModifierEffect;

	public static void Init()
	{
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		PickupObject obj = ItemSetup.NewItem<DragunsScale>("Dragun Scale", "Burning Rage", "This shelldrake scale is full of heat energy, that may be released in a fiery inferno if certain conditions are met.", "dragunscale_improved", assetbundle: true);
		PassiveItem val = (PassiveItem)(object)((obj is PassiveItem) ? obj : null);
		((PickupObject)val).quality = (ItemQuality)3;
	}

	private void IgniteAll(PlayerController user)
	{
		List<AIActor> activeEnemies = user.CurrentRoom.GetActiveEnemies((ActiveEnemyType)0);
		if (activeEnemies == null)
		{
			return;
		}
		for (int i = 0; i < activeEnemies.Count; i++)
		{
			AIActor val = activeEnemies[i];
			if (val.IsNormalEnemy)
			{
				((BraveBehaviour)val).gameActor.ApplyEffect((GameActorEffect)(object)fireEffect, 1f, (Projectile)null);
			}
		}
	}

	private void HandleActiveItemUsed(PlayerController arg1, PlayerItem arg2)
	{
		IgniteAll(((PassiveItem)this).Owner);
	}

	private void CheckForSynergy(FlippableCover obj)
	{
		if (((PassiveItem)this).Owner.HasPickupID(666))
		{
			IgniteAll(((PassiveItem)this).Owner);
		}
	}

	public override void Pickup(PlayerController player)
	{
		((PassiveItem)this).Pickup(player);
		player.OnReceivedDamage += IgniteAll;
		player.OnUsedPlayerItem += HandleActiveItemUsed;
		player.OnTableFlipped = (Action<FlippableCover>)Delegate.Combine(player.OnTableFlipped, new Action<FlippableCover>(CheckForSynergy));
		if (!base.m_pickedUpThisRun)
		{
			LootEngine.GivePrefabToPlayer(((Component)PickupObjectDatabase.GetById(120)).gameObject, player);
		}
	}

	public override DebrisObject Drop(PlayerController player)
	{
		DebrisObject result = ((PassiveItem)this).Drop(player);
		player.OnReceivedDamage -= IgniteAll;
		player.OnUsedPlayerItem -= HandleActiveItemUsed;
		player.OnTableFlipped = (Action<FlippableCover>)Delegate.Remove(player.OnTableFlipped, new Action<FlippableCover>(CheckForSynergy));
		return result;
	}

	public override void OnDestroy()
	{
		if (Object.op_Implicit((Object)(object)((PassiveItem)this).Owner))
		{
			((PassiveItem)this).Owner.OnReceivedDamage -= IgniteAll;
			((PassiveItem)this).Owner.OnUsedPlayerItem -= HandleActiveItemUsed;
			((PassiveItem)this).Owner.OnTableFlipped = (Action<FlippableCover>)Delegate.Remove(((PassiveItem)this).Owner.OnTableFlipped, new Action<FlippableCover>(CheckForSynergy));
		}
		((PassiveItem)this).OnDestroy();
	}
}
