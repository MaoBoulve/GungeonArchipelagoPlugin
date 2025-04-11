using System.Collections.Generic;
using Alexandria.ItemAPI;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class Blowgun : AdvancedGunBehavior
{
	public static int BlowgunID;

	public static void Add()
	{
		//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_011f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0139: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0250: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_034f: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Blowgun", "blowgun");
		Game.Items.Rename("outdated_gun_mods:blowgun", "nn:blowgun");
		Blowgun blowgun = ((Component)val).gameObject.AddComponent<Blowgun>();
		((AdvancedGunBehavior)blowgun).preventNormalReloadAudio = true;
		GunExt.SetShortDescription((PickupObject)(object)val, "Huff and Puff");
		GunExt.SetLongDescription((PickupObject)(object)val, "Relies on lung strength to propel poisonous darts.\n\nRobots may need to hold it up to a cooling vent or something.");
		val.SetGunSprites("blowgun");
		GunExt.SetAnimationFPS(val, val.shootAnimation, 15);
		PickupObject byId = PickupObjectDatabase.GetById(56);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId is Gun) ? byId : null), true, false);
		ref string gunSwitchGroup = ref val.gunSwitchGroup;
		PickupObject byId2 = PickupObjectDatabase.GetById(150);
		gunSwitchGroup = ((Gun)((byId2 is Gun) ? byId2 : null)).gunSwitchGroup;
		ref VFXPool muzzleFlashEffects = ref val.muzzleFlashEffects;
		PickupObject byId3 = PickupObjectDatabase.GetById(26);
		muzzleFlashEffects = ((Gun)((byId3 is Gun) ? byId3 : null)).muzzleFlashEffects;
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.shootStyle = (ShootStyle)0;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 0.5f;
		val.DefaultModule.cooldownTime = 0.2f;
		val.DefaultModule.numberOfShotsInClip = 1;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(1.12f, 0.18f, 0f);
		val.SetBaseMaxAmmo(200);
		val.gunClass = (GunClass)25;
		Projectile val2 = Object.Instantiate<Projectile>(val.DefaultModule.projectiles[0]);
		((Component)val2).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val2).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val2);
		val.DefaultModule.projectiles[0] = val2;
		((BraveBehaviour)val2).transform.parent = val.barrelOffset;
		ProjectileData baseData = val2.baseData;
		baseData.speed *= 2f;
		val2.damageTypes = (CoreDamageTypes)(val2.damageTypes | 0x10);
		ExtremelySimplePoisonBulletBehaviour extremelySimplePoisonBulletBehaviour = ((Component)val2).gameObject.AddComponent<ExtremelySimplePoisonBulletBehaviour>();
		extremelySimplePoisonBulletBehaviour.procChance = 1;
		extremelySimplePoisonBulletBehaviour.useSpecialTint = false;
		val2.SetProjectileSprite("blowgun_projectile", 16, 7, lightened: false, (Anchor)4, 15, 8, anchorChangesCollider: true, fixesScale: false, null, null);
		VFXPool val3 = VFXToolbox.CreateVFXPool("Blowgun Tilemap VFX Horiz", new List<string> { "NevernamedsItems/Resources/MiscVFX/GunVFX/PoisonDarts/poisondart_impacthoriz_001", "NevernamedsItems/Resources/MiscVFX/GunVFX/PoisonDarts/poisondart_impacthoriz_002", "NevernamedsItems/Resources/MiscVFX/GunVFX/PoisonDarts/poisondart_impacthoriz_003", "NevernamedsItems/Resources/MiscVFX/GunVFX/PoisonDarts/poisondart_impacthoriz_004" }, 10, new IntVector2(12, 11), (Anchor)3, usesZHeight: false, 0f, persist: true, (VFXAlignment)1, -1f, null, (WrapMode)2);
		val2.hitEffects.deathTileMapHorizontal = val3;
		val2.hitEffects.tileMapHorizontal = val3;
		val2.hitEffects.deathTileMapVertical = val3;
		val2.hitEffects.tileMapVertical = val3;
		val.DefaultModule.ammoType = (AmmoType)14;
		val.DefaultModule.customAmmoType = CustomClipAmmoTypeToolbox.AddCustomAmmoType("Blowgun Darts", "NevernamedsItems/Resources/CustomGunAmmoTypes/blowgun_clipfull", "NevernamedsItems/Resources/CustomGunAmmoTypes/blowgun_clipempty");
		((PickupObject)val).quality = (ItemQuality)1;
		((BraveBehaviour)val).encounterTrackable.EncounterGuid = "this is the Blowgun";
		Databases.Items.Add(val, (tk2dSpriteCollectionData)null, "ANY");
		foreach (tk2dSpriteAnimationClip gunAnimationClip in AdjustGunPosition.GetGunAnimationClips(val))
		{
			tk2dSpriteAnimationFrame[] frames = gunAnimationClip.frames;
			foreach (tk2dSpriteAnimationFrame val4 in frames)
			{
				ApplyOffsetStuff.ApplyOffset(val4.spriteCollection.spriteDefinitions[val4.spriteId], new Vector2(0f, 0f));
			}
		}
		BlowgunID = ((PickupObject)val).PickupObjectId;
	}

	public override void PostProcessProjectile(Projectile projectile)
	{
		GameActor owner = projectile.Owner;
		PlayerController val = (PlayerController)(object)((owner is PlayerController) ? owner : null);
		((AdvancedGunBehavior)this).PostProcessProjectile(projectile);
		if (CustomSynergies.PlayerHasActiveSynergy(val, "Old and New"))
		{
			projectile.AppliesStun = true;
			projectile.AppliedStunDuration += 10f;
			projectile.StunApplyChance = 1f;
		}
	}
}
