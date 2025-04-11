using Alexandria.ItemAPI;
using Gungeon;

namespace NevernamedsItems;

public class FiftyCalRounds : PassiveItem
{
	public static int FiftyCalRoundsID;

	public static void Init()
	{
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		PickupObject val = ItemSetup.NewItem<FiftyCalRounds>("50. Cal Rounds", "Randy's Favourite", "These bullets are nothing special by Gungeon standards, but they do pack a decent punch.\n\nFavoured by a peculiar young Gungeoneer with even more peculiar tastes.", "50calrounds_icon", assetbundle: true);
		Game.Items.Rename("nn:50._cal_rounds", "nn:50_cal_rounds");
		ItemBuilder.AddPassiveStatModifier(val, (StatType)5, 1.16f, (ModifyMethod)1);
		ItemBuilder.AddPassiveStatModifier(val, (StatType)6, 1.25f, (ModifyMethod)1);
		val.quality = (ItemQuality)2;
		AlexandriaTags.SetTag(val, "bullet_modifier");
		ItemBuilder.AddToSubShop(val, (ShopType)3, 1f);
		FiftyCalRoundsID = val.PickupObjectId;
		Doug.AddToLootPool(val.PickupObjectId);
	}
}
