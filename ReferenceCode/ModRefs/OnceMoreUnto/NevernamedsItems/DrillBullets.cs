using Alexandria.ItemAPI;
using UnityEngine;

namespace NevernamedsItems;

public class DrillBullets : PassiveItem
{
	public static void Init()
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		PickupObject val = ItemSetup.NewItem<DrillBullets>("Drill Bullets", "Drrrrrrrrr", "Bullets increase in damage the more they pierce!\n\nKilling people is probably the most legal thing you can do with these.", "drillbullets_improved", assetbundle: true);
		val.quality = (ItemQuality)4;
		AlexandriaTags.SetTag(val, "bullet_modifier");
		Doug.AddToLootPool(val.PickupObjectId);
	}

	private void PostProcessProjectile(Projectile sourceProjectile, float effectChanceScalar)
	{
		PierceProjModifier orAddComponent = GameObjectExtensions.GetOrAddComponent<PierceProjModifier>(((Component)sourceProjectile).gameObject);
		orAddComponent.penetration += 5;
		orAddComponent.penetratesBreakables = true;
		MaintainDamageOnPierce orAddComponent2 = GameObjectExtensions.GetOrAddComponent<MaintainDamageOnPierce>(((Component)sourceProjectile).gameObject);
		orAddComponent2.damageMultOnPierce = 1.25f;
	}

	public override void Pickup(PlayerController player)
	{
		((PassiveItem)this).Pickup(player);
		player.PostProcessProjectile += PostProcessProjectile;
	}

	public override void DisableEffect(PlayerController player)
	{
		if (Object.op_Implicit((Object)(object)player))
		{
			player.PostProcessProjectile -= PostProcessProjectile;
		}
		((PassiveItem)this).DisableEffect(player);
	}
}
