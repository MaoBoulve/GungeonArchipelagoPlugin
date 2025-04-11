using UnityEngine;

namespace NevernamedsItems;

public class StickPlayerToDebug : MonoBehaviour
{
	public PlayerController player;

	private SpeculativeRigidbody Obj;

	public StickPlayerToDebug()
	{
		Obj = ((Component)this).GetComponent<SpeculativeRigidbody>();
	}

	private void Update()
	{
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		((BraveBehaviour)player).specRigidbody.Position = new Position(Obj.Position);
	}
}
