using System;
using UnityEngine;

namespace NevernamedsItems;

public class CompanionisedEnemyBulletModifiers : BraveBehaviour
{
	private AIActor enemy;

	public PlayerController enemyOwner;

	public bool scaleDamage;

	public bool scaleSize;

	public bool scaleSpeed;

	public bool doPostProcess;

	public float baseBulletDamage;

	public float jammedDamageMultiplier;

	public bool TintBullets;

	public Color TintColor;

	public CompanionisedEnemyBulletModifiers()
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		scaleDamage = false;
		scaleSize = false;
		scaleSpeed = false;
		doPostProcess = false;
		baseBulletDamage = 10f;
		TintBullets = false;
		TintColor = Color.grey;
		jammedDamageMultiplier = 2f;
	}

	public void Start()
	{
		enemy = ((BraveBehaviour)this).aiActor;
		if (!Object.op_Implicit((Object)(object)enemy) || !Object.op_Implicit((Object)(object)((BraveBehaviour)enemy).bulletBank))
		{
			return;
		}
		AIBulletBank bulletBank = ((BraveBehaviour)enemy).bulletBank;
		foreach (Entry bullet in bulletBank.Bullets)
		{
			bullet.BulletObject.GetComponent<Projectile>().BulletScriptSettings.preventPooling = true;
		}
		if ((Object)(object)((BraveBehaviour)enemy).aiShooter != (Object)null)
		{
			AIShooter aiShooter = ((BraveBehaviour)enemy).aiShooter;
			aiShooter.PostProcessProjectile = (Action<Projectile>)Delegate.Combine(aiShooter.PostProcessProjectile, new Action<Projectile>(PostProcessSpawnedEnemyProjectiles));
		}
		if ((Object)(object)((BraveBehaviour)enemy).bulletBank != (Object)null)
		{
			AIBulletBank bulletBank2 = ((BraveBehaviour)enemy).bulletBank;
			bulletBank2.OnProjectileCreated = (Action<Projectile>)Delegate.Combine(bulletBank2.OnProjectileCreated, new Action<Projectile>(PostProcessSpawnedEnemyProjectiles));
		}
	}

	private void PostProcessSpawnedEnemyProjectiles(Projectile proj)
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		if (TintBullets)
		{
			proj.AdjustPlayerProjectileTint(TintColor, 1, 0f);
		}
		if ((Object)(object)enemy != (Object)null)
		{
			if (!((Object)(object)((BraveBehaviour)enemy).aiActor != (Object)null))
			{
				return;
			}
			proj.baseData.damage = baseBulletDamage;
			if ((Object)(object)enemyOwner != (Object)null)
			{
				if (scaleDamage)
				{
					ProjectileData baseData = proj.baseData;
					baseData.damage *= enemyOwner.stats.GetStatValue((StatType)5);
				}
				if (scaleSize)
				{
					proj.RuntimeUpdateScale(enemyOwner.stats.GetStatValue((StatType)15));
				}
				if (scaleSpeed)
				{
					ProjectileData baseData2 = proj.baseData;
					baseData2.speed *= enemyOwner.stats.GetStatValue((StatType)6);
					proj.UpdateSpeed();
				}
				if (doPostProcess)
				{
					enemyOwner.DoPostProcessProjectile(proj);
				}
			}
			if (((BraveBehaviour)enemy).aiActor.IsBlackPhantom)
			{
				proj.baseData.damage = baseBulletDamage * jammedDamageMultiplier;
			}
		}
		else
		{
			ETGModConsole.Log((object)"Shooter is NULL", false);
		}
	}
}
