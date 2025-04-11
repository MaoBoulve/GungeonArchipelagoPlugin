using Dungeonator;
using UnityEngine;

namespace NevernamedsItems;

public class TeleportNonsense
{
	public static bool CanBlinkToPoint(PlayerController Owner, Vector2 point)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Invalid comparison between Unknown and I4
		//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c1: Invalid comparison between Unknown and I4
		bool flag = Owner.IsValidPlayerPosition(point);
		if (flag && Owner.CurrentRoom != null)
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
			if (Owner.CurrentRoom.IsSealed && nearestRoom != Owner.CurrentRoom)
			{
				flag = false;
			}
			if (Owner.CurrentRoom.IsSealed && val.isExitCell)
			{
				flag = false;
			}
			if ((int)nearestRoom.visibility == 0 || (int)nearestRoom.visibility == 3)
			{
				flag = false;
			}
		}
		if (Owner.CurrentRoom == null)
		{
			flag = false;
		}
		if (Owner.IsDodgeRolling | ((GameActor)Owner).IsFalling | Owner.IsCurrentlyCoopReviving | Owner.IsInMinecart | Owner.IsInputOverridden)
		{
			return false;
		}
		return flag;
	}

	public static bool PositionIsInBounds(PlayerController Owner, Vector2 point)
	{
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Invalid comparison between Unknown and I4
		//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b5: Invalid comparison between Unknown and I4
		bool result = true;
		if (Owner.CurrentRoom != null)
		{
			CellData val = GameManager.Instance.Dungeon.data[Vector2Extensions.ToIntVector2(point, (VectorConversions)0)];
			if (val == null)
			{
				return false;
			}
			RoomHandler nearestRoom = val.nearestRoom;
			if ((int)val.type != 2)
			{
				result = false;
			}
			if (Owner.CurrentRoom.IsSealed && nearestRoom != Owner.CurrentRoom)
			{
				result = false;
			}
			if (Owner.CurrentRoom.IsSealed && val.isExitCell)
			{
				result = false;
			}
			if ((int)nearestRoom.visibility == 0 || (int)nearestRoom.visibility == 3)
			{
				result = false;
			}
		}
		if (Owner.CurrentRoom == null)
		{
			result = false;
		}
		if (Owner.IsDodgeRolling | ((GameActor)Owner).IsFalling | Owner.IsCurrentlyCoopReviving | Owner.IsInMinecart | Owner.IsInputOverridden)
		{
			return false;
		}
		return result;
	}

	public static Vector2 AdjustInputVector(Vector2 rawInput, float cardinalMagnetAngle, float ordinalMagnetAngle)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
		float num = BraveMathCollege.ClampAngle360(BraveMathCollege.Atan2Degrees(rawInput));
		float num2 = num % 90f;
		float num3 = (num + 45f) % 90f;
		float num4 = 0f;
		if (cardinalMagnetAngle > 0f)
		{
			if (num2 < cardinalMagnetAngle)
			{
				num4 = 0f - num2;
			}
			else if (num2 > 90f - cardinalMagnetAngle)
			{
				num4 = 90f - num2;
			}
		}
		if (ordinalMagnetAngle > 0f)
		{
			if (num3 < ordinalMagnetAngle)
			{
				num4 = 0f - num3;
			}
			else if (num3 > 90f - ordinalMagnetAngle)
			{
				num4 = 90f - num3;
			}
		}
		num += num4;
		return Vector3Extensions.XY(Quaternion.Euler(0f, 0f, num) * Vector3.right) * ((Vector2)(ref rawInput)).magnitude;
	}
}
