using UnityEngine;

namespace NevernamedsItems;

public class SimpleProjectileTrail : MonoBehaviour
{
	public bool addSmoke;

	public static GameObject smokePre;

	public static GameObject firePre;

	public Projectile self;

	public void Start()
	{
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		self = ((Component)this).GetComponent<Projectile>();
		if (addSmoke)
		{
			GameObject val = Object.Instantiate<GameObject>(smokePre);
			val.transform.position = Vector2.op_Implicit(((BraveBehaviour)self).specRigidbody.UnitCenterLeft);
			val.transform.SetParent(((BraveBehaviour)self).transform);
			val.GetComponent<ParticleKiller>().ForceInit();
		}
	}

	static SimpleProjectileTrail()
	{
		PickupObject byId = PickupObjectDatabase.GetById(39);
		smokePre = ((Component)((BraveBehaviour)((Gun)((byId is Gun) ? byId : null)).DefaultModule.projectiles[0]).transform.Find("VFX_Rocket_Exhaust")).gameObject;
		PickupObject byId2 = PickupObjectDatabase.GetById(39);
		firePre = ((Component)((BraveBehaviour)((Gun)((byId2 is Gun) ? byId2 : null)).DefaultModule.projectiles[0]).transform.Find("VFX_Rocket_Exhaust_Fire")).gameObject;
	}
}
