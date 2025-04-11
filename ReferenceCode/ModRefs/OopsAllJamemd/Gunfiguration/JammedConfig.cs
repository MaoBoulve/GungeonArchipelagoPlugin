using System;
using OopsAllJammed;
using UnityEngine;

namespace Gunfiguration;

public static class JammedConfig
{
	internal static Gunfig _Gunfig;

	internal const string AllJammed = "Make All Enemies In The Game Jammed";

	internal const string PreventUnJam = "Prevent Enemies From Being Un-Jammed";

	internal const string JamMinecartTurrets = "Make Minecart Turrets Jammed";

	internal const string JamProjectileTraps = "Make Projectile Traps Jammed";

	internal const string JamGunjurers = "Make Gunjurers Jammed";

	internal const string JamHammers = "Make Hammers Jammed";

	internal const string JamStatuses = "Make Fire, Poision And Electricity Jammed";

	internal const string JamFlamePipes = "Make Flame Pipes Jammed";

	internal const string JamCrushDoors = "Make Crush Doors Jammed";

	internal const string JamBasicTraps = "Make Basic Traps (Flames, Spikes) Jammed";

	internal const string JamPathingTraps = "Make Pathing Traps (Saws, Rolling Spikes) Jammed";

	internal const string JamPits = "Make Pits Jammed";

	internal const string JamExplosions = "Make Explosions Jammed";

	internal const string JamLordOfTheJammed = "Make Lord Of The Jammed Jammed";

	internal static void Init(Plugin parent)
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		_Gunfig = Gunfig.Get(GunfigHelpers.WithColor("All Jammed", Color.white));
		parent.SetAllJammed(_Gunfig.Enabled("Make All Enemies In The Game Jammed"));
		parent.SetPreventUnJam(_Gunfig.Enabled("Prevent Enemies From Being Un-Jammed"));
		parent.SetJamMinecarts(_Gunfig.Enabled("Make Minecart Turrets Jammed"));
		parent.SetJamProjectileTraps(_Gunfig.Enabled("Make Projectile Traps Jammed"));
		parent.SetJamWizard(_Gunfig.Enabled("Make Gunjurers Jammed"));
		parent.SetJamHammers(_Gunfig.Enabled("Make Hammers Jammed"));
		parent.SetJamStatuses(_Gunfig.Enabled("Make Fire, Poision And Electricity Jammed"));
		parent.SetJamFlamePipes(_Gunfig.Enabled("Make Flame Pipes Jammed"));
		parent.SetJamCrushDoors(_Gunfig.Enabled("Make Crush Doors Jammed"));
		parent.SetJamBasicTraps(_Gunfig.Enabled("Make Basic Traps (Flames, Spikes) Jammed"));
		parent.SetJamPathingTraps(_Gunfig.Enabled("Make Pathing Traps (Saws, Rolling Spikes) Jammed"));
		parent.SetJamPits(_Gunfig.Enabled("Make Pits Jammed"));
		parent.SetJamExplosions(_Gunfig.Enabled("Make Explosions Jammed"));
		parent.SetJamLOTJ(_Gunfig.Enabled("Make Lord Of The Jammed Jammed"));
		_Gunfig.AddToggle("Make All Enemies In The Game Jammed", true, (string)null, (Action<string, string>)delegate(string optionKey, string optionValue)
		{
			parent.SetAllJammed(optionValue == "1");
		}, (Update)1);
		_Gunfig.AddToggle("Prevent Enemies From Being Un-Jammed", true, (string)null, (Action<string, string>)delegate(string optionKey, string optionValue)
		{
			parent.SetPreventUnJam(optionValue == "1");
		}, (Update)1);
		_Gunfig.AddToggle("Make Minecart Turrets Jammed", true, (string)null, (Action<string, string>)delegate(string optionKey, string optionValue)
		{
			parent.SetJamMinecarts(optionValue == "1");
		}, (Update)1);
		_Gunfig.AddToggle("Make Projectile Traps Jammed", true, (string)null, (Action<string, string>)delegate(string optionKey, string optionValue)
		{
			parent.SetJamProjectileTraps(optionValue == "1");
		}, (Update)1);
		_Gunfig.AddToggle("Make Gunjurers Jammed", true, (string)null, (Action<string, string>)delegate(string optionKey, string optionValue)
		{
			parent.SetJamWizard(optionValue == "1");
		}, (Update)1);
		_Gunfig.AddToggle("Make Hammers Jammed", true, (string)null, (Action<string, string>)delegate(string optionKey, string optionValue)
		{
			parent.SetJamHammers(optionValue == "1");
		}, (Update)1);
		_Gunfig.AddToggle("Make Fire, Poision And Electricity Jammed", true, (string)null, (Action<string, string>)delegate(string optionKey, string optionValue)
		{
			parent.SetJamStatuses(optionValue == "1");
		}, (Update)1);
		_Gunfig.AddToggle("Make Flame Pipes Jammed", true, (string)null, (Action<string, string>)delegate(string optionKey, string optionValue)
		{
			parent.SetJamFlamePipes(optionValue == "1");
		}, (Update)1);
		_Gunfig.AddToggle("Make Crush Doors Jammed", true, (string)null, (Action<string, string>)delegate(string optionKey, string optionValue)
		{
			parent.SetJamCrushDoors(optionValue == "1");
		}, (Update)1);
		_Gunfig.AddToggle("Make Basic Traps (Flames, Spikes) Jammed", true, (string)null, (Action<string, string>)delegate(string optionKey, string optionValue)
		{
			parent.SetJamBasicTraps(optionValue == "1");
		}, (Update)1);
		_Gunfig.AddToggle("Make Pathing Traps (Saws, Rolling Spikes) Jammed", true, (string)null, (Action<string, string>)delegate(string optionKey, string optionValue)
		{
			parent.SetJamPathingTraps(optionValue == "1");
		}, (Update)1);
		_Gunfig.AddToggle("Make Pits Jammed", true, (string)null, (Action<string, string>)delegate(string optionKey, string optionValue)
		{
			parent.SetJamPits(optionValue == "1");
		}, (Update)1);
		_Gunfig.AddToggle("Make Explosions Jammed", true, (string)null, (Action<string, string>)delegate(string optionKey, string optionValue)
		{
			parent.SetJamExplosions(optionValue == "1");
		}, (Update)1);
		_Gunfig.AddToggle("Make Lord Of The Jammed Jammed", true, (string)null, (Action<string, string>)delegate(string optionKey, string optionValue)
		{
			parent.SetJamLOTJ(optionValue == "1");
		}, (Update)1);
	}
}
