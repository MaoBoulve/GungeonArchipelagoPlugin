using System;
using System.Collections.Generic;
using System.Reflection;
using Dungeonator;
using MonoMod.RuntimeDetour;
using SaveAPI;
using UnityEngine;

namespace NevernamedsItems;

internal class FloorAndGenerationToolbox
{
	public static Hook ratMazeFailHook;

	public static Hook floorLoadPlayerHook;

	public static Hook floorDepartureHook;

	public static Hook NewSessionStarted;

	public static Action OnFloorExited;

	public static Action OnFloorEntered;

	public static Action<PlayerController> OnNewGame;

	private static bool hookDoubleUpPrevention;

	public static List<string> CurrentFloorEnemyPalette;

	public static void Init()
	{
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Expected O, but got Unknown
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Expected O, but got Unknown
		//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ad: Expected O, but got Unknown
		//IL_00d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e3: Expected O, but got Unknown
		ratMazeFailHook = new Hook((MethodBase)typeof(ResourcefulRatMazeSystemController).GetMethod("HandleFailure", BindingFlags.Instance | BindingFlags.NonPublic), typeof(FloorAndGenerationToolbox).GetMethod("OnFailedRatMaze", BindingFlags.Static | BindingFlags.Public));
		floorLoadPlayerHook = new Hook((MethodBase)typeof(PlayerController).GetMethod("BraveOnLevelWasLoaded", BindingFlags.Instance | BindingFlags.Public), typeof(FloorAndGenerationToolbox).GetMethod("OnNewFloor", BindingFlags.Static | BindingFlags.Public));
		floorDepartureHook = new Hook((MethodBase)typeof(ElevatorDepartureController).GetMethod("DoDeparture", BindingFlags.Instance | BindingFlags.Public), typeof(FloorAndGenerationToolbox).GetMethod("OnFloorDeparture", BindingFlags.Instance | BindingFlags.Public), (object)typeof(ElevatorDepartureController));
		NewSessionStarted = new Hook((MethodBase)typeof(GameStatsManager).GetMethod("BeginNewSession", BindingFlags.Instance | BindingFlags.Public), typeof(FloorAndGenerationToolbox).GetMethod("NewSession", BindingFlags.Static | BindingFlags.Public));
	}

	public static void NewSession(Action<GameStatsManager, PlayerController> orig, GameStatsManager self, PlayerController player)
	{
		orig(self, player);
		if (OnNewGame != null)
		{
			OnNewGame(player);
		}
	}

	public static void OnFloorLoaded()
	{
		if (OnFloorEntered != null)
		{
			OnFloorEntered();
		}
	}

	public static void OnFloorUnloaded(List<PlayerController> Players)
	{
		if (OnFloorExited != null)
		{
			OnFloorExited();
		}
		foreach (PlayerController Player in Players)
		{
		}
		if (CurseManager.CurrentActiveCurses.Count > 0 && !SaveAPIManager.GetFlag(CustomDungeonFlags.FLOOR_CLEARED_WITH_CURSE))
		{
			SaveAPIManager.SetFlag(CustomDungeonFlags.FLOOR_CLEARED_WITH_CURSE, value: true);
		}
		CurseManager.RemoveAllCurses();
	}

	public static void OnNewFloor(Action<PlayerController> orig, PlayerController self)
	{
		bool flag = false;
		if (Object.op_Implicit((Object)(object)GameManager.Instance.SecondaryPlayer) && (Object)(object)GameManager.Instance.SecondaryPlayer == (Object)(object)self)
		{
			flag = true;
		}
		if (!flag || (flag && !Object.op_Implicit((Object)(object)GameManager.Instance.PrimaryPlayer)))
		{
			if (hookDoubleUpPrevention)
			{
				CurrentFloorEnemyPalette = GeneratePalette();
				Challenges.OnLevelLoaded();
				hookDoubleUpPrevention = false;
			}
			else
			{
				hookDoubleUpPrevention = true;
			}
		}
		orig(self);
	}

	public void OnFloorDeparture(Action<ElevatorDepartureController> orig, ElevatorDepartureController self)
	{
		orig(self);
	}

	private static bool EnemyIsValid(string enemyGUID, bool canReturnMimic, bool canReturnBoss)
	{
		if (enemyGUID != null)
		{
			AIActor orLoadByGuid = EnemyDatabase.GetOrLoadByGuid(enemyGUID);
			if (Object.op_Implicit((Object)(object)orLoadByGuid))
			{
				AIActor val = orLoadByGuid;
				if (orLoadByGuid is AIActorDummy && (Object)(object)((AIActorDummy)((orLoadByGuid is AIActorDummy) ? orLoadByGuid : null)).realPrefab.GetComponent<AIActor>() != (Object)null)
				{
					val = ((AIActorDummy)((orLoadByGuid is AIActorDummy) ? orLoadByGuid : null)).realPrefab.GetComponent<AIActor>();
				}
				if (((!canReturnMimic && !val.IsMimicEnemy) || canReturnMimic) && ((!canReturnBoss && Object.op_Implicit((Object)(object)((BraveBehaviour)val).healthHaver) && !((BraveBehaviour)val).healthHaver.IsBoss) || canReturnBoss))
				{
					return true;
				}
			}
		}
		return false;
	}

	public static List<string> GeneratePalette(bool canReturnMimics = false, bool canReturnBosses = false)
	{
		List<string> list = new List<string>();
		Dungeon dungeon = GameManager.Instance.Dungeon;
		if ((Object)(object)dungeon != (Object)null)
		{
			DungeonData data = dungeon.data;
			foreach (AIActor allEnemy in StaticReferenceManager.AllEnemies)
			{
				if ((Object)(object)((Component)allEnemy).GetComponent<CompanionController>() == (Object)null && EnemyIsValid(allEnemy.EnemyGuid, canReturnMimics, canReturnBosses) && !list.Contains(allEnemy.EnemyGuid))
				{
					list.Add(allEnemy.EnemyGuid);
				}
			}
			if (data != null)
			{
				foreach (RoomHandler room in data.rooms)
				{
					List<PrototypeRoomObjectLayer> remainingReinforcementLayers = room.remainingReinforcementLayers;
					if (remainingReinforcementLayers != null && remainingReinforcementLayers.Count > 0)
					{
						foreach (PrototypeRoomObjectLayer item in remainingReinforcementLayers)
						{
							if (item != null)
							{
								if (item.placedObjects != null)
								{
									foreach (PrototypePlacedObjectData placedObject in item.placedObjects)
									{
										if (placedObject != null)
										{
											if ((Object)(object)placedObject.unspecifiedContents != (Object)null)
											{
												if ((Object)(object)placedObject.unspecifiedContents.GetComponent<AIActor>() != (Object)null && EnemyIsValid(placedObject.unspecifiedContents.GetComponent<AIActor>().EnemyGuid, canReturnMimics, canReturnBosses) && !list.Contains(placedObject.unspecifiedContents.GetComponent<AIActor>().EnemyGuid))
												{
													list.Add(placedObject.unspecifiedContents.GetComponent<AIActor>().EnemyGuid);
												}
											}
											else if ((Object)(object)placedObject.placeableContents != (Object)null)
											{
												foreach (DungeonPlaceableVariant variantTier in placedObject.placeableContents.variantTiers)
												{
													if (variantTier.enemyPlaceableGuid != null && !list.Contains(variantTier.enemyPlaceableGuid))
													{
														list.Add(variantTier.enemyPlaceableGuid);
													}
												}
											}
											else
											{
												Debug.LogError((object)"unspecifiedContents AND placeableContents are NULL!");
											}
										}
										else
										{
											Debug.LogError((object)"Object data in the placed objects list is NULL!");
										}
									}
								}
								else
								{
									Debug.LogError((object)"List of placed objects in the layer is NULL!");
								}
							}
							else
							{
								Debug.LogError((object)"Individual object layer is NULL!");
							}
						}
					}
					else
					{
						Debug.Log((object)("There are no reinforcement waves in room: " + room.GetRoomName()));
					}
				}
			}
		}
		return list;
	}

	public static void OnFailedRatMaze(Action<ResourcefulRatMazeSystemController, PlayerController> orig, ResourcefulRatMazeSystemController self, PlayerController playa)
	{
		if (!SaveAPIManager.GetFlag(CustomDungeonFlags.FAILEDRATMAZE))
		{
			SaveAPIManager.SetFlag(CustomDungeonFlags.FAILEDRATMAZE, value: true);
		}
		orig(self, playa);
	}
}
