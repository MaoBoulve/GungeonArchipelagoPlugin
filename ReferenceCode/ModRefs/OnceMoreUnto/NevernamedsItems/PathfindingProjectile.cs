using System;
using System.Collections.Generic;
using Alexandria.Misc;
using Dungeonator;
using Pathfinding;
using UnityEngine;

namespace NevernamedsItems;

public class PathfindingProjectile : Projectile
{
	public GameActor currentTarget;

	public float repathTimer = 0.2f;

	private Path m_currentPath;

	public CellTypes PathableTiles = (CellTypes)2;

	private List<IntVector2> m_upcomingPathTiles = new List<IntVector2>();

	public IntVector2 PathTile => Vector2Extensions.ToIntVector2(((Projectile)this).SafeCenter, (VectorConversions)0);

	public override void Move()
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		Vector2 pathVelocityContribution = GetPathVelocityContribution();
		((BraveBehaviour)this).specRigidbody.Velocity = pathVelocityContribution;
		((Projectile)this).LastVelocity = pathVelocityContribution;
		base.m_currentDirection = ((Vector2)(ref pathVelocityContribution)).normalized;
	}

	public override void Update()
	{
		if ((Object)(object)currentTarget == (Object)null || currentTarget.IsGone || (Object.op_Implicit((Object)(object)((BraveBehaviour)currentTarget).healthHaver) && ((BraveBehaviour)currentTarget).healthHaver.IsDead))
		{
			GetNextTarget();
		}
		if (repathTimer <= 0f)
		{
			UpdatePath();
		}
		else
		{
			repathTimer -= BraveTime.DeltaTime;
		}
		((Projectile)this).Update();
	}

	private Vector2 GetPathVelocityContribution()
	{
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0082: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0086: Unknown result type (might be due to invalid IL or missing references)
		if (m_currentPath == null || m_currentPath.Count == 0)
		{
			return Vector2.zero;
		}
		Vector2 unitCenter = ((BraveBehaviour)this).specRigidbody.UnitCenter;
		Vector2 pathTarget = GetPathTarget();
		Vector2 val = pathTarget - unitCenter;
		if (((Projectile)this).Speed * ((Projectile)this).LocalDeltaTime > ((Vector2)(ref val)).magnitude)
		{
			return val / ((Projectile)this).LocalDeltaTime;
		}
		return ((Projectile)this).Speed * ((Vector2)(ref val)).normalized;
	}

	public void UpdatePath()
	{
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Unknown result type (might be due to invalid IL or missing references)
		if ((Object)(object)currentTarget != (Object)null)
		{
			PathfindToPosition(currentTarget.CenterPosition, smooth: true, null, null, null);
			repathTimer = 0.2f;
		}
		else if (ProjectileUtility.GetAbsoluteRoom((Projectile)(object)this) != null)
		{
			IntVector2? randomAvailableCell = ProjectileUtility.GetAbsoluteRoom((Projectile)(object)this).GetRandomAvailableCell((IntVector2?)new IntVector2(1, 1), (CellTypes?)PathableTiles, false, (CellValidator)null);
			if (randomAvailableCell.HasValue)
			{
				PathfindToPosition((Vector2)randomAvailableCell.Value, smooth: true, null, null, null);
			}
			repathTimer = 1f;
		}
	}

	public bool PathfindToPosition(Vector2 targetPosition, bool smooth = true, CellValidator cellValidator = null, ExtraWeightingFunction extraWeightingFunction = null, CellTypes? overridePathableTiles = null, bool canPassOccupied = false)
	{
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		bool result = false;
		Pathfinder.Instance.RemoveActorPath(m_upcomingPathTiles);
		CellTypes val = ((!overridePathableTiles.HasValue) ? PathableTiles : overridePathableTiles.Value);
		Path val2 = null;
		if (Pathfinder.Instance.GetPath(PathTile, Vector2Extensions.ToIntVector2(targetPosition, (VectorConversions)0), ref val2, (IntVector2?)new IntVector2(1, 1), val, cellValidator, extraWeightingFunction, canPassOccupied))
		{
			m_currentPath = val2;
			if (m_currentPath != null && m_currentPath.WillReachFinalGoal)
			{
				result = true;
			}
			if (m_currentPath.Count == 0)
			{
				m_currentPath = null;
			}
			else if (smooth)
			{
				val2.Smooth(((BraveBehaviour)this).specRigidbody.UnitCenter, ((BraveBehaviour)this).specRigidbody.UnitDimensions / 2f, val, canPassOccupied, new IntVector2(1, 1));
			}
		}
		UpdateUpcomingPathTiles(2f);
		Pathfinder.Instance.UpdateActorPath(m_upcomingPathTiles);
		return result;
	}

	private void UpdateUpcomingPathTiles(float time)
	{
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0096: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0119: Unknown result type (might be due to invalid IL or missing references)
		//IL_011e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0122: Unknown result type (might be due to invalid IL or missing references)
		//IL_0127: Unknown result type (might be due to invalid IL or missing references)
		m_upcomingPathTiles.Clear();
		m_upcomingPathTiles.Add(PathTile);
		if (m_currentPath == null || m_currentPath.Count <= 0)
		{
			return;
		}
		float num = 0f;
		Vector2 val = ((Projectile)this).SafeCenter;
		LinkedListNode<IntVector2> linkedListNode = m_currentPath.Positions.First;
		IntVector2 value = linkedListNode.Value;
		Vector2 val2 = ((IntVector2)(ref value)).ToCenterVector2();
		Vector2 val3;
		for (; num < time; num += ((Vector2)(ref val3)).magnitude / ((Projectile)this).Speed)
		{
			val3 = val2 - val;
			if (((Vector2)(ref val3)).sqrMagnitude > 0.04f)
			{
				val3 = ((Vector2)(ref val3)).normalized * 0.2f;
			}
			val += val3;
			IntVector2 val4 = Vector2Extensions.ToIntVector2(val, (VectorConversions)0);
			if (m_upcomingPathTiles[m_upcomingPathTiles.Count - 1] != val4)
			{
				m_upcomingPathTiles.Add(val4);
			}
			if (((Vector2)(ref val3)).magnitude < 0.2f)
			{
				linkedListNode = linkedListNode.Next;
				if (linkedListNode == null)
				{
					break;
				}
				value = linkedListNode.Value;
				val2 = ((IntVector2)(ref value)).ToCenterVector2();
			}
		}
	}

	public void GetNextTarget()
	{
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		if ((Object)(object)((Projectile)this).Owner != (Object)null && ((Projectile)this).Owner is PlayerController)
		{
			if (ProjectileUtility.GetAbsoluteRoom((Projectile)(object)this) != null && ProjectileUtility.GetAbsoluteRoom((Projectile)(object)this).GetActiveEnemiesCount((ActiveEnemyType)1) > 0)
			{
				AIActor nearestEnemyToPosition = MathsAndLogicHelper.GetNearestEnemyToPosition(Vector2.op_Implicit(((Projectile)this).LastPosition), true, (ActiveEnemyType)1, (List<AIActor>)null, (Func<AIActor, bool>)null);
				currentTarget = (GameActor)(object)nearestEnemyToPosition;
			}
		}
		else
		{
			PlayerController activePlayerClosestToPoint = GameManager.Instance.GetActivePlayerClosestToPoint(Vector2.op_Implicit(((Projectile)this).LastPosition), false);
			currentTarget = (GameActor)(object)activePlayerClosestToPoint;
		}
	}

	private bool GetNextTargetPosition(out Vector2 targetPos)
	{
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		if (m_currentPath != null && m_currentPath.Count > 0)
		{
			targetPos = m_currentPath.GetFirstCenterVector2();
			return true;
		}
		targetPos = Vector2.zero;
		return false;
	}

	private Vector2 GetPathTarget()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0086: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Unknown result type (might be due to invalid IL or missing references)
		//IL_0089: Unknown result type (might be due to invalid IL or missing references)
		//IL_008e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0092: Unknown result type (might be due to invalid IL or missing references)
		//IL_0098: Unknown result type (might be due to invalid IL or missing references)
		//IL_009d: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		Vector2 unitCenter = ((BraveBehaviour)this).specRigidbody.UnitCenter;
		Vector2 result = unitCenter;
		float num = ((Projectile)this).Speed * ((Projectile)this).LocalDeltaTime;
		Vector2 val = unitCenter;
		Vector2 targetPos = unitCenter;
		while (num > 0f)
		{
			if (GetNextTargetPosition(out targetPos))
			{
				float num2 = Vector2.Distance(targetPos, unitCenter);
				if (num2 < num)
				{
					num -= num2;
					val = targetPos;
					result = val;
					if (m_currentPath != null && m_currentPath.Count > 0)
					{
						m_currentPath.RemoveFirst();
					}
					continue;
				}
				Vector2 val2 = targetPos - val;
				result = ((Vector2)(ref val2)).normalized * num + val;
			}
			return result;
		}
		return result;
	}
}
