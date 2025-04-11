using System;
using System.Collections.Generic;
using Alexandria.Misc;
using UnityEngine;

namespace NevernamedsItems;

public class FixedFlakBehaviour : BraveBehaviour
{
	public Action<Projectile> OnFlakSpawn;

	public bool angleIsRelative;

	public bool postProcess;

	public float angleVariance = 0f;

	[SerializeField]
	private List<Projectile> bullets = new List<Projectile>();

	[SerializeField]
	private List<float> angles = new List<float>();

	private void Start()
	{
		if (Object.op_Implicit((Object)(object)((BraveBehaviour)this).projectile))
		{
			Projectile projectile = ((BraveBehaviour)this).projectile;
			projectile.OnHitEnemy = (Action<Projectile, SpeculativeRigidbody, bool>)Delegate.Combine(projectile.OnHitEnemy, new Action<Projectile, SpeculativeRigidbody, bool>(OnDest));
		}
	}

	public void AddProjectile(Projectile proj, float angle)
	{
		bullets.Add(proj);
		angles.Add(angle);
	}

	private void OnDest(Projectile proj, SpeculativeRigidbody en, bool f)
	{
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		for (int i = 0; i < bullets.Count; i++)
		{
			if (!((Object)(object)bullets[i] != (Object)null))
			{
				continue;
			}
			Projectile component = ProjectileUtility.InstantiateAndFireInDirection(bullets[i], proj.SafeCenter, Angle(angles[i]), angleVariance, (PlayerController)null).GetComponent<Projectile>();
			if (Object.op_Implicit((Object)(object)en) && Object.op_Implicit((Object)(object)((BraveBehaviour)component).specRigidbody))
			{
				((BraveBehaviour)component).specRigidbody.RegisterSpecificCollisionException(en);
			}
			component.Owner = proj.Owner;
			component.Shooter = proj.Shooter;
			if (Object.op_Implicit((Object)(object)ProjectileUtility.ProjectilePlayerOwner(proj)))
			{
				component.ScaleByPlayerStats(ProjectileUtility.ProjectilePlayerOwner(proj));
				if (postProcess)
				{
					ProjectileUtility.ProjectilePlayerOwner(proj).DoPostProcessProjectile(component);
				}
			}
			if (OnFlakSpawn != null)
			{
				OnFlakSpawn(component);
			}
		}
	}

	private float Angle(float k)
	{
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		if (angleIsRelative && Object.op_Implicit((Object)(object)((BraveBehaviour)this).projectile))
		{
			float num = k;
			k = Vector2Extensions.ToAngle(((BraveBehaviour)this).projectile.Direction) + num;
		}
		return k;
	}
}
