using UnityEngine;

namespace NevernamedsItems;

public class GameActorJarateEffect : AIActorDebuffEffect
{
	private float pissAccum;

	private FleePlayerData flee;

	public GameActorJarateEffect()
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		((GameActorEffect)this).TintColor = Color.yellow;
		((GameActorEffect)this).DeathTintColor = Color.yellow;
		((GameActorEffect)this).AppliesTint = true;
		((GameActorEffect)this).AppliesDeathTint = true;
		((GameActorEffect)this).AffectsPlayers = false;
		((GameActorEffect)this).AffectsEnemies = true;
		((GameActorEffect)this).effectIdentifier = "jarated";
		pissAccum = 0f;
	}

	public override void OnEffectApplied(GameActor actor, RuntimeGameActorEffectData effectData, float partialAmount = 1f)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Expected O, but got Unknown
		flee = new FleePlayerData();
		flee.Player = GameManager.Instance.PrimaryPlayer;
		flee.StartDistance = 5f;
		flee.StopDistance = 8f;
		actor.RemoveEffect("fire");
		if (actor is AIActor && ((AIActor)((actor is AIActor) ? actor : null)).IsBlackPhantom)
		{
			((AIActor)((actor is AIActor) ? actor : null)).UnbecomeBlackPhantom();
		}
		((AIActorDebuffEffect)this).OnEffectApplied(actor, effectData, partialAmount);
	}

	public override void EffectTick(GameActor actor, RuntimeGameActorEffectData effectData)
	{
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_0086: Unknown result type (might be due to invalid IL or missing references)
		//IL_0091: Unknown result type (might be due to invalid IL or missing references)
		//IL_0096: Unknown result type (might be due to invalid IL or missing references)
		//IL_009b: Unknown result type (might be due to invalid IL or missing references)
		pissAccum += BraveTime.DeltaTime * 3f;
		if (pissAccum > 1f)
		{
			int num = Mathf.FloorToInt(pissAccum);
			pissAccum %= 1f;
			Vector2 worldBottomLeft = ((BraveBehaviour)actor).sprite.WorldBottomLeft;
			Vector2 worldTopRight = ((BraveBehaviour)actor).sprite.WorldTopRight;
			for (int i = 0; i < num; i++)
			{
				GameObject val = Object.Instantiate<GameObject>(SharedVFX.JarateDrip, Vector2.op_Implicit(new Vector2(Random.Range(worldBottomLeft.x, worldTopRight.x), Random.Range(worldBottomLeft.y, worldTopRight.y))), Quaternion.identity);
				val.transform.parent = ((BraveBehaviour)actor).transform;
				val.GetComponent<tk2dBaseSprite>().HeightOffGround = 0.2f;
				((BraveBehaviour)actor).sprite.AttachRenderer(val.GetComponent<tk2dBaseSprite>());
			}
		}
		if (actor is AIActor)
		{
			AIActor val2 = (AIActor)(object)((actor is AIActor) ? actor : null);
			if (val2.IsBlackPhantom)
			{
				val2.UnbecomeBlackPhantom();
			}
			if ((Object)(object)((BraveBehaviour)val2).behaviorSpeculator != (Object)null && flee != null && ((BraveBehaviour)val2).behaviorSpeculator.FleePlayerData == null)
			{
				((BraveBehaviour)val2).behaviorSpeculator.FleePlayerData = flee;
			}
		}
		((GameActorEffect)this).EffectTick(actor, effectData);
	}

	public override void OnEffectRemoved(GameActor actor, RuntimeGameActorEffectData effectData)
	{
		if (actor is AIActor && (Object)(object)((BraveBehaviour)((actor is AIActor) ? actor : null)).behaviorSpeculator != (Object)null && ((BraveBehaviour)((actor is AIActor) ? actor : null)).behaviorSpeculator.FleePlayerData != null && ((BraveBehaviour)((actor is AIActor) ? actor : null)).behaviorSpeculator.FleePlayerData == flee)
		{
			((BraveBehaviour)((actor is AIActor) ? actor : null)).behaviorSpeculator.FleePlayerData = null;
		}
		((AIActorDebuffEffect)this).OnEffectRemoved(actor, effectData);
	}
}
