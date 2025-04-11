using System;
using Alexandria.ItemAPI;
using UnityEngine;

namespace NevernamedsItems;

public class TableTechSpeed : TableFlipItem
{
	public static void Init()
	{
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		PickupObject obj = ItemSetup.NewItem<TableTechSpeed>("Table Tech Speed", "Flip Acceleration", "Flipping a table increases the bearer's movement speed temporarily.\n\nAppendix F of the \"Tabla Sutra\". Flipping is to create motion. In motion there is life, and joy. To flip, is to live.", "tabletechspeed_icon", assetbundle: true);
		TableFlipItem val = (TableFlipItem)(object)((obj is TableFlipItem) ? obj : null);
		((PickupObject)val).quality = (ItemQuality)1;
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
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		PlayerController owner = ((PassiveItem)this).Owner;
		((GameActor)owner).PlayEffectOnActor(SharedVFX.SpeedUpVFX, new Vector3(0f, 0.25f, 0f), true, true, false);
		PlayerToolbox component = ((Component)owner).GetComponent<PlayerToolbox>();
		if (Object.op_Implicit((Object)(object)component))
		{
			float time = 7f;
			if (CustomSynergies.PlayerHasActiveSynergy(owner, "Sound Barrier"))
			{
				time = 14f;
			}
			component.DoTimedStatModifier((StatType)0, 2f, time, (ModifyMethod)0);
		}
	}
}
