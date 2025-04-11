using System;
using Alexandria.ItemAPI;
using Alexandria.Misc;
using UnityEngine;

namespace NevernamedsItems;

public class RoundsOfTheReaver : PassiveItem
{
	public static void Init()
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		PickupObject val = ItemSetup.NewItem<RoundsOfTheReaver>("Rounds Of The Reaver", "Razed", "Separates enemies from their eternal soul.\n\nThese bullets were forged in the flesh of a great beast, trapped outside of time within an aimless void...", "roundsofthereaver_icon", assetbundle: true);
		val.quality = (ItemQuality)4;
		AlexandriaTags.SetTag(val, "bullet_modifier");
		Doug.AddToLootPool(val.PickupObjectId);
	}

	private void PostProcessProjectile(Projectile sourceProjectile, float effectChanceScalar)
	{
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		float num = 0.15f;
		num *= effectChanceScalar;
		bool flag = ((GameActor)((PassiveItem)this).Owner).CurrentGun.LastShotIndex == 0 && CustomSynergies.PlayerHasActiveSynergy(((PassiveItem)this).Owner, "Added Effect - Reave");
		try
		{
			if (Random.value <= num || flag)
			{
				sourceProjectile.AdjustPlayerProjectileTint(ExtendedColours.reaverAqua, 2, 0f);
				sourceProjectile.OnHitEnemy = (Action<Projectile, SpeculativeRigidbody, bool>)Delegate.Combine(sourceProjectile.OnHitEnemy, new Action<Projectile, SpeculativeRigidbody, bool>(OnHitEnemy));
			}
		}
		catch (Exception ex)
		{
			ETGModConsole.Log((object)ex.Message, false);
		}
	}

	private void OnHitEnemy(Projectile bullet, SpeculativeRigidbody body, bool fatal)
	{
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		if (Object.op_Implicit((Object)(object)bullet) && Object.op_Implicit((Object)(object)body) && Object.op_Implicit((Object)(object)((BraveBehaviour)body).healthHaver) && !fatal && Object.op_Implicit((Object)(object)((BraveBehaviour)body).sprite))
		{
			Reave(body, ProjectileUtility.ProjectilePlayerOwner(bullet), Vector2Extensions.ToAngle(bullet.Direction));
		}
	}

	public static void Reave(SpeculativeRigidbody enemy, PlayerController owner, float angle)
	{
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		PickupObject byId = PickupObjectDatabase.GetById(761);
		GameObject gameObject = ((Component)((Gun)((byId is Gun) ? byId : null)).DefaultModule.projectiles[0]).gameObject;
		GameObject val = SpawnManager.SpawnProjectile(gameObject, Vector2.op_Implicit(((BraveBehaviour)enemy).sprite.WorldCenter), Quaternion.Euler(0f, 0f, angle), true);
		if (Object.op_Implicit((Object)(object)val.GetComponent<Projectile>()))
		{
			Projectile component = val.GetComponent<Projectile>();
			component.Owner = (GameActor)(object)owner;
			component.Shooter = ((BraveBehaviour)owner).specRigidbody;
			component.baseData.damage = 0f;
		}
	}

	private void PostProcessBeam(BeamController beam, SpeculativeRigidbody hitRigidBody, float tickrate)
	{
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		float num = 0.15f;
		beam.AdjustPlayerBeamTint(ExtendedColours.reaverAqua, 1, 0f);
		GameActor gameActor = ((BraveBehaviour)hitRigidBody).gameActor;
		if (Object.op_Implicit((Object)(object)gameActor) && Object.op_Implicit((Object)(object)((BraveBehaviour)hitRigidBody).healthHaver) && Object.op_Implicit((Object)(object)((BraveBehaviour)hitRigidBody).sprite) && Random.value < BraveMathCollege.SliceProbability(num, tickrate))
		{
			Reave(hitRigidBody, ProjectileUtility.ProjectilePlayerOwner(((BraveBehaviour)beam).projectile), Vector2Extensions.ToAngle(beam.Direction));
		}
	}

	public override void Pickup(PlayerController player)
	{
		((PassiveItem)this).Pickup(player);
		player.PostProcessProjectile += PostProcessProjectile;
		player.PostProcessBeamTick += PostProcessBeam;
	}

	public override void DisableEffect(PlayerController player)
	{
		if (Object.op_Implicit((Object)(object)player))
		{
			player.PostProcessProjectile -= PostProcessProjectile;
			player.PostProcessBeamTick -= PostProcessBeam;
		}
		((PassiveItem)this).DisableEffect(player);
	}
}
