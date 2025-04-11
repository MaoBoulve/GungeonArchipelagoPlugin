using Alexandria.Misc;
using UnityEngine;

namespace NevernamedsItems;

internal class ChemicalBurnBeamModifier : MonoBehaviour
{
	private bool currentlyActive = false;

	private GoopDefinition lastcheckedgoop;

	private Projectile m_projectile;

	private PlayerController owner;

	public void Start()
	{
		m_projectile = ((Component)this).GetComponent<Projectile>();
		if (Object.op_Implicit((Object)(object)m_projectile) && Object.op_Implicit((Object)(object)ProjectileUtility.ProjectilePlayerOwner(m_projectile)))
		{
			owner = ProjectileUtility.ProjectilePlayerOwner(m_projectile);
		}
	}

	public void Update()
	{
		if (!((Object)(object)((GameActor)owner).CurrentGoop != (Object)(object)lastcheckedgoop))
		{
			return;
		}
		if (((GameActor)owner).CurrentGoop.HealthModifierEffect != null && ((GameActor)owner).CurrentGoop.AppliesDamageOverTime && !(((GameActor)owner).CurrentGoop.HealthModifierEffect is GameActorPlagueEffect))
		{
			if (!currentlyActive)
			{
				ProjectileData baseData = m_projectile.baseData;
				baseData.damage *= 2f;
				currentlyActive = true;
			}
		}
		else if (currentlyActive)
		{
			ProjectileData baseData2 = m_projectile.baseData;
			baseData2.damage /= 2f;
			currentlyActive = false;
		}
		lastcheckedgoop = ((GameActor)owner).CurrentGoop;
	}
}
