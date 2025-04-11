using System.Collections.Generic;
using Dungeonator;
using Gungeon;
using SaveAPI;
using UnityEngine;

namespace NevernamedsItems;

public class ShadesEye : PassiveItem
{
	public static List<int> lootIDlist = new List<int> { 73, 85, 120, 67 };

	public static int ShadesEyeID;

	public static void Init()
	{
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		PickupObject obj = ItemSetup.NewItem<ShadesEye>("Shade's Eye", "Everything For A Price", "Doubles boss loot, but taking damage in a bossfight causes instant death.\nDestroyed upon being discarded.\n\nThe wandering eye of a vengeful shade.", "shadeseye_icon", assetbundle: true);
		PassiveItem val = (PassiveItem)(object)((obj is PassiveItem) ? obj : null);
		((PickupObject)val).quality = (ItemQuality)2;
		Game.Items.Rename("nn:shade's_eye", "nn:shades_eye");
		ShadesEyeID = ((PickupObject)val).PickupObjectId;
		((PickupObject)(object)val).SetupUnlockOnCustomFlag(CustomDungeonFlags.CHEATED_DEATH_SHADE, requiredFlagValue: true);
	}

	public override void Pickup(PlayerController player)
	{
		player.OnRoomClearEvent += OnRoomClear;
		player.OnReceivedDamage += OnDamaged;
		((PassiveItem)this).Pickup(player);
	}

	public override DebrisObject Drop(PlayerController player)
	{
		player.OnReceivedDamage -= OnDamaged;
		player.OnRoomClearEvent -= OnRoomClear;
		DebrisObject val = ((PassiveItem)this).Drop(player);
		Object.Destroy((Object)(object)((Component)val).gameObject, 1f);
		return val;
	}

	public override void OnDestroy()
	{
		if (Object.op_Implicit((Object)(object)((PassiveItem)this).Owner))
		{
			((PassiveItem)this).Owner.OnRoomClearEvent -= OnRoomClear;
			((PassiveItem)this).Owner.OnReceivedDamage -= OnDamaged;
		}
		((PassiveItem)this).OnDestroy();
	}

	private void OnDamaged(PlayerController player)
	{
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Invalid comparison between Unknown and I4
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		if (Object.op_Implicit((Object)(object)player) && player.CurrentRoom != null && (int)player.CurrentRoom.area.PrototypeRoomCategory == 3)
		{
			((BraveBehaviour)((PassiveItem)this).Owner).healthHaver.Armor = 0f;
			((BraveBehaviour)((PassiveItem)this).Owner).healthHaver.ForceSetCurrentHealth(0f);
			((BraveBehaviour)((PassiveItem)this).Owner).healthHaver.Die(Vector2.zero);
		}
	}

	private void GiveConsumables()
	{
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		int num = Random.Range(2, 4);
		for (int i = 0; i < num; i++)
		{
			IntVector2 bestRewardLocation = ((PassiveItem)this).Owner.CurrentRoom.GetBestRewardLocation(IntVector2.One * 3, (RewardLocationStyle)1, true);
			Vector3 val = ((IntVector2)(ref bestRewardLocation)).ToVector3();
			LootEngine.SpawnItem(((Component)PickupObjectDatabase.GetById(BraveUtility.RandomElement<int>(lootIDlist))).gameObject, val, Vector2.zero, 1f, false, true, false);
		}
	}

	private void OnRoomClear(PlayerController player)
	{
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Invalid comparison between Unknown and I4
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Invalid comparison between Unknown and I4
		if (Object.op_Implicit((Object)(object)player) && player.CurrentRoom != null && (int)player.CurrentRoom.area.PrototypeRoomCategory == 3)
		{
			if (!player.CurrentRoom.PlayerHasTakenDamageInThisRoom && (int)player.CurrentRoom.area.PrototypeRoomBossSubcategory != 1)
			{
				GiveMastery();
			}
			GiveItem();
			GiveConsumables();
		}
	}

	private void GiveItem()
	{
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		float value = Random.value;
		PickupObject val = null;
		val = (PickupObject)((!((double)value > 0.5)) ? ((object)LootEngine.GetItemOfTypeAndQuality<Gun>((ItemQuality)4, GameManager.Instance.RewardManager.GunsLootTable, true)) : ((object)LootEngine.GetItemOfTypeAndQuality<PickupObject>((ItemQuality)4, GameManager.Instance.RewardManager.ItemsLootTable, true)));
		LootEngine.SpawnItem(((Component)val).gameObject, Vector2.op_Implicit(((BraveBehaviour)((PassiveItem)this).Owner).sprite.WorldCenter), Vector2.zero, 0f, true, false, false);
	}

	private void GiveMastery()
	{
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		if (GameManager.Instance.Dungeon.BossMasteryTokenItemId > 0)
		{
			LootEngine.SpawnItem(((Component)PickupObjectDatabase.GetById(GameManager.Instance.Dungeon.BossMasteryTokenItemId)).gameObject, Vector2.op_Implicit(((BraveBehaviour)((PassiveItem)this).Owner).sprite.WorldCenter), Vector2.zero, 0f, true, false, false);
		}
	}
}
