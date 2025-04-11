using UnityEngine;

namespace NevernamedsItems;

public class GameActorPlagueEffect : GameActorHealthEffect
{
	public GameActorPlagueEffect()
	{
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		base.DamagePerSecondToEnemies = 1f;
		((GameActorEffect)this).TintColor = ExtendedColours.plaguePurple;
		((GameActorEffect)this).DeathTintColor = ExtendedColours.plaguePurple;
		((GameActorEffect)this).AppliesTint = true;
		((GameActorEffect)this).AppliesDeathTint = true;
	}

	public override void EffectTick(GameActor actor, RuntimeGameActorEffectData effectData)
	{
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		if ((Object)(object)EasyGoopDefinitions.PlagueGoop != (Object)null)
		{
			DeadlyDeadlyGoopManager goopManagerForGoopType = DeadlyDeadlyGoopManager.GetGoopManagerForGoopType(EasyGoopDefinitions.PlagueGoop);
			goopManagerForGoopType.TimedAddGoopCircle(((BraveBehaviour)actor).specRigidbody.UnitCenter, 1.5f, 0.75f, true);
		}
		((GameActorHealthEffect)this).EffectTick(actor, effectData);
	}
}
