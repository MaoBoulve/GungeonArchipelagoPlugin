using System;
using Alexandria.ItemAPI;
using UnityEngine;

namespace NevernamedsItems;

public class TeapotModifiers : MonoBehaviour
{
	private Gun self;

	private void Start()
	{
		self = ((Component)this).GetComponent<Gun>();
		Gun obj = self;
		obj.OnPreFireProjectileModifier = (Func<Gun, Projectile, ProjectileModule, Projectile>)Delegate.Combine(obj.OnPreFireProjectileModifier, new Func<Gun, Projectile, ProjectileModule, Projectile>(OnPreFireProjectileModifier));
	}

	private Projectile OnPreFireProjectileModifier(Gun sourceGun, Projectile sourceProjectile, ProjectileModule sourceModule)
	{
		if (Object.op_Implicit((Object)(object)sourceGun) && Object.op_Implicit((Object)(object)GunTools.GunPlayerOwner(sourceGun)) && CustomSynergies.PlayerHasActiveSynergy(GunTools.GunPlayerOwner(sourceGun), "Russel's Teapot") && Random.value <= 0.15f)
		{
			return BraveUtility.RandomElement<Projectile>(ExistantGunModifiers.Planets);
		}
		return sourceProjectile;
	}
}
