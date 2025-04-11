using Alexandria.ItemAPI;
using Gungeon;
using SaveAPI;
using UnityEngine;

namespace NevernamedsItems;

public class Autogun : AdvancedGunBehavior
{
	public static int AutogunID;

	public static void Add()
	{
		//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_012a: Unknown result type (might be due to invalid IL or missing references)
		//IL_014f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0290: Unknown result type (might be due to invalid IL or missing references)
		//IL_0295: Unknown result type (might be due to invalid IL or missing references)
		//IL_029a: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0331: Unknown result type (might be due to invalid IL or missing references)
		//IL_0338: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Autogun", "autogun");
		Game.Items.Rename("outdated_gun_mods:autogun", "nn:autogun");
		Autogun autogun = ((Component)val).gameObject.AddComponent<Autogun>();
		((AdvancedGunBehavior)autogun).preventNormalFireAudio = true;
		GunExt.SetShortDescription((PickupObject)(object)val, "Fully Fully Automatic");
		GunExt.SetLongDescription((PickupObject)(object)val, "Fires weak energy bolts programmed to seek and destroy.\n\nBrought to the Gungeon by an incompetent spacefarer who couldn't hit the broad side of a barn... from inside the barn.");
		val.doesScreenShake = false;
		val.SetGunSprites("autogun");
		GunExt.SetAnimationFPS(val, val.shootAnimation, 12);
		ref string gunSwitchGroup = ref val.gunSwitchGroup;
		PickupObject byId = PickupObjectDatabase.GetById(89);
		gunSwitchGroup = ((Gun)((byId is Gun) ? byId : null)).gunSwitchGroup;
		PickupObject byId2 = PickupObjectDatabase.GetById(86);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId2 is Gun) ? byId2 : null), true, false);
		val.gunHandedness = (GunHandedness)1;
		ref VFXPool muzzleFlashEffects = ref val.muzzleFlashEffects;
		PickupObject byId3 = PickupObjectDatabase.GetById(36);
		muzzleFlashEffects = ((Gun)((byId3 is Gun) ? byId3 : null)).muzzleFlashEffects;
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.shootStyle = (ShootStyle)1;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 2f;
		val.DefaultModule.cooldownTime = 0.02f;
		val.DefaultModule.numberOfShotsInClip = -1;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(1.43f, 0.31f, 0f);
		val.SetBaseMaxAmmo(2500);
		val.ammo = 2500;
		val.gunClass = (GunClass)10;
		((Component)val).GetComponent<tk2dSpriteAnimator>().GetClipByName(val.shootAnimation).frames[0].eventAudio = "Play_MouthPopSound";
		((Component)val).GetComponent<tk2dSpriteAnimator>().GetClipByName(val.shootAnimation).frames[0].triggerEvent = true;
		PickupObject byId4 = PickupObjectDatabase.GetById(445);
		Projectile val2 = Object.Instantiate<Projectile>(((Component)((Gun)((byId4 is Gun) ? byId4 : null)).DefaultModule.projectiles[0]).GetComponent<SpawnProjModifier>().projectileToSpawnOnCollision);
		((Component)val2).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val2).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val2);
		val.DefaultModule.projectiles[0] = val2;
		val2.baseData.damage = 1f;
		ProjectileData baseData = val2.baseData;
		baseData.range *= 10f;
		ProjectileData baseData2 = val2.baseData;
		baseData2.force *= 0.05f;
		BounceProjModifier orAddComponent = GameObjectExtensions.GetOrAddComponent<BounceProjModifier>(((Component)val2).gameObject);
		orAddComponent.numberOfBounces = 1;
		val2.SetProjectileSprite("autogun_proj", 2, 2, lightened: true, (Anchor)4, 2, 2, anchorChangesCollider: true, fixesScale: false, null, null);
		EasyTrailBullet easyTrailBullet = ((Component)val2).gameObject.AddComponent<EasyTrailBullet>();
		easyTrailBullet.TrailPos = Vector2.op_Implicit(((BraveBehaviour)val2).transform.position);
		easyTrailBullet.StartWidth = 0.2f;
		easyTrailBullet.EndWidth = 0f;
		easyTrailBullet.LifeTime = 0.1f;
		easyTrailBullet.BaseColor = ExtendedColours.freezeBlue;
		easyTrailBullet.EndColor = ExtendedColours.freezeBlue;
		val2.hitEffects.alwaysUseMidair = true;
		ref GameObject overrideMidairDeathVFX = ref val2.hitEffects.overrideMidairDeathVFX;
		PickupObject byId5 = PickupObjectDatabase.GetById(18);
		overrideMidairDeathVFX = ((Gun)((byId5 is Gun) ? byId5 : null)).DefaultModule.projectiles[0].hitEffects.overrideMidairDeathVFX;
		((BraveBehaviour)val2).transform.parent = val.barrelOffset;
		val.DefaultModule.ammoType = (AmmoType)2;
		((PickupObject)val).quality = (ItemQuality)2;
		Databases.Items.Add(val, (tk2dSpriteCollectionData)null, "ANY");
		((PickupObject)(object)val).SetupUnlockOnCustomFlag(CustomDungeonFlags.PURCHASED_AUTOGUN, requiredFlagValue: true);
		ItemBuilder.AddToSubShop((PickupObject)(object)val, (ShopType)3, 1f);
		AutogunID = ((PickupObject)val).PickupObjectId;
	}
}
