using System;
using System.Collections;
using System.Reflection;
using Alexandria.ItemAPI;
using BepInEx;
using SGUI;
using UnityEngine;

namespace Mod;

[BepInDependency(/*Could not decode attribute arguments.*/)]
[BepInDependency(/*Could not decode attribute arguments.*/)]
[BepInPlugin("an3s.etg.noScaling", "No Enemy Health Scaling", "1.0.0")]
public class ScalingModule : BaseUnityPlugin
{
	public const string GUID = "an3s.etg.noScaling";

	public const string NAME = "No Enemy Health Scaling";

	public const string VERSION = "1.0.0";

	public const string TEXT_COLOR = "#00FFFF";

	public void Start()
	{
		ETGModMainBehaviour.WaitForGameManagerStart((Action<GameManager>)GMStart);
	}

	public void GMStart(GameManager g)
	{
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			ETGMod.StartGlobalCoroutine(DelayedStartCR());
		}
		catch (Exception ex)
		{
			((SElement)ETGModConsole.Log((object)ex, false)).Colors[0] = Color.red;
		}
	}

	public IEnumerator DelayedStartCR()
	{
		yield return null;
		DelayedStart();
	}

	public void DelayedStart()
	{
		//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00be: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
		for (int i = 0; i < GameManager.Instance.dungeonFloors.Count; i++)
		{
			GameManager.Instance.GetLevelDefinitionFromName(GameManager.Instance.dungeonFloors[i].dungeonSceneName).enemyHealthMultiplier = 1f;
		}
		for (int j = 0; j < GameManager.Instance.customFloors.Count; j++)
		{
			GameManager.Instance.GetLevelDefinitionFromName(GameManager.Instance.customFloors[j].dungeonSceneName).enemyHealthMultiplier = 1f;
		}
		SLabel val = ETGModConsole.Log((object)"No Enemy Health Scaling v1.0.0 started successfully.", false);
		((SElement)val).Colors[0] = Color32.op_Implicit(new Color32((byte)23, (byte)235, (byte)196, byte.MaxValue));
		val.Icon = (Texture)(object)ResourceExtractor.GetTextureFromResource("NoScalingMod/icon.png", (Assembly)null);
	}
}
