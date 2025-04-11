using Alexandria.ItemAPI;
using Alexandria.Misc;
using UnityEngine;

namespace NevernamedsItems;

public class SnowballerModifiers : GunBehaviour
{
	public override void PostProcessProjectile(Projectile projectile)
	{
		if ((Object)(object)ProjectileUtility.ProjectilePlayerOwner(projectile) != (Object)null && CustomSynergies.PlayerHasActiveSynergy(ProjectileUtility.ProjectilePlayerOwner(projectile), "Frost-Key The Snowman"))
		{
			int num = Mathf.Min(5, ProjectileUtility.ProjectilePlayerOwner(projectile).carriedConsumables.KeyBullets);
			ProjectileData baseData = projectile.baseData;
			baseData.damage *= (float)num;
		}
	}
}
