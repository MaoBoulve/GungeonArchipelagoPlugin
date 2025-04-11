using System;
using Alexandria.ItemAPI;
using Alexandria.Misc;
using Dungeonator;
using SaveAPI;
using UnityEngine;

namespace NevernamedsItems;

public class KinAmmolet : BlankModificationItem
{
	private static int ID;

	public static void Init()
	{
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		PickupObject obj = ItemSetup.NewItem<KinAmmolet>("Kin Ammolet", "Blanks Reinforce", "Blanks summon reinforcements to aid you in combat!\n\nThe little pendant is sentient, and very, very confused.", "kinammolet_icon", assetbundle: true);
		BlankModificationItem val = (BlankModificationItem)(object)((obj is BlankModificationItem) ? obj : null);
		((PickupObject)val).quality = (ItemQuality)1;
		ItemBuilder.AddPassiveStatModifier((PickupObject)(object)val, (StatType)18, 1f, (ModifyMethod)0);
		ItemBuilder.AddToSubShop((PickupObject)(object)val, (ShopType)4, 1f);
		ItemBuilder.AddToSubShop((PickupObject)(object)val, (ShopType)2, 1f);
		ID = ((PickupObject)val).PickupObjectId;
		((PickupObject)(object)val).SetupUnlockOnCustomFlag(CustomDungeonFlags.PURCHASED_KINAMMOLET, requiredFlagValue: true);
		((PickupObject)(object)val).AddItemToDougMetaShop(15, null);
		AlexandriaTags.SetTag((PickupObject)(object)val, "ammolet");
	}

	public override void Pickup(PlayerController player)
	{
		ExtendedPlayerComponent extComp = PlayerUtility.GetExtComp(player);
		extComp.OnBlankModificationItemProcessed = (Action<PlayerController, SilencerInstance, Vector2, BlankModificationItem>)Delegate.Combine(extComp.OnBlankModificationItemProcessed, new Action<PlayerController, SilencerInstance, Vector2, BlankModificationItem>(OnBlankModTriggered));
		((BlankModificationItem)this).Pickup(player);
	}

	public override void DisableEffect(PlayerController player)
	{
		ExtendedPlayerComponent extComp = PlayerUtility.GetExtComp(player);
		extComp.OnBlankModificationItemProcessed = (Action<PlayerController, SilencerInstance, Vector2, BlankModificationItem>)Delegate.Remove(extComp.OnBlankModificationItemProcessed, new Action<PlayerController, SilencerInstance, Vector2, BlankModificationItem>(OnBlankModTriggered));
		((PassiveItem)this).DisableEffect(player);
	}

	private void OnBlankModTriggered(PlayerController user, SilencerInstance blank, Vector2 pos, BlankModificationItem item)
	{
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
		if (!(item is KinAmmolet))
		{
			return;
		}
		RoomHandler currentRoom = user.CurrentRoom;
		if (currentRoom != null && currentRoom.IsSealed)
		{
			string enemyGuid = "01972dee89fc4404a5c408d50007dad5";
			bool shouldBeJammed = false;
			if (CustomSynergies.PlayerHasActiveSynergy(user, "Shotgun Club") && Random.value <= 0.5f)
			{
				enemyGuid = "128db2f0781141bcb505d8f00f9e4d47";
			}
			if (CustomSynergies.PlayerHasActiveSynergy(user, "Friends On The Other Side"))
			{
				shouldBeJammed = true;
			}
			CompanionisedEnemyUtility.SpawnCompanionisedEnemy(user, enemyGuid, Vector2Extensions.ToIntVector2(pos, (VectorConversions)2), doTint: false, ExtendedColours.brown, 15, 2, shouldBeJammed, doFriendlyOverhead: true);
			if (CustomSynergies.PlayerHasActiveSynergy(user, "Aim Twice, Shoot Once"))
			{
				CompanionisedEnemyUtility.SpawnCompanionisedEnemy(user, enemyGuid, Vector2Extensions.ToIntVector2(pos, (VectorConversions)2), doTint: false, ExtendedColours.brown, 15, 2, shouldBeJammed, doFriendlyOverhead: true);
			}
		}
	}
}
