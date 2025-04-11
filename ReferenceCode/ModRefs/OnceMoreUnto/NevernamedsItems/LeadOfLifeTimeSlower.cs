using System.Collections.Generic;
using UnityEngine;

namespace NevernamedsItems;

internal class LeadOfLifeTimeSlower : LeadOfLifeCompanion
{
	public bool doesSepia;

	public float holdTime;

	public float timeModifier;

	public new static LeadOfLifeTimeSlower AddToPrefab(GameObject prefab, int itemID, float moveSpeed = 5f, List<MovementBehaviorBase> movementBehaviors = null)
	{
		//IL_0091: Unknown result type (might be due to invalid IL or missing references)
		//IL_0098: Expected O, but got Unknown
		LeadOfLifeTimeSlower leadOfLifeTimeSlower = prefab.AddComponent<LeadOfLifeTimeSlower>();
		((BraveBehaviour)leadOfLifeTimeSlower).aiActor.MovementSpeed = moveSpeed;
		leadOfLifeTimeSlower.tiedItemID = itemID;
		((BraveBehaviour)leadOfLifeTimeSlower).aiAnimator.GetDirectionalAnimation("idle").Prefix = "idle";
		if (((BraveBehaviour)leadOfLifeTimeSlower).aiAnimator.GetDirectionalAnimation("move") != null)
		{
			((BraveBehaviour)leadOfLifeTimeSlower).aiAnimator.GetDirectionalAnimation("move").Prefix = "run";
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
		return leadOfLifeTimeSlower;
	}

	public LeadOfLifeTimeSlower()
	{
		doesSepia = false;
		holdTime = 5f;
		timeModifier = 0.25f;
	}

	public override void Attack()
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Expected O, but got Unknown
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		RadialSlowInterface val = new RadialSlowInterface();
		val.DoesSepia = doesSepia;
		val.RadialSlowHoldTime = holdTime;
		val.RadialSlowTimeModifier = timeModifier;
		val.DoRadialSlow(((BraveBehaviour)this).specRigidbody.UnitCenter, Vector3Extensions.GetAbsoluteRoom(((BraveBehaviour)this).aiActor.Position));
		timesAttacked++;
		base.Attack();
	}
}
