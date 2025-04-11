using Alexandria.Misc;
using UnityEngine;

namespace NevernamedsItems;

public class DriftModifier : MonoBehaviour
{
	private Projectile m_projectile;

	public float DriftTimer;

	private float timer;

	public int maxDriftReaims;

	public bool diesAfterMaxDrifts;

	private int timesReAimed;

	public bool startInactive;

	private bool active;

	public float degreesOfVariance = -1f;

	public DriftModifier()
	{
		DriftTimer = 1f;
		maxDriftReaims = 100;
		diesAfterMaxDrifts = false;
		startInactive = false;
	}

	private void Start()
	{
		m_projectile = ((Component)this).GetComponent<Projectile>();
		timer = DriftTimer;
		active = !startInactive;
	}

	public void Activate()
	{
		active = true;
	}

	private void Update()
	{
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_008b: Unknown result type (might be due to invalid IL or missing references)
		if (!active)
		{
			return;
		}
		if (timer > 0f)
		{
			timer -= BraveTime.DeltaTime;
			return;
		}
		if (timesReAimed < maxDriftReaims)
		{
			if (degreesOfVariance != -1f)
			{
				m_projectile.SendInDirection(MathsAndLogicHelper.DegreeToVector2(Vector2Extensions.ToAngle(m_projectile.Direction) + Random.Range(0f - degreesOfVariance, degreesOfVariance)), false, false);
			}
			else
			{
				ProjectileUtility.SendInRandomDirection(m_projectile);
			}
			timesReAimed++;
		}
		else if (diesAfterMaxDrifts)
		{
			m_projectile.DieInAir(false, true, true, false);
		}
		timer = DriftTimer;
	}
}
