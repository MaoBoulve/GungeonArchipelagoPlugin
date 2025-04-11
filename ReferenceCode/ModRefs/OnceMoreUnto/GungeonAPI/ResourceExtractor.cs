using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using UnityEngine;

namespace GungeonAPI;

public static class ResourceExtractor
{
	private static string spritesDirectory = Path.Combine(ETGMod.ResourcesDirectory, "sprites");

	public static List<Texture2D> GetTexturesFromDirectory(string directoryPath)
	{
		if (!Directory.Exists(directoryPath))
		{
			Tools.PrintError(directoryPath + " not found.");
			return null;
		}
		List<Texture2D> list = new List<Texture2D>();
		string[] files = Directory.GetFiles(directoryPath);
		foreach (string text in files)
		{
			if (text.EndsWith(".png"))
			{
				Texture2D item = BytesToTexture(File.ReadAllBytes(text), Path.GetFileName(text).Replace(".png", ""));
				list.Add(item);
			}
		}
		return list;
	}

	public static Texture2D GetTextureFromFile(string fileName, string extension = ".png")
	{
		fileName = fileName.Replace(extension, "");
		string text = Path.Combine(spritesDirectory, fileName + extension);
		if (!File.Exists(text))
		{
			Tools.PrintError(text + " not found.");
			return null;
		}
		return BytesToTexture(File.ReadAllBytes(text), fileName);
	}

	public static List<string> GetCollectionFiles()
	{
		List<string> list = new List<string>();
		string[] files = Directory.GetFiles(spritesDirectory);
		foreach (string text in files)
		{
			if (text.EndsWith(".png"))
			{
				list.Add(Path.GetFileName(text).Replace(".png", ""));
			}
		}
		return list;
	}

	public static Texture2D BytesToTexture(byte[] bytes, string resourceName)
	{
		//IL_0005: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Expected O, but got Unknown
		Texture2D val = new Texture2D(1, 1, (TextureFormat)4, false);
		ImageConversion.LoadImage(val, bytes);
		((Texture)val).filterMode = (FilterMode)0;
		((Object)val).name = resourceName;
		return val;
	}

	public static string[] GetLinesFromEmbeddedResource(string filePath)
	{
		string text = BytesToString(ExtractEmbeddedResource(filePath));
		return text.Split('\n');
	}

	public static string[] GetLinesFromFile(string filePath)
	{
		string text = BytesToString(File.ReadAllBytes(filePath));
		return text.Split('\n');
	}

	public static string BytesToString(byte[] bytes)
	{
		return Encoding.UTF8.GetString(bytes, 0, bytes.Length);
	}

	public static List<string> GetResourceFolders()
	{
		List<string> list = new List<string>();
		string path = Path.Combine(ETGMod.ResourcesDirectory, "sprites");
		if (Directory.Exists(path))
		{
			string[] directories = Directory.GetDirectories(path);
			foreach (string path2 in directories)
			{
				list.Add(Path.GetFileName(path2));
			}
		}
		return list;
	}

	public static byte[] ExtractEmbeddedResource(string filePath)
	{
		filePath = filePath.Replace("/", ".");
		filePath = filePath.Replace("\\", ".");
		Assembly callingAssembly = Assembly.GetCallingAssembly();
		using Stream stream = callingAssembly.GetManifestResourceStream(filePath);
		if (stream == null)
		{
			return null;
		}
		byte[] array = new byte[stream.Length];
		stream.Read(array, 0, array.Length);
		return array;
	}

	public static Texture2D GetTextureFromResource(string resourceName)
	{
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Expected O, but got Unknown
		byte[] array = ExtractEmbeddedResource(resourceName);
		if (array == null)
		{
			Tools.PrintError("No bytes found in " + resourceName);
			return null;
		}
		Texture2D val = new Texture2D(1, 1, (TextureFormat)20, false);
		ImageConversion.LoadImage(val, array);
		((Texture)val).filterMode = (FilterMode)0;
		string text = resourceName.Substring(0, resourceName.LastIndexOf('.'));
		if (text.LastIndexOf('.') >= 0)
		{
			text = text.Substring(text.LastIndexOf('.') + 1);
		}
		((Object)val).name = text;
		return val;
	}

	public static string[] GetResourceNames()
	{
		Assembly callingAssembly = Assembly.GetCallingAssembly();
		string[] manifestResourceNames = callingAssembly.GetManifestResourceNames();
		if (manifestResourceNames == null)
		{
			ETGModConsole.Log((object)"No manifest resources found.", false);
			return null;
		}
		return manifestResourceNames;
	}
}
