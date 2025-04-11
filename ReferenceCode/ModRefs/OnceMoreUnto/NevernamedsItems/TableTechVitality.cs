using System;
using Alexandria.ItemAPI;
using UnityEngine;

namespace NevernamedsItems;

public class TableTechVitality : TableFlipItem
{
	public static int ID;

	public static void Init()
	{
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		TableTechVitality tableTechVitality = ItemSetup.NewItem<TableTechVitality>("Table Tech Vitality", "Flip Health", "Chance to conjure rejuvenation when a table is flipped\n\nPart one of the infamous \"Tablos Apocrypha\" of the \"Tabla Sutra\", legends say that this page is written in blood...", "tabletechvitality_icon", assetbundle: true) as TableTechVitality;
		((PickupObject)tableTechVitality).quality = (ItemQuality)3;
		((TableFlipItem)tableTechVitality).TableFlocking = true;
		ID = ((PickupObject)tableTechVitality).PickupObjectId;
		AlexandriaTags.SetTag((PickupObject)(object)tableTechVitality, "table_tech");
	}

	public override void Pickup(PlayerController player)
	{
		player.OnTableFlipped = (Action<FlippableCover>)Delegate.Combine(player.OnTableFlipped, new Action<FlippableCover>(MaybeDropHeart));
		((TableFlipItem)this).Pickup(player);
	}

	public override void DisableEffect(PlayerController player)
	{
		if (Object.op_Implicit((Object)(object)player))
		{
			player.OnTableFlipped = (Action<FlippableCover>)Delegate.Remove(player.OnTableFlipped, new Action<FlippableCover>(MaybeDropHeart));
		}
		((PassiveItem)this).DisableEffect(player);
	}

	private void MaybeDropHeart(FlippableCover obj)
	{
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		if (Random.value <= 0.1f)
		{
			if (Random.value <= 0.3f)
			{
				LootEngine.SpawnItem(((Component)PickupObjectDatabase.GetById(73)).gameObject, ((BraveBehaviour)obj).transform.position, Vector2.zero, 1f, false, true, false);
			}
			else
			{
				LootEngine.SpawnItem(((Component)PickupObjectDatabase.GetById(85)).gameObject, ((BraveBehaviour)obj).transform.position, Vector2.zero, 1f, false, true, false);
			}
		}
	}
}
