using System;
using Alexandria.EnemyAPI;
using Alexandria.Misc;
using UnityEngine;

namespace NevernamedsItems;

public class SpawnGunjurerBulletScriptOnSpawn : MonoBehaviour
{
	private Projectile m_projectile;

	private void Start()
	{
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected O, but got Unknown
		//IL_00eb: Unknown result type (might be due to invalid IL or missing references)
		m_projectile = ((Component)this).GetComponent<Projectile>();
		BulletScriptSource orAddComponent = GameObjectExtensions.GetOrAddComponent<BulletScriptSource>(((Component)m_projectile).gameObject);
		((Component)m_projectile).gameObject.AddComponent<BulletSourceKiller>();
		CustomBulletScriptSelector bulletScript = new CustomBulletScriptSelector(typeof(GunjurerSlamPlayerScript));
		AIBulletBank val = DataCloners.CopyAIBulletBank(((BraveBehaviour)EnemyDatabase.GetOrLoadByGuid("206405acad4d4c33aac6717d184dc8d4")).bulletBank);
		val.OnProjectileCreated = (Action<Projectile>)Delegate.Combine(val.OnProjectileCreated, new Action<Projectile>(OnBulletSpawned));
		foreach (Entry bullet in val.Bullets)
		{
			bullet.BulletObject.GetComponent<Projectile>().BulletScriptSettings.preventPooling = true;
		}
		orAddComponent.BulletManager = val;
		orAddComponent.BulletScript = (BulletScriptSelector)(object)bulletScript;
		orAddComponent.Initialize();
		GunjurerSlamPlayerScript gunjurerSlamPlayerScript = orAddComponent.RootBullet as GunjurerSlamPlayerScript;
		gunjurerSlamPlayerScript.aimDirection = Vector2Extensions.ToAngle(m_projectile.Direction);
	}

	private void OnBulletSpawned(Projectile projectile)
	{
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		if (!Object.op_Implicit((Object)(object)projectile))
		{
			return;
		}
		projectile.collidesWithPlayer = false;
		projectile.collidesWithEnemies = true;
		projectile.UpdateCollisionMask();
		if (Object.op_Implicit((Object)(object)m_projectile) && (Object)(object)m_projectile.Owner != (Object)null)
		{
			projectile.Owner = m_projectile.Owner;
			if ((Object)(object)ProjectileUtility.ProjectilePlayerOwner(m_projectile) != (Object)null)
			{
				PlayerController val = ProjectileUtility.ProjectilePlayerOwner(m_projectile);
				projectile.AdjustPlayerProjectileTint(ExtendedColours.honeyYellow, 1, 0f);
				projectile.baseData.damage = 3f;
				ProjectileData baseData = projectile.baseData;
				baseData.damage *= val.stats.GetStatValue((StatType)5);
				ProjectileData baseData2 = projectile.baseData;
				baseData2.speed *= val.stats.GetStatValue((StatType)6);
				ProjectileData baseData3 = projectile.baseData;
				baseData3.range *= val.stats.GetStatValue((StatType)26);
				projectile.BossDamageMultiplier *= val.stats.GetStatValue((StatType)22);
				projectile.RuntimeUpdateScale(val.stats.GetStatValue((StatType)15));
				projectile.UpdateSpeed();
				val.DoPostProcessProjectile(projectile);
			}
		}
	}
}
