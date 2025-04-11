using UnityEngine;

namespace NevernamedsItems;

public class ProjectileSpinner : MonoBehaviour
{
	public float degreesPerSecond = 180f;

	public void Start()
	{
	}

	public void Update()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		Quaternion rotation = ((Component)this).transform.rotation;
		float z = ((Quaternion)(ref rotation)).eulerAngles.z;
		((Component)this).transform.rotation = Quaternion.Euler(0f, 0f, z + degreesPerSecond * BraveTime.DeltaTime);
	}
}
