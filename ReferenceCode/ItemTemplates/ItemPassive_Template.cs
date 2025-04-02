using Alexandria.ItemAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace ArchiGungeon.ItemTemplates
{
    public class ItemPassive_Template: PassiveItem
    {
        private static string passiveName = "Basil";
        private static string spriteDirectory = "ArchiGungeon/Resources/bulba.png";

        private static string shortDesc = "short desc";
        private static string longDesc = "long desc";
        public static void Register()
        {
            GameObject obj = new GameObject(passiveName);
            var item = obj.AddComponent<ItemPassive_Template>();
            ItemBuilder.AddSpriteToObject(passiveName, spriteDirectory, obj);

            ItemBuilder.SetupItem(item, shortDesc, longDesc, "[general item prefix");


            // Define item properties
            ItemBuilder.AddPassiveStatModifier(item, PlayerStats.StatType.Health, 5, StatModifier.ModifyMethod.ADDITIVE);
            ItemBuilder.AddPassiveStatModifier(item, PlayerStats.StatType.Damage, 1.5f, StatModifier.ModifyMethod.MULTIPLICATIVE);

            item.quality = PickupObject.ItemQuality.S;
        }

        public override void Pickup(PlayerController player)
        {
            base.Pickup(player);

            return;
        }

        public override DebrisObject Drop(PlayerController player)
        {
            return base.Drop(player);
        }
    }
}
