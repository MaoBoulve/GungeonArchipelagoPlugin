using System;
using Alexandria.ItemAPI;
using Gungeon;
using SaveAPI;
using UnityEngine;

namespace NevernamedsItems;

public class Ringer : AdvancedGunBehavior
{
	public static int RingerID;

	public static void Add()
	{
		//IL_0098: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0110: Unknown result type (might be due to invalid IL or missing references)
		//IL_018f: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Ringer", "ringer");
		Game.Items.Rename("outdated_gun_mods:ringer", "nn:ringer");
		((Component)val).gameObject.AddComponent<Ringer>();
		GunExt.SetShortDescription((PickupObject)(object)val, "Been Through It");
		GunExt.SetLongDescription((PickupObject)(object)val, "Blasts you forwards with each shot, and has a chance to negate damage while held.\n\nWhoever made this must really have liked to go fast.");
		val.SetGunSprites("ringer");
		GunExt.SetAnimationFPS(val, val.shootAnimation, 10);
		PickupObject byId = PickupObjectDatabase.GetById(647);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId is Gun) ? byId : null), true, false);
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.shootStyle = (ShootStyle)1;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 1f;
		val.DefaultModule.cooldownTime = 0.1f;
		val.DefaultModule.numberOfShotsInClip = 40;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(2.18f, 0.43f, 0f);
		val.SetBaseMaxAmmo(550);
		val.ammo = 550;
		val.gunClass = (GunClass)10;
		Projectile val2 = Object.Instantiate<Projectile>(val.DefaultModule.projectiles[0]);
		((Component)val2).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val2).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val2);
		ProjectileData baseData = val2.baseData;
		baseData.damage *= 1.8f;
		ProjectileData baseData2 = val2.baseData;
		baseData2.force *= 1.2f;
		val.DefaultModule.projectiles[0] = val2;
		((PickupObject)val).quality = (ItemQuality)2;
		Databases.Items.Add(val, (tk2dSpriteCollectionData)null, "ANY");
		RingerID = ((PickupObject)val).PickupObjectId;
		((PickupObject)(object)val).SetupUnlockOnCustomFlag(CustomDungeonFlags.BEATEN_MINES_BOSS_TURBO_MODE, requiredFlagValue: true);
	}

	private void ModifyDamage(HealthHaver player, ModifyDamageEventArgs args)
	{
		//IL_008e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0093: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
		if (!(((BraveBehaviour)player).gameActor is PlayerController) || ((PickupObject)((GameActor)/*isinst with value type is only supported in some contexts*/).CurrentGun).PickupObjectId != RingerID || !(Random.value <= 0.25f))
		{
			return;
		}
		args.ModifiedDamage = 0f;
		float num = 0f;
		for (int i = 0; i < 12; i++)
		{
			num += 30f;
			GameObject val = SpawnManager.SpawnProjectile(((Component)base.gun.DefaultModule.projectiles[0]).gameObject, Vector2.op_Implicit(((BraveBehaviour)player).sprite.WorldCenter), Quaternion.Euler(0f, 0f, num), true);
			Projectile component = val.GetComponent<Projectile>();
			if ((Object)(object)component != (Object)null)
			{
				component.Owner = ((AdvancedGunBehavior)this).Owner;
				component.Shooter = ((BraveBehaviour)((AdvancedGunBehavior)this).Owner).specRigidbody;
			}
		}
	}

	protected override void OnPickedUpByPlayer(PlayerController player)
	{
		HealthHaver healthHaver = ((BraveBehaviour)player).healthHaver;
		healthHaver.ModifyDamage = (Action<HealthHaver, ModifyDamageEventArgs>)Delegate.Combine(healthHaver.ModifyDamage, new Action<HealthHaver, ModifyDamageEventArgs>(ModifyDamage));
		((AdvancedGunBehavior)this).OnPickedUpByPlayer(player);
	}

	public override void OnDestroy()
	{
		if (Object.op_Implicit((Object)(object)base.gun) && Object.op_Implicit((Object)(object)base.gun.CurrentOwner))
		{
			HealthHaver healthHaver = ((BraveBehaviour)base.gun.CurrentOwner).healthHaver;
			healthHaver.ModifyDamage = (Action<HealthHaver, ModifyDamageEventArgs>)Delegate.Remove(healthHaver.ModifyDamage, new Action<HealthHaver, ModifyDamageEventArgs>(ModifyDamage));
		}
		((BraveBehaviour)this).OnDestroy();
	}

	protected override void OnPostDroppedByPlayer(PlayerController player)
	{
		HealthHaver healthHaver = ((BraveBehaviour)player).healthHaver;
		healthHaver.ModifyDamage = (Action<HealthHaver, ModifyDamageEventArgs>)Delegate.Remove(healthHaver.ModifyDamage, new Action<HealthHaver, ModifyDamageEventArgs>(ModifyDamage));
		((AdvancedGunBehavior)this).OnPostDroppedByPlayer(player);
	}

	public override void OnPostFired(PlayerController player, Gun gun)
	{
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		KnockbackDoer knockbackDoer = ((BraveBehaviour)player).knockbackDoer;
		Vector2 val = ((BraveBehaviour)player).sprite.WorldCenter - Vector3Extensions.XY(player.unadjustedAimPoint);
		knockbackDoer.ApplyKnockback(((Vector2)(ref val)).normalized * -1f, 30f, false);
		((AdvancedGunBehavior)this).OnPostFired(player, gun);
	}
}
