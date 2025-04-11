using System;
using Alexandria.ItemAPI;
using SaveAPI;
using UnityEngine;

namespace NevernamedsItems;

public class LockdownBullets : PassiveItem
{
	public static void Init()
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		PickupObject val = ItemSetup.NewItem<LockdownBullets>("Lockdown Bullets", "Clapped In Irons", "Chance to lock enemies in place.\n\nComissioned by an elderly Gungeoneer whose reaction times weren't enough to keep up with all those fast young whippersnapper bullet kin.", "lockdownbullets_icon", assetbundle: true);
		val.quality = (ItemQuality)2;
		AlexandriaTags.SetTag(val, "bullet_modifier");
		val.SetupUnlockOnCustomFlag(CustomDungeonFlags.PURCHASED_LOCKDOWNBULLETS, requiredFlagValue: true);
		val.AddItemToDougMetaShop(20, null);
		Doug.AddToLootPool(val.PickupObjectId);
	}

	private void PostProcessProjectile(Projectile sourceProjectile, float effectChanceScalar)
	{
		//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
		float num = 0.12f;
		num *= effectChanceScalar;
		bool flag = ((GameActor)((PassiveItem)this).Owner).CurrentGun.LastShotIndex == 0 && CustomSynergies.PlayerHasActiveSynergy(((PassiveItem)this).Owner, "Added Effect - Lockdown");
		bool flag2 = ((GameActor)((PassiveItem)this).Owner).CurrentGun.LastShotIndex == ((GameActor)((PassiveItem)this).Owner).CurrentGun.ClipCapacity - 1 && CustomSynergies.PlayerHasActiveSynergy(((PassiveItem)this).Owner, "Moonstone Weapon");
		try
		{
			if (Random.value <= num || flag || flag2)
			{
				ApplyLockdownBulletBehaviour orAddComponent = GameObjectExtensions.GetOrAddComponent<ApplyLockdownBulletBehaviour>(((Component)sourceProjectile).gameObject);
				orAddComponent.duration = 4f;
				orAddComponent.useSpecialBulletTint = true;
				orAddComponent.bulletTintColour = Color.grey;
				orAddComponent.TintEnemy = true;
				orAddComponent.procChance = 1;
			}
		}
		catch (Exception ex)
		{
			ETGModConsole.Log((object)ex.Message, false);
		}
	}

	private void PostProcessBeam(BeamController beam, SpeculativeRigidbody hitRigidBody, float tickrate)
	{
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		float num = 0.12f;
		GameActor gameActor = ((BraveBehaviour)hitRigidBody).gameActor;
		if (Object.op_Implicit((Object)(object)gameActor) && Random.value < BraveMathCollege.SliceProbability(num, tickrate))
		{
			ApplyLockdown.ApplyDirectLockdown(((BraveBehaviour)hitRigidBody).gameActor, 4f, Color.grey, Color.grey, (EffectResistanceType)0, "Lockdown", tintsEnemy: true, tintsCorpse: false);
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
