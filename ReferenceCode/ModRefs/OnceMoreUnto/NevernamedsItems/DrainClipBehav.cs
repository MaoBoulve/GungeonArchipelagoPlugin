using UnityEngine;

namespace NevernamedsItems;

public class DrainClipBehav : MonoBehaviour
{
	private Projectile m_projectile;

	public int shotsToDrain = 1;

	private void Start()
	{
		m_projectile = ((Component)this).GetComponent<Projectile>();
		if (!Object.op_Implicit((Object)(object)m_projectile) || !((Object)(object)m_projectile.PossibleSourceGun != (Object)null))
		{
			return;
		}
		if (shotsToDrain < 0)
		{
			m_projectile.PossibleSourceGun.MoveBulletsIntoClip(shotsToDrain * -1);
		}
		else if (shotsToDrain > 0)
		{
			m_projectile.PossibleSourceGun.LoseAmmo(shotsToDrain);
			ServiceWeapon component = ((Component)m_projectile.PossibleSourceGun).GetComponent<ServiceWeapon>();
			if (Object.op_Implicit((Object)(object)component) && m_projectile.PossibleSourceGun.ClipShotsRemaining == 0)
			{
				component.Criticalise(state: true);
			}
		}
	}
}
