using System;
using UnityEngine;

namespace NevernamedsItems;

public class ProjectileMotionDrift : MonoBehaviour
{
	private Projectile m_projectile;

	public float maxDriftPerTile;

	public float minDriftPerTile;

	public bool randomiseInverseEachCheck;

	public bool randomInverseOnStart;

	private float distanceLastChecked;

	public bool recalcDriftPerCheck;

	private float staticAngle;

	public ProjectileMotionDrift()
	{
		maxDriftPerTile = 4f;
		minDriftPerTile = 0.1f;
		randomInverseOnStart = true;
		randomiseInverseEachCheck = false;
	}

	private void Start()
	{
		m_projectile = ((Component)this).GetComponent<Projectile>();
		Projectile projectile = m_projectile;
		projectile.ModifyVelocity = (Func<Vector2, Vector2>)Delegate.Combine(projectile.ModifyVelocity, new Func<Vector2, Vector2>(ModVeloc));
		if (!recalcDriftPerCheck)
		{
			staticAngle = Random.Range(minDriftPerTile, maxDriftPerTile);
		}
		if (randomInverseOnStart && Random.value <= 0.5f)
		{
			staticAngle *= -1f;
		}
	}

	private Vector2 ModVeloc(Vector2 inVel)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0073: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Unknown result type (might be due to invalid IL or missing references)
		//IL_0089: Unknown result type (might be due to invalid IL or missing references)
		//IL_009b: Unknown result type (might be due to invalid IL or missing references)
		Vector2 result = inVel;
		if (m_projectile.GetElapsedDistance() > distanceLastChecked + 1f)
		{
			float num = ((!recalcDriftPerCheck) ? staticAngle : Random.Range(minDriftPerTile, maxDriftPerTile));
			if (randomiseInverseEachCheck && Random.value <= 0.5f)
			{
				num *= -1f;
			}
			float num2 = Vector2Extensions.ToAngle(inVel) + num;
			result = BraveMathCollege.DegreesToVector(num2, ((Vector2)(ref inVel)).magnitude);
			((Component)this).transform.rotation = Quaternion.Euler(0f, 0f, num2);
			distanceLastChecked = m_projectile.GetElapsedDistance();
		}
		return result;
	}
}
