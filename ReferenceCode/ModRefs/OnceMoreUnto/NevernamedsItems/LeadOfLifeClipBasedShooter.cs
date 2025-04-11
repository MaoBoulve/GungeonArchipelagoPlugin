using System.Collections.Generic;
using UnityEngine;

namespace NevernamedsItems;

internal class LeadOfLifeClipBasedShooter : LeadOfLifeBasicShooter
{
	public bool isAlpha;

	public bool isOmega;

	public new static LeadOfLifeClipBasedShooter AddToPrefab(GameObject prefab, int itemID, float moveSpeed = 5f, List<MovementBehaviorBase> movementBehaviors = null)
	{
		//IL_0091: Unknown result type (might be due to invalid IL or missing references)
		//IL_0098: Expected O, but got Unknown
		LeadOfLifeClipBasedShooter leadOfLifeClipBasedShooter = prefab.AddComponent<LeadOfLifeClipBasedShooter>();
		((BraveBehaviour)leadOfLifeClipBasedShooter).aiActor.MovementSpeed = moveSpeed;
		leadOfLifeClipBasedShooter.tiedItemID = itemID;
		((BraveBehaviour)leadOfLifeClipBasedShooter).aiAnimator.GetDirectionalAnimation("idle").Prefix = "idle";
		if (((BraveBehaviour)leadOfLifeClipBasedShooter).aiAnimator.GetDirectionalAnimation("move") != null)
		{
			((BraveBehaviour)leadOfLifeClipBasedShooter).aiAnimator.GetDirectionalAnimation("move").Prefix = "run";
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
		return leadOfLifeClipBasedShooter;
	}

	public override void PostProcessProjectile(Projectile projectile)
	{
		if (isAlpha)
		{
			if (Object.op_Implicit((Object)(object)((GameActor)Owner).CurrentGun) && ((GameActor)Owner).CurrentGun.ClipShotsRemaining == ((GameActor)Owner).CurrentGun.ClipCapacity)
			{
				ProjectileData baseData = projectile.baseData;
				baseData.damage *= 2f;
				projectile.AdditionalScaleMultiplier *= 1.25f;
			}
		}
		else if (isOmega && Object.op_Implicit((Object)(object)((GameActor)Owner).CurrentGun) && ((GameActor)Owner).CurrentGun.ClipShotsRemaining == 1)
		{
			ProjectileData baseData2 = projectile.baseData;
			baseData2.damage *= 2f;
			projectile.AdditionalScaleMultiplier *= 1.25f;
		}
		base.PostProcessProjectile(projectile);
	}
}
