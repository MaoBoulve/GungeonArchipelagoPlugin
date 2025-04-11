using UnityEngine;

namespace NevernamedsItems;

public class ScaleProjectileStatOffPlayerStat : MonoBehaviour
{
	public enum ProjectileStatType
	{
		DAMAGE,
		SPEED,
		RANGE,
		SCALE,
		KNOCKBACK,
		BOSSDAMAGE,
		JAMMEDDAMAGE
	}

	private Projectile m_projectile;

	public ProjectileStatType projstat;

	public StatType playerstat;

	public float multiplierPerLevelOfStat;

	public ScaleProjectileStatOffPlayerStat()
	{
		multiplierPerLevelOfStat = 0.1f;
	}

	private void Start()
	{
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		m_projectile = ((Component)this).GetComponent<Projectile>();
		GameActor owner = m_projectile.Owner;
		if (owner is PlayerController)
		{
			GameActor owner2 = m_projectile.Owner;
			PlayerController val = (PlayerController)(object)((owner2 is PlayerController) ? owner2 : null);
			float statValue = val.stats.GetStatValue(playerstat);
			float num = statValue * multiplierPerLevelOfStat + 1f;
			switch (projstat)
			{
			case ProjectileStatType.DAMAGE:
			{
				ProjectileData baseData4 = m_projectile.baseData;
				baseData4.damage *= num;
				break;
			}
			case ProjectileStatType.SPEED:
			{
				ProjectileData baseData3 = m_projectile.baseData;
				baseData3.speed *= num;
				m_projectile.UpdateSpeed();
				break;
			}
			case ProjectileStatType.RANGE:
			{
				ProjectileData baseData2 = m_projectile.baseData;
				baseData2.range *= num;
				break;
			}
			case ProjectileStatType.KNOCKBACK:
			{
				ProjectileData baseData = m_projectile.baseData;
				baseData.force *= num;
				break;
			}
			case ProjectileStatType.SCALE:
				m_projectile.RuntimeUpdateScale(num);
				break;
			case ProjectileStatType.BOSSDAMAGE:
			{
				Projectile projectile2 = m_projectile;
				projectile2.BossDamageMultiplier *= num;
				break;
			}
			case ProjectileStatType.JAMMEDDAMAGE:
			{
				Projectile projectile = m_projectile;
				projectile.BlackPhantomDamageMultiplier *= num;
				break;
			}
			}
		}
	}
}
