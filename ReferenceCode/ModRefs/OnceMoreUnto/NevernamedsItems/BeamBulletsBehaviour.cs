using Alexandria.ItemAPI;
using UnityEngine;

namespace NevernamedsItems;

public class BeamBulletsBehaviour : MonoBehaviour
{
	public enum FireType
	{
		PLUS,
		CROSS,
		STAR,
		FORWARDS,
		BACKWARDS
	}

	private Projectile m_projectile;

	private PlayerController m_owner;

	public Projectile beamToFire;

	public FireType firetype;

	public BeamBulletsBehaviour()
	{
		beamToFire = LaserBullets.SimpleRedBeam;
		firetype = FireType.PLUS;
	}

	private void Start()
	{
		m_projectile = ((Component)this).GetComponent<Projectile>();
		if (Object.op_Implicit((Object)(object)m_projectile.Owner) && m_projectile.Owner is PlayerController)
		{
			ref PlayerController owner = ref m_owner;
			GameActor owner2 = m_projectile.Owner;
			owner = (PlayerController)(object)((owner2 is PlayerController) ? owner2 : null);
		}
		((MonoBehaviour)this).Invoke("BeginBeamFire", 0.1f);
	}

	private void BeginBeamFire()
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_012d: Unknown result type (might be due to invalid IL or missing references)
		//IL_018e: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_026f: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0331: Unknown result type (might be due to invalid IL or missing references)
		//IL_0392: Unknown result type (might be due to invalid IL or missing references)
		if (firetype == FireType.FORWARDS)
		{
			BeamController val = BeamAPI.FreeFireBeamFromAnywhere(beamToFire, m_owner, ((Component)m_projectile).gameObject, Vector2.zero, 0f, 1000f, true, true, 0f);
			Projectile component = ((Component)val).GetComponent<Projectile>();
		}
		if (firetype == FireType.BACKWARDS)
		{
			BeamController val2 = BeamAPI.FreeFireBeamFromAnywhere(beamToFire, m_owner, ((Component)m_projectile).gameObject, Vector2.zero, 180f, 1000f, true, true, 180f);
			Projectile component2 = ((Component)val2).GetComponent<Projectile>();
		}
		if (firetype == FireType.CROSS || firetype == FireType.STAR)
		{
			BeamController val3 = BeamAPI.FreeFireBeamFromAnywhere(beamToFire, m_owner, ((Component)m_projectile).gameObject, Vector2.zero, 45f, 1000f, true, false, 0f);
			Projectile component3 = ((Component)val3).GetComponent<Projectile>();
			ProjectileData baseData = component3.baseData;
			baseData.damage *= m_owner.stats.GetStatValue((StatType)5);
			BeamController val4 = BeamAPI.FreeFireBeamFromAnywhere(beamToFire, m_owner, ((Component)m_projectile).gameObject, Vector2.zero, 135f, 1000f, true, false, 0f);
			Projectile component4 = ((Component)val4).GetComponent<Projectile>();
			ProjectileData baseData2 = component4.baseData;
			baseData2.damage *= m_owner.stats.GetStatValue((StatType)5);
			BeamController val5 = BeamAPI.FreeFireBeamFromAnywhere(beamToFire, m_owner, ((Component)m_projectile).gameObject, Vector2.zero, -45f, 1000f, true, false, 0f);
			Projectile component5 = ((Component)val5).GetComponent<Projectile>();
			ProjectileData baseData3 = component5.baseData;
			baseData3.damage *= m_owner.stats.GetStatValue((StatType)5);
			BeamController val6 = BeamAPI.FreeFireBeamFromAnywhere(beamToFire, m_owner, ((Component)m_projectile).gameObject, Vector2.zero, -135f, 1000f, true, false, 0f);
			Projectile component6 = ((Component)val6).GetComponent<Projectile>();
			ProjectileData baseData4 = component6.baseData;
			baseData4.damage *= m_owner.stats.GetStatValue((StatType)5);
		}
		if (firetype == FireType.PLUS || firetype == FireType.STAR)
		{
			BeamController val7 = BeamAPI.FreeFireBeamFromAnywhere(beamToFire, m_owner, ((Component)m_projectile).gameObject, Vector2.zero, 0f, 1000f, true, false, 0f);
			Projectile component7 = ((Component)val7).GetComponent<Projectile>();
			ProjectileData baseData5 = component7.baseData;
			baseData5.damage *= m_owner.stats.GetStatValue((StatType)5);
			BeamController val8 = BeamAPI.FreeFireBeamFromAnywhere(beamToFire, m_owner, ((Component)m_projectile).gameObject, Vector2.zero, 90f, 1000f, true, false, 0f);
			Projectile component8 = ((Component)val8).GetComponent<Projectile>();
			ProjectileData baseData6 = component8.baseData;
			baseData6.damage *= m_owner.stats.GetStatValue((StatType)5);
			BeamController val9 = BeamAPI.FreeFireBeamFromAnywhere(beamToFire, m_owner, ((Component)m_projectile).gameObject, Vector2.zero, 180f, 1000f, true, false, 0f);
			Projectile component9 = ((Component)val9).GetComponent<Projectile>();
			ProjectileData baseData7 = component9.baseData;
			baseData7.damage *= m_owner.stats.GetStatValue((StatType)5);
			BeamController val10 = BeamAPI.FreeFireBeamFromAnywhere(beamToFire, m_owner, ((Component)m_projectile).gameObject, Vector2.zero, -90f, 1000f, true, false, 0f);
			Projectile component10 = ((Component)val10).GetComponent<Projectile>();
			ProjectileData baseData8 = component10.baseData;
			baseData8.damage *= m_owner.stats.GetStatValue((StatType)5);
		}
	}

	private void Update()
	{
	}
}
