namespace NevernamedsItems;

internal class PlagueStatusEffectSetup
{
	public static void Init()
	{
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		StaticStatusEffects.StandardPlagueEffect = StatusEffectHelper.GeneratePlagueEffect(100f, 2f, tintEnemy: true, ExtendedColours.plaguePurple, tintCorpse: true, ExtendedColours.plaguePurple);
	}
}
