using System;
using System.Collections.Generic;
using Alexandria.Misc;
using Dungeonator;
using UnityEngine;

namespace NevernamedsItems;

public class PillarocketFiring : MonoBehaviour
{
	private bool hasStarted;

	private float timer;

	private float TimeBetweenAttacks;

	private float AngleVariance;

	private Projectile projectileToFire;

	private int numToFire;

	private Projectile m_projectile;

	private SpeculativeRigidbody m_rigidBody;

	private PlayerController m_player;

	public PillarocketFiring()
	{
		hasStarted = false;
	}

	private void Start()
	{
		m_projectile = ((Component)this).GetComponent<Projectile>();
		m_rigidBody = ((BraveBehaviour)m_projectile).specRigidbody;
		if (m_projectile.Owner is PlayerController)
		{
			ref PlayerController player = ref m_player;
			GameActor owner = m_projectile.Owner;
			player = (PlayerController)(object)((owner is PlayerController) ? owner : null);
		}
		switch (Random.Range(1, 4))
		{
		case 1:
			TimeBetweenAttacks = 0.11f;
			AngleVariance = 4f;
			numToFire = 1;
			projectileToFire = Pillarocket.PillarocketAKProj;
			break;
		case 2:
			TimeBetweenAttacks = 0.15f;
			AngleVariance = 7f;
			numToFire = 1;
			projectileToFire = Pillarocket.PillarocketMagnumProj;
			break;
		case 3:
			TimeBetweenAttacks = 0.6f;
			AngleVariance = 10f;
			numToFire = 6;
			projectileToFire = Pillarocket.PillarocketShotgunProj;
			break;
		}
		hasStarted = true;
	}

	private void Update()
	{
		//IL_0089: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f2: Unknown result type (might be due to invalid IL or missing references)
		if (!hasStarted || !Object.op_Implicit((Object)(object)m_projectile) || !Object.op_Implicit((Object)(object)m_player) || !Object.op_Implicit((Object)(object)m_rigidBody))
		{
			return;
		}
		if (timer > 0f)
		{
			timer -= BraveTime.DeltaTime;
		}
		if (!(timer <= 0f))
		{
			return;
		}
		for (int i = 0; i < numToFire; i++)
		{
			if (!Object.op_Implicit((Object)(object)MathsAndLogicHelper.GetNearestEnemyToPosition(((BraveBehaviour)m_projectile).sprite.WorldCenter, true, (ActiveEnemyType)1, (List<AIActor>)null, (Func<AIActor, bool>)null)))
			{
				continue;
			}
			Vector2 worldCenter = ((BraveBehaviour)m_projectile).sprite.WorldCenter;
			Vector2 val = Vector2.op_Implicit(MathsAndLogicHelper.GetNearestEnemyToPosition(worldCenter, true, (ActiveEnemyType)1, (List<AIActor>)null, (Func<AIActor, bool>)null).Position);
			if (val != Vector2.zero)
			{
				GameObject val2 = ProjSpawnHelper.SpawnProjectileTowardsPoint(((Component)projectileToFire).gameObject, worldCenter, val, 0f, AngleVariance);
				Projectile component = val2.GetComponent<Projectile>();
				if ((Object)(object)component != (Object)null)
				{
					component.Owner = (GameActor)(object)m_player;
					component.TreatedAsNonProjectileForChallenge = true;
					component.Shooter = m_rigidBody;
					component.collidesWithPlayer = false;
					ProjectileData baseData = component.baseData;
					baseData.damage *= m_player.stats.GetStatValue((StatType)5);
					ProjectileData baseData2 = component.baseData;
					baseData2.speed *= m_player.stats.GetStatValue((StatType)6);
					ProjectileData baseData3 = component.baseData;
					baseData3.range *= m_player.stats.GetStatValue((StatType)26);
					component.AdditionalScaleMultiplier *= m_player.stats.GetStatValue((StatType)15);
					ProjectileData baseData4 = component.baseData;
					baseData4.force *= m_player.stats.GetStatValue((StatType)12);
					component.BossDamageMultiplier *= m_player.stats.GetStatValue((StatType)22);
					m_player.DoPostProcessProjectile(component);
				}
			}
		}
		timer = TimeBetweenAttacks;
	}
}
