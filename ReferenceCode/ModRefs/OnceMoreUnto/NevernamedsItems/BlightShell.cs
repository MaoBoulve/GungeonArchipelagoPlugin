using System.Collections.Generic;
using Alexandria.ItemAPI;
using Alexandria.Misc;
using SaveAPI;
using UnityEngine;

namespace NevernamedsItems;

public class BlightShell : PassiveItem
{
	public static int BlightShellID;

	public static List<int> shotgunIDs = new List<int>
	{
		347, 404, 55, 61, 93, 126, 1, 202, 151, 346,
		51, 175, 143, 379, 122, 601, 541, 550, 512, 363,
		18, 82, 231, 225, 365, 123, 406, 329
	};

	public static void Init()
	{
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		PickupObject obj = ItemSetup.NewItem<BlightShell>("Blight Shell", "Apocryphal Armoury", "Grants a free shotgun every floor, as well as a free curse.\n\nShotgun Gundead are often neglected in death, despite their noble status. This artefact collects their souls, because nobody else will.", "blightshell_icon", assetbundle: true);
		PassiveItem val = (PassiveItem)(object)((obj is PassiveItem) ? obj : null);
		((PickupObject)val).quality = (ItemQuality)3;
		ItemBuilder.AddToSubShop((PickupObject)(object)val, (ShopType)2, 1f);
		((PickupObject)(object)val).SetupUnlockOnCustomFlag(CustomDungeonFlags.JAMMEDSHOTGUNKIN_QUEST_REWARDED, requiredFlagValue: true);
		BlightShellID = ((PickupObject)val).PickupObjectId;
	}

	private void OnNewFloor()
	{
		if (Object.op_Implicit((Object)(object)((PassiveItem)this).Owner))
		{
			giveNewShotgun();
		}
	}

	private void giveNewShotgun()
	{
		List<int> list = new List<int>();
		list.AddRange(shotgunIDs);
		list = MathsAndLogicHelper.RemoveInvalidIDListEntries(list, true, true);
		int num = BraveUtility.RandomElement<int>(list);
		PickupObject byId = PickupObjectDatabase.GetById(num);
		Gun val = (Gun)(object)((byId is Gun) ? byId : null);
		Gun val2 = Object.Instantiate<Gun>(val);
		ItemBuilder.AddPassiveStatModifier((PickupObject)(object)val2, (StatType)14, 1f, (ModifyMethod)0);
		((PassiveItem)this).Owner.inventory.AddGunToInventory(val2, true);
	}

	public override void Pickup(PlayerController player)
	{
		((PassiveItem)this).Pickup(player);
		if (!base.m_pickedUpThisRun)
		{
			List<int> collection = new List<int>
			{
				JusticeGun.JusticeID,
				Orgun.OrgunID,
				Octagun.OctagunID,
				ClownShotgun.ClownShotgunID,
				Ranger.RangerID
			};
			shotgunIDs.AddRange(collection);
			giveNewShotgun();
		}
		GameManager.Instance.OnNewLevelFullyLoaded += OnNewFloor;
	}

	public override DebrisObject Drop(PlayerController player)
	{
		DebrisObject result = ((PassiveItem)this).Drop(player);
		GameManager.Instance.OnNewLevelFullyLoaded -= OnNewFloor;
		return result;
	}

	public override void OnDestroy()
	{
		GameManager.Instance.OnNewLevelFullyLoaded -= OnNewFloor;
		((PassiveItem)this).OnDestroy();
	}
}
