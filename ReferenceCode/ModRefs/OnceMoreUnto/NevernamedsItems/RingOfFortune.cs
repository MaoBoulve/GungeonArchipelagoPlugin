using System;
using Alexandria.ItemAPI;
using SaveAPI;
using UnityEngine;

namespace NevernamedsItems;

internal class RingOfFortune : PassiveItem
{
	public static int ID;

	public static void Init()
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		PickupObject val = ItemSetup.NewItem<RingOfFortune>("Ring Of Fortune", "+1 To Fortune", "Grants a single casing for every enemy slain.\n\nUsed by a gundead Beggar to barely scrape by in the days of old, before his eyesight became too bad to shoot down Bullats.", "ringoffortune_icon", assetbundle: true);
		val.quality = (ItemQuality)3;
		val.additionalMagnificenceModifier = 1f;
		AlexandriaTags.SetTag(val, "lucky");
		ID = val.PickupObjectId;
		val.SetupUnlockOnCustomStat(CustomTrackedStats.BEGGAR_TOTAL_DONATIONS, 2554f, (PrerequisiteOperation)2);
	}

	private void OnEnemyDamaged(float damage, bool fatal, HealthHaver enemy)
	{
		if (fatal && Object.op_Implicit((Object)(object)((PassiveItem)this).Owner))
		{
			LootEngine.TryGivePrefabToPlayer(((Component)PickupObjectDatabase.GetById(68)).gameObject, ((PassiveItem)this).Owner, false);
		}
	}

	public override void Pickup(PlayerController player)
	{
		player.OnAnyEnemyReceivedDamage = (Action<float, bool, HealthHaver>)Delegate.Combine(player.OnAnyEnemyReceivedDamage, new Action<float, bool, HealthHaver>(OnEnemyDamaged));
		((PassiveItem)this).Pickup(player);
	}

	public override void DisableEffect(PlayerController player)
	{
		if (Object.op_Implicit((Object)(object)player))
		{
			player.OnAnyEnemyReceivedDamage = (Action<float, bool, HealthHaver>)Delegate.Remove(player.OnAnyEnemyReceivedDamage, new Action<float, bool, HealthHaver>(OnEnemyDamaged));
		}
		((PassiveItem)this).DisableEffect(player);
	}
}
