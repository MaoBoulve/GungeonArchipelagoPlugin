using System;
using Alexandria.Assetbundle;
using Alexandria.ItemAPI;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class CrescendoBlaster : AdvancedGunBehavior
{
	public class BigCrescendoBullet : MonoBehaviour
	{
	}

	public static int CrescendoBlasterID;

	public static Projectile projOneSMALLEST;

	public static Projectile projTwo;

	public static Projectile projThree;

	public static Projectile projFour;

	public static Projectile projFive;

	public static Projectile projSixBIGGEST;

	private bool doClipSizeUpgradeBurst = false;

	public static void Add()
	{
		//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_012a: Unknown result type (might be due to invalid IL or missing references)
		//IL_014e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0654: Unknown result type (might be due to invalid IL or missing references)
		//IL_067a: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Crescendo Blaster", "crescendoblaster");
		Game.Items.Rename("outdated_gun_mods:crescendo_blaster", "nn:crescendo_blaster");
		((Component)val).gameObject.AddComponent<CrescendoBlaster>();
		GunExt.SetShortDescription((PickupObject)(object)val, "Rise and Fall");
		GunExt.SetLongDescription((PickupObject)(object)val, "Raises and lowers in damage as it fires.\n\nPowered by exotic morphous crystals from a distance moon.");
		GunInt.SetupSprite(val, Initialisation.gunCollection, "crescendoblaster_idle_001", 8, "crescendoblaster_ammonomicon_001");
		GunExt.SetAnimationFPS(val, val.shootAnimation, 10);
		ref string gunSwitchGroup = ref val.gunSwitchGroup;
		PickupObject byId = PickupObjectDatabase.GetById(504);
		gunSwitchGroup = ((Gun)((byId is Gun) ? byId : null)).gunSwitchGroup;
		PickupObject byId2 = PickupObjectDatabase.GetById(86);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId2 is Gun) ? byId2 : null), true, false);
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.shootStyle = (ShootStyle)0;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)1;
		val.reloadTime = 1f;
		val.DefaultModule.burstCooldownTime = 0.1f;
		val.DefaultModule.cooldownTime = 0.25f;
		val.DefaultModule.numberOfShotsInClip = 10;
		val.DefaultModule.angleFromAim = 0f;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(1.56f, 0.68f, 0f);
		val.SetBaseMaxAmmo(220);
		val.ammo = 220;
		val.gunClass = (GunClass)1;
		PickupObject byId3 = PickupObjectDatabase.GetById(86);
		Projectile val2 = Object.Instantiate<Projectile>(((Gun)((byId3 is Gun) ? byId3 : null)).DefaultModule.projectiles[0]);
		((Component)val2).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val2).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val2);
		ProjectileData baseData = val2.baseData;
		baseData.damage *= 0.6f;
		val2.SetProjectileSprite("crescendoblaster_projectile", 25, 25, lightened: true, (Anchor)4, 20, 20, anchorChangesCollider: true, fixesScale: false, null, null);
		val2.AdditionalScaleMultiplier *= 0.16f;
		projOneSMALLEST = val2;
		PickupObject byId4 = PickupObjectDatabase.GetById(86);
		Projectile val3 = Object.Instantiate<Projectile>(((Gun)((byId4 is Gun) ? byId4 : null)).DefaultModule.projectiles[0]);
		((Component)val3).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val3).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val3);
		ProjectileData baseData2 = val3.baseData;
		baseData2.damage *= 1.2f;
		val3.SetProjectileSprite("crescendoblaster_projectile", 25, 25, lightened: true, (Anchor)4, 20, 20, anchorChangesCollider: true, fixesScale: false, null, null);
		val3.AdditionalScaleMultiplier *= 0.32f;
		projTwo = val3;
		PickupObject byId5 = PickupObjectDatabase.GetById(86);
		Projectile val4 = Object.Instantiate<Projectile>(((Gun)((byId5 is Gun) ? byId5 : null)).DefaultModule.projectiles[0]);
		((Component)val4).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val4).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val4);
		ProjectileData baseData3 = val4.baseData;
		baseData3.damage *= 1.8f;
		val4.SetProjectileSprite("crescendoblaster_projectile", 25, 25, lightened: true, (Anchor)4, 20, 20, anchorChangesCollider: true, fixesScale: false, null, null);
		val4.AdditionalScaleMultiplier *= 0.48f;
		projThree = val4;
		PickupObject byId6 = PickupObjectDatabase.GetById(86);
		Projectile val5 = Object.Instantiate<Projectile>(((Gun)((byId6 is Gun) ? byId6 : null)).DefaultModule.projectiles[0]);
		((Component)val5).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val5).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val5);
		ProjectileData baseData4 = val5.baseData;
		baseData4.damage *= 2.4f;
		val5.SetProjectileSprite("crescendoblaster_projectile", 25, 25, lightened: true, (Anchor)4, 20, 20, anchorChangesCollider: true, fixesScale: false, null, null);
		val5.AdditionalScaleMultiplier *= 0.64f;
		projFour = val5;
		PickupObject byId7 = PickupObjectDatabase.GetById(86);
		Projectile val6 = Object.Instantiate<Projectile>(((Gun)((byId7 is Gun) ? byId7 : null)).DefaultModule.projectiles[0]);
		((Component)val6).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val6).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val6);
		ProjectileData baseData5 = val6.baseData;
		baseData5.damage *= 3.2f;
		val6.SetProjectileSprite("crescendoblaster_projectile", 25, 25, lightened: true, (Anchor)4, 20, 20, anchorChangesCollider: true, fixesScale: false, null, null);
		val6.AdditionalScaleMultiplier *= 0.8f;
		projFive = val6;
		PickupObject byId8 = PickupObjectDatabase.GetById(86);
		Projectile val7 = Object.Instantiate<Projectile>(((Gun)((byId8 is Gun) ? byId8 : null)).DefaultModule.projectiles[0]);
		((Component)val7).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val7).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val7);
		ProjectileData baseData6 = val7.baseData;
		baseData6.damage *= 4f;
		val7.SetProjectileSprite("crescendoblaster_projectile", 25, 25, lightened: true, (Anchor)4, 20, 20, anchorChangesCollider: true, fixesScale: false, null, null);
		val7.AdditionalScaleMultiplier *= 1f;
		BigCrescendoBullet bigCrescendoBullet = ((Component)val7).gameObject.AddComponent<BigCrescendoBullet>();
		projSixBIGGEST = val7;
		val.DefaultModule.projectiles[0] = projOneSMALLEST;
		val.DefaultModule.projectiles.Add(projTwo);
		val.DefaultModule.projectiles.Add(projThree);
		val.DefaultModule.projectiles.Add(projFour);
		val.DefaultModule.projectiles.Add(projFive);
		val.DefaultModule.projectiles.Add(projSixBIGGEST);
		val.DefaultModule.projectiles.Add(projFive);
		val.DefaultModule.projectiles.Add(projFour);
		val.DefaultModule.projectiles.Add(projThree);
		val.DefaultModule.projectiles.Add(projTwo);
		val.DefaultModule.ammoType = (AmmoType)14;
		val.DefaultModule.customAmmoType = CustomClipAmmoTypeToolbox.AddCustomAmmoType("Crescendo Blaster Bullets", "NevernamedsItems/Resources/CustomGunAmmoTypes/crescendoblaster_clipfull", "NevernamedsItems/Resources/CustomGunAmmoTypes/crescendoblaster_clipempty");
		((PickupObject)val).quality = (ItemQuality)2;
		Databases.Items.Add(val, (tk2dSpriteCollectionData)null, "ANY");
		CrescendoBlasterID = ((PickupObject)val).PickupObjectId;
	}

	private void RemoveExtraSynergyBullets()
	{
		try
		{
			base.gun.RawSourceVolley.projectiles[0].numberOfShotsInClip = 10;
			base.gun.RawSourceVolley.projectiles[0].projectiles[6] = projFive;
			base.gun.RawSourceVolley.projectiles[0].projectiles[7] = projFour;
			base.gun.RawSourceVolley.projectiles[0].projectiles[8] = projThree;
			base.gun.RawSourceVolley.projectiles[0].projectiles[9] = projTwo;
			base.gun.RawSourceVolley.projectiles[0].projectiles.RemoveAt(11);
			base.gun.RawSourceVolley.projectiles[0].projectiles.RemoveAt(10);
			if ((Object)(object)base.gun.CurrentOwner != (Object)null && base.gun.CurrentOwner is PlayerController)
			{
				GameActor currentOwner = base.gun.CurrentOwner;
				_003F val = ((PlayerController)((currentOwner is PlayerController) ? currentOwner : null)).stats;
				GameActor currentOwner2 = base.gun.CurrentOwner;
				((PlayerStats)val).RecalculateStats((PlayerController)(object)((currentOwner2 is PlayerController) ? currentOwner2 : null), true, false);
			}
		}
		catch (Exception ex)
		{
			ETGModConsole.Log((object)ex.Message, false);
			ETGModConsole.Log((object)ex.StackTrace, false);
		}
	}

	public override void PostProcessProjectile(Projectile projectile)
	{
		GameObjectExtensions.SetLayerRecursively(((Component)projectile).gameObject, LayerMask.NameToLayer("Default"));
		((AdvancedGunBehavior)this).PostProcessProjectile(projectile);
	}

	private void GiveExtraSynergyBullets()
	{
		base.gun.RawSourceVolley.projectiles[0].numberOfShotsInClip = 12;
		base.gun.RawSourceVolley.projectiles[0].projectiles[6] = projSixBIGGEST;
		base.gun.RawSourceVolley.projectiles[0].projectiles[7] = projSixBIGGEST;
		base.gun.RawSourceVolley.projectiles[0].projectiles[8] = projFive;
		base.gun.RawSourceVolley.projectiles[0].projectiles[9] = projFour;
		base.gun.RawSourceVolley.projectiles[0].projectiles.Add(projThree);
		base.gun.RawSourceVolley.projectiles[0].projectiles.Add(projTwo);
		if ((Object)(object)base.gun.CurrentOwner != (Object)null && base.gun.CurrentOwner is PlayerController)
		{
			GameActor currentOwner = base.gun.CurrentOwner;
			_003F val = ((PlayerController)((currentOwner is PlayerController) ? currentOwner : null)).stats;
			GameActor currentOwner2 = base.gun.CurrentOwner;
			((PlayerStats)val).RecalculateStats((PlayerController)(object)((currentOwner2 is PlayerController) ? currentOwner2 : null), true, false);
		}
	}

	private void MakeBurstGun()
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		base.gun.RawSourceVolley.projectiles[0].shootStyle = (ShootStyle)4;
		doClipSizeUpgradeBurst = true;
		if ((Object)(object)base.gun.CurrentOwner != (Object)null && base.gun.CurrentOwner is PlayerController)
		{
			GameActor currentOwner = base.gun.CurrentOwner;
			_003F val = ((PlayerController)((currentOwner is PlayerController) ? currentOwner : null)).stats;
			GameActor currentOwner2 = base.gun.CurrentOwner;
			((PlayerStats)val).RecalculateStats((PlayerController)(object)((currentOwner2 is PlayerController) ? currentOwner2 : null), true, false);
		}
	}

	private void UnmakeBurstGun()
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		base.gun.RawSourceVolley.projectiles[0].shootStyle = (ShootStyle)0;
		doClipSizeUpgradeBurst = false;
		if ((Object)(object)base.gun.CurrentOwner != (Object)null && base.gun.CurrentOwner is PlayerController)
		{
			GameActor currentOwner = base.gun.CurrentOwner;
			_003F val = ((PlayerController)((currentOwner is PlayerController) ? currentOwner : null)).stats;
			GameActor currentOwner2 = base.gun.CurrentOwner;
			((PlayerStats)val).RecalculateStats((PlayerController)(object)((currentOwner2 is PlayerController) ? currentOwner2 : null), true, false);
		}
	}

	protected override void Update()
	{
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d2: Invalid comparison between Unknown and I4
		//IL_00fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0104: Invalid comparison between Unknown and I4
		if (Object.op_Implicit((Object)(object)base.gun) & ((Object)(object)base.gun.CurrentOwner != (Object)null) & (base.gun.CurrentOwner is PlayerController))
		{
			GameActor currentOwner = base.gun.CurrentOwner;
			PlayerController val = (PlayerController)(object)((currentOwner is PlayerController) ? currentOwner : null);
			BigCrescendoBullet component = ((Component)base.gun.RawSourceVolley.projectiles[0].projectiles[6]).GetComponent<BigCrescendoBullet>();
			if ((Object)(object)component == (Object)null && CustomSynergies.PlayerHasActiveSynergy(val, "Fortissimo"))
			{
				GiveExtraSynergyBullets();
			}
			else if ((Object)(object)component != (Object)null && !CustomSynergies.PlayerHasActiveSynergy(val, "Fortissimo"))
			{
				RemoveExtraSynergyBullets();
			}
			if ((int)base.gun.DefaultModule.shootStyle != 4 && CustomSynergies.PlayerHasActiveSynergy(val, "Allegro"))
			{
				MakeBurstGun();
			}
			else if ((int)base.gun.DefaultModule.shootStyle == 4 && !CustomSynergies.PlayerHasActiveSynergy(val, "Allegro"))
			{
				UnmakeBurstGun();
			}
			if (doClipSizeUpgradeBurst && base.gun.DefaultModule.burstShotCount != base.gun.DefaultModule.numberOfShotsInClip)
			{
				RectifyNonMatchingBurstCount();
			}
		}
		((AdvancedGunBehavior)this).Update();
	}

	private void RectifyNonMatchingBurstCount()
	{
		base.gun.RawSourceVolley.projectiles[0].burstShotCount = base.gun.RawSourceVolley.projectiles[0].numberOfShotsInClip;
		if ((Object)(object)base.gun.CurrentOwner != (Object)null && base.gun.CurrentOwner is PlayerController)
		{
			GameActor currentOwner = base.gun.CurrentOwner;
			_003F val = ((PlayerController)((currentOwner is PlayerController) ? currentOwner : null)).stats;
			GameActor currentOwner2 = base.gun.CurrentOwner;
			((PlayerStats)val).RecalculateStats((PlayerController)(object)((currentOwner2 is PlayerController) ? currentOwner2 : null), true, false);
		}
	}
}
