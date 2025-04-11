using Alexandria.ItemAPI;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class SquarePeg : GunBehaviour
{
	public static int ID;

	public static void Add()
	{
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0101: Unknown result type (might be due to invalid IL or missing references)
		//IL_011a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0206: Unknown result type (might be due to invalid IL or missing references)
		//IL_022c: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Square Peg", "squarepeg");
		Game.Items.Rename("outdated_gun_mods:square_peg", "nn:square_peg");
		((Component)val).gameObject.AddComponent<SquarePeg>();
		GunExt.SetShortDescription((PickupObject)(object)val, "In A Round Chamber");
		GunExt.SetLongDescription((PickupObject)(object)val, "[] A perfect example of the art of cubism.");
		val.SetGunSprites("squarepeg");
		GunExt.SetAnimationFPS(val, val.shootAnimation, 15);
		PickupObject byId = PickupObjectDatabase.GetById(86);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId is Gun) ? byId : null), true, false);
		ref string gunSwitchGroup = ref val.gunSwitchGroup;
		PickupObject byId2 = PickupObjectDatabase.GetById(475);
		gunSwitchGroup = ((Gun)((byId2 is Gun) ? byId2 : null)).gunSwitchGroup;
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.shootStyle = (ShootStyle)0;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 1f;
		val.DefaultModule.cooldownTime = 0.12f;
		val.DefaultModule.numberOfShotsInClip = 6;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(1.625f, 0.875f, 0f);
		val.SetBaseMaxAmmo(150);
		val.gunClass = (GunClass)1;
		val.muzzleFlashEffects = VFXToolbox.CreateVFXPoolBundle("SquarePegMuzzle", usesZHeight: false, 0f, (VFXAlignment)0, -1f, null);
		Projectile val2 = Object.Instantiate<Projectile>(val.DefaultModule.projectiles[0]);
		((Component)val2).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val2).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val2);
		val.DefaultModule.projectiles[0] = val2;
		((BraveBehaviour)val2).transform.parent = val.barrelOffset;
		val2.baseData.damage = 8f;
		val2.hitEffects.overrideMidairDeathVFX = SharedVFX.SquarePegImpact;
		val2.hitEffects.alwaysUseMidair = true;
		GunTools.SetProjectileSpriteRight(val2, "squarepeg_proj", 8, 8, false, (Anchor)4, (int?)8, (int?)8, true, false, (int?)null, (int?)null, (Projectile)null);
		val.DefaultModule.ammoType = (AmmoType)14;
		val.DefaultModule.customAmmoType = CustomClipAmmoTypeToolbox.AddCustomAmmoType("SquarePegSquares", "NevernamedsItems/Resources/CustomGunAmmoTypes/squarepeg_clipfull", "NevernamedsItems/Resources/CustomGunAmmoTypes/squarepeg_clipempty");
		((PickupObject)val).quality = (ItemQuality)2;
		Databases.Items.Add(val, (tk2dSpriteCollectionData)null, "ANY");
		ID = ((PickupObject)val).PickupObjectId;
	}
}
