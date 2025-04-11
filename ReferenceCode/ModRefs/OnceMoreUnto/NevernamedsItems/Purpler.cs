using Alexandria.ItemAPI;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class Purpler : AdvancedGunBehavior
{
	public static int PurplerID;

	private bool GaveFlight;

	private bool hasBirdieNow;

	private bool hadBirdieLastWeChecked;

	public static void Add()
	{
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0114: Unknown result type (might be due to invalid IL or missing references)
		//IL_012e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0213: Unknown result type (might be due to invalid IL or missing references)
		//IL_022a: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Purpler", "purpler");
		Game.Items.Rename("outdated_gun_mods:purpler", "nn:purpler");
		((Component)val).gameObject.AddComponent<Purpler>();
		GunExt.SetShortDescription((PickupObject)(object)val, "Burning Bills");
		GunExt.SetLongDescription((PickupObject)(object)val, "Fires purple in it's rawest form.\n\nThis inconveniently small blaster was made for much more diminutive beings with no fingers.");
		val.SetGunSprites("purpler");
		GunExt.SetAnimationFPS(val, val.shootAnimation, 15);
		PickupObject byId = PickupObjectDatabase.GetById(89);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId is Gun) ? byId : null), true, false);
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.shootStyle = (ShootStyle)4;
		val.DefaultModule.burstShotCount = 3;
		val.DefaultModule.burstCooldownTime = 0.2f;
		val.DefaultModule.angleVariance = 5f;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 1f;
		val.DefaultModule.cooldownTime = 0.7f;
		val.DefaultModule.numberOfShotsInClip = 12;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(1.06f, 0.5f, 0f);
		val.SetBaseMaxAmmo(300);
		val.gunClass = (GunClass)55;
		Projectile val2 = Object.Instantiate<Projectile>(val.DefaultModule.projectiles[0]);
		((Component)val2).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val2).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val2);
		val.DefaultModule.projectiles[0] = val2;
		ProjectileData baseData = val2.baseData;
		baseData.damage *= 1.6f;
		ProjectileData baseData2 = val2.baseData;
		baseData2.range *= 0.7f;
		((BraveBehaviour)val2).transform.parent = val.barrelOffset;
		val2.SetProjectileSprite("purpler_projectile", 8, 6, lightened: true, (Anchor)4, 6, 6, anchorChangesCollider: true, fixesScale: false, null, null);
		val2.hitEffects.alwaysUseMidair = true;
		val2.hitEffects.overrideMidairDeathVFX = SharedVFX.RedLaserCircleVFX;
		val.DefaultModule.ammoType = (AmmoType)14;
		val.DefaultModule.customAmmoType = "Thinline Bullets";
		((PickupObject)val).quality = (ItemQuality)2;
		((BraveBehaviour)val).encounterTrackable.EncounterGuid = "this is the Purpler";
		Databases.Items.Add(val, (tk2dSpriteCollectionData)null, "ANY");
		PurplerID = ((PickupObject)val).PickupObjectId;
	}

	private void changedGun(Gun oldGun, Gun newGun, bool what)
	{
		flightCheck(newGun);
	}

	private void flightCheck(Gun currentGun)
	{
		GameActor currentOwner = currentGun.CurrentOwner;
		PlayerController val = (PlayerController)(object)((currentOwner is PlayerController) ? currentOwner : null);
		if ((Object)(object)currentGun == (Object)(object)base.gun && !GaveFlight && CustomSynergies.PlayerHasActiveSynergy(val, "Birdie!"))
		{
			((GameActor)((AdvancedGunBehavior)this).Player).SetIsFlying(true, "PurpBirdie", false, false);
			((AdvancedGunBehavior)this).Player.AdditionalCanDodgeRollWhileFlying.AddOverride("PurpBirdie", (float?)null);
			GaveFlight = true;
		}
		else if (((Object)(object)currentGun != (Object)(object)base.gun || !CustomSynergies.PlayerHasActiveSynergy(val, "Birdie!")) && GaveFlight)
		{
			((GameActor)((AdvancedGunBehavior)this).Player).SetIsFlying(false, "PurpBirdie", false, false);
			((AdvancedGunBehavior)this).Player.AdditionalCanDodgeRollWhileFlying.RemoveOverride("PurpBirdie");
			GaveFlight = false;
		}
	}

	public override void PostProcessProjectile(Projectile projectile)
	{
		((AdvancedGunBehavior)this).PostProcessProjectile(projectile);
		GameActor owner = projectile.Owner;
		PlayerController val = (PlayerController)(object)((owner is PlayerController) ? owner : null);
		if (Object.op_Implicit((Object)(object)val) && CustomSynergies.PlayerHasActiveSynergy(val, "Purplest"))
		{
			ProjectileData baseData = projectile.baseData;
			baseData.range *= 3f;
			ProjectileData baseData2 = projectile.baseData;
			baseData2.damage *= 2f;
		}
	}

	protected override void Update()
	{
		((AdvancedGunBehavior)this).Update();
		GameActor currentOwner = base.gun.CurrentOwner;
		PlayerController val = (PlayerController)(object)((currentOwner is PlayerController) ? currentOwner : null);
		hasBirdieNow = CustomSynergies.PlayerHasActiveSynergy(val, "Birdie!");
		if (hasBirdieNow != hadBirdieLastWeChecked)
		{
			flightCheck(((GameActor)val).CurrentGun);
			hadBirdieLastWeChecked = hasBirdieNow;
		}
	}

	public override void OnReload(PlayerController player, Gun gun)
	{
		((AdvancedGunBehavior)this).OnReload(player, gun);
		flightCheck(gun);
	}

	protected override void OnPickedUpByPlayer(PlayerController player)
	{
		((AdvancedGunBehavior)this).OnPickedUpByPlayer(player);
		player.GunChanged += changedGun;
		flightCheck(((GameActor)player).CurrentGun);
	}

	protected override void OnPostDroppedByPlayer(PlayerController player)
	{
		player.GunChanged -= changedGun;
		flightCheck(((GameActor)player).CurrentGun);
		player.stats.RecalculateStats(player, true, false);
		((AdvancedGunBehavior)this).OnPostDroppedByPlayer(player);
	}
}
