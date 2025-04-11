using System.Collections.Generic;
using Alexandria.ItemAPI;
using UnityEngine;

namespace NevernamedsItems;

internal class IdentityCrisis : PlayerItem
{
	public static void Init()
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		PickupObject obj = ItemSetup.NewItem<IdentityCrisis>("Identity Crisis", "WHO AM I?", "Makes you completely forget who you are.", "identitycrisis_icon", assetbundle: true);
		PlayerItem val = (PlayerItem)(object)((obj is PlayerItem) ? obj : null);
		ItemBuilder.SetCooldownType(val, (CooldownType)3, 1000f);
		val.consumable = true;
		((PickupObject)val).quality = (ItemQuality)3;
		ItemBuilder.AddToSubShop((PickupObject)(object)val, (ShopType)2, 1f);
	}

	public override void DoEffect(PlayerController user)
	{
		float baseStatValue = user.stats.GetBaseStatValue((StatType)14);
		user.stats.SetBaseStatValue((StatType)14, baseStatValue + 1f, user);
		if (CustomSynergies.PlayerHasActiveSynergy(user, "Those We Left Behind"))
		{
			if (CustomSynergies.PlayerHasActiveSynergy(user, "Associated Disassociations"))
			{
				List<int> collection = new List<int> { 24, 811, 604, 603 };
				foreach (Gun allGun in user.inventory.AllGuns)
				{
					if ((Object)(object)((Component)allGun).GetComponent<Paraglocks>() != (Object)null)
					{
						((Component)allGun).GetComponent<Paraglocks>().idsBuffedByAssociatedDissasociationsSynergy.AddRange(collection);
					}
				}
			}
			if (!user.HasPickupID(24) && !user.HasPickupID(811))
			{
				PickupObject byId = PickupObjectDatabase.GetById(24);
				Gun val = (Gun)(object)((byId is Gun) ? byId : null);
				base.LastOwner.inventory.AddGunToInventory(val, true);
			}
			if (!user.HasPickupID(604))
			{
				PickupObject byId2 = PickupObjectDatabase.GetById(604);
				Gun val2 = (Gun)(object)((byId2 is Gun) ? byId2 : null);
				base.LastOwner.inventory.AddGunToInventory(val2, true);
			}
			if (!user.HasPickupID(603))
			{
				PickupObject byId3 = PickupObjectDatabase.GetById(603);
				Gun val3 = (Gun)(object)((byId3 is Gun) ? byId3 : null);
				base.LastOwner.inventory.AddGunToInventory(val3, true);
			}
		}
		if (CustomSynergies.PlayerHasActiveSynergy(user, "New run, New me"))
		{
			GiveHunterLoadout(user);
			GiveConvictLoadout(user);
			GiveMarineLoadout(user);
			GivePilotLoadout(user);
			GiveBulletLoadout(user);
			GiveRobotLoadout(user);
		}
		else
		{
			pickRandomCharacter();
		}
	}

	private void pickRandomCharacter()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Invalid comparison between Unknown and I4
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Invalid comparison between Unknown and I4
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Invalid comparison between Unknown and I4
		//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b8: Invalid comparison between Unknown and I4
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ed: Invalid comparison between Unknown and I4
		//IL_0125: Unknown result type (might be due to invalid IL or missing references)
		//IL_012b: Invalid comparison between Unknown and I4
		//IL_015a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0160: Invalid comparison between Unknown and I4
		//IL_0195: Unknown result type (might be due to invalid IL or missing references)
		//IL_019b: Invalid comparison between Unknown and I4
		//IL_01d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d7: Invalid comparison between Unknown and I4
		//IL_0228: Unknown result type (might be due to invalid IL or missing references)
		//IL_022e: Invalid comparison between Unknown and I4
		int num = Random.Range(1, 7);
		if (num == 1 && (int)base.LastOwner.characterIdentity != 6)
		{
			GiveHunterLoadout(base.LastOwner);
			return;
		}
		if (num == 1 && (int)base.LastOwner.characterIdentity == 6)
		{
			ETGModConsole.Log((object)"The item seleced the Hunter loadout, but you're already the Hunter so it repicked.", false);
			pickRandomCharacter();
			return;
		}
		if (num == 2 && (int)base.LastOwner.characterIdentity != 1)
		{
			ETGModConsole.Log((object)"The item seleced the Convict loadout", false);
			GiveConvictLoadout(base.LastOwner);
			return;
		}
		if (num == 2 && (int)base.LastOwner.characterIdentity == 1)
		{
			ETGModConsole.Log((object)"The item seleced the Convict loadout, but you're already the Convict so it repicked.", false);
			pickRandomCharacter();
			return;
		}
		if (num == 3 && (int)base.LastOwner.characterIdentity != 5)
		{
			ETGModConsole.Log((object)"The item seleced the Marine loadout", false);
			GiveMarineLoadout(base.LastOwner);
			return;
		}
		if (num == 3 && (int)base.LastOwner.characterIdentity == 5)
		{
			ETGModConsole.Log((object)"The item seleced the Marine loadout, but you're already the Marine so it repicked.", false);
			pickRandomCharacter();
			return;
		}
		if (num == 4 && (int)base.LastOwner.characterIdentity > 0)
		{
			ETGModConsole.Log((object)"The item seleced the Pilot loadout", false);
			GivePilotLoadout(base.LastOwner);
			return;
		}
		if (num == 4 && (int)base.LastOwner.characterIdentity == 0)
		{
			ETGModConsole.Log((object)"The item seleced the Pilot loadout, but you're already the Pilot so it repicked.", false);
			pickRandomCharacter();
			return;
		}
		switch (num)
		{
		case 5:
			if ((int)base.LastOwner.characterIdentity != 2)
			{
				ETGModConsole.Log((object)"The item seleced the Robot loadout", false);
				GiveRobotLoadout(base.LastOwner);
			}
			else
			{
				ETGModConsole.Log((object)"The item seleced the Robot loadout, but you're already the Robot so it repicked.", false);
				pickRandomCharacter();
			}
			break;
		case 6:
			if ((int)base.LastOwner.characterIdentity != 8)
			{
				ETGModConsole.Log((object)"The item seleced the Bullet loadout", false);
				GiveBulletLoadout(base.LastOwner);
			}
			else
			{
				ETGModConsole.Log((object)"The item seleced the Bullet loadout, but you're already the Bullet so it repicked.", false);
				pickRandomCharacter();
			}
			break;
		}
	}

	private void GiveHunterLoadout(PlayerController user)
	{
		if (!user.HasPickupID(300))
		{
			PickupObject byId = PickupObjectDatabase.GetById(300);
			base.LastOwner.AcquirePassiveItemPrefabDirectly((PassiveItem)(object)((byId is PassiveItem) ? byId : null));
		}
		if (!user.HasPickupID(12))
		{
			PickupObject byId2 = PickupObjectDatabase.GetById(12);
			Gun val = (Gun)(object)((byId2 is Gun) ? byId2 : null);
			base.LastOwner.inventory.AddGunToInventory(val, true);
		}
		if (!user.HasPickupID(99) && !user.HasPickupID(810))
		{
			PickupObject byId3 = PickupObjectDatabase.GetById(99);
			Gun val2 = (Gun)(object)((byId3 is Gun) ? byId3 : null);
			base.LastOwner.inventory.AddGunToInventory(val2, true);
		}
		foreach (Gun allGun in user.inventory.AllGuns)
		{
			if ((Object)(object)((Component)allGun).GetComponent<Paraglocks>() != (Object)null)
			{
				((Component)allGun).GetComponent<Paraglocks>().idsBuffedByAssociatedDissasociationsSynergy.Add(99);
				((Component)allGun).GetComponent<Paraglocks>().idsBuffedByAssociatedDissasociationsSynergy.Add(810);
			}
		}
	}

	private void GiveConvictLoadout(PlayerController user)
	{
		//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00eb: Unknown result type (might be due to invalid IL or missing references)
		if (!user.HasPickupID(353))
		{
			PickupObject byId = PickupObjectDatabase.GetById(353);
			base.LastOwner.AcquirePassiveItemPrefabDirectly((PassiveItem)(object)((byId is PassiveItem) ? byId : null));
		}
		if (!user.HasPickupID(202))
		{
			PickupObject byId2 = PickupObjectDatabase.GetById(202);
			Gun val = (Gun)(object)((byId2 is Gun) ? byId2 : null);
			base.LastOwner.inventory.AddGunToInventory(val, true);
		}
		if (!user.HasPickupID(80) && !user.HasPickupID(652))
		{
			PickupObject byId3 = PickupObjectDatabase.GetById(80);
			Gun val2 = (Gun)(object)((byId3 is Gun) ? byId3 : null);
			base.LastOwner.inventory.AddGunToInventory(val2, true);
		}
		if (!user.HasPickupID(366))
		{
			PickupObject byId4 = PickupObjectDatabase.GetById(366);
			LootEngine.SpawnItem(((Component)byId4).gameObject, Vector2.op_Implicit(((BraveBehaviour)base.LastOwner).specRigidbody.UnitCenter), Vector2.left, 1f, false, true, false);
		}
		foreach (Gun allGun in user.inventory.AllGuns)
		{
			if ((Object)(object)((Component)allGun).GetComponent<Paraglocks>() != (Object)null)
			{
				((Component)allGun).GetComponent<Paraglocks>().idsBuffedByAssociatedDissasociationsSynergy.Add(80);
				((Component)allGun).GetComponent<Paraglocks>().idsBuffedByAssociatedDissasociationsSynergy.Add(652);
			}
		}
	}

	private void GivePilotLoadout(PlayerController user)
	{
		//IL_00db: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e5: Unknown result type (might be due to invalid IL or missing references)
		if (!user.HasPickupID(187))
		{
			PickupObject byId = PickupObjectDatabase.GetById(187);
			base.LastOwner.AcquirePassiveItemPrefabDirectly((PassiveItem)(object)((byId is PassiveItem) ? byId : null));
		}
		if (!user.HasPickupID(473))
		{
			PickupObject byId2 = PickupObjectDatabase.GetById(473);
			base.LastOwner.AcquirePassiveItemPrefabDirectly((PassiveItem)(object)((byId2 is PassiveItem) ? byId2 : null));
		}
		if (!user.HasPickupID(89) && !user.HasPickupID(651))
		{
			PickupObject byId3 = PickupObjectDatabase.GetById(89);
			Gun val = (Gun)(object)((byId3 is Gun) ? byId3 : null);
			base.LastOwner.inventory.AddGunToInventory(val, true);
		}
		if (!user.HasPickupID(356))
		{
			PickupObject byId4 = PickupObjectDatabase.GetById(356);
			LootEngine.SpawnItem(((Component)byId4).gameObject, Vector2.op_Implicit(((BraveBehaviour)base.LastOwner).specRigidbody.UnitCenter), Vector2.left, 1f, false, true, false);
		}
		foreach (Gun allGun in user.inventory.AllGuns)
		{
			if ((Object)(object)((Component)allGun).GetComponent<Paraglocks>() != (Object)null)
			{
				((Component)allGun).GetComponent<Paraglocks>().idsBuffedByAssociatedDissasociationsSynergy.Add(89);
				((Component)allGun).GetComponent<Paraglocks>().idsBuffedByAssociatedDissasociationsSynergy.Add(651);
			}
		}
	}

	private void GiveMarineLoadout(PlayerController user)
	{
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		if (!user.HasPickupID(354))
		{
			PickupObject byId = PickupObjectDatabase.GetById(354);
			base.LastOwner.AcquirePassiveItemPrefabDirectly((PassiveItem)(object)((byId is PassiveItem) ? byId : null));
		}
		if (!user.HasPickupID(86) && !user.HasPickupID(809))
		{
			PickupObject byId2 = PickupObjectDatabase.GetById(86);
			Gun val = (Gun)(object)((byId2 is Gun) ? byId2 : null);
			base.LastOwner.inventory.AddGunToInventory(val, true);
		}
		if (!user.HasPickupID(77))
		{
			PickupObject byId3 = PickupObjectDatabase.GetById(77);
			LootEngine.SpawnItem(((Component)byId3).gameObject, Vector2.op_Implicit(((BraveBehaviour)base.LastOwner).specRigidbody.UnitCenter), Vector2.left, 1f, false, true, false);
		}
		LootEngine.GivePrefabToPlayer(((Component)PickupObjectDatabase.GetById(120)).gameObject, base.LastOwner);
		foreach (Gun allGun in user.inventory.AllGuns)
		{
			if ((Object)(object)((Component)allGun).GetComponent<Paraglocks>() != (Object)null)
			{
				((Component)allGun).GetComponent<Paraglocks>().idsBuffedByAssociatedDissasociationsSynergy.Add(86);
				((Component)allGun).GetComponent<Paraglocks>().idsBuffedByAssociatedDissasociationsSynergy.Add(809);
			}
		}
	}

	private void GiveRobotLoadout(PlayerController user)
	{
		//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b0: Unknown result type (might be due to invalid IL or missing references)
		if (!user.HasPickupID(410))
		{
			PickupObject byId = PickupObjectDatabase.GetById(410);
			base.LastOwner.AcquirePassiveItemPrefabDirectly((PassiveItem)(object)((byId is PassiveItem) ? byId : null));
		}
		if (!user.HasPickupID(88) && !user.HasPickupID(812))
		{
			PickupObject byId2 = PickupObjectDatabase.GetById(88);
			Gun val = (Gun)(object)((byId2 is Gun) ? byId2 : null);
			base.LastOwner.inventory.AddGunToInventory(val, true);
		}
		if (!user.HasPickupID(411))
		{
			PickupObject byId3 = PickupObjectDatabase.GetById(411);
			LootEngine.SpawnItem(((Component)byId3).gameObject, Vector2.op_Implicit(((BraveBehaviour)base.LastOwner).specRigidbody.UnitCenter), Vector2.left, 1f, false, true, false);
		}
		foreach (Gun allGun in user.inventory.AllGuns)
		{
			if ((Object)(object)((Component)allGun).GetComponent<Paraglocks>() != (Object)null)
			{
				((Component)allGun).GetComponent<Paraglocks>().idsBuffedByAssociatedDissasociationsSynergy.Add(88);
				((Component)allGun).GetComponent<Paraglocks>().idsBuffedByAssociatedDissasociationsSynergy.Add(812);
			}
		}
	}

	private void GiveBulletLoadout(PlayerController user)
	{
		if (!user.HasPickupID(414))
		{
			PickupObject byId = PickupObjectDatabase.GetById(414);
			base.LastOwner.AcquirePassiveItemPrefabDirectly((PassiveItem)(object)((byId is PassiveItem) ? byId : null));
		}
		if (!user.HasPickupID(417) && !user.HasPickupID(813))
		{
			PickupObject byId2 = PickupObjectDatabase.GetById(417);
			Gun val = (Gun)(object)((byId2 is Gun) ? byId2 : null);
			base.LastOwner.inventory.AddGunToInventory(val, true);
		}
		foreach (Gun allGun in user.inventory.AllGuns)
		{
			if ((Object)(object)((Component)allGun).GetComponent<Paraglocks>() != (Object)null)
			{
				((Component)allGun).GetComponent<Paraglocks>().idsBuffedByAssociatedDissasociationsSynergy.Add(417);
				((Component)allGun).GetComponent<Paraglocks>().idsBuffedByAssociatedDissasociationsSynergy.Add(813);
			}
		}
	}
}
