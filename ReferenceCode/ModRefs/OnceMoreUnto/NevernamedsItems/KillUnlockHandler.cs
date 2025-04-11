using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Alexandria.ItemAPI;
using Alexandria.Misc;
using SaveAPI;
using UnityEngine;

namespace NevernamedsItems;

public static class KillUnlockHandler
{
	[CompilerGenerated]
	private sealed class _003CSaveDeaths_003Ed__2 : IEnumerator<object>, IDisposable, IEnumerator
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public string guid;

		public bool jammed;

		public bool charmed;

		public PlayableCharacters primaryplayerid;

		public bool anyPlayerOnHalfHeart;

		private AIActor _003CprefabForGUID_003E5__1;

		private ValidTilesets _003CcurrentTileset_003E5__2;

		private bool _003CallJammed_003E5__3;

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
		public _003CSaveDeaths_003Ed__2(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			_003CprefabForGUID_003E5__1 = null;
			_003C_003E1__state = -2;
		}

		private bool MoveNext()
		{
			//IL_0039: Unknown result type (might be due to invalid IL or missing references)
			//IL_003e: Unknown result type (might be due to invalid IL or missing references)
			//IL_018a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0190: Invalid comparison between Unknown and I4
			//IL_01c7: Unknown result type (might be due to invalid IL or missing references)
			//IL_01e9: Unknown result type (might be due to invalid IL or missing references)
			//IL_0212: Unknown result type (might be due to invalid IL or missing references)
			//IL_039f: Unknown result type (might be due to invalid IL or missing references)
			//IL_03a5: Invalid comparison between Unknown and I4
			//IL_0554: Unknown result type (might be due to invalid IL or missing references)
			//IL_055b: Invalid comparison between Unknown and I4
			//IL_056a: Unknown result type (might be due to invalid IL or missing references)
			//IL_03d1: Unknown result type (might be due to invalid IL or missing references)
			//IL_057c: Unknown result type (might be due to invalid IL or missing references)
			//IL_03e8: Unknown result type (might be due to invalid IL or missing references)
			//IL_03f3: Unknown result type (might be due to invalid IL or missing references)
			//IL_0463: Unknown result type (might be due to invalid IL or missing references)
			//IL_040a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0415: Unknown result type (might be due to invalid IL or missing references)
			//IL_059d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0475: Unknown result type (might be due to invalid IL or missing references)
			//IL_0433: Unknown result type (might be due to invalid IL or missing references)
			//IL_043e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0496: Unknown result type (might be due to invalid IL or missing references)
			//IL_04b5: Unknown result type (might be due to invalid IL or missing references)
			//IL_04c7: Unknown result type (might be due to invalid IL or missing references)
			//IL_04e8: Unknown result type (might be due to invalid IL or missing references)
			//IL_050b: Unknown result type (might be due to invalid IL or missing references)
			//IL_051d: Unknown result type (might be due to invalid IL or missing references)
			//IL_053e: Unknown result type (might be due to invalid IL or missing references)
			if (_003C_003E1__state != 0)
			{
				return false;
			}
			_003C_003E1__state = -1;
			_003CprefabForGUID_003E5__1 = EnemyDatabase.GetOrLoadByGuid(guid);
			_003CcurrentTileset_003E5__2 = GameManager.Instance.Dungeon.tileIndices.tilesetId;
			_003CallJammed_003E5__3 = SaveAPIManager.GetFlag(CustomDungeonFlags.ALLJAMMEDMODE_ENABLED_GENUINE);
			if (charmed)
			{
				SaveAPIManager.RegisterStatChange(CustomTrackedStats.CHARMED_ENEMIES_KILLED, 1f);
			}
			if (guid == EnemyGuidDatabase.Entries["key_bullet_kin"] && jammed && !SaveAPIManager.GetFlag(CustomDungeonFlags.KILLEDJAMMEDKEYBULLETKIN))
			{
				SaveAPIManager.SetFlag(CustomDungeonFlags.KILLEDJAMMEDKEYBULLETKIN, value: true);
			}
			if (guid == EnemyGuidDatabase.Entries["chance_bullet_kin"] && jammed && !SaveAPIManager.GetFlag(CustomDungeonFlags.KILLEDJAMMEDCHANCEKIN))
			{
				SaveAPIManager.SetFlag(CustomDungeonFlags.KILLEDJAMMEDCHANCEKIN, value: true);
			}
			if ((Object)(object)_003CprefabForGUID_003E5__1 != (Object)null)
			{
				if (AlexandriaTags.HasTag(_003CprefabForGUID_003E5__1, "titan_bullet_kin"))
				{
					SaveAPIManager.RegisterStatChange(CustomTrackedStats.TITAN_KIN_KILLED, 1f);
				}
				if ((AlexandriaTags.HasTag(_003CprefabForGUID_003E5__1, "mimic") & jammed) && !SaveAPIManager.GetFlag(CustomDungeonFlags.KILLEDJAMMEDMIMIC))
				{
					SaveAPIManager.SetFlag(CustomDungeonFlags.KILLEDJAMMEDMIMIC, value: true);
				}
			}
			if (StatsToIncrementOnEnemyKill.ContainsKey(guid))
			{
				SaveAPIManager.RegisterStatChange(StatsToIncrementOnEnemyKill[guid], 1f);
			}
			if ((int)GameManager.Instance.CurrentGameMode != 2)
			{
				if (CharacterSpecificBossSpecificUnlocks.ContainsKey(guid) && CharacterSpecificBossSpecificUnlocks[guid].ContainsKey(primaryplayerid) && !SaveAPIManager.GetFlag(CharacterSpecificBossSpecificUnlocks[guid][primaryplayerid]))
				{
					SaveAPIManager.SetFlag(CharacterSpecificBossSpecificUnlocks[guid][primaryplayerid], value: true);
				}
				if (GameStatsManager.Instance.isTurboMode && TurboModeSpecificBossUnlocks.ContainsKey(guid) && !SaveAPIManager.GetFlag(TurboModeSpecificBossUnlocks[guid]))
				{
					SaveAPIManager.SetFlag(TurboModeSpecificBossUnlocks[guid], value: true);
				}
				if (_003CallJammed_003E5__3 && AllJammedSpecificBossUnlocks.ContainsKey(guid) && !SaveAPIManager.GetFlag(AllJammedSpecificBossUnlocks[guid]))
				{
					SaveAPIManager.SetFlag(AllJammedSpecificBossUnlocks[guid], value: true);
				}
				if (GameStatsManager.Instance.IsRainbowRun && RainbowModeSpecificBossUnlocks.ContainsKey(guid) && !SaveAPIManager.GetFlag(RainbowModeSpecificBossUnlocks[guid]))
				{
					SaveAPIManager.SetFlag(RainbowModeSpecificBossUnlocks[guid], value: true);
				}
			}
			if ((Object)(object)_003CprefabForGUID_003E5__1 != (Object)null && Object.op_Implicit((Object)(object)((BraveBehaviour)_003CprefabForGUID_003E5__1).healthHaver) && ((BraveBehaviour)_003CprefabForGUID_003E5__1).healthHaver.IsBoss && !((BraveBehaviour)_003CprefabForGUID_003E5__1).healthHaver.IsSubboss)
			{
				if (anyPlayerOnHalfHeart && !SaveAPIManager.GetFlag(CustomDungeonFlags.HAS_BEATEN_BOSS_BY_SKIN_OF_TEETH))
				{
					SaveAPIManager.SetFlag(CustomDungeonFlags.HAS_BEATEN_BOSS_BY_SKIN_OF_TEETH, value: true);
				}
				if ((int)GameManager.Instance.CurrentGameMode != 2)
				{
					if (!GameManager.Instance.InTutorial)
					{
						if (CharacterSpecificFloorSpecificUnlocks.ContainsKey(_003CcurrentTileset_003E5__2) && CharacterSpecificFloorSpecificUnlocks[_003CcurrentTileset_003E5__2].ContainsKey(primaryplayerid) && !SaveAPIManager.GetFlag(CharacterSpecificFloorSpecificUnlocks[_003CcurrentTileset_003E5__2][primaryplayerid]))
						{
							SaveAPIManager.SetFlag(CharacterSpecificFloorSpecificUnlocks[_003CcurrentTileset_003E5__2][primaryplayerid], value: true);
						}
						if (GameStatsManager.Instance.isTurboMode && TurboModeFloorUnlocks.ContainsKey(_003CcurrentTileset_003E5__2) && !SaveAPIManager.GetFlag(TurboModeFloorUnlocks[_003CcurrentTileset_003E5__2]))
						{
							SaveAPIManager.SetFlag(TurboModeFloorUnlocks[_003CcurrentTileset_003E5__2], value: true);
						}
						if (_003CallJammed_003E5__3 && AllJammedFloorUnlocks.ContainsKey(_003CcurrentTileset_003E5__2) && !SaveAPIManager.GetFlag(AllJammedFloorUnlocks[_003CcurrentTileset_003E5__2]))
						{
							SaveAPIManager.SetFlag(AllJammedFloorUnlocks[_003CcurrentTileset_003E5__2], value: true);
						}
						if (GameStatsManager.Instance.IsRainbowRun && RainbowModeFloorUnlocks.ContainsKey(_003CcurrentTileset_003E5__2) && !SaveAPIManager.GetFlag(RainbowModeFloorUnlocks[_003CcurrentTileset_003E5__2]))
						{
							SaveAPIManager.SetFlag(RainbowModeFloorUnlocks[_003CcurrentTileset_003E5__2], value: true);
						}
					}
				}
				else if ((int)_003CcurrentTileset_003E5__2 == 64 && BossrushUnlocks.ContainsKey(primaryplayerid) && !SaveAPIManager.GetFlag(BossrushUnlocks[primaryplayerid]))
				{
					SaveAPIManager.SetFlag(BossrushUnlocks[primaryplayerid], value: true);
				}
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

	public static Dictionary<string, CustomTrackedStats> StatsToIncrementOnEnemyKill;

	public static Dictionary<ValidTilesets, Dictionary<PlayableCharacters, CustomDungeonFlags>> CharacterSpecificFloorSpecificUnlocks;

	public static Dictionary<string, Dictionary<PlayableCharacters, CustomDungeonFlags>> CharacterSpecificBossSpecificUnlocks;

	public static Dictionary<ValidTilesets, CustomDungeonFlags> TurboModeFloorUnlocks;

	public static Dictionary<ValidTilesets, CustomDungeonFlags> AllJammedFloorUnlocks;

	public static Dictionary<ValidTilesets, CustomDungeonFlags> RainbowModeFloorUnlocks;

	public static Dictionary<string, CustomDungeonFlags> TurboModeSpecificBossUnlocks;

	public static Dictionary<string, CustomDungeonFlags> AllJammedSpecificBossUnlocks;

	public static Dictionary<string, CustomDungeonFlags> RainbowModeSpecificBossUnlocks;

	public static Dictionary<PlayableCharacters, CustomDungeonFlags> BossrushUnlocks;

	public static void Init()
	{
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_0136: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b0: Unknown result type (might be due to invalid IL or missing references)
		CustomActions.OnAnyHealthHaverDie = (Action<HealthHaver>)Delegate.Combine(CustomActions.OnAnyHealthHaverDie, new Action<HealthHaver>(AnyHealthHaverKilled));
		StatsToIncrementOnEnemyKill = new Dictionary<string, CustomTrackedStats>
		{
			{
				"4b992de5b4274168a8878ef9bf7ea36b",
				CustomTrackedStats.BEHOLSTER_KILLS
			},
			{
				"8b0dd96e2fe74ec7bebc1bc689c0008a",
				CustomTrackedStats.MINEFLAYER_KILLS
			},
			{
				"9189f46c47564ed588b9108965f975c9",
				CustomTrackedStats.DOOR_LORD_KILLS
			}
		};
		CharacterSpecificFloorSpecificUnlocks = new Dictionary<ValidTilesets, Dictionary<PlayableCharacters, CustomDungeonFlags>> { 
		{
			(ValidTilesets)64,
			new Dictionary<PlayableCharacters, CustomDungeonFlags>
			{
				{
					(PlayableCharacters)6,
					CustomDungeonFlags.DRAGUN_KILLED_HUNTER
				},
				{
					ETGModCompatibility.ExtendEnum<PlayableCharacters>("nevernamed.etg.omitb", "Shade"),
					CustomDungeonFlags.DRAGUN_KILLED_SHADE
				}
			}
		} };
		CharacterSpecificBossSpecificUnlocks = new Dictionary<string, Dictionary<PlayableCharacters, CustomDungeonFlags>>
		{
			{
				"7c5d5f09911e49b78ae644d2b50ff3bf",
				new Dictionary<PlayableCharacters, CustomDungeonFlags>
				{
					{
						(PlayableCharacters)9,
						CustomDungeonFlags.UNLOCKED_MISSINGUNO
					},
					{
						ETGModCompatibility.ExtendEnum<PlayableCharacters>("nevernamed.etg.omitb", "Shade"),
						CustomDungeonFlags.LICH_BEATEN_SHADE
					}
				}
			},
			{
				"05b8afe0b6cc4fffa9dc6036fa24c8ec",
				new Dictionary<PlayableCharacters, CustomDungeonFlags>
				{
					{
						(PlayableCharacters)2,
						CustomDungeonFlags.ADVDRAGUN_KILLED_ROBOT
					},
					{
						(PlayableCharacters)8,
						CustomDungeonFlags.ADVDRAGUN_KILLED_BULLET
					},
					{
						ETGModCompatibility.ExtendEnum<PlayableCharacters>("nevernamed.etg.omitb", "Shade"),
						CustomDungeonFlags.ADVDRAGUN_KILLED_SHADE
					}
				}
			},
			{
				"4d164ba3f62648809a4a82c90fc22cae",
				new Dictionary<PlayableCharacters, CustomDungeonFlags>
				{
					{
						(PlayableCharacters)0,
						CustomDungeonFlags.RAT_KILLED_PILOT
					},
					{
						(PlayableCharacters)2,
						CustomDungeonFlags.RAT_KILLED_ROBOT
					},
					{
						(PlayableCharacters)8,
						CustomDungeonFlags.RAT_KILLED_BULLET
					},
					{
						ETGModCompatibility.ExtendEnum<PlayableCharacters>("nevernamed.etg.omitb", "Shade"),
						CustomDungeonFlags.RAT_KILLED_SHADE
					}
				}
			}
		};
		BossrushUnlocks = new Dictionary<PlayableCharacters, CustomDungeonFlags>
		{
			{
				(PlayableCharacters)0,
				CustomDungeonFlags.BOSSRUSH_PILOT
			},
			{
				(PlayableCharacters)6,
				CustomDungeonFlags.BOSSRUSH_HUNTER
			},
			{
				(PlayableCharacters)5,
				CustomDungeonFlags.BOSSRUSH_MARINE
			},
			{
				(PlayableCharacters)1,
				CustomDungeonFlags.BOSSRUSH_CONVICT
			},
			{
				(PlayableCharacters)2,
				CustomDungeonFlags.BOSSRUSH_ROBOT
			},
			{
				(PlayableCharacters)8,
				CustomDungeonFlags.BOSSRUSH_BULLET
			},
			{
				(PlayableCharacters)10,
				CustomDungeonFlags.BOSSRUSH_GUNSLINGER
			},
			{
				(PlayableCharacters)9,
				CustomDungeonFlags.BOSSRUSH_PARADOX
			},
			{
				ETGModCompatibility.ExtendEnum<PlayableCharacters>("nevernamed.etg.omitb", "Shade"),
				CustomDungeonFlags.BOSSRUSH_SHADE
			}
		};
		TurboModeFloorUnlocks = new Dictionary<ValidTilesets, CustomDungeonFlags>
		{
			{
				(ValidTilesets)2,
				CustomDungeonFlags.BEATEN_KEEP_TURBO_MODE
			},
			{
				(ValidTilesets)16,
				CustomDungeonFlags.BEATEN_MINES_BOSS_TURBO_MODE
			},
			{
				(ValidTilesets)32,
				CustomDungeonFlags.BEATEN_HOLLOW_BOSS_TURBO_MODE
			}
		};
		TurboModeSpecificBossUnlocks = new Dictionary<string, CustomDungeonFlags>
		{
			{
				"7c5d5f09911e49b78ae644d2b50ff3bf",
				CustomDungeonFlags.BEATEN_HELL_BOSS_TURBO_MODE
			},
			{
				"4d164ba3f62648809a4a82c90fc22cae",
				CustomDungeonFlags.BEATEN_RAT_BOSS_TURBO_MODE
			}
		};
		AllJammedFloorUnlocks = new Dictionary<ValidTilesets, CustomDungeonFlags>
		{
			{
				(ValidTilesets)2,
				CustomDungeonFlags.ALLJAMMED_BEATEN_KEEP
			},
			{
				(ValidTilesets)4,
				CustomDungeonFlags.ALLJAMMED_BEATEN_OUB
			},
			{
				(ValidTilesets)1,
				CustomDungeonFlags.ALLJAMMED_BEATEN_PROPER
			},
			{
				(ValidTilesets)8,
				CustomDungeonFlags.ALLJAMMED_BEATEN_ABBEY
			},
			{
				(ValidTilesets)16,
				CustomDungeonFlags.ALLJAMMED_BEATEN_MINES
			},
			{
				(ValidTilesets)32,
				CustomDungeonFlags.ALLJAMMED_BEATEN_HOLLOW
			},
			{
				(ValidTilesets)2048,
				CustomDungeonFlags.ALLJAMMED_BEATEN_OFFICE
			},
			{
				(ValidTilesets)64,
				CustomDungeonFlags.ALLJAMMED_BEATEN_FORGE
			}
		};
		AllJammedSpecificBossUnlocks = new Dictionary<string, CustomDungeonFlags>
		{
			{
				"7c5d5f09911e49b78ae644d2b50ff3bf",
				CustomDungeonFlags.ALLJAMMED_BEATEN_HELL
			},
			{
				"4d164ba3f62648809a4a82c90fc22cae",
				CustomDungeonFlags.ALLJAMMED_BEATEN_RAT
			},
			{
				"05b8afe0b6cc4fffa9dc6036fa24c8ec",
				CustomDungeonFlags.ALLJAMMED_BEATEN_ADVANCEDDRAGUN
			}
		};
		RainbowModeFloorUnlocks = new Dictionary<ValidTilesets, CustomDungeonFlags>();
		RainbowModeSpecificBossUnlocks = new Dictionary<string, CustomDungeonFlags> { 
		{
			"7c5d5f09911e49b78ae644d2b50ff3bf",
			CustomDungeonFlags.RAINBOW_KILLED_LICH
		} };
	}

	public static void AnyHealthHaverKilled(HealthHaver target)
	{
		//IL_010a: Unknown result type (might be due to invalid IL or missing references)
		if (!Object.op_Implicit((Object)(object)target) || !Object.op_Implicit((Object)(object)((BraveBehaviour)target).aiActor) || !Object.op_Implicit((Object)(object)GameManager.Instance.PrimaryPlayer))
		{
			return;
		}
		bool anyPlayerOnHalfHeart = false;
		PlayerController[] allPlayers = GameManager.Instance.AllPlayers;
		foreach (PlayerController val in allPlayers)
		{
			if (Object.op_Implicit((Object)(object)val) && Object.op_Implicit((Object)(object)((BraveBehaviour)val).healthHaver))
			{
				anyPlayerOnHalfHeart = (((BraveBehaviour)val).healthHaver.GetCurrentHealth() <= 0f && ((BraveBehaviour)val).healthHaver.Armor == 1f) || (((BraveBehaviour)val).healthHaver.GetCurrentHealth() <= 0.5f && ((BraveBehaviour)val).healthHaver.Armor == 0f);
			}
		}
		ETGMod.StartGlobalCoroutine(SaveDeaths(((BraveBehaviour)target).aiActor.EnemyGuid, ((BraveBehaviour)target).aiActor.IsBlackPhantom, ((BraveBehaviour)target).aiActor.CanTargetEnemies && !((BraveBehaviour)target).aiActor.CanTargetPlayers, GameManager.Instance.PrimaryPlayer.characterIdentity, anyPlayerOnHalfHeart));
	}

	public static IEnumerator SaveDeaths(string guid, bool jammed, bool charmed, PlayableCharacters primaryplayerid, bool anyPlayerOnHalfHeart)
	{
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CSaveDeaths_003Ed__2(0)
		{
			guid = guid,
			jammed = jammed,
			charmed = charmed,
			primaryplayerid = primaryplayerid,
			anyPlayerOnHalfHeart = anyPlayerOnHalfHeart
		};
	}
}
