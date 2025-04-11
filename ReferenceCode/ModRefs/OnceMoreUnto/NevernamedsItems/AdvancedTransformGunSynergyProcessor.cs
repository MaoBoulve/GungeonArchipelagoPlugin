using Alexandria.ItemAPI;
using Dungeonator;
using UnityEngine;

namespace NevernamedsItems;

public class AdvancedTransformGunSynergyProcessor : MonoBehaviour
{
	public string SynergyToCheck;

	public int NonSynergyGunId;

	public int SynergyGunId;

	private Gun m_gun;

	private bool m_transformed;

	public bool ShouldResetAmmoAfterTransformation;

	public int ResetAmmoCount;

	public AdvancedTransformGunSynergyProcessor()
	{
		NonSynergyGunId = -1;
		SynergyGunId = -1;
	}

	private void Awake()
	{
		m_gun = ((Component)this).GetComponent<Gun>();
	}

	private void Update()
	{
		if (Dungeon.IsGenerating || Dungeon.ShouldAttemptToLoadFromMidgameSave)
		{
			return;
		}
		if (Object.op_Implicit((Object)(object)m_gun) && m_gun.CurrentOwner is PlayerController)
		{
			GameActor currentOwner = m_gun.CurrentOwner;
			PlayerController val = (PlayerController)(object)((currentOwner is PlayerController) ? currentOwner : null);
			if (!((Behaviour)m_gun).enabled)
			{
				return;
			}
			if (CustomSynergies.PlayerHasActiveSynergy(val, SynergyToCheck) && !m_transformed)
			{
				m_transformed = true;
				_003F val2 = m_gun;
				PickupObject byId = PickupObjectDatabase.GetById(SynergyGunId);
				((Gun)val2).TransformToTargetGun((Gun)(object)((byId is Gun) ? byId : null));
				if (ShouldResetAmmoAfterTransformation)
				{
					m_gun.ammo = ResetAmmoCount;
				}
			}
			else if (!CustomSynergies.PlayerHasActiveSynergy(val, SynergyToCheck) && m_transformed)
			{
				m_transformed = false;
				_003F val3 = m_gun;
				PickupObject byId2 = PickupObjectDatabase.GetById(NonSynergyGunId);
				((Gun)val3).TransformToTargetGun((Gun)(object)((byId2 is Gun) ? byId2 : null));
				if (ShouldResetAmmoAfterTransformation)
				{
					m_gun.ammo = ResetAmmoCount;
				}
			}
		}
		else if (Object.op_Implicit((Object)(object)m_gun) && !Object.op_Implicit((Object)(object)m_gun.CurrentOwner) && m_transformed)
		{
			m_transformed = false;
			_003F val4 = m_gun;
			PickupObject byId3 = PickupObjectDatabase.GetById(NonSynergyGunId);
			((Gun)val4).TransformToTargetGun((Gun)(object)((byId3 is Gun) ? byId3 : null));
			if (ShouldResetAmmoAfterTransformation)
			{
				m_gun.ammo = ResetAmmoCount;
			}
		}
		ShouldResetAmmoAfterTransformation = false;
	}
}
