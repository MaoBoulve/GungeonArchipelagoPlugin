using System.Collections;
using Brave.BulletScript;

namespace NevernamedsItems;

public class JammedCircleBurst12 : Script
{
	public override IEnumerator Top()
	{
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Expected O, but got Unknown
		//IL_003e: Expected O, but got Unknown
		//IL_003e: Expected O, but got Unknown
		float num = ((Bullet)this).RandomAngle();
		float num2 = 30f;
		for (int i = 0; i < 12; i++)
		{
			((Bullet)this).Fire(new Direction(num + (float)i * num2, (DirectionType)1, -1f), new Speed(9f, (SpeedType)0), new Bullet((string)null, false, false, true));
		}
		return null;
	}
}
