using Alexandria.ItemAPI;
using Alexandria.SoundAPI;


namespace ArchiGungeon.ItemTemplates
{
    // https://github.com/Neighborin0/Updated-Gun-API-/blob/master/BasicGun.cs

    public class ItemGun_Template : GunBehaviour
    {
        public static int SpawnItemID = -1;

        private static string gunName = "Gun Name";
        private static string itemCodeName = "item_codename";
        private static string shortDesc = "short description";
        private static string longDesc = "long desc TKTKTK";

        public static void Register()
        {
            // itemCodeName is used for console commands and for all sprites
            // All sprites must begin with the same word as the codename. For example, your firing sprite would be named "item_codename_001".

            Gun gun = ETGMod.Databases.Items.NewGun(gunName, itemCodeName); // based off pea gun
            gun.gameObject.AddComponent<Archipelagun>();

            gun.SetupSprite(null, "archipelagun_idle_001", 4);

            // Every modded gun has base projectile it works with that is borrowed from other guns in the game. 
            // The gun names are the names from the JSON dump! While most are the same, some guns named completely different things. If you need help finding gun names, ask a modder on the Gungeon discord.

            // general parameters
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

            // projectile handling

            gun.AddProjectileModuleFrom("dart_gun", true, false);
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

            // AUDIO
            gun.gunSwitchGroup = $"[general item prefix]_{gunName}";
            SoundManager.AddCustomSwitchData("WPN_Guns", gun.gunSwitchGroup, "Play_WPN_Gun_Shot_01",
                                "Play_WPN_radgun_noice_01");
            SoundManager.AddCustomSwitchData("WPN_Guns", gun.gunSwitchGroup, "Play_WPN_Gun_Reload_01",
                                            "Play_WPN_LowerCaseR_Magical_Kadabra_01");

            ItemBuilder.SetupItem(gun, shortDesc, longDesc, "[general item prefix]");
            SpawnItemID = PickupObjectDatabase.GetId(gun);

        }


        public override void OnPlayerPickup(PlayerController playerOwner)
        {
            return;

        }

        public override void OnSwitchedToPlayer(PlayerController owner, GunInventory inventory, Gun oldGun, bool isNewGun)
        {

            return;
        }

        public override Projectile OnPreFireProjectileModifier(Gun gun, Projectile projectile, ProjectileModule module)
        {

            return projectile;
        }


        public override void OnPostFired(PlayerController player, Gun gun)
        {


            return;
        }


        public override void OnReloadedPlayer(PlayerController owner, Gun gun)
        {
            return;
        }
    }
}
