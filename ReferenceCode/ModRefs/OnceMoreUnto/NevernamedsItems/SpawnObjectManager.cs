using System;
using System.Collections.Generic;
using Dungeonator;
using UnityEngine;

namespace NevernamedsItems;

public class SpawnObjectManager : MonoBehaviour
{
	public static void SpawnObject(GameObject thingToSpawn, Vector3 convertedVector, GameObject SpawnVFX, bool correctForWalls = false)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_0113: Unknown result type (might be due to invalid IL or missing references)
		//IL_0118: Unknown result type (might be due to invalid IL or missing references)
		//IL_011d: Unknown result type (might be due to invalid IL or missing references)
		Vector2 val = Vector2.op_Implicit(convertedVector);
		GameObject val2 = Object.Instantiate<GameObject>(thingToSpawn, convertedVector, Quaternion.identity);
		SpeculativeRigidbody componentInChildren = val2.GetComponentInChildren<SpeculativeRigidbody>();
		Component[] componentsInChildren = val2.GetComponentsInChildren(typeof(IPlayerInteractable));
		foreach (Component obj in componentsInChildren)
		{
			IPlayerInteractable val3 = (IPlayerInteractable)(object)((obj is IPlayerInteractable) ? obj : null);
			if (val3 != null)
			{
				Vector3Extensions.GetAbsoluteRoom(val2.transform.position).RegisterInteractable(val3);
			}
		}
		Component[] componentsInChildren2 = val2.GetComponentsInChildren(typeof(IPlaceConfigurable));
		foreach (Component obj2 in componentsInChildren2)
		{
			IPlaceConfigurable val4 = (IPlaceConfigurable)(object)((obj2 is IPlaceConfigurable) ? obj2 : null);
			if (val4 != null)
			{
				val4.ConfigureOnPlacement(GameManager.Instance.Dungeon.data.GetAbsoluteRoomFromPosition(Vector2Extensions.ToIntVector2(val, (VectorConversions)2)));
			}
		}
		componentInChildren.Initialize();
		PhysicsEngine.Instance.RegisterOverlappingGhostCollisionExceptions(componentInChildren, (int?)null, false);
		if ((Object)(object)SpawnVFX != (Object)null)
		{
			Object.Instantiate<GameObject>(SpawnVFX, Vector2.op_Implicit(((BraveBehaviour)componentInChildren).sprite.WorldCenter), Quaternion.identity);
		}
		if (correctForWalls)
		{
			CorrectForWalls(val2);
		}
	}

	private static void CorrectForWalls(GameObject portal)
	{
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		//IL_008b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0092: Unknown result type (might be due to invalid IL or missing references)
		//IL_0097: Unknown result type (might be due to invalid IL or missing references)
		//IL_009c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
		SpeculativeRigidbody component = portal.GetComponent<SpeculativeRigidbody>();
		if (!Object.op_Implicit((Object)(object)component) || !PhysicsEngine.Instance.OverlapCast(component, (List<CollisionData>)null, true, false, (int?)null, (int?)null, false, (Vector2?)null, (Func<SpeculativeRigidbody, bool>)null, (SpeculativeRigidbody[])(object)new SpeculativeRigidbody[0]))
		{
			return;
		}
		Vector2 val = Vector3Extensions.XY(portal.transform.position);
		IntVector2[] cardinalsAndOrdinals = IntVector2.CardinalsAndOrdinals;
		int num = 0;
		int num2 = 1;
		do
		{
			for (int i = 0; i < cardinalsAndOrdinals.Length; i++)
			{
				portal.transform.position = Vector2.op_Implicit(val + PhysicsEngine.PixelToUnit(cardinalsAndOrdinals[i] * num2));
				component.Reinitialize();
				if (!PhysicsEngine.Instance.OverlapCast(component, (List<CollisionData>)null, true, false, (int?)null, (int?)null, false, (Vector2?)null, (Func<SpeculativeRigidbody, bool>)null, (SpeculativeRigidbody[])(object)new SpeculativeRigidbody[0]))
				{
					return;
				}
			}
			num2++;
			num++;
		}
		while (num <= 200);
		Debug.LogError((object)"FREEZE AVERTED!  TELL RUBEL!  (you're welcome) 147");
	}
}
