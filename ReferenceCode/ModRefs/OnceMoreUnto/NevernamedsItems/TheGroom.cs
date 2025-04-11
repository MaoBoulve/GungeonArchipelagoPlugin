using Alexandria.Assetbundle;
using Alexandria.ItemAPI;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class TheGroom : GunBehaviour
{
	public static int TheGroomID;

	public static void Add()
	{
		//IL_00d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0266: Unknown result type (might be due to invalid IL or missing references)
		//IL_0297: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_02cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d3: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("The Groom", "thegroom");
		Game.Items.Rename("outdated_gun_mods:the_groom", "nn:the_groom");
		((Component)val).gameObject.AddComponent<TheGroom>();
		GunExt.SetShortDescription((PickupObject)(object)val, "Thin As A Broom");
		GunExt.SetLongDescription((PickupObject)(object)val, "Despite it's heart's longing, this gun missed it's wedding day. Now it roams the halls of the Gungeon, searching for it's bride.");
		GunInt.SetupSprite(val, Initialisation.gunCollection, "thegroom_idle_001", 8, "thegroom_ammonomicon_001");
		GunExt.SetAnimationFPS(val, val.shootAnimation, 13);
		GunExt.SetAnimationFPS(val, val.idleAnimation, 5);
		for (int i = 0; i < 6; i++)
		{
			PickupObject byId = PickupObjectDatabase.GetById(86);
			GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId is Gun) ? byId : null), true, false);
		}
		int num = 0;
		foreach (ProjectileModule projectile in val.Volley.projectiles)
		{
			projectile.ammoCost = 1;
			projectile.shootStyle = (ShootStyle)0;
			projectile.sequenceStyle = (ProjectileSequenceStyle)0;
			projectile.cooldownTime = 0.5f;
			projectile.angleVariance = 11.25f;
			projectile.numberOfShotsInClip = 7;
			Projectile val2 = Object.Instantiate<Projectile>(projectile.projectiles[0]);
			projectile.projectiles[0] = val2;
			((Component)val2).gameObject.SetActive(false);
			FakePrefab.MarkAsFakePrefab(((Component)val2).gameObject);
			Object.DontDestroyOnLoad((Object)(object)val2);
			val2.baseData.range = 25f;
			val2.baseData.damage = 8f;
			val2.hitEffects.alwaysUseMidair = true;
			val2.hitEffects.overrideMidairDeathVFX = SharedVFX.ColouredPoofGrey;
			GunTools.SetProjectileSpriteRight(val2, "groom_projectile", 12, 12, true, (Anchor)4, (int?)10, (int?)10, true, false, (int?)null, (int?)null, (Projectile)null);
			if (num == 0 || num == 1 || num == 2)
			{
				projectile.angleFromAim = 22.5f;
			}
			else if (num == 3 || num == 4 || num == 5)
			{
				projectile.angleFromAim = -22.5f;
			}
			num++;
			if (projectile != val.DefaultModule)
			{
				projectile.ammoCost = 0;
			}
			((BraveBehaviour)val2).transform.parent = val.barrelOffset;
		}
		val.DefaultModule.ammoType = (AmmoType)14;
		val.DefaultModule.customAmmoType = CustomClipAmmoTypeToolbox.AddCustomAmmoType("Groom Bullets", "NevernamedsItems/Resources/CustomGunAmmoTypes/groom_clipfull", "NevernamedsItems/Resources/CustomGunAmmoTypes/groom_clipempty");
		val.reloadTime = 1.5f;
		val.gunHandedness = (GunHandedness)1;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(2.56f, 0.68f, 0f);
		val.SetBaseMaxAmmo(100);
		val.gunClass = (GunClass)5;
		((PickupObject)val).quality = (ItemQuality)3;
		Databases.Items.Add(val, (tk2dSpriteCollectionData)null, "ANY");
		val.Volley.UsesShotgunStyleVelocityRandomizer = true;
		TheGroomID = ((PickupObject)val).PickupObjectId;
	}
}
