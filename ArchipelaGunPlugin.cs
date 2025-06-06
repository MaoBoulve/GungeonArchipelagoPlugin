﻿using ArchiGungeon.ArchipelagoServer;
using ArchiGungeon.ItemArchipelago;
using ArchiGungeon.ModConsoleVisuals;
using ArchiGungeon.GungeonEventHandlers;
using ArchiGungeon.EnemyHandlers;
using ArchiGungeon.DebugTools;
using BepInEx;
using UnityEngine;

namespace ArchiGungeon
{
    [BepInDependency(Alexandria.Alexandria.GUID)] // this mod depends on the Alexandria API: https://enter-the-gungeon.thunderstore.io/package/Alexandria/Alexandria/
    [BepInDependency(ETGModMainBehaviour.GUID)]
    [BepInPlugin(GUID, NAME, VERSION)]
    
    ///<summary>
    /// Class <c>ArchipelaGunPlugin</c> Main plugin class called by BepInEx to initialize all behavior
    ///</summary>
    public class ArchipelaGunPlugin : BaseUnityPlugin
    {
        public const string GUID = "maoboulve.etg.archipelagogungeon";
        public const string NAME = "Archipelago Gungeon Randomizer";
        public const string VERSION = "0.0.8";
        public const string TEXT_COLOR = "#B6FFB8";

        public const string MOD_ITEM_PREFIX = "arch";

        public static ArchipelagoGUI ArchipelagoModMenu { get; protected set; }
        public static GungeonPlayerEventListener PlayerListener { get; protected set; }
        private static bool isInit = false;


        public void Start()
        {
            ArchDebugPrint.DebugLog(DebugCategory.PluginStartup, "Starting ArchipelaGunPlugin");

            InitExceptionCatcher();
            ETGModMainBehaviour.WaitForGameManagerStart(GMStart);
            
        }

        private void InitExceptionCatcher()
        {
            ArchDebugPrint.ClearDebugLog();
            ArchDebugPrint.DebugLog(DebugCategory.PluginStartup, "Init Exception Catcher");
            Application.logMessageReceived += ArchDebugPrint.OnCatchException;
        }

        public void GMStart(GameManager g)
        {
            ArchDebugPrint.DebugLog(DebugCategory.PluginStartup, "GameManager started");

            InitItemHooks();
            RegisterItems();
            InitEnemyHooks();
            InitModMenu();
            

            Log($"{NAME} v{VERSION} started successfully.", TEXT_COLOR);
            isInit = true;

            StartPostInitializationSetup();

            return;
        }

        private void InitItemHooks()
        {
            //CustomBlankModItem.InitHooks();
        }

        private void RegisterItems()
        {
            Archipelagun.Register();
            APPickUpItem.RegisterItemBase();
        }

        private void InitEnemyHooks()
        {
            EnemySwapping.InitializeEnemySwapper();
        }

        private void InitModMenu()
        {
            ArchipelagoModMenu = new ArchipelagoGUI();
            ArchipelagoModMenu.Start();
        }

        // Setup functions after instancing all needed functions to prevent missing reference runtime errors
        private void StartPostInitializationSetup()
        {
            StartGungeonPlayerListener();

            // Print all directories BepInEx will allow
            LocalSaveDataHandler.TDD_PrintAllPathsDirectory();

            return;
        }

        private void StartGungeonPlayerListener()
        {
            GungeonPlayerEventListener.StartSystemEventListens();
            return;
        }

        private static void Log(string text, string color="#FFFFFF")
        {
            ETGModConsole.Log($"<color={color}>{text}</color>");
        }

        public void Update()
        {   
            if ( !isInit )
            {
                return;
            }

            ArchipelagoModMenu.Update();
            SessionHandler.Update();

            return;
        }
    }
}
