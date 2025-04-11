using Alexandria.ItemAPI;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class GlueGunGlueGunnerSynergy : GunBehaviour
{
	public static int GlueGunnerID;

	public static void Add()
	{
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0102: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0268: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Glue Gunner", "gluegunner");
		Game.Items.Rename("outdated_gun_mods:glue_gunner", "nn:hot_glue_gun+glue_gunner");
		((Component)val).gameObject.AddComponent<GlueGunGlueGunnerSynergy>();
		GunExt.SetShortDescription((PickupObject)(object)val, "yes this is a btd reference");
		GunExt.SetLongDescription((PickupObject)(object)val, "im too tired to write a snarky description");
		val.SetGunSprites("gluegunner", 8, noAmmonomicon: true);
		ref string gunSwitchGroup = ref val.gunSwitchGroup;
		PickupObject byId = PickupObjectDatabase.GetById(199);
		gunSwitchGroup = ((Gun)((byId is Gun) ? byId : null)).gunSwitchGroup;
		GunExt.SetAnimationFPS(val, val.shootAnimation, 12);
		PickupObject byId2 = PickupObjectDatabase.GetById(56);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId2 is Gun) ? byId2 : null), true, false);
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.shootStyle = (ShootStyle)1;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 1f;
		val.DefaultModule.cooldownTime = 0.15f;
		val.DefaultModule.numberOfShotsInClip = 15;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(1.37f, 0.56f, 0f);
		val.SetBaseMaxAmmo(340);
		val.ammo = 340;
		Projectile val2 = Object.Instantiate<Projectile>(val.DefaultModule.projectiles[0]);
		((Component)val2).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val2).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val2);
		ProjectileData baseData = val2.baseData;
		baseData.damage *= 1f;
		ProjectileData baseData2 = val2.baseData;
		baseData2.speed *= 1f;
		ProjectileData baseData3 = val2.baseData;
		baseData3.range *= 1f;
		ApplyLockdownBulletBehaviour applyLockdownBulletBehaviour = ((Component)val2).gameObject.AddComponent<ApplyLockdownBulletBehaviour>();
		applyLockdownBulletBehaviour.useSpecialBulletTint = false;
		applyLockdownBulletBehaviour.duration = 6f;
		applyLockdownBulletBehaviour.enemyTintColour = ExtendedColours.paleYellow;
		applyLockdownBulletBehaviour.TintEnemy = true;
		applyLockdownBulletBehaviour.TintCorpse = true;
		applyLockdownBulletBehaviour.corpseTintColour = ExtendedColours.paleYellow;
		ExtremelySimpleStatusEffectBulletBehaviour extremelySimpleStatusEffectBulletBehaviour = ((Component)val2).gameObject.AddComponent<ExtremelySimpleStatusEffectBulletBehaviour>();
		extremelySimpleStatusEffectBulletBehaviour.onHitProcChance = 0.14f;
		extremelySimpleStatusEffectBulletBehaviour.onFiredProcChance = 1f;
		extremelySimpleStatusEffectBulletBehaviour.usesFireEffect = false;
		extremelySimpleStatusEffectBulletBehaviour.usesPoisonEffect = true;
		extremelySimpleStatusEffectBulletBehaviour.poisonEffect = StaticStatusEffects.irradiatedLeadEffect;
		GunTools.SetProjectileSpriteRight(val2, "gluegunner_projectile", 19, 8, false, (Anchor)4, (int?)18, (int?)7, true, false, (int?)null, (int?)null, (Projectile)null);
		val.DefaultModule.projectiles[0] = val2;
		((PickupObject)val).quality = (ItemQuality)(-100);
		Databases.Items.Add(val, (tk2dSpriteCollectionData)null, "ANY");
		GunExt.SetName((PickupObject)(object)val, "Glue Gunner");
		GlueGunnerID = ((PickupObject)val).PickupObjectId;
	}
}
