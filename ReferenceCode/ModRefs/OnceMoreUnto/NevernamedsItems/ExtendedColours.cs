using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class ExtendedColours
{
	public static Color carrionRed = new Color(0.6901961f, 0.015686275f, 0.015686275f);

	public static Color pink = new Color(0.9490196f, 0.45490196f, 0.88235295f);

	public static Color paleYellow = new Color(0.9490196f, 14f / 15f, 0.5803922f);

	public static Color lime = new Color(37f / 85f, 84f / 85f, 1f / 85f);

	public static Color brown = new Color(0.47843137f, 0.2784314f, 0.0627451f);

	public static Color orange = new Color(0.9411765f, 32f / 51f, 0.08627451f);

	public static Color vibrantOrange = new Color(1f, 48f / 85f, 0.16078432f);

	public static Color purple = new Color(57f / 85f, 0.08627451f, 0.9411765f);

	public static Color skyblue = new Color(26f / 51f, 46f / 51f, 8.843137f);

	public static Color honeyYellow = new Color(1f, 0.7058824f, 6f / 85f);

	public static Color maroon = new Color(0.4117647f, 0.02745098f, 3f / 85f);

	public static Color veryDarkRed = new Color(0.2784314f, 0.015686275f, 1f / 85f);

	public static Color plaguePurple = new Color(0.9490196f, 0.6313726f, 1f);

	public static Color darkBrown = new Color(0.2901961f, 0.08627451f, 1f / 51f);

	public static Color reaverAqua = new Color(0.29411766f, 0.7490196f, 0.6509804f);

	public static Color freezeBlue = ((GameActorEffect)StaticStatusEffects.chaosBulletsFreeze).TintColor;

	public static Color poisonGreen = ((GameActorEffect)StaticStatusEffects.irradiatedLeadEffect).TintColor;

	public static Color charmPink = ((GameActorEffect)StaticStatusEffects.charmingRoundsEffect).TintColor;

	public static Color cursedBulletsPurple = ((Component)Game.Items["cursed_bullets"]).GetComponent<ScalingStatBoostItem>().TintColor;

	public static Color gildedBulletsGold = ((Component)Game.Items["gilded_bullets"]).GetComponent<ScalingStatBoostItem>().TintColor;

	public static Color silvedBulletsSilver = ((Component)Game.Items["silver_bullets"]).GetComponent<SilverBulletsPassiveItem>().TintColor;

	public static Color frostBulletsTint = ((Component)Game.Items["frost_bullets"]).GetComponent<BulletStatusEffectItem>().TintColor;

	public static Color shadowBulletsBlue = new Color(0.35f, 0.25f, 0.65f, 1f);
}
