using Alexandria.ItemAPI;

namespace NevernamedsItems;

public class VoidMarshalModifiers : GunBehaviour
{
	public override void PostProcessProjectile(Projectile projectile)
	{
		if (base.gun.CurrentOwner is PlayerController)
		{
			GameActor currentOwner = base.gun.CurrentOwner;
			PlayerController val = (PlayerController)(object)((currentOwner is PlayerController) ? currentOwner : null);
			((GunBehaviour)this).PostProcessProjectile(projectile);
			if (CustomSynergies.PlayerHasActiveSynergy(val, "Court Marshal"))
			{
				ProjectileData baseData = projectile.baseData;
				baseData.damage *= 1.2f;
				ProjectileData baseData2 = projectile.baseData;
				baseData2.speed *= 1.2f;
				projectile.UpdateSpeed();
			}
		}
	}
}
