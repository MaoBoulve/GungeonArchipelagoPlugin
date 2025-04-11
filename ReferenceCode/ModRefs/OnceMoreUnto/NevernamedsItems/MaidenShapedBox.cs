using System;
using System.Collections.Generic;
using Alexandria.ItemAPI;
using SaveAPI;
using UnityEngine;

namespace NevernamedsItems;

public class MaidenShapedBox : PassiveItem
{
	public static List<string> listMaidens = new List<string>
	{
		EnemyGuidDatabase.Entries["lead_maiden"],
		EnemyGuidDatabase.Entries["fridge_maiden"]
	};

	public static void Init()
	{
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		PickupObject val = ItemSetup.NewItem<MaidenShapedBox>("Maiden-Shaped Box", "Singlehandedly Ruining This Game", "The itty bitty nanites contained within this peculiarly shaped container are specifically programmed to seek, destroy, and transmute Lead Maidens.\n\nWhoever made this thing must have really hated Lead Maidens.", "maidenshapedbox_icon", assetbundle: true);
		ItemBuilder.AddPassiveStatModifier(val, (StatType)14, 1f, (ModifyMethod)0);
		val.quality = (ItemQuality)3;
		val.SetupUnlockOnCustomFlag(CustomDungeonFlags.JAMMEDLEADMAIDEN_QUEST_REWARDED, requiredFlagValue: true);
	}

	public override void Pickup(PlayerController player)
	{
		((PassiveItem)this).Pickup(player);
		player.PostProcessProjectile += PostProcessProjectile;
		player.PostProcessBeam += PostProcessBeam;
	}

	private void PostProcessProjectile(Projectile sourceProjectile, float effectChanceScalar)
	{
		try
		{
			sourceProjectile.OnHitEnemy = (Action<Projectile, SpeculativeRigidbody, bool>)Delegate.Combine(sourceProjectile.OnHitEnemy, new Action<Projectile, SpeculativeRigidbody, bool>(OnHitEnemy));
		}
		catch (Exception ex)
		{
			ETGModConsole.Log((object)ex.Message, false);
		}
	}

	private void PostProcessBeam(BeamController sourceBeam)
	{
		try
		{
			Projectile projectile = ((BraveBehaviour)sourceBeam).projectile;
			projectile.OnHitEnemy = (Action<Projectile, SpeculativeRigidbody, bool>)Delegate.Combine(projectile.OnHitEnemy, new Action<Projectile, SpeculativeRigidbody, bool>(OnHitEnemy));
		}
		catch (Exception ex)
		{
			ETGModConsole.Log((object)ex.Message, false);
		}
	}

	private void OnHitEnemy(Projectile arg1, SpeculativeRigidbody arg2, bool arg3)
	{
		string value = ((arg2 == null) ? null : ((BraveBehaviour)arg2).aiActor?.EnemyGuid);
		if (string.IsNullOrEmpty(value))
		{
			return;
		}
		try
		{
			foreach (string listMaiden in listMaidens)
			{
				if (listMaiden.Equals(value))
				{
					if (GameStatsManager.Instance.IsRainbowRun)
					{
						SpawnMaidenRainbowLoot(((BraveBehaviour)((BraveBehaviour)arg2).aiActor).healthHaver);
					}
					else
					{
						SpawnMaidenLoot(((BraveBehaviour)((BraveBehaviour)arg2).aiActor).healthHaver);
					}
					InstaKill(((BraveBehaviour)((BraveBehaviour)arg2).aiActor).healthHaver);
					break;
				}
			}
		}
		catch (Exception ex)
		{
			ETGModConsole.Log((object)ex.Message, false);
		}
	}

	public void SpawnMaidenLoot(HealthHaver target)
	{
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Unknown result type (might be due to invalid IL or missing references)
		//IL_0089: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		if (!((BraveBehaviour)target).healthHaver.IsDead)
		{
			int num = Random.Range(1, 100);
			ItemQuality val = (ItemQuality)1;
			if (num <= 37)
			{
				val = (ItemQuality)1;
			}
			else if (num <= 67)
			{
				val = (ItemQuality)2;
			}
			else if (num <= 87)
			{
				val = (ItemQuality)3;
			}
			else if (num <= 98)
			{
				val = (ItemQuality)4;
			}
			else if (num <= 100)
			{
				val = (ItemQuality)5;
			}
			GameManager.Instance.RewardManager.SpawnTotallyRandomItem(((BraveBehaviour)target).specRigidbody.UnitCenter, val, val);
		}
	}

	public void SpawnMaidenRainbowLoot(HealthHaver target)
	{
		//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Unknown result type (might be due to invalid IL or missing references)
		//IL_0089: Unknown result type (might be due to invalid IL or missing references)
		//IL_008e: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_0104: Unknown result type (might be due to invalid IL or missing references)
		//IL_0109: Unknown result type (might be due to invalid IL or missing references)
		//IL_010e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0139: Unknown result type (might be due to invalid IL or missing references)
		//IL_0180: Unknown result type (might be due to invalid IL or missing references)
		if (((BraveBehaviour)target).healthHaver.IsDead)
		{
			return;
		}
		int num = Random.Range(1, 100);
		if (num <= 35)
		{
			if (Random.value > 0.5f)
			{
				LootEngine.SpawnItem(((Component)PickupObjectDatabase.GetById(127)).gameObject, Vector2.op_Implicit(((BraveBehaviour)target).specRigidbody.UnitCenter), Vector2.zero, 1f, false, true, false);
			}
			else
			{
				LootEngine.SpawnItem(((Component)PickupObjectDatabase.GetById(565)).gameObject, Vector2.op_Implicit(((BraveBehaviour)target).specRigidbody.UnitCenter), Vector2.zero, 1f, false, true, false);
			}
		}
		else if (num <= 67)
		{
			LootEngine.SpawnHealth(((BraveBehaviour)target).specRigidbody.UnitCenter, 1, (Vector2?)null, 4f, 0.05f);
		}
		else if (num <= 87)
		{
			LootEngine.SpawnItem(((Component)PickupObjectDatabase.GetById(120)).gameObject, Vector2.op_Implicit(((BraveBehaviour)target).specRigidbody.UnitCenter), Vector2.zero, 1f, false, true, false);
		}
		else if (num <= 96)
		{
			LootEngine.SpawnHealth(((BraveBehaviour)target).specRigidbody.UnitCenter, 2, (Vector2?)null, 4f, 0.05f);
		}
		else if (num <= 100)
		{
			LootEngine.SpawnBowlerNote(GameManager.Instance.RewardManager.BowlerNoteBoss, ((BraveBehaviour)target).specRigidbody.UnitCenter, ((BraveBehaviour)target).aiActor.ParentRoom, true);
		}
	}

	public void InstaKill(HealthHaver target)
	{
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			target.ApplyDamage(10000000f, Vector2.zero, "Erasure", (CoreDamageTypes)0, (DamageCategory)5, true, (PixelCollider)null, false);
		}
		catch (Exception ex)
		{
			ETGModConsole.Log((object)ex.Message, false);
		}
	}

	public override DebrisObject Drop(PlayerController player)
	{
		DebrisObject result = ((PassiveItem)this).Drop(player);
		player.PostProcessProjectile -= PostProcessProjectile;
		player.PostProcessBeam -= PostProcessBeam;
		return result;
	}

	public override void OnDestroy()
	{
		if (Object.op_Implicit((Object)(object)((PassiveItem)this).Owner))
		{
			((PassiveItem)this).Owner.PostProcessProjectile -= PostProcessProjectile;
			((PassiveItem)this).Owner.PostProcessBeam -= PostProcessBeam;
		}
		((PassiveItem)this).OnDestroy();
	}
}
