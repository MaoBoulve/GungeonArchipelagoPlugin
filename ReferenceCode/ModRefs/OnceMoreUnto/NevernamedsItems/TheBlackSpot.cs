using Alexandria.Misc;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class TheBlackSpot : GunBehaviour
{
	public static int ID;

	public static void Add()
	{
		//IL_00d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0127: Unknown result type (might be due to invalid IL or missing references)
		//IL_013d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0149: Unknown result type (might be due to invalid IL or missing references)
		//IL_0222: Unknown result type (might be due to invalid IL or missing references)
		//IL_0227: Unknown result type (might be due to invalid IL or missing references)
		//IL_022c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0257: Unknown result type (might be due to invalid IL or missing references)
		//IL_025c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0263: Unknown result type (might be due to invalid IL or missing references)
		//IL_0268: Unknown result type (might be due to invalid IL or missing references)
		//IL_02af: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("The Black Spot", "theblackspot");
		Game.Items.Rename("outdated_gun_mods:the_black_spot", "nn:the_black_spot");
		((Component)val).gameObject.AddComponent<TheBlackSpot>();
		GunExt.SetShortDescription((PickupObject)(object)val, "Put To Death");
		GunExt.SetLongDescription((PickupObject)(object)val, "This flintlock pistol is haunted by the souls of an entire pirate crew, put to death for mutiny.\n\nWhen you hold the barrel to your ear, you can hear the sea.");
		val.SetGunSprites("theblackspot");
		GunExt.SetAnimationFPS(val, val.shootAnimation, 12);
		GunExt.SetAnimationFPS(val, val.reloadAnimation, 12);
		PickupObject byId = PickupObjectDatabase.GetById(86);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId is Gun) ? byId : null), true, false);
		ref VFXPool muzzleFlashEffects = ref val.muzzleFlashEffects;
		PickupObject byId2 = PickupObjectDatabase.GetById(169);
		muzzleFlashEffects = ((Gun)((byId2 is Gun) ? byId2 : null)).muzzleFlashEffects;
		ref string gunSwitchGroup = ref val.gunSwitchGroup;
		PickupObject byId3 = PickupObjectDatabase.GetById(9);
		gunSwitchGroup = ((Gun)((byId3 is Gun) ? byId3 : null)).gunSwitchGroup;
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.shootStyle = (ShootStyle)0;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 1.3f;
		val.DefaultModule.cooldownTime = 0.3f;
		val.DefaultModule.numberOfShotsInClip = 1;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(1.9375f, 1f, 0f);
		val.SetBaseMaxAmmo(50);
		val.gunClass = (GunClass)1;
		val.DefaultModule.ammoType = (AmmoType)8;
		Projectile val2 = ProjectileUtility.InstantiateAndFakeprefab(val.DefaultModule.projectiles[0]);
		val.DefaultModule.projectiles[0] = val2;
		((BraveBehaviour)val2).transform.parent = val.barrelOffset;
		ProjectileData baseData = val2.baseData;
		baseData.speed *= 2f;
		val2.baseData.damage = 7f;
		val2.baseData.range = 300f;
		HomingModifier val3 = ((Component)val2).gameObject.AddComponent<HomingModifier>();
		val3.HomingRadius = 100f;
		val3.AngularVelocity = 4000f;
		BounceProjModifier val4 = ((Component)val2).gameObject.AddComponent<BounceProjModifier>();
		val4.numberOfBounces = 100;
		PierceProjModifier val5 = ((Component)val2).gameObject.AddComponent<PierceProjModifier>();
		val5.penetration = 50;
		EasyTrailBullet easyTrailBullet = ((Component)val2).gameObject.AddComponent<EasyTrailBullet>();
		easyTrailBullet.TrailPos = Vector2.op_Implicit(((BraveBehaviour)val2).transform.position);
		easyTrailBullet.StartWidth = 0.43f;
		easyTrailBullet.EndWidth = 0f;
		easyTrailBullet.LifeTime = 1.5f;
		easyTrailBullet.BaseColor = Color.black;
		easyTrailBullet.EndColor = Color.black;
		val2.SetProjectileSprite("theblackspot_proj", 7, 7, lightened: false, (Anchor)4, 6, 6, anchorChangesCollider: true, fixesScale: false, null, null);
		((Component)val2).gameObject.AddComponent<PierceDeadActors>();
		((PickupObject)val).quality = (ItemQuality)4;
		Databases.Items.Add((PickupObject)(object)val, false, "ANY");
		ID = ((PickupObject)val).PickupObjectId;
	}
}
