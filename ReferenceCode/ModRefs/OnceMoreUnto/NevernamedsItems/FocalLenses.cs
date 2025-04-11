using Alexandria.ItemAPI;
using UnityEngine;

namespace NevernamedsItems;

public class FocalLenses : PassiveItem
{
	public static void Init()
	{
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		PickupObject obj = ItemSetup.NewItem<FocalLenses>("Focal Lenses", "Better Beams", "Doubles beam damage.\n\nA set of lenses capable of increasing the firepower of laserbeams... and the waterpower of the Mega Douser, somehow.", "focallenses_icon", assetbundle: true);
		PassiveItem val = (PassiveItem)(object)((obj is PassiveItem) ? obj : null);
		((PickupObject)val).quality = (ItemQuality)1;
		ItemBuilder.AddPassiveStatModifier((PickupObject)(object)val, (StatType)2, 0.9f, (ModifyMethod)1);
	}

	private void PostProcessBeam(BeamController beam)
	{
		if (Object.op_Implicit((Object)(object)beam) && Object.op_Implicit((Object)(object)((BraveBehaviour)beam).projectile))
		{
			ProjectileData baseData = ((BraveBehaviour)beam).projectile.baseData;
			baseData.damage *= 2f;
		}
	}

	public override DebrisObject Drop(PlayerController player)
	{
		player.PostProcessBeam -= PostProcessBeam;
		return ((PassiveItem)this).Drop(player);
	}

	public override void Pickup(PlayerController player)
	{
		player.PostProcessBeam += PostProcessBeam;
		((PassiveItem)this).Pickup(player);
	}

	public override void OnDestroy()
	{
		if (Object.op_Implicit((Object)(object)((PassiveItem)this).Owner))
		{
			((PassiveItem)this).Owner.PostProcessBeam -= PostProcessBeam;
		}
		((PassiveItem)this).OnDestroy();
	}
}
