using System;
using System.Reflection;
using MonoMod.RuntimeDetour;
using UnityEngine;

namespace NevernamedsItems;

public static class ShadeFlightHookFix
{
	public delegate TResult FuncC<T, T2, T3, T4, T5, TResult>(T arg, T2 arg2, T3 arg3, T4 arg4, T5 arg5);

	public static Hook shadefixhook;

	public static Hook shadehandfix;

	public static void Init()
	{
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Expected O, but got Unknown
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Expected O, but got Unknown
		shadefixhook = new Hook((MethodBase)typeof(PlayerController).GetMethod("GetBaseAnimationName", BindingFlags.Instance | BindingFlags.NonPublic), typeof(ShadeFlightHookFix).GetMethod("GetBaseAnimationNameHook", BindingFlags.Static | BindingFlags.NonPublic));
		shadehandfix = new Hook((MethodBase)typeof(PlayerController).GetMethod("HandleGunAttachPointInternal", BindingFlags.Instance | BindingFlags.NonPublic), typeof(ShadeFlightHookFix).GetMethod("HandleGunAttachPointInternalHook", BindingFlags.Static | BindingFlags.NonPublic));
	}

	private static string GetBaseAnimationNameHook(FuncC<PlayerController, Vector2, float, bool, bool, string> orig, PlayerController self, Vector2 v, float gunAngle, bool invertThresholds = false, bool forceTwoHands = false)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0362: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Invalid comparison between Unknown and I4
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Invalid comparison between Unknown and I4
		//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fe: Invalid comparison between Unknown and I4
		//IL_0123: Unknown result type (might be due to invalid IL or missing references)
		//IL_0124: Unknown result type (might be due to invalid IL or missing references)
		//IL_0351: Unknown result type (might be due to invalid IL or missing references)
		if (self.characterIdentity == OMITBChars.Shade)
		{
			string text = string.Empty;
			bool flag = (Object)(object)((GameActor)self).CurrentGun != (Object)null;
			if (flag && (int)((GameActor)self).CurrentGun.Handedness == 4)
			{
				forceTwoHands = true;
			}
			if ((int)GameManager.Instance.CurrentLevelOverrideState == 4)
			{
				flag = false;
			}
			float num = 155f;
			float num2 = 25f;
			if (invertThresholds)
			{
				num = -155f;
				num2 -= 50f;
			}
			float num3 = 120f;
			float num4 = 60f;
			float num5 = -60f;
			float num6 = -120f;
			bool flag2 = gunAngle <= num && gunAngle >= num2;
			if (invertThresholds)
			{
				flag2 = gunAngle <= num || gunAngle >= num2;
			}
			bool flag3 = !self.ForceHandless && (Object)(object)self.CurrentSecondaryGun == (Object)null && ((Object)(object)((GameActor)self).CurrentGun == (Object)null || (int)((GameActor)self).CurrentGun.Handedness != 1);
			if (!self.IsGhost && ((GameActor)self).IsFlying && !self.IsPetting && (v == Vector2.zero || self.IsStationary))
			{
				if (flag2)
				{
					if (gunAngle < num3 && gunAngle >= num4)
					{
						string text2 = ((!(!forceTwoHands && flag) && !self.ForceHandless) ? "idle_backward_twohands" : ((!flag3) ? "idle_backward" : "idle_backward_hand"));
						text = text2;
					}
					else
					{
						string text3 = (((!forceTwoHands && flag) || self.ForceHandless) ? "idle_bw" : "idle_bw_twohands");
						text = text3;
					}
				}
				else if (gunAngle <= num5 && gunAngle >= num6)
				{
					string text4 = ((!(!forceTwoHands && flag) && !self.ForceHandless) ? "idle_forward_twohands" : ((!flag3) ? "idle_forward" : "idle_forward_hand"));
					text = text4;
				}
				else
				{
					string text5 = ((!(!forceTwoHands && flag) && !self.ForceHandless) ? "idle_twohands" : ((!flag3) ? "idle" : "idle_hand"));
					text = text5;
				}
			}
			else if (flag2 && !self.IsGhost && ((GameActor)self).IsFlying)
			{
				string text6 = (((!forceTwoHands && flag) || self.ForceHandless) ? "run_right_bw" : "run_right_bw_twohands");
				if (gunAngle < num3 && gunAngle >= num4)
				{
					text6 = ((!(!forceTwoHands && flag) && !self.ForceHandless) ? "run_up_twohands" : ((!flag3) ? "run_up" : "run_up_hand"));
				}
				text = text6;
			}
			else if (!self.IsGhost && ((GameActor)self).IsFlying)
			{
				string text7 = "run_right";
				if (gunAngle <= num5 && gunAngle >= num6)
				{
					text7 = "run_down";
				}
				if ((forceTwoHands || !flag) && !self.ForceHandless)
				{
					text7 += "_twohands";
				}
				else if (flag3)
				{
					text7 += "_hand";
				}
				text = text7;
			}
			return string.IsNullOrEmpty(text) ? orig(self, v, gunAngle, invertThresholds, forceTwoHands) : text;
		}
		return orig(self, v, gunAngle, invertThresholds, forceTwoHands);
	}

	private static void HandleGunAttachPointInternalHook(Action<PlayerController, Gun, bool> orig, PlayerController self, Gun targetGun, bool isSecondary = false)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Invalid comparison between Unknown and I4
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0082: Unknown result type (might be due to invalid IL or missing references)
		//IL_0091: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0103: Unknown result type (might be due to invalid IL or missing references)
		//IL_0105: Unknown result type (might be due to invalid IL or missing references)
		//IL_0118: Unknown result type (might be due to invalid IL or missing references)
		//IL_0120: Unknown result type (might be due to invalid IL or missing references)
		//IL_0125: Unknown result type (might be due to invalid IL or missing references)
		//IL_0139: Unknown result type (might be due to invalid IL or missing references)
		//IL_013e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0143: Unknown result type (might be due to invalid IL or missing references)
		//IL_0147: Unknown result type (might be due to invalid IL or missing references)
		//IL_014c: Unknown result type (might be due to invalid IL or missing references)
		//IL_014e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0150: Unknown result type (might be due to invalid IL or missing references)
		//IL_015e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0163: Unknown result type (might be due to invalid IL or missing references)
		//IL_016d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0172: Unknown result type (might be due to invalid IL or missing references)
		//IL_0177: Unknown result type (might be due to invalid IL or missing references)
		//IL_0179: Unknown result type (might be due to invalid IL or missing references)
		//IL_017b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0189: Unknown result type (might be due to invalid IL or missing references)
		//IL_018e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0198: Unknown result type (might be due to invalid IL or missing references)
		//IL_019d: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ab: Invalid comparison between Unknown and I4
		//IL_01bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01db: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_020a: Unknown result type (might be due to invalid IL or missing references)
		//IL_020f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0219: Unknown result type (might be due to invalid IL or missing references)
		//IL_021e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0223: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0292: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0266: Unknown result type (might be due to invalid IL or missing references)
		//IL_0373: Unknown result type (might be due to invalid IL or missing references)
		//IL_0379: Invalid comparison between Unknown and I4
		//IL_0351: Unknown result type (might be due to invalid IL or missing references)
		//IL_0353: Unknown result type (might be due to invalid IL or missing references)
		//IL_0357: Unknown result type (might be due to invalid IL or missing references)
		//IL_0361: Unknown result type (might be due to invalid IL or missing references)
		//IL_04ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_04f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_03be: Unknown result type (might be due to invalid IL or missing references)
		//IL_040c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0418: Unknown result type (might be due to invalid IL or missing references)
		//IL_041d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0427: Unknown result type (might be due to invalid IL or missing references)
		//IL_042c: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_03fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0400: Unknown result type (might be due to invalid IL or missing references)
		//IL_043c: Unknown result type (might be due to invalid IL or missing references)
		//IL_043e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0443: Unknown result type (might be due to invalid IL or missing references)
		//IL_0448: Unknown result type (might be due to invalid IL or missing references)
		//IL_0453: Unknown result type (might be due to invalid IL or missing references)
		//IL_0458: Unknown result type (might be due to invalid IL or missing references)
		//IL_045d: Unknown result type (might be due to invalid IL or missing references)
		//IL_04b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_04b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_04ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_04c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_04c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_04cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_04d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0480: Unknown result type (might be due to invalid IL or missing references)
		//IL_0482: Unknown result type (might be due to invalid IL or missing references)
		//IL_0484: Unknown result type (might be due to invalid IL or missing references)
		//IL_048b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0490: Unknown result type (might be due to invalid IL or missing references)
		//IL_0497: Unknown result type (might be due to invalid IL or missing references)
		//IL_04a1: Unknown result type (might be due to invalid IL or missing references)
		if ((int)self.characterIdentity == 274131)
		{
			FieldInfo field = typeof(PlayerController).GetField("m_startingAttachPointPosition", BindingFlags.Instance | BindingFlags.NonPublic);
			FieldInfo field2 = typeof(PlayerController).GetField("m_spriteDimensions", BindingFlags.Instance | BindingFlags.NonPublic);
			FieldInfo field3 = typeof(PlayerController).GetField("m_currentGunAngle", BindingFlags.Instance | BindingFlags.NonPublic);
			if ((Object)(object)targetGun == (Object)null)
			{
				return;
			}
			Vector3 val = (Vector3)field.GetValue(self);
			Vector3 val2 = self.downwardAttachPointPosition;
			if (targetGun.IsForwardPosition)
			{
				val = Vector3Extensions.WithX(val, ((Vector3)field2.GetValue(self)).x - val.x);
				val2 = Vector3Extensions.WithX(val2, ((Vector3)field2.GetValue(self)).x - val2.x);
			}
			if (((GameActor)self).SpriteFlipped)
			{
				val = Vector3Extensions.WithX(val, ((Vector3)field2.GetValue(self)).x - val.x);
				val2 = Vector3Extensions.WithX(val2, ((Vector3)field2.GetValue(self)).x - val2.x);
			}
			float num = ((!((GameActor)self).SpriteFlipped) ? 1 : (-1));
			IntVector2 carryPixelOffset = targetGun.GetCarryPixelOffset(self.characterIdentity);
			Vector3 val3 = ((IntVector2)(ref carryPixelOffset)).ToVector3();
			val += Vector3.Scale(val3, new Vector3(num, 1f, 1f)) * 0.0625f;
			val2 += Vector3.Scale(val3, new Vector3(num, 1f, 1f)) * 0.0625f;
			if ((int)targetGun.Handedness == 4 && ((GameActor)self).SpriteFlipped)
			{
				val += Vector3.Scale(((IntVector2)(ref targetGun.leftFacingPixelOffset)).ToVector3(), new Vector3(num, 1f, 1f)) * 0.0625f;
				val2 += Vector3.Scale(((IntVector2)(ref targetGun.leftFacingPixelOffset)).ToVector3(), new Vector3(num, 1f, 1f)) * 0.0625f;
			}
			if (isSecondary)
			{
				if ((Object)(object)((BraveBehaviour)targetGun).transform.parent != (Object)(object)((GameActor)self).SecondaryGunPivot)
				{
					((BraveBehaviour)targetGun).transform.parent = ((GameActor)self).SecondaryGunPivot;
					((BraveBehaviour)targetGun).transform.localRotation = Quaternion.identity;
					targetGun.HandleSpriteFlip(((GameActor)self).SpriteFlipped);
					targetGun.UpdateAttachTransform();
				}
				((GameActor)self).SecondaryGunPivot.position = self.gunAttachPoint.position + num * new Vector3(-0.75f, 0f, 0f);
				return;
			}
			if ((Object)(object)((BraveBehaviour)targetGun).transform.parent != (Object)(object)self.gunAttachPoint)
			{
				((BraveBehaviour)targetGun).transform.parent = self.gunAttachPoint;
				((BraveBehaviour)targetGun).transform.localRotation = Quaternion.identity;
				targetGun.HandleSpriteFlip(((GameActor)self).SpriteFlipped);
				targetGun.UpdateAttachTransform();
			}
			if (targetGun.IsHeroSword)
			{
				float num2 = 1f - Mathf.Abs((float)field3.GetValue(self) - 90f) / 90f;
				self.gunAttachPoint.localPosition = BraveUtility.QuantizeVector(Vector3.Slerp(val, val2, num2), 16f);
			}
			else if ((int)targetGun.Handedness == 1)
			{
				float num3 = Mathf.PingPong(Mathf.Abs(1f - Mathf.Abs((float)field3.GetValue(self) + 90f) / 90f), 1f);
				Vector2 zero = Vector2.zero;
				zero = ((!((float)field3.GetValue(self) > 0f)) ? (Vector2.Scale(((IntVector2)(ref targetGun.carryPixelDownOffset)).ToVector2(), new Vector2(num, 1f)) * 0.0625f) : (Vector2.Scale(((IntVector2)(ref targetGun.carryPixelUpOffset)).ToVector2(), new Vector2(num, 1f)) * 0.0625f));
				if (targetGun.LockedHorizontalOnCharge)
				{
					zero = Vector2.op_Implicit(Vector3.Slerp(Vector2.op_Implicit(zero), Vector2.op_Implicit(Vector2.zero), targetGun.GetChargeFraction()));
				}
				if ((float)field3.GetValue(self) < 0f)
				{
					self.gunAttachPoint.localPosition = BraveUtility.QuantizeVector(Vector3.Slerp(val, val2 + Vector2Extensions.ToVector3ZUp(zero, 0f), num3), 16f);
				}
				else
				{
					self.gunAttachPoint.localPosition = BraveUtility.QuantizeVector(Vector3.Slerp(val, val + Vector2Extensions.ToVector3ZUp(zero, 0f), num3), 16f);
				}
			}
			else
			{
				self.gunAttachPoint.localPosition = BraveUtility.QuantizeVector(val, 16f);
			}
		}
		else
		{
			orig(self, targetGun, isSecondary);
		}
	}
}
