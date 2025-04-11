using UnityEngine;

namespace NevernamedsItems;

internal static class JamTheLord
{
	public static void BecomeJammedLord(this SuperReaperController controller)
	{
		if (!((Object)(object)((Component)controller).GetComponent<JammedLordController>() != (Object)null))
		{
			((Component)controller).gameObject.AddComponent<JammedLordController>().Initialize(controller);
		}
	}

	public static void UnbecomeJammedLord(this SuperReaperController controller)
	{
		if ((Object)(object)((Component)controller).GetComponent<JammedLordController>() != (Object)null)
		{
			((Component)controller).GetComponent<JammedLordController>().Uninitialize();
		}
	}
}
