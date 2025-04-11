using UnityEngine;

namespace NevernamedsItems;

public class PlacedObjectRotator : BraveBehaviour
{
	public float minRotation = -90f;

	public float maxnRotation = 90f;

	public bool strict = true;

	public float chanceToTriggerOnStart = 1f;

	private void Start()
	{
		if (Random.value <= chanceToTriggerOnStart)
		{
			DoRotation();
		}
	}

	public void DoRotation()
	{
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		float num = 0f;
		num = ((!strict) ? Random.Range(minRotation, maxnRotation) : ((Random.value <= 0.5f) ? minRotation : maxnRotation));
		Quaternion rotation = ((BraveBehaviour)this).transform.rotation;
		float z = ((Quaternion)(ref rotation)).eulerAngles.z;
		((BraveBehaviour)this).transform.rotation = Quaternion.Euler(0f, 0f, z + num);
		if (Object.op_Implicit((Object)(object)((BraveBehaviour)this).specRigidbody))
		{
			((BraveBehaviour)this).specRigidbody.Reinitialize();
		}
	}
}
