using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Alexandria.ItemAPI;
using Alexandria.Misc;


namespace ArchiGungeon
{
    public class PassiveBasil: PassiveItem
    {

        public static void Register()
        {
            string itemName = "Basil";
            string SpriteDirectory = "ArchiGungeon/Resources/bulba.png";

            GameObject obj = new GameObject(itemName);
            var item = obj.AddComponent<PassiveBasil>();
            ItemBuilder.AddSpriteToObject(itemName, SpriteDirectory, obj);

            string shortDesc = "Basil gaoooo!!";
            string longDesc = "You ever think about how Pokemon aren't shown eating meat but eat berries? Is that Grass-type violence";


            ItemBuilder.SetupItem(item, shortDesc, longDesc, "bas");

            ETGModConsole.Log($"Encountered {itemName} count: {GameStatsManager.Instance.m_encounteredTrackables[itemName].encounterCount}");

            ItemBuilder.AddPassiveStatModifier(item, PlayerStats.StatType.Health, 5, StatModifier.ModifyMethod.ADDITIVE);
            ItemBuilder.AddPassiveStatModifier(item, PlayerStats.StatType.Damage, 1.5f, StatModifier.ModifyMethod.MULTIPLICATIVE);


            item.quality = PickupObject.ItemQuality.S;
        }

        public override void Pickup(PlayerController player)
        {
            base.Pickup(player);

            ETGModConsole.Log($"Encountered {"Basil"} count: {GameStatsManager.Instance.m_encounteredTrackables["Basil"].encounterCount}");
            return;
        }

        public override DebrisObject Drop(PlayerController player)
        {
            return base.Drop(player);
        }

    }
}
