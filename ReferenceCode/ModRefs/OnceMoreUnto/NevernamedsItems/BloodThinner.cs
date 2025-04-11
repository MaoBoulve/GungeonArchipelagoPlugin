using System;
using System.Collections.Generic;
using System.Reflection;
using Alexandria.ItemAPI;
using MonoMod.RuntimeDetour;
using UnityEngine;

namespace NevernamedsItems;

public class BloodThinner : PassiveItem
{
	public static int BloodThinnerID;

	public static List<int> NonHeartLoot = new List<int> { 78, 600, 565, 120, 224, 67 };

	public static void Init()
	{
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		PickupObject obj = ItemSetup.NewItem<BloodThinner>("Blood Thinner", "Unnecessary Necessities", "Turns hearts into other consumables at full HP. Does not affect shops.\n\nPrevents blood clots. If you experience side effects such as light headedness, vomiting, nausea, projectile dysfunction, drowsiness, decreased apetite, or death, consult your doctor immediately.", "bloodthinner_icon", assetbundle: true);
		PassiveItem val = (PassiveItem)(object)((obj is PassiveItem) ? obj : null);
		((PickupObject)val).CanBeDropped = true;
		((PickupObject)val).quality = (ItemQuality)2;
		Hook val2 = new Hook((MethodBase)typeof(LootEngine).GetMethod("PostprocessItemSpawn", BindingFlags.Static | BindingFlags.NonPublic), typeof(BloodThinner).GetMethod("doEffect", BindingFlags.Static | BindingFlags.Public));
		BloodThinnerID = ((PickupObject)val).PickupObjectId;
	}

	public static void doEffect(Action<DebrisObject> orig, DebrisObject spawnedItem)
	{
		try
		{
			orig(spawnedItem);
			PickupObject component = ((Component)spawnedItem).gameObject.GetComponent<PickupObject>();
			if ((Object)(object)component != (Object)null && (component.PickupObjectId == 73 || component.PickupObjectId == 85))
			{
				AttemptReroll(component);
			}
		}
		catch (Exception ex)
		{
			ETGModConsole.Log((object)ex.Message, false);
			ETGModConsole.Log((object)ex.StackTrace, false);
		}
	}

	public static void AttemptReroll(PickupObject thing)
	{
		//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0125: Unknown result type (might be due to invalid IL or missing references)
		//IL_0127: Unknown result type (might be due to invalid IL or missing references)
		//IL_012c: Unknown result type (might be due to invalid IL or missing references)
		bool flag = false;
		PlayerController val = null;
		if (GameManager.Instance.PrimaryPlayer.HasPickupID(BloodThinnerID))
		{
			val = GameManager.Instance.PrimaryPlayer;
		}
		else if ((Object)(object)GameManager.Instance.SecondaryPlayer != (Object)null && GameManager.Instance.SecondaryPlayer.HasPickupID(BloodThinnerID))
		{
			val = GameManager.Instance.SecondaryPlayer;
		}
		if (!((Object)(object)val != (Object)null))
		{
			return;
		}
		if (((BraveBehaviour)val).healthHaver.GetCurrentHealthPercentage() == 1f || val.ForceZeroHealthState)
		{
			flag = true;
		}
		if (flag)
		{
			Vector2 val2 = Vector2.op_Implicit(((BraveBehaviour)thing).transform.position);
			bool flag2 = false;
			if (thing.PickupObjectId == 85 && CustomSynergies.PlayerHasActiveSynergy(val, "Thicker Than Water"))
			{
				flag2 = true;
			}
			LootEngine.SpawnItem(((Component)PickupObjectDatabase.GetById(BraveUtility.RandomElement<int>(NonHeartLoot))).gameObject, Vector2.op_Implicit(val2), Vector2.zero, 1f, false, true, false);
			if (flag2)
			{
				LootEngine.SpawnItem(((Component)PickupObjectDatabase.GetById(BraveUtility.RandomElement<int>(NonHeartLoot))).gameObject, Vector2.op_Implicit(val2), Vector2.zero, 1f, false, true, false);
			}
			Object.Destroy((Object)(object)((Component)thing).gameObject);
		}
	}

	public override void Pickup(PlayerController player)
	{
		((PassiveItem)this).Pickup(player);
	}

	public override DebrisObject Drop(PlayerController player)
	{
		return ((PassiveItem)this).Drop(player);
	}
}
