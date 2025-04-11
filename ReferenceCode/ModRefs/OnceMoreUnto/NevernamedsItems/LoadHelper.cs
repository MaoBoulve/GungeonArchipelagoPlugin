using System.Collections.Generic;
using UnityEngine;

namespace NevernamedsItems;

internal class LoadHelper
{
	private static string[] BundlePrereqs;

	public static Object LoadAssetFromAnywhere(string path)
	{
		Object val = null;
		string[] bundlePrereqs = BundlePrereqs;
		foreach (string text in bundlePrereqs)
		{
			try
			{
				val = ResourceManager.LoadAssetBundle(text).LoadAsset(path);
			}
			catch
			{
			}
			if (val != (Object)null)
			{
				break;
			}
		}
		if (val == (Object)null)
		{
		}
		return val;
	}

	public static T LoadAssetFromAnywhere<T>(string path) where T : Object
	{
		T val = default(T);
		string[] bundlePrereqs = BundlePrereqs;
		foreach (string text in bundlePrereqs)
		{
			try
			{
				val = ResourceManager.LoadAssetBundle(text).LoadAsset<T>(path);
			}
			catch
			{
			}
			if ((Object)(object)val != (Object)null)
			{
				break;
			}
		}
		if ((Object)(object)val == (Object)null)
		{
		}
		return val;
	}

	public static List<T> Find<T>(string toFind) where T : Object
	{
		List<T> list = new List<T>();
		string[] bundlePrereqs = BundlePrereqs;
		foreach (string text in bundlePrereqs)
		{
			try
			{
				string[] allAssetNames = ResourceManager.LoadAssetBundle(text).GetAllAssetNames();
				foreach (string text2 in allAssetNames)
				{
					if (text2.ToLower().Contains(toFind) && ((object)ResourceManager.LoadAssetBundle(text).LoadAsset(text2)).GetType() == typeof(T) && !list.Contains(ResourceManager.LoadAssetBundle(text).LoadAsset<T>(text2)))
					{
						list.Add(ResourceManager.LoadAssetBundle(text).LoadAsset<T>(text2));
					}
				}
			}
			catch
			{
			}
		}
		return list;
	}

	public static List<Object> Find(string toFind)
	{
		List<Object> list = new List<Object>();
		string[] bundlePrereqs = BundlePrereqs;
		foreach (string text in bundlePrereqs)
		{
			try
			{
				string[] allAssetNames = ResourceManager.LoadAssetBundle(text).GetAllAssetNames();
				foreach (string text2 in allAssetNames)
				{
					if (text2.ToLower().Contains(toFind) && !list.Contains(ResourceManager.LoadAssetBundle(text).LoadAsset(text2)))
					{
						list.Add(ResourceManager.LoadAssetBundle(text).LoadAsset(text2));
					}
				}
			}
			catch
			{
			}
		}
		return list;
	}

	static LoadHelper()
	{
		BundlePrereqs = new string[30]
		{
			"brave_resources_001", "dungeon_scene_001", "encounters_base_001", "enemies_base_001", "flows_base_001", "foyer_001", "foyer_002", "foyer_003", "shared_auto_001", "shared_auto_002",
			"shared_base_001", "dungeons/base_bullethell", "dungeons/base_castle", "dungeons/base_catacombs", "dungeons/base_cathedral", "dungeons/base_forge", "dungeons/base_foyer", "dungeons/base_gungeon", "dungeons/base_mines", "dungeons/base_nakatomi",
			"dungeons/base_resourcefulrat", "dungeons/base_sewer", "dungeons/base_tutorial", "dungeons/finalscenario_bullet", "dungeons/finalscenario_convict", "dungeons/finalscenario_coop", "dungeons/finalscenario_guide", "dungeons/finalscenario_pilot", "dungeons/finalscenario_robot", "dungeons/finalscenario_soldier"
		};
	}
}
