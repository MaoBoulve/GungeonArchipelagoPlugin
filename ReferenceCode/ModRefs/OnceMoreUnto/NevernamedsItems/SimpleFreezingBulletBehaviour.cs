using System;
using UnityEngine;

namespace NevernamedsItems;

public class SimpleFreezingBulletBehaviour : MonoBehaviour
{
	private Projectile m_projectile;

	public Color tintColour;

	public bool useSpecialTint;

	public int procChance;

	public int freezeAmount;

	public int freezeAmountForBosses;

	public SimpleFreezingBulletBehaviour()
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		tintColour = ExtendedColours.skyblue;
		useSpecialTint = true;
		procChance = 1;
	}

	private void Start()
	{
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		m_projectile = ((Component)this).GetComponent<Projectile>();
		if (useSpecialTint)
		{
			m_projectile.AdjustPlayerProjectileTint(tintColour, 2, 0f);
		}
		Projectile projectile = m_projectile;
		projectile.OnHitEnemy = (Action<Projectile, SpeculativeRigidbody, bool>)Delegate.Combine(projectile.OnHitEnemy, new Action<Projectile, SpeculativeRigidbody, bool>(OnHitEnemy));
	}

	private void OnHitEnemy(Projectile bullet, SpeculativeRigidbody enemy, bool fatal)
	{
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		if (Random.value <= (float)procChance)
		{
			BulletStatusEffectItem component = ((Component)PickupObjectDatabase.GetById(278)).GetComponent<BulletStatusEffectItem>();
			GameActorFreezeEffect freezeModifierEffect = component.FreezeModifierEffect;
			if (((BraveBehaviour)enemy).healthHaver.IsBoss)
			{
				ApplyDirectStatusEffects.ApplyDirectFreeze(((BraveBehaviour)enemy).gameActor, ((GameActorEffect)freezeModifierEffect).duration, freezeAmountForBosses, freezeModifierEffect.UnfreezeDamagePercent, ((GameActorEffect)freezeModifierEffect).TintColor, ((GameActorEffect)freezeModifierEffect).DeathTintColor, (EffectResistanceType)3, "NNs Freeze", tintsEnemy: true, tintsCorpse: true);
			}
			else
			{
				ApplyDirectStatusEffects.ApplyDirectFreeze(((BraveBehaviour)enemy).gameActor, ((GameActorEffect)freezeModifierEffect).duration, freezeAmount, freezeModifierEffect.UnfreezeDamagePercent, ((GameActorEffect)freezeModifierEffect).TintColor, ((GameActorEffect)freezeModifierEffect).DeathTintColor, (EffectResistanceType)3, "NNs Freeze", tintsEnemy: true, tintsCorpse: true);
			}
		}
	}
}
