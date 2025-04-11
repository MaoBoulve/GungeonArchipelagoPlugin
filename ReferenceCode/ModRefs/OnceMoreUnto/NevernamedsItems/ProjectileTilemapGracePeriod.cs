using UnityEngine;

namespace NevernamedsItems;

public class ProjectileTilemapGracePeriod : MonoBehaviour
{
	private Projectile m_projectile;

	public float period;

	public ProjectileTilemapGracePeriod()
	{
		period = 0.1f;
	}

	private void Start()
	{
		m_projectile = ((Component)this).GetComponent<Projectile>();
		m_projectile.RenderTilePiercingForSeconds(period);
	}
}
