using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Alexandria.ItemAPI;
using Alexandria.Misc;
using Dungeonator;
using SaveAPI;
using UnityEngine;

namespace NevernamedsItems;

public class ScrollOfExactKnowledge : CompanionItem
{
	public class ScrollOfExactKnowledgeBehav : CompanionController
	{
		[CompilerGenerated]
		private sealed class _003CSay_003Ed__10 : IEnumerator<object>, IDisposable, IEnumerator
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public List<string> text;

			public ScrollOfExactKnowledgeBehav _003C_003E4__this;

			private List<string>.Enumerator _003C_003Es__1;

			private string _003Ctext2_003E5__2;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return _003C_003E2__current;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return _003C_003E2__current;
				}
			}

			[DebuggerHidden]
			public _003CSay_003Ed__10(int _003C_003E1__state)
			{
				this._003C_003E1__state = _003C_003E1__state;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				int num = _003C_003E1__state;
				if (num == -3 || num == 1)
				{
					try
					{
					}
					finally
					{
						_003C_003Em__Finally1();
					}
				}
				_003C_003Es__1 = default(List<string>.Enumerator);
				_003Ctext2_003E5__2 = null;
				_003C_003E1__state = -2;
			}

			private bool MoveNext()
			{
				//IL_0070: Unknown result type (might be due to invalid IL or missing references)
				//IL_008c: Unknown result type (might be due to invalid IL or missing references)
				//IL_0096: Expected O, but got Unknown
				try
				{
					switch (_003C_003E1__state)
					{
					default:
						return false;
					case 0:
						_003C_003E1__state = -1;
						_003C_003Es__1 = text.GetEnumerator();
						_003C_003E1__state = -3;
						break;
					case 1:
						_003C_003E1__state = -3;
						_003Ctext2_003E5__2 = null;
						break;
					}
					if (_003C_003Es__1.MoveNext())
					{
						_003Ctext2_003E5__2 = _003C_003Es__1.Current;
						TextBubble.DoAmbientTalk(((BraveBehaviour)_003C_003E4__this).transform, new Vector3(0.5f, 2f, 0f), _003Ctext2_003E5__2, 2f);
						_003C_003E2__current = (object)new WaitForSeconds(2f);
						_003C_003E1__state = 1;
						return true;
					}
					_003C_003Em__Finally1();
					_003C_003Es__1 = default(List<string>.Enumerator);
					return false;
				}
				catch
				{
					//try-fault
					((IDisposable)this).Dispose();
					throw;
				}
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			private void _003C_003Em__Finally1()
			{
				_003C_003E1__state = -1;
				((IDisposable)_003C_003Es__1/*cast due to .constrained prefix*/).Dispose();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
				throw new NotSupportedException();
			}
		}

		private List<string> WelcomingDialogues = new List<string> { "Ahh, it's good to be back!", "Back in the saddle!", "Ready and rearing to go!", "Let's do this, you and me!", "I'll do what I can to help!", "Thank goodness, I was getting so lonely." };

		private bool hadRestorationLastChecked;

		private AIActor self;

		public PlayerController Owner;

		private RoomHandler lastCheckedRoom;

		private void Start()
		{
			Owner = base.m_owner;
			self = ((BraveBehaviour)this).aiActor;
			((MonoBehaviour)this).Invoke("DoWelcomingDialogue", 0.5f);
		}

		private void DoWelcomingDialogue()
		{
			//IL_0016: Unknown result type (might be due to invalid IL or missing references)
			TextBubble.DoAmbientTalk(((BraveBehaviour)this).transform, new Vector3(0.5f, 2f, 0f), BraveUtility.RandomElement<string>(WelcomingDialogues), 1.5f);
		}

		public override void Update()
		{
			if (Object.op_Implicit((Object)(object)self) && Object.op_Implicit((Object)(object)Owner) && !Dungeon.IsGenerating)
			{
				if (Owner.CurrentRoom != null && Owner.CurrentRoom != lastCheckedRoom)
				{
					OnRoomChanged(Owner.CurrentRoom);
					lastCheckedRoom = Owner.CurrentRoom;
				}
				if (CustomSynergies.PlayerHasActiveSynergy(Owner, "Restoration") != hadRestorationLastChecked)
				{
					HandleSynergyDialogue(CustomSynergies.PlayerHasActiveSynergy(Owner, "Restoration"));
					hadRestorationLastChecked = CustomSynergies.PlayerHasActiveSynergy(Owner, "Restoration");
				}
			}
		}

		private void OnRoomChanged(RoomHandler room)
		{
			//IL_002d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0516: Unknown result type (might be due to invalid IL or missing references)
			//IL_05a3: Unknown result type (might be due to invalid IL or missing references)
			//IL_05a9: Invalid comparison between Unknown and I4
			//IL_0110: Unknown result type (might be due to invalid IL or missing references)
			//IL_0116: Invalid comparison between Unknown and I4
			//IL_06ac: Unknown result type (might be due to invalid IL or missing references)
			//IL_06b2: Invalid comparison between Unknown and I4
			//IL_06de: Unknown result type (might be due to invalid IL or missing references)
			//IL_06e4: Invalid comparison between Unknown and I4
			//IL_070e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0714: Invalid comparison between Unknown and I4
			List<string> list = new List<string>();
			int num = 0;
			Chest[] array = Object.FindObjectsOfType<Chest>();
			List<Chest> list2 = new List<Chest>();
			Chest[] array2 = array;
			foreach (Chest val in array2)
			{
				if (Vector3Extensions.GetAbsoluteRoom(((BraveBehaviour)val).transform.position) == Owner.CurrentRoom && !val.IsOpen && !val.IsBroken)
				{
					list2.Add(val);
				}
			}
			if (list2.Count > 0)
			{
				foreach (Chest item3 in list2)
				{
					if (item3.IsMimic)
					{
						if (list2.Count > 1)
						{
							list.Add("One of these chests is a mimic... be careful!");
						}
						else
						{
							list.Add("Be careful, that chest's a mimic!");
						}
						num++;
					}
				}
				foreach (Chest item4 in list2)
				{
					if ((int)item4.ChestIdentifier == 2)
					{
						if (list2.Count > 1)
						{
							list.Add("That Chest is a Secret Rainbow Chest!");
						}
						else if (num > 0)
						{
							list.Add("One of these Chests is also secretly a Rainbow Chest!");
						}
						else
						{
							list.Add("One of these Chests is secretly a Rainbow Chest!");
						}
						num++;
					}
				}
				if (list2.Count > 1)
				{
					int num2 = 0;
					int num3 = 0;
					int num4 = 0;
					int num5 = 0;
					foreach (Chest item5 in list2)
					{
						int chestType = GetChestType(item5);
						if (chestType == 0)
						{
							num2++;
						}
						if (chestType == 1)
						{
							num3++;
						}
						if (chestType == 2)
						{
							num4++;
						}
						if (chestType == -1)
						{
							num5++;
						}
					}
					List<string> list3 = new List<string>();
					if (num2 > 1)
					{
						list3.Add($"{num2} guns");
					}
					else if (num2 > 0)
					{
						list3.Add("1 gun");
					}
					if (num3 > 1)
					{
						list3.Add($"{num3} passive items");
					}
					else if (num3 > 0)
					{
						list3.Add("1 passive item");
					}
					if (num4 > 1)
					{
						list3.Add($"{num4} active items");
					}
					else if (num4 > 0)
					{
						list3.Add("1 active item");
					}
					if (num5 > 1)
					{
						list3.Add($"{num5} pickups, I think.");
					}
					else if (num5 > 0)
					{
						list3.Add("1 pickup, I think.");
					}
					foreach (string item6 in list3)
					{
						ETGModConsole.Log((object)item6, false);
					}
					string text = "";
					if (list3.Count > 0)
					{
						for (int j = 0; j < list3.Count; j++)
						{
							string text2 = "";
							if (j == list3.Count - 1)
							{
								text2 = ", and ";
							}
							else if (j != 0)
							{
								text2 = ", ";
							}
							if (list3[j] != null)
							{
								text = text + text2 + list3[j];
							}
						}
						string item = $"Hmm.. out of these chests I'm sensing {text}.";
						list.Add(item);
					}
					else
					{
						list.Add("Oh dear... I think I have experienced a bug while counting items!");
					}
				}
				else
				{
					string text3 = "I think I may have glitched out...";
					switch (GetChestType(list2[0]))
					{
					case 0:
						text3 = "That chest definitely has a gun in it!";
						break;
					case 1:
						text3 = "That chest contains a passive item, I think.";
						break;
					case 2:
						text3 = "That chest contains an active item!";
						break;
					case -1:
						text3 = "That chest doesn't seem to contain... any items at all?";
						break;
					case -2:
						if (!GameStatsManager.Instance.IsRainbowRun)
						{
							text3 = "Oooh! A Rainbow Chest! Lucky you!";
						}
						break;
					}
					if (num > 0)
					{
						text3 = "Also, " + text3;
					}
					list.Add(text3);
					num++;
				}
			}
			foreach (AIActor allEnemy in StaticReferenceManager.AllEnemies)
			{
				if (allEnemy.EnemyGuid == "479556d05c7c44f3b6abb3b2067fc778" && Object.op_Implicit((Object)(object)((BraveBehaviour)allEnemy).specRigidbody) && Vector3Extensions.GetAbsoluteRoom(allEnemy.Position) == room && (Object)(object)((Component)allEnemy).GetComponent<WallMimicController>() != (Object)null && ((Component)allEnemy).GetComponent<WallMimicController>().m_isHidden)
				{
					list.Add("The walls in here look hungry...");
				}
			}
			foreach (RoomHandler connectedRoom in room.connectedRooms)
			{
				if ((int)connectedRoom.area.PrototypeRoomCategory == 3 && !connectedRoom.hasEverBeenVisited)
				{
					List<string> list4 = new List<string>();
					foreach (AIActor activeEnemy in connectedRoom.GetActiveEnemies((ActiveEnemyType)0))
					{
						if (Object.op_Implicit((Object)(object)((BraveBehaviour)activeEnemy).healthHaver) && ((BraveBehaviour)activeEnemy).healthHaver.IsBoss)
						{
							string item2 = activeEnemy.GetActorName();
							if (!string.IsNullOrEmpty(((BraveBehaviour)activeEnemy).healthHaver.overrideBossName))
							{
								item2 = StringTableManager.GetEnemiesString(((BraveBehaviour)activeEnemy).healthHaver.overrideBossName, -1);
							}
							list4.Add(item2);
						}
					}
					if (list4.Count > 0)
					{
						list.Add($"Looks like the {BraveUtility.RandomElement<string>(list4)}... good luck.");
					}
					else
					{
						list.Add("There's a boss nearby...  but I can't tell what it is?");
					}
				}
				else if ((int)connectedRoom.area.PrototypeRoomCategory == 6 && !connectedRoom.hasEverBeenVisited)
				{
					list.Add("The walls in here look suspicious.");
				}
				else if ((int)connectedRoom.area.PrototypeRoomCategory == 4 && !connectedRoom.hasEverBeenVisited)
				{
					list.Add("I think I can sense some loot around here.");
				}
				if ((int)connectedRoom.area.PrototypeRoomCategory != 6)
				{
					Minimap.Instance.RevealMinimapRoom(connectedRoom, true, true, false);
				}
			}
			if (list.Count > 0)
			{
				((MonoBehaviour)this).StartCoroutine(Say(list));
			}
		}

		public void ReactToSpawnedPedestal(RewardPedestal pedestal)
		{
			//IL_0021: Unknown result type (might be due to invalid IL or missing references)
			if (pedestal.IsMimic)
			{
				TextBubble.DoAmbientTalk(((BraveBehaviour)this).transform, new Vector3(0.5f, 2f, 0f), "Be careful... that pedestal's breathing!", 2.5f);
			}
		}

		public void ReactToRuntimeSpawnedChest(Chest chest)
		{
			//IL_009e: Unknown result type (might be due to invalid IL or missing references)
			string text = null;
			switch (GetChestType(chest))
			{
			case 0:
				text = "That chest definitely has a gun in it!";
				break;
			case 1:
				text = "That chest contains a passive item, I think.";
				break;
			case 2:
				text = "That chest contains an active item!";
				break;
			case -1:
				text = "That chest doesn't seem to contain... any items at all?";
				break;
			case -2:
				if (!GameStatsManager.Instance.IsRainbowRun)
				{
					text = "Oooh! A Rainbow Chest! Lucky you!";
				}
				break;
			}
			if (!string.IsNullOrEmpty(text))
			{
				TextBubble.DoAmbientTalk(((BraveBehaviour)this).transform, new Vector3(0.5f, 2f, 0f), text, 1.5f);
			}
		}

		private int GetChestType(Chest chest)
		{
			if (chest.IsRainbowChest)
			{
				return -2;
			}
			List<PickupObject> list = chest.PredictContents(Owner);
			foreach (PickupObject item in list)
			{
				if (item is Gun)
				{
					return 0;
				}
				if (item is PlayerItem)
				{
					return 2;
				}
				if (item is PassiveItem)
				{
					return 1;
				}
			}
			return -1;
		}

		private void HandleSynergyDialogue(bool hasSynergy)
		{
			//IL_004a: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			if (hasSynergy)
			{
				TextBubble.DoAmbientTalk(((BraveBehaviour)this).transform, new Vector3(0.5f, 2f, 0f), "Ooh! That tingles!", 2f);
			}
			else
			{
				TextBubble.DoAmbientTalk(((BraveBehaviour)this).transform, new Vector3(0.5f, 2f, 0f), "Aww, okay then", 2f);
			}
		}

		private IEnumerator Say(List<string> text)
		{
			//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
			return new _003CSay_003Ed__10(0)
			{
				_003C_003E4__this = this,
				text = text
			};
		}
	}

	public static int ScrollOfExactKnowledgeID;

	private List<string> DropDialogue = new List<string> { "No! Wait!", "Please reconsider!", "What did I do wrong?", "Have I really been that much of a burden?", "Not again...", "I'll stay here, I guess... guard the... floor.", "Abandoned again..." };

	public static GameObject prefab;

	private static readonly string guid = "scrollofexactknowledge817498687264735345";

	public static void Init()
	{
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		PickupObject obj = ItemSetup.NewItem<ScrollOfExactKnowledge>("Scroll of Exact Knowledge", "Nerd", "Offers useful information on the Gungeon around you.\n\nSeems to have a fear of being alone, and enjoys company.", "scrollofexactknowledge_icon", assetbundle: true);
		CompanionItem val = (CompanionItem)(object)((obj is CompanionItem) ? obj : null);
		((PickupObject)val).quality = (ItemQuality)2;
		val.CompanionGuid = guid;
		BuildPrefab();
		ScrollOfExactKnowledgeID = ((PickupObject)val).PickupObjectId;
		((PickupObject)(object)val).SetupUnlockOnCustomFlag(CustomDungeonFlags.ALLJAMMED_BEATEN_OFFICE, requiredFlagValue: true);
		CustomActions.OnChestPostSpawn = (Action<Chest>)Delegate.Combine(CustomActions.OnChestPostSpawn, new Action<Chest>(OnChestSpawned));
		CustomActions.OnRewardPedestalSpawned = (Action<RewardPedestal>)Delegate.Combine(CustomActions.OnRewardPedestalSpawned, new Action<RewardPedestal>(OnPedestalSpawned));
	}

	public static void OnPedestalSpawned(RewardPedestal target)
	{
		if (!GameManagerUtility.AnyPlayerHasPickupID(GameManager.Instance, ScrollOfExactKnowledgeID))
		{
			return;
		}
		if ((Object)(object)GameManager.Instance.PrimaryPlayer != (Object)null)
		{
			foreach (PassiveItem passiveItem in GameManager.Instance.PrimaryPlayer.passiveItems)
			{
				if ((Object)(object)((Component)passiveItem).GetComponent<ScrollOfExactKnowledge>() != (Object)null)
				{
					((Component)passiveItem).GetComponent<ScrollOfExactKnowledge>().ReactToSpawnedPedestal(target);
				}
			}
		}
		if (!((Object)(object)GameManager.Instance.SecondaryPlayer != (Object)null))
		{
			return;
		}
		foreach (PassiveItem passiveItem2 in GameManager.Instance.SecondaryPlayer.passiveItems)
		{
			if ((Object)(object)((Component)passiveItem2).GetComponent<ScrollOfExactKnowledge>() != (Object)null)
			{
				((Component)passiveItem2).GetComponent<ScrollOfExactKnowledge>().ReactToSpawnedPedestal(target);
			}
		}
	}

	public static void OnChestSpawned(Chest chest)
	{
		if (Dungeon.IsGenerating || !GameManagerUtility.AnyPlayerHasPickupID(GameManager.Instance, ScrollOfExactKnowledgeID))
		{
			return;
		}
		if ((Object)(object)GameManager.Instance.PrimaryPlayer != (Object)null)
		{
			foreach (PassiveItem passiveItem in GameManager.Instance.PrimaryPlayer.passiveItems)
			{
				if ((Object)(object)((Component)passiveItem).GetComponent<ScrollOfExactKnowledge>() != (Object)null)
				{
					((Component)passiveItem).GetComponent<ScrollOfExactKnowledge>().ReactToRuntimeSpawnedChest(chest);
				}
			}
		}
		if (!((Object)(object)GameManager.Instance.SecondaryPlayer != (Object)null))
		{
			return;
		}
		foreach (PassiveItem passiveItem2 in GameManager.Instance.SecondaryPlayer.passiveItems)
		{
			if ((Object)(object)((Component)passiveItem2).GetComponent<ScrollOfExactKnowledge>() != (Object)null)
			{
				((Component)passiveItem2).GetComponent<ScrollOfExactKnowledge>().ReactToRuntimeSpawnedChest(chest);
			}
		}
	}

	public override DebrisObject Drop(PlayerController player)
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		DebrisObject val = ((CompanionItem)this).Drop(player);
		TextBubble.DoAmbientTalk(((BraveBehaviour)val).transform, new Vector3(0.5f, 2f, 0f), BraveUtility.RandomElement<string>(DropDialogue), 2f);
		return val;
	}

	public void ReactToRuntimeSpawnedChest(Chest chest)
	{
		if (Object.op_Implicit((Object)(object)this) && Object.op_Implicit((Object)(object)((PassiveItem)this).Owner) && Object.op_Implicit((Object)(object)((CompanionItem)this).ExtantCompanion) && (Object)(object)((CompanionItem)this).ExtantCompanion.GetComponent<ScrollOfExactKnowledgeBehav>() != (Object)null)
		{
			((CompanionItem)this).ExtantCompanion.GetComponent<ScrollOfExactKnowledgeBehav>().ReactToRuntimeSpawnedChest(chest);
		}
	}

	public void ReactToSpawnedPedestal(RewardPedestal pedestal)
	{
		if (Object.op_Implicit((Object)(object)this) && Object.op_Implicit((Object)(object)((PassiveItem)this).Owner) && Object.op_Implicit((Object)(object)((CompanionItem)this).ExtantCompanion) && (Object)(object)((CompanionItem)this).ExtantCompanion.GetComponent<ScrollOfExactKnowledgeBehav>() != (Object)null)
		{
			((CompanionItem)this).ExtantCompanion.GetComponent<ScrollOfExactKnowledgeBehav>().ReactToSpawnedPedestal(pedestal);
		}
	}

	public static void BuildPrefab()
	{
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dc: Expected O, but got Unknown
		if (!((Object)(object)prefab != (Object)null) && !CompanionBuilder.companionDictionary.ContainsKey(guid))
		{
			prefab = CompanionBuilder.BuildPrefab("Scroll of Exact Knowledge", guid, "NevernamedsItems/Resources/Companions/ScrollOfExactKnowledge/scrollofexactknowledge_idleright_001", new IntVector2(5, 4), new IntVector2(11, 15));
			ScrollOfExactKnowledgeBehav scrollOfExactKnowledgeBehav = prefab.AddComponent<ScrollOfExactKnowledgeBehav>();
			((BraveBehaviour)scrollOfExactKnowledgeBehav).aiActor.MovementSpeed = 6f;
			((CompanionController)scrollOfExactKnowledgeBehav).CanCrossPits = true;
			((GameActor)((BraveBehaviour)scrollOfExactKnowledgeBehav).aiActor).ActorShadowOffset = new Vector3(0f, -0.5f);
			CompanionBuilder.AddAnimation(prefab, "idle_right", "NevernamedsItems/Resources/Companions/ScrollOfExactKnowledge/scrollofexactknowledge_idleright", 7, (AnimationType)1, (DirectionType)2, (FlipType)0);
			CompanionBuilder.AddAnimation(prefab, "idle_left", "NevernamedsItems/Resources/Companions/ScrollOfExactKnowledge/scrollofexactknowledge_idleleft", 7, (AnimationType)1, (DirectionType)2, (FlipType)0);
			BehaviorSpeculator component = prefab.GetComponent<BehaviorSpeculator>();
			List<MovementBehaviorBase> movementBehaviors = component.MovementBehaviors;
			CompanionFollowPlayerBehavior val = new CompanionFollowPlayerBehavior();
			val.IdleAnimations = new string[1] { "idle" };
			val.CatchUpRadius = 6f;
			val.CatchUpMaxSpeed = 10f;
			val.CatchUpAccelTime = 1f;
			val.CatchUpSpeed = 7f;
			movementBehaviors.Add((MovementBehaviorBase)(object)val);
		}
	}
}
