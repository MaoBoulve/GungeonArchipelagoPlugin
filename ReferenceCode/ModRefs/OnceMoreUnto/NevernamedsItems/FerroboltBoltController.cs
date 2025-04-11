using System;
using System.Collections.Generic;
using Dungeonator;
using UnityEngine;

namespace NevernamedsItems;

public class FerroboltBoltController : BraveBehaviour
{
	public float HomingRadius = 200f;

	public float AngularVelocity = 4000f;

	protected Projectile m_projectile;

	private void Start()
	{
		if (!Object.op_Implicit((Object)(object)m_projectile))
		{
			m_projectile = ((Component)this).GetComponent<Projectile>();
		}
		Projectile projectile = m_projectile;
		projectile.ModifyVelocity = (Func<Vector2, Vector2>)Delegate.Combine(projectile.ModifyVelocity, new Func<Vector2, Vector2>(ModifyVelocity));
	}

	private void Update()
	{
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c8: Unknown result type (might be due to invalid IL or missing references)
		foreach (Projectile allProjectile in StaticReferenceManager.AllProjectiles)
		{
			if (Object.op_Implicit((Object)(object)allProjectile) && (Object)(object)allProjectile.Owner != (Object)null && allProjectile.Owner is PlayerController && Object.op_Implicit((Object)(object)((Component)allProjectile).GetComponent<FerroboltOrbController>()) && Vector2.Distance(((BraveBehaviour)allProjectile).sprite.WorldCenter, ((BraveBehaviour)m_projectile).sprite.WorldCenter) < 1f)
			{
				ExplosionData val = StaticExplosionDatas.explosiveRoundsExplosion.CopyExplosionData();
				val.ignoreList.Add(((BraveBehaviour)allProjectile.Owner).specRigidbody);
				Exploder.Explode(Vector2.op_Implicit(((BraveBehaviour)allProjectile).sprite.WorldCenter), val, Vector2.zero, (Action)null, false, (CoreDamageTypes)0, false);
				allProjectile.DieInAir(false, true, true, false);
				m_projectile.DieInAir(false, true, true, false);
			}
		}
	}

	public void AssignProjectile(Projectile source)
	{
		m_projectile = source;
	}

	private Vector2 ModifyVelocity(Vector2 inVel)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_012f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0134: Unknown result type (might be due to invalid IL or missing references)
		//IL_0104: Unknown result type (might be due to invalid IL or missing references)
		//IL_0105: Unknown result type (might be due to invalid IL or missing references)
		//IL_0159: Unknown result type (might be due to invalid IL or missing references)
		//IL_015e: Unknown result type (might be due to invalid IL or missing references)
		//IL_014c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0314: Unknown result type (might be due to invalid IL or missing references)
		//IL_0163: Unknown result type (might be due to invalid IL or missing references)
		//IL_018a: Unknown result type (might be due to invalid IL or missing references)
		//IL_018f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0191: Unknown result type (might be due to invalid IL or missing references)
		//IL_0196: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_01af: Unknown result type (might be due to invalid IL or missing references)
		//IL_02db: Unknown result type (might be due to invalid IL or missing references)
		//IL_02dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0206: Unknown result type (might be due to invalid IL or missing references)
		//IL_020f: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_0292: Unknown result type (might be due to invalid IL or missing references)
		//IL_030f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0310: Unknown result type (might be due to invalid IL or missing references)
		//IL_030a: Unknown result type (might be due to invalid IL or missing references)
		//IL_030b: Unknown result type (might be due to invalid IL or missing references)
		Vector2 val = inVel;
		RoomHandler absoluteRoomFromPosition = GameManager.Instance.Dungeon.data.GetAbsoluteRoomFromPosition(Vector3Extensions.IntXY(m_projectile.LastPosition, (VectorConversions)0));
		List<Projectile> list = new List<Projectile>();
		foreach (Projectile allProjectile in StaticReferenceManager.AllProjectiles)
		{
			if (Object.op_Implicit((Object)(object)allProjectile) && Object.op_Implicit((Object)(object)((Component)allProjectile).gameObject))
			{
				RoomHandler absoluteRoomFromPosition2 = GameManager.Instance.Dungeon.data.GetAbsoluteRoomFromPosition(Vector3Extensions.IntXY(allProjectile.LastPosition, (VectorConversions)0));
				if (absoluteRoomFromPosition2 == absoluteRoomFromPosition && Object.op_Implicit((Object)(object)((Component)allProjectile).GetComponent<FerroboltOrbController>()))
				{
					list.Add(allProjectile);
				}
			}
		}
		if (list == null || list.Count == 0)
		{
			((BraveBehaviour)m_projectile).specRigidbody.CollideWithTileMap = true;
			m_projectile.UpdateCollisionMask();
			return inVel;
		}
		((BraveBehaviour)m_projectile).specRigidbody.CollideWithTileMap = false;
		m_projectile.UpdateCollisionMask();
		float num = float.MaxValue;
		Vector2 val2 = Vector2.zero;
		Projectile val3 = null;
		Vector2 val4 = ((!Object.op_Implicit((Object)(object)((BraveBehaviour)this).sprite)) ? Vector3Extensions.XY(((BraveBehaviour)this).transform.position) : ((BraveBehaviour)this).sprite.WorldCenter);
		for (int i = 0; i < list.Count; i++)
		{
			Projectile val5 = list[i];
			if (Object.op_Implicit((Object)(object)val5))
			{
				Vector2 val6 = ((BraveBehaviour)val5).sprite.WorldCenter - val4;
				float sqrMagnitude = ((Vector2)(ref val6)).sqrMagnitude;
				if (sqrMagnitude < num)
				{
					val2 = val6;
					num = sqrMagnitude;
					val3 = val5;
				}
			}
		}
		num = Mathf.Sqrt(num);
		if (num < HomingRadius && (Object)(object)val3 != (Object)null)
		{
			float num2 = 1f - num / HomingRadius;
			float num3 = Vector2Extensions.ToAngle(val2);
			float num4 = Vector2Extensions.ToAngle(inVel);
			float num5 = AngularVelocity * num2 * m_projectile.LocalDeltaTime;
			float num6 = Mathf.MoveTowardsAngle(num4, num3, num5);
			if (m_projectile is HelixProjectile)
			{
				float num7 = num6 - num4;
				Projectile projectile = m_projectile;
				((HelixProjectile)((projectile is HelixProjectile) ? projectile : null)).AdjustRightVector(num7);
			}
			else
			{
				if (m_projectile.shouldRotate)
				{
					((BraveBehaviour)this).transform.rotation = Quaternion.Euler(0f, 0f, num6);
				}
				val = BraveMathCollege.DegreesToVector(num6, ((Vector2)(ref inVel)).magnitude);
			}
			if (m_projectile.OverrideMotionModule != null)
			{
				m_projectile.OverrideMotionModule.AdjustRightVector(num6 - num4);
			}
		}
		if (val == Vector2.zero || float.IsNaN(val.x) || float.IsNaN(val.y))
		{
			return inVel;
		}
		return val;
	}

	public override void OnDestroy()
	{
		if (Object.op_Implicit((Object)(object)m_projectile))
		{
			Projectile projectile = m_projectile;
			projectile.ModifyVelocity = (Func<Vector2, Vector2>)Delegate.Remove(projectile.ModifyVelocity, new Func<Vector2, Vector2>(ModifyVelocity));
		}
		((BraveBehaviour)this).OnDestroy();
	}
}
