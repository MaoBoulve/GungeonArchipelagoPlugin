using Alexandria.ItemAPI;
using SaveAPI;
using UnityEngine;

namespace NevernamedsItems;

public class JawsOfDefeat : PassiveItem
{
	public static int JawsOfDefeatID;

	public static void Init()
	{
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		PickupObject val = ItemSetup.NewItem<JawsOfDefeat>("Jaws Of Defeat", "Press To See Graveyard", "Increases Damage and Firerate by 0.5% for every death on the current save file, up to 1000 deaths.\n\nA charm worn by the very first adventurer... ever.", "jawsofdefeat_icon", assetbundle: true);
		ItemBuilder.AddPassiveStatModifier(val, (StatType)14, 3f, (ModifyMethod)0);
		val.quality = (ItemQuality)5;
		JawsOfDefeatID = val.PickupObjectId;
		val.SetupUnlockOnCustomFlag(CustomDungeonFlags.BOSSRUSH_SHADE, requiredFlagValue: true);
	}

	public override void Pickup(PlayerController player)
	{
		if (!base.m_pickedUpThisRun)
		{
			float playerStatValue = GameStatsManager.Instance.GetPlayerStatValue((TrackedStats)3);
			if (playerStatValue > 0f)
			{
				float num = 0.005f * playerStatValue + 1f;
				float num2 = Mathf.Min(num, 6f);
				ItemBuilder.AddPassiveStatModifier((PickupObject)(object)this, (StatType)5, num2, (ModifyMethod)1);
				ItemBuilder.AddPassiveStatModifier((PickupObject)(object)this, (StatType)1, num2, (ModifyMethod)1);
			}
		}
		((PassiveItem)this).Pickup(player);
	}
}
