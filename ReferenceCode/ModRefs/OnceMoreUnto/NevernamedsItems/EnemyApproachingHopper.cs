using System;
using System.Collections.Generic;
using Dungeonator;
using Pathfinding;
using UnityEngine;

namespace NevernamedsItems;

public class EnemyApproachingHopper : MovementBehaviorBase
{
	public Func<AIActor, bool> isValid;

	public Action<AIActor, Vector2> onLanded;

	public Action<AIActor, Vector2> onHopped;

	private float hopTimer;

	private float waitTimer;

	public float teleportCatchUpDistance = 12f;

	public float airtime = 0.5f;

	public float waitTime = 0.5f;

	public float outOfCombatWaitTime = 0.1f;

	private bool isHopping;

	private float storedMovement;

	public string hopAnim;

	private List<AIActor> roomEnemies = new List<AIActor>();

	private PlayerController Owner;

	public override void Init(GameObject gameObject, AIActor aiActor, AIShooter aiShooter)
	{
		isHopping = false;
		waitTimer = 0.5f;
		storedMovement = aiActor.MovementSpeed;
		((BehaviorBase)this).Init(gameObject, aiActor, aiShooter);
	}

	public override void Upkeep()
	{
		((MovementBehaviorBase)this).Upkeep();
		if (isHopping)
		{
			((BehaviorBase)this).DecrementTimer(ref hopTimer, false);
		}
		if (!isHopping)
		{
			((BehaviorBase)this).DecrementTimer(ref waitTimer, false);
		}
	}

	public override BehaviorResult Update()
	{
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
		if ((Object)(object)Owner == (Object)null)
		{
			if (Object.op_Implicit((Object)(object)((BehaviorBase)this).m_aiActor) && Object.op_Implicit((Object)(object)((BehaviorBase)this).m_aiActor.CompanionOwner))
			{
				Owner = ((BehaviorBase)this).m_aiActor.CompanionOwner;
			}
			else
			{
				Owner = GameManager.Instance.BestActivePlayer;
			}
		}
		SpeculativeRigidbody overrideTarget = ((BehaviorBase)this).m_aiActor.OverrideTarget;
		if (isHopping && hopTimer <= 0f)
		{
			Land();
			return (BehaviorResult)0;
		}
		if (!isHopping && waitTimer <= 0f)
		{
			return Hop();
		}
		return (BehaviorResult)0;
	}

	private BehaviorResult Hop()
	{
		//IL_01e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_01db: Unknown result type (might be due to invalid IL or missing references)
		//IL_018e: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0288: Unknown result type (might be due to invalid IL or missing references)
		if ((Object)(object)((BehaviorBase)this).m_aiActor.OverrideTarget == (Object)null || (Object.op_Implicit((Object)(object)((BraveBehaviour)((BehaviorBase)this).m_aiActor.OverrideTarget).healthHaver) && ((BraveBehaviour)((BehaviorBase)this).m_aiActor.OverrideTarget).healthHaver.IsDead))
		{
			PickNewTarget();
		}
		if (isValid != null && Object.op_Implicit((Object)(object)((BehaviorBase)this).m_aiActor.OverrideTarget) && (Object)(object)((BraveBehaviour)((BehaviorBase)this).m_aiActor.OverrideTarget).aiActor != (Object)null && !isValid(((BraveBehaviour)((BehaviorBase)this).m_aiActor.OverrideTarget).aiActor))
		{
			PickNewTarget();
		}
		if (Object.op_Implicit((Object)(object)Owner) && Owner.IsInCombat && Object.op_Implicit((Object)(object)((BehaviorBase)this).m_aiActor.OverrideTarget) && Object.op_Implicit((Object)(object)((BraveBehaviour)((BehaviorBase)this).m_aiActor.OverrideTarget).healthHaver) && ((BraveBehaviour)((BehaviorBase)this).m_aiActor.OverrideTarget).healthHaver.IsAlive)
		{
			isHopping = true;
			((BehaviorBase)this).m_aiActor.MovementSpeed = storedMovement;
			if (!string.IsNullOrEmpty(hopAnim) && Object.op_Implicit((Object)(object)((BehaviorBase)this).m_aiAnimator))
			{
				((BehaviorBase)this).m_aiAnimator.PlayUntilFinished(hopAnim, false, (string)null, -1f, false);
			}
			if (onHopped != null)
			{
				onHopped(((BehaviorBase)this).m_aiActor, ((BraveBehaviour)((BehaviorBase)this).m_aiActor).specRigidbody.UnitCenter);
			}
			((BehaviorBase)this).m_aiActor.PathfindToPosition(((BehaviorBase)this).m_aiActor.OverrideTarget.UnitCenter, (Vector2?)null, true, (CellValidator)null, (ExtraWeightingFunction)null, (CellTypes?)null, false);
			hopTimer = airtime;
			return (BehaviorResult)1;
		}
		if (Vector2.Distance(((GameActor)((BehaviorBase)this).m_aiActor).CenterPosition, ((GameActor)Owner).CenterPosition) > 4f)
		{
			isHopping = true;
			((BehaviorBase)this).m_aiActor.MovementSpeed = storedMovement;
			if (!string.IsNullOrEmpty(hopAnim) && Object.op_Implicit((Object)(object)((BehaviorBase)this).m_aiAnimator))
			{
				((BehaviorBase)this).m_aiAnimator.PlayUntilFinished(hopAnim, false, (string)null, -1f, false);
			}
			if (onHopped != null)
			{
				onHopped(((BehaviorBase)this).m_aiActor, ((BraveBehaviour)((BehaviorBase)this).m_aiActor).specRigidbody.UnitCenter);
			}
			((BehaviorBase)this).m_aiActor.PathfindToPosition(((GameActor)Owner).CenterPosition, (Vector2?)null, true, (CellValidator)null, (ExtraWeightingFunction)null, (CellTypes?)null, false);
			hopTimer = airtime;
			return (BehaviorResult)1;
		}
		return (BehaviorResult)0;
	}

	private void Land()
	{
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0136: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_015a: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0184: Unknown result type (might be due to invalid IL or missing references)
		//IL_018f: Unknown result type (might be due to invalid IL or missing references)
		isHopping = false;
		((BehaviorBase)this).m_aiActor.MovementSpeed = 0f;
		((BehaviorBase)this).m_aiActor.ClearPath();
		if (onLanded != null)
		{
			onLanded(((BehaviorBase)this).m_aiActor, ((BraveBehaviour)((BehaviorBase)this).m_aiActor).specRigidbody.UnitCenter);
		}
		if (Object.op_Implicit((Object)(object)Owner) && Owner.IsInCombat && Object.op_Implicit((Object)(object)((BehaviorBase)this).m_aiActor.OverrideTarget) && Object.op_Implicit((Object)(object)((BraveBehaviour)((BehaviorBase)this).m_aiActor.OverrideTarget).healthHaver) && ((BraveBehaviour)((BehaviorBase)this).m_aiActor.OverrideTarget).healthHaver.IsAlive)
		{
			if (Vector3Extensions.GetAbsoluteRoom(((BraveBehaviour)((BehaviorBase)this).m_aiActor).specRigidbody.UnitCenter) == null || Vector3Extensions.GetAbsoluteRoom(((BehaviorBase)this).m_aiActor.OverrideTarget.UnitCenter) != Vector3Extensions.GetAbsoluteRoom(((BraveBehaviour)((BehaviorBase)this).m_aiActor).specRigidbody.UnitCenter))
			{
				waitTimer = outOfCombatWaitTime;
			}
			else
			{
				waitTimer = waitTime;
			}
		}
		else
		{
			waitTimer = outOfCombatWaitTime;
		}
		if (Vector3Extensions.GetAbsoluteRoom(((BraveBehaviour)((BehaviorBase)this).m_aiActor).specRigidbody.UnitCenter) == null || (Owner.IsInCombat && Vector3Extensions.GetAbsoluteRoom(((BraveBehaviour)((BehaviorBase)this).m_aiActor).specRigidbody.UnitCenter) != Owner.CurrentRoom) || (!Owner.IsInCombat && Vector2.Distance(((GameActor)((BehaviorBase)this).m_aiActor).CenterPosition, ((GameActor)Owner).CenterPosition) > teleportCatchUpDistance))
		{
			((BehaviorBase)this).m_aiActor.CompanionWarp(Vector2.op_Implicit(((GameActor)Owner).CenterPosition));
		}
	}

	private void PickNewTarget()
	{
		if (!((Object)(object)((BehaviorBase)this).m_aiActor != (Object)null))
		{
			return;
		}
		if ((Object)(object)Owner == (Object)null)
		{
			if (Object.op_Implicit((Object)(object)((BehaviorBase)this).m_aiActor) && Object.op_Implicit((Object)(object)((BehaviorBase)this).m_aiActor.CompanionOwner))
			{
				Owner = ((BehaviorBase)this).m_aiActor.CompanionOwner;
			}
			else
			{
				Owner = GameManager.Instance.BestActivePlayer;
			}
		}
		Owner.CurrentRoom.GetActiveEnemies((ActiveEnemyType)1, ref roomEnemies);
		for (int i = 0; i < roomEnemies.Count; i++)
		{
			AIActor val = roomEnemies[i];
			if (val.IsHarmlessEnemy || !val.IsNormalEnemy || ((BraveBehaviour)val).healthHaver.IsDead || (Object)(object)val == (Object)(object)((BehaviorBase)this).m_aiActor || val.EnemyGuid == "ba928393c8ed47819c2c5f593100a5bc")
			{
				roomEnemies.Remove(val);
			}
			if (isValid != null && !isValid(val))
			{
				roomEnemies.Remove(val);
			}
		}
		if (roomEnemies.Count == 0)
		{
			((BehaviorBase)this).m_aiActor.OverrideTarget = null;
			return;
		}
		AIActor aiActor = ((BehaviorBase)this).m_aiActor;
		AIActor val2 = roomEnemies[Random.Range(0, roomEnemies.Count)];
		aiActor.OverrideTarget = (((Object)(object)val2 != (Object)null) ? ((BraveBehaviour)val2).specRigidbody : null);
	}
}
