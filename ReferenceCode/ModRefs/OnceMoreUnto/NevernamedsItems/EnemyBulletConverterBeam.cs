using Alexandria.ItemAPI;
using Alexandria.Misc;
using UnityEngine;

namespace NevernamedsItems;

public class EnemyBulletConverterBeam : MonoBehaviour
{
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
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_0253: Unknown result type (might be due to invalid IL or missing references)
		foreach (Projectile allProjectile in StaticReferenceManager.AllProjectiles)
		{
			if (Object.op_Implicit((Object)(object)allProjectile) && ((Object)(object)allProjectile.Owner == (Object)null || !(allProjectile.Owner is PlayerController)) && (Object)(object)((BraveBehaviour)allProjectile).specRigidbody != (Object)null && BeamAPI.PosIsNearAnyBoneOnBeam(basicBeamController, ((BraveBehaviour)allProjectile).specRigidbody.UnitCenter, 1f))
			{
				if (Object.op_Implicit((Object)(object)allProjectile.Owner) && Object.op_Implicit((Object)(object)((BraveBehaviour)allProjectile.Owner).specRigidbody))
				{
					((BraveBehaviour)allProjectile).specRigidbody.DeregisterSpecificCollisionException(((BraveBehaviour)allProjectile.Owner).specRigidbody);
				}
				if ((Object)(object)((Component)allProjectile).GetComponent<BeamController>() != (Object)null)
				{
					((Component)allProjectile).GetComponent<BeamController>().HitsPlayers = false;
					((Component)allProjectile).GetComponent<BeamController>().HitsEnemies = true;
				}
				else if ((Object)(object)((Component)allProjectile).GetComponent<BasicBeamController>() != (Object)null)
				{
					((BeamController)((Component)allProjectile).GetComponent<BasicBeamController>()).HitsPlayers = false;
					((BeamController)((Component)allProjectile).GetComponent<BasicBeamController>()).HitsEnemies = true;
				}
				allProjectile.Owner = (GameActor)(object)owner;
				allProjectile.SetNewShooter(((BraveBehaviour)owner).specRigidbody);
				allProjectile.allowSelfShooting = false;
				allProjectile.collidesWithPlayer = false;
				allProjectile.collidesWithEnemies = true;
				allProjectile.baseData.damage = 5f;
				if (allProjectile.IsBlackBullet)
				{
					ProjectileData baseData = allProjectile.baseData;
					baseData.damage *= 2f;
				}
				PlayerController val = owner;
				if ((Object)(object)val != (Object)null)
				{
					ProjectileData baseData2 = allProjectile.baseData;
					baseData2.damage *= val.stats.GetStatValue((StatType)5);
					ProjectileData baseData3 = allProjectile.baseData;
					baseData3.speed *= val.stats.GetStatValue((StatType)6);
					allProjectile.UpdateSpeed();
					ProjectileData baseData4 = allProjectile.baseData;
					baseData4.force *= val.stats.GetStatValue((StatType)12);
					ProjectileData baseData5 = allProjectile.baseData;
					baseData5.range *= val.stats.GetStatValue((StatType)26);
					allProjectile.BossDamageMultiplier *= val.stats.GetStatValue((StatType)22);
					allProjectile.RuntimeUpdateScale(val.stats.GetStatValue((StatType)15));
					val.DoPostProcessProjectile(allProjectile);
				}
				allProjectile.AdjustPlayerProjectileTint(ExtendedColours.honeyYellow, 1, 0f);
				allProjectile.UpdateCollisionMask();
				ProjectileUtility.RemoveFromPool(allProjectile);
				allProjectile.Reflected();
			}
		}
	}
}
