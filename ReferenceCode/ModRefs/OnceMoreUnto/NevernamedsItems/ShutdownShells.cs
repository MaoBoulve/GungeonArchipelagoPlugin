using Alexandria.ItemAPI;
using SaveAPI;
using UnityEngine;

namespace NevernamedsItems;

public class ShutdownShells : PassiveItem
{
	public static void Init()
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		PickupObject val = ItemSetup.NewItem<ShutdownShells>("Shutdown Shells", "No, shut them all down!", "These brutal shells are designed to burrow into the long spines of the Gungeon's Shotgun Gundead and wreak havoc, causing a complete shutdown of the central nervous system.\n\nNot compatible with other lifeforms.", "shutdownshells_icon", assetbundle: true);
		val.quality = (ItemQuality)3;
		AlexandriaTags.SetTag(val, "bullet_modifier");
		val.SetupUnlockOnCustomFlag(CustomDungeonFlags.PURCHASED_SHUTDOWNSHELLS, requiredFlagValue: true);
		val.AddItemToDougMetaShop(30, null);
		Doug.AddToLootPool(val.PickupObjectId);
	}

	public override void Pickup(PlayerController player)
	{
		((PassiveItem)this).Pickup(player);
		player.PostProcessProjectile += PostProcessProjectile;
		player.PostProcessBeam += PostProcessBeam;
	}

	private void PostProcessProjectile(Projectile sourceProjectile, float effectChanceScalar)
	{
		ProjectileInstakillBehaviour orAddComponent = GameObjectExtensions.GetOrAddComponent<ProjectileInstakillBehaviour>(((Component)sourceProjectile).gameObject);
		orAddComponent.tagsToKill.Add("shotgun_kin");
	}

	private void PostProcessBeam(BeamController sourceBeam)
	{
		if (Object.op_Implicit((Object)(object)((BraveBehaviour)sourceBeam).projectile))
		{
			PostProcessProjectile(((BraveBehaviour)sourceBeam).projectile, 1f);
		}
	}

	public override void DisableEffect(PlayerController player)
	{
		player.PostProcessProjectile -= PostProcessProjectile;
		player.PostProcessBeam -= PostProcessBeam;
		((PassiveItem)this).DisableEffect(player);
	}
}
