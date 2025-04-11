using UnityEngine;

namespace NevernamedsItems;

public class PositionRandomiser : BraveBehaviour
{
	public float xOffsetMin;

	public float xOffsetMax;

	public float yOffsetMin;

	public float yOffsetMax;

	private void Start()
	{
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		Vector3 val = default(Vector3);
		((Vector3)(ref val))._002Ector(Random.Range(xOffsetMin / 16f, xOffsetMax / 16f), Random.Range(yOffsetMin / 16f, yOffsetMax / 16f));
		if ((Object)(object)((BraveBehaviour)this).transform.parent != (Object)null)
		{
			Transform transform = ((BraveBehaviour)this).transform;
			transform.localPosition += val;
		}
		else
		{
			Transform transform2 = ((BraveBehaviour)this).transform;
			transform2.position += val;
		}
		if (Object.op_Implicit((Object)(object)((BraveBehaviour)this).specRigidbody))
		{
			((BraveBehaviour)this).specRigidbody.Reinitialize();
		}
	}
}
