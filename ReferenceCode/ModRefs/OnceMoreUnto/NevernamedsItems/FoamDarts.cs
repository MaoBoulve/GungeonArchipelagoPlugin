using Alexandria.ItemAPI;
using UnityEngine;

namespace NevernamedsItems;

public class FoamDarts : PassiveItem
{
	public static void Init()
	{
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		PickupObject val = ItemSetup.NewItem<FoamDarts>("Foam Darts", "Or Nothing", "Knockback slightly up. Bullets soak up goop off the floor, and inflict it upon enemies!\n\nPart of an 'Epix Ammo Expansion Pak' by the manufacturer that made the Dart Gun.", "foamdarts_icon", assetbundle: true);
		ItemBuilder.AddPassiveStatModifier(val, (StatType)12, 1.45f, (ModifyMethod)1);
		val.quality = (ItemQuality)1;
		AlexandriaTags.SetTag(val, "bullet_modifier");
		Doug.AddToLootPool(val.PickupObjectId);
	}

	private void PostProcessProjectile(Projectile sourceProjectile, float effectChanceScalar)
	{
		SoakGoopProjModifier orAddComponent = GameObjectExtensions.GetOrAddComponent<SoakGoopProjModifier>(((Component)sourceProjectile).gameObject);
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
