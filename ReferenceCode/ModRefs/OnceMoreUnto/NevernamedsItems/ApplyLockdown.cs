using UnityEngine;

namespace NevernamedsItems;

public class ApplyLockdown
{
	public static void ApplyDirectLockdown(GameActor target, float duration, Color tintColour, Color deathTintColour, EffectResistanceType resistanceType, string identifier, bool tintsEnemy, bool tintsCorpse)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Expected O, but got Unknown
		GameActorSpeedEffect val = new GameActorSpeedEffect
		{
			duration = duration,
			TintColor = tintColour,
			DeathTintColor = deathTintColour,
			effectIdentifier = identifier,
			AppliesTint = tintsEnemy,
			AppliesDeathTint = tintsCorpse,
			resistanceType = resistanceType,
			SpeedMultiplier = 0f,
			OverheadVFX = SharedVFX.LockdownOverhead,
			AffectsEnemies = true,
			AffectsPlayers = false,
			AppliesOutlineTint = false,
			OutlineTintColor = tintColour,
			PlaysVFXOnActor = false
		};
		if (Object.op_Implicit((Object)(object)target) && Object.op_Implicit((Object)(object)((BraveBehaviour)target).aiActor) && Object.op_Implicit((Object)(object)((BraveBehaviour)target).healthHaver) && ((BraveBehaviour)target).healthHaver.IsAlive)
		{
			target.ApplyEffect((GameActorEffect)(object)val, 1f, (Projectile)null);
		}
	}
}
