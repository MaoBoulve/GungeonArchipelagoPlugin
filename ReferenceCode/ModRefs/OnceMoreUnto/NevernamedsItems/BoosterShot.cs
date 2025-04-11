using System;
using Alexandria.ItemAPI;
using Alexandria.Misc;
using Dungeonator;
using UnityEngine;

namespace NevernamedsItems;

internal class BoosterShot : PassiveItem
{
	private bool spunSynergyLastChecked;

	public static void Init()
	{
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		PickupObject obj = ItemSetup.NewItem<BoosterShot>("Booster Shot", "Have you had your shots?", "5% chance to fully heal upon taking damage.\n\nThe mad wizard Alben Smallbore theorised that if one could train the body's immune system to fight pathogens, it may also be possible to vaccinate a Gungeoneer against bullets.\n\nAlben Smallbore did not have a medical license.", "boostershot_icon", assetbundle: true);
		PassiveItem val = (PassiveItem)(object)((obj is PassiveItem) ? obj : null);
		((PickupObject)val).quality = (ItemQuality)2;
	}

	private void Boost(PlayerController user)
	{
		if (!(Random.value <= 0.05f))
		{
			return;
		}
		if (!user.ForceZeroHealthState)
		{
			((BraveBehaviour)user).healthHaver.ApplyHealing(10000f);
		}
		else if (((BraveBehaviour)user).healthHaver.Armor < 6f)
		{
			int num = 6 - (int)((BraveBehaviour)user).healthHaver.Armor;
			for (int i = 0; i < num; i++)
			{
				LootEngine.GivePrefabToPlayer(((Component)PickupObjectDatabase.GetById(120)).gameObject, user);
			}
		}
	}

	public override void Update()
	{
		if (Object.op_Implicit((Object)(object)((PassiveItem)this).Owner) && CustomSynergies.PlayerHasActiveSynergy(((PassiveItem)this).Owner, "Spun") != spunSynergyLastChecked)
		{
			ItemBuilder.RemovePassiveStatModifier((PickupObject)(object)this, (StatType)5);
			((PassiveItem)this).Owner.stats.RecalculateStats(((PassiveItem)this).Owner, false, false);
			if (CustomSynergies.PlayerHasActiveSynergy(((PassiveItem)this).Owner, "Spun"))
			{
				ItemBuilder.AddPassiveStatModifier((PickupObject)(object)this, (StatType)5, 2f, (ModifyMethod)1);
				((PassiveItem)this).Owner.stats.RecalculateStats(((PassiveItem)this).Owner, false, false);
			}
			spunSynergyLastChecked = CustomSynergies.PlayerHasActiveSynergy(((PassiveItem)this).Owner, "Spun");
		}
		((PassiveItem)this).Update();
	}

	private void ModifyDamage(HealthHaver player, ModifyDamageEventArgs args)
	{
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		if (Object.op_Implicit((Object)(object)player) && Object.op_Implicit((Object)(object)((BraveBehaviour)player).gameActor) && ((BraveBehaviour)player).gameActor is PlayerController)
		{
			GameActor gameActor = ((BraveBehaviour)player).gameActor;
			PlayerController val = (PlayerController)(object)((gameActor is PlayerController) ? gameActor : null);
			if (val.characterIdentity == OMITBChars.Shade && Random.value <= 0.1f)
			{
				args.ModifiedDamage = 0f;
				PlayerUtility.DoEasyBlank(val, ((BraveBehaviour)val).specRigidbody.UnitCenter, (EasyBlankType)1);
			}
		}
	}

	public override void Pickup(PlayerController player)
	{
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		((PassiveItem)this).Pickup(player);
		if (!base.m_pickedUpThisRun)
		{
			IntVector2 bestRewardLocation = player.CurrentRoom.GetBestRewardLocation(IntVector2.One * 2, (RewardLocationStyle)1, true);
			Vector3 val = ((IntVector2)(ref bestRewardLocation)).ToVector3();
			LootEngine.SpawnItem(((Component)PickupObjectDatabase.GetById(85)).gameObject, val, Vector2.zero, 1f, false, true, false);
		}
		HealthHaver healthHaver = ((BraveBehaviour)player).healthHaver;
		healthHaver.ModifyDamage = (Action<HealthHaver, ModifyDamageEventArgs>)Delegate.Combine(healthHaver.ModifyDamage, new Action<HealthHaver, ModifyDamageEventArgs>(ModifyDamage));
		player.OnReceivedDamage += Boost;
	}

	public override DebrisObject Drop(PlayerController player)
	{
		DebrisObject result = ((PassiveItem)this).Drop(player);
		player.OnReceivedDamage -= Boost;
		HealthHaver healthHaver = ((BraveBehaviour)player).healthHaver;
		healthHaver.ModifyDamage = (Action<HealthHaver, ModifyDamageEventArgs>)Delegate.Remove(healthHaver.ModifyDamage, new Action<HealthHaver, ModifyDamageEventArgs>(ModifyDamage));
		return result;
	}

	public override void OnDestroy()
	{
		if (Object.op_Implicit((Object)(object)((PassiveItem)this).Owner))
		{
			HealthHaver healthHaver = ((BraveBehaviour)((PassiveItem)this).Owner).healthHaver;
			healthHaver.ModifyDamage = (Action<HealthHaver, ModifyDamageEventArgs>)Delegate.Remove(healthHaver.ModifyDamage, new Action<HealthHaver, ModifyDamageEventArgs>(ModifyDamage));
			((PassiveItem)this).Owner.OnReceivedDamage -= Boost;
		}
		((PassiveItem)this).OnDestroy();
	}
}
