using Alexandria.ItemAPI;

namespace NevernamedsItems;

public class OldGoldieModifiers : GunBehaviour
{
	public override void PostProcessProjectile(Projectile projectile)
	{
		if (base.gun.CurrentOwner is PlayerController)
		{
			GameActor currentOwner = base.gun.CurrentOwner;
			PlayerController val = (PlayerController)(object)((currentOwner is PlayerController) ? currentOwner : null);
			((GunBehaviour)this).PostProcessProjectile(projectile);
			if (CustomSynergies.PlayerHasActiveSynergy(val, "The Classics"))
			{
				ProjectileData baseData = projectile.baseData;
				baseData.range *= 2f;
			}
		}
	}
}
