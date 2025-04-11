using System.Collections.Generic;
using UnityEngine;

namespace NevernamedsItems;

internal class LeadOfLifeProximityShooter : LeadOfLifeBasicShooter
{
	public bool scaleProxDistant;

	public bool scaleProxClose;

	public new static LeadOfLifeProximityShooter AddToPrefab(GameObject prefab, int itemID, float moveSpeed = 5f, List<MovementBehaviorBase> movementBehaviors = null)
	{
		//IL_0091: Unknown result type (might be due to invalid IL or missing references)
		//IL_0098: Expected O, but got Unknown
		LeadOfLifeProximityShooter leadOfLifeProximityShooter = prefab.AddComponent<LeadOfLifeProximityShooter>();
		((BraveBehaviour)leadOfLifeProximityShooter).aiActor.MovementSpeed = moveSpeed;
		leadOfLifeProximityShooter.tiedItemID = itemID;
		((BraveBehaviour)leadOfLifeProximityShooter).aiAnimator.GetDirectionalAnimation("idle").Prefix = "idle";
		if (((BraveBehaviour)leadOfLifeProximityShooter).aiAnimator.GetDirectionalAnimation("move") != null)
		{
			((BraveBehaviour)leadOfLifeProximityShooter).aiAnimator.GetDirectionalAnimation("move").Prefix = "run";
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
		return leadOfLifeProximityShooter;
	}

	public override void PostProcessProjectile(Projectile projectile)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		float num = Vector2.Distance(((BraveBehaviour)this).specRigidbody.UnitCenter, ((GameActor)Owner).CenterPosition);
		if (scaleProxDistant)
		{
			float num2 = num * 0.025f + 1f;
			ProjectileData baseData = projectile.baseData;
			baseData.damage *= num2;
			projectile.AdditionalScaleMultiplier *= num2;
		}
		if (scaleProxClose)
		{
			float num3 = num * 4f * 0.01f;
			float num4 = 1f - num3;
			if (num4 <= 0f)
			{
				num4 = 0.001f;
			}
			ProjectileData baseData2 = projectile.baseData;
			baseData2.damage *= num4;
			projectile.AdditionalScaleMultiplier *= num4;
		}
		base.PostProcessProjectile(projectile);
	}
}
