using System;
using Dungeonator;
using UnityEngine;

namespace NevernamedsItems;

public class EraseFromExistenceOnRoomClear : BraveBehaviour
{
	public bool preventExplodeOnDeath;

	public bool forceExplodeOnDeath;

	public float Delay;

	public void Start()
	{
		RoomHandler parentRoom = ((BraveBehaviour)this).aiActor.ParentRoom;
		parentRoom.OnEnemiesCleared = (Action)Delegate.Combine(parentRoom.OnEnemiesCleared, new Action(RoomCleared));
	}

	public override void OnDestroy()
	{
		if (Object.op_Implicit((Object)(object)((BraveBehaviour)this).aiActor) && ((BraveBehaviour)this).aiActor.ParentRoom != null)
		{
			RoomHandler parentRoom = ((BraveBehaviour)this).aiActor.ParentRoom;
			parentRoom.OnEnemiesCleared = (Action)Delegate.Remove(parentRoom.OnEnemiesCleared, new Action(RoomCleared));
		}
		((BraveBehaviour)this).OnDestroy();
	}

	private void RoomCleared()
	{
		((MonoBehaviour)this).Invoke("DoEliminate", Delay);
	}

	private void DoEliminate()
	{
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		if (!((Object)(object)((BraveBehaviour)this).aiActor != (Object)null))
		{
			return;
		}
		if (preventExplodeOnDeath)
		{
			ExplodeOnDeath component = ((Component)this).GetComponent<ExplodeOnDeath>();
			if (Object.op_Implicit((Object)(object)component))
			{
				((Behaviour)component).enabled = false;
			}
		}
		((BraveBehaviour)this).healthHaver.PreventAllDamage = false;
		Exploder.DoDefaultExplosion(Vector2.op_Implicit(((BraveBehaviour)((BraveBehaviour)this).aiActor).sprite.WorldCenter), Vector2.zero, (Action)null, false, (CoreDamageTypes)0, false);
		((BraveBehaviour)this).aiActor.EraseFromExistenceWithRewards(false);
	}
}
