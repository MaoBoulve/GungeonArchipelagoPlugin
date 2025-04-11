using UnityEngine;

namespace NevernamedsItems;

internal class BloodshotEye : PassiveItem
{
	public static int BloodshotEyeID;

	public static void Init()
	{
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		PickupObject obj = ItemSetup.NewItem<BloodshotEye>("Bloodshot Eye", "Ow, Oof, Ouchie", "Slightly increases damage for every hit taken.\nEffect is permanent.\n\nLooks like you could use some eyedrops.", "bloodshoteye_icon", assetbundle: true);
		PassiveItem val = (PassiveItem)(object)((obj is PassiveItem) ? obj : null);
		((PickupObject)val).quality = (ItemQuality)4;
		BloodshotEyeID = ((PickupObject)val).PickupObjectId;
	}

	private void OnDMG(PlayerController user)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Expected O, but got Unknown
		StatModifier item = new StatModifier
		{
			statToBoost = (StatType)5,
			amount = 1.02f,
			modifyType = (ModifyMethod)1
		};
		user.ownerlessStatModifiers.Add(item);
		user.stats.RecalculateStats(user, false, false);
	}

	public override void Pickup(PlayerController player)
	{
		((PassiveItem)this).Pickup(player);
		player.OnReceivedDamage += OnDMG;
	}

	public override DebrisObject Drop(PlayerController player)
	{
		DebrisObject result = ((PassiveItem)this).Drop(player);
		player.OnReceivedDamage -= OnDMG;
		return result;
	}

	public override void OnDestroy()
	{
		if (Object.op_Implicit((Object)(object)((PassiveItem)this).Owner))
		{
			((PassiveItem)this).Owner.OnReceivedDamage -= OnDMG;
		}
		((PassiveItem)this).OnDestroy();
	}
}
