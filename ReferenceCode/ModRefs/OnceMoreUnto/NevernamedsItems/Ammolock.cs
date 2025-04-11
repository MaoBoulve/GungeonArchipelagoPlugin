using System;
using System.Collections.Generic;
using Alexandria.ItemAPI;
using Alexandria.Misc;
using Dungeonator;
using UnityEngine;

namespace NevernamedsItems;

public class Ammolock : BlankModificationItem
{
	private static int ID;

	public static void Init()
	{
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		PickupObject obj = ItemSetup.NewItem<Ammolock>("Ammolock", "Blanks Clamp", "Blanks lock enemies in place, unable to move!\n\nForged out of impossible Neutronium Alloy, this Ammolet saps Gundead of all their energy.", "ammolock_icon", assetbundle: true);
		BlankModificationItem val = (BlankModificationItem)(object)((obj is BlankModificationItem) ? obj : null);
		((PickupObject)val).quality = (ItemQuality)2;
		ItemBuilder.AddPassiveStatModifier((PickupObject)(object)val, (StatType)18, 1f, (ModifyMethod)0);
		ItemBuilder.AddToSubShop((PickupObject)(object)val, (ShopType)4, 1f);
		ID = ((PickupObject)val).PickupObjectId;
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
		//IL_009f: Unknown result type (might be due to invalid IL or missing references)
		if (!(item is Ammolock))
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
			AIActor val = activeEnemies[i];
			if (Object.op_Implicit((Object)(object)val))
			{
				((BraveBehaviour)val).gameActor.ApplyEffect((GameActorEffect)(object)StatusEffectHelper.GenerateLockdown(10f), 1f, (Projectile)null);
				if (CustomSynergies.PlayerHasActiveSynergy(user, "Under Lock And Key") && Object.op_Implicit((Object)(object)((BraveBehaviour)val).healthHaver))
				{
					((BraveBehaviour)val).healthHaver.ApplyDamage((float)(7 * user.carriedConsumables.KeyBullets), Vector2.zero, "Under Lock And Key", (CoreDamageTypes)0, (DamageCategory)0, false, (PixelCollider)null, false);
				}
			}
		}
	}
}
