using Alexandria.ItemAPI;
using Gungeon;
using SaveAPI;
using UnityEngine;

namespace NevernamedsItems;

public class Rheinmetole : GunBehaviour
{
	public static int ID;

	public static void Add()
	{
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_011e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0138: Unknown result type (might be due to invalid IL or missing references)
		//IL_0166: Unknown result type (might be due to invalid IL or missing references)
		//IL_017d: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01da: Unknown result type (might be due to invalid IL or missing references)
		//IL_0224: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Rheinmetole", "rheinmetole");
		Game.Items.Rename("outdated_gun_mods:rheinmetole", "nn:rheinmetole");
		((Component)val).gameObject.AddComponent<Rheinmetole>();
		GunExt.SetShortDescription((PickupObject)(object)val, "Auf wiedersehen");
		GunExt.SetLongDescription((PickupObject)(object)val, "This monster of a weapon is made out of exlusively 100% melted down and reforged gunmetal, so that it might absorb the fighting spirit of all the guns that came before it.\n\nIt is, quite frankly, excessive.");
		val.SetGunSprites("rheinmetole");
		GunExt.SetAnimationFPS(val, val.shootAnimation, 20);
		GunExt.SetAnimationFPS(val, val.reloadAnimation, 0);
		val.usesContinuousFireAnimation = true;
		((Component)val).GetComponent<tk2dSpriteAnimator>().GetClipByName(val.shootAnimation).wrapMode = (WrapMode)1;
		((Component)val).GetComponent<tk2dSpriteAnimator>().GetClipByName(val.shootAnimation).loopStart = 0;
		PickupObject byId = PickupObjectDatabase.GetById(86);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId is Gun) ? byId : null), true, false);
		ref string gunSwitchGroup = ref val.gunSwitchGroup;
		PickupObject byId2 = PickupObjectDatabase.GetById(153);
		gunSwitchGroup = ((Gun)((byId2 is Gun) ? byId2 : null)).gunSwitchGroup;
		ref VFXPool muzzleFlashEffects = ref val.muzzleFlashEffects;
		PickupObject byId3 = PickupObjectDatabase.GetById(157);
		muzzleFlashEffects = ((Gun)((byId3 is Gun) ? byId3 : null)).muzzleFlashEffects;
		val.reloadTime = 2f;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(2.75f, 0.875f, 0f);
		val.SetBaseMaxAmmo(1000);
		val.gunClass = (GunClass)10;
		val.Volley.projectiles[0].ammoCost = 1;
		val.Volley.projectiles[0].shootStyle = (ShootStyle)1;
		val.Volley.projectiles[0].sequenceStyle = (ProjectileSequenceStyle)0;
		val.Volley.projectiles[0].cooldownTime = 0.07f;
		val.Volley.projectiles[0].numberOfShotsInClip = 100;
		val.Volley.projectiles[0].positionOffset = new Vector3(0.48f, 0f, 0f);
		PickupObject byId4 = PickupObjectDatabase.GetById(329);
		Projectile projectile = ((Gun)((byId4 is Gun) ? byId4 : null)).DefaultModule.chargeProjectiles[1].Projectile;
		val.Volley.projectiles[0].projectiles[0] = projectile;
		((PickupObject)val).quality = (ItemQuality)5;
		Databases.Items.Add(val, (tk2dSpriteCollectionData)null, "ANY");
		((PickupObject)(object)val).SetupUnlockOnCustomFlag(CustomDungeonFlags.PURCHASED_RHEINMETOLE, requiredFlagValue: true);
		((PickupObject)(object)val).AddItemToTrorcMetaShop(100, null);
		ItemBuilder.AddToSubShop((PickupObject)(object)val, (ShopType)3, 1f);
		ID = ((PickupObject)val).PickupObjectId;
	}

	public override void PostProcessProjectile(Projectile projectile)
	{
		base.gun.DefaultModule.positionOffset.x *= -1f;
		((GunBehaviour)this).PostProcessProjectile(projectile);
	}
}
