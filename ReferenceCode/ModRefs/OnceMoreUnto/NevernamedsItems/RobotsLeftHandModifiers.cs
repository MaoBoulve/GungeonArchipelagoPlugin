using Alexandria.ItemAPI;
using Alexandria.Misc;
using UnityEngine;

namespace NevernamedsItems;

public class RobotsLeftHandModifiers : GunBehaviour
{
	public override void PostProcessProjectile(Projectile projectile)
	{
		if (Object.op_Implicit((Object)(object)projectile) && Object.op_Implicit((Object)(object)ProjectileUtility.ProjectilePlayerOwner(projectile)) && CustomSynergies.PlayerHasActiveSynergy(ProjectileUtility.ProjectilePlayerOwner(projectile), "Lefty Loosey") && ((GameActor)ProjectileUtility.ProjectilePlayerOwner(projectile)).SpriteFlipped)
		{
			ProjectileData baseData = projectile.baseData;
			baseData.speed *= 1.5f;
			projectile.UpdateSpeed();
			PierceProjModifier orAddComponent = GameObjectExtensions.GetOrAddComponent<PierceProjModifier>(((Component)projectile).gameObject);
			orAddComponent.penetration += 2;
		}
	}
}
