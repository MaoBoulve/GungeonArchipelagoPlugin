using Alexandria.Misc;
using UnityEngine;

namespace NevernamedsItems;

public class TackShooterBehaviour : MonoBehaviour
{
	public float timeExisted;

	public float timeTillNextShot;

	public bool isActive;

	private AIAnimator bodyAnimator;

	public PlayerController owner;

	public float cooldown;

	public string soundEvent;

	public Projectile ProjectileToShoot;

	public int amountToFire;

	public TackShooterBehaviour()
	{
		timeExisted = 0f;
		isActive = false;
		amountToFire = 8;
		cooldown = 0.8f;
		soundEvent = "Play_WPN_nailgun_shot_01";
	}

	private void Shoot()
	{
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0073: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Unknown result type (might be due to invalid IL or missing references)
		if (!isActive)
		{
			return;
		}
		bodyAnimator.PlayUntilFinished("shoot", false, (string)null, -1f, false);
		if (!string.IsNullOrEmpty(soundEvent))
		{
			AkSoundEngine.PostEvent(soundEvent, ((Component)this).gameObject);
		}
		int num = 0;
		for (int i = 0; i < amountToFire; i++)
		{
			GameObject val = SpawnManager.SpawnProjectile(((Component)ProjectileToShoot).gameObject, Vector2.op_Implicit(((Component)this).gameObject.GetComponent<tk2dBaseSprite>().WorldCenter), Quaternion.Euler(0f, 0f, (float)num), true);
			Projectile component = val.GetComponent<Projectile>();
			if (Object.op_Implicit((Object)(object)component))
			{
				component.Owner = (GameActor)(object)owner;
				component.Shooter = ((BraveBehaviour)owner).specRigidbody;
				component.TreatedAsNonProjectileForChallenge = true;
				ProjectileData baseData = component.baseData;
				baseData.damage *= owner.stats.GetStatValue((StatType)5);
				ProjectileData baseData2 = component.baseData;
				baseData2.speed *= owner.stats.GetStatValue((StatType)6);
				ProjectileData baseData3 = component.baseData;
				baseData3.force *= owner.stats.GetStatValue((StatType)12);
				ProjectileData baseData4 = component.baseData;
				baseData4.range *= owner.stats.GetStatValue((StatType)26);
				component.BossDamageMultiplier *= owner.stats.GetStatValue((StatType)22);
				component.AdditionalScaleMultiplier *= owner.stats.GetStatValue((StatType)15);
				component.UpdateSpeed();
				ProjectileUtility.ApplyCompanionModifierToBullet(component, owner);
			}
			num += 360 / amountToFire;
		}
	}

	public void RemoveTackShooter()
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		isActive = false;
		LootEngine.DoDefaultItemPoof(((Component)this).GetComponent<tk2dBaseSprite>().WorldCenter, false, false);
		Object.Destroy((Object)(object)((Component)this).gameObject);
	}

	private void Start()
	{
		bodyAnimator = ((Component)this).GetComponent<AIAnimator>();
		timeTillNextShot = cooldown;
		isActive = true;
		bodyAnimator.PlayUntilFinished("appear", false, (string)null, -1f, false);
	}

	private void Update()
	{
		if (isActive)
		{
			timeExisted += BraveTime.DeltaTime;
		}
		if (timeExisted > 5f && Object.op_Implicit((Object)(object)owner) && !owner.IsInCombat)
		{
			RemoveTackShooter();
		}
		if (timeTillNextShot > 0f)
		{
			timeTillNextShot -= BraveTime.DeltaTime;
		}
		else if (timeTillNextShot <= 0f)
		{
			Shoot();
			timeTillNextShot = cooldown;
		}
	}
}
