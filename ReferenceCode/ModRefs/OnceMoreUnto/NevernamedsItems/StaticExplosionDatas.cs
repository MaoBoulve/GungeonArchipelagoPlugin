using UnityEngine;

namespace NevernamedsItems;

internal class StaticExplosionDatas
{
	public static ExplosionData explosiveRoundsExplosion = ((Component)PickupObjectDatabase.GetById(304)).GetComponent<ComplexProjectileModifier>().ExplosionData;

	public static ExplosionData genericSmallExplosion = GameManager.Instance.Dungeon.sharedSettingsPrefab.DefaultSmallExplosionData;

	public static ExplosionData genericLargeExplosion = GameManager.Instance.Dungeon.sharedSettingsPrefab.DefaultExplosionData;

	public static ExplosionData tetrisBlockExplosion;

	public static ExplosionData customDynamiteExplosion;

	static StaticExplosionDatas()
	{
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_008e: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0101: Unknown result type (might be due to invalid IL or missing references)
		//IL_0108: Unknown result type (might be due to invalid IL or missing references)
		//IL_010f: Unknown result type (might be due to invalid IL or missing references)
		//IL_011b: Expected O, but got Unknown
		PickupObject byId = PickupObjectDatabase.GetById(483);
		tetrisBlockExplosion = ((Component)((Gun)((byId is Gun) ? byId : null)).DefaultModule.projectiles[0]).GetComponent<TetrisBuff>().tetrisExplosion;
		customDynamiteExplosion = new ExplosionData
		{
			effect = genericLargeExplosion.effect,
			ignoreList = genericLargeExplosion.ignoreList,
			ss = genericLargeExplosion.ss,
			damageRadius = 5f,
			damageToPlayer = 0f,
			doDamage = true,
			damage = 45f,
			doDestroyProjectiles = true,
			doForce = true,
			debrisForce = 30f,
			preventPlayerForce = true,
			explosionDelay = 0.1f,
			usesComprehensiveDelay = false,
			doScreenShake = true,
			playDefaultSFX = true
		};
	}
}
