using System.Collections.Generic;
using Alexandria.ItemAPI;
using Alexandria.Misc;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class FungoCannon : AdvancedGunBehavior
{
	public static int FungoCannonID;

	public static void Add()
	{
		//IL_008c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0208: Expected O, but got Unknown
		//IL_0243: Unknown result type (might be due to invalid IL or missing references)
		//IL_0280: Unknown result type (might be due to invalid IL or missing references)
		//IL_0297: Unknown result type (might be due to invalid IL or missing references)
		//IL_031f: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Fungo Cannon", "fungocannon");
		Game.Items.Rename("outdated_gun_mods:fungo_cannon", "nn:fungo_cannon");
		FungoCannon fungoCannon = ((Component)val).gameObject.AddComponent<FungoCannon>();
		((AdvancedGunBehavior)fungoCannon).preventNormalFireAudio = true;
		((AdvancedGunBehavior)fungoCannon).preventNormalReloadAudio = true;
		GunExt.SetShortDescription((PickupObject)(object)val, "PLOOMPH");
		GunExt.SetLongDescription((PickupObject)(object)val, "A mutated fungun from the Oubliette.\n\nThough horrific genetic anomalies have stripped it of it's face and legs, it still retains it's deadly spores.");
		val.SetGunSprites("fungocannon");
		GunExt.SetAnimationFPS(val, val.shootAnimation, 12);
		GunExt.SetAnimationFPS(val, val.chargeAnimation, 6);
		val.gunClass = (GunClass)60;
		for (int i = 0; i < 20; i++)
		{
			PickupObject byId = PickupObjectDatabase.GetById(86);
			GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId is Gun) ? byId : null), true, false);
		}
		foreach (ProjectileModule projectile in val.Volley.projectiles)
		{
			projectile.ammoCost = 1;
			projectile.shootStyle = (ShootStyle)3;
			projectile.sequenceStyle = (ProjectileSequenceStyle)0;
			projectile.cooldownTime = 1f;
			projectile.angleVariance = 360f;
			projectile.numberOfShotsInClip = 5;
			Projectile val2 = Object.Instantiate<Projectile>(projectile.projectiles[0]);
			projectile.projectiles[0] = val2;
			((Component)val2).gameObject.SetActive(false);
			FakePrefab.MarkAsFakePrefab(((Component)val2).gameObject);
			Object.DontDestroyOnLoad((Object)(object)val2);
			val2.SetProjectileSprite("enemystylespore_projectile", 14, 14, lightened: true, (Anchor)4, 14, 14, anchorChangesCollider: true, fixesScale: false, null, null);
			FungoRandomBullets orAddComponent = GameObjectExtensions.GetOrAddComponent<FungoRandomBullets>(((Component)val2).gameObject);
			ProjectileData baseData = val2.baseData;
			baseData.speed *= 0.2f;
			ProjectileData baseData2 = val2.baseData;
			baseData2.damage *= 2f;
			if (projectile != val.DefaultModule)
			{
				projectile.ammoCost = 0;
			}
			ChargeProjectile item = new ChargeProjectile
			{
				Projectile = val2,
				ChargeTime = 0.5f
			};
			projectile.chargeProjectiles = new List<ChargeProjectile> { item };
		}
		val.DefaultModule.ammoType = (AmmoType)14;
		val.DefaultModule.customAmmoType = CustomClipAmmoTypeToolbox.AddCustomAmmoType("FungoCannon Bullets", "NevernamedsItems/Resources/CustomGunAmmoTypes/fungocannon_clipfull", "NevernamedsItems/Resources/CustomGunAmmoTypes/fungocannon_clipempty");
		val.reloadTime = 1.4f;
		val.SetBaseMaxAmmo(200);
		((PickupObject)val).quality = (ItemQuality)2;
		((Component)val).GetComponent<tk2dSpriteAnimator>().GetClipByName(val.chargeAnimation).wrapMode = (WrapMode)1;
		((Component)val).GetComponent<tk2dSpriteAnimator>().GetClipByName(val.chargeAnimation).loopStart = 1;
		((Component)val).GetComponent<tk2dSpriteAnimator>().GetClipByName(val.shootAnimation).frames[0].eventAudio = "Play_ENM_mushroom_cloud_01";
		((Component)val).GetComponent<tk2dSpriteAnimator>().GetClipByName(val.shootAnimation).frames[0].triggerEvent = true;
		Databases.Items.Add((PickupObject)(object)val, false, "ANY");
		((Component)val.barrelOffset).transform.localPosition = new Vector3(1.56f, 0.62f, 0f);
		FungoCannonID = ((PickupObject)val).PickupObjectId;
	}

	public override void PostProcessProjectile(Projectile projectile)
	{
		if (projectile.Owner is PlayerController)
		{
			GameActor owner = projectile.Owner;
			PlayerController val = (PlayerController)(object)((owner is PlayerController) ? owner : null);
			if ((Object)(object)val != (Object)null)
			{
				if (CustomSynergies.PlayerHasActiveSynergy(val, "Hunter Spores"))
				{
					FungoRandomBullets component = ((Component)projectile).GetComponent<FungoRandomBullets>();
					if ((Object)(object)component != (Object)null)
					{
						component.HasSynergyHunterSpores = true;
					}
				}
				if (CustomSynergies.PlayerHasActiveSynergy(val, "Myshellium"))
				{
					ProjectileData baseData = projectile.baseData;
					baseData.damage *= 2f;
				}
			}
		}
		((AdvancedGunBehavior)this).PostProcessProjectile(projectile);
	}

	public override void OnPostFired(PlayerController player, Gun gun)
	{
		if (CustomSynergies.PlayerHasActiveSynergy(player, "Enspore!"))
		{
			int pickupObjectId = Game.Items["nn:spore_launcher"].PickupObjectId;
			if (player.HasPickupID(pickupObjectId) && (double)Random.value <= 0.45)
			{
				PlayerUtility.GiveAmmoToGunNotInHand(player, pickupObjectId, 1);
			}
		}
		((AdvancedGunBehavior)this).OnPostFired(player, gun);
	}
}
