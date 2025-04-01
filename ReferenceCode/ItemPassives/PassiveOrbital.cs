using Alexandria.ItemAPI;
using System.Collections.Generic;
using UnityEngine;

namespace ArchiGungeon.Passives
{
    public class PassiveOrbital: CustomOrbital
    {

        public static PlayerOrbital orbitalPrefab;
        public static PlayerOrbital upgradeOrbitalPrefab;


        public static void Register()
        {
            string itemName = "Jack Frost"; //The name of the item
            string resourceName = "ArchiGungeon/Resources/JackFrost.png"; //(inventory sprite) MAKE SURE TO CHANGE THE SPRITE PATH TO YOUR MOD'S RESOURCES.

            GameObject obj = new GameObject();
            var item = obj.AddComponent<PassiveOrbital>();
            ItemBuilder.AddSpriteToObject(itemName, resourceName, obj);

            string shortDesc = "In the Gun-hee-geon, ho!";
            string longDesc = "A mysterious creature from another world";

            ItemBuilder.SetupItem(item, shortDesc, longDesc, "bas");
            item.quality = PickupObject.ItemQuality.A;

            BuildPrefab();
            item.OrbitalPrefab = orbitalPrefab;
            BuildSynergyPrefab();

            item.HasAdvancedUpgradeSynergy = true; //Set this to true if you want a synergy that changes the appearance of the Guon Stone. All base game guons have a [colour]-er Guon Stone synergy that makes them bigger and brighter.
            item.AdvancedUpgradeSynergy = "Melted Frost"; //This is the name of the synergy that changes the appearance, if you have one.
            item.AdvancedUpgradeOrbitalPrefab = PassiveOrbital.upgradeOrbitalPrefab.gameObject;

            item.CreateMeltedFrostSynergy();

        }

        public static void BuildPrefab()
        {
            if (PassiveOrbital.orbitalPrefab != null) return;
            GameObject prefab = SpriteBuilder.SpriteFromResource("ArchiGungeon/Resources/JackFrost.png"); //(ingame orbital sprite)MAKE SURE TO CHANGE THE SPRITE PATH TO YOUR MODS RESOURCES
            prefab.name = "NakieFrost Guon Orbital"; //The name of the orbital used by the code. Barely ever used or seen, but important to change.
            var body = prefab.GetComponent<tk2dSprite>().SetUpSpeculativeRigidbody(IntVector2.Zero, new IntVector2(5, 9)); //This line sets up the hitbox of your guon, this one is set to 5 pixels across by 9 pixels high, but you can set it as big or small as you want your guon to be.           
            body.CollideWithTileMap = false;
            body.CollideWithOthers = true;
            body.PrimaryPixelCollider.CollisionLayer = CollisionLayer.EnemyBulletBlocker;

            orbitalPrefab = prefab.AddComponent<PlayerOrbital>();
            orbitalPrefab.motionStyle = PlayerOrbital.OrbitalMotionStyle.ORBIT_PLAYER_ALWAYS; //You can ignore most of this stuff, but I've commented on some of it.
            orbitalPrefab.shouldRotate = false; //This determines if the guon stone rotates. If set to true, the stone will rotate so that it always faces towards the player. Most Guons have this set to false, and you probably should too unless you have a good reason for changing it.
            orbitalPrefab.orbitRadius = 2.5f; //This determines how far away from you the guon orbits. The default for most guons is 2.5.
            orbitalPrefab.orbitDegreesPerSecond = 120f; //This determines how many degrees of rotation the guon travels per second. The default for most guons is 120.
            //orbitalPrefab.perfectOrbitalFactor = 0f; //This determines how fast guons will move to catch up with their owner (regular guons have it set to 0 so they lag behind). You can probably ignore this unless you want or need your guon to stick super strictly to it's orbit.
            orbitalPrefab.perfectOrbitalFactor = 5f;
            orbitalPrefab.SetOrbitalTier(0);

            GameObject.DontDestroyOnLoad(prefab);
            FakePrefab.MarkAsFakePrefab(prefab);
            prefab.SetActive(false);
        }
        public static void BuildSynergyPrefab()
        {
            bool flag = PassiveOrbital.upgradeOrbitalPrefab == null;
            if (flag)
            {
                GameObject gameObject = SpriteBuilder.SpriteFromResource("ArchiGungeon/Resources/NakedFrostSmall.png", null); //(The orbital appearance with it's special synergy) MAKE SURE TO CHANGE THE SPRITE PATH TO YOUR OWN MODS
                gameObject.name = "NakieFrost Orbital Synergy Form";
                SpeculativeRigidbody speculativeRigidbody = gameObject.GetComponent<tk2dSprite>().SetUpSpeculativeRigidbody(IntVector2.Zero, new IntVector2(9, 13));
                PassiveOrbital.upgradeOrbitalPrefab = gameObject.AddComponent<PlayerOrbital>();
                speculativeRigidbody.CollideWithTileMap = false;
                speculativeRigidbody.CollideWithOthers = true;
                speculativeRigidbody.PrimaryPixelCollider.CollisionLayer = CollisionLayer.EnemyBulletBlocker;
                PassiveOrbital.upgradeOrbitalPrefab.shouldRotate = false; //Determines if your guon rotates with it's special synergy
                PassiveOrbital.upgradeOrbitalPrefab.orbitRadius = 2.5f; //Determines how far your guon orbits with it's special synergy
                PassiveOrbital.upgradeOrbitalPrefab.orbitDegreesPerSecond = 120f; //Determines how fast your guon orbits with it's special synergy
                PassiveOrbital.upgradeOrbitalPrefab.perfectOrbitalFactor = 10f; //Determines how fast your guon will move to catch up with its owner with it's special synergy. By default, even though the regular guons have it at 0, the upgraded synergy guons all have a higher perfectOrbitalFactor. I find 10 to be about the same.
                PassiveOrbital.upgradeOrbitalPrefab.SetOrbitalTier(0);
                UnityEngine.Object.DontDestroyOnLoad(gameObject);
                FakePrefab.MarkAsFakePrefab(gameObject);
                gameObject.SetActive(false);
            }
        }

        private void CreateMeltedFrostSynergy()
        {
            List<string> mandatorySynergyConsoleIDs = new List<string>
            {
                "hot_lead",
                "bas:jack_frost"
            };
            List<string> optionalSynergyConsoleIDs = new List<string>
            {
            };

            CustomSynergies.Add("Melted Frost", mandatorySynergyConsoleIDs, optionalSynergyConsoleIDs, true);
        }
        public override void Update()
        {
            base.Update();
        }
        public override void Pickup(PlayerController player)
        {
            base.Pickup(player);
        }
        public override DebrisObject Drop(PlayerController player)
        {
            return base.Drop(player);
        }
        public override void OnDestroy()
        {
            base.OnDestroy();
        }


    }
}
