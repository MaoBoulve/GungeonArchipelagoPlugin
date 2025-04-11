using UnityEngine;

namespace NevernamedsItems;

public class TextBubble
{
	public static void DoAmbientTalk(Transform baseTransform, Vector3 offset, string stringKey, float duration)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		TextBoxManager.ShowTextBox(baseTransform.position + offset, baseTransform, duration, stringKey, string.Empty, false, (BoxSlideOrientation)0, false, false);
	}
}
