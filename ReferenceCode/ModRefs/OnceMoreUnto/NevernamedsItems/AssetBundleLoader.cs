using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

namespace NevernamedsItems;

internal class AssetBundleLoader
{
	public static tk2dSpriteCollectionData FastLoadSpriteCollection(AssetBundle bundle, string CollectionName, string MaterialName)
	{
		if ((Object)(object)bundle == (Object)null)
		{
			ETGModConsole.Log((object)"ASSET BUNDLE WAS NULL.", false);
			return null;
		}
		if ((Object)(object)bundle.LoadAsset<GameObject>(CollectionName) == (Object)null)
		{
			ETGModConsole.Log((object)("COLLECTION '" + CollectionName + "' WAS NULL"), false);
			return null;
		}
		tk2dSpriteCollectionData component = bundle.LoadAsset<GameObject>(CollectionName).GetComponent<tk2dSpriteCollectionData>();
		Material val = bundle.LoadAsset<Material>(MaterialName);
		Texture texture = val.GetTexture("_MainTex");
		texture.filterMode = (FilterMode)0;
		val.SetTexture("_MainTex", texture);
		component.material = val;
		component.materials = (Material[])(object)new Material[1] { val };
		component.materialInsts = (Material[])(object)new Material[1] { val };
		tk2dSpriteDefinition[] spriteDefinitions = component.spriteDefinitions;
		foreach (tk2dSpriteDefinition val2 in spriteDefinitions)
		{
			val2.material = component.materials[0];
			val2.materialInst = component.materials[0];
			val2.materialId = 0;
		}
		return component;
	}

	public static AssetBundle LoadAssetBundleFromLiterallyAnywhere(string name, bool logs = false)
	{
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000a: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Invalid comparison between Unknown and I4
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Invalid comparison between Unknown and I4
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Invalid comparison between Unknown and I4
		AssetBundle val = null;
		RuntimePlatform platform = Application.platform;
		RuntimePlatform val2 = platform;
		string path = (((int)val2 <= 1) ? "MacOS" : (((int)val2 != 13 && (int)val2 != 16) ? "Windows" : "Linux"));
		string text = Path.Combine(Path.Combine(Initialisation.FilePathFolder, path), name);
		if (File.Exists(text))
		{
			try
			{
				val = AssetBundle.LoadFromFile(text);
				if (logs)
				{
					ETGModConsole.Log((object)"Successfully loaded assetbundle!", false);
				}
			}
			catch (Exception ex)
			{
				ETGModConsole.Log((object)"Failed loading asset bundle from file.", false);
				ETGModConsole.Log((object)ex.ToString(), false);
			}
		}
		else
		{
			ETGModConsole.Log((object)"AssetBundle NOT FOUND!", false);
		}
		if ((Object)(object)val != (Object)null)
		{
			IEnumerable<tk2dSpriteCollectionData> enumerable = val.LoadAllAssets<GameObject>().SelectMany((GameObject x) => x.GetComponents<tk2dSpriteCollectionData>());
			Dictionary<string, string> dictionary = new Dictionary<string, string>
			{
				{ "GunCollection", "tk2d/CutoutVertexColorTilted" },
				{ "GunCollection2", "tk2d/CutoutVertexColorTilted" }
			};
			foreach (tk2dSpriteCollectionData item in enumerable)
			{
				if (!dictionary.TryGetValue(item.spriteCollectionName, out var value))
				{
					continue;
				}
				Shader shader = ShaderCache.Acquire(value);
				Material[] materials = item.materials;
				foreach (Material val3 in materials)
				{
					if (!((Object)(object)val3 == (Object)null))
					{
						val3.shader = shader;
					}
				}
			}
		}
		return val;
	}
}
