using ArchiGungeon.Archipelago;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArchiGungeon.ItemArchipelago
{
    public class SentLocationItemHandler
    {

        public static void HandleOpenedChestLocationCheck(Chest chest, PlayerController controller)
        {
            if (SessionHandler.session == null)
            {
                return;
            }

            if (SessionHandler.session.Socket.Connected == false)
            {
                return;
            }

            // TODO: handle as with archipelago item
            chest.contents.Clear();
            chest.contents.Add(SessionHandler.GetNextAPItem());

            //chest.ExplodeInSadness();

            SessionHandler.DataSender.ParseOpenedChestToLocationCheck();

            return;
        }
    }
}
