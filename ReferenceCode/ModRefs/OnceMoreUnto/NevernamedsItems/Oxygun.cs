using Alexandria.ItemAPI;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class Oxygun : AdvancedGunBehavior
{
	public static int OxygunID;

	public static void Add()
	{
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0114: Unknown result type (might be due to invalid IL or missing references)
		//IL_0217: Unknown result type (might be due to invalid IL or missing references)
		//IL_022e: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Oxygun", "oxygun");
		Game.Items.Rename("outdated_gun_mods:oxygun", "nn:oxygun");
		((Component)val).gameObject.AddComponent<Oxygun>();
		GunExt.SetShortDescription((PickupObject)(object)val, "Bullets Not Included");
		GunExt.SetLongDescription((PickupObject)(object)val, "This standard-issue colony multi-tool seems to be stuck on the 'offensive' setting.\n\nUpon finding it, there seemed to be no shots left inside.");
		val.SetGunSprites("oxygun");
		GunExt.SetAnimationFPS(val, val.shootAnimation, 12);
		PickupObject byId = PickupObjectDatabase.GetById(56);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId is Gun) ? byId : null), true, false);
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.shootStyle = (ShootStyle)0;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 0.8f;
		val.DefaultModule.cooldownTime = 0.65f;
		val.muzzleFlashEffects.type = (VFXPoolType)0;
		val.DefaultModule.numberOfShotsInClip = 5;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(1.93f, 0.62f, 0f);
		val.SetBaseMaxAmmo(300);
		val.ammo = 0;
		val.gunClass = (GunClass)50;
		Projectile val2 = Object.Instantiate<Projectile>(val.DefaultModule.projectiles[0]);
		((Component)val2).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val2).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val2);
		val.DefaultModule.projectiles[0] = val2;
		ProjectileData baseData = val2.baseData;
		baseData.damage *= 2f;
		ProjectileData baseData2 = val2.baseData;
		baseData2.speed *= 0.4f;
		ProjectileData baseData3 = val2.baseData;
		baseData3.range *= 10f;
		HomingModifier val3 = ((Component)val2).gameObject.AddComponent<HomingModifier>();
		val3.AngularVelocity = 120f;
		val3.HomingRadius = 1000f;
		GunTools.SetProjectileSpriteRight(val2, "oxygun_projectile", 17, 7, false, (Anchor)4, (int?)17, (int?)7, true, false, (int?)null, (int?)null, (Projectile)null);
		((BraveBehaviour)val2).transform.parent = val.barrelOffset;
		val.DefaultModule.ammoType = (AmmoType)14;
		val.DefaultModule.customAmmoType = "Repetitron Bullets";
		((PickupObject)val).quality = (ItemQuality)2;
		((BraveBehaviour)val).encounterTrackable.EncounterGuid = "this is the Oxygun";
		Databases.Items.Add(val, (tk2dSpriteCollectionData)null, "ANY");
		OxygunID = ((PickupObject)val).PickupObjectId;
	}

	public override void OnPostFired(PlayerController player, Gun gun)
	{
		gun.PreventNormalFireAudio = true;
		AkSoundEngine.PostEvent("Play_WPN_stdissuelaser_shot_01", ((Component)this).gameObject);
	}
}
