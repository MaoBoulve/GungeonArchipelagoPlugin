using UnityEngine;

namespace NevernamedsItems;

public class ModdedStatusEffectApplier : BraveBehaviour
{
	public bool appliesPlague;

	public float appliedPlagueDuration = 100f;

	public bool appliesCrying;

	public float appliedCryingDuration = 20f;

	private Projectile m_projectile;

	private void Start()
	{
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		m_projectile = ((BraveBehaviour)this).projectile;
		if ((Object)(object)m_projectile != (Object)null && m_projectile.statusEffectsToApply != null)
		{
			if (appliesPlague)
			{
				m_projectile.statusEffectsToApply.Add((GameActorEffect)(object)StatusEffectHelper.GeneratePlagueEffect(appliedPlagueDuration, 2f, tintEnemy: true, ExtendedColours.plaguePurple, tintCorpse: true, ExtendedColours.plaguePurple));
			}
			if (appliesCrying)
			{
				m_projectile.statusEffectsToApply.Add((GameActorEffect)(object)StatusEffectHelper.GenerateCryingEfffect(appliedCryingDuration));
			}
		}
	}
}
