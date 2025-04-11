using System;
using System.Collections.Generic;
using Alexandria.ItemAPI;
using Dungeonator;

namespace NevernamedsItems;

public class Permafrost : PassiveItem
{
	public static void Init()
	{
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		PickupObject obj = ItemSetup.NewItem<Permafrost>("Permafrost", "Cold Snap", "This vengeful spirit brings with it the terrifying chill of oblivion.\n\nUse it wisely, and do not disrespect it.", "permafrost_icon", assetbundle: true);
		PassiveItem val = (PassiveItem)(object)((obj is PassiveItem) ? obj : null);
		ItemBuilder.AddPassiveStatModifier((PickupObject)(object)val, (StatType)14, 2f, (ModifyMethod)0);
		((PickupObject)val).quality = (ItemQuality)5;
		ItemBuilder.AddToSubShop((PickupObject)(object)val, (ShopType)2, 1f);
	}

	public void onEnteredCombat()
	{
		//IL_007f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			List<AIActor> activeEnemies = ((PassiveItem)this).Owner.CurrentRoom.GetActiveEnemies((ActiveEnemyType)0);
			if (activeEnemies == null)
			{
				return;
			}
			foreach (AIActor item in activeEnemies)
			{
				if (item.IsNormalEnemy)
				{
					float num = 0f;
					ApplyDirectStatusEffects.ApplyDirectFreeze(freezeAmount: (!((BraveBehaviour)item).healthHaver.IsBoss) ? 150f : 100f, target: ((BraveBehaviour)item).gameActor, duration: 3f, damageToDealOnUnfreeze: StaticStatusEffects.chaosBulletsFreeze.UnfreezeDamagePercent, tintColour: ExtendedColours.freezeBlue, deathTintColour: ExtendedColours.freezeBlue, resistanceType: (EffectResistanceType)0, identifier: "Permafrost", tintsEnemy: true, tintsCorpse: true);
				}
			}
		}
		catch (Exception ex)
		{
			ETGModConsole.Log((object)ex.Message, false);
			ETGModConsole.Log((object)ex.StackTrace, false);
		}
	}

	public override void Pickup(PlayerController player)
	{
		((PassiveItem)this).Pickup(player);
		player.OnEnteredCombat = (Action)Delegate.Combine(player.OnEnteredCombat, new Action(onEnteredCombat));
	}

	public override DebrisObject Drop(PlayerController player)
	{
		DebrisObject result = ((PassiveItem)this).Drop(player);
		player.OnEnteredCombat = (Action)Delegate.Remove(player.OnEnteredCombat, new Action(onEnteredCombat));
		return result;
	}

	public override void OnDestroy()
	{
		((PassiveItem)this).OnDestroy();
	}
}
