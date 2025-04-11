using System;
using System.Reflection;
using BepInEx;
using Gunfiguration;
using HarmonyLib;
using MonoMod.RuntimeDetour;
using UnityEngine;

namespace OopsAllJammed;

[BepInDependency(/*Could not decode attribute arguments.*/)]
[BepInDependency(/*Could not decode attribute arguments.*/)]
[BepInPlugin("SimplyFenton.etg.oopsalljammed", "Oops All Jammed", "1.0.9")]
public class Plugin : BaseUnityPlugin
{
	public const string GUID = "SimplyFenton.etg.oopsalljammed";

	public const string NAME = "Oops All Jammed";

	public const string VERSION = "1.0.9";

	public const string TEXT_COLOR = "#00FFFF";

	public static bool AllJammed = true;

	public static bool PreventUnJam = true;

	public static bool JamMinecarts = true;

	public static bool JamProjectileTraps = true;

	public static bool JamWizard = true;

	public static bool JamHammer = true;

	public static bool JamStatuses = true;

	public static bool JamFlamePipe = true;

	public static bool JamBasicTraps = true;

	public static bool JamPathingTraps = true;

	public static bool JamPits = true;

	public static bool JamExplosions = true;

	public static bool JamLordOfTheJammed = true;

	public static bool JamRatTraps = true;

	public static Shader bulletShader;

	public static Material bulletMaterial;

	public static bool JamCrushDoors { get; set; }

	public void Start()
	{
		ETGModMainBehaviour.WaitForGameManagerStart((Action<GameManager>)GMStart);
		Init();
	}

	private void makeJammed(AIActor enemy)
	{
		if (AllJammed && enemy.IsNormalEnemy)
		{
			enemy.ForceBlackPhantom = true;
		}
	}

	public static void reJamHook(Action<AIActor> orig, AIActor self)
	{
		orig(self);
		if (AllJammed)
		{
			self.ForceBlackPhantom = true;
			self.BecomeBlackPhantom();
		}
	}

	public static void forceJam(AIActor actor)
	{
		if (AllJammed && actor.IsNormalEnemy && PreventUnJam)
		{
			actor.ForceBlackPhantom = true;
			actor.BecomeBlackPhantom();
		}
	}

	public void SetAllJammed(bool jammed)
	{
		AllJammed = jammed;
	}

	public void SetPreventUnJam(bool prevent)
	{
		PreventUnJam = prevent;
	}

	public void SetJamMinecarts(bool jammed)
	{
		JamMinecarts = jammed;
	}

	public void SetJamProjectileTraps(bool jammed)
	{
		JamProjectileTraps = jammed;
	}

	public void SetJamWizard(bool jammed)
	{
		JamWizard = jammed;
	}

	public void SetJamHammers(bool jammed)
	{
		JamHammer = jammed;
	}

	public void SetJamStatuses(bool jammed)
	{
		JamStatuses = jammed;
	}

	public void SetJamFlamePipes(bool jammed)
	{
		JamFlamePipe = jammed;
	}

	public void SetJamCrushDoors(bool jammed)
	{
		JamCrushDoors = jammed;
	}

	public void SetJamBasicTraps(bool jammed)
	{
		JamBasicTraps = jammed;
	}

	public void SetJamPathingTraps(bool jammed)
	{
		JamPathingTraps = jammed;
	}

	public void SetJamPits(bool jammed)
	{
		JamPits = jammed;
	}

	public void SetJamExplosions(bool jammed)
	{
		JamExplosions = jammed;
	}

	public void SetJamLOTJ(bool jammed)
	{
		JamLordOfTheJammed = jammed;
	}

	public void Exit()
	{
		AllJammed = false;
	}

	public void Init()
	{
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		AIActor.OnBlackPhantomnessCheck = (Action<AIActor>)Delegate.Combine(AIActor.OnBlackPhantomnessCheck, new Action<AIActor>(makeJammed));
		AIActor.OnPreStart = (Action<AIActor>)Delegate.Combine(AIActor.OnPreStart, new Action<AIActor>(forceJam));
		new Hook((MethodBase)typeof(AIActor).GetMethod("UnbecomeBlackPhantom", BindingFlags.Instance | BindingFlags.Public), typeof(Plugin).GetMethod("reJamHook"));
	}

	public void GMStart(GameManager g)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Expected O, but got Unknown
		Harmony harmony = new Harmony("SimplyFenton.etg.oopsalljammed");
		HarmonyPatches.Patch(harmony);
		Log("Oops All Jammed v1.0.9 started successfully.", "#00FFFF");
		JammedConfig.Init(this);
	}

	public static void Log(string text, string color = "#FFFFFF")
	{
		ETGModConsole.Log((object)("<color=" + color + ">" + text + "</color>"), false);
	}
}
