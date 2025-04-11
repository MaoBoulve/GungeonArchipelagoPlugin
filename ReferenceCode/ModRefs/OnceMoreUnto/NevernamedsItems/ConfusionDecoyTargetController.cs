using Alexandria.Misc;
using UnityEngine;

namespace NevernamedsItems;

public class ConfusionDecoyTargetController : MonoBehaviour
{
	private SpeculativeRigidbody baseBody;

	public SpeculativeRigidbody surroundObject;

	private void Start()
	{
		baseBody = ((Component)this).GetComponent<SpeculativeRigidbody>();
	}

	private void Update()
	{
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		//IL_0071: Unknown result type (might be due to invalid IL or missing references)
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0082: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		if (Object.op_Implicit((Object)(object)baseBody) && Object.op_Implicit((Object)(object)surroundObject) && Object.op_Implicit((Object)(object)GameManager.Instance.PrimaryPlayer))
		{
			Vector2 val = MathsAndLogicHelper.CalculateVectorBetween(((BraveBehaviour)GameManager.Instance.PrimaryPlayer).specRigidbody.UnitCenter, surroundObject.UnitCenter);
			Vector2 val2 = surroundObject.UnitCenter + ((Vector2)(ref val)).normalized * 5f;
			((Component)this).transform.position = Vector2.op_Implicit(val2);
			baseBody.Reinitialize();
			Object.Instantiate<GameObject>(SharedVFX.YellowLaserCircleVFX, Vector2.op_Implicit(baseBody.UnitCenter), Quaternion.identity);
		}
		if (Object.op_Implicit((Object)(object)baseBody) && Object.op_Implicit((Object)(object)surroundObject) && (Object)(object)((BraveBehaviour)surroundObject).aiActor != (Object)null)
		{
			((BraveBehaviour)surroundObject).aiActor.OverrideTarget = baseBody;
		}
		if ((Object)(object)surroundObject == (Object)null)
		{
			Object.Destroy((Object)(object)((Component)this).gameObject);
		}
		else if ((Object)(object)((BraveBehaviour)surroundObject).healthHaver != (Object)null && ((BraveBehaviour)surroundObject).healthHaver.IsDead)
		{
			Object.Destroy((Object)(object)((Component)this).gameObject);
		}
	}
}
