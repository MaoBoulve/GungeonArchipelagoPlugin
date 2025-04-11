using System;
using Alexandria.ItemAPI;
using Alexandria.Misc;
using UnityEngine;

namespace NevernamedsItems;

internal class IndigoGuonStone : AdvancedPlayerOrbitalItem
{
	public static PlayerOrbital orbitalPrefab;

	public static PlayerOrbital upgradeOrbitalPrefab;

	public static void Init()
	{
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		PickupObject obj = ItemSetup.NewItem<IndigoGuonStone>("Indigo Guon Stone", "Close To Your Heart", "Orbits close, offering bullet banishing protection.\n\nThe blood stone of an ancient frost giant, hardened by time and cold.", "indigoguon_icon", assetbundle: true);
		AdvancedPlayerOrbitalItem val = (AdvancedPlayerOrbitalItem)(object)((obj is AdvancedPlayerOrbitalItem) ? obj : null);
		((PickupObject)val).quality = (ItemQuality)4;
		BuildPrefab();
		val.OrbitalPrefab = orbitalPrefab;
		BuildSynergyPrefab();
		ItemBuilder.AddToSubShop((PickupObject)(object)val, (ShopType)4, 1f);
		AlexandriaTags.SetTag((PickupObject)(object)val, "guon_stone");
		val.HasAdvancedUpgradeSynergy = true;
		val.AdvancedUpgradeSynergy = "Indigoer Guon Stone";
		val.AdvancedUpgradeOrbitalPrefab = ((Component)upgradeOrbitalPrefab).gameObject;
	}

	public static void BuildPrefab()
	{
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_0086: Unknown result type (might be due to invalid IL or missing references)
		if (!((Object)(object)orbitalPrefab != (Object)null))
		{
			GameObject val = ItemBuilder.SpriteFromBundle("IndigoGuonOrbital", Initialisation.itemCollection.GetSpriteIdByName("indigoguon_ingame"), Initialisation.itemCollection, (GameObject)null);
			((Object)val).name = "Indigo Guon Orbital";
			SpeculativeRigidbody val2 = SpriteBuilder.SetUpSpeculativeRigidbody(val.GetComponent<tk2dSprite>(), IntVector2.Zero, new IntVector2(5, 9));
			val2.CollideWithTileMap = false;
			val2.CollideWithOthers = true;
			val2.PrimaryPixelCollider.CollisionLayer = (CollisionLayer)15;
			orbitalPrefab = val.AddComponent<PlayerOrbital>();
			orbitalPrefab.motionStyle = (OrbitalMotionStyle)0;
			orbitalPrefab.perfectOrbitalFactor = 10f;
			orbitalPrefab.shouldRotate = false;
			orbitalPrefab.orbitRadius = 1f;
			orbitalPrefab.orbitDegreesPerSecond = 100f;
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
			GameObject val = ItemBuilder.SpriteFromBundle("IndigoGuonOrbitalSynergy", Initialisation.itemCollection.GetSpriteIdByName("indigoguon_synergy"), Initialisation.itemCollection, (GameObject)null);
			((Object)val).name = "Indigo Guon Orbital Synergy Form";
			SpeculativeRigidbody val2 = SpriteBuilder.SetUpSpeculativeRigidbody(val.GetComponent<tk2dSprite>(), IntVector2.Zero, new IntVector2(9, 13));
			upgradeOrbitalPrefab = val.AddComponent<PlayerOrbital>();
			val2.CollideWithTileMap = false;
			val2.CollideWithOthers = true;
			val2.PrimaryPixelCollider.CollisionLayer = (CollisionLayer)15;
			upgradeOrbitalPrefab.shouldRotate = false;
			upgradeOrbitalPrefab.orbitRadius = 1f;
			upgradeOrbitalPrefab.perfectOrbitalFactor = 10f;
			upgradeOrbitalPrefab.orbitDegreesPerSecond = 100f;
			upgradeOrbitalPrefab.SetOrbitalTier(0);
			Object.DontDestroyOnLoad((Object)(object)val);
			FakePrefab.MarkAsFakePrefab(val);
			val.SetActive(false);
		}
	}

	private void OnGuonHitByBullet(SpeculativeRigidbody myRigidbody, PixelCollider myCollider, SpeculativeRigidbody other, PixelCollider otherCollider)
	{
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d7: Unknown result type (might be due to invalid IL or missing references)
		if (!Object.op_Implicit((Object)(object)((PassiveItem)this).Owner) || !Object.op_Implicit((Object)(object)base.m_extantOrbital))
		{
			return;
		}
		if (((PassiveItem)this).Owner.IsDodgeRolling)
		{
			PhysicsEngine.SkipCollision = true;
		}
		else
		{
			if (!Object.op_Implicit((Object)(object)((BraveBehaviour)other).projectile) || ((BraveBehaviour)other).projectile.Owner is PlayerController)
			{
				return;
			}
			float num = 0.35f;
			if (CustomSynergies.PlayerHasActiveSynergy(((PassiveItem)this).Owner, "Indigoer Guon Stone"))
			{
				num = 0.6f;
			}
			if (Random.value <= num)
			{
				EasyBlankType val = (EasyBlankType)1;
				if (CustomSynergies.PlayerHasActiveSynergy(((PassiveItem)this).Owner, "Indigoer Guon Stone") && (double)Random.value <= 0.2)
				{
					val = (EasyBlankType)0;
				}
				PlayerUtility.DoEasyBlank(((PassiveItem)this).Owner, Vector2.op_Implicit(base.m_extantOrbital.transform.position), val);
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
}
