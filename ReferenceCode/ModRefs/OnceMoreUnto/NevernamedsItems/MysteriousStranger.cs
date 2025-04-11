using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Alexandria.BreakableAPI;
using Alexandria.DungeonAPI;
using Alexandria.ItemAPI;
using Dungeonator;
using InControl;
using UnityEngine;

namespace NevernamedsItems;

public class MysteriousStranger : BraveBehaviour, IPlayerInteractable
{
	[CompilerGenerated]
	private sealed class _003CConversation_003Ed__17 : IEnumerator<object>, IDisposable, IEnumerator
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public string dialogue;

		public PlayerController speaker;

		public string itemName;

		public MysteriousStranger _003C_003E4__this;

		private string _003Cdialogue2_003E5__1;

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
		public _003CConversation_003Ed__17(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			_003Cdialogue2_003E5__1 = null;
			_003C_003E1__state = -2;
		}

		private bool MoveNext()
		{
			//IL_0090: Unknown result type (might be due to invalid IL or missing references)
			if (_003C_003E1__state != 0)
			{
				return false;
			}
			_003C_003E1__state = -1;
			_003Cdialogue2_003E5__1 = dialogue;
			_003Cdialogue2_003E5__1 = _003Cdialogue2_003E5__1.Replace("NICKNAME", StringTableManager.GetString(StringTableManager.GetTalkingPlayerNick()));
			((BraveBehaviour)_003C_003E4__this).spriteAnimator.PlayForDuration(_003C_003E4__this.currentPerson + "_talk", 3f, _003C_003E4__this.currentPerson + "_idle", false);
			TextBoxManager.ShowTextBox(_003C_003E4__this.talkpoint.position, _003C_003E4__this.talkpoint, 3f, _003Cdialogue2_003E5__1, voice[_003C_003E4__this.currentPerson], false, (BoxSlideOrientation)0, false, false);
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
			throw new NotSupportedException();
		}
	}

	[CompilerGenerated]
	private sealed class _003CHandleInteract_003Ed__23 : IEnumerator<object>, IDisposable, IEnumerator
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public PlayerController interactor;

		public MysteriousStranger _003C_003E4__this;

		private CameraController _003CmainCameraController_003E5__1;

		private GenericLootTable _003ClootTable_003E5__2;

		private GameObject _003Citem_003E5__3;

		private string _003Citemname_003E5__4;

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
		public _003CHandleInteract_003Ed__23(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			_003CmainCameraController_003E5__1 = null;
			_003ClootTable_003E5__2 = null;
			_003Citem_003E5__3 = null;
			_003Citemname_003E5__4 = null;
			_003C_003E1__state = -2;
		}

		private bool MoveNext()
		{
			//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
			//IL_0283: Unknown result type (might be due to invalid IL or missing references)
			//IL_0297: Unknown result type (might be due to invalid IL or missing references)
			//IL_029c: Unknown result type (might be due to invalid IL or missing references)
			//IL_02a1: Unknown result type (might be due to invalid IL or missing references)
			//IL_0347: Unknown result type (might be due to invalid IL or missing references)
			//IL_0351: Expected O, but got Unknown
			//IL_010c: Unknown result type (might be due to invalid IL or missing references)
			switch (_003C_003E1__state)
			{
			default:
				return false;
			case 0:
				_003C_003E1__state = -1;
				if (!_003C_003E4__this.GivenItem)
				{
					interactor.SetInputOverride("npcConversation");
					Pixelator.Instance.LerpToLetterbox(0.35f, 0.25f);
					_003CmainCameraController_003E5__1 = GameManager.Instance.MainCameraController;
					_003CmainCameraController_003E5__1.SetManualControl(true, true);
					_003CmainCameraController_003E5__1.OverridePosition = ((BraveBehaviour)_003C_003E4__this).transform.position;
					_003ClootTable_003E5__2 = ((Random.value >= 0.5f) ? GameManager.Instance.RewardManager.GunsLootTable : GameManager.Instance.RewardManager.ItemsLootTable);
					_003Citem_003E5__3 = null;
					while ((Object)(object)_003Citem_003E5__3 == (Object)null)
					{
						_003Citem_003E5__3 = GameManager.Instance.CurrentRewardManager.GetItemForPlayer(interactor, _003ClootTable_003E5__2, GameManager.Instance.CurrentRewardManager.GetDaveStyleItemQuality(), new List<GameObject>(), false, (Random)null, false, (List<GameObject>)null, false, (RewardSource)0);
					}
					_003Citemname_003E5__4 = "";
					if ((Object)(object)_003Citem_003E5__3 != (Object)null && (Object)(object)_003Citem_003E5__3.GetComponent<EncounterTrackable>() != (Object)null)
					{
						_003Citemname_003E5__4 = _003Citem_003E5__3.GetComponent<EncounterTrackable>().journalData.GetPrimaryDisplayName(false);
					}
					else if ((Object)(object)_003Citem_003E5__3 != (Object)null && (Object)(object)_003Citem_003E5__3.GetComponent<PickupObject>() != (Object)null)
					{
						_003Citemname_003E5__4 = _003Citem_003E5__3.GetComponent<PickupObject>().DisplayName;
					}
					else
					{
						_003Citemname_003E5__4 = "this thing";
					}
					if ((Object)(object)_003Citem_003E5__3 == (Object)null)
					{
						Debug.LogError((object)"Mysterious Stranger: Tried to give a NULL item prefab!");
					}
					Debug.Log((object)("Stranger TryGive: " + ((Object)_003Citem_003E5__3).name + _003Citemname_003E5__4));
					_003C_003E2__current = _003C_003E4__this.LongConversation(giveItemDialogue[_003C_003E4__this.currentPerson], interactor, clearAfter: true, _003Citemname_003E5__4);
					_003C_003E1__state = 1;
					return true;
				}
				if (!_003C_003E4__this.Bored)
				{
					_003C_003E2__current = _003C_003E4__this.Conversation(BraveUtility.RandomElement<string>(randomDialogue[_003C_003E4__this.currentPerson]), interactor);
					_003C_003E1__state = 2;
					return true;
				}
				_003C_003E2__current = _003C_003E4__this.Conversation(BraveUtility.RandomElement<string>(boredDialogue[_003C_003E4__this.currentPerson]), interactor);
				_003C_003E1__state = 3;
				return true;
			case 1:
				_003C_003E1__state = -1;
				if (GameStatsManager.Instance.IsRainbowRun)
				{
					LootEngine.SpawnBowlerNote(GameManager.Instance.RewardManager.BowlerNoteOtherSource, Vector2.op_Implicit(((BraveBehaviour)interactor).transform.position + new Vector3(0f, -0.5f, 0f)), interactor.CurrentRoom, true);
				}
				else
				{
					LootEngine.TryGivePrefabToPlayer(_003Citem_003E5__3, interactor, false);
				}
				_003C_003E4__this.GivenItem = true;
				interactor.ClearInputOverride("npcConversation");
				Pixelator.Instance.LerpToLetterbox(1f, 0.25f);
				GameManager.Instance.MainCameraController.SetManualControl(false, true);
				if (_003C_003E4__this.currentPerson == "spapi")
				{
					_003C_003E4__this.m_room.Entered -= new OnEnteredEventHandler(_003C_003E4__this.PlayerEnteredRoom);
					allStrangers.Remove(_003C_003E4__this);
					_003C_003E4__this.m_room.DeregisterInteractable((IPlayerInteractable)(object)_003C_003E4__this);
					AkSoundEngine.PostEvent("gastervanish", ((Component)interactor).gameObject);
					Object.Destroy((Object)(object)((Component)_003C_003E4__this).gameObject);
					return false;
				}
				_003CmainCameraController_003E5__1 = null;
				_003ClootTable_003E5__2 = null;
				_003Citem_003E5__3 = null;
				_003Citemname_003E5__4 = null;
				break;
			case 2:
				_003C_003E1__state = -1;
				_003C_003E4__this.Bored = true;
				break;
			case 3:
				_003C_003E1__state = -1;
				break;
			}
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
			throw new NotSupportedException();
		}
	}

	[CompilerGenerated]
	private sealed class _003CLongConversation_003Ed__18 : IEnumerator<object>, IDisposable, IEnumerator
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public List<string> dialogue;

		public PlayerController speaker;

		public bool clearAfter;

		public string itemName;

		public MysteriousStranger _003C_003E4__this;

		private int _003CconversationIndex_003E5__1;

		private string _003Cdialogue2_003E5__2;

		private float _003Ctimer_003E5__3;

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
		public _003CLongConversation_003Ed__18(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			_003Cdialogue2_003E5__2 = null;
			_003C_003E1__state = -2;
		}

		private bool MoveNext()
		{
			//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			if (num != 0)
			{
				if (num != 1)
				{
					return false;
				}
				_003C_003E1__state = -1;
				goto IL_0137;
			}
			_003C_003E1__state = -1;
			_003CconversationIndex_003E5__1 = 0;
			((BraveBehaviour)_003C_003E4__this).spriteAnimator.Play(_003C_003E4__this.currentPerson + "_talk");
			goto IL_0186;
			IL_0137:
			if (!((OneAxisInputControl)BraveInput.GetInstanceForPlayer(speaker.PlayerIDX).ActiveActions.GetActionFromType((GungeonActionType)10)).WasPressed || _003Ctimer_003E5__3 < 0.4f)
			{
				_003Ctimer_003E5__3 += BraveTime.DeltaTime;
				_003C_003E2__current = null;
				_003C_003E1__state = 1;
				return true;
			}
			_003CconversationIndex_003E5__1++;
			_003Cdialogue2_003E5__2 = null;
			goto IL_0186;
			IL_0186:
			if (_003CconversationIndex_003E5__1 <= dialogue.Count - 1)
			{
				_003Cdialogue2_003E5__2 = dialogue[_003CconversationIndex_003E5__1];
				_003Cdialogue2_003E5__2 = _003Cdialogue2_003E5__2.Replace("NICKNAME", StringTableManager.GetString(StringTableManager.GetTalkingPlayerNick()));
				_003Cdialogue2_003E5__2 = _003Cdialogue2_003E5__2.Replace("ITEMNAME", itemName);
				TextBoxManager.ClearTextBox(_003C_003E4__this.talkpoint);
				TextBoxManager.ShowTextBox(_003C_003E4__this.talkpoint.position, _003C_003E4__this.talkpoint, -1f, _003Cdialogue2_003E5__2, voice[_003C_003E4__this.currentPerson], false, (BoxSlideOrientation)0, true, false);
				_003Ctimer_003E5__3 = 0f;
				goto IL_0137;
			}
			if (clearAfter)
			{
				TextBoxManager.ClearTextBox(_003C_003E4__this.talkpoint);
			}
			((BraveBehaviour)_003C_003E4__this).spriteAnimator.Play(_003C_003E4__this.currentPerson + "_idle");
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
			throw new NotSupportedException();
		}
	}

	private Transform talkpoint;

	public static GameObject mapIcon;

	public RoomHandler m_room;

	public static List<MysteriousStranger> allStrangers = new List<MysteriousStranger>();

	public static List<string> validPeople = new List<string>
	{
		"pretzel", "notsoai", "skilotar", "dallan", "nickel", "qaday", "round", "accidia", "spapi", "turtle",
		"littlewasp", "bunny", "an3s", "schro"
	};

	public static Dictionary<string, List<string>> entryDialogue = new Dictionary<string, List<string>>
	{
		{
			"pretzel",
			new List<string> { "Welcome to the Club! :D" }
		},
		{
			"notsoai",
			new List<string> { "I've never seen Axiom personnel like you before.", "Found any samples?", "Where's your safety gear?" }
		},
		{
			"accidia",
			new List<string> { "Hi hello hii!! :D", "{wq}Friend{w}! :D", "New buds are the best buds :D" }
		},
		{
			"round",
			new List<string> { "Sup, NICKNAME.", "Alright, let's see... I think I'm supposed to give you something." }
		},
		{
			"nickel",
			new List<string> { "Halla.", "Greetings.", "Welcome." }
		},
		{
			"spapi",
			new List<string> { "Google Witches" }
		},
		{
			"turtle",
			new List<string> { "Hello everybody and welcome to an Enter the Gungeon secret room!" }
		},
		{
			"qaday",
			new List<string> { "Oh, hi.", "Oop- you scared me for a second!", "Ah, right on *cue*! {wj}hehe...{w}" }
		},
		{
			"skilotar",
			new List<string> { "Hail to you!", "Salutations!", "Approach Knave!" }
		},
		{
			"dallan",
			new List<string> { "Heyo! How's it goin'?", "A visitor! Stay awhile." }
		},
		{
			"littlewasp",
			new List<string> { "Person! Hello! Don't run away!", "Hi! Hi!", "A carrier of guns! No need to shoot me! Hehe!" }
		},
		{
			"bunny",
			new List<string> { "oh, hello.", "hi again.", "welcome back.", "hello." }
		},
		{
			"an3s",
			new List<string> { "Howzit.", "Hello!!", "Ho brah, you like come over?" }
		},
		{
			"schro",
			new List<string> { "well well well, look who made it! Ive been waiting for ya to arrive!", "Oh hey! Ya caught me at the perfect time!", "Hm? Oh, hey, didnt see ya there!" }
		}
	};

	public static Dictionary<string, List<string>> giveItemDialogue = new Dictionary<string, List<string>>
	{
		{
			"pretzel",
			new List<string> { "Wow, a visitor! O: It's been a while since someone's come around.", "Excuse me, I almost forgot my manners. *ahem* welcome to ...", "...the Gungeon Club for Resplendent Appreciation of Firearms and Trinkets! :D", "As a token of {wr}my{w} appreciation for you coming by, I have a gift for you!", "Hopefully you can appreciate it as much as I have. C:" }
		},
		{
			"notsoai",
			new List<string> { "At Axiom Munitions, we pride ourselves in the finest products...", "...and the {wj}deadliest weaponry.{w}", "Take this, free of charge." }
		},
		{
			"accidia",
			new List<string> { "Hey {wq}friend{w} look at this thingy i found! :D", "Don't know what it does, but it sure tastes bad!" }
		},
		{
			"round",
			new List<string> { "Oh, yeah, here it is. ITEMNAME is alright.", "Just not up to my high standards." }
		},
		{
			"nickel",
			new List<string> { "This will watch over you in your time of need..." }
		},
		{
			"spapi",
			new List<string> { "Google Witches" }
		},
		{
			"turtle",
			new List<string> { "Here ya go, have this." }
		},
		{
			"qaday",
			new List<string> { "Nice to see ya! I see you're a bit busy, but there's some cool stuff I got!", "Why don't I give you a little something? (Don't ask where it came from, and how it materialises out of me)", "{wj}Enjoy your present!{w}" }
		},
		{
			"skilotar",
			new List<string> { "By my Crown and the devine right entrusted to me..", "I bestow upon thee a gift to aid your quest!" }
		},
		{
			"dallan",
			new List<string> { "You look like you need some assistance. I think it would be smart to help each other out down here.", "Take this, and good luck." }
		},
		{
			"littlewasp",
			new List<string> { "Wowie! That's (probably) a lot of guns you have on you there!", "I'm sure you really, really, really want another one, huh? Here you go!" }
		},
		{
			"bunny",
			new List<string> { "{wj}h a v e   f u n !{w}" }
		},
		{
			"an3s",
			new List<string> { "Take this, hopefully you could make some use of it in this god-forsaken Gungeon, god knows I can't.", "Kulia i ka nu'u." }
		},
		{
			"schro",
			new List<string> { "Found this earlier, take it. Dont tell the Hegemony anything." }
		}
	};

	public static Dictionary<string, List<string>> randomDialogue = new Dictionary<string, List<string>>
	{
		{
			"pretzel",
			new List<string> { "Isn't it simply resplendent? O:", "How's the appreciating going? O:", "Swing by the Club any time! :D" }
		},
		{
			"notsoai",
			new List<string> { "That was handcrafted by machines.", "Don't ask about the costs.", "We're hiring unpaid cannon fodder if you're interested." }
		},
		{
			"accidia",
			new List<string> { "Oh buddy you don't have to give me anything in return!, (Not that it would fit in this box anyways)" }
		},
		{
			"round",
			new List<string> { "What, don't want it? Too bad.", "If you don't want it, just toss it.", "Hey, if you ever see a 'Round King', tell him he's a paradox." }
		},
		{
			"nickel",
			new List<string> { "I bid you farewell..." }
		},
		{
			"spapi",
			new List<string> { "Google Witches" }
		},
		{
			"turtle",
			new List<string> { "There's no more items in this shell.", "Please leave before I break the game horrendously in some completely unrecreatable way." }
		},
		{
			"qaday",
			new List<string> { "Hey uh, are you gonna pay for that wall you just broke? Stuff's kinda annoying to repair, you know.", "You know, I love a good bit of TF2 - Thing Furnished 2 You!   ...No? Well, I tried. On the nose and not very good. That's how I roll!", "Yeah, I'm a floating letter. What's it to you?", "I really like ice cream :3", "Oh yeah, and if anyone asks, I'm not a furry." }
		},
		{
			"skilotar",
			new List<string> { "Keep it in your closest care!", "Safe Travels!", "I bid you fairwell!" }
		},
		{
			"dallan",
			new List<string> { "Always happy to help!", "Endure and survive.", "A gun wields no strength unless the hands that holds it has courage.", "The only thing that can defeat power, is more power.", "What is bravery, without a dash of recklessness?", "Did I ever tell you the definition of insanity?", "The right gun in the right place can make all the difference in the world.", "There’s two ways of reasoning with the Gundead, and neither of them work.", "The best solution to a problem is usually the easiest one." }
		},
		{
			"littlewasp",
			new List<string> { "My name's Little Wasp!", "I'm sure you don't want to hear this, but yes, there ARE much bigger wasps out there!", "The gun's quality? It's rated W, for 'wasp', of course!", "I thought this was a bug-geon, but I was horribly mistaken! Hehe! Help." }
		},
		{
			"bunny",
			new List<string> { "ever make a mistake that you wish you could undo? turns out not having opposable thumbs kinda sucks.", "understanding the unknown, knowledge expanding further and further out, all for naught.", "its incredible how much exhaustion this tiny little body can hold.", "i know what you are.", "if youre good enough, you can occasionally trespass into places we were never meant to be in. thats kinda how i got here.", "sometimes, when i press my head against the walls of the Gungeon, i can hear what sounds like a distress signal. but what do i know, im just a bunny.", "know when to turn back, because once it is too late, the only way youll have left to go, is deeper, deeper, yet deeper.", "maybe ill get it right next time." }
		},
		{
			"an3s",
			new List<string> { "Carry on with your gungeoneering.", "E hele!", "I have nothing more to say to you." }
		},
		{
			"schro",
			new List<string> { "Ever met the trigger twins? Great pair, baked me a cake before.", "Look dude, I've got things to post online.", "Sorry I didnt have anything better, man.", "Ooh! I met this guy once. Cant remember his name. Just before ya, you missed him. Nice revolver he had. Somethin card related." }
		}
	};

	public static Dictionary<string, List<string>> boredDialogue = new Dictionary<string, List<string>>
	{
		{
			"pretzel",
			new List<string> { "Isn't it simply resplendent? O:", "How's the appreciating going? O:", "Swing by the Club any time! :D" }
		},
		{
			"notsoai",
			new List<string> { "Don't you have a quota to meet?", "Did you forget Axiom's refund policy?", "...add three, divide by zero... WAIT HOLD ON", "..." }
		},
		{
			"accidia",
			new List<string> { "I appreciate the company :D" }
		},
		{
			"round",
			new List<string> { "I've got to stare at this wall for a couple more hours.", "Bit busy, sorry." }
		},
		{
			"nickel",
			new List<string> { "Run away, Run away.", "You have nothing more to find.", "You will leave me now!" }
		},
		{
			"spapi",
			new List<string> { "Google Witches" }
		},
		{
			"turtle",
			new List<string> { "Subscribe!", "I'm surprised your game hasn't crashed with me here.", "This shell aint big enough for the both of us.", "DON'T eat the melon....." }
		},
		{
			"qaday",
			new List<string> { "Go on now, I've got things on my to-do list to queue!", "You surely have better things to do than to hang out with the physical embodiment of a letter of the alphabet, don't you?", " Bo'a'wo'a", "[Insert Q Pun Here] (I'm very creative)" }
		},
		{
			"skilotar",
			new List<string> { "Away with you!", "I grow weary of you.", "Shoo." }
		},
		{
			"dallan",
			new List<string> { "Man, I could really use a coffee right now.", "Phew, I think I need a nap.", "Yawn..." }
		},
		{
			"littlewasp",
			new List<string> { "You'll never kill your past at this rate!", "Imagine how many minutes you'll have to rewind past when you get The Gun.", "Did you want a hug or something?" }
		},
		{
			"bunny",
			new List<string> { "I think it is time for a rest." }
		},
		{
			"an3s",
			new List<string> { "Carry on with your gungeoneering.", "E hele!", "I have nothing more to say to you." }
		},
		{
			"schro",
			new List<string> { "Look, I ain't got nothin else.", "What, you lookin to chat?", "I could rant for ya if you'd like that.", "Lookin for a date? No thanks.", "well, get a move on now." }
		}
	};

	public static Dictionary<string, List<string>> shotAtDialogue = new Dictionary<string, List<string>>
	{
		{
			"pretzel",
			new List<string> { "Can you appreciate in some other direction please?! D:" }
		},
		{
			"notsoai",
			new List<string> { "You should be on the front line - The production line, that is.", "Axiom Munitions 5-Megawatt Personal Refractive Shields never fail!", "You're lucky they don't give me arms - or arms.", "That ammunition usage is completely suboptimal.", "Really?", "That's a safety violation!" }
		},
		{
			"accidia",
			new List<string> { "Hehehe! {wq}Friend{w} bullets :D", "Bullets from a {wq}friend{w} :D" }
		},
		{
			"round",
			new List<string> { "You're lucky that missed.", "I could totally kick your teeth in if I wanted to." }
		},
		{
			"nickel",
			new List<string> { "Sorrow be upon thee!", "You're a charlatan!", "Enough of this!", "Perish at my hands!" }
		},
		{
			"spapi",
			new List<string> { "Google Witches" }
		},
		{
			"turtle",
			new List<string> { "Whatcha doing??!" }
		},
		{
			"qaday",
			new List<string> { "I didn't choose to have this, but it's kinda necessary when this happens ._.", "It's okay, let it all out.", "There's probably better target practice out there not gonna lie.", "Yeah, that's fair." }
		},
		{
			"skilotar",
			new List<string> { "Begone Mutt!", "GUARRRDSS!!", "Do you fancy yourself a Jester?!", "dude...   uncool." }
		},
		{
			"dallan",
			new List<string> { "Parried!", "Nah. I drink bulletproof coffee.", "Do you {wj}like{w} hurting other people?", "What is {wj}wrong{w} with you?", "And to think I'm here to help...", "You're not getting those bullets back you know." }
		},
		{
			"littlewasp",
			new List<string> { "Nooo! I'm a nice wasp! I'M NICE!", "Aah! That was close!", "Eek!" }
		},
		{
			"bunny",
			new List<string> { "not yet, i have unfinished business.", "you missed.", "maybe next time." }
		},
		{
			"an3s",
			new List<string> { "If you no like stop I'm gonna end up giving you mean lickings brah.", "Just give up, this magical ring protects me from your bullets." }
		},
		{
			"schro",
			new List<string> { "Did'ja really think id just stand there and take it?", "Y'know, this doesn't seem like the best use of your time.", "Oddly enough, I feel attacked.", "That's rude.", "Ah, so close!", "HAH! YA MISSED!", "I'd say your aim is poison, but poison actually kills people." }
		}
	};

	public static Dictionary<string, string> voice = new Dictionary<string, string>
	{
		{ "pretzel", "male" },
		{ "notsoai", "computer" },
		{ "accidia", "teen" },
		{ "round", "robot" },
		{ "nickel", "manly" },
		{ "spapi", "truthknower" },
		{ "turtle", "goofy" },
		{ "qaday", "witch1" },
		{ "skilotar", "dice" },
		{ "dallan", "manly" },
		{ "littlewasp", "bug" },
		{ "bunny", "truthknower" },
		{ "an3s", "fool" },
		{ "schro", "robot" }
	};

	public string currentPerson;

	public bool GivenItem = false;

	public bool Bored = false;

	public static void Init()
	{
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Expected O, but got Unknown
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0112: Unknown result type (might be due to invalid IL or missing references)
		//IL_013b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0145: Expected O, but got Unknown
		GameObject val = ItemBuilder.SpriteFromBundle("ms_pretzel_idle_001", Initialisation.MysteriousStrangerCollection.GetSpriteIdByName("ms_pretzel_idle_001"), Initialisation.MysteriousStrangerCollection, new GameObject("Mysterious Stranger"));
		val.SetActive(false);
		FakePrefab.MarkAsFakePrefab(val);
		val.AddComponent<MysteriousStranger>();
		SpeculativeRigidbody val2 = SpriteBuilder.SetUpSpeculativeRigidbody(val.GetComponent<tk2dSprite>(), new IntVector2(-6, 7), new IntVector2(9, 12));
		val2.CollideWithTileMap = false;
		val2.CollideWithOthers = true;
		UltraFortunesFavor val3 = val.AddComponent<UltraFortunesFavor>();
		val3.sparkOctantVFX = ResourceManager.LoadAssetBundle("shared_auto_002").LoadAsset<GameObject>("npc_blank_jailed").GetComponentInChildren<UltraFortunesFavor>()
			.sparkOctantVFX;
		tk2dSpriteAnimator orAddComponent = GameObjectExtensions.GetOrAddComponent<tk2dSpriteAnimator>(val);
		orAddComponent.Library = Initialisation.mysteriousStrangerAnimationCollection;
		orAddComponent.defaultClipId = Initialisation.mysteriousStrangerAnimationCollection.GetClipIdByName("pretzel_idle");
		orAddComponent.DefaultClipId = Initialisation.mysteriousStrangerAnimationCollection.GetClipIdByName("pretzel_idle");
		orAddComponent.playAutomatically = true;
		GameObjectExtensions.GetOrAddComponent<NPCShootReactor>(val);
		Transform transform = new GameObject("talkpoint").transform;
		transform.SetParent(val.transform);
		((Component)transform).transform.localPosition = new Vector3(0f, 1.4375f);
		GameObject val4 = ItemBuilder.SpriteFromBundle("ms_shadow", Initialisation.MysteriousStrangerCollection.GetSpriteIdByName("ms_shadow"), Initialisation.MysteriousStrangerCollection, new GameObject("ms_shadow"));
		tk2dSprite component = val4.GetComponent<tk2dSprite>();
		((tk2dBaseSprite)component).HeightOffGround = -1.7f;
		((tk2dBaseSprite)component).SortingOrder = 0;
		((tk2dBaseSprite)component).IsPerpendicular = false;
		((BraveBehaviour)component).renderer.material.shader = ShaderCache.Acquire("Brave/LitTk2dCustomFalloffTilted");
		((tk2dBaseSprite)component).usesOverrideMaterial = true;
		val4.transform.SetParent(val.transform);
		Dictionary<GameObject, float> dictionary = new Dictionary<GameObject, float> { { val, 1f } };
		DungeonPlaceable value = BreakableAPIToolbox.GenerateDungeonPlaceable(dictionary, 1, 1, (DungeonPrerequisite[])null);
		StaticReferences.StoredDungeonPlaceables.Add("mysterious_stranger", value);
		StaticReferences.customPlaceables.Add("nn:mysterious_stranger", value);
	}

	private void Start()
	{
		//IL_0091: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0115: Unknown result type (might be due to invalid IL or missing references)
		//IL_0120: Expected O, but got Unknown
		//IL_012e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0138: Expected O, but got Unknown
		talkpoint = ((BraveBehaviour)this).transform.Find("talkpoint");
		List<string> list = new List<string>(validPeople);
		foreach (MysteriousStranger allStranger in allStrangers)
		{
			list.Remove(allStranger.currentPerson);
		}
		if (list.Count <= 0)
		{
			list.AddRange(validPeople);
		}
		currentPerson = BraveUtility.RandomElement<string>(list);
		SpriteOutlineManager.AddOutlineToSprite(((BraveBehaviour)this).sprite, Color.black);
		m_room = GameManager.Instance.Dungeon.data.GetAbsoluteRoomFromPosition(Vector3Extensions.IntXY(((BraveBehaviour)this).transform.position, (VectorConversions)2));
		m_room.RegisterInteractable((IPlayerInteractable)(object)this);
		NPCShootReactor component = ((Component)this).GetComponent<NPCShootReactor>();
		component.OnShot = (Action<Projectile>)Delegate.Combine(component.OnShot, new Action<Projectile>(OnShot));
		Minimap.Instance.RegisterRoomIcon(m_room, (GameObject)BraveResources.Load("Global Prefabs/Minimap_NPC_Icon", ".prefab"), false);
		m_room.Entered += new OnEnteredEventHandler(PlayerEnteredRoom);
		((BraveBehaviour)this).spriteAnimator.Play(currentPerson + "_idle");
		allStrangers.Add(this);
	}

	private void PlayerEnteredRoom(PlayerController player)
	{
		if (currentPerson != "spapi")
		{
			((MonoBehaviour)this).StartCoroutine(Conversation(BraveUtility.RandomElement<string>(entryDialogue[currentPerson]), player));
		}
	}

	private void OnShot(Projectile proj)
	{
		if (currentPerson != "spapi")
		{
			((MonoBehaviour)this).StartCoroutine(Conversation(BraveUtility.RandomElement<string>(shotAtDialogue[currentPerson]), GameManager.Instance.PrimaryPlayer));
		}
	}

	private void Update()
	{
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		PlayerController activePlayerClosestToPoint = GameManager.Instance.GetActivePlayerClosestToPoint(Vector3Extensions.XY(((BraveBehaviour)this).transform.position), false);
		if ((Object)(object)activePlayerClosestToPoint != (Object)null)
		{
			((BraveBehaviour)this).sprite.FlipX = ((GameActor)activePlayerClosestToPoint).CenterPosition.x < ((BraveBehaviour)this).transform.position.x;
		}
	}

	public IEnumerator Conversation(string dialogue, PlayerController speaker, string itemName = "")
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CConversation_003Ed__17(0)
		{
			_003C_003E4__this = this,
			dialogue = dialogue,
			speaker = speaker,
			itemName = itemName
		};
	}

	public IEnumerator LongConversation(List<string> dialogue, PlayerController speaker, bool clearAfter = false, string itemName = "")
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CLongConversation_003Ed__18(0)
		{
			_003C_003E4__this = this,
			dialogue = dialogue,
			speaker = speaker,
			clearAfter = clearAfter,
			itemName = itemName
		};
	}

	public float GetDistanceToPoint(Vector2 point)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		return Vector2.Distance(point, Vector2.op_Implicit(((BraveBehaviour)this).transform.position)) / 1.5f;
	}

	public void OnEnteredRange(PlayerController interactor)
	{
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		SpriteOutlineManager.RemoveOutlineFromSprite(((BraveBehaviour)this).sprite, true);
		SpriteOutlineManager.AddOutlineToSprite(((BraveBehaviour)this).sprite, Color.white);
	}

	public void OnExitRange(PlayerController interactor)
	{
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		SpriteOutlineManager.RemoveOutlineFromSprite(((BraveBehaviour)this).sprite, true);
		SpriteOutlineManager.AddOutlineToSprite(((BraveBehaviour)this).sprite, Color.black);
	}

	public void Interact(PlayerController interactor)
	{
		if (!TextBoxManager.HasTextBox(talkpoint))
		{
			((MonoBehaviour)this).StartCoroutine(HandleInteract(interactor));
		}
	}

	public IEnumerator HandleInteract(PlayerController interactor)
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CHandleInteract_003Ed__23(0)
		{
			_003C_003E4__this = this,
			interactor = interactor
		};
	}

	public string GetAnimationState(PlayerController interactor, out bool shouldBeFlipped)
	{
		shouldBeFlipped = false;
		return string.Empty;
	}

	public float GetOverrideMaxDistance()
	{
		return 1.5f;
	}

	public override void OnDestroy()
	{
		allStrangers.Remove(this);
		((BraveBehaviour)this).OnDestroy();
	}
}
