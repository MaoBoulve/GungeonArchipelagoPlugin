using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace ArchiGungeon.UserInterface
{
    public class TestTextBox: MonoBehaviour
    {


        private void TextBoxExample()
        {
            //TextBoxManager.ShowTextBox("");

            //An example of the method as you would write it in your code.
            //This example places the text box on the transform of a gameobject, which lasts for two seconds, and invites the player to have a seat by the fire.
            //It speaks in a female character voice, and has no other special settings.

            TextBoxManager.ShowTextBox(base.transform.position, base.transform, 2f, "Welcome traveller, have a seat by the fire.", "female", false, TextBoxManager.BoxSlideOrientation.NO_ADJUSTMENT, false, false);
        }
    }
}
