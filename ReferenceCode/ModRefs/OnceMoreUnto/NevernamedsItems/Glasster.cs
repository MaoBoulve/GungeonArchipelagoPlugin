using Alexandria.Assetbundle;
using Alexandria.ItemAPI;
using Alexandria.Misc;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class Glasster : AdvancedGunBehavior
{
	public static int GlassterID;

	public static void Add()
	{
		//IL_00b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0112: Unknown result type (might be due to invalid IL or missing references)
		//IL_0136: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fc: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Glasster", "glasster");
		Game.Items.Rename("outdated_gun_mods:glasster", "nn:glasster");
		((Component)val).gameObject.AddComponent<Glasster>();
		GunExt.SetShortDescription((PickupObject)(object)val, "Glass Blower");
		GunExt.SetLongDescription((PickupObject)(object)val, "Increases in damage the more Glass Guon Stones are held.\n\nGifted unto a spacefaring rogue by the Lady of Pane, it's original bearer died from infection after cutting himself on a shard of glass.");
		GunInt.SetupSprite(val, Initialisation.gunCollection, "glasster_idle_001", 8, "glasster_ammonomicon_001");
		GunExt.SetAnimationFPS(val, val.shootAnimation, 14);
		ref string gunSwitchGroup = ref val.gunSwitchGroup;
		PickupObject byId = PickupObjectDatabase.GetById(32);
		gunSwitchGroup = ((Gun)((byId is Gun) ? byId : null)).gunSwitchGroup;
		PickupObject byId2 = PickupObjectDatabase.GetById(86);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId2 is Gun) ? byId2 : null), true, false);
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.shootStyle = (ShootStyle)0;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 1f;
		val.muzzleFlashEffects.type = (VFXPoolType)0;
		val.DefaultModule.cooldownTime = 0.15f;
		val.DefaultModule.numberOfShotsInClip = 6;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(1.68f, 0.56f, 0f);
		val.SetBaseMaxAmmo(200);
		val.ammo = 200;
		val.gunClass = (GunClass)1;
		Projectile val2 = Object.Instantiate<Projectile>(val.DefaultModule.projectiles[0]);
		((Component)val2).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val2).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val2);
		ProjectileData baseData = val2.baseData;
		baseData.damage *= 1f;
		val2.SetProjectileSprite("glasster_projectile", 4, 4, lightened: true, (Anchor)4, 4, 4, anchorChangesCollider: true, fixesScale: false, null, null);
		val.DefaultModule.projectiles[0] = val2;
		val.DefaultModule.ammoType = (AmmoType)14;
		val.DefaultModule.customAmmoType = CustomClipAmmoTypeToolbox.AddCustomAmmoType("Glasster Bullets", "NevernamedsItems/Resources/CustomGunAmmoTypes/glasster_clipfull", "NevernamedsItems/Resources/CustomGunAmmoTypes/glasster_clipempty");
		((PickupObject)val).quality = (ItemQuality)2;
		Databases.Items.Add(val, (tk2dSpriteCollectionData)null, "ANY");
		GlassterID = ((PickupObject)val).PickupObjectId;
	}

	public override void OnPostFired(PlayerController player, Gun gun)
	{
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Expected O, but got Unknown
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		//IL_009b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
		if (CustomSynergies.PlayerHasActiveSynergy(player, "Masterglass"))
		{
			foreach (IPlayerOrbital orbital in player.orbitals)
			{
				PlayerOrbital val = (PlayerOrbital)orbital;
				if (((Object)val).name == "IounStone_Glass(Clone)")
				{
					Vector2 startPos = Vector2.op_Implicit(orbital.GetTransform().position);
					Vector2 targetPos = Vector3Extensions.XY(player.unadjustedAimPoint);
					if (CustomSynergies.PlayerHasActiveSynergy(player, "Shattershot"))
					{
						FireBullet(player, startPos, targetPos, 0f, 10f);
						FireBullet(player, startPos, targetPos, 14f, 10f);
						FireBullet(player, startPos, targetPos, -14f, 10f);
					}
					else
					{
						FireBullet(player, startPos, targetPos, 0f, 5f);
					}
				}
			}
		}
		((AdvancedGunBehavior)this).OnPostFired(player, gun);
	}

	private void FireBullet(PlayerController Owner, Vector2 startPos, Vector2 targetPos, float angleOffset, float anglevariance)
	{
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		GameObject val = ProjSpawnHelper.SpawnProjectileTowardsPoint(((Component)GlassShard.GlassShardProjectile).gameObject, startPos, targetPos, angleOffset, anglevariance);
		Projectile component = val.GetComponent<Projectile>();
		if ((Object)(object)component != (Object)null)
		{
			component.Owner = (GameActor)(object)Owner;
			component.Shooter = ((BraveBehaviour)Owner).specRigidbody;
			component.TreatedAsNonProjectileForChallenge = true;
			ProjectileData baseData = component.baseData;
			baseData.damage *= Owner.stats.GetStatValue((StatType)5);
			ProjectileData baseData2 = component.baseData;
			baseData2.speed *= Owner.stats.GetStatValue((StatType)6);
			ProjectileData baseData3 = component.baseData;
			baseData3.force *= Owner.stats.GetStatValue((StatType)12);
			component.AdditionalScaleMultiplier *= Owner.stats.GetStatValue((StatType)15);
			component.UpdateSpeed();
			Owner.DoPostProcessProjectile(component);
		}
	}

	public override void PostProcessProjectile(Projectile projectile)
	{
		if (Object.op_Implicit((Object)(object)ProjectileUtility.ProjectilePlayerOwner(projectile)))
		{
			float num = 1f;
			foreach (PassiveItem passiveItem in ProjectileUtility.ProjectilePlayerOwner(projectile).passiveItems)
			{
				if (((PickupObject)passiveItem).PickupObjectId == 565)
				{
					num += 0.35f;
				}
			}
			ProjectileData baseData = projectile.baseData;
			baseData.damage *= num;
			if (CustomSynergies.PlayerHasActiveSynergy(ProjectileUtility.ProjectilePlayerOwner(projectile), "No Pane, No Gain"))
			{
				ProjectileData baseData2 = projectile.baseData;
				baseData2.damage *= 2f;
			}
		}
		((AdvancedGunBehavior)this).PostProcessProjectile(projectile);
	}

	private void OnHit(PlayerController player)
	{
		if ((Object)(object)player == (Object)(object)base.gun.CurrentOwner && ((PickupObject)((GameActor)player).CurrentGun).PickupObjectId == GlassterID && CustomSynergies.PlayerHasActiveSynergy(player, "No Pane, No Gain"))
		{
			base.gun.CurrentAmmo = 0;
		}
	}

	protected override void OnPickedUpByPlayer(PlayerController player)
	{
		if (!base.everPickedUpByPlayer)
		{
			_003F val = player;
			PickupObject byId = PickupObjectDatabase.GetById(565);
			((PlayerController)val).AcquirePassiveItemPrefabDirectly((PassiveItem)(object)((byId is PassiveItem) ? byId : null));
		}
		player.OnReceivedDamage += OnHit;
		((AdvancedGunBehavior)this).OnPickedUpByPlayer(player);
	}

	protected override void OnPostDroppedByPlayer(PlayerController player)
	{
		player.OnReceivedDamage -= OnHit;
		((AdvancedGunBehavior)this).OnPostDroppedByPlayer(player);
	}

	public override void OnDestroy()
	{
		if ((Object)(object)base.gun.CurrentOwner != (Object)null && base.gun.CurrentOwner is PlayerController)
		{
			GameActor currentOwner = base.gun.CurrentOwner;
			((PlayerController)((currentOwner is PlayerController) ? currentOwner : null)).OnReceivedDamage -= OnHit;
		}
		((BraveBehaviour)this).OnDestroy();
	}
}
