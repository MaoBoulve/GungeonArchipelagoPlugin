using UnityEngine;

namespace NevernamedsItems;

public class GameActorConfusionEffect : GameActorEffect
{
	private GameObject extantConfusionDecoy;

	public override void OnEffectApplied(GameActor actor, RuntimeGameActorEffectData effectData, float partialAmount = 1f)
	{
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		if (Object.op_Implicit((Object)(object)actor) && Object.op_Implicit((Object)(object)((BraveBehaviour)actor).specRigidbody))
		{
			GameObject val = Object.Instantiate<GameObject>(Confusion.ConfusionDecoyTarget, Vector2.op_Implicit(actor.CenterPosition), Quaternion.identity);
			val.GetComponent<ConfusionDecoyTargetController>().surroundObject = ((BraveBehaviour)actor).specRigidbody;
			extantConfusionDecoy = val;
		}
		((GameActorEffect)this).OnEffectApplied(actor, effectData, partialAmount);
	}

	public override void OnEffectRemoved(GameActor actor, RuntimeGameActorEffectData effectData)
	{
		if (Object.op_Implicit((Object)(object)extantConfusionDecoy))
		{
			Object.Destroy((Object)(object)extantConfusionDecoy);
		}
		((GameActorEffect)this).OnEffectRemoved(actor, effectData);
	}
}
