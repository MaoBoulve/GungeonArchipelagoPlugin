using System.Collections.Generic;
using System.Reflection;
using Alexandria.Assetbundle;
using Alexandria.ItemAPI;
using UnityEngine;

namespace NevernamedsItems;

public static class ItemSetup
{
	public static PickupObject NewItem<T>(string name, string subtitle, string description, string filepath, bool assetbundle = true) where T : Component
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Expected O, but got Unknown
		GameObject val = new GameObject(name);
		Component val2 = val.AddComponent(typeof(T));
		if (assetbundle)
		{
			ItemBuilder.AddSpriteToObjectAssetbundle(name, Initialisation.itemCollection.GetSpriteIdByName(filepath), Initialisation.itemCollection, val);
		}
		else
		{
			ItemBuilder.AddSpriteToObject(name, filepath, val, (Assembly)null);
		}
		ItemBuilder.SetupItem((PickupObject)(object)((val2 is PickupObject) ? val2 : null), subtitle, description, "nn");
		return (PickupObject)(object)((val2 is PickupObject) ? val2 : null);
	}

	public static void SetProjectileSprite(this Projectile proj, string spriteID, int pixelWidth, int pixelHeight, bool lightened = true, Anchor anchor = 0, int? overrideColliderPixelWidth = null, int? overrideColliderPixelHeight = null, bool anchorChangesCollider = true, bool fixesScale = false, int? overrideColliderOffsetX = null, int? overrideColliderOffsetY = null, Projectile overrideProjectileToCopyFrom = null, bool useFolder = false)
	{
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		if (useFolder)
		{
			GunTools.SetProjectileSpriteRight(proj, spriteID, pixelWidth, pixelHeight, lightened, anchor, overrideColliderPixelWidth, overrideColliderPixelHeight, anchorChangesCollider, fixesScale, overrideColliderOffsetX, overrideColliderOffsetY, overrideProjectileToCopyFrom);
		}
		else
		{
			ProjectileBuilders.SetProjectileCollisionRight(proj, spriteID, Initialisation.ProjectileCollection, pixelWidth, pixelHeight, lightened, anchor, overrideColliderPixelWidth, overrideColliderPixelHeight, anchorChangesCollider, fixesScale, overrideColliderOffsetX, overrideColliderOffsetY, overrideProjectileToCopyFrom);
		}
	}

	public static void SetGunSprites(this Gun gun, string identity, int framerate = 8, bool noAmmonomicon = false, int collection = 1)
	{
		Dictionary<int, tk2dSpriteCollectionData> dictionary = new Dictionary<int, tk2dSpriteCollectionData>
		{
			{
				1,
				Initialisation.gunCollection
			},
			{
				2,
				Initialisation.gunCollection2
			}
		};
		GunInt.SetupSprite(gun, dictionary[collection], identity + "_idle_001", framerate, noAmmonomicon ? null : (identity + "_ammonomicon_001"));
	}

	public static GameObject CreateOrbitalObject(string name, string defaultSprite, IntVector2 colliders, IntVector2 colliderOffsets, string animationClip = null, float orbitRadius = 2.5f, float rotationDegreesPerSecond = 120f, int orbitalTier = 0, OrbitalMotionStyle orbitmotionStyle = 0, float perfectOrbitalFactor = 0f)
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		GameObject val = ItemBuilder.SpriteFromBundle(defaultSprite, Initialisation.itemCollection.GetSpriteIdByName(defaultSprite), Initialisation.itemCollection, new GameObject(name));
		SpeculativeRigidbody val2 = SpriteBuilder.SetUpSpeculativeRigidbody(val.GetComponent<tk2dSprite>(), colliderOffsets, colliders);
		val2.CollideWithTileMap = false;
		val2.CollideWithOthers = true;
		val2.PrimaryPixelCollider.CollisionLayer = (CollisionLayer)15;
		PlayerOrbital val3 = val.AddComponent<PlayerOrbital>();
		val3.motionStyle = orbitmotionStyle;
		val3.shouldRotate = false;
		val3.orbitRadius = orbitRadius;
		val3.orbitDegreesPerSecond = rotationDegreesPerSecond;
		val3.perfectOrbitalFactor = perfectOrbitalFactor;
		val3.SetOrbitalTier(orbitalTier);
		if (animationClip != null)
		{
			tk2dSpriteAnimator orAddComponent = GameObjectExtensions.GetOrAddComponent<tk2dSpriteAnimator>(val);
			orAddComponent.Library = Initialisation.itemAnimationCollection;
			orAddComponent.DefaultClipId = Initialisation.itemAnimationCollection.GetClipIdByName(animationClip);
			orAddComponent.playAutomatically = true;
		}
		FakePrefabExtensions.MakeFakePrefab(val);
		return val;
	}
}
