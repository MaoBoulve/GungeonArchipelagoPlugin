using System;
using System.Collections.Generic;
using Alexandria.Misc;
using Dungeonator;
using UnityEngine;

namespace NevernamedsItems;

internal class LeadOfLifeGooper : LeadOfLifeCompanion
{
	public bool doGoopCircle;

	public GoopDefinition goopDefToSpawn;

	public float goopRadiusOrWidth;

	public new static LeadOfLifeGooper AddToPrefab(GameObject prefab, int itemID, float moveSpeed = 5f, List<MovementBehaviorBase> movementBehaviors = null)
	{
		//IL_0091: Unknown result type (might be due to invalid IL or missing references)
		//IL_0098: Expected O, but got Unknown
		LeadOfLifeGooper leadOfLifeGooper = prefab.AddComponent<LeadOfLifeGooper>();
		((BraveBehaviour)leadOfLifeGooper).aiActor.MovementSpeed = moveSpeed;
		leadOfLifeGooper.tiedItemID = itemID;
		((BraveBehaviour)leadOfLifeGooper).aiAnimator.GetDirectionalAnimation("idle").Prefix = "idle";
		if (((BraveBehaviour)leadOfLifeGooper).aiAnimator.GetDirectionalAnimation("move") != null)
		{
			((BraveBehaviour)leadOfLifeGooper).aiAnimator.GetDirectionalAnimation("move").Prefix = "run";
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
		return leadOfLifeGooper;
	}

	public LeadOfLifeGooper()
	{
		doGoopCircle = false;
		goopRadiusOrWidth = 1f;
	}

	public override void Attack()
	{
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		if (Object.op_Implicit((Object)(object)goopDefToSpawn))
		{
			if (doGoopCircle)
			{
				DeadlyDeadlyGoopManager.GetGoopManagerForGoopType(goopDefToSpawn).TimedAddGoopCircle(((BraveBehaviour)this).specRigidbody.UnitCenter, goopRadiusOrWidth, 0.5f, false);
			}
			else
			{
				DeadlyDeadlyGoopManager.GetGoopManagerForGoopType(goopDefToSpawn).TimedAddGoopLine(((BraveBehaviour)this).specRigidbody.UnitCenter, MathsAndLogicHelper.GetPositionOfNearestEnemy(((BraveBehaviour)this).sprite.WorldCenter, (ActorCenter)1, true, (ActiveEnemyType)1, (List<AIActor>)null, (Func<AIActor, bool>)null), goopRadiusOrWidth, 0.5f);
			}
		}
		timesAttacked++;
		base.Attack();
	}
}
