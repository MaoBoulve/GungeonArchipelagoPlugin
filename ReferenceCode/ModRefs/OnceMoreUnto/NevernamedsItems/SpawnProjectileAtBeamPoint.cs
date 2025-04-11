using System;
using System.Collections.Generic;
using Alexandria.Misc;
using Dungeonator;
using UnityEngine;

namespace NevernamedsItems;

public class SpawnProjectileAtBeamPoint : MonoBehaviour
{
	public float minDistance;

	public float maxDistance;

	public bool pickRandomPosition;

	public float tickCooldown;

	public float chanceToFirePerTick;

	public Projectile projectileToFire;

	public bool doPostProcess;

	public bool addFromBulletWithGunComponent;

	private Projectile m_projectile;

	private BeamController m_beam;

	private BasicBeamController m_basicBeam;

	private PlayerController m_owner;

	private float timer;

	public SpawnProjectileAtBeamPoint()
	{
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		tickCooldown = 0.1f;
		maxDistance = 1f;
		minDistance = 0f;
		pickRandomPosition = true;
		chanceToFirePerTick = 0.5f;
		projectileToFire = Object.Instantiate<Projectile>(((Gun)Databases.Items[86]).DefaultModule.projectiles[0]);
		doPostProcess = true;
		addFromBulletWithGunComponent = false;
	}

	private void Start()
	{
		m_projectile = ((Component)this).GetComponent<Projectile>();
		m_beam = ((Component)this).GetComponent<BeamController>();
		m_basicBeam = ((Component)this).GetComponent<BasicBeamController>();
		if (m_projectile.Owner is PlayerController)
		{
			ref PlayerController owner = ref m_owner;
			GameActor owner2 = m_projectile.Owner;
			owner = (PlayerController)(object)((owner2 is PlayerController) ? owner2 : null);
		}
	}

	private void DoProjectileSpawn()
	{
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		Vector2 pointOnBeam = m_basicBeam.GetPointOnBeam(Random.value);
		Vector2 centerPosition = ((GameActor)MathsAndLogicHelper.GetNearestEnemyToPosition(pointOnBeam, true, (ActiveEnemyType)1, (List<AIActor>)null, (Func<AIActor, bool>)null)).CenterPosition;
		if (!(centerPosition != Vector2.zero))
		{
			return;
		}
		GameObject val = ProjSpawnHelper.SpawnProjectileTowardsPoint(((Component)projectileToFire).gameObject, pointOnBeam, centerPosition, 0f, 5f);
		val.AddComponent<BulletIsFromBeam>();
		Projectile component = val.GetComponent<Projectile>();
		if ((Object)(object)component != (Object)null)
		{
			component.Owner = (GameActor)(object)m_owner;
			component.TreatedAsNonProjectileForChallenge = true;
			component.Shooter = ((BraveBehaviour)m_owner).specRigidbody;
			component.collidesWithPlayer = false;
			if (addFromBulletWithGunComponent)
			{
				GameObjectExtensions.GetOrAddComponent<BulletsWithGuns.BulletFromBulletWithGun>(((Component)component).gameObject);
			}
			if (doPostProcess)
			{
				ProjectileData baseData = component.baseData;
				baseData.damage *= m_owner.stats.GetStatValue((StatType)5);
				ProjectileData baseData2 = component.baseData;
				baseData2.speed *= m_owner.stats.GetStatValue((StatType)6);
				ProjectileData baseData3 = component.baseData;
				baseData3.range *= m_owner.stats.GetStatValue((StatType)26);
				component.AdditionalScaleMultiplier *= m_owner.stats.GetStatValue((StatType)15);
				ProjectileData baseData4 = component.baseData;
				baseData4.force *= m_owner.stats.GetStatValue((StatType)12);
				component.BossDamageMultiplier *= m_owner.stats.GetStatValue((StatType)22);
				m_owner.DoPostProcessProjectile(component);
			}
		}
	}

	private void FixedUpdate()
	{
		if (!((Object)(object)m_beam != (Object)null))
		{
			return;
		}
		if (timer > 0f)
		{
			timer -= BraveTime.DeltaTime;
		}
		if (timer <= 0f)
		{
			if (Random.value <= chanceToFirePerTick)
			{
				DoProjectileSpawn();
			}
			timer = tickCooldown;
		}
	}
}
