using System.Collections.Generic;
using Alexandria.Assetbundle;
using Alexandria.ItemAPI;
using Alexandria.Misc;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class BigShot : AdvancedGunBehavior
{
	public static Projectile pipis;

	public static int BigShotID;

	public bool hasRequestedHeal;

	public static void Add()
	{
		//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00df: Unknown result type (might be due to invalid IL or missing references)
		//IL_00eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0131: Unknown result type (might be due to invalid IL or missing references)
		//IL_0150: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0307: Unknown result type (might be due to invalid IL or missing references)
		//IL_0393: Unknown result type (might be due to invalid IL or missing references)
		//IL_03bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_048e: Unknown result type (might be due to invalid IL or missing references)
		//IL_049e: Unknown result type (might be due to invalid IL or missing references)
		//IL_04d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_05a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_05e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0654: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Big Shot", "bigshot");
		Game.Items.Rename("outdated_gun_mods:big_shot", "nn:big_shot");
		BigShot bigShot = ((Component)val).gameObject.AddComponent<BigShot>();
		((AdvancedGunBehavior)bigShot).preventNormalFireAudio = true;
		((AdvancedGunBehavior)bigShot).preventNormalReloadAudio = true;
		((AdvancedGunBehavior)bigShot).overrideNormalReloadAudio = "Play_NowsYourChanceToBeABigShot";
		GunExt.SetShortDescription((PickupObject)(object)val, "Now's Your Chance!");
		GunExt.SetLongDescription((PickupObject)(object)val, "The sign4ture weap0n of a [ONCE IN A LIFETIME OPPORTUNITY] that came to the Gungeon [ON AN ALL EXPENSES PAID HOLIDAY] seeking $$fr33$$! KROMER.\n\nYou're fill3d with [Hyperlink Blocked.].");
		val.SetGunSprites("bigshot");
		GunExt.SetAnimationFPS(val, val.shootAnimation, 12);
		ref string gunSwitchGroup = ref val.gunSwitchGroup;
		PickupObject byId = PickupObjectDatabase.GetById(519);
		gunSwitchGroup = ((Gun)((byId is Gun) ? byId : null)).gunSwitchGroup;
		PickupObject byId2 = PickupObjectDatabase.GetById(86);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId2 is Gun) ? byId2 : null), true, false);
		((Component)val).GetComponent<tk2dSpriteAnimator>().GetClipByName(val.reloadAnimation).wrapMode = (WrapMode)0;
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.shootStyle = (ShootStyle)1;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 1.6f;
		val.DefaultModule.cooldownTime = 0.45f;
		val.DefaultModule.numberOfShotsInClip = 3;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(1.75f, 0.62f, 0f);
		val.SetBaseMaxAmmo(100);
		val.ammo = 100;
		val.gunClass = (GunClass)50;
		Projectile val2 = Object.Instantiate<Projectile>(val.DefaultModule.projectiles[0]);
		((Component)val2).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val2).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val2);
		val.DefaultModule.projectiles[0] = val2;
		val2.baseData.damage = 29.99f;
		ProjectileData baseData = val2.baseData;
		baseData.speed *= 0.7f;
		ProjectileData baseData2 = val2.baseData;
		baseData2.range *= 2f;
		ProjectileBuilders.AnimateProjectileBundle(val2, "BigShotOrangeProjectile", Initialisation.ProjectileCollection, Initialisation.projectileAnimationCollection, "BigShotOrangeProjectile", MiscTools.DupeList<IntVector2>(new IntVector2(17, 16), 3), MiscTools.DupeList(value: true, 3), MiscTools.DupeList<Anchor>((Anchor)4, 3), MiscTools.DupeList(value: true, 3), MiscTools.DupeList(value: false, 3), MiscTools.DupeList<Vector3?>(null, 3), MiscTools.DupeList<IntVector2?>(null, 3), MiscTools.DupeList<IntVector2?>(null, 3), MiscTools.DupeList<Projectile>(null, 3));
		((Component)val2).gameObject.AddComponent<BigShotProjectileComp>();
		val2.DestroyMode = (ProjectileDestroyMode)2;
		PickupObject byId3 = PickupObjectDatabase.GetById(86);
		Projectile val3 = Object.Instantiate<Projectile>(((Gun)((byId3 is Gun) ? byId3 : null)).DefaultModule.projectiles[0]);
		((Component)val3).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val3).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val3);
		val3.baseData.damage = 29.99f;
		ProjectileData baseData3 = val3.baseData;
		baseData3.speed *= 0.7f;
		ProjectileData baseData4 = val3.baseData;
		baseData4.range *= 2f;
		ProjectileBuilders.AnimateProjectileBundle(val3, "BigShotPinkProjectile", Initialisation.ProjectileCollection, Initialisation.projectileAnimationCollection, "BigShotPinkProjectile", MiscTools.DupeList<IntVector2>(new IntVector2(17, 15), 3), MiscTools.DupeList(value: true, 3), MiscTools.DupeList<Anchor>((Anchor)4, 3), MiscTools.DupeList(value: true, 3), MiscTools.DupeList(value: false, 3), MiscTools.DupeList<Vector3?>(null, 3), MiscTools.DupeList<IntVector2?>(null, 3), MiscTools.DupeList<IntVector2?>(null, 3), MiscTools.DupeList<Projectile>(null, 3));
		val3.DestroyMode = (ProjectileDestroyMode)2;
		((Component)val3).gameObject.AddComponent<BigShotProjectileComp>();
		val.DefaultModule.projectiles.Add(val3);
		((PickupObject)val).quality = (ItemQuality)3;
		Databases.Items.Add((PickupObject)(object)val, false, "ANY");
		BigShotID = ((PickupObject)val).PickupObjectId;
		val.DefaultModule.ammoType = (AmmoType)14;
		val.DefaultModule.customAmmoType = CustomClipAmmoTypeToolbox.AddCustomAmmoType("Round King", "NevernamedsItems/Resources/CustomGunAmmoTypes/bigshot_clipfull", "NevernamedsItems/Resources/CustomGunAmmoTypes/bigshot_clipempty");
		PickupObject byId4 = PickupObjectDatabase.GetById(56);
		Projectile val4 = Object.Instantiate<Projectile>(((Gun)((byId4 is Gun) ? byId4 : null)).DefaultModule.projectiles[0]);
		((Component)val4).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val4).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val4);
		val4.baseData.damage = 7f;
		ProjectileData baseData5 = val4.baseData;
		baseData5.speed *= 1.2f;
		val4.hitEffects.alwaysUseMidair = true;
		val4.hitEffects.overrideMidairDeathVFX = SharedVFX.WhiteCircleVFX;
		ProjectileBuilders.AnimateProjectileBundle(val4, "BigShotSpamtonHeadProjectile", Initialisation.ProjectileCollection, Initialisation.projectileAnimationCollection, "BigShotSpamtonHeadProjectile", new List<IntVector2>
		{
			new IntVector2(10, 13),
			new IntVector2(10, 11)
		}, MiscTools.DupeList(value: true, 2), MiscTools.DupeList<Anchor>((Anchor)4, 2), MiscTools.DupeList(value: true, 2), MiscTools.DupeList(value: false, 2), MiscTools.DupeList<Vector3?>(null, 2), MiscTools.DupeList((IntVector2?)new IntVector2(5, 5), 2), MiscTools.DupeList<IntVector2?>(null, 2), MiscTools.DupeList<Projectile>(null, 2));
		PickupObject byId5 = PickupObjectDatabase.GetById(86);
		Projectile val5 = Object.Instantiate<Projectile>(((Gun)((byId5 is Gun) ? byId5 : null)).DefaultModule.projectiles[0]);
		((Component)val5).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val5).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val5);
		val5.baseData.damage = 29.99f;
		ProjectileData baseData6 = val5.baseData;
		baseData6.speed *= 0.7f;
		ProjectileData baseData7 = val5.baseData;
		baseData7.range *= 0.7f;
		ProjectileBuilders.AnimateProjectileBundle(val5, "BigShotPipisProjectile", Initialisation.ProjectileCollection, Initialisation.projectileAnimationCollection, "BigShotPipisProjectile", MiscTools.DupeList<IntVector2>(new IntVector2(12, 12), 4), MiscTools.DupeList(value: true, 4), MiscTools.DupeList<Anchor>((Anchor)4, 4), MiscTools.DupeList(value: true, 4), MiscTools.DupeList(value: false, 4), MiscTools.DupeList<Vector3?>(null, 4), MiscTools.DupeList((IntVector2?)new IntVector2(9, 9), 4), MiscTools.DupeList<IntVector2?>(null, 4), MiscTools.DupeList<Projectile>(null, 4));
		val5.DestroyMode = (ProjectileDestroyMode)2;
		((Component)val5).gameObject.AddComponent<BigShotProjectileComp>();
		SpawnProjModifier val6 = ((Component)val5).gameObject.AddComponent<SpawnProjModifier>();
		val6.spawnOnObjectCollisions = true;
		val6.spawnProjecitlesOnDieInAir = true;
		val6.spawnProjectilesOnCollision = true;
		val6.spawnProjectilesInFlight = false;
		val6.collisionSpawnStyle = (CollisionSpawnStyle)1;
		val6.alignToSurfaceNormal = true;
		val6.numberToSpawnOnCollison = 5;
		val6.projectileToSpawnOnCollision = val4;
		pipis = val5;
	}

	public override Projectile OnPreFireProjectileModifier(Gun gun, Projectile projectile, ProjectileModule mod)
	{
		if (Object.op_Implicit((Object)(object)gun) && Object.op_Implicit((Object)(object)GunTools.GunPlayerOwner(gun)) && CustomSynergies.PlayerHasActiveSynergy(GunTools.GunPlayerOwner(gun), "pipis"))
		{
			return pipis;
		}
		return ((AdvancedGunBehavior)this).OnPreFireProjectileModifier(gun, projectile, mod);
	}

	public override void OnPostFired(PlayerController player, Gun gun)
	{
		if (gun.ClipShotsRemaining <= 0)
		{
			AkSoundEngine.PostEvent("Play_BeABigShot", ((Component)gun).gameObject);
		}
		else
		{
			AkSoundEngine.PostEvent("Play_BeABig", ((Component)gun).gameObject);
		}
		((AdvancedGunBehavior)this).OnPostFired(player, gun);
	}

	public override void PostProcessProjectile(Projectile projectile)
	{
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		if (Object.op_Implicit((Object)(object)projectile) && Object.op_Implicit((Object)(object)ProjectileUtility.ProjectilePlayerOwner(projectile)))
		{
			if (CustomSynergies.PlayerHasActiveSynergy(ProjectileUtility.ProjectilePlayerOwner(projectile), "Hyperlink Blocked") && Random.value <= 0.35f)
			{
				HungryProjectileModifier val = ((Component)projectile).gameObject.AddComponent<HungryProjectileModifier>();
				val.HungryRadius = 1.5f;
				projectile.AdjustPlayerProjectileTint(ExtendedColours.purple, 1, 0f);
			}
			if (CustomSynergies.PlayerHasActiveSynergy(ProjectileUtility.ProjectilePlayerOwner(projectile), "BIGGEST SHOT"))
			{
				projectile.RuntimeUpdateScale(2f);
				ProjectileData baseData = projectile.baseData;
				baseData.damage *= 1.25f;
			}
		}
		((AdvancedGunBehavior)this).PostProcessProjectile(projectile);
	}

	protected override void Update()
	{
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		if (!hasRequestedHeal && Object.op_Implicit((Object)(object)base.gun) && Object.op_Implicit((Object)(object)GunTools.GunPlayerOwner(base.gun)) && Input.GetKey((KeyCode)282))
		{
			AkSoundEngine.PostEvent("Play_OBJ_heart_heal_01", ((Component)GunTools.GunPlayerOwner(base.gun)).gameObject);
			((GameActor)GunTools.GunPlayerOwner(base.gun)).PlayEffectOnActor(((Component)PickupObjectDatabase.GetById(73)).GetComponent<HealthPickup>().healVFX, Vector3.zero, true, false, false);
			if (GunTools.GunPlayerOwner(base.gun).ForceZeroHealthState)
			{
				HealthHaver healthHaver = ((BraveBehaviour)GunTools.GunPlayerOwner(base.gun)).healthHaver;
				healthHaver.Armor += 1f;
			}
			else
			{
				((BraveBehaviour)GunTools.GunPlayerOwner(base.gun)).healthHaver.ApplyHealing(1f);
			}
			hasRequestedHeal = true;
		}
		((AdvancedGunBehavior)this).Update();
	}
}
