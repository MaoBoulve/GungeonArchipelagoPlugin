using System;
using Alexandria.ItemAPI;
using Dungeonator;
using Pathfinding;
using UnityEngine;

namespace NevernamedsItems;

public class TableTechTable : TableFlipItem
{
	public FlippableCover TableToSpawn;

	public static void Init()
	{
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		PickupObject obj = ItemSetup.NewItem<TableTechTable>("Table Tech Table", "Flip Recursion", "This ancient technique has a chance to create a new table whenever a table is flipped.\n\nChapter 8 of the \"Tabla Sutra.\" Flip unto flip unto flip unto flip unto flip unto flip unto flip unto flip unto flip. Never stop flipping.", "tabletechtable_icon", assetbundle: true);
		TableFlipItem val = (TableFlipItem)(object)((obj is TableFlipItem) ? obj : null);
		((PickupObject)val).quality = (ItemQuality)2;
		AlexandriaTags.SetTag((PickupObject)(object)val, "table_tech");
	}

	public override void Pickup(PlayerController player)
	{
		((TableFlipItem)this).Pickup(player);
		player.OnTableFlipped = (Action<FlippableCover>)Delegate.Combine(player.OnTableFlipped, new Action<FlippableCover>(SpeedEffect));
	}

	public override DebrisObject Drop(PlayerController player)
	{
		DebrisObject result = ((TableFlipItem)this).Drop(player);
		player.OnTableFlipped = (Action<FlippableCover>)Delegate.Remove(player.OnTableFlipped, new Action<FlippableCover>(SpeedEffect));
		return result;
	}

	public override void OnDestroy()
	{
		if (Object.op_Implicit((Object)(object)((PassiveItem)this).Owner))
		{
			PlayerController owner = ((PassiveItem)this).Owner;
			owner.OnTableFlipped = (Action<FlippableCover>)Delegate.Remove(owner.OnTableFlipped, new Action<FlippableCover>(SpeedEffect));
		}
		((TableFlipItem)this).OnDestroy();
	}

	private void SpeedEffect(FlippableCover obj)
	{
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f6: Unknown result type (might be due to invalid IL or missing references)
		if (Random.value < 0.5f)
		{
			Vector2 centerPosition = ((GameActor)((PassiveItem)this).Owner).CenterPosition;
			Vector2 val = Vector3Extensions.XY(((PassiveItem)this).Owner.unadjustedAimPoint) - ((GameActor)((PassiveItem)this).Owner).CenterPosition;
			Vector2 val2 = centerPosition + ((Vector2)(ref val)).normalized;
			IntVector2? nearestAvailableCell = ((PassiveItem)this).Owner.CurrentRoom.GetNearestAvailableCell(val2, (IntVector2?)IntVector2.One, (CellTypes?)(CellTypes)2, false, (CellValidator)null);
			FoldingTableItem component = ((Component)PickupObjectDatabase.GetById(644)).GetComponent<FoldingTableItem>();
			GameObject gameObject = ((Component)component.TableToSpawn).gameObject;
			GameObject gameObject2 = gameObject.gameObject;
			IntVector2 value = nearestAvailableCell.Value;
			GameObject val3 = Object.Instantiate<GameObject>(gameObject2, Vector2.op_Implicit(((IntVector2)(ref value)).ToVector2()), Quaternion.identity);
			SpeculativeRigidbody componentInChildren = val3.GetComponentInChildren<SpeculativeRigidbody>();
			FlippableCover component2 = val3.GetComponent<FlippableCover>();
			Vector3Extensions.GetAbsoluteRoom(Vector3Extensions.XY(((BraveBehaviour)component2).transform.position)).RegisterInteractable((IPlayerInteractable)(object)component2);
			component2.ConfigureOnPlacement(Vector3Extensions.GetAbsoluteRoom(Vector3Extensions.XY(((BraveBehaviour)component2).transform.position)));
			componentInChildren.Initialize();
			PhysicsEngine.Instance.RegisterOverlappingGhostCollisionExceptions(componentInChildren, (int?)null, false);
		}
	}
}
