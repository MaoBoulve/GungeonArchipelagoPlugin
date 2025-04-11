using Alexandria.ItemAPI;
using Alexandria.Misc;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class BrainBlast : AdvancedGunBehavior
{
	public static int ID;

	public bool isAudioLooping = false;

	public static void Add()
	{
		//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0139: Unknown result type (might be due to invalid IL or missing references)
		//IL_015e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0224: Unknown result type (might be due to invalid IL or missing references)
		//IL_0229: Unknown result type (might be due to invalid IL or missing references)
		//IL_0309: Unknown result type (might be due to invalid IL or missing references)
		//IL_0339: Unknown result type (might be due to invalid IL or missing references)
		//IL_033e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0345: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Brain Blast", "brainblast");
		Game.Items.Rename("outdated_gun_mods:brain_blast", "nn:brain_blast");
		BrainBlast brainBlast = ((Component)val).gameObject.AddComponent<BrainBlast>();
		((AdvancedGunBehavior)brainBlast).preventNormalFireAudio = true;
		((AdvancedGunBehavior)brainBlast).preventNormalReloadAudio = true;
		GunExt.SetShortDescription((PickupObject)(object)val, "Mind Power");
		GunExt.SetLongDescription((PickupObject)(object)val, "The electrical impulses that power this floating brain appear to have been exponentially magnified by the Gungeons magics.\n\nDid it always exist, or did it spontaneously manifest in a chest one day? Who knows.");
		val.doesScreenShake = false;
		val.SetGunSprites("brainblast");
		val.preventRotation = true;
		ref string gunSwitchGroup = ref val.gunSwitchGroup;
		PickupObject byId = PickupObjectDatabase.GetById(89);
		gunSwitchGroup = ((Gun)((byId is Gun) ? byId : null)).gunSwitchGroup;
		PickupObject byId2 = PickupObjectDatabase.GetById(86);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId2 is Gun) ? byId2 : null), true, false);
		val.gunHandedness = (GunHandedness)4;
		ref VFXPool muzzleFlashEffects = ref val.muzzleFlashEffects;
		PickupObject byId3 = PickupObjectDatabase.GetById(36);
		muzzleFlashEffects = ((Gun)((byId3 is Gun) ? byId3 : null)).muzzleFlashEffects;
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.shootStyle = (ShootStyle)1;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 2f;
		val.DefaultModule.cooldownTime = 0.06f;
		val.DefaultModule.angleVariance = 360f;
		val.DefaultModule.numberOfShotsInClip = -1;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(1.1875f, 0.5f, 0f);
		val.SetBaseMaxAmmo(2500);
		val.ammo = 2500;
		val.gunClass = (GunClass)10;
		val.shootAnimation = val.idleAnimation;
		Projectile val2 = ProjectileUtility.SetupProjectile(86);
		val.DefaultModule.projectiles[0] = val2;
		val2.baseData.damage = 1f;
		ProjectileData baseData = val2.baseData;
		baseData.range *= 10f;
		ProjectileData baseData2 = val2.baseData;
		baseData2.force *= 0.05f;
		((BraveBehaviour)((BraveBehaviour)val2).sprite).renderer.enabled = false;
		val2.pierceMinorBreakables = true;
		val2.PenetratesInternalWalls = true;
		RemoteBulletsProjectileBehaviour orAddComponent = GameObjectExtensions.GetOrAddComponent<RemoteBulletsProjectileBehaviour>(((Component)val2).gameObject);
		PickupObject byId4 = PickupObjectDatabase.GetById(298);
		ComplexProjectileModifier val3 = (ComplexProjectileModifier)(object)((byId4 is ComplexProjectileModifier) ? byId4 : null);
		ChainLightningModifier orAddComponent2 = GameObjectExtensions.GetOrAddComponent<ChainLightningModifier>(((Component)val2).gameObject);
		orAddComponent2.LinkVFXPrefab = val3.ChainLightningVFX;
		orAddComponent2.damageTypes = val3.ChainLightningDamageTypes;
		orAddComponent2.maximumLinkDistance = 20f;
		orAddComponent2.damagePerHit = 2.5f;
		orAddComponent2.damageCooldown = val3.ChainLightningDamageCooldown;
		if ((Object)(object)val3.ChainLightningDispersalParticles != (Object)null)
		{
			orAddComponent2.UsesDispersalParticles = true;
			orAddComponent2.DispersalParticleSystemPrefab = val3.ChainLightningDispersalParticles;
			orAddComponent2.DispersalDensity = val3.ChainLightningDispersalDensity;
			orAddComponent2.DispersalMinCoherency = val3.ChainLightningDispersalMinCoherence;
			orAddComponent2.DispersalMaxCoherency = val3.ChainLightningDispersalMaxCoherence;
		}
		else
		{
			orAddComponent2.UsesDispersalParticles = false;
		}
		val2.hitEffects.alwaysUseMidair = true;
		ref GameObject overrideMidairDeathVFX = ref val2.hitEffects.overrideMidairDeathVFX;
		PickupObject byId5 = PickupObjectDatabase.GetById(18);
		overrideMidairDeathVFX = ((Gun)((byId5 is Gun) ? byId5 : null)).DefaultModule.projectiles[0].hitEffects.overrideMidairDeathVFX;
		((BraveBehaviour)val2).transform.parent = val.barrelOffset;
		val.DefaultModule.ammoType = (AmmoType)2;
		val.muzzleFlashEffects = VFXToolbox.CreateVFXPoolBundle("BrainBlastMuzzle", usesZHeight: true, 0.4f, (VFXAlignment)0, -1f, null);
		val.carryPixelOffset = new IntVector2(5, 20);
		((PickupObject)val).quality = (ItemQuality)3;
		Databases.Items.Add(val, (tk2dSpriteCollectionData)null, "ANY");
		ItemBuilder.AddToSubShop((PickupObject)(object)val, (ShopType)0, 1f);
		ID = ((PickupObject)val).PickupObjectId;
	}

	protected override void Update()
	{
		if (Object.op_Implicit((Object)(object)base.gun))
		{
			if (base.gun.IsFiring && !isAudioLooping && Object.op_Implicit((Object)(object)base.gun.CurrentOwner))
			{
				AkSoundEngine.PostEvent("Play_ElectricSoundLoop", ((Component)this).gameObject);
				isAudioLooping = true;
			}
			if (!base.gun.IsFiring && isAudioLooping)
			{
				AkSoundEngine.PostEvent("Stop_ElectricSoundLoop", ((Component)this).gameObject);
				isAudioLooping = false;
			}
		}
		((AdvancedGunBehavior)this).Update();
	}

	public override void PostProcessProjectile(Projectile projectile)
	{
		//IL_00df: Unknown result type (might be due to invalid IL or missing references)
		if (Object.op_Implicit((Object)(object)base.gun) && Object.op_Implicit((Object)(object)GunTools.GunPlayerOwner(base.gun)) && CustomSynergies.PlayerHasActiveSynergy(GunTools.GunPlayerOwner(base.gun), "Dear God That Pig Can Do Algebra"))
		{
			foreach (PassiveItem passiveItem in GunTools.GunPlayerOwner(base.gun).passiveItems)
			{
				if (passiveItem is CompanionItem && Object.op_Implicit((Object)(object)((CompanionItem)((passiveItem is CompanionItem) ? passiveItem : null)).ExtantCompanion) && (((CompanionItem)((passiveItem is CompanionItem) ? passiveItem : null)).CompanionGuid == "fe51c83b41ce4a46b42f54ab5f31e6d0" || ((CompanionItem)((passiveItem is CompanionItem) ? passiveItem : null)).CompanionGuid == "86237c6482754cd29819c239403a2de7"))
				{
					Projectile component = ProjectileUtility.InstantiateAndFireInDirection(base.gun.DefaultModule.projectiles[0], ((tk2dBaseSprite)((CompanionItem)((passiveItem is CompanionItem) ? passiveItem : null)).ExtantCompanion.GetComponent<tk2dSprite>()).WorldCenter, BraveUtility.RandomAngle(), 0f, (PlayerController)null).GetComponent<Projectile>();
					component.Owner = (GameActor)(object)GunTools.GunPlayerOwner(base.gun);
					component.Shooter = ((BraveBehaviour)GunTools.GunPlayerOwner(base.gun)).specRigidbody;
					component.ScaleByPlayerStats(GunTools.GunPlayerOwner(base.gun));
					GunTools.GunPlayerOwner(base.gun).DoPostProcessProjectile(component);
				}
			}
		}
		((AdvancedGunBehavior)this).PostProcessProjectile(projectile);
	}

	public override void OnSwitchedAwayFromThisGun()
	{
		AkSoundEngine.PostEvent("Stop_ElectricSoundLoop", ((Component)this).gameObject);
		isAudioLooping = false;
		((AdvancedGunBehavior)this).OnSwitchedAwayFromThisGun();
	}

	public override void OnSwitchedToThisGun()
	{
		AkSoundEngine.PostEvent("Stop_ElectricSoundLoop", ((Component)this).gameObject);
		isAudioLooping = false;
		((AdvancedGunBehavior)this).OnSwitchedToThisGun();
	}
}
