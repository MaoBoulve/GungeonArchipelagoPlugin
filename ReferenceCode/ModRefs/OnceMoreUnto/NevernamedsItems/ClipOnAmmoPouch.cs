using Alexandria.ItemAPI;
using UnityEngine;

namespace NevernamedsItems;

internal class ClipOnAmmoPouch : PlayerItem
{
	public static void Init()
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		PickupObject obj = ItemSetup.NewItem<ClipOnAmmoPouch>("Clip-On Ammo Pouch", "Ammo Up", "Increases the ammo capacity of the held gun by 50%.\n\nClips on easy, and doesn't leave a mark!", "cliponammopouch_icon", assetbundle: true);
		PlayerItem val = (PlayerItem)(object)((obj is PlayerItem) ? obj : null);
		ItemBuilder.SetCooldownType(val, (CooldownType)3, 1000f);
		val.consumable = true;
		((PickupObject)val).quality = (ItemQuality)1;
		ItemBuilder.AddToSubShop((PickupObject)(object)val, (ShopType)3, 1f);
	}

	public override void DoEffect(PlayerController user)
	{
		Gun currentGun = ((GameActor)user).CurrentGun;
		currentGun.SetBaseMaxAmmo(Mathf.CeilToInt((float)currentGun.GetBaseMaxAmmo() * 1.5f));
		user.stats.RecalculateStats(user, false, false);
	}

	public override bool CanBeUsed(PlayerController user)
	{
		if (Object.op_Implicit((Object)(object)user) && (Object)(object)((GameActor)user).CurrentGun != (Object)null && !((GameActor)user).CurrentGun.InfiniteAmmo)
		{
			return true;
		}
		return false;
	}
}
