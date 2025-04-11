using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using UnityEngine;

namespace GungeonAPI;

public static class Tools
{
	public static bool verbose = false;

	private static string defaultLog = Path.Combine(ETGMod.ResourcesDirectory, "customCharacterLog.txt");

	public static string modID = "NN";

	private static Dictionary<string, float> timers = new Dictionary<string, float>();

	public static void Init()
	{
		if (File.Exists(defaultLog))
		{
			File.Delete(defaultLog);
		}
	}

	public static void Print<T>(T obj, string color = "FFFFFF", bool force = false)
	{
		if (verbose || force)
		{
			string[] array = obj.ToString().Split('\n');
			string[] array2 = array;
			foreach (string text in array2)
			{
				LogToConsole("<color=#" + color + ">[" + modID + "] " + text + "</color>");
			}
		}
		Log(obj.ToString());
	}

	public static void PrintRaw<T>(T obj, bool force = false)
	{
		if (verbose || force)
		{
			LogToConsole(obj.ToString());
		}
		Log(obj.ToString());
	}

	public static void PrintError<T>(T obj, string color = "FF0000")
	{
		string[] array = obj.ToString().Split('\n');
		string[] array2 = array;
		foreach (string text in array2)
		{
			LogToConsole("<color=#" + color + ">[" + modID + "] " + text + "</color>");
		}
		Log(obj.ToString());
	}

	public static void PrintException(Exception e, string color = "FF0000")
	{
		string text = e.Message + "\n" + e.StackTrace;
		string[] array = text.Split('\n');
		string[] array2 = array;
		foreach (string text2 in array2)
		{
			LogToConsole("<color=#" + color + ">[" + modID + "] " + text2 + "</color>");
		}
		Log(e.Message);
		Log("\t" + e.StackTrace);
	}

	public static void Log<T>(T obj)
	{
		using StreamWriter streamWriter = new StreamWriter(Path.Combine(ETGMod.ResourcesDirectory, defaultLog), append: true);
		streamWriter.WriteLine(obj.ToString());
	}

	public static void Log<T>(T obj, string fileName)
	{
		if (verbose)
		{
			using (StreamWriter streamWriter = new StreamWriter(Path.Combine(ETGMod.ResourcesDirectory, fileName), append: true))
			{
				streamWriter.WriteLine(obj.ToString());
			}
		}
	}

	public static void LogToConsole(string message)
	{
		message.Replace("\t", "    ");
		ETGModConsole.Log((object)message, false);
	}

	private static void BreakdownComponentsInternal(this GameObject obj, int lvl = 0)
	{
		string text = "";
		for (int i = 0; i < lvl; i++)
		{
			text += "\t";
		}
		Log(text + ((Object)obj).name + "...");
		Component[] components = obj.GetComponents<Component>();
		foreach (Component val in components)
		{
			string text2 = text;
			string text3 = "    -";
			Log(text2 + text3 + ((object)val).GetType());
		}
		Transform[] componentsInChildren = obj.GetComponentsInChildren<Transform>();
		foreach (Transform val2 in componentsInChildren)
		{
			if ((Object)(object)val2 != (Object)(object)obj.transform)
			{
				((Component)val2).gameObject.BreakdownComponentsInternal(lvl + 1);
			}
		}
	}

	public static void BreakdownComponents(this GameObject obj)
	{
		obj.BreakdownComponentsInternal();
	}

	public static void ExportTexture(Texture texture, string folder = "")
	{
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Expected O, but got Unknown
		string text = Path.Combine(ETGMod.ResourcesDirectory, folder);
		if (!Directory.Exists(text))
		{
			Directory.CreateDirectory(text);
		}
		File.WriteAllBytes(Path.Combine(text, ((Object)texture).name + DateTime.Now.Ticks + ".png"), ImageConversion.EncodeToPNG((Texture2D)texture));
	}

	public static T GetEnumValue<T>(string val) where T : Enum
	{
		return (T)Enum.Parse(typeof(T), val.ToUpper());
	}

	public static void LogPropertiesAndFields<T>(T obj, string header = "")
	{
		Log(header);
		Log("=======================");
		if (obj == null)
		{
			Log("LogPropertiesAndFields: Null object");
			return;
		}
		Type type = obj.GetType();
		Log($"Type: {type}");
		PropertyInfo[] properties = type.GetProperties();
		Log($"{typeof(T)} Properties: ");
		PropertyInfo[] array = properties;
		foreach (PropertyInfo propertyInfo in array)
		{
			try
			{
				object value = propertyInfo.GetValue(obj, null);
				string text = value.ToString();
				if (obj?.GetType().GetGenericTypeDefinition() == typeof(List<>))
				{
					List<object> list = value as List<object>;
					text = $"List[{list.Count}]";
					foreach (object item in list)
					{
						text = text + "\n\t\t" + item.ToString();
					}
				}
				Log("\t" + propertyInfo.Name + ": " + text);
			}
			catch
			{
			}
		}
		Log($"{typeof(T)} Fields: ");
		FieldInfo[] fields = type.GetFields();
		FieldInfo[] array2 = fields;
		foreach (FieldInfo fieldInfo in array2)
		{
			Log($"\t{fieldInfo.Name}: {fieldInfo.GetValue(obj)}");
		}
	}

	public static void StartTimer(string name)
	{
		string key = name.ToLower();
		if (timers.ContainsKey(key))
		{
			PrintError("Timer " + name + " already exists.");
		}
		else
		{
			timers.Add(key, Time.realtimeSinceStartup);
		}
	}

	public static void StopTimerAndReport(string name)
	{
		string key = name.ToLower();
		if (!timers.ContainsKey(key))
		{
			PrintError("Could not stop timer " + name + ", no such timer exists");
			return;
		}
		float num = timers[key];
		int num2 = (int)((Time.realtimeSinceStartup - num) * 1000f);
		timers.Remove(key);
		Print(name + " finished in " + num2 + "ms");
	}
}
