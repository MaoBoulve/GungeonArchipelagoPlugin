using Alexandria.ItemAPI;
using Alexandria.Misc;
using UnityEngine;

namespace NevernamedsItems;

public class EnemyBulletReflectorBeam : MonoBehaviour
{
	private float timer;

	private Projectile projectile;

	private BasicBeamController basicBeamController;

	private BeamController beamController;

	private PlayerController owner;

	private void Start()
	{
		projectile = ((Component)this).GetComponent<Projectile>();
		beamController = ((Component)this).GetComponent<BeamController>();
		basicBeamController = ((Component)this).GetComponent<BasicBeamController>();
		if (projectile.Owner is PlayerController)
		{
			ref PlayerController reference = ref owner;
			GameActor obj = projectile.Owner;
			reference = (PlayerController)(object)((obj is PlayerController) ? obj : null);
		}
	}

	private void Update()
	{
		if (timer <= 0.1f)
		{
			timer += BraveTime.DeltaTime;
			return;
		}
		timer = 0f;
		if ((double)Random.value <= 0.25)
		{
			DoReflect();
		}
	}

	private void DoReflect()
	{
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		foreach (Projectile allProjectile in StaticReferenceManager.AllProjectiles)
		{
			if (Object.op_Implicit((Object)(object)allProjectile) && ((Object)(object)allProjectile.Owner == (Object)null || !(allProjectile.Owner is PlayerController)) && (Object)(object)((BraveBehaviour)allProjectile).specRigidbody != (Object)null && BeamAPI.PosIsNearAnyBoneOnBeam(basicBeamController, ((BraveBehaviour)allProjectile).specRigidbody.UnitCenter, 1f))
			{
				ProjectileUtility.ReflectBullet(allProjectile, true, (GameActor)(object)owner, 10f, false, 1f, 10f, 0f, (string)null);
			}
		}
	}
}
