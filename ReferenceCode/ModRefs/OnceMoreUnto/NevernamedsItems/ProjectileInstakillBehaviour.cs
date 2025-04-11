using System;
using System.Collections.Generic;
using Alexandria.ItemAPI;
using UnityEngine;

namespace NevernamedsItems;

public class ProjectileInstakillBehaviour : MonoBehaviour
{
	public float bossBonusDMG;

	private Projectile m_projectile;

	public List<string> enemyGUIDsToKill = new List<string>();

	public List<string> enemyGUIDSToEraseFromExistence = new List<string>();

	public List<string> tagsToKill = new List<string>();

	public bool protectBosses;

	public ProjectileInstakillBehaviour()
	{
		bossBonusDMG = 1f;
		protectBosses = true;
	}

	public void Start()
	{
		m_projectile = ((Component)this).GetComponent<Projectile>();
		if (Object.op_Implicit((Object)(object)m_projectile))
		{
			Projectile projectile = m_projectile;
			projectile.OnHitEnemy = (Action<Projectile, SpeculativeRigidbody, bool>)Delegate.Combine(projectile.OnHitEnemy, new Action<Projectile, SpeculativeRigidbody, bool>(OnHitEnemy));
		}
	}

	private void OnHitEnemy(Projectile bullet, SpeculativeRigidbody enemy, bool fatal)
	{
		//IL_00d5: Unknown result type (might be due to invalid IL or missing references)
		if (!Object.op_Implicit((Object)(object)enemy) || !Object.op_Implicit((Object)(object)((BraveBehaviour)enemy).aiActor) || !Object.op_Implicit((Object)(object)((BraveBehaviour)enemy).healthHaver) || fatal)
		{
			return;
		}
		bool flag = false;
		if (enemyGUIDsToKill.Contains(((BraveBehaviour)enemy).aiActor.EnemyGuid))
		{
			flag = true;
		}
		foreach (string item in tagsToKill)
		{
			if (AlexandriaTags.HasTag(((BraveBehaviour)enemy).aiActor, item))
			{
				flag = true;
			}
		}
		if (flag)
		{
			((BraveBehaviour)enemy).healthHaver.ApplyDamage((((BraveBehaviour)enemy).healthHaver.IsBoss && !((BraveBehaviour)enemy).healthHaver.IsSubboss && protectBosses) ? bossBonusDMG : 10000000f, Vector2.zero, "Erasure", (CoreDamageTypes)0, (DamageCategory)((((BraveBehaviour)enemy).healthHaver.IsBoss && !((BraveBehaviour)enemy).healthHaver.IsSubboss && protectBosses) ? 3 : 5), true, (PixelCollider)null, false);
		}
		if (enemyGUIDSToEraseFromExistence.Contains(((BraveBehaviour)enemy).aiActor.EnemyGuid))
		{
			((BraveBehaviour)enemy).aiActor.EraseFromExistenceWithRewards(false);
		}
	}
}
