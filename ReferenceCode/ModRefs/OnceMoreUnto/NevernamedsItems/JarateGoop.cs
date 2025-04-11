using System.Collections.Generic;
using Alexandria.Misc;
using UnityEngine;

namespace NevernamedsItems;

public class JarateGoop : SpecialGoopBehaviourDoer
{
	public static void Init()
	{
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0089: Unknown result type (might be due to invalid IL or missing references)
		//IL_008e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		//IL_009c: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Expected O, but got Unknown
		EasyGoopDefinitions.JarateGoop = ScriptableObject.CreateInstance<GoopDefinition>();
		EasyGoopDefinitions.JarateGoop.CanBeIgnited = false;
		EasyGoopDefinitions.JarateGoop.damagesEnemies = false;
		EasyGoopDefinitions.JarateGoop.damagesPlayers = false;
		EasyGoopDefinitions.JarateGoop.baseColor32 = Color32.op_Implicit(Color.yellow);
		EasyGoopDefinitions.JarateGoop.goopTexture = GoopUtility.PoisonDef.goopTexture;
		EasyGoopDefinitions.JarateGoop.usesLifespan = true;
		EasyGoopDefinitions.JarateGoop.lifespan = 20f;
		((Object)EasyGoopDefinitions.JarateGoop).name = "omitbjarategoop";
		EasyGoopDefinitions.JarateGoop.goopDamageTypeInteractions = new List<GoopDamageTypeInteraction>
		{
			new GoopDamageTypeInteraction
			{
				freezesGoop = false,
				electrifiesGoop = false,
				ignitionMode = (GoopIgnitionMode)0,
				damageType = (CoreDamageTypes)0
			}
		};
		GoopUtility.RegisterComponentToGoopDefinition(EasyGoopDefinitions.JarateGoop, typeof(JarateGoop));
	}

	public override void DoGoopEffectUpdate(DeadlyDeadlyGoopManager goop, GameActor actor, IntVector2 position)
	{
		//IL_0088: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		if (Object.op_Implicit((Object)(object)actor) && Object.op_Implicit((Object)(object)((BraveBehaviour)actor).aiActor) && ((BraveBehaviour)actor).aiActor.HasBeenEngaged && Object.op_Implicit((Object)(object)((BraveBehaviour)actor).healthHaver))
		{
			actor.ApplyEffect((GameActorEffect)(object)new GameActorJarateEffect
			{
				duration = 10f,
				stackMode = (EffectStackingMode)0,
				HealthMultiplier = (((BraveBehaviour)actor).healthHaver.IsBoss ? 0.75f : 0.66f),
				SpeedMultiplier = 0.9f
			}, 1f, (Projectile)null);
		}
		((SpecialGoopBehaviourDoer)this).DoGoopEffectUpdate(goop, actor, position);
	}
}
