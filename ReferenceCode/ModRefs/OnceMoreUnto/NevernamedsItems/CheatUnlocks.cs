using System;
using System.Collections.Generic;
using SaveAPI;

namespace NevernamedsItems;

internal class CheatUnlocks
{
	public static List<CustomDungeonFlags> flagsToSet = new List<CustomDungeonFlags>
	{
		CustomDungeonFlags.PLAYERHELDMORETHANFIVEARMOUR,
		CustomDungeonFlags.KILLEDJAMMEDKEYBULLETKIN,
		CustomDungeonFlags.KILLEDJAMMEDCHANCEKIN,
		CustomDungeonFlags.KILLEDJAMMEDMIMIC,
		CustomDungeonFlags.HASBEENDAMAGEDBYRISKRIFLE,
		CustomDungeonFlags.FAILEDRATMAZE,
		CustomDungeonFlags.USEDFALLENANGELSHRINE,
		CustomDungeonFlags.KILLEDENEMYWITHTHROWNGUN,
		CustomDungeonFlags.USED_FALSE_BLANK_TEN_TIMES,
		CustomDungeonFlags.KILLED_TITAN_KIN,
		CustomDungeonFlags.HAS_BEATEN_BOSS_BY_SKIN_OF_TEETH,
		CustomDungeonFlags.DRAGUN_KILLED_HUNTER,
		CustomDungeonFlags.ANGERED_BELLO,
		CustomDungeonFlags.ROBOT_HELD_FIVE_JUNK,
		CustomDungeonFlags.HURT_BY_SHROOMER,
		CustomDungeonFlags.UNLOCKED_MISSINGUNO,
		CustomDungeonFlags.FLOOR_CLEARED_WITH_CURSE,
		CustomDungeonFlags.BEATEN_KEEP_TURBO_MODE,
		CustomDungeonFlags.BEATEN_MINES_BOSS_TURBO_MODE,
		CustomDungeonFlags.BEATEN_HOLLOW_BOSS_TURBO_MODE,
		CustomDungeonFlags.RAINBOW_KILLED_LICH,
		CustomDungeonFlags.ALLJAMMED_BEATEN_KEEP,
		CustomDungeonFlags.ALLJAMMED_BEATEN_OUB,
		CustomDungeonFlags.ALLJAMMED_BEATEN_PROPER,
		CustomDungeonFlags.ALLJAMMED_BEATEN_ABBEY,
		CustomDungeonFlags.ALLJAMMED_BEATEN_MINES,
		CustomDungeonFlags.ALLJAMMED_BEATEN_RAT,
		CustomDungeonFlags.ALLJAMMED_BEATEN_HOLLOW,
		CustomDungeonFlags.ALLJAMMED_BEATEN_OFFICE,
		CustomDungeonFlags.ALLJAMMED_BEATEN_FORGE,
		CustomDungeonFlags.ALLJAMMED_BEATEN_HELL,
		CustomDungeonFlags.BOSSRUSH_SHADE,
		CustomDungeonFlags.BOSSRUSH_PARADOX,
		CustomDungeonFlags.BOSSRUSH_CONVICT,
		CustomDungeonFlags.BOSSRUSH_PILOT,
		CustomDungeonFlags.BOSSRUSH_GUNSLINGER,
		CustomDungeonFlags.BOSSRUSH_HUNTER,
		CustomDungeonFlags.BOSSRUSH_MARINE,
		CustomDungeonFlags.BOSSRUSH_ROBOT,
		CustomDungeonFlags.BOSSRUSH_BULLET,
		CustomDungeonFlags.ADVDRAGUN_KILLED_ROBOT,
		CustomDungeonFlags.ADVDRAGUN_KILLED_SHADE,
		CustomDungeonFlags.CHALLENGE_WHATARMY_BEATEN,
		CustomDungeonFlags.CHALLENGE_TOILANDTROUBLE_BEATEN,
		CustomDungeonFlags.CHALLENGE_INVISIBLEO_BEATEN,
		CustomDungeonFlags.CHALLENGE_KEEPITCOOL_BEATEN,
		CustomDungeonFlags.DRAGUN_KILLED_SHADE,
		CustomDungeonFlags.LICH_BEATEN_SHADE,
		CustomDungeonFlags.CHEATED_DEATH_SHADE,
		CustomDungeonFlags.MISFIREBEAST_QUEST_COMPLETE,
		CustomDungeonFlags.NITRA_QUEST_COMPLETE,
		CustomDungeonFlags.GUNCULTIST_QUEST_COMPLETE,
		CustomDungeonFlags.PHASERSPIDER_QUEST_COMPLETE,
		CustomDungeonFlags.JAMMEDBULLETKIN_QUEST_COMPLETE,
		CustomDungeonFlags.JAMMEDSHOTGUNKIN_QUEST_COMPLETE,
		CustomDungeonFlags.JAMMEDLEADMAIDEN_QUEST_COMPLETE,
		CustomDungeonFlags.JAMMEDBULLETSHARK_QUEST_COMPLETE,
		CustomDungeonFlags.JAMMEDGUNNUT_QUEST_COMPLETE,
		CustomDungeonFlags.KEVIN_QUEST_COMPLETE,
		CustomDungeonFlags.MISFIREBEAST_QUEST_REWARDED,
		CustomDungeonFlags.NITRA_QUEST_REWARDED,
		CustomDungeonFlags.GUNCULTIST_QUEST_REWARDED,
		CustomDungeonFlags.PHASERSPIDER_QUEST_REWARDED,
		CustomDungeonFlags.JAMMEDBULLETKIN_QUEST_REWARDED,
		CustomDungeonFlags.JAMMEDSHOTGUNKIN_QUEST_REWARDED,
		CustomDungeonFlags.JAMMEDLEADMAIDEN_QUEST_REWARDED,
		CustomDungeonFlags.JAMMEDBULLETSHARK_QUEST_REWARDED,
		CustomDungeonFlags.JAMMEDGUNNUT_QUEST_REWARDED,
		CustomDungeonFlags.KEVIN_QUEST_REWARDED,
		CustomDungeonFlags.PURCHASED_LOCKDOWNBULLETS,
		CustomDungeonFlags.PURCHASED_THETHINLINE,
		CustomDungeonFlags.PURCHASED_NITROBULLETS,
		CustomDungeonFlags.PURCHASED_KINAMMOLET,
		CustomDungeonFlags.PURCHASED_SHUTDOWNSHELLS,
		CustomDungeonFlags.PURCHASED_ERRORSHELLS,
		CustomDungeonFlags.PURCHASED_MEATSHIELD,
		CustomDungeonFlags.PURCHASED_MAGICMISSILE,
		CustomDungeonFlags.PURCHASED_MINERSBULLETS,
		CustomDungeonFlags.PURCHASED_RANDOROUNDS,
		CustomDungeonFlags.PURCHASED_PESTIFEROUSLEAD,
		CustomDungeonFlags.PURCHASED_THEOUTBREAK,
		CustomDungeonFlags.PURCHASED_SHRINKSHOT,
		CustomDungeonFlags.PURCHASED_BRONZEAMMOLET,
		CustomDungeonFlags.PURCHASED_HEPATIZONAMMOLET,
		CustomDungeonFlags.PURCHASED_HEMATICROUNDS,
		CustomDungeonFlags.PURCHASED_BABYGOODDET,
		CustomDungeonFlags.PURCHASED_NEUTRONIUMAMMOLET,
		CustomDungeonFlags.PURCHASED_BATTERBULLETS,
		CustomDungeonFlags.PURCHASED_TRACERROUNDS,
		CustomDungeonFlags.PURCHASED_BAZOOKA,
		CustomDungeonFlags.PURCHASED_ANTIMATERIELRIFLE,
		CustomDungeonFlags.PURCHASED_RIOTGUN,
		CustomDungeonFlags.PURCHASED_UNENGRAVEDBULLETS,
		CustomDungeonFlags.PURCHASED_SPRINGLOADEDCHAMBER,
		CustomDungeonFlags.PURCHASED_GRENADESHOTGUN,
		CustomDungeonFlags.PURCHASED_LOUDENBOOMER,
		CustomDungeonFlags.PURCHASED_GRACEFULGOOP,
		CustomDungeonFlags.PURCHASED_GOOMPERORSCROWN,
		CustomDungeonFlags.PURCHASED_VACUUMGUN,
		CustomDungeonFlags.PURCHASED_ALKALIBULLETS,
		CustomDungeonFlags.PURCHASED_VISCERIFLE,
		CustomDungeonFlags.PURCHASED_LIQUIDMETALBODY,
		CustomDungeonFlags.PURCHASED_LOVEPOTION,
		CustomDungeonFlags.PURCHASED_SPEEDPOTION,
		CustomDungeonFlags.PURCHASED_SANCTIFIEDOIL,
		CustomDungeonFlags.PURCHASED_SNAILBULLETS,
		CustomDungeonFlags.PURCHASED_SPORELAUNCHER,
		CustomDungeonFlags.PURCHASED_RISKRIFLE,
		CustomDungeonFlags.PURCHASED_CREDITOR,
		CustomDungeonFlags.PURCHASED_OVERPRICEDHEADBAND,
		CustomDungeonFlags.PURCHASED_POWERARMOUR,
		CustomDungeonFlags.PURCHASED_RECYCLINDER,
		CustomDungeonFlags.PURCHASED_BLASMASTER,
		CustomDungeonFlags.PURCHASED_DARTRIFLE,
		CustomDungeonFlags.PURCHASED_DEMOLITIONIST,
		CustomDungeonFlags.PURCHASED_REPEATOVOLVER,
		CustomDungeonFlags.PURCHASED_SPIRAL,
		CustomDungeonFlags.PURCHASED_STUNGUN,
		CustomDungeonFlags.PURCHASED_DRONE,
		CustomDungeonFlags.PURCHASED_AUTOGUN,
		CustomDungeonFlags.PURCHASED_REBONDIR,
		CustomDungeonFlags.PURCHASED_CONVERTER
	};

	public static void Init()
	{
		if (true)
		{
			return;
		}
		ETGModConsole.Commands.GetGroup("nn").AddUnit("cheatunlocks", (Action<string[]>)delegate
		{
			foreach (CustomDungeonFlags item in flagsToSet)
			{
				if (!SaveAPIManager.GetFlag(item))
				{
					SaveAPIManager.SetFlag(item, value: true);
				}
			}
			SaveAPIManager.RegisterStatChange(CustomTrackedStats.TITAN_KIN_KILLED, 5f);
			SaveAPIManager.RegisterStatChange(CustomTrackedStats.BEHOLSTER_KILLS, 20f);
			SaveAPIManager.RegisterStatChange(CustomTrackedStats.MINEFLAYER_KILLS, 20f);
			SaveAPIManager.RegisterStatChange(CustomTrackedStats.CHARMED_ENEMIES_KILLED, 100f);
			SaveAPIManager.RegisterStatChange(CustomTrackedStats.JAMMED_CHESTS_OPENED, 100f);
			SaveAPIManager.RegisterStatChange(CustomTrackedStats.RUSTY_ITEMS_PURCHASED, 100f);
			SaveAPIManager.RegisterStatChange(CustomTrackedStats.RUSTY_ITEMS_STOLEN, 100f);
			SaveAPIManager.UpdateMaximum(CustomTrackedMaximums.MAX_HEART_CONTAINERS_EVER, 10f);
			ETGModConsole.Log((object)"<color=#00d6e6>You cheated not only the game, but yourself.</color>", false);
			ETGModConsole.Log((object)"<color=#00d6e6>You didn't grow.</color>", false);
			ETGModConsole.Log((object)"<color=#00d6e6>You didn't improve.</color>", false);
			ETGModConsole.Log((object)"<color=#00d6e6>You took a shortcut and gained nothing.</color>", false);
			ETGModConsole.Log((object)"<color=#00d6e6>You experienced a hollow victory. Nothing was risked and nothing was gained.</color>", false);
			ETGModConsole.Log((object)"<color=#00d6e6>It's sad you don't know the difference.</color>", false);
		});
	}
}
