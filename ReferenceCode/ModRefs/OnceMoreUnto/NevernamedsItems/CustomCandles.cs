using System.Collections.Generic;
using Alexandria.BreakableAPI;
using Alexandria.DungeonAPI;
using Alexandria.ItemAPI;
using Dungeonator;
using UnityEngine;

namespace NevernamedsItems;

public class CustomCandles
{
	public static void Init()
	{
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Expected O, but got Unknown
		//IL_00e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f3: Expected O, but got Unknown
		//IL_01fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0205: Expected O, but got Unknown
		//IL_022c: Unknown result type (might be due to invalid IL or missing references)
		//IL_04a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_04de: Unknown result type (might be due to invalid IL or missing references)
		//IL_04f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_04fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_04fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0502: Unknown result type (might be due to invalid IL or missing references)
		//IL_0505: Unknown result type (might be due to invalid IL or missing references)
		//IL_050a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0511: Unknown result type (might be due to invalid IL or missing references)
		//IL_0519: Unknown result type (might be due to invalid IL or missing references)
		//IL_0520: Unknown result type (might be due to invalid IL or missing references)
		//IL_052c: Expected O, but got Unknown
		//IL_052e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0533: Unknown result type (might be due to invalid IL or missing references)
		//IL_0535: Unknown result type (might be due to invalid IL or missing references)
		//IL_053a: Unknown result type (might be due to invalid IL or missing references)
		//IL_053c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0541: Unknown result type (might be due to invalid IL or missing references)
		//IL_0548: Unknown result type (might be due to invalid IL or missing references)
		//IL_054f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0556: Unknown result type (might be due to invalid IL or missing references)
		//IL_0562: Expected O, but got Unknown
		//IL_05b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_05be: Unknown result type (might be due to invalid IL or missing references)
		//IL_06fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0770: Unknown result type (might be due to invalid IL or missing references)
		//IL_07e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_07fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0811: Unknown result type (might be due to invalid IL or missing references)
		//IL_0827: Unknown result type (might be due to invalid IL or missing references)
		//IL_087a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0890: Unknown result type (might be due to invalid IL or missing references)
		//IL_08a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_08bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0943: Unknown result type (might be due to invalid IL or missing references)
		//IL_0959: Unknown result type (might be due to invalid IL or missing references)
		//IL_096f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0985: Unknown result type (might be due to invalid IL or missing references)
		//IL_09d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_09ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a05: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a1b: Unknown result type (might be due to invalid IL or missing references)
		GameObject val = ItemBuilder.SpriteFromBundle("candle_halo_003", Initialisation.EnvironmentCollection.GetSpriteIdByName("candle_halo_003"), Initialisation.EnvironmentCollection, new GameObject("Halo"));
		val.SetActive(true);
		tk2dSprite component = val.GetComponent<tk2dSprite>();
		((tk2dBaseSprite)component).HeightOffGround = 1f;
		((tk2dBaseSprite)component).IsPerpendicular = false;
		((BraveBehaviour)component).renderer.material.shader = ShaderCache.Acquire("tk2d/BlendVertexColorTilted");
		((tk2dBaseSprite)component).usesOverrideMaterial = true;
		SpritePulser val2 = val.AddComponent<SpritePulser>();
		val2.duration = 0.7f;
		val2.maxDuration = 2.9f;
		val2.maxScale = 1.1f;
		val2.metaDuration = 6f;
		val2.minAlpha = 0.6f;
		val2.minDuration = 0.8f;
		val2.minScale = 0.9f;
		val2.m_active = true;
		GameObject val3 = ItemBuilder.SpriteFromBundle("candle_haloblue_003", Initialisation.EnvironmentCollection.GetSpriteIdByName("candle_haloblue_003"), Initialisation.EnvironmentCollection, new GameObject("Halo"));
		val3.SetActive(true);
		tk2dSprite component2 = val3.GetComponent<tk2dSprite>();
		((tk2dBaseSprite)component2).HeightOffGround = 1f;
		((tk2dBaseSprite)component2).IsPerpendicular = false;
		((BraveBehaviour)component2).renderer.material.shader = ShaderCache.Acquire("tk2d/BlendVertexColorTilted");
		((tk2dBaseSprite)component2).usesOverrideMaterial = true;
		SpritePulser val4 = val3.AddComponent<SpritePulser>();
		val4.duration = 0.7f;
		val4.maxDuration = 2.9f;
		val4.maxScale = 1.1f;
		val4.metaDuration = 6f;
		val4.minAlpha = 0.6f;
		val4.minDuration = 0.8f;
		val4.minScale = 0.9f;
		val4.m_active = true;
		MinorBreakable val5 = Breakables.GenerateMinorBreakable("Lampstand", Initialisation.EnvironmentCollection, Initialisation.environmentAnimationCollection, "lampstand_idle_001", "lampstand_idle", null, "Play_WPN_metalbullet_impact_01", 3, 24, 1, 1);
		FakePrefabExtensions.MakeFakePrefab(((Component)val5).gameObject);
		GameObject val6 = ItemBuilder.SpriteFromBundle("lampstand_shadow", Initialisation.EnvironmentCollection.GetSpriteIdByName("lampstand_shadow"), Initialisation.EnvironmentCollection, new GameObject("Shadow"));
		val6.transform.SetParent(((BraveBehaviour)val5).transform);
		val6.transform.localPosition = new Vector3(-0.0625f, -0.0625f);
		tk2dSprite component3 = val6.GetComponent<tk2dSprite>();
		((tk2dBaseSprite)component3).HeightOffGround = -5f;
		((tk2dBaseSprite)component3).SortingOrder = 0;
		((tk2dBaseSprite)component3).IsPerpendicular = false;
		((BraveBehaviour)component3).renderer.material.shader = ShaderCache.Acquire("Brave/LitTk2dCustomFalloffTilted");
		((tk2dBaseSprite)component3).usesOverrideMaterial = true;
		val5.stopsBullets = true;
		val5.OnlyPlayerProjectilesCanBreak = false;
		val5.OnlyBreaksOnScreen = false;
		val5.resistsExplosions = false;
		val5.canSpawnFairy = false;
		val5.chanceToRain = 0f;
		val5.dropCoins = false;
		val5.goopsOnBreak = false;
		((Component)val5).gameObject.layer = 22;
		((BraveBehaviour)val5).sprite.HeightOffGround = 0f;
		val5.shardClusters = new List<ShardCluster>
		{
			BreakableAPIToolbox.GenerateShardCluster(Breakables.GenerateDebrisObjects(Initialisation.EnvironmentCollection, new List<string> { "lampstand_debris_base_001", "lampstand_debris_base_002" }.ToArray(), debrisObjectsCanRotate: true, 1f, 1f, 1080f, 0f, null, 0.5f), 0.1f, 0.5f, 1, 2, 0.1f),
			BreakableAPIToolbox.GenerateShardCluster(Breakables.GenerateDebrisObjects(Initialisation.EnvironmentCollection, new List<string> { "lampstand_debris_pole_001", "lampstand_debris_pole_002", "lampstand_debris_pole_003" }.ToArray()), 1f, 1f, 2, 3, 1f),
			BreakableAPIToolbox.GenerateShardCluster(Breakables.GenerateDebrisObjects(Initialisation.EnvironmentCollection, new List<string> { "lampstand_debris_cup" }.ToArray()), 1f, 1f, 1, 1, 1f),
			BreakableAPIToolbox.GenerateShardCluster(Breakables.GenerateDebrisObjects(Initialisation.EnvironmentCollection, new List<string> { "lampstand_debris_candle" }.ToArray()), 1f, 1f, 1, 1, 1f)
		}.ToArray();
		val5.breakStyle = (BreakStyle)0;
		val5.IsDecorativeOnly = true;
		val.transform.SetParent(((Component)val5).gameObject.transform);
		val.transform.localPosition = new Vector3(0.125f, 1.8125f);
		((BraveBehaviour)val5).specRigidbody.PixelColliders = new List<PixelCollider>
		{
			new PixelCollider
			{
				ColliderGenerationMode = (PixelColliderGeneration)0,
				CollisionLayer = (CollisionLayer)12,
				ManualWidth = 3,
				ManualHeight = 24,
				ManualOffsetX = 1,
				ManualOffsetY = 1
			},
			new PixelCollider
			{
				ColliderGenerationMode = (PixelColliderGeneration)0,
				CollisionLayer = (CollisionLayer)6,
				ManualWidth = 3,
				ManualHeight = 3,
				ManualOffsetX = 1,
				ManualOffsetY = 1
			}
		};
		DungeonPlaceable val7 = BreakableAPIToolbox.GenerateDungeonPlaceable(new Dictionary<GameObject, float> { 
		{
			((Component)val5).gameObject,
			1f
		} }, 1, 1, (DungeonPrerequisite[])null);
		val7.isPassable = true;
		val7.width = 1;
		val7.height = 1;
		val7.variantTiers[0].unitOffset = new Vector2(0.375f, 0.375f);
		StaticReferences.StoredDungeonPlaceables.Add("lampstand", val7);
		StaticReferences.customPlaceables.Add("nn:lampstand", val7);
		MinorBreakable val8 = Breakables.GenerateMinorBreakable("Blue Candle", Initialisation.EnvironmentCollection, Initialisation.environmentAnimationCollection, "bluecandle_idle_001", "bluecandle_idle", null, "Play_OBJ_candle_fall_01", 3, 3, 0, 1);
		FakePrefabExtensions.MakeFakePrefab(((Component)val8).gameObject);
		val8.stopsBullets = false;
		val8.OnlyPlayerProjectilesCanBreak = false;
		val8.OnlyBreaksOnScreen = false;
		val8.resistsExplosions = false;
		val8.canSpawnFairy = false;
		val8.chanceToRain = 0f;
		val8.dropCoins = false;
		val8.goopsOnBreak = false;
		((Component)val8).gameObject.layer = 22;
		((BraveBehaviour)val8).sprite.HeightOffGround = 0f;
		val8.shardClusters = new List<ShardCluster> { BreakableAPIToolbox.GenerateShardCluster(Breakables.GenerateDebrisObjects(Initialisation.EnvironmentCollection, new List<string> { "bluecandle_debris_001" }.ToArray()), 1f, 1f, 1, 1, 1f) }.ToArray();
		val8.breakStyle = (BreakStyle)0;
		val8.IsDecorativeOnly = true;
		PositionRandomiser positionRandomiser = ((Component)val8).gameObject.AddComponent<PositionRandomiser>();
		positionRandomiser.xOffsetMax = 14f;
		positionRandomiser.yOffsetMax = 14f;
		PlacedObjectRotator placedObjectRotator = ((Component)val8).gameObject.AddComponent<PlacedObjectRotator>();
		placedObjectRotator.chanceToTriggerOnStart = 0.05f;
		val3.transform.SetParent(((Component)val8).gameObject.transform);
		val3.transform.localPosition = new Vector3(0.0625f, 0.375f);
		DungeonPlaceable value = BreakableAPIToolbox.GenerateDungeonPlaceable(new Dictionary<GameObject, float> { 
		{
			((Component)val8).gameObject,
			1f
		} }, 1, 1, (DungeonPrerequisite[])null);
		StaticReferences.StoredDungeonPlaceables.Add("bluecandle_singular", value);
		StaticReferences.customPlaceables.Add("nn:bluecandle_singular", value);
		DungeonPlaceable value2 = BreakableAPIToolbox.GenerateDungeonPlaceable(new Dictionary<GameObject, float>
		{
			{
				GenerateCandomizer(1, 4, "BlueCandle", ((Component)val8).gameObject, new List<Vector2>
				{
					new Vector2(4f, 4f),
					new Vector2(10f, 3f),
					new Vector2(2f, 11f),
					new Vector2(11f, 13f)
				}, -3f, 3f, -3f, 3f, 0.23f),
				1f
			},
			{
				GenerateCandomizer(1, 4, "BlueCandle", ((Component)val8).gameObject, new List<Vector2>
				{
					new Vector2(8f, 3f),
					new Vector2(3f, 9f),
					new Vector2(13f, 7f),
					new Vector2(7f, 12f)
				}, -3f, 3f, -3f, 3f, 0.23f),
				1f
			}
		}, 1, 1, (DungeonPrerequisite[])null);
		StaticReferences.StoredDungeonPlaceables.Add("bluecandle_cluster", value2);
		StaticReferences.customPlaceables.Add("nn:bluecandle_cluster", value2);
		DungeonPlaceable value3 = BreakableAPIToolbox.GenerateDungeonPlaceable(new Dictionary<GameObject, float>
		{
			{
				GenerateCandomizer(-2, 4, "BlueCandle", ((Component)val8).gameObject, new List<Vector2>
				{
					new Vector2(4f, 4f),
					new Vector2(10f, 3f),
					new Vector2(2f, 11f),
					new Vector2(11f, 13f)
				}, -3f, 3f, -3f, 3f, 0.23f),
				1f
			},
			{
				GenerateCandomizer(-2, 4, "BlueCandle", ((Component)val8).gameObject, new List<Vector2>
				{
					new Vector2(8f, 3f),
					new Vector2(3f, 9f),
					new Vector2(13f, 7f),
					new Vector2(7f, 12f)
				}, -3f, 3f, -3f, 3f, 0.23f),
				1f
			}
		}, 1, 1, (DungeonPrerequisite[])null);
		StaticReferences.StoredDungeonPlaceables.Add("bluecandle_cluster_exclusive", value3);
		StaticReferences.customPlaceables.Add("nn:bluecandle_cluster_exclusive", value3);
	}

	public static GameObject GenerateCandomizer(int minCandles, int maxCandles, string candleIdentifier, GameObject candlePrefab, List<Vector2> Positions, float xOffsetMin = 0f, float xOffsetMax = 0f, float yOffsetMin = 0f, float yOffsetMax = 0f, float chanceToKnockOneOver = 0f)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Expected O, but got Unknown
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Unknown result type (might be due to invalid IL or missing references)
		//IL_0086: Unknown result type (might be due to invalid IL or missing references)
		GameObject val = new GameObject();
		FakePrefabExtensions.MakeFakePrefab(val);
		int num = 1;
		Vector2 val3 = default(Vector2);
		foreach (Vector2 Position in Positions)
		{
			GameObject val2 = FakePrefab.Clone(candlePrefab);
			((Object)val2).name = $"{candleIdentifier} {num}";
			val2.transform.SetParent(val.transform);
			((Vector2)(ref val3))._002Ector(Position.x / 16f, Position.y / 16f);
			val2.transform.localPosition = Vector2.op_Implicit(val3);
			if (xOffsetMin != 0f || xOffsetMax != 0f || yOffsetMin != 0f || yOffsetMax != 0f)
			{
				PositionRandomiser orAddComponent = GameObjectExtensions.GetOrAddComponent<PositionRandomiser>(val2);
				orAddComponent.xOffsetMin = xOffsetMin;
				orAddComponent.xOffsetMax = xOffsetMax;
				orAddComponent.yOffsetMin = yOffsetMin;
				orAddComponent.yOffsetMax = yOffsetMax;
			}
			PlacedObjectRotator orAddComponent2 = GameObjectExtensions.GetOrAddComponent<PlacedObjectRotator>(val2.gameObject);
			orAddComponent2.chanceToTriggerOnStart = 0f;
			num++;
		}
		Candomizer candomizer = val.AddComponent<Candomizer>();
		candomizer.candleIdentifier = candleIdentifier;
		candomizer.minCandles = minCandles;
		candomizer.maxCandles = maxCandles;
		candomizer.chanceForOneToBeKnockedOver = chanceToKnockOneOver;
		return val;
	}
}
