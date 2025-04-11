using System;
using System.Collections.Generic;
using Dungeonator;
using UnityEngine;

namespace NevernamedsItems;

public class AreaFearBulletModifier : MonoBehaviour
{
	private PlayerController player;

	private Projectile m_projectile;

	public Color tintColour;

	public bool useSpecialTint;

	public float procChance;

	public float fearStartDistance;

	public float fearStopDistance;

	public float fearLength;

	public float effectRadius;

	public AreaFearBulletModifier()
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		tintColour = ExtendedColours.pink;
		useSpecialTint = true;
		procChance = 1f;
		effectRadius = 5f;
		fearLength = 1f;
		fearStartDistance = 5f;
		fearStopDistance = 7f;
	}

	private void Start()
	{
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		m_projectile = ((Component)this).GetComponent<Projectile>();
		if (m_projectile.Owner is PlayerController)
		{
			ref PlayerController reference = ref player;
			GameActor owner = m_projectile.Owner;
			reference = (PlayerController)(object)((owner is PlayerController) ? owner : null);
		}
		if (useSpecialTint)
		{
			m_projectile.AdjustPlayerProjectileTint(tintColour, 2, 0f);
		}
		Projectile projectile = m_projectile;
		projectile.OnHitEnemy = (Action<Projectile, SpeculativeRigidbody, bool>)Delegate.Combine(projectile.OnHitEnemy, new Action<Projectile, SpeculativeRigidbody, bool>(OnHitEnemy));
	}

	private void OnHitEnemy(Projectile bullet, SpeculativeRigidbody enemy, bool fatal)
	{
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		if (!(Random.value <= procChance))
		{
			return;
		}
		List<AIActor> activeEnemies = ((DungeonPlaceableBehaviour)((BraveBehaviour)enemy).aiActor).GetAbsoluteParentRoom().GetActiveEnemies((ActiveEnemyType)0);
		if (activeEnemies == null)
		{
			return;
		}
		for (int i = 0; i < activeEnemies.Count; i++)
		{
			AIActor val = activeEnemies[i];
			if (val.IsNormalEnemy)
			{
				float num = Vector2.Distance(((BraveBehaviour)enemy).specRigidbody.UnitCenter, ((GameActor)val).CenterPosition);
				if (num <= effectRadius)
				{
					val.ApplyFear(player, fearLength, fearStartDistance, fearStopDistance);
				}
			}
		}
	}
}
