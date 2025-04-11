using Alexandria.Assetbundle;
using Alexandria.ItemAPI;
using Alexandria.Misc;
using Gungeon;
using SaveAPI;
using UnityEngine;

namespace NevernamedsItems;

public class Creditor : AdvancedGunBehavior
{
	public static int CreditorID;

	public static void Add()
	{
		//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0125: Unknown result type (might be due to invalid IL or missing references)
		//IL_013a: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_022f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0273: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Creditor", "creditor");
		Game.Items.Rename("outdated_gun_mods:creditor", "nn:creditor");
		((Component)val).gameObject.AddComponent<Creditor>();
		GunExt.SetShortDescription((PickupObject)(object)val, "Credit To The Team");
		GunExt.SetLongDescription((PickupObject)(object)val, "Converts the sheer economic potential of the Hegemony Credit into a powerful blast.\n\nDraws from the bearer's stored funds.");
		val.SetGunSprites("creditor");
		GunExt.SetAnimationFPS(val, val.shootAnimation, 10);
		ref string gunSwitchGroup = ref val.gunSwitchGroup;
		PickupObject byId = PickupObjectDatabase.GetById(86);
		gunSwitchGroup = ((Gun)((byId is Gun) ? byId : null)).gunSwitchGroup;
		PickupObject byId2 = PickupObjectDatabase.GetById(56);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId2 is Gun) ? byId2 : null), true, false);
		val.DefaultModule.ammoCost = 0;
		val.DefaultModule.shootStyle = (ShootStyle)0;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 5f;
		val.DefaultModule.cooldownTime = 0.1f;
		val.DefaultModule.angleVariance = 3f;
		val.DefaultModule.numberOfShotsInClip = 5;
		ref VFXPool muzzleFlashEffects = ref val.muzzleFlashEffects;
		PickupObject byId3 = PickupObjectDatabase.GetById(89);
		muzzleFlashEffects = ((Gun)((byId3 is Gun) ? byId3 : null)).muzzleFlashEffects;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(1.37f, 0.81f, 0f);
		val.SetBaseMaxAmmo(0);
		val.gunClass = (GunClass)1;
		Projectile val2 = Object.Instantiate<Projectile>(val.DefaultModule.projectiles[0]);
		((Component)val2).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val2).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val2);
		val2.baseData.damage = 35f;
		ProjectileData baseData = val2.baseData;
		baseData.force *= 2f;
		ProjectileData baseData2 = val2.baseData;
		baseData2.speed *= 1f;
		val2.pierceMinorBreakables = true;
		val2.hitEffects.alwaysUseMidair = true;
		val2.hitEffects.overrideMidairDeathVFX = SharedVFX.GreenLaserCircleVFX;
		ProjectileBuilders.AnimateProjectileBundle(val2, "CreditorProjectile", Initialisation.ProjectileCollection, Initialisation.projectileAnimationCollection, "CreditorProjectile", AnimateBullet.ConstructListOfSameValues<IntVector2>(new IntVector2(15, 11), 10), AnimateBullet.ConstructListOfSameValues(value: true, 10), AnimateBullet.ConstructListOfSameValues<Anchor>((Anchor)4, 10), AnimateBullet.ConstructListOfSameValues(value: true, 10), AnimateBullet.ConstructListOfSameValues(value: false, 10), AnimateBullet.ConstructListOfSameValues<Vector3?>(null, 10), AnimateBullet.ConstructListOfSameValues((IntVector2?)new IntVector2(13, 7), 10), AnimateBullet.ConstructListOfSameValues<IntVector2?>(null, 10), AnimateBullet.ConstructListOfSameValues<Projectile>(null, 10));
		val.DefaultModule.projectiles[0] = val2;
		((PickupObject)val).quality = (ItemQuality)4;
		Databases.Items.Add((PickupObject)(object)val, false, "ANY");
		((PickupObject)(object)val).SetupUnlockOnCustomFlag(CustomDungeonFlags.PURCHASED_CREDITOR, requiredFlagValue: true);
		AlexandriaTags.SetTag((PickupObject)(object)val, "override_cangainammo_check");
		CreditorID = ((PickupObject)val).PickupObjectId;
	}

	public override bool CollectedAmmoPickup(PlayerController player, Gun self, AmmoPickup pickup)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		LootEngine.SpawnCurrency(((BraveBehaviour)player).sprite.WorldCenter, 10, true);
		AmmoPickupFixer.ForcePickupWithoutGainingAmmo(pickup, player, false);
		return false;
	}

	public override void PostProcessProjectile(Projectile projectile)
	{
		if ((double)Random.value <= 0.25)
		{
			projectile.ignoreDamageCaps = true;
		}
		((AdvancedGunBehavior)this).PostProcessProjectile(projectile);
	}

	public override void OnPostFired(PlayerController player, Gun gun)
	{
		if (Object.op_Implicit((Object)(object)GunTools.GunPlayerOwner(gun)) && !gun.InfiniteAmmo)
		{
			int num = -1;
			if (player.HasPickupID(TitaniumClip.TitaniumClipID))
			{
				num = -2;
			}
			GameStatsManager.Instance.RegisterStatChange((TrackedStats)25, (float)num);
		}
		((AdvancedGunBehavior)this).OnPostFired(player, gun);
	}

	protected override void Update()
	{
		if (Object.op_Implicit((Object)(object)GunTools.GunPlayerOwner(base.gun)) && (float)base.gun.CurrentAmmo != GameStatsManager.Instance.GetPlayerStatValue((TrackedStats)25))
		{
			RecalculateClip(GunTools.GunPlayerOwner(base.gun));
		}
		((AdvancedGunBehavior)this).Update();
	}

	private void RecalculateClip(PlayerController gunowner)
	{
		int num = (int)GameStatsManager.Instance.GetPlayerStatValue((TrackedStats)25);
		base.gun.CurrentAmmo = num;
		base.gun.DefaultModule.numberOfShotsInClip = num;
		base.gun.ClipShotsRemaining = num;
		gunowner.stats.RecalculateStats(gunowner, false, false);
	}

	private void OnKilledEnemy(PlayerController player, HealthHaver enemy)
	{
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		if (CustomSynergies.PlayerHasActiveSynergy(player, "Fully Funded") && ((PickupObject)((GameActor)player).CurrentGun).PickupObjectId == CreditorID && (double)Random.value <= 0.25 && enemy.GetMaxHealth() >= 15f)
		{
			LootEngine.SpawnCurrency(((BraveBehaviour)enemy).specRigidbody.UnitCenter, 1, true);
		}
	}

	protected override void OnPostDroppedByPlayer(PlayerController player)
	{
		player.OnKilledEnemyContext -= OnKilledEnemy;
		((AdvancedGunBehavior)this).OnPostDroppedByPlayer(player);
	}

	public override void OnDestroy()
	{
		if (Object.op_Implicit((Object)(object)base.gun) && Object.op_Implicit((Object)(object)base.gun.CurrentOwner) && Object.op_Implicit((Object)(object)GunTools.GunPlayerOwner(base.gun)))
		{
			GunTools.GunPlayerOwner(base.gun).OnKilledEnemyContext -= OnKilledEnemy;
		}
		((BraveBehaviour)this).OnDestroy();
	}

	protected override void OnPickedUpByPlayer(PlayerController player)
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		player.OnKilledEnemyContext += OnKilledEnemy;
		if (!base.everPickedUpByPlayer)
		{
			LootEngine.SpawnCurrency(((BraveBehaviour)player).sprite.WorldCenter, 10, true);
		}
		((AdvancedGunBehavior)this).OnPickedUpByPlayer(player);
	}
}
