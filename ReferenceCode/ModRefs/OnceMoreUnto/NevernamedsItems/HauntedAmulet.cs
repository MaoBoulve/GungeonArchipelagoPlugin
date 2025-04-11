using System.Collections.Generic;
using Alexandria.Assetbundle;
using Alexandria.ItemAPI;
using Alexandria.Misc;
using UnityEngine;

namespace NevernamedsItems;

public class HauntedAmulet : PassiveItem
{
	public static int ID;

	public static Projectile blinky;

	public static Projectile pinky;

	public static Projectile inky;

	public static Projectile clyde;

	public static void Init()
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0071: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_02df: Unknown result type (might be due to invalid IL or missing references)
		//IL_04e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_051c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0720: Unknown result type (might be due to invalid IL or missing references)
		//IL_0759: Unknown result type (might be due to invalid IL or missing references)
		PickupObject val = ItemSetup.NewItem<HauntedAmulet>("Haunted Amulet", "Spirit Shaker", "Summons phantoms from the bodies of the slain.\n\nOriginally worn by the necrogunsmith Nuign to pacify the souls used in his accursed experiments.", "hauntedamulet_icon", assetbundle: true);
		val.quality = (ItemQuality)2;
		ID = val.PickupObjectId;
		PickupObject byId = PickupObjectDatabase.GetById(86);
		blinky = ProjectileUtility.InstantiateAndFakeprefab(((Gun)((byId is Gun) ? byId : null)).DefaultModule.projectiles[0]);
		ProjectileBuilders.AnimateProjectileBundle(blinky, "GhostProjectileBlinky", Initialisation.ProjectileCollection, Initialisation.projectileAnimationCollection, "GhostProjectileBlinky", MiscTools.DupeList<IntVector2>(new IntVector2(14, 27), 5), MiscTools.DupeList(value: false, 5), MiscTools.DupeList<Anchor>((Anchor)4, 5), MiscTools.DupeList(value: true, 5), MiscTools.DupeList(value: false, 5), MiscTools.DupeList<Vector3?>(null, 5), MiscTools.DupeList((IntVector2?)new IntVector2(8, 8), 5), MiscTools.DupeList<IntVector2?>(null, 5), MiscTools.DupeList<Projectile>(null, 5));
		ProjectileData baseData = blinky.baseData;
		baseData.speed *= 0.2f;
		blinky.baseData.force = 0f;
		blinky.baseData.damage = 15f;
		PierceProjModifier orAddComponent = GameObjectExtensions.GetOrAddComponent<PierceProjModifier>(((Component)blinky).gameObject);
		orAddComponent.penetration += 3;
		orAddComponent.penetratesBreakables = true;
		blinky.PenetratesInternalWalls = true;
		HomingModifier orAddComponent2 = GameObjectExtensions.GetOrAddComponent<HomingModifier>(((Component)blinky).gameObject);
		orAddComponent2.AngularVelocity = 360f;
		orAddComponent2.HomingRadius = 100f;
		BounceProjModifier orAddComponent3 = GameObjectExtensions.GetOrAddComponent<BounceProjModifier>(((Component)blinky).gameObject);
		orAddComponent3.numberOfBounces = 1;
		blinky.baseData.UsesCustomAccelerationCurve = true;
		ref AnimationCurve accelerationCurve = ref blinky.baseData.AccelerationCurve;
		PickupObject byId2 = PickupObjectDatabase.GetById(760);
		accelerationCurve = ((Gun)((byId2 is Gun) ? byId2 : null)).DefaultModule.projectiles[0].baseData.AccelerationCurve;
		ref float customAccelerationCurveDuration = ref blinky.baseData.CustomAccelerationCurveDuration;
		PickupObject byId3 = PickupObjectDatabase.GetById(760);
		customAccelerationCurveDuration = ((Gun)((byId3 is Gun) ? byId3 : null)).DefaultModule.projectiles[0].baseData.CustomAccelerationCurveDuration;
		ref float ignoreAccelCurveTime = ref blinky.baseData.IgnoreAccelCurveTime;
		PickupObject byId4 = PickupObjectDatabase.GetById(760);
		ignoreAccelCurveTime = ((Gun)((byId4 is Gun) ? byId4 : null)).DefaultModule.projectiles[0].baseData.IgnoreAccelCurveTime;
		blinky.hitEffects.overrideMidairDeathVFX = SharedVFX.ColouredPoofRed;
		blinky.hitEffects.alwaysUseMidair = true;
		PickupObject byId5 = PickupObjectDatabase.GetById(86);
		pinky = ProjectileUtility.InstantiateAndFakeprefab(((Gun)((byId5 is Gun) ? byId5 : null)).DefaultModule.projectiles[0]);
		ProjectileBuilders.AnimateProjectileBundle(pinky, "GhostProjectilePinky", Initialisation.ProjectileCollection, Initialisation.projectileAnimationCollection, "GhostProjectilePinky", MiscTools.DupeList<IntVector2>(new IntVector2(14, 27), 5), MiscTools.DupeList(value: false, 5), MiscTools.DupeList<Anchor>((Anchor)4, 5), MiscTools.DupeList(value: true, 5), MiscTools.DupeList(value: false, 5), MiscTools.DupeList<Vector3?>(null, 5), MiscTools.DupeList((IntVector2?)new IntVector2(8, 8), 5), MiscTools.DupeList<IntVector2?>(null, 5), MiscTools.DupeList<Projectile>(null, 5));
		ProjectileData baseData2 = pinky.baseData;
		baseData2.speed *= 0.2f;
		pinky.baseData.force = 0f;
		pinky.baseData.damage = 15f;
		PierceProjModifier orAddComponent4 = GameObjectExtensions.GetOrAddComponent<PierceProjModifier>(((Component)pinky).gameObject);
		orAddComponent4.penetration += 3;
		orAddComponent4.penetratesBreakables = true;
		pinky.PenetratesInternalWalls = true;
		HomingModifier orAddComponent5 = GameObjectExtensions.GetOrAddComponent<HomingModifier>(((Component)pinky).gameObject);
		orAddComponent5.AngularVelocity = 360f;
		orAddComponent5.HomingRadius = 100f;
		BounceProjModifier orAddComponent6 = GameObjectExtensions.GetOrAddComponent<BounceProjModifier>(((Component)pinky).gameObject);
		orAddComponent6.numberOfBounces = 1;
		pinky.baseData.UsesCustomAccelerationCurve = true;
		ref AnimationCurve accelerationCurve2 = ref pinky.baseData.AccelerationCurve;
		PickupObject byId6 = PickupObjectDatabase.GetById(760);
		accelerationCurve2 = ((Gun)((byId6 is Gun) ? byId6 : null)).DefaultModule.projectiles[0].baseData.AccelerationCurve;
		ref float customAccelerationCurveDuration2 = ref pinky.baseData.CustomAccelerationCurveDuration;
		PickupObject byId7 = PickupObjectDatabase.GetById(760);
		customAccelerationCurveDuration2 = ((Gun)((byId7 is Gun) ? byId7 : null)).DefaultModule.projectiles[0].baseData.CustomAccelerationCurveDuration;
		ref float ignoreAccelCurveTime2 = ref pinky.baseData.IgnoreAccelCurveTime;
		PickupObject byId8 = PickupObjectDatabase.GetById(760);
		ignoreAccelCurveTime2 = ((Gun)((byId8 is Gun) ? byId8 : null)).DefaultModule.projectiles[0].baseData.IgnoreAccelCurveTime;
		pinky.hitEffects.overrideMidairDeathVFX = SharedVFX.ColouredPoofPink;
		pinky.hitEffects.alwaysUseMidair = true;
		PickupObject byId9 = PickupObjectDatabase.GetById(86);
		inky = ProjectileUtility.InstantiateAndFakeprefab(((Gun)((byId9 is Gun) ? byId9 : null)).DefaultModule.projectiles[0]);
		ProjectileBuilders.AnimateProjectileBundle(inky, "GhostProjectileInky", Initialisation.ProjectileCollection, Initialisation.projectileAnimationCollection, "GhostProjectileInky", MiscTools.DupeList<IntVector2>(new IntVector2(14, 27), 5), MiscTools.DupeList(value: false, 5), MiscTools.DupeList<Anchor>((Anchor)4, 5), MiscTools.DupeList(value: true, 5), MiscTools.DupeList(value: false, 5), MiscTools.DupeList<Vector3?>(null, 5), MiscTools.DupeList((IntVector2?)new IntVector2(8, 8), 5), MiscTools.DupeList<IntVector2?>(null, 5), MiscTools.DupeList<Projectile>(null, 5));
		ProjectileData baseData3 = inky.baseData;
		baseData3.speed *= 0.2f;
		inky.baseData.force = 0f;
		inky.baseData.damage = 15f;
		PierceProjModifier orAddComponent7 = GameObjectExtensions.GetOrAddComponent<PierceProjModifier>(((Component)inky).gameObject);
		orAddComponent7.penetration += 3;
		orAddComponent7.penetratesBreakables = true;
		inky.PenetratesInternalWalls = true;
		HomingModifier orAddComponent8 = GameObjectExtensions.GetOrAddComponent<HomingModifier>(((Component)inky).gameObject);
		orAddComponent8.AngularVelocity = 360f;
		orAddComponent8.HomingRadius = 100f;
		BounceProjModifier orAddComponent9 = GameObjectExtensions.GetOrAddComponent<BounceProjModifier>(((Component)inky).gameObject);
		orAddComponent9.numberOfBounces = 1;
		inky.baseData.UsesCustomAccelerationCurve = true;
		ref AnimationCurve accelerationCurve3 = ref inky.baseData.AccelerationCurve;
		PickupObject byId10 = PickupObjectDatabase.GetById(760);
		accelerationCurve3 = ((Gun)((byId10 is Gun) ? byId10 : null)).DefaultModule.projectiles[0].baseData.AccelerationCurve;
		ref float customAccelerationCurveDuration3 = ref inky.baseData.CustomAccelerationCurveDuration;
		PickupObject byId11 = PickupObjectDatabase.GetById(760);
		customAccelerationCurveDuration3 = ((Gun)((byId11 is Gun) ? byId11 : null)).DefaultModule.projectiles[0].baseData.CustomAccelerationCurveDuration;
		ref float ignoreAccelCurveTime3 = ref inky.baseData.IgnoreAccelCurveTime;
		PickupObject byId12 = PickupObjectDatabase.GetById(760);
		ignoreAccelCurveTime3 = ((Gun)((byId12 is Gun) ? byId12 : null)).DefaultModule.projectiles[0].baseData.IgnoreAccelCurveTime;
		inky.hitEffects.overrideMidairDeathVFX = SharedVFX.ColouredPoofCyan;
		inky.hitEffects.alwaysUseMidair = true;
		PickupObject byId13 = PickupObjectDatabase.GetById(86);
		clyde = ProjectileUtility.InstantiateAndFakeprefab(((Gun)((byId13 is Gun) ? byId13 : null)).DefaultModule.projectiles[0]);
		ProjectileBuilders.AnimateProjectileBundle(clyde, "GhostProjectileClyde", Initialisation.ProjectileCollection, Initialisation.projectileAnimationCollection, "GhostProjectileClyde", MiscTools.DupeList<IntVector2>(new IntVector2(14, 27), 5), MiscTools.DupeList(value: false, 5), MiscTools.DupeList<Anchor>((Anchor)4, 5), MiscTools.DupeList(value: true, 5), MiscTools.DupeList(value: false, 5), MiscTools.DupeList<Vector3?>(null, 5), MiscTools.DupeList((IntVector2?)new IntVector2(8, 8), 5), MiscTools.DupeList<IntVector2?>(null, 5), MiscTools.DupeList<Projectile>(null, 5));
		ProjectileData baseData4 = clyde.baseData;
		baseData4.speed *= 0.2f;
		clyde.baseData.force = 0f;
		clyde.baseData.damage = 15f;
		PierceProjModifier orAddComponent10 = GameObjectExtensions.GetOrAddComponent<PierceProjModifier>(((Component)clyde).gameObject);
		orAddComponent10.penetration += 3;
		orAddComponent10.penetratesBreakables = true;
		clyde.PenetratesInternalWalls = true;
		HomingModifier orAddComponent11 = GameObjectExtensions.GetOrAddComponent<HomingModifier>(((Component)clyde).gameObject);
		orAddComponent11.AngularVelocity = 360f;
		orAddComponent11.HomingRadius = 100f;
		BounceProjModifier orAddComponent12 = GameObjectExtensions.GetOrAddComponent<BounceProjModifier>(((Component)clyde).gameObject);
		orAddComponent12.numberOfBounces = 1;
		clyde.baseData.UsesCustomAccelerationCurve = true;
		ref AnimationCurve accelerationCurve4 = ref clyde.baseData.AccelerationCurve;
		PickupObject byId14 = PickupObjectDatabase.GetById(760);
		accelerationCurve4 = ((Gun)((byId14 is Gun) ? byId14 : null)).DefaultModule.projectiles[0].baseData.AccelerationCurve;
		ref float customAccelerationCurveDuration4 = ref clyde.baseData.CustomAccelerationCurveDuration;
		PickupObject byId15 = PickupObjectDatabase.GetById(760);
		customAccelerationCurveDuration4 = ((Gun)((byId15 is Gun) ? byId15 : null)).DefaultModule.projectiles[0].baseData.CustomAccelerationCurveDuration;
		ref float ignoreAccelCurveTime4 = ref clyde.baseData.IgnoreAccelCurveTime;
		PickupObject byId16 = PickupObjectDatabase.GetById(760);
		ignoreAccelCurveTime4 = ((Gun)((byId16 is Gun) ? byId16 : null)).DefaultModule.projectiles[0].baseData.IgnoreAccelCurveTime;
		clyde.hitEffects.overrideMidairDeathVFX = SharedVFX.ColouredPoofOrange;
		clyde.hitEffects.alwaysUseMidair = true;
	}

	public void OnKilledEnemy(PlayerController player, HealthHaver enemy)
	{
		//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0163: Unknown result type (might be due to invalid IL or missing references)
		//IL_0168: Unknown result type (might be due to invalid IL or missing references)
		float num = 0.5f;
		Projectile val = StandardisedProjectiles.ghost;
		if (CustomSynergies.PlayerHasActiveSynergy(player, "Pac is Back!"))
		{
			List<Projectile> list = new List<Projectile> { pinky, blinky, inky, clyde };
			val = BraveUtility.RandomElement<Projectile>(list);
			num = 1f;
		}
		if (!(Random.value <= num))
		{
			return;
		}
		int num2 = 1;
		if (CustomSynergies.PlayerHasActiveSynergy(player, "Spectrecular"))
		{
			num2++;
		}
		for (int i = 0; i < num2; i++)
		{
			GameObject val2 = ProjectileUtility.InstantiateAndFireInDirection(val, ((BraveBehaviour)enemy).specRigidbody.UnitCenter, (float)Random.Range(0, 360), 0f, (PlayerController)null);
			Projectile component = val2.GetComponent<Projectile>();
			component.Owner = (GameActor)(object)player;
			ProjectileData baseData = component.baseData;
			baseData.range *= 10f;
			component.Shooter = ((BraveBehaviour)player).specRigidbody;
			((BraveBehaviour)component).specRigidbody.RegisterGhostCollisionException(((BraveBehaviour)enemy).specRigidbody);
			player.DoPostProcessProjectile(component);
			if (CustomSynergies.PlayerHasActiveSynergy(player, "Spectrecular"))
			{
				ChainLightningModifier orAddComponent = GameObjectExtensions.GetOrAddComponent<ChainLightningModifier>(((Component)component).gameObject);
				ref GameObject linkVFXPrefab = ref orAddComponent.LinkVFXPrefab;
				PickupObject byId = PickupObjectDatabase.GetById(298);
				linkVFXPrefab = ((ComplexProjectileModifier)((byId is ComplexProjectileModifier) ? byId : null)).ChainLightningVFX;
				ref CoreDamageTypes damageTypes = ref orAddComponent.damageTypes;
				PickupObject byId2 = PickupObjectDatabase.GetById(298);
				damageTypes = ((ComplexProjectileModifier)((byId2 is ComplexProjectileModifier) ? byId2 : null)).ChainLightningDamageTypes;
				ref float maximumLinkDistance = ref orAddComponent.maximumLinkDistance;
				PickupObject byId3 = PickupObjectDatabase.GetById(298);
				maximumLinkDistance = ((ComplexProjectileModifier)((byId3 is ComplexProjectileModifier) ? byId3 : null)).ChainLightningMaxLinkDistance;
				ref float damagePerHit = ref orAddComponent.damagePerHit;
				PickupObject byId4 = PickupObjectDatabase.GetById(298);
				damagePerHit = ((ComplexProjectileModifier)((byId4 is ComplexProjectileModifier) ? byId4 : null)).ChainLightningDamagePerHit;
				ref float damageCooldown = ref orAddComponent.damageCooldown;
				PickupObject byId5 = PickupObjectDatabase.GetById(298);
				damageCooldown = ((ComplexProjectileModifier)((byId5 is ComplexProjectileModifier) ? byId5 : null)).ChainLightningDamageCooldown;
				orAddComponent.UsesDispersalParticles = false;
				ProjectileData baseData2 = component.baseData;
				baseData2.damage *= 0.5f;
				component.RuntimeUpdateScale(0.75f);
			}
		}
	}

	public override void Pickup(PlayerController player)
	{
		((PassiveItem)this).Pickup(player);
		player.OnKilledEnemyContext += OnKilledEnemy;
	}

	public override void DisableEffect(PlayerController player)
	{
		if ((Object)(object)player != (Object)null)
		{
			player.OnKilledEnemyContext -= OnKilledEnemy;
		}
		((PassiveItem)this).DisableEffect(player);
	}
}
