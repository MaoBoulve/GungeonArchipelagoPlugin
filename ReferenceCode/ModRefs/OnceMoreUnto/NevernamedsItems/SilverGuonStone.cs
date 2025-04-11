using System;
using Alexandria.ItemAPI;
using SaveAPI;
using UnityEngine;

namespace NevernamedsItems;

internal class SilverGuonStone : AdvancedPlayerOrbitalItem
{
	public static PlayerOrbital orbitalPrefab;

	public static PlayerOrbital upgradeOrbitalPrefab;

	private float storedDamageMult = 1f;

	public static void Init()
	{
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		PickupObject obj = ItemSetup.NewItem<SilverGuonStone>("Silver Guon Stone", "Relic From Beyond", "Forged from a lump of silvery metal that slipped through a tear in the curtain.\n\nCombats the Jammed.", "silverguon_icon", assetbundle: true);
		AdvancedPlayerOrbitalItem val = (AdvancedPlayerOrbitalItem)(object)((obj is AdvancedPlayerOrbitalItem) ? obj : null);
		((PickupObject)val).quality = (ItemQuality)3;
		BuildPrefab();
		val.OrbitalPrefab = orbitalPrefab;
		BuildSynergyPrefab();
		ItemBuilder.AddToSubShop((PickupObject)(object)val, (ShopType)2, 1f);
		AlexandriaTags.SetTag((PickupObject)(object)val, "guon_stone");
		val.HasAdvancedUpgradeSynergy = true;
		val.AdvancedUpgradeSynergy = "Silverer Guon Stone";
		val.AdvancedUpgradeOrbitalPrefab = ((Component)upgradeOrbitalPrefab).gameObject;
		((PickupObject)(object)val).SetupUnlockOnCustomFlag(CustomDungeonFlags.ALLJAMMED_BEATEN_PROPER, requiredFlagValue: true);
	}

	public static void BuildPrefab()
	{
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		if (!((Object)(object)orbitalPrefab != (Object)null))
		{
			GameObject val = ItemBuilder.SpriteFromBundle("SilverGuonOrbital", Initialisation.itemCollection.GetSpriteIdByName("silverguon_ingame"), Initialisation.itemCollection, (GameObject)null);
			((Object)val).name = "Silver Guon Orbital";
			SpeculativeRigidbody val2 = SpriteBuilder.SetUpSpeculativeRigidbody(val.GetComponent<tk2dSprite>(), IntVector2.Zero, new IntVector2(7, 7));
			val2.CollideWithTileMap = false;
			val2.CollideWithOthers = true;
			val2.PrimaryPixelCollider.CollisionLayer = (CollisionLayer)15;
			orbitalPrefab = val.AddComponent<PlayerOrbital>();
			orbitalPrefab.motionStyle = (OrbitalMotionStyle)0;
			orbitalPrefab.perfectOrbitalFactor = 0f;
			orbitalPrefab.shouldRotate = false;
			orbitalPrefab.orbitRadius = 2.5f;
			orbitalPrefab.orbitDegreesPerSecond = 120f;
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
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		if ((Object)(object)upgradeOrbitalPrefab == (Object)null)
		{
			GameObject val = ItemBuilder.SpriteFromBundle("SilverGuonOrbitalSynergy", Initialisation.itemCollection.GetSpriteIdByName("silverguon_synergy"), Initialisation.itemCollection, (GameObject)null);
			((Object)val).name = "Silver Guon Orbital Synergy Form";
			SpeculativeRigidbody val2 = SpriteBuilder.SetUpSpeculativeRigidbody(val.GetComponent<tk2dSprite>(), IntVector2.Zero, new IntVector2(12, 12));
			upgradeOrbitalPrefab = val.AddComponent<PlayerOrbital>();
			val2.CollideWithTileMap = false;
			val2.CollideWithOthers = true;
			val2.PrimaryPixelCollider.CollisionLayer = (CollisionLayer)15;
			upgradeOrbitalPrefab.shouldRotate = false;
			upgradeOrbitalPrefab.orbitRadius = 2.5f;
			upgradeOrbitalPrefab.perfectOrbitalFactor = 10f;
			upgradeOrbitalPrefab.orbitDegreesPerSecond = 120f;
			upgradeOrbitalPrefab.SetOrbitalTier(0);
			Object.DontDestroyOnLoad((Object)(object)val);
			FakePrefab.MarkAsFakePrefab(val);
			val.SetActive(false);
		}
	}

	private void OnGuonHitByBullet(SpeculativeRigidbody myRigidbody, PixelCollider myCollider, SpeculativeRigidbody other, PixelCollider otherCollider)
	{
		if (!Object.op_Implicit((Object)(object)((PassiveItem)this).Owner) || !Object.op_Implicit((Object)(object)base.m_extantOrbital) || !Object.op_Implicit((Object)(object)((BraveBehaviour)other).projectile) || !Object.op_Implicit((Object)(object)((BraveBehaviour)other).projectile.Owner) || ((BraveBehaviour)other).projectile.Owner is PlayerController)
		{
			return;
		}
		float num = 5f;
		if (CustomSynergies.PlayerHasActiveSynergy(((PassiveItem)this).Owner, "Silverer Guon Stone"))
		{
			num = 8f;
		}
		if (((BraveBehaviour)other).projectile.IsBlackBullet && storedDamageMult < num)
		{
			storedDamageMult += 0.5f;
		}
		if (CustomSynergies.PlayerHasActiveSynergy(((PassiveItem)this).Owner, "Turn Gundead") && Object.op_Implicit((Object)(object)((BraveBehaviour)((BraveBehaviour)other).projectile.Owner).aiActor) && ((BraveBehaviour)((BraveBehaviour)other).projectile.Owner).aiActor.IsBlackPhantom)
		{
			if (Object.op_Implicit((Object)(object)((BraveBehaviour)((BraveBehaviour)other).projectile.Owner).healthHaver) && !((BraveBehaviour)((BraveBehaviour)other).projectile.Owner).healthHaver.IsBoss && Random.value <= 0.1f)
			{
				((BraveBehaviour)((BraveBehaviour)other).projectile.Owner).aiActor.UnbecomeBlackPhantom();
			}
			else if (Object.op_Implicit((Object)(object)((BraveBehaviour)((BraveBehaviour)other).projectile.Owner).healthHaver) && ((BraveBehaviour)((BraveBehaviour)other).projectile.Owner).healthHaver.IsBoss && Random.value <= 0.05f)
			{
				((BraveBehaviour)((BraveBehaviour)other).projectile.Owner).aiActor.UnbecomeBlackPhantom();
			}
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

	private void PostProcessBeam(BeamController beam)
	{
		if (Object.op_Implicit((Object)(object)beam))
		{
			Projectile projectile = ((BraveBehaviour)beam).projectile;
			if (Object.op_Implicit((Object)(object)projectile))
			{
				PostProcessProjectile(projectile, 1f);
			}
		}
	}

	private void PostProcessProjectile(Projectile bullet, float meh)
	{
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		float num = 1.15f;
		if (CustomSynergies.PlayerHasActiveSynergy(((PassiveItem)this).Owner, "Silverer Guon Stone"))
		{
			num = 1.3f;
		}
		bullet.BlackPhantomDamageMultiplier *= num;
		if (storedDamageMult > 1f)
		{
			ProjectileData baseData = bullet.baseData;
			baseData.damage *= storedDamageMult;
			bullet.AdjustPlayerProjectileTint(Color.red, 1, 0f);
			storedDamageMult = 1f;
		}
	}

	public override void Pickup(PlayerController player)
	{
		player.PostProcessProjectile += PostProcessProjectile;
		player.PostProcessBeam += PostProcessBeam;
		((AdvancedPlayerOrbitalItem)this).Pickup(player);
	}

	public override DebrisObject Drop(PlayerController player)
	{
		player.PostProcessProjectile -= PostProcessProjectile;
		player.PostProcessBeam -= PostProcessBeam;
		return ((AdvancedPlayerOrbitalItem)this).Drop(player);
	}

	public override void OnDestroy()
	{
		if (Object.op_Implicit((Object)(object)((PassiveItem)this).Owner))
		{
			((PassiveItem)this).Owner.PostProcessBeam -= PostProcessBeam;
			((PassiveItem)this).Owner.PostProcessProjectile -= PostProcessProjectile;
		}
		((AdvancedPlayerOrbitalItem)this).OnDestroy();
	}
}
