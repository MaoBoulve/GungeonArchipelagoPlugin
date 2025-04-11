using System.Collections.Generic;
using System.Reflection;
using Alexandria.ItemAPI;
using UnityEngine;

namespace NevernamedsItems;

internal class GuonToolbox
{
	public static GameObject MakeAnimatedOrbital(string name, float orbitRadius, float orbitalDegreesPerSecond, int orbitalTier, OrbitalMotionStyle motionStyle, float perfectOrbitalFactor, List<string> idleAnimPaths, int fps, Vector2 colliderDimensions, Vector2 colliderOffsets, Anchor anchorMode, WrapMode wrapMode, bool assetbundle = true)
	{
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_0073: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_008e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		//IL_0092: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Unknown result type (might be due to invalid IL or missing references)
		GameObject val = (assetbundle ? ItemBuilder.SpriteFromBundle("BuildingGuonStone", Initialisation.itemCollection.GetSpriteIdByName(idleAnimPaths[0]), Initialisation.itemCollection, (GameObject)null) : SpriteBuilder.SpriteFromResource(idleAnimPaths[0], (GameObject)null, (Assembly)null));
		((Object)val).name = name;
		SpeculativeRigidbody val2 = SpriteBuilder.SetUpSpeculativeRigidbody(val.GetComponent<tk2dSprite>(), Vector2Extensions.ToIntVector2(colliderOffsets, (VectorConversions)2), Vector2Extensions.ToIntVector2(colliderDimensions, (VectorConversions)2));
		val2.CollideWithTileMap = false;
		val2.CollideWithOthers = true;
		val2.PrimaryPixelCollider.CollisionLayer = (CollisionLayer)15;
		if (assetbundle)
		{
			val.AddAnimationToObjectAssetBundle(Initialisation.itemCollection, "start", idleAnimPaths, fps, colliderDimensions, colliderOffsets, anchorMode, wrapMode, isDefaultAnimation: true);
		}
		else
		{
			tk2dSpriteCollectionData spriteCollection = SpriteBuilder.ConstructCollection(val, name + "_Collection", false);
			val.AddAnimationToObject(spriteCollection, "start", idleAnimPaths, fps, colliderDimensions, colliderOffsets, anchorMode, wrapMode, isDefaultAnimation: true);
		}
		PlayerOrbital val3 = val.AddComponent<PlayerOrbital>();
		val3.motionStyle = motionStyle;
		val3.shouldRotate = false;
		val3.orbitRadius = orbitRadius;
		val3.perfectOrbitalFactor = perfectOrbitalFactor;
		val3.orbitDegreesPerSecond = orbitalDegreesPerSecond;
		val3.SetOrbitalTier(orbitalTier);
		FakePrefabExtensions.MakeFakePrefab(val);
		return val;
	}
}
