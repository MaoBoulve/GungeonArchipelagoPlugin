using Alexandria.Assetbundle;
using Alexandria.ItemAPI;
using Alexandria.Misc;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class CopperSidearm : AdvancedGunBehavior
{
	public static int CopperSidearmID;

	public static void Add()
	{
		//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_012e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0147: Unknown result type (might be due to invalid IL or missing references)
		//IL_027e: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a4: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Copper Sidearm", "coppersidearm");
		Game.Items.Rename("outdated_gun_mods:copper_sidearm", "nn:copper_sidearm");
		((Component)val).gameObject.AddComponent<CopperSidearm>();
		GunExt.SetShortDescription((PickupObject)(object)val, "Conductive");
		GunExt.SetLongDescription((PickupObject)(object)val, "A prime conductor of electricity, the bullets from this gun connect back to the wielder by an electric arc.\n\nSmells faintly of wax.");
		GunInt.SetupSprite(val, Initialisation.gunCollection, "coppersidearm_idle_001", 8, "coppersidearm_ammonomicon_001");
		GunExt.SetAnimationFPS(val, val.shootAnimation, 16);
		GunExt.SetAnimationFPS(val, val.reloadAnimation, 1);
		ref string gunSwitchGroup = ref val.gunSwitchGroup;
		PickupObject byId = PickupObjectDatabase.GetById(545);
		gunSwitchGroup = ((Gun)((byId is Gun) ? byId : null)).gunSwitchGroup;
		PickupObject byId2 = PickupObjectDatabase.GetById(86);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId2 is Gun) ? byId2 : null), true, false);
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.shootStyle = (ShootStyle)0;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 1f;
		val.DefaultModule.cooldownTime = 0.2f;
		ref VFXPool muzzleFlashEffects = ref val.muzzleFlashEffects;
		PickupObject byId3 = PickupObjectDatabase.GetById(97);
		muzzleFlashEffects = ((Gun)((byId3 is Gun) ? byId3 : null)).muzzleFlashEffects;
		val.DefaultModule.numberOfShotsInClip = 6;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(1.56f, 0.62f, 0f);
		val.SetBaseMaxAmmo(200);
		val.gunClass = (GunClass)1;
		ref VFXPool muzzleFlashEffects2 = ref val.muzzleFlashEffects;
		PickupObject byId4 = PickupObjectDatabase.GetById(23);
		muzzleFlashEffects2 = ((Gun)((byId4 is Gun) ? byId4 : null)).muzzleFlashEffects;
		Projectile val2 = Object.Instantiate<Projectile>(val.DefaultModule.projectiles[0]);
		((Component)val2).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val2).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val2);
		val.DefaultModule.projectiles[0] = val2;
		val2.baseData.damage = 6f;
		ProjectileData baseData = val2.baseData;
		baseData.speed *= 0.5f;
		ProjectileData baseData2 = val2.baseData;
		baseData2.range *= 10f;
		val2.SetProjectileSprite("coppersidearm_projectile", 10, 10, lightened: true, (Anchor)4, 8, 8, anchorChangesCollider: true, fixesScale: false, null, null);
		GameObject val3 = FakePrefab.Clone(((Component)Game.Items["shock_rounds"]).GetComponent<ComplexProjectileModifier>().ChainLightningVFX);
		FakePrefab.MarkAsFakePrefab(val3);
		Object.DontDestroyOnLoad((Object)(object)val3);
		OwnerConnectLightningModifier ownerConnectLightningModifier = ((Component)val2).gameObject.AddComponent<OwnerConnectLightningModifier>();
		ownerConnectLightningModifier.linkPrefab = val3;
		PierceProjModifier val4 = ((Component)val2).gameObject.AddComponent<PierceProjModifier>();
		val4.penetration = 1;
		val.DefaultModule.ammoType = (AmmoType)14;
		val.DefaultModule.customAmmoType = CustomClipAmmoTypeToolbox.AddCustomAmmoType("CopperSidearm Bullets", "NevernamedsItems/Resources/CustomGunAmmoTypes/coppersidearm_clipfull", "NevernamedsItems/Resources/CustomGunAmmoTypes/coppersidearm_clipempty");
		((PickupObject)val).quality = (ItemQuality)2;
		Databases.Items.Add((PickupObject)(object)val, false, "ANY");
		CopperSidearmID = ((PickupObject)val).PickupObjectId;
	}

	public override void PostProcessProjectile(Projectile projectile)
	{
		if (Object.op_Implicit((Object)(object)projectile) && Object.op_Implicit((Object)(object)ProjectileUtility.ProjectilePlayerOwner(projectile)) && CustomSynergies.PlayerHasActiveSynergy(ProjectileUtility.ProjectilePlayerOwner(projectile), "Cop-Out") && Random.value <= 0.25f)
		{
			projectile.statusEffectsToApply.Add((GameActorEffect)(object)StaticStatusEffects.hotLeadEffect);
		}
		((AdvancedGunBehavior)this).PostProcessProjectile(projectile);
	}
}
