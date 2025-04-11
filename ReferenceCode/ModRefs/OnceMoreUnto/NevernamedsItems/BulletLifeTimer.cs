using UnityEngine;

namespace NevernamedsItems;

public class BulletLifeTimer : MonoBehaviour
{
	public float secondsTillDeath;

	public bool eraseInsteadOfDie;

	private float timer;

	private Projectile m_projectile;

	public BulletLifeTimer()
	{
		secondsTillDeath = 1f;
		eraseInsteadOfDie = false;
	}

	private void Start()
	{
		timer = secondsTillDeath;
		m_projectile = ((Component)this).GetComponent<Projectile>();
	}

	private void Update()
	{
		if (!((Object)(object)m_projectile != (Object)null))
		{
			return;
		}
		if (timer > 0f)
		{
			timer -= BraveTime.DeltaTime;
		}
		if (timer <= 0f)
		{
			if (eraseInsteadOfDie)
			{
				Object.Destroy((Object)(object)((Component)m_projectile).gameObject);
			}
			else
			{
				m_projectile.DieInAir(false, true, true, false);
			}
		}
	}
}
