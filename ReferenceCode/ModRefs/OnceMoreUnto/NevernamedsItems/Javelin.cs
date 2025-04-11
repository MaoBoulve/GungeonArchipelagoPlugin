using Alexandria.ItemAPI;
using Alexandria.Misc;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class Javelin : GunBehaviour
{
	public static int ID;

	public static string ThrowAnim;

	public static void Add()
	{
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0109: Unknown result type (might be due to invalid IL or missing references)
		//IL_014c: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_024c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0251: Unknown result type (might be due to invalid IL or missing references)
		//IL_025c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0263: Unknown result type (might be due to invalid IL or missing references)
		//IL_0265: Unknown result type (might be due to invalid IL or missing references)
		//IL_026a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0276: Expected O, but got Unknown
		//IL_0310: Unknown result type (might be due to invalid IL or missing references)
		//IL_0344: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0404: Unknown result type (might be due to invalid IL or missing references)
		//IL_040b: Unknown result type (might be due to invalid IL or missing references)
		//IL_040e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0413: Unknown result type (might be due to invalid IL or missing references)
		//IL_0423: Expected O, but got Unknown
		//IL_042b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0432: Unknown result type (might be due to invalid IL or missing references)
		//IL_0465: Unknown result type (might be due to invalid IL or missing references)
		//IL_046c: Expected O, but got Unknown
		//IL_049f: Unknown result type (might be due to invalid IL or missing references)
		//IL_04e3: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Javelin", "javelin");
		Game.Items.Rename("outdated_gun_mods:javelin", "nn:javelin");
		((Component)val).gameObject.AddComponent<Javelin>();
		GunExt.SetShortDescription((PickupObject)(object)val, "Tap To Stab");
		GunExt.SetLongDescription((PickupObject)(object)val, "A sharp stick.\n\nThings don't really have to be that complicated.");
		val.SetGunSprites("javelin", 8, noAmmonomicon: false, 2);
		ThrowAnim = GunExt.UpdateAnimation(val, "throw", Initialisation.gunCollection2, true);
		GunExt.SetAnimationFPS(val, ThrowAnim, 12);
		((Component)val).GetComponent<tk2dSpriteAnimator>().GetClipByName(val.chargeAnimation).wrapMode = (WrapMode)1;
		((Component)val).GetComponent<tk2dSpriteAnimator>().GetClipByName(val.chargeAnimation).loopStart = 7;
		PickupObject byId = PickupObjectDatabase.GetById(56);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId is Gun) ? byId : null), true, false);
		ref string gunSwitchGroup = ref val.gunSwitchGroup;
		PickupObject byId2 = PickupObjectDatabase.GetById(8);
		gunSwitchGroup = ((Gun)((byId2 is Gun) ? byId2 : null)).gunSwitchGroup;
		ItemBuilder.AddPassiveStatModifier((PickupObject)(object)val, (StatType)14, 1f, (ModifyMethod)0);
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.shootStyle = (ShootStyle)3;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 1f;
		val.DefaultModule.cooldownTime = 0.5f;
		val.DefaultModule.numberOfShotsInClip = 1;
		val.SetBarrel(82, 31);
		val.SetBaseMaxAmmo(12);
		val.gunClass = (GunClass)60;
		Projectile val2 = ProjectileSetupUtility.MakeProjectile(56, 15f);
		((Component)val2).gameObject.AddComponent<DrainClipBehav>().shotsToDrain = -1;
		((BraveBehaviour)((BraveBehaviour)val2).sprite).renderer.enabled = false;
		ProjectileSlashingBehaviour val3 = ((Component)val2).gameObject.AddComponent<ProjectileSlashingBehaviour>();
		val3.DestroyBaseAfterFirstSlash = true;
		val3.slashParameters = ScriptableObject.CreateInstance<SlashData>();
		val3.slashParameters.soundEvent = null;
		val3.slashParameters.projInteractMode = (ProjInteractMode)0;
		val3.SlashDamageUsesBaseProjectileDamage = true;
		val3.slashParameters.doVFX = true;
		val3.slashParameters.doHitVFX = true;
		val3.slashParameters.VFX = VFXToolbox.CreateVFXPoolBundle("JavelinSlash", usesZHeight: false, 0f, (VFXAlignment)0, -1f, null);
		val3.slashParameters.slashRange = 3f;
		val3.slashParameters.slashDegrees = 5f;
		val3.slashParameters.playerKnockbackForce = 0f;
		val.DefaultModule.chargeProjectiles.Add(new ChargeProjectile
		{
			ChargeTime = 0f,
			Projectile = val2,
			UsedProperties = (ChargeProjectileProperties)1,
			AmmoCost = 0
		});
		Projectile val4 = ProjectileSetupUtility.MakeProjectile(56, 25f);
		((Object)((Component)val4).gameObject).name = "Thrown_Javelin";
		val4.SetProjectileSprite("woodenjavelin_projectile", 38, 4, lightened: false, (Anchor)4, 36, 2, anchorChangesCollider: true, fixesScale: false, null, null);
		ProjectileData baseData = val4.baseData;
		baseData.force *= 2f;
		ProjectileData baseData2 = val4.baseData;
		baseData2.speed *= 2f;
		GameObject val5 = VFXToolbox.CreateVFXBundle("JavelinSticky", new IntVector2(31, 2), (Anchor)3, usesZHeight: true, 0.4f, -1f, null);
		BuffVFXAnimator val6 = val5.gameObject.AddComponent<BuffVFXAnimator>();
		val6.animationStyle = (BuffAnimationStyle)2;
		val6.AdditionalPierceDepth = 0f;
		SimpleStickInEnemyHandler simpleStickInEnemyHandler = ((Component)val4).gameObject.AddComponent<SimpleStickInEnemyHandler>();
		simpleStickInEnemyHandler.stickyToSpawn = val5;
		val4.hitEffects.deathTileMapHorizontal = VFXToolbox.CreateVFXPoolBundle("JavelinImpact", usesZHeight: false, 0f, (VFXAlignment)1, -1f, null, persist: true);
		val4.hitEffects.deathTileMapVertical = val4.hitEffects.deathTileMapHorizontal;
		val4.hitEffects.enemy = VFXToolbox.CreateBlankVFXPool(SharedVFX.BloodImpactVFX);
		val4.hitEffects.HasProjectileDeathVFX = true;
		ProjWeaknessModifier projWeaknessModifier = ((Component)val4).gameObject.AddComponent<ProjWeaknessModifier>();
		projWeaknessModifier.chanceToApply = 1f;
		val.DefaultModule.chargeProjectiles.Add(new ChargeProjectile
		{
			ChargeTime = 0.75f,
			Projectile = val4,
			UsedProperties = (ChargeProjectileProperties)16,
			OverrideShootAnimation = ThrowAnim
		});
		val.muzzleFlashEffects.type = (VFXPoolType)0;
		val.gunHandedness = (GunHandedness)0;
		val.AddClipSprites("javelin");
		val.CanAttackThroughObjects = true;
		Material val7 = new Material(((BraveBehaviour)((BraveBehaviour)EnemyDatabase.GetOrLoadByName("GunNut")).sprite).renderer.material);
		val7.mainTexture = ((BraveBehaviour)((BraveBehaviour)val).sprite).renderer.material.mainTexture;
		val7.SetColor("_EmissiveColor", new Color(1f, 0.972549f, 0.8f));
		val7.SetFloat("_EmissiveColorPower", 200f);
		val7.SetFloat("_EmissivePower", 200f);
		((BraveBehaviour)((BraveBehaviour)val).sprite).renderer.material = val7;
		((PickupObject)val).quality = (ItemQuality)1;
		Databases.Items.Add(val, (tk2dSpriteCollectionData)null, "ANY");
		ID = ((PickupObject)val).PickupObjectId;
	}

	public override void PostProcessProjectile(Projectile projectile)
	{
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		if (Object.op_Implicit((Object)(object)projectile) && ((Object)((Component)projectile).gameObject).name.Contains("Thrown_Javelin") && Object.op_Implicit((Object)(object)ProjectileUtility.ProjectilePlayerOwner(projectile)))
		{
			if (CustomSynergies.PlayerHasActiveSynergy(ProjectileUtility.ProjectilePlayerOwner(projectile), "Brown And Sticky"))
			{
				ProjectileShootbackMod projectileShootbackMod = ((Component)projectile).gameObject.AddComponent<ProjectileShootbackMod>();
				projectileShootbackMod.prefabToFire = ((Gun)PickupObjectDatabase.GetById(14)).DefaultModule.projectiles[0];
				projectileShootbackMod.shootBackOnTimer = true;
				projectileShootbackMod.timebetweenShootbacks = 0.05f;
			}
			if (CustomSynergies.PlayerHasActiveSynergy(ProjectileUtility.ProjectilePlayerOwner(projectile), "Stick 2 It"))
			{
				((Component)projectile).gameObject.AddComponent<GainAmmoOnHitEnemyModifier>().requireKill = true;
			}
		}
	}

	public override void AutoreloadOnEmptyClip(GameActor owner, Gun gun, ref bool autoreload)
	{
		autoreload = false;
	}
}
