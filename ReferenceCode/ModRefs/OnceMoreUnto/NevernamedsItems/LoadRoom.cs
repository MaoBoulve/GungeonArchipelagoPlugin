using System;
using Dungeonator;
using Pathfinding;
using tk2dRuntime.TileMap;
using UnityEngine;

namespace NevernamedsItems;

internal class LoadRoom
{
	public static void Init()
	{
		ETGModConsole.Commands.GetGroup("nn").AddUnit("loadroom", (Action<string[]>)delegate(string[] args)
		{
			string text = "UNDEFINED";
			if (args != null && args.Length != 0 && args[0] != null && !string.IsNullOrEmpty(args[0]))
			{
				text = args[0];
			}
			PrototypeDungeonRoom val = null;
			string text2 = ((Object)GameManager.Instance.Dungeon).name.Replace("(Clone)", "").ToLower();
			Dungeon orLoadByName = DungeonDatabase.GetOrLoadByName(text2);
			foreach (WeightedRoom element in orLoadByName.PatternSettings.flows[0].fallbackRoomTable.includedRooms.elements)
			{
				if (element != null && (Object)(object)element.room != (Object)null && ((Object)element.room).name == text)
				{
					val = element.room;
				}
			}
			orLoadByName = null;
			if ((Object)(object)val != (Object)null)
			{
				RoomHandler val2 = AddCustomRuntimeRoom(val, addRoomToMinimap: true, addTeleporter: true, isSecretRatExitRoom: false, null, (LightGenerationStyle)0);
				val2.visibility = (VisibilityStatus)1;
				Minimap.Instance.RevealMinimapRoom(val2, false, true, true);
			}
		}, (AutocompletionSettings)null);
	}

	public static RoomHandler AddCustomRuntimeRoom(PrototypeDungeonRoom prototype, bool addRoomToMinimap = true, bool addTeleporter = true, bool isSecretRatExitRoom = false, Action<RoomHandler> postProcessCellData = null, LightGenerationStyle lightStyle = 0, bool allowProceduralDecoration = true, bool allowProceduralLightFixtures = true, bool suppressExceptionMessages = false)
	{
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_008c: Unknown result type (might be due to invalid IL or missing references)
		//IL_008e: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_0096: Unknown result type (might be due to invalid IL or missing references)
		//IL_0098: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00de: Unknown result type (might be due to invalid IL or missing references)
		//IL_0107: Unknown result type (might be due to invalid IL or missing references)
		//IL_011c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0187: Unknown result type (might be due to invalid IL or missing references)
		//IL_0188: Unknown result type (might be due to invalid IL or missing references)
		//IL_018a: Unknown result type (might be due to invalid IL or missing references)
		//IL_018f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0191: Unknown result type (might be due to invalid IL or missing references)
		//IL_0193: Unknown result type (might be due to invalid IL or missing references)
		//IL_0195: Unknown result type (might be due to invalid IL or missing references)
		//IL_019a: Unknown result type (might be due to invalid IL or missing references)
		//IL_019c: Unknown result type (might be due to invalid IL or missing references)
		//IL_019e: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a8: Expected O, but got Unknown
		//IL_01b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ba: Expected O, but got Unknown
		//IL_02b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0334: Unknown result type (might be due to invalid IL or missing references)
		//IL_063f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0648: Unknown result type (might be due to invalid IL or missing references)
		//IL_064d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0659: Unknown result type (might be due to invalid IL or missing references)
		//IL_0660: Unknown result type (might be due to invalid IL or missing references)
		//IL_0665: Unknown result type (might be due to invalid IL or missing references)
		//IL_0293: Unknown result type (might be due to invalid IL or missing references)
		//IL_0380: Unknown result type (might be due to invalid IL or missing references)
		//IL_0386: Invalid comparison between Unknown and I4
		//IL_01d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01db: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b3: Expected O, but got Unknown
		//IL_0204: Unknown result type (might be due to invalid IL or missing references)
		//IL_020c: Unknown result type (might be due to invalid IL or missing references)
		//IL_041e: Unknown result type (might be due to invalid IL or missing references)
		//IL_042a: Unknown result type (might be due to invalid IL or missing references)
		//IL_045b: Unknown result type (might be due to invalid IL or missing references)
		//IL_045c: Unknown result type (might be due to invalid IL or missing references)
		//IL_045e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0463: Unknown result type (might be due to invalid IL or missing references)
		//IL_0465: Unknown result type (might be due to invalid IL or missing references)
		//IL_0467: Unknown result type (might be due to invalid IL or missing references)
		//IL_0469: Unknown result type (might be due to invalid IL or missing references)
		//IL_046e: Unknown result type (might be due to invalid IL or missing references)
		//IL_068c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0693: Expected O, but got Unknown
		//IL_01ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_04c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_059d: Unknown result type (might be due to invalid IL or missing references)
		//IL_05a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_05ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_05b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_05b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0221: Unknown result type (might be due to invalid IL or missing references)
		//IL_0224: Unknown result type (might be due to invalid IL or missing references)
		//IL_022b: Expected O, but got Unknown
		//IL_022f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0234: Unknown result type (might be due to invalid IL or missing references)
		//IL_0236: Unknown result type (might be due to invalid IL or missing references)
		//IL_023f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0244: Unknown result type (might be due to invalid IL or missing references)
		//IL_0249: Unknown result type (might be due to invalid IL or missing references)
		//IL_0277: Unknown result type (might be due to invalid IL or missing references)
		//IL_027f: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_04d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_04e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0514: Unknown result type (might be due to invalid IL or missing references)
		//IL_051f: Unknown result type (might be due to invalid IL or missing references)
		//IL_052a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0535: Unknown result type (might be due to invalid IL or missing references)
		//IL_05cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_05da: Unknown result type (might be due to invalid IL or missing references)
		//IL_04a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0484: Unknown result type (might be due to invalid IL or missing references)
		//IL_048e: Unknown result type (might be due to invalid IL or missing references)
		Dungeon dungeon = GameManager.Instance.Dungeon;
		tk2dTileMap mainTilemap = dungeon.MainTilemap;
		if ((Object)(object)mainTilemap == (Object)null)
		{
			ETGModConsole.Log((object)"ERROR: TileMap object is null! Something seriously went wrong!", false);
			Debug.Log((object)"ERROR: TileMap object is null! Something seriously went wrong!");
			return null;
		}
		TK2DDungeonAssembler assembler = dungeon.assembler;
		IntVector2 zero = IntVector2.Zero;
		IntVector2 val = default(IntVector2);
		((IntVector2)(ref val))._002Ector(50, 50);
		int x = val.x;
		int y = val.y;
		IntVector2 val2 = default(IntVector2);
		((IntVector2)(ref val2))._002Ector(int.MaxValue, int.MaxValue);
		IntVector2 val3 = default(IntVector2);
		((IntVector2)(ref val3))._002Ector(int.MinValue, int.MinValue);
		val2 = IntVector2.Min(val2, zero);
		val3 = IntVector2.Max(val3, zero + new IntVector2(prototype.Width, prototype.Height));
		IntVector2 val4 = val3 - val2;
		IntVector2 val5 = IntVector2.Min(IntVector2.Zero, -1 * val2);
		val4 += val5;
		IntVector2 val6 = default(IntVector2);
		((IntVector2)(ref val6))._002Ector(dungeon.data.Width + x, x);
		int num = dungeon.data.Width + x * 2 + val4.x;
		int num2 = Mathf.Max(dungeon.data.Height, val4.y + x * 2);
		CellData[][] array = BraveUtility.MultidimensionalArrayResize<CellData>(dungeon.data.cellData, dungeon.data.Width, dungeon.data.Height, num, num2);
		dungeon.data.cellData = array;
		dungeon.data.ClearCachedCellData();
		IntVector2 val7 = default(IntVector2);
		((IntVector2)(ref val7))._002Ector(prototype.Width, prototype.Height);
		IntVector2 val8 = zero + val5;
		IntVector2 val9 = val6 + val8;
		CellArea val10 = new CellArea(val9, val7, 0);
		val10.prototypeRoom = prototype;
		RoomHandler val11 = new RoomHandler(val10);
		for (int i = -x; i < val7.x + x; i++)
		{
			for (int j = -x; j < val7.y + x; j++)
			{
				IntVector2 val12 = new IntVector2(i, j) + val9;
				if ((i >= 0 && j >= 0 && i < val7.x && j < val7.y) || array[val12.x][val12.y] == null)
				{
					CellData val13 = new CellData(val12, (CellType)1);
					val13.positionInTilemap = val13.positionInTilemap - val6 + new IntVector2(y, y);
					val13.parentArea = val10;
					val13.parentRoom = val11;
					val13.nearestRoom = val11;
					val13.distanceFromNearestRoom = 0f;
					array[val12.x][val12.y] = val13;
				}
			}
		}
		dungeon.data.rooms.Add(val11);
		try
		{
			val11.WriteRoomData(dungeon.data);
		}
		catch (Exception)
		{
			if (!suppressExceptionMessages)
			{
				ETGModConsole.Log((object)("WARNING: Exception caused during WriteRoomData step on room: " + val11.GetRoomName()), false);
			}
		}
		try
		{
			dungeon.data.GenerateLightsForRoom(dungeon.decoSettings, val11, GameObject.Find("_Lights").transform, lightStyle);
		}
		catch (Exception)
		{
			if (!suppressExceptionMessages)
			{
				ETGModConsole.Log((object)("WARNING: Exception caused during GeernateLightsForRoom step on room: " + val11.GetRoomName()), false);
			}
		}
		postProcessCellData?.Invoke(val11);
		if ((int)val11.area.PrototypeRoomCategory == 6)
		{
			val11.BuildSecretRoomCover();
		}
		GameObject val14 = (GameObject)Object.Instantiate(BraveResources.Load("RuntimeTileMap", ".prefab"));
		tk2dTileMap component = val14.GetComponent<tk2dTileMap>();
		string text = Random.Range(10000, 99999).ToString();
		((Object)val14).name = "Glitch_RuntimeTilemap_" + text;
		((Object)component.renderData).name = "Glitch_RuntimeTilemap_" + text + " Render Data";
		component.Editor__SpriteCollection = dungeon.tileIndices.dungeonCollection;
		try
		{
			TK2DDungeonAssembler.RuntimeResizeTileMap(component, val4.x + y * 2, val4.y + y * 2, mainTilemap.partitionSizeX, mainTilemap.partitionSizeY);
			IntVector2 val15 = default(IntVector2);
			((IntVector2)(ref val15))._002Ector(prototype.Width, prototype.Height);
			IntVector2 val16 = zero + val5;
			IntVector2 val17 = val6 + val16;
			for (int k = -y; k < val15.x + y; k++)
			{
				for (int l = -y; l < val15.y + y + 2; l++)
				{
					assembler.BuildTileIndicesForCell(dungeon, component, val17.x + k, val17.y + l);
				}
			}
			RenderMeshBuilder.CurrentCellXOffset = val6.x - y;
			RenderMeshBuilder.CurrentCellYOffset = val6.y - y;
			component.ForceBuild();
			RenderMeshBuilder.CurrentCellXOffset = 0;
			RenderMeshBuilder.CurrentCellYOffset = 0;
			component.renderData.transform.position = new Vector3((float)(val6.x - y), (float)(val6.y - y), (float)(val6.y - y));
		}
		catch (Exception ex3)
		{
			if (!suppressExceptionMessages)
			{
				ETGModConsole.Log((object)"WARNING: Exception occured during RuntimeResizeTileMap / RenderMeshBuilder steps!", false);
				Debug.Log((object)"WARNING: Exception occured during RuntimeResizeTileMap/RenderMeshBuilder steps!");
				Debug.LogException(ex3);
			}
		}
		val11.OverrideTilemap = component;
		if (allowProceduralLightFixtures)
		{
			for (int m = 0; m < val11.area.dimensions.x; m++)
			{
				for (int n = 0; n < val11.area.dimensions.y + 2; n++)
				{
					IntVector2 val18 = val11.area.basePosition + new IntVector2(m, n);
					if (dungeon.data.CheckInBoundsAndValid(val18))
					{
						CellData val19 = dungeon.data[val18];
						TK2DInteriorDecorator.PlaceLightDecorationForCell(dungeon, component, val19, val18);
					}
				}
			}
		}
		Pathfinder.Instance.InitializeRegion(dungeon.data, val11.area.basePosition + new IntVector2(-3, -3), val11.area.dimensions + new IntVector2(3, 3));
		if (prototype.usesProceduralDecoration && prototype.allowFloorDecoration && allowProceduralDecoration)
		{
			TK2DInteriorDecorator val20 = new TK2DInteriorDecorator(assembler);
			try
			{
				val20.HandleRoomDecoration(val11, dungeon, mainTilemap);
			}
			catch (Exception ex4)
			{
				ETGModConsole.Log((object)"WARNING: Exception occured during HandleRoomDecoration steps!", false);
				Debug.Log((object)"WARNING: Exception occured during RuntimeResizeTileMap/RenderMeshBuilder steps!");
				Debug.LogException(ex4);
			}
		}
		val11.PostGenerationCleanup();
		if (addRoomToMinimap)
		{
			val11.visibility = (VisibilityStatus)1;
			((MonoBehaviour)GameManager.Instance).StartCoroutine(Minimap.Instance.RevealMinimapRoomInternal(val11, true, true, false));
			if (isSecretRatExitRoom)
			{
				val11.visibility = (VisibilityStatus)0;
			}
		}
		if (addTeleporter)
		{
			val11.AddProceduralTeleporterToRoom();
		}
		if (addRoomToMinimap)
		{
			Minimap.Instance.InitializeMinimap(dungeon.data);
		}
		DeadlyDeadlyGoopManager.ReinitializeData();
		return val11;
	}
}
