using System.Collections.Generic;
using Alexandria.BreakableAPI;
using Alexandria.DungeonAPI;
using Alexandria.ItemAPI;
using Dungeonator;
using UnityEngine;
using UnityEngine.Rendering;

namespace NevernamedsItems;

internal class ShrineSetup
{
	public static GameObject shrinePlaceableGeneric;

	public static GameObject shrinePlaceableGenericWide;

	public static void Init()
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Expected O, but got Unknown
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Expected O, but got Unknown
		//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_010f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0119: Expected O, but got Unknown
		//IL_013c: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ad: Expected O, but got Unknown
		//IL_01dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e6: Expected O, but got Unknown
		//IL_0270: Unknown result type (might be due to invalid IL or missing references)
		//IL_0279: Unknown result type (might be due to invalid IL or missing references)
		//IL_029d: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ca: Expected O, but got Unknown
		//IL_02f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0448: Unknown result type (might be due to invalid IL or missing references)
		//IL_04d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0568: Unknown result type (might be due to invalid IL or missing references)
		//IL_058d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0592: Unknown result type (might be due to invalid IL or missing references)
		//IL_0594: Unknown result type (might be due to invalid IL or missing references)
		//IL_0599: Unknown result type (might be due to invalid IL or missing references)
		//IL_059c: Unknown result type (might be due to invalid IL or missing references)
		//IL_05a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_05a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_05a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_05b8: Expected O, but got Unknown
		//IL_0625: Unknown result type (might be due to invalid IL or missing references)
		//IL_06b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0745: Unknown result type (might be due to invalid IL or missing references)
		//IL_07d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0823: Unknown result type (might be due to invalid IL or missing references)
		//IL_082d: Expected O, but got Unknown
		//IL_08c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_08c7: Unknown result type (might be due to invalid IL or missing references)
		GameObject val = new GameObject("ShrineGenericPlaceable");
		val.SetActive(false);
		FakePrefab.MarkAsFakePrefab(val);
		GameObject val2 = ItemBuilder.SpriteFromBundle("shrinebase_generic", Initialisation.NPCCollection.GetSpriteIdByName("shrinebase_generic"), Initialisation.NPCCollection, new GameObject("ShrineBase Generic"));
		((tk2dBaseSprite)val2.GetComponent<tk2dSprite>()).HeightOffGround = -1f;
		((tk2dBaseSprite)val2.GetComponent<tk2dSprite>()).SortingOrder = 0;
		((tk2dBaseSprite)val2.GetComponent<tk2dSprite>()).renderLayer = 0;
		((Renderer)val2.GetComponent<MeshRenderer>()).lightProbeUsage = (LightProbeUsage)0;
		((BraveBehaviour)val2.GetComponent<tk2dSprite>()).renderer.material.shader = ShaderCache.Acquire("Brave/LitTk2dCustomFalloffTiltedCutout");
		((tk2dBaseSprite)val2.GetComponent<tk2dSprite>()).usesOverrideMaterial = true;
		val2.transform.SetParent(val.transform);
		SpeculativeRigidbody val3 = SpriteBuilder.SetUpSpeculativeRigidbody(val2.GetComponent<tk2dSprite>(), new IntVector2(0, -2), new IntVector2(26, 26));
		val3.CollideWithTileMap = false;
		val3.CollideWithOthers = true;
		val3.PrimaryPixelCollider.CollisionLayer = (CollisionLayer)6;
		GameObject val4 = ItemBuilder.SpriteFromBundle("shrinebase_generic_shadow", Initialisation.NPCCollection.GetSpriteIdByName("shrinebase_generic_shadow"), Initialisation.NPCCollection, new GameObject("ShrineBase Generic Shadow"));
		val4.transform.SetParent(val.transform);
		val4.transform.localPosition = new Vector3(-0.0625f, -0.125f);
		tk2dSprite component = val4.GetComponent<tk2dSprite>();
		((tk2dBaseSprite)component).HeightOffGround = -2f;
		((tk2dBaseSprite)component).SortingOrder = 0;
		((tk2dBaseSprite)component).renderLayer = 0;
		((tk2dBaseSprite)component).IsPerpendicular = false;
		((BraveBehaviour)component).renderer.material.shader = ShaderCache.Acquire("Brave/LitTk2dCustomFalloffTilted");
		((tk2dBaseSprite)component).usesOverrideMaterial = true;
		shrinePlaceableGeneric = val;
		GameObject val5 = new GameObject("ShrineWidePlaceable");
		val5.SetActive(false);
		FakePrefab.MarkAsFakePrefab(val5);
		GameObject val6 = ItemBuilder.SpriteFromBundle("shrinebase_wide", Initialisation.NPCCollection.GetSpriteIdByName("shrinebase_wide"), Initialisation.NPCCollection, new GameObject("ShrineBase Wide"));
		((tk2dBaseSprite)val6.GetComponent<tk2dSprite>()).HeightOffGround = -1f;
		((tk2dBaseSprite)val6.GetComponent<tk2dSprite>()).SortingOrder = 0;
		((tk2dBaseSprite)val6.GetComponent<tk2dSprite>()).renderLayer = 0;
		((Renderer)val6.GetComponent<MeshRenderer>()).lightProbeUsage = (LightProbeUsage)0;
		((BraveBehaviour)val6.GetComponent<tk2dSprite>()).renderer.material.shader = ShaderCache.Acquire("Brave/LitTk2dCustomFalloffTiltedCutout");
		((tk2dBaseSprite)val6.GetComponent<tk2dSprite>()).usesOverrideMaterial = true;
		val6.transform.SetParent(val5.transform);
		SpeculativeRigidbody val7 = SpriteBuilder.SetUpSpeculativeRigidbody(val6.GetComponent<tk2dSprite>(), new IntVector2(0, -2), new IntVector2(28, 28));
		val7.CollideWithTileMap = false;
		val7.CollideWithOthers = true;
		val7.PrimaryPixelCollider.CollisionLayer = (CollisionLayer)6;
		GameObject val8 = ItemBuilder.SpriteFromBundle("shrinebase_wide_shadow", Initialisation.NPCCollection.GetSpriteIdByName("shrinebase_wide_shadow"), Initialisation.NPCCollection, new GameObject("ShrineBase Wide Shadow"));
		val8.transform.SetParent(val5.transform);
		val8.transform.localPosition = new Vector3(-0.0625f, -0.125f);
		tk2dSprite component2 = val8.GetComponent<tk2dSprite>();
		((tk2dBaseSprite)component2).HeightOffGround = -2f;
		((tk2dBaseSprite)component2).SortingOrder = 0;
		((tk2dBaseSprite)component2).renderLayer = 0;
		((tk2dBaseSprite)component2).IsPerpendicular = false;
		((BraveBehaviour)component2).renderer.material.shader = ShaderCache.Acquire("Brave/LitTk2dCustomFalloffTilted");
		((tk2dBaseSprite)component2).usesOverrideMaterial = true;
		shrinePlaceableGenericWide = val5;
		GameObject val9 = FakePrefab.Clone(shrinePlaceableGeneric);
		((Object)val9).name = "Investment Shrine";
		GameObject val10 = InvestmentShrine.Setup(((Component)val9.transform.Find("ShrineBase Generic")).gameObject);
		val10.transform.SetParent(val9.transform);
		val10.transform.localPosition = new Vector3(-0.125f, 0.75f, 50f);
		val9.AddComponent<EncounterTrackable>().EncounterGuid = "nn:investment_shrine";
		AddShrineToPool(val9, new List<DungeonPrerequisite>(), 0.1875f, wide: false);
		GameObject val11 = FakePrefab.Clone(shrinePlaceableGenericWide);
		((Object)val11).name = "Artemissile Shrine";
		GameObject val12 = ArtemissileShrine.Setup(((Component)val11.transform.Find("ShrineBase Wide")).gameObject);
		val12.transform.SetParent(val11.transform);
		val12.transform.localPosition = new Vector3(-0.8125f, 0.8125f, 50f);
		val11.AddComponent<EncounterTrackable>().EncounterGuid = "nn:artemissile_shrine";
		AddShrineToPool(val11, new List<DungeonPrerequisite>(), 0.1f, wide: true);
		GameObject val13 = FakePrefab.Clone(shrinePlaceableGenericWide);
		((Object)val13).name = "Dagun Shrine";
		GameObject val14 = DagunShrine.Setup(((Component)val13.transform.Find("ShrineBase Wide")).gameObject);
		val14.transform.SetParent(val13.transform);
		val14.transform.localPosition = new Vector3(0f, 0.75f, 50f);
		val13.AddComponent<EncounterTrackable>().EncounterGuid = "nn:dagun_shrine";
		AddShrineToPool(val13, new List<DungeonPrerequisite>(), 0.1f, wide: true);
		GameObject val15 = FakePrefab.Clone(shrinePlaceableGeneric);
		((Object)val15).name = "Turtle Shrine";
		GameObject val16 = TurtleShrine.Setup(((Component)val15.transform.Find("ShrineBase Generic")).gameObject);
		val16.transform.SetParent(val15.transform);
		val16.transform.localPosition = new Vector3(-0.375f, 0.75f, 50f);
		val15.AddComponent<EncounterTrackable>().EncounterGuid = "nn:turtle_shrine";
		AddShrineToPool(val15, new List<DungeonPrerequisite>
		{
			new DungeonPrerequisite
			{
				prerequisiteType = (PrerequisiteType)1,
				statToCheck = (TrackedStats)71,
				prerequisiteOperation = (PrerequisiteOperation)2,
				comparisonValue = 0f
			}
		}, 0.1f, wide: false);
		GameObject val17 = FakePrefab.Clone(shrinePlaceableGeneric);
		((Object)val17).name = "Executioner Shrine";
		GameObject val18 = ExecutionerShrine.Setup(((Component)val17.transform.Find("ShrineBase Generic")).gameObject);
		val18.transform.SetParent(val17.transform);
		val18.transform.localPosition = new Vector3(-0.25f, 0.75f, 50f);
		val17.AddComponent<EncounterTrackable>().EncounterGuid = "nn:executioner_shrine";
		AddShrineToPool(val17, new List<DungeonPrerequisite>(), 0.1f, wide: false);
		GameObject val19 = FakePrefab.Clone(shrinePlaceableGenericWide);
		((Object)val19).name = "Relodin Shrine";
		GameObject val20 = RelodinShrine.Setup(((Component)val19.transform.Find("ShrineBase Wide")).gameObject);
		val20.transform.SetParent(val19.transform);
		val20.transform.localPosition = new Vector3(-0.4375f, 0.75f, 50f);
		val19.AddComponent<EncounterTrackable>().EncounterGuid = "nn:relodin_shrine";
		AddShrineToPool(val19, new List<DungeonPrerequisite>(), 0.1f, wide: true);
		GameObject val21 = FakePrefab.Clone(shrinePlaceableGenericWide);
		((Object)val21).name = "Kliklok Shrine";
		GameObject val22 = KliklokShrine.Setup(((Component)val21.transform.Find("ShrineBase Wide")).gameObject);
		val22.transform.SetParent(val21.transform);
		val22.transform.localPosition = new Vector3(-0.6875f, 0.75f, 50f);
		val21.AddComponent<EncounterTrackable>().EncounterGuid = "nn:kliklok_shrine";
		AddShrineToPool(val21, new List<DungeonPrerequisite>(), 0.2f, wide: true);
		GameObject val23 = FakePrefab.Clone(shrinePlaceableGenericWide);
		((Object)val23).name = "Vulcairn Shrine";
		GameObject val24 = VulcairnShrine.Setup(((Component)val23.transform.Find("ShrineBase Wide")).gameObject);
		val24.transform.SetParent(val23.transform);
		val24.transform.localPosition = new Vector3(-0.75f, 0.75f, 50f);
		val23.AddComponent<EncounterTrackable>().EncounterGuid = "nn:vulcairn_shrine";
		AddShrineToPool(val23, new List<DungeonPrerequisite>(), 0.1875f, wide: true);
		GameObject val25 = ItemBuilder.SpriteFromBundle("shrine_carpet", Initialisation.NPCCollection.GetSpriteIdByName("shrine_carpet"), Initialisation.NPCCollection, new GameObject("Shrine Carpet"));
		FakePrefabExtensions.MakeFakePrefab(val25);
		tk2dSprite component3 = val25.GetComponent<tk2dSprite>();
		val25.layer = 20;
		((tk2dBaseSprite)component3).SortingOrder = 0;
		((tk2dBaseSprite)component3).HeightOffGround = -2f;
		((tk2dBaseSprite)component3).IsPerpendicular = false;
		((BraveBehaviour)component3).renderer.material.shader = ShaderCache.Acquire("Brave/LitTk2dCustomFalloffTilted");
		((tk2dBaseSprite)component3).usesOverrideMaterial = true;
		DungeonPlaceable val26 = BreakableAPIToolbox.GenerateDungeonPlaceable(new Dictionary<GameObject, float> { { val25, 1f } }, 1, 1, (DungeonPrerequisite[])null);
		val26.variantTiers[0].unitOffset = new Vector2(0f, 0.5f);
		StaticReferences.StoredDungeonPlaceables.Add("shrine_carpet", val26);
		StaticReferences.customPlaceables.Add("nn:shrine_carpet", val26);
	}

	public static void AddShrineToPool(GameObject shrine, List<DungeonPrerequisite> prereq, float weight, bool wide)
	{
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Expected O, but got Unknown
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		List<DungeonPlaceableVariant> variantTiers = ResourceManager.LoadAssetBundle("shared_auto_001").LoadAsset<DungeonPlaceable>("whichshrinewillitbe").variantTiers;
		DungeonPlaceableVariant val = new DungeonPlaceableVariant();
		val.percentChance = weight;
		val.nonDatabasePlaceable = shrine;
		val.enemyPlaceableGuid = "";
		val.pickupObjectPlaceableId = -1;
		val.forceBlackPhantom = false;
		val.addDebrisObject = false;
		val.prerequisites = prereq.ToArray();
		val.unitOffset = (wide ? new Vector2(0.125f, 0f) : new Vector2(0.1875f, 0f));
		val.materialRequirements = (DungeonPlaceableRoomMaterialRequirement[])(object)new DungeonPlaceableRoomMaterialRequirement[0];
		variantTiers.Add(val);
	}
}
