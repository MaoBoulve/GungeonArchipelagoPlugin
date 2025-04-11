using Alexandria.Assetbundle;
using Alexandria.ItemAPI;
using Alexandria.Misc;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class StarterPistol : AdvancedGunBehavior
{
	public static int StarterPistolID;

	public static void Add()
	{
		//IL_00b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_012d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0159: Unknown result type (might be due to invalid IL or missing references)
		//IL_025f: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Starter Pistol", "starterpistol");
		Game.Items.Rename("outdated_gun_mods:starter_pistol", "nn:starter_pistol");
		((Component)val).gameObject.AddComponent<StarterPistol>();
		GunExt.SetShortDescription((PickupObject)(object)val, "Ready... Set...");
		GunExt.SetLongDescription((PickupObject)(object)val, "Designed to signal the start of races, this flimsy plastic gun is cheap to fire and at least delivers a sonic payload.");
		GunInt.SetupSprite(val, Initialisation.gunCollection, "starterpistol_idle_001", 8, "starterpistol_ammonomicon_001");
		GunExt.SetAnimationFPS(val, val.shootAnimation, 16);
		ref string gunSwitchGroup = ref val.gunSwitchGroup;
		PickupObject byId = PickupObjectDatabase.GetById(51);
		gunSwitchGroup = ((Gun)((byId is Gun) ? byId : null)).gunSwitchGroup;
		PickupObject byId2 = PickupObjectDatabase.GetById(56);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId2 is Gun) ? byId2 : null), true, false);
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.shootStyle = (ShootStyle)0;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 0.4f;
		val.DefaultModule.cooldownTime = 0.1f;
		val.DefaultModule.angleVariance = 5f;
		val.DefaultModule.numberOfShotsInClip = 1;
		ref VFXPool muzzleFlashEffects = ref val.muzzleFlashEffects;
		PickupObject byId3 = PickupObjectDatabase.GetById(37);
		muzzleFlashEffects = ((Gun)((byId3 is Gun) ? byId3 : null)).muzzleFlashEffects;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(1.12f, 0.68f, 0f);
		val.SetBaseMaxAmmo(200);
		val.InfiniteAmmo = true;
		val.ammo = 200;
		val.gunClass = (GunClass)1;
		Projectile val2 = Object.Instantiate<Projectile>(val.DefaultModule.projectiles[0]);
		((Component)val2).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val2).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val2);
		val2.SetProjectileSprite("starterpistol_proj", 6, 17, lightened: true, (Anchor)4, 2, 13, anchorChangesCollider: true, fixesScale: false, null, null);
		val2.hitEffects.alwaysUseMidair = true;
		val2.hitEffects.overrideMidairDeathVFX = SharedVFX.YellowLaserCircleVFX;
		val2.baseData.damage = 5f;
		val2.baseData.force = 100f;
		val2.baseData.range = 100f;
		val2.baseData.speed = 40f;
		BounceProjModifier orAddComponent = GameObjectExtensions.GetOrAddComponent<BounceProjModifier>(((Component)val2).gameObject);
		orAddComponent.damageMultiplierOnBounce = 2f;
		orAddComponent.numberOfBounces++;
		val.DefaultModule.projectiles[0] = val2;
		((PickupObject)val).quality = (ItemQuality)1;
		Databases.Items.Add((PickupObject)(object)val, false, "ANY");
		StarterPistolID = ((PickupObject)val).PickupObjectId;
	}

	public override void PostProcessProjectile(Projectile projectile)
	{
		if (Object.op_Implicit((Object)(object)ProjectileUtility.ProjectilePlayerOwner(projectile)) && CustomSynergies.PlayerHasActiveSynergy(ProjectileUtility.ProjectilePlayerOwner(projectile), "Mixed Signals"))
		{
			projectile.statusEffectsToApply.Add((GameActorEffect)(object)StaticStatusEffects.hotLeadEffect);
		}
		((AdvancedGunBehavior)this).PostProcessProjectile(projectile);
	}
}
