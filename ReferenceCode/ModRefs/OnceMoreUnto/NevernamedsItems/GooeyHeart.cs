using System;
using Alexandria.ItemAPI;
using Alexandria.Misc;
using UnityEngine;

namespace NevernamedsItems;

public class GooeyHeart : PassiveItem
{
	public static int GooeyHeartID;

	public static void Init()
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		PickupObject val = ItemSetup.NewItem<GooeyHeart>("Gooey Heart", "Squelchy", "Chance to heal upon killing a blob.\n\nThe heart of the Mighty Blobulord, gained through showing enough skill to leave it intact throughout the entire fight.\n\nWatch as it jiggles", "gooeyheart_icon", assetbundle: true);
		val.quality = (ItemQuality)2;
		LootUtility.RemovePickupFromLootTables(val);
		GooeyHeartID = val.PickupObjectId;
	}

	public override void DisableEffect(PlayerController player)
	{
		player.OnAnyEnemyReceivedDamage = (Action<float, bool, HealthHaver>)Delegate.Remove(player.OnAnyEnemyReceivedDamage, new Action<float, bool, HealthHaver>(HandleHeal));
		((PassiveItem)this).DisableEffect(player);
	}

	public override void Pickup(PlayerController player)
	{
		((PassiveItem)this).Pickup(player);
		player.OnAnyEnemyReceivedDamage = (Action<float, bool, HealthHaver>)Delegate.Combine(player.OnAnyEnemyReceivedDamage, new Action<float, bool, HealthHaver>(HandleHeal));
	}

	private void HandleHeal(float damage, bool fatal, HealthHaver enemy)
	{
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_00de: Unknown result type (might be due to invalid IL or missing references)
		if (Object.op_Implicit((Object)(object)enemy) && Object.op_Implicit((Object)(object)((BraveBehaviour)enemy).aiActor) && AlexandriaTags.HasTag(((BraveBehaviour)enemy).aiActor, "blobulon"))
		{
			if (((PassiveItem)this).Owner.ForceZeroHealthState && Random.value <= 0.025f)
			{
				_003F val = ((PassiveItem)this).Owner;
				Object obj = ResourceCache.Acquire("Global VFX/vfx_healing_sparkles_001");
				((GameActor)val).PlayEffectOnActor((GameObject)(object)((obj is GameObject) ? obj : null), Vector3.zero, true, false, false);
				((BraveBehaviour)((PassiveItem)this).Owner).healthHaver.Armor = ((BraveBehaviour)((PassiveItem)this).Owner).healthHaver.Armor + 1f;
			}
			else if (Random.value < 0.05f)
			{
				((BraveBehaviour)((PassiveItem)this).Owner).healthHaver.ApplyHealing(0.5f);
				_003F val2 = ((PassiveItem)this).Owner;
				Object obj2 = ResourceCache.Acquire("Global VFX/vfx_healing_sparkles_001");
				((GameActor)val2).PlayEffectOnActor((GameObject)(object)((obj2 is GameObject) ? obj2 : null), Vector3.zero, true, false, false);
			}
		}
	}
}
