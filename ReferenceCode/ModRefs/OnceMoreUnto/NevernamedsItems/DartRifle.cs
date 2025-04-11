using Alexandria.ItemAPI;
using Gungeon;
using SaveAPI;
using UnityEngine;

namespace NevernamedsItems;

public class DartRifle : GunBehaviour
{
	public static int DartRifleID;

	public static void Add()
	{
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_0213: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Dart Rifle", "dartrifle");
		Game.Items.Rename("outdated_gun_mods:dart_rifle", "nn:dart_rifle");
		((Component)val).gameObject.AddComponent<DartRifle>();
		GunExt.SetShortDescription((PickupObject)(object)val, "Tactical Incapacitation");
		GunExt.SetLongDescription((PickupObject)(object)val, "Used to incapacitate large animals for transport.\n\nLoaded with a powerful sedative.");
		val.SetGunSprites("dartrifle");
		GunExt.SetAnimationFPS(val, val.shootAnimation, 15);
		PickupObject byId = PickupObjectDatabase.GetById(56);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId is Gun) ? byId : null), true, false);
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.shootStyle = (ShootStyle)0;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 1f;
		val.DefaultModule.cooldownTime = 0.6f;
		val.DefaultModule.numberOfShotsInClip = 5;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(2.12f, 0.56f, 0f);
		val.SetBaseMaxAmmo(100);
		val.gunClass = (GunClass)15;
		Projectile val2 = Object.Instantiate<Projectile>(val.DefaultModule.projectiles[0]);
		((Component)val2).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val2).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val2);
		val.DefaultModule.projectiles[0] = val2;
		((BraveBehaviour)val2).transform.parent = val.barrelOffset;
		ProjectileData baseData = val2.baseData;
		baseData.speed *= 2f;
		ProjectileData baseData2 = val2.baseData;
		baseData2.damage *= 1.4f;
		val2.AppliesStun = true;
		val2.AppliedStunDuration += 7f;
		val2.StunApplyChance = 1f;
		val2.SetProjectileSprite("dartrifle_projectile", 16, 7, lightened: false, (Anchor)4, 14, 3, anchorChangesCollider: true, fixesScale: false, null, null);
		val.DefaultModule.ammoType = (AmmoType)14;
		val.DefaultModule.customAmmoType = CustomClipAmmoTypeToolbox.AddCustomAmmoType("Dart Rifle Darts", "NevernamedsItems/Resources/CustomGunAmmoTypes/dartrifle_clipfull", "NevernamedsItems/Resources/CustomGunAmmoTypes/dartrifle_clipempty");
		((PickupObject)val).quality = (ItemQuality)3;
		Databases.Items.Add(val, (tk2dSpriteCollectionData)null, "ANY");
		((PickupObject)(object)val).SetupUnlockOnCustomFlag(CustomDungeonFlags.PURCHASED_DARTRIFLE, requiredFlagValue: true);
		DartRifleID = ((PickupObject)val).PickupObjectId;
	}

	public override void PostProcessProjectile(Projectile projectile)
	{
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		GameActor owner = projectile.Owner;
		PlayerController val = (PlayerController)(object)((owner is PlayerController) ? owner : null);
		((GunBehaviour)this).PostProcessProjectile(projectile);
		if (CustomSynergies.PlayerHasActiveSynergy(val, "Old and New"))
		{
			projectile.damageTypes = (CoreDamageTypes)(projectile.damageTypes | 0x10);
			ExtremelySimplePoisonBulletBehaviour extremelySimplePoisonBulletBehaviour = ((Component)projectile).gameObject.AddComponent<ExtremelySimplePoisonBulletBehaviour>();
			extremelySimplePoisonBulletBehaviour.procChance = 1;
			extremelySimplePoisonBulletBehaviour.useSpecialTint = false;
		}
	}
}
