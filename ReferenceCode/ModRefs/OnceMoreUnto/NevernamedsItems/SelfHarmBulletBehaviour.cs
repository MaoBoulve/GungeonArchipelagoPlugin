using System;
using System.Reflection;
using Alexandria.ItemAPI;
using UnityEngine;

namespace NevernamedsItems;

public class SelfHarmBulletBehaviour : MonoBehaviour
{
	private Projectile m_projectile;

	private bool canDealDamage = true;

	private void Awake()
	{
		//IL_0096: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a0: Expected O, but got Unknown
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Expected O, but got Unknown
		try
		{
			m_projectile = ((Component)this).GetComponent<Projectile>();
			canDealDamage = false;
			((MonoBehaviour)this).Invoke("HandleCooldown", 1f);
			GameActor owner = m_projectile.Owner;
			PlayerController val = (PlayerController)(object)((owner is PlayerController) ? owner : null);
			m_projectile.allowSelfShooting = true;
			m_projectile.collidesWithEnemies = true;
			m_projectile.collidesWithPlayer = true;
			m_projectile.SetNewShooter(m_projectile.Shooter);
			m_projectile.UpdateCollisionMask();
			SpeculativeRigidbody specRigidbody = ((BraveBehaviour)m_projectile).specRigidbody;
			specRigidbody.OnPreRigidbodyCollision = (OnPreRigidbodyCollisionDelegate)Delegate.Combine((Delegate)(object)specRigidbody.OnPreRigidbodyCollision, (Delegate)new OnPreRigidbodyCollisionDelegate(OnHitSelf));
		}
		catch (Exception ex)
		{
			ETGModConsole.Log((object)ex.Message, false);
			ETGModConsole.Log((object)ex.StackTrace, false);
		}
	}

	private void OnHitSelf(SpeculativeRigidbody myRigidbody, PixelCollider myPixelCollider, SpeculativeRigidbody otherRigidbody, PixelCollider otherPixelCollider)
	{
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		//IL_0198: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			bool flag = false;
			float num = 0.5f;
			FieldInfo field = typeof(Projectile).GetField("m_hasPierced", BindingFlags.Instance | BindingFlags.NonPublic);
			field.SetValue(((BraveBehaviour)myRigidbody).projectile, false);
			GameActor owner = m_projectile.Owner;
			PlayerController val = (PlayerController)(object)((owner is PlayerController) ? owner : null);
			if (CustomSynergies.PlayerHasActiveSynergy(val, "Even Worse Choices"))
			{
				num = 1f;
			}
			if (CustomSynergies.PlayerHasActiveSynergy(val, "Discworld"))
			{
				PlayableCharacters characterIdentity = val.characterIdentity;
				if (val.ForceZeroHealthState)
				{
					if (((BraveBehaviour)val).healthHaver.Armor <= 1f)
					{
						flag = true;
					}
				}
				else if (((BraveBehaviour)val).healthHaver.Armor == 0f || ((BraveBehaviour)val).healthHaver.NextDamageIgnoresArmor)
				{
					if (((BraveBehaviour)val).healthHaver.GetCurrentHealth() == 0.5f)
					{
						flag = true;
					}
					else if (((BraveBehaviour)val).healthHaver.GetCurrentHealth() == 1f && CustomSynergies.PlayerHasActiveSynergy(val, "Even Worse Choices"))
					{
						flag = true;
					}
				}
				else if (((BraveBehaviour)val).healthHaver.NextShotKills)
				{
					flag = true;
				}
			}
			PlayerController component = ((Component)otherRigidbody).GetComponent<PlayerController>();
			if (Object.op_Implicit((Object)(object)component) && !component.IsGhost && Object.op_Implicit((Object)(object)m_projectile.PossibleSourceGun))
			{
				if (canDealDamage && !component.IsDodgeRolling && !flag)
				{
					((BraveBehaviour)component).healthHaver.ApplyDamage(num, Vector2.zero, "Disc Gun", (CoreDamageTypes)0, (DamageCategory)0, true, (PixelCollider)null, false);
					canDealDamage = false;
					((MonoBehaviour)this).Invoke("HandleCooldown", 1f);
				}
				PhysicsEngine.SkipCollision = true;
			}
		}
		catch (Exception ex)
		{
			ETGModConsole.Log((object)ex.Message, false);
			ETGModConsole.Log((object)ex.StackTrace, false);
		}
	}

	private void HandleCooldown()
	{
		canDealDamage = true;
	}

	private void Update()
	{
	}
}
