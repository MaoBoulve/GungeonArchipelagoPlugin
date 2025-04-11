using Alexandria.ItemAPI;
using SaveAPI;
using UnityEngine;

namespace NevernamedsItems;

internal class TrueBlank : ReusableBlankitem
{
	public static void Init()
	{
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		PickupObject obj = ItemSetup.NewItem<TrueBlank>("True Blank", "Blanktism", "Triggers a blank with no cooldown, but costs 0.5 curse to use.\n\nOf all the blanks that have ever shaken the Gungeon's halls, this one is rumoured to be the very first. Torn from the casing of Kaliber and moulded with her blessing.\n\nGives 2.5 curse to get the ball rolling.", "trueblank_icon", assetbundle: true);
		PlayerItem val = (PlayerItem)(object)((obj is PlayerItem) ? obj : null);
		ItemBuilder.SetCooldownType(val, (CooldownType)3, 5f);
		ItemBuilder.AddPassiveStatModifier((PickupObject)(object)val, (StatType)14, 2.5f, (ModifyMethod)0);
		val.consumable = false;
		((PickupObject)val).quality = (ItemQuality)5;
		ItemBuilder.AddToSubShop((PickupObject)(object)val, (ShopType)4, 1f);
		((PickupObject)(object)val).SetupUnlockOnCustomFlag(CustomDungeonFlags.USED_FALSE_BLANK_TEN_TIMES, requiredFlagValue: true);
	}

	public override void DoEffect(PlayerController user)
	{
		float statValue = user.stats.GetStatValue((StatType)14);
		if (statValue > 0.5f)
		{
			float baseStatValue = user.stats.GetBaseStatValue((StatType)14);
			user.ForceBlank(25f, 0.5f, false, true, (Vector2?)null, true, -1f);
			baseStatValue -= 0.5f;
			user.stats.SetBaseStatValue((StatType)14, baseStatValue, user);
		}
		else
		{
			ETGModConsole.Log((object)"ERROR: \"The True Blank doesn't think you have any curse. You should never see this message unless you've encountered a bug.\" - NN", false);
		}
	}

	public override bool CanBeUsed(PlayerController user)
	{
		return (double)user.stats.GetStatValue((StatType)14) > 0.5;
	}
}
