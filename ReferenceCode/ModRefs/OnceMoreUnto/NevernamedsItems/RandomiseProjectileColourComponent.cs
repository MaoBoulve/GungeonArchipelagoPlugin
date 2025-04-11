using System;
using System.Collections.Generic;
using Alexandria.ItemAPI;
using Alexandria.Misc;
using UnityEngine;

namespace NevernamedsItems;

public class RandomiseProjectileColourComponent : MonoBehaviour
{
	public static List<Color> ListOfColours;

	public bool ApplyColourToHitEnemies;

	public int tintPriority;

	public bool paintballGun;

	private Projectile m_projectile;

	private Color selectedColour;

	public RandomiseProjectileColourComponent()
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		ListOfColours = new List<Color>
		{
			ExtendedColours.pink,
			Color.red,
			ExtendedColours.orange,
			Color.yellow,
			Color.green,
			Color.blue,
			ExtendedColours.purple,
			Color.cyan
		};
		ApplyColourToHitEnemies = false;
		tintPriority = 1;
		paintballGun = false;
	}

	private void Start()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		m_projectile = ((Component)this).GetComponent<Projectile>();
		selectedColour = BraveUtility.RandomElement<Color>(ListOfColours);
		if (paintballGun && Object.op_Implicit((Object)(object)ProjectileUtility.ProjectilePlayerOwner(m_projectile)) && CustomSynergies.PlayerHasActiveSynergy(ProjectileUtility.ProjectilePlayerOwner(m_projectile), "Paint It Black"))
		{
			selectedColour = Color.black;
		}
		m_projectile.AdjustPlayerProjectileTint(selectedColour, tintPriority, 0f);
		if (ApplyColourToHitEnemies)
		{
			Projectile projectile = m_projectile;
			projectile.OnHitEnemy = (Action<Projectile, SpeculativeRigidbody, bool>)Delegate.Combine(projectile.OnHitEnemy, new Action<Projectile, SpeculativeRigidbody, bool>(OnHitEnemy));
		}
	}

	private void OnHitEnemy(Projectile bullet, SpeculativeRigidbody enemy, bool what)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Expected O, but got Unknown
		GameActorHealthEffect val = new GameActorHealthEffect
		{
			TintColor = selectedColour,
			DeathTintColor = selectedColour,
			AppliesTint = true,
			AppliesDeathTint = true,
			AffectsEnemies = true,
			DamagePerSecondToEnemies = 0f,
			duration = 10000000f,
			effectIdentifier = "ProjectileAppliedTint"
		};
		((GameActor)((BraveBehaviour)enemy).aiActor).ApplyEffect((GameActorEffect)(object)val, 1f, (Projectile)null);
	}

	private void Update()
	{
	}
}
