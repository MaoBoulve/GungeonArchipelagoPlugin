using System;
using Alexandria.Assetbundle;
using Alexandria.ItemAPI;
using Alexandria.Misc;
using Gungeon;
using SaveAPI;
using UnityEngine;

namespace NevernamedsItems;

public class Repeatovolver : GunBehaviour
{
	public static int RepeatovolverID;

	public static void Add()
	{
		//IL_009d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_010d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0127: Unknown result type (might be due to invalid IL or missing references)
		//IL_018f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0203: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Repeatovolver", "repeatovolver");
		Game.Items.Rename("outdated_gun_mods:repeatovolver", "nn:repeatovolver");
		((Component)val).gameObject.AddComponent<Repeatovolver>();
		GunExt.SetShortDescription((PickupObject)(object)val, "Rolls Off The Tongue");
		GunExt.SetLongDescription((PickupObject)(object)val, "A revolver modified to spew forth it's entire extended cylinder with a single pull of the trigger.\n\nNames such as 'Repeating Revolver', 'Revolverpeater' and 'Rerererererevolver' were floated, but eventually 'Repeatovolver' won out.");
		GunInt.SetupSprite(val, Initialisation.gunCollection, "repeatovolver_idle_001", 8, "repeatovolver_ammonomicon_001");
		GunExt.SetAnimationFPS(val, val.shootAnimation, 15);
		PickupObject byId = PickupObjectDatabase.GetById(56);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId is Gun) ? byId : null), true, false);
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.shootStyle = (ShootStyle)4;
		val.DefaultModule.burstShotCount = 10;
		val.DefaultModule.burstCooldownTime = 0.04f;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 1f;
		val.DefaultModule.cooldownTime = 1f;
		val.DefaultModule.numberOfShotsInClip = 10;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(1.31f, 0.62f, 0f);
		val.SetBaseMaxAmmo(1000);
		val.gunClass = (GunClass)10;
		Projectile val2 = Object.Instantiate<Projectile>(val.DefaultModule.projectiles[0]);
		((Component)val2).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val2).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val2);
		val.DefaultModule.projectiles[0] = val2;
		ref VFXPool muzzleFlashEffects = ref val.muzzleFlashEffects;
		PickupObject byId2 = PickupObjectDatabase.GetById(62);
		muzzleFlashEffects = ((Gun)((byId2 is Gun) ? byId2 : null)).muzzleFlashEffects;
		val.gunHandedness = (GunHandedness)2;
		ProjectileData baseData = val2.baseData;
		baseData.range *= 2f;
		((BraveBehaviour)val2).transform.parent = val.barrelOffset;
		GunTools.SetProjectileSpriteRight(val2, "repeating_projectile", 9, 6, false, (Anchor)4, (int?)9, (int?)6, true, false, (int?)null, (int?)null, (Projectile)null);
		val.AddShellCasing();
		((PickupObject)val).quality = (ItemQuality)3;
		Databases.Items.Add(val, (tk2dSpriteCollectionData)null, "ANY");
		GunExt.SetName((PickupObject)(object)val, "Repeatovolver");
		RepeatovolverID = ((PickupObject)val).PickupObjectId;
		((PickupObject)(object)val).SetupUnlockOnCustomFlag(CustomDungeonFlags.PURCHASED_REPEATOVOLVER, requiredFlagValue: true);
	}

	public override void Update()
	{
		if (Object.op_Implicit((Object)(object)base.gun) && Object.op_Implicit((Object)(object)GunTools.GunPlayerOwner(base.gun)))
		{
			PlayerController val = GunTools.GunPlayerOwner(base.gun);
			if (CustomSynergies.PlayerHasActiveSynergy(val, "Ad Infinitum") && !base.gun.InfiniteAmmo)
			{
				base.gun.InfiniteAmmo = true;
			}
			else if (!CustomSynergies.PlayerHasActiveSynergy(val, "Ad Infinitum") && base.gun.InfiniteAmmo)
			{
				base.gun.InfiniteAmmo = false;
			}
		}
	}

	public override void PostProcessProjectile(Projectile projectile)
	{
		//IL_00cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_010c: Unknown result type (might be due to invalid IL or missing references)
		if (Object.op_Implicit((Object)(object)projectile) && Object.op_Implicit((Object)(object)ProjectileUtility.ProjectilePlayerOwner(projectile)) && Object.op_Implicit((Object)(object)base.gun) && Object.op_Implicit((Object)(object)base.gun.CurrentOwner) && GunTools.IsCurrentGun(base.gun))
		{
			if (CustomSynergies.PlayerHasActiveSynergy(ProjectileUtility.ProjectilePlayerOwner(projectile), "Repeating Yourself"))
			{
				projectile.OnHitEnemy = (Action<Projectile, SpeculativeRigidbody, bool>)Delegate.Combine(projectile.OnHitEnemy, new Action<Projectile, SpeculativeRigidbody, bool>(OnHit));
			}
			bool flag = base.gun.LastShotIndex == 0;
			bool flag2 = base.gun.LastShotIndex == base.gun.ClipCapacity - 1;
			if (flag && CustomSynergies.PlayerHasActiveSynergy(ProjectileUtility.ProjectilePlayerOwner(projectile), "Ad Nauseum"))
			{
				projectile.AdjustPlayerProjectileTint(ExtendedColours.plaguePurple, 2, 0f);
				projectile.statusEffectsToApply.Add((GameActorEffect)(object)StaticStatusEffects.StandardPlagueEffect);
			}
			if (flag2 && CustomSynergies.PlayerHasActiveSynergy(ProjectileUtility.ProjectilePlayerOwner(projectile), "Ad Nauseum"))
			{
				projectile.AdjustPlayerProjectileTint(ExtendedColours.poisonGreen, 2, 0f);
				projectile.statusEffectsToApply.Add((GameActorEffect)(object)StaticStatusEffects.irradiatedLeadEffect);
			}
		}
		((GunBehaviour)this).PostProcessProjectile(projectile);
	}

	public void OnHit(Projectile proj, SpeculativeRigidbody bod, bool fatal)
	{
		if (fatal)
		{
			int num = base.gun.ClipCapacity - base.gun.ClipShotsRemaining;
			if (num > 0)
			{
				base.gun.MoveBulletsIntoClip(num);
			}
		}
	}
}
