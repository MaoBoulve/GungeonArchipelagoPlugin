using Alexandria.Assetbundle;
using Alexandria.ItemAPI;
using UnityEngine;

namespace NevernamedsItems;

internal class UltraVioletGuonStone : AdvancedPlayerOrbitalItem
{
	public static PlayerOrbital orbitalPrefab;

	public static PlayerOrbital upgradeOrbitalPrefab;

	public static Projectile xenochromePrefab;

	private float timer;

	public static void Init()
	{
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_0104: Unknown result type (might be due to invalid IL or missing references)
		//IL_013e: Unknown result type (might be due to invalid IL or missing references)
		PickupObject obj = ItemSetup.NewItem<UltraVioletGuonStone>("Ultraviolet Guon Stone", "Beyond the Pale", "A jittery crystal from a realm beyond the Gungeon.\n\nErratically jumps to different orbits.", "ultravioletguonstone_icon", assetbundle: true);
		AdvancedPlayerOrbitalItem val = (AdvancedPlayerOrbitalItem)(object)((obj is AdvancedPlayerOrbitalItem) ? obj : null);
		((PickupObject)val).quality = (ItemQuality)2;
		AlexandriaTags.SetTag((PickupObject)(object)val, "guon_stone");
		BuildPrefab();
		val.OrbitalPrefab = orbitalPrefab;
		BuildSynergyPrefab();
		val.HasAdvancedUpgradeSynergy = true;
		val.AdvancedUpgradeSynergy = "Ultravioleter Guon Stone";
		val.AdvancedUpgradeOrbitalPrefab = ((Component)upgradeOrbitalPrefab).gameObject;
		PickupObject byId = PickupObjectDatabase.GetById(86);
		xenochromePrefab = Object.Instantiate<Projectile>(((Gun)((byId is Gun) ? byId : null)).DefaultModule.projectiles[0]);
		((Component)xenochromePrefab).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)xenochromePrefab).gameObject);
		Object.DontDestroyOnLoad((Object)(object)xenochromePrefab);
		xenochromePrefab.baseData.damage = 20f;
		xenochromePrefab.baseData.speed = 0f;
		ProjectileBuilders.AnimateProjectileBundle(xenochromePrefab, "ThinLinePinkProjectile", Initialisation.ProjectileCollection, Initialisation.projectileAnimationCollection, "ThinLinePinkProjectile", MiscTools.DupeList<IntVector2>(new IntVector2(10, 10), 6), MiscTools.DupeList(value: true, 6), MiscTools.DupeList<Anchor>((Anchor)4, 6), MiscTools.DupeList(value: true, 6), MiscTools.DupeList(value: false, 6), MiscTools.DupeList<Vector3?>(null, 6), MiscTools.DupeList((IntVector2?)new IntVector2(10, 10), 6), MiscTools.DupeList<IntVector2?>(null, 6), MiscTools.DupeList<Projectile>(null, 6));
		BulletLifeTimer bulletLifeTimer = ((Component)xenochromePrefab).gameObject.AddComponent<BulletLifeTimer>();
		bulletLifeTimer.secondsTillDeath = 2f;
		ExplosiveModifier val2 = ((Component)xenochromePrefab).gameObject.AddComponent<ExplosiveModifier>();
		val2.doExplosion = true;
		val2.explosionData = StaticExplosionDatas.explosiveRoundsExplosion;
		val2.IgnoreQueues = true;
	}

	public static void BuildPrefab()
	{
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_0086: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0113: Unknown result type (might be due to invalid IL or missing references)
		//IL_0118: Unknown result type (might be due to invalid IL or missing references)
		//IL_011e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0123: Unknown result type (might be due to invalid IL or missing references)
		if (!((Object)(object)orbitalPrefab != (Object)null))
		{
			GameObject val = ItemBuilder.SpriteFromBundle("UltravioletGuonOrbital", Initialisation.itemCollection.GetSpriteIdByName("ultravioletguon_ingame"), Initialisation.itemCollection, (GameObject)null);
			((Object)val).name = "Ultraviolet Guon Orbital";
			SpeculativeRigidbody val2 = SpriteBuilder.SetUpSpeculativeRigidbody(val.GetComponent<tk2dSprite>(), IntVector2.Zero, new IntVector2(8, 9));
			val2.CollideWithTileMap = false;
			val2.CollideWithOthers = true;
			val2.PrimaryPixelCollider.CollisionLayer = (CollisionLayer)15;
			orbitalPrefab = val.AddComponent<PlayerOrbital>();
			orbitalPrefab.motionStyle = (OrbitalMotionStyle)0;
			orbitalPrefab.shouldRotate = true;
			orbitalPrefab.orbitRadius = 4.1f;
			orbitalPrefab.orbitDegreesPerSecond = 420f;
			orbitalPrefab.SetOrbitalTier(0);
			EasyTrailMisc easyTrailMisc = val.AddComponent<EasyTrailMisc>();
			easyTrailMisc.TrailPos = Vector2.op_Implicit(val.transform.position);
			easyTrailMisc.TrailPos.x += 0.2f;
			easyTrailMisc.StartWidth = 0.2f;
			easyTrailMisc.EndWidth = 0f;
			easyTrailMisc.LifeTime = 0.1f;
			easyTrailMisc.BaseColor = ExtendedColours.charmPink;
			easyTrailMisc.EndColor = ExtendedColours.pink;
			Object.DontDestroyOnLoad((Object)(object)val);
			FakePrefab.MarkAsFakePrefab(val);
			val.SetActive(false);
		}
	}

	public static void BuildSynergyPrefab()
	{
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0120: Unknown result type (might be due to invalid IL or missing references)
		//IL_0125: Unknown result type (might be due to invalid IL or missing references)
		//IL_012c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0131: Unknown result type (might be due to invalid IL or missing references)
		if ((Object)(object)upgradeOrbitalPrefab == (Object)null)
		{
			GameObject val = ItemBuilder.SpriteFromBundle("UltravioletGuonOrbitalSynergy", Initialisation.itemCollection.GetSpriteIdByName("ultravioletguon_synergy"), Initialisation.itemCollection, (GameObject)null);
			((Object)val).name = "Ultraviolet Guon Orbital Synergy Form";
			SpeculativeRigidbody val2 = SpriteBuilder.SetUpSpeculativeRigidbody(val.GetComponent<tk2dSprite>(), IntVector2.Zero, new IntVector2(14, 14));
			upgradeOrbitalPrefab = val.AddComponent<PlayerOrbital>();
			val2.CollideWithTileMap = false;
			val2.CollideWithOthers = true;
			val2.PrimaryPixelCollider.CollisionLayer = (CollisionLayer)15;
			upgradeOrbitalPrefab.shouldRotate = true;
			upgradeOrbitalPrefab.orbitRadius = 4.1f;
			upgradeOrbitalPrefab.orbitDegreesPerSecond = 500f;
			upgradeOrbitalPrefab.perfectOrbitalFactor = 10f;
			upgradeOrbitalPrefab.SetOrbitalTier(0);
			EasyTrailMisc easyTrailMisc = val.AddComponent<EasyTrailMisc>();
			easyTrailMisc.TrailPos = Vector2.op_Implicit(val.transform.position);
			easyTrailMisc.TrailPos.x += 0.4f;
			easyTrailMisc.StartWidth = 0.4f;
			easyTrailMisc.EndWidth = 0f;
			easyTrailMisc.LifeTime = 0.2f;
			easyTrailMisc.BaseColor = ExtendedColours.charmPink;
			easyTrailMisc.EndColor = ExtendedColours.pink;
			Object.DontDestroyOnLoad((Object)(object)val);
			FakePrefab.MarkAsFakePrefab(val);
			val.SetActive(false);
		}
	}

	public override void Update()
	{
		//IL_0131: Unknown result type (might be due to invalid IL or missing references)
		//IL_0136: Unknown result type (might be due to invalid IL or missing references)
		//IL_0146: Unknown result type (might be due to invalid IL or missing references)
		//IL_014b: Unknown result type (might be due to invalid IL or missing references)
		if (!((Object)(object)base.m_extantOrbital != (Object)null))
		{
			return;
		}
		if (timer > 0f)
		{
			timer -= BraveTime.DeltaTime;
		}
		else if (timer <= 0f)
		{
			if (CustomSynergies.PlayerHasActiveSynergy(((PassiveItem)this).Owner, "Ultravioleter Guon Stone"))
			{
				timer = Random.Range(0.1f, 0.5f);
				base.m_extantOrbital.GetComponent<PlayerOrbital>().orbitRadius = Random.Range(1f, 5f);
			}
			else
			{
				timer = Random.Range(0.1f, 1f);
				base.m_extantOrbital.GetComponent<PlayerOrbital>().orbitRadius = Random.Range(2f, 6f);
			}
			if (((PassiveItem)this).Owner.IsInCombat && CustomSynergies.PlayerHasActiveSynergy(((PassiveItem)this).Owner, "Xenochrome") && Random.value <= 0.5f)
			{
				GameObject val = ProjSpawnHelper.SpawnProjectileTowardsPoint(((Component)xenochromePrefab).gameObject, Vector2.op_Implicit(base.m_extantOrbital.transform.position), Vector2.op_Implicit(((BraveBehaviour)((PassiveItem)this).Owner).transform.position));
				Projectile component = val.GetComponent<Projectile>();
				if ((Object)(object)component != (Object)null)
				{
					component.Owner = (GameActor)(object)((PassiveItem)this).Owner;
					component.Shooter = ((BraveBehaviour)((PassiveItem)this).Owner).specRigidbody;
					component.collidesWithPlayer = false;
					ProjectileData baseData = component.baseData;
					baseData.damage *= ((PassiveItem)this).Owner.stats.GetStatValue((StatType)5);
					ProjectileData baseData2 = component.baseData;
					baseData2.range *= ((PassiveItem)this).Owner.stats.GetStatValue((StatType)26);
					ProjectileData baseData3 = component.baseData;
					baseData3.force *= ((PassiveItem)this).Owner.stats.GetStatValue((StatType)12);
					ProjectileData baseData4 = component.baseData;
					baseData4.speed *= ((PassiveItem)this).Owner.stats.GetStatValue((StatType)6);
					((PassiveItem)this).Owner.DoPostProcessProjectile(component);
				}
			}
		}
		((AdvancedPlayerOrbitalItem)this).Update();
	}

	public override void Pickup(PlayerController player)
	{
		((AdvancedPlayerOrbitalItem)this).Pickup(player);
	}

	public override DebrisObject Drop(PlayerController player)
	{
		return ((AdvancedPlayerOrbitalItem)this).Drop(player);
	}

	public override void OnDestroy()
	{
		((AdvancedPlayerOrbitalItem)this).OnDestroy();
	}
}
