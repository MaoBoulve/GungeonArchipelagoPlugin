using System;
using UnityEngine;

namespace NevernamedsItems;

public class StoutBulletsProjectileBehaviour : MonoBehaviour
{
	public float RangeCap = 7f;

	public float MaxDamageIncrease = 1.75f;

	public float MinDamageIncrease = 1.125f;

	public float ScaleIncrease = 1.5f;

	public float DescaleAmount = 0.5f;

	public float DamageCutOnDescale = 2f;

	private Projectile m_projectile;

	public void Start()
	{
		try
		{
			m_projectile = ((Component)this).GetComponent<Projectile>();
			float num = Mathf.Max(0f, m_projectile.baseData.range - RangeCap);
			float num2 = Mathf.Lerp(MinDamageIncrease, MaxDamageIncrease, Mathf.Clamp01(num / 15f));
			m_projectile.OnPostUpdate += HandlePostUpdate;
			Projectile projectile = m_projectile;
			projectile.AdditionalScaleMultiplier *= ScaleIncrease;
			ProjectileData baseData = m_projectile.baseData;
			baseData.damage *= num2;
		}
		catch (Exception ex)
		{
			ETGModConsole.Log((object)ex.Message, false);
			ETGModConsole.Log((object)ex.StackTrace, false);
		}
	}

	private void HandlePostUpdate(Projectile proj)
	{
		if (Object.op_Implicit((Object)(object)proj) && proj.GetElapsedDistance() > RangeCap)
		{
			proj.RuntimeUpdateScale(DescaleAmount);
			ProjectileData baseData = proj.baseData;
			baseData.damage /= DamageCutOnDescale;
			proj.OnPostUpdate -= HandlePostUpdate;
		}
	}
}
