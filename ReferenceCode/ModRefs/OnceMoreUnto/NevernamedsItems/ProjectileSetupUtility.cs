using Alexandria.ItemAPI;
using UnityEngine;

namespace NevernamedsItems;

public class ProjectileSetupUtility
{
	public static Projectile MakeProjectile(int idToCopy, float damage, float range = -1f, float speed = -1f, float bossDamageMult = 0f)
	{
		PickupObject byId = PickupObjectDatabase.GetById(idToCopy);
		Projectile val = Object.Instantiate<Projectile>(((Gun)((byId is Gun) ? byId : null)).DefaultModule.projectiles[0]);
		((Component)val).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val);
		val.baseData.damage = damage;
		if (speed != -1f)
		{
			val.baseData.speed = speed;
		}
		if (range != -1f)
		{
			val.baseData.range = range;
		}
		val.BossDamageMultiplier = bossDamageMult;
		return val;
	}
}
