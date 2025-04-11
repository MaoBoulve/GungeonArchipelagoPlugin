using System;
using Alexandria.Assetbundle;
using Alexandria.ItemAPI;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class Lantaka : GunBehaviour
{
	public static int LantakaID;

	private GameActorFireEffect fireEffect = ((Component)Game.Items["hot_lead"]).GetComponent<BulletStatusEffectItem>().FireModifierEffect;

	public static void Add()
	{
		//IL_00cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_011d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0137: Unknown result type (might be due to invalid IL or missing references)
		//IL_0276: Unknown result type (might be due to invalid IL or missing references)
		//IL_029c: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Lantaka", "lantaka");
		Game.Items.Rename("outdated_gun_mods:lantaka", "nn:lantaka");
		((Component)val).gameObject.AddComponent<Lantaka>();
		GunExt.SetShortDescription((PickupObject)(object)val, "Head on a Swivel");
		GunExt.SetLongDescription((PickupObject)(object)val, "Used once upon a time by ships to protect against pirates, this ancient gun sat in the back room of a museum for many years until a daring heist saw it make it's way to the Gungeon.");
		GunInt.SetupSprite(val, Initialisation.gunCollection, "lantaka_idle_001", 8, "lantaka_ammonomicon_001");
		GunExt.SetAnimationFPS(val, val.shootAnimation, 15);
		ref string gunSwitchGroup = ref val.gunSwitchGroup;
		PickupObject byId = PickupObjectDatabase.GetById(49);
		gunSwitchGroup = ((Gun)((byId is Gun) ? byId : null)).gunSwitchGroup;
		ref VFXPool muzzleFlashEffects = ref val.muzzleFlashEffects;
		PickupObject byId2 = PickupObjectDatabase.GetById(9);
		muzzleFlashEffects = ((Gun)((byId2 is Gun) ? byId2 : null)).muzzleFlashEffects;
		PickupObject byId3 = PickupObjectDatabase.GetById(86);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId3 is Gun) ? byId3 : null), true, false);
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.shootStyle = (ShootStyle)0;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 1f;
		val.DefaultModule.cooldownTime = 1f;
		val.DefaultModule.numberOfShotsInClip = 1;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(2.56f, 0.81f, 0f);
		val.SetBaseMaxAmmo(150);
		val.gunClass = (GunClass)15;
		Projectile val2 = Object.Instantiate<Projectile>(val.DefaultModule.projectiles[0]);
		((Component)val2).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val2).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val2);
		val.DefaultModule.projectiles[0] = val2;
		((BraveBehaviour)val2).transform.parent = val.barrelOffset;
		ProjectileData baseData = val2.baseData;
		baseData.speed *= 2f;
		ProjectileData baseData2 = val2.baseData;
		baseData2.range *= 2f;
		ProjectileData baseData3 = val2.baseData;
		baseData3.damage *= 4f;
		val2.BossDamageMultiplier *= 1.5f;
		val2.BlackPhantomDamageMultiplier *= 2f;
		PierceProjModifier orAddComponent = GameObjectExtensions.GetOrAddComponent<PierceProjModifier>(((Component)val2).gameObject);
		orAddComponent.penetratesBreakables = true;
		orAddComponent.penetration += 10;
		BounceProjModifier orAddComponent2 = GameObjectExtensions.GetOrAddComponent<BounceProjModifier>(((Component)val2).gameObject);
		orAddComponent2.numberOfBounces = 2;
		val2.SetProjectileSprite("lantaka_projectile", 15, 15, lightened: false, (Anchor)4, 14, 14, anchorChangesCollider: true, fixesScale: false, null, null);
		val.DefaultModule.ammoType = (AmmoType)14;
		val.DefaultModule.customAmmoType = CustomClipAmmoTypeToolbox.AddCustomAmmoType("Lantaka Bullets", "NevernamedsItems/Resources/CustomGunAmmoTypes/lantaka_clipfull", "NevernamedsItems/Resources/CustomGunAmmoTypes/lantaka_clipempty");
		((PickupObject)val).quality = (ItemQuality)2;
		((BraveBehaviour)val).encounterTrackable.EncounterGuid = "this is the Lantaka";
		Databases.Items.Add(val, (tk2dSpriteCollectionData)null, "ANY");
		LantakaID = ((PickupObject)val).PickupObjectId;
	}

	public override void PostProcessProjectile(Projectile projectile)
	{
		((GunBehaviour)this).PostProcessProjectile(projectile);
		GameActor owner = projectile.Owner;
		PlayerController val = (PlayerController)(object)((owner is PlayerController) ? owner : null);
		if (CustomSynergies.PlayerHasActiveSynergy(val, "Brothers in Copper"))
		{
			projectile.OnHitEnemy = (Action<Projectile, SpeculativeRigidbody, bool>)Delegate.Combine(projectile.OnHitEnemy, new Action<Projectile, SpeculativeRigidbody, bool>(applyFire));
		}
	}

	private void applyFire(Projectile bullet, SpeculativeRigidbody enemy, bool fatal)
	{
		((BraveBehaviour)enemy).gameActor.ApplyEffect((GameActorEffect)(object)fireEffect, 1f, (Projectile)null);
	}
}
