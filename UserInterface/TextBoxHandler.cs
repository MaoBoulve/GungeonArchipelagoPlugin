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
        static bool isLargeTextBoxOpen = false;
        static bool isSmallTextBoxOpen = false;

        static PlayerController queueTextTarget = null;
        static List<string> queuedText = new List<string>();

        public static void ShowLargeTextBox(PlayerController playerReference, string textToShow)
        {
            if (isSmallTextBoxOpen)
            {
                ClearAllTextboxes();
            }

            isLargeTextBoxOpen = true;
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

        public static void AddEntryForQueuedSmallTextbox(string textToShow)
        {
            queuedText.Add(textToShow);
            
        }

        public static void SetPlayerReferenceForQueueText(PlayerController player)
        {
            queueTextTarget = player;
            return;
        }


        public static void ShowNextQueuedShortText(PlayerController playerReference, string textToShow)
        {
            Vector2 letterBoxPosition = playerReference.sprite.WorldCenter + new Vector2(0f, -3f);

            TextBoxManager.ShowNote(letterBoxPosition, playerReference.transform, -1f, textToShow, instant: false);

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

            isLargeTextBoxOpen = false;

            return;
        }

        public static void HandleNextQueuedTextbox()
        {
            if (isLargeTextBoxOpen || (queueTextTarget == null) )
            {
                return;
            }

            if (queuedText.Count == 0)
            {
                ClearAllTextboxes();
            }

            string nextText = queuedText[0];
            ShowNextQueuedShortText(queueTextTarget, nextText);

            queuedText.RemoveAt(0);

            return;
        }

        public static void ClearQueueText()
        {
            queuedText.Clear();
        }
    }

    public class UserTextFormatHelper
    {

        public static bool CheckIsItemEventMessage(string text)
        {
            string[] messageElements = text.Split(' ');

            if (!messageElements.Contains<string>("sent"))
            {
                // return if non-item send message
                return false;
            }

            return true;
        }

        public static string FormatArchipelagoMessage(string text, string itemTextColor = "#f4d03f", string nameTextColor = "#72eafc")
        {
            string archipelagoMessage = "";
            // (0)[Name] sent (1)[Item of varying lengths] to (2)[Name] ((3)[Source  Item])

            string[] textSplitter = { " sent ", " to ", "(", ")" };

            string[] messageElements = text.Split(textSplitter, StringSplitOptions.None);

            string sender = messageElements[0];
            string item = messageElements[1];
            string receiver = messageElements[2];
            string locationCheck = messageElements[3];

            archipelagoMessage = $"<color={nameTextColor}>{sender}</color> sent <color={itemTextColor}>{item}</color> to <color={nameTextColor}>{receiver}</color> ({locationCheck})";
          
            return archipelagoMessage;
        }
    }

    
}
