using System.Collections.Generic;
using Alexandria.ItemAPI;
using Dungeonator;
using UnityEngine;

namespace NevernamedsItems;

internal class OpulentBlank : PlayerItem
{
	public static void Init()
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		PickupObject obj = ItemSetup.NewItem<OpulentBlank>("Opulent Blank", "Spin Bullets To Gold", "Turns all enemy bullets to gold. One use.\n\nAn extremely rare variant of the regular Blank.", "opulentblank_icon", assetbundle: true);
		PlayerItem val = (PlayerItem)(object)((obj is PlayerItem) ? obj : null);
		ItemBuilder.SetCooldownType(val, (CooldownType)3, 1000f);
		val.consumable = true;
		((PickupObject)val).quality = (ItemQuality)1;
		ItemBuilder.AddToSubShop((PickupObject)(object)val, (ShopType)4, 1f);
	}

	public override void DoEffect(PlayerController user)
	{
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_0107: Unknown result type (might be due to invalid IL or missing references)
		for (int i = 0; i < StaticReferenceManager.AllProjectiles.Count; i++)
		{
			Projectile val = StaticReferenceManager.AllProjectiles[i];
			if (Object.op_Implicit((Object)(object)val) && !(val.Owner is PlayerController) && (val.collidesWithPlayer || val.Owner is AIActor) && !val.ImmuneToBlanks)
			{
				LootEngine.SpawnCurrency(((BraveBehaviour)val).specRigidbody.UnitCenter, 1, false);
			}
		}
		if (CustomSynergies.PlayerHasActiveSynergy(user, "Wealth Untold") && user.CurrentRoom != null)
		{
			List<AIActor> activeEnemies = user.CurrentRoom.GetActiveEnemies((ActiveEnemyType)0);
			if (activeEnemies != null)
			{
				for (int j = 0; j < activeEnemies.Count; j++)
				{
					AIActor val2 = activeEnemies[j];
					if (val2.IsNormalEnemy)
					{
						((BraveBehaviour)val2).gameActor.ApplyEffect((GameActorEffect)(object)new GameActorGildedEffect
						{
							duration = 50f,
							stackMode = (EffectStackingMode)0
						}, 1f, (Projectile)null);
					}
				}
			}
		}
		user.ForceBlank(25f, 0.5f, false, true, (Vector2?)null, true, -1f);
	}
}
