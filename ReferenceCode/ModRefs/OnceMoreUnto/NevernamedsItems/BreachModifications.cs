using System;
using System.Collections.Generic;
using Alexandria.ItemAPI;
using Alexandria.Misc;
using HarmonyLib;
using UnityEngine;

namespace NevernamedsItems;

public static class BreachModifications
{
	[HarmonyPatch(typeof(Foyer), "ProcessPlayerEnteredFoyer")]
	private class ProcessPlayerEnteredFoyerPatch
	{
		private static void Postfix(Foyer __instance, PlayerController p)
		{
			if (needsToRun)
			{
				OnBreachStart();
				needsToRun = false;
			}
		}
	}

	[HarmonyPatch(typeof(Foyer), "Start")]
	private class OnFoyerStartPatch
	{
		private static void Postfix(Foyer __instance)
		{
			needsToRun = true;
		}
	}

	public static List<GameObject> placedInBreach = new List<GameObject>();

	private static bool needsToRun;

	public static Dictionary<string, GameObject> registeredShops = new Dictionary<string, GameObject>();

	private static void CleanupBreachObjects()
	{
		BreachPlacedItem[] array = Object.FindObjectsOfType<BreachPlacedItem>();
		foreach (BreachPlacedItem breachPlacedItem in array)
		{
			if (!FakePrefab.IsFakePrefab((Object)(object)((Component)breachPlacedItem).gameObject))
			{
				Object.Destroy((Object)(object)((Component)breachPlacedItem).gameObject);
			}
			else
			{
				((Component)breachPlacedItem).gameObject.SetActive(false);
			}
		}
	}

	public static void OnBreachStart()
	{
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		CleanupBreachObjects();
		foreach (GameObject item in placedInBreach)
		{
			try
			{
				GameObject val = Object.Instantiate<GameObject>(item);
				BreachPlacedItem component = item.GetComponent<BreachPlacedItem>();
				val.SetActive(true);
				val.transform.position = Vector2.op_Implicit(component.positionInBreach);
			}
			catch (Exception ex)
			{
				DebugUtility.Print<string>(ex.ToString(), "FF0000", true);
			}
		}
	}
}
