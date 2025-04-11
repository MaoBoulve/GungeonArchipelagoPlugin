using System.Collections.Generic;
using Alexandria.ItemAPI;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class GunjurersStaff : AdvancedGunBehavior
{
	public static int GunjurersStaffID;

	public static void Add()
	{
		//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0181: Unknown result type (might be due to invalid IL or missing references)
		//IL_018d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0199: Unknown result type (might be due to invalid IL or missing references)
		//IL_01df: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_02dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e9: Expected O, but got Unknown
		//IL_0304: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Gunjurer's Staff", "gunjurerswand");
		Game.Items.Rename("outdated_gun_mods:gunjurer's_staff", "nn:gunjurers_staff");
		GunjurersStaff gunjurersStaff = ((Component)val).gameObject.AddComponent<GunjurersStaff>();
		((AdvancedGunBehavior)gunjurersStaff).preventNormalFireAudio = true;
		((AdvancedGunBehavior)gunjurersStaff).preventNormalReloadAudio = true;
		((AdvancedGunBehavior)gunjurersStaff).overrideNormalReloadAudio = "Play_ENM_wizardred_chant_01";
		GunExt.SetShortDescription((PickupObject)(object)val, "Do you believe in magic?");
		GunExt.SetLongDescription((PickupObject)(object)val, "The lost wand of an Apprentice Gunjurer, cruelly slain by a Gungeoneer while out of his mentor's sight for but a moment...");
		val.SetGunSprites("gunjurerswand");
		GunExt.SetAnimationFPS(val, val.shootAnimation, 10);
		GunExt.SetAnimationFPS(val, val.chargeAnimation, 4);
		ref string gunSwitchGroup = ref val.gunSwitchGroup;
		PickupObject byId = PickupObjectDatabase.GetById(35);
		gunSwitchGroup = ((Gun)((byId is Gun) ? byId : null)).gunSwitchGroup;
		PickupObject byId2 = PickupObjectDatabase.GetById(86);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId2 is Gun) ? byId2 : null), true, false);
		((Component)val).GetComponent<tk2dSpriteAnimator>().GetClipByName(val.chargeAnimation).wrapMode = (WrapMode)1;
		((Component)val).GetComponent<tk2dSpriteAnimator>().GetClipByName(val.chargeAnimation).loopStart = 2;
		((Component)val).GetComponent<tk2dSpriteAnimator>().GetClipByName(val.shootAnimation).frames[0].eventAudio = "Play_ENM_wizardred_shoot_01";
		((Component)val).GetComponent<tk2dSpriteAnimator>().GetClipByName(val.shootAnimation).frames[0].triggerEvent = true;
		((Component)val).GetComponent<tk2dSpriteAnimator>().GetClipByName(val.chargeAnimation).frames[0].eventAudio = "Play_ENM_wizard_charge_01";
		((Component)val).GetComponent<tk2dSpriteAnimator>().GetClipByName(val.chargeAnimation).frames[0].triggerEvent = true;
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.shootStyle = (ShootStyle)3;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)1;
		val.muzzleFlashEffects.type = (VFXPoolType)0;
		val.reloadTime = 1.5f;
		val.DefaultModule.cooldownTime = 0.5f;
		val.DefaultModule.numberOfShotsInClip = 3;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(1.31f, 0.5f, 0f);
		val.SetBaseMaxAmmo(45);
		val.ammo = 45;
		val.gunClass = (GunClass)60;
		Projectile val2 = Object.Instantiate<Projectile>(val.DefaultModule.projectiles[0]);
		((Component)val2).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val2).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val2);
		val2.baseData.damage = 0f;
		val2.baseData.force = 0f;
		val2.baseData.speed = 0.001f;
		NoCollideBehaviour noCollideBehaviour = ((Component)val2).gameObject.AddComponent<NoCollideBehaviour>();
		noCollideBehaviour.worksOnEnemies = true;
		noCollideBehaviour.worksOnProjectiles = true;
		((BraveBehaviour)((BraveBehaviour)val2).sprite).renderer.enabled = false;
		BulletLifeTimer bulletLifeTimer = ((Component)val2).gameObject.AddComponent<BulletLifeTimer>();
		bulletLifeTimer.eraseInsteadOfDie = true;
		bulletLifeTimer.secondsTillDeath = 1.5f;
		((BraveBehaviour)val2).specRigidbody.CollideWithTileMap = false;
		SpawnGunjurerBulletScriptOnSpawn spawnGunjurerBulletScriptOnSpawn = ((Component)val2).gameObject.AddComponent<SpawnGunjurerBulletScriptOnSpawn>();
		ChargeProjectile item = new ChargeProjectile
		{
			Projectile = val2,
			ChargeTime = 0.8f
		};
		val.DefaultModule.chargeProjectiles = new List<ChargeProjectile> { item };
		((PickupObject)val).quality = (ItemQuality)4;
		Databases.Items.Add(val, (tk2dSpriteCollectionData)null, "ANY");
		GunjurersStaffID = ((PickupObject)val).PickupObjectId;
	}
}
