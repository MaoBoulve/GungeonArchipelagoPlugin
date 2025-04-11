using System;
using System.Collections.Generic;
using Alexandria.ItemAPI;
using SaveAPI;
using UnityEngine;

namespace NevernamedsItems;

public class MinersBullets : PassiveItem
{
	public static void Init()
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		PickupObject val = ItemSetup.NewItem<MinersBullets>("Miners Bullets", "So we back in the mine", "Allows for the effortless destruction of cubes.", "minersbullets_icon", assetbundle: true);
		val.quality = (ItemQuality)1;
		AlexandriaTags.SetTag(val, "bullet_modifier");
		val.SetupUnlockOnCustomFlag(CustomDungeonFlags.PURCHASED_MINERSBULLETS, requiredFlagValue: true);
		val.AddItemToDougMetaShop(8, null);
		Doug.AddToLootPool(val.PickupObjectId);
	}

	public override void Pickup(PlayerController player)
	{
		((PassiveItem)this).Pickup(player);
		player.PostProcessProjectile += PostProcessProjectile;
		player.PostProcessBeam += PostProcessBeam;
		player.OnAnyEnemyReceivedDamage = (Action<float, bool, HealthHaver>)Delegate.Combine(player.OnAnyEnemyReceivedDamage, new Action<float, bool, HealthHaver>(OnEnemyDamaged));
	}

	private void PostProcessProjectile(Projectile sourceProjectile, float effectChanceScalar)
	{
		ProjectileInstakillBehaviour orAddComponent = GameObjectExtensions.GetOrAddComponent<ProjectileInstakillBehaviour>(((Component)sourceProjectile).gameObject);
		orAddComponent.tagsToKill.AddRange(new List<string> { "sliding_cube", "cube_blobulon" });
		if (CustomSynergies.PlayerHasActiveSynergy(((PassiveItem)this).Owner, "Eye of the Spider"))
		{
			orAddComponent.enemyGUIDsToKill.Add(EnemyGuidDatabase.Entries["phaser_spider"]);
		}
	}

	private void PostProcessBeam(BeamController sourceBeam)
	{
		if (Object.op_Implicit((Object)(object)((BraveBehaviour)sourceBeam).projectile))
		{
			PostProcessProjectile(((BraveBehaviour)sourceBeam).projectile, 1f);
		}
	}

	private void OnEnemyDamaged(float damage, bool fatal, HealthHaver enemyHealth)
	{
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
		if (fatal && Object.op_Implicit((Object)(object)enemyHealth) && Object.op_Implicit((Object)(object)((BraveBehaviour)enemyHealth).aiActor) && Object.op_Implicit((Object)(object)((PassiveItem)this).Owner) && CustomSynergies.PlayerHasActiveSynergy(((PassiveItem)this).Owner, "Miiiining Away~"))
		{
			string enemyGuid = ((BraveBehaviour)enemyHealth).aiActor.EnemyGuid;
			if (enemyGuid == "98ca70157c364750a60f5e0084f9d3e2" && CustomSynergies.PlayerHasActiveSynergy(((PassiveItem)this).Owner, "Eye of the Spider"))
			{
				LootEngine.SpawnCurrency(((BraveBehaviour)enemyHealth).sprite.WorldCenter, 5, false);
			}
			else if (AlexandriaTags.HasTag(((BraveBehaviour)enemyHealth).aiActor, "sliding_cube") || AlexandriaTags.HasTag(((BraveBehaviour)enemyHealth).aiActor, "cube_blobulon"))
			{
				LootEngine.SpawnCurrency(((BraveBehaviour)enemyHealth).sprite.WorldCenter, 5, false);
			}
		}
	}

	public override void DisableEffect(PlayerController player)
	{
		player.PostProcessProjectile -= PostProcessProjectile;
		player.PostProcessBeam -= PostProcessBeam;
		player.OnAnyEnemyReceivedDamage = (Action<float, bool, HealthHaver>)Delegate.Remove(player.OnAnyEnemyReceivedDamage, new Action<float, bool, HealthHaver>(OnEnemyDamaged));
		((PassiveItem)this).DisableEffect(player);
	}
}
