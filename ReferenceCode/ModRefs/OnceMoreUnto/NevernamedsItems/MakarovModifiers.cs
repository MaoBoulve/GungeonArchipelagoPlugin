using System;
using Alexandria.ItemAPI;
using UnityEngine;

namespace NevernamedsItems;

public class MakarovModifiers : MonoBehaviour
{
	private Gun self;

	private void Start()
	{
		self = ((Component)this).GetComponent<Gun>();
		Gun obj = self;
		obj.PostProcessProjectile = (Action<Projectile>)Delegate.Combine(obj.PostProcessProjectile, new Action<Projectile>(OnFired));
	}

	private void OnFired(Projectile proj)
	{
		if (Object.op_Implicit((Object)(object)self) && Object.op_Implicit((Object)(object)GunTools.GunPlayerOwner(self)) && CustomSynergies.PlayerHasActiveSynergy(GunTools.GunPlayerOwner(self), "People's Army"))
		{
			FixedFlakBehaviour fixedFlakBehaviour = ((Component)proj).gameObject.AddComponent<FixedFlakBehaviour>();
			fixedFlakBehaviour.angleIsRelative = true;
			fixedFlakBehaviour.postProcess = true;
			fixedFlakBehaviour.AddProjectile(M70.flak, 90f);
			fixedFlakBehaviour.AddProjectile(M70.flak, -90f);
		}
	}
}
