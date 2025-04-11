using Alexandria.ItemAPI;
using Alexandria.Misc;

namespace NevernamedsItems;

public class BlobulonRage : PassiveItem
{
	public static int BlobulonRageID;

	public static void Init()
	{
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		PickupObject val = ItemSetup.NewItem<BlobulonRage>("Blobulon Rage", "Long Live The Empire", "The berserker rage inherent to all Blobulons, now bestowed unto you.", "blobulonrage_icon", assetbundle: true);
		ItemBuilder.AddPassiveStatModifier(val, (StatType)5, 1.2f, (ModifyMethod)1);
		val.quality = (ItemQuality)2;
		BlobulonRageID = val.PickupObjectId;
		LootUtility.RemovePickupFromLootTables(val);
	}
}
