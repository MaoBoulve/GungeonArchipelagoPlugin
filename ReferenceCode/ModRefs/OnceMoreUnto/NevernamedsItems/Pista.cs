using System;
using System.Collections.Generic;
using Alexandria.Assetbundle;
using Alexandria.ItemAPI;
using Alexandria.Misc;
using Alexandria.VisualAPI;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class Pista : GunBehaviour
{
	public static int PistaID;

	private float frictionTimer;

	public static void Add()
	{
		//IL_00b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0105: Unknown result type (might be due to invalid IL or missing references)
		//IL_0247: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Pista", "pista");
		Game.Items.Rename("outdated_gun_mods:pista", "nn:pista");
		((Component)val).gameObject.AddComponent<Pista>();
		GunExt.SetShortDescription((PickupObject)(object)val, "Yeeeeehaw!");
		GunExt.SetLongDescription((PickupObject)(object)val, "Six tiny spirits inhabit this gun, gleefully riding it's bullets into battle, and re-aiming them towards the nearest target when the owner signals them via reloading.\n\nThis gun smells vaguely Italian.");
		GunInt.SetupSprite(val, Initialisation.gunCollection, "pista_idle_001", 8, "pista_ammonomicon_001");
		GunExt.SetAnimationFPS(val, val.shootAnimation, 15);
		PickupObject byId = PickupObjectDatabase.GetById(86);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId is Gun) ? byId : null), true, false);
		ref string gunSwitchGroup = ref val.gunSwitchGroup;
		PickupObject byId2 = PickupObjectDatabase.GetById(38);
		gunSwitchGroup = ((Gun)((byId2 is Gun) ? byId2 : null)).gunSwitchGroup;
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.shootStyle = (ShootStyle)0;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 1f;
		val.DefaultModule.cooldownTime = 0.15f;
		val.DefaultModule.numberOfShotsInClip = 6;
		val.SetBarrel(16, 13);
		val.SetBaseMaxAmmo(200);
		val.gunClass = (GunClass)1;
		Projectile val2 = ProjectileUtility.InstantiateAndFakeprefab(val.DefaultModule.projectiles[0]);
		val.DefaultModule.projectiles[0] = val2;
		((BraveBehaviour)val2).transform.parent = val.barrelOffset;
		ProjectileData baseData = val2.baseData;
		baseData.speed *= 0.65f;
		ProjectileData baseData2 = val2.baseData;
		baseData2.range *= 2f;
		val2.baseData.damage = 10f;
		ref VFXPool muzzleFlashEffects = ref val.muzzleFlashEffects;
		PickupObject byId3 = PickupObjectDatabase.GetById(38);
		muzzleFlashEffects = ((Gun)((byId3 is Gun) ? byId3 : null)).muzzleFlashEffects;
		SelfReAimBehaviour orAddComponent = GameObjectExtensions.GetOrAddComponent<SelfReAimBehaviour>(((Component)val2).gameObject);
		orAddComponent.maxReloadReAims = 1f;
		orAddComponent.trigger = SelfReAimBehaviour.ReAimTrigger.RELOAD;
		ref GameObject vFX = ref orAddComponent.VFX;
		PickupObject byId4 = PickupObjectDatabase.GetById(178);
		vFX = ((Component)((byId4 is Gun) ? byId4 : null)).GetComponent<FireOnReloadSynergyProcessor>().DirectedBurstSettings.ProjectileInterface.SpecifiedProjectile.hitEffects.tileMapHorizontal.effects[0].effects[0].effect;
		orAddComponent.sounds = new List<string> { "Play_BOSS_Punchout_Punch_Hit_01", "Play_ENM_Hurt" };
		val.AddClipSprites("pista");
		val.AddShellCasing(0, 0, 6, 1, "shell_turquoise");
		((PickupObject)val).quality = (ItemQuality)3;
		Databases.Items.Add((PickupObject)(object)val, false, "ANY");
		PistaID = ((PickupObject)val).PickupObjectId;
	}

	public override void PostProcessProjectile(Projectile projectile)
	{
		if (Object.op_Implicit((Object)(object)((Component)projectile).gameObject.GetComponent<SelfReAimBehaviour>()))
		{
			if (Object.op_Implicit((Object)(object)ProjectileUtility.ProjectilePlayerOwner(projectile)) && CustomSynergies.PlayerHasActiveSynergy(ProjectileUtility.ProjectilePlayerOwner(projectile), "Pistols Requiem"))
			{
				((Component)projectile).gameObject.GetComponent<SelfReAimBehaviour>().maxReloadReAims = 100f;
			}
			SelfReAimBehaviour component = ((Component)projectile).gameObject.GetComponent<SelfReAimBehaviour>();
			component.OnReAim = (Action<Projectile>)Delegate.Combine(component.OnReAim, new Action<Projectile>(OnReAim));
		}
		((GunBehaviour)this).PostProcessProjectile(projectile);
	}

	public override void Update()
	{
		if (frictionTimer >= 0f)
		{
			frictionTimer -= BraveTime.DeltaTime;
		}
		((GunBehaviour)this).Update();
	}

	public void ReAimEffects(Projectile ReAimed)
	{
		//IL_00db: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
		if (frictionTimer < 0f)
		{
			StickyFrictionManager.Instance.RegisterCustomStickyFriction(0.25f, 0f, true, false);
			frictionTimer = 0.3f;
		}
		if (Object.op_Implicit((Object)(object)ProjectileUtility.ProjectilePlayerOwner(ReAimed)) && CustomSynergies.PlayerHasActiveSynergy(ProjectileUtility.ProjectilePlayerOwner(ReAimed), "Six Bullets"))
		{
			ProjectileData baseData = ReAimed.baseData;
			baseData.speed *= 2f;
			ReAimed.UpdateSpeed();
			ProjectileData baseData2 = ReAimed.baseData;
			baseData2.damage *= 1.25f;
			ImprovedAfterImage val = ((Component)ReAimed).gameObject.AddComponent<ImprovedAfterImage>();
			val.spawnShadows = true;
			val.shadowLifetime = Random.Range(0.1f, 0.2f);
			val.shadowTimeDelay = 0.001f;
			val.dashColor = new Color(1f, 0.8f, 0.55f, 0.3f);
			((Object)val).name = "Gun Trail";
		}
	}

	public static void OnReAim(Projectile ReAimed)
	{
		if (Object.op_Implicit((Object)(object)ReAimed) && Object.op_Implicit((Object)(object)ReAimed.PossibleSourceGun) && Object.op_Implicit((Object)(object)((Component)ReAimed.PossibleSourceGun).GetComponent<Pista>()))
		{
			((Component)ReAimed.PossibleSourceGun).GetComponent<Pista>().ReAimEffects(ReAimed);
		}
	}
}
