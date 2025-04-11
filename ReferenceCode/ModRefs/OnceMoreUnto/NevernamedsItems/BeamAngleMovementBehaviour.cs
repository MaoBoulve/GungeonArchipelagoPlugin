using System.Collections.Generic;
using UnityEngine;

namespace NevernamedsItems;

public class BeamAngleMovementBehaviour : MonoBehaviour
{
	public class TargetBeamRotation
	{
		public float rotationAmount;

		public float timeToChangeOver;

		public bool holdAfter = false;
	}

	public List<TargetBeamRotation> targets = new List<TargetBeamRotation>();

	private Projectile m_projectile;

	private BeamController beam;

	public bool loopAfterTargetCompletion = true;

	private float timeSinceLastTarget = 0f;

	private int currentTargetIndex = 0;

	private bool completed;

	public BeamAngleMovementBehaviour()
	{
		completed = false;
	}

	private void Awake()
	{
		m_projectile = ((Component)this).GetComponent<Projectile>();
		beam = ((Component)m_projectile).GetComponent<BeamController>();
	}

	private void LateUpdate()
	{
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_007f: Unknown result type (might be due to invalid IL or missing references)
		if (targets.Count <= 0 || completed)
		{
			return;
		}
		timeSinceLastTarget += BraveTime.DeltaTime;
		float num = Mathf.Lerp(0f, targets[currentTargetIndex].rotationAmount, timeSinceLastTarget / targets[currentTargetIndex].timeToChangeOver);
		Vector2Extensions.Rotate(beam.Direction, num);
		if (!(timeSinceLastTarget <= targets[currentTargetIndex].timeToChangeOver))
		{
			return;
		}
		timeSinceLastTarget = 0f;
		if (targets.Count - 1 == currentTargetIndex)
		{
			if (loopAfterTargetCompletion)
			{
				currentTargetIndex = 0;
			}
			else
			{
				completed = true;
			}
		}
		else
		{
			currentTargetIndex++;
		}
	}
}
