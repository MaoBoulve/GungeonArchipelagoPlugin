using Alexandria.ItemAPI;
using Alexandria.Misc;
using SaveAPI;
using UnityEngine;

namespace NevernamedsItems;

public class MagnetItem : PassiveItem
{
	public static void Init()
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		PickupObject val = ItemSetup.NewItem<MagnetItem>("Magnet", "Mysterious Magic", "A mysterious artifact. Nobody is quite sure how it works.\n\nBullets draw in enemies. Don't take the fight to them, take them to the fight.", "magnet_icon", assetbundle: true);
		val.quality = (ItemQuality)1;
		AlexandriaTags.SetTag(val, "bullet_modifier");
		ItemBuilder.AddPassiveStatModifier(val, (StatType)12, 3f, (ModifyMethod)0);
		val.SetupUnlockOnCustomFlag(CustomDungeonFlags.BOSSRUSH_ROBOT, requiredFlagValue: true);
		Doug.AddToLootPool(val.PickupObjectId);
	}

	private void PostProcessProjectile(Projectile sourceProjectile, float effectChanceScalar)
	{
		MagnetBehaviour orAddComponent = GameObjectExtensions.GetOrAddComponent<MagnetBehaviour>(((Component)sourceProjectile).gameObject);
		orAddComponent.gravitationalForce = 166f;
		orAddComponent.statMult = ProjectileUtility.ProjectilePlayerOwner(sourceProjectile).stats.GetStatValue((StatType)12);
		orAddComponent.debugMode = false;
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
