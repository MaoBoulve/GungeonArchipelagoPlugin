using System;
using Alexandria.EnemyAPI;
using Alexandria.Misc;
using UnityEngine;

namespace NevernamedsItems;

public class AdvancedMirrorProjectileModifier : MonoBehaviour
{
	public bool tintsBullets;

	public Color tintColour;

	public bool projectileSurvives;

	public bool postProcessReflectedBullets;

	public bool allowSurvivalIfPiercing;

	public float baseReflectedDMG;

	public float baseRelfectedSpeed;

	public float baseReflectedSpread;

	public float baseReflectedScaleMod;

	public bool retarget;

	public string sfx;

	public int maxMirrors;

	public bool RapidRiposteWeebshitSynergy;

	private int TimesMirrored = 0;

	private Projectile m_projectile;

	public AdvancedMirrorProjectileModifier()
	{
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		tintsBullets = false;
		tintColour = Color.white;
		projectileSurvives = false;
		postProcessReflectedBullets = false;
		allowSurvivalIfPiercing = true;
		baseReflectedDMG = 15f;
		baseRelfectedSpeed = 10f;
		baseReflectedSpread = 0f;
		baseReflectedScaleMod = 1f;
		retarget = true;
		sfx = null;
		maxMirrors = -1;
		TimesMirrored = 0;
		RapidRiposteWeebshitSynergy = false;
	}

	private void Start()
	{
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Expected O, but got Unknown
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Expected O, but got Unknown
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		m_projectile = ((Component)this).GetComponent<Projectile>();
		if (tintsBullets)
		{
			m_projectile.AdjustPlayerProjectileTint(tintColour, 2, 0f);
		}
		m_projectile.collidesWithProjectiles = true;
		m_projectile.UpdateCollisionMask();
		SpeculativeRigidbody specRigidbody = ((BraveBehaviour)m_projectile).specRigidbody;
		specRigidbody.OnPreRigidbodyCollision = (OnPreRigidbodyCollisionDelegate)Delegate.Combine((Delegate)(object)specRigidbody.OnPreRigidbodyCollision, (Delegate)new OnPreRigidbodyCollisionDelegate(HandlePreCollision));
	}

	private void HandlePreCollision(SpeculativeRigidbody myRigidbody, PixelCollider myPixelCollider, SpeculativeRigidbody otherRigidbody, PixelCollider otherPixelCollider)
	{
		if (!Object.op_Implicit((Object)(object)otherRigidbody) || !Object.op_Implicit((Object)(object)((BraveBehaviour)otherRigidbody).projectile))
		{
			return;
		}
		if ((TimesMirrored < maxMirrors || maxMirrors == -1) && ((BraveBehaviour)otherRigidbody).projectile.Owner is AIActor)
		{
			if (!projectileSurvives)
			{
				if (allowSurvivalIfPiercing)
				{
					PierceProjModifier component = ((Component)((BraveBehaviour)myRigidbody).projectile).GetComponent<PierceProjModifier>();
					if ((Object)(object)component != (Object)null)
					{
						if (component.penetration > 0)
						{
							component.penetration--;
						}
						else
						{
							((BraveBehaviour)myRigidbody).projectile.DieInAir(false, true, true, false);
						}
					}
					else
					{
						((BraveBehaviour)myRigidbody).projectile.DieInAir(false, true, true, false);
					}
				}
				else
				{
					((BraveBehaviour)myRigidbody).projectile.DieInAir(false, true, true, false);
				}
			}
			TimesMirrored++;
			ProjectileUtility.ReflectBullet(((BraveBehaviour)otherRigidbody).projectile, retarget, ((BraveBehaviour)myRigidbody).projectile.Owner, baseRelfectedSpeed, postProcessReflectedBullets, baseReflectedScaleMod, baseReflectedDMG, baseReflectedSpread, sfx);
			if (RapidRiposteWeebshitSynergy)
			{
				Projectile projectile = ((BraveBehaviour)otherRigidbody).projectile;
				projectile.OnHitEnemy = (Action<Projectile, SpeculativeRigidbody, bool>)Delegate.Combine(projectile.OnHitEnemy, new Action<Projectile, SpeculativeRigidbody, bool>(HandleGunie));
			}
		}
		PhysicsEngine.SkipCollision = true;
	}

	private void HandleGunie(Projectile proj, SpeculativeRigidbody enemy, bool fatal)
	{
		if (!fatal && Object.op_Implicit((Object)(object)enemy) && Object.op_Implicit((Object)(object)((BraveBehaviour)enemy).aiActor) && Object.op_Implicit((Object)(object)m_projectile.Owner) && m_projectile.Owner is PlayerController && Random.value <= 0.5f)
		{
			AIActor aiActor = ((BraveBehaviour)enemy).aiActor;
			GameActor owner = m_projectile.Owner;
			AIActorUtility.DoGeniePunch(aiActor, (PlayerController)(object)((owner is PlayerController) ? owner : null));
		}
	}
}
