using System;
using System.Collections.Generic;
using Alexandria.ItemAPI;
using Alexandria.Misc;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class BouncerUzi : AdvancedGunBehavior
{
	public static int ID;

	public static void Add()
	{
		//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0134: Unknown result type (might be due to invalid IL or missing references)
		//IL_0159: Unknown result type (might be due to invalid IL or missing references)
		//IL_0218: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0394: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ab: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Bouncer Uzi", "bounceruzi");
		Game.Items.Rename("outdated_gun_mods:bouncer_uzi", "nn:bouncer_uzi");
		((Component)val).gameObject.AddComponent<BouncerUzi>();
		GunExt.SetShortDescription((PickupObject)(object)val, "Let's Bounce");
		GunExt.SetLongDescription((PickupObject)(object)val, "A standard machine pistol the bullets of which have been wrapped in rubber- though that doesnt make them less deadly.\n\nLegends tell of a mythical troupe of Gundead who used these whimsical barkers, but nobody has seen hide nor hair of them in many years.");
		val.SetGunSprites("bounceruzi");
		GunExt.SetAnimationFPS(val, val.shootAnimation, 12);
		GunExt.SetAnimationFPS(val, val.reloadAnimation, 0);
		ref string gunSwitchGroup = ref val.gunSwitchGroup;
		PickupObject byId = PickupObjectDatabase.GetById(43);
		gunSwitchGroup = ((Gun)((byId is Gun) ? byId : null)).gunSwitchGroup;
		PickupObject byId2 = PickupObjectDatabase.GetById(43);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId2 is Gun) ? byId2 : null), true, false);
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.shootStyle = (ShootStyle)1;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 1.2f;
		val.DefaultModule.cooldownTime = 0.07f;
		val.DefaultModule.angleVariance = 15f;
		val.DefaultModule.numberOfShotsInClip = 30;
		ref VFXPool muzzleFlashEffects = ref val.muzzleFlashEffects;
		PickupObject byId3 = PickupObjectDatabase.GetById(43);
		muzzleFlashEffects = ((Gun)((byId3 is Gun) ? byId3 : null)).muzzleFlashEffects;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(0.6875f, 0.625f, 0f);
		val.SetBaseMaxAmmo(700);
		val.ammo = 700;
		val.gunClass = (GunClass)10;
		Projectile val2 = ProjectileUtility.InstantiateAndFakeprefab(val.DefaultModule.projectiles[0]);
		val2.baseData.damage = 4f;
		val2.SetProjectileSprite("bounceruzi_proj", 5, 5, lightened: true, (Anchor)4, 4, 4, anchorChangesCollider: true, fixesScale: false, null, null);
		BounceProjModifier val3 = ((Component)val2).gameObject.AddComponent<BounceProjModifier>();
		val3.numberOfBounces = 1;
		VFXPool val4 = VFXToolbox.CreateVFXPool("BouncerUzi Impact", new List<string> { "NevernamedsItems/Resources/MiscVFX/GunVFX/bounceruzi_impact_001", "NevernamedsItems/Resources/MiscVFX/GunVFX/bounceruzi_impact_002", "NevernamedsItems/Resources/MiscVFX/GunVFX/bounceruzi_impact_003", "NevernamedsItems/Resources/MiscVFX/GunVFX/bounceruzi_impact_004", "NevernamedsItems/Resources/MiscVFX/GunVFX/bounceruzi_impact_005" }, 12, new IntVector2(13, 13), (Anchor)4, usesZHeight: false, 0f, persist: false, (VFXAlignment)1, -1f, null, (WrapMode)2);
		val2.hitEffects.enemy = val4;
		val2.hitEffects.tileMapHorizontal = val4;
		val2.hitEffects.tileMapVertical = val4;
		val.muzzleFlashEffects = VFXToolbox.CreateVFXPool("BouncerUzi Muzzleflash", new List<string> { "NevernamedsItems/Resources/MiscVFX/GunVFX/bounceruzi_muzzle_001", "NevernamedsItems/Resources/MiscVFX/GunVFX/bounceruzi_muzzle_002", "NevernamedsItems/Resources/MiscVFX/GunVFX/bounceruzi_muzzle_003", "NevernamedsItems/Resources/MiscVFX/GunVFX/bounceruzi_muzzle_004" }, 13, new IntVector2(13, 11), (Anchor)3, usesZHeight: false, 0f, persist: false, (VFXAlignment)0, -1f, null, (WrapMode)2);
		val.DefaultModule.projectiles[0] = val2;
		AdvancedVolleyModificationSynergyProcessor advancedVolleyModificationSynergyProcessor = ((Component)val).gameObject.AddComponent<AdvancedVolleyModificationSynergyProcessor>();
		AdvancedVolleyModificationSynergyData advancedVolleyModificationSynergyData = ScriptableObject.CreateInstance<AdvancedVolleyModificationSynergyData>();
		ProjectileModule val5 = ProjectileModule.CreateClone(val.DefaultModule, false, -1);
		val5.angleFromAim += 90f;
		val5.ammoCost = 0;
		ProjectileModule val6 = ProjectileModule.CreateClone(val.DefaultModule, false, -1);
		val6.angleFromAim -= 90f;
		val6.ammoCost = 0;
		advancedVolleyModificationSynergyData.AddsModules = true;
		advancedVolleyModificationSynergyData.ModulesToAdd = new List<ProjectileModule> { val5, val6 }.ToArray();
		advancedVolleyModificationSynergyData.RequiredSynergy = "Bounce To The Rhythm";
		advancedVolleyModificationSynergyProcessor.synergies.Add(advancedVolleyModificationSynergyData);
		val.DefaultModule.ammoType = (AmmoType)14;
		val.DefaultModule.customAmmoType = "RiotGun Bullets";
		((PickupObject)val).quality = (ItemQuality)2;
		Databases.Items.Add((PickupObject)(object)val, false, "ANY");
		ID = ((PickupObject)val).PickupObjectId;
	}

	public override void PostProcessProjectile(Projectile projectile)
	{
		if (Object.op_Implicit((Object)(object)projectile) && Object.op_Implicit((Object)(object)ProjectileUtility.ProjectilePlayerOwner(projectile)) && CustomSynergies.PlayerHasActiveSynergy(ProjectileUtility.ProjectilePlayerOwner(projectile), "Purple Gungeon Eater") && Object.op_Implicit((Object)(object)((Component)projectile).GetComponent<BounceProjModifier>()))
		{
			BounceProjModifier component = ((Component)projectile).GetComponent<BounceProjModifier>();
			component.OnBounceContext = (Action<BounceProjModifier, SpeculativeRigidbody>)Delegate.Combine(component.OnBounceContext, new Action<BounceProjModifier, SpeculativeRigidbody>(OnBounceContext));
		}
		((AdvancedGunBehavior)this).PostProcessProjectile(projectile);
	}

	public void OnBounceContext(BounceProjModifier bounce, SpeculativeRigidbody body)
	{
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		Exploder.DoDistortionWave(((BraveBehaviour)((Component)bounce).GetComponent<Projectile>()).sprite.WorldCenter, 0.5f, 0.04f, 2f, 0.5f);
		Exploder.DoRadialDamage(4f, Vector2.op_Implicit(((BraveBehaviour)((Component)bounce).GetComponent<Projectile>()).sprite.WorldCenter), 3f, false, true, false, (VFXPool)null);
	}
}
