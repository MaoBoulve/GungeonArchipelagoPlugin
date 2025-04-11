using Alexandria.Assetbundle;
using Alexandria.ItemAPI;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class ElysiumCannon : AdvancedGunBehavior
{
	public static int ID;

	public static void Add()
	{
		//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0105: Unknown result type (might be due to invalid IL or missing references)
		//IL_010d: Unknown result type (might be due to invalid IL or missing references)
		//IL_02bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_02fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0334: Unknown result type (might be due to invalid IL or missing references)
		//IL_034d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0354: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Elysium Cannon", "elysiumcannon");
		Game.Items.Rename("outdated_gun_mods:elysium_cannon", "nn:elysium_cannon");
		ElysiumCannon elysiumCannon = ((Component)val).gameObject.AddComponent<ElysiumCannon>();
		((AdvancedGunBehavior)elysiumCannon).overrideNormalFireAudio = "Play_ElectricSound";
		((AdvancedGunBehavior)elysiumCannon).preventNormalFireAudio = true;
		GunExt.SetShortDescription((PickupObject)(object)val, "The Sky Will Crack");
		GunExt.SetLongDescription((PickupObject)(object)val, "Cracks reality and unleashes a torrent of holey light.\n\nInitially created by the Order of the True Gun for righteous inquisitions, this unimaginable flood of radiant power has been the subject of countless wars.");
		GunInt.SetupSprite(val, Initialisation.gunCollection, "elysiumcannon_idle_001", 8, "elysiumcannon_ammonomicon_001");
		GunExt.SetAnimationFPS(val, val.shootAnimation, 16);
		GunExt.SetAnimationFPS(val, val.idleAnimation, 16);
		GunExt.SetAnimationFPS(val, val.reloadAnimation, 16);
		for (int i = 0; i < 2; i++)
		{
			PickupObject byId = PickupObjectDatabase.GetById(86);
			GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId is Gun) ? byId : null), true, false);
		}
		val.muzzleFlashEffects.type = (VFXPoolType)0;
		foreach (ProjectileModule projectile in val.Volley.projectiles)
		{
			projectile.ammoCost = 1;
			projectile.shootStyle = (ShootStyle)1;
			projectile.sequenceStyle = (ProjectileSequenceStyle)0;
			projectile.cooldownTime = 0.01f;
			projectile.angleVariance = 20f;
			projectile.numberOfShotsInClip = 70;
			Projectile val2 = Object.Instantiate<Projectile>(projectile.projectiles[0]);
			projectile.projectiles[0] = val2;
			((Component)val2).gameObject.SetActive(false);
			FakePrefab.MarkAsFakePrefab(((Component)val2).gameObject);
			Object.DontDestroyOnLoad((Object)(object)val2);
			ProjectileData baseData = val2.baseData;
			baseData.range *= 1.5f;
			val2.baseData.damage = 3f;
			ProjectileData baseData2 = val2.baseData;
			baseData2.force *= 0.5f;
			ProjectileData baseData3 = val2.baseData;
			baseData3.speed *= 0.85f;
			val2.PenetratesInternalWalls = true;
			val2.hitEffects.overrideMidairDeathVFX = SharedVFX.BigWhitePoofVFX;
			val2.hitEffects.alwaysUseMidair = true;
			PierceProjModifier orAddComponent = GameObjectExtensions.GetOrAddComponent<PierceProjModifier>(((Component)val2).gameObject);
			orAddComponent.penetration = 100;
			orAddComponent.penetratesBreakables = true;
			val2.pierceMinorBreakables = true;
			val2.SetProjectileSprite("elysiumcannon_proj", 56, 56, lightened: true, (Anchor)4, 50, 50, anchorChangesCollider: true, fixesScale: false, null, null);
			BounceProjModifier orAddComponent2 = GameObjectExtensions.GetOrAddComponent<BounceProjModifier>(((Component)val2).gameObject);
			orAddComponent2.numberOfBounces = 1;
			if (projectile != val.DefaultModule)
			{
				projectile.ammoCost = 0;
			}
			((BraveBehaviour)val2).transform.parent = val.barrelOffset;
		}
		val.gunHandedness = (GunHandedness)3;
		((Component)val).GetComponent<tk2dSpriteAnimator>().GetClipByName(val.shootAnimation).wrapMode = (WrapMode)0;
		((Component)val).GetComponent<tk2dSpriteAnimator>().GetClipByName(val.reloadAnimation).wrapMode = (WrapMode)0;
		val.DefaultModule.ammoType = (AmmoType)14;
		val.DefaultModule.customAmmoType = "white";
		val.reloadTime = 2f;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(1.25f, 0.81f, 0f);
		val.SetBaseMaxAmmo(777);
		val.gunClass = (GunClass)5;
		((PickupObject)val).quality = (ItemQuality)4;
		Databases.Items.Add(val, (tk2dSpriteCollectionData)null, "ANY");
		val.Volley.UsesShotgunStyleVelocityRandomizer = true;
		ID = ((PickupObject)val).PickupObjectId;
	}
}
