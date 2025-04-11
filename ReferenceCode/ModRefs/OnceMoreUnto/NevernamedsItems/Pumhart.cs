using System.Collections.Generic;
using Alexandria.ItemAPI;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class Pumhart : AdvancedGunBehavior
{
	public static int PumhartID;

	public static void Add()
	{
		//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_012d: Unknown result type (might be due to invalid IL or missing references)
		//IL_014c: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0302: Expected O, but got Unknown
		//IL_031d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0346: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_0476: Unknown result type (might be due to invalid IL or missing references)
		//IL_0480: Expected O, but got Unknown
		//IL_042e: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Pumhart", "pumhart");
		Game.Items.Rename("outdated_gun_mods:pumhart", "nn:pumhart");
		Pumhart pumhart = ((Component)val).gameObject.AddComponent<Pumhart>();
		GunExt.SetShortDescription((PickupObject)(object)val, "Mega Bore");
		GunExt.SetLongDescription((PickupObject)(object)val, "A magnificent example of bombard weaponry, built to slay giants!\n\nNormally impossible for a single person to wield, Gunymede's reduced gravity somewhat allows this ridiculous feat.");
		val.SetGunSprites("pumhart");
		GunExt.SetAnimationFPS(val, val.chargeAnimation, 1);
		PickupObject byId = PickupObjectDatabase.GetById(86);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId is Gun) ? byId : null), true, false);
		ItemBuilder.AddCurrentGunStatModifier(val, (StatType)0, 0.6f, (ModifyMethod)1);
		ItemBuilder.AddCurrentGunStatModifier(val, (StatType)28, 0.6f, (ModifyMethod)1);
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.shootStyle = (ShootStyle)3;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 5f;
		ref VFXPool muzzleFlashEffects = ref val.muzzleFlashEffects;
		PickupObject byId2 = PickupObjectDatabase.GetById(486);
		muzzleFlashEffects = ((Gun)((byId2 is Gun) ? byId2 : null)).muzzleFlashEffects;
		val.DefaultModule.cooldownTime = 5f;
		val.DefaultModule.angleVariance = 0f;
		val.DefaultModule.numberOfShotsInClip = 1;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(6.43f, 1.81f, 0f);
		val.SetBaseMaxAmmo(10);
		val.ammo = 10;
		val.gunClass = (GunClass)60;
		Projectile val2 = Object.Instantiate<Projectile>(val.DefaultModule.projectiles[0]);
		((Component)val2).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val2).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val2);
		val2.baseData.damage = 150f;
		ProjectileData baseData = val2.baseData;
		baseData.force *= 10f;
		ProjectileData baseData2 = val2.baseData;
		baseData2.speed *= 1f;
		val2.baseData.range = 10000f;
		PierceProjModifier orAddComponent = GameObjectExtensions.GetOrAddComponent<PierceProjModifier>(((Component)val2).gameObject);
		orAddComponent.penetration += 140;
		MaintainDamageOnPierce orAddComponent2 = GameObjectExtensions.GetOrAddComponent<MaintainDamageOnPierce>(((Component)val2).gameObject);
		orAddComponent.penetratesBreakables = true;
		BlockEnemyProjectilesMod orAddComponent3 = GameObjectExtensions.GetOrAddComponent<BlockEnemyProjectilesMod>(((Component)val2).gameObject);
		orAddComponent3.projectileSurvives = true;
		BounceProjModifier orAddComponent4 = GameObjectExtensions.GetOrAddComponent<BounceProjModifier>(((Component)val2).gameObject);
		orAddComponent4.numberOfBounces += 140;
		ref ScreenShakeSettings additionalScreenShake = ref orAddComponent4.additionalScreenShake;
		PickupObject byId3 = PickupObjectDatabase.GetById(37);
		additionalScreenShake = ((Component)((Gun)((byId3 is Gun) ? byId3 : null)).DefaultModule.chargeProjectiles[0].Projectile).GetComponent<BounceProjModifier>().additionalScreenShake;
		ref GameObject overrideMidairDeathVFX = ref val2.hitEffects.overrideMidairDeathVFX;
		PickupObject byId4 = PickupObjectDatabase.GetById(37);
		overrideMidairDeathVFX = ((Gun)((byId4 is Gun) ? byId4 : null)).DefaultModule.chargeProjectiles[0].Projectile.hitEffects.overrideMidairDeathVFX;
		val2.hitEffects.alwaysUseMidair = true;
		val2.SetProjectileSprite("pumhart_proj", 48, 48, lightened: false, (Anchor)4, 30, 30, anchorChangesCollider: true, fixesScale: false, null, null);
		ChargeProjectile item = new ChargeProjectile
		{
			Projectile = val2,
			ChargeTime = 5f
		};
		val.DefaultModule.chargeProjectiles = new List<ChargeProjectile> { item };
		((PickupObject)val).quality = (ItemQuality)5;
		Databases.Items.Add(val, (tk2dSpriteCollectionData)null, "ANY");
		((Component)val).GetComponent<tk2dSpriteAnimator>().GetClipByName(val.chargeAnimation).wrapMode = (WrapMode)1;
		((Component)val).GetComponent<tk2dSpriteAnimator>().GetClipByName(val.chargeAnimation).loopStart = 4;
		tk2dSpriteAnimationClip clipByName = ((Component)val).GetComponent<tk2dSpriteAnimator>().GetClipByName(val.chargeAnimation);
		tk2dSpriteAnimationFrame[] frames = clipByName.frames;
		foreach (tk2dSpriteAnimationFrame val3 in frames)
		{
			tk2dSpriteDefinition val4 = val3.spriteCollection.spriteDefinitions[val3.spriteId];
			if (val4 != null)
			{
				GunTools.MakeOffset(val4, new Vector2(-2.12f, -1.75f), false);
			}
		}
		tk2dSpriteAnimationClip clipByName2 = ((Component)val).GetComponent<tk2dSpriteAnimator>().GetClipByName(val.shootAnimation);
		tk2dSpriteAnimationFrame[] frames2 = clipByName2.frames;
		foreach (tk2dSpriteAnimationFrame val5 in frames2)
		{
			tk2dSpriteDefinition val6 = val5.spriteCollection.spriteDefinitions[val5.spriteId];
			if (val6 != null)
			{
				GunTools.MakeOffset(val6, new Vector2(-2.12f, -1.75f), false);
			}
		}
		ref string gunSwitchGroup = ref val.gunSwitchGroup;
		PickupObject byId5 = PickupObjectDatabase.GetById(37);
		gunSwitchGroup = ((Gun)((byId5 is Gun) ? byId5 : null)).gunSwitchGroup;
		val.gunScreenShake = new ScreenShakeSettings(5f, 1f, 0.5f, 0.5f);
		PumhartID = ((PickupObject)val).PickupObjectId;
	}
}
