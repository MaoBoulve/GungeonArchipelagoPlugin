using Alexandria.Assetbundle;
using Alexandria.ItemAPI;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class ClownShotgun : AdvancedGunBehavior
{
	public static int ClownShotgunID;

	public static void Add()
	{
		//IL_0144: Unknown result type (might be due to invalid IL or missing references)
		//IL_014c: Unknown result type (might be due to invalid IL or missing references)
		//IL_025a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0273: Unknown result type (might be due to invalid IL or missing references)
		//IL_027a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0299: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Clown Shotgun", "clownshotgun");
		Game.Items.Rename("outdated_gun_mods:clown_shotgun", "nn:clown_shotgun");
		ClownShotgun clownShotgun = ((Component)val).gameObject.AddComponent<ClownShotgun>();
		((AdvancedGunBehavior)clownShotgun).preventNormalFireAudio = true;
		((AdvancedGunBehavior)clownShotgun).overrideNormalFireAudio = "Play_ClownHonk";
		GunExt.SetShortDescription((PickupObject)(object)val, "Honk Honk");
		GunExt.SetLongDescription((PickupObject)(object)val, "Filled to an excessive degree with bouncing shells. Once belonged to a real, genuine, pure-bred clown.\n\nAn essential tool in any clown's arsenal, along with a cute little car, a hula hoop, and space lubricant.");
		GunInt.SetupSprite(val, Initialisation.gunCollection, "clownshotgun_idle_001", 8, "clownshotgun_ammonomicon_001");
		GunExt.SetAnimationFPS(val, val.shootAnimation, 13);
		GunExt.SetAnimationFPS(val, val.idleAnimation, 5);
		ref string gunSwitchGroup = ref val.gunSwitchGroup;
		PickupObject byId = PickupObjectDatabase.GetById(519);
		gunSwitchGroup = ((Gun)((byId is Gun) ? byId : null)).gunSwitchGroup;
		for (int i = 0; i < 9; i++)
		{
			PickupObject byId2 = PickupObjectDatabase.GetById(86);
			GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId2 is Gun) ? byId2 : null), true, false);
		}
		((Component)val).GetComponent<tk2dSpriteAnimator>().GetClipByName(val.shootAnimation).frames[0].eventAudio = "Play_ClownHonk";
		((Component)val).GetComponent<tk2dSpriteAnimator>().GetClipByName(val.shootAnimation).frames[0].triggerEvent = true;
		foreach (ProjectileModule projectile in val.Volley.projectiles)
		{
			projectile.ammoCost = 1;
			projectile.shootStyle = (ShootStyle)0;
			projectile.sequenceStyle = (ProjectileSequenceStyle)0;
			projectile.cooldownTime = 0.8f;
			projectile.angleVariance = 40f;
			projectile.numberOfShotsInClip = 40;
			Projectile val2 = Object.Instantiate<Projectile>(projectile.projectiles[0]);
			projectile.projectiles[0] = val2;
			((Component)val2).gameObject.SetActive(false);
			FakePrefab.MarkAsFakePrefab(((Component)val2).gameObject);
			Object.DontDestroyOnLoad((Object)(object)val2);
			ProjectileData baseData = val2.baseData;
			baseData.range *= 10f;
			BounceProjModifier orAddComponent = GameObjectExtensions.GetOrAddComponent<BounceProjModifier>(((Component)val2).gameObject);
			orAddComponent.numberOfBounces = 1;
			if (projectile != val.DefaultModule)
			{
				projectile.ammoCost = 0;
			}
			((BraveBehaviour)val2).transform.parent = val.barrelOffset;
		}
		val.reloadTime = 1.5f;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(1.68f, 0.62f, 0f);
		val.SetBaseMaxAmmo(200);
		val.gunClass = (GunClass)5;
		((PickupObject)val).quality = (ItemQuality)2;
		Databases.Items.Add((PickupObject)(object)val, false, "ANY");
		val.DefaultModule.ammoType = (AmmoType)14;
		val.DefaultModule.customAmmoType = CustomClipAmmoTypeToolbox.AddCustomAmmoType("Clown Shotgun Shells", "NevernamedsItems/Resources/CustomGunAmmoTypes/clownshotgun_clipfull", "NevernamedsItems/Resources/CustomGunAmmoTypes/clownshotgun_clipempty");
		val.Volley.UsesShotgunStyleVelocityRandomizer = true;
		ClownShotgunID = ((PickupObject)val).PickupObjectId;
	}

	protected override void Update()
	{
		if (Object.op_Implicit((Object)(object)base.gun) && Object.op_Implicit((Object)(object)GunTools.GunPlayerOwner(base.gun)))
		{
			GameActor currentOwner = base.gun.CurrentOwner;
			PlayerController val = (PlayerController)(object)((currentOwner is PlayerController) ? currentOwner : null);
			if (CustomSynergies.PlayerHasActiveSynergy(val, "Clown Town"))
			{
				if (base.gun.DefaultModule.angleVariance == 40f)
				{
					foreach (ProjectileModule projectile in base.gun.Volley.projectiles)
					{
						projectile.angleVariance = 10f;
					}
				}
			}
			else if (base.gun.DefaultModule.angleVariance == 10f)
			{
				foreach (ProjectileModule projectile2 in base.gun.Volley.projectiles)
				{
					projectile2.angleVariance = 40f;
				}
			}
		}
		((AdvancedGunBehavior)this).Update();
	}
}
