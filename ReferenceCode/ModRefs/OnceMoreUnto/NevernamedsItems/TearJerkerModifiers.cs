using Alexandria.ItemAPI;
using Alexandria.Misc;
using UnityEngine;

namespace NevernamedsItems;

public class TearJerkerModifiers : GunBehaviour
{
	public override void PostProcessProjectile(Projectile projectile)
	{
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		if ((Object)(object)ProjectileUtility.ProjectilePlayerOwner(projectile) != (Object)null && CustomSynergies.PlayerHasActiveSynergy(ProjectileUtility.ProjectilePlayerOwner(projectile), "Cow, on a Trash Farm") && Random.value <= 0.25f)
		{
			projectile.AdjustPlayerProjectileTint(ExtendedColours.poisonGreen, 1, 0f);
			projectile.statusEffectsToApply.Add((GameActorEffect)(object)StaticStatusEffects.irradiatedLeadEffect);
		}
	}
}
