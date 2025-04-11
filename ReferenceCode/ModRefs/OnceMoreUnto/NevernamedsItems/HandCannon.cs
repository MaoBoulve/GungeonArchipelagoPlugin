using System;
using System.Reflection;
using Alexandria.Assetbundle;
using Alexandria.ItemAPI;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class HandCannon : GunBehaviour
{
	public static int HandCannonID;

	public static void Add()
	{
		//IL_009d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0115: Unknown result type (might be due to invalid IL or missing references)
		//IL_025c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0299: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Hand Cannon", "handcannon");
		Game.Items.Rename("outdated_gun_mods:hand_cannon", "nn:hand_cannon");
		((Component)val).gameObject.AddComponent<HandCannon>();
		GunExt.SetShortDescription((PickupObject)(object)val, "Protogun");
		GunExt.SetLongDescription((PickupObject)(object)val, "The earliest recorded type of real firearm. Though it is little more than a small cannon on a stick, it can spit some damaging shrapnel.");
		GunInt.SetupSprite(val, Initialisation.gunCollection, "handcannon_idle_001", 8, "handcannon_ammonomicon_001");
		GunExt.SetAnimationFPS(val, val.shootAnimation, 15);
		PickupObject byId = PickupObjectDatabase.GetById(86);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId is Gun) ? byId : null), true, false);
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.shootStyle = (ShootStyle)0;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 2.5f;
		val.DefaultModule.cooldownTime = 1f;
		val.muzzleFlashEffects.type = (VFXPoolType)0;
		val.DefaultModule.numberOfShotsInClip = 1;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(2.87f, 0.5f, 0f);
		val.SetBaseMaxAmmo(190);
		val.gunClass = (GunClass)55;
		Projectile val2 = Object.Instantiate<Projectile>(val.DefaultModule.projectiles[0]);
		((Component)val2).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val2).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val2);
		val.DefaultModule.projectiles[0] = val2;
		ProjectileData baseData = val2.baseData;
		baseData.damage *= 7f;
		PierceProjModifier orAddComponent = GameObjectExtensions.GetOrAddComponent<PierceProjModifier>(((Component)val2).gameObject);
		orAddComponent.penetratesBreakables = true;
		orAddComponent.penetration += 10;
		BounceProjModifier orAddComponent2 = GameObjectExtensions.GetOrAddComponent<BounceProjModifier>(((Component)val2).gameObject);
		orAddComponent2.numberOfBounces = 10;
		ProjectileData baseData2 = val2.baseData;
		baseData2.range *= 0.5f;
		((BraveBehaviour)val2).transform.parent = val.barrelOffset;
		val2.SetProjectileSprite("handcannon_projectile", 17, 15, lightened: false, (Anchor)4, 15, 13, anchorChangesCollider: true, fixesScale: false, null, null);
		ref GameObject overrideMidairDeathVFX = ref val2.hitEffects.overrideMidairDeathVFX;
		PickupObject byId2 = PickupObjectDatabase.GetById(37);
		overrideMidairDeathVFX = ((Gun)((byId2 is Gun) ? byId2 : null)).DefaultModule.chargeProjectiles[0].Projectile.hitEffects.overrideMidairDeathVFX;
		val2.hitEffects.alwaysUseMidair = true;
		val.DefaultModule.ammoType = (AmmoType)14;
		val.DefaultModule.customAmmoType = CustomClipAmmoTypeToolbox.AddCustomAmmoType("HandCannon Bullets", "NevernamedsItems/Resources/CustomGunAmmoTypes/handcannon_clipfull", "NevernamedsItems/Resources/CustomGunAmmoTypes/handcannon_clipempty");
		ref VFXPool muzzleFlashEffects = ref val.muzzleFlashEffects;
		PickupObject byId3 = PickupObjectDatabase.GetById(53);
		muzzleFlashEffects = ((Gun)((byId3 is Gun) ? byId3 : null)).muzzleFlashEffects;
		((PickupObject)val).quality = (ItemQuality)1;
		((BraveBehaviour)val).encounterTrackable.EncounterGuid = "this is the Hand Cannon";
		Databases.Items.Add(val, (tk2dSpriteCollectionData)null, "ANY");
		HandCannonID = ((PickupObject)val).PickupObjectId;
	}

	public override void PostProcessProjectile(Projectile projectile)
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Expected O, but got Unknown
		((GunBehaviour)this).PostProcessProjectile(projectile);
		GameActor owner = projectile.Owner;
		PlayerController val = (PlayerController)(object)((owner is PlayerController) ? owner : null);
		SpeculativeRigidbody specRigidbody = ((BraveBehaviour)projectile).specRigidbody;
		specRigidbody.OnPreRigidbodyCollision = (OnPreRigidbodyCollisionDelegate)Delegate.Combine((Delegate)(object)specRigidbody.OnPreRigidbodyCollision, (Delegate)new OnPreRigidbodyCollisionDelegate(HandlePierce));
		if (CustomSynergies.PlayerHasActiveSynergy(val, "Good Old Guns"))
		{
			ProjectileData baseData = projectile.baseData;
			baseData.damage *= 1.5f;
			ProjectileData baseData2 = projectile.baseData;
			baseData2.range *= 3f;
		}
	}

	private void HandlePierce(SpeculativeRigidbody myRigidbody, PixelCollider myPixelCollider, SpeculativeRigidbody otherRigidbody, PixelCollider otherPixelCollider)
	{
		FieldInfo field = typeof(Projectile).GetField("m_hasPierced", BindingFlags.Instance | BindingFlags.NonPublic);
		field.SetValue(((BraveBehaviour)myRigidbody).projectile, false);
	}

	public override void OnPostFired(PlayerController player, Gun gun)
	{
		gun.PreventNormalFireAudio = true;
		AkSoundEngine.PostEvent("Play_WPN_seriouscannon_shot_01", ((Component)this).gameObject);
	}
}
