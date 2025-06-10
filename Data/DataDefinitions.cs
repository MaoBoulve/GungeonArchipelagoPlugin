using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArchiGungeon.Data
{
    #region Save Data Definitions
    public enum PlayerCompletionGoals
    {
        Dragun,
        Lich,
        PastsBase,
        PastsFull,
        SecretChamber,
        AdvancedGungeon,
        FarewellArms,
    }

    public enum SaveCountStats
    {
        // public readonly int location_check_initial_ID = 8755000;
        ChestsOpened,
        RoomPoints,
        CashSpent,

        BlobulordKills,
        OldKingKills,
        RatKills,
        DeptAgunimKills,
        AdvancedDragunKills,
        DragunKills,
        LichKills,

        Floor1Clears,
        Floor2Clears,
        Floor3Clears,
        Floor4Clears,
        Floor5Clears,
        FloorHellClears,
        FloorGoopClears,
        FloorAbbeyClears,
        FloorRatClears,
        FloorDeptClears,

        PastMarine,
        PastConvict,
        PastPilot,
        PastHunter,
        PastRobot,
        PastBullet,
        PastKills
    }
    #endregion

    #region Randomizer Settings
    public enum EnemyShuffleCategories
    {
        NormalDifficultyShuffle,
        HardDifficultyShuffle,
        BossShuffle
    }
    #endregion

    #region Server Data Definitions
    public struct CountGoalServerKeys
    {
        public string CountKey;

        public CountGoalServerKeys(string countKey)
        {
            CountKey = countKey;
            return;
        }
    }

    public struct PlayerConnectionInfo
    {
        public string IP;
        public string Port;
        public string PlayerName;
        public string Password;

        public PlayerConnectionInfo(string IPstring, string portString, string playerNameString, string password = "")
        {
            IP = IPstring;
            Port = portString;
            PlayerName = playerNameString;
            Password = password;
            return;
        }
    }
    #endregion

    #region Debug Data Definitions
    public enum DebugCategory
    {
        PluginStartup,
        PlayerEventListener,
        LocalSaveData,
        ServerReceive,
        ServerSend,
        CountingGoal,
        EnemyRandomization,
        InitializingGameState,
        ItemHandling,
        TrapHandling,
        UserInterface,
        GameCompletion,
        CharacterSystems
    }

    public enum AvailableDebugCMD
    {
        SpawnAPItem,
        SendDeathlink,
        ReceiveDeathlink,
        AddChest,
        Add1RoomPoint,
        Add100CashSpent,
        Speedrun,
        FullDebug,
        NoDebug,
        LoadFloor1,
        LoadFloor2,
        LoadFloor3,
        LoadFloor4,
        LoadFloor5,
        LoadHell,
        LoadSewers,
        LoadAbbey,
        LoadRat,
        LoadDept,
        PastMarine,
        PastConvict,
        PastHunter,
        PastPilot,
        PastRobot,
        PastBullet,
        PastGunslinger,
        PastCoop,
        ReceiveItem
    }

    #endregion
}
