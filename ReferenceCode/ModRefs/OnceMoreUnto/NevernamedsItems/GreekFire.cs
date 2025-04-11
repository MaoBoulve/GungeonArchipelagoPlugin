using System.Collections.Generic;
using Alexandria.Assetbundle;
using Alexandria.ItemAPI;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class GreekFire : AdvancedGunBehavior
{
	public static int GreekFireID;

	public static void Add()
	{
		//IL_00e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0351: Unknown result type (might be due to invalid IL or missing references)
		//IL_0276: Unknown result type (might be due to invalid IL or missing references)
		//IL_027b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0283: Unknown result type (might be due to invalid IL or missing references)
		//IL_0290: Expected O, but got Unknown
		Gun val = Databases.Items.NewGun("Greek Fire", "greekfire");
		Game.Items.Rename("outdated_gun_mods:greek_fire", "nn:greek_fire");
		ref string gunSwitchGroup = ref val.gunSwitchGroup;
		PickupObject byId = PickupObjectDatabase.GetById(37);
		gunSwitchGroup = ((Gun)((byId is Gun) ? byId : null)).gunSwitchGroup;
		GunExt.SetShortDescription((PickupObject)(object)val, "Fire of Man");
		GunExt.SetLongDescription((PickupObject)(object)val, "Used by ancient civilisations as a primitive flamethrower.\n\nThe potent chemical mixture used to create the flames makes it remarkably dangerous.");
		GunInt.SetupSprite(val, Initialisation.gunCollection, "greekfire_idle_001", 8, "greekfire_ammonomicon_001");
		GunExt.SetAnimationFPS(val, val.shootAnimation, 16);
		GunExt.SetAnimationFPS(val, val.chargeAnimation, 3);
		for (int i = 0; i < 4; i++)
		{
			PickupObject byId2 = PickupObjectDatabase.GetById(698);
			GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId2 is Gun) ? byId2 : null), true, false);
		}
		foreach (ProjectileModule projectile in val.Volley.projectiles)
		{
			projectile.ammoCost = 1;
			projectile.shootStyle = (ShootStyle)3;
			projectile.sequenceStyle = (ProjectileSequenceStyle)0;
			projectile.cooldownTime = 1f;
			projectile.angleVariance = 20f;
			projectile.numberOfShotsInClip = 1;
			Projectile val2 = Object.Instantiate<Projectile>(projectile.projectiles[0]);
			projectile.projectiles[0] = val2;
			((Component)val2).gameObject.SetActive(false);
			FakePrefab.MarkAsFakePrefab(((Component)val2).gameObject);
			Object.DontDestroyOnLoad((Object)(object)val2);
			ProjectileData baseData = val2.baseData;
			baseData.damage *= 5f;
			val2.AdditionalScaleMultiplier *= 2f;
			ProjectileData baseData2 = val2.baseData;
			baseData2.range *= 0.5f;
			if (projectile != val.DefaultModule)
			{
				projectile.ammoCost = 0;
			}
			val2.AppliesFire = true;
			val2.FireApplyChance = 1f;
			val2.fireEffect = StaticStatusEffects.greenFireEffect;
			if (Object.op_Implicit((Object)(object)((Component)val2).gameObject.GetComponent<GoopModifier>()))
			{
				Object.Destroy((Object)(object)((Component)val2).gameObject.GetComponent<GoopModifier>());
			}
			GoopModifier val3 = ((Component)val2).gameObject.AddComponent<GoopModifier>();
			val3.SpawnGoopOnCollision = true;
			val3.InFlightSpawnFrequency = 0.05f;
			val3.InFlightSpawnRadius = 0.5f;
			val3.SpawnGoopInFlight = true;
			val3.CollisionSpawnRadius = 3f;
			val3.goopDefinition = EasyGoopDefinitions.GreenFireDef;
			PierceProjModifier orAddComponent = GameObjectExtensions.GetOrAddComponent<PierceProjModifier>(((Component)val2).gameObject);
			orAddComponent.penetratesBreakables = true;
			orAddComponent.penetration++;
			ChargeProjectile item = new ChargeProjectile
			{
				Projectile = val2,
				ChargeTime = 1f
			};
			projectile.chargeProjectiles = new List<ChargeProjectile> { item };
		}
		val.reloadTime = 1f;
		val.SetBaseMaxAmmo(65);
		((PickupObject)val).quality = (ItemQuality)3;
		val.gunClass = (GunClass)30;
		((Component)val).GetComponent<tk2dSpriteAnimator>().GetClipByName(val.chargeAnimation).wrapMode = (WrapMode)1;
		((Component)val).GetComponent<tk2dSpriteAnimator>().GetClipByName(val.chargeAnimation).loopStart = 1;
		((BraveBehaviour)val).encounterTrackable.EncounterGuid = "this is Greek Fire";
		Databases.Items.Add(val, (tk2dSpriteCollectionData)null, "ANY");
		((Component)val.barrelOffset).transform.localPosition = new Vector3(1.37f, 0.37f, 0f);
		GreekFireID = ((PickupObject)val).PickupObjectId;
	}

	public override void PostProcessProjectile(Projectile projectile)
	{
		((AdvancedGunBehavior)this).PostProcessProjectile(projectile);
	}
}
