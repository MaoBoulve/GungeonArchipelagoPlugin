using UnityEngine;

namespace NevernamedsItems;

public class ScaleProjectileStatOffConsumableCount : MonoBehaviour
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

	public enum ConsumableType
	{
		MONEY,
		BLANKS,
		KEYS,
		ITEMS,
		GUNS,
		ARMOUR,
		HEALTH,
		RATKEYS
	}

	private Projectile m_projectile;

	public ProjectileStatType projstat;

	public ConsumableType consumableType;

	public float multiplierPerLevelOfStat;

	public ScaleProjectileStatOffConsumableCount()
	{
		multiplierPerLevelOfStat = 0.1f;
	}

	private void Start()
	{
		m_projectile = ((Component)this).GetComponent<Projectile>();
		GameActor owner = m_projectile.Owner;
		if (owner is PlayerController)
		{
			GameActor owner2 = m_projectile.Owner;
			PlayerController val = (PlayerController)(object)((owner2 is PlayerController) ? owner2 : null);
			float num = 0f;
			switch (consumableType)
			{
			case ConsumableType.ARMOUR:
				num = ((BraveBehaviour)val).healthHaver.Armor;
				break;
			case ConsumableType.BLANKS:
				num = val.Blanks;
				break;
			case ConsumableType.GUNS:
				num = val.inventory.AllGuns.Count;
				break;
			case ConsumableType.HEALTH:
				num = ((BraveBehaviour)val).healthHaver.GetCurrentHealth() * 2f;
				break;
			case ConsumableType.ITEMS:
				num = val.passiveItems.Count + val.activeItems.Count;
				break;
			case ConsumableType.KEYS:
				num = val.carriedConsumables.KeyBullets;
				break;
			case ConsumableType.MONEY:
				num = val.carriedConsumables.Currency;
				break;
			case ConsumableType.RATKEYS:
				num = val.carriedConsumables.ResourcefulRatKeys;
				break;
			}
			float num2 = num * multiplierPerLevelOfStat + 1f;
			switch (projstat)
			{
			case ProjectileStatType.DAMAGE:
			{
				ProjectileData baseData4 = m_projectile.baseData;
				baseData4.damage *= num2;
				break;
			}
			case ProjectileStatType.SPEED:
			{
				ProjectileData baseData3 = m_projectile.baseData;
				baseData3.speed *= num2;
				m_projectile.UpdateSpeed();
				break;
			}
			case ProjectileStatType.RANGE:
			{
				ProjectileData baseData2 = m_projectile.baseData;
				baseData2.range *= num2;
				break;
			}
			case ProjectileStatType.KNOCKBACK:
			{
				ProjectileData baseData = m_projectile.baseData;
				baseData.force *= num2;
				break;
			}
			case ProjectileStatType.SCALE:
				m_projectile.RuntimeUpdateScale(num2);
				break;
			case ProjectileStatType.BOSSDAMAGE:
			{
				Projectile projectile2 = m_projectile;
				projectile2.BossDamageMultiplier *= num2;
				break;
			}
			case ProjectileStatType.JAMMEDDAMAGE:
			{
				Projectile projectile = m_projectile;
				projectile.BlackPhantomDamageMultiplier *= num2;
				break;
			}
			}
		}
	}
}
