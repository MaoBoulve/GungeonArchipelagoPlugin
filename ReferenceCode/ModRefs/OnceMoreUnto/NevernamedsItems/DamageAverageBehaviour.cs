using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace NevernamedsItems;

public class DamageAverageBehaviour : MonoBehaviour
{
	private Projectile m_projectile;

	private PlayerController Owner;

	private void Start()
	{
		m_projectile = ((Component)this).GetComponent<Projectile>();
		if (Object.op_Implicit((Object)(object)m_projectile) && Object.op_Implicit((Object)(object)m_projectile.Owner) && m_projectile.Owner is PlayerController)
		{
			ref PlayerController owner = ref Owner;
			GameActor owner2 = m_projectile.Owner;
			owner = (PlayerController)(object)((owner2 is PlayerController) ? owner2 : null);
		}
		if (!Object.op_Implicit((Object)(object)Owner))
		{
			return;
		}
		List<float> list = new List<float>();
		foreach (Gun allGun in Owner.inventory.AllGuns)
		{
			if ((Object)(object)allGun != (Object)null && allGun.DefaultModule != null && allGun.DefaultModule.projectiles != null && (Object)(object)allGun.DefaultModule.projectiles[0] != (Object)null && (Object)(object)((Component)allGun.DefaultModule.projectiles[0]).GetComponent<DamageAverageBehaviour>() == (Object)null)
			{
				list.Add(allGun.DefaultModule.projectiles[0].baseData.damage);
			}
		}
		m_projectile.baseData.damage = list.ToArray().Average() * Owner.stats.GetStatValue((StatType)5);
	}
}
