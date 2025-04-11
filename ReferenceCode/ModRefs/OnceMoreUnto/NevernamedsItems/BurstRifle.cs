using Alexandria.ItemAPI;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class BurstRifle : AdvancedGunBehavior
{
	public static int ID;

	public static void Add()
	{
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0162: Unknown result type (might be due to invalid IL or missing references)
		//IL_0187: Unknown result type (might be due to invalid IL or missing references)
		//IL_0267: Unknown result type (might be due to invalid IL or missing references)
		//IL_026c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0271: Unknown result type (might be due to invalid IL or missing references)
		//IL_0298: Unknown result type (might be due to invalid IL or missing references)
		//IL_029d: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_031a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0331: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Burst Rifle", "burstrifle");
		Game.Items.Rename("outdated_gun_mods:burst_rifle", "nn:burst_rifle");
		((Component)val).gameObject.AddComponent<BurstRifle>();
		GunExt.SetShortDescription((PickupObject)(object)val, "Trifling Matters");
		GunExt.SetLongDescription((PickupObject)(object)val, "Designed by famous gunsmith Algernon Burst, this classic weapon features a stylish leather grip.\n\nPuts the tat-tat in 'ratta tat-tat'. Whatever the hell that means.");
		val.SetGunSprites("burstrifle");
		GunExt.SetAnimationFPS(val, val.shootAnimation, 12);
		GunExt.SetAnimationFPS(val, val.reloadAnimation, 0);
		ref string gunSwitchGroup = ref val.gunSwitchGroup;
		PickupObject byId = PickupObjectDatabase.GetById(5);
		gunSwitchGroup = ((Gun)((byId is Gun) ? byId : null)).gunSwitchGroup;
		ItemBuilder.AddCurrentGunStatModifier(val, (StatType)4, 2f, (ModifyMethod)0);
		PickupObject byId2 = PickupObjectDatabase.GetById(56);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId2 is Gun) ? byId2 : null), true, false);
		val.gunHandedness = (GunHandedness)1;
		ref VFXPool muzzleFlashEffects = ref val.muzzleFlashEffects;
		PickupObject byId3 = PickupObjectDatabase.GetById(5);
		muzzleFlashEffects = ((Gun)((byId3 is Gun) ? byId3 : null)).muzzleFlashEffects;
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.shootStyle = (ShootStyle)4;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 1.2f;
		val.DefaultModule.burstShotCount = 4;
		val.DefaultModule.burstCooldownTime = 0.1f;
		val.DefaultModule.cooldownTime = 0.25f;
		val.DefaultModule.numberOfShotsInClip = 8;
		val.DefaultModule.angleVariance = 3.5f;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(2.68f, 0.87f, 0f);
		val.SetBaseMaxAmmo(240);
		val.ammo = 240;
		val.gunClass = (GunClass)15;
		Projectile val2 = Object.Instantiate<Projectile>(val.DefaultModule.projectiles[0]);
		((Component)val2).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val2).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val2);
		val.DefaultModule.projectiles[0] = val2;
		val2.baseData.damage = 10f;
		ProjectileData baseData = val2.baseData;
		baseData.speed *= 3f;
		ProjectileData baseData2 = val2.baseData;
		baseData2.range *= 10f;
		PierceDeadActors pierceDeadActors = ((Component)val2).gameObject.AddComponent<PierceDeadActors>();
		val2.SetProjectileSprite("burstrifle_proj", 7, 4, lightened: true, (Anchor)4, 7, 4, anchorChangesCollider: true, fixesScale: false, null, null);
		EasyTrailBullet easyTrailBullet = ((Component)val2).gameObject.AddComponent<EasyTrailBullet>();
		easyTrailBullet.TrailPos = Vector2.op_Implicit(((BraveBehaviour)val2).transform.position);
		easyTrailBullet.StartWidth = 0.25f;
		easyTrailBullet.EndWidth = 0f;
		easyTrailBullet.LifeTime = 0.1f;
		easyTrailBullet.BaseColor = ExtendedColours.honeyYellow;
		easyTrailBullet.EndColor = ExtendedColours.honeyYellow;
		val2.hitEffects.alwaysUseMidair = true;
		ref GameObject overrideMidairDeathVFX = ref val2.hitEffects.overrideMidairDeathVFX;
		PickupObject byId4 = PickupObjectDatabase.GetById(647);
		overrideMidairDeathVFX = ((Gun)((byId4 is Gun) ? byId4 : null)).DefaultModule.projectiles[0].hitEffects.tileMapVertical.effects[0].effects[0].effect;
		((BraveBehaviour)val2).transform.parent = val.barrelOffset;
		val.DefaultModule.ammoType = (AmmoType)14;
		val.DefaultModule.customAmmoType = "Rifle";
		((PickupObject)val).quality = (ItemQuality)4;
		Databases.Items.Add(val, (tk2dSpriteCollectionData)null, "ANY");
		ItemBuilder.AddToSubShop((PickupObject)(object)val, (ShopType)3, 1f);
		ID = ((PickupObject)val).PickupObjectId;
	}
}
