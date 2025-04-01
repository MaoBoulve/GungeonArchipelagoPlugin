using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Alexandria.ItemAPI;
using UnityEngine;

namespace ArchiGungeon
{
    public class ActiveChorpi: PlayerItem
    {
        public static void Register()
        {
            string itemName = "Chorpi";
            string SpriteDirectory = "ArchiGungeon/Resources/chorpi.png";

            GameObject obj = new GameObject(itemName);
            var item = obj.AddComponent<ActiveChorpi>();
            ItemBuilder.AddSpriteToObject(itemName, SpriteDirectory, obj);

            string shortDesc = "Can you pea-lieve it?";
            string longDesc = "PEA, UP!!";


            ItemBuilder.SetupItem(item, shortDesc, longDesc, "bas");
            ItemBuilder.SetCooldownType(item, ItemBuilder.CooldownType.None, 0f);

            

            item.quality = PickupObject.ItemQuality.S;
            item.consumable = false;
        }

        public override void Pickup(PlayerController player)
        {
            base.Pickup(player);
        }

        public override void DoEffect(PlayerController user)
        {
            Vector2 spawnPosition = user.CenterPosition;

            user.healthHaver.ApplyHealing(-0.5f);

            GameObject peaGun = PickupObjectDatabase.GetById(197).gameObject;
            LootEngine.SpawnItem(peaGun, user.CenterPosition, Vector2.zero, 0);

            user.carriedConsumables.Currency += 15;

            return;
        }

        public override bool CanBeUsed(PlayerController user)
        {
            return user.healthHaver.GetCurrentHealth() > .5f;
        }
    }
}
