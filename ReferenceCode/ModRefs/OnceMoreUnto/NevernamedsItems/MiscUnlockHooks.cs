using System;
using System.Reflection;
using MonoMod.RuntimeDetour;
using SaveAPI;

namespace NevernamedsItems;

internal class MiscUnlockHooks
{
	public static Hook ShrineUseHook;

	public static Hook BelloAngerHook;

	public static void InitHooks()
	{
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Expected O, but got Unknown
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Expected O, but got Unknown
		ShrineUseHook = new Hook((MethodBase)typeof(AdvancedShrineController).GetMethod("DoShrineEffect", BindingFlags.Instance | BindingFlags.NonPublic), typeof(MiscUnlockHooks).GetMethod("OnShrineUsed", BindingFlags.Static | BindingFlags.Public));
		BelloAngerHook = new Hook((MethodBase)typeof(BaseShopController).GetMethod("OnProjectileCreated", BindingFlags.Instance | BindingFlags.NonPublic), typeof(MiscUnlockHooks).GetMethod("BelloFiredBullet", BindingFlags.Static | BindingFlags.Public));
	}

	public static void OnShrineUsed(Action<AdvancedShrineController, PlayerController> orig, AdvancedShrineController self, PlayerController playa)
	{
		if (self.displayTextKey == "#SHRINE_FALLEN_ANGEL_DISPLAY" && !SaveAPIManager.GetFlag(CustomDungeonFlags.USEDFALLENANGELSHRINE))
		{
			SaveAPIManager.SetFlag(CustomDungeonFlags.USEDFALLENANGELSHRINE, value: true);
		}
		orig(self, playa);
	}

	public static void BelloFiredBullet(Action<BaseShopController, Projectile> orig, BaseShopController self, Projectile firedShot)
	{
		orig(self, firedShot);
		if (!SaveAPIManager.GetFlag(CustomDungeonFlags.ANGERED_BELLO))
		{
			SaveAPIManager.SetFlag(CustomDungeonFlags.ANGERED_BELLO, value: true);
		}
	}
}
