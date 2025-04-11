using Alexandria.ItemAPI;
using UnityEngine;

namespace NevernamedsItems;

public class TitaniumClip : PassiveItem
{
	public static int TitaniumClipID;

	private bool buffActive;

	public static void Init()
	{
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		PickupObject obj = ItemSetup.NewItem<TitaniumClip>("Titanium Clip", "Damage Output", "Doubles damage of non-infinite ammo guns, but also doubles their ammo consumption.\n\nCreated to aid the greedy and shortsighted.\n\nTechnically, this is a magazine and not a clip, but I really don't care.", "titaniumclip_icon", assetbundle: true);
		PassiveItem val = (PassiveItem)(object)((obj is PassiveItem) ? obj : null);
		((PickupObject)val).CanBeDropped = true;
		((PickupObject)val).quality = (ItemQuality)3;
		TitaniumClipID = ((PickupObject)val).PickupObjectId;
	}

	public void ModifyVolley(ProjectileVolleyData volleyToModify)
	{
		int count = volleyToModify.projectiles.Count;
		for (int i = 0; i < count; i++)
		{
			ProjectileModule val = volleyToModify.projectiles[i];
			val.ammoCost *= 2;
		}
	}

	private void RemoveBuff()
	{
		((PassiveItem)this).Owner.stats.AdditionalVolleyModifiers -= ModifyVolley;
		ItemBuilder.RemovePassiveStatModifier((PickupObject)(object)this, (StatType)5);
		((PassiveItem)this).Owner.stats.RecalculateStats(((PassiveItem)this).Owner, false, false);
		buffActive = false;
	}

	private void AddBuff()
	{
		((PassiveItem)this).Owner.stats.AdditionalVolleyModifiers += ModifyVolley;
		ItemBuilder.AddPassiveStatModifier((PickupObject)(object)this, (StatType)5, 2f, (ModifyMethod)1);
		((PassiveItem)this).Owner.stats.RecalculateStats(((PassiveItem)this).Owner, false, false);
		buffActive = true;
	}

	public override void Update()
	{
		if (Object.op_Implicit((Object)(object)((PassiveItem)this).Owner))
		{
			if (Object.op_Implicit((Object)(object)((GameActor)((PassiveItem)this).Owner).CurrentGun) && !((GameActor)((PassiveItem)this).Owner).CurrentGun.InfiniteAmmo)
			{
				if (!buffActive)
				{
					AddBuff();
				}
			}
			else if (buffActive)
			{
				RemoveBuff();
			}
		}
		((PassiveItem)this).Update();
	}

	public override void Pickup(PlayerController player)
	{
		((PassiveItem)this).Pickup(player);
	}

	public override DebrisObject Drop(PlayerController player)
	{
		RemoveBuff();
		return ((PassiveItem)this).Drop(player);
	}

	public override void OnDestroy()
	{
		if (Object.op_Implicit((Object)(object)((PassiveItem)this).Owner))
		{
			RemoveBuff();
		}
		((PassiveItem)this).OnDestroy();
	}
}
