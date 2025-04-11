using System;
using UnityEngine;

namespace NevernamedsItems;

public class GumPile : MonoBehaviour
{
	public SpeculativeRigidbody target;

	public float lifetime = 1f;

	public float elapsed;

	private void Update()
	{
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		elapsed += BraveTime.DeltaTime;
		if (elapsed > lifetime)
		{
			End();
			GameObject val = SpawnManager.SpawnVFX(ChewingGun.popVFX, ((Component)this).transform.position, Quaternion.identity);
			val.transform.localScale = Vector2.op_Implicit(new Vector2(0.25f, 0.25f));
			Object.Destroy((Object)(object)((Component)this).gameObject);
		}
	}

	public void Start()
	{
		if (!Object.op_Implicit((Object)(object)target))
		{
			return;
		}
		Component[] componentsInChildren = ((Component)target).gameObject.GetComponentsInChildren<Component>();
		foreach (Component val in componentsInChildren)
		{
			if (val is GumPile && (Object)(object)(val as GumPile) != (Object)(object)this)
			{
				lifetime += (val as GumPile).lifetime - (val as GumPile).elapsed;
				(val as GumPile).End();
				Object.Destroy((Object)(object)val.gameObject);
			}
		}
		SpeculativeRigidbody obj = target;
		obj.OnPreMovement = (Action<SpeculativeRigidbody>)Delegate.Combine(obj.OnPreMovement, new Action<SpeculativeRigidbody>(ModifyVelocity));
	}

	public void End()
	{
		if (Object.op_Implicit((Object)(object)target))
		{
			SpeculativeRigidbody obj = target;
			obj.OnPreMovement = (Action<SpeculativeRigidbody>)Delegate.Remove(obj.OnPreMovement, new Action<SpeculativeRigidbody>(ModifyVelocity));
		}
	}

	public void ModifyVelocity(SpeculativeRigidbody myRigidbody)
	{
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		myRigidbody.Velocity *= 0f;
	}
}
