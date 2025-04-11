using Alexandria.ItemAPI;

namespace NevernamedsItems;

public class ReallySpecialLuteModifiers : GunBehaviour
{
	public override void PostProcessProjectile(Projectile projectile)
	{
		GameActor currentOwner = base.gun.CurrentOwner;
		PlayerController val = (PlayerController)(object)((currentOwner is PlayerController) ? currentOwner : null);
		((GunBehaviour)this).PostProcessProjectile(projectile);
		if (CustomSynergies.PlayerHasActiveSynergy(val, "Eternal Prose"))
		{
			ProjectileData baseData = projectile.baseData;
			baseData.range *= 10f;
			ProjectileData baseData2 = projectile.baseData;
			baseData2.speed *= 2f;
		}
	}
}
