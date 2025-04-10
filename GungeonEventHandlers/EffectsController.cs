using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace ArchiGungeon.GungeonEventHandlers
{
    class EffectsController
    {
        public static void PlayCurseVFX()
        {
            GungeonPlayerEventListener.Player.PlayEffectOnActor(ResourceCache.Acquire("Global VFX/VFX_Curse") as GameObject, Vector3.zero);
            return;
        }

        public static void PlaySynergyVFX()
        {
            GungeonPlayerEventListener.Player.PlayEffectOnActor(ResourceCache.Acquire("Global VFX/VFX_Synergy") as GameObject, new Vector3(0f, 0.5f, 0f));
            return;
        }
    }
}
