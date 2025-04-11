using System;
using UnityEngine;

namespace NevernamedsItems;

public class GameActorGildedEffect : GameActorEffect
{
	private float sparkleAccum;

	private float cachedHealth = 0f;

	private int currencyToSpawnNextTick = 0;

	public GameActorGildedEffect()
	{
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		base.TintColor = ExtendedColours.gildedBulletsGold;
		base.DeathTintColor = ExtendedColours.gildedBulletsGold;
		base.AppliesTint = true;
		base.AppliesDeathTint = true;
		base.AffectsPlayers = false;
		base.AffectsEnemies = true;
		base.effectIdentifier = "gilded";
		base.OverheadVFX = SharedVFX.GildedOverhead;
		sparkleAccum = 0f;
	}

	public override void OnEffectApplied(GameActor actor, RuntimeGameActorEffectData effectData, float partialAmount = 1f)
	{
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Expected O, but got Unknown
		if (Object.op_Implicit((Object)(object)actor) && (Object)(object)((BraveBehaviour)actor).healthHaver != (Object)null)
		{
			cachedHealth = ((BraveBehaviour)actor).healthHaver.currentHealth;
			((BraveBehaviour)actor).healthHaver.OnHealthChanged += new OnHealthChangedEvent(Hurt);
		}
		((GameActorEffect)this).OnEffectApplied(actor, effectData, partialAmount);
	}

	public void Hurt(float currentHealth, float maxHealth)
	{
		float num = cachedHealth - currentHealth;
		if (num > 0f)
		{
			currencyToSpawnNextTick = Mathf.FloorToInt(num / 3.5f);
			currencyToSpawnNextTick = Math.Max(currencyToSpawnNextTick, 0);
		}
		cachedHealth = currentHealth;
	}

	public override void EffectTick(GameActor actor, RuntimeGameActorEffectData effectData)
	{
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_0106: Unknown result type (might be due to invalid IL or missing references)
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_0086: Unknown result type (might be due to invalid IL or missing references)
		//IL_0091: Unknown result type (might be due to invalid IL or missing references)
		//IL_0096: Unknown result type (might be due to invalid IL or missing references)
		//IL_009b: Unknown result type (might be due to invalid IL or missing references)
		sparkleAccum += BraveTime.DeltaTime * 3f;
		if (sparkleAccum > 1f)
		{
			int num = Mathf.FloorToInt(sparkleAccum);
			sparkleAccum %= 1f;
			Vector2 worldBottomLeft = ((BraveBehaviour)actor).sprite.WorldBottomLeft;
			Vector2 worldTopRight = ((BraveBehaviour)actor).sprite.WorldTopRight;
			for (int i = 0; i < num; i++)
			{
				GameObject val = Object.Instantiate<GameObject>(SharedVFX.GoldenSparkle, Vector2.op_Implicit(new Vector2(Random.Range(worldBottomLeft.x, worldTopRight.x), Random.Range(worldBottomLeft.y, worldTopRight.y))), Quaternion.identity);
				val.transform.parent = ((BraveBehaviour)actor).transform;
				val.GetComponent<tk2dBaseSprite>().HeightOffGround = 0.2f;
				((BraveBehaviour)actor).sprite.AttachRenderer(val.GetComponent<tk2dBaseSprite>());
			}
		}
		if (currencyToSpawnNextTick > 0)
		{
			LootEngine.SpawnCurrency(actor.CenterPosition, currencyToSpawnNextTick, false);
			currencyToSpawnNextTick = 0;
		}
		if (Object.op_Implicit((Object)(object)((BraveBehaviour)actor).aiAnimator))
		{
			((BraveBehaviour)actor).aiAnimator.FpsScale = ((!actor.IsFalling) ? 0.5f : 1f);
		}
		if (Object.op_Implicit((Object)(object)((BraveBehaviour)actor).aiShooter))
		{
			((BraveBehaviour)actor).aiShooter.AimTimeScale = 0.5f;
		}
		if (Object.op_Implicit((Object)(object)((BraveBehaviour)actor).behaviorSpeculator))
		{
			((BraveBehaviour)actor).behaviorSpeculator.CooldownScale = 0.5f;
		}
		if (Object.op_Implicit((Object)(object)((BraveBehaviour)actor).bulletBank))
		{
			((BraveBehaviour)actor).bulletBank.TimeScale = 0.5f;
		}
		((GameActorEffect)this).EffectTick(actor, effectData);
	}

	public override void OnEffectRemoved(GameActor actor, RuntimeGameActorEffectData effectData)
	{
		//IL_00b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00be: Expected O, but got Unknown
		if (Object.op_Implicit((Object)(object)((BraveBehaviour)actor).aiAnimator))
		{
			((BraveBehaviour)actor).aiAnimator.FpsScale = 1f;
		}
		if (Object.op_Implicit((Object)(object)((BraveBehaviour)actor).aiShooter))
		{
			((BraveBehaviour)actor).aiShooter.AimTimeScale = 1f;
		}
		if (Object.op_Implicit((Object)(object)((BraveBehaviour)actor).behaviorSpeculator))
		{
			((BraveBehaviour)actor).behaviorSpeculator.CooldownScale = 1f;
		}
		if (Object.op_Implicit((Object)(object)((BraveBehaviour)actor).bulletBank))
		{
			((BraveBehaviour)actor).bulletBank.TimeScale = 1f;
		}
		if (Object.op_Implicit((Object)(object)actor) && (Object)(object)((BraveBehaviour)actor).healthHaver != (Object)null)
		{
			((BraveBehaviour)actor).healthHaver.OnHealthChanged -= new OnHealthChangedEvent(Hurt);
		}
		((GameActorEffect)this).OnEffectRemoved(actor, effectData);
	}
}
