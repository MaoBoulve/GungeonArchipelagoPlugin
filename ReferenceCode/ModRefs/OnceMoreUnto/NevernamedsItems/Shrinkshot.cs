using System;
using Alexandria.ItemAPI;
using SaveAPI;
using UnityEngine;

namespace NevernamedsItems;

public class Shrinkshot : PassiveItem
{
	public static void Init()
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		PickupObject val = ItemSetup.NewItem<Shrinkshot>("Shrinkshot", "A Person's A Person", "Chance to shrink enemies, allowing them to be stomped on.\n\nA portal accident.", "shrinkshot_icon", assetbundle: true);
		val.quality = (ItemQuality)3;
		AlexandriaTags.SetTag(val, "bullet_modifier");
		val.SetupUnlockOnCustomFlag(CustomDungeonFlags.PURCHASED_SHRINKSHOT, requiredFlagValue: true);
		val.AddItemToDougMetaShop(40, null);
		Doug.AddToLootPool(val.PickupObjectId);
	}

	private void PostProcessProjectile(Projectile sourceProjectile, float effectChanceScalar)
	{
		//IL_008b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
		float num = 0.09f;
		num *= effectChanceScalar;
		bool flag = ((GameActor)((PassiveItem)this).Owner).CurrentGun.LastShotIndex == 0 && CustomSynergies.PlayerHasActiveSynergy(((PassiveItem)this).Owner, "Added Effect - Shrink");
		bool flag2 = ((GameActor)((PassiveItem)this).Owner).CurrentGun.LastShotIndex == ((GameActor)((PassiveItem)this).Owner).CurrentGun.ClipCapacity - 1 && CustomSynergies.PlayerHasActiveSynergy(((PassiveItem)this).Owner, "Topaz Weapon");
		try
		{
			if (Random.value <= num || flag || flag2)
			{
				sourceProjectile.RuntimeUpdateScale(0.7f);
				sourceProjectile.AdjustPlayerProjectileTint(ExtendedColours.vibrantOrange, 2, 0f);
				sourceProjectile.statusEffectsToApply.Add((GameActorEffect)(object)StatusEffectHelper.GenerateSizeEffect(10f, new Vector2(0.4f, 0.4f)));
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
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		float num = 0.09f;
		beam.AdjustPlayerBeamTint(ExtendedColours.vibrantOrange, 1, 0f);
		GameActor gameActor = ((BraveBehaviour)hitRigidBody).gameActor;
		if (Object.op_Implicit((Object)(object)gameActor) && Random.value < BraveMathCollege.SliceProbability(num, tickrate))
		{
			((BraveBehaviour)hitRigidBody).gameActor.ApplyEffect((GameActorEffect)(object)StatusEffectHelper.GenerateSizeEffect(10f, new Vector2(0.4f, 0.4f)), 1f, (Projectile)null);
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
