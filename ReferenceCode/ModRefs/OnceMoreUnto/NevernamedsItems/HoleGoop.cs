using System.Collections.Generic;
using Alexandria.Misc;
using UnityEngine;

namespace NevernamedsItems;

public class HoleGoop : SpecialGoopBehaviourDoer
{
	public static void Init()
	{
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_009d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c3: Expected O, but got Unknown
		EasyGoopDefinitions.PitGoop = ScriptableObject.CreateInstance<GoopDefinition>();
		EasyGoopDefinitions.PitGoop.CanBeIgnited = false;
		EasyGoopDefinitions.PitGoop.damagesEnemies = false;
		EasyGoopDefinitions.PitGoop.damagesPlayers = false;
		EasyGoopDefinitions.PitGoop.baseColor32 = Color32.op_Implicit(Color.black);
		EasyGoopDefinitions.PitGoop.goopTexture = Initialisation.assetBundle.LoadAsset<Texture2D>("pitgooptex");
		EasyGoopDefinitions.PitGoop.usesLifespan = true;
		EasyGoopDefinitions.PitGoop.lifespan = 30f;
		EasyGoopDefinitions.PitGoop.overrideOpaqueness = 1f;
		((Object)EasyGoopDefinitions.PitGoop).name = "omitbpitgoop";
		EasyGoopDefinitions.PitGoop.goopDamageTypeInteractions = new List<GoopDamageTypeInteraction>
		{
			new GoopDamageTypeInteraction
			{
				freezesGoop = false,
				electrifiesGoop = false,
				ignitionMode = (GoopIgnitionMode)0,
				damageType = (CoreDamageTypes)0
			}
		};
		GoopUtility.RegisterComponentToGoopDefinition(EasyGoopDefinitions.PitGoop, typeof(HoleGoop));
	}

	public override void DoGoopEffectUpdate(DeadlyDeadlyGoopManager goop, GameActor actor, IntVector2 position)
	{
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		if (Object.op_Implicit((Object)(object)actor) && actor is AIActor && Object.op_Implicit((Object)(object)((BraveBehaviour)actor).aiAnimator) && !((BraveBehaviour)actor).aiAnimator.IsPlaying("spawn") && !((BraveBehaviour)actor).aiAnimator.IsPlaying("awaken") && Object.op_Implicit((Object)(object)((BraveBehaviour)actor).healthHaver) && !((BraveBehaviour)actor).healthHaver.IsBoss && ((BraveBehaviour)actor).aiActor.HasBeenEngaged)
		{
			actor.ForceFall();
		}
		((SpecialGoopBehaviourDoer)this).DoGoopEffectUpdate(goop, actor, position);
	}
}
