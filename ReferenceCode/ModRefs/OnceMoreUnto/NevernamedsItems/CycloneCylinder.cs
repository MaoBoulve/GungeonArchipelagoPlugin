using System.Collections.Generic;
using Alexandria.ItemAPI;
using UnityEngine;

namespace NevernamedsItems;

public class CycloneCylinder : PassiveItem
{
	public static void Init()
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		PickupObject val = ItemSetup.NewItem<CycloneCylinder>("Cyclone Boots", "Gusty Dodges", "Dodge rolling releases a magical gust of wind that pushes all enemies around you back.\n\nThe magical wind is stored in the boots themselves, and it feels oddly tickly on your toes.", "cycloneboots_icon", assetbundle: true);
		val.quality = (ItemQuality)1;
		List<string> list = new List<string> { "nn:cyclone_boots", "balloon_gun" };
		CustomSynergies.Add("Let Loose", list, (List<string>)null, true);
		List<string> list2 = new List<string> { "nn:cyclone_boots", "armor_of_thorns" };
		CustomSynergies.Add("Scytheclone", list2, (List<string>)null, true);
	}

	private void onDodgeRoll(PlayerController player, Vector2 dirVec)
	{
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		int num = 10;
		if (CustomSynergies.PlayerHasActiveSynergy(((PassiveItem)this).Owner, "Let Loose"))
		{
			num = 20;
		}
		Exploder.DoRadialKnockback(Vector2.op_Implicit(((BraveBehaviour)player).specRigidbody.UnitCenter), 100f, (float)num);
		if (CustomSynergies.PlayerHasActiveSynergy(((PassiveItem)this).Owner, "Scytheclone"))
		{
			float statValue = player.stats.GetStatValue((StatType)21);
			Exploder.DoRadialDamage(statValue * 3f, Vector2.op_Implicit(((BraveBehaviour)player).specRigidbody.UnitCenter), (float)num, false, true, false, (VFXPool)null);
		}
	}

	public override void Pickup(PlayerController player)
	{
		player.OnRollStarted += onDodgeRoll;
		((PassiveItem)this).Pickup(player);
	}

	public override DebrisObject Drop(PlayerController player)
	{
		DebrisObject result = ((PassiveItem)this).Drop(player);
		player.OnRollStarted -= onDodgeRoll;
		return result;
	}

	public override void OnDestroy()
	{
		if (Object.op_Implicit((Object)(object)((PassiveItem)this).Owner))
		{
			((PassiveItem)this).Owner.OnRollStarted -= onDodgeRoll;
		}
		((PassiveItem)this).OnDestroy();
	}
}
