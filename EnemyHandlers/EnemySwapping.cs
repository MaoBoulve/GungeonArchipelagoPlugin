using System;
using System.Reflection;
using System.Linq;
using System.Text;
using UnityEngine;
using BepInEx;
using HarmonyLib;
using MonoMod.RuntimeDetour;

namespace ArchiGungeon.EnemyHandlers
{
    class EnemySwapping : MonoBehaviour
    {

        public static void InitializeEnemySwapper()
        {
            ETGMod.AIActor.OnPreStart += OnActorPreStart;
        }

        private static void OnActorPreStart(AIActor actor)
        {
            string currentID = actor.EnemyGuid;

            if(EnemyGuidDatabase.ShuffledEnemyGUIDs.ContainsKey(currentID))
            {
                string newID = EnemyGuidDatabase.ShuffledEnemyGUIDs[currentID];
                actor.EnemyGuid = newID;
            }

            return;
        }

    }
}
