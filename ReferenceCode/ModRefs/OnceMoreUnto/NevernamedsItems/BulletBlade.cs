using System.Collections.Generic;
using Alexandria.ItemAPI;
using Gungeon;
using SaveAPI;
using UnityEngine;

namespace NevernamedsItems;

public class BulletBlade : AdvancedGunBehavior
{
	public static int BulletBladeID;

	public static void Add()
	{
		//IL_0133: Unknown result type (might be due to invalid IL or missing references)
		//IL_013b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0256: Unknown result type (might be due to invalid IL or missing references)
		//IL_025b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0263: Unknown result type (might be due to invalid IL or missing references)
		//IL_0270: Expected O, but got Unknown
		//IL_02b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_034a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0415: Unknown result type (might be due to invalid IL or missing references)
		//IL_03bc: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Bullet Blade", "bulletblade");
		Game.Items.Rename("outdated_gun_mods:bullet_blade", "nn:bullet_blade");
		BulletBlade bulletBlade = ((Component)val).gameObject.AddComponent<BulletBlade>();
		((AdvancedGunBehavior)bulletBlade).preventNormalFireAudio = true;
		((AdvancedGunBehavior)bulletBlade).preventNormalReloadAudio = true;
		GunExt.SetShortDescription((PickupObject)(object)val, "Forged of Pure Bullet");
		GunExt.SetLongDescription((PickupObject)(object)val, "The hefty blade of the fearsome armoured sentinels that tread the Gungeon's Halls.\n\nHas claimed the life of many a careless gungeoneer with it's wide spread.");
		val.SetGunSprites("bulletblade");
		GunExt.SetAnimationFPS(val, val.shootAnimation, 12);
		GunExt.SetAnimationFPS(val, val.chargeAnimation, 6);
		ItemBuilder.AddPassiveStatModifier((PickupObject)(object)val, (StatType)14, 1f, (ModifyMethod)0);
		((Component)val).GetComponent<tk2dSpriteAnimator>().GetClipByName(val.shootAnimation).frames[0].eventAudio = "Play_ENM_gunnut_shockwave_01";
		((Component)val).GetComponent<tk2dSpriteAnimator>().GetClipByName(val.shootAnimation).frames[0].triggerEvent = true;
		for (int i = 0; i < 45; i++)
		{
			PickupObject byId = PickupObjectDatabase.GetById(86);
			GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId is Gun) ? byId : null), true, false);
		}
		foreach (ProjectileModule projectile in val.Volley.projectiles)
		{
			projectile.ammoCost = 1;
			projectile.shootStyle = (ShootStyle)3;
			projectile.sequenceStyle = (ProjectileSequenceStyle)0;
			projectile.cooldownTime = 2.5f;
			projectile.angleVariance = 70f;
			projectile.numberOfShotsInClip = 1;
			Projectile val2 = Object.Instantiate<Projectile>(projectile.projectiles[0]);
			projectile.projectiles[0] = val2;
			((Component)val2).gameObject.SetActive(false);
			FakePrefab.MarkAsFakePrefab(((Component)val2).gameObject);
			Object.DontDestroyOnLoad((Object)(object)val2);
			ProjectileData baseData = val2.baseData;
			baseData.damage *= 1.6f;
			ProjectileData baseData2 = val2.baseData;
			baseData2.speed *= 0.6f;
			ProjectileData baseData3 = val2.baseData;
			baseData3.range *= 1f;
			val2.SetProjectileSprite("enemystyle_projectile", 10, 10, lightened: true, (Anchor)4, 8, 8, anchorChangesCollider: true, fixesScale: false, null, null);
			if (projectile != val.DefaultModule)
			{
				projectile.ammoCost = 0;
			}
			((BraveBehaviour)val2).transform.parent = val.barrelOffset;
			ChargeProjectile item = new ChargeProjectile
			{
				Projectile = val2,
				ChargeTime = 1f
			};
			projectile.chargeProjectiles = new List<ChargeProjectile> { item };
		}
		val.reloadTime = 1f;
		val.SetBaseMaxAmmo(50);
		((PickupObject)val).quality = (ItemQuality)3;
		val.gunClass = (GunClass)60;
		((Component)val).GetComponent<tk2dSpriteAnimator>().GetClipByName(val.chargeAnimation).wrapMode = (WrapMode)1;
		((Component)val).GetComponent<tk2dSpriteAnimator>().GetClipByName(val.chargeAnimation).loopStart = 4;
		tk2dSpriteAnimationClip clipByName = ((Component)val).GetComponent<tk2dSpriteAnimator>().GetClipByName(val.chargeAnimation);
		tk2dSpriteAnimationFrame[] frames = clipByName.frames;
		foreach (tk2dSpriteAnimationFrame val3 in frames)
		{
			tk2dSpriteDefinition val4 = val3.spriteCollection.spriteDefinitions[val3.spriteId];
			if (val4 != null)
			{
				GunTools.MakeOffset(val4, new Vector2(-0.56f, -2.31f), false);
			}
		}
		tk2dSpriteAnimationClip clipByName2 = ((Component)val).GetComponent<tk2dSpriteAnimator>().GetClipByName(val.shootAnimation);
		tk2dSpriteAnimationFrame[] frames2 = clipByName2.frames;
		foreach (tk2dSpriteAnimationFrame val5 in frames2)
		{
			tk2dSpriteDefinition val6 = val5.spriteCollection.spriteDefinitions[val5.spriteId];
			if (val6 != null)
			{
				GunTools.MakeOffset(val6, new Vector2(-0.56f, -2.31f), false);
			}
		}
		((BraveBehaviour)val).encounterTrackable.EncounterGuid = "this is the Bullet Blade";
		Databases.Items.Add(val, (tk2dSpriteCollectionData)null, "ANY");
		((Component)val.barrelOffset).transform.localPosition = new Vector3(3.18f, -0.31f, 0f);
		BulletBladeID = ((PickupObject)val).PickupObjectId;
		((PickupObject)(object)val).SetupUnlockOnCustomFlag(CustomDungeonFlags.JAMMEDGUNNUT_QUEST_REWARDED, requiredFlagValue: true);
	}

	public override void PostProcessProjectile(Projectile projectile)
	{
		((AdvancedGunBehavior)this).PostProcessProjectile(projectile);
	}
}
