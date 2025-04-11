using System.Collections.Generic;
using UnityEngine;

namespace NevernamedsItems;

internal class LeadOfLifeComplexShooter : LeadOfLifeBasicShooter
{
	public bool orbital;

	public bool platinum;

	public new static LeadOfLifeComplexShooter AddToPrefab(GameObject prefab, int itemID, float moveSpeed = 5f, List<MovementBehaviorBase> movementBehaviors = null)
	{
		//IL_0091: Unknown result type (might be due to invalid IL or missing references)
		//IL_0098: Expected O, but got Unknown
		LeadOfLifeComplexShooter leadOfLifeComplexShooter = prefab.AddComponent<LeadOfLifeComplexShooter>();
		((BraveBehaviour)leadOfLifeComplexShooter).aiActor.MovementSpeed = moveSpeed;
		leadOfLifeComplexShooter.tiedItemID = itemID;
		((BraveBehaviour)leadOfLifeComplexShooter).aiAnimator.GetDirectionalAnimation("idle").Prefix = "idle";
		if (((BraveBehaviour)leadOfLifeComplexShooter).aiAnimator.GetDirectionalAnimation("move") != null)
		{
			((BraveBehaviour)leadOfLifeComplexShooter).aiAnimator.GetDirectionalAnimation("move").Prefix = "run";
		}
		BehaviorSpeculator component = prefab.GetComponent<BehaviorSpeculator>();
		if (movementBehaviors == null)
		{
			List<MovementBehaviorBase> movementBehaviors2 = component.MovementBehaviors;
			List<MovementBehaviorBase> list = new List<MovementBehaviorBase> { (MovementBehaviorBase)(object)new CustomCompanionBehaviours.LeadOfLifeCompanionApproach() };
			CompanionFollowPlayerBehavior val = new CompanionFollowPlayerBehavior();
			val.IdleAnimations = new string[1] { "idle" };
			list.Add((MovementBehaviorBase)(object)val);
			movementBehaviors2.AddRange(list);
		}
		else
		{
			component.MovementBehaviors.AddRange(movementBehaviors);
		}
		return leadOfLifeComplexShooter;
	}

	public LeadOfLifeComplexShooter()
	{
		orbital = false;
		platinum = false;
	}

	public override void PostProcessProjectile(Projectile projectile)
	{
		if (orbital && Object.op_Implicit((Object)(object)((BraveBehaviour)this).specRigidbody))
		{
			OrbitalBulletsBehaviour orAddComponent = GameObjectExtensions.GetOrAddComponent<OrbitalBulletsBehaviour>(((Component)projectile).gameObject);
			orAddComponent.usesOverrideCenter = true;
			orAddComponent.overrideCenter = ((BraveBehaviour)this).specRigidbody;
			orAddComponent.orbitalGroup = 2;
		}
		if (platinum && (Object)(object)correspondingItem != (Object)null && (Object)(object)((Component)correspondingItem).GetComponent<PlatinumBulletsItem>() != (Object)null)
		{
			PlatinumBulletsItem component = ((Component)correspondingItem).GetComponent<PlatinumBulletsItem>();
			ProjectileData baseData = projectile.baseData;
			baseData.damage *= Mathf.Min(component.MaximumDamageMultiplier, 1f + component.m_totalBulletsFiredNormalizedByFireRate / component.ShootSecondsPerDamageDouble);
		}
		base.PostProcessProjectile(projectile);
	}

	public override float ModifyCooldown(float originalCooldown)
	{
		if (platinum && (Object)(object)correspondingItem != (Object)null && (Object)(object)((Component)correspondingItem).GetComponent<PlatinumBulletsItem>() != (Object)null)
		{
			PlatinumBulletsItem component = ((Component)correspondingItem).GetComponent<PlatinumBulletsItem>();
			return originalCooldown / Mathf.Min(component.MaximumRateOfFireMultiplier, 1f + component.m_totalBulletsFiredNormalizedByFireRate / component.ShootSecondsPerRateOfFireDouble);
		}
		return base.ModifyCooldown(originalCooldown);
	}
}
