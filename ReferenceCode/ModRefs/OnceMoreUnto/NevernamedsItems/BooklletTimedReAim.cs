using System;
using System.Collections.Generic;
using Alexandria.Misc;
using Dungeonator;
using UnityEngine;

namespace NevernamedsItems;

public class BooklletTimedReAim : MonoBehaviour
{
	private Projectile m_projectile;

	private void Start()
	{
		m_projectile = ((Component)this).GetComponent<Projectile>();
		((MonoBehaviour)this).Invoke("ChangeSpeedAndReAim", 1.5f);
	}

	private void ChangeSpeedAndReAim()
	{
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		Vector2 vectorToNearestEnemy = ProjectileUtility.GetVectorToNearestEnemy(m_projectile, true, (ActiveEnemyType)1, (List<AIActor>)null, (Func<AIActor, bool>)null);
		m_projectile.SendInDirection(vectorToNearestEnemy, false, true);
		ProjectileData baseData = m_projectile.baseData;
		baseData.speed *= 7500f;
		m_projectile.UpdateSpeed();
	}
}
