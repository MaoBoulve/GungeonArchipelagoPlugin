using Alexandria.Misc;
using UnityEngine;

namespace NevernamedsItems;

public class SpiralHandler : MonoBehaviour
{
	private float spawnAngle = 90f;

	private Projectile m_projectile;

	private SpeculativeRigidbody speculativeRigidBoy;

	public Projectile projectileToSpawn;

	private float elapsed;

	public SpiralHandler()
	{
		projectileToSpawn = null;
	}

	private void Start()
	{
		m_projectile = ((Component)this).GetComponent<Projectile>();
		speculativeRigidBoy = ((Component)this).GetComponent<SpeculativeRigidbody>();
	}

	private void Update()
	{
		//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c8: Unknown result type (might be due to invalid IL or missing references)
		if ((Object)(object)m_projectile == (Object)null)
		{
			if (!((Object)(object)((Component)this).GetComponent<Projectile>() != (Object)null))
			{
				return;
			}
			m_projectile = ((Component)this).GetComponent<Projectile>();
		}
		if ((Object)(object)speculativeRigidBoy == (Object)null)
		{
			if (!((Object)(object)((Component)this).GetComponent<SpeculativeRigidbody>() != (Object)null))
			{
				return;
			}
			speculativeRigidBoy = ((Component)this).GetComponent<SpeculativeRigidbody>();
		}
		elapsed += BraveTime.DeltaTime;
		if (elapsed > 0.02f)
		{
			if ((Object)(object)projectileToSpawn == (Object)null)
			{
				Debug.LogError((object)"SpiralHandler tried to spawn a bullet that doesn't exist.");
				return;
			}
			SpawnProjectile(projectileToSpawn, Vector2.op_Implicit(((BraveBehaviour)m_projectile).sprite.WorldCenter), spawnAngle);
			spawnAngle += 10f;
			elapsed = 0f;
		}
	}

	private void SpawnProjectile(Projectile proj, Vector3 spawnPosition, float zRotation, SpeculativeRigidbody collidedRigidbody = null)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		GameObject val = SpawnManager.SpawnProjectile(((Component)proj).gameObject, spawnPosition, Quaternion.Euler(0f, 0f, zRotation), true);
		Projectile component = val.GetComponent<Projectile>();
		if (Object.op_Implicit((Object)(object)component) && Object.op_Implicit((Object)(object)ProjectileUtility.ProjectilePlayerOwner(m_projectile)))
		{
			PlayerController val3 = (PlayerController)(object)(component.Owner = (GameActor)(object)ProjectileUtility.ProjectilePlayerOwner(m_projectile));
			component.Shooter = ((BraveBehaviour)val3).specRigidbody;
			component.SpawnedFromOtherPlayerProjectile = true;
			component.TreatedAsNonProjectileForChallenge = true;
			ProjectileData baseData = component.baseData;
			baseData.damage *= val3.stats.GetStatValue((StatType)5);
			ProjectileData baseData2 = component.baseData;
			baseData2.force *= val3.stats.GetStatValue((StatType)12);
			ProjectileData baseData3 = component.baseData;
			baseData3.speed *= val3.stats.GetStatValue((StatType)6);
			val3.DoPostProcessProjectile(component);
		}
	}
}
