using Alexandria.ItemAPI;
using Dungeonator;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class Primos1 : AdvancedGunBehavior
{
	public static RoomHandler lastFiredRoom;

	public static void Add()
	{
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_011c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0141: Unknown result type (might be due to invalid IL or missing references)
		//IL_0210: Unknown result type (might be due to invalid IL or missing references)
		//IL_023a: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Primos 1", "primos1");
		Game.Items.Rename("outdated_gun_mods:primos_1", "nn:primos_1");
		((Component)val).gameObject.AddComponent<Primos1>();
		GunExt.SetShortDescription((PickupObject)(object)val, "Pre-emptive Strike");
		GunExt.SetLongDescription((PickupObject)(object)val, "First shot in every room is significantly more powerful.\n\nIssued to only the highest ranking Primerdyne Marines.");
		val.SetGunSprites("primos1");
		GunExt.SetAnimationFPS(val, val.shootAnimation, 10);
		ref string gunSwitchGroup = ref val.gunSwitchGroup;
		PickupObject byId = PickupObjectDatabase.GetById(504);
		gunSwitchGroup = ((Gun)((byId is Gun) ? byId : null)).gunSwitchGroup;
		PickupObject byId2 = PickupObjectDatabase.GetById(86);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId2 is Gun) ? byId2 : null), true, false);
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.shootStyle = (ShootStyle)0;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 1f;
		val.DefaultModule.cooldownTime = 0.3f;
		val.DefaultModule.numberOfShotsInClip = 10;
		ref VFXPool muzzleFlashEffects = ref val.muzzleFlashEffects;
		PickupObject byId3 = PickupObjectDatabase.GetById(334);
		muzzleFlashEffects = ((Gun)((byId3 is Gun) ? byId3 : null)).muzzleFlashEffects;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(2.5f, 0.81f, 0f);
		val.SetBaseMaxAmmo(260);
		val.ammo = 260;
		val.gunClass = (GunClass)15;
		Projectile val2 = Object.Instantiate<Projectile>(val.DefaultModule.projectiles[0]);
		((Component)val2).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val2).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val2);
		ProjectileData baseData = val2.baseData;
		baseData.damage *= 1.6f;
		ProjectileData baseData2 = val2.baseData;
		baseData2.force *= 1.2f;
		val2.hitEffects.alwaysUseMidair = true;
		val2.hitEffects.overrideMidairDeathVFX = SharedVFX.RedLaserCircleVFX;
		GunTools.SetProjectileSpriteRight(val2, "primos1_projectile", 17, 17, true, (Anchor)4, (int?)15, (int?)15, true, false, (int?)null, (int?)null, (Projectile)null);
		PrimosBulletBehaviour orAddComponent = GameObjectExtensions.GetOrAddComponent<PrimosBulletBehaviour>(((Component)val2).gameObject);
		val.DefaultModule.ammoType = (AmmoType)14;
		val.DefaultModule.customAmmoType = "Thinline Bullets";
		val.DefaultModule.projectiles[0] = val2;
		((PickupObject)val).quality = (ItemQuality)3;
		Databases.Items.Add(val, (tk2dSpriteCollectionData)null, "ANY");
	}
}
