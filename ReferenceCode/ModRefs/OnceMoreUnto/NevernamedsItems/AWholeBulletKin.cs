using Alexandria.ItemAPI;

namespace NevernamedsItems;

public class AWholeBulletKin : PassiveItem
{
	public static int WholeBulletKinID;

	public static void Init()
	{
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		PickupObject obj = ItemSetup.NewItem<AWholeBulletKin>("A Whole Bullet Kin", "What.", "This is just... a bullet kin...\n\nIs he moving?... Is he alive? Comatose? Also WHAT?", "awholebulletkin_icon", assetbundle: true);
		PassiveItem val = (PassiveItem)(object)((obj is PassiveItem) ? obj : null);
		ItemBuilder.AddPassiveStatModifier((PickupObject)(object)val, (StatType)10, 0.8f, (ModifyMethod)1);
		((PickupObject)val).quality = (ItemQuality)1;
		WholeBulletKinID = ((PickupObject)val).PickupObjectId;
		AlexandriaTags.SetTag((PickupObject)(object)val, "non_companion_living_item");
	}
}
