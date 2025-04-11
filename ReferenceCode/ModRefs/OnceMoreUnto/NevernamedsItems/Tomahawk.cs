using Alexandria.Assetbundle;
using Alexandria.ItemAPI;
using Alexandria.Misc;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class Tomahawk : GunBehaviour
{
	public static int ID;

	public static BoomerangProjectile thrown;

	public float timeSincethrow;

	public static void Add()
	{
		//IL_008e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0205: Unknown result type (might be due to invalid IL or missing references)
		//IL_020d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0281: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_02cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_04d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0510: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Tomahawk", "tomahawk");
		Game.Items.Rename("outdated_gun_mods:tomahawk", "nn:tomahawk");
		Tomahawk tomahawk = ((Component)val).gameObject.AddComponent<Tomahawk>();
		GunExt.SetShortDescription((PickupObject)(object)val, "Demahigun");
		GunExt.SetLongDescription((PickupObject)(object)val, "This mastercraft shotgun is impeccably weighted, and can be thrown in a devstating bladed arc to cut through waves of foes.");
		val.SetGunSprites("tomahawk");
		GunExt.SetAnimationFPS(val, val.shootAnimation, 12);
		GunExt.SetAnimationFPS(val, val.reloadAnimation, 12);
		((Component)val).GetComponent<tk2dSpriteAnimator>().GetClipByName(val.reloadAnimation).wrapMode = (WrapMode)1;
		((Component)val).GetComponent<tk2dSpriteAnimator>().GetClipByName(val.reloadAnimation).loopStart = 5;
		ref string gunSwitchGroup = ref val.gunSwitchGroup;
		PickupObject byId = PickupObjectDatabase.GetById(98);
		gunSwitchGroup = ((Gun)((byId is Gun) ? byId : null)).gunSwitchGroup;
		GunExt.SetAnimationFPS(val, val.shootAnimation, 13);
		GunExt.SetAnimationFPS(val, val.idleAnimation, 5);
		ref VFXPool muzzleFlashEffects = ref val.muzzleFlashEffects;
		PickupObject byId2 = PickupObjectDatabase.GetById(23);
		muzzleFlashEffects = ((Gun)((byId2 is Gun) ? byId2 : null)).muzzleFlashEffects;
		for (int i = 0; i < 2; i++)
		{
			PickupObject byId3 = PickupObjectDatabase.GetById(86);
			GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId3 is Gun) ? byId3 : null), true, false);
		}
		Projectile val2 = Object.Instantiate<Projectile>(val.DefaultModule.projectiles[0]);
		((Component)val2).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val2).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val2);
		val2.AdditionalScaleMultiplier = 0.8f;
		val2.baseData.range = 15f;
		val2.baseData.damage = 7f;
		ref GameObject overrideMidairDeathVFX = ref val2.hitEffects.overrideMidairDeathVFX;
		PickupObject byId4 = PickupObjectDatabase.GetById(178);
		overrideMidairDeathVFX = ((Component)((byId4 is Gun) ? byId4 : null)).GetComponent<FireOnReloadSynergyProcessor>().DirectedBurstSettings.ProjectileInterface.SpecifiedProjectile.hitEffects.tileMapHorizontal.effects[0].effects[0].effect;
		val2.hitEffects.alwaysUseMidair = true;
		foreach (ProjectileModule projectile in val.Volley.projectiles)
		{
			projectile.ammoCost = 1;
			projectile.shootStyle = (ShootStyle)0;
			projectile.sequenceStyle = (ProjectileSequenceStyle)0;
			projectile.cooldownTime = 0.2f;
			projectile.angleVariance = 10f;
			projectile.numberOfShotsInClip = 7;
			projectile.projectiles[0] = val2;
			if (projectile != val.DefaultModule)
			{
				projectile.ammoCost = 0;
			}
		}
		val.DefaultModule.ammoType = (AmmoType)11;
		val.reloadTime = 1f;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(2.1875f, 1.8125f, 0f);
		val.SetBaseMaxAmmo(200);
		val.gunClass = (GunClass)5;
		((PickupObject)val).quality = (ItemQuality)3;
		Databases.Items.Add(val, (tk2dSpriteCollectionData)null, "ANY");
		ID = ((PickupObject)val).PickupObjectId;
		thrown = DataCloners.CopyFields<BoomerangProjectile>(ProjectileUtility.InstantiateAndFakeprefab(val.DefaultModule.projectiles[0]));
		thrown.MaximumTraversalDistance = 8f;
		thrown.StunDuration = 0f;
		thrown.trackingSpeed = 720f;
		((Projectile)thrown).baseData.damage = 25f;
		((Projectile)thrown).baseData.speed = 30f;
		((Projectile)thrown).baseData.range = 1E+12f;
		((Component)thrown).gameObject.AddComponent<PierceProjModifier>().penetration = 3;
		((Component)thrown).gameObject.AddComponent<BounceProjModifier>().numberOfBounces = 50;
		PickupObject byId5 = PickupObjectDatabase.GetById(178);
		GameObject effect = ((Component)((byId5 is Gun) ? byId5 : null)).GetComponent<FireOnReloadSynergyProcessor>().DirectedBurstSettings.ProjectileInterface.SpecifiedProjectile.hitEffects.tileMapHorizontal.effects[0].effects[0].effect;
		VFXPool val3 = VFXToolbox.CreateBlankVFXPool(effect);
		((Projectile)thrown).hitEffects.tileMapHorizontal = val3;
		((Projectile)thrown).hitEffects.tileMapVertical = val3;
		((Projectile)thrown).hitEffects.deathTileMapHorizontal = val3;
		((Projectile)thrown).hitEffects.deathTileMapVertical = val3;
		((Projectile)thrown).hitEffects.HasProjectileDeathVFX = true;
		ref VFXPool enemy = ref ((Projectile)thrown).hitEffects.enemy;
		PickupObject byId6 = PickupObjectDatabase.GetById(178);
		enemy = ((Component)((byId6 is Gun) ? byId6 : null)).GetComponent<FireOnReloadSynergyProcessor>().DirectedBurstSettings.ProjectileInterface.SpecifiedProjectile.hitEffects.enemy;
		ref VFXPool deathEnemy = ref ((Projectile)thrown).hitEffects.deathEnemy;
		PickupObject byId7 = PickupObjectDatabase.GetById(178);
		deathEnemy = ((Component)((byId7 is Gun) ? byId7 : null)).GetComponent<FireOnReloadSynergyProcessor>().DirectedBurstSettings.ProjectileInterface.SpecifiedProjectile.hitEffects.deathEnemy;
		ProjectileBuilders.AnimateProjectileBundle((Projectile)(object)thrown, "TomahawkThrown", Initialisation.ProjectileCollection, Initialisation.projectileAnimationCollection, "TomahawkThrown", MiscTools.DupeList<IntVector2>(new IntVector2(32, 30), 4), MiscTools.DupeList(value: false, 8), MiscTools.DupeList<Anchor>((Anchor)4, 4), MiscTools.DupeList(value: true, 4), MiscTools.DupeList(value: false, 4), MiscTools.DupeList<Vector3?>(null, 4), MiscTools.DupeList((IntVector2?)new IntVector2(30, 30), 4), MiscTools.DupeList<IntVector2?>(null, 4), MiscTools.DupeList<Projectile>(null, 4));
	}

	public override void OnReloadPressed(PlayerController player, Gun gun, bool manual)
	{
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		((GunBehaviour)this).OnReloadPressed(player, gun, manual);
		if (gun.ClipShotsRemaining < gun.ClipCapacity && timeSincethrow <= 0f)
		{
			timeSincethrow = 1f;
			GameObject val = ProjectileUtility.InstantiateAndFireInDirection((Projectile)(object)thrown, Vector2.op_Implicit(gun.barrelOffset.position), gun.CurrentAngle, 0f, (PlayerController)null);
			Projectile component = val.GetComponent<Projectile>();
			if ((Object)(object)component != (Object)null)
			{
				component.Owner = (GameActor)(object)player;
				component.Shooter = ((BraveBehaviour)player).specRigidbody;
				component.ScaleByPlayerStats(player);
				player.DoPostProcessProjectile(component);
			}
		}
	}

	public override void Update()
	{
		((GunBehaviour)this).Update();
		if (timeSincethrow > 0f)
		{
			timeSincethrow -= BraveTime.DeltaTime;
		}
	}
}
