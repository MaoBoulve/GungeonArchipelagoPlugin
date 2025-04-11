using Alexandria.ItemAPI;
using Alexandria.Misc;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class MusketRifle : AdvancedGunBehavior
{
	public static int ID;

	public static void Add()
	{
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0123: Unknown result type (might be due to invalid IL or missing references)
		//IL_013a: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c9: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Musket Rifle", "musketrifle");
		Game.Items.Rename("outdated_gun_mods:musket_rifle", "nn:musket_rifle");
		((Component)val).gameObject.AddComponent<MusketRifle>();
		GunExt.SetShortDescription((PickupObject)(object)val, "Civil");
		GunExt.SetLongDescription((PickupObject)(object)val, "An antique musket rifle. Thoroughly inefficient, but charged with a sense of bloodthirsty ancient optimism about it's potential.");
		val.SetGunSprites("musketrifle");
		GunExt.SetAnimationFPS(val, val.shootAnimation, 15);
		GunExt.SetAnimationFPS(val, val.reloadAnimation, 6);
		ref string gunSwitchGroup = ref val.gunSwitchGroup;
		PickupObject byId = PickupObjectDatabase.GetById(9);
		gunSwitchGroup = ((Gun)((byId is Gun) ? byId : null)).gunSwitchGroup;
		ref VFXPool muzzleFlashEffects = ref val.muzzleFlashEffects;
		PickupObject byId2 = PickupObjectDatabase.GetById(9);
		muzzleFlashEffects = ((Gun)((byId2 is Gun) ? byId2 : null)).muzzleFlashEffects;
		PickupObject byId3 = PickupObjectDatabase.GetById(9);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId3 is Gun) ? byId3 : null), true, false);
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.shootStyle = (ShootStyle)0;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 2f;
		val.DefaultModule.cooldownTime = 1f;
		val.DefaultModule.numberOfShotsInClip = 1;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(4.9375f, 1.5f, 0f);
		val.SetBaseMaxAmmo(100);
		val.gunClass = (GunClass)15;
		Projectile val2 = ProjectileUtility.InstantiateAndFakeprefab(val.DefaultModule.projectiles[0]);
		val.DefaultModule.projectiles[0] = val2;
		val2.baseData.damage = 34f;
		ProjectileData baseData = val2.baseData;
		baseData.speed *= 2f;
		BounceProjModifier component = ((Component)val2).GetComponent<BounceProjModifier>();
		component.TrackEnemyChance = 1f;
		component.bouncesTrackEnemies = true;
		component.bounceTrackRadius = 5f;
		val2.pierceMinorBreakables = true;
		val.DefaultModule.ammoType = (AmmoType)8;
		((PickupObject)val).quality = (ItemQuality)1;
		Databases.Items.Add(val, (tk2dSpriteCollectionData)null, "ANY");
		ID = ((PickupObject)val).PickupObjectId;
	}

	public override void OnPostFired(PlayerController player, Gun gun)
	{
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		if (Object.op_Implicit((Object)(object)player) && CustomSynergies.PlayerHasActiveSynergy(player, "Flash In The Pan"))
		{
			GameObject val = ProjectileUtility.InstantiateAndFireInDirection(StandardisedProjectiles.smoke, Vector2.op_Implicit(gun.barrelOffset.position), gun.CurrentAngle, 0f, player);
			val.GetComponent<Projectile>().AssignToPlayer(player, postProcess: true);
		}
		((AdvancedGunBehavior)this).OnPostFired(player, gun);
	}
}
