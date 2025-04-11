using System.Collections.Generic;
using UnityEngine;

namespace NevernamedsItems;

internal class LeadOfLifeCompanionCountReactiveShooter : LeadOfLifeBasicShooter
{
	public bool crowdedClip;

	public bool bashfulShot;

	public new static LeadOfLifeCompanionCountReactiveShooter AddToPrefab(GameObject prefab, int itemID, float moveSpeed = 5f, List<MovementBehaviorBase> movementBehaviors = null)
	{
		//IL_0091: Unknown result type (might be due to invalid IL or missing references)
		//IL_0098: Expected O, but got Unknown
		LeadOfLifeCompanionCountReactiveShooter leadOfLifeCompanionCountReactiveShooter = prefab.AddComponent<LeadOfLifeCompanionCountReactiveShooter>();
		((BraveBehaviour)leadOfLifeCompanionCountReactiveShooter).aiActor.MovementSpeed = moveSpeed;
		leadOfLifeCompanionCountReactiveShooter.tiedItemID = itemID;
		((BraveBehaviour)leadOfLifeCompanionCountReactiveShooter).aiAnimator.GetDirectionalAnimation("idle").Prefix = "idle";
		if (((BraveBehaviour)leadOfLifeCompanionCountReactiveShooter).aiAnimator.GetDirectionalAnimation("move") != null)
		{
			((BraveBehaviour)leadOfLifeCompanionCountReactiveShooter).aiAnimator.GetDirectionalAnimation("move").Prefix = "run";
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
		return leadOfLifeCompanionCountReactiveShooter;
	}

	public override void PostProcessProjectile(Projectile projectile)
	{
		if (Object.op_Implicit((Object)(object)baseLeadOfLife))
		{
			int num = baseLeadOfLife.extantCompanions.Count - 1;
			if (bashfulShot)
			{
				float num2 = -0.03f * (float)num + 2f;
				num2 = Mathf.Max(1f, num2);
				ProjectileData baseData = projectile.baseData;
				baseData.damage *= num2;
			}
			if (crowdedClip)
			{
				float num3 = 0.01f * (float)num + 1f;
				ProjectileData baseData2 = projectile.baseData;
				baseData2.damage *= num3;
			}
		}
		base.PostProcessProjectile(projectile);
	}

	public override float ModifyCooldown(float originalCooldown)
	{
		if (Object.op_Implicit((Object)(object)baseLeadOfLife))
		{
			int num = baseLeadOfLife.extantCompanions.Count - 1;
			if (bashfulShot)
			{
				float num2 = -0.03f * (float)num + 2f;
				num2 = Mathf.Max(1f, num2);
				return originalCooldown / num2;
			}
		}
		return base.ModifyCooldown(originalCooldown);
	}
}
