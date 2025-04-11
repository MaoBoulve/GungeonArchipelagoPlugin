using System.Collections.Generic;
using System.Reflection;
using Alexandria.ItemAPI;
using Alexandria.VisualAPI;
using Gungeon;
using SaveAPI;
using UnityEngine;

namespace NevernamedsItems;

public class Boltcaster : AdvancedGunBehavior
{
	public static void Add()
	{
		//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0111: Unknown result type (might be due to invalid IL or missing references)
		//IL_011d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0165: Unknown result type (might be due to invalid IL or missing references)
		//IL_0184: Unknown result type (might be due to invalid IL or missing references)
		//IL_0281: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Boltcaster", "nnboltcaster");
		Game.Items.Rename("outdated_gun_mods:boltcaster", "nn:boltcaster");
		Boltcaster boltcaster = ((Component)val).gameObject.AddComponent<Boltcaster>();
		GunExt.SetShortDescription((PickupObject)(object)val, "It Belongs In A Museum");
		GunExt.SetLongDescription((PickupObject)(object)val, "An old relic of one of the many rebel groups that have risen up against- and inevitably broken against the unshakeable Hegemony of Man.\n\nThe magnetic mass driver orbs give it the appearance of a crossbow.");
		((AdvancedGunBehavior)boltcaster).preventNormalFireAudio = true;
		((AdvancedGunBehavior)boltcaster).overrideNormalFireAudio = "Play_WPN_plasmarifle_shot_01";
		val.SetGunSprites("nnboltcaster");
		GunExt.SetAnimationFPS(val, val.shootAnimation, 16);
		GunExt.SetAnimationFPS(val, val.reloadAnimation, 0);
		val.muzzleFlashEffects = VFXBuilder.CreateVFXPool("Boltcaster Muzzleflash", new List<string> { "NevernamedsItems/Resources/MiscVFX/GunVFX/Boltcaster/boltcaster_muzzleflash_001", "NevernamedsItems/Resources/MiscVFX/GunVFX/Boltcaster/boltcaster_muzzleflash_002", "NevernamedsItems/Resources/MiscVFX/GunVFX/Boltcaster/boltcaster_muzzleflash_003" }, 10, new IntVector2(49, 26), (Anchor)3, false, 0f, false, (VFXAlignment)0, -1f, (Color?)null, (Assembly)null);
		PickupObject byId = PickupObjectDatabase.GetById(56);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId is Gun) ? byId : null), true, false);
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.shootStyle = (ShootStyle)0;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 1.1f;
		val.DefaultModule.cooldownTime = 0.5f;
		val.DefaultModule.numberOfShotsInClip = 1;
		val.DefaultModule.angleVariance = 0f;
		val.SetBaseMaxAmmo(100);
		val.gunClass = (GunClass)15;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(1.6875f, 0.4375f, 0f);
		Projectile component = FakePrefabExtensions.InstantiateAndFakeprefab(((Component)val.DefaultModule.projectiles[0]).gameObject).GetComponent<Projectile>();
		val.DefaultModule.projectiles[0] = component;
		component.baseData.damage = 30f;
		ProjectileData baseData = component.baseData;
		baseData.speed *= 3f;
		ProjectileData baseData2 = component.baseData;
		baseData2.range *= 3f;
		component.SetProjectileSprite("boltcaster_proj", 23, 3, lightened: true, (Anchor)4, 13, 3, anchorChangesCollider: true, fixesScale: false, null, null);
		ref ProjectileImpactVFXPool hitEffects = ref component.hitEffects;
		PickupObject byId2 = PickupObjectDatabase.GetById(543);
		hitEffects = ((Gun)((byId2 is Gun) ? byId2 : null)).DefaultModule.projectiles[0].hitEffects;
		component.pierceMinorBreakables = true;
		ProjectileData baseData3 = component.baseData;
		baseData3.force *= 4f;
		((PickupObject)val).quality = (ItemQuality)3;
		Databases.Items.Add((PickupObject)(object)val, false, "ANY");
		((PickupObject)(object)val).SetupUnlockOnCustomFlag(CustomDungeonFlags.BOSSRUSH_HUNTER, requiredFlagValue: true);
		AlexandriaTags.SetTag((PickupObject)(object)val, "arrow_bolt_weapon");
	}
}
