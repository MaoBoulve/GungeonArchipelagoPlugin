using System;
using System.Reflection;
using System.Linq;
using System.Text;
using UnityEngine;
using BepInEx;
using HarmonyLib;
using MonoMod.RuntimeDetour;
using ArchiGungeon.ModConsoleVisuals;
using Dungeonator;


namespace ArchiGungeon.EnemyHandlers
{
    class EnemySwapping : MonoBehaviour
    {
        private static float enemyDamageMult = 4.0f;

        public static void InitializeEnemySwapper()
        {
            ETGMod.AIActor.OnPreStart += OnActorPreStart;
            ETGMod.AIActor.OnPostStart += OnActorPostStart;
        }


        private static void OnActorPreStart(AIActor actor)
        {

            ArchipelagoGUI.ConsoleLog(actor.name);
            string currentID = actor.EnemyGuid;

            if(EnemyGuidDatabase.ShuffledEnemyGUIDs.ContainsKey(currentID))
            {
                
                string newID = EnemyGuidDatabase.ShuffledEnemyGUIDs[currentID];
                Vector2 spawnPos = actor.CenterPosition;
                RoomHandler roomHandler = actor.parentRoom;

                ArchipelagoGUI.ConsoleLog("Current: " + currentID);
                ArchipelagoGUI.ConsoleLog("Current: " + newID);

                actor.invisibleUntilAwaken = true;

                //actor.EnemyGuid = newID;

                //actor.Die

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

            AIActor.Spawn(enemyToSpawn, position, parentRoom);
            //enemyToSpawn.aiAnimator.EndAnimation();

            return;
        }

        public static void ResetEnemyDamageMult()
        {
            enemyDamageMult = 3.5f;
            return;
        }
        
        public static void ReduceEnemyDamageMult(int stepsToReduce)
        {
            enemyDamageMult = enemyDamageMult - ((float)stepsToReduce * 0.5f);

            if(enemyDamageMult < 1)
            {
                enemyDamageMult = 1.0f;
            }

            return;
        }

        private static void OnActorPostStart(AIActor actor)
        {
            string currentID = actor.EnemyGuid;

            if (EnemyGuidDatabase.ShuffledEnemyGUIDs.ContainsKey(currentID))
            {
                actor.EraseFromExistenceWithRewards(suppressDeathSounds: true);
            }

            return;
        }

    }
}
