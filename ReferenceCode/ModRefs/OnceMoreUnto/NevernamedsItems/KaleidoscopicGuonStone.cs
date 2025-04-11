using System;
using System.Collections.Generic;
using Alexandria.ItemAPI;
using UnityEngine;

namespace NevernamedsItems;

internal class KaleidoscopicGuonStone : AdvancedPlayerOrbitalItem
{
	private class KaleidoscopicBullet : MonoBehaviour
	{
	}

	public static PlayerOrbital orbitalPrefab;

	public static PlayerOrbital upgradeOrbitalPrefab;

	private Dictionary<int, Color> indexToColors = new Dictionary<int, Color>
	{
		{
			0,
			Color.red
		},
		{
			1,
			ExtendedColours.vibrantOrange
		},
		{
			2,
			ExtendedColours.honeyYellow
		},
		{
			3,
			Color.green
		},
		{
			4,
			Color.blue
		},
		{
			5,
			ExtendedColours.purple
		}
	};

	private Dictionary<int, string> synergyNameForIndex = new Dictionary<int, string>
	{
		{ 0, "Reddy Steady" },
		{ 1, "Orange U Glad" },
		{ 2, "Yellow There" },
		{ 3, "Green Behind The Ears" },
		{ 4, "da ba dee da ba die" },
		{ 5, "Tomorrow, or just the end of time?" }
	};

	public static void Init()
	{
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		PickupObject obj = ItemSetup.NewItem<KaleidoscopicGuonStone>("Kaleidoscopic Guon Stone", "Twisted!", "Spirals in beautiful patterns. Capable of twisting the fabric of bullet-based matter to leave you with more bullet than you started with.", "kaleidoscopicguon_icon", assetbundle: true);
		AdvancedPlayerOrbitalItem val = (AdvancedPlayerOrbitalItem)(object)((obj is AdvancedPlayerOrbitalItem) ? obj : null);
		((PickupObject)val).quality = (ItemQuality)5;
		BuildPrefab();
		val.OrbitalPrefab = orbitalPrefab;
		BuildSynergyPrefab();
		ItemBuilder.AddToSubShop((PickupObject)(object)val, (ShopType)2, 1f);
		AlexandriaTags.SetTag((PickupObject)(object)val, "guon_stone");
		val.HasAdvancedUpgradeSynergy = true;
		val.AdvancedUpgradeSynergy = "Kaleidoscopicer Guon Stone";
		val.AdvancedUpgradeOrbitalPrefab = ((Component)upgradeOrbitalPrefab).gameObject;
	}

	public static void BuildPrefab()
	{
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Unknown result type (might be due to invalid IL or missing references)
		if (!((Object)(object)orbitalPrefab != (Object)null))
		{
			GameObject val = ItemBuilder.SpriteFromBundle("KaleidoscopicGuonOrbital", Initialisation.itemCollection.GetSpriteIdByName("kaleidoscopicguon_icon"), Initialisation.itemCollection, (GameObject)null);
			((Object)val).name = "Kaleidoscopic Guon Orbital";
			SpeculativeRigidbody val2 = SpriteBuilder.SetUpSpeculativeRigidbody(val.GetComponent<tk2dSprite>(), IntVector2.Zero, new IntVector2(14, 14));
			val2.CollideWithTileMap = false;
			val2.CollideWithOthers = true;
			val2.UpdateCollidersOnRotation = true;
			val2.PrimaryPixelCollider.CollisionLayer = (CollisionLayer)8;
			orbitalPrefab = val.AddComponent<PlayerOrbital>();
			orbitalPrefab.motionStyle = (OrbitalMotionStyle)0;
			orbitalPrefab.perfectOrbitalFactor = 10f;
			orbitalPrefab.shouldRotate = false;
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
			GameObject val = ItemBuilder.SpriteFromBundle("KaleidoscopicGuonOrbitalSynergy", Initialisation.itemCollection.GetSpriteIdByName("kaleidoscopicguon_synergy"), Initialisation.itemCollection, (GameObject)null);
			((Object)val).name = "Kaleidoscopic Guon Orbital Synergy Form";
			SpeculativeRigidbody val2 = SpriteBuilder.SetUpSpeculativeRigidbody(val.GetComponent<tk2dSprite>(), IntVector2.Zero, new IntVector2(20, 20));
			upgradeOrbitalPrefab = val.AddComponent<PlayerOrbital>();
			val2.CollideWithTileMap = false;
			val2.CollideWithOthers = true;
			val2.UpdateCollidersOnRotation = true;
			val2.PrimaryPixelCollider.CollisionLayer = (CollisionLayer)8;
			upgradeOrbitalPrefab.shouldRotate = false;
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
		//IL_009e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0204: Unknown result type (might be due to invalid IL or missing references)
		if (!Object.op_Implicit((Object)(object)((PassiveItem)this).Owner) || !Object.op_Implicit((Object)(object)base.m_extantOrbital))
		{
			return;
		}
		if (Object.op_Implicit((Object)(object)((BraveBehaviour)other).projectile) && ((BraveBehaviour)other).projectile.Owner is PlayerController)
		{
			if ((Object)(object)((Component)((BraveBehaviour)other).projectile).gameObject.GetComponent<KaleidoscopicBullet>() == (Object)null)
			{
				float num = 40f;
				if (CustomSynergies.PlayerHasActiveSynergy(((PassiveItem)this).Owner, "Kaleidoscopicer Guon Stone"))
				{
					num = 20f;
				}
				float num2 = num / 5f;
				float num3 = Vector2Extensions.ToAngle(((BraveBehaviour)other).projectile.Direction);
				float num4 = num3 + num * 0.5f;
				int num5 = 0;
				for (int i = 0; i < 6; i++)
				{
					float num6 = num4 - num2 * (float)num5;
					GameObject val = FakePrefab.Clone(((Component)((BraveBehaviour)other).projectile).gameObject);
					GameObject val2 = SpawnManager.SpawnProjectile(val, ((BraveBehaviour)other).projectile.LastPosition, Quaternion.Euler(0f, 0f, num6), true);
					Projectile component = val2.GetComponent<Projectile>();
					if ((Object)(object)component != (Object)null)
					{
						component.Owner = (GameActor)(object)((PassiveItem)this).Owner;
						component.Shooter = ((BraveBehaviour)((PassiveItem)this).Owner).specRigidbody;
						if (!CustomSynergies.PlayerHasActiveSynergy(((PassiveItem)this).Owner, synergyNameForIndex[i]))
						{
							ProjectileData baseData = component.baseData;
							baseData.damage *= 0.5f;
							component.RuntimeUpdateScale(0.9f);
						}
						else
						{
							ProjectileData baseData2 = component.baseData;
							baseData2.speed *= 1.2f;
							ProjectileData baseData3 = component.baseData;
							baseData3.range *= 3f;
							BounceProjModifier component2 = ((Component)component).gameObject.GetComponent<BounceProjModifier>();
							if (Object.op_Implicit((Object)(object)component2))
							{
								component2.numberOfBounces++;
							}
							else
							{
								((Component)component).gameObject.AddComponent<BounceProjModifier>();
							}
						}
						component.AdjustPlayerProjectileTint(indexToColors[i], 2, 0f);
					}
					val2.AddComponent<KaleidoscopicBullet>();
					num5++;
				}
				Object.Destroy((Object)(object)((Component)((BraveBehaviour)other).projectile).gameObject);
			}
			PhysicsEngine.SkipCollision = true;
		}
		else if (Object.op_Implicit((Object)(object)((BraveBehaviour)other).projectile) && !(((BraveBehaviour)other).projectile.Owner is PlayerController))
		{
			PhysicsEngine.SkipCollision = false;
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
