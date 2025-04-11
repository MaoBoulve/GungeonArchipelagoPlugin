using Alexandria.ItemAPI;

namespace NevernamedsItems;

public class BoxingGloveModifiers : GunBehaviour
{
	public override void PostProcessProjectile(Projectile projectile)
	{
		GameActor currentOwner = base.gun.CurrentOwner;
		PlayerController val = (PlayerController)(object)((currentOwner is PlayerController) ? currentOwner : null);
		((GunBehaviour)this).PostProcessProjectile(projectile);
		if (CustomSynergies.PlayerHasActiveSynergy(val, "Gun Punch Man"))
		{
			ProjectileData baseData = projectile.baseData;
			baseData.damage *= 2f;
		}
		if (CustomSynergies.PlayerHasActiveSynergy(val, "Punch Line"))
		{
			projectile.statusEffectsToApply.Add((GameActorEffect)(object)StaticStatusEffects.charmingRoundsEffect);
		}
		if (CustomSynergies.PlayerHasActiveSynergy(val, "North Star"))
		{
			projectile.statusEffectsToApply.Add((GameActorEffect)(object)StaticStatusEffects.chaosBulletsFreeze);
		}
	}
}
