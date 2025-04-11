using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

internal class BlankKey : PassiveItem
{
	private float currentKeys;

	private float lastKeys;

	public static void Init()
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		PickupObject val = ItemSetup.NewItem<BlankKey>("Blank Key", "Implosive Openings", "Spending a key triggers a blank effect.\n\nFlynt and Old Red don't often see eye to eye, but there are some... exceptions.", "blankkey_icon", assetbundle: true);
		val.quality = (ItemQuality)2;
	}

	public override void Update()
	{
		if (Object.op_Implicit((Object)(object)((PassiveItem)this).Owner))
		{
			CalculateKeys(((PassiveItem)this).Owner);
		}
	}

	private void CalculateKeys(PlayerController player)
	{
		currentKeys = player.carriedConsumables.KeyBullets;
		if (currentKeys < lastKeys)
		{
			if (((PassiveItem)this).Owner.HasPickupID(Game.Items["nn:spare_blank"].PickupObjectId))
			{
				LootEngine.GivePrefabToPlayer(((Component)PickupObjectDatabase.GetById(224)).gameObject, player);
			}
			else
			{
				player.ForceBlank(25f, 0.5f, false, true, (Vector2?)null, true, -1f);
			}
		}
		lastKeys = currentKeys;
	}

	public override void Pickup(PlayerController player)
	{
		if (!base.m_pickedUpThisRun)
		{
			LootEngine.GivePrefabToPlayer(((Component)PickupObjectDatabase.GetById(67)).gameObject, player);
			LootEngine.GivePrefabToPlayer(((Component)PickupObjectDatabase.GetById(224)).gameObject, player);
		}
		((PassiveItem)this).Pickup(player);
	}

	public override DebrisObject Drop(PlayerController player)
	{
		return ((PassiveItem)this).Drop(player);
	}

	public override void OnDestroy()
	{
		((PassiveItem)this).OnDestroy();
	}
}
