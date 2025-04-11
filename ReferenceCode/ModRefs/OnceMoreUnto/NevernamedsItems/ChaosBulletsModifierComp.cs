using System;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class ChaosBulletsModifierComp : MonoBehaviour
{
	private Projectile m_projectile;

	public float effectScaler;

	public float chanceToAddPierce;

	public float chanceToAddBounce;

	public float chanceToAddFat;

	public float maxFatScale;

	public float minFatScale;

	public bool usesVelocityModificationCurve;

	public AnimationCurve VelocityModificationCurve;

	public float chanceOfActivatingStatusEffect;

	public float speedModifierWeight;

	public GameActorSpeedEffect speedModifierEffect;

	public Color speedModifierTintColour;

	public float poisonModifierWeight;

	public GameActorHealthEffect poisonModifierEffect;

	public Color poisonModifierTintColour;

	public float fireModifierWeight;

	public GameActorFireEffect fireModifierEffect;

	public Color fireModifierTintColour;

	public float charmModifierWeight;

	public GameActorCharmEffect charmModifierEffect;

	public Color charmModifierTintColour;

	public float freezeModifierWeight;

	public GameActorFreezeEffect freezeModifierEffect;

	public Color freezeModifierTintColour;

	public float transmogModifierWeight;

	public string transmogTargetGuid;

	public Color transmogModifierTintColour;

	public ChaosBulletsModifierComp()
	{
		//IL_009b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_012d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0132: Unknown result type (might be due to invalid IL or missing references)
		//IL_0176: Unknown result type (might be due to invalid IL or missing references)
		//IL_017b: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0208: Unknown result type (might be due to invalid IL or missing references)
		//IL_020d: Unknown result type (might be due to invalid IL or missing references)
		effectScaler = 1f;
		chanceToAddPierce = 0.1f;
		chanceToAddBounce = 0.1f;
		chanceToAddFat = 0.1f;
		minFatScale = 1.25f;
		maxFatScale = 1.75f;
		usesVelocityModificationCurve = true;
		VelocityModificationCurve = ((Component)Game.Items["chaos_bullets"]).GetComponent<ChaosBulletsItem>().VelocityModificationCurve;
		chanceOfActivatingStatusEffect = 0.1f;
		speedModifierWeight = 2f;
		speedModifierTintColour = ((Component)Game.Items["chaos_bullets"]).GetComponent<ChaosBulletsItem>().SpeedTintColor;
		speedModifierEffect = ((Component)Game.Items["chaos_bullets"]).GetComponent<ChaosBulletsItem>().SpeedModifierEffect;
		poisonModifierWeight = 2f;
		poisonModifierTintColour = ((Component)Game.Items["chaos_bullets"]).GetComponent<ChaosBulletsItem>().PoisonTintColor;
		poisonModifierEffect = ((Component)Game.Items["chaos_bullets"]).GetComponent<ChaosBulletsItem>().HealthModifierEffect;
		fireModifierWeight = 2f;
		fireModifierTintColour = ((Component)Game.Items["chaos_bullets"]).GetComponent<ChaosBulletsItem>().FireTintColor;
		fireModifierEffect = ((Component)Game.Items["chaos_bullets"]).GetComponent<ChaosBulletsItem>().FireModifierEffect;
		charmModifierWeight = 1f;
		charmModifierTintColour = ((Component)Game.Items["chaos_bullets"]).GetComponent<ChaosBulletsItem>().CharmTintColor;
		charmModifierEffect = ((Component)Game.Items["chaos_bullets"]).GetComponent<ChaosBulletsItem>().CharmModifierEffect;
		freezeModifierWeight = 1f;
		freezeModifierTintColour = ((Component)Game.Items["chaos_bullets"]).GetComponent<ChaosBulletsItem>().FreezeTintColor;
		freezeModifierEffect = ((Component)Game.Items["chaos_bullets"]).GetComponent<ChaosBulletsItem>().FreezeModifierEffect;
		transmogModifierWeight = 0.05f;
		transmogModifierTintColour = ((Component)Game.Items["chaos_bullets"]).GetComponent<ChaosBulletsItem>().TransmogrifyTintColor;
		transmogTargetGuid = "76bc43539fc24648bff4568c75c686d1";
	}

	public void Start()
	{
		try
		{
			m_projectile = ((Component)this).GetComponent<Projectile>();
			DoEffects(m_projectile);
		}
		catch (Exception ex)
		{
			ETGModConsole.Log((object)ex.Message, false);
			ETGModConsole.Log((object)ex.StackTrace, false);
		}
	}

	private void DoEffects(Projectile projectile)
	{
		//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0174: Unknown result type (might be due to invalid IL or missing references)
		//IL_0179: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0352: Unknown result type (might be due to invalid IL or missing references)
		//IL_0239: Unknown result type (might be due to invalid IL or missing references)
		//IL_023e: Unknown result type (might be due to invalid IL or missing references)
		//IL_027f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0284: Unknown result type (might be due to invalid IL or missing references)
		//IL_02cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_031d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0322: Unknown result type (might be due to invalid IL or missing references)
		if (usesVelocityModificationCurve)
		{
			ProjectileData baseData = projectile.baseData;
			baseData.speed *= VelocityModificationCurve.Evaluate(Random.value);
		}
		int num = 0;
		while (Random.value < chanceToAddBounce && num < 10)
		{
			num++;
			BounceProjModifier component = ((Component)projectile).GetComponent<BounceProjModifier>();
			if ((Object)(object)component == (Object)null)
			{
				component = ((Component)projectile).gameObject.AddComponent<BounceProjModifier>();
				component.numberOfBounces = 1;
			}
			else
			{
				BounceProjModifier obj = component;
				obj.numberOfBounces++;
			}
		}
		num = 0;
		while (Random.value < chanceToAddPierce && num < 10)
		{
			num++;
			PierceProjModifier component2 = ((Component)projectile).GetComponent<PierceProjModifier>();
			if ((Object)(object)component2 == (Object)null)
			{
				component2 = ((Component)projectile).gameObject.AddComponent<PierceProjModifier>();
				component2.penetration = 2;
				component2.penetratesBreakables = true;
				component2.BeastModeLevel = (BeastModeStatus)0;
			}
			else
			{
				PierceProjModifier obj2 = component2;
				obj2.penetration += 2;
			}
		}
		if (Random.value < chanceToAddFat)
		{
			projectile.AdditionalScaleMultiplier *= Random.Range(minFatScale, maxFatScale);
		}
		if (chanceOfActivatingStatusEffect < 1f)
		{
			chanceOfActivatingStatusEffect *= effectScaler;
		}
		if (Random.value < chanceOfActivatingStatusEffect)
		{
			Color white = Color.white;
			float num2 = speedModifierWeight + poisonModifierWeight + freezeModifierWeight + charmModifierWeight + fireModifierWeight + transmogModifierWeight;
			float num3 = num2 * Random.value;
			if (num3 < speedModifierWeight)
			{
				white = speedModifierTintColour;
				projectile.statusEffectsToApply.Add((GameActorEffect)(object)speedModifierEffect);
			}
			else if (num3 < speedModifierWeight + poisonModifierWeight)
			{
				white = poisonModifierTintColour;
				projectile.statusEffectsToApply.Add((GameActorEffect)(object)poisonModifierEffect);
			}
			else if (num3 < speedModifierWeight + poisonModifierWeight + freezeModifierWeight)
			{
				white = freezeModifierTintColour;
				projectile.statusEffectsToApply.Add((GameActorEffect)(object)freezeModifierEffect);
			}
			else if (num3 < speedModifierWeight + poisonModifierWeight + freezeModifierWeight + charmModifierWeight)
			{
				white = charmModifierTintColour;
				projectile.statusEffectsToApply.Add((GameActorEffect)(object)charmModifierEffect);
			}
			else if (num3 < speedModifierWeight + poisonModifierWeight + freezeModifierWeight + charmModifierWeight + fireModifierWeight)
			{
				white = fireModifierTintColour;
				projectile.statusEffectsToApply.Add((GameActorEffect)(object)fireModifierEffect);
			}
			else if (num3 < speedModifierWeight + poisonModifierWeight + freezeModifierWeight + charmModifierWeight + fireModifierWeight + transmogModifierWeight)
			{
				white = transmogModifierTintColour;
				projectile.CanTransmogrify = true;
				projectile.ChanceToTransmogrify = 1f;
				projectile.TransmogrifyTargetGuids = new string[1];
				projectile.TransmogrifyTargetGuids[0] = transmogTargetGuid;
			}
			projectile.AdjustPlayerProjectileTint(white, 6, 0f);
		}
	}
}
