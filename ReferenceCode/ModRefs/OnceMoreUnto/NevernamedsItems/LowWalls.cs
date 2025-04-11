using System.Collections.Generic;
using Alexandria.BreakableAPI;
using Alexandria.DungeonAPI;
using Alexandria.ItemAPI;
using Dungeonator;
using UnityEngine;
using UnityEngine.Rendering;

namespace NevernamedsItems;

internal class LowWalls : BraveBehaviour
{
	public IntVector2 position;

	public string spritename = "";

	public static Dictionary<ValidTilesets, string> levelNames = new Dictionary<ValidTilesets, string> { 
	{
		(ValidTilesets)2,
		"keep"
	} };

	public static void Init()
	{
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_008c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0093: Unknown result type (might be due to invalid IL or missing references)
		//IL_009c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0105: Unknown result type (might be due to invalid IL or missing references)
		//IL_010e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0137: Unknown result type (might be due to invalid IL or missing references)
		//IL_013e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0147: Unknown result type (might be due to invalid IL or missing references)
		//IL_0170: Unknown result type (might be due to invalid IL or missing references)
		//IL_0177: Unknown result type (might be due to invalid IL or missing references)
		//IL_0180: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_021b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0222: Unknown result type (might be due to invalid IL or missing references)
		//IL_022b: Unknown result type (might be due to invalid IL or missing references)
		RegisterWall("lowwall_gp_westeast", "lowwall_gp_westeast_shadow", new Vector3(-0.25f, 0f, 50f), new IntVector2(0, -1), new IntVector2(16, 17), "lowwall_westeast");
		RegisterWall("lowwall_gp_westeastsouth", "lowwall_gp_westeastsouth_shadow", new Vector3(-0.25f, -0.5f, 50f), new IntVector2(0, 4), new IntVector2(16, 12), "lowwall_westeastsouth");
		RegisterWall("lowwall_gp_westeastnorth", "lowwall_gp_westeastnorth_shadow", new Vector3(-0.25f, 0f, 50f), new IntVector2(0, 0), new IntVector2(16, 16), "lowwall_westeastnorth");
		RegisterWall("lowwall_gp_westnorthsouth", "lowwall_gp_westnorthsouth_shadow", new Vector3(-0.25f, -0.5f, 50f), new IntVector2(0, 0), new IntVector2(16, 21), "lowwall_westnorthsouth");
		RegisterWall("lowwall_gp_eastnorthsouth", "lowwall_gp_eastnorthsouth_shadow", new Vector3(0f, -0.5f, 50f), new IntVector2(0, 0), new IntVector2(16, 21), "lowwall_eastnorthsouth");
		RegisterWall("lowwall_gp_northsouth", "lowwall_gp_northsouth_shadow", new Vector3(0f, -0.5f, 50f), new IntVector2(0, -1), new IntVector2(16, 21), "lowwall_northsouth");
		RegisterWall("lowwall_gp_northeastcorner", "lowwall_gp_northeastcorner_shadow", new Vector3(1f, 0f, 50f), new IntVector2(0, 0), new IntVector2(16, 21), "lowwall_northeastcorner");
		RegisterWall("lowwall_gp_northwestcorner", "lowwall_gp_northwestcorner_shadow", new Vector3(-0.25f, 0f, 50f), new IntVector2(0, 0), new IntVector2(16, 21), "lowwall_northwestcorner");
		RegisterWall("lowwall_gp_southeastcorner", "lowwall_gp_southeastcorner_shadow", new Vector3(0f, -0.5f, 50f), new IntVector2(0, -1), new IntVector2(16, 17), "lowwall_southeastcorner");
		RegisterWall("lowwall_gp_southwestcorner", "lowwall_gp_southwestcorner_shadow", new Vector3(-0.25f, -0.5f, 50f), new IntVector2(0, -1), new IntVector2(16, 17), "lowwall_southwestcorner");
	}

	public static void RegisterWall(string spritename, string shadowname, Vector3 shadowOffset, IntVector2 hitboxOffset, IntVector2 hitboxSize, string name)
	{
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Expected O, but got Unknown
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e0: Expected O, but got Unknown
		//IL_00f9: Unknown result type (might be due to invalid IL or missing references)
		GameObject val = ItemBuilder.SpriteFromBundle(spritename, Initialisation.TrapCollection.GetSpriteIdByName(spritename), Initialisation.TrapCollection, new GameObject("Low Wall"));
		FakePrefabExtensions.MakeFakePrefab(val);
		SpeculativeRigidbody val2 = SpriteBuilder.SetUpSpeculativeRigidbody(val.GetComponent<tk2dSprite>(), hitboxOffset, hitboxSize);
		val2.CollideWithTileMap = false;
		val2.CollideWithOthers = true;
		val2.PrimaryPixelCollider.CollisionLayer = (CollisionLayer)5;
		((tk2dBaseSprite)((Component)val.GetComponent<tk2dSprite>()).GetComponent<tk2dSprite>()).HeightOffGround = 0f;
		((tk2dBaseSprite)((Component)val.GetComponent<tk2dSprite>()).GetComponent<tk2dSprite>()).IsPerpendicular = false;
		((Renderer)val.GetComponent<MeshRenderer>()).lightProbeUsage = (LightProbeUsage)0;
		GameObjectExtensions.SetLayerRecursively(val, LayerMask.NameToLayer("FG_Critical"));
		((Renderer)val.GetComponent<MeshRenderer>()).material.shader = ShaderCache.Acquire("Brave/LitTk2dCustomFalloffTilted");
		((tk2dBaseSprite)val.GetComponent<tk2dSprite>()).usesOverrideMaterial = true;
		GameObject val3 = ItemBuilder.SpriteFromBundle(shadowname, Initialisation.TrapCollection.GetSpriteIdByName(shadowname), Initialisation.TrapCollection, new GameObject("Low Wall Shadow"));
		val3.transform.SetParent(val.transform);
		val3.transform.localPosition = shadowOffset;
		tk2dSprite component = val3.GetComponent<tk2dSprite>();
		((tk2dBaseSprite)component).HeightOffGround = -5f;
		((tk2dBaseSprite)component).SortingOrder = 0;
		((tk2dBaseSprite)component).IsPerpendicular = false;
		((BraveBehaviour)component).renderer.material.shader = ShaderCache.Acquire("Brave/LitTk2dCustomFalloffTilted");
		((tk2dBaseSprite)component).usesOverrideMaterial = true;
		val.AddComponent<PlacedBlockerConfigurable>();
		LowWalls lowWalls = val.AddComponent<LowWalls>();
		lowWalls.spritename = spritename;
		DungeonPlaceable val4 = BreakableAPIToolbox.GenerateDungeonPlaceable(new Dictionary<GameObject, float> { { val.gameObject, 1f } }, 1, 1, (DungeonPrerequisite[])null);
		val4.isPassable = false;
		val4.width = 1;
		val4.height = 1;
		StaticReferences.StoredDungeonPlaceables.Add(name, val4);
		StaticReferences.customPlaceables.Add("nn:" + name, val4);
	}

	private void Start()
	{
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		position = Vector2Extensions.ToIntVector2(Vector2.op_Implicit(((BraveBehaviour)this).transform.position), (VectorConversions)2);
		if (levelNames.ContainsKey(GameManager.Instance.Dungeon.tileIndices.tilesetId))
		{
			((BraveBehaviour)this).sprite.SetSprite(Initialisation.TrapCollection.GetSpriteIdByName(spritename.Replace("gp", levelNames[GameManager.Instance.Dungeon.tileIndices.tilesetId])));
		}
	}
}
