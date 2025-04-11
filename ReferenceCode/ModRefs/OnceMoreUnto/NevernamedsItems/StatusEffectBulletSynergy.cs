using System.Collections.Generic;
using Alexandria.ItemAPI;
using Alexandria.Misc;
using UnityEngine;

namespace NevernamedsItems;

public class StatusEffectBulletSynergy : MonoBehaviour
{
	private Projectile m_projectile;

	public List<GameActorEffect> StatusEffects = new List<GameActorEffect>();

	public Color tint;

	public float chance;

	public string synergyToCheckFor;

	public StatusEffectBulletSynergy()
	{
		chance = 1f;
	}

	private void Start()
	{
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		m_projectile = ((Component)this).GetComponent<Projectile>();
		if (Object.op_Implicit((Object)(object)m_projectile) && Object.op_Implicit((Object)(object)ProjectileUtility.ProjectilePlayerOwner(m_projectile)) && !string.IsNullOrEmpty(synergyToCheckFor) && CustomSynergies.PlayerHasActiveSynergy(ProjectileUtility.ProjectilePlayerOwner(m_projectile), synergyToCheckFor) && Random.value <= chance)
		{
			m_projectile.statusEffectsToApply.AddRange(StatusEffects);
			m_projectile.AdjustPlayerProjectileTint(tint, 1, 0f);
		}
	}
}
