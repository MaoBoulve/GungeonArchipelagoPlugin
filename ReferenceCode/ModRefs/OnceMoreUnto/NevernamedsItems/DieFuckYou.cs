using UnityEngine;

namespace NevernamedsItems;

public class DieFuckYou : MonoBehaviour
{
	private Projectile m_projectile;

	private void Start()
	{
		m_projectile = ((Component)this).GetComponent<Projectile>();
		m_projectile.ForceDestruction();
	}
}
