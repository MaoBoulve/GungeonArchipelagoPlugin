using Alexandria.ItemAPI;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class GunsharkMegasharkSynergyForme : GunBehaviour
{
	public static int GunsharkMegasharkSynergyFormeID;

	public static void Add()
	{
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_01db: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Megashark", "gunshark_megasharkforme");
		Game.Items.Rename("outdated_gun_mods:megashark", "nn:gunshark+megashark");
		((Component)val).gameObject.AddComponent<Gunshark>();
		GunExt.SetShortDescription((PickupObject)(object)val, "Completely Awesomer");
		GunExt.SetLongDescription((PickupObject)(object)val, "Big shark gun go brr.\n\nIf you're reading this, you're a cheatsy haxor.");
		val.SetGunSprites("gunshark_megasharkforme", 8, noAmmonomicon: true);
		GunExt.SetAnimationFPS(val, val.shootAnimation, 17);
		PickupObject byId = PickupObjectDatabase.GetById(56);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId is Gun) ? byId : null), true, false);
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.shootStyle = (ShootStyle)1;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 2f;
		val.DefaultModule.cooldownTime = 0.04f;
		val.DefaultModule.numberOfShotsInClip = 200;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(3.12f, 0.68f, 0f);
		val.SetBaseMaxAmmo(3996);
		val.ammo = 3996;
		Projectile val2 = Object.Instantiate<Projectile>(val.DefaultModule.projectiles[0]);
		((Component)val2).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val2).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val2);
		val.DefaultModule.projectiles[0] = val2;
		ProjectileData baseData = val2.baseData;
		baseData.damage *= 1.25f;
		val2.ignoreDamageCaps = true;
		ProjectileData baseData2 = val2.baseData;
		baseData2.speed *= 3f;
		val2.pierceMinorBreakables = true;
		GunTools.SetProjectileSpriteRight(val2, "gunshark_projectile", 17, 4, true, (Anchor)4, (int?)17, (int?)4, true, false, (int?)null, (int?)null, (Projectile)null);
		((BraveBehaviour)val2).transform.parent = val.barrelOffset;
		((PickupObject)val).quality = (ItemQuality)(-100);
		((BraveBehaviour)val).encounterTrackable.EncounterGuid = "this is the Gunshark Megashark Synergy Form";
		Databases.Items.Add(val, (tk2dSpriteCollectionData)null, "ANY");
		GunsharkMegasharkSynergyFormeID = ((PickupObject)val).PickupObjectId;
		GunExt.SetName((PickupObject)(object)val, "Gunshark");
	}

	public override void PostProcessProjectile(Projectile projectile)
	{
		((GunBehaviour)this).PostProcessProjectile(projectile);
	}

	public override void OnPostFired(PlayerController player, Gun gun)
	{
	}
}
