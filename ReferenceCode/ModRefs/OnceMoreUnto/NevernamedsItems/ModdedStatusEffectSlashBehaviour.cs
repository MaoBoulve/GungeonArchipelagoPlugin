using Alexandria.ItemAPI;

namespace NevernamedsItems;

public class ModdedStatusEffectSlashBehaviour : ProjectileSlashingBehaviour
{
	public bool appliesExsanguination;

	public float exsanguinationDuration = 10f;

	public int exsanguinationStacks = 1;

	public override void SlashHitTarget(GameActor target, bool fatal)
	{
		if (target is AIActor && appliesExsanguination)
		{
			for (int i = 0; i < 1; i++)
			{
				((BraveBehaviour)target).gameActor.ApplyEffect((GameActorEffect)(object)new GameActorExsanguinationEffect
				{
					duration = exsanguinationDuration
				}, 1f, (Projectile)null);
			}
		}
		((ProjectileSlashingBehaviour)this).SlashHitTarget(target, fatal);
	}
}
