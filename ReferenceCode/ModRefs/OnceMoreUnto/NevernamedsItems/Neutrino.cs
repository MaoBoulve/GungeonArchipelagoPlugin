using Alexandria.Assetbundle;
using Alexandria.ItemAPI;
using Alexandria.Misc;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class Neutrino : AdvancedGunBehavior
{
	public static Projectile burnModeProj;

	private bool isInBurnMode = false;

	public static void Add()
	{
		//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0129: Unknown result type (might be due to invalid IL or missing references)
		//IL_0148: Unknown result type (might be due to invalid IL or missing references)
		//IL_02fc: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Neutrino", "neutrino");
		Game.Items.Rename("outdated_gun_mods:neutrino", "nn:neutrino");
		((Component)val).gameObject.AddComponent<Neutrino>();
		GunExt.SetShortDescription((PickupObject)(object)val, "D'arvit");
		GunExt.SetLongDescription((PickupObject)(object)val, "Made for tiny hands. A micro-nuclear battery will keep this blaster burning longer than the lifetime of Gunymede's star!\n\nReload a full clip to swap between 'stun' and 'fry' modes.");
		GunInt.SetupSprite(val, Initialisation.gunCollection, "neutrino_idle_001", 8, "neutrino_ammonomicon_001");
		GunExt.SetAnimationFPS(val, val.shootAnimation, 10);
		ref string gunSwitchGroup = ref val.gunSwitchGroup;
		PickupObject byId = PickupObjectDatabase.GetById(32);
		gunSwitchGroup = ((Gun)((byId is Gun) ? byId : null)).gunSwitchGroup;
		PickupObject byId2 = PickupObjectDatabase.GetById(56);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId2 is Gun) ? byId2 : null), true, false);
		val.InfiniteAmmo = true;
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.shootStyle = (ShootStyle)1;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)1;
		ref VFXPool muzzleFlashEffects = ref val.muzzleFlashEffects;
		PickupObject byId3 = PickupObjectDatabase.GetById(809);
		muzzleFlashEffects = ((Gun)((byId3 is Gun) ? byId3 : null)).muzzleFlashEffects;
		val.reloadTime = 1f;
		val.DefaultModule.cooldownTime = 0.15f;
		val.DefaultModule.numberOfShotsInClip = 12;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(0.87f, 0.31f, 0f);
		val.SetBaseMaxAmmo(100);
		val.ammo = 100;
		val.gunClass = (GunClass)10;
		Projectile val2 = Object.Instantiate<Projectile>(val.DefaultModule.projectiles[0]);
		((Component)val2).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val2).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val2);
		val2.baseData.damage = 2.5f;
		ProjectileData baseData = val2.baseData;
		baseData.speed *= 1.5f;
		val2.AppliesStun = true;
		val2.AppliedStunDuration = 4f;
		val2.StunApplyChance = 0.2f;
		val2.hitEffects.overrideMidairDeathVFX = SharedVFX.SmoothLightBlueLaserCircleVFX;
		val2.hitEffects.alwaysUseMidair = true;
		val2.SetProjectileSprite("neutrino_stun_proj", 10, 3, lightened: true, (Anchor)4, 8, 3, anchorChangesCollider: true, fixesScale: false, null, null);
		Projectile val3 = Object.Instantiate<Projectile>(val.DefaultModule.projectiles[0]);
		((Component)val3).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val3).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val3);
		val3.baseData.damage = 2.5f;
		ProjectileData baseData2 = val3.baseData;
		baseData2.speed *= 1.5f;
		val3.AppliesFire = true;
		val3.fireEffect = StaticStatusEffects.hotLeadEffect;
		val3.FireApplyChance = 0.07f;
		val3.hitEffects.overrideMidairDeathVFX = SharedVFX.YellowLaserCircleVFX;
		val3.hitEffects.alwaysUseMidair = true;
		val3.SetProjectileSprite("neutrino_burn_proj", 10, 3, lightened: true, (Anchor)4, 8, 3, anchorChangesCollider: true, fixesScale: false, null, null);
		burnModeProj = val3;
		val.DefaultModule.projectiles[0] = val2;
		((PickupObject)val).quality = (ItemQuality)3;
		Databases.Items.Add(val, (tk2dSpriteCollectionData)null, "ANY");
	}

	public override Projectile OnPreFireProjectileModifier(Gun gun, Projectile projectile, ProjectileModule mod)
	{
		if (isInBurnMode)
		{
			return burnModeProj;
		}
		return ((AdvancedGunBehavior)this).OnPreFireProjectileModifier(gun, projectile, mod);
	}

	public override void OnReloadPressed(PlayerController player, Gun gun, bool manualReload)
	{
		if (gun.ClipShotsRemaining == gun.ClipCapacity)
		{
			if (isInBurnMode)
			{
				isInBurnMode = false;
			}
			else
			{
				isInBurnMode = true;
			}
		}
		((AdvancedGunBehavior)this).OnReloadPressed(player, gun, manualReload);
	}

	public override void PostProcessProjectile(Projectile projectile)
	{
		if (Object.op_Implicit((Object)(object)projectile) && Object.op_Implicit((Object)(object)ProjectileUtility.ProjectilePlayerOwner(projectile)) && CustomSynergies.PlayerHasActiveSynergy(ProjectileUtility.ProjectilePlayerOwner(projectile), "Softnose"))
		{
			ProjectileData baseData = projectile.baseData;
			baseData.damage *= 2f;
			ProjectileData baseData2 = projectile.baseData;
			baseData2.speed *= 0.5f;
		}
		((AdvancedGunBehavior)this).PostProcessProjectile(projectile);
	}
}
