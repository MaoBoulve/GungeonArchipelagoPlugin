using System;
using Alexandria.ItemAPI;
using UnityEngine;

namespace NevernamedsItems;

internal class CrosshairNecklace : PassiveItem
{
	public static int ID;

	public static void Init()
	{
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		PickupObject val = ItemSetup.NewItem<CrosshairNecklace>("Crosshair Necklace", "Via Crucis", "Jammed enemies have a chance to drop pickups.\n\nA necklace worn on occasion by Cultists of the True Gun for protection and prosperity.", "crosshairnecklace_icon", assetbundle: true);
		ItemBuilder.AddPassiveStatModifier(val, (StatType)14, 1f, (ModifyMethod)0);
		val.quality = (ItemQuality)1;
		ItemBuilder.AddToSubShop(val, (ShopType)2, 1f);
		ID = val.PickupObjectId;
	}

	private void OnEnemyDamaged(float damage, bool fatal, HealthHaver enemyHealth)
	{
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		int num;
		if (enemyHealth == null)
		{
			num = 0;
		}
		else
		{
			AIActor aiActor = ((BraveBehaviour)enemyHealth).aiActor;
			num = ((((aiActor != null) ? new bool?(aiActor.IsBlackPhantom) : ((bool?)null)) == true) ? 1 : 0);
		}
		if (((uint)num & (fatal ? 1u : 0u)) != 0 && Random.value <= 0.1f)
		{
			int num2 = BraveUtility.RandomElement<int>(BabyGoodChanceKin.lootIDlist);
			LootEngine.SpawnItem(((Component)PickupObjectDatabase.GetById(num2)).gameObject, Vector2.op_Implicit(((BraveBehaviour)enemyHealth).sprite.WorldCenter), Vector2.zero, 1f, false, true, false);
		}
	}

	public override void Pickup(PlayerController player)
	{
		((PassiveItem)this).Pickup(player);
		player.OnAnyEnemyReceivedDamage = (Action<float, bool, HealthHaver>)Delegate.Combine(player.OnAnyEnemyReceivedDamage, new Action<float, bool, HealthHaver>(OnEnemyDamaged));
	}

	public override DebrisObject Drop(PlayerController player)
	{
		player.OnAnyEnemyReceivedDamage = (Action<float, bool, HealthHaver>)Delegate.Remove(player.OnAnyEnemyReceivedDamage, new Action<float, bool, HealthHaver>(OnEnemyDamaged));
		return ((PassiveItem)this).Drop(player);
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
