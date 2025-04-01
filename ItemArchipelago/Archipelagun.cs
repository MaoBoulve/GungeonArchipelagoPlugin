using Alexandria.ItemAPI;
using ArchiGungeon.Archipelago;
using Alexandria.SoundAPI;

namespace ArchiGungeon
{
    // https://github.com/Neighborin0/Updated-Gun-API-/blob/master/BasicGun.cs

    public class Archipelagun : GunBehaviour
    {
        public static int SpawnItemID = -1;

        private static string itemName = "Archipelagun";

        private static string shortDesc = "Fire - menu, Reload - reconnect";
        private static string longDesc = "long desc TKTKTK";

        public static void Register()
        {
            // Get yourself a new gun "base" first.
            // Let's just call it "Basic Gun", and use "jpxfrd" for all sprites and as "codename" All sprites must begin with the same word as the codename. For example, your firing sprite would be named "jpxfrd_fire_001".
            Gun gun = ETGMod.Databases.Items.NewGun(itemName, "archipelagun"); // based off pea gun
            gun.gameObject.AddComponent<Archipelagun>();

            gun.SetupSprite(null, "archipelagun_idle_001", 4);

            
            // Every modded gun has base projectile it works with that is borrowed from other guns in the game. 
            // The gun names are the names from the JSON dump! While most are the same, some guns named completely different things. If you need help finding gun names, ask a modder on the Gungeon discord.
            
            gun.AddProjectileModuleFrom("dart_gun", true, false);

            gun.quality = PickupObject.ItemQuality.EXCLUDED;

            gun.DefaultModule.ammoCost = 1;
            gun.reloadTime = 4f;
            gun.DefaultModule.numberOfShotsInClip = 9999;
            gun.LocalInfiniteAmmo = true;
            gun.DefaultModule.cooldownTime = 2f;
            gun.doesScreenShake = false;
            

            // AUDIO
            gun.gunSwitchGroup = $"{ArchipelaGunPlugin.MOD_ITEM_PREFIX}_{itemName}";
            SoundManager.AddCustomSwitchData("WPN_Guns", gun.gunSwitchGroup, "Play_WPN_Gun_Shot_01",
                                "Play_WPN_radgun_noice_01");
            SoundManager.AddCustomSwitchData("WPN_Guns", gun.gunSwitchGroup, "Play_WPN_Gun_Reload_01",
                                            "Play_WPN_LowerCaseR_Magical_Kadabra_01");

            gun.CanBeDropped = false;
            gun.CanBeSold = false;
            gun.ShouldBeExcludedFromShops = true;
            gun.RespawnsIfPitfall = true;
            gun.IgnoredByRat = true;

            // projectile setup
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

            ArchipelagoGUI.ConsoleLog($"{gun} + {gun.name} + {gun.PickupObjectId}");

            return;
        }


        public override void OnPlayerPickup(PlayerController playerOwner)
        {

            // ArchipelagoGUI.ConsoleLog("Player pickup");

            // TODO, auto connect to archipelago


        }

        public override void OnSwitchedToPlayer(PlayerController owner, GunInventory inventory, Gun oldGun, bool isNewGun)
        {
            ArchipelagoGUI.ConsoleLog("Switched to");

            return;
        }

        // open archipelago menu on firing gun
        public override Projectile OnPreFireProjectileModifier(Gun gun, Projectile projectile, ProjectileModule module)
        {

            //ArchipelagoGUI.ConsoleLog("Gun pre fire");

            return projectile;
        }


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
            ArchipelagoGUI.ConsoleLog("Reload");
            ArchipelagoGungeonBridge.DeathlinkKillPlayer();
        }
    }
}
