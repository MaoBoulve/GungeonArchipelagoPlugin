using System.Collections.Generic;
using Alexandria.Assetbundle;
using Alexandria.ItemAPI;
using Alexandria.Misc;
using UnityEngine;

namespace NevernamedsItems;

public static class StandardisedProjectiles
{
	private class IsCorpseWithSynergy : MonoBehaviour
	{
		public void Start()
		{
			if (GameManagerUtility.AnyPlayerHasActiveSynergy(GameManager.Instance, "Rock Python"))
			{
				StaticReferenceManager.AllCorpses.Add(((Component)this).gameObject);
			}
		}
	}

	public static Projectile snake;

	public static Projectile smoke;

	public static Projectile ghost;

	public static Projectile flamethrower;

	public static void Init()
	{
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0103: Unknown result type (might be due to invalid IL or missing references)
		//IL_022d: Unknown result type (might be due to invalid IL or missing references)
		//IL_02af: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_036c: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_045c: Unknown result type (might be due to invalid IL or missing references)
		//IL_049d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0589: Unknown result type (might be due to invalid IL or missing references)
		//IL_06af: Unknown result type (might be due to invalid IL or missing references)
		//IL_06e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0771: Unknown result type (might be due to invalid IL or missing references)
		//IL_077b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0abd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b08: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b0d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b12: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b53: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b55: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b5c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b5e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b65: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b67: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bf4: Unknown result type (might be due to invalid IL or missing references)
		PickupObject byId = PickupObjectDatabase.GetById(56);
		Projectile val = ProjectileUtility.InstantiateAndFakeprefab(((Gun)((byId is Gun) ? byId : null)).DefaultModule.projectiles[0]);
		ProjectileBuilders.AnimateProjectileBundle(val, "SmokeProjectile", Initialisation.ProjectileCollection, Initialisation.projectileAnimationCollection, "SmokeProjectile", MiscTools.DupeList<IntVector2>(new IntVector2(48, 48), 12), MiscTools.DupeList(value: false, 12), MiscTools.DupeList<Anchor>((Anchor)4, 12), MiscTools.DupeList(value: true, 12), MiscTools.DupeList(value: false, 12), MiscTools.DupeList<Vector3?>(null, 12), MiscTools.DupeList((IntVector2?)new IntVector2(26, 26), 12), MiscTools.DupeList<IntVector2?>(null, 12), MiscTools.DupeList<Projectile>(null, 12));
		((BraveBehaviour)((BraveBehaviour)val).sprite).renderer.material.shader = ShaderCache.Acquire("Brave/LitBlendUber");
		((BraveBehaviour)((BraveBehaviour)val).sprite).renderer.material.SetFloat("_VertexColor", 1f);
		((BraveBehaviour)val).sprite.color = Vector3Extensions.WithAlpha(((BraveBehaviour)val).sprite.color, 0.65f);
		((BraveBehaviour)val).sprite.usesOverrideMaterial = true;
		ProjectileData baseData = val.baseData;
		baseData.speed *= 0.65f;
		val.baseData.force = 0f;
		val.baseData.damage = 1f;
		PierceProjModifier orAddComponent = GameObjectExtensions.GetOrAddComponent<PierceProjModifier>(((Component)val).gameObject);
		orAddComponent.penetration += 100;
		orAddComponent.penetratesBreakables = true;
		BounceProjModifier orAddComponent2 = GameObjectExtensions.GetOrAddComponent<BounceProjModifier>(((Component)val).gameObject);
		orAddComponent2.numberOfBounces = 5;
		SlowDownOverTimeModifier orAddComponent3 = GameObjectExtensions.GetOrAddComponent<SlowDownOverTimeModifier>(((Component)val).gameObject);
		orAddComponent3.extendTimeByRangeStat = true;
		orAddComponent3.killAfterCompleteStop = true;
		orAddComponent3.targetSpeed = 0f;
		orAddComponent3.timeToSlowOver = 1f;
		orAddComponent3.timeTillKillAfterCompleteStop = 20f;
		orAddComponent3.doRandomTimeMultiplier = true;
		GameObjectExtensions.GetOrAddComponent<DieWhenOwnerNotInRoom>(((Component)val).gameObject);
		VFXPool val2 = VFXToolbox.CreateVFXPool("SmokePoof", new List<string> { "NevernamedsItems/Resources/MiscVFX/GunVFX/smokeimpact_vfx_001", "NevernamedsItems/Resources/MiscVFX/GunVFX/smokeimpact_vfx_002", "NevernamedsItems/Resources/MiscVFX/GunVFX/smokeimpact_vfx_003", "NevernamedsItems/Resources/MiscVFX/GunVFX/smokeimpact_vfx_004", "NevernamedsItems/Resources/MiscVFX/GunVFX/smokeimpact_vfx_005", "NevernamedsItems/Resources/MiscVFX/GunVFX/smokeimpact_vfx_006" }, 10, new IntVector2(48, 48), (Anchor)3, usesZHeight: false, 0f, persist: false, (VFXAlignment)1, -1f, null, (WrapMode)2);
		tk2dBaseSprite component = val2.effects[0].effects[0].effect.GetComponent<tk2dBaseSprite>();
		((BraveBehaviour)component).renderer.material.shader = ShaderCache.Acquire("Brave/LitBlendUber");
		((BraveBehaviour)component).renderer.material.SetFloat("_VertexColor", 1f);
		component.color = Vector3Extensions.WithAlpha(((BraveBehaviour)val).sprite.color, 0.65f);
		component.usesOverrideMaterial = true;
		val.hitEffects.tileMapVertical = val2;
		val.hitEffects.tileMapHorizontal = val2;
		val.hitEffects.deathAny = val2;
		val.hitEffects.overrideMidairDeathVFX = val2.effects[0].effects[0].effect;
		VFXPool val3 = VFXToolbox.CreateVFXPool("SmokePoof Small", new List<string> { "NevernamedsItems/Resources/MiscVFX/GunVFX/smokeenemyimpact_vfx_001", "NevernamedsItems/Resources/MiscVFX/GunVFX/smokeenemyimpact_vfx_002", "NevernamedsItems/Resources/MiscVFX/GunVFX/smokeenemyimpact_vfx_003", "NevernamedsItems/Resources/MiscVFX/GunVFX/smokeenemyimpact_vfx_004", "NevernamedsItems/Resources/MiscVFX/GunVFX/smokeenemyimpact_vfx_005", "NevernamedsItems/Resources/MiscVFX/GunVFX/smokeenemyimpact_vfx_006" }, 10, new IntVector2(24, 24), (Anchor)3, usesZHeight: false, 0f, persist: false, (VFXAlignment)1, -1f, null, (WrapMode)2);
		tk2dBaseSprite component2 = val3.effects[0].effects[0].effect.GetComponent<tk2dBaseSprite>();
		((BraveBehaviour)component2).renderer.material.shader = ShaderCache.Acquire("Brave/LitBlendUber");
		((BraveBehaviour)component2).renderer.material.SetFloat("_VertexColor", 1f);
		component2.color = Vector3Extensions.WithAlpha(((BraveBehaviour)val).sprite.color, 0.65f);
		component2.usesOverrideMaterial = true;
		val.hitEffects.enemy = val3;
		smoke = val;
		PickupObject byId2 = PickupObjectDatabase.GetById(56);
		Projectile val4 = ProjectileUtility.InstantiateAndFakeprefab(((Gun)((byId2 is Gun) ? byId2 : null)).DefaultModule.projectiles[0]);
		ProjectileBuilders.AnimateProjectileBundle(val4, "FlamethrowerProjectile", Initialisation.ProjectileCollection, Initialisation.projectileAnimationCollection, "FlamethrowerProjectile", MiscTools.DupeList<IntVector2>(new IntVector2(32, 31), 13), MiscTools.DupeList(value: false, 13), MiscTools.DupeList<Anchor>((Anchor)4, 13), MiscTools.DupeList(value: true, 13), MiscTools.DupeList(value: false, 13), MiscTools.DupeList<Vector3?>(null, 13), MiscTools.DupeList((IntVector2?)new IntVector2(18, 18), 13), MiscTools.DupeList<IntVector2?>(null, 13), MiscTools.DupeList<Projectile>(null, 13));
		ProjectileData baseData2 = val4.baseData;
		baseData2.speed *= 0.65f;
		val4.baseData.force = 0f;
		val4.baseData.damage = 2f;
		val4.baseData.range = 16f;
		val4.AppliesFire = true;
		val4.FireApplyChance = 1f;
		val4.fireEffect = StaticStatusEffects.hotLeadEffect;
		PierceProjModifier orAddComponent4 = GameObjectExtensions.GetOrAddComponent<PierceProjModifier>(((Component)val4).gameObject);
		orAddComponent4.penetration += 100;
		orAddComponent4.penetratesBreakables = true;
		BulletLifeTimer orAddComponent5 = GameObjectExtensions.GetOrAddComponent<BulletLifeTimer>(((Component)val4).gameObject);
		orAddComponent5.secondsTillDeath = 1f;
		ParticleShitter orAddComponent6 = GameObjectExtensions.GetOrAddComponent<ParticleShitter>(((Component)val4).gameObject);
		orAddComponent6.particleType = (SparksType)5;
		VFXPool val5 = VFXToolbox.CreateBlankVFXPool();
		ref GameObject effect = ref val5.effects[0].effects[0].effect;
		PickupObject byId3 = PickupObjectDatabase.GetById(336);
		effect = ((Gun)((byId3 is Gun) ? byId3 : null)).DefaultModule.projectiles[0].hitEffects.overrideMidairDeathVFX;
		val4.hitEffects.tileMapVertical = smoke.hitEffects.tileMapVertical;
		val4.hitEffects.tileMapHorizontal = smoke.hitEffects.tileMapHorizontal;
		val4.hitEffects.deathAny = smoke.hitEffects.deathAny;
		val4.hitEffects.overrideMidairDeathVFX = smoke.hitEffects.overrideMidairDeathVFX;
		val4.hitEffects.enemy = val5;
		val4.enemyImpactEventName = "flame";
		val4.objectImpactEventName = "flame";
		flamethrower = val4;
		PickupObject byId4 = PickupObjectDatabase.GetById(86);
		ghost = ProjectileUtility.InstantiateAndFakeprefab(((Gun)((byId4 is Gun) ? byId4 : null)).DefaultModule.projectiles[0]);
		ProjectileBuilders.AnimateProjectileBundle(ghost, "GhostProjectile", Initialisation.ProjectileCollection, Initialisation.projectileAnimationCollection, "GhostProjectile", MiscTools.DupeList<IntVector2>(new IntVector2(14, 27), 5), MiscTools.DupeList(value: false, 5), MiscTools.DupeList<Anchor>((Anchor)4, 5), MiscTools.DupeList(value: true, 5), MiscTools.DupeList(value: false, 5), MiscTools.DupeList<Vector3?>(null, 5), MiscTools.DupeList((IntVector2?)new IntVector2(8, 8), 5), MiscTools.DupeList<IntVector2?>(null, 5), MiscTools.DupeList<Projectile>(null, 5));
		((BraveBehaviour)((BraveBehaviour)ghost).sprite).renderer.material.shader = ShaderCache.Acquire("Brave/LitBlendUber");
		((BraveBehaviour)((BraveBehaviour)ghost).sprite).renderer.material.SetFloat("_VertexColor", 1f);
		((BraveBehaviour)ghost).sprite.color = Vector3Extensions.WithAlpha(((BraveBehaviour)ghost).sprite.color, 0.8f);
		((BraveBehaviour)ghost).sprite.usesOverrideMaterial = true;
		ProjectileData baseData3 = ghost.baseData;
		baseData3.speed *= 0.2f;
		ghost.baseData.force = 0f;
		ghost.baseData.damage = 15f;
		PierceProjModifier orAddComponent7 = GameObjectExtensions.GetOrAddComponent<PierceProjModifier>(((Component)ghost).gameObject);
		orAddComponent7.penetration += 3;
		orAddComponent7.penetratesBreakables = true;
		ghost.PenetratesInternalWalls = true;
		HomingModifier orAddComponent8 = GameObjectExtensions.GetOrAddComponent<HomingModifier>(((Component)ghost).gameObject);
		orAddComponent8.AngularVelocity = 360f;
		orAddComponent8.HomingRadius = 100f;
		BounceProjModifier orAddComponent9 = GameObjectExtensions.GetOrAddComponent<BounceProjModifier>(((Component)ghost).gameObject);
		orAddComponent9.numberOfBounces = 1;
		ghost.baseData.UsesCustomAccelerationCurve = true;
		ref AnimationCurve accelerationCurve = ref ghost.baseData.AccelerationCurve;
		PickupObject byId5 = PickupObjectDatabase.GetById(760);
		accelerationCurve = ((Gun)((byId5 is Gun) ? byId5 : null)).DefaultModule.projectiles[0].baseData.AccelerationCurve;
		ref float customAccelerationCurveDuration = ref ghost.baseData.CustomAccelerationCurveDuration;
		PickupObject byId6 = PickupObjectDatabase.GetById(760);
		customAccelerationCurveDuration = ((Gun)((byId6 is Gun) ? byId6 : null)).DefaultModule.projectiles[0].baseData.CustomAccelerationCurveDuration;
		ref float ignoreAccelCurveTime = ref ghost.baseData.IgnoreAccelCurveTime;
		PickupObject byId7 = PickupObjectDatabase.GetById(760);
		ignoreAccelCurveTime = ((Gun)((byId7 is Gun) ? byId7 : null)).DefaultModule.projectiles[0].baseData.IgnoreAccelCurveTime;
		ghost.hitEffects.overrideMidairDeathVFX = SharedVFX.ColouredPoofWhite;
		ghost.hitEffects.alwaysUseMidair = true;
		PickupObject byId8 = PickupObjectDatabase.GetById(56);
		Projectile val6 = ProjectileUtility.InstantiateAndFakeprefab(((Gun)((byId8 is Gun) ? byId8 : null)).DefaultModule.projectiles[0]);
		((Component)val6).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val6).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val6);
		val6.baseData.damage = 13f;
		ProjectileData baseData4 = val6.baseData;
		baseData4.force *= 0.2f;
		ProjectileData baseData5 = val6.baseData;
		baseData5.speed *= 0.5f;
		val6.PoisonApplyChance = 0.2f;
		val6.AppliesPoison = true;
		val6.healthEffect = StaticStatusEffects.irradiatedLeadEffect;
		HomingModifier orAddComponent10 = GameObjectExtensions.GetOrAddComponent<HomingModifier>(((Component)val6).gameObject);
		orAddComponent10.AngularVelocity = 360f;
		orAddComponent10.HomingRadius = 100f;
		BounceProjModifier orAddComponent11 = GameObjectExtensions.GetOrAddComponent<BounceProjModifier>(((Component)val6).gameObject);
		orAddComponent11.numberOfBounces = 2;
		PierceProjModifier orAddComponent12 = GameObjectExtensions.GetOrAddComponent<PierceProjModifier>(((Component)val6).gameObject);
		orAddComponent12.penetration = 2;
		val6.pierceMinorBreakables = true;
		((Component)val6).gameObject.AddComponent<ConvertToHelixOnSpawn>();
		val6.SetProjectileSprite("snake_proj", 12, 9, lightened: false, (Anchor)4, 10, 7, anchorChangesCollider: true, fixesScale: false, null, null);
		VFXPool enemy = VFXToolbox.CreateVFXPool("Bite Impact", new List<string> { "NevernamedsItems/Resources/MiscVFX/biteimpact_001", "NevernamedsItems/Resources/MiscVFX/biteimpact_002", "NevernamedsItems/Resources/MiscVFX/biteimpact_003", "NevernamedsItems/Resources/MiscVFX/biteimpact_004", "NevernamedsItems/Resources/MiscVFX/biteimpact_005" }, 13, new IntVector2(27, 17), (Anchor)4, usesZHeight: true, 0.2f, persist: false, (VFXAlignment)0, -1f, null, (WrapMode)2);
		val6.hitEffects.enemy = enemy;
		EasyTrailBullet easyTrailBullet = ((Component)val6).gameObject.AddComponent<EasyTrailBullet>();
		easyTrailBullet.TrailPos = Vector2.op_Implicit(((BraveBehaviour)val6).transform.position);
		easyTrailBullet.StartWidth = 0.25f;
		easyTrailBullet.EndWidth = 0f;
		easyTrailBullet.LifeTime = 0.4f;
		Color val7 = default(Color);
		((Color)(ref val7))._002Ector(0.2784314f, 0.8235294f, 0.19215687f);
		easyTrailBullet.BaseColor = val7;
		easyTrailBullet.StartColor = val7;
		easyTrailBullet.EndColor = val7;
		VFXPool val8 = VFXToolbox.CreateVFXPool("Snake Death", new List<string> { "NevernamedsItems/Resources/MiscVFX/GunVFX/snakeproj_death_001", "NevernamedsItems/Resources/MiscVFX/GunVFX/snakeproj_death_002", "NevernamedsItems/Resources/MiscVFX/GunVFX/snakeproj_death_003", "NevernamedsItems/Resources/MiscVFX/GunVFX/snakeproj_death_004", "NevernamedsItems/Resources/MiscVFX/GunVFX/snakeproj_death_005", "NevernamedsItems/Resources/MiscVFX/GunVFX/snakeproj_death_006", "NevernamedsItems/Resources/MiscVFX/GunVFX/snakeproj_death_007", "NevernamedsItems/Resources/MiscVFX/GunVFX/snakeproj_death_008", "NevernamedsItems/Resources/MiscVFX/GunVFX/snakeproj_death_009", "NevernamedsItems/Resources/MiscVFX/GunVFX/snakeproj_death_010" }, 13, new IntVector2(29, 59), (Anchor)1, usesZHeight: true, -1.73f, persist: true, (VFXAlignment)0, -1f, null, (WrapMode)2);
		val8.effects[0].effects[0].effect.gameObject.AddComponent<IsCorpseWithSynergy>();
		val6.hitEffects.deathAny = val8;
		val6.hitEffects.HasProjectileDeathVFX = true;
		snake = val6;
	}
}
