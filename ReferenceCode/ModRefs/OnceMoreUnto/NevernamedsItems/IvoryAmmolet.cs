using System;
using System.Reflection;
using Alexandria.ItemAPI;
using MonoMod.RuntimeDetour;
using UnityEngine;

namespace NevernamedsItems;

public class IvoryAmmolet : PassiveItem
{
	public delegate void Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 t10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15);

	private static Hook blankPickupHook;

	public static int IvoryAmmoletID;

	private static Hook BlankHook;

	public static void Init()
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_008c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0096: Expected O, but got Unknown
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Expected O, but got Unknown
		PickupObject val = ItemSetup.NewItem<IvoryAmmolet>("Ivory Ammolet", "Tiny Blanks", "Makes your blanks weaker, but gives you more of them.\n\nCarved from rare Dragun ivory.", "ivoryammolet_icon", assetbundle: true);
		val.quality = (ItemQuality)2;
		ItemBuilder.AddPassiveStatModifier(val, (StatType)18, 2f, (ModifyMethod)0);
		ItemBuilder.AddToSubShop(val, (ShopType)4, 1f);
		IvoryAmmoletID = val.PickupObjectId;
		AlexandriaTags.SetTag(val, "ammolet");
		BlankHook = new Hook((MethodBase)typeof(SilencerInstance).GetMethod("TriggerSilencer", BindingFlags.Instance | BindingFlags.Public), typeof(IvoryAmmolet).GetMethod("BlankModHook", BindingFlags.Instance | BindingFlags.Public), (object)typeof(SilencerInstance));
		blankPickupHook = new Hook((MethodBase)typeof(SilencerItem).GetMethod("Pickup", BindingFlags.Instance | BindingFlags.Public), typeof(IvoryAmmolet).GetMethod("blankPickupHookMethod"));
	}

	public override void Pickup(PlayerController player)
	{
		if (!base.m_pickedUpThisRun)
		{
			LootEngine.GivePrefabToPlayer(((Component)PickupObjectDatabase.GetById(224)).gameObject, player);
		}
		((PassiveItem)this).Pickup(player);
	}

	public void BlankModHook(Action<SilencerInstance, Vector2, float, float, GameObject, float, float, float, float, float, float, float, PlayerController, bool, bool> orig, SilencerInstance silencer, Vector2 pos, float expandSpeed, float maxRadius, GameObject vfx, float distIntensity, float distRadius, float pushForce, float pushRadius, float knockbackForce, float knockbackRadius, float additionalTimeAtMaxRadius, PlayerController user, bool breaksWalls = true, bool skipBreakables = true)
	{
		//IL_0124: Unknown result type (might be due to invalid IL or missing references)
		//IL_009d: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Expected O, but got Unknown
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		if (Object.op_Implicit((Object)(object)silencer) && !silencer.ForceNoDamage && (Object)(object)user != (Object)null)
		{
			if (user.HasPickupID(IvoryAmmoletID))
			{
				GameObject arg = (GameObject)ResourceCache.Acquire("Global VFX/BlankVFX_Ghost");
				orig(silencer, pos, expandSpeed * 0.5f, maxRadius / 5f, arg, 0f, 0f, pushForce / 16f, pushRadius / 3f, knockbackForce * 0.5f, knockbackRadius / 3f, additionalTimeAtMaxRadius * 0.5f, user, breaksWalls, skipBreakables);
			}
			else
			{
				orig(silencer, pos, expandSpeed, maxRadius, vfx, distIntensity, distRadius, pushForce, pushRadius, knockbackForce, knockbackRadius, additionalTimeAtMaxRadius, user, breaksWalls, skipBreakables);
			}
			return;
		}
		Debug.Log((object)("Ivory Ammolet Silencer Hook: DEFAULTED TO BASE. Silencer: " + ((Object)(object)silencer == (Object)null) + "Owner: " + ((Object)(object)user == (Object)null) + " ForceNoDMG: " + silencer.ForceNoDamage));
		orig(silencer, pos, expandSpeed, maxRadius, vfx, distIntensity, distRadius, pushForce, pushRadius, knockbackForce, knockbackRadius, additionalTimeAtMaxRadius, user, breaksWalls, skipBreakables);
	}

	public static void blankPickupHookMethod(Action<SilencerItem, PlayerController> orig, SilencerItem self, PlayerController player)
	{
		orig(self, player);
		if (Object.op_Implicit((Object)(object)self) && Object.op_Implicit((Object)(object)player) && player.HasPickupID(IvoryAmmoletID))
		{
			player.Blanks += 2;
		}
	}
}
