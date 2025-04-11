using Alexandria.ItemAPI;
using SaveAPI;
using UnityEngine;

namespace NevernamedsItems;

public class SupersonicShots : PassiveItem
{
	public static void Init()
	{
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		PickupObject val = ItemSetup.NewItem<SupersonicShots>("Supersonic Shots", "Nyoom", "Makes your bullets travel at supersonic speeds.\n\nBrought to the Gungeon by the infamous speedster Tonic.", "supersonicshot_icon", assetbundle: true);
		ItemBuilder.AddPassiveStatModifier(val, (StatType)6, 10f, (ModifyMethod)1);
		val.quality = (ItemQuality)4;
		AlexandriaTags.SetTag(val, "bullet_modifier");
		ItemBuilder.AddToSubShop(val, (ShopType)2, 1f);
		val.SetupUnlockOnCustomFlag(CustomDungeonFlags.BEATEN_HOLLOW_BOSS_TURBO_MODE, requiredFlagValue: true);
		Doug.AddToLootPool(val.PickupObjectId);
	}

	private void PostProcessProjectile(Projectile sourceProjectile, float effectChanceScalar)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		sourceProjectile.AdjustPlayerProjectileTint(Color.blue, 1, 0f);
	}

	public override DebrisObject Drop(PlayerController player)
	{
		DebrisObject result = ((PassiveItem)this).Drop(player);
		player.PostProcessProjectile -= PostProcessProjectile;
		return result;
	}

	public override void Pickup(PlayerController player)
	{
		((PassiveItem)this).Pickup(player);
		player.PostProcessProjectile += PostProcessProjectile;
	}

	public override void OnDestroy()
	{
		if (Object.op_Implicit((Object)(object)((PassiveItem)this).Owner))
		{
			((PassiveItem)this).Owner.PostProcessProjectile -= PostProcessProjectile;
		}
		((PassiveItem)this).OnDestroy();
	}
}
