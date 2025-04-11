using Alexandria.ItemAPI;
using Gungeon;
using SaveAPI;
using UnityEngine;

namespace NevernamedsItems;

public class AntimaterielRifle : GunBehaviour
{
	public static int AntimaterielRifleID;

	public static void Add()
	{
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_010e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0128: Unknown result type (might be due to invalid IL or missing references)
		//IL_0212: Unknown result type (might be due to invalid IL or missing references)
		//IL_0229: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b5: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Antimateriel Rifle", "antimaterielrifle");
		Game.Items.Rename("outdated_gun_mods:antimateriel_rifle", "nn:antimateriel_rifle");
		((Component)val).gameObject.AddComponent<AntimaterielRifle>();
		GunExt.SetShortDescription((PickupObject)(object)val, "Shreddin' Vapours");
		GunExt.SetLongDescription((PickupObject)(object)val, "Used in rebel attacks on remote Hegemony of Man outposts, this high-tech tool of destruction is geared to take out heavy targets.\n\nIgnores boss DPS cap.");
		val.SetGunSprites("antimaterielrifle");
		GunExt.SetAnimationFPS(val, val.shootAnimation, 15);
		PickupObject byId = PickupObjectDatabase.GetById(56);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId is Gun) ? byId : null), true, false);
		ref VFXPool muzzleFlashEffects = ref val.muzzleFlashEffects;
		PickupObject byId2 = PickupObjectDatabase.GetById(334);
		muzzleFlashEffects = ((Gun)((byId2 is Gun) ? byId2 : null)).muzzleFlashEffects;
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.shootStyle = (ShootStyle)1;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 2f;
		val.DefaultModule.cooldownTime = 0.04f;
		val.muzzleFlashEffects.type = (VFXPoolType)0;
		val.DefaultModule.numberOfShotsInClip = 55;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(2.75f, 0.56f, 0f);
		val.SetBaseMaxAmmo(720);
		val.gunClass = (GunClass)10;
		Projectile val2 = Object.Instantiate<Projectile>(val.DefaultModule.projectiles[0]);
		((Component)val2).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val2).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val2);
		val.DefaultModule.projectiles[0] = val2;
		ProjectileData baseData = val2.baseData;
		baseData.damage *= 1f;
		ProjectileData baseData2 = val2.baseData;
		baseData2.speed *= 1.2f;
		val2.ignoreDamageCaps = true;
		val2.pierceMinorBreakables = true;
		PierceProjModifier orAddComponent = GameObjectExtensions.GetOrAddComponent<PierceProjModifier>(((Component)val2).gameObject);
		orAddComponent.penetratesBreakables = true;
		orAddComponent.penetration++;
		val2.SetProjectileSprite("antimaterielrifle_projectile", 15, 7, lightened: true, (Anchor)4, 15, 7, anchorChangesCollider: true, fixesScale: false, null, null);
		val.DefaultModule.ammoType = (AmmoType)14;
		val.DefaultModule.customAmmoType = "Thinline Bullets";
		((PickupObject)val).quality = (ItemQuality)5;
		Databases.Items.Add(val, (tk2dSpriteCollectionData)null, "ANY");
		ItemBuilder.AddToSubShop((PickupObject)(object)val, (ShopType)3, 1f);
		AntimaterielRifleID = ((PickupObject)val).PickupObjectId;
		((PickupObject)(object)val).SetupUnlockOnCustomFlag(CustomDungeonFlags.PURCHASED_ANTIMATERIELRIFLE, requiredFlagValue: true);
		((PickupObject)(object)val).AddItemToTrorcMetaShop(28, null);
		AdvancedHoveringGunSynergyProcessor advancedHoveringGunSynergyProcessor = ((Component)val).gameObject.AddComponent<AdvancedHoveringGunSynergyProcessor>();
		advancedHoveringGunSynergyProcessor.RequiredSynergy = "Prima Materia";
		advancedHoveringGunSynergyProcessor.TriggerDuration = 2f;
		advancedHoveringGunSynergyProcessor.requiresBaseGunInHand = true;
		advancedHoveringGunSynergyProcessor.FireType = (FireType)1;
		advancedHoveringGunSynergyProcessor.fireDelayBasedOnGun = true;
		advancedHoveringGunSynergyProcessor.Trigger = AdvancedHoveringGunSynergyProcessor.TriggerStyle.ON_DAMAGE;
		advancedHoveringGunSynergyProcessor.PositionType = (HoverPosition)1;
		advancedHoveringGunSynergyProcessor.IDsToSpawn = new int[1] { AntimaterielRifleID };
	}

	public override void OnPostFired(PlayerController player, Gun gun)
	{
		gun.PreventNormalFireAudio = true;
		AkSoundEngine.PostEvent("Play_WPN_plasmarifle_shot_01", ((Component)this).gameObject);
	}
}
