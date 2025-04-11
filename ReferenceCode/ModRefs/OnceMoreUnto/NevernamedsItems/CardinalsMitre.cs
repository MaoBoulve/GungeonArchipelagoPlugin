using System;
using System.Collections.Generic;
using Alexandria.Assetbundle;
using Alexandria.ItemAPI;
using UnityEngine;

namespace NevernamedsItems;

public class CardinalsMitre : PassiveItem
{
	public static Projectile MitreProjectile;

	private bool canFire = true;

	public static void Init()
	{
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_0133: Unknown result type (might be due to invalid IL or missing references)
		//IL_0143: Unknown result type (might be due to invalid IL or missing references)
		//IL_0153: Unknown result type (might be due to invalid IL or missing references)
		PickupObject obj = ItemSetup.NewItem<CardinalsMitre>("Cardinals Mitre", "Ex Cathedra", "Fires a homing bullet upon reloading.\n\nImbued with power by a Bishop of the True Gun, hats like these are worn by Kaliber-devout Cardinals.", "cardinalsmitre_icon", assetbundle: true);
		PassiveItem val = (PassiveItem)(object)((obj is PassiveItem) ? obj : null);
		((PickupObject)val).quality = (ItemQuality)2;
		PickupObject byId = PickupObjectDatabase.GetById(86);
		MitreProjectile = Object.Instantiate<Projectile>(((Gun)((byId is Gun) ? byId : null)).DefaultModule.projectiles[0]);
		((Component)MitreProjectile).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)MitreProjectile).gameObject);
		Object.DontDestroyOnLoad((Object)(object)MitreProjectile);
		ProjectileData baseData = MitreProjectile.baseData;
		baseData.damage *= 5f;
		ProjectileData baseData2 = MitreProjectile.baseData;
		baseData2.speed *= 0.4f;
		MitreProjectile.SetProjectileSprite("mitreproj_1", 22, 22, lightened: true, (Anchor)4, 22, 22, anchorChangesCollider: true, fixesScale: false, null, null);
		HomingModifier val2 = ((Component)MitreProjectile).gameObject.AddComponent<HomingModifier>();
		val2.AngularVelocity = 80f;
		val2.HomingRadius = 1000f;
		ProjectileBuilders.AnimateProjectileBundle(MitreProjectile, "CardinalsMitreProjectile", Initialisation.ProjectileCollection, Initialisation.projectileAnimationCollection, "CardinalsMitreProjectile", new List<IntVector2>
		{
			new IntVector2(22, 22),
			new IntVector2(20, 20),
			new IntVector2(20, 20)
		}, MiscTools.DupeList(value: true, 3), MiscTools.DupeList<Anchor>((Anchor)4, 3), MiscTools.DupeList(value: true, 3), MiscTools.DupeList(value: false, 3), MiscTools.DupeList<Vector3?>(null, 3), MiscTools.DupeList<IntVector2?>(null, 3), MiscTools.DupeList<IntVector2?>(null, 3), MiscTools.DupeList<Projectile>(null, 3));
	}

	private void HandleGunReloaded(PlayerController player, Gun playerGun)
	{
		if (playerGun.ClipShotsRemaining == 0)
		{
			FireBullet(player);
		}
	}

	private void FireBullet(PlayerController player)
	{
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		if (canFire)
		{
			canFire = false;
			GameObject val = SpawnManager.SpawnProjectile(((Component)MitreProjectile).gameObject, Vector2.op_Implicit(((BraveBehaviour)((PassiveItem)this).Owner).sprite.WorldCenter), Quaternion.Euler(0f, 0f, ((Object)(object)((GameActor)((PassiveItem)this).Owner).CurrentGun == (Object)null) ? 0f : ((GameActor)((PassiveItem)this).Owner).CurrentGun.CurrentAngle), true);
			Projectile component = val.GetComponent<Projectile>();
			if ((Object)(object)component != (Object)null)
			{
				component.Owner = (GameActor)(object)player;
				component.Shooter = ((BraveBehaviour)player).specRigidbody;
				ProjectileData baseData = component.baseData;
				baseData.damage *= player.stats.GetStatValue((StatType)5);
				ProjectileData baseData2 = component.baseData;
				baseData2.speed *= player.stats.GetStatValue((StatType)6);
				ProjectileData baseData3 = component.baseData;
				baseData3.force *= player.stats.GetStatValue((StatType)12);
				component.UpdateSpeed();
				player.DoPostProcessProjectile(component);
			}
			((MonoBehaviour)this).Invoke("HandleCooldown", 0.7f);
		}
	}

	private void OnRollStarted(PlayerController player, Vector2 direction)
	{
		if (CustomSynergies.PlayerHasActiveSynergy(player, "Holy Socks"))
		{
			FireBullet(player);
		}
	}

	private void HandleCooldown()
	{
		canFire = true;
	}

	public override void Pickup(PlayerController player)
	{
		((PassiveItem)this).Pickup(player);
		player.OnReloadedGun = (Action<PlayerController, Gun>)Delegate.Combine(player.OnReloadedGun, new Action<PlayerController, Gun>(HandleGunReloaded));
		player.OnRollStarted += OnRollStarted;
	}

	public override DebrisObject Drop(PlayerController player)
	{
		DebrisObject result = ((PassiveItem)this).Drop(player);
		player.OnReloadedGun = (Action<PlayerController, Gun>)Delegate.Remove(player.OnReloadedGun, new Action<PlayerController, Gun>(HandleGunReloaded));
		player.OnRollStarted -= OnRollStarted;
		return result;
	}

	public override void OnDestroy()
	{
		if (Object.op_Implicit((Object)(object)((PassiveItem)this).Owner))
		{
			PlayerController owner = ((PassiveItem)this).Owner;
			owner.OnReloadedGun = (Action<PlayerController, Gun>)Delegate.Remove(owner.OnReloadedGun, new Action<PlayerController, Gun>(HandleGunReloaded));
			((PassiveItem)this).Owner.OnRollStarted -= OnRollStarted;
		}
		((PassiveItem)this).OnDestroy();
	}
}
