using Alexandria.Assetbundle;
using Alexandria.ItemAPI;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class MinuteGun : AdvancedGunBehavior
{
	public static int MinuteGunID;

	private float timer;

	public static void Add()
	{
		//IL_00b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_012d: Unknown result type (might be due to invalid IL or missing references)
		//IL_014a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0202: Unknown result type (might be due to invalid IL or missing references)
		//IL_0228: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Minute Gun", "minutegun");
		Game.Items.Rename("outdated_gun_mods:minute_gun", "nn:minute_gun");
		((Component)val).gameObject.AddComponent<MinuteGun>();
		GunExt.SetShortDescription((PickupObject)(object)val, "You Have 60 Seconds");
		GunExt.SetLongDescription((PickupObject)(object)val, "Usable for only 60 seconds each floor.\n\nA tiny adventurer managed to bring this all the way from his home in the swamps to the Gungeon's Entrance before his time was up.");
		GunInt.SetupSprite(val, Initialisation.gunCollection, "minutegun_idle_001", 8, "minutegun_ammonomicon_001");
		GunExt.SetAnimationFPS(val, val.shootAnimation, 16);
		ref string gunSwitchGroup = ref val.gunSwitchGroup;
		PickupObject byId = PickupObjectDatabase.GetById(86);
		gunSwitchGroup = ((Gun)((byId is Gun) ? byId : null)).gunSwitchGroup;
		PickupObject byId2 = PickupObjectDatabase.GetById(56);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId2 is Gun) ? byId2 : null), true, false);
		val.DefaultModule.ammoCost = 0;
		val.DefaultModule.shootStyle = (ShootStyle)0;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 1f;
		val.DefaultModule.cooldownTime = 0.1f;
		val.DefaultModule.angleVariance = 5f;
		val.DefaultModule.numberOfShotsInClip = 7;
		ref VFXPool muzzleFlashEffects = ref val.muzzleFlashEffects;
		PickupObject byId3 = PickupObjectDatabase.GetById(84);
		muzzleFlashEffects = ((Gun)((byId3 is Gun) ? byId3 : null)).muzzleFlashEffects;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(1.75f, 0.87f, 0f);
		val.SetBaseMaxAmmo(0);
		val.ammo = 60;
		val.gunClass = (GunClass)1;
		Projectile val2 = Object.Instantiate<Projectile>(val.DefaultModule.projectiles[0]);
		((Component)val2).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val2).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val2);
		val2.SetProjectileSprite("minutegun_projectile", 16, 9, lightened: true, (Anchor)4, 15, 8, anchorChangesCollider: true, fixesScale: false, null, null);
		val2.hitEffects.overrideMidairDeathVFX = SharedVFX.WhiteCircleVFX;
		val2.hitEffects.alwaysUseMidair = true;
		val2.baseData.damage = 20f;
		val.DefaultModule.projectiles[0] = val2;
		val.DefaultModule.ammoType = (AmmoType)14;
		val.DefaultModule.customAmmoType = CustomClipAmmoTypeToolbox.AddCustomAmmoType("Minute Gun Bullets", "NevernamedsItems/Resources/CustomGunAmmoTypes/minutegun_clipfull", "NevernamedsItems/Resources/CustomGunAmmoTypes/minutegun_clipempty");
		((PickupObject)val).quality = (ItemQuality)2;
		Databases.Items.Add(val, (tk2dSpriteCollectionData)null, "ANY");
		MinuteGunID = ((PickupObject)val).PickupObjectId;
	}

	public override void OnSwitchedToThisGun()
	{
		if (timer > 0f)
		{
			base.gun.MoveBulletsIntoClip(Mathf.CeilToInt(timer));
		}
		((AdvancedGunBehavior)this).OnSwitchedToThisGun();
	}

	public override void PostProcessProjectile(Projectile projectile)
	{
		if (Object.op_Implicit((Object)(object)GunTools.GunPlayerOwner(base.gun)) && CustomSynergies.PlayerHasActiveSynergy(GunTools.GunPlayerOwner(base.gun), "Nick Of Time"))
		{
			ProjectileData baseData = projectile.baseData;
			baseData.damage *= 3f - 0.05f * timer;
		}
		((AdvancedGunBehavior)this).PostProcessProjectile(projectile);
	}

	protected override void OnPickedUpByPlayer(PlayerController player)
	{
		if (!base.everPickedUpByPlayer)
		{
			timer = 60f * player.stats.GetStatValue((StatType)9);
		}
		else
		{
			base.gun.CurrentAmmo = Mathf.CeilToInt(timer);
		}
		GameManager.Instance.OnNewLevelFullyLoaded += OnNewLevel;
		((AdvancedGunBehavior)this).OnPickedUpByPlayer(player);
	}

	protected override void OnPostDroppedByPlayer(PlayerController player)
	{
		GameManager.Instance.OnNewLevelFullyLoaded -= OnNewLevel;
		((AdvancedGunBehavior)this).OnPostDroppedByPlayer(player);
	}

	public override void OnDestroy()
	{
		GameManager.Instance.OnNewLevelFullyLoaded -= OnNewLevel;
		((BraveBehaviour)this).OnDestroy();
	}

	private void OnNewLevel()
	{
		if (Object.op_Implicit((Object)(object)((AdvancedGunBehavior)this).Owner) && ((AdvancedGunBehavior)this).Owner is PlayerController)
		{
			ref float reference = ref timer;
			GameActor owner = ((AdvancedGunBehavior)this).Owner;
			reference = 60f * ((PlayerController)((owner is PlayerController) ? owner : null)).stats.GetStatValue((StatType)9);
		}
	}

	protected override void Update()
	{
		if (timer >= 0f && Object.op_Implicit((Object)(object)base.gun) && Object.op_Implicit((Object)(object)base.gun.CurrentOwner) && ((PickupObject)base.gun.CurrentOwner.CurrentGun).PickupObjectId == MinuteGunID)
		{
			timer -= BraveTime.DeltaTime;
		}
		base.gun.CurrentAmmo = Mathf.CeilToInt(timer);
		((AdvancedGunBehavior)this).Update();
	}
}
