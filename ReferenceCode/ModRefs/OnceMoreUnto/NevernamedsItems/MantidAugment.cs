using Alexandria.ItemAPI;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class MantidAugment : AdvancedGunBehavior
{
	public static int MantidAugmentID;

	public static void Add()
	{
		//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_013a: Unknown result type (might be due to invalid IL or missing references)
		//IL_015f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0220: Unknown result type (might be due to invalid IL or missing references)
		//IL_022a: Expected O, but got Unknown
		//IL_027f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0296: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Mantid Augment", "mantidaugment");
		Game.Items.Rename("outdated_gun_mods:mantid_augment", "nn:mantid_augment");
		MantidAugment mantidAugment = ((Component)val).gameObject.AddComponent<MantidAugment>();
		((AdvancedGunBehavior)mantidAugment).preventNormalFireAudio = true;
		GunExt.SetShortDescription((PickupObject)(object)val, "Flashy and Lethal");
		GunExt.SetLongDescription((PickupObject)(object)val, "A cybernetic augment concealed in the forearm, this cruel blade extends to slash at your enemies with inhuman speed.");
		val.SetGunSprites("mantidaugment");
		ItemBuilder.AddPassiveStatModifier((PickupObject)(object)val, (StatType)14, 1f, (ModifyMethod)0);
		ItemBuilder.AddCurrentGunStatModifier(val, (StatType)0, 1f, (ModifyMethod)0);
		GunExt.SetAnimationFPS(val, val.shootAnimation, 20);
		GunExt.SetAnimationFPS(val, val.reloadAnimation, 12);
		PickupObject byId = PickupObjectDatabase.GetById(86);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId is Gun) ? byId : null), true, false);
		val.gunHandedness = (GunHandedness)3;
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.shootStyle = (ShootStyle)1;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.DefaultModule.ammoType = (AmmoType)2;
		val.reloadTime = 1f;
		val.muzzleFlashEffects.type = (VFXPoolType)0;
		val.DefaultModule.cooldownTime = 0.01f;
		val.DefaultModule.numberOfShotsInClip = 100;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(1.56f, 0.56f, 0f);
		val.SetBaseMaxAmmo(2077);
		val.ammo = 2077;
		val.gunClass = (GunClass)10;
		Projectile val2 = Object.Instantiate<Projectile>(val.DefaultModule.projectiles[0]);
		((Component)val2).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val2).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val2);
		ProjectileData baseData = val2.baseData;
		baseData.damage *= 2f;
		ProjectileData baseData2 = val2.baseData;
		baseData2.force *= 0.5f;
		((BraveBehaviour)((BraveBehaviour)val2).sprite).renderer.enabled = false;
		NoCollideBehaviour noCollideBehaviour = ((Component)val2).gameObject.AddComponent<NoCollideBehaviour>();
		noCollideBehaviour.worksOnEnemies = true;
		noCollideBehaviour.worksOnProjectiles = true;
		((BraveBehaviour)val2).specRigidbody.CollideWithTileMap = false;
		ProjectileSlashingBehaviour val3 = ((Component)val2).gameObject.AddComponent<ProjectileSlashingBehaviour>();
		val3.DestroyBaseAfterFirstSlash = true;
		val3.SlashDamageUsesBaseProjectileDamage = true;
		val3.slashParameters = new SlashData();
		ref VFXPool hitVFX = ref val3.slashParameters.hitVFX;
		PickupObject byId2 = PickupObjectDatabase.GetById(369);
		hitVFX = ((Gun)((byId2 is Gun) ? byId2 : null)).DefaultModule.chargeProjectiles[0].Projectile.hitEffects.tileMapVertical;
		val.DefaultModule.projectiles[0] = val2;
		val.DefaultModule.ammoType = (AmmoType)14;
		val.DefaultModule.customAmmoType = "red_beam";
		((PickupObject)val).quality = (ItemQuality)4;
		Databases.Items.Add(val, (tk2dSpriteCollectionData)null, "ANY");
		MantidAugmentID = ((PickupObject)val).PickupObjectId;
	}

	public override void PostProcessProjectile(Projectile projectile)
	{
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		if (Object.op_Implicit((Object)(object)projectile) && Object.op_Implicit((Object)(object)projectile.Owner) && projectile.Owner is PlayerController)
		{
			GameActor owner = projectile.Owner;
			PlayerController val = (PlayerController)(object)((owner is PlayerController) ? owner : null);
			ProjectileSlashingBehaviour component = ((Component)projectile).gameObject.GetComponent<ProjectileSlashingBehaviour>();
			if (Object.op_Implicit((Object)(object)component) && CustomSynergies.PlayerHasActiveSynergy(val, "Bloodthirsty Blades") && Random.value <= 0.07f)
			{
				component.slashParameters.projInteractMode = (ProjInteractMode)1;
			}
		}
		((AdvancedGunBehavior)this).PostProcessProjectile(projectile);
	}
}
