using Dungeonator;
using UnityEngine;

namespace NevernamedsItems;

public class AmmoBasedFormeChanger : MonoBehaviour
{
	private int cachedAmmo;

	private Gun m_gun;

	public int baseGunID;

	public int higherAmmoGunID;

	public int highestAmmoGunID;

	public int lowerAmmoGunID;

	public int lowestAmmoGunID;

	public int highestAmmoAmount;

	public int higherAmmoAmount;

	public int lowerAmmoAmount;

	public int lowestAmmoAmount;

	private string Forme;

	public AmmoBasedFormeChanger()
	{
		highestAmmoGunID = -1;
		higherAmmoGunID = -1;
		baseGunID = -1;
		lowerAmmoGunID = -1;
		lowestAmmoGunID = -1;
		highestAmmoAmount = -1;
		higherAmmoAmount = -1;
		lowerAmmoAmount = -1;
		lowestAmmoAmount = -1;
	}

	private void Awake()
	{
		m_gun = ((Component)this).GetComponent<Gun>();
	}

	private void Update()
	{
		if (Dungeon.IsGenerating || Dungeon.ShouldAttemptToLoadFromMidgameSave || !Object.op_Implicit((Object)(object)m_gun) || !(m_gun.CurrentOwner is PlayerController))
		{
			return;
		}
		GameActor currentOwner = m_gun.CurrentOwner;
		PlayerController val = (PlayerController)(object)((currentOwner is PlayerController) ? currentOwner : null);
		if (((Behaviour)m_gun).enabled)
		{
			int currentAmmo = m_gun.CurrentAmmo;
			if (currentAmmo != cachedAmmo)
			{
				DetermineForme(currentAmmo);
				cachedAmmo = currentAmmo;
			}
		}
	}

	private void DetermineForme(int currentAmmo)
	{
		if (highestAmmoGunID != -1 && currentAmmo > highestAmmoAmount)
		{
			if (Forme != "Highest")
			{
				_003F val = m_gun;
				PickupObject byId = PickupObjectDatabase.GetById(highestAmmoGunID);
				((Gun)val).TransformToTargetGun((Gun)(object)((byId is Gun) ? byId : null));
				Forme = "Highest";
			}
		}
		else if (higherAmmoGunID != -1 && currentAmmo > higherAmmoAmount && (highestAmmoGunID == -1 || currentAmmo < highestAmmoAmount))
		{
			if (Forme != "Higher")
			{
				_003F val2 = m_gun;
				PickupObject byId2 = PickupObjectDatabase.GetById(higherAmmoGunID);
				((Gun)val2).TransformToTargetGun((Gun)(object)((byId2 is Gun) ? byId2 : null));
				Forme = "Higher";
			}
		}
		else if (lowerAmmoGunID != -1 && currentAmmo < lowerAmmoAmount && (lowestAmmoGunID == -1 || currentAmmo > lowestAmmoAmount))
		{
			if (Forme != "Lower")
			{
				_003F val3 = m_gun;
				PickupObject byId3 = PickupObjectDatabase.GetById(lowerAmmoGunID);
				((Gun)val3).TransformToTargetGun((Gun)(object)((byId3 is Gun) ? byId3 : null));
				Forme = "Lower";
			}
		}
		else if (lowestAmmoGunID != -1 && currentAmmo < lowestAmmoAmount)
		{
			if (Forme != "Lowest")
			{
				_003F val4 = m_gun;
				PickupObject byId4 = PickupObjectDatabase.GetById(lowestAmmoGunID);
				((Gun)val4).TransformToTargetGun((Gun)(object)((byId4 is Gun) ? byId4 : null));
				Forme = "Lowest";
			}
		}
		else if (baseGunID != -1 && (currentAmmo > lowerAmmoAmount || lowerAmmoAmount == -1) && (currentAmmo < higherAmmoAmount || higherAmmoAmount == -1))
		{
			if (Forme != "Normal")
			{
				_003F val5 = m_gun;
				PickupObject byId5 = PickupObjectDatabase.GetById(baseGunID);
				((Gun)val5).TransformToTargetGun((Gun)(object)((byId5 is Gun) ? byId5 : null));
				Forme = "Normal";
			}
		}
		else
		{
			ETGModConsole.Log((object)"That's weird, this message shouldn't be seen unless I fucked up. Send this to Nevernamed and tell him he needs to fix his Ammo Based Forme Switcher.", false);
		}
	}
}
