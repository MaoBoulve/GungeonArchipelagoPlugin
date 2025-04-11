using System;
using System.Collections.Generic;
using Dungeonator;
using UnityEngine;

namespace GungeonAPI;

public static class StaticReferences
{
	public static Dictionary<string, AssetBundle> AssetBundles;

	public static Dictionary<string, GenericRoomTable> RoomTables;

	public static SharedInjectionData subShopTable;

	public static Dictionary<string, string> roomTableMap = new Dictionary<string, string>
	{
		{ "castle", "Castle_RoomTable" },
		{ "gungeon", "Gungeon_RoomTable" },
		{ "mines", "Mines_RoomTable" },
		{ "catacombs", "Catacomb_RoomTable" },
		{ "forge", "Forge_RoomTable" },
		{ "sewer", "Sewer_RoomTable" },
		{ "cathedral", "Cathedral_RoomTable" },
		{ "bullethell", "BulletHell_RoomTable" }
	};

	public static Dictionary<string, string> specialRoomTableMap = new Dictionary<string, string>
	{
		{ "special", "basic special rooms (shrines, etc)" },
		{ "shop", "Shop Room Table" },
		{ "secret", "secret_room_table_01" }
	};

	public static Dictionary<string, string> BossRoomGrabage = new Dictionary<string, string>
	{
		{ "gull", "bosstable_01_gatlinggull" },
		{ "triggertwins", "bosstable_01_bulletbros" },
		{ "bulletking", "bosstable_01_bulletking" },
		{ "blobby", "bosstable_01a_blobulord" },
		{ "gorgun", "bosstable_02_meduzi" },
		{ "beholster", "bosstable_02_beholster" },
		{ "ammoconda", "bosstable_02_bashellisk" },
		{ "oldking", "bosstable_04_oldking" },
		{ "tank", "bosstable_03_tank" },
		{ "cannonballrog", "bosstable_03_powderskull" },
		{ "flayer", "bosstable_03_mineflayer" },
		{ "priest", "bosstable_02a_highpriest" },
		{ "pillars", "bosstable_04_statues" },
		{ "monger", "bosstable_04_demonwall" },
		{ "doorlord", "bosstable_xx_bossdoormimic" }
	};

	public static Dictionary<string, string> MiniBossRoomPools = new Dictionary<string, string>
	{
		{ "blockner", "BlocknerMiniboss_Table_01" },
		{ "shadeagunim", "PhantomAgunim_Table_01" }
	};

	public static string[] assetBundleNames = new string[3] { "shared_auto_001", "shared_auto_002", "brave_resources_001" };

	public static string[] dungeonPrefabNames = new string[8] { "base_gungeon", "base_castle", "base_mines", "base_catacombs", "base_forge", "base_sewer", "base_cathedral", "base_bullethell" };

	public static void Init()
	{
		AssetBundles = new Dictionary<string, AssetBundle>();
		string[] array = assetBundleNames;
		foreach (string text in array)
		{
			try
			{
				AssetBundle val = ResourceManager.LoadAssetBundle(text);
				if ((Object)(object)val == (Object)null)
				{
					Tools.PrintError("Failed to load asset bundle: " + text);
				}
				else
				{
					AssetBundles.Add(text, ResourceManager.LoadAssetBundle(text));
				}
			}
			catch (Exception e)
			{
				Tools.PrintError("Failed to load asset bundle: " + text);
				Tools.PrintException(e);
			}
		}
		RoomTables = new Dictionary<string, GenericRoomTable>();
		foreach (KeyValuePair<string, string> item in roomTableMap)
		{
			try
			{
				GenericRoomTable fallbackRoomTable = DungeonDatabase.GetOrLoadByName("base_" + item.Key).PatternSettings.flows[0].fallbackRoomTable;
				RoomTables.Add(item.Key, fallbackRoomTable);
			}
			catch (Exception e2)
			{
				Tools.PrintError("Failed to load room table: " + item.Key + ":" + item.Value);
				Tools.PrintException(e2);
			}
		}
		foreach (KeyValuePair<string, string> item2 in specialRoomTableMap)
		{
			try
			{
				GenericRoomTable asset = StaticReferences.GetAsset<GenericRoomTable>(item2.Value);
				RoomTables.Add(item2.Key, asset);
			}
			catch (Exception e3)
			{
				Tools.PrintError("Failed to load special room table: " + item2.Key + ":" + item2.Value);
				Tools.PrintException(e3);
			}
		}
		foreach (KeyValuePair<string, string> item3 in BossRoomGrabage)
		{
			try
			{
				GenericRoomTable asset2 = StaticReferences.GetAsset<GenericRoomTable>(item3.Value);
				RoomTables.Add(item3.Key, asset2);
			}
			catch (Exception e4)
			{
				Tools.PrintError("Failed to load special room table: " + item3.Key + ":" + item3.Value);
				Tools.PrintException(e4);
			}
		}
		foreach (KeyValuePair<string, string> miniBossRoomPool in MiniBossRoomPools)
		{
			try
			{
				GenericRoomTable asset3 = StaticReferences.GetAsset<GenericRoomTable>(miniBossRoomPool.Value);
				RoomTables.Add(miniBossRoomPool.Key, asset3);
			}
			catch (Exception e5)
			{
				Tools.PrintError("Failed to load special room table: " + miniBossRoomPool.Key + ":" + miniBossRoomPool.Value);
				Tools.PrintException(e5);
			}
		}
		subShopTable = AssetBundles["shared_auto_001"].LoadAsset<SharedInjectionData>("_global injected subshop table");
		Tools.Print("Static references initialized.");
	}

	public static GenericRoomTable GetRoomTable(ValidTilesets tileset)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0004: Unknown result type (might be due to invalid IL or missing references)
		//IL_0005: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Invalid comparison between Unknown and I4
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Invalid comparison between Unknown and I4
		//IL_000a: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Expected I4, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Invalid comparison between Unknown and I4
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Invalid comparison between Unknown and I4
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Invalid comparison between Unknown and I4
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Invalid comparison between Unknown and I4
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Invalid comparison between Unknown and I4
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Invalid comparison between Unknown and I4
		if ((int)tileset <= 16)
		{
			switch (tileset - 1)
			{
			default:
				if ((int)tileset != 8)
				{
					if ((int)tileset != 16)
					{
						break;
					}
					return RoomTables["mines"];
				}
				return RoomTables["cathedral"];
			case 1:
				return RoomTables["castle"];
			case 0:
				return RoomTables["gungeon"];
			case 3:
				return RoomTables["sewer"];
			case 2:
				break;
			}
		}
		else if ((int)tileset <= 64)
		{
			if ((int)tileset == 32)
			{
				return RoomTables["catacombs"];
			}
			if ((int)tileset == 64)
			{
				return RoomTables["forge"];
			}
		}
		else
		{
			if ((int)tileset == 128)
			{
				return RoomTables["bullethell"];
			}
			if ((int)tileset == 32768)
			{
				ETGModConsole.Log((object)"CANNOT ADD TO RAT FLOOR. DEFAULTING TO GUNGEON PROPER", false);
				return RoomTables["gungeon"];
			}
		}
		return RoomTables["gungeon"];
	}

	public static T GetAsset<T>(string assetName) where T : Object
	{
		T val = default(T);
		foreach (AssetBundle value in AssetBundles.Values)
		{
			val = value.LoadAsset<T>(assetName);
			if ((Object)(object)val != (Object)null)
			{
				break;
			}
		}
		return val;
	}
}
