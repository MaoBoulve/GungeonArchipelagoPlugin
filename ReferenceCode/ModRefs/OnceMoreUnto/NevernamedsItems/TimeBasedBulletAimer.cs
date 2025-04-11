using System;
using Alexandria.Misc;
using UnityEngine;

namespace NevernamedsItems;

public class TimeBasedBulletAimer : MonoBehaviour
{
	public enum ClockHandAimType
	{
		MINUTE_HAND,
		HOUR_HAND,
		SECOND_HAND,
		NULL
	}

	private Projectile m_projectile;

	public ClockHandAimType aimType;

	public TimeBasedBulletAimer()
	{
		aimType = ClockHandAimType.NULL;
	}

	private void Start()
	{
		//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f9: Unknown result type (might be due to invalid IL or missing references)
		m_projectile = ((Component)this).GetComponent<Projectile>();
		DateTime now = DateTime.Now;
		int minute = now.Minute;
		int num = -1;
		int second = now.Second;
		num = ((now.Hour <= 12) ? now.Hour : (now.Hour - 12));
		float num2 = ((float)minute * 6f - 90f) * -1f;
		float num3 = ((float)num * 30f - 90f) * -1f;
		float num4 = ((float)second * 6f - 90f) * -1f;
		if (aimType == ClockHandAimType.MINUTE_HAND)
		{
			m_projectile.SendInDirection(MathsAndLogicHelper.DegreeToVector2(num2), false, true);
		}
		else if (aimType == ClockHandAimType.HOUR_HAND)
		{
			m_projectile.SendInDirection(MathsAndLogicHelper.DegreeToVector2(num3), false, true);
		}
		else if (aimType == ClockHandAimType.SECOND_HAND)
		{
			m_projectile.SendInDirection(MathsAndLogicHelper.DegreeToVector2(num4), false, true);
		}
	}
}
