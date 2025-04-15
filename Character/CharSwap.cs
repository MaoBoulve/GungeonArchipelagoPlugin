using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Alexandria.ItemAPI;

namespace ArchiGungeon.Character
{
    class CharSwap
    {

		private void GiveHunterLoadout(PlayerController user)
		{
			if (!user.HasPickupID(300))
			{
				PickupObject byId = PickupObjectDatabase.GetById(300);
				user.AcquirePassiveItemPrefabDirectly((PassiveItem)(object)((byId is PassiveItem) ? byId : null));
			}
			if (!user.HasPickupID(12))
			{
				PickupObject byId2 = PickupObjectDatabase.GetById(12);
				Gun val = (Gun)(object)((byId2 is Gun) ? byId2 : null);
				user.inventory.AddGunToInventory(val, true);
			}
			if (!user.HasPickupID(99) && !user.HasPickupID(810))
			{
				PickupObject byId3 = PickupObjectDatabase.GetById(99);
				Gun val2 = (Gun)(object)((byId3 is Gun) ? byId3 : null);
				user.inventory.AddGunToInventory(val2, true);
			}

			return;
		}

		private void GiveConvictLoadout(PlayerController user)
		{
			
			if (!user.HasPickupID(353))
			{
				PickupObject byId = PickupObjectDatabase.GetById(353);
				user.AcquirePassiveItemPrefabDirectly((PassiveItem)(object)((byId is PassiveItem) ? byId : null));
			}
			if (!user.HasPickupID(202))
			{
				PickupObject byId2 = PickupObjectDatabase.GetById(202);
				Gun val = (Gun)(object)((byId2 is Gun) ? byId2 : null);
				user.inventory.AddGunToInventory(val, true);
			}
			if (!user.HasPickupID(80) && !user.HasPickupID(652))
			{
				PickupObject byId3 = PickupObjectDatabase.GetById(80);
				Gun val2 = (Gun)(object)((byId3 is Gun) ? byId3 : null);
				user.inventory.AddGunToInventory(val2, true);
			}
			if (!user.HasPickupID(366))
			{
				PickupObject byId4 = PickupObjectDatabase.GetById(366);
				LootEngine.SpawnItem(byId4.gameObject, user.specRigidbody.UnitCenter, Vector2.left, 1f, false, true, false);
			}

		}

		private void GivePilotLoadout(PlayerController user)
		{
			
			if (!user.HasPickupID(187))
			{
				PickupObject byId = PickupObjectDatabase.GetById(187);
				user.AcquirePassiveItemPrefabDirectly((PassiveItem)(object)((byId is PassiveItem) ? byId : null));
			}
			if (!user.HasPickupID(473))
			{
				PickupObject byId2 = PickupObjectDatabase.GetById(473);
				user.AcquirePassiveItemPrefabDirectly((PassiveItem)(object)((byId2 is PassiveItem) ? byId2 : null));
			}
			if (!user.HasPickupID(89) && !user.HasPickupID(651))
			{
				PickupObject byId3 = PickupObjectDatabase.GetById(89);
				Gun val = (Gun)(object)((byId3 is Gun) ? byId3 : null);
				user.inventory.AddGunToInventory(val, true);
			}
			if (!user.HasPickupID(356))
			{
				PickupObject byId4 = PickupObjectDatabase.GetById(356);
				LootEngine.SpawnItem(byId4.gameObject, user.specRigidbody.UnitCenter, Vector2.left, 1f, false, true, false);
			}

		}


		private void GiveMarineLoadout(PlayerController user)
		{
			
			if (!user.HasPickupID(354))
			{
				PickupObject byId = PickupObjectDatabase.GetById(354);
				user.AcquirePassiveItemPrefabDirectly((PassiveItem)(object)((byId is PassiveItem) ? byId : null));
			}
			if (!user.HasPickupID(86) && !user.HasPickupID(809))
			{
				PickupObject byId2 = PickupObjectDatabase.GetById(86);
				Gun val = (Gun)(object)((byId2 is Gun) ? byId2 : null);
				user.inventory.AddGunToInventory(val, true);
			}
			if (!user.HasPickupID(77))
			{
				PickupObject byId3 = PickupObjectDatabase.GetById(77);
				LootEngine.SpawnItem(((Component)byId3).gameObject, (((BraveBehaviour)user).specRigidbody.UnitCenter), Vector2.left, 1f, false, true, false);
			}

			LootEngine.GivePrefabToPlayer(((Component)PickupObjectDatabase.GetById(120)).gameObject, user);

		}

		private void GiveRobotLoadout(PlayerController user)
		{
			
			if (!user.HasPickupID(410))
			{
				PickupObject byId = PickupObjectDatabase.GetById(410);
				user.AcquirePassiveItemPrefabDirectly((PassiveItem)(object)((byId is PassiveItem) ? byId : null));
			}
			if (!user.HasPickupID(88) && !user.HasPickupID(812))
			{
				PickupObject byId2 = PickupObjectDatabase.GetById(88);
				Gun val = (Gun)(object)((byId2 is Gun) ? byId2 : null);
				user.inventory.AddGunToInventory(val, true);
			}
			if (!user.HasPickupID(411))
			{
				PickupObject byId3 = PickupObjectDatabase.GetById(411);
				LootEngine.SpawnItem(((Component)byId3).gameObject, (((BraveBehaviour)user).specRigidbody.UnitCenter), Vector2.left, 1f, false, true, false);
			}

		}

		private void GiveBulletLoadout(PlayerController user)
		{
			if (!user.HasPickupID(414))
			{
				PickupObject byId = PickupObjectDatabase.GetById(414);
				user.AcquirePassiveItemPrefabDirectly((PassiveItem)(object)((byId is PassiveItem) ? byId : null));
			}
			if (!user.HasPickupID(417) && !user.HasPickupID(813))
			{
				PickupObject byId2 = PickupObjectDatabase.GetById(417);
				Gun val = (Gun)(object)((byId2 is Gun) ? byId2 : null);
				user.inventory.AddGunToInventory(val, true);
			}

		}

	}
}
