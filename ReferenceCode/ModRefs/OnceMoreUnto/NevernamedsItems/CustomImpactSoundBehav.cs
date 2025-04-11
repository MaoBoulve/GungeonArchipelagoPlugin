using UnityEngine;

namespace NevernamedsItems;

public class CustomImpactSoundBehav : MonoBehaviour
{
	public string ImpactSFX;

	private Projectile m_projectile;

	private void Start()
	{
		m_projectile = ((Component)this).GetComponent<Projectile>();
		m_projectile.OnDestruction += onDestroy;
	}

	private void onDestroy(Projectile self)
	{
		if (!string.IsNullOrEmpty(ImpactSFX))
		{
			AkSoundEngine.PostEvent(ImpactSFX, ((Component)m_projectile).gameObject);
		}
	}
}
