using Alexandria.ItemAPI;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class HandMortar : GunBehaviour
{
	public static int ID;

	private static ExplosionData bigExplosion = GameManager.Instance.Dungeon.sharedSettingsPrefab.DefaultExplosionData;

	private static ExplosionData HandMortarExplosion = new ExplosionData
	{
		effect = bigExplosion.effect,
		ignoreList = bigExplosion.ignoreList,
		ss = bigExplosion.ss,
		damageRadius = 2.5f,
		damageToPlayer = 0f,
		doDamage = true,
		damage = 50f,
		doDestroyProjectiles = true,
		doForce = true,
		debrisForce = 30f,
		preventPlayerForce = true,
		explosionDelay = 0.1f,
		usesComprehensiveDelay = false,
		doScreenShake = true,
		playDefaultSFX = true
	};

	public static void Add()
	{
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_010e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0221: Unknown result type (might be due to invalid IL or missing references)
		//IL_0247: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Hand Mortar", "handmortar");
		Game.Items.Rename("outdated_gun_mods:hand_mortar", "nn:hand_mortar");
		((Component)val).gameObject.AddComponent<HandMortar>();
		GunExt.SetShortDescription((PickupObject)(object)val, "Kingdom Come");
		GunExt.SetLongDescription((PickupObject)(object)val, "The classy and classical predecessor to the modern grenade launchers, some old grenadiers still swear by their effectiveness.");
		val.SetGunSprites("handmortar");
		GunExt.SetAnimationFPS(val, val.shootAnimation, 15);
		PickupObject byId = PickupObjectDatabase.GetById(86);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId is Gun) ? byId : null), true, false);
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.shootStyle = (ShootStyle)0;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 2f;
		val.DefaultModule.angleVariance = 10f;
		val.DefaultModule.cooldownTime = 1f;
		val.DefaultModule.numberOfShotsInClip = 3;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(2.81f, 1f, 0f);
		val.SetBaseMaxAmmo(70);
		val.gunClass = (GunClass)45;
		Projectile val2 = Object.Instantiate<Projectile>(val.DefaultModule.projectiles[0]);
		((Component)val2).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val2).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val2);
		val.DefaultModule.projectiles[0] = val2;
		ProjectileData baseData = val2.baseData;
		baseData.damage *= 6f;
		BounceProjModifier orAddComponent = GameObjectExtensions.GetOrAddComponent<BounceProjModifier>(((Component)val2).gameObject);
		orAddComponent.numberOfBounces = 2;
		ExplosiveModifier val3 = ((Component)val2).gameObject.AddComponent<ExplosiveModifier>();
		val3.doExplosion = true;
		val3.explosionData = HandMortarExplosion;
		ProjectileData baseData2 = val2.baseData;
		baseData2.speed *= 0.6f;
		ProjectileData baseData3 = val2.baseData;
		baseData3.range *= 0.8f;
		((BraveBehaviour)val2).transform.parent = val.barrelOffset;
		val2.SetProjectileSprite("handmortar_projectile", 8, 8, lightened: false, (Anchor)4, 8, 8, anchorChangesCollider: true, fixesScale: false, null, null);
		val.DefaultModule.ammoType = (AmmoType)14;
		val.DefaultModule.customAmmoType = CustomClipAmmoTypeToolbox.AddCustomAmmoType("HandMortar Bullets", "NevernamedsItems/Resources/CustomGunAmmoTypes/handmortar_clipfull", "NevernamedsItems/Resources/CustomGunAmmoTypes/handmortar_clipempty");
		((PickupObject)val).quality = (ItemQuality)4;
		((BraveBehaviour)val).encounterTrackable.EncounterGuid = "this is the Hand Mortar";
		Databases.Items.Add(val, (tk2dSpriteCollectionData)null, "ANY");
		ID = ((PickupObject)val).PickupObjectId;
	}

	public override void PostProcessProjectile(Projectile projectile)
	{
		((GunBehaviour)this).PostProcessProjectile(projectile);
		GameActor owner = projectile.Owner;
		PlayerController val = (PlayerController)(object)((owner is PlayerController) ? owner : null);
		if (CustomSynergies.PlayerHasActiveSynergy(val, "Good Old Guns"))
		{
			ProjectileData baseData = projectile.baseData;
			baseData.damage *= 1.5f;
			ProjectileData baseData2 = projectile.baseData;
			baseData2.range *= 3f;
		}
		if (CustomSynergies.PlayerHasActiveSynergy(val, "The Classics"))
		{
			ExplosiveModifier component = ((Component)projectile).gameObject.GetComponent<ExplosiveModifier>();
			if (Object.op_Implicit((Object)(object)component))
			{
				ExplosionData explosionData = component.explosionData;
				explosionData.damageRadius *= 2f;
			}
		}
	}

	public override void OnPostFired(PlayerController player, Gun gun)
	{
		gun.PreventNormalFireAudio = true;
		AkSoundEngine.PostEvent("Play_WPN_seriouscannon_shot_01", ((Component)this).gameObject);
	}
}
