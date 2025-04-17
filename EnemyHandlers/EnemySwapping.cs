using System;
using System.Reflection;
using System.Linq;
using System.Text;
using UnityEngine;
using BepInEx;
using HarmonyLib;
using MonoMod.RuntimeDetour;
using Dungeonator;
using System.Collections.Generic;
using ArchiGungeon.DebugTools;


namespace ArchiGungeon.EnemyHandlers
{
    class EnemySwapping : MonoBehaviour
    {
        private static Dictionary<string, string> ShuffledEnemyGUIDs { get; set; } = new Dictionary<string, string>();
        private static float enemyDamageMult = 4.0f;

        public static void InitializeEnemySwapper()
        {
            ETGMod.AIActor.OnPreStart += OnActorPreStart;
            ETGMod.AIActor.OnPostStart += OnActorPostStart;


        }

        public static void MakeNormalShuffleEnemies(int seed)
        {
            DebugPrint.DebugLog(DebugCategory.EnemyRandomization, $"Normal Enemy Shuffling with key: {seed}");
            ShuffledEnemyGUIDs = EnemyGuidDatabase.GetShuffledGUIDList(EnemyShuffleCategories.NormalDifficultyShuffle, seed);
            return;
        }

        public static void MakeDifficultShuffleEnemies(int seed)
        {
            DebugPrint.DebugLog(DebugCategory.EnemyRandomization, $"Difficult Enemy Shuffling with key: {seed}");
            ShuffledEnemyGUIDs = EnemyGuidDatabase.GetShuffledGUIDList(EnemyShuffleCategories.HardDifficultyShuffle, seed);
            return;
        }

        public static void MakeBossShuffle(int seed)
        {
            DebugPrint.DebugLog(DebugCategory.EnemyRandomization, $"Boss Shuffling with key: {seed}");
            return;
        }

        public static void ClearAllShuffleLists()
        {
            DebugPrint.DebugLog(DebugCategory.EnemyRandomization, "Resetting enemy randomization");

            ShuffledEnemyGUIDs.Clear();
            return;
        }

        private static void OnActorPreStart(AIActor actor)
        {

            DebugPrint.DebugLog(DebugCategory.EnemyRandomization, actor.name);
            string currentID = actor.EnemyGuid;

            if(ShuffledEnemyGUIDs.ContainsKey(currentID))
            {
                
                string newID = ShuffledEnemyGUIDs[currentID];
                Vector2 spawnPos = actor.CenterPosition;
                RoomHandler roomHandler = actor.parentRoom;

                DebugPrint.DebugLog(DebugCategory.EnemyRandomization, "Current: " + EnemyDatabase.GetOrLoadByGuid(currentID));
                DebugPrint.DebugLog(DebugCategory.EnemyRandomization, "Swapped to: " + EnemyDatabase.GetOrLoadByGuid(newID));

                actor.invisibleUntilAwaken = true;


                SpawnReplacementEnemy(newID, spawnPos, roomHandler);

            }

            return;
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
            //enemyToSpawn.HandleReinforcementFallIntoRoom(0.1f);

            enemyToSpawn.healthHaver.AllDamageMultiplier = enemyDamageMult;

            AIActor.Spawn(enemyToSpawn, position, parentRoom, correctForWalls: true);
            //enemyToSpawn.aiAnimator.EndAnimation();

            return;
        }

        public static void ResetEnemyDamageMult()
        {
            enemyDamageMult = 4.0f;

            DebugPrint.DebugLog(DebugCategory.EnemyRandomization, $"Enemy damage mult is: {enemyDamageMult}");
            return;
        }
        
        public static void ReduceEnemyDamageMult(int stepsToReduce)
        {
            enemyDamageMult = enemyDamageMult - ((float)stepsToReduce * 0.5f);

            if(enemyDamageMult < 1)
            {
                enemyDamageMult = 1.0f;
            }

            DebugPrint.DebugLog(DebugCategory.EnemyRandomization, $"Enemy damage mult is: {enemyDamageMult}");
            return;
        }

        private static void OnActorPostStart(AIActor actor)
        {
            string currentID = actor.EnemyGuid;

            if (ShuffledEnemyGUIDs.ContainsKey(currentID))
            {
                actor.EraseFromExistenceWithRewards(suppressDeathSounds: true);
            }

            return;
        }

    }
}
