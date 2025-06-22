using System;
using UnityEngine;
using Dungeonator;
using System.Collections.Generic;
using ArchiGungeon.DebugTools;
using ArchiGungeon.Data;


namespace ArchiGungeon.EnemyHandlers
{
    class EnemySwapping : MonoBehaviour
    {
        private static Dictionary<string, string> ShuffledEnemyGUIDs { get; set; } = new Dictionary<string, string>();
        private static float enemyDamageMult = 4.0f;
        private static int enemiesToShufflePerRoom = 15;
        private static int currentShuffleCount = 0;
        private static List<AIActor> actorsValidForShuffling = new List<AIActor>();

        #region Enemy GUID Shuffling
        public static void InitializeEnemySwapper()
        {
            ArchDebugPrint.DebugLog(DebugCategory.PluginStartup, "Starting Enemy Swapper");
            ETGMod.AIActor.OnPreStart += OnActorPreStart;
            ETGMod.AIActor.OnPostStart += OnActorPostStart;
        }

        public static void MakeNormalShuffleEnemies(int seed)
        {
            ArchDebugPrint.DebugLog(DebugCategory.EnemyRandomization, $"Normal Enemy Shuffling with key: {seed}");
            ShuffledEnemyGUIDs = EnemyGuidDatabase.GetShuffledGUIDList(EnemyShuffleCategories.NormalDifficultyShuffle, seed);
            return;
        }

        public static void MakeDifficultShuffleEnemies(int seed)
        {
            ArchDebugPrint.DebugLog(DebugCategory.EnemyRandomization, $"Difficult Enemy Shuffling with key: {seed}");
            ShuffledEnemyGUIDs = EnemyGuidDatabase.GetShuffledGUIDList(EnemyShuffleCategories.HardDifficultyShuffle, seed);
            return;
        }

        public static void MakeBossShuffle(int seed)
        {
            ArchDebugPrint.DebugLog(DebugCategory.EnemyRandomization, $"Boss Shuffling with key: {seed}");
            return;
        }

        public static void ClearAllShuffleLists()
        {
            ArchDebugPrint.DebugLog(DebugCategory.EnemyRandomization, "Resetting enemy randomization");

            ShuffledEnemyGUIDs.Clear();
            return;
        }
        #endregion

        #region Enemy Spawn Handling
        private static void OnActorPreStart(AIActor actor)
        {
            if(currentShuffleCount > enemiesToShufflePerRoom)
            {
                return;
            }

            actorsValidForShuffling.Add(actor);
            CheckToShuffleEnemySpawn(actor);

            return;
        }

        public static void ResetShuffleCountOnRoomClear()
        {
            currentShuffleCount = 0;
        }

        private static void CheckToShuffleEnemySpawn(AIActor actor)
        {
            ArchDebugPrint.DebugLog(DebugCategory.EnemyRandomization, actor.name);
            string currentID = actor.EnemyGuid;

            if (ShuffledEnemyGUIDs.ContainsKey(currentID))
            {
                currentShuffleCount++;
                string newID = ShuffledEnemyGUIDs[currentID];
                Vector2 spawnPos = actor.CenterPosition;
                RoomHandler roomHandler = actor.parentRoom;

                ArchDebugPrint.DebugLog(DebugCategory.EnemyRandomization, "Current: " + EnemyDatabase.GetOrLoadByGuid(currentID));
                ArchDebugPrint.DebugLog(DebugCategory.EnemyRandomization, "Swapped to: " + EnemyDatabase.GetOrLoadByGuid(newID));

                actor.invisibleUntilAwaken = true;


                SpawnReplacementEnemy(newID, spawnPos, roomHandler);

            }
        }

        private static void SpawnReplacementEnemy(string enemyID, Vector2 position, RoomHandler parentRoom)
        {
            
            AIActor enemyToSpawn = EnemyDatabase.GetOrLoadByGuid(enemyID);

            if(enemyToSpawn == null)
            {
                return;
            }

            enemyToSpawn.EnemyGuid = "SWAP_" + enemyToSpawn.EnemyGuid;
            enemyToSpawn.HasDonePlayerEnterCheck = true;
            enemyToSpawn.IsInReinforcementLayer = true;
            enemyToSpawn.reinforceType = (AIActor.ReinforceType)2;
            enemyToSpawn.HandleReinforcementFallIntoRoom(0.5f);

            enemyToSpawn.healthHaver.AllDamageMultiplier = enemyDamageMult;

            AIActor.Spawn(enemyToSpawn, position, parentRoom, correctForWalls: true);
            //enemyToSpawn.aiAnimator.EndAnimation();

            return;
        }

        public static void ResetEnemyDamageMult()
        {
            enemyDamageMult = 4.0f;

            ArchDebugPrint.DebugLog(DebugCategory.EnemyRandomization, $"Enemy damage mult is: {enemyDamageMult}");
            return;
        }
        
        public static void ReduceEnemyDamageMult(int stepsToReduce)
        {
            enemyDamageMult = enemyDamageMult - ((float)stepsToReduce * 0.25f);

            if(enemyDamageMult < 1)
            {
                enemyDamageMult = 1.0f;
            }

            ArchDebugPrint.DebugLog(DebugCategory.EnemyRandomization, $"Enemy damage mult is: {enemyDamageMult}");
            return;
        }


        private static void OnActorPostStart(AIActor actor)
        {
            
            if(!actorsValidForShuffling.Contains(actor))
            {
                return;
            }

            actorsValidForShuffling.Remove(actor);
            string currentID = actor.EnemyGuid;

            if (ShuffledEnemyGUIDs.ContainsKey(currentID))
            {
                actor.EraseFromExistenceWithRewards(suppressDeathSounds: true);
            }

            return;
        }

        #endregion
    }
}
