using Alexandria.ItemAPI;
using Alexandria.Misc;
using UnityEngine;

namespace NevernamedsItems;

public class Splattershot : PassiveItem
{
	public static void Init()
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		PickupObject val = ItemSetup.NewItem<Splattershot>("Splattershot", "SPLAT", "Bullets spend the beginning of their lives clustered close together, before splitting apart in a hearbreaking parable about the pain of growing up.", "splattershot_icon", assetbundle: true);
		val.quality = (ItemQuality)3;
		AlexandriaTags.SetTag(val, "bullet_modifier");
		Doug.AddToLootPool(val.PickupObjectId);
	}

	private void PostProcessProjectile(Projectile sourceProjectile, float effectChanceScalar)
	{
		ProjectileSplitController orAddComponent = GameObjectExtensions.GetOrAddComponent<ProjectileSplitController>(((Component)sourceProjectile).gameObject);
		orAddComponent.distanceBasedSplit = true;
		orAddComponent.amtToSplitTo += 3;
		if (Object.op_Implicit((Object)(object)ProjectileUtility.ProjectilePlayerOwner(sourceProjectile)) && CustomSynergies.PlayerHasActiveSynergy(ProjectileUtility.ProjectilePlayerOwner(sourceProjectile), "3 + 1 = 4"))
		{
			orAddComponent.amtToSplitTo++;
		}
	}

	private void PostProcessBeam(BeamController beam)
	{
		if (Object.op_Implicit((Object)(object)beam) && Object.op_Implicit((Object)(object)((Component)beam).gameObject) && Object.op_Implicit((Object)(object)((BraveBehaviour)beam).projectile))
		{
			BeamSplittingModifier orAddComponent = GameObjectExtensions.GetOrAddComponent<BeamSplittingModifier>(((Component)beam).gameObject);
			orAddComponent.amtToSplitTo += 3;
			if (Object.op_Implicit((Object)(object)ProjectileUtility.ProjectilePlayerOwner(((BraveBehaviour)beam).projectile)) && CustomSynergies.PlayerHasActiveSynergy(ProjectileUtility.ProjectilePlayerOwner(((BraveBehaviour)beam).projectile), "3 + 1 = 4"))
			{
				orAddComponent.amtToSplitTo++;
			}
		}
	}

	public override DebrisObject Drop(PlayerController player)
	{
		DebrisObject result = ((PassiveItem)this).Drop(player);
		player.PostProcessProjectile -= PostProcessProjectile;
		player.PostProcessBeam -= PostProcessBeam;
		return result;
	}

	public override void Pickup(PlayerController player)
	{
		((PassiveItem)this).Pickup(player);
		player.PostProcessProjectile += PostProcessProjectile;
		player.PostProcessBeam += PostProcessBeam;
	}

	public override void OnDestroy()
	{
		if (Object.op_Implicit((Object)(object)((PassiveItem)this).Owner))
		{
			((PassiveItem)this).Owner.PostProcessProjectile -= PostProcessProjectile;
			((PassiveItem)this).Owner.PostProcessBeam -= PostProcessBeam;
		}
		((PassiveItem)this).OnDestroy();
	}
}
