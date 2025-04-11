using System;
using System.Collections.Generic;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class GunpowderPheromones : PassiveItem
{
	public static int GunpowderPheromonesID;

	public static List<string> explosiveKin = new List<string>
	{
		EnemyGuidDatabase.Entries["brollet"],
		EnemyGuidDatabase.Entries["grenat"],
		EnemyGuidDatabase.Entries["grenade_kin"],
		EnemyGuidDatabase.Entries["dynamite_kin"],
		EnemyGuidDatabase.Entries["bombshee"],
		EnemyGuidDatabase.Entries["m80_kin"],
		EnemyGuidDatabase.Entries["mine_flayers_claymore"],
		EnemyGuidDatabase.Entries["det"],
		EnemyGuidDatabase.Entries["x_det"],
		EnemyGuidDatabase.Entries["diagonal_x_det"],
		EnemyGuidDatabase.Entries["vertical_det"],
		EnemyGuidDatabase.Entries["horizontal_det"],
		EnemyGuidDatabase.Entries["diagonal_det"],
		EnemyGuidDatabase.Entries["vertical_x_det"],
		EnemyGuidDatabase.Entries["horizontal_x_det"]
	};

	public static List<string> shotgunEnemies = new List<string>
	{
		EnemyGuidDatabase.Entries["red_shotgun_kin"],
		EnemyGuidDatabase.Entries["blue_shotgun_kin"],
		EnemyGuidDatabase.Entries["veteran_shotgun_kin"],
		EnemyGuidDatabase.Entries["mutant_shotgun_kin"],
		EnemyGuidDatabase.Entries["executioner"],
		EnemyGuidDatabase.Entries["ashen_shotgun_kin"],
		EnemyGuidDatabase.Entries["shotgrub"],
		EnemyGuidDatabase.Entries["creech"],
		EnemyGuidDatabase.Entries["western_shotgun_kin"],
		EnemyGuidDatabase.Entries["shotgat"],
		EnemyGuidDatabase.Entries["pirate_shotgun_kin"]
	};

	public static void Init()
	{
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		PickupObject obj = ItemSetup.NewItem<GunpowderPheromones>("Gunpowder Pheromones", "My Pretties", "This oddly aromatic powder has peculiar effects on Gundead. Explosive Gundead seem the most succeptable.", "gunpowderpheromones_improved", assetbundle: true);
		PassiveItem val = (PassiveItem)(object)((obj is PassiveItem) ? obj : null);
		((PickupObject)val).quality = (ItemQuality)1;
		GunpowderPheromonesID = ((PickupObject)val).PickupObjectId;
	}

	public void AIActorMods(AIActor target)
	{
		if (!Object.op_Implicit((Object)(object)target) || !Object.op_Implicit((Object)(object)((BraveBehaviour)target).aiActor) || ((BraveBehaviour)target).aiActor.EnemyGuid == null)
		{
			return;
		}
		string text = ((target == null) ? null : ((BraveBehaviour)target).aiActor?.EnemyGuid);
		if (string.IsNullOrEmpty(text))
		{
			return;
		}
		try
		{
			if (explosiveKin.Contains(text))
			{
				((GameActor)target).ApplyEffect((GameActorEffect)(object)GameManager.Instance.Dungeon.sharedSettingsPrefab.DefaultPermanentCharmEffect, 1f, (Projectile)null);
				((Component)target).gameObject.AddComponent<KillOnRoomClear>();
				target.IsHarmlessEnemy = true;
				target.IgnoreForRoomClear = true;
				if (Object.op_Implicit((Object)(object)((Component)target).gameObject.GetComponent<SpawnEnemyOnDeath>()))
				{
					Object.Destroy((Object)(object)((Component)target).gameObject.GetComponent<SpawnEnemyOnDeath>());
				}
			}
			else if (((PassiveItem)this).Owner.HasPickupID(Game.Items["nn:shutdown_shells"].PickupObjectId) && shotgunEnemies.Contains(text))
			{
				((GameActor)target).ApplyEffect((GameActorEffect)(object)GameManager.Instance.Dungeon.sharedSettingsPrefab.DefaultPermanentCharmEffect, 1f, (Projectile)null);
				((Component)target).gameObject.AddComponent<KillOnRoomClear>();
				target.IsHarmlessEnemy = true;
				target.IgnoreForRoomClear = true;
				if (Object.op_Implicit((Object)(object)((Component)target).gameObject.GetComponent<SpawnEnemyOnDeath>()))
				{
					Object.Destroy((Object)(object)((Component)target).gameObject.GetComponent<SpawnEnemyOnDeath>());
				}
			}
		}
		catch (Exception ex)
		{
			ETGModConsole.Log((object)ex.Message, false);
		}
	}

	public override void Pickup(PlayerController player)
	{
		AIActor.OnPreStart = (Action<AIActor>)Delegate.Combine(AIActor.OnPreStart, new Action<AIActor>(AIActorMods));
		((PassiveItem)this).Pickup(player);
	}

	public override void DisableEffect(PlayerController player)
	{
		AIActor.OnPreStart = (Action<AIActor>)Delegate.Remove(AIActor.OnPreStart, new Action<AIActor>(AIActorMods));
		((PassiveItem)this).DisableEffect(player);
	}
}
