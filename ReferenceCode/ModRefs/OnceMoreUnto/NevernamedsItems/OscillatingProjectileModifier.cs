using UnityEngine;

namespace NevernamedsItems;

internal class OscillatingProjectileModifier : BraveBehaviour
{
	public float oscillationTime = 0.5f;

	public bool multiplyScale = false;

	public float minScaleMult = 1f;

	public float maxScaleMult = 3f;

	public bool multiplyDamage = false;

	public float minDamageMult = 1f;

	public float maxDamageMult = 2f;

	public bool multiplySpeed = false;

	public float minSpeedMult = 1f;

	public float maxSpeedMult = 0.2f;

	public bool multiplyRange = false;

	public float minRangeMult = 0.8f;

	public float maxRangeMult = 1.2f;

	private float lastMult = 1f;

	private float damageMult = 1f;

	private float latspeed = 1f;

	private float lastRange = 1f;

	private float elapsedTime = 0f;

	private void Update()
	{
		float num = Mathf.PingPong(elapsedTime, oscillationTime);
		float num2 = Mathf.SmoothStep(minScaleMult, maxScaleMult, num);
		float num3 = Mathf.SmoothStep(minDamageMult, maxDamageMult, num);
		float num4 = Mathf.SmoothStep(minSpeedMult, maxSpeedMult, num);
		float num5 = Mathf.SmoothStep(minRangeMult, maxRangeMult, num);
		elapsedTime += BraveTime.DeltaTime;
		if (multiplyScale)
		{
			((BraveBehaviour)this).projectile.RuntimeUpdateScale(num2 / lastMult);
		}
		if (multiplyDamage)
		{
			ProjectileData baseData = ((BraveBehaviour)this).projectile.baseData;
			baseData.damage *= num3 / damageMult;
		}
		if (multiplySpeed)
		{
			ProjectileData baseData2 = ((BraveBehaviour)this).projectile.baseData;
			baseData2.speed *= num4 / latspeed;
			((BraveBehaviour)this).projectile.UpdateSpeed();
		}
		if (multiplyRange)
		{
			ProjectileData baseData3 = ((BraveBehaviour)this).projectile.baseData;
			baseData3.range *= num5 / lastRange;
		}
		lastMult = num2;
		damageMult = num3;
		latspeed = num4;
		lastRange = num5;
	}
}
