using Alexandria.ItemAPI;
using Alexandria.Misc;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class KineticBlaster : AdvancedGunBehavior
{
	public static void Add()
	{
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_011c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0141: Unknown result type (might be due to invalid IL or missing references)
		//IL_0221: Unknown result type (might be due to invalid IL or missing references)
		//IL_0247: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Kinetic Blaster", "kineticblaster");
		Game.Items.Rename("outdated_gun_mods:kinetic_blaster", "nn:kinetic_blaster");
		((Component)val).gameObject.AddComponent<KineticBlaster>();
		GunExt.SetShortDescription((PickupObject)(object)val, "Knock Knock Knockin");
		GunExt.SetLongDescription((PickupObject)(object)val, "Converts chemical potential energy into potent kinetic energy.\n\nOlder than most guns in the Gungeon. In it's hayday, it was even powerful enough to grant flight!");
		val.SetGunSprites("kineticblaster");
		GunExt.SetAnimationFPS(val, val.shootAnimation, 12);
		ref string gunSwitchGroup = ref val.gunSwitchGroup;
		PickupObject byId = PickupObjectDatabase.GetById(402);
		gunSwitchGroup = ((Gun)((byId is Gun) ? byId : null)).gunSwitchGroup;
		PickupObject byId2 = PickupObjectDatabase.GetById(86);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId2 is Gun) ? byId2 : null), true, false);
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.shootStyle = (ShootStyle)0;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 1.2f;
		val.DefaultModule.cooldownTime = 0.2f;
		ref VFXPool muzzleFlashEffects = ref val.muzzleFlashEffects;
		PickupObject byId3 = PickupObjectDatabase.GetById(228);
		muzzleFlashEffects = ((Gun)((byId3 is Gun) ? byId3 : null)).muzzleFlashEffects;
		val.DefaultModule.numberOfShotsInClip = 10;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(2.18f, 0.5f, 0f);
		val.SetBaseMaxAmmo(300);
		val.ammo = 300;
		val.gunClass = (GunClass)15;
		Projectile val2 = Object.Instantiate<Projectile>(val.DefaultModule.projectiles[0]);
		((Component)val2).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val2).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val2);
		val.DefaultModule.projectiles[0] = val2;
		val2.baseData.damage = 7f;
		ProjectileData baseData = val2.baseData;
		baseData.force *= 6f;
		val2.SetProjectileSprite("kineticblaster_projectile", 10, 10, lightened: true, (Anchor)4, 8, 8, anchorChangesCollider: true, fixesScale: false, null, null);
		val2.hitEffects.alwaysUseMidair = true;
		val2.hitEffects.overrideMidairDeathVFX = SharedVFX.BlueFrostBlastVFX;
		((BraveBehaviour)val2).transform.parent = val.barrelOffset;
		val.DefaultModule.ammoType = (AmmoType)14;
		val.DefaultModule.customAmmoType = CustomClipAmmoTypeToolbox.AddCustomAmmoType("Kinetic Blaster Bullets", "NevernamedsItems/Resources/CustomGunAmmoTypes/kineticblaster_clipfull", "NevernamedsItems/Resources/CustomGunAmmoTypes/kineticblaster_clipempty");
		((PickupObject)val).quality = (ItemQuality)2;
		Databases.Items.Add((PickupObject)(object)val, false, "ANY");
	}

	public override void OnPostFired(PlayerController player, Gun gun)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		Vector2 val = Vector2Extensions.Rotate(MathsAndLogicHelper.DegreeToVector2(gun.CurrentAngle), 180f);
		((BraveBehaviour)player).knockbackDoer.ApplyKnockback(val, 30f * player.stats.GetStatValue((StatType)12), false);
		((AdvancedGunBehavior)this).OnPostFired(player, gun);
	}

	public override void PostProcessProjectile(Projectile projectile)
	{
		if (Object.op_Implicit((Object)(object)projectile) && Object.op_Implicit((Object)(object)ProjectileUtility.ProjectilePlayerOwner(projectile)))
		{
			ProjectileData baseData = projectile.baseData;
			baseData.damage *= ProjectileUtility.ProjectilePlayerOwner(projectile).stats.GetStatValue((StatType)12);
		}
		((AdvancedGunBehavior)this).PostProcessProjectile(projectile);
	}
}
