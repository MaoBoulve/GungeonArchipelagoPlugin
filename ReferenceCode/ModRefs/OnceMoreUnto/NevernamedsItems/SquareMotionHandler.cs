using UnityEngine;

namespace NevernamedsItems;

public class SquareMotionHandler : MonoBehaviour
{
	private Projectile self;

	public float horizontalLimiter;

	public float verticalLimiter;

	private float curDistance;

	private float lastDistance;

	private float curTargetDistance;

	public float angleChange;

	public bool randomiseStart;

	public bool startLeft;

	private int stage;

	public SquareMotionHandler()
	{
		horizontalLimiter = 3f;
		verticalLimiter = 2f;
		stage = 0;
		angleChange = 90f;
		randomiseStart = false;
		startLeft = true;
	}

	private void Start()
	{
		if (!startLeft)
		{
			stage = -1;
		}
		if (randomiseStart)
		{
			stage = ((Random.value <= 0.5f) ? (-1) : 0);
		}
		self = ((Component)this).GetComponent<Projectile>();
	}

	private void Update()
	{
		if (Object.op_Implicit((Object)(object)self) && self.m_distanceElapsed > lastDistance)
		{
			curDistance += self.m_distanceElapsed - lastDistance;
			lastDistance = self.m_distanceElapsed;
		}
		if (curDistance >= curTargetDistance)
		{
			ProgressStage();
			curDistance = 0f;
		}
	}

	private void ProgressStage()
	{
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_009b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0108: Unknown result type (might be due to invalid IL or missing references)
		//IL_0113: Unknown result type (might be due to invalid IL or missing references)
		//IL_0141: Unknown result type (might be due to invalid IL or missing references)
		//IL_014d: Unknown result type (might be due to invalid IL or missing references)
		//IL_017b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0187: Unknown result type (might be due to invalid IL or missing references)
		switch (stage)
		{
		case -1:
			curTargetDistance = verticalLimiter * 0.5f;
			self.SendInDirection(Vector2Extensions.Rotate(self.Direction, angleChange), false, true);
			stage = 3;
			break;
		case 0:
			curTargetDistance = verticalLimiter * 0.5f;
			self.SendInDirection(Vector2Extensions.Rotate(self.Direction, 0f - angleChange), false, true);
			stage = 1;
			break;
		case 1:
			curTargetDistance = horizontalLimiter;
			self.SendInDirection(Vector2Extensions.Rotate(self.Direction, angleChange), false, true);
			stage = 2;
			break;
		case 2:
			curTargetDistance = verticalLimiter;
			self.SendInDirection(Vector2Extensions.Rotate(self.Direction, angleChange), false, true);
			stage = 3;
			break;
		case 3:
			curTargetDistance = horizontalLimiter;
			self.SendInDirection(Vector2Extensions.Rotate(self.Direction, 0f - angleChange), false, true);
			stage = 4;
			break;
		case 4:
			curTargetDistance = verticalLimiter;
			self.SendInDirection(Vector2Extensions.Rotate(self.Direction, 0f - angleChange), false, true);
			stage = 1;
			break;
		}
	}
}
