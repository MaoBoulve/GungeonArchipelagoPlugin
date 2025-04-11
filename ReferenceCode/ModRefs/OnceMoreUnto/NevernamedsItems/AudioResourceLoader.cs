using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;

namespace NevernamedsItems;

public class AudioResourceLoader
{
	public static void InitAudio()
	{
		AutoloadFromAssembly(Assembly.GetExecutingAssembly(), "NevernamedsItems");
	}

	public static void AutoloadFromAssembly(Assembly assembly, string prefix)
	{
		if (assembly == null)
		{
			throw new ArgumentNullException("assembly", "Assembly cannot be null.");
		}
		if (prefix == null)
		{
			throw new ArgumentNullException("prefix", "Prefix name cannot be null.");
		}
		prefix = prefix.Trim();
		if (prefix == "")
		{
			throw new ArgumentException("Prefix name cannot be an empty (or whitespace only) string.", "prefix");
		}
		List<string> list = new List<string>(assembly.GetManifestResourceNames());
		for (int i = 0; i < list.Count; i++)
		{
			string text = list[i];
			string text2 = text;
			text2 = text2.Replace('/', Path.DirectorySeparatorChar);
			text2 = text2.Replace('\\', Path.DirectorySeparatorChar);
			if (text2.IndexOf(prefix) != 0)
			{
				continue;
			}
			text2 = text2.Substring(text2.IndexOf(prefix) + prefix.Length);
			if (text2.LastIndexOf(".bnk") == text2.Length - ".bnk".Length)
			{
				text2 = text2.Substring(0, text2.Length - ".bnk".Length);
				if (text2.IndexOf(Path.DirectorySeparatorChar) == 0)
				{
					text2 = text2.Substring(1);
				}
				text2 = prefix + ":" + text2;
				using Stream stream = assembly.GetManifestResourceStream(text);
				LoadSoundbankFromStream(stream, text2);
			}
		}
	}

	private static void LoadSoundbankFromStream(Stream stream, string name)
	{
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		byte[] array = StreamToByteArray(stream);
		IntPtr intPtr = Marshal.AllocHGlobal(array.Length);
		try
		{
			Marshal.Copy(array, 0, intPtr, array.Length);
			uint num = default(uint);
			AKRESULT val = AkSoundEngine.LoadAndDecodeBankFromMemory(intPtr, (uint)array.Length, false, name, false, ref num);
		}
		finally
		{
			Marshal.FreeHGlobal(intPtr);
		}
	}

	public static byte[] StreamToByteArray(Stream input)
	{
		byte[] array = new byte[16384];
		using MemoryStream memoryStream = new MemoryStream();
		int count;
		while ((count = input.Read(array, 0, array.Length)) > 0)
		{
			memoryStream.Write(array, 0, count);
		}
		return memoryStream.ToArray();
	}
}
