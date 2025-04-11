using System.Collections.Generic;
using Alexandria.BreakableAPI;
using Alexandria.ItemAPI;
using UnityEngine;

namespace NevernamedsItems;

public class Breakables
{
	public static void Init()
	{
		GreyBarrel.Init();
		BulletScarecrow.Init();
		BigBlank.Init();
		CustomCandles.Init();
	}

	public static DebrisObject[] GenerateDebrisObjects(tk2dSpriteCollectionData spriteCollection, string[] shardSpriteNames, bool debrisObjectsCanRotate = true, float LifeSpanMin = 1f, float LifeSpanMax = 1f, float AngularVelocity = 1080f, float AngularVelocityVariance = 0f, tk2dSprite shadowSprite = null, float Mass = 1f, string AudioEventName = null, GameObject BounceVFX = null, int DebrisBounceCount = 1, bool DoesGoopOnRest = false, GoopDefinition GoopType = null, float GoopRadius = 1f)
	{
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Expected O, but got Unknown
		List<DebrisObject> list = new List<DebrisObject>();
		for (int i = 0; i < shardSpriteNames.Length; i++)
		{
			GameObject val = ItemBuilder.SpriteFromBundle(shardSpriteNames[i], spriteCollection.GetSpriteIdByName(shardSpriteNames[i]), spriteCollection, new GameObject("debris"));
			FakePrefab.MarkAsFakePrefab(val);
			tk2dSprite component = val.GetComponent<tk2dSprite>();
			((BraveBehaviour)component).renderer.material.shader = ShaderCache.Acquire("Brave/LitTk2dCustomFalloffTiltedCutout");
			((tk2dBaseSprite)component).usesOverrideMaterial = true;
			DebrisObject val2 = val.AddComponent<DebrisObject>();
			val2.canRotate = debrisObjectsCanRotate;
			val2.lifespanMin = LifeSpanMin;
			val2.lifespanMax = LifeSpanMax;
			val2.bounceCount = DebrisBounceCount;
			val2.angularVelocity = AngularVelocity;
			val2.angularVelocityVariance = AngularVelocityVariance;
			if (AudioEventName != null)
			{
				val2.audioEventName = AudioEventName;
			}
			if ((Object)(object)BounceVFX != (Object)null)
			{
				val2.optionalBounceVFX = BounceVFX;
			}
			((BraveBehaviour)val2).sprite = (tk2dBaseSprite)(object)component;
			val2.DoesGoopOnRest = DoesGoopOnRest;
			if ((Object)(object)GoopType != (Object)null)
			{
				val2.AssignedGoop = GoopType;
			}
			else if ((Object)(object)GoopType == (Object)null && val2.DoesGoopOnRest)
			{
				val2.DoesGoopOnRest = false;
			}
			val2.GoopRadius = GoopRadius;
			if ((Object)(object)shadowSprite != (Object)null)
			{
				val2.shadowSprite = shadowSprite;
			}
			val2.inertialMass = Mass;
			list.Add(val2);
		}
		return list.ToArray();
	}

	public static MinorBreakable GenerateMinorBreakable(string name, tk2dSpriteCollectionData spriteCollection, tk2dSpriteAnimation animationCollection, string defaultSprite, string idleAnim, string breakAnim, string breakAudioEvent = "Play_OBJ_pot_shatter_01", int ColliderSizeX = 16, int ColliderSizeY = 8, int ColliderOffsetX = 0, int ColliderOffsetY = 8, GameObject DestroyVFX = null, List<CollisionLayer> collisionLayerList = null)
	{
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Expected O, but got Unknown
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		//IL_008e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0100: Unknown result type (might be due to invalid IL or missing references)
		//IL_010c: Unknown result type (might be due to invalid IL or missing references)
		//IL_010d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0119: Unknown result type (might be due to invalid IL or missing references)
		//IL_011a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0126: Unknown result type (might be due to invalid IL or missing references)
		//IL_012d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0134: Unknown result type (might be due to invalid IL or missing references)
		//IL_013b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0142: Unknown result type (might be due to invalid IL or missing references)
		//IL_014e: Expected O, but got Unknown
		//IL_0167: Unknown result type (might be due to invalid IL or missing references)
		//IL_016c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0176: Unknown result type (might be due to invalid IL or missing references)
		//IL_017b: Unknown result type (might be due to invalid IL or missing references)
		//IL_017d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0182: Unknown result type (might be due to invalid IL or missing references)
		//IL_0183: Unknown result type (might be due to invalid IL or missing references)
		//IL_0185: Unknown result type (might be due to invalid IL or missing references)
		//IL_018a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0191: Unknown result type (might be due to invalid IL or missing references)
		//IL_0198: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01de: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0206: Expected O, but got Unknown
		GameObject val = ItemBuilder.SpriteFromBundle(defaultSprite, spriteCollection.GetSpriteIdByName(defaultSprite), spriteCollection, new GameObject("debris"));
		FakePrefab.MarkAsFakePrefab(val);
		((Object)val).name = name;
		MinorBreakable val2 = val.AddComponent<MinorBreakable>();
		tk2dSprite orAddComponent = GameObjectExtensions.GetOrAddComponent<tk2dSprite>(val);
		((Renderer)((Component)orAddComponent).GetComponent<MeshRenderer>()).material.shader = ShaderCache.Acquire("Brave/LitTk2dCustomFalloffTilted");
		((tk2dBaseSprite)((Component)orAddComponent).GetComponent<tk2dSprite>()).usesOverrideMaterial = true;
		IntVector2 val3 = default(IntVector2);
		((IntVector2)(ref val3))._002Ector(ColliderSizeX, ColliderSizeY);
		IntVector2 val4 = default(IntVector2);
		((IntVector2)(ref val4))._002Ector(ColliderOffsetX, ColliderOffsetY);
		IntVector2 val5 = default(IntVector2);
		((IntVector2)(ref val5))._002Ector(val3.x, val3.y);
		SpeculativeRigidbody val6 = SpriteBuilder.SetUpSpeculativeRigidbody(val.GetComponent<tk2dSprite>(), val4, val5);
		val6.CollideWithTileMap = false;
		val6.CollideWithOthers = true;
		if (collisionLayerList == null)
		{
			val6.PixelColliders.Add(new PixelCollider
			{
				ColliderGenerationMode = (PixelColliderGeneration)0,
				CollisionLayer = (CollisionLayer)6,
				IsTrigger = false,
				BagleUseFirstFrameOnly = false,
				SpecifyBagelFrame = string.Empty,
				BagelColliderNumber = 0,
				ManualOffsetX = val4.x,
				ManualOffsetY = val4.y,
				ManualWidth = val5.x,
				ManualHeight = val5.y,
				ManualDiameter = 0,
				ManualLeftX = 0,
				ManualLeftY = 0,
				ManualRightX = 0,
				ManualRightY = 0
			});
		}
		else
		{
			foreach (CollisionLayer collisionLayer in collisionLayerList)
			{
				val6.PixelColliders.Add(new PixelCollider
				{
					ColliderGenerationMode = (PixelColliderGeneration)0,
					CollisionLayer = collisionLayer,
					IsTrigger = false,
					BagleUseFirstFrameOnly = false,
					SpecifyBagelFrame = string.Empty,
					BagelColliderNumber = 0,
					ManualOffsetX = val4.x,
					ManualOffsetY = val4.y,
					ManualWidth = val5.x,
					ManualHeight = val5.y,
					ManualDiameter = 0,
					ManualLeftX = 0,
					ManualLeftY = 0,
					ManualRightX = 0,
					ManualRightY = 0
				});
			}
		}
		tk2dSpriteAnimator orAddComponent2 = GameObjectExtensions.GetOrAddComponent<tk2dSpriteAnimator>(val);
		orAddComponent2.Library = animationCollection;
		orAddComponent2.DefaultClipId = animationCollection.GetClipIdByName(idleAnim);
		orAddComponent2.playAutomatically = true;
		val2.breakAnimName = breakAnim;
		((BraveBehaviour)val2).sprite = (tk2dBaseSprite)(object)orAddComponent;
		((BraveBehaviour)val2).specRigidbody = val6;
		((BraveBehaviour)val2).spriteAnimator = orAddComponent2;
		val2.breakAudioEventName = breakAudioEvent;
		if ((Object)(object)DestroyVFX != (Object)null)
		{
			val2.AdditionalVFXObject = DestroyVFX;
		}
		return val2;
	}

	public static MajorBreakable GenerateMajorBreakable(string name, tk2dSpriteCollectionData spriteCollection, tk2dSpriteAnimation animationCollection, string defaultSprite, string idleAnim, string breakAnim, float HP = 100f, bool UsesCustomColliderValues = false, int ColliderSizeX = 16, int ColliderSizeY = 8, int ColliderOffsetX = 0, int ColliderOffsetY = 8, bool DistribleShards = true, VFXPool breakVFX = null, VFXPool damagedVFX = null, bool BlocksPaths = false, List<CollisionLayer> collisionLayerList = null, Dictionary<float, string> preBreakframesAndHPPercentages = null, bool destroyedOnBreak = true, bool handlesOwnBreakAnim = false)
	{
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Expected O, but got Unknown
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		//IL_008e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0100: Unknown result type (might be due to invalid IL or missing references)
		//IL_010c: Unknown result type (might be due to invalid IL or missing references)
		//IL_010d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0119: Unknown result type (might be due to invalid IL or missing references)
		//IL_011a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0126: Unknown result type (might be due to invalid IL or missing references)
		//IL_012d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0134: Unknown result type (might be due to invalid IL or missing references)
		//IL_013b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0142: Unknown result type (might be due to invalid IL or missing references)
		//IL_014e: Expected O, but got Unknown
		//IL_0259: Unknown result type (might be due to invalid IL or missing references)
		//IL_0167: Unknown result type (might be due to invalid IL or missing references)
		//IL_016c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0176: Unknown result type (might be due to invalid IL or missing references)
		//IL_017b: Unknown result type (might be due to invalid IL or missing references)
		//IL_017d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0182: Unknown result type (might be due to invalid IL or missing references)
		//IL_0183: Unknown result type (might be due to invalid IL or missing references)
		//IL_0185: Unknown result type (might be due to invalid IL or missing references)
		//IL_018a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0191: Unknown result type (might be due to invalid IL or missing references)
		//IL_0198: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01de: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0206: Expected O, but got Unknown
		//IL_02ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_0311: Unknown result type (might be due to invalid IL or missing references)
		GameObject val = ItemBuilder.SpriteFromBundle(defaultSprite, spriteCollection.GetSpriteIdByName(defaultSprite), spriteCollection, new GameObject("debris"));
		FakePrefab.MarkAsFakePrefab(val);
		((Object)val).name = name;
		MajorBreakable val2 = val.AddComponent<MajorBreakable>();
		tk2dSprite orAddComponent = GameObjectExtensions.GetOrAddComponent<tk2dSprite>(val);
		((Renderer)((Component)orAddComponent).GetComponent<MeshRenderer>()).material.shader = ShaderCache.Acquire("Brave/LitTk2dCustomFalloffTilted");
		((tk2dBaseSprite)((Component)orAddComponent).GetComponent<tk2dSprite>()).usesOverrideMaterial = true;
		IntVector2 val3 = default(IntVector2);
		((IntVector2)(ref val3))._002Ector(ColliderSizeX, ColliderSizeY);
		IntVector2 val4 = default(IntVector2);
		((IntVector2)(ref val4))._002Ector(ColliderOffsetX, ColliderOffsetY);
		IntVector2 val5 = default(IntVector2);
		((IntVector2)(ref val5))._002Ector(val3.x, val3.y);
		SpeculativeRigidbody val6 = SpriteBuilder.SetUpSpeculativeRigidbody(val.GetComponent<tk2dSprite>(), val4, val5);
		val6.CollideWithTileMap = false;
		val6.CollideWithOthers = true;
		if (collisionLayerList == null)
		{
			val6.PixelColliders.Add(new PixelCollider
			{
				ColliderGenerationMode = (PixelColliderGeneration)0,
				CollisionLayer = (CollisionLayer)6,
				IsTrigger = false,
				BagleUseFirstFrameOnly = false,
				SpecifyBagelFrame = string.Empty,
				BagelColliderNumber = 0,
				ManualOffsetX = val4.x,
				ManualOffsetY = val4.y,
				ManualWidth = val5.x,
				ManualHeight = val5.y,
				ManualDiameter = 0,
				ManualLeftX = 0,
				ManualLeftY = 0,
				ManualRightX = 0,
				ManualRightY = 0
			});
		}
		else
		{
			foreach (CollisionLayer collisionLayer in collisionLayerList)
			{
				val6.PixelColliders.Add(new PixelCollider
				{
					ColliderGenerationMode = (PixelColliderGeneration)0,
					CollisionLayer = collisionLayer,
					IsTrigger = false,
					BagleUseFirstFrameOnly = false,
					SpecifyBagelFrame = string.Empty,
					BagelColliderNumber = 0,
					ManualOffsetX = val4.x,
					ManualOffsetY = val4.y,
					ManualWidth = val5.x,
					ManualHeight = val5.y,
					ManualDiameter = 0,
					ManualLeftX = 0,
					ManualLeftY = 0,
					ManualRightX = 0,
					ManualRightY = 0
				});
			}
		}
		tk2dSpriteAnimator orAddComponent2 = GameObjectExtensions.GetOrAddComponent<tk2dSpriteAnimator>(val);
		orAddComponent2.Library = animationCollection;
		orAddComponent2.DefaultClipId = animationCollection.GetClipIdByName(idleAnim);
		orAddComponent2.playAutomatically = true;
		val2.breakAnimation = breakAnim;
		val2.shardBreakStyle = (BreakStyle)0;
		((BraveBehaviour)val2).sprite = (tk2dBaseSprite)(object)orAddComponent;
		((BraveBehaviour)val2).specRigidbody = val6;
		((BraveBehaviour)val2).spriteAnimator = orAddComponent2;
		val2.HitPoints = HP;
		val2.HandlePathBlocking = BlocksPaths;
		val2.destroyedOnBreak = destroyedOnBreak;
		val2.handlesOwnBreakAnimation = handlesOwnBreakAnim;
		if (breakVFX != null)
		{
			val2.breakVfx = breakVFX;
		}
		if (damagedVFX != null)
		{
			val2.damageVfx = damagedVFX;
		}
		if (preBreakframesAndHPPercentages != null)
		{
			List<BreakFrame> list = new List<BreakFrame>();
			foreach (KeyValuePair<float, string> preBreakframesAndHPPercentage in preBreakframesAndHPPercentages)
			{
				BreakFrame item = default(BreakFrame);
				item.healthPercentage = preBreakframesAndHPPercentage.Key;
				item.sprite = preBreakframesAndHPPercentage.Value;
				list.Add(item);
			}
			BreakFrame[] prebreakFrames = list.ToArray();
			val2.prebreakFrames = prebreakFrames;
		}
		val2.distributeShards = DistribleShards;
		return val2;
	}

	public static List<ShardCluster> GenerateBarrelStyleShardClusters(List<string> BigChunks, List<string> MetalPiecesMedium, List<string> MetalPiecesSmall, List<string> WoodPiecesLarge, List<string> WoodPiecesMedium, List<string> WoodPiecesSmall)
	{
		ShardCluster item = BreakableAPIToolbox.GenerateShardCluster(GenerateDebrisObjects(Initialisation.EnvironmentCollection, BigChunks.ToArray(), debrisObjectsCanRotate: true, 1f, 1f, 1080f, 0f, null, 0.5f), 0.1f, 0.5f, 1, 2, 0.1f);
		ShardCluster item2 = BreakableAPIToolbox.GenerateShardCluster(GenerateDebrisObjects(Initialisation.EnvironmentCollection, MetalPiecesMedium.ToArray()), 1f, 1f, 1, 2, 1f);
		ShardCluster item3 = BreakableAPIToolbox.GenerateShardCluster(GenerateDebrisObjects(Initialisation.EnvironmentCollection, MetalPiecesSmall.ToArray()), 1f, 1f, 1, 2, 1f);
		ShardCluster item4 = BreakableAPIToolbox.GenerateShardCluster(GenerateDebrisObjects(Initialisation.EnvironmentCollection, WoodPiecesSmall.ToArray()), 1f, 1f, 1, 4, 1f);
		ShardCluster item5 = BreakableAPIToolbox.GenerateShardCluster(GenerateDebrisObjects(Initialisation.EnvironmentCollection, WoodPiecesMedium.ToArray()), 1f, 1f, 1, 3, 1f);
		ShardCluster item6 = BreakableAPIToolbox.GenerateShardCluster(GenerateDebrisObjects(Initialisation.EnvironmentCollection, WoodPiecesLarge.ToArray()), 1f, 1f, 0, 2, 1f);
		return new List<ShardCluster> { item, item2, item3, item4, item5, item6 };
	}

	public static DebrisObject GenerateDebrisObject(tk2dSpriteCollectionData spriteCollection, string shardSpriteName, bool debrisObjectsCanRotate = true, float LifeSpanMin = 1f, float LifeSpanMax = 1f, float AngularVelocity = 1080f, float AngularVelocityVariance = 0f, tk2dSprite shadowSprite = null, float Mass = 1f, string AudioEventName = null, GameObject BounceVFX = null, int DebrisBounceCount = 1, bool DoesGoopOnRest = false, GoopDefinition GoopType = null, float GoopRadius = 1f)
	{
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Expected O, but got Unknown
		GameObject val = ItemBuilder.SpriteFromBundle(shardSpriteName, spriteCollection.GetSpriteIdByName(shardSpriteName), spriteCollection, new GameObject("debris"));
		FakePrefab.MarkAsFakePrefab(val);
		tk2dSprite component = val.GetComponent<tk2dSprite>();
		((BraveBehaviour)component).renderer.material.shader = ShaderCache.Acquire("Brave/LitTk2dCustomFalloffTiltedCutout");
		((tk2dBaseSprite)component).usesOverrideMaterial = true;
		DebrisObject val2 = val.AddComponent<DebrisObject>();
		val2.canRotate = debrisObjectsCanRotate;
		val2.lifespanMin = LifeSpanMin;
		val2.lifespanMax = LifeSpanMax;
		val2.bounceCount = DebrisBounceCount;
		val2.angularVelocity = AngularVelocity;
		val2.angularVelocityVariance = AngularVelocityVariance;
		if (AudioEventName != null)
		{
			val2.audioEventName = AudioEventName;
		}
		if ((Object)(object)BounceVFX != (Object)null)
		{
			val2.optionalBounceVFX = BounceVFX;
		}
		((BraveBehaviour)val2).sprite = (tk2dBaseSprite)(object)component;
		val2.DoesGoopOnRest = DoesGoopOnRest;
		if ((Object)(object)GoopType != (Object)null)
		{
			val2.AssignedGoop = GoopType;
		}
		else if ((Object)(object)GoopType == (Object)null && val2.DoesGoopOnRest)
		{
			val2.DoesGoopOnRest = false;
		}
		val2.GoopRadius = GoopRadius;
		if ((Object)(object)shadowSprite != (Object)null)
		{
			val2.shadowSprite = shadowSprite;
		}
		val2.inertialMass = Mass;
		return val2;
	}
}
