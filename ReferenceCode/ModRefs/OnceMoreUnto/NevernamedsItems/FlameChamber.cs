using System;
using System.Collections.Generic;
using Alexandria.ItemAPI;
using Dungeonator;
using UnityEngine;

namespace NevernamedsItems;

public class FlameChamber : PassiveItem
{
	public static int ID;

	public static void Init()
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		PickupObject val = ItemSetup.NewItem<FlameChamber>("Flame Chamber", "Hotshot", "Reloading on an empty clip ignites nearby enemies!.\n\nThis artefact seems strangely familiar to you, but you've never seen anything like it... yet.", "flamechamber_icon", assetbundle: true);
		val.quality = (ItemQuality)1;
		ItemBuilder.AddToSubShop(val, (ShopType)2, 1f);
		List<string> list = new List<string> { "nn:flame_chamber" };
		List<string> list2 = new List<string> { "charmed_bow", "charm_horn", "charming_rounds" };
		CustomSynergies.Add("Burning With Passion", list, list2, true);
		ID = val.PickupObjectId;
	}

	private void HandleGunReloaded(PlayerController player, Gun playerGun)
	{
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		if (playerGun.ClipShotsRemaining == 0)
		{
			LightEnemiesInRadiusOnFire(player);
			if (CustomSynergies.PlayerHasActiveSynergy(player, "Burning With Passion"))
			{
				DeadlyDeadlyGoopManager.GetGoopManagerForGoopType(EasyGoopDefinitions.CharmGoopDef).TimedAddGoopCircle(((BraveBehaviour)((PassiveItem)this).Owner).specRigidbody.UnitCenter, 3.75f, 0.75f, false);
			}
		}
	}

	private void LightEnemiesInRadiusOnFire(PlayerController user)
	{
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		//IL_008e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0098: Unknown result type (might be due to invalid IL or missing references)
		float num = 5f;
		if (CustomSynergies.PlayerHasActiveSynergy(user, "Pyromaniac"))
		{
			num *= 2f;
		}
		List<AIActor> activeEnemies = user.CurrentRoom.GetActiveEnemies((ActiveEnemyType)0);
		if (activeEnemies == null)
		{
			return;
		}
		for (int i = 0; i < activeEnemies.Count; i++)
		{
			AIActor val = activeEnemies[i];
			if (val.IsNormalEnemy)
			{
				float num2 = Vector2.Distance(((GameActor)user).CenterPosition, ((GameActor)val).CenterPosition);
				if (num2 <= num)
				{
					ApplyDirectStatusEffects.ApplyDirectFire((GameActor)(object)val, 10f, ((GameActorHealthEffect)StaticStatusEffects.hotLeadEffect).DamagePerSecondToEnemies, ((GameActorEffect)StaticStatusEffects.hotLeadEffect).TintColor, ((GameActorEffect)StaticStatusEffects.hotLeadEffect).DeathTintColor, (EffectResistanceType)1, "Fire", tintsEnemy: true, tintsCorpse: true);
				}
			}
		}
	}

	public override void Pickup(PlayerController player)
	{
		((PassiveItem)this).Pickup(player);
		player.OnReloadedGun = (Action<PlayerController, Gun>)Delegate.Combine(player.OnReloadedGun, new Action<PlayerController, Gun>(HandleGunReloaded));
	}

	public override DebrisObject Drop(PlayerController player)
	{
		player.OnReloadedGun = (Action<PlayerController, Gun>)Delegate.Remove(player.OnReloadedGun, new Action<PlayerController, Gun>(HandleGunReloaded));
		return ((PassiveItem)this).Drop(player);
	}

	public override void OnDestroy()
	{
		if (Object.op_Implicit((Object)(object)((PassiveItem)this).Owner))
		{
			PlayerController owner = ((PassiveItem)this).Owner;
			owner.OnReloadedGun = (Action<PlayerController, Gun>)Delegate.Remove(owner.OnReloadedGun, new Action<PlayerController, Gun>(HandleGunReloaded));
		}
		((PassiveItem)this).OnDestroy();
	}
}
