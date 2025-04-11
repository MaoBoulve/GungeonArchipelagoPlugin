using Alexandria.Misc;
using UnityEngine;

namespace NevernamedsItems;

public class BulletSharkProjectileDoer : MonoBehaviour
{
	private bool leftie;

	public float Delay = 0.1f;

	private float timer;

	private Projectile m_projectile;

	private PlayerController playerOwner;

	public Projectile toSpawn;

	private void Awake()
	{
		m_projectile = ((Component)this).GetComponent<Projectile>();
		playerOwner = ProjectileUtility.ProjectilePlayerOwner(m_projectile);
	}

	private void Update()
	{
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		if (timer < Delay)
		{
			timer += BraveTime.DeltaTime;
			return;
		}
		if (Object.op_Implicit((Object)(object)toSpawn))
		{
			Projectile component = ProjectileUtility.InstantiateAndFireInDirection(toSpawn, Vector2.op_Implicit(m_projectile.LastPosition), FireAngle(), 10f, playerOwner).GetComponent<Projectile>();
			if (Object.op_Implicit((Object)(object)playerOwner))
			{
				component.Owner = (GameActor)(object)playerOwner;
				component.Shooter = ((BraveBehaviour)playerOwner).specRigidbody;
				component.ScaleByPlayerStats(playerOwner);
				playerOwner.DoPostProcessProjectile(component);
			}
			else
			{
				component.Owner = m_projectile.Owner;
				component.Shooter = m_projectile.Shooter;
			}
			leftie = !leftie;
		}
		timer = 0f;
	}

	public float FireAngle()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		float num = Vector2Extensions.ToAngle(m_projectile.Direction);
		num += 180f;
		return num + (float)(leftie ? 25 : (-25));
	}
}
