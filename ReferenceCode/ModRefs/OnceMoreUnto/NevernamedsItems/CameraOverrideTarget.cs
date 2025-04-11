using UnityEngine;

namespace NevernamedsItems;

public class CameraOverrideTarget : MonoBehaviour
{
	public bool startOverrideOnStart;

	private SpeculativeRigidbody targetObject;

	public float duration;

	private float timer;

	public CameraOverrideTarget()
	{
		startOverrideOnStart = false;
		duration = -1f;
		timer = -1f;
	}

	private void OnDestroy()
	{
		GameManager.Instance.MainCameraController.SetManualControl(false, true);
	}

	private void Start()
	{
		targetObject = ((Component)this).GetComponent<SpeculativeRigidbody>();
		if (startOverrideOnStart)
		{
			BeginOverride();
		}
	}

	private void Update()
	{
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		if (Object.op_Implicit((Object)(object)targetObject))
		{
			GameManager.Instance.MainCameraController.OverridePosition = Vector2.op_Implicit(targetObject.UnitCenter);
		}
		if (duration > 0f)
		{
			if (timer <= 0f)
			{
				EndOverride();
			}
			else
			{
				timer -= BraveTime.DeltaTime;
			}
		}
	}

	public void BeginOverride()
	{
		GameManager.Instance.MainCameraController.SetManualControl(true, false);
		if (duration > 0f)
		{
			timer = duration;
		}
	}

	public void EndOverride()
	{
		GameManager.Instance.MainCameraController.SetManualControl(false, true);
	}
}
