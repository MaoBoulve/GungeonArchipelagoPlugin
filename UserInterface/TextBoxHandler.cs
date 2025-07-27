using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace ArchiGungeon.UserInterface
{
    

    public class TextBoxHandler
    {
        //https://mtgmodders.gitbook.io/etg-modding-guide/text-text-boxes-etc/textboxes
        static List<PlayerController> playersWithPossibleTextbox = new List<PlayerController>();

        public static void ShowArchipelagoLetterBox(PlayerController playerReference, string textToShow)
        {
            Vector2 letterBoxPosition = playerReference.sprite.WorldCenter + new Vector2(0f, 1f);
            float boxDuration = -1f;
            TextBoxManager.ShowLetterBox(letterBoxPosition, playerReference.transform, 
                duration: boxDuration, text: textToShow);

            if(!playersWithPossibleTextbox.Contains(playerReference))
            {
                playersWithPossibleTextbox.Add(playerReference);
            }
            

            return;
        }


        public static void ShowItemEventTextBox(PlayerController playerReference, string textToShow, float textDuration)
        {
            Vector2 letterBoxPosition = playerReference.sprite.WorldCenter + new Vector2(0f, -3f);

            TextBoxManager.ShowNote(letterBoxPosition, playerReference.transform, textDuration, textToShow, instant: false);

            if (!playersWithPossibleTextbox.Contains(playerReference))
            {
                playersWithPossibleTextbox.Add(playerReference);
            }

            return;
        }

        public static void ClearAllTextboxes()
        {
            foreach(PlayerController player in playersWithPossibleTextbox)
            {
                if(player != null)
                {
                    TextBoxManager.ClearTextBoxImmediate(player.transform);
                }
                
            }

            return;
        }
    }
}
