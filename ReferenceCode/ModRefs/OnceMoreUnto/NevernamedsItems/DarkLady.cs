using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class DarkLady : GunBehaviour
{
	public static int ID;

	public static void Add()
	{
		//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d2: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Dark Lady", "darklady");
		Game.Items.Rename("outdated_gun_mods:dark_lady", "nn:dark_lady");
		DarkLady darkLady = ((Component)val).gameObject.AddComponent<DarkLady>();
		GunExt.SetShortDescription((PickupObject)(object)val, "Two-Stage Mechanism");
		GunExt.SetLongDescription((PickupObject)(object)val, "Uncooperative. Half of the bullets it fires seem to have a mind of their own.\n\nAn infamous firearm.");
		val.SetGunSprites("darklady", 8, noAmmonomicon: false, 2);
		ref string gunSwitchGroup = ref val.gunSwitchGroup;
		PickupObject byId = PickupObjectDatabase.GetById(30);
		gunSwitchGroup = ((Gun)((byId is Gun) ? byId : null)).gunSwitchGroup;
		ref VFXPool muzzleFlashEffects = ref val.muzzleFlashEffects;
		PickupObject byId2 = PickupObjectDatabase.GetById(30);
		muzzleFlashEffects = ((Gun)((byId2 is Gun) ? byId2 : null)).muzzleFlashEffects;
		for (int i = 0; i < 2; i++)
		{
			PickupObject byId3 = PickupObjectDatabase.GetById(15);
			GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId3 is Gun) ? byId3 : null), true, false);
		}
		foreach (ProjectileModule projectile in val.Volley.projectiles)
		{
			projectile.ammoCost = 1;
			projectile.shootStyle = (ShootStyle)0;
			projectile.sequenceStyle = (ProjectileSequenceStyle)0;
			projectile.cooldownTime = 0.3f;
			projectile.angleVariance = 7f;
			projectile.numberOfShotsInClip = 6;
			Projectile val2 = ProjectileSetupUtility.MakeProjectile(15, 7f);
			projectile.projectiles[0] = val2;
			if (projectile != val.DefaultModule)
			{
				projectile.ammoCost = 0;
				SelfReAimBehaviour orAddComponent = GameObjectExtensions.GetOrAddComponent<SelfReAimBehaviour>(((Component)val2).gameObject);
				orAddComponent.trigger = SelfReAimBehaviour.ReAimTrigger.IMMEDIATE;
			}
			else
			{
				ProjectileData baseData = val2.baseData;
				baseData.speed *= 1.3f;
			}
		}
		val.reloadTime = 0.85f;
		val.SetBarrel(31, 20);
		val.SetBaseMaxAmmo(130);
		val.gunClass = (GunClass)1;
		((PickupObject)val).quality = (ItemQuality)3;
		Databases.Items.Add((PickupObject)(object)val, false, "ANY");
		val.AddClipSprites("redbullets");
		ID = ((PickupObject)val).PickupObjectId;
	}
}
