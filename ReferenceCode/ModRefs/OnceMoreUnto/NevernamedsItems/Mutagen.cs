using System;
using Alexandria.ItemAPI;
using SaveAPI;
using UnityEngine;

namespace NevernamedsItems;

internal class Mutagen : PassiveItem
{
	public static void Init()
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		PickupObject val = ItemSetup.NewItem<Mutagen>("Mutagen", "Rampant Mutation", "Heals a small amount whenever the afflicted individual defeats a boss.\n\nThis mutagen progresses in stages, just like the Gungeon itself.", "mutagen_icon", assetbundle: true);
		val.quality = (ItemQuality)2;
		ItemBuilder.AddToSubShop(val, (ShopType)0, 1f);
		val.SetupUnlockOnCustomFlag(CustomDungeonFlags.HAS_BEATEN_BOSS_BY_SKIN_OF_TEETH, requiredFlagValue: true);
	}

	private void OnEnemyDamaged(float damage, bool fatal, HealthHaver enemy)
	{
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		//IL_0132: Unknown result type (might be due to invalid IL or missing references)
		if (!Object.op_Implicit((Object)(object)((BraveBehaviour)enemy).aiActor) || !enemy.IsBoss || !fatal)
		{
			return;
		}
		if (((PassiveItem)this).Owner.ForceZeroHealthState)
		{
			LootEngine.GivePrefabToPlayer(((Component)PickupObjectDatabase.GetById(120)).gameObject, ((PassiveItem)this).Owner);
			_003F val = ((PassiveItem)this).Owner;
			Object obj = ResourceCache.Acquire("Global VFX/vfx_healing_sparkles_001");
			((GameActor)val).PlayEffectOnActor((GameObject)(object)((obj is GameObject) ? obj : null), Vector3.zero, true, false, false);
			AkSoundEngine.PostEvent("Play_OBJ_heart_heal_01", ((Component)this).gameObject);
			if (((PassiveItem)this).Owner.HasPickupID(314))
			{
				LootEngine.GivePrefabToPlayer(((Component)PickupObjectDatabase.GetById(120)).gameObject, ((PassiveItem)this).Owner);
			}
			if (((PassiveItem)this).Owner.HasPickupID(259))
			{
				LootEngine.GivePrefabToPlayer(((Component)PickupObjectDatabase.GetById(120)).gameObject, ((PassiveItem)this).Owner);
			}
			return;
		}
		float num = 1f;
		if (((PassiveItem)this).Owner.HasPickupID(259))
		{
			num = 1.5f;
		}
		((BraveBehaviour)((PassiveItem)this).Owner).healthHaver.ApplyHealing(num);
		_003F val2 = ((PassiveItem)this).Owner;
		Object obj2 = ResourceCache.Acquire("Global VFX/vfx_healing_sparkles_001");
		((GameActor)val2).PlayEffectOnActor((GameObject)(object)((obj2 is GameObject) ? obj2 : null), Vector3.zero, true, false, false);
		AkSoundEngine.PostEvent("Play_OBJ_heart_heal_01", ((Component)this).gameObject);
		if (((PassiveItem)this).Owner.HasPickupID(314))
		{
			LootEngine.GivePrefabToPlayer(((Component)PickupObjectDatabase.GetById(120)).gameObject, ((PassiveItem)this).Owner);
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
