using System;
using Gunfiguration;
using UnityEngine;

namespace NevernamedsItems;

public static class Gunfigs
{
	internal static Gunfig _Gunfig;

	internal const string DISABLE_GUILLOTINE = "Portcullis Trap Replacements";

	internal static void Init()
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		_Gunfig = Gunfig.Get(GunfigHelpers.WithColor("Once More Into The Breach", Color.white));
		_Gunfig.AddToggle("Portcullis Trap Replacements", false, (string)null, (Action<string, string>)null, (Update)0);
	}
}
