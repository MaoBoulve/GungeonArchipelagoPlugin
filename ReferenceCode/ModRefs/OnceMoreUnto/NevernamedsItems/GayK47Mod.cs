using UnityEngine;

namespace NevernamedsItems;

public class GayK47Mod : MonoBehaviour
{
	private Projectile self;

	private void Start()
	{
		//IL_0071: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0107: Unknown result type (might be due to invalid IL or missing references)
		//IL_0139: Unknown result type (might be due to invalid IL or missing references)
		//IL_0168: Unknown result type (might be due to invalid IL or missing references)
		//IL_0197: Unknown result type (might be due to invalid IL or missing references)
		self = ((Component)this).GetComponent<Projectile>();
		if (Object.op_Implicit((Object)(object)self))
		{
			switch (Random.Range(1, 8))
			{
			case 1:
				self.statusEffectsToApply.Add((GameActorEffect)(object)StaticStatusEffects.hotLeadEffect);
				self.AdjustPlayerProjectileTint(Color.red, 1, 0f);
				break;
			case 2:
				self.statusEffectsToApply.Add((GameActorEffect)(object)StaticStatusEffects.tripleCrossbowSlowEffect);
				self.AdjustPlayerProjectileTint(Color.yellow, 1, 0f);
				break;
			case 3:
				self.statusEffectsToApply.Add((GameActorEffect)(object)StaticStatusEffects.irradiatedLeadEffect);
				self.AdjustPlayerProjectileTint(ExtendedColours.poisonGreen, 1, 0f);
				break;
			case 4:
				self.statusEffectsToApply.Add((GameActorEffect)(object)StaticStatusEffects.frostBulletsEffect);
				self.AdjustPlayerProjectileTint(ExtendedColours.freezeBlue, 1, 0f);
				break;
			case 5:
				self.statusEffectsToApply.Add((GameActorEffect)(object)StaticStatusEffects.charmingRoundsEffect);
				self.AdjustPlayerProjectileTint(ExtendedColours.charmPink, 1, 0f);
				break;
			case 6:
				self.statusEffectsToApply.Add((GameActorEffect)(object)StaticStatusEffects.StandardPlagueEffect);
				self.AdjustPlayerProjectileTint(ExtendedColours.plaguePurple, 1, 0f);
				break;
			case 7:
				self.statusEffectsToApply.Add((GameActorEffect)(object)StaticStatusEffects.elimentalerCheeseEffect);
				self.AdjustPlayerProjectileTint(ExtendedColours.vibrantOrange, 1, 0f);
				break;
			}
		}
	}
}
