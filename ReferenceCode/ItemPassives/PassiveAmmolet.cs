using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Alexandria.ItemAPI;

namespace ArchiGungeon
{
    class PassiveAmmolet: CustomBlankModItem
    {
        private static bool canSpawnBlank;

        public static void Register()
        {
            string itemName = "Blankie";
            string SpriteDirectory = "ArchiGungeon/Resources/example_item_sprite.png";

            GameObject obj = new GameObject(itemName);
            var item = obj.AddComponent<PassiveAmmolet>();
            ItemBuilder.AddSpriteToObject(itemName, SpriteDirectory, obj);

            string shortDesc = "Blankie McBlank Face";
            string longDesc = "What if blanks could blank its own blank?";


            ItemBuilder.SetupItem(item, shortDesc, longDesc, "bas");

            ItemBuilder.AddPassiveStatModifier(item, PlayerStats.StatType.AdditionalBlanksPerFloor, 1, StatModifier.ModifyMethod.ADDITIVE);

            item.quality = PickupObject.ItemQuality.S;
        }


        public override void Pickup(PlayerController player)
        {
            base.Pickup(player);
        }

        public override DebrisObject Drop(PlayerController player)
        {
            return base.Drop(player);
        }

        protected override void OnBlank(SilencerInstance silencerInstance, Vector2 centerPoint, PlayerController user)
        {
            // base.OnBlank(silencerInstance, centerPoint, user);

            if (canSpawnBlank)
            {
                GameObject freeBlank = PickupObjectDatabase.GetById(224).gameObject;
                LootEngine.SpawnItem(freeBlank, user.CenterPosition, Vector2.zero, 0);

                canSpawnBlank = false;
            }

            else
            {
                canSpawnBlank = true;
            }

            return;
        }

    }
}
