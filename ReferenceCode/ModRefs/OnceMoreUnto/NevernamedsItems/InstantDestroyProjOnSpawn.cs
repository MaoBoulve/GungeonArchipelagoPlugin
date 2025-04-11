using UnityEngine;

namespace NevernamedsItems;

public class InstantDestroyProjOnSpawn : MonoBehaviour
{
	public float chance;

	private Projectile m_projectile;

	public InstantDestroyProjOnSpawn()
	{
		chance = 1f;
	}

	private void Start()
	{
		m_projectile = ((Component)this).GetComponent<Projectile>();
		if (Random.value <= chance)
		{
			Object.DestroyImmediate((Object)(object)((Component)m_projectile).gameObject);
		}
	}
}
