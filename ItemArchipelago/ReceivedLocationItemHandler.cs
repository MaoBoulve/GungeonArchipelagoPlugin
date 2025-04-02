using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace ArchiGungeon.ItemArchipelago
{
    public class ReceivedLocationItemHandler
    {
        private static System.Random random = new();

        private static Gun GetRandomGunByQualities(PickupObject.ItemQuality[] itemQuals)
        {
            Gun gunToReturn = PickupObjectDatabase.GetRandomGunOfQualities(random, new List<int>(), itemQuals);

            return gunToReturn;
        }

        private static PassiveItem GetRandomPassiveByQualities(PickupObject.ItemQuality[] itemQuals)
        {
            PassiveItem passiveItem = PickupObjectDatabase.GetRandomPassiveOfQualities(random, new List<int>(), itemQuals);

            return passiveItem;
        }

        public static void SpawnRandomGun(PickupObject.ItemQuality[] itemquals)
        {
            Vector2 spawnPosition = GameManager.Instance.PrimaryPlayer.CenterPosition;
            Vector2 spawnDirection = Vector2.down;
            float spawnForce = 0f;

            Gun gunToSpawn = GetRandomGunByQualities(itemquals);

            LootEngine.SpawnItem(gunToSpawn.gameObject, spawnPosition, spawnDirection, spawnForce);

            return;
        }

        public static void SpawnRandomPassive(PickupObject.ItemQuality[] itemquals)
        {
            Vector2 spawnPosition = GameManager.Instance.PrimaryPlayer.CenterPosition;
            Vector2 spawnDirection = Vector2.down;
            float spawnForce = 0f;

            PassiveItem passiveToSpawn = GetRandomPassiveByQualities(itemquals);

            LootEngine.SpawnItem(passiveToSpawn.gameObject, spawnPosition, spawnDirection, spawnForce);

            return;
        }
    }
}
