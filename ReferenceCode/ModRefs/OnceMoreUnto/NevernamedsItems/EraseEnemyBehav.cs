using System;
using UnityEngine;

namespace NevernamedsItems;

public class EraseEnemyBehav : MonoBehaviour
{
	public enum BossInteraction
	{
		ERASE,
		DAMAGE,
		IGNORE
	}

	private Projectile m_projectile;

	public BossInteraction bossMode;

	public float bonusBossDMG;

	public bool doSparks;

	public EraseEnemyBehav()
	{
		bossMode = BossInteraction.DAMAGE;
		bonusBossDMG = 500f;
	}

	private void Start()
	{
		m_projectile = ((Component)this).GetComponent<Projectile>();
		Projectile projectile = m_projectile;
		projectile.OnHitEnemy = (Action<Projectile, SpeculativeRigidbody, bool>)Delegate.Combine(projectile.OnHitEnemy, new Action<Projectile, SpeculativeRigidbody, bool>(OnHitEnemy));
	}

	private void OnHitEnemy(Projectile self, SpeculativeRigidbody enemy, bool fatal)
	{
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e4: Unknown result type (might be due to invalid IL or missing references)
		if (!Object.op_Implicit((Object)(object)enemy) || !Object.op_Implicit((Object)(object)((BraveBehaviour)enemy).aiActor) || !Object.op_Implicit((Object)(object)((BraveBehaviour)((BraveBehaviour)enemy).aiActor).healthHaver))
		{
			return;
		}
		if (((BraveBehaviour)((BraveBehaviour)enemy).aiActor).healthHaver.IsBoss && bossMode != 0)
		{
			if (bossMode != BossInteraction.IGNORE)
			{
				((BraveBehaviour)((BraveBehaviour)enemy).aiActor).healthHaver.ApplyDamage(bonusBossDMG, Vector2.zero, "Erase", (CoreDamageTypes)1, (DamageCategory)5, false, (PixelCollider)null, false);
			}
			return;
		}
		((BraveBehaviour)enemy).aiActor.EraseFromExistenceWithRewards(false);
		if (doSparks)
		{
			for (int i = 0; i < 5; i++)
			{
				GlobalSparksDoer.DoRandomParticleBurst(3, Vector2.op_Implicit(((BraveBehaviour)enemy).specRigidbody.UnitCenter), Vector2.op_Implicit(((BraveBehaviour)enemy).specRigidbody.UnitCenter), new Vector3((float)Random.Range(0, 4), (float)Random.Range(0, 4)), 360f, 0f, (float?)null, (float?)null, (Color?)null, (SparksType)3);
			}
		}
	}
}
