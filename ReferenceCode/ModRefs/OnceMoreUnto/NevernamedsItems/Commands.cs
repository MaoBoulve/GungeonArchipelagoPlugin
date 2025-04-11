using System;
using SaveAPI;
using UnityEngine;

namespace NevernamedsItems;

public class Commands
{
	public static bool allJammedState;

	public static bool itemsHaveBeenRarityBoosted;

	public static void Init()
	{
		ETGModConsole.Commands.AddGroup("nn", (Action<string[]>)delegate
		{
			ETGModConsole.Log((object)"<size=100><color=#ff0000ff>Please specify a command. Type 'nn help' for a list of commands.</color></size>", false);
		});
		ETGModConsole.Commands.GetGroup("nn").AddUnit("help", (Action<string[]>)delegate
		{
			ETGModConsole.Log((object)"<size=100><color=#ff0000ff>List of Commands</color></size>", false);
			ETGModConsole.Log((object)"<size=100><color=#ff0000ff>-------------------</color></size>", false);
			ETGModConsole.Log((object)"<color=#ff0000ff>checkunlocks</color> - Lists what OMITB unlocks you have yet to achieve, with explanations for each one.", false);
			ETGModConsole.Log((object)"<color=#ff0000ff>togglealljammed</color> - Turns on and off All-Jammed mode.", false);
			ETGModConsole.Log((object)"<color=#ff0000ff>togglerarityboost</color> - Greatly increases the loot weight of modded items, making them show up much more.", false);
			ETGModConsole.Log((object)"<color=#ff0000ff>roomdata</color> - Displays data about the current room (currently only it's name)", false);
		});
		ETGModConsole.Commands.GetGroup("nn").AddUnit("togglealljammed", (Action<string[]>)delegate
		{
			if (AllJammedState.AllJammedActive)
			{
				SaveAPIManager.SetFlag(CustomDungeonFlags.ALLJAMMEDMODE_ENABLED_CONSOLE, value: false);
				SaveAPIManager.SetFlag(CustomDungeonFlags.ALLJAMMEDMODE_ENABLED_GENUINE, value: false);
				ETGModConsole.Log((object)"All-Jammed Mode has been disabed.", false);
			}
			else
			{
				SaveAPIManager.SetFlag(CustomDungeonFlags.ALLJAMMEDMODE_ENABLED_CONSOLE, value: true);
				SaveAPIManager.SetFlag(CustomDungeonFlags.ALLJAMMEDMODE_ENABLED_GENUINE, value: false);
				ETGModConsole.Log((object)"All-Jammed Mode has been enabled.", false);
			}
		});
		ETGModConsole.Commands.GetGroup("nn").AddUnit("togglecurses", (Action<string[]>)delegate
		{
			if (AllJammedState.AllJammedActive)
			{
				SaveAPIManager.SetFlag(CustomDungeonFlags.CURSES_DISABLED, value: true);
				ETGModConsole.Log((object)"Y'know what sucks? Putting time and effort into something only for everyone to just disable it and tell you how much they hate it.", false);
				ETGModConsole.Log((object)"Yeah this is a petty message, but consider it developer venting or something.", false);
				ETGModConsole.Log((object)"Anyways... curses have been disabed.", false);
			}
			else
			{
				SaveAPIManager.SetFlag(CustomDungeonFlags.CURSES_DISABLED, value: false);
				ETGModConsole.Log((object)"Curses have been enabled.   ...thanks.", false);
			}
		});
		ETGModConsole.Commands.GetGroup("nn").AddUnit("roomdata", (Action<string[]>)delegate
		{
			PlayerController primaryPlayer = GameManager.Instance.PrimaryPlayer;
			string roomName = primaryPlayer.CurrentRoom.GetRoomName();
			ETGModConsole.Log((object)("<color=#ff0000ff>Room Name: </color>" + roomName), false);
			ETGModConsole.Log((object)("<color=#ff0000ff>Category: </color>" + ((object)(RoomCategory)(ref primaryPlayer.CurrentRoom.area.PrototypeRoomCategory)/*cast due to .constrained prefix*/).ToString()), false);
			ETGModConsole.Log((object)("<color=#ff0000ff>Subcategory: </color>" + ((object)(RoomNormalSubCategory)(ref primaryPlayer.CurrentRoom.area.PrototypeRoomNormalSubcategory)/*cast due to .constrained prefix*/).ToString()), false);
		});
		ETGModConsole.Commands.GetGroup("nn").AddUnit("togglerarityboost", (Action<string[]>)delegate
		{
			if (itemsHaveBeenRarityBoosted)
			{
				ETGModConsole.Log((object)"The loot weight of modded items and guns has been reset to normal.", false);
				foreach (WeightedGameObject element in GameManager.Instance.RewardManager.GunsLootTable.defaultItemDrops.elements)
				{
					if (element.pickupId > 823 || element.pickupId < 0)
					{
						element.weight /= 100f;
					}
				}
				foreach (WeightedGameObject element2 in GameManager.Instance.RewardManager.ItemsLootTable.defaultItemDrops.elements)
				{
					if (element2.pickupId > 823 || element2.pickupId < 0)
					{
						element2.weight /= 100f;
					}
				}
				itemsHaveBeenRarityBoosted = false;
			}
			else
			{
				ETGModConsole.Log((object)"The loot weight of modded items and guns has been GREATLY increased.", false);
				foreach (WeightedGameObject element3 in GameManager.Instance.RewardManager.GunsLootTable.defaultItemDrops.elements)
				{
					if (element3.pickupId > 823 || element3.pickupId < 0)
					{
						float weight = element3.weight;
						element3.weight *= 100f;
						string text = "ERROR DISPLAY NAME NULL";
						if ((Object)(object)PickupObjectDatabase.GetById(element3.pickupId) != (Object)null)
						{
							PickupObject byId = PickupObjectDatabase.GetById(element3.pickupId);
							text = ((byId is Gun) ? byId : null).DisplayName;
						}
						ETGModConsole.Log((object)(text + " (" + element3.pickupId + "): " + weight + " ---> " + element3.weight), false);
					}
				}
				foreach (WeightedGameObject element4 in GameManager.Instance.RewardManager.ItemsLootTable.defaultItemDrops.elements)
				{
					if (element4.pickupId > 823 || element4.pickupId < 0)
					{
						element4.weight *= 100f;
					}
				}
				itemsHaveBeenRarityBoosted = true;
			}
		});
		CheckUnlocks.Init();
		CheatUnlocks.Init();
		ETGModConsole.Commands.GetGroup("nn").AddUnit("givebyid", (Action<string[]>)delegate(string[] args)
		{
			//IL_0083: Unknown result type (might be due to invalid IL or missing references)
			//IL_0088: Unknown result type (might be due to invalid IL or missing references)
			//IL_008d: Unknown result type (might be due to invalid IL or missing references)
			if (args == null)
			{
				ETGModConsole.Log((object)"No args", false);
			}
			if (args.Length > 1)
			{
				ETGModConsole.Log((object)"Too many args", false);
			}
			string s = args[0];
			int num = -1;
			try
			{
				num = int.Parse(s);
			}
			catch
			{
				ETGModConsole.Log((object)"That's not a numerical id", false);
			}
			if (num >= 0 && (Object)(object)PickupObjectDatabase.GetById(num) != (Object)null)
			{
				LootEngine.SpawnItem(((Component)PickupObjectDatabase.GetById(num)).gameObject, Vector2.op_Implicit(((GameActor)GameManager.Instance.PrimaryPlayer).CenterPosition), Vector2.zero, 0f, true, false, false);
			}
		});
		ETGModConsole.Commands.GetGroup("nn").AddUnit("zoom", (Action<string[]>)delegate(string[] args)
		{
			if (args != null && args.Length != 0)
			{
				if (args.Length == 1)
				{
					if (float.TryParse(args[0], out var result))
					{
						GameManager.Instance.MainCameraController.OverrideZoomScale = result;
					}
					else
					{
						Console.WriteLine("Error: '" + args[0] + "' is not a valid integer.");
					}
				}
				else
				{
					ETGModConsole.Log((object)"<color=#ff1500>Error: Too many arguments!</color>", false);
				}
			}
			else
			{
				ETGModConsole.Log((object)"<color=#ff1500>Error: Please input a value for how much you want to zoom (eg: 'nn zoom 4')</color>", false);
			}
		});
		DeconstructGun.Init();
		DeconstructDungeon.Init();
		LoadRoom.Init();
	}
}
