using System.Linq;
using Alexandria.ItemAPI;
using Alexandria.Misc;
using UnityEngine;

namespace NevernamedsItems;

public class Albedo : PassiveItem
{
	private class BoostedByAlbedo : MonoBehaviour
	{
		public int currentMultiplier;

		public int storedOrbitalTier;
	}

	public static int AlbedoID;

	private float lastOrbitals;

	private bool hadSynergyLastChecked;

	public static void Init()
	{
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		PickupObject obj = ItemSetup.NewItem<Albedo>("Albedo", "Clarity", "Speeds up Glass Guon Stones.\n\nThe second phase of the prime materia's transition into the Philosopher's Stone, where the murky darkness of the Nigredo is purified into a lunarily charged clarity.", "albedo_icon", assetbundle: true);
		PassiveItem val = (PassiveItem)(object)((obj is PassiveItem) ? obj : null);
		((PickupObject)val).quality = (ItemQuality)2;
		ItemBuilder.AddToSubShop((PickupObject)(object)val, (ShopType)0, 1f);
		AlbedoID = ((PickupObject)val).PickupObjectId;
	}

	public override void Update()
	{
		((PassiveItem)this).Update();
		if (!Object.op_Implicit((Object)(object)((PassiveItem)this).Owner) || ((PassiveItem)this).Owner.orbitals.Count < 0)
		{
			return;
		}
		float num = ((PassiveItem)this).Owner.orbitals.Count();
		if (num != lastOrbitals)
		{
			if (num > 0f)
			{
				UpdateOrbitals();
			}
			lastOrbitals = num;
		}
		if (hadSynergyLastChecked != CustomSynergies.PlayerHasActiveSynergy(((PassiveItem)this).Owner, "White Ethesia"))
		{
			if (num > 0f)
			{
				UpdateOrbitals();
			}
			hadSynergyLastChecked = CustomSynergies.PlayerHasActiveSynergy(((PassiveItem)this).Owner, "White Ethesia");
		}
	}

	private void UpdateOrbitals()
	{
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Expected O, but got Unknown
		foreach (IPlayerOrbital orbital in ((PassiveItem)this).Owner.orbitals)
		{
			if (!(orbital is PlayerOrbital))
			{
				continue;
			}
			PlayerOrbital val = (PlayerOrbital)orbital;
			if (!((Object)(object)val != (Object)null) || !(((Object)val).name == "IounStone_Glass(Clone)"))
			{
				continue;
			}
			if ((Object)(object)((Component)val).gameObject.GetComponent<BoostedByAlbedo>() == (Object)null)
			{
				int num = 3;
				if (CustomSynergies.PlayerHasActiveSynergy(((PassiveItem)this).Owner, "White Ethesia"))
				{
					num = 4;
				}
				BoostedByAlbedo boostedByAlbedo = ((Component)val).gameObject.AddComponent<BoostedByAlbedo>();
				boostedByAlbedo.currentMultiplier = num;
				boostedByAlbedo.storedOrbitalTier = val.GetOrbitalTier();
				val.orbitDegreesPerSecond *= (float)num;
				val.SetOrbitalTier(1010);
				val.SetOrbitalTierIndex(PlayerOrbital.GetNumberOfOrbitalsInTier(((PassiveItem)this).Owner, 1010));
			}
			else if (((Component)val).gameObject.GetComponent<BoostedByAlbedo>().currentMultiplier == 3 && CustomSynergies.PlayerHasActiveSynergy(((PassiveItem)this).Owner, "White Ethesia"))
			{
				val.orbitDegreesPerSecond /= 3f;
				val.orbitDegreesPerSecond *= 4f;
				((Component)val).gameObject.GetComponent<BoostedByAlbedo>().currentMultiplier = 4;
				val.SetOrbitalTier(1010);
				val.SetOrbitalTierIndex(PlayerOrbital.GetNumberOfOrbitalsInTier(((PassiveItem)this).Owner, 1010));
			}
			else if (((Component)val).gameObject.GetComponent<BoostedByAlbedo>().currentMultiplier == 4 && !CustomSynergies.PlayerHasActiveSynergy(((PassiveItem)this).Owner, "White Ethesia"))
			{
				val.orbitDegreesPerSecond /= 4f;
				val.orbitDegreesPerSecond *= 3f;
				((Component)val).gameObject.GetComponent<BoostedByAlbedo>().currentMultiplier = 3;
				val.SetOrbitalTier(1010);
				val.SetOrbitalTierIndex(PlayerOrbital.GetNumberOfOrbitalsInTier(((PassiveItem)this).Owner, 1010));
			}
		}
		RecalcOrbIndex();
	}

	private void ResetOrbitals(PlayerController player)
	{
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Expected O, but got Unknown
		if (player.orbitals == null || player.orbitals.Count <= 0)
		{
			return;
		}
		foreach (IPlayerOrbital orbital in ((PassiveItem)this).Owner.orbitals)
		{
			if (orbital is PlayerOrbital)
			{
				PlayerOrbital val = (PlayerOrbital)orbital;
				if ((Object)(object)((Component)val).gameObject.GetComponent<BoostedByAlbedo>() != (Object)null)
				{
					val.orbitDegreesPerSecond /= (float)((Component)val).gameObject.GetComponent<BoostedByAlbedo>().currentMultiplier;
					val.SetOrbitalTier(PlayerOrbital.CalculateTargetTier(player, orbital));
					val.SetOrbitalTierIndex(PlayerOrbital.GetNumberOfOrbitalsInTier(player, ((Component)val).gameObject.GetComponent<BoostedByAlbedo>().storedOrbitalTier));
					Object.Destroy((Object)(object)((Component)val).gameObject.GetComponent<BoostedByAlbedo>());
				}
			}
		}
		RecalcOrbIndex();
	}

	private void RecalcOrbIndex()
	{
		PlayerUtility.RecalculateOrbitals(((PassiveItem)this).Owner);
	}

	public override void Pickup(PlayerController player)
	{
		if (!base.m_pickedUpThisRun)
		{
			for (int i = 0; i < 3; i++)
			{
				_003F val = player;
				PickupObject byId = PickupObjectDatabase.GetById(565);
				((PlayerController)val).AcquirePassiveItemPrefabDirectly((PassiveItem)(object)((byId is PassiveItem) ? byId : null));
			}
		}
		((PassiveItem)this).Pickup(player);
		UpdateOrbitals();
		GameManager.Instance.OnNewLevelFullyLoaded += NewFloor;
	}

	public override DebrisObject Drop(PlayerController player)
	{
		GameManager.Instance.OnNewLevelFullyLoaded -= NewFloor;
		if (PlayerUtility.GetNumberOfItemInInventory(player, AlbedoID) <= 1)
		{
			ResetOrbitals(player);
		}
		return ((PassiveItem)this).Drop(player);
	}

	public override void OnDestroy()
	{
		GameManager.Instance.OnNewLevelFullyLoaded -= NewFloor;
		if (Object.op_Implicit((Object)(object)((PassiveItem)this).Owner))
		{
			ResetOrbitals(((PassiveItem)this).Owner);
		}
		((PassiveItem)this).OnDestroy();
	}

	private void NewFloor()
	{
		if (Object.op_Implicit((Object)(object)((PassiveItem)this).Owner))
		{
			_003F val = ((PassiveItem)this).Owner;
			PickupObject byId = PickupObjectDatabase.GetById(565);
			((PlayerController)val).AcquirePassiveItemPrefabDirectly((PassiveItem)(object)((byId is PassiveItem) ? byId : null));
			ResetOrbitals(((PassiveItem)this).Owner);
		}
	}
}
