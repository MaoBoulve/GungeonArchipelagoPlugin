using System;
using System.Reflection;
using HarmonyLib;
using Mono.Cecil.Cil;
using MonoMod.Cil;

namespace NevernamedsItems;

public static class ChanceScalarPatch
{
	[HarmonyPatch(typeof(PlayerController), "DoPostProcessProjectile")]
	[HarmonyILManipulator]
	public static void ChanceScalarPatch_Transpiler(ILContext ctx)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Expected O, but got Unknown
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		ILCursor val = new ILCursor(ctx);
		if (val.TryGotoNext((MoveType)0, new Func<Instruction, bool>[1]
		{
			(Instruction instruction) => ILPatternMatchingExt.MatchCallOrCallvirt<Action<Projectile, float>>(instruction, "Invoke")
		}))
		{
			val.Emit(OpCodes.Ldarg_0);
			val.Emit(OpCodes.Call, (MethodBase)AccessTools.Method(typeof(ChanceScalarPatch), "ChanceScalarIncrease", (Type[])null, (Type[])null));
		}
	}

	public static float ChanceScalarIncrease(float current, PlayerController player)
	{
		if (OMITBActions.ModifyChanceScalar != null)
		{
			OMITBActions.ModifyChanceScalar(ref current, player);
		}
		return current;
	}
}
