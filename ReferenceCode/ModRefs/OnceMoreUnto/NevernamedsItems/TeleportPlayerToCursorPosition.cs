using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using Dungeonator;
using UnityEngine;

namespace NevernamedsItems;

public class TeleportPlayerToCursorPosition : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CHandleBlinkTeleport_003Ed__6 : IEnumerator<object>, IDisposable, IEnumerator
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public PlayerController Owner;

		public Vector2 targetPoint;

		public Vector2 targetDirection;

		private List<AIActor> _003Cm_rollDamagedEnemies_003E5__1;

		private float _003CRecoverySpeed_003E5__2;

		private bool _003CIsLerping_003E5__3;

		private FieldInfo _003Cm_rollDamagedEnemiesClear_003E5__4;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return _003C_003E2__current;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return _003C_003E2__current;
			}
		}

		[DebuggerHidden]
		public _003CHandleBlinkTeleport_003Ed__6(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			_003Cm_rollDamagedEnemies_003E5__1 = null;
			_003Cm_rollDamagedEnemiesClear_003E5__4 = null;
			_003C_003E1__state = -2;
		}

		private bool MoveNext()
		{
			//IL_0045: Unknown result type (might be due to invalid IL or missing references)
			//IL_01e2: Unknown result type (might be due to invalid IL or missing references)
			//IL_01e7: Unknown result type (might be due to invalid IL or missing references)
			//IL_01f8: Unknown result type (might be due to invalid IL or missing references)
			//IL_01fd: Unknown result type (might be due to invalid IL or missing references)
			//IL_026f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0274: Unknown result type (might be due to invalid IL or missing references)
			//IL_0285: Unknown result type (might be due to invalid IL or missing references)
			//IL_028a: Unknown result type (might be due to invalid IL or missing references)
			//IL_023a: Unknown result type (might be due to invalid IL or missing references)
			//IL_023f: Unknown result type (might be due to invalid IL or missing references)
			//IL_024a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0254: Expected O, but got Unknown
			//IL_01ad: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b2: Unknown result type (might be due to invalid IL or missing references)
			//IL_01bd: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c7: Expected O, but got Unknown
			//IL_02f5: Unknown result type (might be due to invalid IL or missing references)
			//IL_0140: Unknown result type (might be due to invalid IL or missing references)
			//IL_014a: Expected O, but got Unknown
			switch (_003C_003E1__state)
			{
			default:
				return false;
			case 0:
				_003C_003E1__state = -1;
				((GameActor)Owner).PlayEffectOnActor(SharedVFX.BloodiedScarfPoofVFX, Vector3.zero, false, true, false);
				AkSoundEngine.PostEvent("Play_ENM_wizardred_vanish_01", ((Component)Owner).gameObject);
				_003Cm_rollDamagedEnemies_003E5__1 = Owner.m_rollDamagedEnemies;
				if (_003Cm_rollDamagedEnemies_003E5__1 != null)
				{
					_003Cm_rollDamagedEnemies_003E5__1.Clear();
					_003Cm_rollDamagedEnemiesClear_003E5__4 = typeof(PlayerController).GetField("m_rollDamagedEnemies", BindingFlags.Instance | BindingFlags.NonPublic);
					_003Cm_rollDamagedEnemiesClear_003E5__4.SetValue(Owner, _003Cm_rollDamagedEnemies_003E5__1);
					_003Cm_rollDamagedEnemiesClear_003E5__4 = null;
				}
				if (Object.op_Implicit((Object)(object)((BraveBehaviour)Owner).knockbackDoer))
				{
					((BraveBehaviour)Owner).knockbackDoer.ClearContinuousKnockbacks();
				}
				Owner.IsEthereal = true;
				Owner.IsVisible = false;
				_003CRecoverySpeed_003E5__2 = GameManager.Instance.MainCameraController.OverrideRecoverySpeed;
				_003CIsLerping_003E5__3 = GameManager.Instance.MainCameraController.IsLerping;
				_003C_003E2__current = (object)new WaitForSeconds(0.1f);
				_003C_003E1__state = 1;
				return true;
			case 1:
				_003C_003E1__state = -1;
				GameManager.Instance.MainCameraController.OverrideRecoverySpeed = 80f;
				GameManager.Instance.MainCameraController.IsLerping = true;
				if (Owner.IsPrimaryPlayer)
				{
					GameManager.Instance.MainCameraController.UseOverridePlayerOnePosition = true;
					GameManager.Instance.MainCameraController.OverridePlayerOnePosition = targetPoint;
					_003C_003E2__current = (object)new WaitForSeconds(0.12f);
					_003C_003E1__state = 2;
					return true;
				}
				GameManager.Instance.MainCameraController.UseOverridePlayerTwoPosition = true;
				GameManager.Instance.MainCameraController.OverridePlayerTwoPosition = targetPoint;
				_003C_003E2__current = (object)new WaitForSeconds(0.12f);
				_003C_003E1__state = 3;
				return true;
			case 2:
				_003C_003E1__state = -1;
				((BraveBehaviour)Owner).specRigidbody.Velocity = Vector2.zero;
				((BraveBehaviour)Owner).specRigidbody.Position = new Position(targetPoint);
				GameManager.Instance.MainCameraController.UseOverridePlayerOnePosition = false;
				break;
			case 3:
				_003C_003E1__state = -1;
				((BraveBehaviour)Owner).specRigidbody.Velocity = Vector2.zero;
				((BraveBehaviour)Owner).specRigidbody.Position = new Position(targetPoint);
				GameManager.Instance.MainCameraController.UseOverridePlayerTwoPosition = false;
				break;
			}
			GameManager.Instance.MainCameraController.OverrideRecoverySpeed = _003CRecoverySpeed_003E5__2;
			GameManager.Instance.MainCameraController.IsLerping = _003CIsLerping_003E5__3;
			Owner.IsEthereal = false;
			Owner.IsVisible = true;
			((GameActor)Owner).PlayEffectOnActor(SharedVFX.BloodiedScarfPoofVFX, Vector3.zero, false, true, false);
			if (Owner.CurrentFireMeterValue <= 0f)
			{
				return false;
			}
			PlayerController obj = Owner;
			PlayerController obj2 = Owner;
			obj.CurrentFireMeterValue = Mathf.Max(0f, obj2.CurrentFireMeterValue -= 0.5f);
			if (Owner.CurrentFireMeterValue == 0f)
			{
				Owner.IsOnFire = false;
				return false;
			}
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
			throw new NotSupportedException();
		}
	}

	private static Vector2 lockedDodgeRollDirection;

	public static BlinkPassiveItem m_BlinkPassive = ((Component)PickupObjectDatabase.GetById(436)).GetComponent<BlinkPassiveItem>();

	public GameObject BlinkpoofVfx = m_BlinkPassive.BlinkpoofVfx;

	public static void StartTeleport(PlayerController user, Vector2 newPosition)
	{
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		((BraveBehaviour)user).healthHaver.TriggerInvulnerabilityPeriod(0.001f);
		user.DidUnstealthyAction();
		Vector2 targetPoint = BraveMathCollege.ClampToBounds(newPosition, GameManager.Instance.MainCameraController.MinVisiblePoint, GameManager.Instance.MainCameraController.MaxVisiblePoint);
		BlinkToPoint(user, targetPoint);
	}

	private static void BlinkToPoint(PlayerController Owner, Vector2 targetPoint)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c8: Unknown result type (might be due to invalid IL or missing references)
		Vector2 val = targetPoint - ((BraveBehaviour)Owner).specRigidbody.UnitCenter;
		lockedDodgeRollDirection = ((Vector2)(ref val)).normalized;
		Vector2 val2 = Vector2.op_Implicit(((BraveBehaviour)Owner).transform.position);
		int num = (int)targetPoint.x;
		int num2 = (int)targetPoint.y;
		int num3 = (int)val2.x;
		int num4 = (int)val2.y;
		int num5 = Math.Abs(num3 - num);
		int num6 = ((num < num3) ? 1 : (-1));
		int num7 = -Math.Abs(num4 - num2);
		int num8 = ((num2 < num4) ? 1 : (-1));
		int num9 = num5 + num7;
		int num10 = 600;
		while (num10 > 0 && (num != num3 || num2 != num4))
		{
			if (CanBlinkToPoint(new Vector2((float)num, (float)num2), Owner))
			{
				StaticCoroutine.Start(HandleBlinkTeleport(Owner, new Vector2((float)num, (float)num2), lockedDodgeRollDirection));
				break;
			}
			int num11 = 2 * num9;
			if (num11 >= num7)
			{
				num9 += num7;
				num += num6;
			}
			if (num11 <= num5)
			{
				num9 += num5;
				num2 += num8;
			}
			num10--;
		}
	}

	private static bool CanBlinkToPoint(Vector2 point, PlayerController owner)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Invalid comparison between Unknown and I4
		//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b8: Invalid comparison between Unknown and I4
		RoomHandler currentRoom = owner.CurrentRoom;
		bool flag = owner.IsValidPlayerPosition(point);
		if (flag && currentRoom != null)
		{
			CellData val = GameManager.Instance.Dungeon.data[Vector2Extensions.ToIntVector2(point, (VectorConversions)0)];
			if (val == null)
			{
				return false;
			}
			RoomHandler nearestRoom = val.nearestRoom;
			if ((int)val.type != 2)
			{
				flag = false;
			}
			if (currentRoom.IsSealed && nearestRoom != currentRoom)
			{
				flag = false;
			}
			if (currentRoom.IsSealed && val.isExitCell)
			{
				flag = false;
			}
			if ((int)nearestRoom.visibility == 0 || (int)nearestRoom.visibility == 3)
			{
				flag = false;
			}
		}
		if (currentRoom == null)
		{
			flag = false;
		}
		return flag;
	}

	private static IEnumerator HandleBlinkTeleport(PlayerController Owner, Vector2 targetPoint, Vector2 targetDirection)
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CHandleBlinkTeleport_003Ed__6(0)
		{
			Owner = Owner,
			targetPoint = targetPoint,
			targetDirection = targetDirection
		};
	}

	public static void CorrectForWalls(PlayerController portal)
	{
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0082: Unknown result type (might be due to invalid IL or missing references)
		//IL_0087: Unknown result type (might be due to invalid IL or missing references)
		//IL_008c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0091: Unknown result type (might be due to invalid IL or missing references)
		if (!PhysicsEngine.Instance.OverlapCast(((BraveBehaviour)portal).specRigidbody, (List<CollisionData>)null, true, false, (int?)null, (int?)null, false, (Vector2?)null, (Func<SpeculativeRigidbody, bool>)null, (SpeculativeRigidbody[])(object)new SpeculativeRigidbody[0]))
		{
			return;
		}
		Vector2 val = Vector3Extensions.XY(((BraveBehaviour)portal).transform.position);
		IntVector2[] cardinalsAndOrdinals = IntVector2.CardinalsAndOrdinals;
		int num = 0;
		int num2 = 1;
		do
		{
			for (int i = 0; i < cardinalsAndOrdinals.Length; i++)
			{
				((BraveBehaviour)portal).specRigidbody.Position = new Position(val + PhysicsEngine.PixelToUnit(cardinalsAndOrdinals[i] * num2));
				((BraveBehaviour)portal).specRigidbody.Reinitialize();
				if (!PhysicsEngine.Instance.OverlapCast(((BraveBehaviour)portal).specRigidbody, (List<CollisionData>)null, true, false, (int?)null, (int?)null, false, (Vector2?)null, (Func<SpeculativeRigidbody, bool>)null, (SpeculativeRigidbody[])(object)new SpeculativeRigidbody[0]))
				{
					return;
				}
			}
			num2++;
			num++;
		}
		while (num <= 200);
		Debug.LogError((object)"FREEZE AVERTED!  TELL RUBEL!  (you're welcome) 147");
	}
}
