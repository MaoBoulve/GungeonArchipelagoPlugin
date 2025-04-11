using UnityEngine;

namespace NevernamedsItems;

public class JusticeBurstHandler : MonoBehaviour
{
	private float spawnAngle = 90f;

	private Projectile m_projectile;

	private SpeculativeRigidbody speculativeRigidBoy;

	public Projectile projectileToSpawn;

	public JusticeBurstHandler()
	{
		projectileToSpawn = null;
	}

	private void Start()
	{
		m_projectile = ((Component)this).GetComponent<Projectile>();
		speculativeRigidBoy = ((Component)this).GetComponent<SpeculativeRigidbody>();
		if (Random.value <= 0.45f)
		{
			m_projectile.OnDestruction += DoBurstProjectiles;
		}
	}

	private void DoBurstProjectiles(Projectile bullet)
	{
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		Projectile proj = ((Gun)PickupObjectDatabase.GetById(378)).DefaultModule.projectiles[0];
		for (int i = 0; i < 8; i++)
		{
			SpawnProjectile(proj, Vector2.op_Implicit(((BraveBehaviour)m_projectile).sprite.WorldCenter), ((BraveBehaviour)m_projectile).transform.eulerAngles.z + spawnAngle);
			spawnAngle += 45f;
		}
	}

	private void SpawnProjectile(Projectile proj, Vector3 spawnPosition, float zRotation, SpeculativeRigidbody collidedRigidbody = null)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		GameObject val = SpawnManager.SpawnProjectile(((Component)proj).gameObject, spawnPosition, Quaternion.Euler(0f, 0f, zRotation), true);
		Projectile component = val.GetComponent<Projectile>();
		if (Object.op_Implicit((Object)(object)component))
		{
			component.SpawnedFromOtherPlayerProjectile = true;
			GameActor owner = m_projectile.Owner;
			PlayerController val2 = (PlayerController)(object)((owner is PlayerController) ? owner : null);
			component.Owner = m_projectile.Owner;
			ProjectileData baseData = component.baseData;
			baseData.damage *= 1.2f;
		}
	}
}
