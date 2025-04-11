using System.Collections.Generic;
using Alexandria.Misc;
using Dungeonator;
using UnityEngine;

namespace NevernamedsItems;

internal class LeadOfLifeMassRoomDamager : LeadOfLifeCompanion
{
	public ActiveEnemyType targetType;

	public float roomDamageAmount;

	public bool doesBlank;

	public float chanceToFailBlank;

	public float randomChanceToAlternateBlankType;

	public EasyBlankType blankType;

	public new static LeadOfLifeMassRoomDamager AddToPrefab(GameObject prefab, int itemID, float moveSpeed = 5f, List<MovementBehaviorBase> movementBehaviors = null)
	{
		//IL_0091: Unknown result type (might be due to invalid IL or missing references)
		//IL_0098: Expected O, but got Unknown
		LeadOfLifeMassRoomDamager leadOfLifeMassRoomDamager = prefab.AddComponent<LeadOfLifeMassRoomDamager>();
		((BraveBehaviour)leadOfLifeMassRoomDamager).aiActor.MovementSpeed = moveSpeed;
		leadOfLifeMassRoomDamager.tiedItemID = itemID;
		((BraveBehaviour)leadOfLifeMassRoomDamager).aiAnimator.GetDirectionalAnimation("idle").Prefix = "idle";
		if (((BraveBehaviour)leadOfLifeMassRoomDamager).aiAnimator.GetDirectionalAnimation("move") != null)
		{
			((BraveBehaviour)leadOfLifeMassRoomDamager).aiAnimator.GetDirectionalAnimation("move").Prefix = "run";
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
		return leadOfLifeMassRoomDamager;
	}

	public LeadOfLifeMassRoomDamager()
	{
		//IL_000a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		targetType = (ActiveEnemyType)0;
		roomDamageAmount = 5f;
		doesBlank = false;
		blankType = (EasyBlankType)1;
		randomChanceToAlternateBlankType = 0f;
		chanceToFailBlank = 0f;
	}

	public override void Attack()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0139: Unknown result type (might be due to invalid IL or missing references)
		//IL_013e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0117: Unknown result type (might be due to invalid IL or missing references)
		//IL_011a: Invalid comparison between Unknown and I4
		//IL_012a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0124: Unknown result type (might be due to invalid IL or missing references)
		//IL_008c: Unknown result type (might be due to invalid IL or missing references)
		if (Vector3Extensions.GetAbsoluteRoom(((GameActor)((BraveBehaviour)this).aiActor).CenterPosition) != null)
		{
			List<AIActor> activeEnemies = Vector3Extensions.GetAbsoluteRoom(((GameActor)((BraveBehaviour)this).aiActor).CenterPosition).GetActiveEnemies(targetType);
			if (activeEnemies != null && activeEnemies.Count > 0)
			{
				foreach (AIActor item in activeEnemies)
				{
					if (Object.op_Implicit((Object)(object)item) && Object.op_Implicit((Object)(object)((BraveBehaviour)item).healthHaver))
					{
						((BraveBehaviour)item).healthHaver.ApplyDamage(roomDamageAmount, Vector2.zero, "Lead of Life Buddy", (CoreDamageTypes)0, (DamageCategory)0, false, (PixelCollider)null, false);
						OnMassDamagedEnemy();
					}
				}
			}
		}
		if (doesBlank)
		{
			if (Random.value <= chanceToFailBlank)
			{
				base.Attack();
			}
			else
			{
				EasyBlankType val = blankType;
				if (Random.value <= randomChanceToAlternateBlankType)
				{
					val = (((int)val != 0) ? ((EasyBlankType)0) : ((EasyBlankType)1));
				}
				PlayerUtility.DoEasyBlank(Owner, ((BraveBehaviour)this).specRigidbody.UnitCenter, val);
				timesAttacked++;
			}
		}
		timesAttacked++;
		base.Attack();
	}

	public virtual void OnMassDamagedEnemy()
	{
	}
}
