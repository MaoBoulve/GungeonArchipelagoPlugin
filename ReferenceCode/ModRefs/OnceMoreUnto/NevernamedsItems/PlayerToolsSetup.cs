using System;
using System.Reflection;
using MonoMod.RuntimeDetour;
using UnityEngine;

namespace NevernamedsItems;

internal class PlayerToolsSetup
{
	public static Hook playerStartHook;

	public static void Init()
	{
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		playerStartHook = new Hook((MethodBase)typeof(PlayerController).GetMethod("Start", BindingFlags.Instance | BindingFlags.Public), typeof(PlayerToolsSetup).GetMethod("DoSetup"));
	}

	public static void DoSetup(Action<PlayerController> action, PlayerController player)
	{
		action(player);
		if ((Object)(object)((Component)player).GetComponent<PlayerToolbox>() == (Object)null)
		{
			((Component)player).gameObject.AddComponent<PlayerToolbox>();
		}
	}
}
