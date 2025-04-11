using System;
using Alexandria.ItemAPI;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

internal class AmuletOfShelltan : PassiveItem
{
	public static void Init()
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		PickupObject val = ItemSetup.NewItem<AmuletOfShelltan>("Amulet of Shell'tan", "Promise of Ammo", "All bosses drop ammo.\n\nThis pendant denotes devotion to the elemental lord of ammunition, Shell'tan.", "amuletofshelltan_icon", assetbundle: true);
		val.quality = (ItemQuality)1;
		ItemBuilder.AddToSubShop(val, (ShopType)2, 1f);
		Game.Items.Rename("nn:amulet_of_shell'tan", "nn:amulet_of_shelltan");
	}

	private void OnEnemyDamaged(float damage, bool fatal, HealthHaver enemy)
	{
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		if (Object.op_Implicit((Object)(object)((BraveBehaviour)enemy).aiActor) && enemy.IsBoss && fatal)
		{
			if (Random.value <= 0.5f)
			{
				LootEngine.SpawnItem(((Component)PickupObjectDatabase.GetById(78)).gameObject, Vector2.op_Implicit(((BraveBehaviour)enemy).specRigidbody.UnitCenter), Vector2.zero, 0f, true, false, false);
			}
			else
			{
				LootEngine.SpawnItem(((Component)PickupObjectDatabase.GetById(600)).gameObject, Vector2.op_Implicit(((BraveBehaviour)enemy).specRigidbody.UnitCenter), Vector2.zero, 0f, true, false, false);
			}
		}
	}

	public override void Pickup(PlayerController player)
	{
		((PassiveItem)this).Pickup(player);
		player.OnAnyEnemyReceivedDamage = (Action<float, bool, HealthHaver>)Delegate.Combine(player.OnAnyEnemyReceivedDamage, new Action<float, bool, HealthHaver>(OnEnemyDamaged));
	}

	public override DebrisObject Drop(PlayerController player)
	{
		DebrisObject result = ((PassiveItem)this).Drop(player);
		player.OnAnyEnemyReceivedDamage = (Action<float, bool, HealthHaver>)Delegate.Remove(player.OnAnyEnemyReceivedDamage, new Action<float, bool, HealthHaver>(OnEnemyDamaged));
		return result;
	}

	public override void OnDestroy()
	{
		if (Object.op_Implicit((Object)(object)((PassiveItem)this).Owner))
		{
			PlayerController owner = ((PassiveItem)this).Owner;
			owner.OnAnyEnemyReceivedDamage = (Action<float, bool, HealthHaver>)Delegate.Remove(owner.OnAnyEnemyReceivedDamage, new Action<float, bool, HealthHaver>(OnEnemyDamaged));
		}
		((PassiveItem)this).OnDestroy();
	}
}
