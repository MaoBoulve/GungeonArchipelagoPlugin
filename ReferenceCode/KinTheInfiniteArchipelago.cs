using System;
using System.Collections.Generic;
using System.Reflection;
using Alexandria.ItemAPI;
using Archipelago.MultiClient.Net;
using Archipelago.MultiClient.Net.Enums;
using Archipelago.MultiClient.Net.Helpers;
using Archipelago.MultiClient.Net.MessageLog.Messages;
using Archipelago.MultiClient.Net.Models;
using Archipelago.MultiClient.Net.Packets;
using BepInEx;
using Newtonsoft.Json.Linq;
using UnityEngine;

namespace GungeonArchipelago;

[BepInDependency(/*Could not decode attribute arguments.*/)]
[BepInDependency(/*Could not decode attribute arguments.*/)]
[BepInPlugin("kintheinfinite.etg.archipelago", "Archipelago", "1.0.0")]
public class Plugin : BaseUnityPlugin
{
	public const string GUID = "kintheinfinite.etg.archipelago";

	public const string NAME = "Archipelago";

	public const string VERSION = "1.0.0";

	public const string TEXT_COLOR = "#FFFFFF";

	public static ArchipelagoSession session;

	private static int chest_starting_id = 8755000;

	public static Dictionary<string, int> slot_data = new Dictionary<string, int>();

	public static List<long> items_received = new List<long>();

	public static Random random = new Random();

	public static PassiveItem archipelago_pickup;

	public static bool allow_traps = false;

	public void Start()
	{
		ETGModMainBehaviour.WaitForGameManagerStart(GMStart);
	}

	public void GMStart(GameManager g)
	{
		//IL_0137: Unknown result type (might be due to invalid IL or missing references)
		//IL_013d: Expected O, but got Unknown
		ETGModConsole.CommandDescriptions.Add("archipelago connect", "Input the ip, port, and player name seperated by spaces");
		ETGModConsole.CommandDescriptions.Add("archipelago items", "Use when you are starting a new run but are already connected to spawn your items in");
		ETGModConsole.CommandDescriptions.Add("archipelago chat", "Sends a chat message to your connected server");
		ETGModConsole.Commands.AddGroup("archipelago");
		ETGModConsole.Commands.GetGroup("archipelago").AddGroup("connect", delegate(string[] args)
		{
			ArchipelagoConnect(args[0], args[1], args[2]);
		});
		ETGModConsole.Commands.GetGroup("archipelago").AddGroup("items", delegate
		{
			ArchipelagoItems();
		});
		ETGModConsole.Commands.GetGroup("archipelago").AddGroup("chat", delegate(string[] args)
		{
			ArchipelagoChat(args[0]);
		});
		ETGMod.Chest.OnPostOpen = (Action<Chest, PlayerController>)Delegate.Combine(ETGMod.Chest.OnPostOpen, new Action<Chest, PlayerController>(OnChestOpen));
		string text = "Archipelago Item";
		string text2 = "GungeonArchipelago/Resources/archipelago_sprite";
		GameObject val = new GameObject(text);
		archipelago_pickup = val.AddComponent<PassiveItem>();
		ItemBuilder.AddSpriteToObject(text, text2, val, (Assembly)null);
		ItemBuilder.SetupItem((PickupObject)archipelago_pickup, "An archipelago item.", "An archipelago item\n\nA randomized item received from the archipelago server", "Archipelago");
		archipelago_pickup.quality = PickupObject.ItemQuality.EXCLUDED;
		Log("Archipelago v1.0.0 started successfully.");
	}

	public void Update()
	{
		//IL_017d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0182: Unknown result type (might be due to invalid IL or missing references)
		//IL_0187: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0211: Unknown result type (might be due to invalid IL or missing references)
		//IL_0216: Unknown result type (might be due to invalid IL or missing references)
		//IL_021b: Unknown result type (might be due to invalid IL or missing references)
		//IL_025b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0260: Unknown result type (might be due to invalid IL or missing references)
		//IL_0265: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_02aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_02af: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0339: Unknown result type (might be due to invalid IL or missing references)
		//IL_033e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0343: Unknown result type (might be due to invalid IL or missing references)
		//IL_0383: Unknown result type (might be due to invalid IL or missing references)
		//IL_0388: Unknown result type (might be due to invalid IL or missing references)
		//IL_038d: Unknown result type (might be due to invalid IL or missing references)
		//IL_03cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0417: Unknown result type (might be due to invalid IL or missing references)
		//IL_041c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0421: Unknown result type (might be due to invalid IL or missing references)
		PlayerController player = GameManager.Instance.m_player;
		if ((Object)(object)player != (Object)null)
		{
			player.OnKilledEnemyContext -= OnEnemyKill;
			player.OnKilledEnemyContext += OnEnemyKill;
		}
		if (items_received.Count == 0)
		{
			return;
		}
		long num3 = items_received[0];
		items_received.RemoveAt(0);
		long num4 = num3 - 8754000;
		if ((ulong)num4 <= 12uL)
		{
			switch (num4)
			{
			case 0L:
				LootEngine.SpawnItem(((Component)PickupObjectDatabase.GetRandomGunOfQualities(random, new List<int>(), PickupObject.ItemQuality.D)).gameObject, Vector2.op_Implicit(GameManager.Instance.PrimaryPlayer.CenterPosition), Vector2.down, 0f);
				return;
			case 1L:
				LootEngine.SpawnItem(((Component)PickupObjectDatabase.GetRandomGunOfQualities(random, new List<int>(), PickupObject.ItemQuality.C)).gameObject, Vector2.op_Implicit(GameManager.Instance.PrimaryPlayer.CenterPosition), Vector2.down, 0f);
				return;
			case 2L:
				LootEngine.SpawnItem(((Component)PickupObjectDatabase.GetRandomGunOfQualities(random, new List<int>(), PickupObject.ItemQuality.B)).gameObject, Vector2.op_Implicit(GameManager.Instance.PrimaryPlayer.CenterPosition), Vector2.down, 0f);
				return;
			case 3L:
				LootEngine.SpawnItem(((Component)PickupObjectDatabase.GetRandomGunOfQualities(random, new List<int>(), PickupObject.ItemQuality.A)).gameObject, Vector2.op_Implicit(GameManager.Instance.PrimaryPlayer.CenterPosition), Vector2.down, 0f);
				return;
			case 4L:
				LootEngine.SpawnItem(((Component)PickupObjectDatabase.GetRandomGunOfQualities(random, new List<int>(), PickupObject.ItemQuality.S)).gameObject, Vector2.op_Implicit(GameManager.Instance.PrimaryPlayer.CenterPosition), Vector2.down, 0f);
				return;
			case 5L:
				LootEngine.SpawnItem(((Component)PickupObjectDatabase.GetRandomPassiveOfQualities(random, new List<int>(), PickupObject.ItemQuality.D)).gameObject, Vector2.op_Implicit(GameManager.Instance.PrimaryPlayer.CenterPosition), Vector2.down, 0f);
				return;
			case 6L:
				LootEngine.SpawnItem(((Component)PickupObjectDatabase.GetRandomPassiveOfQualities(random, new List<int>(), PickupObject.ItemQuality.C)).gameObject, Vector2.op_Implicit(GameManager.Instance.PrimaryPlayer.CenterPosition), Vector2.down, 0f);
				return;
			case 7L:
				LootEngine.SpawnItem(((Component)PickupObjectDatabase.GetRandomPassiveOfQualities(random, new List<int>(), PickupObject.ItemQuality.B)).gameObject, Vector2.op_Implicit(GameManager.Instance.PrimaryPlayer.CenterPosition), Vector2.down, 0f);
				return;
			case 8L:
				LootEngine.SpawnItem(((Component)PickupObjectDatabase.GetRandomPassiveOfQualities(random, new List<int>(), PickupObject.ItemQuality.A)).gameObject, Vector2.op_Implicit(GameManager.Instance.PrimaryPlayer.CenterPosition), Vector2.down, 0f);
				return;
			case 9L:
				LootEngine.SpawnItem(((Component)PickupObjectDatabase.GetRandomPassiveOfQualities(random, new List<int>(), PickupObject.ItemQuality.S)).gameObject, Vector2.op_Implicit(GameManager.Instance.PrimaryPlayer.CenterPosition), Vector2.down, 0f);
				return;
			case 10L:
				ETGModConsole.SpawnItem(new string[2] { "gnawed_key", "1" });
				return;
			case 11L:
				ETGModConsole.SpawnItem(new string[2] { "old_crest", "1" });
				return;
			case 12L:
				ETGModConsole.SpawnItem(new string[2] { "weird_egg", "1" });
				return;
			}
		}
		long num5 = num3 - 8754100;
		if ((ulong)num5 <= 6uL)
		{
			switch (num5)
			{
			case 0L:
				ETGModConsole.Spawn(new string[2] { "chance_kin", "10" });
				return;
			case 1L:
				ETGModConsole.SpawnItem(new string[2] { "50_casing", "1" });
				return;
			case 2L:
				ETGModConsole.SpawnItem(new string[2] { "key", "1" });
				return;
			case 3L:
				ETGModConsole.SpawnItem(new string[2] { "blank", "1" });
				return;
			case 4L:
				ETGModConsole.SpawnItem(new string[2] { "armor", "1" });
				return;
			case 5L:
				ETGModConsole.SpawnItem(new string[2] { "heart", "1" });
				return;
			case 6L:
				ETGModConsole.SpawnItem(new string[2] { "ammo", "1" });
				return;
			}
		}
		long num6 = num3 - 8754200;
		if ((ulong)num6 <= 7uL)
		{
			switch (num6)
			{
			case 0L:
				ETGModConsole.Spawn(new string[2] { "rat", "100" });
				break;
			case 1L:
				ETGModConsole.Spawn(new string[2] { "shelleton", "3" });
				break;
			case 2L:
				ETGModConsole.Spawn(new string[2] { "shotgrub", "3" });
				break;
			case 3L:
				ETGModConsole.Spawn(new string[2] { "tanker", "12" });
				ETGModConsole.Spawn(new string[2] { "professional", "2" });
				break;
			case 4L:
				ETGModConsole.Spawn(new string[2] { "hollowpoint", "6" });
				ETGModConsole.Spawn(new string[2] { "bombshee", "2" });
				ETGModConsole.Spawn(new string[2] { "gunreaper", "1" });
				break;
			case 5L:
				ETGModConsole.Spawn(new string[2] { "gun_nut", "1" });
				ETGModConsole.Spawn(new string[2] { "chain_gunner", "2" });
				ETGModConsole.Spawn(new string[2] { "spectral_gun_nut", "3" });
				break;
			case 6L:
				ETGModConsole.Spawn(new string[2] { "jamerlengo", "3" });
				ETGModConsole.Spawn(new string[2] { "spirat", "15" });
				break;
			case 7L:
				GameManager.Instance.Dungeon.SpawnCurseReaper();
				break;
			}
		}
	}

	public static void OnEnemyKill(PlayerController player, HealthHaver enemy)
	{
		if (session != null && session.Socket.Connected)
		{
			if (((Object)enemy).name.Equals("Blobulord(Clone)"))
			{
				session.DataStorage[Scope.Slot, "Blobulord Killed"] = 1;
				CheckCompletion();
			}
			if (((Object)enemy).name.Equals("OldBulletKing(Clone)"))
			{
				session.DataStorage[Scope.Slot, "Old King Killed"] = 1;
				CheckCompletion();
			}
			if (((Object)enemy).name.Equals("MetalGearRat(Clone)"))
			{
				session.DataStorage[Scope.Slot, "Resourceful Rat Killed"] = 1;
				CheckCompletion();
			}
			if (((Object)enemy).name.Equals("Helicopter(Clone)"))
			{
				session.DataStorage[Scope.Slot, "Agunim Killed"] = 1;
				CheckCompletion();
			}
			if (((Object)enemy).name.Equals("AdvancedDraGun(Clone)"))
			{
				session.DataStorage[Scope.Slot, "Dragun Killed"] = 1;
				session.DataStorage[Scope.Slot, "Advanced Dragun Killed"] = 1;
				CheckCompletion();
			}
			if (((Object)enemy).name.Equals("DraGun(Clone)"))
			{
				session.DataStorage[Scope.Slot, "Dragun Killed"] = 1;
				CheckCompletion();
			}
			if (((Object)enemy).name.Equals("Infinilich(Clone)"))
			{
				session.DataStorage[Scope.Slot, "Lich Killed"] = 1;
				CheckCompletion();
			}
		}
	}

	public static void CheckCompletion()
	{
		if ((slot_data["Blobulord Goal"] != 1 || (bool)session.DataStorage[Scope.Slot, "Blobulord Killed"]) && (slot_data["Old King Goal"] != 1 || (bool)session.DataStorage[Scope.Slot, "Old King Killed"]) && (slot_data["Resourceful Rat Goal"] != 1 || (bool)session.DataStorage[Scope.Slot, "Resourceful Rat Killed"]) && (slot_data["Agunim Goal"] != 1 || (bool)session.DataStorage[Scope.Slot, "Agunim Killed"]) && (slot_data["Advanced Dragun Goal"] != 1 || (bool)session.DataStorage[Scope.Slot, "Advanced Dragun Killed"]) && (slot_data["Goal"] != 0 || (bool)session.DataStorage[Scope.Slot, "Dragun Killed"]) && (slot_data["Goal"] != 1 || (bool)session.DataStorage[Scope.Slot, "Lich Killed"]))
		{
			StatusUpdatePacket statusUpdatePacket = new StatusUpdatePacket();
			statusUpdatePacket.Status = ArchipelagoClientState.ClientGoal;
			session.Socket.SendPacket(statusUpdatePacket);
		}
	}

	public static void Log(string text, string color = "#FFFFFF")
	{
		ETGModConsole.Log("<color=" + color + ">" + text + "</color>");
	}

	public static void OnChestOpen(Chest chest, PlayerController controller)
	{
		if (session != null && session.Socket.Connected)
		{
			chest.contents.Clear();
			chest.ExplodeInSadness();
			session.DataStorage[Scope.Slot, "ChestsOpened"] += 1;
		}
	}

	public static void ArchipelagoConnect(string ip, string port, string name)
	{
		if (session != null && session.Socket.Connected)
		{
			Log("You are already connected!");
			return;
		}
		Log("Connecting To: " + ip + ":" + port + " as " + name);
		allow_traps = false;
		session = ArchipelagoSessionFactory.CreateSession(ip, int.Parse(port));
		session.Socket.PacketReceived += OnPacketReceived;
		session.MessageLog.OnMessageReceived += OnMessageReceived;
		session.Items.ItemReceived += OnItemReceived;
		LoginResult loginResult = session.TryConnectAndLogin("Enter The Gungeon", name, ItemsHandlingFlags.IncludeOwnItems, new Version(1, 0, 0));
		if (!loginResult.Successful)
		{
			LoginFailure loginFailure = (LoginFailure)loginResult;
			string text = "Failed to Connect to " + ip + ":" + port + " as " + name;
			string[] errors = loginFailure.Errors;
			foreach (string text2 in errors)
			{
				text = text + "\n    " + text2;
			}
			ConnectionRefusedError[] errorCodes = loginFailure.ErrorCodes;
			foreach (ConnectionRefusedError connectionRefusedError in errorCodes)
			{
				text += $"\n    {connectionRefusedError}";
			}
			Log(text);
			return;
		}
		LoginSuccessful loginSuccessful = (LoginSuccessful)loginResult;
		foreach (string key in loginSuccessful.SlotData.Keys)
		{
			int value = int.Parse(loginSuccessful.SlotData[key].ToString());
			slot_data[key] = value;
		}
		Log("Connected to Archipelago server.");


		allow_traps = true;
		session.DataStorage[Scope.Slot, "ChestsOpened"].Initialize(JToken.op_Implicit(0));
		session.DataStorage[Scope.Slot, "Blobulord Killed"].Initialize(JToken.op_Implicit(0));
		session.DataStorage[Scope.Slot, "Old King Killed"].Initialize(JToken.op_Implicit(0));
		session.DataStorage[Scope.Slot, "Resourceful Rat Killed"].Initialize(JToken.op_Implicit(0));
		session.DataStorage[Scope.Slot, "Agunim Killed"].Initialize(JToken.op_Implicit(0));
		session.DataStorage[Scope.Slot, "Dragun Killed"].Initialize(JToken.op_Implicit(0));
		session.DataStorage[Scope.Slot, "Advanced Dragun Killed"].Initialize(JToken.op_Implicit(0));
		session.DataStorage[Scope.Slot, "Lich Killed"].Initialize(JToken.op_Implicit(0));
		session.DataStorage[Scope.Slot, "ChestsOpened"].OnValueChanged += delegate(JToken old_value, JToken new_value, Dictionary<string, JToken> _)
		{
			for (int k = 0; k < new_value.ToObject<int>(); k++)
			{
				session.Locations.CompleteLocationChecks(chest_starting_id + k);
			}
		};
	}

	public static void ArchipelagoItems()
	{
		if (session == null || !session.Socket.Connected)
		{
			Log("You are not connected!");
			return;
		}
		foreach (ItemInfo item in session.Items.AllItemsReceived)
		{
			if (item.ItemId < 8754200)
			{
				items_received.Add(item.ItemId);
			}
		}
	}

	public static void OnItemReceived(ReceivedItemsHelper helper)
	{
		ItemInfo itemInfo = helper.PeekItem();
		if (allow_traps || (!allow_traps && itemInfo.ItemId < 8754200))
		{
			items_received.Add(itemInfo.ItemId);
		}
		helper.DequeueItem();
	}

	public static void ArchipelagoPickupNotification(string title, string text)
	{
		GameUIRoot.Instance.notificationController.DoCustomNotification(title, text, archipelago_pickup.sprite.collection, archipelago_pickup.sprite.spriteId);
	}

	public static void ArchipelagoChat(string message)
	{
		session.Socket.SendPacketAsync(new SayPacket
		{
			Text = message
		});
	}

	public static void OnMessageReceived(LogMessage message)
	{
		Log(message.ToString());
	}

	public static void OnPacketReceived(ArchipelagoPacketBase packet)
	{
		if (packet is ItemPrintJsonPacket)
		{
			ItemPrintJsonPacket itemPrintJsonPacket = (ItemPrintJsonPacket)packet;
			if (itemPrintJsonPacket.ReceivingPlayer == session.ConnectionInfo.Slot || session.Locations.AllLocations.Contains(itemPrintJsonPacket.Item.Location))
			{
				string game = session.Players.Players[session.ConnectionInfo.Team][itemPrintJsonPacket.Item.Player].Game;
				string game2 = session.Players.Players[session.ConnectionInfo.Team][itemPrintJsonPacket.ReceivingPlayer].Game;
				ArchipelagoPickupNotification(session.Players.GetPlayerName(itemPrintJsonPacket.ReceivingPlayer) + " got " + session.Items.GetItemName(itemPrintJsonPacket.Item.Item, game2), "from " + session.Locations.GetLocationNameFromId(itemPrintJsonPacket.Item.Location, game));
			}
		}
	}
}
