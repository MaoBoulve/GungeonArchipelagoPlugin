using System;
using System.Collections.Generic;
using Alexandria.ItemAPI;
using Dungeonator;
using UnityEngine;

namespace NevernamedsItems;

internal class Toolbox : PlayerItem
{
	public static List<GameObject> PossibleObjects = new List<GameObject>
	{
		EasyPlaceableObjects.TableVertical,
		EasyPlaceableObjects.TableHorizontal,
		EasyPlaceableObjects.TableHorizontalStone,
		EasyPlaceableObjects.TableVerticalStone,
		EasyPlaceableObjects.FoldingTable,
		EasyPlaceableObjects.CoffinHoriz,
		EasyPlaceableObjects.CoffinVert,
		EasyPlaceableObjects.ExplosiveBarrel,
		EasyPlaceableObjects.MetalExplosiveBarrel,
		EasyPlaceableObjects.OilBarrel,
		EasyPlaceableObjects.PoisonBarrel,
		EasyPlaceableObjects.WaterBarrel,
		EasyPlaceableObjects.IceBomb
	};

	public static void Init()
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		PickupObject obj = ItemSetup.NewItem<Toolbox>("Toolbox", "Robust", "Makes a random object.\n\nA blunt object popular for it's usefulness in bludgeoning other people (or yourself) in the head.\n\nAlso holds tools, or whatever.", "toolbox_improved", assetbundle: true);
		PlayerItem val = (PlayerItem)(object)((obj is PlayerItem) ? obj : null);
		ItemBuilder.SetCooldownType(val, (CooldownType)1, 60f);
		val.consumable = false;
		((PickupObject)val).quality = (ItemQuality)1;
	}

	public override void DoEffect(PlayerController user)
	{
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Invalid comparison between Unknown and I4
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		//IL_0133: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00de: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			IntVector2 bestRewardLocation = user.CurrentRoom.GetBestRewardLocation(IntVector2.One * 2, (RewardLocationStyle)1, true);
			Vector3 convertedVector = ((IntVector2)(ref bestRewardLocation)).ToVector3();
			FireplaceController val = null;
			if ((int)GameManager.Instance.Dungeon.tileIndices.tilesetId == 2)
			{
				val = Object.FindObjectOfType<FireplaceController>();
			}
			GameObject thingToSpawn = BraveUtility.RandomElement<GameObject>(PossibleObjects);
			if ((Object)(object)val != (Object)null && Vector3Extensions.GetAbsoluteRoom(((BraveBehaviour)val).transform.position) == user.CurrentRoom)
			{
				thingToSpawn = EasyPlaceableObjects.WaterBarrel;
			}
			if (Random.value <= 0.01f)
			{
				IntVector2 bestRewardLocation2 = user.CurrentRoom.GetBestRewardLocation(IntVector2.One * 2, (RewardLocationStyle)1, true);
				Chest d_Chest = GameManager.Instance.RewardManager.D_Chest;
				d_Chest.IsLocked = false;
				d_Chest.ChestType = (GeneralChestType)0;
				Chest val2 = Chest.Spawn(d_Chest, bestRewardLocation2);
				val2.lootTable.lootTable = ((Random.value <= 0.5f) ? GameManager.Instance.RewardManager.GunsLootTable : GameManager.Instance.RewardManager.ItemsLootTable);
				val2.RegisterChestOnMinimap(((DungeonPlaceableBehaviour)val2).GetAbsoluteParentRoom());
			}
			else
			{
				SpawnObjectManager.SpawnObject(thingToSpawn, convertedVector, SharedVFX.BloodiedScarfPoofVFX);
			}
			if (CustomSynergies.PlayerHasActiveSynergy(user, "His Grace"))
			{
				KillRandomEnemy(user.CurrentRoom);
			}
			if (CustomSynergies.PlayerHasActiveSynergy(user, "Sharpest Tool In The Shed"))
			{
				DoRandomRoomSpawns(user.CurrentRoom);
			}
		}
		catch (Exception ex)
		{
			ETGModConsole.Log((object)ex.Message, false);
			ETGModConsole.Log((object)ex.StackTrace, false);
		}
	}

	private void DoRandomRoomSpawns(RoomHandler room)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		for (int i = 0; i < 2; i++)
		{
			IntVector2 randomVisibleClearSpot = room.GetRandomVisibleClearSpot(2, 2);
			Vector3 convertedVector = ((IntVector2)(ref randomVisibleClearSpot)).ToVector3();
			SpawnObjectManager.SpawnObject(BraveUtility.RandomElement<GameObject>(PossibleObjects), convertedVector, SharedVFX.BloodiedScarfPoofVFX);
		}
	}

	private void KillRandomEnemy(RoomHandler room)
	{
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		AIActor randomActiveEnemy = room.GetRandomActiveEnemy(true);
		if (randomActiveEnemy.IsNormalEnemy && Object.op_Implicit((Object)(object)((BraveBehaviour)randomActiveEnemy).healthHaver) && !((BraveBehaviour)randomActiveEnemy).healthHaver.IsBoss)
		{
			Object.Instantiate<GameObject>(SharedVFX.TeleporterPrototypeTelefragVFX, Vector2Extensions.ToVector3ZisY(((GameActor)randomActiveEnemy).CenterPosition, 0f), Quaternion.identity);
			((BraveBehaviour)randomActiveEnemy).healthHaver.ApplyDamage(100000f, Vector2.zero, "His Grace", (CoreDamageTypes)0, (DamageCategory)0, true, (PixelCollider)null, false);
		}
	}

	public override bool CanBeUsed(PlayerController user)
	{
		return true;
	}
}
