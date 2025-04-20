using Alexandria.ItemAPI;
using ArchiGungeon.ArchipelagoServer;
using Alexandria.SoundAPI;
using ArchiGungeon.ModConsoleVisuals;
using System;
using ArchiGungeon.DebugTools;
using static UnityEngine.UI.GridLayoutGroup;

namespace ArchiGungeon
{
    // https://github.com/Neighborin0/Updated-Gun-API-/blob/master/BasicGun.cs

    public class Archipelagun : GunBehaviour
    {
        public static int SpawnItemID = -1;
        private static bool canBeWielded = true;
        private static PlayerController playerWithArchipelagun;
        private static int equippedslot = -1;

        private static string itemName = "Archipelagun";

        private static string shortDesc = "Fire to open menu";
        private static string longDesc = "Does no damage. A hop away to other worlds. Fire to open the main mod menu.";

        public static void Register()
        {
            // Instance base gun

            Gun gun = ETGMod.Databases.Items.NewGun(itemName, "archipelagun"); // based off pea gun
            gun.gameObject.AddComponent<Archipelagun>();

            gun.SetupSprite(null, "archipelagun_idle_001", 4);

            
            // Load dart gun from JSON dump

            gun.AddProjectileModuleFrom("dart_gun", true, false);

            // Parameters
            gun.quality = PickupObject.ItemQuality.EXCLUDED;

            gun.DefaultModule.ammoCost = 1;
            gun.reloadTime = 4f;
            gun.DefaultModule.numberOfShotsInClip = 9999;
            gun.LocalInfiniteAmmo = true;
            gun.DefaultModule.cooldownTime = 2f;
            gun.doesScreenShake = false;

            gun.CanBeDropped = false;
            gun.CanBeSold = false;
            gun.ShouldBeExcludedFromShops = true;
            gun.RespawnsIfPitfall = true;
            gun.IgnoredByRat = true;


            // AUDIO
            gun.gunSwitchGroup = $"{ArchipelaGunPlugin.MOD_ITEM_PREFIX}_{itemName}";
            SoundManager.AddCustomSwitchData("WPN_Guns", gun.gunSwitchGroup, "Play_WPN_Gun_Shot_01",
                                "Play_WPN_radgun_noice_01");
            SoundManager.AddCustomSwitchData("WPN_Guns", gun.gunSwitchGroup, "Play_WPN_Gun_Reload_01",
                                            "Play_WPN_LowerCaseR_Magical_Kadabra_01");

            // projectile setup -- need to setup or causes a compile error
            Projectile projectile = UnityEngine.Object.Instantiate<Projectile>(gun.DefaultModule.projectiles[0]);
            projectile.gameObject.SetActive(false);
            FakePrefab.MarkAsFakePrefab(projectile.gameObject);
            UnityEngine.Object.DontDestroyOnLoad(projectile);
            gun.DefaultModule.projectiles[0] = projectile;

            //projectile.baseData allows you to modify the base properties of your projectile module.
            projectile.baseData.damage = 0f;
            projectile.baseData.speed = 1.7f;
            projectile.baseData.range = 0f;
            projectile.baseData.force = 0f;

            ItemBuilder.SetupItem(gun, shortDesc, longDesc, "bas");
            SpawnItemID = PickupObjectDatabase.GetId(gun);

            // ArchipelagoGUI.ConsoleLog($"{gun} + {gun.name} + {gun.PickupObjectId}");

            return;
        }


        public override void OnPlayerPickup(PlayerController playerOwner)
        {
            canBeWielded = true;
            playerWithArchipelagun = playerOwner;
            equippedslot = playerWithArchipelagun.inventory.AllGuns.IndexOf(playerWithArchipelagun.inventory.CurrentGun);

            ArchDebugPrint.DebugLog(DebugCategory.PlayerEventListener, $"Archipelagun is in slot {equippedslot}");

            playerWithArchipelagun.OnReloadPressed += OnReloadPressed;
            playerWithArchipelagun.OnEnteredCombat += OnEnterCombat;
            playerWithArchipelagun.OnRoomClearEvent += OnRoomClear;

            // ArchipelagoGUI.ConsoleLog("Player pickup");

            // TODO, auto connect to archipelago


        }

        private void OnRoomClear(PlayerController controller)
        {
            canBeWielded = true;
        }

        private void OnEnterCombat()
        {
            canBeWielded = false;

            if(playerWithArchipelagun.CurrentGun.ToString().Contains("archipelagun"))
            {
                ArchDebugPrint.DebugLog(DebugCategory.PlayerEventListener, $"Forcing swap to starter gun");
                playerWithArchipelagun.ChangeToGunSlot(0);
            }

            return;
        }

        private void OnReloadPressed(PlayerController controller, Gun gun)
        {
            return;
        }

        public override void OnSwitchedToPlayer(PlayerController owner, GunInventory inventory, Gun oldGun, bool isNewGun)
        {
            //ArchipelagoGUI.ConsoleLog("Switched to");

            if(canBeWielded == false)
            {
                owner.ChangeToGunSlot(inventory.AllGuns.IndexOf(oldGun));
            }

            return;
        }

        // open archipelago menu on firing gun

        public override void OnPostFired(PlayerController player, Gun gun)
        {

            //ArchipelagoGUI.ConsoleLog("Gun post fire");

            if (player.IsInCombat == true)
            {
                return;
            }
            ArchipelagoGUI.Instance?.OnOpen();


            return;
        }


        public override void OnReloadedPlayer(PlayerController owner, Gun gun)
        {
            //base.OnReloadedPlayer(owner, gun);
            //ArchipelagoGUI.ConsoleLog("Reload");
            //ArchipelagoGungeonBridge.DeathlinkKillPlayer();
        }
    }
}
