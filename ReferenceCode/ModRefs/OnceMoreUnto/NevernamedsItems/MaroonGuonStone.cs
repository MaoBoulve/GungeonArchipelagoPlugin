using System;
using Alexandria.ItemAPI;
using SaveAPI;
using UnityEngine;

namespace NevernamedsItems;

internal class MaroonGuonStone : AdvancedPlayerOrbitalItem
{
	public static PlayerOrbital orbitalPrefab;

	public static PlayerOrbital upgradeOrbitalPrefab;

	public static void Init()
	{
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		PickupObject obj = ItemSetup.NewItem<MaroonGuonStone>("Maroon Guon Stone", "Unapologetically Offensive", "Has zero defensive capabilities, but empowers bullets that it's owner shoots through it.\n\nLost in the Gungeon by the infamous Jammomaster, many years ago...", "maroonguon_icon", assetbundle: true);
		AdvancedPlayerOrbitalItem val = (AdvancedPlayerOrbitalItem)(object)((obj is AdvancedPlayerOrbitalItem) ? obj : null);
		((PickupObject)val).quality = (ItemQuality)4;
		BuildPrefab();
		val.OrbitalPrefab = orbitalPrefab;
		BuildSynergyPrefab();
		ItemBuilder.AddToSubShop((PickupObject)(object)val, (ShopType)2, 1f);
		AlexandriaTags.SetTag((PickupObject)(object)val, "guon_stone");
		val.HasAdvancedUpgradeSynergy = true;
		val.AdvancedUpgradeSynergy = "Marooner Guon Stone";
		val.AdvancedUpgradeOrbitalPrefab = ((Component)upgradeOrbitalPrefab).gameObject;
		((PickupObject)(object)val).SetupUnlockOnCustomFlag(CustomDungeonFlags.JAMMEDBULLETKIN_QUEST_REWARDED, requiredFlagValue: true);
	}

	public static void BuildPrefab()
	{
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Unknown result type (might be due to invalid IL or missing references)
		if (!((Object)(object)orbitalPrefab != (Object)null))
		{
			GameObject val = ItemBuilder.SpriteFromBundle("MaroonGuonOrbital", Initialisation.itemCollection.GetSpriteIdByName("maroonguon_ingame"), Initialisation.itemCollection, (GameObject)null);
			((Object)val).name = "Maroon Guon Orbital";
			SpeculativeRigidbody val2 = SpriteBuilder.SetUpSpeculativeRigidbody(val.GetComponent<tk2dSprite>(), IntVector2.Zero, new IntVector2(10, 16));
			val2.CollideWithTileMap = false;
			val2.CollideWithOthers = true;
			val2.UpdateCollidersOnRotation = true;
			val2.PrimaryPixelCollider.CollisionLayer = (CollisionLayer)8;
			orbitalPrefab = val.AddComponent<PlayerOrbital>();
			orbitalPrefab.motionStyle = (OrbitalMotionStyle)0;
			orbitalPrefab.perfectOrbitalFactor = 10f;
			orbitalPrefab.shouldRotate = true;
			orbitalPrefab.orbitRadius = 3.5f;
			orbitalPrefab.orbitDegreesPerSecond = 50f;
			orbitalPrefab.SetOrbitalTier(0);
			Object.DontDestroyOnLoad((Object)(object)val);
			FakePrefab.MarkAsFakePrefab(val);
			val.SetActive(false);
		}
	}

	public static void BuildSynergyPrefab()
	{
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		if ((Object)(object)upgradeOrbitalPrefab == (Object)null)
		{
			GameObject val = ItemBuilder.SpriteFromBundle("MaroonGuonOrbitalSynergy", Initialisation.itemCollection.GetSpriteIdByName("maroonguon_synergy"), Initialisation.itemCollection, (GameObject)null);
			((Object)val).name = "Maroon Guon Orbital Synergy Form";
			SpeculativeRigidbody val2 = SpriteBuilder.SetUpSpeculativeRigidbody(val.GetComponent<tk2dSprite>(), IntVector2.Zero, new IntVector2(13, 20));
			upgradeOrbitalPrefab = val.AddComponent<PlayerOrbital>();
			val2.CollideWithTileMap = false;
			val2.CollideWithOthers = true;
			val2.UpdateCollidersOnRotation = true;
			val2.PrimaryPixelCollider.CollisionLayer = (CollisionLayer)8;
			upgradeOrbitalPrefab.shouldRotate = true;
			upgradeOrbitalPrefab.orbitRadius = 3.5f;
			upgradeOrbitalPrefab.perfectOrbitalFactor = 10f;
			upgradeOrbitalPrefab.orbitDegreesPerSecond = 30f;
			upgradeOrbitalPrefab.SetOrbitalTier(0);
			Object.DontDestroyOnLoad((Object)(object)val);
			FakePrefab.MarkAsFakePrefab(val);
			val.SetActive(false);
		}
	}

	private void OnGuonHitByBullet(SpeculativeRigidbody myRigidbody, PixelCollider myCollider, SpeculativeRigidbody other, PixelCollider otherCollider)
	{
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		if (!Object.op_Implicit((Object)(object)((PassiveItem)this).Owner) || !Object.op_Implicit((Object)(object)base.m_extantOrbital))
		{
			return;
		}
		if (Object.op_Implicit((Object)(object)((BraveBehaviour)other).projectile) && ((BraveBehaviour)other).projectile.Owner is PlayerController)
		{
			if (!Object.op_Implicit((Object)(object)((Component)((BraveBehaviour)other).projectile).GetComponent<BuffedByMaroonGuonStone>()))
			{
				float num = 1.5f;
				if (CustomSynergies.PlayerHasActiveSynergy(((PassiveItem)this).Owner, "Marooner Guon Stone"))
				{
					num = 2f;
				}
				ProjectileData baseData = ((BraveBehaviour)other).projectile.baseData;
				baseData.damage *= num;
				((BraveBehaviour)other).projectile.RuntimeUpdateScale(1.2f);
				((Component)((BraveBehaviour)other).projectile).gameObject.AddComponent<BuffedByMaroonGuonStone>();
				((BraveBehaviour)other).projectile.AdjustPlayerProjectileTint(ExtendedColours.maroon, 2, 0f);
				ExtremelySimpleStatusEffectBulletBehaviour orAddComponent = GameObjectExtensions.GetOrAddComponent<ExtremelySimpleStatusEffectBulletBehaviour>(((Component)((BraveBehaviour)other).projectile).gameObject);
				if (CustomSynergies.PlayerHasActiveSynergy(((PassiveItem)this).Owner, "Toxic Core"))
				{
					orAddComponent.usesPoisonEffect = true;
				}
				if (CustomSynergies.PlayerHasActiveSynergy(((PassiveItem)this).Owner, "Charming Core"))
				{
					orAddComponent.usesCharmEffect = true;
				}
				if (CustomSynergies.PlayerHasActiveSynergy(((PassiveItem)this).Owner, "Burning Core"))
				{
					orAddComponent.usesFireEffect = true;
				}
				if (CustomSynergies.PlayerHasActiveSynergy(((PassiveItem)this).Owner, "Explosive Core"))
				{
					ExplosiveModifier orAddComponent2 = GameObjectExtensions.GetOrAddComponent<ExplosiveModifier>(((Component)((BraveBehaviour)other).projectile).gameObject);
					orAddComponent2.doExplosion = true;
					orAddComponent2.explosionData = StaticExplosionDatas.explosiveRoundsExplosion;
				}
				if (CustomSynergies.PlayerHasActiveSynergy(((PassiveItem)this).Owner, "Hungry Core"))
				{
					HungryProjectileModifier orAddComponent3 = GameObjectExtensions.GetOrAddComponent<HungryProjectileModifier>(((Component)((BraveBehaviour)other).projectile).gameObject);
				}
				if (CustomSynergies.PlayerHasActiveSynergy(((PassiveItem)this).Owner, "Smart Core"))
				{
					HomingModifier orAddComponent4 = GameObjectExtensions.GetOrAddComponent<HomingModifier>(((Component)((BraveBehaviour)other).projectile).gameObject);
				}
			}
			PhysicsEngine.SkipCollision = true;
		}
		else if (Object.op_Implicit((Object)(object)((BraveBehaviour)other).projectile) && !(((BraveBehaviour)other).projectile.Owner is PlayerController))
		{
			PhysicsEngine.SkipCollision = true;
		}
	}

	public override void OnOrbitalCreated(GameObject orbital)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Expected O, but got Unknown
		if (Object.op_Implicit((Object)(object)orbital.GetComponent<SpeculativeRigidbody>()))
		{
			SpeculativeRigidbody component = orbital.GetComponent<SpeculativeRigidbody>();
			component.OnPreRigidbodyCollision = (OnPreRigidbodyCollisionDelegate)Delegate.Combine((Delegate)(object)component.OnPreRigidbodyCollision, (Delegate)new OnPreRigidbodyCollisionDelegate(OnGuonHitByBullet));
		}
		((AdvancedPlayerOrbitalItem)this).OnOrbitalCreated(orbital);
	}
}
