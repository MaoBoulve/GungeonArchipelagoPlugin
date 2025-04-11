using Alexandria.ItemAPI;
using Alexandria.Misc;
using Gungeon;
using SaveAPI;
using UnityEngine;

namespace NevernamedsItems;

public class Spitballer : AdvancedGunBehavior
{
	public static int ID;

	public static Projectile plagueball;

	public static void Add()
	{
		//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_012b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0133: Unknown result type (might be due to invalid IL or missing references)
		//IL_0147: Unknown result type (might be due to invalid IL or missing references)
		//IL_014c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0182: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_0371: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Spitballer", "spitballer");
		Game.Items.Rename("outdated_gun_mods:spitballer", "nn:spitballer");
		Spitballer spitballer = ((Component)val).gameObject.AddComponent<Spitballer>();
		((AdvancedGunBehavior)spitballer).preventNormalFireAudio = true;
		((AdvancedGunBehavior)spitballer).preventNormalReloadAudio = true;
		GunExt.SetShortDescription((PickupObject)(object)val, "Spoot");
		GunExt.SetLongDescription((PickupObject)(object)val, "A rolled piece of paper designed by cruel schoolchildren to launch balls of spit and more paper at their classmates.");
		val.SetGunSprites("spitballer");
		GunExt.SetAnimationFPS(val, val.shootAnimation, 10);
		GunExt.SetAnimationFPS(val, val.reloadAnimation, 0);
		((Component)val).GetComponent<tk2dSpriteAnimator>().GetClipByName(val.shootAnimation).frames[0].eventAudio = "spit_fire";
		((Component)val).GetComponent<tk2dSpriteAnimator>().GetClipByName(val.shootAnimation).frames[0].triggerEvent = true;
		PickupObject byId = PickupObjectDatabase.GetById(86);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId is Gun) ? byId : null), true, false);
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.shootStyle = (ShootStyle)0;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 0.5f;
		val.DefaultModule.cooldownTime = 0.3f;
		val.DefaultModule.numberOfShotsInClip = 3;
		((PickupObject)val).quality = (ItemQuality)1;
		val.gunClass = (GunClass)55;
		val.SetBaseMaxAmmo(1000);
		val.carryPixelOffset = new IntVector2(1, 3);
		ref VFXPool muzzleFlashEffects = ref val.muzzleFlashEffects;
		PickupObject byId2 = PickupObjectDatabase.GetById(33);
		muzzleFlashEffects = ((Gun)((byId2 is Gun) ? byId2 : null)).muzzleFlashEffects;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(0.75f, 0.1875f, 0f);
		Projectile val2 = ProjectileUtility.SetupProjectile(86);
		val.DefaultModule.projectiles[0] = val2;
		((Object)((Component)val2).gameObject).name = "spitball";
		val2.baseData.damage = 5.1f;
		ProjectileData baseData = val2.baseData;
		baseData.speed *= 0.8f;
		val2.hitEffects.overrideMidairDeathVFX = VFXToolbox.CreateVFXBundle("SpitballerImpact", new IntVector2(10, 8), (Anchor)4, usesZHeight: true, 0.2f, -1f, null);
		val2.hitEffects.alwaysUseMidair = true;
		val2.SetProjectileSprite("spitballer_proj", 4, 4, lightened: false, (Anchor)4, 4, 4, anchorChangesCollider: true, fixesScale: false, null, null);
		GoopModifier val3 = ((Component)val2).gameObject.AddComponent<GoopModifier>();
		val3.SpawnGoopOnCollision = true;
		val3.CollisionSpawnRadius = 0.5f;
		val3.goopDefinition = EasyGoopDefinitions.WaterGoop;
		plagueball = ProjectileUtility.SetupProjectile(86);
		plagueball.baseData.damage = 6.1f;
		ProjectileData baseData2 = plagueball.baseData;
		baseData2.speed *= 0.8f;
		plagueball.hitEffects.overrideMidairDeathVFX = VFXToolbox.CreateVFXBundle("PlagueSplash_Small", new IntVector2(10, 8), (Anchor)4, usesZHeight: true, 0.2f, -1f, null);
		plagueball.hitEffects.alwaysUseMidair = true;
		plagueball.SetProjectileSprite("plagueball_proj", 4, 4, lightened: false, (Anchor)4, 4, 4, anchorChangesCollider: true, fixesScale: false, null, null);
		GoopModifier val4 = ((Component)plagueball).gameObject.AddComponent<GoopModifier>();
		val4.SpawnGoopOnCollision = true;
		val4.CollisionSpawnRadius = 0.5f;
		val4.goopDefinition = EasyGoopDefinitions.PlagueGoop;
		val.DefaultModule.ammoType = (AmmoType)14;
		val.DefaultModule.customAmmoType = "white";
		Databases.Items.Add((PickupObject)(object)val, false, "ANY");
		ID = ((PickupObject)val).PickupObjectId;
		((PickupObject)(object)val).SetupUnlockOnCustomStat(CustomTrackedStats.BEGGAR_TOTAL_DONATIONS, 4f, (PrerequisiteOperation)2);
	}

	public override Projectile OnPreFireProjectileModifier(Gun gun, Projectile projectile, ProjectileModule mod)
	{
		if (Object.op_Implicit((Object)(object)projectile) && ((Object)projectile).name.Contains("spitball") && Object.op_Implicit((Object)(object)gun) && Object.op_Implicit((Object)(object)GunTools.GunPlayerOwner(gun)) && CustomSynergies.PlayerHasActiveSynergy(GunTools.GunPlayerOwner(gun), "Superspreader"))
		{
			return plagueball;
		}
		return ((AdvancedGunBehavior)this).OnPreFireProjectileModifier(gun, projectile, mod);
	}

	public override void PostProcessProjectile(Projectile projectile)
	{
		if (Object.op_Implicit((Object)(object)projectile) && ((Object)projectile).name.Contains("spitfire_proj") && Object.op_Implicit((Object)(object)base.gun) && Object.op_Implicit((Object)(object)GunTools.GunPlayerOwner(base.gun)) && CustomSynergies.PlayerHasActiveSynergy(GunTools.GunPlayerOwner(base.gun), "Superspreader"))
		{
			BulletSharkProjectileDoer component = ((Component)projectile).GetComponent<BulletSharkProjectileDoer>();
			if (Object.op_Implicit((Object)(object)component))
			{
				component.toSpawn = plagueball;
			}
		}
		((AdvancedGunBehavior)this).PostProcessProjectile(projectile);
	}
}
