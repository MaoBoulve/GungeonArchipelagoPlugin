using Alexandria.ItemAPI;
using Alexandria.Misc;
using Gungeon;
using SaveAPI;
using UnityEngine;

namespace NevernamedsItems;

public class Carnwennan : AdvancedGunBehavior
{
	public class CarnwennanSlashModifier : ProjectileSlashingBehaviour
	{
		public override void SlashHitTarget(GameActor target, bool fatal)
		{
			//IL_0037: Unknown result type (might be due to invalid IL or missing references)
			//IL_003c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0041: Unknown result type (might be due to invalid IL or missing references)
			float value = Random.value;
			if (fatal && value <= 0.25f)
			{
				LootEngine.SpawnItem(((Component)PickupObjectDatabase.GetById(BraveUtility.RandomElement<int>(LootEngineItem.validIDs))).gameObject, Vector2.op_Implicit(((BraveBehaviour)target).sprite.WorldCenter), Vector2.zero, 0f, true, true, false);
			}
			((ProjectileSlashingBehaviour)this).SlashHitTarget(target, fatal);
		}
	}

	public static int ID;

	public static void Add()
	{
		//IL_00be: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_011c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0132: Unknown result type (might be due to invalid IL or missing references)
		//IL_013a: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0227: Unknown result type (might be due to invalid IL or missing references)
		//IL_0284: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f8: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Carnwennan", "carnwennan");
		Game.Items.Rename("outdated_gun_mods:carnwennan", "nn:carnwennan");
		Carnwennan carnwennan = ((Component)val).gameObject.AddComponent<Carnwennan>();
		ref string gunSwitchGroup = ref val.gunSwitchGroup;
		PickupObject byId = PickupObjectDatabase.GetById(417);
		gunSwitchGroup = ((Gun)((byId is Gun) ? byId : null)).gunSwitchGroup;
		GunExt.SetShortDescription((PickupObject)(object)val, "Prosper");
		GunExt.SetLongDescription((PickupObject)(object)val, "This ancient magical dagger was stolen from the ruins of Castle Blamalot.\n\nWhile both it's range and power are lacking, you sense a strange, bountiful energy in the blade.");
		val.SetGunSprites("carnwennan");
		GunExt.SetAnimationFPS(val, val.shootAnimation, 12);
		ItemBuilder.AddPassiveStatModifier((PickupObject)(object)val, (StatType)14, 1f, (ModifyMethod)0);
		PickupObject byId2 = PickupObjectDatabase.GetById(86);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId2 is Gun) ? byId2 : null), true, false);
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.shootStyle = (ShootStyle)0;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 1.05f;
		val.DefaultModule.cooldownTime = 0.3f;
		val.muzzleFlashEffects.type = (VFXPoolType)0;
		val.DefaultModule.numberOfShotsInClip = 5;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(0.5625f, 0.25f, 0f);
		val.SetBaseMaxAmmo(50);
		((PickupObject)val).quality = (ItemQuality)1;
		val.gunClass = (GunClass)50;
		Projectile val2 = ProjectileUtility.SetupProjectile(86);
		val.DefaultModule.projectiles[0] = val2;
		val.InfiniteAmmo = true;
		val2.baseData.damage = 4f;
		ProjectileData baseData = val2.baseData;
		baseData.speed *= 1.2f;
		((BraveBehaviour)((BraveBehaviour)val2).sprite).renderer.enabled = false;
		CarnwennanSlashModifier carnwennanSlashModifier = ((Component)val2).gameObject.AddComponent<CarnwennanSlashModifier>();
		((ProjectileSlashingBehaviour)carnwennanSlashModifier).DestroyBaseAfterFirstSlash = true;
		((ProjectileSlashingBehaviour)carnwennanSlashModifier).slashParameters = ScriptableObject.CreateInstance<SlashData>();
		((ProjectileSlashingBehaviour)carnwennanSlashModifier).slashParameters.soundEvent = null;
		((ProjectileSlashingBehaviour)carnwennanSlashModifier).slashParameters.projInteractMode = (ProjInteractMode)0;
		((ProjectileSlashingBehaviour)carnwennanSlashModifier).slashParameters.playerKnockbackForce = 0f;
		((ProjectileSlashingBehaviour)carnwennanSlashModifier).SlashDamageUsesBaseProjectileDamage = true;
		((ProjectileSlashingBehaviour)carnwennanSlashModifier).slashParameters.enemyKnockbackForce = 10f;
		((ProjectileSlashingBehaviour)carnwennanSlashModifier).slashParameters.doVFX = false;
		((ProjectileSlashingBehaviour)carnwennanSlashModifier).slashParameters.doHitVFX = true;
		((ProjectileSlashingBehaviour)carnwennanSlashModifier).slashParameters.slashRange = 2f;
		val.DefaultModule.ammoType = (AmmoType)2;
		tk2dSpriteAnimationClip clipByName = ((Component)val).GetComponent<tk2dSpriteAnimator>().GetClipByName(val.reloadAnimation);
		tk2dSpriteAnimationFrame[] frames = clipByName.frames;
		foreach (tk2dSpriteAnimationFrame val3 in frames)
		{
			tk2dSpriteDefinition val4 = val3.spriteCollection.spriteDefinitions[val3.spriteId];
			if (val4 != null)
			{
				GunTools.MakeOffset(val4, new Vector2(-0.81f, -2.18f), false);
			}
		}
		tk2dSpriteAnimationClip clipByName2 = ((Component)val).GetComponent<tk2dSpriteAnimator>().GetClipByName(val.shootAnimation);
		tk2dSpriteAnimationFrame[] frames2 = clipByName2.frames;
		foreach (tk2dSpriteAnimationFrame val5 in frames2)
		{
			tk2dSpriteDefinition val6 = val5.spriteCollection.spriteDefinitions[val5.spriteId];
			if (val6 != null)
			{
				GunTools.MakeOffset(val6, new Vector2(-0.81f, -2.18f), false);
			}
		}
		Databases.Items.Add((PickupObject)(object)val, false, "ANY");
		ID = ((PickupObject)val).PickupObjectId;
		((PickupObject)(object)val).SetupUnlockOnCustomFlag(CustomDungeonFlags.BOSSRUSH_BULLET, requiredFlagValue: true);
	}
}
