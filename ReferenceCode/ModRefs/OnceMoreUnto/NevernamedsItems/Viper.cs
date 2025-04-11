using Alexandria.Assetbundle;
using Alexandria.ItemAPI;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class Viper : AdvancedGunBehavior
{
	public static void Add()
	{
		//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0142: Unknown result type (might be due to invalid IL or missing references)
		//IL_0166: Unknown result type (might be due to invalid IL or missing references)
		//IL_0327: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Viper", "viper");
		Game.Items.Rename("outdated_gun_mods:viper", "nn:viper");
		Viper viper = ((Component)val).gameObject.AddComponent<Viper>();
		((AdvancedGunBehavior)viper).overrideNormalFireAudio = "Play_ENM_snake_shot_01";
		((AdvancedGunBehavior)viper).preventNormalFireAudio = true;
		GunExt.SetShortDescription((PickupObject)(object)val, "Death Throws");
		GunExt.SetLongDescription((PickupObject)(object)val, "A futuristic plasma blaster modeled after a historic flintlock.\n\nIt's initial bite has a deadly followup.");
		GunInt.SetupSprite(val, Initialisation.gunCollection, "viper_idle_001", 8, "viper_ammonomicon_001");
		GunExt.SetAnimationFPS(val, val.shootAnimation, 10);
		ref string gunSwitchGroup = ref val.gunSwitchGroup;
		PickupObject byId = PickupObjectDatabase.GetById(32);
		gunSwitchGroup = ((Gun)((byId is Gun) ? byId : null)).gunSwitchGroup;
		PickupObject byId2 = PickupObjectDatabase.GetById(56);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId2 is Gun) ? byId2 : null), true, false);
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.shootStyle = (ShootStyle)0;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 1f;
		val.DefaultModule.cooldownTime = 0.3f;
		val.DefaultModule.angleVariance = 5f;
		val.DefaultModule.numberOfShotsInClip = 4;
		ref VFXPool muzzleFlashEffects = ref val.muzzleFlashEffects;
		PickupObject byId3 = PickupObjectDatabase.GetById(334);
		muzzleFlashEffects = ((Gun)((byId3 is Gun) ? byId3 : null)).muzzleFlashEffects;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(1.81f, 0.43f, 0f);
		val.SetBaseMaxAmmo(200);
		val.ammo = 200;
		val.gunClass = (GunClass)1;
		PickupObject byId4 = PickupObjectDatabase.GetById(86);
		Projectile val2 = Object.Instantiate<Projectile>(((Gun)((byId4 is Gun) ? byId4 : null)).DefaultModule.projectiles[0]);
		((Component)val2).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val2).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val2);
		ProjectileData baseData = val2.baseData;
		baseData.damage *= 1.2f;
		ProjectileData baseData2 = val2.baseData;
		baseData2.force *= 2f;
		val2.SetProjectileSprite("vipersecondary_projectile", 6, 6, lightened: true, (Anchor)4, 4, 4, anchorChangesCollider: true, fixesScale: false, null, null);
		Projectile val3 = Object.Instantiate<Projectile>(val.DefaultModule.projectiles[0]);
		((Component)val3).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val3).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val3);
		ProjectileData baseData3 = val3.baseData;
		baseData3.damage *= 2f;
		ProjectileData baseData4 = val3.baseData;
		baseData4.force *= 1f;
		ProjectileData baseData5 = val3.baseData;
		baseData5.speed *= 2f;
		ProjectileData baseData6 = val3.baseData;
		baseData6.range *= 2f;
		ViperProjModifier orAddComponent = GameObjectExtensions.GetOrAddComponent<ViperProjModifier>(((Component)val3).gameObject);
		orAddComponent.projToSpawn = val2;
		PierceProjModifier orAddComponent2 = GameObjectExtensions.GetOrAddComponent<PierceProjModifier>(((Component)val3).gameObject);
		orAddComponent2.penetration++;
		orAddComponent2.penetratesBreakables = true;
		val3.SetProjectileSprite("vipermain_projectile", 15, 10, lightened: true, (Anchor)4, 11, 6, anchorChangesCollider: true, fixesScale: false, null, null);
		val.DefaultModule.projectiles[0] = val3;
		((PickupObject)val).quality = (ItemQuality)3;
		Databases.Items.Add((PickupObject)(object)val, false, "ANY");
	}

	public override void PostProcessProjectile(Projectile projectile)
	{
		if (Object.op_Implicit((Object)(object)projectile.Owner) && projectile.Owner is PlayerController && CustomSynergies.PlayerHasActiveSynergy((PlayerController)/*isinst with value type is only supported in some contexts*/, "Lightning Fast Strike"))
		{
			ViperProjModifier component = ((Component)projectile).GetComponent<ViperProjModifier>();
			if ((Object)(object)component != (Object)null)
			{
				component.DistanceBetweenPositions = 1;
			}
		}
		((AdvancedGunBehavior)this).PostProcessProjectile(projectile);
	}
}
