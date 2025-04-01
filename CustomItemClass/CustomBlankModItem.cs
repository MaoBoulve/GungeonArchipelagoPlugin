using MonoMod.RuntimeDetour;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using UnityEngine;

namespace ArchiGungeon.CustomItemClass
{
    internal class CustomBlankModItem : BlankModificationItem
    {
        public static void InitHooks()
        {
            Hook hook = new Hook(
                typeof(SilencerInstance).GetMethod("ProcessBlankModificationItemAdditionalEffects", BindingFlags.NonPublic | BindingFlags.Instance),
                typeof(CustomBlankModItem).GetMethod("BlankModificationHook")
            );
        }

        public static void BlankModificationHook(Action<SilencerInstance, BlankModificationItem, Vector2, PlayerController> blankAction, SilencerInstance self, 
            BlankModificationItem blackModItem, Vector2 centerPoint, PlayerController user)
        {
            blankAction(self, blackModItem, centerPoint, user);
            if (blackModItem is CustomBlankModItem)
            {
                (blackModItem as CustomBlankModItem).OnBlank(self, centerPoint, user);
            }
        }

        protected virtual void OnBlank(SilencerInstance silencerInstance, Vector2 centerPoint, PlayerController user)
        {

        }
    }
}
