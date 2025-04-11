using System;
using Alexandria.ItemAPI;
using SaveAPI;
using UnityEngine;

namespace NevernamedsItems;

public class PestiferousLead : PassiveItem
{
	public static void Init()
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		PickupObject val = ItemSetup.NewItem<PestiferousLead>("Pestiferous Lead", "The Fester Pours", "These shells are loaded with a potent viral slurry, capable of quickly spreading through an enemy legion.\n\nFar removed from the ancient days of plague warfare, which typically involved corpses and catapults.", "pestiferouslead_icon", assetbundle: true);
		val.quality = (ItemQuality)4;
		AlexandriaTags.SetTag(val, "bullet_modifier");
		val.SetupUnlockOnCustomFlag(CustomDungeonFlags.PURCHASED_PESTIFEROUSLEAD, requiredFlagValue: true);
		val.AddItemToDougMetaShop(30, null);
		Doug.AddToLootPool(val.PickupObjectId);
	}

	private void PostProcessProjectile(Projectile sourceProjectile, float effectChanceScalar)
	{
		//IL_007f: Unknown result type (might be due to invalid IL or missing references)
		float num = 0.12f;
		num *= effectChanceScalar;
		bool flag = ((GameActor)((PassiveItem)this).Owner).CurrentGun.LastShotIndex == 0 && CustomSynergies.PlayerHasActiveSynergy(((PassiveItem)this).Owner, "Added Effect - Plague");
		bool flag2 = ((GameActor)((PassiveItem)this).Owner).CurrentGun.LastShotIndex == ((GameActor)((PassiveItem)this).Owner).CurrentGun.ClipCapacity - 1 && CustomSynergies.PlayerHasActiveSynergy(((PassiveItem)this).Owner, "Amethyst Weapon");
		try
		{
			if (Random.value <= num || flag || flag2)
			{
				sourceProjectile.AdjustPlayerProjectileTint(ExtendedColours.plaguePurple, 2, 0f);
				sourceProjectile.statusEffectsToApply.Add((GameActorEffect)(object)StaticStatusEffects.StandardPlagueEffect);
			}
		}
		catch (Exception ex)
		{
			ETGModConsole.Log((object)ex.Message, false);
		}
	}

	private void PostProcessBeam(BeamController beam, SpeculativeRigidbody hitRigidBody, float tickrate)
	{
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		float num = 0.12f;
		beam.AdjustPlayerBeamTint(ExtendedColours.plaguePurple, 1, 0f);
		GameActor gameActor = ((BraveBehaviour)hitRigidBody).gameActor;
		if (Object.op_Implicit((Object)(object)gameActor) && Random.value < BraveMathCollege.SliceProbability(num, tickrate))
		{
			((BraveBehaviour)hitRigidBody).gameActor.ApplyEffect((GameActorEffect)(object)StaticStatusEffects.StandardPlagueEffect, 1f, (Projectile)null);
		}
	}

	public override DebrisObject Drop(PlayerController player)
	{
		DebrisObject result = ((PassiveItem)this).Drop(player);
		player.PostProcessProjectile -= PostProcessProjectile;
		player.PostProcessBeamTick -= PostProcessBeam;
		return result;
	}

	public override void Pickup(PlayerController player)
	{
		((PassiveItem)this).Pickup(player);
		player.PostProcessProjectile += PostProcessProjectile;
		player.PostProcessBeamTick += PostProcessBeam;
	}

	public override void OnDestroy()
	{
		if (Object.op_Implicit((Object)(object)((PassiveItem)this).Owner))
		{
			((PassiveItem)this).Owner.PostProcessBeamTick -= PostProcessBeam;
			((PassiveItem)this).Owner.PostProcessProjectile -= PostProcessProjectile;
		}
		((PassiveItem)this).OnDestroy();
	}
}
