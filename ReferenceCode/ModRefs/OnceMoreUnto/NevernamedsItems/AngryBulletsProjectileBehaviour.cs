using System;
using Dungeonator;
using UnityEngine;

namespace NevernamedsItems;

public class AngryBulletsProjectileBehaviour : MonoBehaviour
{
	private Projectile m_projectile;

	public bool ApplyRandomBounceOffEnemy;

	public float ChanceToSeekEnemyOnBounce;

	public bool NormalizeAcrossFireRate;

	public float ActivationsPerSecond;

	public float MinActivationChance;

	public AngryBulletsProjectileBehaviour()
	{
		ApplyRandomBounceOffEnemy = true;
		ChanceToSeekEnemyOnBounce = 0.5f;
		ActivationsPerSecond = 1f;
		MinActivationChance = 0.05f;
	}

	public void Start()
	{
		try
		{
			m_projectile = ((Component)this).GetComponent<Projectile>();
			Projectile projectile = m_projectile;
			projectile.OnHitEnemy = (Action<Projectile, SpeculativeRigidbody, bool>)Delegate.Combine(projectile.OnHitEnemy, new Action<Projectile, SpeculativeRigidbody, bool>(HandleProjectileHitEnemy));
		}
		catch (Exception ex)
		{
			ETGModConsole.Log((object)ex.Message, false);
			ETGModConsole.Log((object)ex.StackTrace, false);
		}
	}

	private void HandleProjectileHitEnemy(Projectile obj, SpeculativeRigidbody enemy, bool killed)
	{
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_019e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0153: Unknown result type (might be due to invalid IL or missing references)
		//IL_0180: Unknown result type (might be due to invalid IL or missing references)
		//IL_018b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0190: Unknown result type (might be due to invalid IL or missing references)
		//IL_0195: Unknown result type (might be due to invalid IL or missing references)
		//IL_019a: Unknown result type (might be due to invalid IL or missing references)
		if (!ApplyRandomBounceOffEnemy)
		{
			return;
		}
		PierceProjModifier orAddComponent = GameObjectExtensions.GetOrAddComponent<PierceProjModifier>(((Component)obj).gameObject);
		orAddComponent.penetratesBreakables = true;
		orAddComponent.penetration++;
		HomingModifier component = ((Component)obj).gameObject.GetComponent<HomingModifier>();
		if (Object.op_Implicit((Object)(object)component))
		{
			component.AngularVelocity *= 0.75f;
		}
		Vector2 val = Random.insideUnitCircle;
		float num = ChanceToSeekEnemyOnBounce;
		Gun possibleSourceGun = obj.PossibleSourceGun;
		if (NormalizeAcrossFireRate && Object.op_Implicit((Object)(object)possibleSourceGun))
		{
			float num2 = 1f / possibleSourceGun.DefaultModule.cooldownTime;
			if ((Object)(object)possibleSourceGun.Volley != (Object)null && possibleSourceGun.Volley.UsesShotgunStyleVelocityRandomizer)
			{
				num2 *= (float)Mathf.Max(1, possibleSourceGun.Volley.projectiles.Count);
			}
			num = Mathf.Clamp01(ActivationsPerSecond / num2);
			num = Mathf.Max(MinActivationChance, num);
		}
		if (Random.value < num && Object.op_Implicit((Object)(object)((BraveBehaviour)enemy).aiActor))
		{
			Func<AIActor, bool> func = (AIActor a) => Object.op_Implicit((Object)(object)a) && a.HasBeenEngaged && Object.op_Implicit((Object)(object)((BraveBehaviour)a).healthHaver) && ((BraveBehaviour)a).healthHaver.IsVulnerable;
			AIActor closestToPosition = BraveUtility.GetClosestToPosition<AIActor>(((BraveBehaviour)enemy).aiActor.ParentRoom.GetActiveEnemies((ActiveEnemyType)0), enemy.UnitCenter, func, (AIActor[])(object)new AIActor[1] { ((BraveBehaviour)enemy).aiActor });
			if (Object.op_Implicit((Object)(object)closestToPosition))
			{
				val = ((GameActor)closestToPosition).CenterPosition - Vector3Extensions.XY(((BraveBehaviour)obj).transform.position);
			}
		}
		obj.SendInDirection(val, false, true);
	}
}
