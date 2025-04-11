using Alexandria.BreakableAPI;
using Alexandria.ItemAPI;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class Sweeper : AdvancedGunBehavior
{
	public static int ID;

	public static void Add()
	{
		//IL_0101: Unknown result type (might be due to invalid IL or missing references)
		//IL_0109: Unknown result type (might be due to invalid IL or missing references)
		//IL_0550: Unknown result type (might be due to invalid IL or missing references)
		//IL_0566: Unknown result type (might be due to invalid IL or missing references)
		//IL_058f: Unknown result type (might be due to invalid IL or missing references)
		//IL_05e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0603: Unknown result type (might be due to invalid IL or missing references)
		//IL_04c8: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Sweeper", "sweeper");
		Game.Items.Rename("outdated_gun_mods:sweeper", "nn:sweeper");
		Sweeper sweeper = ((Component)val).gameObject.AddComponent<Sweeper>();
		GunExt.SetShortDescription((PickupObject)(object)val, "B)");
		GunExt.SetLongDescription((PickupObject)(object)val, "Used for clearing minefields with it's forceful blast.\n\nThe numbers, what do they mean!?");
		val.SetGunSprites("sweeper");
		GunExt.SetAnimationFPS(val, val.shootAnimation, 13);
		GunExt.SetAnimationFPS(val, val.idleAnimation, 5);
		ref string gunSwitchGroup = ref val.gunSwitchGroup;
		PickupObject byId = PickupObjectDatabase.GetById(51);
		gunSwitchGroup = ((Gun)((byId is Gun) ? byId : null)).gunSwitchGroup;
		ref VFXPool muzzleFlashEffects = ref val.muzzleFlashEffects;
		PickupObject byId2 = PickupObjectDatabase.GetById(38);
		muzzleFlashEffects = ((Gun)((byId2 is Gun) ? byId2 : null)).muzzleFlashEffects;
		for (int i = 0; i < 4; i++)
		{
			PickupObject byId3 = PickupObjectDatabase.GetById(86);
			GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId3 is Gun) ? byId3 : null), true, false);
		}
		int num = 1;
		foreach (ProjectileModule projectile in val.Volley.projectiles)
		{
			projectile.ammoCost = 1;
			projectile.shootStyle = (ShootStyle)0;
			projectile.sequenceStyle = (ProjectileSequenceStyle)0;
			projectile.cooldownTime = 0.5f;
			projectile.angleVariance = 20f;
			projectile.numberOfShotsInClip = 8;
			projectile.projectiles.Clear();
			if (num != 1)
			{
				int num2 = 1;
				for (int j = 0; j < 8; j++)
				{
					Projectile val2 = ProjectileSetupUtility.MakeProjectile(86, num2, 15f, 23f);
					val2.hitEffects.alwaysUseMidair = true;
					switch (num2)
					{
					case 1:
						GunTools.SetProjectileSpriteRight(val2, "sweeper_1", 6, 10, false, (Anchor)4, (int?)4, (int?)8, true, false, (int?)null, (int?)null, (Projectile)null);
						val2.hitEffects.overrideMidairDeathVFX = SharedVFX.ColouredPoofBlue;
						break;
					case 2:
						GunTools.SetProjectileSpriteRight(val2, "sweeper_2", 7, 10, false, (Anchor)4, (int?)5, (int?)8, true, false, (int?)null, (int?)null, (Projectile)null);
						val2.hitEffects.overrideMidairDeathVFX = SharedVFX.ColouredPoofGreen;
						break;
					case 3:
						GunTools.SetProjectileSpriteRight(val2, "sweeper_3", 7, 10, false, (Anchor)4, (int?)5, (int?)8, true, false, (int?)null, (int?)null, (Projectile)null);
						val2.hitEffects.overrideMidairDeathVFX = SharedVFX.ColouredPoofRed;
						break;
					case 4:
						GunTools.SetProjectileSpriteRight(val2, "sweeper_4", 7, 10, false, (Anchor)4, (int?)5, (int?)8, true, false, (int?)null, (int?)null, (Projectile)null);
						val2.hitEffects.overrideMidairDeathVFX = SharedVFX.ColouredPoofBlue;
						break;
					case 5:
						GunTools.SetProjectileSpriteRight(val2, "sweeper_5", 7, 10, false, (Anchor)4, (int?)5, (int?)8, true, false, (int?)null, (int?)null, (Projectile)null);
						val2.hitEffects.overrideMidairDeathVFX = SharedVFX.ColouredPoofRed;
						break;
					case 6:
						GunTools.SetProjectileSpriteRight(val2, "sweeper_6", 7, 10, false, (Anchor)4, (int?)5, (int?)8, true, false, (int?)null, (int?)null, (Projectile)null);
						val2.hitEffects.overrideMidairDeathVFX = SharedVFX.ColouredPoofCyan;
						break;
					case 7:
						GunTools.SetProjectileSpriteRight(val2, "sweeper_7", 7, 10, false, (Anchor)4, (int?)5, (int?)8, true, false, (int?)null, (int?)null, (Projectile)null);
						val2.hitEffects.overrideMidairDeathVFX = SharedVFX.ColouredPoofGrey;
						break;
					case 8:
						GunTools.SetProjectileSpriteRight(val2, "sweeper_8", 7, 10, false, (Anchor)4, (int?)5, (int?)8, true, false, (int?)null, (int?)null, (Projectile)null);
						val2.hitEffects.overrideMidairDeathVFX = SharedVFX.ColouredPoofGrey;
						break;
					}
					projectile.projectiles.Add(val2);
					num2++;
				}
			}
			else
			{
				Projectile val3 = ProjectileSetupUtility.MakeProjectile(86, 9f, 10f, 18f);
				GunTools.SetProjectileSpriteRight(val3, "sweeper_bomb", 13, 13, false, (Anchor)4, (int?)11, (int?)11, true, false, (int?)null, (int?)null, (Projectile)null);
				ExplosiveModifier orAddComponent = GameObjectExtensions.GetOrAddComponent<ExplosiveModifier>(((Component)val3).gameObject);
				orAddComponent.doExplosion = true;
				orAddComponent.explosionData = StaticExplosionDatas.explosiveRoundsExplosion;
				projectile.projectiles.Add(val3);
			}
			val.DefaultModule.ammoType = (AmmoType)14;
			val.DefaultModule.customAmmoType = CustomClipAmmoTypeToolbox.AddCustomAmmoType("Sweeper Bullets", "NevernamedsItems/Resources/CustomGunAmmoTypes/sweeper_clipfull", "NevernamedsItems/Resources/CustomGunAmmoTypes/sweeper_clipempty");
			if (projectile != val.DefaultModule)
			{
				projectile.ammoCost = 0;
			}
			num++;
		}
		val.reloadTime = 1.4f;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(1.5625f, 0.6875f, 0f);
		val.SetBaseMaxAmmo(80);
		val.gunClass = (GunClass)5;
		((Component)((Component)val).gameObject.transform.Find("Clip")).transform.position = new Vector3(0.375f, 0.5625f);
		val.clipObject = ((Component)BreakableAPIToolbox.GenerateDebrisObject("NevernamedsItems/Resources/Debris/sweeper_clip.png", true, 1f, 5f, 60f, 20f, (tk2dSprite)null, 1f, (string)null, (GameObject)null, 1, false, (GoopDefinition)null, 1f)).gameObject;
		val.reloadClipLaunchFrame = 3;
		val.clipsToLaunchOnReload = 1;
		((PickupObject)val).quality = (ItemQuality)3;
		Databases.Items.Add(val, (tk2dSpriteCollectionData)null, "ANY");
		val.DefaultModule.ammoType = (AmmoType)14;
		val.Volley.UsesShotgunStyleVelocityRandomizer = true;
		ID = ((PickupObject)val).PickupObjectId;
	}
}
