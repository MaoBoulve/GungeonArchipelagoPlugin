using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class Betsy : GunBehaviour
{
	public static void Add()
	{
		//IL_008e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00de: Unknown result type (might be due to invalid IL or missing references)
		//IL_0125: Unknown result type (might be due to invalid IL or missing references)
		//IL_0148: Unknown result type (might be due to invalid IL or missing references)
		//IL_014d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0155: Unknown result type (might be due to invalid IL or missing references)
		//IL_015a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0162: Unknown result type (might be due to invalid IL or missing references)
		//IL_0167: Unknown result type (might be due to invalid IL or missing references)
		//IL_0282: Unknown result type (might be due to invalid IL or missing references)
		//IL_0289: Expected O, but got Unknown
		//IL_029d: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a4: Expected O, but got Unknown
		//IL_02a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_02bd: Expected O, but got Unknown
		//IL_02c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_02cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_02df: Expected O, but got Unknown
		//IL_02e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f9: Expected O, but got Unknown
		//IL_0353: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Betsy", "betsy");
		Game.Items.Rename("outdated_gun_mods:betsy", "nn:betsy");
		((Component)val).gameObject.AddComponent<Betsy>();
		GunExt.SetShortDescription((PickupObject)(object)val, "Heavens");
		GunExt.SetLongDescription((PickupObject)(object)val, "A gorgeous exemplar of guncraft, this undeniable Edwin original is the only one of its kind in the whole galaxy.");
		val.SetGunSprites("betsy", 8, noAmmonomicon: false, 2);
		GunExt.SetAnimationFPS(val, val.shootAnimation, 15);
		GunExt.SetAnimationFPS(val, val.reloadAnimation, 15);
		((Component)val).GetComponent<tk2dSpriteAnimator>().GetClipByName(val.reloadAnimation).wrapMode = (WrapMode)0;
		PickupObject byId = PickupObjectDatabase.GetById(56);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId is Gun) ? byId : null), true, false);
		ref string gunSwitchGroup = ref val.gunSwitchGroup;
		PickupObject byId2 = PickupObjectDatabase.GetById(53);
		gunSwitchGroup = ((Gun)((byId2 is Gun) ? byId2 : null)).gunSwitchGroup;
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.shootStyle = (ShootStyle)0;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 1f;
		val.DefaultModule.cooldownTime = 0.1f;
		val.DefaultModule.numberOfShotsInClip = 15;
		val.SetBarrel(30, 12);
		val.SetBaseMaxAmmo(200);
		val.gunClass = (GunClass)45;
		ref VFXPool muzzleFlashEffects = ref val.muzzleFlashEffects;
		PickupObject byId3 = PickupObjectDatabase.GetById(477);
		muzzleFlashEffects = ((Gun)((byId3 is Gun) ? byId3 : null)).muzzleFlashEffects;
		val.carryPixelOffset = new IntVector2(5, -5);
		val.carryPixelDownOffset = new IntVector2(3, 2);
		val.carryPixelUpOffset = new IntVector2(5, 4);
		Projectile val2 = ProjectileSetupUtility.MakeProjectile(56, 10f);
		ProjectileData baseData = val2.baseData;
		baseData.speed *= 1.6f;
		val2.baseData.UsesCustomAccelerationCurve = true;
		val2.baseData.AccelerationCurve = AnimationCurve.Linear(0f, 0f, 1f, 1f);
		ExplosiveModifier val3 = ((Component)val2).gameObject.AddComponent<ExplosiveModifier>();
		val3.doExplosion = true;
		val3.explosionData = StaticExplosionDatas.explosiveRoundsExplosion.CopyExplosionData();
		val3.explosionData.damage = 10f;
		val3.explosionData.damageRadius = 1.5f;
		val3.explosionData.pushRadius = 1.5f;
		val2.SetProjectileSprite("betsy_proj", 9, 5, lightened: false, (Anchor)3, null, null, anchorChangesCollider: true, fixesScale: false, null, null);
		CustomVFXTrail customVFXTrail = ((Component)val2).gameObject.AddComponent<CustomVFXTrail>();
		customVFXTrail.timeBetweenSpawns = 0.02f;
		customVFXTrail.anchor = CustomVFXTrail.Anchor.ChildTransform;
		GameObject val4 = new GameObject("CustomVFXSpawnpoint");
		val4.transform.SetParent(((BraveBehaviour)val2).transform);
		VFXPool val5 = new VFXPool();
		val5.type = (VFXPoolType)1;
		VFXComplex[] array = new VFXComplex[1];
		VFXComplex val6 = new VFXComplex();
		val6.effects = (VFXObject[])(object)new VFXObject[2]
		{
			new VFXObject
			{
				effect = SharedVFX.BulletSmokeTrail,
				attached = false
			},
			new VFXObject
			{
				effect = SharedVFX.BulletSparkTrail,
				attached = true
			}
		};
		array[0] = val6;
		val5.effects = (VFXComplex[])(object)array;
		customVFXTrail.VFX = val5;
		val.DefaultModule.projectiles[0] = val2;
		val.AddShellCasing(1, 0, 0, 0, "shell_betsy");
		val.AddClipDebris(0, 1, "clipdebris_betsy");
		val.AddClipSprites("betsy");
		((PickupObject)val).quality = (ItemQuality)4;
		Databases.Items.Add(val, (tk2dSpriteCollectionData)null, "ANY");
	}
}
