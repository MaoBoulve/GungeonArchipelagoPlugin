using System;
using System.Collections.Generic;
using UnityEngine;

namespace NevernamedsItems;

public class TurtleShrineEffectHandler : MonoBehaviour
{
	private int CountForNextFloor;

	private List<GameObject> activeTurtles;

	private PlayerController player;

	private void Start()
	{
		player = ((Component)this).GetComponent<PlayerController>();
		FloorAndGenerationToolbox.OnFloorEntered = (Action)Delegate.Combine(FloorAndGenerationToolbox.OnFloorEntered, new Action(LevelLoadStart));
		FloorAndGenerationToolbox.OnFloorEntered = (Action)Delegate.Combine(FloorAndGenerationToolbox.OnFloorEntered, new Action(LevelLoadFinish));
		activeTurtles = new List<GameObject>();
	}

	private void OnDestroy()
	{
		FloorAndGenerationToolbox.OnFloorEntered = (Action)Delegate.Remove(FloorAndGenerationToolbox.OnFloorEntered, new Action(LevelLoadStart));
		FloorAndGenerationToolbox.OnFloorEntered = (Action)Delegate.Remove(FloorAndGenerationToolbox.OnFloorEntered, new Action(LevelLoadFinish));
	}

	private void LevelLoadStart()
	{
		CountForNextFloor = activeTurtles.Count;
		for (int num = activeTurtles.Count - 1; num >= 0; num--)
		{
			Object.Destroy((Object)(object)activeTurtles[num]);
		}
		activeTurtles.Clear();
	}

	private void LevelLoadFinish()
	{
		if (CountForNextFloor > 0)
		{
			for (int i = 0; i < CountForNextFloor; i++)
			{
				SpawnNewTurtle();
			}
		}
	}

	public void SpawnNewTurtle()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		string companionGuid = ((Component)PickupObjectDatabase.GetById(645)).GetComponent<MulticompanionItem>().CompanionGuid;
		AIActor orLoadByGuid = EnemyDatabase.GetOrLoadByGuid(companionGuid);
		Vector3 position = ((BraveBehaviour)player).transform.position;
		GameObject val = Object.Instantiate<GameObject>(((Component)orLoadByGuid).gameObject, position, Quaternion.identity);
		CompanionController orAddComponent = GameObjectExtensions.GetOrAddComponent<CompanionController>(val);
		if (activeTurtles == null)
		{
			activeTurtles = new List<GameObject>();
		}
		activeTurtles.Add(val);
		orAddComponent.Initialize(player);
		if (Object.op_Implicit((Object)(object)((BraveBehaviour)orAddComponent).specRigidbody))
		{
			PhysicsEngine.Instance.RegisterOverlappingGhostCollisionExceptions(((BraveBehaviour)orAddComponent).specRigidbody, (int?)null, false);
		}
		HealthHaver component = val.GetComponent<HealthHaver>();
		if ((Object)(object)component != (Object)null)
		{
			float num = component.GetMaxHealth() * 3f;
			component.SetHealthMaximum(num, (float?)null, false);
			component.ForceSetCurrentHealth(num);
		}
	}
}
