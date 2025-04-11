using System;
using System.Collections.Generic;
using Alexandria.Assetbundle;
using Alexandria.ItemAPI;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class HandGun : AdvancedGunBehavior
{
	public static int HandGunID;

	public static void Add()
	{
		//IL_009d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0120: Unknown result type (might be due to invalid IL or missing references)
		//IL_30b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_30dd: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Hand Gun", "nnhandgun");
		Game.Items.Rename("outdated_gun_mods:hand_gun", "nn:hand_gun");
		((Component)val).gameObject.AddComponent<HandGun>();
		GunExt.SetShortDescription((PickupObject)(object)val, "The Hand You've Been Dealt");
		GunExt.SetLongDescription((PickupObject)(object)val, "Brought to the Gungeon by infamous gambler Blast Eddie after the losing streak of his lifetime.\n\nThe characters depicted on the cards go back eons.");
		GunInt.SetupSprite(val, Initialisation.gunCollection, "nnhandgun_idle_001", 8, "nnhandgun_ammonomicon_001");
		GunExt.SetAnimationFPS(val, val.shootAnimation, 14);
		PickupObject byId = PickupObjectDatabase.GetById(56);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId is Gun) ? byId : null), true, false);
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.shootStyle = (ShootStyle)0;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 1f;
		val.muzzleFlashEffects.type = (VFXPoolType)0;
		val.DefaultModule.cooldownTime = 0.15f;
		val.DefaultModule.numberOfShotsInClip = 5;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(1.12f, 0.75f, 0f);
		val.SetBaseMaxAmmo(312);
		val.ammo = 312;
		val.gunClass = (GunClass)50;
		PickupObject byId2 = PickupObjectDatabase.GetById(56);
		Projectile val2 = Object.Instantiate<Projectile>(((Gun)((byId2 is Gun) ? byId2 : null)).DefaultModule.projectiles[0]);
		((Component)val2).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val2).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val2);
		ProjectileData baseData = val2.baseData;
		baseData.damage *= 4f;
		ProjectileData baseData2 = val2.baseData;
		baseData2.range *= 3f;
		ProjectileData baseData3 = val2.baseData;
		baseData3.speed *= 0.5f;
		val2.SetProjectileSprite("aceofhearts_projectile", 11, 13, lightened: true, (Anchor)4, 7, 7, anchorChangesCollider: true, fixesScale: false, null, null);
		DesignateType(val2, HandGunCardBullet.CardSuit.HEARTS, HandGunCardBullet.CardValue.ACE);
		PickupObject byId3 = PickupObjectDatabase.GetById(56);
		Projectile val3 = Object.Instantiate<Projectile>(((Gun)((byId3 is Gun) ? byId3 : null)).DefaultModule.projectiles[0]);
		((Component)val3).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val3).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val3);
		ProjectileData baseData4 = val3.baseData;
		baseData4.damage *= 2.4f;
		ProjectileData baseData5 = val3.baseData;
		baseData5.range *= 3f;
		ProjectileData baseData6 = val3.baseData;
		baseData6.speed *= 0.5f;
		HomingModifier orAddComponent = GameObjectExtensions.GetOrAddComponent<HomingModifier>(((Component)val3).gameObject);
		orAddComponent.HomingRadius = 100f;
		val3.SetProjectileSprite("queenofhearts_projectile", 12, 13, lightened: true, (Anchor)4, 7, 7, anchorChangesCollider: true, fixesScale: false, null, null);
		DesignateType(val3, HandGunCardBullet.CardSuit.HEARTS, HandGunCardBullet.CardValue.QUEEN);
		PickupObject byId4 = PickupObjectDatabase.GetById(56);
		Projectile val4 = Object.Instantiate<Projectile>(((Gun)((byId4 is Gun) ? byId4 : null)).DefaultModule.projectiles[0]);
		((Component)val4).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val4).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val4);
		ProjectileData baseData7 = val4.baseData;
		baseData7.damage *= 2.6f;
		ProjectileData baseData8 = val4.baseData;
		baseData8.range *= 3f;
		ProjectileData baseData9 = val4.baseData;
		baseData9.speed *= 0.5f;
		PierceProjModifier orAddComponent2 = GameObjectExtensions.GetOrAddComponent<PierceProjModifier>(((Component)val4).gameObject);
		orAddComponent2.penetration += 5;
		BounceProjModifier orAddComponent3 = GameObjectExtensions.GetOrAddComponent<BounceProjModifier>(((Component)val4).gameObject);
		orAddComponent3.numberOfBounces += 5;
		val4.SetProjectileSprite("kingofhearts_projectile", 12, 13, lightened: true, (Anchor)4, 7, 7, anchorChangesCollider: true, fixesScale: false, null, null);
		DesignateType(val4, HandGunCardBullet.CardSuit.HEARTS, HandGunCardBullet.CardValue.KING);
		PickupObject byId5 = PickupObjectDatabase.GetById(56);
		Projectile val5 = Object.Instantiate<Projectile>(((Gun)((byId5 is Gun) ? byId5 : null)).DefaultModule.projectiles[0]);
		((Component)val5).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val5).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val5);
		PlayerProjectileTeleportModifier orAddComponent4 = GameObjectExtensions.GetOrAddComponent<PlayerProjectileTeleportModifier>(((Component)val5).gameObject);
		ProjectileData baseData10 = val5.baseData;
		baseData10.damage *= 2.2f;
		ProjectileData baseData11 = val5.baseData;
		baseData11.range *= 4f;
		ProjectileData baseData12 = val5.baseData;
		baseData12.speed *= 0.5f;
		val5.SetProjectileSprite("knaveofhearts_projectile", 11, 13, lightened: true, (Anchor)4, 7, 7, anchorChangesCollider: true, fixesScale: false, null, null);
		DesignateType(val5, HandGunCardBullet.CardSuit.HEARTS, HandGunCardBullet.CardValue.KNAVE);
		PickupObject byId6 = PickupObjectDatabase.GetById(56);
		Projectile val6 = Object.Instantiate<Projectile>(((Gun)((byId6 is Gun) ? byId6 : null)).DefaultModule.projectiles[0]);
		((Component)val6).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val6).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val6);
		ProjectileData baseData13 = val6.baseData;
		baseData13.damage *= 0.4f;
		ProjectileData baseData14 = val6.baseData;
		baseData14.range *= 3f;
		ProjectileData baseData15 = val6.baseData;
		baseData15.speed *= 0.5f;
		val6.SetProjectileSprite("generichearts_projectile", 11, 13, lightened: true, (Anchor)4, 7, 7, anchorChangesCollider: true, fixesScale: false, null, null);
		DesignateType(val6, HandGunCardBullet.CardSuit.HEARTS, HandGunCardBullet.CardValue.GENERIC);
		PickupObject byId7 = PickupObjectDatabase.GetById(56);
		Projectile val7 = Object.Instantiate<Projectile>(((Gun)((byId7 is Gun) ? byId7 : null)).DefaultModule.projectiles[0]);
		((Component)val7).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val7).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val7);
		ProjectileData baseData16 = val7.baseData;
		baseData16.damage *= 0.6f;
		ProjectileData baseData17 = val7.baseData;
		baseData17.range *= 3f;
		ProjectileData baseData18 = val7.baseData;
		baseData18.speed *= 0.5f;
		val7.SetProjectileSprite("generichearts_projectile", 11, 13, lightened: true, (Anchor)4, 7, 7, anchorChangesCollider: true, fixesScale: false, null, null);
		DesignateType(val7, HandGunCardBullet.CardSuit.HEARTS, HandGunCardBullet.CardValue.GENERIC);
		PickupObject byId8 = PickupObjectDatabase.GetById(56);
		Projectile val8 = Object.Instantiate<Projectile>(((Gun)((byId8 is Gun) ? byId8 : null)).DefaultModule.projectiles[0]);
		((Component)val8).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val8).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val8);
		ProjectileData baseData19 = val8.baseData;
		baseData19.damage *= 0.8f;
		ProjectileData baseData20 = val8.baseData;
		baseData20.range *= 3f;
		ProjectileData baseData21 = val8.baseData;
		baseData21.speed *= 0.5f;
		val8.SetProjectileSprite("generichearts_projectile", 11, 13, lightened: true, (Anchor)4, 7, 7, anchorChangesCollider: true, fixesScale: false, null, null);
		DesignateType(val8, HandGunCardBullet.CardSuit.HEARTS, HandGunCardBullet.CardValue.GENERIC);
		PickupObject byId9 = PickupObjectDatabase.GetById(56);
		Projectile val9 = Object.Instantiate<Projectile>(((Gun)((byId9 is Gun) ? byId9 : null)).DefaultModule.projectiles[0]);
		((Component)val9).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val9).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val9);
		ProjectileData baseData22 = val9.baseData;
		baseData22.damage *= 1f;
		ProjectileData baseData23 = val9.baseData;
		baseData23.range *= 3f;
		ProjectileData baseData24 = val9.baseData;
		baseData24.speed *= 0.5f;
		val9.SetProjectileSprite("generichearts_projectile", 11, 13, lightened: true, (Anchor)4, 7, 7, anchorChangesCollider: true, fixesScale: false, null, null);
		DesignateType(val9, HandGunCardBullet.CardSuit.HEARTS, HandGunCardBullet.CardValue.GENERIC);
		PickupObject byId10 = PickupObjectDatabase.GetById(56);
		Projectile val10 = Object.Instantiate<Projectile>(((Gun)((byId10 is Gun) ? byId10 : null)).DefaultModule.projectiles[0]);
		((Component)val10).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val10).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val10);
		ProjectileData baseData25 = val10.baseData;
		baseData25.damage *= 1.2f;
		ProjectileData baseData26 = val10.baseData;
		baseData26.range *= 3f;
		ProjectileData baseData27 = val10.baseData;
		baseData27.speed *= 0.5f;
		val10.SetProjectileSprite("generichearts_projectile", 11, 13, lightened: true, (Anchor)4, 7, 7, anchorChangesCollider: true, fixesScale: false, null, null);
		DesignateType(val10, HandGunCardBullet.CardSuit.HEARTS, HandGunCardBullet.CardValue.GENERIC);
		PickupObject byId11 = PickupObjectDatabase.GetById(56);
		Projectile val11 = Object.Instantiate<Projectile>(((Gun)((byId11 is Gun) ? byId11 : null)).DefaultModule.projectiles[0]);
		((Component)val11).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val11).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val11);
		ProjectileData baseData28 = val11.baseData;
		baseData28.damage *= 1.4f;
		ProjectileData baseData29 = val11.baseData;
		baseData29.range *= 3f;
		ProjectileData baseData30 = val11.baseData;
		baseData30.speed *= 0.5f;
		val11.SetProjectileSprite("generichearts_projectile", 11, 13, lightened: true, (Anchor)4, 7, 7, anchorChangesCollider: true, fixesScale: false, null, null);
		DesignateType(val11, HandGunCardBullet.CardSuit.HEARTS, HandGunCardBullet.CardValue.GENERIC);
		PickupObject byId12 = PickupObjectDatabase.GetById(56);
		Projectile val12 = Object.Instantiate<Projectile>(((Gun)((byId12 is Gun) ? byId12 : null)).DefaultModule.projectiles[0]);
		((Component)val12).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val12).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val12);
		ProjectileData baseData31 = val12.baseData;
		baseData31.damage *= 1.6f;
		ProjectileData baseData32 = val12.baseData;
		baseData32.range *= 3f;
		ProjectileData baseData33 = val12.baseData;
		baseData33.speed *= 0.5f;
		val12.SetProjectileSprite("generichearts_projectile", 11, 13, lightened: true, (Anchor)4, 7, 7, anchorChangesCollider: true, fixesScale: false, null, null);
		DesignateType(val12, HandGunCardBullet.CardSuit.HEARTS, HandGunCardBullet.CardValue.GENERIC);
		PickupObject byId13 = PickupObjectDatabase.GetById(56);
		Projectile val13 = Object.Instantiate<Projectile>(((Gun)((byId13 is Gun) ? byId13 : null)).DefaultModule.projectiles[0]);
		((Component)val13).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val13).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val13);
		ProjectileData baseData34 = val13.baseData;
		baseData34.damage *= 1.8f;
		ProjectileData baseData35 = val13.baseData;
		baseData35.range *= 3f;
		ProjectileData baseData36 = val13.baseData;
		baseData36.speed *= 0.5f;
		val13.SetProjectileSprite("generichearts_projectile", 11, 13, lightened: true, (Anchor)4, 7, 7, anchorChangesCollider: true, fixesScale: false, null, null);
		DesignateType(val13, HandGunCardBullet.CardSuit.HEARTS, HandGunCardBullet.CardValue.GENERIC);
		PickupObject byId14 = PickupObjectDatabase.GetById(56);
		Projectile val14 = Object.Instantiate<Projectile>(((Gun)((byId14 is Gun) ? byId14 : null)).DefaultModule.projectiles[0]);
		((Component)val14).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val14).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val14);
		ProjectileData baseData37 = val14.baseData;
		baseData37.damage *= 2f;
		ProjectileData baseData38 = val14.baseData;
		baseData38.range *= 3f;
		ProjectileData baseData39 = val14.baseData;
		baseData39.speed *= 0.5f;
		val14.SetProjectileSprite("generichearts_projectile", 11, 13, lightened: true, (Anchor)4, 7, 7, anchorChangesCollider: true, fixesScale: false, null, null);
		DesignateType(val14, HandGunCardBullet.CardSuit.HEARTS, HandGunCardBullet.CardValue.GENERIC);
		PickupObject byId15 = PickupObjectDatabase.GetById(56);
		Projectile val15 = Object.Instantiate<Projectile>(((Gun)((byId15 is Gun) ? byId15 : null)).DefaultModule.projectiles[0]);
		((Component)val15).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val15).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val15);
		ProjectileData baseData40 = val15.baseData;
		baseData40.damage *= 4f;
		ProjectileData baseData41 = val15.baseData;
		baseData41.range *= 3f;
		ProjectileData baseData42 = val15.baseData;
		baseData42.speed *= 0.5f;
		val15.SetProjectileSprite("aceofdiamonds_projectile", 18, 10, lightened: true, (Anchor)4, 11, 7, anchorChangesCollider: true, fixesScale: false, null, null);
		DesignateType(val15, HandGunCardBullet.CardSuit.DIAMONDS, HandGunCardBullet.CardValue.ACE);
		PickupObject byId16 = PickupObjectDatabase.GetById(56);
		Projectile val16 = Object.Instantiate<Projectile>(((Gun)((byId16 is Gun) ? byId16 : null)).DefaultModule.projectiles[0]);
		((Component)val16).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val16).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val16);
		ProjectileData baseData43 = val16.baseData;
		baseData43.damage *= 2.4f;
		ProjectileData baseData44 = val16.baseData;
		baseData44.range *= 3f;
		ProjectileData baseData45 = val16.baseData;
		baseData45.speed *= 0.5f;
		HomingModifier orAddComponent5 = GameObjectExtensions.GetOrAddComponent<HomingModifier>(((Component)val16).gameObject);
		orAddComponent5.HomingRadius = 100f;
		val16.SetProjectileSprite("queenofdiamonds_projectile", 18, 10, lightened: true, (Anchor)4, 11, 7, anchorChangesCollider: true, fixesScale: false, null, null);
		DesignateType(val16, HandGunCardBullet.CardSuit.DIAMONDS, HandGunCardBullet.CardValue.QUEEN);
		PickupObject byId17 = PickupObjectDatabase.GetById(56);
		Projectile val17 = Object.Instantiate<Projectile>(((Gun)((byId17 is Gun) ? byId17 : null)).DefaultModule.projectiles[0]);
		((Component)val17).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val17).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val17);
		ProjectileData baseData46 = val17.baseData;
		baseData46.damage *= 2.6f;
		ProjectileData baseData47 = val17.baseData;
		baseData47.range *= 3f;
		ProjectileData baseData48 = val17.baseData;
		baseData48.speed *= 0.5f;
		PierceProjModifier orAddComponent6 = GameObjectExtensions.GetOrAddComponent<PierceProjModifier>(((Component)val17).gameObject);
		orAddComponent6.penetration += 5;
		BounceProjModifier orAddComponent7 = GameObjectExtensions.GetOrAddComponent<BounceProjModifier>(((Component)val17).gameObject);
		orAddComponent7.numberOfBounces += 5;
		val17.SetProjectileSprite("kingofdiamonds_projectile", 18, 10, lightened: true, (Anchor)4, 11, 7, anchorChangesCollider: true, fixesScale: false, null, null);
		DesignateType(val17, HandGunCardBullet.CardSuit.DIAMONDS, HandGunCardBullet.CardValue.KING);
		PickupObject byId18 = PickupObjectDatabase.GetById(56);
		Projectile val18 = Object.Instantiate<Projectile>(((Gun)((byId18 is Gun) ? byId18 : null)).DefaultModule.projectiles[0]);
		((Component)val18).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val18).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val18);
		PlayerProjectileTeleportModifier orAddComponent8 = GameObjectExtensions.GetOrAddComponent<PlayerProjectileTeleportModifier>(((Component)val18).gameObject);
		ProjectileData baseData49 = val18.baseData;
		baseData49.damage *= 2.2f;
		ProjectileData baseData50 = val18.baseData;
		baseData50.range *= 4f;
		ProjectileData baseData51 = val18.baseData;
		baseData51.speed *= 0.5f;
		val18.SetProjectileSprite("knaveofdiamonds_projectile", 18, 10, lightened: true, (Anchor)4, 11, 7, anchorChangesCollider: true, fixesScale: false, null, null);
		DesignateType(val18, HandGunCardBullet.CardSuit.DIAMONDS, HandGunCardBullet.CardValue.KNAVE);
		PickupObject byId19 = PickupObjectDatabase.GetById(56);
		Projectile val19 = Object.Instantiate<Projectile>(((Gun)((byId19 is Gun) ? byId19 : null)).DefaultModule.projectiles[0]);
		((Component)val19).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val19).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val19);
		ProjectileData baseData52 = val19.baseData;
		baseData52.damage *= 0.4f;
		ProjectileData baseData53 = val19.baseData;
		baseData53.range *= 3f;
		ProjectileData baseData54 = val19.baseData;
		baseData54.speed *= 0.5f;
		val19.SetProjectileSprite("genericdiamonds_projectile", 18, 10, lightened: true, (Anchor)4, 11, 7, anchorChangesCollider: true, fixesScale: false, null, null);
		DesignateType(val19, HandGunCardBullet.CardSuit.DIAMONDS, HandGunCardBullet.CardValue.GENERIC);
		PickupObject byId20 = PickupObjectDatabase.GetById(56);
		Projectile val20 = Object.Instantiate<Projectile>(((Gun)((byId20 is Gun) ? byId20 : null)).DefaultModule.projectiles[0]);
		((Component)val20).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val20).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val20);
		ProjectileData baseData55 = val20.baseData;
		baseData55.damage *= 0.6f;
		ProjectileData baseData56 = val20.baseData;
		baseData56.range *= 3f;
		ProjectileData baseData57 = val20.baseData;
		baseData57.speed *= 0.5f;
		val20.SetProjectileSprite("genericdiamonds_projectile", 18, 10, lightened: true, (Anchor)4, 11, 7, anchorChangesCollider: true, fixesScale: false, null, null);
		DesignateType(val20, HandGunCardBullet.CardSuit.DIAMONDS, HandGunCardBullet.CardValue.GENERIC);
		PickupObject byId21 = PickupObjectDatabase.GetById(56);
		Projectile val21 = Object.Instantiate<Projectile>(((Gun)((byId21 is Gun) ? byId21 : null)).DefaultModule.projectiles[0]);
		((Component)val21).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val21).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val21);
		ProjectileData baseData58 = val21.baseData;
		baseData58.damage *= 0.8f;
		ProjectileData baseData59 = val21.baseData;
		baseData59.range *= 3f;
		ProjectileData baseData60 = val21.baseData;
		baseData60.speed *= 0.5f;
		val21.SetProjectileSprite("genericdiamonds_projectile", 18, 10, lightened: true, (Anchor)4, 11, 7, anchorChangesCollider: true, fixesScale: false, null, null);
		DesignateType(val21, HandGunCardBullet.CardSuit.DIAMONDS, HandGunCardBullet.CardValue.GENERIC);
		PickupObject byId22 = PickupObjectDatabase.GetById(56);
		Projectile val22 = Object.Instantiate<Projectile>(((Gun)((byId22 is Gun) ? byId22 : null)).DefaultModule.projectiles[0]);
		((Component)val22).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val22).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val22);
		ProjectileData baseData61 = val22.baseData;
		baseData61.damage *= 1f;
		ProjectileData baseData62 = val22.baseData;
		baseData62.range *= 3f;
		ProjectileData baseData63 = val22.baseData;
		baseData63.speed *= 0.5f;
		val22.SetProjectileSprite("genericdiamonds_projectile", 18, 10, lightened: true, (Anchor)4, 11, 7, anchorChangesCollider: true, fixesScale: false, null, null);
		DesignateType(val22, HandGunCardBullet.CardSuit.DIAMONDS, HandGunCardBullet.CardValue.GENERIC);
		PickupObject byId23 = PickupObjectDatabase.GetById(56);
		Projectile val23 = Object.Instantiate<Projectile>(((Gun)((byId23 is Gun) ? byId23 : null)).DefaultModule.projectiles[0]);
		((Component)val23).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val23).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val23);
		ProjectileData baseData64 = val23.baseData;
		baseData64.damage *= 1.2f;
		ProjectileData baseData65 = val23.baseData;
		baseData65.range *= 3f;
		ProjectileData baseData66 = val23.baseData;
		baseData66.speed *= 0.5f;
		val23.SetProjectileSprite("genericdiamonds_projectile", 18, 10, lightened: true, (Anchor)4, 11, 7, anchorChangesCollider: true, fixesScale: false, null, null);
		DesignateType(val23, HandGunCardBullet.CardSuit.DIAMONDS, HandGunCardBullet.CardValue.GENERIC);
		PickupObject byId24 = PickupObjectDatabase.GetById(56);
		Projectile val24 = Object.Instantiate<Projectile>(((Gun)((byId24 is Gun) ? byId24 : null)).DefaultModule.projectiles[0]);
		((Component)val24).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val24).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val24);
		ProjectileData baseData67 = val24.baseData;
		baseData67.damage *= 1.4f;
		ProjectileData baseData68 = val24.baseData;
		baseData68.range *= 3f;
		ProjectileData baseData69 = val24.baseData;
		baseData69.speed *= 0.5f;
		val24.SetProjectileSprite("genericdiamonds_projectile", 18, 10, lightened: true, (Anchor)4, 11, 7, anchorChangesCollider: true, fixesScale: false, null, null);
		DesignateType(val24, HandGunCardBullet.CardSuit.DIAMONDS, HandGunCardBullet.CardValue.GENERIC);
		PickupObject byId25 = PickupObjectDatabase.GetById(56);
		Projectile val25 = Object.Instantiate<Projectile>(((Gun)((byId25 is Gun) ? byId25 : null)).DefaultModule.projectiles[0]);
		((Component)val25).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val25).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val25);
		ProjectileData baseData70 = val25.baseData;
		baseData70.damage *= 1.6f;
		ProjectileData baseData71 = val25.baseData;
		baseData71.range *= 3f;
		ProjectileData baseData72 = val25.baseData;
		baseData72.speed *= 0.5f;
		val25.SetProjectileSprite("genericdiamonds_projectile", 18, 10, lightened: true, (Anchor)4, 11, 7, anchorChangesCollider: true, fixesScale: false, null, null);
		DesignateType(val25, HandGunCardBullet.CardSuit.DIAMONDS, HandGunCardBullet.CardValue.GENERIC);
		PickupObject byId26 = PickupObjectDatabase.GetById(56);
		Projectile val26 = Object.Instantiate<Projectile>(((Gun)((byId26 is Gun) ? byId26 : null)).DefaultModule.projectiles[0]);
		((Component)val26).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val26).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val26);
		ProjectileData baseData73 = val26.baseData;
		baseData73.damage *= 1.8f;
		ProjectileData baseData74 = val26.baseData;
		baseData74.range *= 3f;
		ProjectileData baseData75 = val26.baseData;
		baseData75.speed *= 0.5f;
		val26.SetProjectileSprite("genericdiamonds_projectile", 18, 10, lightened: true, (Anchor)4, 11, 7, anchorChangesCollider: true, fixesScale: false, null, null);
		DesignateType(val26, HandGunCardBullet.CardSuit.DIAMONDS, HandGunCardBullet.CardValue.GENERIC);
		PickupObject byId27 = PickupObjectDatabase.GetById(56);
		Projectile val27 = Object.Instantiate<Projectile>(((Gun)((byId27 is Gun) ? byId27 : null)).DefaultModule.projectiles[0]);
		((Component)val27).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val27).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val27);
		ProjectileData baseData76 = val27.baseData;
		baseData76.damage *= 2f;
		ProjectileData baseData77 = val27.baseData;
		baseData77.range *= 3f;
		ProjectileData baseData78 = val27.baseData;
		baseData78.speed *= 0.5f;
		val27.SetProjectileSprite("genericdiamonds_projectile", 18, 10, lightened: true, (Anchor)4, 11, 7, anchorChangesCollider: true, fixesScale: false, null, null);
		DesignateType(val27, HandGunCardBullet.CardSuit.DIAMONDS, HandGunCardBullet.CardValue.GENERIC);
		PickupObject byId28 = PickupObjectDatabase.GetById(56);
		Projectile val28 = Object.Instantiate<Projectile>(((Gun)((byId28 is Gun) ? byId28 : null)).DefaultModule.projectiles[0]);
		((Component)val28).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val28).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val28);
		ProjectileData baseData79 = val28.baseData;
		baseData79.damage *= 8f;
		ProjectileData baseData80 = val28.baseData;
		baseData80.range *= 3f;
		ProjectileData baseData81 = val28.baseData;
		baseData81.speed *= 0.5f;
		val28.ignoreDamageCaps = true;
		val28.SetProjectileSprite("aceofspades_projectile", 20, 17, lightened: true, (Anchor)4, 9, 7, anchorChangesCollider: true, fixesScale: false, null, null);
		DesignateType(val28, HandGunCardBullet.CardSuit.SPADES, HandGunCardBullet.CardValue.ACE);
		PickupObject byId29 = PickupObjectDatabase.GetById(56);
		Projectile val29 = Object.Instantiate<Projectile>(((Gun)((byId29 is Gun) ? byId29 : null)).DefaultModule.projectiles[0]);
		((Component)val29).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val29).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val29);
		ProjectileData baseData82 = val29.baseData;
		baseData82.damage *= 2.4f;
		ProjectileData baseData83 = val29.baseData;
		baseData83.range *= 3f;
		ProjectileData baseData84 = val29.baseData;
		baseData84.speed *= 0.5f;
		HomingModifier orAddComponent9 = GameObjectExtensions.GetOrAddComponent<HomingModifier>(((Component)val29).gameObject);
		orAddComponent9.HomingRadius = 100f;
		val29.SetProjectileSprite("queenofspades_projectile", 14, 11, lightened: true, (Anchor)4, 7, 7, anchorChangesCollider: true, fixesScale: false, null, null);
		DesignateType(val29, HandGunCardBullet.CardSuit.SPADES, HandGunCardBullet.CardValue.QUEEN);
		PickupObject byId30 = PickupObjectDatabase.GetById(56);
		Projectile val30 = Object.Instantiate<Projectile>(((Gun)((byId30 is Gun) ? byId30 : null)).DefaultModule.projectiles[0]);
		((Component)val30).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val30).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val30);
		ProjectileData baseData85 = val30.baseData;
		baseData85.damage *= 2.6f;
		ProjectileData baseData86 = val30.baseData;
		baseData86.range *= 3f;
		ProjectileData baseData87 = val30.baseData;
		baseData87.speed *= 0.5f;
		PierceProjModifier orAddComponent10 = GameObjectExtensions.GetOrAddComponent<PierceProjModifier>(((Component)val30).gameObject);
		orAddComponent10.penetration += 5;
		BounceProjModifier orAddComponent11 = GameObjectExtensions.GetOrAddComponent<BounceProjModifier>(((Component)val30).gameObject);
		orAddComponent11.numberOfBounces += 5;
		val30.SetProjectileSprite("kingofspades_projectile", 14, 11, lightened: true, (Anchor)4, 7, 7, anchorChangesCollider: true, fixesScale: false, null, null);
		DesignateType(val30, HandGunCardBullet.CardSuit.SPADES, HandGunCardBullet.CardValue.KING);
		PickupObject byId31 = PickupObjectDatabase.GetById(56);
		Projectile val31 = Object.Instantiate<Projectile>(((Gun)((byId31 is Gun) ? byId31 : null)).DefaultModule.projectiles[0]);
		((Component)val31).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val31).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val31);
		PlayerProjectileTeleportModifier orAddComponent12 = GameObjectExtensions.GetOrAddComponent<PlayerProjectileTeleportModifier>(((Component)val31).gameObject);
		ProjectileData baseData88 = val31.baseData;
		baseData88.damage *= 2.2f;
		ProjectileData baseData89 = val31.baseData;
		baseData89.range *= 4f;
		ProjectileData baseData90 = val31.baseData;
		baseData90.speed *= 0.5f;
		val31.SetProjectileSprite("knaveofspades_projectile", 14, 11, lightened: true, (Anchor)4, 7, 7, anchorChangesCollider: true, fixesScale: false, null, null);
		DesignateType(val31, HandGunCardBullet.CardSuit.SPADES, HandGunCardBullet.CardValue.KNAVE);
		PickupObject byId32 = PickupObjectDatabase.GetById(56);
		Projectile val32 = Object.Instantiate<Projectile>(((Gun)((byId32 is Gun) ? byId32 : null)).DefaultModule.projectiles[0]);
		((Component)val32).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val32).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val32);
		ProjectileData baseData91 = val32.baseData;
		baseData91.damage *= 0.4f;
		ProjectileData baseData92 = val32.baseData;
		baseData92.range *= 3f;
		ProjectileData baseData93 = val32.baseData;
		baseData93.speed *= 0.5f;
		val32.SetProjectileSprite("genericspades_projectile", 14, 11, lightened: true, (Anchor)4, 7, 7, anchorChangesCollider: true, fixesScale: false, null, null);
		DesignateType(val32, HandGunCardBullet.CardSuit.SPADES, HandGunCardBullet.CardValue.GENERIC);
		PickupObject byId33 = PickupObjectDatabase.GetById(56);
		Projectile val33 = Object.Instantiate<Projectile>(((Gun)((byId33 is Gun) ? byId33 : null)).DefaultModule.projectiles[0]);
		((Component)val33).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val33).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val33);
		ProjectileData baseData94 = val33.baseData;
		baseData94.damage *= 0.6f;
		ProjectileData baseData95 = val33.baseData;
		baseData95.range *= 3f;
		ProjectileData baseData96 = val33.baseData;
		baseData96.speed *= 0.5f;
		val33.SetProjectileSprite("genericspades_projectile", 14, 11, lightened: true, (Anchor)4, 7, 7, anchorChangesCollider: true, fixesScale: false, null, null);
		DesignateType(val33, HandGunCardBullet.CardSuit.SPADES, HandGunCardBullet.CardValue.GENERIC);
		PickupObject byId34 = PickupObjectDatabase.GetById(56);
		Projectile val34 = Object.Instantiate<Projectile>(((Gun)((byId34 is Gun) ? byId34 : null)).DefaultModule.projectiles[0]);
		((Component)val34).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val34).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val34);
		ProjectileData baseData97 = val34.baseData;
		baseData97.damage *= 0.8f;
		ProjectileData baseData98 = val34.baseData;
		baseData98.range *= 3f;
		ProjectileData baseData99 = val34.baseData;
		baseData99.speed *= 0.5f;
		val34.SetProjectileSprite("genericspades_projectile", 14, 11, lightened: true, (Anchor)4, 7, 7, anchorChangesCollider: true, fixesScale: false, null, null);
		DesignateType(val34, HandGunCardBullet.CardSuit.SPADES, HandGunCardBullet.CardValue.GENERIC);
		PickupObject byId35 = PickupObjectDatabase.GetById(56);
		Projectile val35 = Object.Instantiate<Projectile>(((Gun)((byId35 is Gun) ? byId35 : null)).DefaultModule.projectiles[0]);
		((Component)val35).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val35).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val35);
		ProjectileData baseData100 = val35.baseData;
		baseData100.damage *= 1f;
		ProjectileData baseData101 = val35.baseData;
		baseData101.range *= 3f;
		ProjectileData baseData102 = val35.baseData;
		baseData102.speed *= 0.5f;
		val35.SetProjectileSprite("genericspades_projectile", 14, 11, lightened: true, (Anchor)4, 7, 7, anchorChangesCollider: true, fixesScale: false, null, null);
		DesignateType(val35, HandGunCardBullet.CardSuit.SPADES, HandGunCardBullet.CardValue.GENERIC);
		PickupObject byId36 = PickupObjectDatabase.GetById(56);
		Projectile val36 = Object.Instantiate<Projectile>(((Gun)((byId36 is Gun) ? byId36 : null)).DefaultModule.projectiles[0]);
		((Component)val36).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val36).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val36);
		ProjectileData baseData103 = val36.baseData;
		baseData103.damage *= 1.2f;
		ProjectileData baseData104 = val36.baseData;
		baseData104.range *= 3f;
		ProjectileData baseData105 = val36.baseData;
		baseData105.speed *= 0.5f;
		val36.SetProjectileSprite("genericspades_projectile", 14, 11, lightened: true, (Anchor)4, 7, 7, anchorChangesCollider: true, fixesScale: false, null, null);
		DesignateType(val36, HandGunCardBullet.CardSuit.SPADES, HandGunCardBullet.CardValue.GENERIC);
		PickupObject byId37 = PickupObjectDatabase.GetById(56);
		Projectile val37 = Object.Instantiate<Projectile>(((Gun)((byId37 is Gun) ? byId37 : null)).DefaultModule.projectiles[0]);
		((Component)val37).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val37).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val37);
		ProjectileData baseData106 = val37.baseData;
		baseData106.damage *= 1.4f;
		ProjectileData baseData107 = val37.baseData;
		baseData107.range *= 3f;
		ProjectileData baseData108 = val37.baseData;
		baseData108.speed *= 0.5f;
		val37.SetProjectileSprite("genericspades_projectile", 14, 11, lightened: true, (Anchor)4, 7, 7, anchorChangesCollider: true, fixesScale: false, null, null);
		DesignateType(val37, HandGunCardBullet.CardSuit.SPADES, HandGunCardBullet.CardValue.GENERIC);
		PickupObject byId38 = PickupObjectDatabase.GetById(56);
		Projectile val38 = Object.Instantiate<Projectile>(((Gun)((byId38 is Gun) ? byId38 : null)).DefaultModule.projectiles[0]);
		((Component)val38).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val38).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val38);
		ProjectileData baseData109 = val38.baseData;
		baseData109.damage *= 1.6f;
		ProjectileData baseData110 = val38.baseData;
		baseData110.range *= 3f;
		ProjectileData baseData111 = val38.baseData;
		baseData111.speed *= 0.5f;
		val38.SetProjectileSprite("genericspades_projectile", 14, 11, lightened: true, (Anchor)4, 7, 7, anchorChangesCollider: true, fixesScale: false, null, null);
		DesignateType(val38, HandGunCardBullet.CardSuit.SPADES, HandGunCardBullet.CardValue.GENERIC);
		PickupObject byId39 = PickupObjectDatabase.GetById(56);
		Projectile val39 = Object.Instantiate<Projectile>(((Gun)((byId39 is Gun) ? byId39 : null)).DefaultModule.projectiles[0]);
		((Component)val39).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val39).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val39);
		ProjectileData baseData112 = val39.baseData;
		baseData112.damage *= 1.8f;
		ProjectileData baseData113 = val39.baseData;
		baseData113.range *= 3f;
		ProjectileData baseData114 = val39.baseData;
		baseData114.speed *= 0.5f;
		val39.SetProjectileSprite("genericspades_projectile", 14, 11, lightened: true, (Anchor)4, 7, 7, anchorChangesCollider: true, fixesScale: false, null, null);
		DesignateType(val39, HandGunCardBullet.CardSuit.SPADES, HandGunCardBullet.CardValue.GENERIC);
		PickupObject byId40 = PickupObjectDatabase.GetById(56);
		Projectile val40 = Object.Instantiate<Projectile>(((Gun)((byId40 is Gun) ? byId40 : null)).DefaultModule.projectiles[0]);
		((Component)val40).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val40).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val40);
		ProjectileData baseData115 = val40.baseData;
		baseData115.damage *= 2f;
		ProjectileData baseData116 = val40.baseData;
		baseData116.range *= 3f;
		ProjectileData baseData117 = val40.baseData;
		baseData117.speed *= 0.5f;
		val40.SetProjectileSprite("genericspades_projectile", 14, 11, lightened: true, (Anchor)4, 7, 7, anchorChangesCollider: true, fixesScale: false, null, null);
		DesignateType(val40, HandGunCardBullet.CardSuit.SPADES, HandGunCardBullet.CardValue.GENERIC);
		PickupObject byId41 = PickupObjectDatabase.GetById(56);
		Projectile val41 = Object.Instantiate<Projectile>(((Gun)((byId41 is Gun) ? byId41 : null)).DefaultModule.projectiles[0]);
		((Component)val41).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val41).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val41);
		ProjectileData baseData118 = val41.baseData;
		baseData118.damage *= 4f;
		ProjectileData baseData119 = val41.baseData;
		baseData119.range *= 3f;
		ProjectileData baseData120 = val41.baseData;
		baseData120.speed *= 0.5f;
		val41.SetProjectileSprite("aceofclubs_projectile", 15, 17, lightened: true, (Anchor)4, 10, 9, anchorChangesCollider: true, fixesScale: false, null, null);
		DesignateType(val41, HandGunCardBullet.CardSuit.CLUBS, HandGunCardBullet.CardValue.ACE);
		PickupObject byId42 = PickupObjectDatabase.GetById(56);
		Projectile val42 = Object.Instantiate<Projectile>(((Gun)((byId42 is Gun) ? byId42 : null)).DefaultModule.projectiles[0]);
		((Component)val42).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val42).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val42);
		ProjectileData baseData121 = val42.baseData;
		baseData121.damage *= 2.4f;
		ProjectileData baseData122 = val42.baseData;
		baseData122.range *= 3f;
		ProjectileData baseData123 = val42.baseData;
		baseData123.speed *= 0.5f;
		HomingModifier orAddComponent13 = GameObjectExtensions.GetOrAddComponent<HomingModifier>(((Component)val42).gameObject);
		orAddComponent13.HomingRadius = 100f;
		val42.SetProjectileSprite("queenofclubs_projectile", 15, 17, lightened: true, (Anchor)4, 10, 9, anchorChangesCollider: true, fixesScale: false, null, null);
		DesignateType(val42, HandGunCardBullet.CardSuit.CLUBS, HandGunCardBullet.CardValue.QUEEN);
		PickupObject byId43 = PickupObjectDatabase.GetById(56);
		Projectile val43 = Object.Instantiate<Projectile>(((Gun)((byId43 is Gun) ? byId43 : null)).DefaultModule.projectiles[0]);
		((Component)val43).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val43).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val43);
		ProjectileData baseData124 = val43.baseData;
		baseData124.damage *= 2.6f;
		ProjectileData baseData125 = val43.baseData;
		baseData125.range *= 3f;
		ProjectileData baseData126 = val43.baseData;
		baseData126.speed *= 0.5f;
		PierceProjModifier orAddComponent14 = GameObjectExtensions.GetOrAddComponent<PierceProjModifier>(((Component)val43).gameObject);
		orAddComponent14.penetration += 5;
		BounceProjModifier orAddComponent15 = GameObjectExtensions.GetOrAddComponent<BounceProjModifier>(((Component)val43).gameObject);
		orAddComponent15.numberOfBounces += 5;
		val43.SetProjectileSprite("kingofclubs_projectile", 15, 17, lightened: true, (Anchor)4, 10, 9, anchorChangesCollider: true, fixesScale: false, null, null);
		DesignateType(val43, HandGunCardBullet.CardSuit.CLUBS, HandGunCardBullet.CardValue.KING);
		PickupObject byId44 = PickupObjectDatabase.GetById(56);
		Projectile val44 = Object.Instantiate<Projectile>(((Gun)((byId44 is Gun) ? byId44 : null)).DefaultModule.projectiles[0]);
		((Component)val44).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val44).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val44);
		PlayerProjectileTeleportModifier orAddComponent16 = GameObjectExtensions.GetOrAddComponent<PlayerProjectileTeleportModifier>(((Component)val44).gameObject);
		ProjectileData baseData127 = val44.baseData;
		baseData127.damage *= 2.2f;
		ProjectileData baseData128 = val44.baseData;
		baseData128.range *= 4f;
		ProjectileData baseData129 = val44.baseData;
		baseData129.speed *= 0.5f;
		val44.SetProjectileSprite("knaveofclubs_projectile", 15, 15, lightened: true, (Anchor)4, 10, 9, anchorChangesCollider: true, fixesScale: false, null, null);
		DesignateType(val44, HandGunCardBullet.CardSuit.CLUBS, HandGunCardBullet.CardValue.KNAVE);
		PickupObject byId45 = PickupObjectDatabase.GetById(56);
		Projectile val45 = Object.Instantiate<Projectile>(((Gun)((byId45 is Gun) ? byId45 : null)).DefaultModule.projectiles[0]);
		((Component)val45).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val45).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val45);
		ProjectileData baseData130 = val45.baseData;
		baseData130.damage *= 0.4f;
		ProjectileData baseData131 = val45.baseData;
		baseData131.range *= 3f;
		ProjectileData baseData132 = val45.baseData;
		baseData132.speed *= 0.5f;
		val45.SetProjectileSprite("genericclubs_projectile", 15, 15, lightened: true, (Anchor)4, 10, 9, anchorChangesCollider: true, fixesScale: false, null, null);
		DesignateType(val45, HandGunCardBullet.CardSuit.CLUBS, HandGunCardBullet.CardValue.GENERIC);
		PickupObject byId46 = PickupObjectDatabase.GetById(56);
		Projectile val46 = Object.Instantiate<Projectile>(((Gun)((byId46 is Gun) ? byId46 : null)).DefaultModule.projectiles[0]);
		((Component)val46).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val46).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val46);
		ProjectileData baseData133 = val46.baseData;
		baseData133.damage *= 0.6f;
		ProjectileData baseData134 = val46.baseData;
		baseData134.range *= 3f;
		ProjectileData baseData135 = val46.baseData;
		baseData135.speed *= 0.5f;
		val46.SetProjectileSprite("genericclubs_projectile", 15, 15, lightened: true, (Anchor)4, 10, 9, anchorChangesCollider: true, fixesScale: false, null, null);
		DesignateType(val46, HandGunCardBullet.CardSuit.CLUBS, HandGunCardBullet.CardValue.GENERIC);
		PickupObject byId47 = PickupObjectDatabase.GetById(56);
		Projectile val47 = Object.Instantiate<Projectile>(((Gun)((byId47 is Gun) ? byId47 : null)).DefaultModule.projectiles[0]);
		((Component)val47).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val47).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val47);
		ProjectileData baseData136 = val47.baseData;
		baseData136.damage *= 0.8f;
		ProjectileData baseData137 = val47.baseData;
		baseData137.range *= 3f;
		ProjectileData baseData138 = val47.baseData;
		baseData138.speed *= 0.5f;
		val47.SetProjectileSprite("genericclubs_projectile", 15, 15, lightened: true, (Anchor)4, 10, 9, anchorChangesCollider: true, fixesScale: false, null, null);
		DesignateType(val47, HandGunCardBullet.CardSuit.CLUBS, HandGunCardBullet.CardValue.GENERIC);
		PickupObject byId48 = PickupObjectDatabase.GetById(56);
		Projectile val48 = Object.Instantiate<Projectile>(((Gun)((byId48 is Gun) ? byId48 : null)).DefaultModule.projectiles[0]);
		((Component)val48).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val48).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val48);
		ProjectileData baseData139 = val48.baseData;
		baseData139.damage *= 1f;
		ProjectileData baseData140 = val48.baseData;
		baseData140.range *= 3f;
		ProjectileData baseData141 = val48.baseData;
		baseData141.speed *= 0.5f;
		val48.SetProjectileSprite("genericclubs_projectile", 15, 15, lightened: true, (Anchor)4, 10, 9, anchorChangesCollider: true, fixesScale: false, null, null);
		DesignateType(val48, HandGunCardBullet.CardSuit.CLUBS, HandGunCardBullet.CardValue.GENERIC);
		PickupObject byId49 = PickupObjectDatabase.GetById(56);
		Projectile val49 = Object.Instantiate<Projectile>(((Gun)((byId49 is Gun) ? byId49 : null)).DefaultModule.projectiles[0]);
		((Component)val49).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val49).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val49);
		ProjectileData baseData142 = val49.baseData;
		baseData142.damage *= 1.2f;
		ProjectileData baseData143 = val49.baseData;
		baseData143.range *= 3f;
		ProjectileData baseData144 = val49.baseData;
		baseData144.speed *= 0.5f;
		val49.SetProjectileSprite("genericclubs_projectile", 15, 15, lightened: true, (Anchor)4, 10, 9, anchorChangesCollider: true, fixesScale: false, null, null);
		DesignateType(val49, HandGunCardBullet.CardSuit.CLUBS, HandGunCardBullet.CardValue.GENERIC);
		PickupObject byId50 = PickupObjectDatabase.GetById(56);
		Projectile val50 = Object.Instantiate<Projectile>(((Gun)((byId50 is Gun) ? byId50 : null)).DefaultModule.projectiles[0]);
		((Component)val50).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val50).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val50);
		ProjectileData baseData145 = val50.baseData;
		baseData145.damage *= 1.4f;
		ProjectileData baseData146 = val50.baseData;
		baseData146.range *= 3f;
		ProjectileData baseData147 = val50.baseData;
		baseData147.speed *= 0.5f;
		val50.SetProjectileSprite("genericclubs_projectile", 15, 15, lightened: true, (Anchor)4, 10, 9, anchorChangesCollider: true, fixesScale: false, null, null);
		DesignateType(val50, HandGunCardBullet.CardSuit.CLUBS, HandGunCardBullet.CardValue.GENERIC);
		PickupObject byId51 = PickupObjectDatabase.GetById(56);
		Projectile val51 = Object.Instantiate<Projectile>(((Gun)((byId51 is Gun) ? byId51 : null)).DefaultModule.projectiles[0]);
		((Component)val51).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val51).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val51);
		ProjectileData baseData148 = val51.baseData;
		baseData148.damage *= 1.6f;
		ProjectileData baseData149 = val51.baseData;
		baseData149.range *= 3f;
		ProjectileData baseData150 = val51.baseData;
		baseData150.speed *= 0.5f;
		val51.SetProjectileSprite("genericclubs_projectile", 15, 15, lightened: true, (Anchor)4, 10, 9, anchorChangesCollider: true, fixesScale: false, null, null);
		DesignateType(val51, HandGunCardBullet.CardSuit.CLUBS, HandGunCardBullet.CardValue.GENERIC);
		PickupObject byId52 = PickupObjectDatabase.GetById(56);
		Projectile val52 = Object.Instantiate<Projectile>(((Gun)((byId52 is Gun) ? byId52 : null)).DefaultModule.projectiles[0]);
		((Component)val52).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val52).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val52);
		ProjectileData baseData151 = val52.baseData;
		baseData151.damage *= 1.8f;
		ProjectileData baseData152 = val52.baseData;
		baseData152.range *= 3f;
		ProjectileData baseData153 = val52.baseData;
		baseData153.speed *= 0.5f;
		val52.SetProjectileSprite("genericclubs_projectile", 15, 15, lightened: true, (Anchor)4, 10, 9, anchorChangesCollider: true, fixesScale: false, null, null);
		DesignateType(val52, HandGunCardBullet.CardSuit.CLUBS, HandGunCardBullet.CardValue.GENERIC);
		PickupObject byId53 = PickupObjectDatabase.GetById(56);
		Projectile val53 = Object.Instantiate<Projectile>(((Gun)((byId53 is Gun) ? byId53 : null)).DefaultModule.projectiles[0]);
		((Component)val53).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val53).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val53);
		ProjectileData baseData154 = val53.baseData;
		baseData154.damage *= 2f;
		ProjectileData baseData155 = val53.baseData;
		baseData155.range *= 3f;
		ProjectileData baseData156 = val53.baseData;
		baseData156.speed *= 0.5f;
		val53.SetProjectileSprite("genericclubs_projectile", 15, 15, lightened: true, (Anchor)4, 10, 9, anchorChangesCollider: true, fixesScale: false, null, null);
		DesignateType(val53, HandGunCardBullet.CardSuit.CLUBS, HandGunCardBullet.CardValue.GENERIC);
		val.DefaultModule.projectiles[0] = val2;
		val.DefaultModule.projectiles.Add(val6);
		val.DefaultModule.projectiles.Add(val7);
		val.DefaultModule.projectiles.Add(val8);
		val.DefaultModule.projectiles.Add(val9);
		val.DefaultModule.projectiles.Add(val10);
		val.DefaultModule.projectiles.Add(val11);
		val.DefaultModule.projectiles.Add(val12);
		val.DefaultModule.projectiles.Add(val13);
		val.DefaultModule.projectiles.Add(val14);
		val.DefaultModule.projectiles.Add(val5);
		val.DefaultModule.projectiles.Add(val3);
		val.DefaultModule.projectiles.Add(val4);
		val.DefaultModule.projectiles.Add(val15);
		val.DefaultModule.projectiles.Add(val19);
		val.DefaultModule.projectiles.Add(val20);
		val.DefaultModule.projectiles.Add(val21);
		val.DefaultModule.projectiles.Add(val22);
		val.DefaultModule.projectiles.Add(val23);
		val.DefaultModule.projectiles.Add(val24);
		val.DefaultModule.projectiles.Add(val25);
		val.DefaultModule.projectiles.Add(val26);
		val.DefaultModule.projectiles.Add(val27);
		val.DefaultModule.projectiles.Add(val18);
		val.DefaultModule.projectiles.Add(val16);
		val.DefaultModule.projectiles.Add(val17);
		val.DefaultModule.projectiles.Add(val28);
		val.DefaultModule.projectiles.Add(val32);
		val.DefaultModule.projectiles.Add(val33);
		val.DefaultModule.projectiles.Add(val34);
		val.DefaultModule.projectiles.Add(val35);
		val.DefaultModule.projectiles.Add(val36);
		val.DefaultModule.projectiles.Add(val37);
		val.DefaultModule.projectiles.Add(val38);
		val.DefaultModule.projectiles.Add(val39);
		val.DefaultModule.projectiles.Add(val40);
		val.DefaultModule.projectiles.Add(val31);
		val.DefaultModule.projectiles.Add(val29);
		val.DefaultModule.projectiles.Add(val30);
		val.DefaultModule.projectiles.Add(val41);
		val.DefaultModule.projectiles.Add(val45);
		val.DefaultModule.projectiles.Add(val46);
		val.DefaultModule.projectiles.Add(val47);
		val.DefaultModule.projectiles.Add(val48);
		val.DefaultModule.projectiles.Add(val49);
		val.DefaultModule.projectiles.Add(val50);
		val.DefaultModule.projectiles.Add(val51);
		val.DefaultModule.projectiles.Add(val52);
		val.DefaultModule.projectiles.Add(val53);
		val.DefaultModule.projectiles.Add(val44);
		val.DefaultModule.projectiles.Add(val42);
		val.DefaultModule.projectiles.Add(val43);
		val.DefaultModule.ammoType = (AmmoType)14;
		val.DefaultModule.customAmmoType = CustomClipAmmoTypeToolbox.AddCustomAmmoType("Hand Gun Bullets", "NevernamedsItems/Resources/CustomGunAmmoTypes/handgun_clipfull", "NevernamedsItems/Resources/CustomGunAmmoTypes/handgun_clipempty");
		((PickupObject)val).quality = (ItemQuality)2;
		Databases.Items.Add(val, (tk2dSpriteCollectionData)null, "ANY");
		HandGunID = ((PickupObject)val).PickupObjectId;
	}

	public static void DesignateType(Projectile projectile, HandGunCardBullet.CardSuit Suit, HandGunCardBullet.CardValue Value)
	{
		HandGunCardBullet orAddComponent = GameObjectExtensions.GetOrAddComponent<HandGunCardBullet>(((Component)projectile).gameObject);
		orAddComponent.Suit = Suit;
		orAddComponent.Value = Value;
	}

	public override void PostProcessProjectile(Projectile projectile)
	{
		HandGunCardBullet component = ((Component)projectile).gameObject.GetComponent<HandGunCardBullet>();
		if (projectile.Owner is PlayerController && (Object)(object)component != (Object)null)
		{
			GameActor owner = projectile.Owner;
			PlayerController val = (PlayerController)(object)((owner is PlayerController) ? owner : null);
			if (CustomSynergies.PlayerHasActiveSynergy(val, "Suicide King"))
			{
				ProjectileData baseData = projectile.baseData;
				baseData.damage *= 2f;
				ProjectileInstakillBehaviour orAddComponent = GameObjectExtensions.GetOrAddComponent<ProjectileInstakillBehaviour>(((Component)projectile).gameObject);
				orAddComponent.tagsToKill.Add("royalty");
				if (component.Suit == HandGunCardBullet.CardSuit.HEARTS && component.Value == HandGunCardBullet.CardValue.KING)
				{
					ProjectileData baseData2 = projectile.baseData;
					baseData2.damage *= 2f;
					projectile.ignoreDamageCaps = true;
				}
			}
			if (CustomSynergies.PlayerHasActiveSynergy(val, "Girls Best Friend") && component.Suit == HandGunCardBullet.CardSuit.DIAMONDS)
			{
				ProjectileData baseData3 = projectile.baseData;
				baseData3.damage *= 2f;
				ProjectileData baseData4 = projectile.baseData;
				baseData4.damage *= 0.003f * (float)val.carriedConsumables.Currency + 1f;
			}
			if (CustomSynergies.PlayerHasActiveSynergy(val, "Have A Heart") && component.Suit == HandGunCardBullet.CardSuit.HEARTS)
			{
				ProjectileData baseData5 = projectile.baseData;
				baseData5.damage *= 2f;
				if (!val.ForceZeroHealthState)
				{
					ProjectileData baseData6 = projectile.baseData;
					baseData6.damage *= 0.025f * ((BraveBehaviour)val).healthHaver.GetCurrentHealth() + 1f;
				}
				else
				{
					ProjectileData baseData7 = projectile.baseData;
					baseData7.damage *= 0.025f * ((BraveBehaviour)val).healthHaver.Armor + 1f;
				}
			}
			if (CustomSynergies.PlayerHasActiveSynergy(val, "Dig Deep") && component.Suit == HandGunCardBullet.CardSuit.SPADES)
			{
				ProjectileData baseData8 = projectile.baseData;
				baseData8.damage *= 2f;
				ProjectileData baseData9 = projectile.baseData;
				baseData9.damage *= 0.07f * (float)val.carriedConsumables.KeyBullets + 1f;
			}
			if (CustomSynergies.PlayerHasActiveSynergy(val, "Going Clubbing") && component.Suit == HandGunCardBullet.CardSuit.CLUBS)
			{
				ProjectileData baseData10 = projectile.baseData;
				baseData10.damage *= 2f;
				ProjectileData baseData11 = projectile.baseData;
				baseData11.damage *= 0.07f * (float)val.Blanks + 1f;
			}
		}
		((AdvancedGunBehavior)this).PostProcessProjectile(projectile);
	}

	private void modifyDamage(HealthHaver player, ModifyDamageEventArgs data)
	{
		if (Object.op_Implicit((Object)(object)base.gun.CurrentOwner) && base.gun.CurrentOwner is PlayerController && (Object)(object)((BraveBehaviour)base.gun.CurrentOwner).healthHaver == (Object)(object)player && CustomSynergies.PlayerHasActiveSynergy((PlayerController)/*isinst with value type is only supported in some contexts*/, "Suicide King") && (Object)(object)base.gun.CurrentOwner.CurrentGun == (Object)(object)base.gun)
		{
			data.ModifiedDamage = data.InitialDamage * 3f;
		}
	}

	protected override void OnPickedUpByPlayer(PlayerController player)
	{
		HealthHaver healthHaver = ((BraveBehaviour)player).healthHaver;
		healthHaver.ModifyDamage = (Action<HealthHaver, ModifyDamageEventArgs>)Delegate.Combine(healthHaver.ModifyDamage, new Action<HealthHaver, ModifyDamageEventArgs>(modifyDamage));
		((AdvancedGunBehavior)this).OnPickedUpByPlayer(player);
	}

	protected override void OnPostDroppedByPlayer(PlayerController player)
	{
		HealthHaver healthHaver = ((BraveBehaviour)player).healthHaver;
		healthHaver.ModifyDamage = (Action<HealthHaver, ModifyDamageEventArgs>)Delegate.Remove(healthHaver.ModifyDamage, new Action<HealthHaver, ModifyDamageEventArgs>(modifyDamage));
		((AdvancedGunBehavior)this).OnPostDroppedByPlayer(player);
	}

	public override void OnDestroy()
	{
		if (Object.op_Implicit((Object)(object)base.gun.CurrentOwner) && base.gun.CurrentOwner is PlayerController)
		{
			GameActor currentOwner = base.gun.CurrentOwner;
			HealthHaver healthHaver = ((BraveBehaviour)((currentOwner is PlayerController) ? currentOwner : null)).healthHaver;
			healthHaver.ModifyDamage = (Action<HealthHaver, ModifyDamageEventArgs>)Delegate.Remove(healthHaver.ModifyDamage, new Action<HealthHaver, ModifyDamageEventArgs>(modifyDamage));
		}
		((BraveBehaviour)this).OnDestroy();
	}

	public override void OnReloadPressedSafe(PlayerController player, Gun gun, bool manualReload)
	{
		//IL_01ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b6: Unknown result type (might be due to invalid IL or missing references)
		if (gun.ClipShotsRemaining == gun.ClipCapacity && gun.CurrentAmmo > 15 && CustomSynergies.PlayerHasActiveSynergy(player, "Royal Flush"))
		{
			int num = Random.Range(1, 5);
			List<int> list = new List<int>();
			switch (num)
			{
			case 1:
				list.AddRange(new List<int> { 0, 9, 10, 11, 12 });
				break;
			case 2:
				list.AddRange(new List<int> { 13, 22, 23, 24, 25 });
				break;
			case 3:
				list.AddRange(new List<int> { 26, 35, 36, 37, 38 });
				break;
			case 4:
				list.AddRange(new List<int> { 39, 48, 49, 50, 51 });
				break;
			}
			if (list.Count > 0)
			{
				gun.CurrentAmmo -= 15;
				foreach (int item in list)
				{
					GameObject val = ProjSpawnHelper.SpawnProjectileTowardsPoint(((Component)gun.DefaultModule.projectiles[item]).gameObject, ((GameActor)player).CenterPosition, Vector2.op_Implicit(player.unadjustedAimPoint), 0f, 40f, player);
					Projectile component = val.GetComponent<Projectile>();
					if ((Object)(object)component != (Object)null)
					{
						component.Owner = (GameActor)(object)player;
						component.Shooter = ((BraveBehaviour)player).specRigidbody;
						ProjectileData baseData = component.baseData;
						baseData.damage *= player.stats.GetStatValue((StatType)5);
						component.BossDamageMultiplier *= player.stats.GetStatValue((StatType)22);
						ProjectileData baseData2 = component.baseData;
						baseData2.speed *= player.stats.GetStatValue((StatType)6);
						component.AdditionalScaleMultiplier *= player.stats.GetStatValue((StatType)15);
						ProjectileData baseData3 = component.baseData;
						baseData3.range *= player.stats.GetStatValue((StatType)26);
						ProjectileData baseData4 = component.baseData;
						baseData4.force *= player.stats.GetStatValue((StatType)12);
						player.DoPostProcessProjectile(component);
					}
				}
			}
		}
		((AdvancedGunBehavior)this).OnReloadPressedSafe(player, gun, manualReload);
	}
}
