using System;
using System.Collections.Generic;
using UnityEngine;

namespace NevernamedsItems;

public class TickDamageBehaviour : MonoBehaviour
{
	private PlayerController owner;

	public List<HealthHaver> FirstStrikeEnemies = new List<HealthHaver>();

	private Projectile m_projectile;

	private tk2dBaseSprite m_sprite;

	public float EffectRadius = 1f;

	private float godHelpUsTick;

	public string damageSource;

	public float starterDamage;

	public TickDamageBehaviour()
	{
		damageSource = "Tick Damage";
		starterDamage = 2f;
		godHelpUsTick = 0.016f;
	}

	public void Start()
	{
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_0070: Expected O, but got Unknown
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Expected O, but got Unknown
		try
		{
			m_projectile = ((Component)this).GetComponent<Projectile>();
			m_sprite = ((BraveBehaviour)m_projectile).sprite;
			if (m_projectile.Owner is PlayerController)
			{
				ref PlayerController reference = ref owner;
				GameActor obj = m_projectile.Owner;
				reference = (PlayerController)(object)((obj is PlayerController) ? obj : null);
			}
			SpeculativeRigidbody specRigidbody = ((BraveBehaviour)m_projectile).specRigidbody;
			specRigidbody.OnPreRigidbodyCollision = (OnPreRigidbodyCollisionDelegate)Delegate.Combine((Delegate)(object)specRigidbody.OnPreRigidbodyCollision, (Delegate)new OnPreRigidbodyCollisionDelegate(HandlePreCollision));
			Projectile projectile = m_projectile;
			projectile.OnHitEnemy = (Action<Projectile, SpeculativeRigidbody, bool>)Delegate.Combine(projectile.OnHitEnemy, new Action<Projectile, SpeculativeRigidbody, bool>(OnHitEnemy));
		}
		catch (Exception ex)
		{
			ETGModConsole.Log((object)ex.Message, false);
			ETGModConsole.Log((object)ex.StackTrace, false);
		}
	}

	private void OnHitEnemy(Projectile bullet, SpeculativeRigidbody enemy, bool fatal)
	{
		if (Object.op_Implicit((Object)(object)((BraveBehaviour)enemy).healthHaver) && !FirstStrikeEnemies.Contains(((BraveBehaviour)enemy).healthHaver))
		{
			FirstStrikeEnemies.Add(((BraveBehaviour)enemy).healthHaver);
		}
	}

	private void Update()
	{
		if (godHelpUsTick >= 0f)
		{
			godHelpUsTick -= BraveTime.DeltaTime;
		}
	}

	private void HandlePreCollision(SpeculativeRigidbody myRigidbody, PixelCollider myPixelCollider, SpeculativeRigidbody otherRigidbody, PixelCollider otherPixelCollider)
	{
		//IL_00de: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			if (!((Object)(object)((BraveBehaviour)otherRigidbody).healthHaver != (Object)null) || !FirstStrikeEnemies.Contains(((BraveBehaviour)otherRigidbody).healthHaver))
			{
				return;
			}
			PlayerController component = ((Component)otherRigidbody).gameObject.GetComponent<PlayerController>();
			if (!((Object)(object)component == (Object)null))
			{
				return;
			}
			if (godHelpUsTick <= 0f)
			{
				float num = starterDamage;
				num *= owner.stats.GetStatValue((StatType)5);
				if (((BraveBehaviour)otherRigidbody).healthHaver.IsBoss)
				{
					num *= owner.stats.GetStatValue((StatType)22);
				}
				if (Object.op_Implicit((Object)(object)((BraveBehaviour)otherRigidbody).aiActor) && ((BraveBehaviour)otherRigidbody).aiActor.IsBlackPhantom)
				{
					num *= m_projectile.BlackPhantomDamageMultiplier;
				}
				((BraveBehaviour)otherRigidbody).healthHaver.ApplyDamage(num, Vector2.zero, damageSource, (CoreDamageTypes)0, (DamageCategory)5, true, (PixelCollider)null, true);
				godHelpUsTick = 0.016f;
			}
			PhysicsEngine.SkipCollision = true;
		}
		catch (Exception ex)
		{
			ETGModConsole.Log((object)ex.Message, false);
			ETGModConsole.Log((object)ex.StackTrace, false);
		}
	}
}
