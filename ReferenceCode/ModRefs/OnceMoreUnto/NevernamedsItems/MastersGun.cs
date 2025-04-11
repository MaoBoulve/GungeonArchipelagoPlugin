using System;
using Alexandria.ItemAPI;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class MastersGun : AdvancedGunBehavior
{
	public static Projectile keepProjectile;

	public static Projectile properProjectile;

	public static Projectile minesProjectile;

	public static Projectile hollowProjectile;

	public static Projectile forgeProjectile;

	public static void Add()
	{
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0114: Unknown result type (might be due to invalid IL or missing references)
		//IL_0858: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Master's Gun", "mastersgun");
		Game.Items.Rename("outdated_gun_mods:master's_gun", "nn:masters_gun");
		((Component)val).gameObject.AddComponent<MastersGun>();
		GunExt.SetShortDescription((PickupObject)(object)val, "Firing On All Cylinders");
		GunExt.SetLongDescription((PickupObject)(object)val, "A humongous firearm, created by the Gungeon's Master to fire the legendary master rounds, though he never truly finished it.\n\nAfter it's recent rediscovery, the Blacksmith managed to finish the spectacular weapon, and even forged Master-Sized bullet replicas for ammo.\n\nNothing can beat the gun's original purpose though, so getting your grubby hands on some master rounds would be good.");
		val.SetGunSprites("mastersgun");
		GunExt.SetAnimationFPS(val, val.shootAnimation, 11);
		PickupObject byId = PickupObjectDatabase.GetById(56);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId is Gun) ? byId : null), true, false);
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.shootStyle = (ShootStyle)0;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 1f;
		ref VFXPool muzzleFlashEffects = ref val.muzzleFlashEffects;
		PickupObject byId2 = PickupObjectDatabase.GetById(37);
		muzzleFlashEffects = ((Gun)((byId2 is Gun) ? byId2 : null)).muzzleFlashEffects;
		val.DefaultModule.cooldownTime = 0.4f;
		val.DefaultModule.numberOfShotsInClip = 6;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(3.62f, 1.81f, 0f);
		val.SetBaseMaxAmmo(50);
		val.gunClass = (GunClass)1;
		Projectile val2 = Object.Instantiate<Projectile>(val.DefaultModule.projectiles[0]);
		((Component)val2).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val2).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val2);
		val.DefaultModule.projectiles[0] = val2;
		ProjectileData baseData = val2.baseData;
		baseData.damage *= 10f;
		val2.ignoreDamageCaps = true;
		ProjectileData baseData2 = val2.baseData;
		baseData2.speed *= 1f;
		val2.pierceMinorBreakables = true;
		PierceProjModifier orAddComponent = GameObjectExtensions.GetOrAddComponent<PierceProjModifier>(((Component)val2).gameObject);
		orAddComponent.penetratesBreakables = true;
		orAddComponent.penetration++;
		GunTools.SetProjectileSpriteRight(val2, "mastersgun_projectile", 27, 12, false, (Anchor)4, (int?)27, (int?)12, true, false, (int?)null, (int?)null, (Projectile)null);
		((BraveBehaviour)val2).transform.parent = val.barrelOffset;
		PickupObject byId3 = PickupObjectDatabase.GetById(56);
		keepProjectile = Object.Instantiate<Projectile>(((Gun)((byId3 is Gun) ? byId3 : null)).DefaultModule.projectiles[0]);
		((Component)keepProjectile).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)keepProjectile).gameObject);
		Object.DontDestroyOnLoad((Object)(object)keepProjectile);
		ProjectileData baseData3 = keepProjectile.baseData;
		baseData3.damage *= 16f;
		keepProjectile.ignoreDamageCaps = true;
		ProjectileData baseData4 = keepProjectile.baseData;
		baseData4.speed *= 1f;
		keepProjectile.pierceMinorBreakables = true;
		PierceProjModifier orAddComponent2 = GameObjectExtensions.GetOrAddComponent<PierceProjModifier>(((Component)keepProjectile).gameObject);
		orAddComponent2.penetratesBreakables = true;
		orAddComponent2.penetration++;
		BounceProjModifier orAddComponent3 = GameObjectExtensions.GetOrAddComponent<BounceProjModifier>(((Component)keepProjectile).gameObject);
		orAddComponent3.numberOfBounces = 5;
		GunTools.SetProjectileSpriteRight(keepProjectile, "mastersgun_keep_projectile", 27, 12, false, (Anchor)4, (int?)27, (int?)12, true, false, (int?)null, (int?)null, (Projectile)null);
		((BraveBehaviour)keepProjectile).transform.parent = val.barrelOffset;
		ref string gunSwitchGroup = ref val.gunSwitchGroup;
		PickupObject byId4 = PickupObjectDatabase.GetById(37);
		gunSwitchGroup = ((Gun)((byId4 is Gun) ? byId4 : null)).gunSwitchGroup;
		PickupObject byId5 = PickupObjectDatabase.GetById(56);
		properProjectile = Object.Instantiate<Projectile>(((Gun)((byId5 is Gun) ? byId5 : null)).DefaultModule.projectiles[0]);
		((Component)properProjectile).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)properProjectile).gameObject);
		Object.DontDestroyOnLoad((Object)(object)properProjectile);
		ProjectileData baseData5 = properProjectile.baseData;
		baseData5.damage *= 16f;
		properProjectile.ignoreDamageCaps = true;
		ProjectileData baseData6 = properProjectile.baseData;
		baseData6.speed *= 1f;
		properProjectile.pierceMinorBreakables = true;
		PierceProjModifier orAddComponent4 = GameObjectExtensions.GetOrAddComponent<PierceProjModifier>(((Component)properProjectile).gameObject);
		orAddComponent4.penetratesBreakables = true;
		orAddComponent4.penetration++;
		ApplyLockdownBulletBehaviour orAddComponent5 = GameObjectExtensions.GetOrAddComponent<ApplyLockdownBulletBehaviour>(((Component)properProjectile).gameObject);
		orAddComponent5.duration = 6f;
		GunTools.SetProjectileSpriteRight(properProjectile, "mastersgun_proper_projectile", 27, 12, false, (Anchor)4, (int?)27, (int?)12, true, false, (int?)null, (int?)null, (Projectile)null);
		((BraveBehaviour)properProjectile).transform.parent = val.barrelOffset;
		PickupObject byId6 = PickupObjectDatabase.GetById(56);
		minesProjectile = Object.Instantiate<Projectile>(((Gun)((byId6 is Gun) ? byId6 : null)).DefaultModule.projectiles[0]);
		((Component)minesProjectile).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)minesProjectile).gameObject);
		Object.DontDestroyOnLoad((Object)(object)minesProjectile);
		ProjectileData baseData7 = minesProjectile.baseData;
		baseData7.damage *= 16f;
		minesProjectile.ignoreDamageCaps = true;
		ProjectileData baseData8 = minesProjectile.baseData;
		baseData8.speed *= 1f;
		minesProjectile.pierceMinorBreakables = true;
		PierceProjModifier orAddComponent6 = GameObjectExtensions.GetOrAddComponent<PierceProjModifier>(((Component)minesProjectile).gameObject);
		orAddComponent6.penetratesBreakables = true;
		orAddComponent6.penetration++;
		ExtremelySimplePoisonBulletBehaviour orAddComponent7 = GameObjectExtensions.GetOrAddComponent<ExtremelySimplePoisonBulletBehaviour>(((Component)minesProjectile).gameObject);
		orAddComponent7.procChance = 1;
		orAddComponent7.useSpecialTint = false;
		GunTools.SetProjectileSpriteRight(minesProjectile, "mastersgun_mines_projectile", 27, 12, false, (Anchor)4, (int?)27, (int?)12, true, false, (int?)null, (int?)null, (Projectile)null);
		((BraveBehaviour)minesProjectile).transform.parent = val.barrelOffset;
		PickupObject byId7 = PickupObjectDatabase.GetById(56);
		hollowProjectile = Object.Instantiate<Projectile>(((Gun)((byId7 is Gun) ? byId7 : null)).DefaultModule.projectiles[0]);
		((Component)hollowProjectile).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)hollowProjectile).gameObject);
		Object.DontDestroyOnLoad((Object)(object)hollowProjectile);
		ProjectileData baseData9 = hollowProjectile.baseData;
		baseData9.damage *= 16f;
		hollowProjectile.ignoreDamageCaps = true;
		ProjectileData baseData10 = hollowProjectile.baseData;
		baseData10.speed *= 1f;
		hollowProjectile.pierceMinorBreakables = true;
		PierceProjModifier orAddComponent8 = GameObjectExtensions.GetOrAddComponent<PierceProjModifier>(((Component)hollowProjectile).gameObject);
		orAddComponent8.penetratesBreakables = true;
		orAddComponent8.penetration++;
		SimpleFreezingBulletBehaviour orAddComponent9 = GameObjectExtensions.GetOrAddComponent<SimpleFreezingBulletBehaviour>(((Component)hollowProjectile).gameObject);
		orAddComponent9.procChance = 1;
		orAddComponent9.useSpecialTint = false;
		orAddComponent9.freezeAmount = 150;
		orAddComponent9.freezeAmountForBosses = 100;
		GunTools.SetProjectileSpriteRight(hollowProjectile, "mastersgun_hollow_projectile", 27, 12, false, (Anchor)4, (int?)27, (int?)12, true, false, (int?)null, (int?)null, (Projectile)null);
		((BraveBehaviour)hollowProjectile).transform.parent = val.barrelOffset;
		PickupObject byId8 = PickupObjectDatabase.GetById(56);
		forgeProjectile = Object.Instantiate<Projectile>(((Gun)((byId8 is Gun) ? byId8 : null)).DefaultModule.projectiles[0]);
		((Component)forgeProjectile).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)forgeProjectile).gameObject);
		Object.DontDestroyOnLoad((Object)(object)forgeProjectile);
		ProjectileData baseData11 = forgeProjectile.baseData;
		baseData11.damage *= 20f;
		forgeProjectile.ignoreDamageCaps = true;
		ProjectileData baseData12 = forgeProjectile.baseData;
		baseData12.speed *= 1f;
		forgeProjectile.pierceMinorBreakables = true;
		PierceProjModifier orAddComponent10 = GameObjectExtensions.GetOrAddComponent<PierceProjModifier>(((Component)forgeProjectile).gameObject);
		orAddComponent10.penetratesBreakables = true;
		orAddComponent10.penetration++;
		ExtremelySimpleStatusEffectBulletBehaviour orAddComponent11 = GameObjectExtensions.GetOrAddComponent<ExtremelySimpleStatusEffectBulletBehaviour>(((Component)forgeProjectile).gameObject);
		orAddComponent11.onFiredProcChance = 1f;
		orAddComponent11.usesFireEffect = true;
		orAddComponent11.fireEffect = StaticStatusEffects.hotLeadEffect;
		orAddComponent11.useSpecialTint = false;
		GunTools.SetProjectileSpriteRight(forgeProjectile, "mastersgun_forge_projectile", 33, 18, false, (Anchor)3, (int?)27, (int?)12, true, false, (int?)null, (int?)null, (Projectile)null);
		((BraveBehaviour)forgeProjectile).transform.parent = val.barrelOffset;
		((PickupObject)val).quality = (ItemQuality)5;
		((BraveBehaviour)val).encounterTrackable.EncounterGuid = "this is the Master's Gun";
		Databases.Items.Add(val, (tk2dSpriteCollectionData)null, "ANY");
	}

	public override Projectile OnPreFireProjectileModifier(Gun gun, Projectile projectile, ProjectileModule mod)
	{
		try
		{
			GameActor currentOwner = base.gun.CurrentOwner;
			PlayerController val = (PlayerController)(object)((currentOwner is PlayerController) ? currentOwner : null);
			if (Object.op_Implicit((Object)(object)val))
			{
				switch (Random.Range(1, 6))
				{
				case 1:
					if (val.HasPickupID(469))
					{
						return keepProjectile;
					}
					break;
				case 2:
					if (val.HasPickupID(471))
					{
						return properProjectile;
					}
					break;
				case 3:
					if (val.HasPickupID(468))
					{
						return minesProjectile;
					}
					break;
				case 4:
					if (val.HasPickupID(470))
					{
						return hollowProjectile;
					}
					break;
				case 5:
					if (val.HasPickupID(467))
					{
						return forgeProjectile;
					}
					break;
				}
			}
			return projectile;
		}
		catch (Exception ex)
		{
			ETGModConsole.Log((object)ex.Message, false);
			ETGModConsole.Log((object)ex.StackTrace, false);
			return projectile;
		}
	}

	public override void OnPostFired(PlayerController player, Gun gun)
	{
		gun.PreventNormalFireAudio = true;
		AkSoundEngine.PostEvent("Play_WPN_seriouscannon_shot_01", ((Component)this).gameObject);
	}
}
