using Alexandria.Misc;
using UnityEngine;

namespace NevernamedsItems;

public class ProjectileShootbackMod : MonoBehaviour
{
	public bool shootBackOnDestruction = false;

	public bool shootBackOnTimer = false;

	public float timebetweenShootbacks = 0.1f;

	private float t = 0f;

	private Projectile m_projectile;

	public Projectile prefabToFire;

	private void Awake()
	{
		m_projectile = ((Component)this).GetComponent<Projectile>();
		m_projectile.OnDestruction += HandleShootBack;
	}

	private void HandleShootBack(Projectile promj)
	{
		if (Object.op_Implicit((Object)(object)m_projectile) && shootBackOnDestruction)
		{
			Shootback();
		}
	}

	private void Update()
	{
		if (!shootBackOnTimer)
		{
			return;
		}
		t += BraveTime.DeltaTime;
		if (t >= timebetweenShootbacks)
		{
			if (Object.op_Implicit((Object)(object)m_projectile))
			{
				Shootback();
			}
			t = 0f;
		}
	}

	private void Shootback()
	{
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		GameObject val = ProjectileUtility.InstantiateAndFireInDirection(prefabToFire, Vector2.op_Implicit(m_projectile.LastPosition), Vector2Extensions.ToAngle(m_projectile.Direction) + 180f, 0f, (PlayerController)null);
		Projectile component = val.GetComponent<Projectile>();
		if (Object.op_Implicit((Object)(object)component) && Object.op_Implicit((Object)(object)m_projectile.Owner))
		{
			component.Owner = m_projectile.Owner;
			component.Shooter = ((BraveBehaviour)m_projectile.Owner).specRigidbody;
			if (Object.op_Implicit((Object)(object)ProjectileUtility.ProjectilePlayerOwner(m_projectile)))
			{
				component.ScaleByPlayerStats(ProjectileUtility.ProjectilePlayerOwner(m_projectile));
				ProjectileUtility.ProjectilePlayerOwner(m_projectile).DoPostProcessProjectile(component);
			}
			component.RenderTilePiercingForSeconds(0.2f);
		}
	}
}
