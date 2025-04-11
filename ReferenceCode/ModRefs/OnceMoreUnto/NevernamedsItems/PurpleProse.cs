using System.Collections.Generic;
using Dungeonator;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

internal class PurpleProse : PassiveItem
{
	private GameActorCharmEffect charmEffect = ((Component)Game.Items["charming_rounds"]).GetComponent<BulletStatusEffectItem>().CharmModifierEffect;

	public static void Init()
	{
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		PickupObject obj = ItemSetup.NewItem<PurpleProse>("Purple Prose", "Pity Is A Powerful Weapon", "Charms all enemies in the room upon taking damage.\n\nA beautiful rose grown in some long lost floral garden deep within the gungeon. As you peel away it's petals, you find more inside, with seemingly no end. \n\nI guess you'll never find out if 'she loves you'.", "purpleprose_improved", assetbundle: true);
		PassiveItem val = (PassiveItem)(object)((obj is PassiveItem) ? obj : null);
		((PickupObject)val).quality = (ItemQuality)1;
	}

	private void charmAll(PlayerController user)
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
				((BraveBehaviour)val).gameActor.ApplyEffect((GameActorEffect)(object)charmEffect, 1f, (Projectile)null);
			}
		}
	}

	public override void Pickup(PlayerController player)
	{
		((PassiveItem)this).Pickup(player);
		player.OnReceivedDamage += charmAll;
	}

	public override DebrisObject Drop(PlayerController player)
	{
		DebrisObject result = ((PassiveItem)this).Drop(player);
		player.OnReceivedDamage -= charmAll;
		return result;
	}

	public override void OnDestroy()
	{
		if (Object.op_Implicit((Object)(object)((PassiveItem)this).Owner))
		{
			((PassiveItem)this).Owner.OnReceivedDamage -= charmAll;
		}
		((PassiveItem)this).OnDestroy();
	}
}
