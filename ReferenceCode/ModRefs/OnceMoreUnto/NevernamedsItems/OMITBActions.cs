using System;

namespace NevernamedsItems;

public static class OMITBActions
{
	public delegate void ChSclModify(ref float scalar, PlayerController player);

	public static ChSclModify ModifyChanceScalar;

	public static Action<MinorBreakable> MinorBreakableBroken;
}
