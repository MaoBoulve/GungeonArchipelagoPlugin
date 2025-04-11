using System;
using Dungeonator;
using UnityEngine;

namespace NevernamedsItems;

public class HomeInOnPlayerModifyer : BraveBehaviour
{
	public float HomingRadius = 2f;

	public float AngularVelocity = 180f;

	protected Projectile m_projectile;

	private void Start()
	{
		if (!Object.op_Implicit((Object)(object)m_projectile))
		{
			m_projectile = ((Component)this).GetComponent<Projectile>();
		}
		Projectile projectile = m_projectile;
		if (Object.op_Implicit((Object)(object)projectile.Owner) && projectile.Owner is PlayerController)
		{
			projectile.ModifyVelocity = (Func<Vector2, Vector2>)Delegate.Combine(projectile.ModifyVelocity, new Func<Vector2, Vector2>(ModifyVelocity));
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
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0071: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_0098: Unknown result type (might be due to invalid IL or missing references)
		//IL_009a: Unknown result type (might be due to invalid IL or missing references)
		//IL_019d: Unknown result type (might be due to invalid IL or missing references)
		//IL_019e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0169: Unknown result type (might be due to invalid IL or missing references)
		//IL_016e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0154: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d6: Unknown result type (might be due to invalid IL or missing references)
		Vector2 val = inVel;
		RoomHandler absoluteRoomFromPosition = GameManager.Instance.Dungeon.data.GetAbsoluteRoomFromPosition(Vector3Extensions.IntXY(m_projectile.LastPosition, (VectorConversions)0));
		float num = float.MaxValue;
		Vector2 val2 = Vector2.zero;
		GameActor owner = m_projectile.Owner;
		PlayerController val3 = (PlayerController)(object)((owner is PlayerController) ? owner : null);
		Vector2 val4 = ((!Object.op_Implicit((Object)(object)((BraveBehaviour)this).sprite)) ? Vector3Extensions.XY(((BraveBehaviour)this).transform.position) : ((BraveBehaviour)this).sprite.WorldCenter);
		Vector2 val5 = ((GameActor)val3).CenterPosition - val4;
		float sqrMagnitude = ((Vector2)(ref val5)).sqrMagnitude;
		if (sqrMagnitude < num)
		{
			val2 = val5;
			num = sqrMagnitude;
		}
		num = Mathf.Sqrt(num);
		if (num < HomingRadius)
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
