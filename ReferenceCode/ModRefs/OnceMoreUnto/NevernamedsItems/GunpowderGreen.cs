using Alexandria.ItemAPI;
using UnityEngine;

namespace NevernamedsItems;

internal class GunpowderGreen : PassiveItem
{
	public static int ID;

	public float clipPercentLastFrame;

	public static void Init()
	{
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		PickupObject obj = ItemSetup.NewItem<GunpowderGreen>("Gunpowder Green", "Soothed Trigger Finger", "Reload faster the more full the clip already is.\n\nIntroduces a certain zen into the process of reloading, allowing you to refill your guns more effectively.", "gunpowdergreen_icon", assetbundle: true);
		PassiveItem val = (PassiveItem)(object)((obj is PassiveItem) ? obj : null);
		((PickupObject)val).quality = (ItemQuality)1;
		ID = ((PickupObject)val).PickupObjectId;
	}

	public override void Update()
	{
		if (Object.op_Implicit((Object)(object)((PassiveItem)this).Owner) && Object.op_Implicit((Object)(object)((GameActor)((PassiveItem)this).Owner).CurrentGun))
		{
			float num = (float)((GameActor)((PassiveItem)this).Owner).CurrentGun.ClipShotsRemaining / (float)((GameActor)((PassiveItem)this).Owner).CurrentGun.ClipCapacity;
			if (num != clipPercentLastFrame)
			{
				Recalculate(num);
				clipPercentLastFrame = num;
			}
		}
		((PassiveItem)this).Update();
	}

	private void Recalculate(float clipPercent)
	{
		ItemBuilder.RemovePassiveStatModifier((PickupObject)(object)this, (StatType)10);
		if (clipPercent < 1f)
		{
			float num = 1f - clipPercent;
			ItemBuilder.AddPassiveStatModifier((PickupObject)(object)this, (StatType)10, Mathf.Max(num, 0.05f), (ModifyMethod)1);
			if (Object.op_Implicit((Object)(object)((PassiveItem)this).Owner))
			{
				((PassiveItem)this).Owner.stats.RecalculateStats(((PassiveItem)this).Owner, false, false);
			}
		}
	}
}
