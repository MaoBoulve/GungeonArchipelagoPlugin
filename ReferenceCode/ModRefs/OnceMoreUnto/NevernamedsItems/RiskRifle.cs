using Alexandria.ItemAPI;
using Gungeon;
using SaveAPI;
using UnityEngine;

namespace NevernamedsItems;

public class RiskRifle : GunBehaviour
{
	public static int RiskRifleID;

	public static void Add()
	{
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_010d: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ce: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Risk Rifle", "riskrifle");
		Game.Items.Rename("outdated_gun_mods:risk_rifle", "nn:risk_rifle");
		((Component)val).gameObject.AddComponent<RiskRifle>();
		GunExt.SetShortDescription((PickupObject)(object)val, "Danger Zone");
		GunExt.SetLongDescription((PickupObject)(object)val, "A strong rifle with one notable drawback; it harms it's owner upon emptying a clip. Be very careful to reload before then.\n\n");
		val.SetGunSprites("riskrifle");
		GunExt.SetAnimationFPS(val, val.shootAnimation, 17);
		PickupObject byId = PickupObjectDatabase.GetById(56);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId is Gun) ? byId : null), true, false);
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.shootStyle = (ShootStyle)1;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 2f;
		val.DefaultModule.cooldownTime = 0.04f;
		val.DefaultModule.numberOfShotsInClip = 40;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(2.25f, 0.5f, 0f);
		val.SetBaseMaxAmmo(400);
		val.ammo = 400;
		val.gunClass = (GunClass)10;
		Projectile val2 = Object.Instantiate<Projectile>(val.DefaultModule.projectiles[0]);
		((Component)val2).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val2).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val2);
		val.DefaultModule.projectiles[0] = val2;
		val2.SetProjectileSprite("riskrifle_projectile", 6, 4, lightened: true, (Anchor)4, 6, 4, anchorChangesCollider: true, fixesScale: false, null, null);
		((BraveBehaviour)val2).transform.parent = val.barrelOffset;
		val.DefaultModule.ammoType = (AmmoType)14;
		val.DefaultModule.customAmmoType = CustomClipAmmoTypeToolbox.AddCustomAmmoType("Risk Rifle Bullets", "NevernamedsItems/Resources/CustomGunAmmoTypes/riskrifle_clipfull", "NevernamedsItems/Resources/CustomGunAmmoTypes/riskrifle_clipempty");
		((PickupObject)val).quality = (ItemQuality)2;
		((BraveBehaviour)val).encounterTrackable.EncounterGuid = "this is the Risk Rifle";
		Databases.Items.Add(val, (tk2dSpriteCollectionData)null, "ANY");
		RiskRifleID = ((PickupObject)val).PickupObjectId;
		((PickupObject)(object)val).SetupUnlockOnCustomFlag(CustomDungeonFlags.PURCHASED_RISKRIFLE, requiredFlagValue: true);
	}

	public override void PostProcessProjectile(Projectile projectile)
	{
		if (projectile.Owner is PlayerController)
		{
			GameActor owner = projectile.Owner;
			PlayerController val = (PlayerController)(object)((owner is PlayerController) ? owner : null);
			if (CustomSynergies.PlayerHasActiveSynergy(val, "Double Risk, Double Reward"))
			{
				ProjectileData baseData = projectile.baseData;
				baseData.damage *= 2f;
			}
			((GunBehaviour)this).PostProcessProjectile(projectile);
		}
	}

	public override void OnPostFired(PlayerController player, Gun gun)
	{
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		if (gun.ClipShotsRemaining != 0 || CustomSynergies.PlayerHasActiveSynergy(player, "Zero Risk"))
		{
			return;
		}
		if (CustomSynergies.PlayerHasActiveSynergy(player, "Double Risk, Double Reward"))
		{
			((BraveBehaviour)player).healthHaver.ApplyDamage(1f, Vector2.zero, "Very Risky Business", (CoreDamageTypes)0, (DamageCategory)0, true, (PixelCollider)null, false);
			return;
		}
		((BraveBehaviour)player).healthHaver.ApplyDamage(0.5f, Vector2.zero, "Risky Business", (CoreDamageTypes)0, (DamageCategory)0, true, (PixelCollider)null, false);
		if (!SaveAPIManager.GetFlag(CustomDungeonFlags.HASBEENDAMAGEDBYRISKRIFLE))
		{
			SaveAPIManager.SetFlag(CustomDungeonFlags.HASBEENDAMAGEDBYRISKRIFLE, value: true);
		}
	}
}
