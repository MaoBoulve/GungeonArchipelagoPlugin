using UnityEngine;

namespace NevernamedsItems;

public class RandomProjectileStatsComponent : MonoBehaviour
{
	private Projectile m_projectile;

	public bool randomDamage;

	public int highDMGPercent;

	public int lowDMGPercent;

	public bool randomSpeed;

	public int highSpeedPercent;

	public int lowSpeedPercent;

	public bool randomKnockback;

	public int highKnockbackPercent;

	public int lowKnockbackPercent;

	public bool randomRange;

	public int highRangePercent;

	public int lowRangePercent;

	public bool randomScale;

	public int highScalePercent;

	public int lowScalePercent;

	public bool randomBossDMG;

	public int highBossDMGPercent;

	public int lowBossDMGPercent;

	public bool randomJammedDMG;

	public int highJammedDMGPercent;

	public int lowJammedDMGPercent;

	public bool scaleBasedOnDamage;

	public RandomProjectileStatsComponent()
	{
		randomDamage = false;
		highDMGPercent = 200;
		lowDMGPercent = 10;
		randomSpeed = false;
		highSpeedPercent = 200;
		lowSpeedPercent = 10;
		randomKnockback = false;
		highKnockbackPercent = 200;
		lowKnockbackPercent = 10;
		randomRange = false;
		highRangePercent = 200;
		lowRangePercent = 10;
		randomScale = false;
		highScalePercent = 200;
		lowScalePercent = 10;
		randomJammedDMG = false;
		highJammedDMGPercent = 200;
		lowJammedDMGPercent = 10;
		randomBossDMG = false;
		highBossDMGPercent = 200;
		lowBossDMGPercent = 10;
		scaleBasedOnDamage = false;
	}

	private void Start()
	{
		m_projectile = ((Component)this).GetComponent<Projectile>();
		if (randomSpeed)
		{
			ProjectileData baseData = m_projectile.baseData;
			baseData.speed *= (float)Random.Range(lowSpeedPercent, highSpeedPercent + 1) / 100f;
		}
		if (randomKnockback)
		{
			ProjectileData baseData2 = m_projectile.baseData;
			baseData2.force *= (float)Random.Range(lowKnockbackPercent, highKnockbackPercent + 1) / 100f;
		}
		if (randomRange)
		{
			ProjectileData baseData3 = m_projectile.baseData;
			baseData3.range *= (float)Random.Range(lowRangePercent, highRangePercent + 1) / 100f;
		}
		if (randomBossDMG)
		{
			Projectile projectile = m_projectile;
			projectile.BossDamageMultiplier *= (float)Random.Range(lowBossDMGPercent, highBossDMGPercent + 1) / 100f;
		}
		if (randomJammedDMG)
		{
			Projectile projectile2 = m_projectile;
			projectile2.BlackPhantomDamageMultiplier *= (float)Random.Range(lowJammedDMGPercent, highJammedDMGPercent + 1) / 100f;
		}
		float num = (float)Random.Range(lowDMGPercent, highDMGPercent + 1) / 100f;
		if (randomDamage)
		{
			ProjectileData baseData4 = m_projectile.baseData;
			baseData4.damage *= num;
		}
		if (randomScale)
		{
			m_projectile.RuntimeUpdateScale((float)Random.Range(lowScalePercent, highScalePercent + 1) / 100f);
		}
		if (scaleBasedOnDamage)
		{
			m_projectile.RuntimeUpdateScale(num);
		}
		m_projectile.UpdateSpeed();
	}
}
