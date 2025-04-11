using UnityEngine;

namespace NevernamedsItems;

public class EvenRadialBurstHandler : MonoBehaviour
{
	private float spawnAngle = 0f;

	private Projectile m_projectile;

	private SpeculativeRigidbody speculativeRigidBoy;

	public Projectile projectileToSpawn;

	public bool PostProcess;

	public int numberToSpawn;

	public EvenRadialBurstHandler()
	{
		projectileToSpawn = null;
		numberToSpawn = 10;
	}

	private void Start()
	{
		m_projectile = ((Component)this).GetComponent<Projectile>();
		speculativeRigidBoy = ((Component)this).GetComponent<SpeculativeRigidbody>();
		m_projectile.OnDestruction += DoBurstProjectiles;
		spawnAngle = Random.Range(1, 360);
	}

	private void DoBurstProjectiles(Projectile bullet)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		Projectile proj = (Object.op_Implicit((Object)(object)projectileToSpawn) ? projectileToSpawn : ((Gun)PickupObjectDatabase.GetById(56)).DefaultModule.projectiles[0]);
		for (int i = 0; i < numberToSpawn; i++)
		{
			SpawnProjectile(proj, Vector2.op_Implicit(((BraveBehaviour)m_projectile).sprite.WorldCenter), ((BraveBehaviour)m_projectile).transform.eulerAngles.z + spawnAngle);
			spawnAngle += 360 / numberToSpawn;
		}
	}

	private void SpawnProjectile(Projectile proj, Vector3 spawnPosition, float zRotation, SpeculativeRigidbody collidedRigidbody = null)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		GameObject val = SpawnManager.SpawnProjectile(((Component)proj).gameObject, spawnPosition, Quaternion.Euler(0f, 0f, zRotation), true);
		Projectile component = val.GetComponent<Projectile>();
		if (!Object.op_Implicit((Object)(object)component))
		{
			return;
		}
		component.SpawnedFromOtherPlayerProjectile = true;
		component.Owner = m_projectile.Owner;
		component.Shooter = m_projectile.Shooter;
		if (m_projectile.Owner is PlayerController)
		{
			GameActor owner = m_projectile.Owner;
			PlayerController val2 = (PlayerController)(object)((owner is PlayerController) ? owner : null);
			if (PostProcess)
			{
				val2.DoPostProcessProjectile(component);
			}
		}
	}
}
