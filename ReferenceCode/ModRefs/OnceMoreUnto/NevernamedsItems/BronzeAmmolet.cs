using System;
using System.Collections.Generic;
using Alexandria.ItemAPI;
using Alexandria.Misc;
using Dungeonator;
using SaveAPI;
using UnityEngine;

namespace NevernamedsItems;

public class BronzeAmmolet : BlankModificationItem
{
	private static int ID;

	public static void Init()
	{
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		PickupObject obj = ItemSetup.NewItem<BronzeAmmolet>("Bronze Ammolet", "Blanks Diminish", "This ammolet appears to have shrunk in the wash, and is eager to take out it's vengeance against any home appliances or Gundead fiends that get in it's way by shrinking them as well!\n\nShrunken enemies can be stomped on to kill them.", "bronzeammolet_icon", assetbundle: true);
		BlankModificationItem val = (BlankModificationItem)(object)((obj is BlankModificationItem) ? obj : null);
		((PickupObject)val).quality = (ItemQuality)2;
		ItemBuilder.AddPassiveStatModifier((PickupObject)(object)val, (StatType)18, 1f, (ModifyMethod)0);
		ItemBuilder.AddToSubShop((PickupObject)(object)val, (ShopType)4, 1f);
		ID = ((PickupObject)val).PickupObjectId;
		((PickupObject)(object)val).SetupUnlockOnCustomFlag(CustomDungeonFlags.PURCHASED_BRONZEAMMOLET, requiredFlagValue: true);
		((PickupObject)(object)val).AddItemToDougMetaShop(41, null);
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
		if (Object.op_Implicit((Object)(object)player))
		{
			ExtendedPlayerComponent extComp = PlayerUtility.GetExtComp(player);
			extComp.OnBlankModificationItemProcessed = (Action<PlayerController, SilencerInstance, Vector2, BlankModificationItem>)Delegate.Remove(extComp.OnBlankModificationItemProcessed, new Action<PlayerController, SilencerInstance, Vector2, BlankModificationItem>(OnBlankModTriggered));
		}
		((PassiveItem)this).DisableEffect(player);
	}

	private void OnBlankModTriggered(PlayerController user, SilencerInstance blank, Vector2 pos, BlankModificationItem item)
	{
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		if (!(item is BronzeAmmolet))
		{
			return;
		}
		List<AIActor> activeEnemies = user.CurrentRoom.GetActiveEnemies((ActiveEnemyType)0);
		if (activeEnemies == null)
		{
			return;
		}
		for (int i = 0; i < activeEnemies.Count; i++)
		{
			if (Random.value <= 0.5f)
			{
				((GameActor)activeEnemies[i]).ApplyEffect((GameActorEffect)(object)StatusEffectHelper.GenerateSizeEffect(10f, new Vector2(0.4f, 0.4f)), 1f, (Projectile)null);
			}
		}
	}
}
