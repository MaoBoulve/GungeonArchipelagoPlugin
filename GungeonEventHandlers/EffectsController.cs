using UnityEngine;

namespace ArchiGungeon.GungeonEventHandlers
{
    class EffectsController
    {
        public static void PlayCurseVFX()
        {
            PlayerController playerToSpawnOn = GungeonPlayerEventListener.GetFirstAlivePlayer();

            if (playerToSpawnOn != null)
            {
                playerToSpawnOn.PlayEffectOnActor(ResourceCache.Acquire("Global VFX/VFX_Curse") as GameObject, Vector3.zero);
                return;
            }

            return;
        }

        public static void PlaySynergyVFX()
        {
            PlayerController playerToSpawnOn = GungeonPlayerEventListener.GetFirstAlivePlayer();

            if (playerToSpawnOn != null)
            {
                playerToSpawnOn.PlayEffectOnActor(ResourceCache.Acquire("Global VFX/VFX_Synergy") as GameObject, Vector3.zero);
                return;
            }
                
            return;
        }

        public static void PlayTestVFX()
        {
            LootEngine.DoDefaultPurplePoof(Vector2.zero);
        }
    }
}
