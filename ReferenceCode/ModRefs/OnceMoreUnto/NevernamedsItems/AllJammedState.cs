using System;
using System.Reflection;
using MonoMod.RuntimeDetour;
using SaveAPI;

namespace NevernamedsItems;

public class AllJammedState
{
	public static Hook sreaperStartHook;

	public static bool AllJammedActive => SaveAPIManager.GetFlag(CustomDungeonFlags.ALLJAMMEDMODE_ENABLED_CONSOLE) || SaveAPIManager.GetFlag(CustomDungeonFlags.ALLJAMMEDMODE_ENABLED_GENUINE);

	public static void Init()
	{
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Expected O, but got Unknown
		SaveAPIManager.SetFlag(CustomDungeonFlags.ALLJAMMEDMODE_ENABLED_CONSOLE, value: false);
		SaveAPIManager.SetFlag(CustomDungeonFlags.ALLJAMMEDMODE_ENABLED_GENUINE, value: false);
		AIActor.OnPreStart = (Action<AIActor>)Delegate.Combine(AIActor.OnPreStart, new Action<AIActor>(makeJammed));
		sreaperStartHook = new Hook((MethodBase)typeof(SuperReaperController).GetMethod("Start", BindingFlags.Instance | BindingFlags.NonPublic), typeof(AllJammedState).GetMethod("SreaperAwakeHook"));
	}

	private static void makeJammed(AIActor enemy)
	{
		if (SaveAPIManager.GetFlag(CustomDungeonFlags.ALLJAMMEDMODE_ENABLED_CONSOLE) || SaveAPIManager.GetFlag(CustomDungeonFlags.ALLJAMMEDMODE_ENABLED_GENUINE))
		{
			enemy.BecomeBlackPhantom();
		}
	}

	public static void SreaperAwakeHook(Action<SuperReaperController> orig, SuperReaperController self)
	{
		orig(self);
		if (SaveAPIManager.GetFlag(CustomDungeonFlags.ALLJAMMEDMODE_ENABLED_CONSOLE) || SaveAPIManager.GetFlag(CustomDungeonFlags.ALLJAMMEDMODE_ENABLED_GENUINE))
		{
			self.BecomeJammedLord();
		}
	}
}
