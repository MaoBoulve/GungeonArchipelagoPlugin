using Alexandria.ItemAPI;
using UnityEngine;

namespace NevernamedsItems;

public class BashingBullets : PassiveItem
{
	public static int BashingBulletsID;

	public static void Init()
	{
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		PickupObject val = ItemSetup.NewItem<BashingBullets>("Bashing Bullets", "Punch Out", "The thick leather gloves glued to the slugs of these bullets increase the kinetic force they apply to the target.", "bashingbullets_improved", assetbundle: true);
		ItemBuilder.AddPassiveStatModifier(val, (StatType)12, 10f, (ModifyMethod)0);
		val.quality = (ItemQuality)1;
		AlexandriaTags.SetTag(val, "bullet_modifier");
		BashingBulletsID = val.PickupObjectId;
		Doug.AddToLootPool(val.PickupObjectId);
	}

	public override void Pickup(PlayerController player)
	{
		player.PostProcessProjectile += PostProcessProj;
		((PassiveItem)this).Pickup(player);
	}

	public override void DisableEffect(PlayerController player)
	{
		if (Object.op_Implicit((Object)(object)player))
		{
			player.PostProcessProjectile -= PostProcessProj;
		}
		((PassiveItem)this).DisableEffect(player);
	}

	private void PostProcessProj(Projectile bullet, float b)
	{
		((Component)bullet).gameObject.AddComponent<BreakableBashingBehaviour>();
	}
}
