using System.Collections.Generic;
using Alexandria.Assetbundle;
using Alexandria.ItemAPI;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class HotGlueGun : GunBehaviour
{
	public static int HotGlueGunID;

	public static void Add()
	{
		//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0109: Unknown result type (might be due to invalid IL or missing references)
		//IL_012e: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_0242: Unknown result type (might be due to invalid IL or missing references)
		//IL_0250: Unknown result type (might be due to invalid IL or missing references)
		//IL_025e: Unknown result type (might be due to invalid IL or missing references)
		//IL_026c: Unknown result type (might be due to invalid IL or missing references)
		//IL_02eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0311: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Hot Glue Gun", "hotgluegun");
		Game.Items.Rename("outdated_gun_mods:hot_glue_gun", "nn:hot_glue_gun");
		((Component)val).gameObject.AddComponent<HotGlueGun>();
		GunExt.SetShortDescription((PickupObject)(object)val, "Ow!.. Heat was Hot!");
		GunExt.SetLongDescription((PickupObject)(object)val, "Glues your foes in place, and has a chance to set them ablaze.\n\nPioneered by amateur guncrafters, and generally considered one of the most painful methods of adhesive application.");
		GunInt.SetupSprite(val, Initialisation.gunCollection, "hotgluegun_idle_001", 8, "hotgluegun_ammonomicon_001");
		ref string gunSwitchGroup = ref val.gunSwitchGroup;
		PickupObject byId = PickupObjectDatabase.GetById(199);
		gunSwitchGroup = ((Gun)((byId is Gun) ? byId : null)).gunSwitchGroup;
		GunExt.SetAnimationFPS(val, val.shootAnimation, 12);
		PickupObject byId2 = PickupObjectDatabase.GetById(86);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId2 is Gun) ? byId2 : null), true, false);
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.shootStyle = (ShootStyle)0;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 0.7f;
		val.DefaultModule.cooldownTime = 0.4f;
		val.DefaultModule.numberOfShotsInClip = 5;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(0.75f, 0.31f, 0f);
		val.SetBaseMaxAmmo(150);
		val.ammo = 150;
		val.gunClass = (GunClass)30;
		Projectile val2 = Object.Instantiate<Projectile>(val.DefaultModule.projectiles[0]);
		((Component)val2).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val2).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val2);
		ProjectileData baseData = val2.baseData;
		baseData.damage *= 1.6f;
		ProjectileData baseData2 = val2.baseData;
		baseData2.speed *= 0.5f;
		ProjectileData baseData3 = val2.baseData;
		baseData3.range *= 0.5f;
		ApplyLockdownBulletBehaviour applyLockdownBulletBehaviour = ((Component)val2).gameObject.AddComponent<ApplyLockdownBulletBehaviour>();
		applyLockdownBulletBehaviour.useSpecialBulletTint = false;
		applyLockdownBulletBehaviour.duration = 5f;
		applyLockdownBulletBehaviour.enemyTintColour = ExtendedColours.paleYellow;
		applyLockdownBulletBehaviour.TintEnemy = true;
		applyLockdownBulletBehaviour.TintCorpse = true;
		applyLockdownBulletBehaviour.corpseTintColour = ExtendedColours.paleYellow;
		ExtremelySimpleStatusEffectBulletBehaviour extremelySimpleStatusEffectBulletBehaviour = ((Component)val2).gameObject.AddComponent<ExtremelySimpleStatusEffectBulletBehaviour>();
		extremelySimpleStatusEffectBulletBehaviour.onHitProcChance = 0.07f;
		extremelySimpleStatusEffectBulletBehaviour.onFiredProcChance = 1f;
		extremelySimpleStatusEffectBulletBehaviour.usesFireEffect = true;
		extremelySimpleStatusEffectBulletBehaviour.fireEffect = StaticStatusEffects.hotLeadEffect;
		ProjectileBuilders.AnimateProjectileBundle(val2, "GlueGunProjectile", Initialisation.ProjectileCollection, Initialisation.projectileAnimationCollection, "GlueGunProjectile", new List<IntVector2>
		{
			new IntVector2(5, 5),
			new IntVector2(4, 6),
			new IntVector2(5, 5),
			new IntVector2(6, 4)
		}, MiscTools.DupeList(value: false, 4), MiscTools.DupeList<Anchor>((Anchor)4, 4), MiscTools.DupeList(value: true, 4), MiscTools.DupeList(value: false, 4), MiscTools.DupeList<Vector3?>(null, 4), MiscTools.DupeList<IntVector2?>(null, 4), MiscTools.DupeList<IntVector2?>(null, 4), MiscTools.DupeList<Projectile>(null, 4));
		val.DefaultModule.projectiles[0] = val2;
		val.DefaultModule.ammoType = (AmmoType)14;
		val.DefaultModule.customAmmoType = CustomClipAmmoTypeToolbox.AddCustomAmmoType("HotGlueGun Bullets", "NevernamedsItems/Resources/CustomGunAmmoTypes/hotgluegun_clipfull", "NevernamedsItems/Resources/CustomGunAmmoTypes/hotgluegun_clipempty");
		((PickupObject)val).quality = (ItemQuality)3;
		Databases.Items.Add((PickupObject)(object)val, false, "ANY");
		HotGlueGunID = ((PickupObject)val).PickupObjectId;
	}

	public override void PostProcessProjectile(Projectile projectile)
	{
		if (!(projectile.Owner is PlayerController))
		{
			return;
		}
		GameActor owner = projectile.Owner;
		PlayerController val = (PlayerController)(object)((owner is PlayerController) ? owner : null);
		if (CustomSynergies.PlayerHasActiveSynergy(val, "Heat Stress"))
		{
			ExtremelySimpleStatusEffectBulletBehaviour component = ((Component)projectile).gameObject.GetComponent<ExtremelySimpleStatusEffectBulletBehaviour>();
			if ((Object)(object)component != (Object)null)
			{
				component.onHitProcChance *= 3f;
			}
		}
		if (CustomSynergies.PlayerHasActiveSynergy(val, "Stick In The Mud"))
		{
			ApplyLockdownBulletBehaviour component2 = ((Component)projectile).gameObject.GetComponent<ApplyLockdownBulletBehaviour>();
			if ((Object)(object)component2 != (Object)null)
			{
				component2.duration *= 2f;
			}
		}
	}
}
