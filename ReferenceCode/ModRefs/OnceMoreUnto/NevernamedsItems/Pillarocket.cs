using Alexandria.Assetbundle;
using Alexandria.ItemAPI;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class Pillarocket : AdvancedGunBehavior
{
	public static int ID;

	public static Projectile PillarocketAKProj;

	public static Projectile PillarocketMagnumProj;

	public static Projectile PillarocketShotgunProj;

	public static void Add()
	{
		//IL_00c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_013d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0213: Unknown result type (might be due to invalid IL or missing references)
		//IL_0253: Unknown result type (might be due to invalid IL or missing references)
		//IL_028b: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_02cc: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Pillarocket", "pillarocket");
		Game.Items.Rename("outdated_gun_mods:pillarocket", "nn:pillarocket");
		Pillarocket pillarocket = ((Component)val).gameObject.AddComponent<Pillarocket>();
		((AdvancedGunBehavior)pillarocket).preventNormalFireAudio = true;
		((AdvancedGunBehavior)pillarocket).preventNormalReloadAudio = true;
		((AdvancedGunBehavior)pillarocket).overrideNormalFireAudio = "Play_ENM_statue_stomp_01";
		((AdvancedGunBehavior)pillarocket).overrideNormalReloadAudio = "Play_ENM_statue_charge_01";
		GunExt.SetShortDescription((PickupObject)(object)val, "Ancient Shrine");
		GunExt.SetLongDescription((PickupObject)(object)val, "Fires vengeful effigies, under your command.\n\nInhabited by the souls of ancient gundead heroes.");
		val.SetGunSprites("pillarocket");
		ref string gunSwitchGroup = ref val.gunSwitchGroup;
		PickupObject byId = PickupObjectDatabase.GetById(37);
		gunSwitchGroup = ((Gun)((byId is Gun) ? byId : null)).gunSwitchGroup;
		PickupObject byId2 = PickupObjectDatabase.GetById(39);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId2 is Gun) ? byId2 : null), true, false);
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.shootStyle = (ShootStyle)0;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 4f;
		val.DefaultModule.cooldownTime = 2f;
		val.DefaultModule.angleVariance = 20f;
		val.DefaultModule.numberOfShotsInClip = 4;
		ref VFXPool muzzleFlashEffects = ref val.muzzleFlashEffects;
		PickupObject byId3 = PickupObjectDatabase.GetById(372);
		muzzleFlashEffects = ((Gun)((byId3 is Gun) ? byId3 : null)).muzzleFlashEffects;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(2.18f, 1.68f, 0f);
		val.SetBaseMaxAmmo(30);
		val.ammo = 30;
		Projectile val2 = Object.Instantiate<Projectile>(val.DefaultModule.projectiles[0]);
		((Component)val2).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val2).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val2);
		val2.baseData.speed = 6.5f;
		val2.baseData.damage = 80f;
		val2.baseData.range = 100f;
		val2.baseData.force = 10f;
		val2.pierceMinorBreakables = true;
		RemoteBulletsProjectileBehaviour orAddComponent = GameObjectExtensions.GetOrAddComponent<RemoteBulletsProjectileBehaviour>(((Component)val2).gameObject);
		orAddComponent.trackingTime = 1000f;
		PillarocketFiring orAddComponent2 = GameObjectExtensions.GetOrAddComponent<PillarocketFiring>(((Component)val2).gameObject);
		ProjectileBuilders.AnimateProjectileBundle(val2, "PillarocketProjectile", Initialisation.ProjectileCollection, Initialisation.projectileAnimationCollection, "PillarocketProjectile", MiscTools.DupeList<IntVector2>(new IntVector2(15, 8), 20), MiscTools.DupeList(value: false, 20), MiscTools.DupeList<Anchor>((Anchor)4, 20), MiscTools.DupeList(value: false, 20), MiscTools.DupeList(value: false, 20), MiscTools.DupeList<Vector3?>(null, 20), MiscTools.DupeList((IntVector2?)new IntVector2(15, 6), 20), MiscTools.DupeList<IntVector2?>(null, 20), MiscTools.DupeList<Projectile>(null, 20));
		val.DefaultModule.ammoType = (AmmoType)14;
		val.DefaultModule.customAmmoType = CustomClipAmmoTypeToolbox.AddCustomAmmoType("Pillarocket Bullets", "NevernamedsItems/Resources/CustomGunAmmoTypes/pillarocket_clipfull", "NevernamedsItems/Resources/CustomGunAmmoTypes/pillarocket_clipempty");
		val.DefaultModule.projectiles[0] = val2;
		val.gunClass = (GunClass)45;
		((PickupObject)val).quality = (ItemQuality)5;
		Databases.Items.Add(val, (tk2dSpriteCollectionData)null, "ANY");
		PickupObject byId4 = PickupObjectDatabase.GetById(15);
		Projectile val3 = Object.Instantiate<Projectile>(((Gun)((byId4 is Gun) ? byId4 : null)).DefaultModule.projectiles[0]);
		((Component)val3).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val3).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val3);
		val3.SetProjectileSprite("pillarocket_subprojectile", 5, 5, lightened: true, (Anchor)4, 3, 3, anchorChangesCollider: true, fixesScale: false, null, null);
		PillarocketAKProj = val3;
		PickupObject byId5 = PickupObjectDatabase.GetById(38);
		Projectile val4 = Object.Instantiate<Projectile>(((Gun)((byId5 is Gun) ? byId5 : null)).DefaultModule.projectiles[0]);
		((Component)val4).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val4).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val4);
		val4.SetProjectileSprite("pillarocket_subprojectile", 5, 5, lightened: true, (Anchor)4, 3, 3, anchorChangesCollider: true, fixesScale: false, null, null);
		PillarocketMagnumProj = val4;
		PickupObject byId6 = PickupObjectDatabase.GetById(51);
		Projectile val5 = Object.Instantiate<Projectile>(((Gun)((byId6 is Gun) ? byId6 : null)).DefaultModule.projectiles[0]);
		((Component)val5).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val5).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val5);
		val5.SetProjectileSprite("pillarocket_subprojectile", 5, 5, lightened: true, (Anchor)4, 3, 3, anchorChangesCollider: true, fixesScale: false, null, null);
		PillarocketShotgunProj = val5;
		ID = ((PickupObject)val).PickupObjectId;
	}
}
