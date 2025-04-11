using System;
using Alexandria.ItemAPI;
using Gungeon;
using SaveAPI;
using UnityEngine;

namespace NevernamedsItems;

internal class NitroBullets : PassiveItem
{
	public static int NitroBulletsID;

	private bool hasSynergy;

	public static void Init()
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		PickupObject val = ItemSetup.NewItem<NitroBullets>("Nitro Bullets", "Badda Bing...", "50% chance for enemies to explode violently on death.\n\nMade by a lunatic who loved the way the ground shook when he used his special brand of... making things go away.\n\nYou are not immune to these explosions. You have been warned.", "nitrobullets_icon", assetbundle: true);
		val.quality = (ItemQuality)2;
		ItemBuilder.AddToSubShop(val, (ShopType)3, 1f);
		AlexandriaTags.SetTag(val, "bullet_modifier");
		val.SetupUnlockOnCustomFlag(CustomDungeonFlags.PURCHASED_NITROBULLETS, requiredFlagValue: true);
		val.AddItemToDougMetaShop(15, null);
		NitroBulletsID = val.PickupObjectId;
		Doug.AddToLootPool(val.PickupObjectId);
	}

	private void OnEnemyDamaged(float damage, bool fatal, HealthHaver enemyHealth)
	{
		//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_010e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0113: Unknown result type (might be due to invalid IL or missing references)
		//IL_011a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0120: Unknown result type (might be due to invalid IL or missing references)
		if (((PassiveItem)this).Owner.HasPickupID(304) || ((PassiveItem)this).Owner.HasPickupID(Game.Items["nn:nitroglycylinder"].PickupObjectId))
		{
			hasSynergy = true;
		}
		else
		{
			hasSynergy = false;
		}
		if (Object.op_Implicit((Object)(object)((BraveBehaviour)enemyHealth).aiActor) && Object.op_Implicit((Object)(object)enemyHealth) && !enemyHealth.IsBoss && fatal && ((BraveBehaviour)enemyHealth).aiActor.IsNormalEnemy && !hasSynergy)
		{
			if (Random.value < 0.5f)
			{
				Exploder.DoDefaultExplosion(Vector2.op_Implicit(((GameActor)((BraveBehaviour)enemyHealth).aiActor).CenterPosition), default(Vector2), (Action)null, false, (CoreDamageTypes)0, false);
			}
		}
		else if (Object.op_Implicit((Object)(object)enemyHealth) && !enemyHealth.IsBoss && fatal && Object.op_Implicit((Object)(object)((BraveBehaviour)enemyHealth).aiActor) && ((BraveBehaviour)enemyHealth).aiActor.IsNormalEnemy && hasSynergy)
		{
			Exploder.DoDefaultExplosion(Vector2.op_Implicit(((GameActor)((BraveBehaviour)enemyHealth).aiActor).CenterPosition), default(Vector2), (Action)null, false, (CoreDamageTypes)0, false);
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
