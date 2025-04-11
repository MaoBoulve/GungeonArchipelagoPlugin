using System;
using Alexandria.ItemAPI;
using Alexandria.Misc;
using Dungeonator;
using UnityEngine;

namespace NevernamedsItems;

public class SilverAmmolet : BlankModificationItem
{
	private static int ID;

	public static void Init()
	{
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		PickupObject obj = ItemSetup.NewItem<SilverAmmolet>("Silver Ammolet", "Blanks Cleanse", "A holy artefact from The Order of The True Gun's archives.\n\nMade of 200% Silver, and capable of bestowing a holy cleanse upon the Jammed.", "silverammolet_icon", assetbundle: true);
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
		//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f0: Unknown result type (might be due to invalid IL or missing references)
		if (!(item is SilverAmmolet) || user.CurrentRoom == null || !user.CurrentRoom.HasActiveEnemies((ActiveEnemyType)0))
		{
			return;
		}
		foreach (AIActor activeEnemy in user.CurrentRoom.GetActiveEnemies((ActiveEnemyType)0))
		{
			if (!activeEnemy.IsBlackPhantom)
			{
				continue;
			}
			float num = 0.5f;
			float num2 = 30f;
			if (CustomSynergies.PlayerHasActiveSynergy(user, "Blessed are The Shriek"))
			{
				num = 0.7f;
				num2 = 42f;
			}
			if (Random.value <= num)
			{
				((GameActor)activeEnemy).PlayEffectOnActor(((Component)PickupObjectDatabase.GetById(538)).GetComponent<SilverBulletsPassiveItem>().SynergyPowerVFX, new Vector3(0f, -0.5f, 0f), true, false, false);
				if (Object.op_Implicit((Object)(object)((BraveBehaviour)activeEnemy).healthHaver))
				{
					((BraveBehaviour)activeEnemy).healthHaver.ApplyDamage(num2, Vector2.zero, "Silver Ammolet", (CoreDamageTypes)0, (DamageCategory)0, false, (PixelCollider)null, false);
				}
				activeEnemy.UnbecomeBlackPhantom();
			}
		}
	}
}
