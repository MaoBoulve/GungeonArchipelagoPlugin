using System;
using System.Collections.Generic;
using Dungeonator;
using UnityEngine;

namespace NevernamedsItems;

internal class DeconstructDungeon
{
	protected static AutocompletionSettings deconstructAutocomplete = new AutocompletionSettings((Func<string, string[]>)delegate
	{
		List<string> list = new List<string>
		{
			"base_jungle", "base_cathedral", "base_sewer", "base_nakatomi", "base_castle", "base_catacombs", "base_forge", "base_foyer", "base_gungeon", "base_mines",
			"base_nakatomi", "base_resourcefulrat", "base_tutorial"
		};
		return list.ToArray();
	});

	public static void Init()
	{
		ETGModConsole.Commands.GetGroup("nn").AddUnit("deconstructdungeon", (Action<string[]>)delegate(string[] args)
		{
			string text = "UNDEFINED";
			if (args != null && args.Length != 0 && args[0] != null && !string.IsNullOrEmpty(args[0]))
			{
				text = args[0];
			}
			if ((Object)(object)GameManager.Instance == (Object)null)
			{
				ETGModConsole.Log((object)"Somehow the fucking game manager was null lol rip get fucked mate.", false);
			}
			else
			{
				ETGModConsole.Log((object)"<color=#09b022>-------------------------------------</color>", false);
				ETGModConsole.Log((object)("<color=#09b022>Checking for Dungeon:</color> " + text), false);
				bool flag = false;
				Dungeon orLoadByName = DungeonDatabase.GetOrLoadByName(text);
				if ((Object)(object)orLoadByName == (Object)null)
				{
					ETGModConsole.Log((object)"<color=#ff0000ff>COULD NOT FIND DUNGEON</color>", false);
				}
				else
				{
					ETGModConsole.Log((object)"<color=#4dfffc>Pattern Settings:</color>", false);
					if (Object.op_Implicit((Object)(object)orLoadByName) && orLoadByName.PatternSettings != null)
					{
						ETGModConsole.Log((object)"<color=#4dfffc>  Flows:</color>", false);
						if (orLoadByName.PatternSettings.flows != null && orLoadByName.PatternSettings.flows.Count > 0)
						{
							int num = 0;
							foreach (DungeonFlow flow in orLoadByName.PatternSettings.flows)
							{
								ETGModConsole.Log((object)$"<color=#4dfffc>  Flow {num} ({((Object)flow).name}):</color>", false);
								ETGModConsole.Log((object)"<color=#4dfffc>    Injections:</color>", false);
								if (flow.flowInjectionData != null && flow.flowInjectionData.Count > 0)
								{
									int num2 = 0;
									foreach (ProceduralFlowModifierData flowInjectionDatum in flow.flowInjectionData)
									{
										ETGModConsole.Log((object)$"<color=#4dfffc>     Injection {num2}:</color>", false);
										DeconstructThing(flowInjectionDatum);
										num2++;
									}
								}
								else
								{
									ETGModConsole.Log((object)"<color=#ff0000ff>    Injections table was null or empty.</color>", false);
								}
								ETGModConsole.Log((object)"<color=#4dfffc>    Shared Injections:</color>", false);
								if (flow.sharedInjectionData != null && flow.sharedInjectionData.Count > 0)
								{
									int num3 = 0;
									foreach (SharedInjectionData sharedInjectionDatum in flow.sharedInjectionData)
									{
										ETGModConsole.Log((object)$"<color=#4dfffc>     Shared Inj {num3}:</color>", false);
										if (sharedInjectionDatum.InjectionData != null && sharedInjectionDatum.InjectionData.Count > 0)
										{
											int num4 = 0;
											foreach (ProceduralFlowModifierData injectionDatum in sharedInjectionDatum.InjectionData)
											{
												ETGModConsole.Log((object)$"<color=#4dfffc>         Injection {num4}:</color>", false);
												DeconstructThing(injectionDatum, "         ");
												num4++;
											}
										}
										else
										{
											ETGModConsole.Log((object)"<color=#ff0000ff>    Injections table was null or empty.</color>", false);
										}
										num3++;
									}
								}
								else
								{
									ETGModConsole.Log((object)"<color=#ff0000ff>    Shared Injections table was null or empty.</color>", false);
								}
								ETGModConsole.Log((object)"<color=#4dfffc>     Rooms:</color>", false);
								if ((Object)(object)flow.fallbackRoomTable != (Object)null)
								{
									if (flow.fallbackRoomTable.includedRooms != null)
									{
										if (flow.fallbackRoomTable.includedRooms.elements != null)
										{
											if (flag)
											{
												ETGModConsole.Log((object)$"     Number of Rooms: {flow.fallbackRoomTable.includedRooms.elements.Count}", false);
											}
											else
											{
												flag = true;
												foreach (WeightedRoom element in flow.fallbackRoomTable.includedRooms.elements)
												{
													if ((Object)(object)element.room != (Object)null && !string.IsNullOrEmpty(((Object)element.room).name))
													{
														ETGModConsole.Log((object)("     " + ((Object)element.room).name), false);
													}
												}
											}
										}
										else
										{
											ETGModConsole.Log((object)"<color=#ff0000ff>       Fallback room table had no elements.</color>", false);
										}
									}
									else
									{
										ETGModConsole.Log((object)"<color=#ff0000ff>       Fallback room table had no room collection.</color>", false);
									}
								}
								else
								{
									ETGModConsole.Log((object)"<color=#ff0000ff>       Fallback room table was null.</color>", false);
								}
								num++;
							}
						}
						else
						{
							ETGModConsole.Log((object)"<color=#ff0000ff>        Flows were null or empty</color>", false);
						}
					}
					else
					{
						ETGModConsole.Log((object)"<color=#ff0000ff>    Pattern settings null</color>", false);
					}
				}
				orLoadByName = null;
			}
		}, deconstructAutocomplete);
	}

	public static void DeconstructThing(ProceduralFlowModifierData flowmod, string gap = "     ")
	{
		//IL_0108: Unknown result type (might be due to invalid IL or missing references)
		//IL_010d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0115: Unknown result type (might be due to invalid IL or missing references)
		ETGModConsole.Log((object)(gap + "Annotation: " + flowmod.annotation), false);
		ETGModConsole.Log((object)$"{gap}OncePerRun: {flowmod.OncePerRun}", false);
		ETGModConsole.Log((object)$"{gap}IsWarpWing: {flowmod.IsWarpWing}", false);
		ETGModConsole.Log((object)$"{gap}RequiresMasteryToken: {flowmod.RequiresMasteryToken}", false);
		ETGModConsole.Log((object)$"{gap}ChanceToLock: {flowmod.chanceToLock}", false);
		ETGModConsole.Log((object)$"{gap}SelectionWeight: {flowmod.selectionWeight}", false);
		ETGModConsole.Log((object)$"{gap}ChanceToSpawn: {flowmod.chanceToSpawn}", false);
		ETGModConsole.Log((object)(gap + "Placement Rules:"), false);
		if (flowmod.placementRules != null && flowmod.placementRules.Count > 0)
		{
			foreach (FlowModifierPlacementType placementRule in flowmod.placementRules)
			{
				ETGModConsole.Log((object)$"{gap}    {placementRule}", false);
			}
		}
		else
		{
			ETGModConsole.Log((object)(gap + "    None"), false);
		}
		if (Object.op_Implicit((Object)(object)flowmod.RequiredValidPlaceable))
		{
			ETGModConsole.Log((object)(gap + "RequiredValidPlaceable: " + ((Object)flowmod.RequiredValidPlaceable).name), false);
		}
		else
		{
			ETGModConsole.Log((object)(gap + "RequiredValidPlaceable: None"), false);
		}
		ETGModConsole.Log((object)("<color=#4dfffc>" + gap + "Exact Room:</color>"), false);
		if (Object.op_Implicit((Object)(object)flowmod.exactRoom))
		{
			ETGModConsole.Log((object)(gap + "   " + ((Object)flowmod.exactRoom).name), false);
		}
		else
		{
			ETGModConsole.Log((object)(gap + "    None"), false);
		}
		ETGModConsole.Log((object)("<color=#4dfffc>" + gap + "Secondary Exact Room:</color>"), false);
		if (Object.op_Implicit((Object)(object)flowmod.exactSecondaryRoom))
		{
			ETGModConsole.Log((object)(gap + "   " + ((Object)flowmod.exactSecondaryRoom).name), false);
		}
		else
		{
			ETGModConsole.Log((object)(gap + "    None"), false);
		}
		ETGModConsole.Log((object)("<color=#4dfffc>" + gap + "Room Table:</color>"), false);
		if ((Object)(object)flowmod.roomTable != (Object)null && flowmod.roomTable.includedRooms != null && flowmod.roomTable.includedRooms.elements != null && flowmod.roomTable.includedRooms.elements.Count > 0)
		{
			foreach (WeightedRoom element in flowmod.roomTable.includedRooms.elements)
			{
				if ((Object)(object)element.room != (Object)null && !string.IsNullOrEmpty(((Object)element.room).name))
				{
					ETGModConsole.Log((object)(gap + "   " + ((Object)element.room).name), false);
				}
			}
			return;
		}
		ETGModConsole.Log((object)(gap + "    None"), false);
	}
}
