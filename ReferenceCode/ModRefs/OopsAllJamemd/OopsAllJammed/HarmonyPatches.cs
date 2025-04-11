using System;
using System.Reflection;
using Brave.BulletScript;
using HarmonyLib;
using Mono.Cecil;
using Mono.Cecil.Cil;
using MonoMod.Cil;
using UnityEngine;

namespace OopsAllJammed;

internal static class HarmonyPatches
{
	[HarmonyPatch(typeof(CartTurretController), "FireBullet")]
	private static class JamCartTurretPatch
	{
		[HarmonyILManipulator]
		private static void JamPatch(ILContext il)
		{
			//IL_0002: Unknown result type (might be due to invalid IL or missing references)
			//IL_0008: Expected O, but got Unknown
			//IL_0041: Unknown result type (might be due to invalid IL or missing references)
			ILCursor val = new ILCursor(il);
			MethodReference val2 = default(MethodReference);
			if (val.TryGotoNext((MoveType)2, new Func<Instruction, bool>[1]
			{
				(Instruction instr) => ILPatternMatchingExt.MatchCallOrCallvirt(instr, ref val2) && ((MemberReference)val2).Name == "GetComponent"
			}))
			{
				val.Emit(OpCodes.Call, (MethodBase)typeof(JamCartTurretPatch).GetMethod("JamProjectile", BindingFlags.Static | BindingFlags.NonPublic));
			}
		}

		private static Projectile JamProjectile(Projectile p)
		{
			if (Plugin.JamMinecarts)
			{
				p.BecomeBlackBullet();
			}
			return p;
		}
	}

	[HarmonyPatch(typeof(ProjectileTrapController), "ShootProjectileInDirection")]
	private static class JamProjectileTrapPatch
	{
		[HarmonyILManipulator]
		private static void JamPatch(ILContext il)
		{
			//IL_0002: Unknown result type (might be due to invalid IL or missing references)
			//IL_0008: Expected O, but got Unknown
			//IL_0041: Unknown result type (might be due to invalid IL or missing references)
			ILCursor val = new ILCursor(il);
			MethodReference val2 = default(MethodReference);
			if (val.TryGotoNext((MoveType)2, new Func<Instruction, bool>[1]
			{
				(Instruction instr) => ILPatternMatchingExt.MatchCallOrCallvirt(instr, ref val2) && ((MemberReference)val2).Name == "GetComponent"
			}))
			{
				val.Emit(OpCodes.Call, (MethodBase)typeof(JamProjectileTrapPatch).GetMethod("JamProjectile", BindingFlags.Static | BindingFlags.NonPublic));
			}
		}

		private static Projectile JamProjectile(Projectile p)
		{
			if (Plugin.JamProjectileTraps)
			{
				p.BecomeBlackBullet();
			}
			return p;
		}
	}

	[HarmonyPatch(typeof(WizardSpinShootBehavior), "OnTriggerCollision")]
	private static class WizardCollisionPatch
	{
		[HarmonyILManipulator]
		private static void JamPatch(ILContext il)
		{
			//IL_0002: Unknown result type (might be due to invalid IL or missing references)
			//IL_0008: Expected O, but got Unknown
			//IL_0041: Unknown result type (might be due to invalid IL or missing references)
			ILCursor val = new ILCursor(il);
			MethodReference val2 = default(MethodReference);
			if (val.TryGotoNext((MoveType)0, new Func<Instruction, bool>[1]
			{
				(Instruction instr) => ILPatternMatchingExt.MatchCallOrCallvirt(instr, ref val2) && ((MemberReference)val2).Name == "RemovePlayerOnlyModifiers"
			}))
			{
				val.Emit(OpCodes.Call, (MethodBase)typeof(WizardCollisionPatch).GetMethod("JamProjectile", BindingFlags.Static | BindingFlags.NonPublic));
			}
		}

		private static Projectile JamProjectile(Projectile p)
		{
			if (Plugin.JamWizard)
			{
				((BraveBehaviour)p).sprite.usesOverrideMaterial = true;
				((BraveBehaviour)((BraveBehaviour)p).sprite).renderer.material = Plugin.bulletMaterial;
				ETGModConsole.Log((object)"First Pass", false);
				((BraveBehaviour)((BraveBehaviour)p).sprite).renderer.material.SetFloat("_EmissivePower", -40f);
				ETGModConsole.Log((object)((BraveBehaviour)((BraveBehaviour)p).sprite).renderer.material.GetFloat("_EmissivePower"), false);
				((BraveBehaviour)((BraveBehaviour)p).sprite).renderer.material.SetFloat("_EmissiveColorPower", 35.36f);
				ETGModConsole.Log((object)((BraveBehaviour)((BraveBehaviour)p).sprite).renderer.material.GetFloat("_EmissiveColorPower"), false);
				((BraveBehaviour)((BraveBehaviour)p).sprite).renderer.material.SetFloat("_BlackBullet", 1f);
				ETGModConsole.Log((object)((BraveBehaviour)((BraveBehaviour)p).sprite).renderer.material.GetFloat("_BlackBullet"), false);
				p.BecomeBlackBullet();
				ETGModConsole.Log((object)"Second Pass", false);
				ETGModConsole.Log((object)((BraveBehaviour)((BraveBehaviour)p).sprite).renderer.material.GetFloat("_EmissivePower"), false);
				ETGModConsole.Log((object)((BraveBehaviour)((BraveBehaviour)p).sprite).renderer.material.GetFloat("_EmissiveColorPower"), false);
				ETGModConsole.Log((object)((BraveBehaviour)((BraveBehaviour)p).sprite).renderer.material.GetFloat("_BlackBullet"), false);
			}
			return p;
		}
	}

	[HarmonyPatch(typeof(WizardSpinShootBehavior), "ContinuousUpdate")]
	private static class WizardSpawningPatch
	{
		[HarmonyILManipulator]
		private static void JamPatch(ILContext il)
		{
			//IL_0002: Unknown result type (might be due to invalid IL or missing references)
			//IL_0008: Expected O, but got Unknown
			//IL_0041: Unknown result type (might be due to invalid IL or missing references)
			ILCursor val = new ILCursor(il);
			MethodReference val2 = default(MethodReference);
			if (val.TryGotoNext((MoveType)2, new Func<Instruction, bool>[1]
			{
				(Instruction instr) => ILPatternMatchingExt.MatchCallOrCallvirt(instr, ref val2) && ((MemberReference)val2).Name == "GetComponent"
			}))
			{
				val.Emit(OpCodes.Call, (MethodBase)typeof(WizardSpawningPatch).GetMethod("JamProjectile", BindingFlags.Static | BindingFlags.NonPublic));
			}
		}

		private static Projectile JamProjectile(Projectile p)
		{
			if (Plugin.JamWizard)
			{
				p.BecomeBlackBullet();
			}
			if ((Object)(object)Plugin.bulletShader == (Object)null)
			{
				Plugin.bulletShader = ((BraveBehaviour)((BraveBehaviour)p).sprite).renderer.material.shader;
			}
			if ((Object)(object)Plugin.bulletMaterial == (Object)null)
			{
				Plugin.bulletMaterial = ((BraveBehaviour)((BraveBehaviour)p).sprite).renderer.material;
			}
			return p;
		}
	}

	[HarmonyPatch(/*Could not decode attribute arguments.*/)]
	private static class PitPatch
	{
		[HarmonyILManipulator]
		private static void JamPatch(ILContext il)
		{
			//IL_0002: Unknown result type (might be due to invalid IL or missing references)
			//IL_0008: Expected O, but got Unknown
			//IL_0038: Unknown result type (might be due to invalid IL or missing references)
			ILCursor val = new ILCursor(il);
			if (val.JumpToNext((Instruction instr) => ILPatternMatchingExt.MatchLdcI4(instr, 3), 2))
			{
				val.Emit(OpCodes.Call, (MethodBase)typeof(PitPatch).GetMethod("JamPit", BindingFlags.Static | BindingFlags.NonPublic));
			}
		}

		private static DamageCategory JamPit(DamageCategory p)
		{
			//IL_000e: Unknown result type (might be due to invalid IL or missing references)
			//IL_000f: Unknown result type (might be due to invalid IL or missing references)
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0012: Unknown result type (might be due to invalid IL or missing references)
			if (Plugin.JamPits)
			{
				return (DamageCategory)4;
			}
			return p;
		}
	}

	[HarmonyPatch(typeof(Exploder), "DoRadialDamage")]
	private static class ExplosionPatch
	{
		[HarmonyILManipulator]
		private static void JamPatch(ILContext il)
		{
			//IL_0002: Unknown result type (might be due to invalid IL or missing references)
			//IL_0008: Expected O, but got Unknown
			//IL_0038: Unknown result type (might be due to invalid IL or missing references)
			ILCursor val = new ILCursor(il);
			if (val.JumpToNext((Instruction instr) => ILPatternMatchingExt.MatchLdcI4(instr, 0), 8))
			{
				val.Emit(OpCodes.Call, (MethodBase)typeof(ExplosionPatch).GetMethod("JamExplosion", BindingFlags.Static | BindingFlags.NonPublic));
			}
		}

		private static DamageCategory JamExplosion(DamageCategory p)
		{
			//IL_000e: Unknown result type (might be due to invalid IL or missing references)
			//IL_000f: Unknown result type (might be due to invalid IL or missing references)
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0012: Unknown result type (might be due to invalid IL or missing references)
			if (Plugin.JamExplosions)
			{
				return (DamageCategory)4;
			}
			return p;
		}
	}

	[HarmonyPatch(/*Could not decode attribute arguments.*/)]
	private static class ExplosionPatch2
	{
		[HarmonyILManipulator]
		private static void JamPatch(ILContext il)
		{
			//IL_0002: Unknown result type (might be due to invalid IL or missing references)
			//IL_0008: Expected O, but got Unknown
			//IL_0039: Unknown result type (might be due to invalid IL or missing references)
			ILCursor val = new ILCursor(il);
			if (val.JumpToNext((Instruction instr) => ILPatternMatchingExt.MatchLdcI4(instr, 0), 13))
			{
				val.Emit(OpCodes.Call, (MethodBase)typeof(ExplosionPatch2).GetMethod("JamExplosion", BindingFlags.Static | BindingFlags.NonPublic));
			}
		}

		private static DamageCategory JamExplosion(DamageCategory p)
		{
			//IL_000e: Unknown result type (might be due to invalid IL or missing references)
			//IL_000f: Unknown result type (might be due to invalid IL or missing references)
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0012: Unknown result type (might be due to invalid IL or missing references)
			if (Plugin.JamPits)
			{
				return (DamageCategory)4;
			}
			return p;
		}
	}

	[HarmonyPatch(typeof(DeadlyDeadlyGoopManager), "DoTimelessGoopEffect")]
	private static class ElectricityPatch
	{
		[HarmonyILManipulator]
		private static void JamPatch(ILContext il)
		{
			//IL_0002: Unknown result type (might be due to invalid IL or missing references)
			//IL_0008: Expected O, but got Unknown
			//IL_0041: Unknown result type (might be due to invalid IL or missing references)
			ILCursor val = new ILCursor(il);
			if (val.TryGotoNext((MoveType)2, new Func<Instruction, bool>[1]
			{
				(Instruction instr) => ILPatternMatchingExt.MatchLdcI4(instr, 3)
			}))
			{
				val.Emit(OpCodes.Call, (MethodBase)typeof(ElectricityPatch).GetMethod("JamGoop", BindingFlags.Static | BindingFlags.NonPublic));
			}
		}

		private static DamageCategory JamGoop(DamageCategory p)
		{
			//IL_000e: Unknown result type (might be due to invalid IL or missing references)
			//IL_000f: Unknown result type (might be due to invalid IL or missing references)
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0012: Unknown result type (might be due to invalid IL or missing references)
			if (Plugin.JamStatuses)
			{
				return (DamageCategory)4;
			}
			return p;
		}
	}

	[HarmonyPatch(typeof(HealthHaver), "ApplyDamageDirectional")]
	private static class DamageImmunityPatch
	{
		[HarmonyILManipulator]
		private static void Patch(ILContext il)
		{
			//IL_0002: Unknown result type (might be due to invalid IL or missing references)
			//IL_0008: Expected O, but got Unknown
			//IL_0041: Unknown result type (might be due to invalid IL or missing references)
			//IL_004d: Unknown result type (might be due to invalid IL or missing references)
			ILCursor val = new ILCursor(il);
			if (val.TryGotoNext((MoveType)2, new Func<Instruction, bool>[1]
			{
				(Instruction instr) => ILPatternMatchingExt.MatchLdcR4(instr, 1f)
			}))
			{
				val.Emit(OpCodes.Ldarg_1);
				val.Emit(OpCodes.Call, (MethodBase)typeof(DamageImmunityPatch).GetMethod("DamageCheck", BindingFlags.Static | BindingFlags.NonPublic));
			}
		}

		private static float DamageCheck(float blackBullet, float damage)
		{
			if (damage == 0f)
			{
				return 0f;
			}
			return blackBullet;
		}
	}

	[HarmonyPatch(typeof(DeadlyDeadlyGoopManager), "DoGoopEffect")]
	private static class PoisonPatch
	{
		[HarmonyILManipulator]
		private static void JamPatch(ILContext il)
		{
			//IL_0002: Unknown result type (might be due to invalid IL or missing references)
			//IL_0008: Expected O, but got Unknown
			//IL_0041: Unknown result type (might be due to invalid IL or missing references)
			ILCursor val = new ILCursor(il);
			if (val.TryGotoNext((MoveType)2, new Func<Instruction, bool>[1]
			{
				(Instruction instr) => ILPatternMatchingExt.MatchLdcI4(instr, 3)
			}))
			{
				val.Emit(OpCodes.Call, (MethodBase)typeof(PoisonPatch).GetMethod("JamGoop", BindingFlags.Static | BindingFlags.NonPublic));
			}
		}

		private static DamageCategory JamGoop(DamageCategory p)
		{
			//IL_000e: Unknown result type (might be due to invalid IL or missing references)
			//IL_000f: Unknown result type (might be due to invalid IL or missing references)
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0012: Unknown result type (might be due to invalid IL or missing references)
			if (Plugin.JamStatuses)
			{
				return (DamageCategory)4;
			}
			return p;
		}
	}

	[HarmonyPatch(typeof(PlayerController), "LateUpdate")]
	private static class FirePatch
	{
		[HarmonyILManipulator]
		private static void JamPatch(ILContext il)
		{
			//IL_0002: Unknown result type (might be due to invalid IL or missing references)
			//IL_0008: Expected O, but got Unknown
			//IL_0038: Unknown result type (might be due to invalid IL or missing references)
			ILCursor val = new ILCursor(il);
			if (val.JumpToNext((Instruction instr) => ILPatternMatchingExt.MatchLdcI4(instr, 3), 2))
			{
				val.Emit(OpCodes.Call, (MethodBase)typeof(FirePatch).GetMethod("JamGoop", BindingFlags.Static | BindingFlags.NonPublic));
			}
		}

		private static DamageCategory JamGoop(DamageCategory p)
		{
			//IL_001f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0020: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0023: Unknown result type (might be due to invalid IL or missing references)
			ETGModConsole.Log((object)Plugin.JamStatuses, false);
			if (Plugin.JamStatuses)
			{
				return (DamageCategory)4;
			}
			return p;
		}
	}

	[HarmonyPatch(/*Could not decode attribute arguments.*/)]
	private static class ForgeHammerPatch
	{
		[HarmonyILManipulator]
		private static void JamPatch(ILContext il)
		{
			//IL_0002: Unknown result type (might be due to invalid IL or missing references)
			//IL_0008: Expected O, but got Unknown
			//IL_004b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0058: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
			ILCursor val = new ILCursor(il);
			VariableDefinition val2 = val.DeclareLocal<DefaultBullet>();
			if (val.TryGotoNext((MoveType)2, new Func<Instruction, bool>[1]
			{
				(Instruction instr) => ILPatternMatchingExt.MatchNewobj<DefaultBullet>(instr)
			}))
			{
				val.Emit(OpCodes.Ldloca_S, val2);
				val.Emit(OpCodes.Call, (MethodBase)typeof(ForgeHammerPatch).GetMethod("SaveBullet", BindingFlags.Static | BindingFlags.NonPublic));
				MethodReference val3 = default(MethodReference);
				if (val.TryGotoNext((MoveType)2, new Func<Instruction, bool>[1]
				{
					(Instruction instr) => ILPatternMatchingExt.MatchCallOrCallvirt(instr, ref val3) && ((MemberReference)val3).Name == "Fire"
				}))
				{
					val.Emit(OpCodes.Ldloc_S, val2);
					val.Emit(OpCodes.Call, (MethodBase)typeof(ForgeHammerPatch).GetMethod("JamProjectile", BindingFlags.Static | BindingFlags.NonPublic));
				}
			}
		}

		private static void JamProjectile(DefaultBullet p)
		{
			if (Plugin.JamHammer)
			{
				((Bullet)p).Projectile.BecomeBlackBullet();
			}
		}

		private static DefaultBullet SaveBullet(DefaultBullet p, out DefaultBullet b)
		{
			b = p;
			return p;
		}
	}

	[HarmonyPatch(typeof(CircleBurst12), "Top")]
	private static class LOTJPatch
	{
		[HarmonyILManipulator]
		private static void JamPatch(ILContext il)
		{
			//IL_0002: Unknown result type (might be due to invalid IL or missing references)
			//IL_0008: Expected O, but got Unknown
			//IL_004b: Unknown result type (might be due to invalid IL or missing references)
			//IL_006d: Unknown result type (might be due to invalid IL or missing references)
			//IL_007a: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d4: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
			ILCursor val = new ILCursor(il);
			VariableDefinition val2 = val.DeclareLocal<DefaultBullet>();
			MethodReference val3 = default(MethodReference);
			if (val.TryGotoNext((MoveType)0, new Func<Instruction, bool>[1]
			{
				(Instruction instr) => ILPatternMatchingExt.MatchCallOrCallvirt(instr, ref val3) && ((MemberReference)val3).Name == "Fire"
			}))
			{
				val.Emit(OpCodes.Call, (MethodBase)typeof(LOTJPatch).GetMethod("CreateBullet", BindingFlags.Static | BindingFlags.NonPublic));
				val.Emit(OpCodes.Ldloca_S, val2);
				val.Emit(OpCodes.Call, (MethodBase)typeof(LOTJPatch).GetMethod("SaveBullet", BindingFlags.Static | BindingFlags.NonPublic));
				MethodReference val4 = default(MethodReference);
				if (val.TryGotoNext((MoveType)2, new Func<Instruction, bool>[1]
				{
					(Instruction instr) => ILPatternMatchingExt.MatchCallOrCallvirt(instr, ref val4) && ((MemberReference)val4).Name == "Fire"
				}))
				{
					val.Emit(OpCodes.Ldloc_S, val2);
					val.Emit(OpCodes.Call, (MethodBase)typeof(ForgeHammerPatch).GetMethod("JamProjectile", BindingFlags.Static | BindingFlags.NonPublic));
				}
			}
		}

		private static Bullet CreateBullet(object p)
		{
			//IL_0005: Unknown result type (might be due to invalid IL or missing references)
			//IL_000b: Expected O, but got Unknown
			return new Bullet((string)null, false, false, false);
		}

		private static void JamProjectile(DefaultBullet p)
		{
			if (Plugin.JamLordOfTheJammed)
			{
				((Bullet)p).Projectile.BecomeBlackBullet();
			}
		}

		private static DefaultBullet SaveBullet(DefaultBullet p, out DefaultBullet b)
		{
			b = p;
			return p;
		}
	}

	[HarmonyPatch(typeof(PathingTrapController), "Damage")]
	private static class PathingTrapPatch
	{
		[HarmonyILManipulator]
		private static void JamPatch(ILContext il)
		{
			//IL_0002: Unknown result type (might be due to invalid IL or missing references)
			//IL_0008: Expected O, but got Unknown
			//IL_0038: Unknown result type (might be due to invalid IL or missing references)
			ILCursor val = new ILCursor(il);
			if (val.JumpToNext((Instruction instr) => ILPatternMatchingExt.MatchLdcI4(instr, 0), 3))
			{
				val.Emit(OpCodes.Call, (MethodBase)typeof(PathingTrapPatch).GetMethod("JamPathing", BindingFlags.Static | BindingFlags.NonPublic));
			}
		}

		private static DamageCategory JamPathing(DamageCategory p)
		{
			//IL_000e: Unknown result type (might be due to invalid IL or missing references)
			//IL_000f: Unknown result type (might be due to invalid IL or missing references)
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0012: Unknown result type (might be due to invalid IL or missing references)
			if (Plugin.JamPathingTraps)
			{
				return (DamageCategory)4;
			}
			return p;
		}
	}

	[HarmonyPatch(typeof(BasicTrapController), "Damage")]
	private static class BasicTrapPatch
	{
		[HarmonyILManipulator]
		private static void JamPatch(ILContext il)
		{
			//IL_0002: Unknown result type (might be due to invalid IL or missing references)
			//IL_0008: Expected O, but got Unknown
			//IL_0038: Unknown result type (might be due to invalid IL or missing references)
			ILCursor val = new ILCursor(il);
			if (val.JumpToNext((Instruction instr) => ILPatternMatchingExt.MatchLdcI4(instr, 0), 2))
			{
				val.Emit(OpCodes.Call, (MethodBase)typeof(BasicTrapPatch).GetMethod("JamBasic", BindingFlags.Static | BindingFlags.NonPublic));
			}
		}

		private static DamageCategory JamBasic(DamageCategory p)
		{
			//IL_000e: Unknown result type (might be due to invalid IL or missing references)
			//IL_000f: Unknown result type (might be due to invalid IL or missing references)
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0012: Unknown result type (might be due to invalid IL or missing references)
			if (Plugin.JamBasicTraps)
			{
				return (DamageCategory)4;
			}
			return p;
		}
	}

	[HarmonyPatch(/*Could not decode attribute arguments.*/)]
	private static class ForgeFlamePipePatch
	{
		[HarmonyILManipulator]
		private static void JamPatch(ILContext il)
		{
			//IL_0002: Unknown result type (might be due to invalid IL or missing references)
			//IL_0008: Expected O, but got Unknown
			//IL_0038: Unknown result type (might be due to invalid IL or missing references)
			ILCursor val = new ILCursor(il);
			if (val.JumpToNext((Instruction instr) => ILPatternMatchingExt.MatchLdcI4(instr, 3), 2))
			{
				val.Emit(OpCodes.Call, (MethodBase)typeof(ForgeFlamePipePatch).GetMethod("JamFlame", BindingFlags.Static | BindingFlags.NonPublic));
			}
		}

		private static DamageCategory JamFlame(DamageCategory p)
		{
			//IL_000e: Unknown result type (might be due to invalid IL or missing references)
			//IL_000f: Unknown result type (might be due to invalid IL or missing references)
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0012: Unknown result type (might be due to invalid IL or missing references)
			if (Plugin.JamFlamePipe)
			{
				return (DamageCategory)4;
			}
			return p;
		}
	}

	[HarmonyPatch(typeof(ForgeCrushDoorController), "HandleAnimationEvent")]
	private static class ForgeDoorsPatch
	{
		[HarmonyILManipulator]
		private static void JamPatch(ILContext il)
		{
			//IL_0002: Unknown result type (might be due to invalid IL or missing references)
			//IL_0008: Expected O, but got Unknown
			//IL_0038: Unknown result type (might be due to invalid IL or missing references)
			ILCursor val = new ILCursor(il);
			if (val.JumpToNext((Instruction instr) => ILPatternMatchingExt.MatchLdcI4(instr, 0), 5))
			{
				val.Emit(OpCodes.Call, (MethodBase)typeof(ForgeDoorsPatch).GetMethod("JamDoor", BindingFlags.Static | BindingFlags.NonPublic));
			}
		}

		private static DamageCategory JamDoor(DamageCategory p)
		{
			//IL_000e: Unknown result type (might be due to invalid IL or missing references)
			//IL_000f: Unknown result type (might be due to invalid IL or missing references)
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0012: Unknown result type (might be due to invalid IL or missing references)
			if (Plugin.JamCrushDoors)
			{
				return (DamageCategory)4;
			}
			return p;
		}
	}

	public static void Patch(Harmony harmony)
	{
		harmony.PatchAll();
	}

	public static bool JumpToNext(this ILCursor crs, Func<Instruction, bool> match, int times = 1)
	{
		for (int i = 0; i < times; i++)
		{
			if (!crs.TryGotoNext((MoveType)2, new Func<Instruction, bool>[1] { match }))
			{
				return false;
			}
		}
		return true;
	}

	public static bool JumpBeforeNext(this ILCursor crs, Func<Instruction, bool> match, int times = 1)
	{
		for (int i = 0; i < times; i++)
		{
			if (!crs.TryGotoNext((MoveType)0, new Func<Instruction, bool>[1] { match }))
			{
				return false;
			}
		}
		return true;
	}

	public static VariableDefinition DeclareLocal<T>(this ILContext ctx)
	{
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Expected O, but got Unknown
		VariableDefinition val = new VariableDefinition(ctx.Import(typeof(T)));
		ctx.Body.Variables.Add(val);
		return val;
	}

	public static VariableDefinition DeclareLocal<T>(this ILCursor curs)
	{
		return curs.Context.DeclareLocal<T>();
	}
}
