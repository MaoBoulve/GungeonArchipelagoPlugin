using Alexandria.ItemAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace ArchiGungeon.ItemTemplates
{
    public class ItemActive_Template: PlayerItem
    {
        private static string passiveName = "Basil";
        private static string spriteDirectory = "ArchiGungeon/Resources/bulba.png";

        private static string shortDesc = "short desc";
        private static string longDesc = "long desc";
        public static void Register()
        {
            GameObject obj = new GameObject(passiveName);
            var item = obj.AddComponent<ItemActive_Template>();
            ItemBuilder.AddSpriteToObject(passiveName, spriteDirectory, obj);

            ItemBuilder.SetupItem(item, shortDesc, longDesc, "[general item prefix");



            // Define item properties
            ItemBuilder.SetCooldownType(item, ItemBuilder.CooldownType.None, 0f);

            item.consumable = false;
            item.quality = PickupObject.ItemQuality.S;
        }

        public override void Pickup(PlayerController player)
        {
            base.Pickup(player);
        }

        public override void DoEffect(PlayerController user)
        {
            user.healthHaver.ApplyHealing(-0.5f);
            return;
        }

        public override bool CanBeUsed(PlayerController user)
        {
            return user.healthHaver.GetCurrentHealth() > .5f;
        }
    }
}
