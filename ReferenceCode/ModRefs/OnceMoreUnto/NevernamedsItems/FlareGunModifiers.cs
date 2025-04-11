using Alexandria.ItemAPI;
using UnityEngine;

namespace NevernamedsItems;

public class FlareGunModifiers : GunBehaviour
{
	public override void PostProcessProjectile(Projectile projectile)
	{
		if (Object.op_Implicit((Object)(object)base.gun) && Object.op_Implicit((Object)(object)GunTools.GunPlayerOwner(base.gun)))
		{
			if (CustomSynergies.PlayerHasActiveSynergy(GunTools.GunPlayerOwner(base.gun), "Mixed Signals"))
			{
				ProjectileData baseData = projectile.baseData;
				baseData.speed *= 2f;
				ProjectileData baseData2 = projectile.baseData;
				baseData2.force += 40f;
				BounceProjModifier orAddComponent = GameObjectExtensions.GetOrAddComponent<BounceProjModifier>(((Component)projectile).gameObject);
				orAddComponent.numberOfBounces++;
				projectile.UpdateSpeed();
			}
			((GunBehaviour)this).PostProcessProjectile(projectile);
		}
	}
}
