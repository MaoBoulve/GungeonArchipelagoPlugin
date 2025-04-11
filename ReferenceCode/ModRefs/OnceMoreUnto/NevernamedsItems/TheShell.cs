using Alexandria.ItemAPI;
using UnityEngine;

namespace NevernamedsItems;

public class TheShell : PassiveItem
{
	public static void Init()
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		PickupObject val = ItemSetup.NewItem<TheShell>("The Shell", "The First", "This is the first shotgun shell ever to be created, by the great Gunsmith Geddian\n\nHas an affinity with all shotguns.", "theshell_improved", assetbundle: true);
		val.quality = (ItemQuality)3;
		AlexandriaTags.SetTag(val, "bullet_modifier");
		Doug.AddToLootPool(val.PickupObjectId);
	}

	public override void Pickup(PlayerController player)
	{
		player.GunChanged += GunChanged;
		((PassiveItem)this).Pickup(player);
		Recalc();
	}

	public override DebrisObject Drop(PlayerController player)
	{
		player.GunChanged -= GunChanged;
		return ((PassiveItem)this).Drop(player);
	}

	public override void OnDestroy()
	{
		if (Object.op_Implicit((Object)(object)((PassiveItem)this).Owner))
		{
			((PassiveItem)this).Owner.GunChanged -= GunChanged;
		}
		((PassiveItem)this).OnDestroy();
	}

	private void Recalc()
	{
		ItemBuilder.RemovePassiveStatModifier((PickupObject)(object)this, (StatType)5);
		float num = 1f;
		float num2 = 0.05f;
		if (CustomSynergies.PlayerHasActiveSynergy(((PassiveItem)this).Owner, "ShellllehS llehSShell"))
		{
			num2 = 0.07f;
		}
		if (CustomSynergies.PlayerHasActiveSynergy(((PassiveItem)this).Owner, "Shoot Your Shot"))
		{
			num2 *= 3f;
		}
		if (Object.op_Implicit((Object)(object)((PassiveItem)this).Owner) && Object.op_Implicit((Object)(object)((GameActor)((PassiveItem)this).Owner).CurrentGun))
		{
			if (Object.op_Implicit((Object)(object)((GameActor)((PassiveItem)this).Owner).CurrentGun.Volley) && ((GameActor)((PassiveItem)this).Owner).CurrentGun.Volley.projectiles != null)
			{
				num += (float)((GameActor)((PassiveItem)this).Owner).CurrentGun.Volley.projectiles.Count * num2;
			}
			else if (((GameActor)((PassiveItem)this).Owner).CurrentGun.DefaultModule != null)
			{
				num += num2;
			}
			num = Mathf.Min(num, 3f);
		}
		ItemBuilder.AddPassiveStatModifier((PickupObject)(object)this, (StatType)5, num, (ModifyMethod)1);
		((PassiveItem)this).Owner.stats.RecalculateStats(((PassiveItem)this).Owner, false, false);
	}

	private void GunChanged(Gun gun, Gun gun2, bool idk)
	{
		Recalc();
	}
}
